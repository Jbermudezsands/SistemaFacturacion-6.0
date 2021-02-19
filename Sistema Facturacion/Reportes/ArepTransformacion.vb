Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepTransformacion 
    Public Numero As String, RutaLogo As String
    Private ComprasSubReport As ArepSubDetalleTransformacion = Nothing
    Private FacturasSubReport As ArepSubDetalleTransformacion = Nothing

    Private Sub ArepTransformacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If ComprasSubReport Is Nothing Then
            ComprasSubReport = New ArepSubDetalleTransformacion
            Me.SrpCompras.Report = ComprasSubReport
            Me.SrpCompras.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If FacturasSubReport Is Nothing Then
            FacturasSubReport = New ArepSubDetalleTransformacion
            Me.SrpFacturas.Report = FacturasSubReport
            Me.SrpFacturas.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If Dir(RutaLogo) <> "" Then
            Me.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim SqlString As String, SqlStringDestino As String

        '//////////////////////////////////////////////////////EL ORIGEN ES SALIDA ////////////////////////////////////////
        SqlString = "SELECT  Detalle_Transformacion.*, Productos.Unidad_Medida FROM Detalle_Transformacion INNER JOIN Productos ON Detalle_Transformacion.Codigo_Producto = Productos.Cod_Productos  " & _
                    "WHERE (Detalle_Transformacion.Numero_Transforma = '" & Numero & "') AND (Detalle_Transformacion.TipoTransforma = 'Origen')"
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString

        '//////////////////////////////////////////////////////EL DESTINO ES ENTRADA ////////////////////////////////////////////////////7
        SqlString = "SELECT  Detalle_Transformacion.*, Productos.Unidad_Medida FROM Detalle_Transformacion INNER JOIN Productos ON Detalle_Transformacion.Codigo_Producto = Productos.Cod_Productos  " & _
                    "WHERE (Detalle_Transformacion.Numero_Transforma = '" & Numero & "') AND (Detalle_Transformacion.TipoTransforma = 'Destino')"
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString

        My.Application.DoEvents()
    End Sub
End Class
