Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmTipoPrestamos

    Private ReadOnly _servicio As New TipoPrestamoService()

    Private Const TituloSistema As String = "Sistema de Crédito"
    Private Const FormatoTasa As String = "##,##0.0000000000"
    Private Const DiasPorAnio As Decimal = 365D
    Private Const MesesPorAnio As Decimal = 12D

    'Evita que TxtInteresAnual_TextChanged recalcule mientras se cargan valores guardados
    Private _cargandoRegistro As Boolean = False

#Region "Eventos del formulario"

    Private Sub FrmTipoPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargarModalidades()
            CargarTiposPrestamo()
        Catch ex As Exception
            MostrarError("No se pudieron cargar los catálogos.", ex)
        End Try
    End Sub

    Private Sub CboCodigoLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoLinea.TextChanged
        Try
            MostrarTipoPrestamo(Me.CboCodigoLinea.Text.Trim())
        Catch ex As Exception
            MostrarError("No se pudo consultar el tipo de préstamo.", ex)
        End Try
    End Sub

    Private Sub TxtInteresAnual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInteresAnual.TextChanged
        If _cargandoRegistro Then Exit Sub

        Dim interesAnual As Decimal = ObtenerDecimal(Me.TxtInteresAnual.Text)
        Me.TxtInteresMensual.Text = Format(interesAnual / MesesPorAnio, FormatoTasa)
        Me.TxtInteresDiario.Text = Format(interesAnual / DiasPorAnio, FormatoTasa)
    End Sub

    Private Sub ChkInteresUnico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInteresUnico.CheckedChanged
        AplicarModoInteresUnico(Me.ChkInteresUnico.Checked)
    End Sub

#End Region

#Region "Botones"

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        If Not ValidarDatos() Then Exit Sub

        Try
            Dim codigo As String = Me.CboCodigoLinea.Text.Trim()
            Dim codModalidad As String = Me.CboCodigoModalidad.Columns(0).Text

            If ExisteTipoPrestamo(codigo) Then
                ActualizarTipoPrestamo(codigo, codModalidad)
            Else
                InsertarTipoPrestamo(codigo, codModalidad)
            End If

            CargarTiposPrestamo()
            Me.CboCodigoLinea.Text = ""
            MsgBox("Tipo de préstamo guardado correctamente.", MsgBoxStyle.Information, TituloSistema)

        Catch ex As Exception
            MostrarError("No se pudo guardar el tipo de préstamo.", ex)
        End Try
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Dim codigo As String = Me.CboCodigoLinea.Text.Trim()

        If codigo = "" Then
            MsgBox("Seleccione el tipo de préstamo que desea eliminar.", MsgBoxStyle.Exclamation, TituloSistema)
            Exit Sub
        End If

        Try
            If Not ExisteTipoPrestamo(codigo) Then
                MsgBox("El tipo de préstamo " & codigo & " no existe.", MsgBoxStyle.Exclamation, TituloSistema)
                Exit Sub
            End If

            If MsgBox("¿Desea eliminar el tipo de préstamo " & codigo & "?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question, TituloSistema) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            EjecutarComando("DELETE FROM TipoPrestamo WHERE CodTipoPrestamo = @Codigo",
                            New SqlParameter("@Codigo", codigo))

            CargarTiposPrestamo()
            Me.CboCodigoLinea.Text = ""
            MsgBox("Tipo de préstamo eliminado.", MsgBoxStyle.Information, TituloSistema)

        Catch ex As SqlException When ex.Number = 547
            'Violación de llave foránea: hay registros que usan este tipo de préstamo
            MsgBox("No se puede eliminar: existen préstamos registrados con este tipo.",
                   MsgBoxStyle.Exclamation, TituloSistema)
        Catch ex As Exception
            MostrarError("No se pudo eliminar el tipo de préstamo.", ex)
        End Try
    End Sub

    Private Sub CmdBuscarModalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscarModalidad.Click
        Quien = "CodigoModalidad"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoModalidad.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

#End Region

#Region "Carga y presentación de datos"

    Private Sub CargarModalidades()

        Dim tabla As DataTable = _servicio.ObtenerModalidades()

        Me.CboCodigoModalidad.DataSource = Nothing
        Me.CboCodigoModalidad.DataSource = tabla

    End Sub

    Private Sub CargarTiposPrestamo()

        Dim tabla As DataTable = _servicio.ObtenerTiposPrestamo()

        Me.CboCodigoLinea.DataSource = Nothing
        Me.CboCodigoLinea.DataSource = tabla

    End Sub

    Private Sub MostrarTipoPrestamo(ByVal codigo As String)

        If String.IsNullOrWhiteSpace(codigo) Then
            LimpiarCampos()
            Return
        End If

        Dim prestamo As TipoPrestamo =
        _servicio.ObtenerPorCodigo(codigo)

        If prestamo Is Nothing Then
            LimpiarCampos()
            Return
        End If

        _cargandoRegistro = True

        Try

            Me.TxtNombre.Text = prestamo.Nombre
            Me.TxtInteresAnual.Text = prestamo.InteresAnual.ToString()
            Me.TxtInteresMensual.Text = prestamo.InteresMensual.ToString()
            Me.TxtInteresDiario.Text = prestamo.InteresDiario.ToString()
            Me.TxtInteresMora.Text = prestamo.InteresMora.ToString()
            Me.TxtInteresDeslizamiento.Text =
            prestamo.InteresDeslizamiento.ToString()

            Me.TxtMaximoCuotas.Value = prestamo.MaxCuotas
            Me.TxtCantidadPrestamos.Value = prestamo.CantPrestamos

        Finally
            _cargandoRegistro = False
        End Try

        MostrarModalidad(prestamo.CodModalidad)

    End Sub
    Private Sub MostrarModalidad(ByVal codModalidad As String)
        Dim tabla As DataTable = ConsultarTabla("SELECT Modalidad FROM dbo.Modalidades WHERE CodModalidad = @CodModalidad",
                                                New SqlParameter("@CodModalidad", codModalidad))
        If tabla.Rows.Count > 0 Then
            Me.CboCodigoModalidad.Text = TextoDe(tabla.Rows(0)("Modalidad"))
        Else
            Me.CboCodigoModalidad.Text = ""
        End If
    End Sub

    Private Sub LimpiarCampos()
        _cargandoRegistro = True
        Try
            Me.TxtNombre.Text = ""
            Me.TxtInteresAnual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresDiario.Text = ""
            Me.TxtInteresMora.Text = ""
            Me.TxtInteresDeslizamiento.Text = ""
            Me.TxtMaximoCuotas.Value = 0
            Me.TxtCantidadPrestamos.Value = 0
        Finally
            _cargandoRegistro = False
        End Try
    End Sub

    Private Sub AplicarModoInteresUnico(ByVal esInteresUnico As Boolean)
        _cargandoRegistro = True
        Try
            Me.TxtInteresAnual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresDiario.Text = ""
            Me.TxtInteresDeslizamiento.Text = ""
            Me.TxtInteresMora.Text = ""
        Finally
            _cargandoRegistro = False
        End Try

        Me.TxtInteresAnual.Enabled = Not esInteresUnico
        Me.TxtInteresMensual.Enabled = Not esInteresUnico
        Me.TxtInteresDiario.Enabled = Not esInteresUnico
        Me.TxtInteresMora.Enabled = Not esInteresUnico
        Me.TxtInteresDeslizamiento.Enabled = Not esInteresUnico
        Me.TxtMaximoCuotas.Enabled = Not esInteresUnico
        Me.TxtMaximoCuotas.Value = 1

        Me.TxtInteresUnico.Enabled = esInteresUnico
        If Not esInteresUnico Then Me.TxtInteresUnico.Text = ""
    End Sub

#End Region

#Region "Validación y guardado"

    Private Function ValidarDatos() As Boolean
        If Me.CboCodigoLinea.Text.Trim() = "" Then
            Return AvisarYEnfocar("Se necesita el código del tipo de crédito.", Me.CboCodigoLinea)
        End If

        If Me.TxtNombre.Text.Trim() = "" Then
            Return AvisarYEnfocar("Se necesita el nombre del tipo de crédito.", Me.TxtNombre)
        End If

        If Me.CboCodigoModalidad.Text.Trim() = "" Then
            Return AvisarYEnfocar("Se necesita el tipo de modalidad.", Me.CboCodigoModalidad)
        End If

        Dim camposTasa() As TextBox = {Me.TxtInteresAnual, Me.TxtInteresMensual, Me.TxtInteresDiario,
                                       Me.TxtInteresMora, Me.TxtInteresDeslizamiento}
        For Each campo As TextBox In camposTasa
            If Not EsDecimalValido(campo.Text) Then
                Return AvisarYEnfocar("El valor ingresado no es un número válido.", campo)
            End If
        Next

        Return True
    End Function

    Private Function AvisarYEnfocar(ByVal mensaje As String, ByVal control As Control) As Boolean
        MsgBox(mensaje, MsgBoxStyle.Critical, TituloSistema)
        control.Focus()
        Return False
    End Function

    Private Function ExisteTipoPrestamo(ByVal codigo As String) As Boolean
        Dim tabla As DataTable = ConsultarTabla("SELECT CodTipoPrestamo FROM TipoPrestamo WHERE CodTipoPrestamo = @Codigo",
                                                New SqlParameter("@Codigo", codigo))
        Return tabla.Rows.Count > 0
    End Function

    Private Sub InsertarTipoPrestamo(ByVal codigo As String, ByVal codModalidad As String)
        Dim sql As String = "INSERT INTO TipoPrestamo " &
            "(CodTipoPrestamo, TipoPrestamo, InteresAnual, InteresMensual, InteresDiario, InteresMora, " &
            " InteresDeslizamiento, MaxCuotas, CantPrestamos, CodModalidad) " &
            "VALUES (@Codigo, @Nombre, @InteresAnual, @InteresMensual, @InteresDiario, @InteresMora, " &
            " @InteresDeslizamiento, @MaxCuotas, @CantPrestamos, @CodModalidad)"

        EjecutarComando(sql, ParametrosTipoPrestamo(codigo, codModalidad))
    End Sub

    Private Sub ActualizarTipoPrestamo(ByVal codigo As String, ByVal codModalidad As String)
        Dim sql As String = "UPDATE TipoPrestamo SET " &
            "TipoPrestamo = @Nombre, InteresAnual = @InteresAnual, InteresMensual = @InteresMensual, " &
            "InteresDiario = @InteresDiario, InteresMora = @InteresMora, InteresDeslizamiento = @InteresDeslizamiento, " &
            "MaxCuotas = @MaxCuotas, CantPrestamos = @CantPrestamos, CodModalidad = @CodModalidad " &
            "WHERE CodTipoPrestamo = @Codigo"

        EjecutarComando(sql, ParametrosTipoPrestamo(codigo, codModalidad))
    End Sub

    Private Function ParametrosTipoPrestamo(ByVal codigo As String, ByVal codModalidad As String) As SqlParameter()
        Return New SqlParameter() {
            New SqlParameter("@Codigo", codigo),
            New SqlParameter("@Nombre", Me.TxtNombre.Text.Trim()),
            New SqlParameter("@InteresAnual", ObtenerDecimal(Me.TxtInteresAnual.Text)),
            New SqlParameter("@InteresMensual", ObtenerDecimal(Me.TxtInteresMensual.Text)),
            New SqlParameter("@InteresDiario", ObtenerDecimal(Me.TxtInteresDiario.Text)),
            New SqlParameter("@InteresMora", ObtenerDecimal(Me.TxtInteresMora.Text)),
            New SqlParameter("@InteresDeslizamiento", ObtenerDecimal(Me.TxtInteresDeslizamiento.Text)),
            New SqlParameter("@MaxCuotas", Me.TxtMaximoCuotas.Value),
            New SqlParameter("@CantPrestamos", Me.TxtCantidadPrestamos.Value),
            New SqlParameter("@CodModalidad", codModalidad)}
    End Function

#End Region

#Region "Acceso a datos y utilidades"

    Private Function ConsultarTabla(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable
        Using conexionBD As New SqlConnection(Conexion)
            Using comando As New SqlCommand(sql, conexionBD)
                comando.Parameters.AddRange(parametros)
                Using adaptador As New SqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    Private Function EjecutarComando(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As Integer
        Using conexionBD As New SqlConnection(Conexion)
            Using comando As New SqlCommand(sql, conexionBD)
                comando.Parameters.AddRange(parametros)
                conexionBD.Open()
                Return comando.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Private Function EsDecimalValido(ByVal texto As String) As Boolean
        Dim valor As Decimal
        Return texto.Trim() = "" OrElse
               Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, valor)
    End Function

    Private Function ObtenerDecimal(ByVal texto As String) As Decimal
        Dim valor As Decimal
        If Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, valor) Then
            Return valor
        End If
        Return 0D
    End Function

    Private Function TextoDe(ByVal valor As Object) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return ""
        Return Convert.ToString(valor)
    End Function

    Private Function NumeroDe(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
        Return Convert.ToDecimal(valor)
    End Function

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MsgBox(mensaje & vbCrLf & vbCrLf & "Detalle: " & ex.Message, MsgBoxStyle.Critical, TituloSistema)
    End Sub

    Private Sub PnlAcciones_Paint(sender As Object, e As PaintEventArgs) Handles PnlAcciones.Paint

    End Sub

#End Region

End Class
