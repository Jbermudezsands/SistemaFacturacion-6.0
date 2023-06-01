Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepProductoVendedor 

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

    End Sub

    Private Sub ArepProductoVendedor_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.LblRango.Text = "Desde " & Format(FrmReportes.DTPFechaIni.Value, "dd/MM/yyyy") & " Hasta " & Format(FrmReportes.DTPFechaFin.Value, "dd/MM/yyyy")
        Me.LblImpreso.Text = Format(Now, "dd-MMM-yyyy")
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
