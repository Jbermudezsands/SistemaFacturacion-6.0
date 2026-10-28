Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepEstadoCuentas2 

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.LblCargo.Text = Me.TxtTotalCargo.Text
        Me.LblAbono.Text = Me.TxtTotalAbono.Text
        Me.LblMora.Text = Me.TxtTotalMora.Text
        Me.LblSaldoFinal.Text = Me.TxtTotalSaldoFinal.Text

    End Sub

    ' Factura vencida con saldo: la fila sale en rojo (mismo criterio que FrmCuentasXCobrar)
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim vencida As Boolean = False
        Try
            Dim saldo As Object = Me.Fields("Saldo").Value
            Dim dias As Object = Me.Fields("Dias").Value
            vencida = saldo IsNot Nothing AndAlso Not IsDBNull(saldo) AndAlso CDec(saldo) > 0D AndAlso
                      dias IsNot Nothing AndAlso Not IsDBNull(dias) AndAlso CInt(dias) > 0
        Catch
        End Try

        Dim color As System.Drawing.Color = If(vencida, System.Drawing.Color.FromArgb(185, 28, 28), System.Drawing.Color.Black)
        For Each c As DataDynamics.ActiveReports.ARControl In Me.Detail1.Controls
            Dim t As DataDynamics.ActiveReports.TextBox = TryCast(c, DataDynamics.ActiveReports.TextBox)
            If t IsNot Nothing Then t.ForeColor = color
        Next
    End Sub
End Class
