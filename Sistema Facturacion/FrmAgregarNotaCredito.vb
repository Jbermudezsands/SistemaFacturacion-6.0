Public Class FrmAgregarNotaCredito
    Public Numero_Factura As String, Fecha_Factura As String, MontoFactura As Double

    Private Sub FrmAgregarNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblNumeroFactura.Text = Numero_Factura
        Me.LblMontoFactura.Text = MontoFactura
    End Sub
End Class