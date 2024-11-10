Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 



Public Class SubReporteFacturas
    Public CostoPromedios As Double

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Cantidad As Double = 0, CostoPromedio As Double = 0, FechaFactura As Date, CodigoBodega As String, CodigoProducto As String
        Dim PrecioUnitario As Double = 0, Importe As Double, ImporteCompras As Double = 0

        CodigoProducto = Me.TxtCodProducto.Text
        CodigoBodega = Me.TxtCodBodega.Text
        FechaFactura = FrmReportes.DTPFechaFin.Value
        PrecioUnitario = Me.TxtPrecioUnitario.Text
        'CostoPromedio = CostoPromedioKardexBodega(CodigoProducto, FechaFactura, CodigoBodega)


        If Me.TxtTipo.Text = "Devolucion de Venta" Then
            Me.TxtCantidad1.Visible = True
            Me.TxtImporte1.Visible = True
            Me.TxtCantidad2.Visible = False
            Me.TxtImporte2.Visible = False
            If Me.TxtCantidad1.Text <> "" Then
                Cantidad = Me.TxtCantidad1.Text
                CantidadCompra = CantidadCompra + Cantidad
            Else
                Cantidad = 0
            End If
            FechaFactura = Me.TxtFechaFactura.Text
            If Me.TxtImporte1.Text <> "" Then
                ImporteCompras = Me.TxtImporte1.Text
                TotalMontoCompras = TotalMontoCompras + ImporteCompras
            End If


        ElseIf Me.TxtTipo.Text = "Transferencia Enviada" Then
            Me.TxtCantidad1.Visible = False
            Me.TxtImporte1.Visible = False
            Me.TxtCantidad2.Visible = True
            Me.TxtImporte2.Visible = True
            If Me.TxtCantidad2.Text <> "" Then
                Cantidad = Me.TxtCantidad2.Text
                CantidadSalida = CantidadSalida + Cantidad
            Else
                Cantidad = 0
            End If
            If Me.TxtFechaFactura.Text <> "" Then
                FechaFactura = Me.TxtFechaFactura.Text
            End If
            CodigoBodega = Me.TxtCodBodega.Text

            Importe = Cantidad * PrecioUnitario
            Me.TxtImporte2.Text = Format(Importe, "##,##0.00")

        Else    'If Me.TxtTipo.Text = "Salida Bodega"

            Me.TxtCantidad1.Visible = False
            Me.TxtImporte1.Visible = False
            Me.TxtCantidad2.Visible = True
            Me.TxtImporte2.Visible = True
            If Me.TxtCantidad2.Text <> "" Then
                Cantidad = Me.TxtCantidad2.Text
                CantidadSalida = CantidadSalida + Cantidad
            Else
                Cantidad = 0
            End If
            If Me.TxtFechaFactura.Text <> "" Then
                FechaFactura = Me.TxtFechaFactura.Text
            End If
            CodigoBodega = Me.TxtCodBodega.Text
            If Me.TxtTotalImporte.Text <> "" Then
                Importe = Me.TxtTotalImporte.Text
            Else
                Importe = 0
            End If

            Me.TxtImporte2.Text = Format(Importe, "##,##0.00")
            End If

            TotalMontoFacturas = TotalMontoFacturas + Importe

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        TotalMontoFacturas = 0
    End Sub
End Class
