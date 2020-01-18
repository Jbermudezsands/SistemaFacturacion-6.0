Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepVentasProductos 
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String = "", CodBodega As String = ""
        If Me.TxtCodBodega.Text <> "" Then
            CodBodega = Me.TxtCodBodega.Text
        End If

        '***********************************************************************************************************************************************
        '//////////////////////////////////BUSCO EL NOMBRE DE LA BODEGA SEGUN EL CODIGO /////////////////////////////////////////////////////////////
        '********************************************************************************************************************************************
        SqlString = "SELECT  *  FROM Bodegas WHERE (Cod_Bodega = '" & CodBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")
        If DataSet.Tables("Bodegas").Rows.Count <> 0 Then
            Me.TxtNombreBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Nombre_Bodega")
        End If



    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String = "", CodBodega As String = ""
        Dim Fecha1 As Date, Fecha2 As Date, Iva As Double, SubTotal As Double

        Fecha1 = FrmReportes.DTPFechaIni.Value
        Fecha2 = FrmReportes.DTPFechaFin.Value

        If Me.TxtCodBodega.Text <> "" Then
            CodBodega = Me.TxtCodBodega.Text
        End If

        Select Case FrmReportes.ListBox.Text
            Case "Reporte de Ventas x Productos al Credito"
                SqlString = "SELECT SUM(SubTotal) AS SubTotal, SUM(IVA) AS IVA FROM Facturas " & _
                            "WHERE (MetodoPago = 'Credito') AND (Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura') AND (Cod_Bodega BETWEEN '" & CodBodega & "' AND '" & CodBodega & "') "
            Case "Reporte de Ventas x Productos al Contado"
                SqlString = "SELECT SUM(SubTotal) AS SubTotal, SUM(IVA) AS IVA FROM Facturas " & _
                            "WHERE (MetodoPago <> 'Credito') AND (Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura') AND (Cod_Bodega BETWEEN '" & CodBodega & "' AND '" & CodBodega & "') "
            Case "Reporte de Ventas x Productos"
                SqlString = "SELECT SUM(SubTotal) AS SubTotal, SUM(IVA) AS IVA FROM Facturas " & _
                            "WHERE (Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Factura') AND (Cod_Bodega BETWEEN '" & CodBodega & "' AND '" & CodBodega & "') "
        End Select
        '***********************************************************************************************************************************************
        '//////////////////////////////////BUSCO EL TOTAL DE LAS FACTURAS /////////////////////////////////////////////////////////////
        '********************************************************************************************************************************************
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")
        If DataSet.Tables("Facturas").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("IVA")) Then
                Iva = DataSet.Tables("Facturas").Rows(0)("IVA")
            End If

        End If

        SubTotal = Me.TxtSubTotal.Text
        Me.TxtImpuesto.Text = Format(Iva, "##,##0.00")
        Me.TxtTotal.Text = Format(SubTotal + Iva, "##,##0.00")

    End Sub
End Class
