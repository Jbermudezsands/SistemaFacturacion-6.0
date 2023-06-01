Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepKardex 

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
        'Dim CostoPromedio As Double, Inicial As Double, VentasInicial As Double, ComprasInicial As Double
        'Dim Saldo As Double
        ''Existencia As Double

        'FechaIni = Format(FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        'FechaFin = Format(FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")

        'CodProducto = Me.TxtCodProducto.Text

        'Compras = BuscaCompra(CodProducto, FechaIni, FechaFin)
        'ComprasInicial = BuscaCompraAcumulada(CodProducto, FechaIni)
        'Me.TxtEntrada.Text = Format(Compras, "##,##0.00")


        'Ventas = BuscaVenta(CodProducto, FechaIni, FechaFin)
        'Me.TxtSalida.Text = Format(Ventas, "##,##0.00")
        'VentasInicial = BuscaVentaAcumulada(CodProducto, FechaIni)
        ''Me.TxtImporteVenta.Text = Format(ImporteVenta, "##,##0.00")


        ''Existencia = Me.TxtSaldo.Text
        'CostoPromedio = Me.TxtCostoPromedio.Text
        ''Me.TxtExistenciaValores.Text = Existencia * CostoPromedio

        ''Inicial = Existencia + Ventas - Compras
        'Inicial = ComprasInicial - VentasInicial
        'Me.TxtInicial.Text = Format(Inicial, "##,##0.00")
        'Saldo = Inicial + Compras - Ventas

        'Me.TxtSaldo.Text = Format(Inicial + Compras - Ventas, "##,##0.00")
        'Me.TxtInicialM.Text = Format(Inicial * CostoPromedio, "##,##0.00")
        'Me.TxtEntradaM.Text = Format(Compras * CostoPromedio, "##,##0.00")
        'Me.TxtSalidaM.Text = Format(Ventas * CostoPromedio, "##,##0.00")
        'Me.TxtSaldoM.Text = Format(Saldo * CostoPromedio, "##,##0.00")

        'My.Forms.FrmReportes.Text = "Procesando: " & CodProducto
        'My.Forms.FrmReportes.ProgressBar.Value = My.Forms.FrmReportes.ProgressBar.Value + 1
        'My.Application.DoEvents()


    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub
End Class
