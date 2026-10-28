Imports System.Data.SqlClient

Public Class FrmClientes

    Private Sub FrmClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Seguridad.Bloqueo(Me, Acceso, "Clientes")
    End Sub

    Private Sub FrmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarClientes()

        Me.CboEndoso.DataSource = ObtenerTabla("SELECT Endoso.* FROM Endoso")
        Me.CboDepartamento.DataSource = ObtenerTabla("SELECT DISTINCT Departamento FROM Clientes")
        CboCodigoVendedor.DataSource = ObtenerTabla("SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores")

        Me.LblCodigo.Text = "Codigo " & NombreCliente
        Me.LblNombre.Text = "Nombre " & NombreCliente
        Me.LblApellido.Text = "Apellido " & NombreCliente
        Me.LblDireccion.Text = "Direccion " & NombreCliente
        Me.LblTitulo.Text = "REGISTRO DE " & UCase(NombreCliente)
        Me.Text = UCase(NombreCliente)
    End Sub

#Region "Acceso a datos"

    ' Cada consulta abre y cierra su propia conexion (Using), asi un error
    ' nunca deja una conexion abierta para la siguiente operacion.
    Private Function ObtenerTabla(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable("Tabla")
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand(sql, cn)
                If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                    cmd.Parameters.AddRange(parametros)
                End If
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    Private Sub CargarClientes()
        Dim sql As String
        If CodigoClienteNumero = True Then
            sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres, REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes"
        End If

        Dim tabla As DataTable = ObtenerTabla(sql)
        If tabla.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.CboCodigoCliente.DataSource = tabla
        If CodigoClienteNumero = True Then
            Me.CboCodigoCliente.Splits.Item(0).DisplayColumns(2).Visible = False
        End If
    End Sub

    Private Function ClienteExiste(ByVal codigo As String) As Boolean
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM Clientes WHERE Cod_Cliente = @Cod", cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)
                cn.Open()
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Private Sub AgregarParametrosCliente(ByVal cmd As SqlCommand)
        With cmd.Parameters
            .AddWithValue("@Cod", Me.CboCodigoCliente.Text)
            .AddWithValue("@Nombre", Me.TxtNombre.Text)
            .AddWithValue("@Apellido", Me.TxtApellidos.Text)
            .AddWithValue("@Direccion", Me.TxtDireccion.Text)
            .AddWithValue("@Telefono", Me.TxtTelefono.Text)
            .AddWithValue("@CtaCliente", Me.TxtCtaxCobrar.Text)
            .AddWithValue("@Limite", Me.TxtLimite.Text)
            .AddWithValue("@RUC", Me.TxtRUC.Text)
            .AddWithValue("@CausaIva", Me.ChkCausaIVA.Checked)
            .AddWithValue("@CreditoDisp", Me.ChkCreditoDisponible.Checked)
            .AddWithValue("@Anio", Me.TxtAño.Text)
            .AddWithValue("@Grado", Me.TxtGrado.Text)
            .AddWithValue("@Turno", Me.CmbTurno.Text)
            .AddWithValue("@Inventario", Me.ChkInventario.Checked)
            .AddWithValue("@DiasCredito", Me.TxtDiasCredito.Value)
            .AddWithValue("@Departamento", Me.CboDepartamento.Text)
            .AddWithValue("@Municipio", Me.CboMunicipio.Text)
            .AddWithValue("@Endoso", Me.CboEndoso.Text)
            .AddWithValue("@Activo", Me.ChkActivo.Checked)
            .AddWithValue("@Efectivo", Me.ChkEfectivo.Checked)
            .AddWithValue("@Cedula", Me.TxtCedula.Text)
            .AddWithValue("@Estado", Me.CmbEstado.Text)
            .AddWithValue("@Vendedor", Me.CboCodigoVendedor.Text)
            .AddWithValue("@Moneda", Me.CboMonedaFactura.Text)
            .AddWithValue("@BloqueoLimite", Me.ChkBloqueoLimite.Checked)
            .AddWithValue("@Foto", FotoParaGuardar())
        End With
    End Sub

    Private Sub GuardarCliente(ByVal existe As Boolean)
        Dim sql As String
        If existe Then
            sql = "UPDATE [Clientes] SET [Nombre_Cliente] = @Nombre, [Apellido_Cliente] = @Apellido, [Direccion_Cliente] = @Direccion, [Telefono] = @Telefono, " & _
                  "[Cod_Cuenta_Cliente] = @CtaCliente, [Limite_Credito] = @Limite, [RUC] = @RUC, [CausaIva] = @CausaIva, [Credito_Disponible] = @CreditoDisp, " & _
                  "[Año] = @Anio, [Grado] = @Grado, [Turno] = @Turno, [InventarioFisico] = @Inventario, [DiasCredito] = @DiasCredito, [Departamento] = @Departamento, " & _
                  "[Municipio] = @Municipio, [Endoso] = @Endoso, [Activo] = @Activo, [Efectivo] = @Efectivo, [Cedula] = @Cedula, [Estado] = @Estado, " & _
                  "[CodVendedor] = @Vendedor, [MonedaCredito] = @Moneda, [BloquearPorLimiteCredito] = @BloqueoLimite, [Foto] = @Foto " & _
                  "WHERE (Cod_Cliente = @Cod)"
        Else
            sql = "INSERT INTO [Clientes] ([Cod_Cliente],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono],[Cod_Cuenta_Cliente],[Año],[Grado],[Turno]," & _
                  "[InventarioFisico],[RUC],[Limite_Credito],[DiasCredito],[Departamento],[Municipio],[Endoso],[Activo],[Efectivo],[Cedula],[Estado],[CodVendedor]," & _
                  "[CausaIva],[MonedaCredito],[BloquearPorLimiteCredito],[Foto]) " & _
                  "VALUES (@Cod,@Nombre,@Apellido,@Direccion,@Telefono,@CtaCliente,@Anio,@Grado,@Turno,@Inventario,@RUC,@Limite,@DiasCredito,@Departamento,@Municipio," & _
                  "@Endoso,@Activo,@Efectivo,@Cedula,@Estado,@Vendedor,@CausaIva,@Moneda,@BloqueoLimite,@Foto)"
        End If

        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand(sql, cn)
                AgregarParametrosCliente(cmd)
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub EliminarCliente(ByVal codigo As String)
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand("DELETE FROM [Clientes] WHERE (Cod_Cliente = @Cod)", cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

#End Region

#Region "Botones"

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoCliente.Text = ""
        Me.ImgFotoCliente.Image = Nothing
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        If Me.TxtRUC.Text <> "" Then
            Me.TxtApellidos.Text = "RUC #" & Me.TxtRUC.Text
        End If

        If Trim(Me.CboCodigoCliente.Text) = "" Then
            MsgBox("Se necesito Codigo de Cliente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        GuardarCliente(ClienteExiste(Me.CboCodigoCliente.Text))

        Bitacora(Now, NombreUsuario, "Clientes", "Grabo el cliente: " & Me.TxtNombre.Text)
        CargarClientes()
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        If MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion") <> MsgBoxResult.Ok Then
            Exit Sub
        End If

        If Trim(Me.CboCodigoCliente.Text) = "" Then
            Exit Sub
        End If

        EliminarCliente(Me.CboCodigoCliente.Text)

        Bitacora(Now, NombreUsuario, "Clientes", "Borro el cliente: " & Me.TxtNombre.Text)
        CargarClientes()
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdCargarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCargarFoto.Click
        If Me.OpenFileDialogFoto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.ImgFotoCliente.Image = CambiarTamañoImagenMesa(Image.FromFile(Me.OpenFileDialogFoto.FileName))
        End If
    End Sub

    Private Sub CmdBorrarFotoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarFotoCliente.Click
        Me.ImgFotoCliente.Image = Nothing
    End Sub

#End Region

#Region "Carga de datos en pantalla"

    Private Sub CboCodigoCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim tabla As DataTable = ObtenerTabla("SELECT * FROM Clientes WHERE (Cod_Cliente = @Cod)", New SqlParameter("@Cod", Me.CboCodigoCliente.Text))

        Me.ImgFotoCliente.Image = Nothing
        If tabla.Rows.Count = 0 Then
            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtCtaxCobrar.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtCedula.Text = ""
            Me.CmbEstado.Text = ""

            Me.ChkCausaIVA.Checked = True
            Me.ChkActivo.Checked = True
            Exit Sub
        End If

        Dim fila As DataRow = tabla.Rows(0)
        CargarFotoCliente(fila)

        AsignarTexto(Me.CboMonedaFactura, fila, "MonedaCredito")
        AsignarTexto(Me.TxtAño, fila, "Año")
        AsignarTexto(Me.TxtGrado, fila, "Grado")
        AsignarTexto(Me.CmbTurno, fila, "Turno")
        AsignarTexto(Me.TxtNombre, fila, "Nombre_Cliente")
        AsignarTexto(Me.TxtApellidos, fila, "Apellido_Cliente")
        AsignarTexto(Me.TxtTelefono, fila, "Telefono")
        AsignarTexto(Me.TxtDireccion, fila, "Direccion_Cliente")
        AsignarTexto(Me.TxtCtaxCobrar, fila, "Cod_Cuenta_Cliente")
        AsignarTexto(Me.TxtLimite, fila, "Limite_Credito")
        AsignarTexto(Me.TxtRUC, fila, "RUC")
        AsignarTexto(Me.CboDepartamento, fila, "Departamento")
        AsignarTexto(Me.CboMunicipio, fila, "Municipio")
        AsignarTexto(Me.CboEndoso, fila, "Endoso")
        AsignarTexto(Me.TxtCedula, fila, "Cedula")
        AsignarTexto(Me.CmbEstado, fila, "Estado")
        AsignarTexto(Me.CboCodigoVendedor, fila, "CodVendedor")

        If Not IsDBNull(fila("DiasCredito")) Then
            Me.TxtDiasCredito.Value = CDec(fila("DiasCredito"))
        End If

        AsignarCheck(Me.ChkCausaIVA, fila, "CausaIva", Me.ChkCausaIVA.Checked)
        AsignarCheck(Me.ChkCreditoDisponible, fila, "Credito_Disponible", Me.ChkCreditoDisponible.Checked)
        AsignarCheck(Me.ChkInventario, fila, "InventarioFisico", False)
        AsignarCheck(Me.ChkActivo, fila, "Activo", False)
        AsignarCheck(Me.ChkEfectivo, fila, "Efectivo", False)
        AsignarCheck(Me.ChkBloqueoLimite, fila, "BloquearPorLimiteCredito", False)
    End Sub

    ' Solo asigna cuando la columna trae valor (igual que antes: si es NULL no toca el control).
    Private Sub AsignarTexto(ByVal control As Control, ByVal fila As DataRow, ByVal columna As String)
        If Not IsDBNull(fila(columna)) Then
            control.Text = fila(columna).ToString()
        End If
    End Sub

    Private Sub AsignarCheck(ByVal check As CheckBox, ByVal fila As DataRow, ByVal columna As String, ByVal valorSiNulo As Boolean)
        If IsDBNull(fila(columna)) Then
            check.Checked = valorSiNulo
        Else
            check.Checked = Convert.ToBoolean(fila(columna))
        End If
    End Sub

    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        Me.CboMunicipio.DataSource = ObtenerTabla("SELECT DISTINCT Municipio FROM Clientes WHERE (Departamento LIKE '%' + @Dep)", _
                                                  New SqlParameter("@Dep", Me.CboDepartamento.Text))
    End Sub

    Private Sub CargarFotoCliente(ByVal Fila As DataRow)
        If Fila.Table.Columns.Contains("Foto") AndAlso Not IsDBNull(Fila("Foto")) AndAlso Trim(Fila("Foto").ToString) <> "" Then
            Me.ImgFotoCliente.Image = BytesToImagen(StringtoByte(Fila("Foto").ToString))
        End If
    End Sub

    Private Function FotoParaGuardar() As Object
        If Me.ImgFotoCliente.Image Is Nothing Then
            Return DBNull.Value
        End If
        Return bytesToString(ImagenToBytes(Me.ImgFotoCliente.Image))
    End Function

#End Region

End Class
