Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepKardexLinea
    Public TotalInicial As Double = 0, TotalCompras As Double = 0, TotalVentas As Double = 0, TotalExistencia As Double = 0, TotalInicialM As Double, TotalComprasM As Double = 0, TotalVentasM As Double = 0, TotalExistenciaM As Double

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
        'Dim CostoPromedio As Double, Existencia As Double, Inicial As Double, CodBodega As String
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim Sql As String


        'FechaIni = Format(FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        'FechaFin = Format(FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")

        ''/////////////////ESTE ES EL COSTO PROMEDIO GENERAL ////////////////////
        'If Me.TxtCostoPromedio.Text <> "" Then
        '    CostoPromedio = Me.TxtCostoPromedio.Text
        'End If

        'CodProducto = Me.TxtCodProducto.Text

        'If Me.TxtCodProducto.Text = Nothing Then
        '    Exit Sub
        'End If


        'If FrmReportes.CmbAgrupado.Text = "Bodega" Then
        '    CodBodega = Me.TxtCodLinea.Text

        '    CostoPromedio = CostoBodega(CodProducto, CodBodega)
        '    Me.TxtCostoPromedio.Text = Format(CostoPromedio, "##,##0.00")



        '    Compras = BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega)
        '    Me.TxtEntrada.Text = Format(Compras, "##,##0.00")

        '    Ventas = BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega)
        '    Me.TxtSalida.Text = Format(Ventas, "##,##0.00")

        '    Inicial = BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega)
        '    Me.TxtInicial.Text = Format(Inicial, "##,##0.00")

        '    Existencia = Inicial + Compras - Ventas
        '    Me.TxtSaldo.Text = Format(Existencia, "##,##0.00")

        'Else

        '    Compras = BuscaCompra(CodProducto, FechaIni, FechaFin)
        '    Me.TxtEntrada.Text = Format(Compras, "##,##0.00")

        '    Ventas = BuscaVenta(CodProducto, FechaIni, FechaFin)
        '    Me.TxtSalida.Text = Format(Ventas, "##,##0.00")




        '    'Me.TxtExistenciaValores.Text = Existencia * CostoPromedio

        '    Inicial = BuscaCompraAcumulada(CodProducto, FechaIni) - BuscaVentaAcumulada(CodProducto, FechaIni)
        '    Me.TxtInicial.Text = Format(Inicial, "##,##0.00")

        '    Existencia = Inicial + Compras - Ventas
        '    Me.TxtSaldo.Text = Format(Existencia, "##,##0.00")
        '    CostoPromedio = Me.TxtCostoPromedio.Text

        'End If


        'Me.TxtInicialM.Text = Format(Inicial * CostoPromedio, "##,##0.00")
        'Me.TxtEntradaM.Text = Format(Compras * CostoPromedio, "##,##0.00")
        'Me.TxtSalidaM.Text = Format(Ventas * CostoPromedio, "##,##0.00")
        'Me.TxtSaldoM.Text = Format(Existencia * CostoPromedio, "##,##0.00")


        ''///////////////////////////////SUMO LAS VARIABLES ///////////////////////////////////////
        'TotalInicial = TotalInicial + Inicial
        'TotalCompras = TotalCompras + Compras
        'TotalVentas = TotalVentas + Ventas
        'TotalExistencia = TotalInicial + TotalCompras - TotalVentas

        'TotalInicialM = TotalInicialM + (Inicial * CostoPromedio)
        'TotalComprasM = TotalComprasM + (Compras * CostoPromedio)
        'TotalVentasM = TotalVentasM + (Ventas * CostoPromedio)
        'TotalExistenciaM = TotalExistenciaM + (Existencia * CostoPromedio)






        'My.Forms.FrmReportes.Text = "Procesando: " & CodProducto

        'If My.Forms.FrmReportes.ProgressBar.Maximum <> 0 Then
        '    My.Forms.FrmReportes.ProgressBar.Value = My.Forms.FrmReportes.ProgressBar.Value + 1
        'End If

        'My.Application.DoEvents()

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        'Me.TxtTotalInicial.Text = Format(TotalInicial, "##,##0.00")
        'Me.TxtTotalEntrada.Text = Format(TotalCompras, "##,##0.00")
        'Me.TxtTotalSalida.Text = Format(TotalVentas, "##,##0.00")
        'Me.TxtTotalSaldo.Text = Format(TotalExistencia, "##,##0.00")

        'Me.TxtTotalInicalM.Text = Format(TotalInicialM, "##,##0.00")
        'Me.TxtTotalEntradaM.Text = Format(TotalComprasM, "##,##0.00")
        'Me.TxtTotalSalidaM.Text = Format(TotalVentasM, "##,##0.00")
        'Me.TxtTotalSaldoM.Text = Format(TotalExistenciaM, "##,##0.00")

        Me.LblTotal.Text = "Total de " & Me.Label20.Text

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        TotalInicial = 0
        TotalCompras = 0
        TotalVentas = 0
        TotalExistencia = 0
        TotalInicialM = 0
        TotalComprasM = 0
        TotalVentasM = 0
        TotalExistenciaM = 0

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    End Sub
End Class
