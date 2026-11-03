
Public Class FrmVendedor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCuentas.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoVendedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoVendedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub FrmVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Seguridad.Bloqueo(Me, Acceso, "Vendedores")
    End Sub

    Private Sub FrmVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT * FROM Vendedores"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaVendedores")

        End If
        CargarCajeros()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim TipoComision As String = "Recuperacion"
        If Me.OptVentas.Checked = True Then
            TipoComision = "Ventas"
        ElseIf Me.OptGrupoVendedores.Checked = True Then
            TipoComision = "GrupoVendedores"
        ElseIf Me.OptRecuperacionVentas.Checked = True Then
            TipoComision = "RecuperacionVentas"
        End If

        Dim TipoVendedor As String = "Mesero"
        If Me.CboTipo.Text <> "" Then TipoVendedor = Me.CboTipo.Text

        If Me.CboCodigoVendedor.Text.Trim() = "" Then
            MsgBox("Ingrese el código del vendedor.", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
            Me.TabControl1.SelectedTab = Me.TabPage1
            Me.CboCodigoVendedor.Focus()
            Exit Sub
        End If

        If Me.TxtNombre.Text.Trim() = "" Then
            MsgBox("Ingrese el nombre del vendedor.", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
            Me.TabControl1.SelectedTab = Me.TabPage1
            Me.TxtNombre.Focus()
            Exit Sub
        End If

        Dim CodCajero As Object = DBNull.Value
        If Me.CboCajero.SelectedValue IsNot Nothing AndAlso Convert.ToString(Me.CboCajero.SelectedValue) <> "" Then
            CodCajero = Convert.ToString(Me.CboCajero.SelectedValue)
        End If

        Try
            Using cn As New SqlClient.SqlConnection(Conexion)
                cn.Open()

                Dim Existe As Boolean
                Using cmdExiste As New SqlClient.SqlCommand("SELECT COUNT(*) FROM Vendedores WHERE Cod_Vendedor = @Cod", cn)
                    cmdExiste.Parameters.AddWithValue("@Cod", Me.CboCodigoVendedor.Text)
                    Existe = Convert.ToInt32(cmdExiste.ExecuteScalar()) > 0
                End Using

                Dim Sql As String
                If Existe Then
                    Sql = "UPDATE [Vendedores] SET [Nombre_Vendedor] = @Nombre,[Apellido_Vendedor] = @Apellido,[Direccion_Vendedor] = @Direccion,[Telefono_Vendedor] = @Telefono,[Cod_Cuenta_Vendedor] = @Cuenta,[Comision1] = @Comision1,[Comision2] = @Comision2,[Recuperacion1] = @Recuperacion1,[Recuperacion2] = @Recuperacion2,[TipoComision] = @TipoComision,[Tipo] = @Tipo,[CodCajero] = @CodCajero WHERE Cod_Vendedor = @Cod"
                Else
                    Sql = "INSERT INTO [Vendedores] ([Cod_Vendedor],[Nombre_Vendedor],[Apellido_Vendedor],[Direccion_Vendedor],[Telefono_Vendedor],[Cod_Cuenta_Vendedor],[Comision1],[Comision2],[Recuperacion1],[Recuperacion2],[TipoComision],[Tipo],[CodCajero]) " & _
                          "VALUES (@Cod,@Nombre,@Apellido,@Direccion,@Telefono,@Cuenta,@Comision1,@Comision2,@Recuperacion1,@Recuperacion2,@TipoComision,@Tipo,@CodCajero)"
                End If

                Using cmd As New SqlClient.SqlCommand(Sql, cn)
                    cmd.Parameters.AddWithValue("@Cod", Me.CboCodigoVendedor.Text)
                    cmd.Parameters.AddWithValue("@Nombre", Me.TxtNombre.Text)
                    cmd.Parameters.AddWithValue("@Apellido", Me.TxtApellidos.Text)
                    cmd.Parameters.AddWithValue("@Direccion", Me.TxtDireccion.Text)
                    cmd.Parameters.AddWithValue("@Telefono", Me.TxtTelefono.Text)
                    cmd.Parameters.AddWithValue("@Cuenta", Me.TxtCtaxCobrar.Text)
                    cmd.Parameters.AddWithValue("@Comision1", ValorNumerico(Me.TxtComision1.Text))
                    cmd.Parameters.AddWithValue("@Comision2", ValorNumerico(Me.TxtComision2.Text))
                    cmd.Parameters.AddWithValue("@Recuperacion1", ValorNumerico(Me.TxtRecuperacion1.Text))
                    cmd.Parameters.AddWithValue("@Recuperacion2", ValorNumerico(Me.TxtRecuperacion2.Text))
                    cmd.Parameters.AddWithValue("@TipoComision", TipoComision)
                    cmd.Parameters.AddWithValue("@Tipo", TipoVendedor)
                    cmd.Parameters.AddWithValue("@CodCajero", CodCajero)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("No se pudo guardar el vendedor: " & ex.Message, MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End Try

        CargarVendedores()
        Me.CboCodigoVendedor.Text = ""
        MsgBox("Vendedor guardado correctamente.", MsgBoxStyle.Information, "Sistema de Facturacion")

    End Sub

    Private Function ValorNumerico(ByVal Texto As String) As Decimal
        Dim Valor As Decimal
        If Decimal.TryParse(Texto, Valor) Then Return Valor
        Return 0D
    End Function

    Private Sub CargarVendedores()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter("SELECT * FROM Vendedores", MiConexion)
        DataAdapter.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaVendedores")
        End If
    End Sub

    Private Sub CargarCajeros()
        Dim dt As New DataTable("Cajeros")
        Using da As New SqlClient.SqlDataAdapter("SELECT Cod_Cajero, Nombre_Cajero FROM Cajeros ORDER BY Nombre_Cajero", Conexion)
            da.Fill(dt)
        End Using
        Dim fila As DataRow = dt.NewRow()
        fila("Cod_Cajero") = ""
        fila("Nombre_Cajero") = "(Sin cajero)"
        dt.Rows.InsertAt(fila, 0)
        Me.CboCajero.DisplayMember = "Nombre_Cajero"
        Me.CboCajero.ValueMember = "Cod_Cajero"
        Me.CboCajero.DataSource = dt
        Me.CboCajero.SelectedIndex = 0
    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim tc As System.Windows.Forms.TabControl = DirectCast(sender, System.Windows.Forms.TabControl)
        Dim Seleccionada As Boolean = (e.Index = tc.SelectedIndex)
        Dim r As System.Drawing.Rectangle = tc.GetTabRect(e.Index)
        Dim Fondo As System.Drawing.Color = System.Drawing.Color.FromArgb(232, 237, 245)
        Dim Texto As System.Drawing.Color = System.Drawing.Color.FromArgb(71, 85, 105)
        If Seleccionada Then
            Fondo = System.Drawing.Color.White
            Texto = System.Drawing.Color.FromArgb(37, 99, 235)
        End If
        Using b As New System.Drawing.SolidBrush(Fondo)
            e.Graphics.FillRectangle(b, r)
        End Using
        If Seleccionada Then
            Using b As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(37, 99, 235))
                e.Graphics.FillRectangle(b, r.X, r.Y, r.Width, 3)
            End Using
        End If
        System.Windows.Forms.TextRenderer.DrawText(e.Graphics, tc.TabPages(e.Index).Text, tc.Font, r, Texto, System.Windows.Forms.TextFormatFlags.HorizontalCenter Or System.Windows.Forms.TextFormatFlags.VerticalCenter)
    End Sub
    Private Sub CboCodigoVendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoVendedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TipoComision As String
        SqlProveedor = "SELECT  * FROM Vendedores  WHERE (Cod_Vendedor = '" & Me.CboCodigoVendedor.Text.Replace("'", "''") & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            Dim Fila As DataRow = DataSet.Tables("Vendedores").Rows(0)

            Me.TxtNombre.Text = Convert.ToString(Fila("Nombre_Vendedor"))
            If Not IsDBNull(Fila("Apellido_Vendedor")) Then
                Me.TxtApellidos.Text = Convert.ToString(Fila("Apellido_Vendedor"))
            End If
            Me.TxtDireccion.Text = Convert.ToString(Fila("Direccion_Vendedor"))
            Me.TxtTelefono.Text = Convert.ToString(Fila("Telefono_Vendedor"))

            Me.TxtCtaxCobrar.Text = Convert.ToString(Fila("Cod_Cuenta_Vendedor"))

            If Not IsDBNull(Fila("Comision1")) Then
                Me.TxtComision1.Text = Convert.ToString(Fila("Comision1"))
            End If

            If Not IsDBNull(Fila("Comision2")) Then
                Me.TxtComision2.Text = Convert.ToString(Fila("Comision2"))
            End If

            If Not IsDBNull(Fila("Recuperacion1")) Then
                Me.TxtRecuperacion1.Text = Convert.ToString(Fila("Recuperacion1"))
            End If

            If Not IsDBNull(Fila("Recuperacion2")) Then
                Me.TxtRecuperacion2.Text = Convert.ToString(Fila("Recuperacion2"))
            End If

            If Not IsDBNull(Fila("TipoComision")) Then
                TipoComision = Convert.ToString(Fila("TipoComision"))

                If TipoComision = "Recuperacion" Then
                    Me.OptRecuperacion.Checked = True
                ElseIf TipoComision = "Ventas" Then
                    Me.OptVentas.Checked = True
                ElseIf TipoComision = "GrupoVendedores" Then
                    Me.OptGrupoVendedores.Checked = True
                ElseIf TipoComision = "RecuperacionVentas" Then
                    Me.OptRecuperacionVentas.Checked = True
                End If

            End If

            Me.CboTipo.Text = "Mesero"
            If DataSet.Tables("Vendedores").Columns.Contains("Tipo") AndAlso Not IsDBNull(Fila("Tipo")) Then
                Me.CboTipo.Text = Convert.ToString(Fila("Tipo"))
            End If

            If Me.CboCajero.Items.Count > 0 Then Me.CboCajero.SelectedIndex = 0
            If DataSet.Tables("Vendedores").Columns.Contains("CodCajero") AndAlso Not IsDBNull(Fila("CodCajero")) Then
                Me.CboCajero.SelectedValue = Convert.ToString(Fila("CodCajero"))
                If Me.CboCajero.SelectedIndex < 0 Then Me.CboCajero.SelectedIndex = 0
            End If
        Else

            Me.CboTipo.Text = "Mesero"
            If Me.CboCajero.Items.Count > 0 Then Me.CboCajero.SelectedIndex = 0
            Me.TxtRecuperacion1.Text = "0"
            Me.TxtRecuperacion2.Text = "0"
            Me.TxtComision1.Text = "0"
            Me.TxtComision2.Text = "0"
            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtCtaxCobrar.Text = ""

        End If
    End Sub
    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Vendedores.* FROM Vendedores WHERE (Cod_Vendedor = '" & Me.CboCodigoVendedor.Text & "') ORDER BY Cod_Vendedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Vendedores] WHERE (Cod_Vendedor = '" & Me.CboCodigoVendedor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Vendedores.* FROM Vendedores"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaVendedores")
        End If

        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub OptVentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptVentas.CheckedChanged
        Me.TxtComision1.Text = 0
        Me.TxtComision2.Text = 0
        Me.TxtRecuperacion1.Text = 0
        Me.TxtRecuperacion2.Text = 0

    End Sub

    Private Sub OptGrupoVendedores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptGrupoVendedores.CheckedChanged
        Me.TxtComision1.Text = 0
        Me.TxtComision2.Text = 0
        Me.TxtRecuperacion1.Text = 0
        Me.TxtRecuperacion2.Text = 0
    End Sub

    Private Sub OptRecuperacionVentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRecuperacionVentas.CheckedChanged
        Me.TxtComision1.Text = 0
        Me.TxtComision2.Text = 0
        Me.TxtRecuperacion1.Text = 0
        Me.TxtRecuperacion2.Text = 0
    End Sub

    Private Sub OptRecuperacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRecuperacion.CheckedChanged
        Me.TxtComision1.Text = 0
        Me.TxtComision2.Text = 0
        Me.TxtRecuperacion1.Text = 0
        Me.TxtRecuperacion2.Text = 0
    End Sub
End Class