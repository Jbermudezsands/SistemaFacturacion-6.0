Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports GrapeCity.DD
Imports System.Text.RegularExpressions

Public Class FrmRecibos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public ConsecutivoReciboSerie As Boolean = False, Impresora_Defecto As String
    Private _MapaAplicacionesPlan As New Dictionary(Of AplicacionPlanPendiente, DataRow)


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
            End If
            Me.TrueDBGridComponentes.Enabled = True


            MiConexion.Close()
            SqlProveedor = "SELECT DISTINCT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito,DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado AS MontoPagado, Facturas.MontoCredito AS Saldo FROM  Facturas LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Facturas.Numero_Factura DESC"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Consultas")
            Me.BindingFacturas.DataSource = DataSet.Tables("Consultas")
            Me.TrueDBGridComponentes.DataSource = Me.BindingFacturas
        Else

            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TrueDBGridComponentes.Enabled = False

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TrueDBGridMetodo_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.AfterUpdate
        ActualizaMETODORecibos()
    End Sub

    Private Sub TrueDBGridMetodo_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridMetodo.BeforeUpdate
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TrueDBGridMetodo.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TrueDBGridMetodo.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridMetodo.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Cheque"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Text = ""
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.Label1.Text = "Numero Tarjeta"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Text = ""
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"
                My.Forms.FrmMetodosPagos.ShowDialog()
                If FrmMetodosPagos.Numero <> "" Then
                    Me.TrueDBGridMetodo.Columns(2).Text = FrmMetodosPagos.Numero
                End If
                If FrmMetodosPagos.Fecha <> "" Then
                    Me.TrueDBGridMetodo.Columns(3).Text = FrmMetodosPagos.Fecha
                End If
        End Select


        ActualizaMETODORecibos()
    End Sub

    Private Sub TrueDBGridMetodo_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridMetodo.ButtonClick
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TrueDBGridMetodo.Columns(0).Text = Metodo
    End Sub

    Private Sub TrueDBGridMetodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.Click

    End Sub

    Private Sub FrmRecibos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Seguridad.Bloqueo(Me, Acceso, "Recibo de Caja")
    End Sub
    Public Sub Bloquear_Botones(Bloquear As Boolean)
        If Bloquear = True Then
            Me.CmdNuevo.Enabled = False
            Me.Button2.Enabled = False
            Me.ButtonAgregar.Enabled = False
            Me.Button1.Enabled = False
            Me.TrueDBGridComponentes.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.GroupBox1.Enabled = False
            Me.TDBGridDetalle.Enabled = False
            Me.CmbSerie.Enabled = False
            Me.TxtMonedaFactura.Enabled = False
            Me.CboCajero.Enabled = False
            Me.ButtonBorrar.Enabled = False
            Me.OptRet1Porciento.Enabled = False
            Me.OptRet2Porciento.Enabled = False

        Else
            Me.CmdNuevo.Enabled = True
            Me.Button2.Enabled = True
            Me.ButtonAgregar.Enabled = True
            Me.Button1.Enabled = True
            Me.TrueDBGridComponentes.Enabled = True
            Me.GroupBox2.Enabled = True
            Me.GroupBox1.Enabled = True
            Me.TDBGridDetalle.Enabled = True
            Me.CboCajero.Enabled = True
            Me.ButtonBorrar.Enabled = True
            Me.OptRet1Porciento.Enabled = True
            Me.OptRet2Porciento.Enabled = True
        End If


    End Sub


    Private Sub FrmRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String
        MiConexion.Close()
        Me.DTPFecha.Value = Now

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()


        If UsuarioTipoSerie <> "" Then
            If UsuarioTipoSerie <> "Ninguna" Then
                Me.CmbSerie.Text = UsuarioTipoSerie
            End If
        End If



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura") = True Then
                    Me.OptRet1Porciento.Visible = False
                    Me.OptRet2Porciento.Visible = False
                    Me.OptRet1Porciento.Checked = False
                    Me.OptRet2Porciento.Checked = False
                Else
                    Me.OptRet1Porciento.Visible = True
                    Me.OptRet2Porciento.Visible = True
                End If

            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie") = True Then
                    Me.CmbSerie.Visible = True
                    Me.LblNumero.Location = New Point(307, 20)
                    ConsecutivoReciboSerie = True
                Else
                    Me.CmbSerie.Visible = False
                    Me.LblNumero.Location = New Point(356, 17)
                    ConsecutivoReciboSerie = False
                End If
            End If

        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS CAJEROS////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Cajero, Nombre_Cajero + ' ' + Apellido_Cajero AS Nombres FROM Cajeros"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        Me.CboCajero.DataSource = DataSet.Tables("Cajeros")
        If Not DataSet.Tables("Cajeros").Rows.Count = 0 Then
            Me.CboCajero.Text = DataSet.Tables("Cajeros").Rows(0)("Cod_Cajero")
        End If
        MiConexion.Close()

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS FORMA DE PAGO////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  NombrePago, Monto,NumeroTarjeta,FechaVence FROM Detalle_MetodoCompras WHERE (Numero_Compra = '-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Me.BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
        Me.TrueDBGridMetodo.DataSource = Me.BindingMetodo
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 110
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridMetodo.Columns(1).NumberFormat = "##,##0.00"
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

        SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo, Numero_Nota FROM DetalleRecibo WHERE (CodReciboPago = '-1') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleRecibo")
        Me.BindingDetalleRecibo.DataSource = ds.Tables("DetalleRecibo")
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleRecibo")
        'Me.BindingDetalleRecibo.DataSource = DataSet.Tables("DetalleRecibo")
        Me.TDBGridDetalle.DataSource = Me.BindingDetalleRecibo
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 213
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 100
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 75
        Me.TDBGridDetalle.Columns(3).NumberFormat = "##,##0.00"
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(11).Visible = False
        Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Numero_Nota").Visible = False

        MiConexion.Close()
    End Sub

    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate
        Dim Saldo As Double, MontoCredito As Double, MontoAplicado As Double

        If Me.TrueDBGridComponentes.Columns(2).Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns(2).Text)
        End If

        If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
            MontoAplicado = 0
        Else
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        End If


        Saldo = MontoCredito - MontoAplicado

        Me.TrueDBGridComponentes.Columns(4).Text = Format(Saldo, "##,##0.00")
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        ActualizaMETODORecibos()
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim MontoCredito As Double, MontoAplicado As Double

        If Me.TrueDBGridComponentes.Columns(2).Text = "" Then
            MontoCredito = 0
        Else
            MontoCredito = CDbl(Me.TrueDBGridComponentes.Columns(2).Text)
        End If

        If Me.TrueDBGridComponentes.Columns(3).Text = "" Then
            MontoAplicado = 0
        Else
            MontoAplicado = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
        End If

        If MontoCredito < MontoAplicado Then
            MsgBox("No se puede Pagar mas del Monto facturado", MsgBoxStyle.Critical, "Sistema Facturacion")
            Me.TrueDBGridComponentes.Columns(3).Text = 0
            MontoAplicado = 0
        End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaRecibo()
    End Sub


    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click

        If ds.Tables("DetalleRecibo").Rows.Count = 0 Then Exit Sub
        If Me.TxtCodigoClientes.Text.Trim() = "" Then Exit Sub

        Me.BindingDetalleRecibo.EndEdit()

        Dim servicio As New Recibos(Conexion)
        Dim config As ConfiguracionRecibos = servicio.LeerConfiguracion()

        '------------------------------------------------------------------
        ' ENCABEZADO
        '------------------------------------------------------------------
        Dim recibo As New ReciboCaja With {
            .Fecha = Me.DTPFecha.Value.Date,
            .CodCliente = Me.TxtCodigoClientes.Text.Trim(),
            .Cajero = Me.CboCajero.Text,
            .NombreCliente = Me.TxtNombres.Text,
            .Apellidos = Me.TxtApellidos.Text,
            .Direccion = Me.TxtDireccion.Text,
            .Telefono = Me.TxtTelefono.Text,
            .Moneda = Me.TxtMonedaFactura.Text.Trim(),
            .Observaciones = Me.TxtObservaciones.Text,
            .Descuento = CeldaDecimal(Me.TxtDescuento.Text),
            .RetencionAlcaldia1 = Me.OptRet1Porciento.Checked,
            .RetencionIR2 = Me.OptRet2Porciento.Checked,
            .Usuario = Me.CboCajero.Text}

        '------------------------------------------------------------------
        ' NÚMERO: nuevo (automático / manual, con o sin serie) o edición
        '------------------------------------------------------------------
        If Me.TxtNumeroEnsamble.Text = Recibos.SinNumero Then
            If ConsecutivoReciboSerie Then recibo.Serie = Me.CmbSerie.Text.Trim()

            If config.ConsecutivoManual Then
                FrmConsecutivos.LblTitulo.Text = "Consecutivos Recibos"
                FrmConsecutivos.LblTitulo2.Text = "RECIBO NO"
                Quien = "Recibo"
                FrmConsecutivos.ShowDialog()
                If FrmConsecutivos.TxtConsecutivo.Text = Recibos.SinNumero Then Exit Sub
                recibo.ConsecutivoManual = CDec(FrmConsecutivos.NumeroFactura)
            End If
        Else
            recibo.Numero = Me.TxtNumeroEnsamble.Text.Trim()
        End If

        '------------------------------------------------------------------
        ' DETALLE
        '------------------------------------------------------------------
        Dim lineaPorFila As New Dictionary(Of DataRow, ReciboLinea)

        For Each fila As DataRow In ds.Tables("DetalleRecibo").Rows
            If fila.RowState = DataRowState.Deleted Then Continue For

            Dim linea As New ReciboLinea With {
                .IdDetalleRecibo = CeldaDecimal(fila("idDetalleRecibo")),
                .NumeroFactura = Celda(fila("Numero_Factura"), "0"),
                .MontoPagado = CeldaDecimal(fila("MontoPagado")),
                .NombrePago = Celda(fila("NombrePago")),
                .Descripcion = Celda(fila("Descripcion")),
                .NumeroTarjeta = Celda(fila("NumeroTarjeta")),
                .MontoFactura = CeldaDecimal(fila("MontoFactura")),
                .AplicaFactura = CeldaDecimal(fila("AplicaFactura")),
                .SaldoFactura = CeldaDecimal(fila("SaldoFactura")),
                .NumeroNota = Celda(fila("Numero_Nota"))}

            If Not IsDBNull(fila("FechaVence")) Then linea.FechaVence = CDate(fila("FechaVence"))

            recibo.Lineas.Add(linea)
            lineaPorFila(fila) = linea
        Next

        '------------------------------------------------------------------
        ' APLICACIONES DEL PLAN DE PAGOS (se graban en la misma transacción)
        '------------------------------------------------------------------
        If _MapaAplicacionesPlan IsNot Nothing Then
            For Each par As KeyValuePair(Of AplicacionPlanPendiente, DataRow) In _MapaAplicacionesPlan
                If par.Key Is Nothing OrElse par.Value Is Nothing Then Continue For
                Dim linea As ReciboLinea = Nothing
                If lineaPorFila.TryGetValue(par.Value, linea) Then
                    linea.AplicacionesPlan.Add(New ReciboAplicacionPlan With {
                        .IdDetallePago = CInt(par.Key.IdDetallePago),
                        .NumeroCuota = CInt(par.Key.NumeroCuota),
                        .MontoAplicado = CDec(par.Key.MontoAplicado)})
                End If
            Next
        End If

        '------------------------------------------------------------------
        ' GRABAR (una sola transacción)
        '------------------------------------------------------------------
        Me.Cursor = Cursors.WaitCursor
        Dim resultado As ReciboResultado = servicio.Grabar(recibo)
        Me.Cursor = Cursors.Default

        If Not resultado.Exito Then
            MsgBox(resultado.Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Dim aviso As String = ""
        For Each r As ReciboRetencion In resultado.Retenciones
            aviso &= String.Format("Nota de crédito {0}: {1} factura {2} = {3:N2}", r.NumeroNota, r.DescripcionNota, r.NumeroFactura, r.Monto) & vbCrLf
        Next
        For Each a As String In resultado.Advertencias
            aviso &= a & vbCrLf
        Next
        If aviso <> "" Then MsgBox(aviso, MsgBoxStyle.Information, "Recibo " & resultado.Numero)

        Imprimir_Recibo(resultado.Numero, Me.TxtCodigoClientes.Text)
        LimpiaRecibo()

    End Sub

    Public Sub Imprimir_Recibo(NumeroRecibo As String, Cod_Cliente As String)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim MontoPagado As Double, MontoCredito As Double, Descuento As Double, NombrePago As String = ""
        Dim ArepPagoClientes As New ArepPagoClientes, RutaLogo As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SQlPagos As String, Descripcion As String = ""
        Dim SQlString As String, TipoImpresion As String, RutaBD As String, ArepRecibos2 As New ArepRecibo2
        Dim ConexionAccess As String, iResultado As Integer, ArepReciboTira As New ArepReciboTira, ArepReciboTira2 As New ArepReciboCajaTira
        Dim ComandoUpdate As New SqlClient.SqlCommand, ConsecutivoManual As Boolean = False
        Dim Saldo As Double = 0, Retencion1 As Double = 0, Retencion2 As Double = 0, NumeroNota As String = "", Consecutivo As Double = 0
        Dim ReciboSerie As Boolean = False, idDetalle As Double = -1
        Dim oDataRow As DataRow, i As Double




        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ArepPagoClientes.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepPagoClientes.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
            ArepReciboTira.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepReciboTira.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
            ArepRecibos2.LblTitulo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRecibos2.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            ArepReciboTira2.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepReciboTira2.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
            ArepReciboTira2.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepPagoClientes.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepReciboTira.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepReciboTira2.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepRecibos2.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepPagoClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepReciboTira.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepReciboTira2.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepRecibos2.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If

        End If


        Me.TxtNumeroEnsamble.Text = NumeroRecibo
        ArepPagoClientes.LblCodCliente.Text = Me.TxtCodigoClientes.Text
        ArepPagoClientes.LblNombreCliente.Text = Me.TxtNombres.Text
        ArepPagoClientes.LblApellidos.Text = Me.TxtApellidos.Text
        ArepPagoClientes.LblDireccionCliente.Text = Me.TxtDireccion.Text
        ArepPagoClientes.LblTelefonoCliente.Text = Me.TxtTelefono.Text
        ArepPagoClientes.LblOrden.Text = NumeroRecibo
        ArepPagoClientes.TxtObservaciones.Text = Me.TxtObservaciones.Text
        ArepPagoClientes.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")

        '----------------------------SEGUNDO FORMATO DE RECIBO -----------------------------------------------------
        ArepRecibos2.TxtNoRecibo.Text = NumeroRecibo
        ArepRecibos2.TxtFecha.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")
        ArepRecibos2.TxtRecibimosDe.Text = Me.TxtNombres.Text
        ArepRecibos2.TxtLaSumaDe.Text = Me.LblLetras.Text
        ArepRecibos2.TxtObservaciones.Text = Me.TxtObservaciones.Text
        ArepRecibos2.LblTitulo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")


        '----------------------------SEGUNDO FORMATO DE TIRA -----------------------------------------------------
        ArepReciboTira.LblNombres.Text = Me.TxtNombres.Text
        ArepReciboTira.LblDireccion.Text = Me.TxtDireccion.Text
        ArepReciboTira.LblTelefono.Text = Me.TxtTelefono.Text
        ArepReciboTira.LblOrden.Text = NumeroRecibo
        ArepReciboTira.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")

        '----------------------------SEGUNDO FORMATO DE TIRA 2-----------------------------------------------------
        ArepReciboTira2.LblNombres.Text = Me.TxtNombres.Text
        ArepReciboTira2.TxtDireccion.Text = Me.TxtDireccion.Text
        ArepReciboTira2.LblReciboNo.Text = "Recibo Oficial No: " & NumeroRecibo
        ArepReciboTira2.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")
        ArepReciboTira2.LblObservaciones.Text = Me.TxtObservaciones.Text

        SqlDatos = "SELECT  *  FROM DetalleRecibo WHERE (CodReciboPago = '" & NumeroRecibo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaConcepto")
        If DataSet.Tables("BuscaConcepto").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("BuscaConcepto").Rows(0)("Descripcion")) Then
                ArepRecibos2.TxtConcepto.Text = DataSet.Tables("BuscaConcepto").Rows(0)("Descripcion")
            End If

            If Not IsDBNull(DataSet.Tables("BuscaConcepto").Rows(0)("NombrePago")) Then
                If Not IsDBNull(DataSet.Tables("BuscaConcepto").Rows(0)("MontoPagado")) Then
                    ArepPagoClientes.TxtMetodo.Text = DataSet.Tables("BuscaConcepto").Rows(0)("NombrePago") & " $" & DataSet.Tables("BuscaConcepto").Rows(0)("MontoPagado")
                End If
            End If
        End If


        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////ESTA CONSULTA NUNCA TENDRA REGISTROS /////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlPagos = "SELECT DISTINCT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito+DetalleRecibo.MontoPagado as MontoCredito,DetalleRecibo.MontoPagado, Facturas.MontoCredito AS Saldo, DetalleRecibo.Descripcion, DetalleRecibo.NombrePago FROM Facturas LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " &
                   "WHERE (Facturas.Cod_Cliente = '-100000') AND (Facturas.Tipo_Factura = 'Factura') AND (DetalleRecibo.CodReciboPago = '" & NumeroRecibo & "') ORDER BY Facturas.Numero_Factura DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQlPagos, MiConexion)
        DataAdapter.Fill(DataSet, "ReciboPago")

        SQlString = "SELECT DISTINCT DetalleRecibo.MontoPagado, DetalleRecibo.Descripcion, DetalleRecibo.NombrePago, DetalleRecibo.Numero_Nota, DetalleRecibo.Numero_Factura, Recibo.Cod_Cliente FROM  DetalleRecibo INNER JOIN  Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo  " &
                    "WHERE (DetalleRecibo.CodReciboPago = '" & NumeroRecibo & "') AND (Recibo.Cod_Cliente = '" & Cod_Cliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        MiConexion.Close()

        Dim FechaFactura As Date, TipoFactura As String = "", NumeroFactura As String
        i = 0
        Do While DataSet.Tables("Recibos").Rows.Count > i

            NumeroFactura = DataSet.Tables("Recibos").Rows(i)("Numero_Factura")
            MontoPagado = DataSet.Tables("Recibos").Rows(i)("MontoPagado")

            ''''''''''''''''''''''''''''''''''''''''''''''VERIFICO SI ES FACTURA ///////////////////////////////////////////////////////////////
            If Mid(DataSet.Tables("Recibos").Rows(i)("Numero_Factura"), 1, 2) <> "NB" Then
                '//////////////////////////SI ES NB ES NOTA DE DEBITO /////////////////////////////////////
                SQlString = "SELECT DISTINCT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito+DetalleRecibo.MontoPagado as MontoCredito,DetalleRecibo.MontoPagado, Facturas.MontoCredito AS Saldo, DetalleRecibo.Descripcion, DetalleRecibo.NombrePago FROM Facturas LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " &
                                  "WHERE (Facturas.Cod_Cliente = '" & Cod_Cliente & "') AND (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Numero_Factura = '" & NumeroFactura & "') ORDER BY Facturas.Numero_Factura DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                MiConexion.Close()

                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    FechaFactura = DataSet.Tables("Consulta").Rows(0)("Fecha_Factura")
                    MontoCredito = DataSet.Tables("Consulta").Rows(0)("MontoCredito")
                    Saldo = DataSet.Tables("Consulta").Rows(0)("Saldo")
                    TipoFactura = "Factura"
                End If
            Else

                NumeroNota = Mid(DataSet.Tables("Recibos").Rows(i)("Numero_Factura"), 3, Len(DataSet.Tables("Recibos").Rows(i)("Numero_Factura")))

                SQlString = "SELECT  Detalle_Nota.Numero_Factura, Detalle_Nota.Fecha_Nota, Detalle_Nota.Monto, Detalle_Nota.Numero_Nota, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente,  IndiceNota.Nombre_Cliente, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Tipo_Nota, NotaDebito.Tipo FROM Detalle_Nota INNER JOIN  IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND  Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB " &
                            "WHERE (Detalle_Nota.Numero_Factura = N'0000') AND (IndiceNota.Cod_Cliente = '" & Cod_Cliente & "') AND (NotaDebito.Tipo = 'Debito Clientes') AND   (Detalle_Nota.Numero_Nota = '" & NumeroNota & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                MiConexion.Close()
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    FechaFactura = DataSet.Tables("Consulta").Rows(0)("Fecha_Nota")
                    MontoCredito = DataSet.Tables("Consulta").Rows(0)("Monto")
                    Saldo = DataSet.Tables("Consulta").Rows(0)("Monto") - DataSet.Tables("Recibos").Rows(i)("MontoPagado")
                    TipoFactura = "NotaDebito"
                End If

            End If

            DataSet.Tables("Consulta").Reset()



            oDataRow = DataSet.Tables("ReciboPago").NewRow
            oDataRow("Numero_Factura") = NumeroFactura
            oDataRow("Fecha_Factura") = FechaFactura
            oDataRow("MontoCredito") = Format(MontoCredito, "##,##0.00")
            oDataRow("MontoPagado") = MontoPagado
            oDataRow("Descripcion") = DataSet.Tables("Recibos").Rows(i)("Descripcion")
            oDataRow("NombrePago") = DataSet.Tables("Recibos").Rows(i)("NombrePago")
            oDataRow("Saldo") = Format(Saldo, "##,##0.00")
            'oDataRow("Tipo_Factura") = TipoFactura
            DataSet.Tables("ReciboPago").Rows.Add(oDataRow)

            i = i + 1
        Loop



        'SQL.ConnectionString = Conexion
        'SQL.SQL = SQlPagos
        ArepPagoClientes.Document.Name = "SOLICITUD DE PAGO CLIENTES"
        ArepReciboTira.Document.Name = "RECIBOS DE CAJA"

        If Me.TxtDescuento.Text = "" Then
            Descuento = 0
        Else
            Descuento = Me.TxtDescuento.Text
        End If


        '/////////////////////////////////////////////CONSULTO LOSDATOS DE LOS CLIENTES //////////////////////////////////////////////

        SQlString = "SELECT  Clientes.*  FROM Clientes WHERE  (Cod_Cliente = '" & Cod_Cliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("RUC")) Then
                ArepReciboTira2.TxtRuc.Text = DataSet.Tables("Clientes").Rows(0)("RUC")
            ElseIf Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Cedula")) Then
                ArepReciboTira2.TxtRuc.Text = DataSet.Tables("Clientes").Rows(0)("Cedula")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                ArepReciboTira2.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
            End If
        End If



        ArepPagoClientes.LblSubTotalRecibo.Text = Me.TxtSubTotal.Text
        ArepPagoClientes.LblDescuentoRecibo.Text = Format(Descuento, "##,##0.00")
        ArepPagoClientes.LblPagadoRecibo.Text = Me.TxtNetoPagar.Text
        ArepReciboTira.LblPagadoRecibo.Text = Me.TxtNetoPagar.Text
        ArepReciboTira.LblMontoTexto.Text = Me.LblLetras.Text
        ArepReciboTira.TxtVendedor.Text = Me.CboCajero.Columns(1).Text
        ArepRecibos2.TxtMonto.Text = Format(CDbl(Me.TxtNetoPagar.Text), "##,##0.00")

        ArepReciboTira2.LblPagadoRecibo.Text = Me.TxtNetoPagar.Text
        ArepReciboTira2.LblMontoTexto.Text = Me.LblLetras.Text
        ArepReciboTira2.TxtVendedor.Text = Me.CboCajero.Columns(1).Text


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        TipoImpresion = Me.TxtTipoRecibo.Text

        If Me.CmbSerie.Visible = True Then
            TipoImpresion = Me.TxtTipoRecibo.Text & Me.CmbSerie.Text
        Else
            TipoImpresion = Me.TxtTipoRecibo.Text
        End If


        Select Case Me.TxtTipoRecibo.Text
            Case "Recibos de Caja"

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////////SELECCIONO LA IMPRESORA CONFIGURADA PARA LOS RECIBOS /////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Dim pd As New PrintDocument
                Dim ImpresoraRecibo As String
                Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

                Impresora_Defecto = s_Default_Printer
                ImpresoraRecibo = BuscaImpresora("Recibo")
                Establecer_Impresora(ImpresoraRecibo)


                'TipoImpresion = Me.TxtTipoRecibo.Text
                SQlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                        Case "Tiras de Papel2"
                            'SQL.ConnectionString = Conexion
                            'SQL.SQL = SQlPagos

                            ArepReciboTira2.DataSource = DataSet.Tables("ReciboPago")
                            Dim ViewerForm As New FrmViewer()

                            ViewerForm.arvMain.Document = ArepReciboTira2.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepReciboTira2.Run(False)

                            'Establecer_Impresora(Impresora_Defecto)

                        Case "Tira de Papel"
                            'SQL.ConnectionString = Conexion
                            'SQL.SQL = SQlPagos
                            ArepReciboTira.DataSource = DataSet.Tables("ReciboPago")
                            Dim ViewerForm As New FrmViewer()

                            ViewerForm.arvMain.Document = ArepReciboTira.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepReciboTira.Run(False)

                            'Establecer_Impresora(Impresora_Defecto)
                        Case "Papel en Blanco"
                            'SQL.ConnectionString = Conexion
                            'SQL.SQL = SQlPagos
                            ArepPagoClientes.DataSource = DataSet.Tables("ReciboPago")

                            Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepPagoClientes.Document
                            ViewerForm.Show()
                            ArepPagoClientes.Run(False)

                            'Establecer_Impresora(Impresora_Defecto)

                        Case "Papel en Blanco Standard"
                            'SQL.ConnectionString = Conexion
                            'SQL.SQL = SQlPagos
                            ArepPagoClientes.DataSource = DataSet.Tables("ReciboPago")

                            Dim ViewerForm As New FrmViewer()
                            'ViewerForm.arvMain.Document = ArepPagoClientes.Document
                            ViewerForm.arvMain.Document = ArepRecibos2.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepRecibos2.Run(False)

                            'Establecer_Impresora(Impresora_Defecto)

                        Case "Personalizado"

                            Dim StrSQLUpdate As String
                            Dim RutaReportes As String, StrSQLAccess As String = "SELECT * FROM Usuarios"  'WHERE (((Usuarios.TipoImpresion)='Recibos de Caja'))"
                            RutaBD = My.Application.Info.DirectoryPath & "\TrueDbGridFr.dll"
                            ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

                            Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess), ComandoUpdateAccess As New OleDb.OleDbCommand
                            Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
                            Dim DatasetDatos As New DataSet


                            MiConexionAccess.Open()
                            DataAdapterAccess.Fill(DatasetDatos, "Usuarios")


                            StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & Me.TxtTipoRecibo.Text & "',[NumeroImpresion] = '" & NumeroRecibo & "',[Usuario] = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "' "
                            ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                            iResultado = ComandoUpdateAccess.ExecuteNonQuery
                            MiConexionAccess.Close()

                            'RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                            'If Dir(RutaReportes) <> "" Then
                            '    Shell(RutaReportes)
                            'End If

                            '///////////////////////////CON ESTE ARCHIVO SE CAMBIA LA CONEXION PARA IMPRIMIR /////////////////////////
                            EscribirArchivo()

                            RutaReportes = My.Application.Info.DirectoryPath & "\Imprime.exe"
                            If Dir(RutaReportes) <> "" Then
                                Shell(RutaReportes)
                            End If



                    End Select
                End If
        End Select

    End Sub



    Private Sub TrueDBGridMetodo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridMetodo.DoubleClick
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TrueDBGridMetodo.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TrueDBGridMetodo.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TrueDBGridMetodo.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If Me.TrueDBGridMetodo.Columns(2).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TrueDBGridMetodo.Columns(2).Text
                End If
                If Me.TrueDBGridMetodo.Columns(3).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TrueDBGridMetodo.Columns(3).Text
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"

                If Me.TrueDBGridMetodo.Columns(2).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TrueDBGridMetodo.Columns(2).Text
                End If
                If Me.TrueDBGridMetodo.Columns(3).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TrueDBGridMetodo.Columns(3).Text
                End If
                My.Forms.FrmMetodosPagos.ShowDialog()
        End Select


        ActualizaMETODORecibos()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Recibos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
            Me.CmbSerie.Enabled = False
        End If
    End Sub

    Private Sub TDBGridDetalle_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDBGridDetalle.AfterUpdate
        ActualizaMETODORecibos()
    End Sub

    Private Sub TDBGridDetalle_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDBGridDetalle.BeforeColUpdate
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim NumeroFactura As String, CodigoCliente As String

        '////////////////////////////////////////////////////////////BUSCO EL NUMERO DE FACTURA SI EXISTE ////////////////////////////////

        NumeroFactura = Me.TDBGridDetalle.Columns(2).Text
        CodigoCliente = Me.TxtCodigoClientes.Text

        If e.ColIndex = 2 Then
            SqlString = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & CodigoCliente & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count = 0 Then
                If NumeroFactura <> "00000" Then
                    MsgBox("El numero de Factura No existe!!!", MsgBoxStyle.Critical, "Zeus Facturacion")
                    'Me.TDBGridDetalle.Columns(2).Text = "00000"
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If






    End Sub

    Private Sub TDBGridDetalle_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDBGridDetalle.BeforeUpdate
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If


        If Me.TDBGridDetalle.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TDBGridDetalle.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TDBGridDetalle.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If Me.TDBGridDetalle.Columns(4).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TDBGridDetalle.Columns(4).Text
                End If
                If Me.TDBGridDetalle.Columns(5).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TDBGridDetalle.Columns(5).Text
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"

                If Me.TDBGridDetalle.Columns(4).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TDBGridDetalle.Columns(4).Text
                End If
                If Me.TDBGridDetalle.Columns(5).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TDBGridDetalle.Columns(5).Text
                End If
                My.Forms.FrmMetodosPagos.ShowDialog()
        End Select


        ActualizaMETODORecibos()
    End Sub


    Private Sub TDBGridDetalle_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDBGridDetalle.ButtonClick
        'Dim Metodo As String
        'Quien = "MetodoPago"
        'My.Forms.FrmConsultas.ShowDialog()
        'Metodo = FrmConsultas.Codigo
        'Me.TDBGridDetalle.Columns(0).Text = Metodo

        SeleccionarMetodoPago()
    End Sub

    Private Sub C1TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridDetalle.Click

    End Sub

    Private Sub TDBGridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDBGridDetalle.DoubleClick
        Dim MetodoPago As String, SqlMetodo As String, MetodoConsulta As String, TipoPago As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlMetodo = "SELECT * FROM MetodoPago "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            MetodoConsulta = DataSet.Tables("Consulta").Rows(0)("NombrePago")
            TipoPago = DataSet.Tables("Consulta").Rows(0)("TipoPago")
        Else
            MsgBox("No existen Metodos de Pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If


        If Me.TDBGridDetalle.Columns(0).Text = "" Then
            Exit Sub
        Else
            MetodoPago = Me.TDBGridDetalle.Columns(0).Text
            SqlMetodo = "SELECT * FROM MetodoPago WHERE (NombrePago = '" & MetodoPago & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
            DataAdapter.Fill(DataSet, "Metodo")
            If DataSet.Tables("Metodo").Rows.Count = 0 Then
                MsgBox("Metodo de Pago no Existe,", MsgBoxStyle.Critical, "Sistema Facturacion")
                Me.TDBGridDetalle.Columns(0).Text = MetodoConsulta
            Else
                TipoPago = DataSet.Tables("Metodo").Rows(0)("TipoPago")
            End If
        End If



        Select Case TipoPago
            Case "Cheques"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
                My.Forms.FrmMetodosPagos.ShowDialog()
                If Me.TDBGridDetalle.Columns(4).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TDBGridDetalle.Columns(4).Text
                End If
                If Me.TDBGridDetalle.Columns(5).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TDBGridDetalle.Columns(5).Text
                End If

            Case "Tarjetas"
                My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"

                If Me.TDBGridDetalle.Columns(4).Text <> "" Then
                    FrmMetodosPagos.TxtNumeroTarjeta.Text = Me.TDBGridDetalle.Columns(4).Text
                End If
                If Me.TDBGridDetalle.Columns(5).Text <> "" Then
                    FrmMetodosPagos.Fecha = Me.TDBGridDetalle.Columns(5).Text
                End If
                My.Forms.FrmMetodosPagos.ShowDialog()
        End Select


        ActualizaMETODORecibos()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.TxtCodigoClientes.Text <> "" Then
            Me.Button2.Enabled = False
            FrmRecibosFacturas.CodigoClientes = Me.TxtCodigoClientes.Text
            FrmRecibosFacturas.ShowDialog()
            Me.Button2.Enabled = True
        Else
            MsgBox("Es necesario Seleccionar un Cliente", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtNetoPagar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNetoPagar.TextChanged
        Dim NetoPagar As Double
        NetoPagar = Me.TxtNetoPagar.Text
        Me.LblLetras.Text = Letras(NetoPagar, Me.TxtMonedaFactura.Text)
    End Sub

    Private Sub TxtSubTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSubTotal.TextChanged

    End Sub
    Public Sub Cargar_Recibos(Numero_Recibo As String, FechaRecibo As Date)
        Dim SqlCompras As String, SqlString As String, Fecha As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Numero_Recibo <> "-----0-----" Then
            Fecha = Format(FechaRecibo, "yyyy-MM-dd")
            SqlCompras = "SELECT Recibo.* FROM Recibo WHERE (CodReciboPago = '" & Numero_Recibo & "') AND (Fecha_Recibo = CONVERT(DATETIME, '" & Fecha & "', 102))"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            If Not DataSet.Tables("Recibos").Rows.Count = 0 Then
                Me.TxtCodigoClientes.Text = DataSet.Tables("Recibos").Rows(0)("Cod_Cliente")
                Me.TxtNombres.Text = DataSet.Tables("Recibos").Rows(0)("NombreCliente")
                Me.TxtApellidos.Text = DataSet.Tables("Recibos").Rows(0)("ApellidosCliente")
                Me.TxtDireccion.Text = DataSet.Tables("Recibos").Rows(0)("DireccionCliente")
                Me.TxtTelefono.Text = DataSet.Tables("Recibos").Rows(0)("TelefonoCliente")
                Me.TxtMonedaFactura.Text = DataSet.Tables("Recibos").Rows(0)("MonedaRecibo")
                Me.TxtSubTotal.Text = Format(DataSet.Tables("Recibos").Rows(0)("Sub_Total"), "##,##0.00")
                Me.TxtDescuento.Text = Format(DataSet.Tables("Recibos").Rows(0)("Descuento"), "##,##0.00")
                Me.TxtNetoPagar.Text = Format(DataSet.Tables("Recibos").Rows(0)("Total"), "##,##0.00")

                If ConsecutivoReciboSerie = True Then
                    Me.CmbSerie.Text = Mid(Me.TxtNumeroEnsamble.Text, 1, 1)
                End If



                SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo, Numero_Nota FROM DetalleRecibo WHERE (CodReciboPago = '" & Numero_Recibo & "') "
                'SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo FROM DetalleRecibo WHERE (CodReciboPago = '-1') AND (Fecha_Recibo = CONVERT(DATETIME, '2010-01-01 00:00:00', 102))"
                ds = New DataSet
                da = New SqlDataAdapter(SqlString, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleRecibo")
                Me.BindingDetalleRecibo.DataSource = ds.Tables("DetalleRecibo")
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleRecibo")
                'Me.BindingDetalleRecibo.DataSource = DataSet.Tables("DetalleRecibo")
                'Me.TDBGridDetalle.DataSource = Me.BindingDetalleRecibo
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Button = True
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 213
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 100
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 75
                Me.TDBGridDetalle.Columns(3).NumberFormat = "##,##0.00"
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Visible = False
                Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(11).Visible = False

            End If
        End If
    End Sub
    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Cargar_Recibos(TxtNumeroEnsamble.Text, DTPFecha.Value)
    End Sub

    Private Sub TxtNombres_TextChanged(sender As Object, e As EventArgs) Handles TxtNombres.TextChanged

    End Sub

    Private Sub LblNumero_Click(sender As Object, e As EventArgs) Handles LblNumero.Click

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnPlanPagos_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs
) Handles BtnPlanPagos.Click

        Dim Datos As New DatosReciboPlanPago()

        Datos.CodigoCliente = Me.TxtCodigoClientes.Text
        Datos.CodReciboPago = Me.TxtNumeroEnsamble.Text
        Datos.FechaRecibo = Me.DTPFecha.Value
        Datos.MonedaRecibo = Me.TxtMonedaFactura.Text

        Dim Frm As New FrmPlanPagoRecibos()

        Frm.DatosRecibo = Datos

        If Frm.ShowDialog() = DialogResult.OK Then

            '======================================================
            ' RECIBIR LAS APLICACIONES PREPARADAS
            '======================================================
            Dim Aplicaciones As List(Of AplicacionPlanPendiente) =
            Frm.AplicacionesPendientes

            '======================================================
            ' VALIDAR QUE HAYA APLICACIONES
            '======================================================
            If Aplicaciones Is Nothing OrElse
           Aplicaciones.Count = 0 Then

                MessageBox.Show(
                "No se recibieron aplicaciones del plan de pagos.",
                "Recibo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If

            '======================================================
            ' ACTUALIZAR TOTALES DEL RECIBO
            '======================================================
            Me.TxtSubTotal.Text = Frm.TxtImporteRecibido.Text
            Me.TxtDescuento.Text = "0.00"
            Me.TxtNetoPagar.Text = Frm.TxtImporteRecibido.Text

            '======================================================
            ' AGREGAR LAS APLICACIONES AL DETALLE DEL RECIBO
            '======================================================
            AgregarAplicacionesPlanPago(Aplicaciones)

            '======================================================
            ' DEPURACION
            '======================================================
            For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                Debug.WriteLine(
                "Factura: " & Aplicacion.NumeroFactura &
                " | Cuota: " & Aplicacion.NumeroCuota &
                " | Monto: " & Aplicacion.MontoAplicado.ToString("N2"))

            Next

        End If

    End Sub


    Private Sub ButtonBorrar_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles ButtonBorrar.Click

        Dim Servicio As New ServicioRecibos(Conexion)

        Dim NumeroRecibo As String = Me.TxtNumeroEnsamble.Text.Trim()
        Dim FechaRecibo As Date = Me.DTPFecha.Value.Date
        Dim CodigoCliente As String = Me.TxtCodigoClientes.Text.Trim()

        '==========================================================
        ' VALIDACIONES BASICAS
        '==========================================================

        If NumeroRecibo = "" OrElse NumeroRecibo = "-----0-----" Then
            MsgBox(
            "No existe un número de recibo para anular.",
            MsgBoxStyle.Exclamation,
            "Sistema Facturación")

            Exit Sub
        End If

        If CodigoCliente = "" Then
            MsgBox(
            "No se encontró el código del cliente.",
            MsgBoxStyle.Exclamation,
            "Sistema Facturación")

            Exit Sub
        End If

        '==========================================================
        ' CONFIRMAR ANULACION
        '==========================================================

        If MsgBox(
        "¿Está seguro que desea anular el recibo " &
        NumeroRecibo & "?",
        MsgBoxStyle.YesNo Or MsgBoxStyle.Question,
        "Anular Recibo") <> MsgBoxResult.Yes Then

            Exit Sub

        End If

        '==========================================================
        ' ANULAR RECIBO
        '
        ' El servicio se encarga de:
        '
        ' 1. Validar que el recibo exista y esté activo.
        ' 2. Anular Recibo.
        ' 3. Poner MontoPagado = 0 en DetalleRecibo.
        ' 4. Anular las aplicaciones activas de Plan Pago.
        ' 5. Registrar fecha, usuario y motivo de anulación.
        ' 6. Ejecutar todo dentro de una transacción.
        '==========================================================

        Dim Usuario As String = Environment.UserName

        Dim Motivo As String =
        "Anulación de recibo desde FrmRecibos"

        If Not Servicio.AnularRecibo(
        NumeroRecibo,
        FechaRecibo,
        CodigoCliente,
        Usuario,
        Motivo) Then

            MsgBox(
            "No fue posible anular el recibo." &
            vbCrLf &
            "Verifique que el recibo exista, esté activo " &
            "y que la fecha corresponda al recibo.",
            MsgBoxStyle.Critical,
            "Sistema Facturación")

            Exit Sub

        End If

        '==========================================================
        ' LIMPIAR FORMULARIO
        '==========================================================

        LimpiaRecibo()

        MsgBox(
        "El recibo " & NumeroRecibo &
        " fue anulado correctamente.",
        MsgBoxStyle.Information,
        "Sistema Facturación")

    End Sub



    '*********************CODIGO RETIRADO 15/09/2026 ***********************************
    'Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
    '    Dim SQlString As String
    '    Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
    '    Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SQLPagos As String

    '    '///////////////////////////////////////////BUSCO SI LA FACTURA QUEDA EN CERO PARA DESACTIVARLAS /////////////////////
    '    SQlString = "SELECT  Recibo.*  FROM Recibo WHERE (Activo = 1) AND (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
    '    DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
    '    DataAdapter.Fill(DataSet, "Recibo")
    '    If DataSet.Tables("Recibo").Rows.Count <> 0 Then
    '        MiConexion.Close()

    '        SQLPagos = "UPDATE Recibo SET [Contabilizado] = 'True', [Activo] = 'False'   , [NombreCliente] = '******CANCELADO' ,[ApellidosCliente] = '******'  WHERE (Activo = 1) AND (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
    '        MiConexion.Open()
    '        ComandoUpdate = New SqlClient.SqlCommand(SQLPagos, MiConexion)
    '        iResultado = ComandoUpdate.ExecuteNonQuery
    '        MiConexion.Close()

    '        SQLPagos = "UPDATE [DetalleRecibo] SET [MontoPagado] = 0 WHERE (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') "
    '        MiConexion.Open()
    '        ComandoUpdate = New SqlClient.SqlCommand(SQLPagos, MiConexion)
    '        iResultado = ComandoUpdate.ExecuteNonQuery
    '        MiConexion.Close()
    '    End If

    '    LimpiaRecibo()

    'End Sub

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint

    End Sub

    Private Sub AgregarAplicacionesPlanPago(
        ByVal Aplicaciones As List(Of AplicacionPlanPendiente))

        If Aplicaciones Is Nothing Then Exit Sub

        If Aplicaciones.Count = 0 Then Exit Sub

        If Me.ds Is Nothing Then Exit Sub

        If Not Me.ds.Tables.Contains("DetalleRecibo") Then Exit Sub


        Dim Tabla As DataTable =
    Me.ds.Tables("DetalleRecibo")


        '==========================================================
        ' ELIMINAR APLICACIONES DE PLAN DE PAGOS ANTERIORES
        '
        ' Si el usuario vuelve a abrir Plan Pagos antes de guardar
        ' el recibo, reemplazamos las aplicaciones anteriores.
        '
        ' NO tocamos otros detalles del recibo.
        '==========================================================
        If _MapaAplicacionesPlan IsNot Nothing AndAlso
   _MapaAplicacionesPlan.Count > 0 Then

            Dim FilasAnteriores As New List(Of DataRow)

            For Each Fila As DataRow In
        _MapaAplicacionesPlan.Values

                If Fila IsNot Nothing Then
                    FilasAnteriores.Add(Fila)
                End If

            Next


            For Each Fila As DataRow In FilasAnteriores

                If Fila.RowState <> DataRowState.Detached Then
                    Fila.Delete()
                End If

            Next

        End If


        '==========================================================
        ' LIMPIAR EL MAPA
        '==========================================================
        _MapaAplicacionesPlan.Clear()


        '==========================================================
        ' AGREGAR CADA APLICACION COMO UNA FILA DE DETALLE
        '==========================================================
        For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

            If Aplicacion Is Nothing Then Continue For

            If Aplicacion.MontoAplicado <= 0D Then Continue For


            '------------------------------------------------------
            ' CREAR NUEVA FILA
            '------------------------------------------------------
            Dim Fila As DataRow =
                Tabla.NewRow()


            '======================================================
            ' METODO DE PAGO
            '======================================================
            Fila("NombrePago") =
                Aplicacion.NombrePago


            '======================================================
            ' FACTURA
            '======================================================
            Fila("Numero_Factura") =
                Aplicacion.NumeroFactura


            '======================================================
            ' MONTO PAGADO
            '======================================================
            Fila("MontoPagado") =
                Convert.ToDouble(Aplicacion.MontoAplicado)


            '======================================================
            ' DESCRIPCION
            '======================================================
            Fila("Descripcion") =
                "PAGO PLAN CUOTA " &
                Aplicacion.NumeroCuota.ToString()


            '======================================================
            ' DATOS DE LA FACTURA
            '======================================================
            Fila("MontoFactura") =
                Convert.ToDouble(Aplicacion.MontoAplicado)

            Fila("AplicaFactura") =
                Convert.ToDouble(Aplicacion.MontoAplicado)

            Fila("SaldoFactura") =
                0D


            '======================================================
            ' NUMERO DE TARJETA
            '======================================================
            If String.IsNullOrEmpty(
                Aplicacion.NumeroTarjeta) Then

                Fila("NumeroTarjeta") =
                    DBNull.Value

            Else

                Fila("NumeroTarjeta") =
                    Aplicacion.NumeroTarjeta

            End If


            '======================================================
            ' FECHA DE VENCIMIENTO DE TARJETA
            '======================================================
            If Aplicacion.FechaVence <> Date.MinValue Then

                Fila("FechaVence") =
                    Aplicacion.FechaVence

            Else

                Fila("FechaVence") =
                    DBNull.Value

            End If


            '======================================================
            ' DATOS DEL RECIBO
            '
            ' Todavía utilizamos los valores actuales del formulario.
            ' ButtonAgregar_Click posteriormente asignará el
            ' NumeroRecibo definitivo.
            '======================================================
            Fila("CodReciboPago") =
                Me.TxtNumeroEnsamble.Text

            Fila("Fecha_Recibo") =
                Me.DTPFecha.Value



            '======================================================
            ' AGREGAR FILA AL DATATABLE
            '======================================================
            Tabla.Rows.Add(Fila)


            '======================================================
            ' GUARDAR LA RELACION:
            '
            ' AplicacionPlanPendiente
            '             ↓
            '          DataRow
            '
            ' IMPORTANTE:
            ' No buscamos posteriormente por factura/monto.
            ' Conservamos la referencia exacta al DataRow.
            '======================================================
            _MapaAplicacionesPlan.Add(
                Aplicacion,
                Fila)

        Next

    End Sub

    Private Function GrabarAplicacionesPlanPago(
    ByVal NumeroRecibo As String) As Boolean

        '==========================================================
        ' SI NO HAY APLICACIONES DE PLAN, NO HACER NADA
        '==========================================================
        If _MapaAplicacionesPlan Is Nothing Then
            Return True
        End If

        If _MapaAplicacionesPlan.Count = 0 Then
            Return True
        End If


        '==========================================================
        ' IDS DE DETALLE RECIBO YA UTILIZADOS
        '==========================================================
        Dim IdsUtilizados As New List(Of Decimal)


        Using CN As New SqlClient.SqlConnection(Conexion)

            CN.Open()


            '======================================================
            ' INSERTAR APLICACION
            '
            ' Utilizamos solamente las columnas que realmente
            ' existen en AplicacionPagoPlan.
            '======================================================
            Dim SQL As String = ""

            SQL &= "INSERT INTO AplicacionPagoPlan "
            SQL &= "("
            SQL &= "idDetallePago, "
            SQL &= "idDetalleRecibo, "
            SQL &= "MontoAplicado, "
            SQL &= "FechaAplicacion, "
            SQL &= "UsuarioAplicacion, "
            SQL &= "Anulado, "
            SQL &= "FechaRegistro, "
            SQL &= "CodReciboPago, "
            SQL &= "Fecha_Recibo, "
            SQL &= "Numero_Factura"
            SQL &= ") "
            SQL &= "VALUES "
            SQL &= "("
            SQL &= "@idDetallePago, "
            SQL &= "@idDetalleRecibo, "
            SQL &= "@MontoAplicado, "
            SQL &= "SYSDATETIME(), "
            SQL &= "@UsuarioAplicacion, "
            SQL &= "0, "
            SQL &= "SYSDATETIME(), "
            SQL &= "@CodReciboPago, "
            SQL &= "@Fecha_Recibo, "
            SQL &= "@Numero_Factura"
            SQL &= ")"


            Using CMD As New SqlClient.SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@idDetallePago",
                SqlDbType.Int)


                Dim ParamIdDetalleRecibo As SqlClient.SqlParameter =
                CMD.Parameters.Add(
                    "@idDetalleRecibo",
                    SqlDbType.Decimal)

                ParamIdDetalleRecibo.Precision = 18
                ParamIdDetalleRecibo.Scale = 0


                Dim ParamMonto As SqlClient.SqlParameter =
                CMD.Parameters.Add(
                    "@MontoAplicado",
                    SqlDbType.Decimal)

                ParamMonto.Precision = 18
                ParamMonto.Scale = 2


                CMD.Parameters.Add(
                "@UsuarioAplicacion",
                SqlDbType.NVarChar,
                100)

                CMD.Parameters.Add(
                "@CodReciboPago",
                SqlDbType.NVarChar,
                50)

                CMD.Parameters.Add(
                "@Fecha_Recibo",
                SqlDbType.SmallDateTime)

                CMD.Parameters.Add(
                "@Numero_Factura",
                SqlDbType.NVarChar,
                50)


                '==================================================
                ' RECORRER APLICACIONES
                '==================================================
                For Each Par As KeyValuePair(
                Of AplicacionPlanPendiente, DataRow) _
                In _MapaAplicacionesPlan


                    Dim Aplicacion As AplicacionPlanPendiente =
                    Par.Key

                    Dim Fila As DataRow =
                    Par.Value


                    If Aplicacion Is Nothing Then
                        Continue For
                    End If

                    If Fila Is Nothing Then
                        Continue For
                    End If


                    '==================================================
                    ' OBTENER ID DETALLE RECIBO
                    '==================================================
                    Dim IdDetalleRecibo As Decimal = 0D


                    '--------------------------------------------------
                    ' PRIMERO REVISAR SI EL DATAROW YA LO TIENE
                    '--------------------------------------------------
                    If Not IsDBNull(
                    Fila("idDetalleRecibo")) Then

                        IdDetalleRecibo =
                        Convert.ToDecimal(
                            Fila("idDetalleRecibo"))

                    End If


                    '==================================================
                    ' SI NO LO TIENE, BUSCARLO EN SQL SERVER
                    '==================================================
                    If IdDetalleRecibo <= 0D Then

                        Dim NumeroFactura As String = ""

                        If Not IsDBNull(
                        Fila("Numero_Factura")) Then

                            NumeroFactura =
                            Convert.ToString(
                                Fila("Numero_Factura"))

                        End If


                        Dim NombrePago As String = ""

                        If Not IsDBNull(
                        Fila("NombrePago")) Then

                            NombrePago =
                            Convert.ToString(
                                Fila("NombrePago"))

                        End If


                        Dim Descripcion As String = ""

                        If Not IsDBNull(
                        Fila("Descripcion")) Then

                            Descripcion =
                            Convert.ToString(
                                Fila("Descripcion"))

                        End If


                        Dim MontoPagado As Decimal = 0D

                        If Not IsDBNull(
                        Fila("MontoPagado")) Then

                            MontoPagado =
                            Convert.ToDecimal(
                                Fila("MontoPagado"))

                        End If


                        IdDetalleRecibo =
                        ObtenerIdDetalleRecibo(
                            NumeroRecibo,
                            NumeroFactura,
                            NombrePago,
                            Descripcion,
                            MontoPagado,
                            IdsUtilizados)

                    End If


                    '==================================================
                    ' VALIDAR ID
                    '==================================================
                    If IdDetalleRecibo <= 0D Then

                        MessageBox.Show(
                        "No se pudo obtener el idDetalleRecibo " &
                        "para la cuota " &
                        Aplicacion.NumeroCuota.ToString() &
                        " de la factura " &
                        Aplicacion.NumeroFactura &
                        "." &
                        vbCrLf & vbCrLf &
                        "No se grabará la aplicación del plan de pagos.",
                        "Recibo de plan de pagos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                        Return False

                    End If


                    '==================================================
                    ' GUARDAR ID EN EL DATAROW
                    '==================================================
                    If IsDBNull(
                    Fila("idDetalleRecibo")) Then

                        Fila("idDetalleRecibo") =
                        IdDetalleRecibo

                    End If


                    '==================================================
                    ' EVITAR UTILIZAR EL MISMO DETALLE DOS VECES
                    '==================================================
                    If Not IdsUtilizados.Contains(
                    IdDetalleRecibo) Then

                        IdsUtilizados.Add(
                        IdDetalleRecibo)

                    End If


                    '==================================================
                    ' ASIGNAR PARAMETROS
                    '==================================================
                    CMD.Parameters(
                    "@idDetallePago").Value =
                    Aplicacion.IdDetallePago


                    CMD.Parameters(
                    "@idDetalleRecibo").Value =
                    IdDetalleRecibo


                    CMD.Parameters(
                    "@MontoAplicado").Value =
                    Aplicacion.MontoAplicado


                    '--------------------------------------------------
                    ' Por ahora dejamos el usuario en NULL.
                    ' Posteriormente podemos utilizar el cajero/usuario
                    ' actual del sistema.
                    '--------------------------------------------------
                    CMD.Parameters(
                    "@UsuarioAplicacion").Value =
                    DBNull.Value

                    CMD.Parameters(
    "@CodReciboPago").Value =
    NumeroRecibo

                    If Not IsDBNull(Fila("Fecha_Recibo")) Then

                        CMD.Parameters(
        "@Fecha_Recibo").Value =
        Convert.ToDateTime(
            Fila("Fecha_Recibo"))

                    Else

                        MessageBox.Show(
        "No se encontró la fecha del recibo " &
        "para la cuota " &
        Aplicacion.NumeroCuota.ToString() &
        " de la factura " &
        Aplicacion.NumeroFactura & ".",
        "Recibo de plan de pagos",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning)

                        Return False

                    End If

                    CMD.Parameters(
    "@Numero_Factura").Value =
    Aplicacion.NumeroFactura


                    '==================================================
                    ' INSERTAR
                    '==================================================
                    CMD.ExecuteNonQuery()

                Next

            End Using

        End Using


        Return True

    End Function

    Private Function ObtenerIdDetalleRecibo(
        ByVal NumeroRecibo As String,
        ByVal NumeroFactura As String,
        ByVal NombrePago As String,
        ByVal Descripcion As String,
        ByVal MontoPagado As Decimal,
        ByVal IdsUtilizados As List(Of Decimal)
    ) As Decimal

        Dim IdDetalleRecibo As Decimal = 0D

        Dim SQL As String = ""

        SQL &= "SELECT TOP 1 idDetalleRecibo "
        SQL &= "FROM DetalleRecibo "
        SQL &= "WHERE CodReciboPago = @CodReciboPago "
        SQL &= "AND Numero_Factura = @Numero_Factura "
        SQL &= "AND NombrePago = @NombrePago "
        SQL &= "AND Descripcion = @Descripcion "
        SQL &= "AND MontoPagado = @MontoPagado "

        '==========================================================
        ' EVITAR UTILIZAR DOS VECES EL MISMO DETALLE
        '==========================================================
        If IdsUtilizados IsNot Nothing AndAlso
           IdsUtilizados.Count > 0 Then

            SQL &= "AND idDetalleRecibo NOT IN ("

            For i As Integer = 0 To IdsUtilizados.Count - 1

                If i > 0 Then
                    SQL &= ","
                End If

                SQL &= IdsUtilizados(i).ToString(
                    System.Globalization.CultureInfo.InvariantCulture)

            Next

            SQL &= ") "

        End If

        SQL &= "ORDER BY idDetalleRecibo DESC"


        Using CN As New SqlClient.SqlConnection(Conexion)

            Using CMD As New SqlClient.SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value = NumeroRecibo

                CMD.Parameters.Add(
                    "@Numero_Factura",
                    SqlDbType.NVarChar,
                    50).Value = NumeroFactura

                CMD.Parameters.Add(
                    "@NombrePago",
                    SqlDbType.NVarChar,
                    50).Value = NombrePago

                CMD.Parameters.Add(
                    "@Descripcion",
                    SqlDbType.NVarChar,
                    50).Value = Descripcion

                CMD.Parameters.Add(
                    "@MontoPagado",
                    SqlDbType.Float).Value =
                    Convert.ToDouble(MontoPagado)


                CN.Open()

                Dim Resultado As Object =
                    CMD.ExecuteScalar()


                If Resultado IsNot Nothing AndAlso
                   Not IsDBNull(Resultado) Then

                    IdDetalleRecibo =
                        Convert.ToDecimal(Resultado)

                End If

            End Using

        End Using


        Return IdDetalleRecibo

    End Function


    Private Function ValidarDatosBasicosRecibo() As Boolean

        If ds Is Nothing Then
            Return False
        End If

        If Not ds.Tables.Contains("DetalleRecibo") Then
            Return False
        End If

        If ds.Tables("DetalleRecibo").Rows.Count = 0 Then
            Return False
        End If

        If Me.TxtCodigoClientes.Text.Trim() = "" Then
            Return False
        End If

        Return True

    End Function


    Private Sub BtnAgregarLinea_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles BtnAgregarLinea.Click

        '--------------------------------------------------
        ' Posicionar el cursor en la nueva línea
        '--------------------------------------------------
        Me.TrueDBGridMetodo.Col = 0
        Me.TrueDBGridMetodo.Focus()

        SeleccionarMetodoPago()

    End Sub

    Private Sub SeleccionarMetodoPago()

        Dim Metodo As String

        Quien = "MetodoPago"

        My.Forms.FrmConsultas.ShowDialog()

        Metodo = FrmConsultas.Codigo

        If Metodo <> "-----0-----" AndAlso Metodo.Trim <> "" Then

            Me.TDBGridDetalle.Columns(0).Text = Metodo

        Else

            Me.TDBGridDetalle.Columns(0).Text = ""

        End If

    End Sub

    Private Sub BtnQuitarLinea_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles BtnQuitarLinea.Click

        Dim posicion As Integer

        If Me.BindingMetodo.DataSource Is Nothing Then
            Exit Sub
        End If

        If Me.BindingMetodo.Count = 0 Then
            Exit Sub
        End If

        posicion = Me.BindingMetodo.Position

        If posicion < 0 OrElse posicion >= Me.BindingMetodo.Count Then
            Exit Sub
        End If


        '==========================================================
        ' NO PERMITIR ELIMINAR EL ULTIMO METODO
        '==========================================================

        If Me.BindingMetodo.Count = 1 Then

            MsgBox(
            "Debe existir al menos un método de pago.",
            MsgBoxStyle.Information,
            "Sistema Facturacion")

            Exit Sub

        End If


        '==========================================================
        ' CONFIRMAR
        '==========================================================

        If MsgBox(
        "¿Desea quitar el método de pago seleccionado?",
        MsgBoxStyle.Question Or MsgBoxStyle.YesNo,
        "Sistema Facturacion") <> MsgBoxResult.Yes Then

            Exit Sub

        End If


        '==========================================================
        ' ELIMINAR
        '==========================================================

        Me.BindingMetodo.RemoveAt(posicion)


        '==========================================================
        ' RECALCULAR
        '==========================================================

        ActualizaMETODORecibos2()

    End Sub

    Private Function ProcesarRetencionesRecibo() As Boolean

        Dim DataSetRetencion As New DataSet
        Dim DataAdapterRetencion As New SqlClient.SqlDataAdapter

        Dim Registros As Integer
        Dim iPosicion As Integer

        Dim NumeroCompra As String
        Dim MontoPagado As Double
        Dim Saldo As Double

        Dim SQlString As String

        Dim Consecutivo As Double
        Dim NumeroNota As String

        '----------------------------------------------------------
        ' Validamos que exista detalle
        '----------------------------------------------------------
        If ds Is Nothing Then
            Return False
        End If

        If Not ds.Tables.Contains("DetalleRecibo") Then
            Return False
        End If

        Registros = ds.Tables("DetalleRecibo").Rows.Count

        '----------------------------------------------------------
        ' Recorremos el detalle del recibo
        '----------------------------------------------------------
        iPosicion = 0

        Do While iPosicion < Registros

            '------------------------------------------------------
            ' Numero de factura
            '------------------------------------------------------
            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")) Then
                NumeroCompra = ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")
            Else
                NumeroCompra = 0
            End If

            '------------------------------------------------------
            ' Monto pagado
            '------------------------------------------------------
            MontoPagado = 0

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")) Then
                MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
            End If

            '------------------------------------------------------
            ' Si existe retención seleccionada
            '------------------------------------------------------
            If Me.OptRet1Porciento.Checked = True Or
               Me.OptRet2Porciento.Checked = True Then

                Saldo = ValidarFacturaEnRecibo(
                    Me.TxtCodigoClientes.Text,
                    NumeroCompra,
                    MontoPagado,
                    Me.TxtMonedaFactura.Text)

                '--------------------------------------------------
                ' El pago no puede ser mayor al saldo
                '--------------------------------------------------
                If MontoPagado <= Saldo Then

                    '==================================================
                    ' RETENCION 1%
                    '==================================================
                    If Me.OptRet1Porciento.Checked = True Then

                        Dim MontoIr As Double
                        Dim CodigoNota As String

                        SQlString =
                            "SELECT CodigoNB, Tipo, Descripcion, CuentaContable " &
                            "FROM NotaDebito " &
                            "WHERE (Tipo = 'Credito Clientes') " &
                            "AND (Descripcion LIKE N'%1%%')"

                        DataAdapterRetencion =
                            New SqlClient.SqlDataAdapter(SQlString, MiConexion)

                        DataAdapterRetencion.Fill(
                            DataSetRetencion,
                            "Retencion")

                        If DataSetRetencion.Tables("Retencion").Rows.Count <> 0 Then

                            MontoIr = Format(
                                FSubTotal * 0.01,
                                "##,##0.00")

                            CodigoNota =
                                DataSetRetencion.Tables("Retencion").Rows(0)("CodigoNB")

                        Else

                            MsgBox(
                                "No Existe Nota de Credito para Retencion 1%",
                                MsgBoxStyle.Critical,
                                "Zeus Facturacion")

                            Me.OptRet1Porciento.Checked = False

                            MontoIr = 0
                            CodigoNota = 0

                        End If

                        DataSetRetencion.Tables("Retencion").Reset()

                        Consecutivo = BuscaConsecutivo("NotaCredito")

                        NumeroNota = Format(
                            Consecutivo,
                            "0000#")

                        GrabaNotaDebito(
                            NumeroNota,
                            Me.DTPFecha.Text,
                            CodigoNota,
                            MontoIr,
                            Me.TxtMonedaFactura.Text,
                            Me.TxtCodigoClientes.Text,
                            Me.TxtNombres.Text,
                            Me.TxtObservaciones.Text,
                            True,
                            False,
                            False)

                        InsertarDetalleNotaDebito(
                            NumeroNota,
                            Me.DTPFecha.Text,
                            CodigoNota,
                            "Generado Automaticamente por Recibos",
                            NumeroCompra,
                            MontoIr)

                    End If

                    '==================================================
                    ' RETENCION 2%
                    '==================================================
                    If Me.OptRet2Porciento.Checked = True Then

                        Dim MontoIr As Double
                        Dim CodigoNota As String

                        SQlString =
                            "SELECT CodigoNB, Tipo, Descripcion, CuentaContable " &
                            "FROM NotaDebito " &
                            "WHERE (Tipo = 'Credito Clientes') " &
                            "AND (Descripcion LIKE N'%2%%')"

                        DataAdapterRetencion =
                            New SqlClient.SqlDataAdapter(SQlString, MiConexion)

                        DataAdapterRetencion.Fill(
                            DataSetRetencion,
                            "Retencion")

                        If DataSetRetencion.Tables("Retencion").Rows.Count <> 0 Then

                            MontoIr = Format(
                                FSubTotal * 0.02,
                                "##,##0.00")

                            CodigoNota =
                                DataSetRetencion.Tables("Retencion").Rows(0)("CodigoNB")

                        Else

                            MsgBox(
                                "No Existe Nota de Credito para Retencion 2%",
                                MsgBoxStyle.Critical,
                                "Zeus Facturacion")

                            Me.OptRet1Porciento.Checked = False

                            MontoIr = 0
                            CodigoNota = 0

                        End If

                        DataSetRetencion.Tables("Retencion").Reset()

                        Consecutivo = BuscaConsecutivo("NotaCredito")

                        NumeroNota = Format(
                            Consecutivo,
                            "0000#")

                        GrabaNotaDebito(
                            NumeroNota,
                            Me.DTPFecha.Text,
                            CodigoNota,
                            MontoIr,
                            Me.TxtMonedaFactura.Text,
                            Me.TxtCodigoClientes.Text,
                            Me.TxtNombres.Text,
                            Me.TxtObservaciones.Text,
                            True,
                            False,
                            False)

                        InsertarDetalleNotaDebito(
                            NumeroNota,
                            Me.DTPFecha.Text,
                            CodigoNota,
                            "Generado Automaticamente por Recibos",
                            NumeroCompra,
                            MontoIr)

                    End If

                Else

                    MsgBox(
                        "Esta Pagando Mas que el Saldo Pendiente!!",
                        MsgBoxStyle.Critical,
                        "Zeus Facturacion")

                    Return False

                End If

            End If

            iPosicion += 1

        Loop

        Return True

    End Function
    Private Function ObtenerNumeroRecibo(ByRef ConsecutivoPago As Double) As String

        Dim DataSet As New DataSet
        Dim DataAdapter As New SqlClient.SqlDataAdapter

        Dim SqlConsecutivo As String
        Dim ConsecutivoManual As Boolean = False

        Dim NumeroRecibo As String = ""

        '==========================================================
        ' BUSCAR CONFIGURACION DE CONSECUTIVO MANUAL
        '==========================================================
        SqlConsecutivo = "SELECT ConsecutivoReciboManual FROM DatosEmpresa"

        DataAdapter = New SqlClient.SqlDataAdapter(
            SqlConsecutivo,
            MiConexion)

        DataAdapter.Fill(
            DataSet,
            "Configuracion")

        If DataSet.Tables("Configuracion").Rows.Count <> 0 Then

            If Not IsDBNull(
                DataSet.Tables("Configuracion").Rows(0)(
                    "ConsecutivoReciboManual")) Then

                ConsecutivoManual =
                    DataSet.Tables("Configuracion").Rows(0)(
                        "ConsecutivoReciboManual")

            End If

        End If


        '==========================================================
        ' OBTENER CONSECUTIVO
        '==========================================================
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            '------------------------------------------------------
            ' RECIBO NUEVO
            '------------------------------------------------------
            If ConsecutivoManual = True Then

                FrmConsecutivos.LblTitulo.Text =
                    "Consecutivos Recibos"

                FrmConsecutivos.LblTitulo2.Text =
                    "RECIBO NO"

                Quien = "Recibo"

                FrmConsecutivos.ShowDialog()

                If FrmConsecutivos.TxtConsecutivo.Text <>
                   "-----0-----" Then

                    ConsecutivoPago =
                        FrmConsecutivos.NumeroFactura

                Else

                    Return ""

                End If

            Else

                If ConsecutivoReciboSerie = False Then

                    ConsecutivoPago =
                        BuscaConsecutivo("Recibo_Caja")

                Else

                    ConsecutivoPago =
                        BuscaConsecutivoSerie(
                            "Recibo",
                            Me.CmbSerie.Text)

                End If

            End If

        Else

            '------------------------------------------------------
            ' RECIBO EXISTENTE / EDICION
            '
            ' IMPORTANTE:
            ' No reconstruimos el NumeroRecibo.
            ' Conservamos exactamente el valor existente.
            '------------------------------------------------------

            If Not IsNumeric(
                Me.TxtNumeroEnsamble.Text) Then

                ConsecutivoPago =
                    Regex.Replace(
                        Me.TxtNumeroEnsamble.Text,
                        "^[^0-9]+",
                        "")

            Else

                ConsecutivoPago =
                    Me.TxtNumeroEnsamble.Text

            End If

        End If


        '==========================================================
        ' DETERMINAR NUMERO DEL RECIBO
        '==========================================================
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            '------------------------------------------------------
            ' RECIBO NUEVO
            '------------------------------------------------------
            If ConsecutivoReciboSerie = False Then

                NumeroRecibo =
                    Format(
                        ConsecutivoPago,
                        "0000#")

            Else

                NumeroRecibo =
                    Me.CmbSerie.Text &
                    Format(
                        ConsecutivoPago,
                        "0000#")

            End If

        Else

            '------------------------------------------------------
            ' RECIBO EXISTENTE / EDICION
            '
            ' Conservar exactamente el numero existente.
            '------------------------------------------------------
            NumeroRecibo =
                Me.TxtNumeroEnsamble.Text.Trim()

        End If


        Return NumeroRecibo

    End Function



    Private Function Celda(ByVal valor As Object, Optional ByVal siVacio As String = "") As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return siVacio
        Dim texto As String = CStr(valor).Trim()
        Return If(texto = "", siVacio, texto)
    End Function

    Private Function CeldaDecimal(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
        If Not TypeOf valor Is String Then Return Convert.ToDecimal(valor)
        Dim numero As Decimal
        If Decimal.TryParse(CStr(valor), numero) Then Return numero
        Return 0D
    End Function



End Class