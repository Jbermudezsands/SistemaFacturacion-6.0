Imports System.Data.SqlClient

Public Class FrmPlanillaLiquidacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public dsEgreso As New DataSet, daEgreso As New SqlClient.SqlDataAdapter, CmdBuilderEgreso As New SqlCommandBuilder
    Public Sub InsertarRowGridIngresos()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TDGridIngresos.Row

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleIngresos").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleIngresos").AcceptChanges()
            da.Update(ds.Tables("DetalleIngresos"))

            ActualizarGridInsertRowIngresos()

            Me.TDGridIngresos.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleIngresos").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleIngresos").AcceptChanges()
                da.Update(ds.Tables("DetalleIngresos"))
            End If
        End If

    End Sub
    Public Sub ActualizarGridInsertRowIngresos()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT Codigo, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado,  Domingo, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaLiquidacion WHERE (Detalle_NominaLiquidacion.NumNomina = '" & Me.TxtNumNomina.Text & "') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")
        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Width = 70
        Me.TDGridIngresos.Columns(0).Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Locked = False
        Me.TDGridIngresos.Columns(9).Caption = "Total Litros"
        Me.TDGridIngresos.Columns(10).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns(10).Caption = "PrecioUnit"
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Width = 80
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Locked = True
        Me.TDGridIngresos.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumNomina").Visible = False

    End Sub

    Private Sub TDGridIngresos_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridIngresos.AfterUpdate
        InsertarRowGridIngresos()
    End Sub
    Private Sub TDGridIngresos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridIngresos.AfterColUpdate
        Dim TotalLitros As Double, TotalIngresos As Double, PrecioUnitario As Double, Lunes As Double, Martes As Double, Miercoles As Double, Jueves As Double, Viernes As Double, Sabado As Double, Domingo As Double

        Lunes = Me.TDGridIngresos.Columns("Lunes").Text
        Martes = Me.TDGridIngresos.Columns("Martes").Text
        Miercoles = Me.TDGridIngresos.Columns("Miercoles").Text
        Jueves = Me.TDGridIngresos.Columns("Jueves").Text
        Viernes = Me.TDGridIngresos.Columns("Viernes").Text
        Sabado = Me.TDGridIngresos.Columns("Sabado").Text
        Domingo = Me.TDGridIngresos.Columns("Domingo").Text

        TotalLitros = Lunes + Martes + Miercoles + Jueves + Viernes + Sabado + Domingo

        Me.TDGridIngresos.Columns("Total").Text = TotalLitros

        If IsNumeric(Me.TDGridIngresos.Columns("PrecioVenta").Text) Then
            PrecioUnitario = Me.TDGridIngresos.Columns("PrecioVenta").Text
        Else
            PrecioUnitario = 0
        End If

        TotalIngresos = TotalLitros * PrecioUnitario

        Me.TDGridIngresos.Columns("TotalIngresos").Text = Format(TotalIngresos, "##,##0.00")

        Me.TDGridIngresos.Col = 0

    End Sub

    Private Sub FrmLiquidacionLeche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, SqlConsulta As String = "SELECT Endoso.* FROM Endoso"
        Dim SqlString As String
        Dim NumNomina As String, Año As Double, Mes As Double, Periodo As Double

        If CodigoClienteNumero = True Then
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
        End If

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
            Me.CboCodigoCliente.Text = DataSet.Tables("Clientes").Rows(0)("CodigoCliente")
        End If

        If CodigoClienteNumero = True Then
            Me.CboCodigoCliente.Splits.Item(0).DisplayColumns(2).Visible = False
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"



        SqlString = "SELECT  NominaLiquidacion.* FROM NominaLiquidacion  WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "NominaLiquidacion")
        If DataSet.Tables("NominaLiquidacion").Rows.Count <> 0 Then


            Me.DTPFechaIni.Value = DataSet.Tables("NominaLiquidacion").Rows(0)("FechaInicial")
            Me.DTPFechaFin.Value = DataSet.Tables("NominaLiquidacion").Rows(0)("FechaFinal")
            Me.CmdCalcular.Enabled = True

            NumNomina = DataSet.Tables("NominaLiquidacion").Rows(0)("NumPlanilla")
            Año = DataSet.Tables("NominaLiquidacion").Rows(0)("Año")
            Mes = DataSet.Tables("NominaLiquidacion").Rows(0)("mes")
            Periodo = DataSet.Tables("NominaLiquidacion").Rows(0)("Periodo")

            Me.TxtNumNomina.Text = NumNomina

        Else
            MsgBox("Se necesitan Nominas Activas para Calcular Planilla de Liquidacion", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        SqlString = "SELECT Codigo, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaLiquidacion WHERE (NumNomina = '-100000') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")

        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Width = 70
        Me.TDGridIngresos.Columns(0).Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Locked = False
        Me.TDGridIngresos.Columns(9).Caption = "Total Litros"
        Me.TDGridIngresos.Columns(10).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns(10).Caption = "PrecioUnit"
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Width = 80
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Locked = True
        Me.TDGridIngresos.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumNomina").Visible = False


        SqlString = "SELECT Detalle_NominaLiquidacion.Codigo, Conductor.Nombre As  Nombres, Detalle_NominaLiquidacion.IR, Detalle_NominaLiquidacion.Bolsa, Detalle_NominaLiquidacion.DeduccionPolicia, Detalle_NominaLiquidacion.Anticipo, Detalle_NominaLiquidacion.DeduccionTransporte, Detalle_NominaLiquidacion.Pulperia,Detalle_NominaLiquidacion.Inseminacion, Detalle_NominaLiquidacion.Trazabilidad, Detalle_NominaLiquidacion.ProductosVeterinarios,Detalle_NominaLiquidacion.OtrasDeducciones, Detalle_NominaLiquidacion.IR + Detalle_NominaLiquidacion.Bolsa + Detalle_NominaLiquidacion.DeduccionPolicia + Detalle_NominaLiquidacion.Anticipo + Detalle_NominaLiquidacion.DeduccionTransporte + Detalle_NominaLiquidacion.Pulperia + Detalle_NominaLiquidacion.Inseminacion + Detalle_NominaLiquidacion.ProductosVeterinarios + Detalle_NominaLiquidacion.OtrasDeducciones + Detalle_NominaLiquidacion.Trazabilidad AS TotalEgresos, Detalle_NominaLiquidacion.TotalIngresos - (Detalle_NominaLiquidacion.IR + Detalle_NominaLiquidacion.DeduccionPolicia + Detalle_NominaLiquidacion.Anticipo + Detalle_NominaLiquidacion.DeduccionTransporte + Detalle_NominaLiquidacion.Pulperia + Detalle_NominaLiquidacion.Inseminacion + Detalle_NominaLiquidacion.ProductosVeterinarios + Detalle_NominaLiquidacion.OtrasDeducciones + Detalle_NominaLiquidacion.Trazabilidad) AS NetoPagar FROM  Detalle_NominaLiquidacion INNER JOIN Conductor ON Detalle_NominaLiquidacion.CodigoTransportista = Conductor.Codigo " & _
                     "WHERE (Detalle_NominaLiquidacion.NumNomina = '" & Me.TxtNumNomina.Text & "') ORDER BY Codigo"
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Width = 50
        Me.TDGridDeducciones.Columns(0).Caption = "Codigo"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Width = 180
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Width = 60
        Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 60
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
        Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns(3).Caption = "Policia"
        Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 60
        Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
        Me.TDGridDeducciones.Columns(5).Caption = "Anticipo"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True
        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCalcular.Click
        Dim SqlProductos As String
        Dim SqlString As String, iPosicion As Double, Registros As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProductor As String, Nombres As String, Fecha As Date, Cantidad As Double, CantidadTotal As Double
        Dim MontoLunes As Double, MontoMartes As Double, MontoMiercoles As Double, MontoJueves As Double, MontoViernes As Double, MontoSabado As Double, MontoDomingo As Double
        Dim iPosicion2 As Double = 0, Registros2 As Double = 0, Contador As Double = 1, PrecioUnitario As Double, IngresoBruto, PorcientoIr As Double
        Dim MontoIr As Double, PorcientoPolicia As Double, MontoPolicia As Double, MontoVeterinario As Double, ROC1 As String = 0, ROC2 As String = 0, ROC3 As String = 0, ROC4 As String = 0, ROC5 As String = 0, ROC6 As String = 0, ROC7 As String = 0
        Dim Anticipo As Double, Transporte As Double, Pulperia As Double, Inseminacion As Double, NCompra As String, PrecioLunes As Double, PrecioMartes As Double, PrecioMiercoles As Double, PrecioJueves As Double, PrecioViernes As Double, PrecioSabado As Double, PrecioDomingo As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Trazabilidad As Double, Otros As Double
        Dim CantPlanilla As Double = 0, PLunes As Double, PMartes As Double, PMiercoles As Double, PJueves As Double, PViernes As Double, PSabado As Double, PDomingo As Double
        Dim PorcientoBolsa As Double = 0, MontoBolsa As Double = 0, ProductosVeterinarios As Double = 0, CantLunes As Double = 0, CantMartes As Double = 0, CantMiercoles As Double = 0, CantJueves As Double = 0, CantViernes As Double = 0, CantSabado As Double = 0, CantDomingo As Double = 0
        Dim CodProducto As String




        If Me.CboCodigoCliente.Text = "" Then
            MsgBox("Seleccione un Cliente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Fecha = Me.DTPFechaIni.Value

        PorcientoIr = Val(Me.TxtIR.Text) / 100
        PorcientoBolsa = Val(Me.TxtBolsa.Text) / 100
        PorcientoPolicia = Val(Me.TxtDeduccionPolicia.Text) / 100
        PrecioUnitario = Val(Me.TxtPrecioUnitario.Text)

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////ACTUALIZO LOS ENCABEZADOS DE LA NOMINA//////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [NominaLiquidacion] SET [PorcientoIR] = " & Val(Me.TxtIR.Text) & ",[PorcientoPolicia] =  " & Val(Me.TxtDeduccionPolicia.Text) & ",[PrecioUnitario] = " & Val(Me.TxtPrecioUnitario.Text) & ",[CodigoCliente] = '" & Me.CboCodigoCliente.Text & "',[CodigoBodega] = '" & Me.CboCodigoBodega.Text & "'  " & _
                       "WHERE (NumPlanilla = '" & Me.TxtNumNomina.Text & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '///////////////////////////////////////////////SELECCIONO LOS PROUCTOS 
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto = 'Insumos')"
        DataAdapter.Fill(DataSet, "Productos")
        MiConexion.Close()

        iPosicion = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Registros = DataSet.Tables("Productos").Rows.Count
        Me.ProgressBar.Maximum = Registros
        Do While iPosicion < Registros

            CodProducto = DataSet.Tables("Productos").Rows(iPosicion)("Cod_Productos")


            '//////////////////////////////////////////////CONSULTO SI ESTE PRODUCTOR YA TIENE UNA PLANILLA GRABADA ANTERIOR ////////////////////////////
            SqlString = "SELECT Detalle_NominaLiquidacion.* FROM Detalle_NominaLiquidacion  WHERE  (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Codigo = '" & CodProducto & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                PLunes = DataSet.Tables("Consulta").Rows(0)("Lunes")
                PMartes = DataSet.Tables("Consulta").Rows(0)("Martes")
                PMiercoles = DataSet.Tables("Consulta").Rows(0)("Miercoles")
                PJueves = DataSet.Tables("Consulta").Rows(0)("Jueves")
                PViernes = DataSet.Tables("Consulta").Rows(0)("Viernes")
                PSabado = DataSet.Tables("Consulta").Rows(0)("Sabado")
                PDomingo = DataSet.Tables("Consulta").Rows(0)("Domingo")
                PrecioUnitario = DataSet.Tables("Consulta").Rows(0)("PrecioVenta")

                PrecioLunes = PrecioUnitario
                PrecioMartes = PrecioUnitario
                PrecioMiercoles = PrecioUnitario
                PrecioJueves = PrecioUnitario
                PrecioViernes = PrecioUnitario
                PrecioSabado = PrecioUnitario
                PrecioDomingo = PrecioUnitario

            Else
                PLunes = 0
                PMartes = 0
                PMiercoles = 0
                PJueves = 0
                PViernes = 0
                PSabado = 0
                PDomingo = 0
            End If
            DataSet.Tables("Consulta").Reset()



            Fecha = Me.DTPFechaIni.Value
            Nombres = DataSet.Tables("Productos").Rows(iPosicion)("Descripcion_Producto")
            Me.LblProcesando.Text = "PROCESANDO PRODUCTO: " & CodProducto & " " & Nombres
            CantidadTotal = 0
            Contador = 1

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////RECORRO LA SEMANA PARA ACTUALIZAR ///////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Maximum = 7
            Do While Fecha <= Me.DTPFechaFin.Value



                Contador = Fecha.DayOfWeek
                Cantidad = 0

                Select Case Contador
                    Case 1
                        If PLunes > Cantidad Then
                            Cantidad = PLunes
                        End If
                        CantLunes = Cantidad
                        MontoLunes = Cantidad * PrecioLunes
                    Case 2
                        If PMartes > Cantidad Then
                            Cantidad = PMartes
                        End If
                        CantMartes = Cantidad
                        MontoMartes = Cantidad * PrecioMartes
                    Case 3
                        If PMiercoles > Cantidad Then
                            Cantidad = PMiercoles
                        End If
                        CantMiercoles = Cantidad
                        MontoMiercoles = Cantidad * PrecioMiercoles
                    Case 4
                        If PJueves > Cantidad Then
                            Cantidad = PJueves
                        End If
                        CantJueves = Cantidad
                        MontoJueves = Cantidad * PrecioJueves
                    Case 5
                        If PViernes > Cantidad Then
                            Cantidad = PViernes
                        End If
                        CantViernes = Cantidad
                        MontoViernes = Cantidad * PrecioViernes
                    Case 6
                        If PSabado > Cantidad Then
                            Cantidad = PSabado
                        End If
                        CantSabado = Cantidad
                        MontoSabado = Cantidad * PrecioSabado
                    Case 0
                        If PDomingo > Cantidad Then
                            Cantidad = PDomingo
                        End If
                        CantDomingo = Cantidad
                        MontoDomingo = Cantidad * PrecioDomingo
                End Select


                CantidadTotal = CantidadTotal + Cantidad
                IngresoBruto = MontoLunes + MontoMartes + MontoMiercoles + MontoJueves + MontoViernes + MontoSabado + MontoDomingo
                MontoIr = PorcientoIr * IngresoBruto
                MontoPolicia = PorcientoPolicia * CantidadTotal
                MontoBolsa = PorcientoBolsa * IngresoBruto


                Contador = Contador + 1
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
            Loop



            SqlString = "SELECT  * FROM Detalle_NominaLiquidacion WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Codigo = '" & CodProducto & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleNomina")
            If DataSet.Tables("DetalleNomina").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Detalle_NominaLiquidacion] ([NumNomina],[Codigo],[Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado],[Domingo],[Total],[PrecioVenta],[TotalIngresos],[IR],[DeduccionPolicia],[Anticipo],[DeduccionTransporte],[Pulperia],[Inseminacion],[Trazabilidad],[ProductosVeterinarios],[OtrasDeducciones],[Nombres],[Bolsa],[PrecioLunes],[PrecioMartes],[PrecioMiercoles],[PrecioJueves],[PrecioViernes],[PrecioSabado],[PrecioDomingo]) " & _
                               "VALUES ('" & Me.TxtNumNomina.Text & "','" & CodProducto & "'," & CantLunes & "," & CantMartes & "," & CantMiercoles & "," & CantJueves & "," & CantViernes & "," & CantSabado & "," & CantDomingo & "," & CantidadTotal & " ," & PrecioUnitario & "," & IngresoBruto & "," & MontoIr & "," & MontoPolicia & "," & Anticipo & "," & Transporte & "," & Pulperia & "," & Inseminacion & "," & Trazabilidad & " ," & MontoVeterinario & " ," & Otros & ", '" & Nombres & "', " & MontoBolsa & ", " & PrecioLunes & "," & PrecioMartes & ", " & PrecioMiercoles & ", " & PrecioJueves & ", " & PrecioViernes & ", " & PrecioSabado & ", " & PrecioDomingo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                StrSqlUpdate = "UPDATE [Detalle_NominaLiquidacion] SET [Lunes] = " & CantLunes & ",[Martes] = " & CantMartes & ",[Miercoles] = '" & CantMiercoles & "',[Jueves] = " & CantJueves & ",[Viernes] =" & CantViernes & ", [Sabado] = " & CantSabado & ",[Domingo] = " & CantDomingo & ",[Total] = " & CantidadTotal & ",[PrecioVenta] = " & PrecioUnitario & ",[TotalIngresos] = " & IngresoBruto & ",[IR] = " & MontoIr & ",[DeduccionPolicia] = " & MontoPolicia & ",[Nombres] = '" & Nombres & "', [Bolsa] = '" & MontoBolsa & "' , [PrecioLunes] = '" & PrecioLunes & "',  [PrecioMartes] = '" & PrecioMartes & "',  [PrecioMiercoles] = '" & PrecioMiercoles & "' , [PrecioJueves] = '" & PrecioJueves & "', [PrecioViernes] = '" & PrecioViernes & "', [PrecioSabado] = '" & PrecioSabado & "', [PrecioDomingo] = '" & PrecioDomingo & "'   " & _
                               "WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Codigo = '" & CodProducto & "') "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            DataSet.Tables("DetalleNomina").Clear()

            PLunes = 0
            PMartes = 0
            PMiercoles = 0
            PJueves = 0
            PViernes = 0
            PSabado = 0
            PDomingo = 0

            CantLunes = 0
            CantMartes = 0
            CantMiercoles = 0
            CantJueves = 0
            CantViernes = 0
            CantSabado = 0
            CantDomingo = 0

            Cantidad = 0


            iPosicion = iPosicion + 1
            Me.ProgressBar.Value = iPosicion
        Loop



        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT Codigo, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado,  Domingo, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaLiquidacion WHERE (Detalle_NominaLiquidacion.NumNomina = '" & Me.TxtNumNomina.Text & "') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")
        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Width = 70
        Me.TDGridIngresos.Columns(0).Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Domingo").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Lunes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Martes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Miercoles").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Jueves").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Viernes").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Sabado").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns(9).Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns(10).Locked = False
        Me.TDGridIngresos.Columns(9).Caption = "Total Litros"
        Me.TDGridIngresos.Columns(10).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns(10).Caption = "PrecioUnit"
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Width = 80
        Me.TDGridIngresos.Splits(0).DisplayColumns(11).Locked = True
        Me.TDGridIngresos.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumNomina").Visible = False

        dsEgreso.Tables("DetalleEgresos").Reset()
        SqlString = "SELECT Detalle_NominaLiquidacion.Codigo, Productos.Descripcion_Producto  AS Nombres, Detalle_NominaLiquidacion.IR, Detalle_NominaLiquidacion.Bolsa, Detalle_NominaLiquidacion.DeduccionPolicia, Detalle_NominaLiquidacion.Anticipo, Detalle_NominaLiquidacion.DeduccionTransporte, Detalle_NominaLiquidacion.Pulperia,Detalle_NominaLiquidacion.Inseminacion, Detalle_NominaLiquidacion.Trazabilidad, Detalle_NominaLiquidacion.ProductosVeterinarios,Detalle_NominaLiquidacion.OtrasDeducciones, Detalle_NominaLiquidacion.IR + Detalle_NominaLiquidacion.Bolsa + Detalle_NominaLiquidacion.DeduccionPolicia + Detalle_NominaLiquidacion.Anticipo + Detalle_NominaLiquidacion.DeduccionTransporte + Detalle_NominaLiquidacion.Pulperia + Detalle_NominaLiquidacion.Inseminacion + Detalle_NominaLiquidacion.ProductosVeterinarios + Detalle_NominaLiquidacion.OtrasDeducciones + Detalle_NominaLiquidacion.Trazabilidad AS TotalEgresos, Detalle_NominaLiquidacion.TotalIngresos - (Detalle_NominaLiquidacion.IR + Detalle_NominaLiquidacion.Bolsa + Detalle_NominaLiquidacion.DeduccionPolicia + Detalle_NominaLiquidacion.Anticipo + Detalle_NominaLiquidacion.DeduccionTransporte + Detalle_NominaLiquidacion.Pulperia + Detalle_NominaLiquidacion.Inseminacion + Detalle_NominaLiquidacion.ProductosVeterinarios + Detalle_NominaLiquidacion.OtrasDeducciones + Detalle_NominaLiquidacion.Trazabilidad) AS NetoPagar FROM  Detalle_NominaLiquidacion INNER JOIN Productos ON Detalle_NominaLiquidacion.Codigo = Productos.Cod_Productos  " & _
                    "WHERE (Detalle_NominaLiquidacion.NumNomina = '" & Me.TxtNumNomina.Text & "') "
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Width = 50
        Me.TDGridDeducciones.Columns(0).Caption = "Codigo"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Width = 160
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Width = 60
        Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
        Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 60
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Visible = True
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Width = 60
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
        Me.TDGridDeducciones.Columns("DeduccionPolicia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("DeduccionPolicia").Caption = "Policia"
        Me.TDGridDeducciones.Columns("Anticipo").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipo").Width = 60
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 60
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 60
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Veterinario"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 60
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 60
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True



        Me.CmdNomina.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdCerrar.Enabled = True


    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
End Class