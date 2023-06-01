Public Class FrmCajeros
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim SQLVendedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        SQLVendedor = "SELECT TOP (100) PERCENT Cajeros.* FROM Cajeros WHERE (Cod_Cajero = '" & Me.CboCodigoVendedor.Text & "') ORDER BY Cod_Cajero"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLVendedor, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        If Not DataSet.Tables("Cajeros").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Cajeros] SET [Nombre_Cajero] = '" & Me.TxtNombre.Text & "',[Apellido_Cajero] = '" & Me.TxtApellidos.Text & "',[Direccion_Cajero] = '" & Me.TxtDireccion.Text & "',[Telefono_Cajero] = '" & Me.TxtTelefono.Text & "'  WHERE Cod_Cajero= '" & Me.CboCodigoVendedor.Text & "'"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Cajeros] ([Cod_Cajero],[Nombre_Cajero],[Apellido_Cajero],[Direccion_Cajero],[Telefono_Cajero]) " & _
                           "VALUES ('" & Me.CboCodigoVendedor.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellidos.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        SQLVendedor = "SELECT TOP (100) PERCENT dbo.Cajeros.* FROM Cajeros"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLVendedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaCajeros")
        If Not DataSet.Tables("ListaCajeros").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaCajeros")
        End If

        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub CboCodigoVendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoVendedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        SqlProveedor = "SELECT  * FROM Cajeros  WHERE (Cod_Cajero = '" & Me.CboCodigoVendedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        If Not DataSet.Tables("Cajeros").Rows.Count = 0 Then
            Me.TxtNombre.Text = DataSet.Tables("Cajeros").Rows(0)("Nombre_Cajero")
            If Not IsDBNull(DataSet.Tables("Cajeros").Rows(0)("Apellido_Cajero")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Cajeros").Rows(0)("Apellido_Cajero")
            End If
            Me.TxtDireccion.Text = DataSet.Tables("Cajeros").Rows(0)("Direccion_Cajero")
            Me.TxtTelefono.Text = DataSet.Tables("Cajeros").Rows(0)("Telefono_Cajero")

        Else

            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""

        End If
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoCajero"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoVendedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Cajero?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Cajeros.* FROM Cajeros WHERE (Cod_Cajero = '" & Me.CboCodigoVendedor.Text & "') ORDER BY Cod_Cajero"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        If Not DataSet.Tables("Cajeros").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Cajeros] WHERE (Cod_Cajero = '" & Me.CboCodigoVendedor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Cajeros.* FROM Cajeros"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaCajeros")
        If Not DataSet.Tables("ListaCajeros").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaCajeros")
        End If

        Me.CboCodigoVendedor.Text = ""
    End Sub

    Private Sub FrmCajeros_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Impuestos")
    End Sub

    Private Sub FrmCajeros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT * FROM Cajeros"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaCajeros")
        If Not DataSet.Tables("ListaCajeros").Rows.Count = 0 Then
            Me.CboCodigoVendedor.DataSource = DataSet.Tables("ListaCajeros")

        End If
    End Sub
End Class