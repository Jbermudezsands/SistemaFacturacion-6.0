Imports System.Data.SqlClient

Public Class FrmRecibos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public ConsecutivoReciboSerie As Boolean = False


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
        Bloqueo(Me, Acceso, "Recibo de Caja")
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

        SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo FROM DetalleRecibo WHERE (CodReciboPago = '-1') "
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
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String, Monto As Double
        Dim ConsecutivoPago As Double, NumeroCompra As String, Registros As Double, iPosicion As Double, Cadena As String
        Dim NumeroRecibo As String, MontoPagado As Double, MontoCredito As Double, Descuento As Double, NombrePago As String = ""
        Dim ArepPagoClientes As New ArepPagoClientes, RutaLogo As String, NumeroTarjeta As String, FechaVenceTarjeta As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SQlPagos As String, Descripcion As String = "", FechaVence As Date
        Dim SQlString As String, TipoImpresion As String, RutaBD As String, ArepRecibos2 As New ArepRecibo2
        Dim ConexionAccess As String, iResultado As Integer, ArepReciboTira As New ArepReciboTira, ArepReciboTira2 As New ArepReciboCajaTira
        Dim ComandoUpdate As New SqlClient.SqlCommand, SqlConsecutivo As String, ConsecutivoManual As Boolean = False
        Dim Saldo As Double = 0, Retencion1 As Double = 0, Retencion2 As Double = 0, NumeroNota As String = "", Consecutivo As Double = 0
        Dim ReciboSerie As Boolean = False, idDetalle As Double = -1


        If ds.Tables("DetalleRecibo").Rows.Count = 0 Then
            Exit Sub
        End If

        If Me.TxtCodigoClientes.Text = "" Then
            Exit Sub
        End If

        Me.BindingDetalleRecibo.MoveFirst()
        Registros = ds.Tables("DetalleRecibo").Rows.Count  'Me.BindingDetalleRecibo.Count
        iPosicion = 0
        Do While iPosicion < Registros

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")) Then
                NumeroCompra = ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")
            Else
                NumeroCompra = 0
            End If

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")) Then
                MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
            End If

            If Me.OptRet1Porciento.Checked = True Or Me.OptRet2Porciento.Checked = True Then
                Saldo = ValidarFacturaEnRecibo(Me.TxtCodigoClientes.Text, NumeroCompra, MontoPagado, Me.TxtMonedaFactura.Text)
                If MontoPagado < Saldo Then


                    If Me.OptRet1Porciento.Checked = True Then
                        Dim MontoIr As Double, CodigoNota As String

                        SQlString = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%1%%')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Retencion")
                        If DataSet.Tables("Retencion").Rows.Count <> 0 Then
                            MontoIr = Format(FSubTotal * 0.01, "##,##0.00")
                            CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
                        Else
                            MsgBox("No Existe Nota de Credito para Retencion 1%", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Me.OptRet1Porciento.Checked = False
                            MontoIr = 0
                            CodigoNota = 0
                        End If
                        DataSet.Tables("Retencion").Reset()

                        Consecutivo = BuscaConsecutivo("NotaCredito")
                        NumeroNota = Format(Consecutivo, "0000#")
                        GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, MontoIr, Me.TxtMonedaFactura.Text, Me.TxtCodigoClientes.Text, Me.TxtNombres.Text, Me.TxtObservaciones.Text, True, False)
                        GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Recibos", NumeroCompra, MontoIr)
                    End If


                    If Me.OptRet2Porciento.Checked = True Then
                        Dim MontoIr As Double, CodigoNota As String

                        SQlString = "SELECT CodigoNB, Tipo, Descripcion, CuentaContable FROM NotaDebito WHERE (Tipo = 'Credito Clientes') AND (Descripcion LIKE N'%2%%')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Retencion")
                        If DataSet.Tables("Retencion").Rows.Count <> 0 Then
                            MontoIr = Format(FSubTotal * 0.02, "##,##0.00")
                            CodigoNota = DataSet.Tables("Retencion").Rows(0)("CodigoNB")
                        Else
                            MsgBox("No Existe Nota de Credito para Retencion 2%", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Me.OptRet1Porciento.Checked = False
                            MontoIr = 0
                            CodigoNota = 0
                        End If
                        DataSet.Tables("Retencion").Reset()
                        Consecutivo = BuscaConsecutivo("NotaCredito")
                        NumeroNota = Format(Consecutivo, "0000#")
                        GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, MontoIr, Me.TxtMonedaFactura.Text, Me.TxtCodigoClientes.Text, Me.TxtNombres.Text, Me.TxtObservaciones.Text, True, False)
                        GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, CodigoNota, "Generado Automaticamente por Recibos", NumeroCompra, MontoIr)
                    End If


                Else
                    MsgBox("Esta Pagando Mas que el Saldo Pendiente!!", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
            End If

            iPosicion = iPosicion + 1
        Loop

        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO MANUAL /////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////
        SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        DataAdapter.Fill(DataSet, "Configuracion")
        If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoReciboManual")) Then
                ConsecutivoManual = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoReciboManual")
            End If
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            If ConsecutivoManual = True Then
                FrmConsecutivos.LblTitulo.Text = "Consecutivos Recibos"
                FrmConsecutivos.LblTitulo2.Text = "RECIBO NO"
                Quien = "Recibo"
                FrmConsecutivos.ShowDialog()
                If FrmConsecutivos.TxtConsecutivo.Text <> "-----0-----" Then
                    ConsecutivoPago = FrmConsecutivos.NumeroFactura
                Else
                    Exit Sub
                End If
            Else
                'ConsecutivoPago = BuscaConsecutivo("Recibo_Caja")

                If ConsecutivoReciboSerie = False Then
                    ConsecutivoReciboSerie = BuscaConsecutivo("Recibo_Caja")
                Else
                    ConsecutivoReciboSerie = BuscaConsecutivoSerie("Recibo", Me.CmbSerie.Text)
                End If


            End If
        Else
            If Not IsNumeric(Me.TxtNumeroEnsamble.Text) Then
                ConsecutivoPago = Mid(Me.TxtNumeroEnsamble.Text, 2, Len(Me.TxtNumeroEnsamble.Text) - 1)
            Else
                ConsecutivoPago = Me.TxtNumeroEnsamble.Text
            End If

        End If

        If ConsecutivoReciboSerie = False Then
            NumeroRecibo = Format(ConsecutivoPago, "0000#")
        Else
            NumeroRecibo = Me.CmbSerie.Text & Format(ConsecutivoPago, "0000#")
        End If

        CambiaFechaRecibo = False

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LOS PAGOS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaRecibos(NumeroRecibo)


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DEL RECIBO/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////




        Me.BindingDetalleRecibo.MoveFirst()
        Registros = Me.BindingDetalleRecibo.Count
        iPosicion = 0

        Do While iPosicion < Registros

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("idDetalleRecibo")) Then
                idDetalle = ds.Tables("DetalleRecibo").Rows(iPosicion)("idDetalleRecibo")
            Else
                idDetalle = -1
            End If

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")) Then
                NumeroCompra = ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura")
            Else
                NumeroCompra = 0
                ds.Tables("DetalleRecibo").Rows(iPosicion)("Numero_Factura") = 0
            End If

            ds.Tables("DetalleRecibo").Rows(iPosicion)("CodReciboPago") = NumeroRecibo
            ds.Tables("DetalleRecibo").Rows(iPosicion)("Fecha_Recibo") = Format(Me.DTPFecha.Value, "dd/MM/yyyy")


            NombrePago = ds.Tables("DetalleRecibo").Rows(iPosicion)("NombrePago")
            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("Descripcion")) Then
                Descripcion = ds.Tables("DetalleRecibo").Rows(iPosicion)("Descripcion")
            End If
            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = ds.Tables("DetalleRecibo").Rows(iPosicion)("NumeroTarjeta")
            Else
                NumeroTarjeta = 0
            End If

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("FechaVence")) Then
                FechaVence = ds.Tables("DetalleRecibo").Rows(iPosicion)("FechaVence")
            Else
                FechaVence = Format(Now, "dd/MM/yyyy")
            End If


            MontoPagado = 0
            MontoCredito = 0

            If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")) Then
                If iPosicion <> 0 Then
                    If Me.BindingDetalleRecibo.Item(iPosicion - 1)("NombrePago") = ds.Tables("DetalleRecibo").Rows(iPosicion)("NombrePago") Then
                        MontoPagado = MontoPagado + ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                        If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                            MontoCredito = MontoCredito + ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                        Else
                            MontoCredito = MontoCredito
                        End If
                        Cadena = NombrePago & " $" & MontoPagado

                        '//////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////SI CAMBIA LA FECHA DEL RECIBO /////////////////////////////////
                        '///////////////////////////////////////////////////////////////////////////////////////

                        'If CambiaFechaRecibo = True Then
                        '    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, MontoPagado, NumeroTarjeta, FechaVence)
                        'End If
                    Else
                        MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                        If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                            MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                        Else
                            MontoCredito = MontoCredito
                        End If

                        '//////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////SI CAMBIA LA FECHA DEL RECIBO /////////////////////////////////
                        '///////////////////////////////////////////////////////////////////////////////////////
                        'If CambiaFechaRecibo = True Then
                        '    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, MontoPagado, NumeroTarjeta, FechaVence)
                        'End If

                    End If
                Else

                    MontoPagado = ds.Tables("DetalleRecibo").Rows(iPosicion)("MontoPagado")
                    If Not IsDBNull(ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")) Then
                        MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("SaldoFactura")
                    End If


                    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, MontoPagado, NumeroTarjeta, FechaVence)
                End If

            Else
                MontoPagado = 0
            End If


            'MontoCredito = ds.Tables("DetalleRecibo").Rows(iPosicion)("Saldo")
            If MontoPagado <> 0 Then

                If CambiaFechaRecibo = True Then
                    GrabaDetalleRecibos(NumeroRecibo, NumeroCompra, MontoPagado, NombrePago, Descripcion, NumeroTarjeta, FechaVence, idDetalle)
                End If

                ActualizaMontoCreditoFactura(NumeroCompra, MontoCredito)

                '///////////////////////////////////////////BUSCO SI LA FACTURA QUEDA EN CERO PARA DESACTIVARLAS /////////////////////
                SQlString = "SELECT   *  FROM Facturas WHERE (Numero_Factura = '" & NumeroCompra & "') AND (Tipo_Factura = 'Factura') ORDER BY Fecha_Factura DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Factuas")
                If DataSet.Tables("Factuas").Rows.Count <> 0 Then
                    MiConexion.Close()
                    MontoCredito = DataSet.Tables("Factuas").Rows(0)("MontoCredito")
                    If MontoCredito = 0 Then

                        SQlPagos = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                                     "WHERE  (Numero_Factura = '" & NumeroCompra & "') AND (Tipo_Factura = 'Factura')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(SQlPagos, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    End If

                End If

            Else
                ds.Tables("DetalleRecibo").Rows(iPosicion).Delete()
                Registros = Registros - 1
                iPosicion = iPosicion - 1

            End If



            iPosicion = iPosicion + 1
        Loop

        If CambiaFechaRecibo = False Then
            da.Update(ds.Tables("DetalleRecibo"))
        End If

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQlString = "SELECT NombrePago, MAX(NumeroTarjeta) AS NumeroTarjeta, MAX(FechaVence) AS FechaVence, SUM(MontoPagado) AS MontoPagado  FROM DetalleRecibo WHERE (CodReciboPago = '" & NumeroRecibo & "') GROUP BY NombrePago"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Registros = DataSet.Tables("MetodoPago").Rows.Count
        iPosicion = 0
        Cadena = ""

        Do While iPosicion < Registros
            NombrePago = DataSet.Tables("MetodoPago").Rows(iPosicion)("NombrePago")
            Monto = DataSet.Tables("MetodoPago").Rows(iPosicion)("MontoPagado")
            If Not IsDBNull(DataSet.Tables("MetodoPago").Rows(iPosicion)("NumeroTarjeta")) Then
                NumeroTarjeta = DataSet.Tables("MetodoPago").Rows(iPosicion)("NumeroTarjeta")
            End If
            If Not IsDBNull(DataSet.Tables("MetodoPago").Rows(iPosicion)("FechaVence")) Then
                FechaVenceTarjeta = DataSet.Tables("MetodoPago").Rows(iPosicion)("FechaVence")
            End If

            Cadena = Cadena & " " & NombrePago & " $" & Monto
            GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)

            iPosicion = iPosicion + 1
        Loop


        '//////////////////////////////////////////BUSCO TODAS LAS FACTURAS QUE ESTAN EN CERO PARA DESACTIVARLAS ///////////////////////////////





        'Me.BindingMetodo.MoveFirst()
        'Registros = Me.BindingMetodo.Count
        'iPosicion = 0
        'Monto = 0
        'Do While iPosicion < Registros
        '    NombrePago = Me.BindingMetodo.Item(iPosicion)("NombrePago")
        '    Monto = Me.BindingMetodo.Item(iPosicion)("Monto") + Monto
        '    If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")) Then
        '        NumeroTarjeta = Me.BindingMetodo.Item(iPosicion)("NumeroTarjeta")
        '    Else
        '        NumeroTarjeta = 0
        '    End If
        '    If Not IsDBNull(Me.BindingMetodo.Item(iPosicion)("FechaVence")) Then
        '        FechaVenceTarjeta = Me.BindingMetodo.Item(iPosicion)("FechaVence")
        '    Else
        '        FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
        '    End If

        '    Cadena = NombrePago & " $" & Monto
        '    ArepPagoClientes.TxtMetodo.Text = NombrePago & " $" & Monto
        '    GrabaMetodoDetalleRecibo(NumeroRecibo, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta)
        '    iPosicion = iPosicion + 1
        'Loop

        ArepPagoClientes.TxtMetodo.Text = NombrePago & " $" & Monto

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
        ArepReciboTira2.LblDireccion.Text = Me.TxtDireccion.Text
        ArepReciboTira2.LblTelefono.Text = Me.TxtTelefono.Text
        ArepReciboTira2.LblReciboNo.Text = "Recibo Oficial No:" & NumeroRecibo
        ArepReciboTira2.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyy")

        SqlDatos = "SELECT  *  FROM DetalleRecibo WHERE (CodReciboPago = '" & NumeroRecibo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaConcepto")
        If DataSet.Tables("BuscaConcepto").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("BuscaConcepto").Rows(0)("Descripcion")) Then
                ArepRecibos2.TxtConcepto.Text = DataSet.Tables("BuscaConcepto").Rows(0)("Descripcion")
            End If
        End If


        SQlPagos = "SELECT DISTINCT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MontoCredito+DetalleRecibo.MontoPagado as MontoCredito,DetalleRecibo.MontoPagado, Facturas.MontoCredito AS Saldo, DetalleRecibo.Descripcion, DetalleRecibo.NombrePago FROM Facturas LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura  " & _
                   "WHERE (Facturas.MontoCredito <> 0) AND (Facturas.Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Facturas.Tipo_Factura = 'Factura') AND (DetalleRecibo.CodReciboPago = '" & NumeroRecibo & "') ORDER BY Facturas.Numero_Factura DESC"

        SQL.ConnectionString = Conexion
        SQL.SQL = SQlPagos
        ArepPagoClientes.Document.Name = "SOLICITUD DE PAGO CLIENTES"
        ArepReciboTira.Document.Name = "RECIBOS DE CAJA"

        If Me.TxtDescuento.Text = "" Then
            Descuento = 0
        Else
            Descuento = Me.TxtDescuento.Text
        End If


        '/////////////////////////////////////////////CONSULTO LOSDATOS DE LOS CLIENTES //////////////////////////////////////////////

        SQlString = "SELECT  Clientes.*  FROM Clientes WHERE  (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
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
                'TipoImpresion = Me.TxtTipoRecibo.Text
                SQlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                        Case "Tiras de Papel2"
                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlPagos
                            ArepReciboTira2.DataSource = SQL
                            Dim ViewerForm As New FrmViewer()

                            ViewerForm.arvMain.Document = ArepReciboTira2.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepReciboTira2.Run(False)
                        Case "Tira de Papel"
                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlPagos
                            ArepReciboTira.DataSource = SQL
                            Dim ViewerForm As New FrmViewer()

                            ViewerForm.arvMain.Document = ArepReciboTira.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepReciboTira.Run(False)
                        Case "Papel en Blanco"
                            SQL.ConnectionString = Conexion
                            SQL.SQL = SQlPagos
                            ArepPagoClientes.DataSource = SQL

                            Dim ViewerForm As New FrmViewer()
                            ViewerForm.arvMain.Document = ArepPagoClientes.Document
                            ViewerForm.Show()
                            ArepPagoClientes.Run(False)


                        Case "Papel en Blanco Standard"
                            'SQL.ConnectionString = Conexion
                            'SQL.SQL = SQlPagos
                            'ArepPagoClientes.DataSource = SQL

                            Dim ViewerForm As New FrmViewer()
                            'ViewerForm.arvMain.Document = ArepPagoClientes.Document
                            ViewerForm.arvMain.Document = ArepRecibos2.Document
                            ViewerForm.Show()
                            'ArepPagoClientes.Run(False)
                            ArepRecibos2.Run(False)

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

        LimpiaRecibo()


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
        Dim Metodo As String
        Quien = "MetodoPago"
        My.Forms.FrmConsultas.ShowDialog()
        Metodo = FrmConsultas.Codigo
        Me.TDBGridDetalle.Columns(0).Text = Metodo
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
            FrmRecibosFacturas.CodigoClientes = Me.TxtCodigoClientes.Text
            FrmRecibosFacturas.ShowDialog()
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

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT Recibo.* FROM Recibo WHERE (CodReciboPago = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Recibo = CONVERT(DATETIME, '" & Fecha & "', 102))"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            If Not DataSet.Tables("Recibos").Rows.Count = 0 Then
                Me.TxtCodigoClientes.Text = DataSet.Tables("Recibos").Rows(0)("Cod_Cliente")
                Me.TxtNombres.Text = DataSet.Tables("Recibos").Rows(0)("NombreCliente")
                Me.TxtApellidos.Text = DataSet.Tables("Recibos").Rows(0)("ApellidosCliente")
                Me.TxtDireccion.Text = DataSet.Tables("Recibos").Rows(0)("DireccionCliente")
                Me.TxtTelefono.Text = DataSet.Tables("Recibos").Rows(0)("TelefonoCliente")
                Me.TxtMonedaFactura.Text = DataSet.Tables("Recibos").Rows(0)("MonedaRecibo")
                Me.TxtSubTotal.Text = DataSet.Tables("Recibos").Rows(0)("Sub_Total")
                Me.TxtDescuento.Text = DataSet.Tables("Recibos").Rows(0)("Descuento")
                Me.TxtNetoPagar.Text = DataSet.Tables("Recibos").Rows(0)("Total")




                SqlString = "SELECT NombrePago, Descripcion, Numero_Factura, MontoPagado,NumeroTarjeta,FechaVence,MontoFactura,AplicaFactura,SaldoFactura, idDetalleRecibo, CodReciboPago, Fecha_Recibo FROM DetalleRecibo WHERE (CodReciboPago = '" & Me.TxtNumeroEnsamble.Text & "') "
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

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SQLPagos As String

        '///////////////////////////////////////////BUSCO SI LA FACTURA QUEDA EN CERO PARA DESACTIVARLAS /////////////////////
        SQlString = "SELECT  Recibo.*  FROM Recibo WHERE (Activo = 1) AND (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibo")
        If DataSet.Tables("Recibo").Rows.Count <> 0 Then
            MiConexion.Close()

            SQLPagos = "UPDATE Recibo SET [Contabilizado] = 'True', [Activo] = 'False'   , [NombreCliente] = '******CANCELADO' ,[ApellidosCliente] = '******'  WHERE (Activo = 1) AND (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQLPagos, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            SQLPagos = "UPDATE [DetalleRecibo] SET [MontoPagado] = 0 WHERE (CodReciboPago ='" & Me.TxtNumeroEnsamble.Text & "') "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQLPagos, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        LimpiaRecibo()

    End Sub

    Private Sub TxtMonedaFactura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonedaFactura.SelectedIndexChanged

    End Sub

    Private Sub TxtTipoRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTipoRecibo.TextChanged

    End Sub
End Class