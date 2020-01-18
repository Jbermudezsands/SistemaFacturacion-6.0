Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepVentasClientes 
    Public MiConexion As New SqlClient.SqlConnection(Conexion), TotalDescuentoDia As Double = 0, TotalDescuentoTotal As Double = 0, Fecha As Date
    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.TxtDescripcion1.Text = "Sub Total del Dia   " & Format(Fecha, "dd/MM/yyyy")
        TotalDescuentoTotal = TotalDescuentoTotal + TotalDescuentoDia
        Me.TxtDescuentoDia.Text = Format(TotalDescuentoDia, "##,##0.00")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SqlString As String = "", NumeroFactura As String, MontoDescuento As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TasaCambio As Double = 0

        NumeroFactura = Me.TxtNumeroFactrua.Text
        If Me.TxtFecha.Text <> "" Then
            Fecha = Me.TxtFecha.Text
        End If


        SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Precio_Neto, Productos.Tipo_Producto, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Cantidad FROM Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                    "WHERE (Productos.Tipo_Producto = 'Descuento') AND (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TotalFacturas")
        If DataSet.Tables("TotalFacturas").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Precio_Unitario")) Then
                MontoDescuento = DataSet.Tables("TotalFacturas").Rows(0)("Precio_Unitario")
            End If
        End If

        If Me.TxtFecha.Text <> "" Then
            Fecha = Me.TxtFecha.Text
        End If
        TotalDescuentoDia = TotalDescuentoDia + MontoDescuento
        Me.TxtDescuento.Text = Format(MontoDescuento, "##,##0.00")

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        TotalDescuentoDia = 0
        Fecha = Now
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Me.TxtTotalDecuento.Text = Format(TotalDescuentoTotal, "##,##0.00")
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ArepVentasClientes_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.Label7.Text = "Impreso: " & Format(Now, "dd/MM/yyyy") & "Municipio Desde " & FrmReportes.CboMunicipioIni.Text & " Hasta " & FrmReportes.CboMunicipio2.Text & " Dpto Desde " & FrmReportes.CboCodDepartamentoIni.Text & "Hasta " & FrmReportes.CboCodDepartamentoFin.Text
    End Sub
End Class
