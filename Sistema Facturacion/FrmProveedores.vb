Public Class FrmProveedores
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmProveedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Proveedores")
    End Sub
    Private Sub FrmProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT * FROM Proveedor"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")

        End If


        Dim SqlString As String = "SELECT  * FROM Ruta_Distribucion"

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataSet.Tables("Notas").Reset()
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Ruta")
        End If


    End Sub

    Private Sub CboCodigoProveedor_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoProveedor.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Cod_Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Proveedor] SET [Nombre_Proveedor] = '" & Me.TxtNombre.Text & "',[Apellido_Proveedor] = '" & Me.TxtApellido.Text & "',[Direccion_Proveedor] = '" & Me.TxtDireccion.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Cod_Cuenta_Pagar] = '" & Me.TxtCtaxPagar.Text & "',[Cod_Cuenta_Cobrar] = '" & Me.TxtCtaxPagar.Text & "',[Merma] = '" & Me.TxtMerma.Text & "',[InventarioFisico] = '" & Me.ChkInventario.Checked & "'  WHERE Cod_Proveedor= '" & Me.CboCodigoProveedor.Text & "'"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Proveedor] ([Cod_Proveedor],[Nombre_Proveedor],[Apellido_Proveedor],[Direccion_Proveedor],[Telefono],[Cod_Cuenta_Pagar],[Cod_Cuenta_Cobrar],[Merma],[InventarioFisico]) " & _
                           "VALUES ('" & Me.CboCodigoProveedor.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellido.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtCtaxPagar.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtMerma.Text & "','" & Me.ChkInventario.Checked & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        Bitacora(Now, NombreUsuario, "Proveedores", "Grabo el Proveedor: " & Me.TxtNombre.Text)

        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProveedor.Text = ""

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




        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Cod_Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Proveedor] WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Proveedores", "Borro el Proveedor: " & Me.TxtNombre.Text)

        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProveedor.Text = ""
    End Sub


    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                Me.TxtApellido.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Merma")) Then
                Me.TxtMerma.Text = DataSet.Tables("Proveedor").Rows(0)("Merma")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Cobrar")) Then
                Me.TxtCtaxCobrar.Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Cobrar")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Pagar")) Then
                Me.TxtCtaxPagar.Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Pagar")
            End If

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("InventarioFisico")) Then
                If DataSet.Tables("Proveedor").Rows(0)("InventarioFisico") = 0 Then
                    Me.ChkInventario.Checked = False
                Else
                    Me.ChkInventario.Checked = True
                End If
            Else
                Me.ChkInventario.Checked = False
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////CARGO LOS HISTORICOS DE COMPRAS/////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT Numero_Compra, Fecha_Compra, SubTotal, IVA, Pagado, NetoPagar FROM Compras WHERE (Tipo_Compra = 'Mercancia Recibida')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Compras")
            Me.BindingHistoricoCompras.DataSource = DataSet.Tables("Compras")
            Me.TruDbGridHistoricosCompras.DataSource = Me.BindingHistoricoCompras

            Me.TruDbGridHistoricosCompras.Columns(3).NumberFormat = "##,##0.00"


        Else

            Me.TxtNombre.Text = ""
            Me.TxtApellido.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtMerma.Text = ""
            Me.TxtCtaxCobrar.Text = ""
            Me.TxtCtaxPagar.Text = ""

        End If
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConsulta.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub
End Class