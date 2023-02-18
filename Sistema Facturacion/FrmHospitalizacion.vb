Imports System.Data.SqlClient

Public Class FrmHospitalizacion
    Public dsMedicamento As New DataSet, daMedicamento As New SqlClient.SqlDataAdapter, CmdBuilderMedicamento As New SqlCommandBuilder
    Public Sub Limpiar_Expediente()

        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.TxtLetra.Text = ""
        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""

        Me.TxtNombreEmergencia.Text = ""
        Me.TxtTelefonoEmergencia.Text = ""
        Me.TxtDireccionEmergencia.Text = ""

        Me.ImgFoto.Image = My.Resources.NoDisponible

        Me.Timer1.Enabled = True
        Me.Timer2.Enabled = True
        Me.BtnIngreso.Visible = True
        Me.BtnSalida.Visible = True


    End Sub
    Public Sub Cargar_Grid()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlCompras As String, DataSet As New DataSet

        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT  Cod_Productos, Descripcion, Cantidad, IdConsulta FROM Medicamentos_Quirofano  WHERE(IdConsulta = -1000)"
        dsMedicamento = New DataSet
        daMedicamento = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderMedicamento = New SqlCommandBuilder(daMedicamento)
        daMedicamento.Fill(dsMedicamento, "DetalleCompra")
        Me.BindingDetalle.DataSource = dsMedicamento.Tables("DetalleCompra")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub

    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, idConsulta As String

        iPosicion = Me.TrueDBGridComponentes.Row
        idConsulta = Me.TrueDBGridComponentes.Columns("idConsulta").Text

        CmdBuilderMedicamento.RefreshSchema()
        oTabla = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daMedicamento.Update(oTabla)
            dsMedicamento.Tables("DetalleCompra").AcceptChanges()
            daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))



            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daMedicamento.Update(oTabla)
                dsMedicamento.Tables("DetalleCompra").AcceptChanges()
                daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))
            End If
        End If

        'ActualizarGridInsertRow(idConsulta)



    End Sub

    Function Buscar_Medico(ByVal Codigo_Medico As String) As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlString As String, Nombres As String, Apellidos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Buscar_Medico = ""

        If Codigo_Medico <> "" Then
            SqlString = "SELECT dbo.Doctores.* FROM dbo.Doctores WHERE (Codigo_Minsa = '" & Codigo_Medico & "') AND (Tipo = 'Doctor')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Doctores")
            If Not DataSet.Tables("Doctores").Rows.Count = 0 Then

                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Nombre_Doctor")) Then
                    Nombres = DataSet.Tables("Doctores").Rows(0)("Nombre_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Apellido_Doctor")) Then
                    Apellidos = DataSet.Tables("Doctores").Rows(0)("Apellido_Doctor")
                End If

            End If

            Buscar_Medico = Nombres & " " & Apellidos
        End If

    End Function

    Private Sub FrmHospitalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.LblFecha2.Text = Format(Now, "dd/MM/yyyy")

        Cargar_Grid()
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Quien = "Expediente"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Cargar_Expediente(My.Forms.FrmConsultas.Codigo)
        End If
    End Sub

    Public Sub Cargar_Expediente(ByVal Numero_Expediente As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroExpediente As String, Num(2) As String, RutaOrigen As String, Fecha As Date
        Dim ds As New DataSet

        Try

            If Numero_Expediente = "" Then
                MsgBox("Se necesita el Numeero del Expediente", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub

            End If

            '///////////////////lleno el combo 7777777777777777777777777777
            SQLstring = "SELECT DISTINCT Tipo_Cirugia FROM Quirofano"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
            DataAdapter.Fill(DataSet, "TipoCirugia")

            If Not DataSet.Tables("TipoCirugia").Rows.Count = 0 Then
                Me.CboTipoCirugia.DataSource = DataSet.Tables("TipoCirugia")
            End If

            SQLstring = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
            DataAdapter.Fill(DataSet, "Expediente")
            If Not DataSet.Tables("Expediente").Rows.Count = 0 Then

                Numero_Expediente = DataSet.Tables("Expediente").Rows(0)("Numero_Expediente")
                Num = Numero_Expediente.Split("-")
                NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                Me.TxtLetra.Text = Num(0)
                Me.TxtCodigo.Text = Format(CDbl(Num(1)), "00000#")

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombres")) Then
                    Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Apellidos")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Emergencia")) Then
                    Me.TxtNombreEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Emergencia")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Telefono_Emergencia")) Then
                    Me.TxtTelefonoEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Telefono_Emergencia")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Direccion_Emergencia")) Then
                    Me.TxtDireccionEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Direccion_Emergencia")
                End If


                Dim CodDepartamento As String, IdMunicipio As Double, IdComarca As Double


                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Expediente & ".bmp"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                Else
                    Me.ImgFoto.Image = My.Resources.NoDisponible
                End If


                '////////////////////////////////////////////////////////////////////////////
                '//////////////////////VALIDO EL USO DEL QUIROFANO /////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////

                SQLstring = "SELECT  Quirofano.*  FROM Quirofano WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1) AND (Tipo_Cirugia = 'Hospitalizacion')"
                ds = BuscaConsulta(SQLstring, "PreConsulta").Copy
                If ds.Tables("PreConsulta").Rows.Count <> 0 Then
                    Me.Timer1.Enabled = False
                    Me.Timer2.Enabled = True
                    Me.BtnIngreso.Visible = False
                    Me.BtnSalida.Visible = True

                    If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Fecha_Hora_Inicio")) Then
                        Fecha = ds.Tables("PreConsulta").Rows(0)("Fecha_Hora_Inicio")

                        Me.DTPFecha.Text = Format(Fecha, "dd/MM/yyyy")
                        Me.LblHora.Text = Format(Fecha, "hh:mm:ss tt")


                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("IdDoctor_CodigoMinsa")) Then
                            Me.txtIdCirujano.Text = ds.Tables("PreConsulta").Rows(0)("IdDoctor_CodigoMinsa")
                            Me.txtNombreCirujano.Text = Buscar_Medico(Me.txtIdCirujano.Text)
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Anestecista_CodigoMinsa")) Then
                            Me.txtIdAnestecista.Text = ds.Tables("PreConsulta").Rows(0)("Anestecista_CodigoMinsa")
                            Me.txtNombreAnestecista.Text = Buscar_Medico(Me.txtIdAnestecista.Text)
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Ayudante_CodigoMinsa")) Then
                            Me.txtIdDoctorAyudante.Text = ds.Tables("PreConsulta").Rows(0)("Ayudante_CodigoMinsa")
                            Me.txtNombreAyudante.Text = Buscar_Medico(Me.txtIdDoctorAyudante.Text)
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Tecnico_Quirofano")) Then
                            Me.txtTecnico.Text = ds.Tables("PreConsulta").Rows(0)("Tecnico_Quirofano")
                            Me.txtNombreTecnico.Text = Buscar_Medico(Me.txtTecnico.Text)
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Tipo_Cirugia")) Then
                            Me.CboTipoCirugia.Text = ds.Tables("PreConsulta").Rows(0)("Tipo_Cirugia")
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Prontuario")) Then
                            Me.txtProntuario.Text = ds.Tables("PreConsulta").Rows(0)("Prontuario")
                        End If

                        If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Diagnostico")) Then
                            Me.TxtDiagnostico.Text = ds.Tables("PreConsulta").Rows(0)("Diagnostico")
                        End If


                    End If
                Else
                    Me.Timer1.Enabled = True
                    Me.Timer2.Enabled = True
                    Me.BtnIngreso.Visible = True
                    Me.BtnSalida.Visible = True
                End If



            Else
                Limpiar_Expediente()
            End If


        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.LblHora2.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()

        Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
        Me.TrueDBGridComponentes.Columns(2).Text = 1
        Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim Resultado As Double, iPosicion As Double

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        iPosicion = Me.BindingDetalle.Position

        If Me.BindingDetalle.Count <> 0 Then

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            oDataRow = dsMedicamento.Tables("DetalleCompra").Rows(iPosicion)
            oDataRow.Delete()

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
            'oTablaBorrados = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Deleted)
            'If Not IsNothing(oTablaBorrados) Then
            '    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            '    daMedicamento.Update(oTablaBorrados)
            'End If
            'dsMedicamento.Tables("DetalleCompra").AcceptChanges()
            'daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))

        End If
    End Sub

    Private Sub BtnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngreso.Click
        Dim Numero_Expediente As String

        Numero_Expediente = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
        Grabar_Registro(Numero_Expediente, Now, Now, True, Me.txtIdCirujano.Text, Me.txtProntuario.Text, Me.TxtDiagnostico.Text, Me.txtIdAnestecista.Text, Me.txtIdDoctorAyudante.Text, Me.txtTecnico.Text, "Hospitalizacion")
    End Sub

    Public Sub Grabar_Registro(ByVal Numero_Expediente As String, ByVal Fecha_Inicio As Date, ByVal Fecha_Fin As Date, ByVal Activo As Boolean, ByVal IdDoctor As String, ByVal Diagnostico As String, ByVal Prontuario As String, ByVal idAnestecista As String, ByVal idAyudante As String, ByVal idTecnico As String, ByVal TipoCirugia As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim ds As New DataSet, idConsultas As Double, i As Double, Cont As Double


        If Numero_Expediente = "" Then
            MsgBox("Se necesita el codigo del Expediente", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If


        SQLstring = "SELECT  Quirofano.*  FROM Quirofano WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1) AND (Tipo_Cirugia = '" & TipoCirugia & "')"
        ds = BuscaConsulta(SQLstring, "PreConsulta").Copy
        If ds.Tables("PreConsulta").Rows.Count <> 0 Then
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "UPDATE [Quirofano] SET  [Fecha_Hora_Fin] = '" & Format(Fecha_Fin, "dd/MM/yyyy HH:mm:ss") & "' ,[Activo] = 0  WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1) AND (Tipo_Cirugia = '" & TipoCirugia & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.Timer2.Enabled = False
            Me.BtnSalida.Visible = False
            Me.BtnIngreso.Visible = False
        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Quirofano] ([Numero_Expediente],[Fecha_Hora_Inicio],[Fecha_Hora_Fin],[Activo],[IdDoctor_CodigoMinsa],[Diagnostico],[Prontuario],[Anestecista_CodigoMinsa],[Ayudante_CodigoMinsa],[Tecnico_Quirofano],[Tipo_Cirugia]) VALUES ('" & Numero_Expediente & "'  ,'" & Format(Fecha_Inicio, "dd/MM/yyyy HH:mm:ss") & "' ,'" & Format(Fecha_Inicio, "dd/MM/yyyy HH:mm:ss") & "',1, '" & IdDoctor & "', '" & Diagnostico & "', '" & Prontuario & "',  '" & idAnestecista & "',  '" & idAyudante & "',  '" & idTecnico & "',  '" & TipoCirugia & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.Timer1.Enabled = False
            Me.BtnIngreso.Visible = False
            Me.BtnSalida.Visible = True
        End If


        MsgBox("Registro Completo", MsgBoxStyle.Exclamation, "Zeus Facturacion")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.txtIdCirujano.Text = My.Forms.FrmConsultas.Codigo
        Me.txtNombreCirujano.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.txtIdAnestecista.Text = My.Forms.FrmConsultas.Codigo
        Me.txtNombreAnestecista.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.txtIdDoctorAyudante.Text = My.Forms.FrmConsultas.Codigo
        Me.txtNombreAyudante.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.txtTecnico.Text = My.Forms.FrmConsultas.Codigo
        Me.txtNombreTecnico.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim ConsecutivoFactura As Double = 0, NumeroFactura As String, iPosicion As Double, Registros As Double, Fecha As Date, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaSalida As Date, Posicion As Double, NumeroRecepcion As String = "", TipoRecepcion As String
        Dim FechaFactura As Date, CodigoCliente As String = "", CodigoBodega As String = "", SubTotal As Double, Pagado As Double = 0, CodProductos As String, NombreProductos As String, PrecioCompra As Double, Cantidad As Double, Importe As Double
        Dim Respuesta As Double, PrecioVenta As Double, IVA As Double, CostoUnitario As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String, IdConsulta As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaImpuesto As Double
        Dim Numero_Expediente As String, ConsecutivoFacturaManual As Double
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Numero_Expediente = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text


        Posicion = Me.BindingDetalle.Position

        Respuesta = MsgBox("Esta Seguro de Generar la Factura a " & Numero_Expediente, MsgBoxStyle.YesNo, "Zeus Facturacion")
        If Respuesta = 7 Then
            Exit Sub
        End If


        My.Forms.FrmFecha.ShowDialog()
        FechaSalida = Format(My.Forms.FrmFecha.FechaCompra, "dd/MM/yyyy")
        Fecha = Format(CDate(FechaSalida), "yyyy-MM-dd")

        TipoRecepcion = "Factura"
        'NumeroRecepcion = Me.TrueDBGridConsultas.Item(Posicion)("NumeroRecepcion")

        SqlString = "SELECT Clientes.* FROM Clientes"
        DataSet = BuscaConsulta(SqlString, "Cliente").Copy
        If DataSet.Tables("Cliente").Rows.Count <> 0 Then
            CodigoCliente = DataSet.Tables("Cliente").Rows(0)("Cod_Cliente")
            NombreCliente = DataSet.Tables("Cliente").Rows(0)("Nombre_Cliente")
        End If

        SqlString = "SELECT Bodegas.* FROM Bodegas "
        DataSet = BuscaConsulta(SqlString, "Bodega").Copy
        If DataSet.Tables("Bodega").Rows.Count <> 0 Then
            CodigoBodega = DataSet.Tables("Bodega").Rows(0)("Cod_Bodega")
        End If

        SubTotal = 0


        Sql = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ConsecutivoFacturaManual = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacturaManual")
        End If


        FechaFactura = Format(Now, "dd/MM/yyyy")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA SALIDA DE BODEGA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        Quien = "NumeroFacturas"
        NumeroFactura = GenerarNumeroFacturaBascula(ConsecutivoFacturaManual, "Factura")

        GrabaEncabezadoFacturas(NumeroFactura, FechaFactura, "Factura", CodigoCliente, CodigoBodega, NombreCliente, NombreCliente, FechaFactura, SubTotal, 0, SubTotal, SubTotal, "Cordobas", "Procesado por Facturacion Hospitalizacion")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        'Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(Precio) AS Precio, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ  FROM Detalle_Recepcion GROUP BY NumeroRecepcion, TipoRecepcion, Cod_Productos, Descripcion_Producto " & _
        '      "HAVING (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleRecepcion")

        Registros = TrueDBGridComponentes.RowCount
        iPosicion = 0
        SubTotal = 0
        IVA = 0
        Do While iPosicion < Registros

            CodProductos = Me.TrueDBGridComponentes.Item(iPosicion)("Cod_Productos")
            IdConsulta = Me.TrueDBGridComponentes.Item(iPosicion)("IdConsulta")

            '////////////////////////////CONSULTO EL PRODUCTO //////////////////////////////////////////////////
            SqlString = "SELECT  * FROM  Productos INNER JOIN Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva WHERE  (Cod_Productos = '" & CodProductos & "')"
            DataSet = BuscaConsulta(SqlString, "Producto").Copy
            PrecioVenta = 0
            NombreProductos = ""
            TasaImpuesto = 0
            If DataSet.Tables("Producto").Rows.Count <> 0 Then
                PrecioVenta = DataSet.Tables("Producto").Rows(0)("Precio_Venta")
                NombreProductos = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
                TasaImpuesto = DataSet.Tables("Producto").Rows(0)("Impuesto")
            End If


            Cantidad = Me.TrueDBGridComponentes.Item(iPosicion)("Cantidad")
            Importe = Format(Cantidad * PrecioVenta, "##,##0.00")
            SubTotal = SubTotal + Importe
            IVA = IVA + (Importe * TasaImpuesto)

            CostoUnitario = CostoPromedioKardex(CodProductos, FechaFactura)

            GrabaDetalleFacturaSalida(NumeroFactura, CodProductos, NombreProductos, PrecioVenta, 0, PrecioCompra, Importe, Cantidad, "Cordobas", FechaFactura, "Factura", CostoUnitario)
            ActualizaExistencia(CodProductos)


            '//////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////ACTUALIZO LOS PRODUCTOS FACTURADOS //////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            StrSqlUpdate = "UPDATE [Medicamentos_Consulta] SET [Facturar] = 0, [Numero_Factura] = '" & NumeroFactura & "' WHERE  (IdConsulta = " & IdConsulta & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            iPosicion = iPosicion + 1
            'Me.ProgressBar.Value = Me.ProgressBar.Value + 1
        Loop



        MiConexion.Close()

        StrSqlUpdate = "UPDATE [Facturas] SET [SubTotal] = " & SubTotal & " ,[IVA] = " & IVA & " ,[Pagado] = 0, [NetoPagar] = " & SubTotal + IVA & ", [MontoCredito] = " & SubTotal + IVA & "  " & _
                       "WHERE  (Tipo_Factura = 'Factura') AND (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102))"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()



        'Cargar_Grid_Medicamentos()

        MsgBox("Se ha Procesado la Factura  No." & NumeroFactura, MsgBoxStyle.Information, "Zeus Facturacion")
    End Sub
End Class