Imports System.Data.SqlClient

Public Class FrmArqueo
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder

    Private Sub FrmArqueo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Arqueo de Caja")
    End Sub
    Private Sub FrmArqueo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.DTFecha.Value = Now

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
    End Sub

    Private Sub CboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCajero.TextChanged
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        MiConexion.Close()
        SqlString = "SELECT *  FROM Cajeros WHERE (Cod_Cajero = '" & Me.CboCajero.Text & "')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cajeros")
        If DataSet.Tables("Cajeros").Rows.Count <> 0 Then
            Me.TxtCajero.Text = DataSet.Tables("Cajeros").Rows(0)("Nombre_Cajero") + " " + DataSet.Tables("Cajeros").Rows(0)("Apellido_Cajero")
        End If

    End Sub

    Private Sub CmdIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIniciar.Click
        Dim ConsecutivoArqueo As Double, NumeroArqueo As String, SqlDenominaciones As String, idDenominacion As Double, CodCajero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, iPosicion As Double, Registros As Double
        Dim Valor As Double, SQlcheques As String, Fecha As String, NumeroTarjeta As String, FechaVence As String, Monto As Double
        Dim NumeroFactura As String, NombrePago As String

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            ConsecutivoArqueo = BuscaConsecutivo("Arqueo")
        Else
            ConsecutivoArqueo = Me.TxtNumeroEnsamble.Text
        End If
        NumeroArqueo = Format(ConsecutivoArqueo, "0000#")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LOS PAGOS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaArqueo(NumeroArqueo)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LAS DENOMINACIONES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDenominaciones = "SELECT  *  FROM Denominacion"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDenominaciones, MiConexion)
        DataAdapter.Fill(DataSet, "Denominacion")
        iPosicion = 0
        Registros = DataSet.Tables("Denominacion").Rows.Count
        If DataSet.Tables("Denominacion").Rows.Count <> 0 Then
            Do While iPosicion < Registros
                idDenominacion = DataSet.Tables("Denominacion").Rows(iPosicion)("idDenominacion")
                Valor = DataSet.Tables("Denominacion").Rows(iPosicion)("Valor")
                GrabaDetalleArqueo(NumeroArqueo, "Cordobas", idDenominacion, Valor, "0.00", "0.00")
                GrabaDetalleArqueo(NumeroArqueo, "Dolares", idDenominacion, Valor, "0.00", "0.00")

                iPosicion = iPosicion + 1
            Loop
        End If


        Fecha = Format(Me.DTFecha.Value, "dd/MM/yyyy")
        CodCajero = Me.CboCajero.Text


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS CHEQUES Y TARJETAS CORDOBAS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlcheques = "SELECT Detalle_MetodoFacturas.Numero_Factura, Detalle_MetodoFacturas.NombrePago, Detalle_MetodoFacturas.NumeroTarjeta,Detalle_MetodoFacturas.Monto, Detalle_MetodoFacturas.FechaVence FROM  Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura And Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                     "WHERE (Detalle_MetodoFacturas.Arqueado = 0) AND (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (MetodoPago.TipoPago <> 'Efectivo') AND (MetodoPago.Moneda = 'Cordobas') AND (Facturas.Cod_Cajero = '" & CodCajero & "')  AND (Detalle_MetodoFacturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Me.DTFecha.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "ORDER BY Detalle_MetodoFacturas.Numero_Factura "
        DataAdapter = New SqlClient.SqlDataAdapter(SQlcheques, MiConexion)
        DataAdapter.Fill(DataSet, "Cheques")
        iPosicion = 0
        Registros = DataSet.Tables("Cheques").Rows.Count
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Registros
        Me.ProgressBar.Value = 0
        If DataSet.Tables("Cheques").Rows.Count <> 0 Then
            Do While iPosicion < Registros
                NumeroFactura = "Fact" & DataSet.Tables("Cheques").Rows(iPosicion)("Numero_Factura")
                NombrePago = DataSet.Tables("Cheques").Rows(iPosicion)("NombrePago")
                NumeroTarjeta = DataSet.Tables("Cheques").Rows(iPosicion)("NumeroTarjeta")
                FechaVence = DataSet.Tables("Cheques").Rows(iPosicion)("FechaVence")
                Monto = DataSet.Tables("Cheques").Rows(iPosicion)("Monto")
                GrabaDetalleArqueoCheque(Fecha, NumeroArqueo, "Cordobas", Monto, NumeroFactura, NombrePago, NumeroTarjeta, FechaVence)
                iPosicion = iPosicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Loop
        End If


        DataSet.Tables("Cheques").Clear()
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS CHEQUES Y TARJETAS DOLARES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlcheques = "SELECT Detalle_MetodoFacturas.Numero_Factura, Detalle_MetodoFacturas.NombrePago, Detalle_MetodoFacturas.NumeroTarjeta,Detalle_MetodoFacturas.Monto, Detalle_MetodoFacturas.FechaVence FROM  Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura And Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                     "WHERE (Detalle_MetodoFacturas.Arqueado = 0) AND (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (MetodoPago.TipoPago <> 'Efectivo') AND (MetodoPago.Moneda = 'Dolares') AND (Facturas.Cod_Cajero = '" & CodCajero & "') AND (Detalle_MetodoFacturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Me.DTFecha.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "ORDER BY Detalle_MetodoFacturas.Numero_Factura "

        DataAdapter = New SqlClient.SqlDataAdapter(SQlcheques, MiConexion)
        DataAdapter.Fill(DataSet, "ChequesDolar")
        iPosicion = 0
        Registros = DataSet.Tables("ChequesDolar").Rows.Count
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Registros
        Me.ProgressBar.Value = 0
        If DataSet.Tables("ChequesDolar").Rows.Count <> 0 Then
            Do While iPosicion < Registros
                NumeroFactura = "Fact" & DataSet.Tables("ChequesDolar").Rows(iPosicion)("Numero_Factura")
                NombrePago = DataSet.Tables("ChequesDolar").Rows(iPosicion)("NombrePago")
                NumeroTarjeta = DataSet.Tables("ChequesDolar").Rows(iPosicion)("NumeroTarjeta")
                FechaVence = DataSet.Tables("ChequesDolar").Rows(iPosicion)("FechaVence")
                Monto = DataSet.Tables("ChequesDolar").Rows(iPosicion)("Monto")
                GrabaDetalleArqueoCheque(Fecha, NumeroArqueo, "Dolares", Monto, NumeroFactura, NombrePago, NumeroTarjeta, FechaVence)
                iPosicion = iPosicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Loop
        End If

        DataSet.Reset()
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS CHEQUES Y TARJETAS CORDOBAS RECIBOS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlcheques = "SELECT Detalle_MetodoRecibo.CodRecibo, Detalle_MetodoRecibo.NombrePago, Detalle_MetodoRecibo.NumeroTarjeta, Detalle_MetodoRecibo.Monto,Recibo.Cod_Cajero, MetodoPago.Moneda, Detalle_MetodoRecibo.Fecha_Vence FROM Detalle_MetodoRecibo INNER JOIN Recibo ON Detalle_MetodoRecibo.CodRecibo = Recibo.CodReciboPago AND Detalle_MetodoRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN MetodoPago ON Detalle_MetodoRecibo.NombrePago = MetodoPago.NombrePago  " & _
              "WHERE (Detalle_MetodoRecibo.Arqueado = 0) AND (MetodoPago.TipoPago <> 'Efectivo') AND (Recibo.Cod_Cajero = '" & CodCajero & "') AND (MetodoPago.Moneda = 'Cordobas') AND (Detalle_MetodoRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTFecha.Value, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlcheques, MiConexion)
        DataAdapter.Fill(DataSet, "Cheques")
        iPosicion = 0
        Registros = DataSet.Tables("Cheques").Rows.Count
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Registros
        Me.ProgressBar.Value = 0
        If DataSet.Tables("Cheques").Rows.Count <> 0 Then
            Do While iPosicion < Registros
                NumeroFactura = "Rec" & DataSet.Tables("Cheques").Rows(iPosicion)("CodRecibo")
                NombrePago = DataSet.Tables("Cheques").Rows(iPosicion)("NombrePago")
                NumeroTarjeta = DataSet.Tables("Cheques").Rows(iPosicion)("NumeroTarjeta")
                FechaVence = DataSet.Tables("Cheques").Rows(iPosicion)("Fecha_Vence")
                Monto = DataSet.Tables("Cheques").Rows(iPosicion)("Monto")
                GrabaDetalleArqueoCheque(Fecha, NumeroArqueo, "Cordobas", Monto, NumeroFactura, NombrePago, NumeroTarjeta, FechaVence)
                iPosicion = iPosicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Loop
        End If

        DataSet.Reset()
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS CHEQUES Y TARJETAS DOLARES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlcheques = "SELECT Detalle_MetodoRecibo.CodRecibo, Detalle_MetodoRecibo.NombrePago, Detalle_MetodoRecibo.NumeroTarjeta, Detalle_MetodoRecibo.Monto,Recibo.Cod_Cajero, MetodoPago.Moneda, Detalle_MetodoRecibo.Fecha_Vence FROM Detalle_MetodoRecibo INNER JOIN Recibo ON Detalle_MetodoRecibo.CodRecibo = Recibo.CodReciboPago AND Detalle_MetodoRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN MetodoPago ON Detalle_MetodoRecibo.NombrePago = MetodoPago.NombrePago  " & _
              "WHERE (Detalle_MetodoRecibo.Arqueado = 0) AND (MetodoPago.TipoPago <> 'Efectivo') AND (Recibo.Cod_Cajero = '" & CodCajero & "') AND (MetodoPago.Moneda = 'Dolares') AND (Detalle_MetodoRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(Me.DTFecha.Value, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlcheques, MiConexion)
        DataAdapter.Fill(DataSet, "ChequesDolar")
        iPosicion = 0
        Registros = DataSet.Tables("ChequesDolar").Rows.Count
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Registros
        Me.ProgressBar.Value = 0
        If DataSet.Tables("ChequesDolar").Rows.Count <> 0 Then
            Do While iPosicion < Registros
                NumeroFactura = "Rec" & DataSet.Tables("ChequesDolar").Rows(iPosicion)("CodRecibo")
                NombrePago = DataSet.Tables("ChequesDolar").Rows(iPosicion)("NombrePago")
                NumeroTarjeta = DataSet.Tables("ChequesDolar").Rows(iPosicion)("NumeroTarjeta")
                FechaVence = DataSet.Tables("ChequesDolar").Rows(iPosicion)("Fecha_Vence")
                Monto = DataSet.Tables("ChequesDolar").Rows(iPosicion)("Monto")
                GrabaDetalleArqueoCheque(Fecha, NumeroArqueo, "Dolares", Monto, NumeroFactura, NombrePago, NumeroTarjeta, FechaVence)
                iPosicion = iPosicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Loop
        End If

        Me.TxtNumeroEnsamble.Text = NumeroArqueo
        Me.CmdGrabar.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Arqueo"
        My.Forms.FrmConsultas.ShowDialog()
        Me.DTFecha.Value = My.Forms.FrmConsultas.Fecha
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
        Me.CboCajero.Text = My.Forms.FrmConsultas.CodCajero
        Me.CmdIniciar.Enabled = False
        Me.DTFecha.Enabled = False
        Me.CboCajero.Enabled = False
        Me.CmdGrabar.Enabled = False
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim NumeroArqueo As String, SQLDetalleCheque As String, CodCajero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQLArqueo As String
        Dim SQlDenominacion As String, Fecha As String

        NumeroArqueo = Me.TxtNumeroEnsamble.Text
        Fecha = Format(Me.DTFecha.Value, "yyyy-MM-dd")
        CodCajero = Me.CboCajero.Text
        Me.CmdIniciar.Enabled = False

        If NumeroArqueo = "-----0-----" Then
            Me.CmdIniciar.Enabled = True
            Exit Sub
        End If

        SQLArqueo = "SELECT * FROM Arqueo WHERE (CodArqueo = '" & NumeroArqueo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLArqueo, MiConexion)
        DataAdapter.Fill(DataSet, "Arqueo")
        If DataSet.Tables("Arqueo").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Arqueo").Rows(0)("Observaciones")) Then
                Me.TxtObservaciones.Text = DataSet.Tables("Arqueo").Rows(0)("Observaciones")
            End If

            If Not IsDBNull(DataSet.Tables("Arqueo").Rows(0)("PracticadoPor")) Then
                Me.TxtPracticadoPor.Text = DataSet.Tables("Arqueo").Rows(0)("PracticadoPor")
            End If

        End If



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////CARGO LA CONSULTA A BINDIGN /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlDenominacion = "SELECT idDenominacion,Valor, Canitdad, Monto FROM Detalle_Arqueo WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Moneda = 'Cordobas')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlDenominacion, MiConexion)
        DataAdapter.Fill(DataSet, "LlenadoCordobas")
        Me.BindingDetalleCordobas.DataSource = DataSet.Tables("LlenadoCordobas")
        Me.TdbGridCordobas.DataSource = Me.BindingDetalleCordobas
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(0).Width = 80
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(1).Width = 80
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(2).Width = 80
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(3).Width = 80
        Me.TdbGridCordobas.Columns(2).NumberFormat = "##,##0.00"
        Me.TdbGridCordobas.Columns(3).NumberFormat = "##,##0.00"
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TdbGridCordobas.Splits.Item(0).DisplayColumns(0).Visible = False

        SQlDenominacion = "SELECT idDenominacion,Valor, Canitdad, Monto FROM Detalle_Arqueo WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Moneda = 'Dolares')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlDenominacion, MiConexion)
        DataAdapter.Fill(DataSet, "LlenadoDolares")
        Me.BindingDetalleDolares.DataSource = DataSet.Tables("LlenadoDolares")
        Me.TdbGridDolares.DataSource = Me.BindingDetalleDolares
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(0).Width = 80
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(1).Width = 80
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(2).Width = 80
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(3).Width = 80
        Me.TdbGridDolares.Columns(2).NumberFormat = "##,##0.00"
        Me.TdbGridDolares.Columns(3).NumberFormat = "##,##0.00"
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TdbGridDolares.Splits.Item(0).DisplayColumns(0).Visible = False

        SQLDetalleCheque = "SELECT NumeroFactura AS [Factura#/Recibo#], NombrePago, NumeroTarjeta AS [Tarjeta#/Cheque#], Monto FROM Detalle_ArqueoCheque  " & _
                           "WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Modena = 'Cordobas') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLDetalleCheque, MiConexion)
        DataAdapter.Fill(DataSet, "Cheque")
        Me.BindingDetalleChequeCordobas.DataSource = DataSet.Tables("Cheque")
        Me.TdbGridChequeCordobas.DataSource = Me.BindingDetalleChequeCordobas
        Me.TdbGridChequeCordobas.Columns(3).NumberFormat = "##,##0.00"
        Me.TdbGridChequeCordobas.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TdbGridChequeCordobas.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TdbGridChequeCordobas.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TdbGridChequeCordobas.Splits.Item(0).DisplayColumns(3).Locked = True

        SQLDetalleCheque = "SELECT NumeroFactura AS [Factura#/Recibo#], NombrePago, NumeroTarjeta AS [Tarjeta#/Cheque#], Monto FROM Detalle_ArqueoCheque  " & _
                           "WHERE (CodArqueo = '" & NumeroArqueo & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Modena = 'Dolares') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLDetalleCheque, MiConexion)
        DataAdapter.Fill(DataSet, "ChequeDolar")
        Me.BindingDetalleChequeDolares.DataSource = DataSet.Tables("ChequeDolar")
        Me.TdbGridChequeDolares.DataSource = Me.BindingDetalleChequeDolares
        Me.TdbGridChequeDolares.Columns(3).NumberFormat = "##,##0.00"
        Me.TdbGridChequeDolares.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TdbGridChequeDolares.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TdbGridChequeDolares.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TdbGridChequeDolares.Splits.Item(0).DisplayColumns(3).Locked = True

        ActualizaMetodoArqueo()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String, NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String
        Dim ArepArqueoCaja As New ArepArqueoCaja, Fecha As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim ArepDenominacion As New ArepDenominacion


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        NombreEmpresa = ""
        DireccionEmpresa = ""
        RutaLogo = ""
        Ruc = ""

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                Ruc = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")


            End If
        End If

        ArepArqueoCaja.LblTitulo.Text = NombreEmpresa
        ArepArqueoCaja.LblDireccion.Text = DireccionEmpresa
        ArepArqueoCaja.LblRuc.Text = Ruc
        If Dir(RutaLogo) <> "" Then
            ArepArqueoCaja.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If
        ArepArqueoCaja.TxtFechaArqueo.Text = Me.DTFecha.Value
        ArepArqueoCaja.TxtCodCajero.Text = Me.CboCajero.Text
        ArepArqueoCaja.TxtNumeroArqueo.Text = Me.TxtNumeroEnsamble.Text
        ArepArqueoCaja.TxtNombreCajero.Text = Me.TxtCajero.Text
        ArepArqueoCaja.LblSubTotal1.Text = Me.TxtSubTotalCordobas.Text
        ArepArqueoCaja.LblSubTotal2.Text = Me.TxtSubTotalDolares.Text
        ArepArqueoCaja.LblSumaFact1.Text = Me.TxtSumaFacturaCordobas.Text
        ArepArqueoCaja.LblSumaFact2.Text = Me.TxtSumaFacturaDolares.Text
        ArepArqueoCaja.LblTotalChequeCordobas.Text = Me.TxtTotalChequeCordobas.Text
        ArepArqueoCaja.LblTotalChequeDolares.Text = Me.TxtTotalChequeDolares.Text
        ArepArqueoCaja.LbltotalCordobasDolares.Text = Me.TxtCordobasDolares.Text
        ArepArqueoCaja.LblMontoRecibidos.Text = Me.TxtValorFacturas.Text
        ArepArqueoCaja.LblDiferencia.Text = Me.TxtDiferencia.Text
        ArepArqueoCaja.LblObservaciones.Text = Me.TxtObservaciones.Text
        ArepArqueoCaja.LblArqueadoPor.Text = "Practicado por " & Me.TxtPracticadoPor.Text
        Fecha = Format(Me.DTFecha.Value, "yyyy-MM-dd")

        SqlDatos = "SELECT * FROM Arqueo WHERE (CodArqueo = '" & Me.TxtNumeroEnsamble.Text & "') AND (FechaArqueo = CONVERT(DATETIME, '" & Fecha & "', 102))"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDatos
        ArepArqueoCaja.DataSource = SQL
        ArepArqueoCaja.Document.Name = "ARQUEO DE CAJA"
        ArepArqueoCaja.Run(False)
        ArepArqueoCaja.Show()

        Me.CmdIniciar.Enabled = True
        Me.DTFecha.Enabled = True
        Me.CboCajero.Enabled = True
    End Sub

    Private Sub TdbGridCordobas_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TdbGridCordobas.AfterColUpdate
        Dim Denominacion As Double, Cantidad As Double, Valor As Double, Col As Double
        Col = e.ColIndex

        Denominacion = Me.TdbGridCordobas.Columns(1).Text
        Cantidad = Me.TdbGridCordobas.Columns(2).Text
        Valor = Denominacion * Cantidad
        Me.TdbGridCordobas.Columns(3).Text = Format(Valor, "##,##0.00")
        ActualizaMetodoArqueo()

    End Sub

    Private Sub TdbGridCordobas_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TdbGridCordobas.AfterUpdate

    End Sub

    Private Sub TdbGridCordobas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TdbGridCordobas.Click

    End Sub

    Private Sub TdbGridDolares_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TdbGridDolares.AfterColUpdate
        Dim Denominacion As Double, Cantidad As Double, Valor As Double, Col As Double
        Col = e.ColIndex
        Denominacion = Me.TdbGridDolares.Columns(1).Text
        Cantidad = Me.TdbGridDolares.Columns(2).Text
        Valor = Denominacion * Cantidad
        Me.TdbGridDolares.Columns(3).Text = Format(Valor, "##,##0.00")
        ActualizaMetodoArqueo()
    End Sub

    Private Sub TdbGridDolares_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TdbGridDolares.AfterUpdate

    End Sub

    Private Sub TdbGridDolares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TdbGridDolares.Click

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim Registros As Double, iPosicion As Double, NumeroArqueo As String, idDenominacion As Double
        Dim Valor As Double, Cantidad As Double, Monto As Double

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO DENOMINACION CORDOBAS////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        idDenominacion = 0
        Valor = 0
        Monto = 0
        Cantidad = 0
        Registros = Me.BindingDetalleCordobas.Count
        NumeroArqueo = Me.TxtNumeroEnsamble.Text
        iPosicion = 0
        Do While iPosicion < Registros

            idDenominacion = BindingDetalleCordobas.Item(iPosicion)("idDenominacion")
            Valor = BindingDetalleCordobas.Item(iPosicion)("Valor")
            Cantidad = BindingDetalleCordobas.Item(iPosicion)("Canitdad")
            Monto = BindingDetalleCordobas.Item(iPosicion)("Monto")

            GrabaDetalleArqueo(NumeroArqueo, "Cordobas", idDenominacion, Valor, Cantidad, Monto)

            iPosicion = iPosicion + 1
        Loop

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO DENOMINACION DOLARES////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        idDenominacion = 0
        Valor = 0
        Monto = 0
        Cantidad = 0
        Registros = Me.BindingDetalleDolares.Count
        NumeroArqueo = Me.TxtNumeroEnsamble.Text
        iPosicion = 0
        Do While iPosicion < Registros

            idDenominacion = BindingDetalleDolares.Item(iPosicion)("idDenominacion")
            Valor = BindingDetalleDolares.Item(iPosicion)("Valor")
            Cantidad = BindingDetalleDolares.Item(iPosicion)("Canitdad")
            Monto = BindingDetalleDolares.Item(iPosicion)("Monto")

            GrabaDetalleArqueo(NumeroArqueo, "Dolares", idDenominacion, Valor, Cantidad, Monto)

            iPosicion = iPosicion + 1
        Loop


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LOS PAGOS /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaArqueo(NumeroArqueo)
    End Sub

    Private Sub TdbGridChequeCordobas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TdbGridChequeCordobas.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub LblCajero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCajero.Click

    End Sub

    Private Sub TxtSumaFacturaDolares_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSumaFacturaDolares.TextChanged

    End Sub

    Private Sub TxtPracticadoPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPracticadoPor.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub TxtTotalChequeCordobas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotalChequeCordobas.TextChanged

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub TxtTotalChequeDolares_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotalChequeDolares.TextChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar.Click

    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click

    End Sub
End Class