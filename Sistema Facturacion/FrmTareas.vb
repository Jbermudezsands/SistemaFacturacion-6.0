Public Class FrmTareas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmTareas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Tipos de Precios")
    End Sub
    Private Sub FrmTareas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT  * FROM  Tareas"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Tareas")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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


        SQLProveedor = "SELECT  *  FROM Tareas WHERE  (CodigoTarea = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Tareas]  WHERE (CodigoTarea = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM Tareas "
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Tareas")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLRubros As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQLRubros = "SELECT  *  FROM Tareas WHERE  (CodigoTarea = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRubros, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Tareas] SET [Nombre_Tarea] = '" & Me.TxtNombre.Text & "',[CtaCosto] = '" & Me.TxtCtaCosto.Text & "' WHERE (CodigoTarea = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Tareas] ([CodigoTarea] ,[Nombre_Tarea],[CtaCosto]) " & _
                           "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtCtaCosto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM Tareas"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Tareas")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQL As String = "SELECT  *  FROM Tareas WHERE  (CodigoTarea = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Tareas")
        If Not DataSet.Tables("Tareas").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Tareas").Rows(0)("Nombre_Tarea")) Then
                Me.TxtNombre.Text = DataSet.Tables("Tareas").Rows(0)("Nombre_Tarea")
            End If
            If Not IsDBNull(DataSet.Tables("Tareas").Rows(0)("CtaCosto")) Then
                Me.TxtCtaCosto.Text = DataSet.Tables("Tareas").Rows(0)("CtaCosto")
            End If
        Else
            Me.TxtNombre.Text = ""
            Me.TxtCtaCosto.Text = ""
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoTarea"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCosto"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class