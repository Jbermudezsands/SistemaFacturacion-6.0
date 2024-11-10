Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepProveedores 
    Public ComprasTotales As Double
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Compra As Double
        If Val(Me.TxtVentas.Text) <> 0 Then
            Compra = Me.TxtVentas.Text
        Else
            Compra = 0
        End If
        If ComprasTotales <> 0 Then
            Me.LblPorciento.Text = Format((Compra / ComprasTotales), "0.00%")
        End If

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim dp As DataDynamics.ActiveReports.Chart.DataPoint
        For Each dp In ChartControl.Series(0).Points
            dp.DisplayInLegend = New DataDynamics.ActiveReports.Chart.NullableBoolean(True)
            If FrmReportes.OptDolares.Checked = True Then
                dp.LegendText = dp.XValue.ToString() + " " + "$ " + Format(dp.YValues(0), "##,##0.00")
            Else
                'dp.LegendText = dp.XValue.ToString() + " " + String.Format("{0:C}", dp.YValues(0))
                dp.LegendText = dp.XValue.ToString() + " " + "C$ " + Format(dp.YValues(0), "##,##0.00")
            End If
        Next dp
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub
End Class
