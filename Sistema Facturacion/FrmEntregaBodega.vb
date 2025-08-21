Imports System.Data.Common
Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Imports Microsoft.Win32

Public Class FrmEntregaBodega
    Public MiConexion As New SqlClient.SqlConnection(Conexion)


    Public Sub Cargar_Entrega(Entregado As Integer)
        Dim Sqlstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter



        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////CARGO LAS ADMISIONES PARA ESTE PACIENTE ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.Tipo_Factura, Facturas.Nombre_Cliente, Vendedores.Nombre_Vendedor, Facturas.MonedaFactura, Facturas.Cod_Bodega, Facturas.Observaciones, Facturas.Entregada FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Nombre_Cliente <> N'******CANCELADO')  AND (Facturas.Entregada = " & Entregado & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Facturas")
        Me.TrueDBGridConsultas.Columns("Numero_Factura").Caption = "Numero Factura"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Factura").Width = 70
    End Sub


    Private Sub FrmEntregaBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Entrega(0)
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.CmbConsultas.Text = "Pendiente" Then
            Cargar_Entrega(0)
        ElseIf Me.CmbConsultas.Text = "Entregado" Then
            Cargar_Entrega(1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, ArepFacturas As New ArepFacturas, SqlDatos As String, RutaLogo As String, Impresora_Defecto As String, SqlString As String
        Dim ArepFacturasTiras As New ArepFacturasTiras2, ArepFacturaMediaPagina As New ArepFacturaMedia, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Fecha As String, TasaCambio As Double
        Dim ArepCotizaciones As New ArepCotizaciones, ImprimeFacturaPreview As Boolean = True, CostoUnitario As Double = 0
        Dim ArepFacturasTareas As New ArepFacturasTareas, FacturaBodega As Boolean = False, CompraBodega As Boolean = False, ArepSalidaBodega As New ArepSalidaBodega
        Dim ArepFacturas2 As New ArepFacturas2, ArepOrdenTrabajo As New ArepFacturasTiras, Cont As Double, Monto As Double = 0
        Dim TipoImpresion As String, NumeroFactura As String, MonedaFactura As String, MonedaImprime As String
        Dim NombrePago As String, NumeroTarjeta As String, FechaVenceTarjeta As Date, SQlDetalle As String, TipoFactura As String = ""
        Dim SubTotal As Double = 0, Iva As Double = 0

        NumeroFactura = Me.TrueDBGridConsultas.Columns("Numero_Factura").Text

        Me.Button1.Enabled = False
        Me.Button2.Enabled = False
        Me.CmdGuardar.Enabled = False



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                ImprimeFacturaPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
            Else
                ImprimeFacturaPreview = False
            End If


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                ArepFacturasTiras.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepFacturas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepFacturasTareas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepFacturasTiras.LblRuc.Text = "RUC: " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepSalidaBodega.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepFacturaMediaPagina.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepFacturas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    'ArepCotizacionFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepFacturasTareas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepFacturasTiras.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepSalidaBodega.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    'ArepCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        SqlString = "SELECT  * FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega WHERE  (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Nombre_Cliente <> N'******CANCELADO') AND (Facturas.Numero_Factura = '" & NumeroFactura & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Factura")
        If DataSet.Tables("Factura").Rows.Count <> 0 Then

            TipoFactura = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            Iva = DataSet.Tables("Factura").Rows(0)("IVA")
            SubTotal = DataSet.Tables("Factura").Rows(0)("SubTotal")

            ArepFacturaMediaPagina.LblVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")
            ArepFacturas.LblVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")
            ArepFacturas2.LblVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")
            ArepFacturas.Label1.Text = "Cliente"
            ArepFacturaMediaPagina.LblOrden.Text = NumeroFactura
            ArepFacturas.LblNotas.Text = DataSet.Tables("Factura").Rows(0)("Observaciones")
            ArepFacturas.LblOrden.Text = NumeroFactura
            ArepFacturas.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepFacturas.LblTipoCompra.Text = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            ArepFacturas.LblCodProveedor.Text = DataSet.Tables("Factura").Rows(0)("Cod_Cliente")
            ArepFacturas.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente")
            ArepFacturaMediaPagina.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente")
            ArepFacturas.LblApellidos.Text = DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")
            ArepFacturaMediaPagina.LblApellidos.Text = DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")

            ArepFacturas.LblDireccionProveedor.Text = DataSet.Tables("Factura").Rows(0)("Direccion_Cliente")
            ArepFacturas.LblTelefono.Text = DataSet.Tables("Factura").Rows(0)("Telefono_Cliente")
            ArepFacturas.LblFechaVence.Text = DataSet.Tables("Factura").Rows(0)("Fecha_Vencimiento")
            ArepFacturas.LblBodegas.Text = DataSet.Tables("Factura").Rows(0)("Cod_Bodega") + " " + DataSet.Tables("Factura").Rows(0)("Nombre_Bodega")

            ArepFacturas2.Label1.Text = "Cliente"
            ArepFacturas2.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepFacturas2.LblNotas.Text = DataSet.Tables("Factura").Rows(0)("Observaciones")
            ArepFacturas2.LblCodProveedor.Text = DataSet.Tables("Factura").Rows(0)("Cod_Cliente")
            ArepFacturas2.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente")
            ArepFacturas2.LblApellidos.Text = DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")
            ArepFacturas2.LblDireccionProveedor.Text = DataSet.Tables("Factura").Rows(0)("Direccion_Cliente")
            ArepFacturas2.LblTelefono.Text = DataSet.Tables("Factura").Rows(0)("Telefono_Cliente")
            ArepFacturas2.LblFechaVence.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Vencimiento")), "dd/MM/yyyy")
            ArepFacturas2.LblBodegas.Text = DataSet.Tables("Factura").Rows(0)("Cod_Bodega") + " " + DataSet.Tables("Factura").Rows(0)("Nombre_Bodega")

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTareas.LblVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")
            ArepFacturasTareas.Label1.Text = "Cliente"
            ArepFacturasTareas.LblNotas.Text = DataSet.Tables("Factura").Rows(0)("Observaciones")
            ArepFacturasTareas.LblOrden.Text = NumeroFactura
            ArepFacturasTareas.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepFacturasTareas.LblTipoCompra.Text = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            ArepFacturasTareas.LblCodProveedor.Text = DataSet.Tables("Factura").Rows(0)("Cod_Cliente")
            ArepFacturasTareas.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente")
            ArepFacturasTareas.LblApellidos.Text = DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")
            ArepFacturasTareas.LblDireccionProveedor.Text = DataSet.Tables("Factura").Rows(0)("Direccion_Cliente")
            ArepFacturasTareas.LblTelefono.Text = DataSet.Tables("Factura").Rows(0)("Telefono_Cliente")
            ArepFacturasTareas.LblFechaVence.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Vencimiento")), "dd/MM/yyyy")
            ArepFacturaMediaPagina.LblFechaVence.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Vencimiento")), "dd/MM/yyyy")
            ArepFacturasTareas.LblBodegas.Text = DataSet.Tables("Factura").Rows(0)("Cod_Bodega") + " " + DataSet.Tables("Factura").Rows(0)("Nombre_Bodega")

            ArepSalidaBodega.LblBodegas.Text = DataSet.Tables("Factura").Rows(0)("Cod_Bodega") + " " + DataSet.Tables("Factura").Rows(0)("Nombre_Bodega")

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepFacturasTiras.LblOrden.Text = NumeroFactura
            ArepFacturasTiras.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepFacturasTiras.LblTipoCompra.Text = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            ArepFacturasTiras.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")
            ArepFacturasTiras.LblApellidos.Text = DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepOrdenTrabajo.LblOrden.Text = NumeroFactura
            ArepOrdenTrabajo.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepOrdenTrabajo.LblTipoCompra.Text = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            ArepOrdenTrabajo.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")



            ArepSalidaBodega.LblOrden.Text = NumeroFactura
            ArepSalidaBodega.LblFechaOrden.Text = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "dd/MM/yyyy")
            ArepSalidaBodega.LblTipoCompra.Text = DataSet.Tables("Factura").Rows(0)("Tipo_Factura")
            ArepSalidaBodega.LblNombres.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Factura").Rows(0)("Apellido_Cliente")

            MonedaFactura = DataSet.Tables("Factura").Rows(0)("MonedaFactura")
            MonedaImprime = DataSet.Tables("Factura").Rows(0)("MonedaImprime")
            Fecha = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = 1
                Else
                    TasaCambio = (1 / BuscaTasaCambio(Fecha))
                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = BuscaTasaCambio(Fecha)
                Else
                    TasaCambio = 1
                End If
            End If

            'If Val(Me.TxtSubTotal.Text) <> 0 Then
            '    ArepCotizacionFoto.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblSubTotal.Text = "0.00"
            'End If

            If Val(DataSet.Tables("Factura").Rows(0)("IVA")) <> 0 Then
                ArepSalidaBodega.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
            Else
                ArepSalidaBodega.LblIva.Text = "0.00"
            End If

            'If Val(Me.TxtIva.Text) <> 0 Then
            '    ArepCotizacionFoto.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblIva.Text = "0.00"
            'End If

            'If Val(Me.TxtPagado.Text) <> 0 Then
            '    ArepCotizacionFoto.LblPagado.Text = Format(CDbl(Me.TxtPagado.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblPagado.Text = "0.00"
            'End If
            'If Val(Me.TxtNetoPagar.Text) <> 0 Then
            '    ArepCotizacionFoto.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblTotal.Text = "0.00"
            'End If
            'If Val(Me.TxtDescuento.Text) <> 0 Then
            '    ArepCotizacionFoto.LblDescuento.Text = Format(CDbl(Me.TxtDescuento.Text) * TasaCambio, "##,##0.00")
            'Else
            '    ArepCotizacionFoto.LblDescuento.Text = "0.00"
            'End If


            If Val(DataSet.Tables("Factura").Rows(0)("SubTotal")) <> 0 Then
                'ArepCotizaciones.LblSubTotal.Text = Format(CDbl(Me.TxtSubTotal.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPropina.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblSubTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) * TasaCambio, "##,##0.00")

            Else
                'ArepCotizaciones.LblSubTotal.Text = "0.00"
                ArepFacturas.LblSubTotal.Text = "0.00"
                ArepFacturas2.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblSubTotal.Text = "0.00"
                ArepSalidaBodega.LblSubTotal.Text = "0.00"
                ArepOrdenTrabajo.LblSubTotal.Text = "0.00"
                ArepFacturasTiras.LblPropina.Text = "0.00"
                ArepFacturaMediaPagina.LblSubTotal.Text = "0.00"
                ArepFacturasTareas.LblSubTotal.Text = "0.00"
            End If

            If Val(DataSet.Tables("Factura").Rows(0)("IVA")) <> 0 Then
                'ArepCotizaciones.LblIva.Text = Format(CDbl(Me.TxtIva.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblIva.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblIva.Text = "0.00"
                ArepFacturas.LblIva.Text = "0.00"
                ArepFacturas2.LblIva.Text = "0.00"
                ArepFacturasTiras.LblIva.Text = "0.00"
                ArepOrdenTrabajo.LblIva.Text = "0.00"
                ArepFacturaMediaPagina.LblIva.Text = "0.00"
                ArepFacturasTareas.LblIva.Text = "0.00"
            End If

            If Val(DataSet.Tables("Factura").Rows(0)("Pagado")) <> 0 Then
                ArepFacturas.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Pagado")) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblPagado.Text = "0.00"
                ArepFacturas2.LblPagado.Text = "0.00"
                ArepFacturasTiras.LblPagado.Text = "0.00"
                ArepOrdenTrabajo.LblPagado.Text = "0.00"
                ArepFacturaMediaPagina.LblPagado.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"
            End If

            If Val(DataSet.Tables("Factura").Rows(0)("NetoPagar")) <> 0 Then
                'ArepCotizaciones.LblTotal.Text = Format(CDbl(Me.TxtNetoPagar.Text) * TasaCambio, "##,##0.00")
                ArepFacturas.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepFacturasTiras.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepOrdenTrabajo.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepSalidaBodega.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblTotal.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblPagado.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("NetoPagar")) * TasaCambio, "##,##0.00")
            Else
                'ArepCotizaciones.LblTotal.Text = "0.00"
                ArepFacturas.LblTotal.Text = "0.00"
                ArepFacturas2.LblTotal.Text = "0.00"
                ArepFacturasTiras.LblTotal.Text = "0.00"
                ArepOrdenTrabajo.LblTotal.Text = "0.00"
                ArepSalidaBodega.LblTotal.Text = "0.00"
                ArepFacturaMediaPagina.LblTotal.Text = "0.00"
                ArepFacturasTareas.LblPagado.Text = "0.00"

            End If
            If Val(DataSet.Tables("Factura").Rows(0)("Descuentos")) <> 0 Then
                ArepFacturas.LblDescuento.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Descuentos")) * TasaCambio, "##,##0.00")
                ArepFacturas2.LblDescuento.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Descuentos")) * TasaCambio, "##,##0.00")
                ArepFacturaMediaPagina.LblDescuento.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Descuentos")) * TasaCambio, "##,##0.00")
                ArepFacturasTareas.LblDescuento.Text = Format(CDbl(DataSet.Tables("Factura").Rows(0)("Descuentos")) * TasaCambio, "##,##0.00")
            Else
                ArepFacturas.LblDescuento.Text = "0.00"
                ArepFacturas2.LblDescuento.Text = "0.00"
                ArepFacturaMediaPagina.LblDescuento.Text = "0.00"
                ArepFacturasTareas.LblDescuento.Text = "0.00"
            End If


            ArepFacturasTiras.LblTotal1.Text = Format((CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) + CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal")) + CDbl(DataSet.Tables("Factura").Rows(0)("Propina"))) * TasaCambio, "##,##0.00")
            ArepOrdenTrabajo.LblTotal1.Text = Format((CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) + CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal"))) * TasaCambio, "##,##0.00")
            ArepSalidaBodega.LblTotal.Text = Format((CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) + CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal"))) * TasaCambio, "##,##0.00")
            ArepFacturasTareas.LblTotal.Text = Format((CDbl(DataSet.Tables("Factura").Rows(0)("IVA")) + CDbl(DataSet.Tables("Factura").Rows(0)("SubTotal"))) * TasaCambio, "##,##0.00")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////IMPRIMO LOS METODOS DE PAGO /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            ArepFacturas.TxtMetodo.Text = "Credito"
            ArepFacturas2.TxtMetodo.Text = "Credito"


            SqlString = "SELECT * FROM Detalle_MetodoFacturas WHERE (Numero_Factura = '" & NumeroFactura & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            Cont = DataSet.Tables("Metodo").Rows.Count
            i = 0
            Monto = 0

            Do While Cont > i
                NombrePago = DataSet.Tables("Metodo").Rows(i)("NombrePago")
                Monto = DataSet.Tables("Metodo").Rows(i)("Monto") + Monto
                If Not IsDBNull(DataSet.Tables("Metodo").Rows(i)("NumeroTarjeta")) Then
                    NumeroTarjeta = DataSet.Tables("Metodo").Rows(i)("NumeroTarjeta")
                Else
                    NumeroTarjeta = 0
                End If
                If Not IsDBNull(DataSet.Tables("Metodo").Rows(i)("FechaVence")) Then
                    FechaVenceTarjeta = DataSet.Tables("Metodo").Rows(i)("FechaVence")
                Else
                    FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
                End If

                ArepFacturas.TxtMetodo.Text = NombrePago & " " & Monto
                ArepFacturas2.TxtMetodo.Text = NombrePago & " " & Monto

                i = i + 1
            Loop



            SQlDetalle = ""
            Fecha = Format(CDate(DataSet.Tables("Factura").Rows(0)("Fecha_Factura")), "yyyy-MM-dd")
            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT     Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * (1 / TasaCambio.MontoTasa) AS Precio_Unitario, Detalle_Facturas.Descuento * (1 / TasaCambio.MontoTasa) AS Descuento, Detalle_Facturas.Precio_Neto * (1 / TasaCambio.MontoTasa) AS Precio_Neto, Detalle_Facturas.Importe * (1 / TasaCambio.MontoTasa) AS Importe, TasaCambio.MontoTasa, Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " &
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND  (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Productos.Unidad_Medida,Detalle_Facturas.CodTarea FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad,Detalle_Facturas.Precio_Unitario * TasaCambio.MontoTasa AS Precio_Unitario, Detalle_Facturas.Descuento * TasaCambio.MontoTasa AS Descuento,Detalle_Facturas.Precio_Neto * TasaCambio.MontoTasa AS Precio_Neto, Detalle_Facturas.Importe * TasaCambio.MontoTasa AS Importe,TasaCambio.MontoTasa,Productos.Unidad_Medida, Detalle_Facturas.CodTarea FROM Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa " &
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,'" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')"

                End If
            End If



            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////SELECCIONO LA IMPRESORA CONFIGURADA PARA LAS FACTURAS /////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Dim pd As New PrintDocument
                Dim ImpresoraFactura As String
                Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

                Impresora_Defecto = s_Default_Printer
                ImpresoraFactura = BuscaImpresora("Factura")
                Establecer_Impresora(ImpresoraFactura)

                TipoImpresion = "Factura"


                SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then

                    Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")

                        Case "Papel en Blanco MediaPagina"

                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturaMediaPagina.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturaMediaPagina.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturaMediaPagina.DataSource = SQL
                            ArepFacturaMediaPagina.Document.Name = "Reporte de " & TipoImpresion

                            Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepFacturaMediaPagina.Document
                            ViewerForm.Show()

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepFacturaMediaPagina.Run(True)
                            Else
                                ArepFacturaMediaPagina.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If
                        Case "Papel en Blanco, Lotes"
                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturasTareas.DataSource = SQL
                        ArepFacturasTareas.Document.Name = "Reporte de " & TipoFactura

                        Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepFacturasTareas.Document
                            'ViewerForm.Show()

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepFacturasTareas.Run(True)
                            Else
                                ArepFacturasTareas.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If

                        Case "Papel en Blanco, Sin Encabezado"
                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturasTareas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturasTareas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturas2.DataSource = SQL
                            ArepFacturas2.Document.Name = "Reporte de " & TipoImpresion
                        ArepFacturas2.LblLetras.Text = Letras(CDbl(SubTotal) + CDbl(Iva), MonedaFactura)

                        Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepFacturas2.Document
                            ViewerForm.Show()

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepFacturas2.Run(True)
                            Else
                                ArepFacturas2.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If

                        Case "Tira de Papel"

                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturasTiras.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturasTiras.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

                                ArepOrdenTrabajo.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepOrdenTrabajo.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                        ArepFacturasTiras.TxtVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")
                        ArepOrdenTrabajo.TxtVendedor.Text = DataSet.Tables("Factura").Rows(0)("Nombre_Vendedor")

                        SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturasTiras.DataSource = SQL
                        ArepFacturasTiras.Document.Name = "Reporte de " & TipoFactura

                        ArepOrdenTrabajo.DataSource = SQL
                        ArepOrdenTrabajo.Document.Name = "Reporte de " & TipoFactura
                        If MonedaImprime = "Cordobas" Then
                                ArepFacturasTiras.Simbolo1.Text = "C$"
                                ArepFacturasTiras.Simbolo2.Text = "C$"
                                ArepFacturasTiras.Simbolo3.Text = "C$"
                                ArepFacturasTiras.Simbolo4.Text = "C$"
                                ArepFacturasTiras.Simbolo5.Text = "C$"

                                ArepOrdenTrabajo.Simbolo1.Text = "C$"
                                ArepOrdenTrabajo.Simbolo2.Text = "C$"
                                ArepOrdenTrabajo.Simbolo3.Text = "C$"
                                ArepOrdenTrabajo.Simbolo4.Text = "C$"
                                ArepOrdenTrabajo.Simbolo5.Text = "C$"
                            Else
                                ArepFacturasTiras.Simbolo1.Text = "$"
                                ArepFacturasTiras.Simbolo2.Text = "$"
                                ArepFacturasTiras.Simbolo3.Text = "$"
                                ArepFacturasTiras.Simbolo4.Text = "$"
                                ArepFacturasTiras.Simbolo5.Text = "$"

                                ArepOrdenTrabajo.Simbolo1.Text = "$"
                                ArepOrdenTrabajo.Simbolo2.Text = "$"
                                ArepOrdenTrabajo.Simbolo3.Text = "$"
                                ArepOrdenTrabajo.Simbolo4.Text = "$"
                                ArepOrdenTrabajo.Simbolo5.Text = "$"
                            End If


                        If DataSet.Tables("Factura").Rows(0)("Referencia") = "Orden de Trabajo" Then
                            Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepOrdenTrabajo.Document

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepOrdenTrabajo.Run(True)
                            Else
                                ArepOrdenTrabajo.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If


                        Else
                            Dim ViewerForm As New FrmViewer()
                                ViewerForm.arvMain.Document = ArepFacturasTiras.Document

                                'ViewerForm.Show()
                                'ArepFacturasTiras.Run(True)
                                If ImprimeFacturaPreview = True Then
                                    ViewerForm.Show()
                                    ArepFacturasTiras.Run(True)
                                Else
                                    ArepFacturasTiras.Run(True)
                                    ViewerForm.arvMain.Document.Print(False, False, False)
                                End If
                            End If



                                'ArepFacturas.Run(False)
                                'ArepFacturas.Show()
                        Case "Papel en Blanco"

                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturas.DataSource = SQL
                        ArepFacturas.Document.Name = "Reporte de " & TipoFactura

                        Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepFacturas.Document
                            ViewerForm.Show()

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepFacturas.Run(True)
                            Else
                                ArepFacturas.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If

                        Case "Personalizado"

                            SqlDatos = "SELECT * FROM DatosEmpresa"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                            DataAdapter.Fill(DataSet, "DatosEmpresa")
                            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                                ArepFacturas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                                ArepFacturas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                            End If

                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlDetalle
                            ArepFacturas.DataSource = SQL
                        ArepFacturas.Document.Name = "Reporte de " & TipoFactura

                        Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepFacturas.Document
                            ViewerForm.Show()

                            If ImprimeFacturaPreview = True Then
                                ViewerForm.Show()
                                ArepFacturas.Run(True)
                            Else
                                ArepFacturas.Run(True)
                                ViewerForm.arvMain.Document.Print(False, False, False)
                            End If

                            'TipoImpresion = Me.CboTipoProducto.Text


                            'Dim StrSQLUpdate As String
                            'Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios " 'WHERE (((Usuarios.TipoImpresion)='Factura'))
                            'RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                            'ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                            'Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                            'Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                            'Dim DatasetDatos As New DataSet


                            'MiConexionAccess.Open()
                            'DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                            'StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & Me.TxtNumeroEnsamble.Text & "' "
                            'ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                            'iResultado = ComandoUpdateAccess.ExecuteNonQuery
                            'MiConexionAccess.Close()

                            ''///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                            'EscribirArchivo()

                            'RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                            'If Dir(RutaReportes) <> "" Then
                            '    Shell(RutaReportes)
                            'End If

                    End Select
                End If

        End If


        Me.Button1.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdGuardar.Enabled = True


    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles CmdGuardar.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlCompras As String
        Dim NumeroFactura As String, TipoFactura As String, Fecha As String, Resultado As Integer

        Resultado = MsgBox("¿Esta Seguro de Poner como entregado la Factura?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = 7 Then
            Exit Sub
        End If

        NumeroFactura = Me.TrueDBGridConsultas.Columns("Numero_Factura").Text
        Fecha = Format(CDate(Me.TrueDBGridConsultas.Columns("Fecha_Factura").Text), "yyyy-MM-dd")
        TipoFactura = Me.TrueDBGridConsultas.Columns("Tipo_Factura").Text


        SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False', [Entregada] = 'True' " &
             "WHERE  (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        If Me.CmbConsultas.Text = "Pendiente" Then
            Cargar_Entrega(0)
        ElseIf Me.CmbConsultas.Text = "Entregado" Then
            Cargar_Entrega(1)
        End If
    End Sub
End Class