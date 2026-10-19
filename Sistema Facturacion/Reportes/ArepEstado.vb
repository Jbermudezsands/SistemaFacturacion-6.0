Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepEstado 
    Inherits ActiveReport3
    Private MovimientosSubReport As ArepSubReporteMovPrestamos = Nothing
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim NumeroPrestamo As String = "", SqlPagos As String = ""

        NumeroPrestamo = Me.TxtNumeroPrestamo.Text

        SqlPagos = "SELECT Prestamo.NumPrestamo, Prestamo.CodTipoPrestamo, TipoPrestamo.TipoPrestamo, Prestamo.PorcInteres, Prestamo.CodProductor, NProductor.NombreProductor + ' ' + NProductor.ApellidosProductor AS NombreSocio, Prestamo.CantCuotas, Prestamo.MontoPrestamo, Prestamo.MontoInteres, Prestamo.MontoMantoValor, Prestamo.MontoTotal, Prestamo.FechaInicial, Prestamo.Moneda, Prestamo.FechaUltMov, Prestamo.FechaVencimiento, Prestamo.CantDias, Prestamo.Reestructurado, Prestamo.Cancelado, Prestamo.DeCadaMes, MovPrestamo.NumCuota, MovPrestamo.Tipo, MovPrestamo.Monto, MovPrestamo.Interes, MovPrestamo.MantoValor, MovPrestamo.Saldo, MovPrestamo.Mora, MovPrestamo.Fecha, MovPrestamo.FechaMora, MovPrestamo.Dias, MovPrestamo.Cancelado, MovPrestamo.Monto + MovPrestamo.Interes + MovPrestamo.MantoValor AS TotalCuota FROM  NProductor INNER JOIN Prestamo ON NProductor.CodProductor = Prestamo.CodProductor INNER JOIN TipoPrestamo INNER JOIN MovPrestamo ON TipoPrestamo.CodTipoPrestamo = MovPrestamo.CodTipoPrestamo ON Prestamo.NumPrestamo = MovPrestamo.NumPrestamo  WHERE (Prestamo.NumPrestamo = '" & NumeroPrestamo & "') ORDER BY MovPrestamo.NumCuota"

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SubReportMovPrestamos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportMovPrestamos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlPagos
        My.Application.DoEvents()
    End Sub

    Private Sub ArepEstado_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////ENLAZO EL OBJETO SUB REPORT, CON EL SUB REPORTE CREADO COMO OBJETO////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If MovimientosSubReport Is Nothing Then
            MovimientosSubReport = New ArepSubReporteMovPrestamos
            Me.SubReportMovPrestamos.Report = MovimientosSubReport
            Me.SubReportMovPrestamos.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
