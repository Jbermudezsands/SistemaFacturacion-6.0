Public Class FrmAccesosAddPerfil

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TxtPerfil.Text = ""
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim seguridad As New Seguridad(Conexion)
            seguridad.CrearPerfil(Me.TxtPerfil.Text)
        Catch ex As ArgumentException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End Try

        Me.Close()
    End Sub
End Class
