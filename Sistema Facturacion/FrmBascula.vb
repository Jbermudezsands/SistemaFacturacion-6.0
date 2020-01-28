Public Class FrmBascula
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdLugarAcopio As Double, IdEstadoFisico As Double, IdCategoria As Double, IdTipoLugarAcopio As Double, EstadoFisico As String, Categoria As String, IdCalidad As Double, Calidad As String, TipoPesada As String, TaraRemision As Double, SubTotalRemision As Double, TotalRemision As Double, QQRemision As Double, Posicion As Double, CadenaRecibos As String, IdRemisionPergamino As Double, IdCosecha As Double
    Delegate Sub delegado(ByVal data As String)

    Public Sub SumaPesadaRemision(ByVal ConsecutivoRemision As String, ByVal TipoRemision As String, ByVal Calidad As String, ByVal EstadoFisico As String, ByVal TipoPesada As String)

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Fecha As String

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Pesadas  " & _
        '      "WHERE  (NumeroRemision = '" & ConsecutivoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') "

        Sql = "SELECT  SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & ConsecutivoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRemision =  '" & TipoRemision & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRemision")

        If DataSet.Tables("DetalleRemision").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("DetalleRemision").Rows(0)("Tara")) Then
                TaraRemision = DataSet.Tables("DetalleRemision").Rows(0)("Tara")
            Else
                TaraRemision = 0
            End If
            If Not IsDBNull(DataSet.Tables("DetalleRemision").Rows(0)("PesoKg")) Then
                SubTotalRemision = DataSet.Tables("DetalleRemision").Rows(0)("PesoKg")
            Else
                SubTotalRemision = 0
            End If
            If Not IsDBNull(DataSet.Tables("DetalleRemision").Rows(0)("PesoNetoKg")) Then
                TotalRemision = DataSet.Tables("DetalleRemision").Rows(0)("PesoNetoKg")
            Else
                TotalRemision = 0
            End If
            If Not IsDBNull(DataSet.Tables("DetalleRemision").Rows(0)("QQ")) Then
                QQRemision = DataSet.Tables("DetalleRemision").Rows(0)("QQ")
            Else
                QQRemision = 0
            End If

            Me.txtsubtotal.Text = Format(SubTotalRemision, "##,##0.00")
            Me.TxtTara.Text = Format(TaraRemision, "##,##0.00")
            Me.TxtNeto.Text = Format(TotalRemision, "##,##0.00")

        End If




    End Sub

    Private Sub sp_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim s As String '= sp.ReadExisting, Pesada As Double

        Dim escribeport3 As New delegado(AddressOf Me.mostar)



        s = sp.ReadLine

        Select Case Mid(s, 1, 4)
            Case "TARA" : Exit Sub
            Case "NETO" : Exit Sub
            Case "" : Exit Sub
        End Select

        If Len(s) > 5 Then
            s = SoloNumeros(s)
            Me.Invoke(escribeport3, s)
        End If




    End Sub

    Sub mostar(ByVal d As String)
        Dim Posicion As Double
        Dim Cadena As String, Pesada As Double, PesoEntero As Double, PesoDecimal As Double

        'Cadena = Mid(d, 7, Len(d))
        'Pesada = CDbl(Cadena)
        Cadena = d
        Pesada = SoloNumeros(Cadena)
        '-------------------------------SI SE ACTIVA EL REDONDEO CAMBIO LA PESADA

        'If Me.ChkRedondeo.Checked = True Then
        '    PesoEntero = Int(Pesada)
        '    PesoDecimal = Format(Pesada - PesoEntero, "##0.00")
        '    'If PesoDecimal >= 0.01 And PesoDecimal <= 0.4 Then
        '    '    PesoDecimal = 0
        '    'ElseIf PesoDecimal >= 0.41 And PesoDecimal <= 0.5 Then
        '    '    'PesoDecimal = 0.5
        '    'ElseIf PesoDecimal >= 0.51 And PesoDecimal <= 0.9 Then
        '    '    PesoDecimal = 0.5
        '    'ElseIf PesoDecimal >= 0.91 And PesoDecimal <= 0.99 Then
        '    '    'PesoDecimal = 1
        '    'End If

        '    Pesada = PesoEntero + PesoDecimal
        'End If


        'Posicion = Me.BindingDetalle.Position
        Posicion = Me.TrueDBGridComponentes.Row
        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Pesada
        'Me.LblPeso.Text = Pesada & " Kg"
        My.Application.DoEvents()
        GrabaLecturaPesoRemision(Pesada)
        SumaPesadaRemision(Me.TxtNumeroRemision.Text, Me.TxtTipoRemision.Text, Calidad, EstadoFisico, TipoPesada)
        'Me.BindingDetalle.Position = Posicion + 1
        Me.TrueDBGridComponentes.Row = Posicion + 1


    End Sub
    Public Function BuscaLineaRemision(ByVal NumeroRemision As String, ByVal FechaRemision As Date, ByVal TipoRemision As String, ByVal Calidad As String, ByVal EstadoFisico As String, ByVal TipoPesada As String) As Double
        Dim Sql As String, Fecha As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), Registros As Double, i As Double, j As Double
        Dim iResultado As Integer, SqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, Linea As Double = 0

        Fecha = Format(FechaRemision, "yyyy-MM-dd")

        Sql = "SELECT  Detalle_Pesadas.* FROM Detalle_Pesadas WHERE (NumeroRemision = '" & NumeroRemision & "')  AND (TipoRemision = '" & TipoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRemision, "yyyy-MM-dd") & "', 102)) AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
        'Sql = "SELECT id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Liquidado,  Codigo_BeamsOrigen, RecepcionBin, Transferido, Calidad, Estado, Precio, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ, Calidad_Cafe FROM Detalle_Recepcion " & _
        '      "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "') AND (Fecha = CONVERT(DATETIME,  '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRemision")
        Registros = DataSet.Tables("DetalleRemision").Rows.Count
        i = 0
        j = 1
        Do While Registros > i
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            Linea = DataSet.Tables("DetalleRemision").Rows(i)("id_Eventos")
            SqlUpdate = "UPDATE [Detalle_Pesadas]  SET [id_Eventos] = " & j & " " & _
                        "WHERE (NumeroRemision = '" & NumeroRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRemision, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "') AND (id_Eventos = " & Linea & ") AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            i = i + 1
            j = j + 1
        Loop
        BuscaLineaRemision = j

    End Function



    Public Sub GrabaLecturaPesoRemision(ByVal Peso As Double)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Dim NumeroRemision As String, Registros As Double, Iposicion As Double
        Dim Linea As Double, CodigoProducto As String, Cantidad As Double, Descripcion As String, UnidadMedida As String = ""
        Dim CodigoBeamsOrigen As String = "", CodigoRecepcionBin As String = "", Calidad As String
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, PesoKg As Double, Precio As Double, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Tara As Double = 0, PesoNetoLb As Double = 0, PesoNetoKg As Double = 0, QQ As Double = 0, SubTotal As Double = 0
        Dim HumedadxDefecto As Double = 0, HumedadReal As Double = 0
        Dim Factor As Double = 0


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////


        NumeroRemision = Me.TxtNumeroRemision.Text
        Registros = Me.BindingDetalle.Count
        Iposicion = Me.BindingDetalle.Position
        If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
            Linea = BuscaLineaRemision(NumeroRemision, CDate(Me.DTPFecha.Text), Me.TxtTipoRemision.Text, Me.Calidad, Me.EstadoFisico, Me.TipoPesada)
        Else
            Linea = Me.TrueDBGridComponentes.Columns(0).Text
        End If

        CodigoProducto = Me.CboIngresoBascula.Columns(0).Text
        Cantidad = Peso
        Descripcion = Me.CboIngresoBascula.Columns(1).Text

        Precio = 0

        '-------------------------------PREGUNTO LOS QUINTALES -----------------------------
        '--------------------------------------------------------------------------------------
        Factor = 0
        QQ = 0
        If Me.ChkTaraSaco.Checked = True Then
            Factor = 3
            My.Forms.FrmQQ.ShowDialog()
            QQ = My.Forms.FrmQQ.QQ
        End If
        'My.Forms.FrmQQ.ShowDialog()
        'QQ = My.Forms.FrmQQ.QQ

        '///////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////CONVERTIR DE LIBRAS A KG //////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////
        PesoKg = Cantidad
        Cantidad = Format((Cantidad / 46) * 100, "##,##0.00")


        '//////////////////////////////ESTA OPCION SOLO CALCULA TARA PARA EL DETALLE DE REMISION ////////////////////////////
        '//////////////////////////////LAS ENTRADAS Y SALIDAS NO LLEVAN TARA ///////////////////////////////////////////////

        If Me.TipoPesada = "Repesaje" & Me.Posicion Then
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////CONSULTO LAS TARAS /////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            Tara = Factor * QQ
        Else
            Tara = 0
        End If

        PesoNetoKg = Format((PesoKg - Tara), "##,##0.0000")
        PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

        'GrabaDetalleRemision(NumeroRemision, CodigoProducto, Cantidad, Linea, Descripcion, Calidad, Estado, Precio, PesoKg, FrmBascula.TxtTipoRemision.Text, Tara, PesoNetoKg, QQ, FrmBascula.Calidad, FrmBascula.TipoPesada, FrmBascula.DTPRemFechCarga.Value, IdRemision)
        'ActualizaDetalleRemision(NumeroRemision, FrmBascula.TxtTipoRemision.Text, FrmBascula.Calidad, FrmBascula.EstadoFisico, FrmBascula.TipoPesada)


        Me.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        Me.TrueDBGridComponentes.Columns(2).Text = Descripcion
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Calidad").Visible = False
        'Me.TrueDBGridComponentes.Columns(3).Text = Calidad
        'Me.TrueDBGridComponentes.Columns(4).Text = Estado
        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Cantidad
        Me.TrueDBGridComponentes.Columns("PesoKg").Text = PesoKg
        Me.TrueDBGridComponentes.Columns("Tara").Text = Tara
        Me.TrueDBGridComponentes.Columns("PesoNetoLb").Text = PesoNetoLb
        Me.TrueDBGridComponentes.Columns("PesoNetoKg").Text = PesoNetoKg
        Me.TrueDBGridComponentes.Columns("Saco").Text = QQ
        'Me.TrueDBGridComponentes.Columns(11).Text = Format(Precio / 46, "##,##0.00")
        Me.TrueDBGridComponentes.Columns("Linea").Text = Linea
        Me.TxtNumeroRemision.Text = NumeroRemision

        Iposicion = Me.TrueDBGridComponentes.Row
        Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1
        Me.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        Me.TrueDBGridComponentes.Columns(2).Text = Descripcion
        Me.TrueDBGridComponentes.Col = 5


        Me.txtsubtotal.Text = TotalRecepcion(Me.TxtNumeroRemision.Text, Me.DTPFecha.Text, Me.TxtTipoRemision.Text)



        SubTotal = Me.txtsubtotal.Text






    End Sub



    Private Sub Siguiente()
        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            Dim Iposicion As Double
            Iposicion = Me.TrueDBGridComponentes.RowCount
            Me.TrueDBGridComponentes.Row = Iposicion
            Me.TrueDBGridComponentes.Columns(1).Text = Me.CboIngresoBascula.Columns(0).Text
            Me.TrueDBGridComponentes.Columns(2).Text = Me.CboIngresoBascula.Columns(1).Text
            Me.TrueDBGridComponentes.Col = 5
        End If
    End Sub

    Private Sub FrmBascula_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim TotalRecibos As Double

        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            If TipoPesada = "DetalleRemision" & Posicion Then

                'Me.TDBGridDetalle.Columns("CantidadSacos").Text = QQRemision
                'Me.TDBGridDetalle.Columns("PesoBruto").Text = SubTotalRemision
                'Me.TDBGridDetalle.Columns("Tara").Text = TaraRemision
                'Me.TDBGridDetalle.Columns("PesoNeto").Text = TotalRemision

                FrmInventarioFisico.PesoBruto = TotalRemision
                FrmInventarioFisico.Numero_Repesaje = Me.TxtNumeroRemision.Text
            ElseIf TipoPesada = "PuntoIntermedio" & Posicion Then
                'My.Forms.FrmPuntosInter.TxtCantDest.Text = QQRemision
                'My.Forms.FrmPuntosInter.TxtPesoBrutDestino.Text = SubTotalRemision
            End If
        End If

    End Sub

    Private Sub FrmBascula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, TipoRemision As String, SqlString As String, Fecha As Date
        Dim Cont As Double

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        Button_Pesada.Visible = True


        '//////////////////SI NO SE HA GRABADO SE ASIGNA UN NUMERO TEMPORAL A LA PESADA /////////////
        If FrmInventarioFisico.Numero_Repesaje = "-----0-----" Then
            Me.TxtNumeroRemision.Text = FrmInventarioFisico.NumeroTemporal
            Me.IdRemisionPergamino = 0
        ElseIf FrmInventarioFisico.Numero_Repesaje = "" Then
            FrmInventarioFisico.NumeroTemporal = FrmInventarioFisico.Random.Next()
            Me.TxtNumeroRemision.Text = FrmInventarioFisico.NumeroTemporal
        Else
            Me.TxtNumeroRemision.Text = FrmInventarioFisico.Numero_Repesaje
        End If

        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")



        sql = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboIngresoBascula.DataSource = DataSet.Tables("ListaProductos")
            Me.CboIngresoBascula.Text = DataSet.Tables("ListaProductos").Rows(0)("Descripcion_Producto")
        End If

        Me.CboIngresoBascula.Splits(0).DisplayColumns(1).Width = 400

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco  FROM Detalle_Pesadas  WHERE (NumeroRemision = N'-100000')"
        'sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Pesadas   WHERE (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRemision = '" & Me.TxtTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "')"
        sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd") & "', 102)) AND (TipoPesada = 'Repesaje')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRemision")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRemision")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("TipoRemision").Visible = False



        SumaPesadaRemision(Me.TxtNumeroRemision.Text, Me.TxtTipoRemision.Text, Calidad, EstadoFisico, TipoPesada)


        '///////////////////////////////////AL CARGAR LOS REGISTROS ME UBICO EN LA ULTIMA PESADA ///////////
        Siguiente()
    End Sub

    Private Sub Eventos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eventos.Enter

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Conectar.Click
        My.Forms.FrmPuertos.Pregunta = "Bascula"
        My.Forms.FrmPuertos.ShowDialog()
    End Sub

    Private Sub Button_Desconectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Desconectar.Click
        Me.sp.Close()
        Me.LblEstado.Text = "DESCONECT"
        Me.LblEstado.ForeColor = Color.Black
    End Sub

    Private Sub Button_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Salir.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand


        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            Button_Grabar_Click(sender, e)
        End If


        Me.sp.Close()
        Me.Close()

    End Sub

    Private Sub CmdPesada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pesada.Click
        Dim Pesada As Double, Posicion As Double

        Posicion = Me.TrueDBGridComponentes.Row

        FrmTeclado.ShowDialog()
        Pesada = FrmTeclado.Numero
        Me.LblPeso.Text = Pesada & " Kg"
        'Pesada = 100

        Me.TrueDBGridComponentes.Columns(5).Text = Pesada
        My.Application.DoEvents()
        GrabaLecturaPesoRemision(Pesada)
        Me.TrueDBGridComponentes.Row = Posicion + 1

        SumaPesadaRemision(Me.TxtNumeroRemision.Text, Me.TxtTipoRemision.Text, Calidad, EstadoFisico, TipoPesada)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
        My.Application.DoEvents()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim SQLProveedor As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, Posicion As Double, CodigoLinea As String = ""
        Dim CodigoIngreso As String = "", SqlString As String = "", Fecha As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Ingreso?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado <> 6 Then
            Exit Sub
        End If

        Posicion = Me.BindingDetalle.Position
        If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Linea")) Then
            CodigoLinea = Me.BindingDetalle.Item(Posicion)("Linea")
        End If

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        SQLProveedor = "SELECT * FROM Detalle_Pesadas WHERE (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRemision = '" & Me.TxtTipoRemision.Text & "') AND (id_Eventos = " & CodigoLinea & ") AND (TipoPesada = '" & TipoPesada & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        If Not DataSet.Tables("Deducciones").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [Detalle_Pesadas] WHERE (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRemision = '" & Me.TxtTipoRemision.Text & "') AND (id_Eventos = " & CodigoLinea & ") AND (TipoPesada = '" & TipoPesada & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If



        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Pesadas   WHERE (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRemision = '" & Me.TxtTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75

        SumaPesadaRemision(Me.TxtNumeroRemision.Text, Me.TxtTipoRemision.Text, Calidad, EstadoFisico, TipoPesada)


        '///////////////////////////////////AL CARGAR LOS REGISTROS ME UBICO EN LA ULTIMA PESADA ///////////
        Siguiente()

    End Sub

    Private Sub Button_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Grabar.Click
        Dim TotalRecibos As Double

        If Me.TrueDBGridComponentes.RowCount = 0 Then
            MsgBox("Necesita Grabar Pesadas", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If TipoPesada = "Repesaje" Then
            'TotalRecibos = Me.TDBGridDetalle.Columns("PesoNeto2").Text

            ''/////////////////////SE QUITA VALIDACION POR INTRUCCIONES DE EXPORTADORA ARCHIVO EXCEL 30/07/2019 /
            ''If TotalRemision > TotalRecibos Then
            ''    MsgBox("Las Pesadas no puede ser mayor que lo recibos", MsgBoxStyle.Critical, "Sistema Bascula")
            ''    Exit Sub
            ''End If

            'Me.TDBGridDetalle.Columns("CantidadSacos").Text = QQRemision
            'Me.TDBGridDetalle.Columns("PesoBruto").Text = SubTotalRemision
            'Me.TDBGridDetalle.Columns("Tara").Text = TaraRemision
            FrmInventarioFisico.PesoBruto = TotalRemision

            FrmInventarioFisico.Numero_Repesaje = Me.TxtNumeroRemision.Text

        ElseIf TipoPesada = "PuntoIntermedio" & Posicion Then
            'My.Forms.FrmPuntosInter.TxtCantDest.Text = QQRemision
            'My.Forms.FrmPuntosInter.TxtPesoBrutDestino.Text = SubTotalRemision
        End If
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CmdPesada_Click(sender, e)
    End Sub
End Class