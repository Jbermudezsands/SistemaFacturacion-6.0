Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class SubReporteCompras 
    Dim Importe As Double = 0, Cantidad As Double = 0
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If Me.TxtTipo.Text = "Devolucion de Compra" Then
            Me.TxtCantidad1.Visible = False
            Me.TxtImporte1.Visible = False
            Me.TxtCantidad2.Visible = True

            Me.TxtImporte2.Visible = True
            If Me.TxtImporte2.Text <> "" Then
                Importe = Me.TxtImporte2.Text
                TotalMontoFacturas = TotalMontoFacturas + Importe

            End If
            If Me.TxtCantidad2.Text <> "" Then
                Cantidad = Me.TxtCantidad2.Text
                CantidadSalida = CantidadSalida + Cantidad
            End If

        Else
            Me.TxtCantidad1.Visible = True
            Me.TxtImporte1.Visible = True
            Me.TxtCantidad2.Visible = False
            Me.TxtImporte2.Visible = False
            If Me.TxtImporte1.Text <> "" Then
                Importe = Me.TxtImporte1.Text
                TotalMontoCompras = TotalMontoCompras + Importe
            End If

            If Me.TxtCantidad1.Text <> "" Then
                Cantidad = Me.TxtCantidad1.Text
                CantidadCompra = CantidadCompra + Cantidad
            End If
        End If
    End Sub
End Class
