Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document


Public Class ArepVentasVendedor
    Public VentasTotales As Double
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

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim dp As DataDynamics.ActiveReports.Chart.DataPoint
        For Each dp In ChartControl.Series(0).Points
            dp.DisplayInLegend = New DataDynamics.ActiveReports.Chart.NullableBoolean(True)
            dp.LegendText = dp.XValue.ToString() + " " + String.Format("{0:C}", dp.YValues(0))
        Next dp
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub
End Class
