Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepActividadProductoLinea 

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
        Dim CostoPromedio As Double, Existencia As Double


        FechaIni = Format(FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        FechaFin = Format(FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")


        CodProducto = Me.TxtCodProducto.Text
        Compras = BuscaCompra(CodProducto, FechaIni, FechaFin)
        Me.TxtCompras.Text = Format(Compras, "##,##0.00")
        Me.TxtImporteCompras.Text = Format(ImporteCompra, "##,##0.00")

        Ventas = BuscaVenta(CodProducto, FechaIni, FechaFin)
        Me.TxtVentas.Text = Format(Ventas, "##,##0.00")
        Me.TxtImporteVenta.Text = Format(ImporteVenta, "##,##0.00")
        Me.TxtExistencia.Text = Format(ExistenciaProducto(CodProducto), "##,##0.00")
        Existencia = Me.TxtExistencia.Text
        CostoPromedio = Me.TxtCostoPromedio.Text
        Me.TxtExistenciaValores.Text = Existencia * CostoPromedio

        My.Application.DoEvents()
    End Sub
End Class
