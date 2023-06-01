Imports System.Data.SqlClient
Public Class FrmExamenes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdPreConsultas As Double, HoraInicio As Date, IdConsultorio As Double, IdDoctor As Double
    Public dsMedicamento As New DataSet, daMedicamento As New SqlClient.SqlDataAdapter, CmdBuilderMedicamento As New SqlCommandBuilder
    Public ConsecutivoFacturaManual As Boolean = False
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String, IdConsulta As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaImpuesto As Double



        IdConsulta = Me.TDGridMedicamentos.Item(Me.TDGridMedicamentos.Row)("IdConsulta")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////ACTUALIZO LOS PRODUCTOS FACTURADOS //////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        StrSqlUpdate = "UPDATE [TipoExamen_Consulta] SET [Facturado] = 0 WHERE  (IdConsulta = " & IdConsulta & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Cargar_Grid_Examenes()

    End Sub


    Public Sub Cargar_Grid_Examenes()
        Dim SqlCompras As String

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT Expediente.Numero_Expediente, TipoExamen_Consulta.Descripcion, Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombre_Paciente, Consultorio.Nombre_Consultorio, Doctores.Nombre_Doctor + ' ' + Doctores.Apellido_Doctor AS Nombre_Doctor, Consulta.Activo, TipoExamen_Consulta.Facturado, Consulta.IdConsulta, TipoExamen_Consulta.IdTipoExamen FROM Consulta INNER JOIN  Doctores ON Consulta.IdDoctor_CodigoMinsa = Doctores.Codigo_Minsa INNER JOIN Consultorio ON Consulta.IdConsultorio = Consultorio.IdConsultorio INNER JOIN Expediente ON Consulta.Numero_Expediente = Expediente.Numero_Expediente INNER JOIN TipoExamen_Consulta ON Consulta.IdConsulta = TipoExamen_Consulta.IdConsulta  WHERE(Consulta.Activo = 1) AND (TipoExamen_Consulta.Facturado = 0)"
        dsMedicamento = New DataSet
        daMedicamento = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderMedicamento = New SqlCommandBuilder(daMedicamento)
        daMedicamento.Fill(dsMedicamento, "DetalleCompra")
        Me.BindingDetalle.DataSource = dsMedicamento.Tables("DetalleCompra")
        Me.TDGridMedicamentos.DataSource = Me.BindingDetalle
        Me.TDGridMedicamentos.Columns("Numero_Expediente").Caption = "Expediente"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Expediente").Width = 120
        Me.TDGridMedicamentos.Columns("Nombre_Paciente").Caption = "Paciente"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Nombre_Paciente").Width = 120
        Me.TDGridMedicamentos.Columns("Nombre_Consultorio").Caption = "Consultorio"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Nombre_Consultorio").Width = 120
        Me.TDGridMedicamentos.Columns("Nombre_Doctor").Caption = "Nombre Doctor"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Nombre_Doctor").Width = 150
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Nombre_Doctor").Locked = True
        Me.TDGridMedicamentos.Columns("Descripcion").Caption = "Descripcion Producto"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Descripcion").Width = 200
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Activo").Visible = False
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("IdConsulta").Visible = False
    End Sub

    Private Sub FrmExamenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Grid_Examenes()
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim ConsecutivoFactura As Double = 0, NumeroFactura As String, iPosicion As Double, Registros As Double, Fecha As Date, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaSalida As Date, Posicion As Double, NumeroRecepcion As String = "", TipoRecepcion As String
        Dim FechaFactura As Date, CodigoCliente As String = "", CodigoBodega As String = "", SubTotal As Double, Pagado As Double = 0, CodProductos As String, NombreProductos As String, PrecioCompra As Double, Cantidad As Double, Importe As Double
        Dim Respuesta As Double, PrecioVenta As Double, IVA As Double, CostoUnitario As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String, IdConsulta As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaImpuesto As Double


        Posicion = Me.BindingDetalle.Position

        Respuesta = MsgBox("Esta Seguro de Generar la Factura a " & Me.TDGridMedicamentos.Item(Posicion)("Numero_Expediente"), MsgBoxStyle.YesNo, "Zeus Facturacion")
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

        GrabaEncabezadoFacturas(NumeroFactura, FechaFactura, "Factura", CodigoCliente, CodigoBodega, NombreCliente, NombreCliente, FechaFactura, SubTotal, 0, SubTotal, SubTotal, "Cordobas", "Procesado por Facturacion Medicamentos")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        'Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(Precio) AS Precio, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ  FROM Detalle_Recepcion GROUP BY NumeroRecepcion, TipoRecepcion, Cod_Productos, Descripcion_Producto " & _
        '      "HAVING (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleRecepcion")

        Registros = Me.TDGridMedicamentos.RowCount
        iPosicion = 0
        SubTotal = 0
        IVA = 0
        Do While iPosicion < Registros

            CodProductos = Me.TDGridMedicamentos.Item(iPosicion)("Cod_Productos")
            IdConsulta = Me.TDGridMedicamentos.Item(iPosicion)("IdConsulta")

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


            Cantidad = Me.TDGridMedicamentos.Item(iPosicion)("Cantidad")
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

        '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////ACTUALIZO LA TABLA CONSULTA //////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        IdConsulta = Me.TDGridMedicamentos.Item(Me.TDGridMedicamentos.Row)("IdConsulta")
        MiConexion.Close()
        StrSqlUpdate = "UPDATE [Consulta] SET [Activo] = 0 WHERE  (IdConsulta = " & IdConsulta & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        Cargar_Grid_Examenes()

        MsgBox("Se ha Procesado la Factura  No." & NumeroFactura, MsgBoxStyle.Information, "Zeus Facturacion")


    End Sub

    Private Sub CmdResultados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdResultados.Click
        Dim NumeroExpediente As String, Id_TipoExamen As Double, Descripcion As String

        NumeroExpediente = Me.TDGridMedicamentos.Columns("Numero_Expediente").Text
        Id_TipoExamen = Me.TDGridMedicamentos.Columns("IdTipoExamen").Text
        Descripcion = Me.TDGridMedicamentos.Columns("Descripcion").Text

        My.Forms.FrmExamen.Show()
        My.Forms.FrmExamen.BloquearCampos(Descripcion)

        'My.Forms.FrmConsultasMedicas.IdConsultorio = Me.Id_Consultorio
        'My.Forms.FrmConsultasMedicas.IdDoctor = Me.Id_Doctor
        'My.Forms.FrmConsultasMedicas.TxtCodigo.Text = NumeroExpediente
        'My.Forms.FrmConsultasMedicas.TxtHoraAdmision.Text = Me.TrueDBGridConsultas.Columns("Fecha_Hora").Text
        'My.Forms.FrmConsultasMedicas.Cargar_Expediente(NumeroExpediente)
        'My.Forms.FrmConsultasMedicas.ShowDialog()
    End Sub
End Class