Public Class FrmRubros
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmRubros_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Rubros")
    End Sub

    Private Sub FrmRubros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT  * FROM  Rubro"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Rubro")
        If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Rubro")
        End If

    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQL As String = "SELECT  *  FROM Rubro WHERE  (Codigo_Rubro = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Rubros")
        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")) Then
                Me.TxtNombre.Text = DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")
            End If
        Else
            Me.TxtNombre.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLRubros As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQLRubros = "SELECT  *  FROM Rubro WHERE  (Codigo_Rubro = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRubros, MiConexion)
        DataAdapter.Fill(DataSet, "Rubros")
        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Rubro] SET [Nombre_Rubro] = '" & Me.TxtNombre.Text & "' WHERE (Codigo_Rubro = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Rubro] ([Codigo_Rubro] ,[Nombre_Rubro]) " & _
                           "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM Rubro"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Rubro")
        If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Rubro")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Rubro?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        SQLProveedor = "SELECT  *  FROM Rubro WHERE  (Codigo_Rubro = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Rubros")
        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Rubro]  WHERE (Codigo_Rubro = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM Rubro "
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Rubro")
        If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Rubro")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoRubro"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class