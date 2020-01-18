
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
        Bloqueo(Me, Acceso, "Vendedores")
    End Sub

    Private Sub FrmVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT * FROM Vendedores"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaVendedores")

        End If
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim SQLVendedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim TipoComision As String = ""

        If Me.OptRecuperacion.Checked = True Then
            TipoComision = "Recuperacion"
        ElseIf Me.OptVentas.Checked = True Then
            TipoComision = "Ventas"
        ElseIf Me.OptGrupoVendedores.Checked = True Then
            TipoComision = "GrupoVendedores"
        ElseIf Me.OptRecuperacionVentas.Checked = True Then
            TipoComision = "RecuperacionVentas"
        End If



        SQLVendedor = "SELECT TOP (100) PERCENT Vendedores.* FROM Vendedores WHERE (Cod_Vendedor = '" & Me.CboCodigoVendedor.Text & "') ORDER BY Cod_Vendedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLVendedor, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Vendedores] SET [Nombre_Vendedor] = '" & Me.TxtNombre.Text & "',[Apellido_Vendedor] = '" & Me.TxtApellidos.Text & "',[Direccion_Vendedor] = '" & Me.TxtDireccion.Text & "',[Telefono_Vendedor] = '" & Me.TxtTelefono.Text & "',[Cod_Cuenta_Vendedor] = '" & Me.TxtCtaxCobrar.Text & "',[Comision1] = " & Me.TxtComision1.Text & ",[Comision2] = " & Me.TxtComision2.Text & ",[Recuperacion1] = '" & Me.TxtRecuperacion1.Text & "',[Recuperacion2] = '" & Me.TxtRecuperacion2.Text & "',[TipoComision] = '" & TipoComision & "'  WHERE Cod_Vendedor= '" & Me.CboCodigoVendedor.Text & "'"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Vendedores] ([Cod_Vendedor],[Nombre_Vendedor],[Apellido_Vendedor],[Direccion_Vendedor],[Telefono_Vendedor],[Cod_Cuenta_Vendedor],[Comision1],[Comision2],[Recuperacion1],[Recuperacion2],[TipoComision]) " & _
                           "VALUES ('" & Me.CboCodigoVendedor.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellidos.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtComision1.Text & "','" & Me.TxtComision2.Text & "' ,'" & Me.TxtRecuperacion1.Text & "' ,'" & Me.TxtRecuperacion2.Text & "','" & TipoComision & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        SQLVendedor = "SELECT TOP (100) PERCENT dbo.Vendedores.* FROM Vendedores"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLVendedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaVendedores")
        End If

        Me.CboCodigoVendedor.Text = ""

    End Sub

    Private Sub CboCodigoVendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoVendedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TipoComision As String
        SqlProveedor = "SELECT  * FROM Vendedores  WHERE (Cod_Vendedor = '" & Me.CboCodigoVendedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then


            Me.TxtNombre.Text = DataSet.Tables("Vendedores").Rows(0)("Nombre_Vendedor")
            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("Apellido_Vendedor")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Vendedores").Rows(0)("Apellido_Vendedor")
            End If
            Me.TxtDireccion.Text = DataSet.Tables("Vendedores").Rows(0)("Direccion_Vendedor")
            Me.TxtTelefono.Text = DataSet.Tables("Vendedores").Rows(0)("Telefono_Vendedor")

            Me.TxtCtaxCobrar.Text = DataSet.Tables("Vendedores").Rows(0)("Cod_Cuenta_Vendedor")

            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("Comision1")) Then
                Me.TxtComision1.Text = DataSet.Tables("Vendedores").Rows(0)("Comision1")
            End If

            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("Comision2")) Then
                Me.TxtComision2.Text = DataSet.Tables("Vendedores").Rows(0)("Comision2")
            End If

            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("Recuperacion1")) Then
                Me.TxtRecuperacion1.Text = DataSet.Tables("Vendedores").Rows(0)("Recuperacion1")
            End If

            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("Recuperacion2")) Then
                Me.TxtRecuperacion2.Text = DataSet.Tables("Vendedores").Rows(0)("Recuperacion2")
            End If

            If Not IsDBNull(DataSet.Tables("Vendedores").Rows(0)("TipoComision")) Then
                TipoComision = DataSet.Tables("Vendedores").Rows(0)("TipoComision")

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

            Me.TxtTelefono.Text = DataSet.Tables("Vendedores").Rows(0)("Telefono_Vendedor")
        Else

            Me.TxtRecuperacion1.Text = ""
            Me.TxtRecuperacion2.Text = ""
            Me.TxtComision1.Text = ""
            Me.TxtComision2.Text = ""
            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtCtaxCobrar.Text = ""
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