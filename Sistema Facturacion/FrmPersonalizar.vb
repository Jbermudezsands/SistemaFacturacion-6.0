Public Class FrmPersonalizar
    Public MiConexion As New SqlClient.SqlConnection(Conexion), TipoImpresion As String, TipoCoordenadas As String



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        'Me.TxtCtaxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmPersonalizar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Personalizar")
    End Sub

    Private Sub FrmPersonalizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Sql As String = "SELECT  *   FROM Consecutivos"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        Dim SQlInteres As String, SQlDatos As String, RespuestaIva As String, ConsecutivoManual As Boolean, FacturaTarea As Boolean, ImpresionPreview As Boolean
        Dim Metodo As String, LineaFactura As Boolean, ConsecutivoReciboManual As Boolean, CodidoClienteNumerico As Boolean = False
        Dim BloquearPrecios As Boolean = False, BloquearPreciosBajoCosto As Boolean = False, FacturaUnidadMedida As Boolean = False

        DataAdapter.Fill(DataSet, "Consecutivos")
        If Not DataSet.Tables("Consecutivos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Cotizacion")) Then
                Me.TxtCotizaciones.Value = DataSet.Tables("Consecutivos").Rows(0)("Cotizacion")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Transferencia_Enviada")) Then
                Me.TxtTransferenciaEnviadas.Value = DataSet.Tables("Consecutivos").Rows(0)("Transferencia_Enviada")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Factura")) Then
                Me.TxtFactura.Value = CDbl(DataSet.Tables("Consecutivos").Rows(0)("Factura"))
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Compra")) Then
                Me.TxtCompra.Value = DataSet.Tables("Consecutivos").Rows(0)("Compra")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Orden_Compra")) Then
                Me.TxtOrdenCompra.Value = DataSet.Tables("Consecutivos").Rows(0)("Orden_Compra")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Transferecia_Recibida")) Then
                Me.TxtTranferenciaRecibida.Value = DataSet.Tables("Consecutivos").Rows(0)("Transferecia_Recibida")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("DevFactura")) Then
                Me.TxtDevFactura.Value = DataSet.Tables("Consecutivos").Rows(0)("DevFactura")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("DevCompra")) Then
                Me.TxtDevCompra.Value = DataSet.Tables("Consecutivos").Rows(0)("DevCompra")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Ensamble_Recibido")) Then
                Me.TxtEnsambleRecibido.Value = DataSet.Tables("Consecutivos").Rows(0)("Ensamble_Recibido")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Ensamble_Contrato")) Then
                Me.TxtEnsambleContrato.Value = DataSet.Tables("Consecutivos").Rows(0)("Ensamble_Contrato")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Orden_Ensamble")) Then
                Me.TxtOrdenEnsamble.Value = DataSet.Tables("Consecutivos").Rows(0)("Orden_Ensamble")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Deshacer_Ensamble")) Then
                Me.TxtDeshacerEnsamble.Value = DataSet.Tables("Consecutivos").Rows(0)("Deshacer_Ensamble")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Pago_Proveedor")) Then
                Me.TxtPagoProveedor.Value = DataSet.Tables("Consecutivos").Rows(0)("Pago_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Recibo_Caja")) Then
                Me.TxtReciboCaja.Value = DataSet.Tables("Consecutivos").Rows(0)("Recibo_Caja")
            End If
            If Not IsDBNull(DataSet.Tables("Consecutivos").Rows(0)("Arqueo")) Then
                Me.TxtNArqueo.Value = DataSet.Tables("Consecutivos").Rows(0)("Arqueo")
            End If
        End If

        SQlInteres = "SELECT  Cod_Interes, Tasa  FROM Interes"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlInteres, MiConexion)
        DataAdapter.Fill(DataSet, "Interes")
        BindingInteres.DataSource = DataSet.Tables("Interes")
        Me.CboInteres.DataSource = Me.BindingInteres


        SQlInteres = "SELECT  *  FROM MetodoPago"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlInteres, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        BindingMetodo.DataSource = DataSet.Tables("MetodoPago")
        Me.CboMetodoPago.DataSource = Me.BindingMetodo


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.CboMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.CboImprimeFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")
            Me.CboMonedaCompra.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaCompra")
            Me.CboImprimeCompra.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaImprimeCompra")
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("NumeroCopias")) Then
                Me.TxtCopias.Text = DataSet.Tables("DatosEmpresa").Rows(0)("NumeroCopias")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConexionImpresionSQL")) Then
                Me.CmbConexionImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ConexionImpresionSQL")
            Else
                Me.CmbConexionImprime.Text = "Provider=SQLOLEDB.1"
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("DetalleUndFactura")) Then
                FacturaUnidadMedida = DataSet.Tables("DatosEmpresa").Rows(0)("DetalleUndFactura")
                Select Case FacturaUnidadMedida
                    Case True
                        Me.ChkFacturarUnidadMedida.Checked = True
                    Case False
                        Me.ChkFacturarUnidadMedida.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")) Then
                RespuestaIva = DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")
                Select Case RespuestaIva
                    Case "Sumando IVA del Producto"
                        Me.OptIvaSuma.Checked = True
                    Case "Restando IVA del Producto"
                        Me.OptIva1.Checked = True
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
                Select Case ConsecutivoManual
                    Case True
                        Me.ChkConsecutivoFactura.Checked = True
                    Case False
                        Me.ChkConsecutivoFactura.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("PedirCantEscaner")) Then
                Select Case DataSet.Tables("DatosEmpresa").Rows(0)("PedirCantEscaner")
                    Case True
                        Me.ChkPedirCantEscaner.Checked = True
                    Case False
                        Me.ChkPedirCantEscaner.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
                Select Case ConsecutivoManual
                    Case True
                        Me.ChkConsecutivoFactura.Checked = True
                    Case False
                        Me.ChkConsecutivoFactura.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboManual")) Then
                ConsecutivoReciboManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboManual")
                Select Case ConsecutivoReciboManual
                    Case True
                        Me.ChkConsecutivoRecibo.Checked = True
                    Case False
                        Me.ChkConsecutivoRecibo.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")) Then
                FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
                Select Case FacturaTarea
                    Case True
                        Me.ChkFacturarLotes.Checked = True
                    Case False
                        Me.ChkFacturarLotes.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")) Then
                ImpresionPreview = DataSet.Tables("DatosEmpresa").Rows(0)("ImprimirSinPreview")
                Select Case ImpresionPreview
                    Case True
                        Me.ChkFacturaPreview.Checked = True
                    Case False
                        Me.ChkFacturaPreview.Checked = False
                End Select
            Else
                Me.ChkFacturaPreview.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto")) Then
                Metodo = DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto")
                Select Case Metodo
                    Case "Efectivo"
                        Me.ChkEfectivo.Checked = True
                    Case Else
                        Me.ChkEfectivo.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura")) Then
                LineaFactura = DataSet.Tables("DatosEmpresa").Rows(0)("LineaFactura")
                Select Case LineaFactura
                    Case True
                        Me.ChkLineaFactura.Checked = True
                    Case False
                        Me.ChkLineaFactura.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("PorcientoTarjetaCredito")) Then
                Me.TxtIncrementar.Text = DataSet.Tables("DatosEmpresa").Rows(0)("PorcientoTarjetaCredito")
            Else
                Me.TxtIncrementar.Text = 0
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacBodega")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacBodega")
                Select Case ConsecutivoManual
                    Case True
                        Me.ChkFacturaBodega.Checked = True
                    Case False
                        Me.ChkFacturaBodega.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoComBodega")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoComBodega")
                Select Case ConsecutivoManual
                    Case True
                        Me.ChkCompraBodega.Checked = True
                    Case False
                        Me.ChkCompraBodega.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("BloquearBajoCosto")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("BloquearBajoCosto")
                Select Case ConsecutivoManual
                    Case True
                        Me.OptBloquearPrecioBajoCosto.Checked = True
                    Case False
                        Me.OptBloquearPrecioBajoCosto.Checked = False
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("BloquearPreciosFactura")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("BloquearPreciosFactura")
                Select Case ConsecutivoManual
                    Case True
                        Me.OptBloquearPrecio.Checked = True
                    Case False
                        Me.OptBloquearPrecio.Checked = False
                End Select
            End If

            If Me.OptBloquearPrecio.Checked = False And Me.OptBloquearPrecioBajoCosto.Checked = False Then
                Me.OptNoBloquearPrecio.Checked = True
            Else
                Me.OptNoBloquearPrecio.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")) Then
                ConsecutivoManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
                Select Case ConsecutivoManual
                    Case True
                        Me.ChkFacturaSerie.Checked = True
                    Case False
                        Me.ChkFacturaSerie.Checked = False
                End Select
            End If

            If Me.ChkFacturaSerie.Checked = False And Me.ChkFacturaBodega.Checked = False Then
                Me.ChkFacturaGeneral.Checked = True
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("MostrarRetencionFactura") = True Then
                    Me.ChkMostrarRetencion.Checked = True
                Else
                    Me.ChkMostrarRetencion.Checked = False
                End If

            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie") = True Then
                    Me.ChkReciboSerie.Checked = True
                Else
                    Me.ChkReciboSerie.Checked = False
                End If
            End If


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("CalcularPropina")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("CalcularPropina") = True Then
                    Me.ChkPropina.Checked = True
                    Me.TxtPropina.Visible = True

                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("PorcentajePropina")) Then
                        Me.TxtPropina.Text = DataSet.Tables("DatosEmpresa").Rows(0)("PorcentajePropina")
                    End If
                Else
                    Me.ChkPropina.Checked = False
                    Me.TxtPropina.Visible = False
                End If
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("FacturaLotes")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("FacturaLotes") = True Then
                    Me.ChkActivarLotes.Checked = True
                Else
                    Me.ChkActivarLotes.Checked = False
                End If
            End If



            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////CARGO LOS SERIES RECIBOS////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlDatos = "SELECT DISTINCT Serie FROM ConsecutivoSerie"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "ConsecutivoSerieRecibo")
            CmbSerieRecibo.DataSource = DataSet.Tables("ConsecutivoSerieRecibo")
            If Not DataSet.Tables("ConsecutivoSerieRecibo").Rows.Count = 0 Then
                Me.CmbSerieRecibo.Text = DataSet.Tables("ConsecutivoSerieRecibo").Rows(0)("Serie")
            End If

            SQlDatos = "SELECT DISTINCT Serie FROM ConsecutivoSerie"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "ConsecutivoSerieImprime")
            CmbSerieImprime.DataSource = DataSet.Tables("ConsecutivoSerieImprime")
            If Not DataSet.Tables("ConsecutivoSerieImprime").Rows.Count = 0 Then
                Me.CmbSerieImprime.Text = DataSet.Tables("ConsecutivoSerieImprime").Rows(0)("Serie")
            End If


            If Me.ChkFacturaGeneral.Checked = False Then
                Dim DtConsecuitivoFactura As New DataTable
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQlDatos = "SELECT DISTINCT Serie FROM ConsecutivoSerie"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
                DataAdapter.Fill(DtConsecuitivoFactura)
                CmbSerie.DataSource = DtConsecuitivoFactura
                If Not DtConsecuitivoFactura.Rows.Count = 0 Then
                    Me.CmbSerie.Text = DtConsecuitivoFactura.Rows(0)("Serie")
                End If

                'SQlDatos = "SELECT DISTINCT Serie FROM ConsecutivoSerie"
                'DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
                'DataAdapter.Fill(DataSet, "ConsecutivoSerieImprime")
                'CmbSerieImprime.DataSource = DataSet.Tables("ConsecutivoSerieImprime")
                'If Not DataSet.Tables("ConsecutivoSerieImprime").Rows.Count = 0 Then
                '    Me.CmbSerieImprime.Text = DataSet.Tables("ConsecutivoSerieImprime").Rows(0)("Serie")
                'End If


                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQlDatos = "SELECT * FROM ConsecutivoSerie WHERE  (Serie = '" & Me.CmbSerie.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "ConsecutivoSerie")
                If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
                    Me.TxtFactura.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Factura")
                    Me.TxtDevFactura.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("DevFactura")
                    Me.TxtCotizaciones.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Cotizacion")
                    Me.TxtTransferenciaEnviadas.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Transferencia_Enviada")
                End If

            End If




            If Me.ChkReciboSerie.Checked = True Then
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQlDatos = "SELECT * FROM ConsecutivoSerie WHERE  (Serie = '" & Me.CmbSerieRecibo.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "ConsecutivoSerieRecibo2")
                If Not DataSet.Tables("ConsecutivoSerieRecibo2").Rows.Count = 0 Then
                    Me.TxtReciboCaja.Value = DataSet.Tables("ConsecutivoSerieRecibo2").Rows(0)("Recibo")
                End If

            End If




        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLProveedor As String, SqlInteres As String, SqlDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Metodo As String = "Efectivo"
        Dim Tasa As Double, TipoPago As String = "", Descripcion As String = "", RespuestaIva As String, ConsecutivoManual As Integer, FacturaTarea As Integer
        Dim lineaFactura As Integer = 0, PorcientoTarjeta As Double = 0, CompraBodega As Integer = 0, FacturaBodega As Integer = 0, ImpresionPreview As Integer
        Dim FacturaSerie As Integer = 0, ConsecutivoReciboManual As Integer = 0
        Dim BloquearPrecios As Integer = 0, BloquearPreciosBajoCosto As Integer = 0, MostrarRetencion As Integer = 0, ConsecutivoReciboSerie As Integer = 0
        Dim CalcularPropina As Integer = 0, ActivarLotes As Integer = 0, PedirCantEscaner As Integer = 0, FacturarUnidadMedida As Integer = 0

        If Me.TxtIncrementar.Text <> "" Then
            PorcientoTarjeta = Me.TxtIncrementar.Text
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////GRABO LAS FORMAS DE IMPRESION/////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        If Me.ChkFacturaSerie.Checked = False Then
            SQLProveedor = "SELECT  *   FROM Consecutivos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Consecutivos")
            If Not DataSet.Tables("Consecutivos").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Consecutivos]  SET [Factura] = " & Me.TxtFactura.Value & ",[Cotizacion] = " & Me.TxtCotizaciones.Value & ",[Transferencia_Enviada] = " & Me.TxtTransferenciaEnviadas.Value & ",[Compra] = " & Me.TxtCompra.Value & ",[Orden_Compra] = " & Me.TxtOrdenCompra.Value & ",[Transferecia_Recibida] = " & Me.TxtTranferenciaRecibida.Value & ",[DevFactura] = " & Me.TxtDevFactura.Value & ",[DevCompra] = " & Me.TxtDevCompra.Value & ",[Ensamble_Recibido] = " & Me.TxtEnsambleRecibido.Value & " ,[Ensamble_Contrato] = " & Me.TxtEnsambleContrato.Value & ",[Orden_Ensamble] = " & Me.TxtOrdenEnsamble.Value & ",[Deshacer_Ensamble] = " & Me.TxtDeshacerEnsamble.Value & ",[Pago_Proveedor] = " & Me.TxtPagoProveedor.Value & ",[Recibo_Caja] = " & Me.TxtReciboCaja.Value & ",[Arqueo] = " & Me.TxtNArqueo.Value & " "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        Else
            SQLProveedor = "SELECT  *  FROM ConsecutivoSerie WHERE (Serie = '" & Me.CmbSerie.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Consecutivos")
            If Not DataSet.Tables("Consecutivos").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [ConsecutivoSerie]  SET [Factura] = " & Me.TxtFactura.Value & ",[Cotizacion] = " & Me.TxtCotizaciones.Value & ",[Transferencia_Enviada] = " & Me.TxtTransferenciaEnviadas.Value & ",[DevFactura] = " & Me.TxtDevFactura.Value & "  WHERE  (Serie = '" & Me.CmbSerie.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        End If


        '//////////////////////////////////////////////////////////////////////////////////
        '///////////////////GRABO EL INTERES//////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////
        If Me.TxtTasa.Text = "" Then
            Tasa = 0
        Else
            Tasa = CDbl(Me.TxtTasa.Text)
        End If

        If Me.CboInteres.Text <> "" Then
            SqlInteres = "SELECT Interes.* FROM Interes WHERE (Cod_Interes = '" & Me.CboInteres.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlInteres, MiConexion)
            DataAdapter.Fill(DataSet, "Interes")
            If Not DataSet.Tables("Interes").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Interes] SET [Tasa] = " & Tasa & " ,[InteresxCobrar] = '" & Me.TxtInteresxCobrar.Text & "' ,[InteresxPagar] = '" & Me.TxtInteresxPagar.Text & "'  WHERE (Cod_Interes = '" & Me.CboInteres.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else
                MiConexion.Close()
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [Interes] ([Cod_Interes],[Tasa],[InteresxCobrar],[InteresxPagar]) " & _
                               "VALUES('" & Me.CboInteres.Text & "', " & Tasa & " ,'" & Me.TxtInteresxCobrar.Text & "','" & Me.TxtInteresxPagar.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
        End If

        '//////////////////////////////////////////////////////////////////////////////////
        '///////////////////GRABO LOS METODO DE PAGO//////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////

        If Me.RadioButton1.Checked = True Then
            TipoPago = "Efectivo"
        ElseIf Me.RadioButton2.Checked = True Then
            TipoPago = "Cheques"
        ElseIf Me.RadioButton3.Checked = True Then
            TipoPago = "Tarjetas"
        ElseIf Me.RadioButton4.Checked = True Then
            TipoPago = "Cambio"
        ElseIf Me.RadioButton5.Checked = True Then
            TipoPago = "Efectivo,Tarjeta"
        ElseIf Me.RadioButton6.Checked = True Then
            TipoPago = "Cheque,Tarjeta"
        End If



        If Me.CboMetodoPago.Text <> "" Then
            If Me.CboMoneda.Text <> "" Then
                SqlInteres = "SELECT *  FROM MetodoPago WHERE  (NombrePago = '" & Me.CboMetodoPago.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlInteres, MiConexion)
                DataAdapter.Fill(DataSet, "Metodo")
                If Not DataSet.Tables("Metodo").Rows.Count = 0 Then
                    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    StrSqlUpdate = "UPDATE [MetodoPago] SET [TipoPago] = '" & TipoPago & "',[Cod_Cuenta] = '" & Me.TxtCuentaCaja.Text & "',[Moneda] = '" & Me.CboMoneda.Text & "' " & _
                                   "WHERE (NombrePago = '" & Me.CboMetodoPago.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                Else


                    MiConexion.Close()
                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                    StrSqlUpdate = "INSERT INTO [MetodoPago]  ([NombrePago] ,[TipoPago] ,[Cod_Cuenta],[Moneda]) " & _
                                   "VALUES('" & Me.CboMetodoPago.Text & "' ,'" & TipoPago & "','" & Me.TxtCuentaCaja.Text & "','" & Me.CboMoneda.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                End If
            Else
                MsgBox("Se necesita que seleccione una Moneda para el metodo de pago", MsgBoxStyle.Critical, "Sistema Facturacion")
            End If
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////ACTUALIZACION DE LA MONEDA PARA FACTURA Y COMRPAS/////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        If Me.ChkMostrarRetencion.Checked = True Then
            MostrarRetencion = 1
        Else
            MostrarRetencion = 0
        End If

        If Me.OptIva1.Checked = True Then
            RespuestaIva = Me.OptIva1.Text
        Else
            RespuestaIva = Me.OptIvaSuma.Text
        End If

        If Me.ChkConsecutivoFactura.Checked = True Then
            ConsecutivoManual = 1
        Else
            ConsecutivoManual = 0
        End If

        If Me.ChkConsecutivoRecibo.Checked = True Then
            ConsecutivoReciboManual = 1
        Else
            ConsecutivoReciboManual = 0
        End If

        If Me.ChkFacturarLotes.Checked = True Then
            FacturaTarea = 1
        Else
            FacturaTarea = 0
        End If

        If Me.ChkEfectivo.Checked = True Then
            Metodo = "Efectivo"
        Else
            Metodo = "Ninguno"
        End If

        If Me.ChkLineaFactura.Checked = True Then
            lineaFactura = 1
        Else
            lineaFactura = 0
        End If

        If Me.ChkCompraBodega.Checked = True Then
            CompraBodega = 1
        Else
            CompraBodega = 0
        End If

        If Me.ChkFacturaBodega.Checked = True Then
            FacturaBodega = 1
        Else
            FacturaBodega = 0
        End If

        If Me.ChkFacturaPreview.Checked = True Then
            ImpresionPreview = 1
        Else
            ImpresionPreview = 0
        End If

        If Me.ChkFacturaSerie.Checked = True Then
            FacturaSerie = 1
        Else
            FacturaSerie = 0
        End If

        If Me.OptBloquearPrecio.Checked = True Then
            BloquearPrecios = 1
        Else
            BloquearPrecios = 0
        End If

        If Me.OptBloquearPrecioBajoCosto.Checked = True Then
            BloquearPreciosBajoCosto = 1
        Else
            BloquearPreciosBajoCosto = 0
        End If


        If Me.ChkReciboSerie.Checked = True Then
            ConsecutivoReciboSerie = 1
        Else
            ConsecutivoReciboSerie = 0
        End If

        If Me.ChkPropina.Checked = True Then
            CalcularPropina = 1
        Else
            CalcularPropina = 0
        End If

        If Me.CmbConexionImprime.Text = "" Then
            Me.CmbConexionImprime.Text = "Provider=SQLOLEDB.1"
        End If

        If Me.TxtPropina.Text = "" Then
            Me.TxtPropina.Text = 0
        End If

        If Me.ChkActivarLotes.Checked = True Then
            ActivarLotes = 1
        Else
            ActivarLotes = 0
        End If

        If Me.ChkPedirCantEscaner.Checked = True Then
            PedirCantEscaner = 1
        Else
            PedirCantEscaner = 0
        End If

        If Me.ChkFacturarUnidadMedida.Checked = True Then
            FacturarUnidadMedida = 1
        Else
            FacturarUnidadMedida = 0
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            MiConexion.Open()
            StrSqlUpdate = "UPDATE [DatosEmpresa] SET [MonedaFactura] = '" & Me.CboMonedaFactura.Text & "',[ModedaImprimeFactura] = '" & Me.CboImprimeFactura.Text & "',[MonedaCompra] = '" & Me.CboMonedaCompra.Text & "',[MonedaImprimeCompra] = '" & Me.CboImprimeCompra.Text & "',[IvaProducto] = '" & RespuestaIva & "',[ConsecutivoFacturaManual] = " & ConsecutivoManual & ",[Factura_Tarea] = " & FacturaTarea & ",[MetodoPagoDefecto] = '" & Metodo & "',[LineaFactura] = " & lineaFactura & ",[PorcientoTarjetaCredito] = " & PorcientoTarjeta & ",[ConsecutivoFacBodega] = " & FacturaBodega & ",[ConsecutivoComBodega] = " & CompraBodega & ",[ImprimirSinPreview] = " & ImpresionPreview & ",[ConsecutivoFacSerie] = " & FacturaSerie & ",[ConsecutivoReciboManual] = " & ConsecutivoReciboManual & ",[NumeroCopias] = " & Me.TxtCopias.Text & ",[BloquearBajoCosto] = " & BloquearPreciosBajoCosto & ",[BloquearPreciosFactura] = " & BloquearPrecios & " ,[MostrarRetencionFactura] = " & MostrarRetencion & ", [ConsecutivoReciboSerie] = " & ConsecutivoReciboSerie & " , [ConexionImpresionSQL] = '" & Me.CmbConexionImprime.Text & "',[CalcularPropina] = " & CalcularPropina & ", [PorcentajePropina] = '" & Me.TxtPropina.Text & "', [FacturaLotes] = " & ActivarLotes & ", [PedirCantEscaner] = " & PedirCantEscaner & ", [DetalleUndFactura] = " & FacturarUnidadMedida & "  "
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////GRABO LAS FORMAS DE IMPRESION/////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        If Me.OptPapelBlanco.Checked = True Then
            If Me.ChkMediaPagina.Checked = False Then
                Descripcion = Me.OptPapelBlanco.Text
            Else
                Descripcion = Me.OptPapelBlanco.Text & " MediaPagina"
            End If
        ElseIf Me.OptPersonalizado.Checked = True Then
            Descripcion = Me.OptPersonalizado.Text
        ElseIf Me.OptTiraPapel.Checked = True Then
            Descripcion = Me.OptTiraPapel.Text
        ElseIf Me.OptPapelBlanco2.Checked = True Then
            Descripcion = Me.OptPapelBlanco2.Text
        ElseIf Me.OptPapelBlancoLotes.Checked = True Then
            Descripcion = Me.OptPapelBlancoLotes.Text
        End If

        If Me.ListBox1.Text <> "" Then
            '--------------------------------------------------------------------------------------------------------------
            '------------------------------------------BUSCO LAS COORDENADAS ----------------------------------------------
            '--------------------------------------------------------------------------------------------------------------
            SqlDatos = "SELECT  *  FROM Coordenadas WHERE (Tipo = '" & Me.ListBox1.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "CoordenadasBasico")
            If DataSet.Tables("CoordenadasBasico").Rows.Count = 0 Then
                '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
                StrSqlUpdate = "INSERT INTO Coordenadas (Tipo, Nlineas, X1, Y1, X2, Y2, X3, Y3, X4, Y4, X5, Y5, X6, Y6, X7, Y7, X8, Y8, X9, Y9, X10, Y10, X11, Y11, X12, Y12, X13, Y13, X14, Y14, X15, Y15, X16, Y16, X17, Y17, X18, Y18, X19, Y19, X20, Y20, X21, Y21, X22, Y22, X23, Y23, X24, Y24, X25, Y25, X26, Y26, X27, Y27, CaracteresLineas, X28, Y28, X29, Y29, X30, Y30, X31, Y31, X32, Y32, X33, Y33, X34, Y34, X35, Y35, X36, Y36, X37, Y37, X38, Y38, X39, X40, Y40, X41, Y41, CaracteresObservacion)  " & _
                                                   "VALUES ('" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "', 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30)"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


            SqlDatos = "SELECT * FROM Impresion WHERE (Impresion = '" & Me.ListBox1.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "Impresion")
            If DataSet.Tables("Impresion").Rows.Count <> 0 Then
                '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE Impresion  SET [Configuracion] = '" & Descripcion & "' WHERE (Impresion = '" & Me.ListBox1.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '------------ACTUALIZAO EL FORMATO PARA CADA SERIE ------------------
                'SQLProveedor = "SELECT  *  FROM ConsecutivoSerie WHERE (Serie = '" & Me.CmbSerieImprime.Text & "')"
                'DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
                'DataAdapter.Fill(DataSet, "Consecutivos")
                'If Not DataSet.Tables("Consecutivos").Rows.Count = 0 Then
                '    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                '    StrSqlUpdate = "UPDATE [ConsecutivoSerie]  SET [FormatoFactura] = '" & Descripcion & "'  WHERE  (Serie = '" & Me.CmbSerieImprime.Text & "')"
                '    MiConexion.Open()
                '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                '    iResultado = ComandoUpdate.ExecuteNonQuery
                '    MiConexion.Close()
                'End If

            Else

                MiConexion.Close()
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO Impresion ([Impresion] ,[Configuracion]) " & _
                               "VALUES ('" & Me.ListBox1.Text & "' ,'" & Descripcion & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


            End If

            '------------------------------------------------------------------------------------------------------------
            '-----------------------------VERIFICO SI LA FACTURACION POR SERIE PARA AGREGAR FORMATO DE IMPRESION ---------
            '------------------------------------------------------------------------------------------------------------

            If Me.ChkFacturaSerie.Checked = True Or Me.ChkReciboSerie.Checked = True Then

                '--------------------------------------------------------------------------------------------------------------
                '------------------------------------------BUSCO LAS COORDENADAS ----------------------------------------------
                '--------------------------------------------------------------------------------------------------------------
                SqlDatos = "SELECT  *  FROM Coordenadas WHERE (Tipo = '" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "CoordenadasSerie")
                If DataSet.Tables("CoordenadasSerie").Rows.Count = 0 Then
                    '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
                    StrSqlUpdate = "INSERT INTO Coordenadas (Tipo, Nlineas, X1, Y1, X2, Y2, X3, Y3, X4, Y4, X5, Y5, X6, Y6, X7, Y7, X8, Y8, X9, Y9, X10, Y10, X11, Y11, X12, Y12, X13, Y13, X14, Y14, X15, Y15, X16, Y16, X17, Y17, X18, Y18, X19, Y19, X20, Y20, X21, Y21, X22, Y22, X23, Y23, X24, Y24, X25, Y25, X26, Y26, X27, Y27, CaracteresLineas, X28, Y28, X29, Y29, X30, Y30, X31, Y31, X32, Y32, X33, Y33, X34, Y34, X35, Y35, X36, Y36, X37, Y37, X38, Y38, X39, X40, Y40, X41, Y41, CaracteresObservacion)  " & _
                                   "VALUES ('" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "', 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30)"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If


                SqlDatos = "SELECT * FROM Impresion WHERE (Impresion = '" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "ImpresionSerie")
                If DataSet.Tables("ImpresionSerie").Rows.Count <> 0 Then
                    '///////////SI EXISTE LA CONFIGURACION LA ACTUALIZO////////////////
                    StrSqlUpdate = "UPDATE Impresion  SET [Configuracion] = '" & Descripcion & "' WHERE (Impresion = '" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                    '------------ACTUALIZAO EL FORMATO PARA CADA SERIE ------------------
                    'SQLProveedor = "SELECT  *  FROM ConsecutivoSerie WHERE (Serie = '" & Me.CmbSerieImprime.Text & "')"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
                    'DataAdapter.Fill(DataSet, "Consecutivos")
                    'If Not DataSet.Tables("Consecutivos").Rows.Count = 0 Then
                    '    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    '    StrSqlUpdate = "UPDATE [ConsecutivoSerie]  SET [FormatoFactura] = '" & Descripcion & "'  WHERE  (Serie = '" & Me.CmbSerieImprime.Text & "')"
                    '    MiConexion.Open()
                    '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    '    iResultado = ComandoUpdate.ExecuteNonQuery
                    '    MiConexion.Close()
                    'End If

                Else

                    MiConexion.Close()
                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                    StrSqlUpdate = "INSERT INTO Impresion ([Impresion] ,[Configuracion]) " & _
                                   "VALUES ('" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "' ,'" & Descripcion & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()


                End If

            End If

        End If

        MsgBox("Se ha Grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CuentaCaja"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentaCaja.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInteresxPagar.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtInteresxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtInteresxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CboInteres_ItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboInteres.ItemChanged
        Dim SqlInteres As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet

        SqlInteres = "SELECT Interes.* FROM Interes WHERE (Cod_Interes = '" & Me.CboInteres.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlInteres, MiConexion)
        DataAdapter.Fill(DataSet, "Interes")
        If Not DataSet.Tables("Interes").Rows.Count = 0 Then
            Me.TxtTasa.Text = DataSet.Tables("Interes").Rows(0)("Tasa")
            Me.TxtInteresxPagar.Text = DataSet.Tables("Interes").Rows(0)("InteresxPagar")
            Me.TxtInteresxCobrar.Text = DataSet.Tables("Interes").Rows(0)("InteresxCobrar")
        End If
    End Sub

    Private Sub CboInteres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboInteres.TextChanged
        Dim SqlInteres As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet


        SqlInteres = "SELECT Interes.* FROM Interes WHERE (Cod_Interes = '" & Me.CboInteres.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlInteres, MiConexion)
        DataAdapter.Fill(DataSet, "Interes")
        If Not DataSet.Tables("Interes").Rows.Count = 0 Then
            Me.TxtTasa.Text = DataSet.Tables("Interes").Rows(0)("Tasa")
            Me.TxtInteresxPagar.Text = DataSet.Tables("Interes").Rows(0)("InteresxPagar")
            Me.TxtInteresxCobrar.Text = DataSet.Tables("Interes").Rows(0)("InteresxCobrar")
        Else
            Me.TxtTasa.Text = ""
            Me.TxtInteresxPagar.Text = ""
            Me.TxtInteresxCobrar.Text = ""
        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click

    End Sub

    Private Sub CboMetodoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMetodoPago.TextChanged
        Dim SqlMetodo As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, TipoPago As String


        SqlMetodo = "SELECT *  FROM MetodoPago WHERE  (NombrePago = '" & Me.CboMetodoPago.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlMetodo, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        If Not DataSet.Tables("MetodoPago").Rows.Count = 0 Then

            TipoPago = DataSet.Tables("MetodoPago").Rows(0)("TipoPago")
            Select Case TipoPago

                Case "Efectivo" : RadioButton1.Checked = True
                Case "Cheques" : Me.RadioButton2.Checked = True
                Case "Tarjetas" : Me.RadioButton3.Checked = True
                Case "Cambio" : Me.RadioButton4.Checked = True
                Case "Efectivo,Tarjeta" : Me.RadioButton5.Checked = True
                Case "Cheque,Tarjeta" : Me.RadioButton6.Checked = True

            End Select

            Me.TxtCuentaCaja.Text = DataSet.Tables("MetodoPago").Rows(0)("Cod_Cuenta")
            Me.CboMoneda.Text = DataSet.Tables("MetodoPago").Rows(0)("Moneda")

        Else
            Me.TxtCuentaCaja.Text = ""
            Me.RadioButton1.Checked = True

        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptPapelBlanco.CheckedChanged
        If Me.OptPapelBlanco.Checked = True Then
            Me.CmdConfigurar.Visible = False
            Me.ChkMediaPagina.Visible = True
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptPersonalizado.CheckedChanged
        Me.ChkMediaPagina.Checked = False
        Me.ChkMediaPagina.Visible = False

        If Me.ListBox1.Text <> "Cotizacion" Then
            If Me.OptPersonalizado.Checked = True Then
                Me.CmdConfigurar.Visible = True

                If Me.ChkFacturaSerie.Checked = True Then
                    Me.CmbSerieImprime.Visible = True
                End If
            End If
        End If

        If Me.ListBox1.Text = "Notas Debito" Then
            If Me.ChkNotasSerie.Checked = True Then
                Me.CmbSerieImprime.Visible = True
            Else
                Me.CmbSerieImprime.Visible = False
            End If

        ElseIf Me.ListBox1.Text = "Notas Credito" Then
            If Me.ChkNotasSerie.Checked = True Then
                Me.CmbSerieImprime.Visible = True
            Else
                Me.CmbSerieImprime.Visible = False
            End If
        End If
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, Configuracion As String, SqlDatos As String


        Me.OptPapelBlanco2.Visible = True
        Me.OptPersonalizado.Visible = True
        Me.OptTiraPapel.Visible = True
        Me.ChkFacturaPreview.Visible = False
        Me.CmbSerieImprime.Visible = False
        Me.ChkNotasSerie.Visible = False
        Me.ChkMediaPagina.Visible = False
        Me.OptPapelBlancoLotes.Visible = False
        Me.OptPapelBlancoLotes.Text = "Papel en Blanco, Lotes"

        SqlString = "SELECT * FROM Impresion WHERE (Impresion = '" & Me.ListBox1.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impresion")
        If DataSet.Tables("Impresion").Rows.Count <> 0 Then
            Configuracion = DataSet.Tables("Impresion").Rows(0)("Configuracion")
            Me.OptPersonalizado.Text = "Personalizado"
            Select Case Me.ListBox1.Text
                Case "Notas Debito"
                    Me.ChkFacturaPreview.Visible = False
                    Me.OptTiraPapel.Visible = False
                    Me.CmbSerieImprime.Visible = False
                    Me.ChkNotasSerie.Visible = True

                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    Else
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    End If

                Case "Notas Credito"
                    Me.ChkFacturaPreview.Visible = False
                    Me.OptTiraPapel.Visible = False
                    Me.CmbSerieImprime.Visible = False
                    Me.ChkNotasSerie.Visible = True

                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    Else
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    End If

                Case "Salida Bodega"
                    Me.OptPapelBlanco2.Visible = False
                    Me.OptPersonalizado.Visible = True
                    Me.OptTiraPapel.Visible = False
                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    ElseIf Configuracion = "Personalizado" Then
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    End If

                Case "Compra"
                    Me.CmbSerieImprime.Visible = False
                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    Else
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    End If
                Case "Factura"
                    Me.ChkFacturaPreview.Visible = True
                    Me.ChkMediaPagina.Checked = True
                    Me.CmbSerieImprime.Visible = True
                    Me.OptPapelBlancoLotes.Visible = True

                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    ElseIf Configuracion = "Personalizado" Then
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    ElseIf Configuracion = "Tira de Papel" Then
                        Me.OptTiraPapel.Checked = True
                        Me.CmdConfigurar.Visible = False
                    ElseIf Configuracion = "Papel en Blanco, Sin Encabezado" Then
                        Me.OptPapelBlanco2.Checked = True
                        Me.CmdConfigurar.Visible = False
                    ElseIf Configuracion = "Papel en Blanco MediaPagina" Then
                        Me.OptPapelBlanco.Checked = True
                        Me.ChkMediaPagina.Checked = True
                        Me.ChkMediaPagina.Visible = True
                    ElseIf Configuracion = "Papel en Blanco, Lotes" Then
                        Me.OptPapelBlancoLotes.Checked = True
                    End If

                    If Me.ChkFacturaSerie.Checked = True Then
                        SqlDatos = "SELECT * FROM Impresion WHERE (Impresion = '" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "ImpresionSerie")
                        If DataSet.Tables("ImpresionSerie").Rows.Count <> 0 Then
                            Configuracion = DataSet.Tables("ImpresionSerie").Rows(0)("Configuracion")

                            If Configuracion = "Papel en Blanco" Then
                                Me.OptPapelBlanco.Checked = True
                                Me.ChkMediaPagina.Checked = True
                                Me.ChkMediaPagina.Visible = True
                            ElseIf Configuracion = "Personalizado" Then
                                Me.OptPersonalizado.Checked = True
                                Me.CmdConfigurar.Visible = True
                            ElseIf Configuracion = "Tira de Papel" Then
                                Me.OptTiraPapel.Checked = True
                                Me.CmdConfigurar.Visible = False
                            ElseIf Configuracion = "Papel en Blanco, Sin Encabezado" Then
                                Me.OptPapelBlanco2.Checked = True
                                Me.CmdConfigurar.Visible = False
                            ElseIf Configuracion = "Papel en Blanco MediaPagina" Then
                                Me.OptPapelBlanco.Checked = True
                                Me.ChkMediaPagina.Checked = True
                            ElseIf Configuracion = "Papel en Blanco, Lotes" Then
                                Me.OptPapelBlancoLotes.Visible = True
                                Me.OptPapelBlancoLotes.Checked = True
                            End If
                        End If
                    End If

                Case "Cotizacion"
                    Me.OptPersonalizado.Text = "Cotizacion con Fotos"
                    Me.OptPapelBlanco2.Text = "Papel en Blanco Membrete"

                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    ElseIf Configuracion = "Papel en Blanco Membrete" Then
                        Me.OptPapelBlanco2.Checked = True
                    Else

                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = False
                        Me.OptPersonalizado.Text = "Cotizacion con Fotos"
                    End If

                Case "Recibos de Caja"

                    Me.OptPapelBlancoLotes.Visible = True
                    Me.OptPapelBlancoLotes.Text = "Tiras de Papel2"

                    If Me.ChkReciboSerie.Checked = True Then
                        Me.CmbSerieImprime.Visible = True
                    Else
                        Me.CmbSerieImprime.Visible = False
                    End If

                    If Configuracion = "Papel en Blanco" Then
                        Me.OptPapelBlanco.Checked = True
                    ElseIf Configuracion = "Tiras de Papel2" Then
                        Me.OptPapelBlancoLotes.Checked = True

                    Else
                        Me.OptPersonalizado.Checked = True
                        Me.CmdConfigurar.Visible = True
                    End If

            End Select

        End If
    End Sub

    Private Sub GroupBox14_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub CmdConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfigurar.Click

        FrmCoordenadasNotas.Serie = Me.ChkNotasSerie.Checked

        TipoImpresion = Me.ListBox1.Text

        Select Case TipoImpresion
            Case "Notas Debito"
                If Me.ChkNotasSerie.Checked = True Then
                    TipoImpresion = Me.ListBox1.Text & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasNotas.LblSerie.Text = "NOTAS DE DEBITO SERIE " & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasNotas.LblSerie.Visible = True
                    Me.CmbSerieImprime.Visible = True
                Else
                    My.Forms.FrmCoordenadasNotas.LblSerie.Visible = False
                    Me.CmbSerieImprime.Visible = False
                End If
                My.Forms.FrmCoordenadasNotas.Show(Owner)


            Case "Notas Credito"
                If Me.ChkNotasSerie.Checked = True Then
                    TipoImpresion = Me.ListBox1.Text & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasNotas.LblSerie.Text = "NOTAS DE CREDITO SERIE " & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasNotas.LblSerie.Visible = True
                    Me.CmbSerieImprime.Visible = True
                Else
                    My.Forms.FrmCoordenadasNotas.LblSerie.Visible = False
                    Me.CmbSerieImprime.Visible = False
                End If
                My.Forms.FrmCoordenadasNotas.Show(Owner)

            Case "Salida Bodega"
                If Me.ChkFacturaSerie.Checked = True Then
                    TipoImpresion = Me.ListBox1.Text & Me.CmbSerieImprime.Text
                    My.Forms.FrmCordenadas.LblSerie.Text = "SERIE DE SALIDA " & Me.CmbSerieImprime.Text
                    My.Forms.FrmCordenadas.LblSerie.Visible = True
                    Me.CmbSerieImprime.Visible = True
                Else
                    My.Forms.FrmCordenadas.LblSerie.Visible = False
                End If

                My.Forms.FrmCordenadas.Show(Owner)
            Case "Factura"
                If Me.ChkFacturaSerie.Checked = True Then
                    TipoImpresion = Me.ListBox1.Text & Me.CmbSerieImprime.Text
                    My.Forms.FrmCordenadas.LblSerie.Text = "SERIE DE FACTURA " & Me.CmbSerieImprime.Text
                    My.Forms.FrmCordenadas.LblSerie.Visible = True
                    Me.CmbSerieImprime.Visible = True
                Else
                    TipoImpresion = Me.ListBox1.Text
                    My.Forms.FrmCordenadas.LblSerie.Visible = False
                End If
                My.Forms.FrmCordenadas.Show(Owner)

            Case "Recibos de Caja"
                If Me.ChkReciboSerie.Checked = True Then
                    TipoImpresion = Me.ListBox1.Text
                    TipoCoordenadas = Me.ListBox1.Text & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasRecibos.LblSerie.Text = "SERIE DE RECIBO " & Me.CmbSerieImprime.Text
                    My.Forms.FrmCoordenadasRecibos.LblSerie.Visible = True
                    Me.CmbSerieImprime.Visible = True
                Else
                    TipoImpresion = Me.ListBox1.Text
                    TipoCoordenadas = Me.ListBox1.Text
                    My.Forms.FrmCoordenadasRecibos.LblSerie.Visible = False
                End If

                My.Forms.FrmCoordenadasRecibos.Show(Owner)
        End Select
    End Sub

    Private Sub TxtCotizaciones_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCotizaciones.ValueChanged

    End Sub

    Private Sub TxtDeshacerEnsamble_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDeshacerEnsamble.ValueChanged

    End Sub

    Private Sub TxtEnsambleContrato_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEnsambleContrato.ValueChanged

    End Sub

    Private Sub TxtReciboCaja_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtReciboCaja.ValueChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlProductos As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, iPosicionFila As Double = 0
        Dim Fecha As Date, NumeroFactura As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim NombrePago As String = ""
        Dim Iposicion As Double = 0, Registros As Double = 0, CodProducto As String, CostoUnitario As Double

        SqlProductos = "SELECT  *  FROM Detalle_Compras WHERE (Numero_Compra = N'00001')"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")

        If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = DataSet.Tables("Consultas").Rows.Count
            Iposicion = 0
            Registros = DataSet.Tables("Consultas").Rows.Count

            Do While Iposicion <> Registros

                NumeroFactura = DataSet.Tables("Consultas").Rows(Iposicion)("Numero_Compra")
                Fecha = DataSet.Tables("Consultas").Rows(Iposicion)("Fecha_Compra")
                CodProducto = DataSet.Tables("Consultas").Rows(Iposicion)("Cod_Producto")
                CostoUnitario = DataSet.Tables("Consultas").Rows(Iposicion)("Precio_Unitario")



                GrabaComprasHistoricos(NumeroFactura, Fecha, "Mercancia Recibida", CodProducto, 0, CostoUnitario, 1121)



                Iposicion = Iposicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            Loop

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SqlProductos As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, iPosicionFila As Double = 0
        Dim NumeroFactura As String, StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NombrePago As String = ""
        Dim Iposicion As Double = 0, Registros As Double = 0

        SqlProductos = "SELECT  *, Rubro.Nombre_Rubro AS Expr2, Facturas.MonedaFactura AS Expr1 FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN  Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE  (Rubro.Nombre_Rubro = N'Matriculas')"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")

        If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = DataSet.Tables("Consultas").Rows.Count
            Iposicion = 0
            Registros = DataSet.Tables("Consultas").Rows.Count

            Do While Iposicion <> Registros

                NumeroFactura = DataSet.Tables("Consultas").Rows(Iposicion)("Numero_Factura")
                '///////////////////////////////////////////////////CAMBIO LAS FACTURAS A CONTADO ////////////////////////////////////////////////
                SqlProductos = "SELECT   *  FROM Facturas " & _
                               "WHERE   (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura') "

                DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Facturas")
                If DataSet.Tables("Facturas").Rows.Count <> 0 Then
                    MiConexion.Close()
                    StrSqlUpdate = "UPDATE [Facturas] SET [MonedaFactura] = 'Cordobas'" & _
                                   "WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                    StrSqlUpdate = "UPDATE [Detalle_Facturas] SET [TasaCambio] = 1 " & _
                                   "WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                End If

                Iposicion = Iposicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1

            Loop

        End If
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SqlProductos As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, iPosicionFila As Double = 0
        Dim NumeroFactura As String, StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NombrePago As String = ""
        Dim Iposicion As Double = 0, Registros As Double = 0, TasaCambio As Double, Fecha As Date

        SqlProductos = "SELECT  *, Rubro.Nombre_Rubro AS Expr2, Facturas.MonedaFactura AS Expr1 FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN  Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE  (Rubro.Nombre_Rubro = N'Mensualidades')"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")

        If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = DataSet.Tables("Consultas").Rows.Count
            Iposicion = 0
            Registros = DataSet.Tables("Consultas").Rows.Count

            Do While Iposicion <> Registros

                NumeroFactura = DataSet.Tables("Consultas").Rows(Iposicion)("Numero_Factura")
                Fecha = DataSet.Tables("Consultas").Rows(Iposicion)("Fecha_Factura")

                '///////////////////////////////////////////////////CAMBIO LAS FACTURAS A CONTADO ////////////////////////////////////////////////
                SqlProductos = "SELECT   *  FROM Facturas " & _
                               "WHERE   (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura') "

                DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Facturas")
                If DataSet.Tables("Facturas").Rows.Count <> 0 Then
                    MiConexion.Close()
                    StrSqlUpdate = "UPDATE [Facturas] SET [MonedaFactura] = 'Dolares'" & _
                                   "WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                    TasaCambio = BuscaTasaCambio(Fecha)

                    StrSqlUpdate = "UPDATE [Detalle_Facturas] SET [TasaCambio] = " & TasaCambio & "  " & _
                                   "WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                End If

                Iposicion = Iposicion + 1
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1

            Loop

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQl As String = "SELECT *  FROM DetalleRecibo", Registros = 0, iPosicion = 0
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, TasaCambio As Double
        Dim Fecha As Date, IdDetalle As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlUpdate As String

        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")

        Registros = DataSet.Tables("Consultas").Rows.Count
        iPosicion = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = Registros

        Do While Registros > iPosicion
            Fecha = DataSet.Tables("Consultas").Rows(iPosicion)("Fecha_Recibo")
            TasaCambio = BuscaTasaCambio(Fecha)
            IdDetalle = DataSet.Tables("Consultas").Rows(iPosicion)("idDetalleRecibo")

            '///////////////////////////////////////ACTUALIZO LOS DETALLE RECIBOS ///////////////////////////////

            SqlUpdate = "UPDATE [DetalleRecibo]  SET [TasaCambio] = " & TasaCambio & "  WHERE (idDetalleRecibo = " & IdDetalle & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            iPosicion = iPosicion + 1
            Me.ProgressBar.Value = iPosicion
        Loop

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If Me.RadioButton3.Checked = True Then
            Me.LblIncrementar1.Visible = True
            Me.TxtIncrementar.Visible = True
            Me.LblIncrementar2.Visible = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.LblIncrementar1.Visible = False
            Me.TxtIncrementar.Visible = False
            Me.LblIncrementar2.Visible = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            Me.LblIncrementar1.Visible = False
            Me.TxtIncrementar.Visible = False
            Me.LblIncrementar2.Visible = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If Me.RadioButton4.Checked = True Then
            Me.LblIncrementar1.Visible = False
            Me.TxtIncrementar.Visible = False
            Me.LblIncrementar2.Visible = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If Me.RadioButton5.Checked = True Then
            Me.LblIncrementar1.Visible = False
            Me.TxtIncrementar.Visible = False
            Me.LblIncrementar2.Visible = False
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If Me.RadioButton6.Checked = True Then
            Me.LblIncrementar1.Visible = False
            Me.TxtIncrementar.Visible = False
            Me.LblIncrementar2.Visible = False
        End If
    End Sub

    Private Sub OptTiraPapel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTiraPapel.CheckedChanged
        If Me.OptTiraPapel.Checked = True Then
            Me.CmdConfigurar.Visible = False
        End If
    End Sub

    Private Sub ChkFacturaSerie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFacturaSerie.CheckedChanged
        If ChkFacturaSerie.Checked = True Then
            ChkFacturaBodega.Checked = False
            ChkFacturaGeneral.Checked = False
            Me.CmbSerie.Visible = True
        End If
    End Sub

    Private Sub ChkFacturaBodega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFacturaBodega.CheckedChanged
        If Me.ChkFacturaBodega.Checked = True Then
            Me.ChkFacturaSerie.Checked = False
            ChkFacturaGeneral.Checked = False
            Me.CmbSerie.Visible = False
        End If
    End Sub

    Private Sub ChkFacturaGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFacturaGeneral.CheckedChanged
        If Me.ChkFacturaGeneral.Checked = True Then
            Me.ChkFacturaBodega.Checked = False
            Me.ChkFacturaSerie.Checked = False
            Me.CmbSerie.Visible = False
        Else
            Me.ChkFacturaSerie.Checked = True
            ChkFacturaBodega.Checked = False
            Me.CmbSerie.Visible = True
        End If
    End Sub

    Private Sub CmbSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSerie.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQlDatos As String

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlDatos = "SELECT * FROM ConsecutivoSerie WHERE  (Serie = '" & Me.CmbSerie.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.TxtFactura.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Factura")
            Me.TxtDevFactura.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("DevFactura")
            Me.TxtCotizaciones.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Cotizacion")
            Me.TxtTransferenciaEnviadas.Value = DataSet.Tables("ConsecutivoSerie").Rows(0)("Transferencia_Enviada")
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkReciboSerie.CheckedChanged
        If ChkReciboSerie.Checked = True Then
            Me.CmbSerieRecibo.Visible = True

        Else
            Me.CmbSerieRecibo.Visible = False
        End If
    End Sub

    Private Sub CmbSerieRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSerieRecibo.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQlDatos As String

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlDatos = "SELECT * FROM ConsecutivoSerie WHERE  (Serie = '" & Me.CmbSerieRecibo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerieRecibo2")
        If Not DataSet.Tables("ConsecutivoSerieRecibo2").Rows.Count = 0 Then
            Me.TxtReciboCaja.Value = DataSet.Tables("ConsecutivoSerieRecibo2").Rows(0)("Recibo")
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        FrmCopia.TipoCopia = "Compra"
        FrmCopia.ShowDialog()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        FrmCopia.TipoCopia = "Recibos"
        FrmCopia.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        FrmCopia.TipoCopia = "Factura"
        FrmCopia.ShowDialog()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        FrmCopia.TipoCopia = "Productos"
        FrmCopia.ShowDialog()
    End Sub

    Private Sub ChkPropina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPropina.CheckedChanged
        If Me.ChkPropina.Checked = True Then
            Me.TxtPropina.Visible = True
        Else
            Me.TxtPropina.Visible = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkNotasSerie.CheckedChanged
        If Me.ChkNotasSerie.Checked = True Then
            Me.CmbSerieImprime.Visible = True
        Else
            Me.CmbSerieImprime.Visible = False

        End If
    End Sub

    Private Sub CmbSerieImprime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSerieImprime.TextChanged
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, Configuracion As String, SqlDatos As String

        If Me.ChkFacturaSerie.Checked = True Then
            SqlDatos = "SELECT * FROM Impresion WHERE (Impresion = '" & Me.ListBox1.Text & Me.CmbSerieImprime.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "ImpresionSerie")
            If DataSet.Tables("ImpresionSerie").Rows.Count <> 0 Then
                Configuracion = DataSet.Tables("ImpresionSerie").Rows(0)("Configuracion")

                If Configuracion = "Papel en Blanco" Then
                    Me.OptPapelBlanco.Checked = True
                ElseIf Configuracion = "Personalizado" Then
                    Me.OptPersonalizado.Checked = True
                    Me.CmdConfigurar.Visible = True
                ElseIf Configuracion = "Tira de Papel" Then
                    Me.OptTiraPapel.Checked = True
                    Me.CmdConfigurar.Visible = False
                ElseIf Configuracion = "Papel en Blanco, Sin Encabezado" Then
                    Me.OptPapelBlanco2.Checked = True
                    Me.CmdConfigurar.Visible = False
                ElseIf Configuracion = "Papel en Blanco MediaPagina" Then
                    Me.OptPapelBlanco.Checked = True
                    Me.ChkMediaPagina.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub OptPapelBlanco2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptPapelBlanco2.CheckedChanged
        Me.ChkMediaPagina.Visible = False
        Me.ChkMediaPagina.Checked = False
    End Sub

    Private Sub BtnDetalleCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetalleCompra.Click
        LiberarCompras = True
        My.Forms.FrmCompras.EsSolicitud = False
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        My.Forms.FrmImpresoras.ShowDialog()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim SqlString As String




    End Sub
End Class