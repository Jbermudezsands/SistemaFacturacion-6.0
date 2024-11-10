Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document




Public Class ArepDetalleMovimientoProducto

    Public CantidadSaldo As Double, ImporteSaldo As Double

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim FechaIni As String, Inicial As Double

        My.Application.DoEvents()

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        If FrmReportes.CmbAgrupado.Text = "Bodega" Then
            Inicial = BuscaInventarioInicialEntreBodega(Me.TxtCodProducto.Text, FechaIni, My.Forms.FrmReportes.CmbRango1.Text, My.Forms.FrmReportes.CmbRango2.Text)
        Else
            Inicial = BuscaInventarioInicial(Me.TxtCodProducto.Text, FechaIni)
        End If

        CantidadSaldo = Inicial
        ImporteSaldo = MontoInicial

        Me.TxtSaldoInicial.Text = Format(Inicial, "##,##0.00")
        Me.TxtImporteInicial.Text = Format(MontoInicial, "##,##0.00")
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim CantidadInicia As Double, ImporteInicia As Double, CantidadEntrada As Double, ImporteEntrada As Double
        Dim CantidadSalida As Double, ImporteSalida As Double

        CantidadInicia = Me.TxtSaldoInicial.Text
        ImporteInicia = Me.TxtImporteInicial.Text
        CantidadEntrada = Me.TxtCantidadEntrada.Text
        ImporteEntrada = Me.TxtImporteEntrada.Text
        CantidadSalida = Me.TxtCantidadSalida.Text
        ImporteSalida = Me.TxtImporteSalida.Text

        Me.LblTotalCantidad3.Text = Format(CantidadInicia + CantidadEntrada - CantidadSalida, "##,##0.00")
        Me.LblTotalImporte3.Text = Format(ImporteInicia + ImporteEntrada - ImporteSalida, "##,##0.00")



    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Cantidad1 As Double = 0, Cantidad2 As Double = 0, Importe1 As Double = 0, Importe2 As Double = 0

        If Me.TxtCantidad1.Text <> "" Then
            Cantidad1 = Me.TxtCantidad1.Text
        End If

        If Me.TxtCantidad2.Text <> "" Then
            Cantidad2 = Me.TxtCantidad2.Text
        End If

        If Me.TxtImporte1.Text <> "" Then
            Importe1 = Me.TxtImporte1.Text
        End If

        If Me.TxtImporte2.Text <> "" Then
            Importe2 = Me.TxtImporte2.Text
        End If

        CantidadSaldo = CantidadSaldo + Cantidad1 - Cantidad2
        ImporteSaldo = ImporteSaldo + Importe1 - Importe2

        Me.LblCantidadSaldo.Text = Format(CantidadSaldo, "##,##0.00")
        Me.LblImporteSaldo.Text = Format(ImporteSaldo, "##,##0.00")


    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
