Public Class FrmQQ
    Public QQ As Double = 0

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        QQ = 0
        Me.Close()
    End Sub

    Private Sub CmdBoton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "1"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "1"
        End If
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "2"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "2"
        End If
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "3"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "3"
        End If
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "4"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "4"
        End If
    End Sub

    Private Sub CmdBoton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "5"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "5"
        End If
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "6"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "6"
        End If
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "7"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "7"
        End If
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "8"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "8"
        End If
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "9"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "9"
        End If
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "0"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "0"
        End If
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        If Me.TxtQQ.Text = "" Then
            Me.TxtQQ.Text = "+"
        Else
            Me.TxtQQ.Text = Me.TxtQQ.Text & "+"
        End If
    End Sub

    Private Sub C1Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        If Me.TxtQQ.Text <> "" Then
            Me.TxtQQ.Text = Mid(Me.TxtQQ.Text, 1, Len(Me.TxtQQ.Text) - 1)
        End If
    End Sub

    Private Sub FrmQQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtQQ.Text = ""
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        If Me.TxtQQ.Text = "" Then
            QQ = 0
        Else
            QQ = Me.TxtQQ.Text
        End If


        Me.Close()

    End Sub
End Class