Public Class FrmExpediente
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Public Sub GenerarExpediente()
        Dim Serie As String, Numero As Double, NumeroExpediente As String, NumeroExpedienteG As String
        Dim SqlString As String, Num() As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, i As Double


        If Me.TxtLetra.Text <> "" Then
            If Not IsNumeric(Me.TxtLetra.Text) Then
                Serie = Me.TxtLetra.Text
            Else
                Serie = "B"
            End If
        Else
            Serie = "B"
        End If

        If Me.TxtCodigo.Text <> "" Then
            If IsNumeric(Me.TxtCodigo.Text) Then
                Numero = Me.TxtCodigo.Text
            Else
                Numero = 1
            End If
        Else
            Numero = 1
        End If

        NumeroExpediente = Serie & "-" & Format(Numero, "00000#")
        Num = NumeroExpediente.Split("-")
        Me.TxtLetra.Text = Num(0)
        Me.TxtCodigo.Text = Num(1)

        SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & NumeroExpediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If DataSet.Tables("Expediente").Rows.Count = 0 Then

            '/////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////SI NO EXISTE BUSCO SI ES EL SIGUIENTE //////////////////
            '////////////////////////////7////////////////////////////////////////////////////////
            SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente like  '%" & Serie & "%') ORDER BY Numero_Expediente"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Siguiente")
            i = 0

            '/////////////////RECORRO PARA BUCAR EL SIGUIENTE DISPONIBLE
            Do While DataSet.Tables("Siguiente").Rows.Count > i
                If i = 0 Then
                    NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(0)("Numero_Expediente")
                Else
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")

                    If NumeroExpediente <> DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente") Then
                        Num = NumeroExpediente.Split("-")
                        Me.TxtLetra.Text = Num(0)
                        Me.TxtCodigo.Text = Num(1)
                        Exit Do
                    Else
                        NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente")
                    End If
                End If


                i = i + 1

                If DataSet.Tables("Siguiente").Rows.Count = i Then
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                    Me.TxtLetra.Text = Num(0)
                    Me.TxtCodigo.Text = Format(CDbl(Num(1)) + 1, "00000#")
                    Exit Do

                End If
            Loop


            'If NumeroExpediente <> NumeroExpedienteG Then
            '    If NumeroExpedienteG <> Nothing Then
            '        NumeroExpediente = NumeroExpedienteG
            '    End If
            'End If

            'Num = NumeroExpediente.Split("-")
            'Me.TxtLetra.Text = Num(0)
            'Me.TxtCodigo.Text = Num(1)

        Else

            '/////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////BUSCO EL SIGUIENTE //////////////////
            '////////////////////////////7////////////////////////////////////////////////////////
            SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente like  '%" & Serie & "%') ORDER BY Numero_Expediente"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Siguiente")
            i = 0

            '/////////////////RECORRO PARA BUCAR EL SIGUIENTE DISPONIBLE
            Do While DataSet.Tables("Siguiente").Rows.Count > i
                If i = 0 Then
                    NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(0)("Numero_Expediente")
                Else
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")

                    If NumeroExpediente <> DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente") Then
                        Num = NumeroExpediente.Split("-")
                        Me.TxtLetra.Text = Num(0)
                        Me.TxtCodigo.Text = Num(1)
                        Exit Do
                    Else
                        NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente")
                    End If
                End If


                i = i + 1

                If DataSet.Tables("Siguiente").Rows.Count = i Then
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                    Me.TxtLetra.Text = Num(0)
                    Me.TxtCodigo.Text = Format(CDbl(Num(1)) + 1, "00000#")
                    Exit Do

                End If
            Loop



        End If






    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLetra.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombrePadre.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub FrmExpediente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GenerarExpediente()
    End Sub

    Private Sub TxtApellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellidos.TextChanged
        If Me.TxtApellidos.Text <> "" Then
            Me.TxtLetra.Text = Mid(Me.TxtApellidos.Text, 1, 1)
            GenerarExpediente()
        End If

    End Sub
End Class