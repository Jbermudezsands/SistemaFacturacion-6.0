Imports System.Data.SqlClient

Public Class frmPlanillaConductores

    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, dsEgreso As New DataSet, daEgreso As New SqlClient.SqlDataAdapter, CmdBuilderEgreso As New SqlCommandBuilder



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
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Detalle_NominaTransportista.Nombre As Nombres, Detalle_NominaTransportista.Domingo, Detalle_NominaTransportista.Lunes,Detalle_NominaTransportista.Martes, Detalle_NominaTransportista.Miercoles, Detalle_NominaTransportista.Jueves, Detalle_NominaTransportista.Viernes, Detalle_NominaTransportista.Sabado, Detalle_NominaTransportista.Total, Detalle_NominaTransportista.PrecioVenta, Detalle_NominaTransportista.TotalIngresos FROM Detalle_NominaTransportista INNER JOIN Productor ON Detalle_NominaTransportista.CodProductor = Productor.CodProductor AND Detalle_NominaTransportista.TipoProductor = Productor.TipoProductor WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")

        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleIngresos")
        'Me.TDGridIngresos.DataSource = DataSet.Tables("DetalleIngresos")
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

    End Sub
    Public Sub InsertarRowGridEgresos(ByVal CodigoTransportista As String)
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim IR As Double, Bolsa As Double, DeduccionPolicia As Double, Anticipo As Double, DeduccionTransporte As Double, Pulperia As Double, Inseminacion As Double, Trazabilidad As Double
        Dim ProductosVeterinarios As Double, OtrasDeducciones As Double



        iPosicion = Me.TDGridDeducciones.Row

        IR = Me.TDGridDeducciones.Columns("IR").Text
        Bolsa = Me.TDGridDeducciones.Columns("Bolsa").Text
        DeduccionPolicia = Me.TDGridDeducciones.Columns("DeduccionPolicia").Text
        Anticipo = Me.TDGridDeducciones.Columns("Anticipo").Text
        DeduccionTransporte = Me.TDGridDeducciones.Columns("DeduccionTransporte").Text
        Pulperia = Me.TDGridDeducciones.Columns("Pulperia").Text
        Inseminacion = Me.TDGridDeducciones.Columns("Inseminacion").Text

        Trazabilidad = Me.TDGridDeducciones.Columns("Trazabilidad").Text
        ProductosVeterinarios = Me.TDGridDeducciones.Columns("ProductosVeterinarios").Text
        OtrasDeducciones = Me.TDGridDeducciones.Columns("OtrasDeducciones").Text

        'CmdBuilderEgreso.RefreshSchema()
        'oTabla = dsEgreso.Tables("DetalleEgresos").GetChanges(DataRowState.Added)
        'If Not IsNothing(oTabla) Then
        '    '//////////////////SI  TIENE REGISTROS NUEVOS 
        '    daEgreso.Update(oTabla)
        '    dsEgreso.Tables("DetalleEgresos").AcceptChanges()
        '    daEgreso.Update(ds.Tables("DetalleEgresos"))

        '    ActualizarGridInsertRowEgresos()

        '    Me.TDGridDeducciones.Row = iPosicion

        'Else
        '    oTabla = dsEgreso.Tables("DetalleEgresos").GetChanges(DataRowState.Modified)
        '    If Not IsNothing(oTabla) Then
        '        daEgreso.Update(oTabla)
        '        dsEgreso.Tables("DetalleEgresos").AcceptChanges()
        '        daEgreso.Update(ds.Tables("DetalleEgresos"))
        '    End If
        'End If


        StrSqlUpdate = "UPDATE [Detalle_NominaTransportista] SET [IR] = " & IR & ",[DeduccionPolicia] = " & DeduccionPolicia & ",[Anticipo] = " & Anticipo & ",[DeduccionTransporte] = " & DeduccionTransporte & " ,[Pulperia] = " & Pulperia & ",[Inseminacion] = " & Inseminacion & ",[ProductosVeterinarios] = " & ProductosVeterinarios & " ,[Trazabilidad] = " & Trazabilidad & ",[OtrasDeducciones] = " & OtrasDeducciones & " , [Bolsa] = '" & Bolsa & "'   " & _
                       "WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodigoTransportista = '" & CodigoTransportista & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()



    End Sub
    Public Sub ActualizarGridInsertRowEgresos()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        dsEgreso.Tables("DetalleEgresos").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        dsEgreso.Tables("DetalleEgresos").Reset()
        SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre  AS Nombres, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo  " & _
                    "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
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
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipo").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Veterinario"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True

    End Sub



    Private Sub frmPlanillaConductores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, NumNomina As String, Año As Double, Mes As Double, Periodo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT  NominaTransportista.* FROM NominaTransportista  WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        Me.CboTipoPlanilla.DataSource = DataSet.Tables("TipoNomina")
        If DataSet.Tables("TipoNomina").Rows.Count <> 0 Then


            Me.DTPFechaIni.Value = DataSet.Tables("TipoNomina").Rows(0)("FechaInicial")
            Me.DTPFechaFin.Value = DataSet.Tables("TipoNomina").Rows(0)("FechaFinal")
            Me.CmdCalcular.Enabled = True

            NumNomina = DataSet.Tables("TipoNomina").Rows(0)("NumPlanilla")
            Año = DataSet.Tables("TipoNomina").Rows(0)("Año")
            Mes = DataSet.Tables("TipoNomina").Rows(0)("mes")
            Periodo = DataSet.Tables("TipoNomina").Rows(0)("Periodo")

            Me.TxtNumNomina.Text = NumNomina

        Else
            MsgBox("Se necesitan Nominas Activas para Calcular Planilla de Conductores", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        SqlString = "SELECT CodigoTransportista, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaTransportista WHERE (NumNomina = '-100000') "
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


        SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre As  Nombres, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo " & _
            "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') ORDER BY CodigoTransportista"
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
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
        Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
        Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns(3).Caption = "Policia"
        Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
        Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
        Me.TDGridDeducciones.Columns(5).Caption = "Anticipo"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True

    End Sub

    Private Sub CmdCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCalcular.Click
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


        'If Me.CboTipoPlanilla.Text = "" Then
        '    MsgBox("Seleccione la Nomina, para Calcular", MsgBoxStyle.Critical, "Zeus Acopio")
        '    Exit Sub
        'End If

        Fecha = Me.DTPFechaIni.Value
        If Me.TxtPrecioLunes.Text = "" Then
            PrecioUnitario = 0
        Else
            PrecioUnitario = Me.TxtPrecioLunes.Text
        End If

        PorcientoIr = Val(Me.TxtIR.Text) / 100
        PorcientoBolsa = Val(Me.TxtBolsa.Text) / 100
        PorcientoPolicia = Val(Me.TxtDeduccionPolicia.Text) / 100

        If Me.TxtPrecioLunes.Text = "" Then
            Me.TxtPrecioLunes.Text = 0
        End If

        If Me.TxtPrecioMartes.Text = "" Then
            Me.TxtPrecioMartes.Text = 0
        End If

        If Me.TxtPrecioMiercoles.Text = "" Then
            Me.TxtPrecioMiercoles.Text = 0
        End If

        If Me.TxtPrecioJueves.Text = "" Then
            Me.TxtPrecioJueves.Text = 0
        End If

        If Me.TxtPrecioViernes.Text = "" Then
            Me.TxtPrecioViernes.Text = 0
        End If

        If Me.TxtPrecioSabado.Text = "" Then
            Me.TxtPrecioSabado.Text = 0
        End If

        If Me.TxtPrecioDomingo.Text = "" Then
            Me.TxtPrecioDomingo.Text = 0
        End If

        PrecioLunes = Me.TxtPrecioLunes.Text
        PrecioMartes = Me.TxtPrecioMartes.Text
        PrecioMiercoles = Me.TxtPrecioMiercoles.Text
        PrecioJueves = Me.TxtPrecioJueves.Text
        PrecioViernes = Me.TxtPrecioViernes.Text
        PrecioSabado = Me.TxtPrecioSabado.Text
        PrecioDomingo = Me.TxtPrecioDomingo.Text


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////ACTUALIZO LOS ENCABEZADOS DE LA NOMINA//////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [NominaTransportista] SET [PorcientoIR] = " & Val(Me.TxtIR.Text) & ",[PorcientoPolicia] =  " & Val(Me.TxtDeduccionPolicia.Text) & ",[PrecioUnitario] = " & Val(Me.TxtPrecioLunes.Text) & ", [PrecioLunes] = " & Val(Me.TxtPrecioLunes.Text) & ", [PrecioMartes] = " & Val(Me.TxtPrecioMartes.Text) & ", [PrecioMiercoles] = " & Val(Me.TxtPrecioMiercoles.Text) & ", [PrecioJueves] = " & Val(Me.TxtPrecioJueves.Text) & ", [PrecioViernes] = " & Val(Me.TxtPrecioViernes.Text) & ", [PrecioSabado] = " & Val(Me.TxtPrecioSabado.Text) & ", [PrecioDomingo] = " & Val(Me.TxtPrecioDomingo.Text) & " " & _
                       "WHERE (NumPlanilla = '" & Me.TxtNumNomina.Text & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '/////////////////////////////////////////CARGO LOS CONDUCTORES ACTIVOS/////////////////////////////////////////

        SqlString = "SELECT  Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra, Cuenta_Contable, Precio  FROM Conductor WHERE (Activo = 1) AND (ListaNegra = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        MiConexion.Close()

        iPosicion = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Registros = DataSet.Tables("Conductor").Rows.Count
        Me.ProgressBar.Maximum = Registros
        Do While iPosicion < Registros
            My.Application.DoEvents()
            CodProductor = DataSet.Tables("Conductor").Rows(iPosicion)("Codigo")


            MontoLunes = 0
            MontoMartes = 0
            MontoMiercoles = 0
            MontoJueves = 0
            MontoViernes = 0
            MontoSabado = 0
            MontoDomingo = 0


            If Not IsDBNull(DataSet.Tables("Conductor").Rows(iPosicion)("Precio")) Then
                PrecioUnitario = DataSet.Tables("Conductor").Rows(iPosicion)("Precio")
                PrecioLunes = PrecioUnitario
                PrecioMartes = PrecioUnitario
                PrecioMiercoles = PrecioUnitario
                PrecioJueves = PrecioUnitario
                PrecioViernes = PrecioUnitario
                PrecioSabado = PrecioUnitario
                PrecioDomingo = PrecioUnitario
            End If

            '//////////////////////////////////////////////CONSULTO SI ESTE PRODUCTOR YA TIENE UNA PLANILLA GRABADA ANTERIOR ////////////////////////////
            SqlString = "SELECT Detalle_NominaTransportista.* FROM Detalle_NominaTransportista  WHERE  (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodigoTransportista = '" & CodProductor & "') "
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

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioLunes")) Then
                '    PrecioLunes = DataSet.Tables("Consulta").Rows(0)("PrecioLunes")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioMartes")) Then
                '    PrecioMartes = DataSet.Tables("Consulta").Rows(0)("PrecioMartes")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioMiercoles")) Then
                '    PrecioMiercoles = DataSet.Tables("Consulta").Rows(0)("PrecioMiercoles")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioJueves")) Then
                '    PrecioJueves = DataSet.Tables("Consulta").Rows(0)("PrecioJueves")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioViernes")) Then
                '    PrecioViernes = DataSet.Tables("Consulta").Rows(0)("PrecioViernes")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioSabado")) Then
                '    PrecioSabado = DataSet.Tables("Consulta").Rows(0)("PrecioSabado")
                'End If

                'If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PrecioDomingo")) Then
                '    PrecioDomingo = DataSet.Tables("Consulta").Rows(0)("PrecioDomingo")
                'End If

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


            '////////////////////////////////////////////CAMBIO EL PRECIO SI EL USUARIO DIGITA PRECIO PARA UN DIA /////////////////////////////
            '////////////////////////////////////////////SI EL PRECIO ES CERO NO CAMBIO NADA /////////////////////////////////////////////////

            If Val(Me.TxtPrecioLunes.Text) <> 0 Then
                PrecioLunes = Me.TxtPrecioLunes.Text
            End If

            If Val(Me.TxtPrecioMartes.Text) <> 0 Then
                PrecioMartes = Me.TxtPrecioMartes.Text
            End If

            If Val(Me.TxtPrecioMiercoles.Text) <> 0 Then
                PrecioMiercoles = Me.TxtPrecioMiercoles.Text
            End If

            If Val(Me.TxtPrecioJueves.Text) <> 0 Then
                PrecioJueves = Me.TxtPrecioJueves.Text
            End If

            If Val(Me.TxtPrecioViernes.Text) <> 0 Then
                PrecioViernes = Me.TxtPrecioViernes.Text
            End If

            If Val(Me.TxtPrecioSabado.Text) <> 0 Then
                PrecioSabado = Me.TxtPrecioSabado.Text
            End If

            If Val(Me.TxtPrecioDomingo.Text) <> 0 Then
                PrecioDomingo = Me.TxtPrecioDomingo.Text
            End If



            Fecha = Me.DTPFechaIni.Value
            Nombres = DataSet.Tables("Conductor").Rows(iPosicion)("Nombre")
            Me.LblProcesando.Text = "PROCESANDO PRODUCTOR: " & CodProductor & " " & Nombres
            CantidadTotal = 0
            Contador = 1


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

                If CodProductor = "0101" Then
                    CodProductor = "0101"
                End If

                CantidadTotal = CantidadTotal + Cantidad
                IngresoBruto = MontoLunes + MontoMartes + MontoMiercoles + MontoJueves + MontoViernes + MontoSabado + MontoDomingo
                MontoIr = PorcientoIr * IngresoBruto
                MontoPolicia = PorcientoPolicia * CantidadTotal
                MontoBolsa = PorcientoBolsa * IngresoBruto


                Contador = Contador + 1
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
            Loop


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////BUSCO LAS DEDUCCIONES/////////////////////////////////////////////////
            '////////////////////////////////////////////////777777777777777777777777777777777777777777777777777777777777777777777
            'Anticipo = 0
            'Transporte = 0
            'Pulperia = 0
            'Inseminacion = 0
            'Trazabilidad = 0
            'Otros = 0
            'MontoVeterinario = 0
            'SqlString = "SELECT  * FROM Detalle_NominaTransportista WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodigoTransportista = '" & CodProductor & "') "
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "DeduccionPlanilla")
            'If DataSet.Tables("DeduccionPlanilla").Rows.Count <> 0 Then
            '    Anticipo = DataSet.Tables("DeduccionPlanilla").Rows(0)("Anticipo")
            '    Transporte = DataSet.Tables("DeduccionPlanilla").Rows(0)("Transporte")
            '    Pulperia = DataSet.Tables("DeduccionPlanilla").Rows(0)("Pulperia")
            '    Inseminacion = DataSet.Tables("DeduccionPlanilla").Rows(0)("Inseminacion")
            '    Trazabilidad = DataSet.Tables("DeduccionPlanilla").Rows(0)("Trazabilidad")
            '    If Not IsDBNull(DataSet.Tables("DeduccionPlanilla").Rows(0)("ProductosVeterinarios")) Then
            '        MontoVeterinario = DataSet.Tables("DeduccionPlanilla").Rows(0)("ProductosVeterinarios")
            '    End If
            '    Otros = DataSet.Tables("DeduccionPlanilla").Rows(0)("OtrasDeducciones")

            'End If



            SqlString = "SELECT  * FROM Detalle_NominaTransportista WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodigoTransportista = '" & CodProductor & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleNomina")
            If DataSet.Tables("DetalleNomina").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Detalle_NominaTransportista] ([NumNomina],[CodigoTransportista],[Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado],[Domingo],[Total],[PrecioVenta],[TotalIngresos],[IR],[DeduccionPolicia],[Anticipo],[DeduccionTransporte],[Pulperia],[Inseminacion],[Trazabilidad],[ProductosVeterinarios],[OtrasDeducciones],[Nombres],[Bolsa],[PrecioLunes],[PrecioMartes],[PrecioMiercoles],[PrecioJueves],[PrecioViernes],[PrecioSabado],[PrecioDomingo]) " & _
                               "VALUES ('" & Me.TxtNumNomina.Text & "','" & CodProductor & "'," & CantLunes & "," & CantMartes & "," & CantMiercoles & "," & CantJueves & "," & CantViernes & "," & CantSabado & "," & CantDomingo & "," & CantidadTotal & " ," & PrecioUnitario & "," & IngresoBruto & "," & MontoIr & "," & MontoPolicia & "," & Anticipo & "," & Transporte & "," & Pulperia & "," & Inseminacion & "," & Trazabilidad & " ," & MontoVeterinario & " ," & Otros & ", '" & Nombres & "', " & MontoBolsa & ", " & PrecioLunes & "," & PrecioMartes & ", " & PrecioMiercoles & ", " & PrecioJueves & ", " & PrecioViernes & ", " & PrecioSabado & ", " & PrecioDomingo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                StrSqlUpdate = "UPDATE [Detalle_NominaTransportista] SET [Lunes] = " & CantLunes & ",[Martes] = " & CantMartes & ",[Miercoles] = '" & CantMiercoles & "',[Jueves] = " & CantJueves & ",[Viernes] =" & CantViernes & ", [Sabado] = " & CantSabado & ",[Domingo] = " & CantDomingo & ",[Total] = " & CantidadTotal & ",[PrecioVenta] = " & PrecioUnitario & ",[TotalIngresos] = " & IngresoBruto & ",[IR] = " & MontoIr & ",[DeduccionPolicia] = " & MontoPolicia & ",[Nombres] = '" & Nombres & "', [Bolsa] = '" & MontoBolsa & "' , [PrecioLunes] = '" & PrecioLunes & "',  [PrecioMartes] = '" & PrecioMartes & "',  [PrecioMiercoles] = '" & PrecioMiercoles & "' , [PrecioJueves] = '" & PrecioJueves & "', [PrecioViernes] = '" & PrecioViernes & "', [PrecioSabado] = '" & PrecioSabado & "', [PrecioDomingo] = '" & PrecioDomingo & "'   " & _
                               "WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodigoTransportista = '" & CodProductor & "') "
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

        'Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres
        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT CodigoTransportista, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado,  Domingo, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaTransportista WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
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
        SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre  AS Nombres, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo  " & _
                    "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
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
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipo").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Veterinario"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True



        Me.CmdNomina.Enabled = True
        'Me.CmdColillas.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdCerrar.Enabled = True

    End Sub

    Private Sub CboTipoPlanilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoPlanilla.TextChanged
        Dim SqlString As String, CodTipoNomina As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumNomina As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Año As Double, Mes As Double, Periodo As Double

        CodTipoNomina = Me.CboTipoPlanilla.Text

        SqlString = "SELECT TipoNomina.CodTipoNomina, TipoNomina.TipoNomina, Periodos.Actual, Periodos.Periodo, Periodos.Inicio, Periodos.Final FROM  TipoNomina INNER JOIN Periodos ON TipoNomina.CodTipoNomina = Periodos.TipoNomina  WHERE(Periodos.Actual = 1) And (TipoNomina.CodTipoNomina='" & CodTipoNomina & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If DataSet.Tables("TipoNomina").Rows.Count <> 0 Then
            Me.DTPFechaIni.Value = DataSet.Tables("TipoNomina").Rows(0)("Inicio")
            Me.DTPFechaFin.Value = DataSet.Tables("TipoNomina").Rows(0)("Final")
            Me.CmdCalcular.Enabled = True

            SqlString = "SELECT * FROM Periodos WHERE (Inicio = CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102)) AND (Actual = 1) AND (TipoNomina = '" & CodTipoNomina & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "PeriodoNomina")
            If DataSet.Tables("PeriodoNomina").Rows.Count <> 0 Then
                NumNomina = DataSet.Tables("PeriodoNomina").Rows(0)("NumNomina")
                Año = DataSet.Tables("PeriodoNomina").Rows(0)("año")
                Mes = DataSet.Tables("PeriodoNomina").Rows(0)("mes")
                Periodo = DataSet.Tables("PeriodoNomina").Rows(0)("Periodo")

                Me.TxtNumNomina.Text = NumNomina





                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////AGREGO LA NOMINA///////////////////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT * FROM NominaTransportista WHERE (NumPlanilla = '" & NumNomina & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Nomina")
                If DataSet.Tables("Nomina").Rows.Count = 0 Then
                    StrSqlUpdate = "INSERT INTO [NominaTransportista] ([NumPlanilla],[CodTipoNomina],[FechaInicial],[FechaFinal],[Año],[mes],[Periodo]) " & _
                                   "VALUES( '" & NumNomina & "', '" & CodTipoNomina & "','" & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "','" & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy") & "'," & Año & " ," & Mes & "," & Periodo & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If


                SqlString = "SELECT * FROM NominaTransportista WHERE (NumPlanilla = '" & NumNomina & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Nomina")
                If DataSet.Tables("Nomina").Rows.Count <> 0 Then

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioLunes")) Then
                        Me.TxtPrecioLunes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioLunes")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioMartes")) Then
                        Me.TxtPrecioMartes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioMartes")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioMiercoles")) Then
                        Me.TxtPrecioMiercoles.Text = DataSet.Tables("Nomina").Rows(0)("PrecioMiercoles")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioJueves")) Then
                        Me.TxtPrecioJueves.Text = DataSet.Tables("Nomina").Rows(0)("PrecioJueves")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioViernes")) Then
                        Me.TxtPrecioViernes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioViernes")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioSabado")) Then
                        Me.TxtPrecioSabado.Text = DataSet.Tables("Nomina").Rows(0)("PrecioSabado")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PrecioDomingo")) Then
                        Me.TxtPrecioDomingo.Text = DataSet.Tables("Nomina").Rows(0)("PrecioDomingo")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PorcientoIR")) Then
                        Me.TxtIR.Text = DataSet.Tables("Nomina").Rows(0)("PorcientoIR")
                    End If

                    If Not IsDBNull(DataSet.Tables("Nomina").Rows(0)("PorcientoPolicia")) Then
                        Me.TxtDeduccionPolicia.Text = DataSet.Tables("Nomina").Rows(0)("PorcientoPolicia")
                    End If

                End If


                ds.Tables("DetalleIngresos").Reset()
                SqlString = "SELECT CodigoTransportista, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaTransportista WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
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
                Me.TDGridIngresos.Splits(0).DisplayColumns(10).Locked = True
                Me.TDGridIngresos.Columns(9).Caption = "Total Litros"
                Me.TDGridIngresos.Columns(10).NumberFormat = "##,##0.00"
                Me.TDGridIngresos.Columns(10).Caption = "PrecioUnit"
                Me.TDGridIngresos.Splits(0).DisplayColumns(11).Width = 80
                Me.TDGridIngresos.Splits(0).DisplayColumns(11).Locked = True
                Me.TDGridIngresos.Columns(11).NumberFormat = "##,##0.00"
                Me.TDGridIngresos.Splits(0).DisplayColumns("NumNomina").Visible = False



                SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre As  Nombres, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo " & _
                            "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') ORDER BY CodigoTransportista"
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
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
                Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 60
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
                Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
                Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Columns(3).Caption = "Policia"
                Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 60
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
                Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
                Me.TDGridDeducciones.Columns(5).Caption = "Anticipo"
                Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
                Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
                Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
                Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
                Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
                Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
                Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
                Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
                Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
                Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
                Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
                Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

                Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
                'Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True

                Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
                Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True

                'Me.TDGridDeducciones.Columns(10).NumberFormat = "##,##0.00"
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Width = 80
                'Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Locked = True

            Else
                MsgBox("No Existe nomina asignada al periodo Seleccionado", MsgBoxStyle.Critical, "Zeus Acopio")
                Exit Sub
                NumNomina = -1
            End If






        Else
            Me.CmdCalcular.Enabled = False
        End If
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

    Private Sub TDGridIngresos_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridIngresos.AfterUpdate
        InsertarRowGridIngresos()
    End Sub

    Private Sub TDGridIngresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridIngresos.Click

    End Sub

    Private Sub TDGridDeducciones_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridDeducciones.AfterColUpdate
        Dim TotalLitros As Double, TotalGastos As Double, PrecioUnitario As Double
        Dim IR As Double, Bolsa As Double, DeduccionPolicia As Double, Anticipo As Double, DeduccionTransporte As Double, Pulperia As Double, Inseminacion As Double, Trazabilidad As Double
        Dim ProductosVeterinarios As Double, OtrasDeducciones As Double
        Dim iPosicion As Double = 0, TotalIngresos As Double = 0

        iPosicion = Me.TDGridDeducciones.Row
        TotalIngresos = Me.TDGridIngresos.Item(iPosicion)("TotalIngresos")

        IR = Me.TDGridDeducciones.Columns("IR").Text
        Bolsa = Me.TDGridDeducciones.Columns("Bolsa").Text
        DeduccionPolicia = Me.TDGridDeducciones.Columns("DeduccionPolicia").Text
        Anticipo = Me.TDGridDeducciones.Columns("Anticipo").Text
        DeduccionTransporte = Me.TDGridDeducciones.Columns("DeduccionTransporte").Text
        Pulperia = Me.TDGridDeducciones.Columns("Pulperia").Text
        Inseminacion = Me.TDGridDeducciones.Columns("Inseminacion").Text

        Trazabilidad = Me.TDGridDeducciones.Columns("Trazabilidad").Text
        ProductosVeterinarios = Me.TDGridDeducciones.Columns("ProductosVeterinarios").Text
        OtrasDeducciones = Me.TDGridDeducciones.Columns("OtrasDeducciones").Text

        TotalGastos = IR + Bolsa + DeduccionPolicia + Anticipo + DeduccionTransporte + Pulperia + Inseminacion + Trazabilidad + ProductosVeterinarios + OtrasDeducciones

        'Me.TDGridDeducciones.Columns("Total").Text = TotalLitros

        'If IsNumeric(Me.TDGridDeducciones.Columns("PrecioVenta").Text) Then
        '    PrecioUnitario = Me.TDGridDeducciones.Columns("PrecioVenta").Text
        'Else
        '    PrecioUnitario = 0
        'End If
        Me.TDGridDeducciones.Columns("NetoPagar").Text = Format(TotalIngresos - TotalGastos, "##,##0.00")

        Me.TDGridDeducciones.Columns("TotalEgresos").Text = Format(TotalGastos, "##,##0.00")

        Me.TDGridIngresos.Col = 0
    End Sub

    Private Sub TDGridDeducciones_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridDeducciones.AfterUpdate

    End Sub


    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub TDGridDeducciones_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDGridDeducciones.BeforeUpdate
        InsertarRowGridEgresos(Me.TDGridDeducciones.Columns("CodigoTransportista").Text)
    End Sub

    Private Sub TDGridDeducciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridDeducciones.Click

    End Sub

    Private Sub CmdNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNomina.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepPlanilla As New ArepPlanilla, SqlDatos As String
        Dim RutaLogo As String, SqlDetalle As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepPlanilla.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepPlanilla.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepPlanilla.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepPlanilla.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If


        ArepPlanilla.LblOrden.Text = Me.TxtNumNomina.Text
        ArepPlanilla.LblFechaOrden.Text = Me.DTPFechaFin.Value
        ArepPlanilla.Label22.Text = "PLANILLA DE PAGO DE TRANSPORTISTAS"
        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT Detalle_NominaTransportista.NumNomina,Detalle_NominaTransportista.CodigoTransportista As CodProductor, Conductor.Nombre  AS Nombres, Detalle_NominaTransportista.Lunes,Detalle_NominaTransportista.Martes, Detalle_NominaTransportista.Miercoles, Detalle_NominaTransportista.Jueves, Detalle_NominaTransportista.Viernes, Detalle_NominaTransportista.Sabado,Detalle_NominaTransportista.Domingo, Detalle_NominaTransportista.Total, Detalle_NominaTransportista.PrecioVenta, Detalle_NominaTransportista.TotalIngresos, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.Trazabilidad + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios AS TotalEgresos,Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Trazabilidad + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo " & _
                     "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "')"
        'SqlDetalle = "SELECT Detalle_NominaTransportista.NumNomina, Detalle_NominaTransportista.CodigoTransportista, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_NominaTransportista.Lunes, Detalle_NominaTransportista.Martes, Detalle_NominaTransportista.Miercoles, Detalle_NominaTransportista.Jueves, Detalle_NominaTransportista.Viernes, Detalle_NominaTransportista.Sabado, Detalle_NominaTransportista.Domingo, Detalle_NominaTransportista.Lunes * Detalle_NominaTransportista.PrecioVenta AS MontoLunes, Detalle_NominaTransportista.Martes * Detalle_NominaTransportista.PrecioVenta AS MontoMartes, Detalle_NominaTransportista.Miercoles * Detalle_NominaTransportista.PrecioVenta AS MontoMiercoles, Detalle_NominaTransportista.Jueves * Detalle_NominaTransportista.PrecioVenta AS MontoJueves, Detalle_NominaTransportista.Viernes * Detalle_NominaTransportista.PrecioVenta AS MontoViernes, Detalle_NominaTransportista.Sabado * Detalle_NominaTransportista.PrecioVenta AS MontoSabado, Detalle_NominaTransportista.Domingo * Detalle_NominaTransportista.PrecioVenta AS MontoDomingo, Detalle_NominaTransportista.Total, Detalle_NominaTransportista.PrecioVenta, Detalle_NominaTransportista.TotalIngresos, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia, Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.ProductosVeterinarios, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios) AS NetoPagar, Ruta_Distribucion.Nombre_Ruta, Ruta_Distribucion.CodRuta  FROM Detalle_NominaTransportista INNER JOIN Productor ON Detalle_NominaTransportista.CodigoTransportista = Productor.CodigoTransportista AND Detalle_NominaTransportista.TipoProductor = Productor.TipoProductor INNER JOIN Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
        '             "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_NominaTransportista.TipoProductor = 'Productor') ORDER BY Ruta_Distribucion.CodRuta"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepPlanilla.DataSource = SQL
        ArepPlanilla.Document.Name = "Reporte de Planilla"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepPlanilla.Document
        ViewerForm.Show()
        ArepPlanilla.Run(False)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepColilla As New ArepColillas, SqlDatos As String
        Dim SqlDetalle As String, SqlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim i As Double = 0, CodRuta As String



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepColilla.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")


            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
            '    ArepColilla.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            'End If
            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
            '    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            '    If Dir(RutaLogo) <> "" Then
            '        ArepPlanilla.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
            '    End If

            'End If
        End If

        ArepColilla.LblPeriodo.Text = "Desde     " & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "    Hasta     " & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")


        'SqlString = "SELECT DISTINCT Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM  Ruta_Distribucion INNER JOIN Productor ON Ruta_Distribucion.CodRuta = Productor.CodRuta"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Ruta")
        'i = 0
        'Do While DataSet.Tables("Ruta").Rows.Count > i

        'CodRuta = DataSet.Tables("Ruta").Rows(i)("CodRuta")

        'MsgBox("SE IMPRIME LAS COLILLAS DE " & DataSet.Tables("Ruta").Rows(i)("Nombre_Ruta"))


        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT  Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre AS Nombres, Detalle_NominaTransportista.Lunes,Detalle_NominaTransportista.Martes, Detalle_NominaTransportista.Miercoles, Detalle_NominaTransportista.Jueves, Detalle_NominaTransportista.Viernes, Detalle_NominaTransportista.Sabado,Detalle_NominaTransportista.Domingo, Detalle_NominaTransportista.Total, Detalle_NominaTransportista.PrecioVenta, Detalle_NominaTransportista.TotalIngresos,  Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.IR,Detalle_NominaTransportista.Bolsa,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.IR +  Detalle_NominaTransportista.Trazabilidad + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios AS TotalEgresos,Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR +  Detalle_NominaTransportista.Trazabilidad + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios) AS NetoPagar, NominaTransportista.NumPlanilla,NominaTransportista.FechaInicial, NominaTransportista.FechaFinal ,  Detalle_NominaTransportista.PrecioLunes, Detalle_NominaTransportista.PrecioMartes, Detalle_NominaTransportista.PrecioMiercoles, Detalle_NominaTransportista.PrecioJueves, Detalle_NominaTransportista.PrecioViernes, Detalle_NominaTransportista.PrecioSabado, Detalle_NominaTransportista.PrecioDomingo FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo INNER JOIN NominaTransportista ON Detalle_NominaTransportista.NumNomina = NominaTransportista.NumPlanilla " & _
                     "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') "
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepColilla.DataSource = SQL
        ArepColilla.Document.Name = "PLANILLA TRANSPORTISTA"
        ArepColilla.Label37.Text = ""
        ArepColilla.TextBox31.Text = "COLILLA PAGO DE TRANSPORTISTA"
        ArepColilla.TextBox31.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepColilla.Document
        ArepColilla.Run(True)
        ViewerForm.ShowDialog()

        'i = i + 1
        'Loop
    End Sub


    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Dim Respuesta As Integer, FechaInicio As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String
        Dim CantPlanilla As Double = 0, PLunes As Double, PMartes As Double, PMiercoles As Double, PJueves As Double, PViernes As Double, PSabado As Double, PDomingo As Double
        Dim iPosicion As Double, Registros As Double, CodProductor As String, Fecha As Date, Nombres As String, CantidadTotal As Double, Contador As Double
        Dim iPosicion2 As Double, Cantidad As Double, NCompra As Double, Registros2 As Double
        Dim Monto As Double, CodTipoNomina As String
        Dim ROC1 As String = 0, ROC2 As String = 0, ROC3 As String = 0, ROC4 As String = 0, ROC5 As String = 0, ROC6 As String = 0, ROC7 As String = 0
        Dim NumeroCompra As String, ConsecutivoCompra As Double, PrecioVenta As Double
        Respuesta = MsgBox("Desea Cerrar la Nomina", MsgBoxStyle.YesNo, "Zeus Acopio")
        If Respuesta = 7 Then
            Exit Sub
        End If

        FechaInicio = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
        CodTipoNomina = Me.CboTipoPlanilla.Text

        '///////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////GENERO UNA COMPRA POR PROVEEDOR ////////////////////////////////////////
        ''///////////////////////////////////////////////////////////////////////////////////////////////////////



        My.Application.DoEvents()

        Fecha = Me.DTPFechaIni.Value
        Nombres = Me.TDGridIngresos.Item(iPosicion)("Nombres")
        'Me.LblProcesando.Text = "PROCESANDO PRODUCTOR: " & CodProductor & " " & Nombres

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////ACTUALIZO LOS ENCABEZADOS DEl TIPO NOMINA//////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [NominaTransportista] SET [Activo] = 0 WHERE (NumPlanilla = '" & Me.TxtNumNomina.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        ds.Reset()
        SqlString = "SELECT CodigoTransportista, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina FROM Detalle_NominaTransportista WHERE (NumNomina = '-100000') "
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

        dsEgreso.Reset()
        SqlString = "SELECT Detalle_NominaTransportista.CodigoTransportista, Conductor.Nombre As  Nombres, Detalle_NominaTransportista.IR, Detalle_NominaTransportista.Bolsa, Detalle_NominaTransportista.DeduccionPolicia, Detalle_NominaTransportista.Anticipo, Detalle_NominaTransportista.DeduccionTransporte, Detalle_NominaTransportista.Pulperia,Detalle_NominaTransportista.Inseminacion, Detalle_NominaTransportista.Trazabilidad, Detalle_NominaTransportista.ProductosVeterinarios,Detalle_NominaTransportista.OtrasDeducciones, Detalle_NominaTransportista.IR + Detalle_NominaTransportista.Bolsa + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad AS TotalEgresos, Detalle_NominaTransportista.TotalIngresos - (Detalle_NominaTransportista.IR + Detalle_NominaTransportista.DeduccionPolicia + Detalle_NominaTransportista.Anticipo + Detalle_NominaTransportista.DeduccionTransporte + Detalle_NominaTransportista.Pulperia + Detalle_NominaTransportista.Inseminacion + Detalle_NominaTransportista.ProductosVeterinarios + Detalle_NominaTransportista.OtrasDeducciones + Detalle_NominaTransportista.Trazabilidad) AS NetoPagar FROM  Detalle_NominaTransportista INNER JOIN Conductor ON Detalle_NominaTransportista.CodigoTransportista = Conductor.Codigo " & _
            "WHERE (Detalle_NominaTransportista.NumNomina = '" & Me.TxtNumNomina.Text & "') ORDER BY CodigoTransportista"
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
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
        Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
        Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns(3).Caption = "Policia"
        Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 60
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
        Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
        Me.TDGridDeducciones.Columns(5).Caption = "Anticipo"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True

        Me.CmdNomina.Enabled = False
        Me.Button2.Enabled = False
        Me.CmdCerrar.Enabled = False
        Me.CboTipoPlanilla.Text = ""


        MsgBox("La Nomina se ha cerrado con Existo!!!", MsgBoxStyle.Critical, "Zeus Facturacion")
    End Sub
End Class