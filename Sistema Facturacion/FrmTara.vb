Public Class FrmTara
    Delegate Sub delegado(ByVal data As String)
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        My.Forms.FrmPuertosTara.Pregunta = "BasculaTara"
        My.Forms.FrmPuertosTara.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.sp.Close()
        Me.LblEstado.Text = "DESCONECT"
        Me.LblEstado.ForeColor = Color.Black
    End Sub

    Private Sub sp_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim s As String '= sp.ReadExisting, Pesada As Double

        Dim escribeport3 As New delegado(AddressOf Me.mostar)



        s = sp.ReadLine


        If Len(s) = 19 Then
            If Mid(s, 1, 5) <> "GROSS" Then
                Exit Sub
            End If
        End If

        Select Case Mid(s, 1, 4)
            Case "TARA" : Exit Sub
            Case "NETO" : Exit Sub
            Case "TEL:2263-5025" : Exit Sub
            Case "" : Exit Sub

        End Select

        If Len(s) > 5 Then
            s = SoloNumeros(s)


            If s = "2263-5025" Then  ''''SOBRE PASA EL " Then  SOLO EMTRIDES---
                Exit Sub
            End If


            If s <> "" Then
                Me.Invoke(escribeport3, s)
            End If

        End If
    End Sub

    Sub mostar(ByVal d As String)
        Dim Posicion As Double
        Dim Cadena As String, Pesada As Double, PesoEntero As Double, PesoDecimal As Double


        Cadena = d
        Pesada = SoloNumeros(Cadena)
        '-------------------------------SI SE ACTIVA EL REDONDEO CAMBIO LA PESADA

        PesoEntero = Int(Pesada)
        PesoDecimal = Format(Pesada - PesoEntero, "##0.00")
        Pesada = PesoEntero + PesoDecimal


        Me.TxtTara.Text = Pesada
    End Sub

    Private Sub FrmTara_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '/////////////////////////DESCONECTA LA BASCULA DE LA PESADA DE LA TARA ////////////////////////////////////////
        Button10_Click(sender, e)
    End Sub

    Private Sub FrmTara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button11_Click(sender, e)
        Me.TxtTara.Text = ""
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Me.TxtTara.Text <> "" Then
            My.Forms.FrmRecepcion.Tara = Me.TxtTara.Text
        End If
        Me.Close()
    End Sub
End Class