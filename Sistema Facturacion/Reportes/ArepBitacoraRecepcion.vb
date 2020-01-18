Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepBitacoraRecepcion 

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        'If My.Forms.FrmRecepcion.OptMaquila.Checked = True Then
        '    Me.LblTipo.Text = "M A Q U I L A"
        'Else
        '    Me.LblTipo.Text = "E X P A S A"
        'End If

        'Me.LblCosecha.Text = My.Forms.FrmRecepcion.LblCosecha.Text
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub ArepBitacoraRecepcion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        'Me.LblLocalidad.Text = My.Forms.MDIParent1.LugarAcopio
        Me.LblHora.Text = "Impreso: " & FrmRecepcion.DTPFecha.Text & " " & FrmRecepcion.LblHora.Text

    End Sub
End Class
