Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class FrmListadoRecibo
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Public Sub Cargar_Grid()
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT  CodReciboPago, Fecha_Recibo, Cod_Cliente, NombreCliente, ApellidosCliente, Sub_Total, Descuento, Total, Activo, Contabilizado FROM  Recibo WHERE    (NombreCliente <> N'******CANCELADO') AND (Activo = 0) AND (Contabilizado = 1) "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Listado")
        Me.TDGridListadoNomina.DataSource = DataSet.Tables("Listado")


    End Sub


    Private Sub FrmListadoRecibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Grid()
    End Sub

    Private Sub BtnVisualizar_Click(sender As Object, e As EventArgs) Handles BtnVisualizar.Click
        Dim Numero_Recibo As String, Fecha_Recibo As Date, Codidgo_Cliente As String

        Numero_Recibo = Me.TDGridListadoNomina.Columns("CodReciboPago").Text
        Fecha_Recibo = Me.TDGridListadoNomina.Columns("Fecha_Recibo").Text
        Codidgo_Cliente = Me.TDGridListadoNomina.Columns("Cod_Cliente").Text

        Quien = "Historico"
        FrmRecibos.Show()
        FrmRecibos.Cargar_Recibos(Numero_Recibo, Fecha_Recibo)
        FrmRecibos.Bloquear_Botones(True)

    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim Numero_Recibo As String, Cod_Cliente As String, FechaRecibo As Date
        Numero_Recibo = Me.TDGridListadoNomina.Columns("CodReciboPago").Text
        FechaRecibo = Me.TDGridListadoNomina.Columns("Fecha_Recibo").Text
        Cod_Cliente = Me.TDGridListadoNomina.Columns("Cod_Cliente").Text

        Imprimir_Recibo(Numero_Recibo, Cod_Cliente)

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
        Dim ReciboSerie As Boolean = False, idDetalle As Double = -1, FechaRecibo As Date, Impresion As String = ""
        Dim oDataRow As DataRow, i As Double, Serie As Boolean = True, Impresora_Defecto As String




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

        SqlDatos = "SELECT CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, Sub_Total, Descuento, Total, NombreCliente, ApellidosCliente, DireccionCliente, TelefonoCliente, MonedaRecibo, Activo, Contabilizado, Marca, Observaciones FROM Recibo WHERE  (CodReciboPago = '" & NumeroRecibo & "') AND (Cod_Cliente = '" & Cod_Cliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Recibo")
        If Not DataSet.Tables("Recibo").Rows.Count = 0 Then
            FechaRecibo = DataSet.Tables("Recibo").Rows(0)("Fecha_Recibo")
            Descuento = DataSet.Tables("Recibo").Rows(0)("Descuento")
            ArepPagoClientes.LblCodCliente.Text = Cod_Cliente
            ArepPagoClientes.LblNombreCliente.Text = DataSet.Tables("Recibo").Rows(0)("NombreCliente")
            ArepPagoClientes.LblApellidos.Text = DataSet.Tables("Recibo").Rows(0)("ApellidosCliente")
            ArepPagoClientes.LblDireccionCliente.Text = DataSet.Tables("Recibo").Rows(0)("DireccionCliente")
            ArepPagoClientes.LblTelefonoCliente.Text = DataSet.Tables("Recibo").Rows(0)("TelefonoCliente")
            ArepPagoClientes.LblOrden.Text = NumeroRecibo
            ArepPagoClientes.TxtObservaciones.Text = DataSet.Tables("Recibo").Rows(0)("Observaciones")
            ArepPagoClientes.LblFechaOrden.Text = DataSet.Tables("Recibo").Rows(0)("Fecha_Recibo")

            '----------------------------SEGUNDO FORMATO DE RECIBO -----------------------------------------------------
            ArepRecibos2.TxtNoRecibo.Text = NumeroRecibo
            ArepRecibos2.TxtFecha.Text = DataSet.Tables("Recibo").Rows(0)("Fecha_Recibo")
            ArepRecibos2.TxtRecibimosDe.Text = DataSet.Tables("Recibo").Rows(0)("NombreCliente")
            ArepRecibos2.TxtLaSumaDe.Text = Letras(DataSet.Tables("Recibo").Rows(0)("Total"), DataSet.Tables("Recibo").Rows(0)("MonedaRecibo"))
            ArepRecibos2.TxtObservaciones.Text = DataSet.Tables("Recibo").Rows(0)("Observaciones")
            ArepRecibos2.LblTitulo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")


            '----------------------------SEGUNDO FORMATO DE TIRA -----------------------------------------------------
            ArepReciboTira.LblNombres.Text = DataSet.Tables("Recibo").Rows(0)("NombreCliente")
            ArepReciboTira.LblDireccion.Text = DataSet.Tables("Recibo").Rows(0)("DireccionCliente")
            ArepReciboTira.LblTelefono.Text = DataSet.Tables("Recibo").Rows(0)("TelefonoCliente")
            ArepReciboTira.LblOrden.Text = NumeroRecibo
            ArepReciboTira.LblFechaOrden.Text = DataSet.Tables("Recibo").Rows(0)("Fecha_Recibo")

            '----------------------------SEGUNDO FORMATO DE TIRA 2-----------------------------------------------------
            ArepReciboTira2.LblNombres.Text = DataSet.Tables("Recibo").Rows(0)("NombreCliente")
            ArepReciboTira2.TxtDireccion.Text = DataSet.Tables("Recibo").Rows(0)("DireccionCliente")
            ArepReciboTira2.LblReciboNo.Text = "Recibo Oficial No: " & NumeroRecibo
            ArepReciboTira2.LblFechaOrden.Text = DataSet.Tables("Recibo").Rows(0)("Fecha_Recibo")
            ArepReciboTira2.LblObservaciones.Text = DataSet.Tables("Recibo").Rows(0)("Observaciones")

            ArepPagoClientes.LblSubTotalRecibo.Text = DataSet.Tables("Recibo").Rows(0)("Sub_Total")
            ArepPagoClientes.LblDescuentoRecibo.Text = Format(Descuento, "##,##0.00")
            ArepPagoClientes.LblPagadoRecibo.Text = DataSet.Tables("Recibo").Rows(0)("Total")
            ArepReciboTira.LblPagadoRecibo.Text = DataSet.Tables("Recibo").Rows(0)("Total")
            ArepReciboTira.LblMontoTexto.Text = Letras(DataSet.Tables("Recibo").Rows(0)("Total"), DataSet.Tables("Recibo").Rows(0)("MonedaRecibo"))
            ArepReciboTira.TxtVendedor.Text = DataSet.Tables("Recibo").Rows(0)("Cod_Cajero")
            ArepRecibos2.TxtMonto.Text = DataSet.Tables("Recibo").Rows(0)("Total")

            ArepReciboTira2.LblPagadoRecibo.Text = DataSet.Tables("Recibo").Rows(0)("Total")
            ArepReciboTira2.LblMontoTexto.Text = Letras(DataSet.Tables("Recibo").Rows(0)("Total"), DataSet.Tables("Recibo").Rows(0)("MonedaRecibo"))
            ArepReciboTira2.TxtVendedor.Text = DataSet.Tables("Recibo").Rows(0)("Cod_Cajero")
        End If




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

        'If Me.TxtDescuento.Text = "" Then
        '    Descuento = 0
        'Else
        '    Descuento = Me.TxtDescuento.Text
        'End If


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






        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie") = True Then
                    Serie = True
                Else
                    Serie = False
                End If
            End If

        End If


        Impresion = "Recibos de Caja"

        If Serie = True Then
            TipoImpresion = Impresion & Mid(NumeroRecibo, 1, 1)
        Else
            TipoImpresion = Impresion
        End If



        Select Case Impresion
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


                            StrSQLUpdate = "UPDATE Usuarios SET [TipoImpresion] = '" & TipoImpresion & "',[NumeroImpresion] = '" & NumeroRecibo & "',[Usuario] = '" & Format(FechaRecibo, "dd/MM/yyyy") & "' "
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

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
End Class