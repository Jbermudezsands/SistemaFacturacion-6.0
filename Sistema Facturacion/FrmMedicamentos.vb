Imports System.Data.SqlClient
Public Class FrmMedicamentos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdPreConsultas As Double, HoraInicio As Date, IdConsultorio As Double, IdDoctor As Double
    Public dsMedicamento As New DataSet, daMedicamento As New SqlClient.SqlDataAdapter, CmdBuilderMedicamento As New SqlCommandBuilder
    Public ConsecutivoFacturaManual As Boolean = False
    Public Sub Cargar_Grid_Medicamentos()
        Dim SqlCompras As String

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SqlCompras = "SELECT Expediente.Numero_Expediente, Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombre_Paciente, Consultorio.Nombre_Consultorio, Doctores.Nombre_Doctor + ' ' + Doctores.Apellido_Doctor AS Nombre_Doctor, Medicamentos_Consulta.Cod_Productos, Medicamentos_Consulta.Descripcion, Medicamentos_Consulta.Cantidad, Medicamentos_Consulta.Facturar, Consulta.Activo, Medicamentos_Consulta.IdConsulta FROM Medicamentos_Consulta INNER JOIN Consulta ON Medicamentos_Consulta.IdConsulta = Consulta.IdConsulta INNER JOIN  Doctores ON Consulta.IdDoctor_CodigoMinsa = Doctores.Codigo_Minsa INNER JOIN Consultorio ON Consulta.IdConsultorio = Consultorio.IdConsultorio INNER JOIN " & _
                     "Expediente ON Consulta.Numero_Expediente = Expediente.Numero_Expediente WHERE (Medicamentos_Consulta.Aular = 0) AND (Consulta.Activo = 1) AND (Medicamentos_Consulta.Facturar = 1)"
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
        Me.TDGridMedicamentos.Columns("Cod_Productos").Caption = "Codigo Producto"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 100
        Me.TDGridMedicamentos.Columns("Descripcion").Caption = "Descripcion Producto"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Descripcion").Width = 200
        Me.TDGridMedicamentos.Columns("Cantidad").Caption = "Cantidad"
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Cantidad").Width = 74
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("Activo").Visible = False
        Me.TDGridMedicamentos.Splits.Item(0).DisplayColumns("IdConsulta").Visible = False
    End Sub



    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim ConsecutivoFactura As Double = 0, NumeroFactura As String, iPosicion As Double, Registros As Double, Fecha As Date, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, FechaSalida As Date, Posicion As Double, NumeroRecepcion As String = "", TipoRecepcion As String
        Dim FechaFactura As Date, CodigoCliente As String = "", CodigoBodega As String = "", SubTotal As Double, Pagado As Double = 0, CodProductos As String, NombreProductos As String, PrecioCompra As Double, Cantidad As Double, Importe As Double
        Dim Respuesta As Double, PrecioVenta As Double, IVA As Double, CostoUnitario As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String, IdConsulta As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaImpuesto As Double
        Dim RstCosto As New RstCostoPromedio

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

            RstCosto = CostoPromedioKardex(CodProductos, FechaFactura)
            CostoUnitario = RstCosto.Costo_Cordoba
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


        Cargar_Grid_Medicamentos()

        MsgBox("Se ha Procesado la Factura  No." & NumeroFactura, MsgBoxStyle.Information, "Zeus Facturacion")


    End Sub

    Private Sub FrmMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Grid_Medicamentos()
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String, IdConsulta As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaImpuesto As Double



        IdConsulta = Me.TDGridMedicamentos.Item(Me.TDGridMedicamentos.Row)("IdConsulta")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////ACTUALIZO LOS PRODUCTOS FACTURADOS //////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        StrSqlUpdate = "UPDATE [Medicamentos_Consulta] SET [Facturar] = 0 WHERE  (IdConsulta = " & IdConsulta & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Cargar_Grid_Medicamentos()

    End Sub
End Class