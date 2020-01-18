Public Class FrmCoordenadasNotas
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Serie As Boolean

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SqlDatos As String, TipoImpresion As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////GRABO LAS COORDENADAS/////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        TipoImpresion = FrmPersonalizar.TipoImpresion

        SqlDatos = "SELECT  *  FROM Coordenadas WHERE (Tipo = '" & TipoImpresion & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Impresion")
        If DataSet.Tables("Impresion").Rows.Count <> 0 Then
            '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE Coordenadas SET [Nlineas] = '1' ,[X1] = '" & Me.TxtX1.Text & "',[Y1] = '" & Me.TxtY1.Text & "',[X2] = '" & Me.TxtX2.Text & "',[Y2] = '" & Me.TxtY2.Text & "',[X3] = '" & Me.TxtX3.Text & "',[Y3] = '" & Me.TxtY3.Text & "',[X4] = '" & Me.TxtX4.Text & "',[Y4] = '" & Me.TxtY4.Text & "',[X5] = '" & Me.TxtX5.Text & "',[Y5] = '" & Me.TxtY5.Text & "',[X6] = '" & Me.TxtX6.Text & "',[Y6] = '" & Me.TxtY6.Text & "',[X7] = '" & Me.TxtX7.Text & "',[Y7] = '" & Me.TxtY7.Text & "',[X8] = '" & Me.TxtX8.Text & "',[Y8] = '" & Me.TxtY8.Text & "',[X9] = '" & Me.TxtX9.Text & "',[Y9] = '" & Me.TxtY9.Text & "',[X10] = '" & Me.TxtX10.Text & "',[Y10] = '" & Me.TxtY10.Text & "',[X11] = '" & Me.TxtX11.Text & "',[Y11] = '" & Me.TxtY11.Text & "',[X12] = '0',[Y12] = '0' ,[X13] = '0',[Y13] = '0',[X14] = '0',[Y14] = '0',[X15] = '0',[Y15] = '0',[X16] = '0',[Y16] = '0',[X17] = '0',[Y17] = '0',[X18] = '0',[Y18] = '0',[X19] = '0',[Y19] = '0',[X20] = '0',[Y20] = '0',[X21] = '0',[Y21] = '0',[X22] = '0',[Y22] = '0',[X23] = '0',[Y23] = '0',[X24] = '0',[Y24] = '0' ,[X25] = '0',[Y25] = '0' ,[X26] = '0',[Y26] = '0',[X27] = '0',[Y27] = '0',[X28] = '" & Me.TxtX28.Text & "',[Y28] = '" & Me.TxtY28.Text & "',[X29] = '0',[Y29] = '0',[X33] = '0',[Y33] = '0',[X34] = '0',[Y34] = '0', [CaracteresLineas] = '" & Me.TxtCaracteres.Text & "', [CaracteresObservacion] = '" & Me.TxtCaracObservaciones.Text & "'  " & _
                           "WHERE (Tipo = '" & TipoImpresion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO Coordenadas ([Tipo],[Nlineas],[X1],[Y1],[X2],[Y2],[X3],[Y3],[X4],[Y4],[X5],[Y5],[X6],[Y6],[X7],[Y7],[X8],[Y8],[X9],[Y9],[X10],[Y10],[X11],[Y11],[X28],[Y28],[CaracteresLineas], [CaracteresObservacion]) " & _
                           "VALUES('" & TipoImpresion & "','1','" & Me.TxtX1.Text & "','" & Me.TxtY1.Text & "','" & Me.TxtX2.Text & "','" & Me.TxtY2.Text & "','" & Me.TxtX3.Text & "','" & Me.TxtY3.Text & "','" & Me.TxtX4.Text & "','" & Me.TxtY4.Text & "','" & Me.TxtX5.Text & "','" & Me.TxtY5.Text & "','" & Me.TxtX6.Text & "','" & Me.TxtY6.Text & "','" & Me.TxtX7.Text & "','" & Me.TxtY7.Text & "','" & Me.TxtX8.Text & "','" & Me.TxtY8.Text & "','" & Me.TxtX9.Text & "','" & Me.TxtY9.Text & "','" & Me.TxtX10.Text & "','" & Me.TxtY10.Text & "','" & Me.TxtX11.Text & "','" & Me.TxtY11.Text & "','" & Me.TxtX28.Text & "','" & Me.TxtY28.Text & "','" & Me.TxtCaracteres.Text & "','" & Me.TxtCaracObservaciones.Text & "') "

            'StrSqlUpdate = "INSERT INTO Impresion ([Impresion] ,[Configuracion]) " & _
            '               "VALUES ('" & Me.ListBox1.Text & "' ,'" & Descripcion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Critical)
    End Sub

    Private Sub FrmCoordenadasNotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String, TipoImpresion As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim TipoCoordenadas As String

        If Serie = False Then
            TipoCoordenadas = FrmPersonalizar.TipoImpresion
            TipoImpresion = FrmPersonalizar.ListBox1.Text
        Else
            TipoCoordenadas = FrmPersonalizar.ListBox1.Text & FrmPersonalizar.CmbSerieImprime.Text
            TipoImpresion = FrmPersonalizar.ListBox1.Text
        End If

        SQlString = "SELECT * FROM Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"


        Select Case TipoImpresion
            Case "Notas Credito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
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
                    Me.TxtX28.Text = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Me.TxtY28.Text = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                End If

            Case "Notas Debito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
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
                    Me.TxtX28.Text = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Me.TxtY28.Text = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                End If
        End Select
    End Sub

    Private Sub PrintNota_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintNota.PrintPage
        Dim prFont As New Font("Arial", 15, FontStyle.Bold)
        Dim SQlString As String, TipoImpresion As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim TipoCoordenadas As String, X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer, X3 As Integer, Y3 As Integer, X4 As Integer, Y4 As Integer, X5 As Integer, Y5 As Integer, X6 As Integer, Y6 As Integer, X7 As Integer, Y7 As Integer, X28 As Integer, Y28 As Integer, X8 As Integer, Y8 As Integer, X9 As Integer, Y9 As Integer, X10 As Integer, Y10 As Integer, X11 As Integer, Y11 As Integer, CarateresLinea As Integer
        Dim Observaciones As String = "Esta es una impresion de prueba de las notas de debito del sistema Zeus Facturacion, con esto comprobamos el tamaño de las lineas configuradas en observaciones para imprimir dentro del formato sin problemas"






        If Serie = False Then
            TipoCoordenadas = FrmPersonalizar.TipoImpresion
            TipoImpresion = FrmPersonalizar.ListBox1.Text
        Else
            TipoCoordenadas = FrmPersonalizar.ListBox1.Text & FrmPersonalizar.CmbSerieImprime.Text
            TipoImpresion = FrmPersonalizar.ListBox1.Text
        End If

        SQlString = "SELECT * FROM Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"


        Select Case TipoImpresion
            Case "Notas Credito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    CarateresLinea = DataSet.Tables("Coordenadas").Rows(0)("CaracteresLineas")
                    X1 = DataSet.Tables("Coordenadas").Rows(0)("X1")
                    Y1 = DataSet.Tables("Coordenadas").Rows(0)("Y1")
                    X2 = DataSet.Tables("Coordenadas").Rows(0)("X2")
                    Y2 = DataSet.Tables("Coordenadas").Rows(0)("Y2")
                    X3 = DataSet.Tables("Coordenadas").Rows(0)("X3")
                    Y3 = DataSet.Tables("Coordenadas").Rows(0)("Y3")
                    X4 = DataSet.Tables("Coordenadas").Rows(0)("X4")
                    Y4 = DataSet.Tables("Coordenadas").Rows(0)("Y4")
                    X5 = DataSet.Tables("Coordenadas").Rows(0)("X5")
                    Y5 = DataSet.Tables("Coordenadas").Rows(0)("Y5")
                    X6 = DataSet.Tables("Coordenadas").Rows(0)("X6")
                    Y6 = DataSet.Tables("Coordenadas").Rows(0)("Y6")
                    X7 = DataSet.Tables("Coordenadas").Rows(0)("X7")
                    Y7 = DataSet.Tables("Coordenadas").Rows(0)("Y7")
                    X8 = DataSet.Tables("Coordenadas").Rows(0)("X8")
                    Y8 = DataSet.Tables("Coordenadas").Rows(0)("Y8")
                    X9 = DataSet.Tables("Coordenadas").Rows(0)("X9")
                    Y9 = DataSet.Tables("Coordenadas").Rows(0)("Y9")
                    X10 = DataSet.Tables("Coordenadas").Rows(0)("X10")
                    Y10 = DataSet.Tables("Coordenadas").Rows(0)("Y10")
                    X11 = DataSet.Tables("Coordenadas").Rows(0)("X11")
                    Y11 = DataSet.Tables("Coordenadas").Rows(0)("Y11")
                    X28 = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Y28 = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                End If

            Case "Notas Debito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    CarateresLinea = DataSet.Tables("Coordenadas").Rows(0)("CaracteresLineas")
                    X1 = DataSet.Tables("Coordenadas").Rows(0)("X1")
                    Y1 = DataSet.Tables("Coordenadas").Rows(0)("Y1")
                    X2 = DataSet.Tables("Coordenadas").Rows(0)("X2")
                    Y2 = DataSet.Tables("Coordenadas").Rows(0)("Y2")
                    X3 = DataSet.Tables("Coordenadas").Rows(0)("X3")
                    Y3 = DataSet.Tables("Coordenadas").Rows(0)("Y3")
                    X4 = DataSet.Tables("Coordenadas").Rows(0)("X4")
                    Y4 = DataSet.Tables("Coordenadas").Rows(0)("Y4")
                    X5 = DataSet.Tables("Coordenadas").Rows(0)("X5")
                    Y5 = DataSet.Tables("Coordenadas").Rows(0)("Y5")
                    X6 = DataSet.Tables("Coordenadas").Rows(0)("X6")
                    Y6 = DataSet.Tables("Coordenadas").Rows(0)("Y6")
                    X7 = DataSet.Tables("Coordenadas").Rows(0)("X7")
                    Y7 = DataSet.Tables("Coordenadas").Rows(0)("Y7")
                    X8 = DataSet.Tables("Coordenadas").Rows(0)("X8")
                    Y8 = DataSet.Tables("Coordenadas").Rows(0)("Y8")
                    X9 = DataSet.Tables("Coordenadas").Rows(0)("X9")
                    Y9 = DataSet.Tables("Coordenadas").Rows(0)("Y9")
                    X10 = DataSet.Tables("Coordenadas").Rows(0)("X10")
                    Y10 = DataSet.Tables("Coordenadas").Rows(0)("Y10")
                    X11 = DataSet.Tables("Coordenadas").Rows(0)("X11")
                    Y11 = DataSet.Tables("Coordenadas").Rows(0)("Y11")
                    X28 = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Y28 = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                End If
        End Select

        prFont = New Font("Arial", 8, FontStyle.Regular)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        'e.Graphics.DrawString("METROGARMENT NICARAGUA", prFont, Brushes.Black, 67, 10)

        If X1 <> 0 And Y1 <> 0 Then
            e.Graphics.DrawString("15/08/2017", prFont, Brushes.Black, X1, Y1)
        End If
        If X2 <> 0 And Y2 <> 0 Then
            e.Graphics.DrawString("0000501", prFont, Brushes.Black, X2, Y2)
        End If
        If X3 <> 0 And Y3 <> 0 Then
            e.Graphics.DrawString("JUAN BERMUDEZ HERNANDEZ", prFont, Brushes.Black, X3, Y3)
        End If
        If X4 <> 0 And Y4 <> 0 Then
            e.Graphics.DrawString("C01", prFont, Brushes.Black, X4, Y4)
        End If
        If X5 <> 0 And Y5 <> 0 Then
            e.Graphics.DrawString("Retencion del 2%", prFont, Brushes.Black, X5, Y5)
        End If
        If X6 <> 0 And Y6 <> 0 Then
            e.Graphics.DrawString("2,225.56", prFont, Brushes.Black, X6, Y6)
        End If
        If X7 <> 0 And Y7 <> 0 Then
            e.Graphics.DrawString("Observaciones: Retenciones", prFont, Brushes.Black, X7, Y7)
        End If
        If X8 <> 0 And Y8 <> 0 Then
            e.Graphics.DrawString("0011508770016B", prFont, Brushes.Black, X8, Y8)
        End If
        If X9 <> 0 And Y9 <> 0 Then
            e.Graphics.DrawString("$100.00", prFont, Brushes.Black, X9, Y9)
        End If
        If X10 <> 0 And Y10 <> 0 Then
            e.Graphics.DrawString("2,225.56", prFont, Brushes.Black, X10, Y10)
        End If
        If X11 <> 0 And Y11 <> 0 Then
            e.Graphics.DrawString("$100.00", prFont, Brushes.Black, X11, Y11)
        End If
        If X28 <> 0 And Y28 <> 0 Then
            e.Graphics.DrawString("Dos mil docientos veinte y cinco con 56/100", prFont, Brushes.Black, X28, Y28)
        End If


    End Sub

    Private Sub TxtX3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtX3.TextChanged

    End Sub

    Private Sub CmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdImprimir.Click
        Me.PrintNota.Print()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtX11.TextChanged

    End Sub
End Class