Public Class FrmRutaDistribucion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmRutaDistribucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String = "SELECT  * FROM Ruta_Distribucion"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataSet.Tables("Notas").Reset()
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Ruta")
        End If
    End Sub

    Private Sub CmbCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCodigo.TextChanged
        Dim SQL As String = "SELECT  *  FROM Ruta_Distribucion WHERE (CodRuta = '" & Me.CmbCodigo.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Ruta").Rows(0)("Nombre_Ruta")) Then
                Me.TxtDescripcion.Text = DataSet.Tables("Ruta").Rows(0)("Nombre_Ruta")
            End If
        Else
            Me.TxtDescripcion.Text = ""
        End If
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CmbCodigo.Text = ""
        Me.TxtDescripcion.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQL As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        SQL = "SELECT  *  FROM Ruta_Distribucion WHERE (CodRuta = '" & Me.CmbCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE Ruta_Distribucion  SET [Nombre_Ruta] = '" & Me.TxtDescripcion.Text & "'  WHERE (CodRuta = '" & Me.CmbCodigo.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO Ruta_Distribucion ([CodRuta],[Nombre_Ruta]) " & _
                           "VALUES ('" & Me.CmbCodigo.Text & "','" & Me.TxtDescripcion.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Bitacora(Now, NombreUsuario, "Se Grabo la Ruta de Distribucion: " & Me.TxtDescripcion.Text, "Grabar")
        Dim SqlString As String = "SELECT  *  FROM Ruta_Distribucion "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Tables("Ruta").Reset()
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Ruta")

        End If

        CmdNuevo_Click(sender, e)
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar esta Nota?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT  *  FROM Ruta_Distribucion WHERE (CodRuta = '" & Me.CmbCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM Ruta_Distribucion WHERE (CodRuta = '" & Me.CmbCodigo.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Se Elimino la Ruta de Distribucion: " & Me.TxtDescripcion.Text, "Borrar")
        Dim SqlString As String = "SELECT  *  FROM Ruta_Distribucion "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Tables("Ruta").Reset()
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Ruta")
        End If

        CmdNuevo_Click(sender, e)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Ruta"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbCodigo.Text = My.Forms.FrmConsultas.Codigo
        Me.TxtDescripcion.Text = My.Forms.FrmConsultas.Descripcion
    End Sub
End Class