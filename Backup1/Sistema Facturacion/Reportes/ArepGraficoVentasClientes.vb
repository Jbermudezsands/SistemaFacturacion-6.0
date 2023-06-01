Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepGraficoVentasClientes 
    Public VentasTotales As Double

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        Dim dp As DataDynamics.ActiveReports.Chart.DataPoint
        For Each dp In Me.ChartControl1.Series(0).Points
            dp.DisplayInLegend = New DataDynamics.ActiveReports.Chart.NullableBoolean(True)
            If FrmReportes.OptDolares.Checked = True Then
                dp.LegendText = dp.XValue.ToString() + " " + "$ " + Format(dp.YValues(0), "##,##0.00")
            Else
                dp.LegendText = dp.XValue.ToString() + " " + "C$ " + Format(dp.YValues(0), "##,##0.00")
            End If
        Next dp
    End Sub


    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Venta As Double
        If Val(Me.TxtVentas.Text) <> 0 Then
            Venta = Me.TxtVentas.Text
        Else
            Venta = 0
        End If
        If VentasTotales <> 0 Then
            Me.LblPorciento.Text = Format((Venta / VentasTotales), "0.00%")
        End If
    End Sub
End Class
