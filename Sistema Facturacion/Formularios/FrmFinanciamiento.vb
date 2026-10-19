Imports System.Data.SqlClient

Public Class FrmFinanciamiento

    Private Const TITULO As String = "Sistema de Facturación"

    ' Paleta para los mensajes de estado
    Private Shared ReadOnly ColorNeutro As Color = Color.FromArgb(100, 116, 139)
    Private Shared ReadOnly ColorInfo As Color = Color.FromArgb(37, 99, 235)
    Private Shared ReadOnly ColorExito As Color = Color.FromArgb(22, 163, 74)

    Private _cargando As Boolean = False      ' Evita eventos mientras se llena el combo
    Private _codigoActual As String = Nothing ' Último código mostrado
    Private _existe As Boolean = False        ' La fuente mostrada ya existe en BD

#Region "Eventos del formulario"

    Private Sub FrmFinanciamiento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ConfigurarIconos()
        Try
            CargarFuentes()
        Catch ex As Exception
            MostrarError("No se pudieron cargar las fuentes.", ex)
        End Try
        Limpiar()
    End Sub

    ' Atajos: Ctrl+S guardar, Ctrl+N nuevo, F3 buscar, Esc salir (CancelButton)
    Private Sub FrmFinanciamiento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            e.SuppressKeyPress = True
            Guardar()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            e.SuppressKeyPress = True
            Limpiar()
        ElseIf e.KeyCode = Keys.F3 Then
            e.SuppressKeyPress = True
            Buscar()
        End If
    End Sub

#End Region

#Region "Eventos de controles"

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.Click
        Limpiar()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CboCodigo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CboCodigo.SelectedIndexChanged
        If _cargando OrElse CboCodigo.SelectedIndex < 0 Then Exit Sub
        MostrarFuente(Convert.ToString(CboCodigo.SelectedValue))
    End Sub

    ' Se consulta al salir del combo, no en cada tecla (antes: TextChanged)
    Private Sub CboCodigo_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles CboCodigo.Validated
        MostrarFuente(CboCodigo.Text)
    End Sub

    Private Sub CboCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles CboCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TxtNombre.Focus()
        End If
    End Sub

#End Region

#Region "Lógica del formulario"

    Private Sub Limpiar()
        _cargando = True
        Try
            CboCodigo.SelectedIndex = -1
            CboCodigo.Text = ""
        Finally
            _cargando = False
        End Try
        TxtNombre.Text = ""
        _codigoActual = ""
        EstablecerModo(False)
        CboCodigo.Focus()
    End Sub

    Private Sub MostrarFuente(ByVal codigo As String)
        codigo = Convert.ToString(codigo).Trim()
        If codigo = _codigoActual Then Exit Sub ' No pisar cambios del usuario
        _codigoActual = codigo

        If codigo = "" Then
            TxtNombre.Text = ""
            EstablecerModo(False)
            Exit Sub
        End If

        Try
            Dim nombre As String = ObtenerNombreFuente(codigo)
            If nombre Is Nothing Then
                TxtNombre.Text = ""
                EstablecerModo(False)
            Else
                TxtNombre.Text = nombre
                EstablecerModo(True)
            End If
        Catch ex As Exception
            MostrarError("No se pudo consultar la fuente.", ex)
        End Try
    End Sub

    Private Sub Guardar()
        Dim codigo As String = CboCodigo.Text.Trim()
        Dim nombre As String = TxtNombre.Text.Trim()

        If codigo = "" Then
            Advertir("Se necesita el código de la fuente.", CboCodigo)
            Exit Sub
        End If
        If nombre = "" Then
            Advertir("Se necesita el nombre de la fuente.", TxtNombre)
            Exit Sub
        End If

        Try
            Dim esNueva As Boolean = GuardarFuente(codigo, nombre)
            CargarFuentes()
            Limpiar()
            If esNueva Then
                MostrarEstado("Fuente " & codigo & " agregada correctamente.", ColorExito)
            Else
                MostrarEstado("Fuente " & codigo & " actualizada correctamente.", ColorExito)
            End If
        Catch ex As Exception
            MostrarError("No se pudo guardar la fuente.", ex)
        End Try
    End Sub

    Private Sub Eliminar()
        Dim codigo As String = CboCodigo.Text.Trim()
        If codigo = "" OrElse Not _existe Then
            Advertir("Seleccione una fuente existente para eliminarla.", CboCodigo)
            Exit Sub
        End If

        Dim pregunta As String = "¿Está seguro de eliminar la fuente " & codigo & " - " & TxtNombre.Text.Trim() & "?"
        If MessageBox.Show(pregunta, TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                           MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            EliminarFuente(codigo)
            CargarFuentes()
            Limpiar()
            MostrarEstado("Fuente " & codigo & " eliminada.", ColorExito)
        Catch ex As SqlException When ex.Number = 547
            MessageBox.Show("No se puede eliminar la fuente porque tiene registros asociados.", _
                            TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MostrarError("No se pudo eliminar la fuente.", ex)
        End Try
    End Sub

    Private Sub Buscar()
        Quien = "CodigoFinanciamiento"
        My.Forms.FrmConsultas.ShowDialog()

        Dim codigo As String = Convert.ToString(My.Forms.FrmConsultas.Codigo).Trim()
        If codigo = "" Then Exit Sub ' El usuario canceló la búsqueda

        CboCodigo.Text = codigo
        MostrarFuente(codigo)
        TxtNombre.Focus()
    End Sub

#End Region

#Region "Acceso a datos"

    Private Sub CargarFuentes()
        Dim tabla As New DataTable()
        Using da As New SqlDataAdapter("SELECT CodigoFuente, DescripcionFuente FROM dbo.FuentesFinanciamiento ORDER BY CodigoFuente", Conexion)
            da.Fill(tabla)
        End Using

        _cargando = True
        Try
            CboCodigo.DisplayMember = "CodigoFuente"
            CboCodigo.ValueMember = "CodigoFuente"
            CboCodigo.DataSource = tabla
            CboCodigo.SelectedIndex = -1
        Finally
            _cargando = False
        End Try
    End Sub

    ''' <summary>Devuelve el nombre, o Nothing si la fuente no existe.</summary>
    Private Function ObtenerNombreFuente(ByVal codigo As String) As String
        Dim resultado As Object = EjecutarEscalar(
            "SELECT DescripcionFuente FROM dbo.FuentesFinanciamiento WHERE CodigoFuente = @Codigo",
            New SqlParameter("@Codigo", codigo))

        If resultado Is Nothing Then Return Nothing
        If resultado Is DBNull.Value Then Return ""
        Return CStr(resultado)
    End Function

    ''' <summary>Inserta o actualiza. Devuelve True si fue un registro nuevo.</summary>
    Private Function GuardarFuente(ByVal codigo As String, ByVal nombre As String) As Boolean
        Const SQL As String =
            "IF EXISTS (SELECT 1 FROM dbo.FuentesFinanciamiento WHERE CodigoFuente = @Codigo) " &
            "BEGIN " &
            "   UPDATE dbo.FuentesFinanciamiento SET DescripcionFuente = @Nombre WHERE CodigoFuente = @Codigo; " &
            "   SELECT 0; " &
            "END " &
            "ELSE " &
            "BEGIN " &
            "   INSERT INTO dbo.FuentesFinanciamiento (CodigoFuente, DescripcionFuente) VALUES (@Codigo, @Nombre); " &
            "   SELECT 1; " &
            "END"

        Dim resultado As Object = EjecutarEscalar(SQL, _
            New SqlParameter("@Codigo", codigo), _
            New SqlParameter("@Nombre", nombre))

        Return Convert.ToInt32(resultado) = 1
    End Function

    Private Sub EliminarFuente(ByVal codigo As String)
        EjecutarComando("DELETE FROM dbo.FuentesFinanciamiento WHERE CodigoFuente = @Codigo",
                        New SqlParameter("@Codigo", codigo))
    End Sub

    Private Function EjecutarEscalar(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As Object
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddRange(parametros)
                cn.Open()
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Private Function EjecutarComando(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As Integer
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddRange(parametros)
                cn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

#End Region

#Region "Interfaz"

    Private Sub EstablecerModo(ByVal existe As Boolean)
        _existe = existe
        BtnEliminar.Enabled = existe

        If CboCodigo.Text.Trim() = "" Then
            MostrarEstado("Escriba un código o presione F3 para buscar.", ColorNeutro)
        ElseIf existe Then
            MostrarEstado("Editando fuente existente.", ColorInfo)
        Else
            MostrarEstado("Nueva fuente: se agregará al guardar.", ColorExito)
        End If
    End Sub

    Private Sub MostrarEstado(ByVal mensaje As String, ByVal color As Color)
        LblEstado.ForeColor = color
        LblEstado.Text = mensaje
    End Sub

    Private Sub Advertir(ByVal mensaje As String, ByVal control As Control)
        MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        control.Focus()
    End Sub

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & vbCrLf & vbCrLf & "Detalle: " & ex.Message, _
                        TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ConfigurarIconos()
        ' Lupa con la fuente de íconos de Windows 10/11; si no existe, se deja "..."
        Dim fuenteIconos As String = Nothing
        If FuenteDisponible("Segoe Fluent Icons") Then
            fuenteIconos = "Segoe Fluent Icons"
        ElseIf FuenteDisponible("Segoe MDL2 Assets") Then
            fuenteIconos = "Segoe MDL2 Assets"
        End If

        If fuenteIconos IsNot Nothing Then
            BtnBuscar.Font = New Font(fuenteIconos, 11.0!)
            BtnBuscar.Text = ChrW(&HE721)
        End If

        ToolTip1.SetToolTip(BtnBuscar, "Buscar fuente (F3)")
        ToolTip1.SetToolTip(BtnGuardar, "Guardar (Ctrl+S)")
        ToolTip1.SetToolTip(BtnNuevo, "Nuevo (Ctrl+N)")
        ToolTip1.SetToolTip(BtnSalir, "Salir (Esc)")
    End Sub

    Private Shared Function FuenteDisponible(ByVal nombre As String) As Boolean
        For Each familia As FontFamily In FontFamily.Families
            If String.Equals(familia.Name, nombre, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return False
    End Function

#End Region

End Class
