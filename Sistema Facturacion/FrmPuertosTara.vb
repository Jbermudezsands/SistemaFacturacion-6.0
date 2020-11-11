Public Class FrmPuertosTara
    Public Pregunta As String
    Private Sub FrmPuertosTara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lista.Items.Clear()
        consola.Text = ""

        For Each s As String In My.Computer.Ports.SerialPortNames
            lista.Items.Add(s)
        Next
    End Sub

    Sub mostar(ByVal d As String)
        Dim Cadena As String, Pesada As Double
        'FrmPuertos.consola.AppendText("El Puerto 3 Recibe : " & d)
        Cadena = Mid(d, 4, 10)
        Pesada = CDbl(Cadena)
        'Me.TrueDBGridComponentes.Columns(3).Text = Pesada
    End Sub

    Private Sub lista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista.SelectedIndexChanged
        Try

            Select Case Pregunta
                Case "BasculaTara"

                    My.Forms.FrmTara.sp.Close()
                    consola.AppendText("Puerto " & My.Forms.FrmTara.sp.PortName & " Cerrado" & vbCrLf)
                    My.Forms.FrmTara.sp.PortName = lista.SelectedItem
                    consola.AppendText("Abriendo Puerto : " & My.Forms.FrmTara.sp.PortName & vbCrLf)
                    My.Forms.FrmTara.sp.Open()
                    'sp3.Open()
                    'consola.AppendText("Puerto : " & sp.PortName & " Abierto" & vbCrLf)
                    My.Forms.FrmTara.LblEstado.Text = "CONECTADO"
                    My.Forms.FrmTara.LblEstado.ForeColor = Color.Brown


            End Select
        Catch ex As Exception

            Select Case Pregunta
                Case "BasculaTara"
                    MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    FrmBascula.LblEstado.Text = "DESCONECT"
                    FrmBascula.LblEstado.ForeColor = Color.Black
            End Select
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub
End Class