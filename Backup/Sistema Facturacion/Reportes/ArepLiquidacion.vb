Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepLiquidacion 
    Private DetalleSubReporte As ArepDetalleImpuestos = Nothing
    Public NumeroLiquidacion As String, FechaLiquidacion As Date

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim SqlString As String
        SqlString = "SELECT  Cod_Iva, SUM(Monto) AS Monto  FROM ImpuestosLiquidacion WHERE (Numero_Liquidacion = '" & NumeroLiquidacion & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(FechaLiquidacion, "yyyy-MM-dd") & "', 102)) GROUP BY Cod_Iva"
        CType(Me.SrpDetalleImpuesto.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpDetalleImpuesto.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString

    End Sub

    Private Sub ArepLiquidacion_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        DetalleSubReporte.Document.Dispose()
        DetalleSubReporte.Dispose()
        DetalleSubReporte = Nothing
    End Sub

    Private Sub ArepLiquidacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If DetalleSubReporte Is Nothing Then
            DetalleSubReporte = New ArepDetalleImpuestos
            Me.SrpDetalleImpuesto.Report = DetalleSubReporte
            Me.SrpDetalleImpuesto.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        'Me.DataSource = "SELECT  * FROM Liquidacion INNER JOIN Detalle_Liquidacion ON Liquidacion.Numero_Liquidacion = Detalle_Liquidacion.Numero_Liquidacion AND Liquidacion.Fecha_Liquidacion = Detalle_Liquidacion.Fecha_Liquidacion INNER JOIN Productos ON Detalle_Liquidacion.Cod_Producto = Productos.Cod_Productos  " & _
        '                "WHERE (Liquidacion.Numero_Liquidacion = '" & NumeroLiquidacion & "') AND (Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(FechaLiquidacion, "yyyy-MM-dd") & "', 102))"
    End Sub

    Private Sub Customers_DataInitialize(ByVal sender As Object, ByVal eArgs As System.EventArgs) Handles MyBase.DataInitialize
        'Assign Main data source
        'Dim ds As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        'SqlString = "SELECT  Cod_Iva, SUM(Monto) AS Monto  FROM ImpuestosLiquidacion WHERE (Numero_Liquidacion = '" & NumeroLiquidacion & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(FechaLiquidacion, "yyyy-MM-dd") & "', 102)) GROUP BY Cod_Iva"
        'ds.ConnectionString = Conexion
        'ds.SQL = SqlString
        'Me.DataSource = ds
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub
End Class
