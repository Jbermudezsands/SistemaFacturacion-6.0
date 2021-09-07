Public Class FrmNuevoLote
    Public MiConexion As New SqlClient.SqlConnection(Conexion)


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SqlClientes As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Respuesta As Double

        SqlClientes = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & Me.TxtNumeroLote.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Respuesta = MsgBox("El Lote Existe, ¿Desea Modificarlo?", MsgBoxStyle.YesNo, "Zeus Facturacion")
            If Respuesta = 7 Then
                Me.TxtNumeroLote.Text = ""
                Me.TxtNombreLote.Text = ""
                Exit Sub
            End If

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Lote]  SET [Nombre_Lote] =  '" & Me.TxtNombreLote.Text & "' ,[FechaVence] = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "'  WHERE (Numero_Lote = '" & Me.TxtNumeroLote.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Lote] ([Numero_Lote],[Nombre_Lote],[FechaVence]) VALUES ('" & Me.TxtNumeroLote.Text & "' ,'" & Me.TxtNombreLote.Text & "' ,'" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        Me.TxtNombreLote.Text = ""
        Me.TxtNumeroLote.Text = ""
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmNuevoLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class