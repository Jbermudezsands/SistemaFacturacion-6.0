Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data
Imports System


Public Class ArepArqueoCaja
    Inherits ActiveReport3
    Private SrpDenominaCordobas As ArepDenominacion = Nothing, SrpDenominaDolares As ArepDenominacion = Nothing
    Private SrpDetalleChequeCordobas As ArepDetalleCheque = Nothing, SrpDetalleChequeDolares As ArepDetalleCheque = Nothing

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim NumeroArqueo As String, Fecha As String, SqlDatos As String

        NumeroArqueo = Me.TxtNumeroArqueo.Text
        Fecha = Format(CDate(Me.TxtFechaArqueo.Text), "yyyy-MM-dd")

        SqlDatos = "SELECT idDenominacion,Valor, Canitdad, Monto FROM Detalle_Arqueo WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Moneda = 'Cordobas')"
        CType(Me.SubReportDenom1.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportDenom1.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlDatos

        SqlDatos = "SELECT idDenominacion,Valor, Canitdad, Monto FROM Detalle_Arqueo WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Moneda = 'Dolares')"
        CType(Me.SubReportDenom2.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportDenom2.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlDatos

        SqlDatos = "SELECT NumeroFactura, NombrePago, NumeroTarjeta, Monto FROM Detalle_ArqueoCheque  " & _
                           "WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Modena = 'Cordobas') "
        CType(Me.SubReport1.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReport1.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlDatos

        SqlDatos = "SELECT NumeroFactura, NombrePago, NumeroTarjeta, Monto FROM Detalle_ArqueoCheque  " & _
                   "WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Modena = 'Dolares') "
        CType(Me.SubReport2.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReport2.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlDatos

    End Sub


    Private Sub ArepArqueoCaja_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If SrpDenominaCordobas Is Nothing Then
            SrpDenominaCordobas = New ArepDenominacion
            Me.SubReportDenom1.Report = SrpDenominaCordobas
            Me.SubReportDenom1.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If SrpDenominaDolares Is Nothing Then
            SrpDenominaDolares = New ArepDenominacion
            Me.SubReportDenom2.Report = SrpDenominaDolares
            Me.SubReportDenom2.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If SrpDetalleChequeCordobas Is Nothing Then
            SrpDetalleChequeCordobas = New ArepDetalleCheque
            Me.SubReport1.Report = SrpDetalleChequeCordobas
            Me.SubReport1.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If SrpDetalleChequeDolares Is Nothing Then
            SrpDetalleChequeDolares = New ArepDetalleCheque
            Me.SubReport2.Report = SrpDetalleChequeDolares
            Me.SubReport2.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub
End Class
