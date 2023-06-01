Public Class FrmCoordenadasRecibos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtX10.TextChanged

    End Sub
    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SqlDatos As String, TipoImpresion As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, TipoCoordenadas As String

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////GRABO LAS COORDENADAS/////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        TipoImpresion = FrmPersonalizar.TipoImpresion
        TipoCoordenadas = FrmPersonalizar.TipoCoordenadas

        SqlDatos = "SELECT  *  FROM Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Impresion")
        If DataSet.Tables("Impresion").Rows.Count <> 0 Then
            '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE Coordenadas SET [Nlineas] = '" & Me.TxtNLineas.Text & "' ,[X1] = '" & Me.TxtX1.Text & "',[Y1] = '" & Me.TxtY1.Text & "',[X2] = '" & Me.TxtX2.Text & "',[Y2] = '" & Me.TxtY2.Text & "',[X3] = '" & Me.TxtX3.Text & "',[Y3] = '" & Me.TxtY3.Text & "',[X4] = '" & Me.TxtX4.Text & "',[Y4] = '" & Me.TxtY4.Text & "',[X5] = '" & Me.TxtX5.Text & "',[Y5] = '" & Me.TxtY5.Text & "',[X6] = '" & Me.TxtX6.Text & "',[Y6] = '" & Me.TxtY6.Text & "',[X7] = '" & Me.TxtX7.Text & "',[Y7] = '" & Me.TxtY7.Text & "',[X8] = '" & Me.TxtX8.Text & "',[Y8] = '" & Me.TxtY8.Text & "',[X9] = '" & Me.TxtX9.Text & "',[Y9] = '" & Me.TxtY9.Text & "',[X10] = '" & Me.TxtX10.Text & "',[Y10] = '" & Me.TxtY10.Text & "',[X11] = '" & Me.TxtX11.Text & "',[Y11] = '" & Me.TxtY11.Text & "',[X12] = '" & Me.TxtX12.Text & "',[Y12] = '" & Me.TxtY12.Text & "' ,[X13] = '" & Me.TxtX13.Text & "',[Y13] = '" & Me.TxtY13.Text & "',[X14] = '" & Me.TxtX14.Text & "',[Y14] = '" & Me.TxtY14.Text & "',[X15] = '" & Me.TxtX15.Text & "',[Y15] = '" & Me.TxtY15.Text & "',[X16] = '" & Me.TxtX16.Text & "',[Y16] = '" & Me.TxtY16.Text & "',[X17] = '" & Me.TxtX17.Text & "',[Y17] = '" & Me.TxtY17.Text & "',[X18] = '" & Me.TxtX18.Text & "',[Y18] = '" & Me.TxtY18.Text & "',[X19] = '" & Me.TxtX19.Text & "',[Y19] = '" & Me.TxtY19.Text & "',[X20] = '" & Me.TxtX20.Text & "',[Y20] = '" & Me.TxtY20.Text & "',[X21] = '0',[Y21] = '0',[X22] = '0',[Y22] = '0',[X23] = '0',[Y23] = '0',[X24] = '0',[Y24] = '0' ,[X25] = '0',[Y25] = '0' ,[X26] = '0',[Y26] = '0',[X27] = '0',[Y27] = '0',[CaracteresLineas] = '" & Me.TxtCaracteres.Text & "'  " & _
                           "WHERE (Tipo = '" & TipoCoordenadas & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO Coordenadas ([Tipo],[Nlineas],[X1],[Y1],[X2],[Y2],[X3],[Y3],[X4],[Y4],[X5],[Y5],[X6],[Y6],[X7],[Y7],[X8],[Y8],[X9],[Y9],[X10],[Y10],[X11],[Y11],[X12],[Y12],[X13],[Y13],[X14],[Y14],[X15],[Y15],[X16],[Y16],[X17],[Y17],[X18],[Y18],[X19],[Y19],[X20],[Y20],[X21],[Y21],[X22],[Y22],[X23],[Y23],[X24],[Y24],[X25],[Y25],[X26],[Y26],[X27],[Y27],[CaracteresLineas]) " & _
                            "VALUES('" & TipoImpresion & "','" & Me.TxtNLineas.Text & "','" & Me.TxtX1.Text & "','" & Me.TxtY1.Text & "','" & Me.TxtX2.Text & "','" & Me.TxtY2.Text & "','" & Me.TxtX3.Text & "','" & Me.TxtY3.Text & "','" & Me.TxtX4.Text & "','" & Me.TxtY4.Text & "','" & Me.TxtX5.Text & "','" & Me.TxtY5.Text & "','" & Me.TxtX6.Text & "','" & Me.TxtY6.Text & "','" & Me.TxtX7.Text & "','" & Me.TxtY7.Text & "','" & Me.TxtX8.Text & "','" & Me.TxtY8.Text & "','" & Me.TxtX9.Text & "','" & Me.TxtY9.Text & "','" & Me.TxtX10.Text & "' ,'" & Me.TxtY10.Text & "','" & Me.TxtX11.Text & "','" & Me.TxtY11.Text & "','" & Me.TxtX12.Text & "','" & Me.TxtY12.Text & "','" & Me.TxtX13.Text & "','" & Me.TxtY13.Text & "','" & Me.TxtX14.Text & "','" & Me.TxtY14.Text & "','" & Me.TxtX15.Text & "','" & Me.TxtY15.Text & "','" & Me.TxtX16.Text & "','" & Me.TxtY16.Text & "','" & Me.TxtX17.Text & "','" & Me.TxtY17.Text & "','" & Me.TxtX18.Text & "','" & Me.TxtY18.Text & "','" & Me.TxtX19.Text & "','" & Me.TxtY19.Text & "','" & Me.TxtX20.Text & "','" & Me.TxtY20.Text & "','0','0','0','0','0','0','0','0','0','0','0','0','0','0','" & Me.TxtCaracteres.Text & "') "

            'StrSqlUpdate = "INSERT INTO Impresion ([Impresion] ,[Configuracion]) " & _
            '               "VALUES ('" & Me.ListBox1.Text & "' ,'" & Descripcion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Critical)
    End Sub

    Private Sub FrmCoordenadasRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String, TipoImpresion As String, TipoCoordenadas As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter



        TipoImpresion = FrmPersonalizar.TipoImpresion
        TipoCoordenadas = FrmPersonalizar.TipoCoordenadas
        SQlString = "SELECT * FROM Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"


        Select Case TipoImpresion
            Case "Recibos de Caja"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    Me.TxtNLineas.Text = DataSet.Tables("Coordenadas").Rows(0)("Nlineas")
                    Me.TxtCaracteres.Text = DataSet.Tables("Coordenadas").Rows(0)("CaracteresLineas")
                    Me.TxtX1.Text = DataSet.Tables("Coordenadas").Rows(0)("X1")
                    Me.TxtY1.Text = DataSet.Tables("Coordenadas").Rows(0)("Y1")
                    Me.TxtX2.Text = DataSet.Tables("Coordenadas").Rows(0)("X2")
                    Me.TxtY2.Text = DataSet.Tables("Coordenadas").Rows(0)("Y2")
                    Me.TxtX3.Text = DataSet.Tables("Coordenadas").Rows(0)("X3")
                    Me.TxtY3.Text = DataSet.Tables("Coordenadas").Rows(0)("Y3")
                    Me.TxtX4.Text = DataSet.Tables("Coordenadas").Rows(0)("X4")
                    Me.TxtY4.Text = DataSet.Tables("Coordenadas").Rows(0)("Y4")
                    Me.TxtX5.Text = DataSet.Tables("Coordenadas").Rows(0)("X5")
                    Me.TxtY5.Text = DataSet.Tables("Coordenadas").Rows(0)("Y5")
                    Me.TxtX6.Text = DataSet.Tables("Coordenadas").Rows(0)("X6")
                    Me.TxtY6.Text = DataSet.Tables("Coordenadas").Rows(0)("Y6")
                    Me.TxtX7.Text = DataSet.Tables("Coordenadas").Rows(0)("X7")
                    Me.TxtY7.Text = DataSet.Tables("Coordenadas").Rows(0)("Y7")
                    Me.TxtX8.Text = DataSet.Tables("Coordenadas").Rows(0)("X8")
                    Me.TxtY8.Text = DataSet.Tables("Coordenadas").Rows(0)("Y8")
                    Me.TxtX9.Text = DataSet.Tables("Coordenadas").Rows(0)("X9")
                    Me.TxtY9.Text = DataSet.Tables("Coordenadas").Rows(0)("Y9")
                    Me.TxtX10.Text = DataSet.Tables("Coordenadas").Rows(0)("X10")
                    Me.TxtY10.Text = DataSet.Tables("Coordenadas").Rows(0)("Y10")
                    Me.TxtX11.Text = DataSet.Tables("Coordenadas").Rows(0)("X11")
                    Me.TxtY11.Text = DataSet.Tables("Coordenadas").Rows(0)("Y11")
                    Me.TxtX12.Text = DataSet.Tables("Coordenadas").Rows(0)("X12")
                    Me.TxtY12.Text = DataSet.Tables("Coordenadas").Rows(0)("Y12")
                    Me.TxtX13.Text = DataSet.Tables("Coordenadas").Rows(0)("X13")
                    Me.TxtY13.Text = DataSet.Tables("Coordenadas").Rows(0)("Y13")
                    Me.TxtX14.Text = DataSet.Tables("Coordenadas").Rows(0)("X14")
                    Me.TxtY14.Text = DataSet.Tables("Coordenadas").Rows(0)("Y14")
                    Me.TxtX15.Text = DataSet.Tables("Coordenadas").Rows(0)("X15")
                    Me.TxtY15.Text = DataSet.Tables("Coordenadas").Rows(0)("Y15")
                    Me.TxtX16.Text = DataSet.Tables("Coordenadas").Rows(0)("X16")
                    Me.TxtY16.Text = DataSet.Tables("Coordenadas").Rows(0)("Y16")
                    Me.TxtX17.Text = DataSet.Tables("Coordenadas").Rows(0)("X17")
                    Me.TxtY17.Text = DataSet.Tables("Coordenadas").Rows(0)("Y17")
                    Me.TxtX18.Text = DataSet.Tables("Coordenadas").Rows(0)("X18")
                    Me.TxtY18.Text = DataSet.Tables("Coordenadas").Rows(0)("Y18")
                    Me.TxtX19.Text = DataSet.Tables("Coordenadas").Rows(0)("X19")
                    Me.TxtY19.Text = DataSet.Tables("Coordenadas").Rows(0)("Y19")
                    Me.TxtX20.Text = DataSet.Tables("Coordenadas").Rows(0)("X20")
                    Me.TxtY20.Text = DataSet.Tables("Coordenadas").Rows(0)("Y20")
                End If

        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class