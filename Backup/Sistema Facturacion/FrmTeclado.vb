Public Class FrmTeclado
    Public Numero As String
    Private Sub FrmTeclado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtNumero.Text = ""
    End Sub

    Private Sub C1Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdBoton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "1"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "1"
        End If
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "2"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "2"
        End If
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "3"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "3"
        End If
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "4"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "4"
        End If
    End Sub

    Private Sub CmdBoton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "5"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "5"
        End If
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "6"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "6"
        End If
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "7"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "7"
        End If
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "8"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "8"
        End If
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "9"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "9"
        End If
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "+"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "+"
        End If
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "0"
        End If
    End Sub

    Private Sub C1Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        If Me.TxtNumero.Text <> "" Then
            Me.TxtNumero.Text = Mid(Me.TxtNumero.Text, 1, Len(Me.TxtNumero.Text) - 1)
        End If
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Numero = 0
        Me.Close()
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        If Me.TxtNumero.Text = "" Then
            Numero = 0
        Else
            Numero = Me.TxtNumero.Text
        End If
        Me.Close()
    End Sub

    Private Sub BtnPunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPunto.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0."
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "."
        End If
    End Sub
End Class