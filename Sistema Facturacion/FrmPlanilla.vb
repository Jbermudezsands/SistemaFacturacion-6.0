Imports System.Data.SqlClient

Public Class FrmPlanilla
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
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
        SqlString = "SELECT Detalle_Nomina.CodProductor, Detalle_Nomina.Nombres, Detalle_Nomina.Domingo, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos FROM Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
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



    Private Sub FrmPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, Fecha As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        'SqlString = "SELECT TipoNomina.CodTipoNomina, TipoNomina.TipoNomina, Periodos.Actual, Periodos.Periodo, Periodos.Inicio, Periodos.Final FROM  TipoNomina INNER JOIN Periodos ON TipoNomina.TipoNomina = Periodos.TipoNomina  WHERE(Periodos.Actual = 1)"
        SqlString = "SELECT TipoNomina.CodTipoNomina, TipoNomina.TipoNomina, Periodos.Actual, Periodos.Periodo, Periodos.Inicio, Periodos.Final FROM TipoNomina INNER JOIN Periodos ON TipoNomina.CodTipoNomina = Periodos.TipoNomina  WHERE(Periodos.Actual = 1) ORDER BY CodTipoNomina"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        Me.CboTipoPlanilla.DataSource = DataSet.Tables("TipoNomina")



        '///////////////////////////////////////////////////////////////////BUSCO LA  NOMINA ACTUAL PARA VER EL DIA DE LA SEMANA ///////////////////////
        SqlString = "SELECT Periodo, año, mes, TipoNomina, Inicio, Final, Actual, Calculada, NumNomina  FROM Periodos WHERE(Actual = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PeriodosActivo")
        If DataSet.Tables("PeriodosActivo").Rows.Count <> 0 Then
            Fecha = DataSet.Tables("PeriodosActivo").Rows(0)("Inicio")
            If Fecha.DayOfWeek = 1 Then
                SqlString = "SELECT CodProductor, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (NumNomina = '-100000') AND (TipoProductor = 'Productor')"
            ElseIf Fecha.DayOfWeek = 6 Then
                SqlString = "SELECT CodProductor, Nombres, Sabado, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (NumNomina = '-100000') AND (TipoProductor = 'Productor')"
            End If
        Else
            SqlString = "SELECT CodProductor, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (NumNomina = '-100000') AND (TipoProductor = 'Productor')"
        End If


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
        Me.TDGridIngresos.Splits(0).DisplayColumns("TipoProductor").Visible = False




    End Sub

    Private Sub CboTipoPlanilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoPlanilla.TextChanged
        Dim SqlString As String, CodTipoNomina As String, Fecha As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumNomina As String

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
                Me.TxtNumNomina.Text = NumNomina
                Me.TDGridDeducciones2.Enabled = True

                SqlString = "SELECT * FROM Nomina WHERE (NumPlanilla = '" & NumNomina & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Nomina")
                If DataSet.Tables("Nomina").Rows.Count <> 0 Then
                    Me.TxtPrecioLunes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioLunes")
                    Me.TxtPrecioMartes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioMartes")
                    Me.TxtPrecioMiercoles.Text = DataSet.Tables("Nomina").Rows(0)("PrecioMiercoles")
                    Me.TxtPrecioJueves.Text = DataSet.Tables("Nomina").Rows(0)("PrecioJueves")
                    Me.TxtPrecioViernes.Text = DataSet.Tables("Nomina").Rows(0)("PrecioViernes")
                    Me.TxtPrecioSabado.Text = DataSet.Tables("Nomina").Rows(0)("PrecioSabado")
                    Me.TxtPrecioDomingo.Text = DataSet.Tables("Nomina").Rows(0)("PrecioDomingo")
                    Me.TxtIR.Text = DataSet.Tables("Nomina").Rows(0)("PorcientoIR")
                    Me.TxtDeduccionPolicia.Text = DataSet.Tables("Nomina").Rows(0)("PorcientoPolicia")
                End If


                SqlString = "SELECT IdDeduccion, NumNomina, CodProductor, TipoProductor, NombreProductor, NoAnticipo, Anticipo, Transporte, Pulperia, Inseminacion, Trazabilidad, ProductosVeterinarios , OtrasDeducciones  FROM Deducciones_Planilla WHERE (NumNomina = '" & NumNomina & "')ORDER BY CodProductor"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Deducciones")
                Me.BindingDeducciones2.DataSource = DataSet.Tables("Deducciones")
                Me.TDGridDeducciones2.DataSource = Me.BindingDeducciones2
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(0).Visible = False
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(1).Visible = False
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Button = True
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Width = 100
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(3).Visible = False
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(4).Width = 156
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(5).Width = 78
                Me.TDGridDeducciones2.Columns(5).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(6).Width = 78
                Me.TDGridDeducciones2.Columns(6).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(7).Width = 78
                Me.TDGridDeducciones2.Columns(7).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("Pulperia").Width = 78
                Me.TDGridDeducciones2.Columns("Pulperia").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Columns("Pulperia").Caption = "Fondos"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(9).Width = 78
                Me.TDGridDeducciones2.Columns(9).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("Trazabilidad").Width = 70
                Me.TDGridDeducciones2.Columns("Trazabilidad").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("OtrasDeducciones").Width = 70
                Me.TDGridDeducciones2.Columns("OtrasDeducciones").Caption = "Otras"
                Me.TDGridDeducciones2.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("ProductosVeterinarios").Width = 70
                Me.TDGridDeducciones2.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones2.Columns("ProductosVeterinarios").Caption = "Veterinario"



                ds.Tables("DetalleIngresos").Reset()
                'SqlString = "SELECT Detalle_Nomina.CodProductor, Detalle_Nomina.Nombres, Detalle_Nomina.Domingo, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos FROM Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "DetalleIngresos")
                'Me.TDGridIngresos.DataSource = DataSet.Tables("DetalleIngresos")
                Fecha = Me.DTPFechaIni.Value
                If Fecha.DayOfWeek = 1 Then
                    SqlString = "SELECT CodProductor, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
                ElseIf Fecha.DayOfWeek = 6 Then
                    SqlString = "SELECT CodProductor, Nombres,Sabado, Domingo,  Lunes, Martes, Miercoles, Jueves, Viernes, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
                End If

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
                Me.TDGridIngresos.Splits(0).DisplayColumns("TipoProductor").Visible = False


                SqlString = "SELECT Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.IR, Detalle_Nomina.Bolsa, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.Trazabilidad, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.IR + Detalle_Nomina.Bolsa + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.Trazabilidad AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.Trazabilidad) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor " & _
                            "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor') ORDER BY CodProductor"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleEgresos")
                Me.TDGridDeducciones.DataSource = DataSet.Tables("DetalleEgresos")
                Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Width = 50
                Me.TDGridDeducciones.Columns(0).Caption = "Codigo"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Locked = True
                Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Width = 180
                Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Locked = True
                Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Width = 60
                Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
                Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 60
                Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
                Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionPolicia").Visible = False
                Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Columns(3).Caption = "Policia"
                Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 60
                Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
                Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
                Me.TDGridDeducciones.Columns(5).Caption = "Anticipo"
                Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
                Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
                Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
                Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
                Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
                Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
                Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
                Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
                Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
                Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
                Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
                Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
                Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

                Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
                Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True

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

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
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


        If Me.CboTipoPlanilla.Text = "" Then
            MsgBox("Seleccione la Nomina, para Calcular", MsgBoxStyle.Critical, "Zeus Acopio")
            Exit Sub
        End If

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
        StrSqlUpdate = "UPDATE [Nomina] SET [PorcientoIR] = " & Val(Me.TxtIR.Text) & ",[PorcientoPolicia] =  " & Val(Me.TxtDeduccionPolicia.Text) & ",[PrecioUnitario] = " & Val(Me.TxtPrecioLunes.Text) & ", [PrecioLunes] = " & Val(Me.TxtPrecioLunes.Text) & ", [PrecioMartes] = " & Val(Me.TxtPrecioMartes.Text) & ", [PrecioMiercoles] = " & Val(Me.TxtPrecioMiercoles.Text) & ", [PrecioJueves] = " & Val(Me.TxtPrecioJueves.Text) & ", [PrecioViernes] = " & Val(Me.TxtPrecioViernes.Text) & ", [PrecioSabado] = " & Val(Me.TxtPrecioSabado.Text) & ", [PrecioDomingo] = " & Val(Me.TxtPrecioDomingo.Text) & " " & _
                       "WHERE (NumPlanilla = '" & Me.TxtNumNomina.Text & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '/////////////////////////////////////////CARGO LOS PRODUCTORES ACTIVOS/////////////////////////////////////////

        SqlString = "SELECT * FROM Productor WHERE (TipoProductor = 'Productor') AND (Activo = 1) AND (CodTipoNomina = '" & Me.CboTipoPlanilla.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Productor")
        MiConexion.Close()

        iPosicion = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Registros = DataSet.Tables("Productor").Rows.Count
        Me.ProgressBar.Maximum = Registros
        Do While iPosicion < Registros
            My.Application.DoEvents()
            CodProductor = DataSet.Tables("Productor").Rows(iPosicion)("CodProductor")



            MontoLunes = 0
            MontoMartes = 0
            MontoMiercoles = 0
            MontoJueves = 0
            MontoViernes = 0
            MontoSabado = 0
            MontoDomingo = 0


            If Not IsDBNull(DataSet.Tables("Productor").Rows(iPosicion)("Precio")) Then
                PrecioUnitario = DataSet.Tables("Productor").Rows(iPosicion)("Precio")

                PrecioLunes = PrecioUnitario
                PrecioMartes = PrecioUnitario
                PrecioMiercoles = PrecioUnitario
                PrecioJueves = PrecioUnitario
                PrecioViernes = PrecioUnitario
                PrecioSabado = PrecioUnitario
                PrecioDomingo = PrecioUnitario
            End If

            '//////////////////////////////////////////////CONSULTO SI ESTE PRODUCTOR YA TIENE UNA PLANILLA GRABADA ANTERIOR ////////////////////////////
            SqlString = "SELECT Detalle_Nomina.* FROM Detalle_Nomina  WHERE  (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Lunes")) Then
                    PLunes = DataSet.Tables("Consulta").Rows(0)("Lunes")
                Else
                    PLunes = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Martes")) Then
                    PMartes = DataSet.Tables("Consulta").Rows(0)("Martes")
                Else
                    PMartes = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Miercoles")) Then
                    PMiercoles = DataSet.Tables("Consulta").Rows(0)("Miercoles")
                Else
                    PMiercoles = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Jueves")) Then
                    PJueves = DataSet.Tables("Consulta").Rows(0)("Jueves")
                Else
                    PJueves = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Viernes")) Then
                    PViernes = DataSet.Tables("Consulta").Rows(0)("Viernes")
                Else
                    PViernes = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Sabado")) Then
                    PSabado = DataSet.Tables("Consulta").Rows(0)("Sabado")
                Else
                    PSabado = 0
                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Domingo")) Then
                    PDomingo = DataSet.Tables("Consulta").Rows(0)("Domingo")
                Else
                    PDomingo = 0
                End If



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
            Nombres = DataSet.Tables("Productor").Rows(iPosicion)("NombreProductor") + " " + DataSet.Tables("Productor").Rows(iPosicion)("ApellidoProductor")
            Me.LblProcesando.Text = "PROCESANDO PRODUCTOR: " & CodProductor & " " & Nombres
            CantidadTotal = 0
            Contador = 1
            '///////////////////////////////////////////////77////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////BUSCO LAS RECEPCIONES DEL PRODUCTOR///////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Maximum = 7
            Do While Fecha <= Me.DTPFechaFin.Value

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////BUSCO LAS RECEPCIONES DE LECHE/////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT  * FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                            "WHERE (Detalle_Compras.Tipo_Compra = 'Recepcion') AND (Compras.Cod_Proveedor = '" & CodProductor & "') AND (Compras.TipoProductor = 'Productor') AND (Compras.Fecha_Compra = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Recepciones")
                iPosicion2 = 0
                Cantidad = 0
                NCompra = 0
                Registros2 = DataSet.Tables("Recepciones").Rows.Count

                Do While iPosicion2 < Registros2
                    Cantidad = Cantidad + DataSet.Tables("Recepciones").Rows(iPosicion2)("Cantidad")
                    NCompra = DataSet.Tables("Recepciones").Rows(iPosicion2)("Numero_Compra")
                    iPosicion2 = iPosicion2 + 1
                Loop
                DataSet.Tables("Recepciones").Clear()


                Contador = Fecha.DayOfWeek

                Select Case Contador
                    Case 1
                        If PLunes > Cantidad Then
                            Cantidad = PLunes
                            ROC1 = 0
                        End If
                        CantLunes = Cantidad
                        MontoLunes = Cantidad * PrecioLunes
                        ROC1 = NCompra
                    Case 2
                        If PMartes > Cantidad Then
                            Cantidad = PMartes
                            ROC2 = 0
                        End If
                        CantMartes = Cantidad
                        MontoMartes = Cantidad * PrecioMartes
                        ROC2 = NCompra
                    Case 3
                        If PMiercoles > Cantidad Then
                            Cantidad = PMiercoles
                            ROC3 = 0
                        End If
                        CantMiercoles = Cantidad
                        MontoMiercoles = Cantidad * PrecioMiercoles
                        ROC3 = NCompra
                    Case 4
                        If PJueves > Cantidad Then
                            Cantidad = PJueves
                            ROC4 = 0
                        End If
                        CantJueves = Cantidad
                        MontoJueves = Cantidad * PrecioJueves
                        ROC4 = NCompra
                    Case 5
                        If PViernes > Cantidad Then
                            Cantidad = PViernes
                            ROC5 = 0
                        End If
                        CantViernes = Cantidad
                        MontoViernes = Cantidad * PrecioViernes
                        ROC5 = NCompra
                    Case 6
                        If PSabado > Cantidad Then
                            Cantidad = PSabado
                            ROC6 = 0
                        End If
                        CantSabado = Cantidad
                        MontoSabado = Cantidad * PrecioSabado
                        ROC6 = NCompra
                    Case 0
                        If PDomingo > Cantidad Then
                            Cantidad = PDomingo
                            ROC7 = 0
                        End If

                        CantDomingo = Cantidad
                        MontoDomingo = Cantidad * PrecioDomingo
                        ROC7 = NCompra
                End Select

                If CodProductor = "0101" Then
                    CodProductor = "0101"
                End If

                CantidadTotal = CantidadTotal + Cantidad
                IngresoBruto = MontoLunes + MontoMartes + MontoMiercoles + MontoJueves + MontoViernes + MontoSabado + MontoDomingo
                MontoIr = PorcientoIr * IngresoBruto
                MontoPolicia = PorcientoPolicia * CantidadTotal
                MontoBolsa = PorcientoBolsa * IngresoBruto

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////BUSCO LAS DEDUCCIONES/////////////////////////////////////////////////
                '////////////////////////////////////////////////777777777777777777777777777777777777777777777777777777777777777777777
                Anticipo = 0
                Transporte = 0
                Pulperia = 0
                Inseminacion = 0
                Trazabilidad = 0
                Otros = 0
                MontoVeterinario = 0
                SqlString = "SELECT  * FROM Deducciones_Planilla WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "DeduccionPlanilla")
                If DataSet.Tables("DeduccionPlanilla").Rows.Count <> 0 Then
                    Anticipo = DataSet.Tables("DeduccionPlanilla").Rows(0)("Anticipo")
                    Transporte = DataSet.Tables("DeduccionPlanilla").Rows(0)("Transporte")
                    Pulperia = DataSet.Tables("DeduccionPlanilla").Rows(0)("Pulperia")
                    Inseminacion = DataSet.Tables("DeduccionPlanilla").Rows(0)("Inseminacion")
                    Trazabilidad = DataSet.Tables("DeduccionPlanilla").Rows(0)("Trazabilidad")
                    If Not IsDBNull(DataSet.Tables("DeduccionPlanilla").Rows(0)("ProductosVeterinarios")) Then
                        MontoVeterinario = DataSet.Tables("DeduccionPlanilla").Rows(0)("ProductosVeterinarios")
                    End If
                    Otros = DataSet.Tables("DeduccionPlanilla").Rows(0)("OtrasDeducciones")

                Else
                    '///////////SI NO EXISTE AGREGO UNA DEDUCCION EN CERO CON EL PRODUCTOR////////////////
                    StrSqlUpdate = "INSERT INTO [Deducciones_Planilla] ([NumNomina],[CodProductor],[TipoProductor],[NombreProductor],[NoAnticipo],[Anticipo],[Transporte],[Pulperia],[Inseminacion],[Trazabilidad],[OtrasDeducciones],[ProductosVeterinarios]) " & _
                                   "VALUES ('" & Me.TxtNumNomina.Text & "','" & CodProductor & "','Productor','" & Nombres & "','0000',0,0,0,0,0,0,0)"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If
                DataSet.Tables("DeduccionPlanilla").Clear()



                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////BUSCO LOS PRODUCTOS VETERINARIOS EN FACTURACION/////////////////////////////////////////////////
                '////////////////////////////////////////////////777777777777777777777777777777777777777777777777777777777777777777777
                SqlString = "SELECT DISTINCT MAX(Facturas.Numero_Factura) AS Numero_Factura, MAX(Facturas.Fecha_Factura) AS Fecha_Factura, SUM(Facturas.MontoCredito) AS MontoCredito, SUM(DetalleRecibo.MontoPagado - DetalleRecibo.MontoPagado) AS MontoPagado, SUM(Facturas.MontoCredito) AS Saldo FROM  Facturas LEFT OUTER JOIN DetalleRecibo ON Facturas.Numero_Factura = DetalleRecibo.Numero_Factura " & _
                            "WHERE (Facturas.Cod_Cliente = '" & CodProductor & "') AND (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Vencimiento <= CONVERT(DATETIME,'" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) HAVING (SUM(Facturas.MontoCredito) <> 0) AND (MAX(Facturas.TipoProductor) = 'Productor') ORDER BY MAX(Facturas.Numero_Factura) DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Veterinario")
                If DataSet.Tables("Veterinario").Rows.Count <> 0 Then
                    If Not IsDBNull(DataSet.Tables("Veterinario").Rows(0)("MontoCredito")) Then
                        MontoVeterinario = MontoVeterinario + DataSet.Tables("Veterinario").Rows(0)("MontoCredito")
                    End If
                Else
                    'MontoVeterinario = 0
                End If

                DataSet.Tables("Veterinario").Clear()


                Contador = Contador + 1
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
            Loop





            SqlString = "SELECT  * FROM Detalle_Nomina WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleNomina")
            If DataSet.Tables("DetalleNomina").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Detalle_Nomina] ([NumNomina],[CodProductor],[TipoProductor],[Roc1],[Lunes],[Roc2],[Martes],[Roc3],[Miercoles],[Roc4],[Jueves],[Roc5],[Viernes],[Roc6],[Sabado],[Roc7],[Domingo],[Total],[PrecioVenta],[TotalIngresos],[IR],[DeduccionPolicia],[Anticipo],[DeduccionTransporte],[Pulperia],[Inseminacion],[Trazabilidad],[ProductosVeterinarios],[OtrasDeducciones],[Nombres],[Bolsa],[PrecioLunes],[PrecioMartes],[PrecioMiercoles],[PrecioJueves],[PrecioViernes],[PrecioSabado],[PrecioDomingo]) " & _
                               "VALUES ('" & Me.TxtNumNomina.Text & "','" & CodProductor & "','Productor','" & ROC1 & "'," & CantLunes & ",'" & ROC2 & "'," & CantMartes & ",'" & ROC3 & "'," & CantMiercoles & ",'" & ROC4 & "'," & CantJueves & ",'" & ROC5 & "'," & CantViernes & ",'" & ROC6 & "'," & CantSabado & ",'" & ROC7 & "'," & CantDomingo & "," & CantidadTotal & " ," & PrecioUnitario & "," & IngresoBruto & "," & MontoIr & "," & MontoPolicia & "," & Anticipo & "," & Transporte & "," & Pulperia & "," & Inseminacion & "," & Trazabilidad & " ," & MontoVeterinario & " ," & Otros & ", '" & Nombres & "', " & MontoBolsa & ", " & PrecioLunes & "," & PrecioMartes & ", " & PrecioMiercoles & ", " & PrecioJueves & ", " & PrecioViernes & ", " & PrecioSabado & ", " & PrecioDomingo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                'If Not IsDBNull(DataSet.Tables("DetalleNomina").Rows(0)("PrecioVenta")) Then
                '    If DataSet.Tables("DetalleNomina").Rows(0)("PrecioVenta") <= 0 Then
                '        PrecioUnitario = Me.TxtPrecioUnitario.Text
                '    Else
                '        PrecioUnitario = DataSet.Tables("DetalleNomina").Rows(0)("PrecioVenta")
                '    End If
                'Else
                '    PrecioUnitario = Me.TxtPrecioUnitario.Text
                'End If


                StrSqlUpdate = "UPDATE [Detalle_Nomina] SET [Roc1] = '" & ROC1 & "',[Lunes] = " & CantLunes & ",[Roc2] = '" & ROC2 & "',[Martes] = " & CantMartes & ",[Roc3] = '" & ROC3 & "',[Miercoles] = '" & CantMiercoles & "',[Roc4] = '" & ROC4 & "',[Jueves] = " & CantJueves & ",[Roc5] = '" & ROC5 & "',[Viernes] =" & CantViernes & ",[Roc6] = '" & ROC6 & "',[Sabado] = " & CantSabado & ",[Roc7] = '" & ROC7 & "',[Domingo] = " & CantDomingo & ",[Total] = " & CantidadTotal & ",[PrecioVenta] = " & PrecioUnitario & ",[TotalIngresos] = " & IngresoBruto & ",[IR] = " & MontoIr & ",[DeduccionPolicia] = " & MontoPolicia & ",[Anticipo] = " & Anticipo & ",[DeduccionTransporte] = " & Transporte & " ,[Pulperia] = " & Pulperia & ",[Inseminacion] = " & Inseminacion & ",[ProductosVeterinarios] = " & MontoVeterinario & " ,[Trazabilidad] = " & Trazabilidad & ",[OtrasDeducciones] = " & Otros & " ,[Nombres] = '" & Nombres & "', [Bolsa] = '" & MontoBolsa & "' , [PrecioLunes] = '" & PrecioLunes & "',  [PrecioMartes] = '" & PrecioMartes & "',  [PrecioMiercoles] = '" & PrecioMiercoles & "' , [PrecioJueves] = '" & PrecioJueves & "', [PrecioViernes] = '" & PrecioViernes & "', [PrecioSabado] = '" & PrecioSabado & "', [PrecioDomingo] = '" & PrecioDomingo & "'   " & _
                               "WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            DataSet.Tables("DetalleNomina").Clear()

            iPosicion = iPosicion + 1
            Me.ProgressBar.Value = iPosicion
        Loop

        'Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres
        ds.Tables("DetalleIngresos").Reset()

        Fecha = Me.DTPFechaIni.Value
        If Fecha.DayOfWeek = 1 Then
            SqlString = "SELECT CodProductor, Nombres, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado,  Domingo, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        ElseIf Fecha.DayOfWeek = 6 Then
            SqlString = "SELECT CodProductor, Nombres, Sabado,  Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        End If

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
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumNomina").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("TipoProductor").Visible = False


        SqlString = "SELECT Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.IR, Detalle_Nomina.Bolsa, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.Trazabilidad, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.IR + Detalle_Nomina.Bolsa + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.Trazabilidad AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.Bolsa + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.Trazabilidad) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor " & _
            "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = DataSet.Tables("DetalleEgresos")
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
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipo").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("DeduccionTransporte").Locked = True
        Me.TDGridDeducciones.Columns("DeduccionTransporte").Caption = "Transporte"
        Me.TDGridDeducciones.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pulperia").Locked = True
        Me.TDGridDeducciones.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones.Columns("Inseminacion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Inseminacion").Locked = True
        Me.TDGridDeducciones.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Trazabilidad").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Veterinario"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("ProductosVeterinarios").Locked = True
        Me.TDGridDeducciones.Columns("ProductosVeterinarios").Caption = "Veterinario"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("OtrasDeducciones").Locked = True
        Me.TDGridDeducciones.Columns("TotalEgresos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("TotalEgresos").Locked = True

        Me.TDGridDeducciones.Columns("NetoPagar").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NetoPagar").Locked = True


        SqlString = "SELECT IdDeduccion, NumNomina, CodProductor, TipoProductor, NombreProductor, NoAnticipo, Anticipo, Transporte, Pulperia, Inseminacion, Trazabilidad, ProductosVeterinarios , OtrasDeducciones  FROM Deducciones_Planilla WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "')ORDER BY CodProductor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        Me.BindingDeducciones2.DataSource = DataSet.Tables("Deducciones")
        Me.TDGridDeducciones2.DataSource = Me.BindingDeducciones2
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(1).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Button = True
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Width = 100
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(3).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(4).Width = 156
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(5).Width = 78
        Me.TDGridDeducciones2.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(6).Width = 78
        Me.TDGridDeducciones2.Columns(6).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(7).Width = 78
        Me.TDGridDeducciones2.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("Pulperia").Width = 78
        Me.TDGridDeducciones2.Columns("Pulperia").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Columns("Pulperia").Caption = "Fondos"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(9).Width = 78
        Me.TDGridDeducciones2.Columns(9).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("Trazabilidad").Width = 70
        Me.TDGridDeducciones2.Columns("Trazabilidad").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("OtrasDeducciones").Width = 70
        Me.TDGridDeducciones2.Columns("OtrasDeducciones").Caption = "Otras"
        Me.TDGridDeducciones2.Columns("OtrasDeducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns("ProductosVeterinarios").Width = 70
        Me.TDGridDeducciones2.Columns("ProductosVeterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Columns("ProductosVeterinarios").Caption = "Veterinario"

        'SqlString = "SELECT Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.IR,Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor " & _
        '            "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleEgresos")
        'Me.TDGridDeducciones.DataSource = DataSet.Tables("DetalleEgresos")
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Width = 70
        'Me.TDGridDeducciones.Columns(0).Caption = "Codigo"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Locked = True
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Width = 180
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Locked = True
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
        'Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
        'Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Columns(3).Caption = "Policia"
        'Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
        'Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
        'Me.TDGridDeducciones.Columns(5).Caption = "Transporte"
        'Me.TDGridDeducciones.Columns(6).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(6).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(6).Locked = True
        'Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
        'Me.TDGridDeducciones.Columns(8).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(8).Width = 70
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(8).Locked = True
        'Me.TDGridDeducciones.Columns(8).Caption = "Veterinario"
        'Me.TDGridDeducciones.Columns(9).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(9).Width = 80
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(9).Locked = True
        'Me.TDGridDeducciones.Columns(10).NumberFormat = "##,##0.00"
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Width = 80
        'Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Locked = True

        Me.CmdNomina.Enabled = True
        Me.CmdColillas.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdCerrar.Enabled = True



    End Sub

    Private Sub TDGridDeducciones2_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridDeducciones2.AfterUpdate

        Me.TDGridDeducciones2.Col = 2
    End Sub

    Private Sub TDGridDeducciones2_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TDGridDeducciones2.BeforeColEdit


    End Sub

    Private Sub TDGridDeducciones2_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDGridDeducciones2.BeforeColUpdate
        Dim Cols As Double, CodProductor As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Cols = e.ColIndex

        Select Case Cols
            Case 2

                CodProductor = Me.TDGridDeducciones2.Columns(2).Text
                SqlString = "SELECT *  FROM Productor WHERE (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Productor")
                If DataSet.Tables("Productor").Rows.Count = 0 Then
                    MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                Else
                    Me.TDGridDeducciones2.Columns(2).Text = DataSet.Tables("Productor").Rows(0)("CodProductor")
                    Me.TDGridDeducciones2.Columns(4).Text = DataSet.Tables("Productor").Rows(0)("NombreProductor")
                End If

        End Select
    End Sub

    Private Sub TDGridDeducciones2_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDGridDeducciones2.BeforeUpdate
        Dim SqlString As String, CodProductor As String, NombreProductor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Anticipo As Double, Transporte As Double, Pulperia As Double, Inseminacion As Double, Trazabilidad As Double, Otros As Double
        Dim MontoVeterinario As Double = 0

        CodProductor = Me.TDGridDeducciones2.Columns(2).Text
        NombreProductor = Me.TDGridDeducciones2.Columns(4).Text
        If IsNumeric(Me.TDGridDeducciones2.Columns(6).Text) Then
            Anticipo = Me.TDGridDeducciones2.Columns(6).Text
        Else
            Anticipo = 0
        End If

        If IsNumeric(Me.TDGridDeducciones2.Columns(7).Text) Then
            Transporte = Me.TDGridDeducciones2.Columns(7).Text
        Else
            Transporte = 0
        End If

        If IsNumeric(Me.TDGridDeducciones2.Columns(8).Text) Then
            Pulperia = Me.TDGridDeducciones2.Columns(8).Text
        Else
            Pulperia = 0
        End If

        If IsNumeric(Me.TDGridDeducciones2.Columns(9).Text) Then
            Inseminacion = Me.TDGridDeducciones2.Columns(9).Text
        Else
            Inseminacion = 0
        End If

        If IsNumeric(Me.TDGridDeducciones2.Columns("Trazabilidad").Text) Then
            Trazabilidad = Me.TDGridDeducciones2.Columns("Trazabilidad").Text
        Else
            Trazabilidad = 0
        End If

        If IsNumeric(Me.TDGridDeducciones2.Columns("OtrasDeducciones").Text) Then
            Otros = Me.TDGridDeducciones2.Columns("OtrasDeducciones").Text
        Else
            Otros = 0
        End If


        If IsNumeric(Me.TDGridDeducciones2.Columns("ProductosVeterinarios").Text) Then
            MontoVeterinario = Me.TDGridDeducciones2.Columns("ProductosVeterinarios").Text
        Else
            MontoVeterinario = 0
        End If


        SqlString = "SELECT  * FROM Deducciones_Planilla WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')ORDER BY CodProductor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleDeduccion")
        If DataSet.Tables("DetalleDeduccion").Rows.Count = 0 Then
            '///////////SI EXISTE EL LO ACTUALIZO////////////////
            StrSqlUpdate = "INSERT INTO [Deducciones_Planilla] ([NumNomina],[CodProductor],[TipoProductor],[NombreProductor],[NoAnticipo],[Anticipo],[Transporte],[Pulperia],[Inseminacion],[Trazabilidad],[OtrasDeducciones],[ProductosVeterinarios]) " & _
                           "VALUES ('" & Me.TxtNumNomina.Text & "','" & CodProductor & "','Productor','" & NombreProductor & "','" & Me.TDGridDeducciones2.Columns(5).Text & "'," & Anticipo & "," & Transporte & "," & Pulperia & " ," & Inseminacion & "," & Trazabilidad & "," & Otros & "," & MontoVeterinario & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            StrSqlUpdate = "UPDATE [Deducciones_Planilla] SET [NoAnticipo] = '" & Me.TDGridDeducciones2.Columns(5).Text & "' ,[Anticipo] = " & Anticipo & ",[Transporte] = " & Transporte & ",[Pulperia] = " & Pulperia & ",[Inseminacion] = " & Inseminacion & ", [Trazabilidad] = " & Trazabilidad & ", [OtrasDeducciones] = " & Otros & ", [ProductosVeterinarios] = " & MontoVeterinario & "  WHERE (NumNomina = '" & Me.TxtNumNomina.Text & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If
    End Sub

    Private Sub TDGridDeducciones2_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridDeducciones2.ButtonClick
        Dim Nombres As String
        Quien = "CodigoProductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TDGridDeducciones2.Columns(2).Text = My.Forms.FrmConsultas.Codigo
        Nombres = My.Forms.FrmConsultas.Nombres + " " + My.Forms.FrmConsultas.Apellidos
        Me.TDGridDeducciones2.Columns(4).Text = Nombres

    End Sub

    Private Sub TDGridDeducciones2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridDeducciones2.Click

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

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridIngresos.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, idDeduccion As Double, NumNomina As String, CodProductor As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Respuesta As Integer, SqlString As String


        Respuesta = MsgBox("Desea Elimnar el Registro", MsgBoxStyle.YesNo, "Zeus Acopio")
        If Respuesta <> 6 Then
            Exit Sub
        End If


        idDeduccion = Me.TDGridDeducciones2.Columns(0).Text
        NumNomina = Me.TxtNumNomina.Text
        CodProductor = Me.TDGridDeducciones2.Columns(2).Text


        '///////////SI EXISTE EL LO ACTUALIZO////////////////
        StrSqlUpdate = "DELETE FROM [Deducciones_Planilla] WHERE (IdDeduccion = " & idDeduccion & ") AND (NumNomina = '" & NumNomina & "') AND (CodProductor = '" & CodProductor & "') AND (TipoProductor = 'Productor')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        SqlString = "SELECT * FROM Deducciones_Planilla WHERE (NumNomina = '" & NumNomina & "')ORDER BY CodProductor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        Me.BindingDeducciones2.DataSource = DataSet.Tables("Deducciones")
        Me.TDGridDeducciones2.DataSource = Me.BindingDeducciones2
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(1).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Button = True
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Width = 100
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(3).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(4).Width = 156
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(5).Width = 78
        Me.TDGridDeducciones2.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(6).Width = 78
        Me.TDGridDeducciones2.Columns(6).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(7).Width = 78
        Me.TDGridDeducciones2.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(8).Width = 78
        Me.TDGridDeducciones2.Columns(8).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(9).Width = 78
        Me.TDGridDeducciones2.Columns(9).NumberFormat = "##,##0.00"
    End Sub

    Private Sub CmdNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNomina.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepPlanilla As New ArepPlanilla, SqlDatos As String
        Dim RutaLogo As String, SqlDetalle As String, Fecha As Date
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
        ArepPlanilla.LblPeriodo.Text = "Periodo desde " & Me.DTPFechaIni.Value & " Hasta " & Me.DTPFechaFin.Value
        ArepPlanilla.LblImpreso.Text = "Impreso: " & Format(Now, "D")
        ArepPlanilla.LblTipoNomina.Text = Me.CboTipoPlanilla.Text

        Fecha = Me.DTPFechaIni.Value
        If Fecha.DayOfWeek = 6 Then
            ArepPlanilla.LblLunes.Text = "Sabado"
            ArepPlanilla.LblMartes.Text = "Domingo"
            ArepPlanilla.LblMiercoles.Text = "Lunes"
            ArepPlanilla.LblJueves.Text = "Martes"
            ArepPlanilla.LblViernes.Text = "Miercoles"
            ArepPlanilla.LblSabado.Text = "Jueves"
            ArepPlanilla.LblDomingo.Text = "Viernes"

            ArepPlanilla.TextBox3.DataField = "Sabado"
            ArepPlanilla.TextBox4.DataField = "Domingo"
            ArepPlanilla.TextBox5.DataField = "Lunes"
            ArepPlanilla.TextBox6.DataField = "Martes"
            ArepPlanilla.TextBox7.DataField = "Miercoles"
            ArepPlanilla.TextBox8.DataField = "Jueves"
            ArepPlanilla.TextBox9.DataField = "Viernes"

            ArepPlanilla.TextBox23.Text = "Sabado"
            ArepPlanilla.TextBox39.Text = "Domingo"
            ArepPlanilla.TextBox44.Text = "Lunes"
            ArepPlanilla.TextBox45.Text = "Martes"
            ArepPlanilla.TextBox47.Text = "Miercoles"
            ArepPlanilla.TextBox49.Text = "Jueves"
            ArepPlanilla.TextBox50.Text = "Viernes"

            ArepPlanilla.TxtLunes.DataField = "Sabado"
            ArepPlanilla.TxtMartes.DataField = "Domingo"
            ArepPlanilla.TxtMiercoles.DataField = "Lunes"
            ArepPlanilla.TxtJueves.DataField = "Martes"
            ArepPlanilla.txtviernes.DataField = "Miercoles"
            ArepPlanilla.TxtSabado.DataField = "Jueves"
            ArepPlanilla.TxtDomingo.DataField = "Viernes"

            ArepPlanilla.TxtMontoLunes.DataField = "Sabado"
            ArepPlanilla.TxtMontoMartes.DataField = "Domingo"
            ArepPlanilla.TxtMontoMiercoles.DataField = "Lunes"
            ArepPlanilla.TxtMontoJueves.DataField = "Martes"
            ArepPlanilla.TxtMontoViernes.DataField = "Miercoles"
            ArepPlanilla.TxtMontoSabado.DataField = "Jueves"
            ArepPlanilla.TxtMontoDomingo.DataField = "Viernes"

        End If

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT Detalle_Nomina.NumNomina,Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado,Detalle_Nomina.Domingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos, Detalle_Nomina.IR, Detalle_Nomina.Trazabilidad, Detalle_Nomina.Bolsa, Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR + Detalle_Nomina.Bolsa + Detalle_Nomina.Trazabilidad + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos,Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor  " & _
                     "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        'SqlDetalle = "SELECT Detalle_Nomina.NumNomina, Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes, Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado, Detalle_Nomina.Domingo, Detalle_Nomina.Lunes * Detalle_Nomina.PrecioVenta AS MontoLunes, Detalle_Nomina.Martes * Detalle_Nomina.PrecioVenta AS MontoMartes, Detalle_Nomina.Miercoles * Detalle_Nomina.PrecioVenta AS MontoMiercoles, Detalle_Nomina.Jueves * Detalle_Nomina.PrecioVenta AS MontoJueves, Detalle_Nomina.Viernes * Detalle_Nomina.PrecioVenta AS MontoViernes, Detalle_Nomina.Sabado * Detalle_Nomina.PrecioVenta AS MontoSabado, Detalle_Nomina.Domingo * Detalle_Nomina.PrecioVenta AS MontoDomingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos, Detalle_Nomina.IR, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia, Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios, Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar, Ruta_Distribucion.Nombre_Ruta, Ruta_Distribucion.CodRuta  FROM Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
        '             "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor') ORDER BY Ruta_Distribucion.CodRuta"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepPlanilla.DataSource = SQL
        ArepPlanilla.Document.Name = "Reporte de Planilla"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepPlanilla.Document
        ViewerForm.Show()
        ArepPlanilla.Run(False)

        'ArepPlanilla.Show()
    End Sub

    Private Sub CmdColillas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdColillas.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Mes As String = ""
        Dim ArepColillas As New ArepListaRecepcion, SqlDatos As String, FechaInicio As Date, FechaFin As Date
        Dim RutaLogo As String, SqlDetalle As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepColillas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepColillas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepColillas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepColillas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        Select Case FechaFin.Month
            Case 1 : Mes = "Enero"
            Case 2 : Mes = "Febrero"
            Case 3 : Mes = "Marzo"
            Case 4 : Mes = "Abril"
            Case 5 : Mes = "Mayo"
            Case 6 : Mes = "Junio"
            Case 7 : Mes = "Julio"
            Case 8 : Mes = "Agosto"
            Case 9 : Mes = "Septiembre"
            Case 10 : Mes = "Octubre"
            Case 11 : Mes = "Noviembre"
            Case 12 : Mes = "Diciembre"
        End Select


        FechaInicio = Me.DTPFechaIni.Value
        FechaFin = Me.DTPFechaFin.Value
        ArepColillas.LblImpreso.Text = Format(Now, "dd/MM/yyyy")
        ArepColillas.LblRecepcion.Text = "Recepcion de Leche de la Semana del " & FechaInicio.Day & " al " & FechaFin.Day & " de " & Mes & " " & FechaFin.Year

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        'SqlDetalle = "SELECT  Nomina.NumPlanilla, Nomina.FechaInicial, Nomina.FechaFinal, Productor.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Roc1, Detalle_Nomina.Lunes, Detalle_Nomina.Roc2, Detalle_Nomina.Martes, Detalle_Nomina.Roc3, Detalle_Nomina.Miercoles, Detalle_Nomina.Roc4, Detalle_Nomina.Jueves, Detalle_Nomina.Roc5, Detalle_Nomina.Viernes, Detalle_Nomina.Roc6, Detalle_Nomina.Sabado, Detalle_Nomina.Roc7, Detalle_Nomina.Domingo, Detalle_Nomina.Total, Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM  Detalle_Nomina INNER JOIN Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN  Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN  Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
        '             "WHERE  (Nomina.NumPlanilla = '" & Me.TxtNumNomina.Text & "') ORDER BY Ruta_Distribucion.CodRuta, Productor.CodProductor"

        SqlDetalle = "SELECT  Nomina.NumPlanilla, Nomina.FechaInicial, Nomina.FechaFinal, Productor.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Roc1, Detalle_Nomina.Lunes, Detalle_Nomina.Roc2, Detalle_Nomina.Martes, Detalle_Nomina.Roc3, Detalle_Nomina.Miercoles, Detalle_Nomina.Roc4, Detalle_Nomina.Jueves, Detalle_Nomina.Roc5, Detalle_Nomina.Viernes, Detalle_Nomina.Roc6, Detalle_Nomina.Sabado, Detalle_Nomina.Roc7, Detalle_Nomina.Domingo, Detalle_Nomina.Total, Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM Detalle_Nomina INNER JOIN  Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
                     "WHERE   (Nomina.NumPlanilla = '" & Me.TxtNumNomina.Text & "') ORDER BY Ruta_Distribucion.CodRuta, Productor.CodProductor"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepColillas.DataSource = SQL
        ArepColillas.Document.Name = "Reporte de Planilla"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepColillas.Document
        ViewerForm.Show()
        ArepColillas.Run(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepColilla As New ArepColillas, SqlDatos As String
        Dim SqlDetalle As String, SqlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim i As Double = 0, CodRuta As String, Fecha As Date



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

        Fecha = Me.DTPFechaIni.Value
        If Fecha.DayOfWeek = 6 Then
            ArepColilla.LblLunes.Text = "Sabado"
            ArepColilla.LblMartes.Text = "Domingo"
            ArepColilla.LblMiercoles.Text = "Lunes"
            ArepColilla.LblJueves.Text = "Martes"
            ArepColilla.LblViernes.Text = "Miercoles"
            ArepColilla.LblSabado.Text = "Jueves"
            ArepColilla.LblDomingo.Text = "Viernes"

            ArepColilla.LblPrecioLunes.Text = "Sabado"
            ArepColilla.LblPrecioMartes.Text = "Domingo"
            ArepColilla.LblPrecioMiercoles.Text = "Lunes"
            ArepColilla.LblPrecioJueves.Text = "Martes"
            ArepColilla.LblPrecioViernes.Text = "Miercoles"
            ArepColilla.LblPrecioSabado.Text = "Jueves"
            ArepColilla.LblPrecioDomingo.Text = "Viernes"

            ArepColilla.TxtMontoLunes.DataField = "Sabado"
            ArepColilla.TxtMontoMartes.DataField = "Domingo"
            ArepColilla.TxtMontoMiercoles.DataField = "Lunes"
            ArepColilla.TxtMontoJueves.DataField = "Martes"
            ArepColilla.TxtMontoViernes.DataField = "Miercoles"
            ArepColilla.TxtMontoSabado.DataField = "Jueves"
            ArepColilla.TxtMontoDomingo.DataField = "Viernes"

            ArepColilla.TxtPrecioLunes.DataField = "Sabado"
            ArepColilla.TxtPrecioMartes.DataField = "Domingo"
            ArepColilla.TxtPrecioMiercoles.DataField = "Lunes"
            ArepColilla.TxtPrecioJueves.DataField = "Martes"
            ArepColilla.TxtPrecioViernes.DataField = "Miercoles"
            ArepColilla.TxtPrecioSabado.DataField = "Jueves"
            ArepColilla.TxtPrecioDomingo.DataField = "Viernes"


        End If

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT  Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado,Detalle_Nomina.Domingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos,  Detalle_Nomina.Trazabilidad, Detalle_Nomina.IR,Detalle_Nomina.Bolsa,Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR +  Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos,Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR +  Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar, Nomina.NumPlanilla,Nomina.FechaInicial, Nomina.FechaFinal ,  Detalle_Nomina.PrecioLunes, Detalle_Nomina.PrecioMartes, Detalle_Nomina.PrecioMiercoles, Detalle_Nomina.PrecioJueves, Detalle_Nomina.PrecioViernes, Detalle_Nomina.PrecioSabado, Detalle_Nomina.PrecioDomingo, TipoNomina.TipoNomina FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN TipoNomina ON Nomina.CodTipoNomina = TipoNomina.CodTipoNomina " & _
                     "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor') "
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepColilla.DataSource = SQL
        ArepColilla.Document.Name = "Reporte de Planilla"
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


        iPosicion = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Registros = Me.TDGridIngresos.RowCount
        Me.ProgressBar.Maximum = Registros
        Do While iPosicion < Registros
            My.Application.DoEvents()
            CodProductor = Me.TDGridIngresos.Item(iPosicion)("CodProductor")

            PLunes = Me.TDGridIngresos.Item(iPosicion)("Lunes")
            PMartes = Me.TDGridIngresos.Item(iPosicion)("Martes")
            PMiercoles = Me.TDGridIngresos.Item(iPosicion)("Miercoles")
            PJueves = Me.TDGridIngresos.Item(iPosicion)("Jueves")
            PViernes = Me.TDGridIngresos.Item(iPosicion)("Viernes")
            PSabado = Me.TDGridIngresos.Item(iPosicion)("Sabado")
            PDomingo = Me.TDGridIngresos.Item(iPosicion)("Domingo")
            PrecioVenta = Me.TDGridIngresos.Item(iPosicion)("PrecioVenta")

            Fecha = Me.DTPFechaIni.Value
            Nombres = Me.TDGridIngresos.Item(iPosicion)("Nombres")
            Me.LblProcesando.Text = "PROCESANDO PRODUCTOR: " & CodProductor & " " & Nombres

            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Maximum = 7
            Do While Fecha <= Me.DTPFechaFin.Value

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////BUSCO LAS RECEPCIONES DE LECHE/////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT  * FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                            "WHERE (Detalle_Compras.Tipo_Compra = 'Recepcion') AND (Compras.Cod_Proveedor = '" & CodProductor & "') AND (Compras.TipoProductor = 'Productor') AND (Compras.Fecha_Compra = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Recepciones")
                iPosicion2 = 0
                Cantidad = 0
                NCompra = 0
                Registros2 = DataSet.Tables("Recepciones").Rows.Count

                Do While iPosicion2 < Registros2
                    Cantidad = Cantidad + DataSet.Tables("Recepciones").Rows(iPosicion2)("Cantidad")
                    NCompra = DataSet.Tables("Recepciones").Rows(iPosicion2)("Numero_Compra")
                    iPosicion2 = iPosicion2 + 1
                Loop
                DataSet.Tables("Recepciones").Clear()

                Contador = Fecha.DayOfWeek

                Select Case Contador
                    Case 1

                        If PLunes > Cantidad Then
                            Cantidad = PLunes - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If





                    Case 2

                        If PMartes > Cantidad Then
                            Cantidad = PMartes - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                    Case 3
                        If PMiercoles > Cantidad Then
                            Cantidad = PMiercoles - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                    Case 4
                        If PJueves > Cantidad Then
                            Cantidad = PJueves - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                    Case 5
                        If PViernes > Cantidad Then
                            Cantidad = PViernes - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                    Case 6
                        If PSabado > Cantidad Then
                            Cantidad = PSabado - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                    Case 0
                        If PDomingo > Cantidad Then
                            Cantidad = PDomingo - Cantidad
                            Monto = Cantidad * PrecioVenta
                            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
                            NumeroCompra = Format(ConsecutivoCompra, "0000#")
                            GrabaEncabezadoComprasPlanilla(NumeroCompra, Fecha, "Recepcion", CodProductor, "01", Nombres, Nombres, Fecha, Monto, Val(0), Val(0), Monto, "Cordobas", "Procesado por la Planilla " & Me.TxtNumNomina.Text)

                            '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////
                            GrabaDetalleCompraSolicitud(NumeroCompra, "001-1", PrecioVenta, 0, PrecioVenta, Monto, Cantidad, "0000", "01/01/1900", "Leche", "Cordobas", Fecha, "Recepcion")
                        End If

                End Select


                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
            Loop




            iPosicion = iPosicion + 1
            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
        Loop





        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////ACTUALIZO LOS ENCABEZADOS DEl TIPO NOMINA//////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [TipoNomina] SET [Activa] = 0 WHERE (CodTipoNomina = '" & CodTipoNomina & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        StrSqlUpdate = "UPDATE [Periodos] SET [Actual] = 0,[Calculada] = 1  WHERE (TipoNomina = '" & CodTipoNomina & "')  AND [NumNomina] = '" & Me.TxtNumNomina.Text & "' "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        SqlString = "SELECT TipoNomina.CodTipoNomina, TipoNomina.TipoNomina, Periodos.Actual, Periodos.Periodo, Periodos.Inicio, Periodos.Final FROM  TipoNomina INNER JOIN Periodos ON TipoNomina.TipoNomina = Periodos.TipoNomina  WHERE(Periodos.Actual = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        Me.CboTipoPlanilla.DataSource = DataSet.Tables("TipoNomina")

        Me.TxtNumNomina.Text = ""

        SqlString = "SELECT * FROM Deducciones_Planilla WHERE (NumNomina = '-1')ORDER BY CodProductor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        Me.BindingDeducciones2.DataSource = DataSet.Tables("Deducciones")
        Me.TDGridDeducciones2.DataSource = Me.BindingDeducciones2
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(1).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Button = True
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(2).Width = 100
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(3).Visible = False
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(4).Width = 156
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(5).Width = 78
        Me.TDGridDeducciones2.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(6).Width = 78
        Me.TDGridDeducciones2.Columns(6).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(7).Width = 78
        Me.TDGridDeducciones2.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(8).Width = 78
        Me.TDGridDeducciones2.Columns(8).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones2.Splits.Item(0).DisplayColumns(9).Width = 78
        Me.TDGridDeducciones2.Columns(9).NumberFormat = "##,##0.00"

        ds.Reset()
        SqlString = "SELECT CodProductor, Nombres, Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Total, PrecioVenta, TotalIngresos, NumNomina, TipoProductor FROM Detalle_Nomina WHERE (NumNomina = '-100000') AND (TipoProductor = 'Productor')"
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
        Me.TDGridIngresos.Splits(0).DisplayColumns("TipoProductor").Visible = False



        SqlString = "SELECT Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.IR,Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor " & _
                    "WHERE (Detalle_Nomina.NumNomina = '-1') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = DataSet.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Width = 70
        Me.TDGridDeducciones.Columns(0).Caption = "Codigo"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(0).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Width = 180
        Me.TDGridDeducciones.Splits(0).DisplayColumns(1).Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(2).Locked = True
        Me.TDGridDeducciones.Columns(2).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(3).Locked = True
        Me.TDGridDeducciones.Columns(3).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Columns(3).Caption = "Policia"
        Me.TDGridDeducciones.Columns(4).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(4).Locked = True
        Me.TDGridDeducciones.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(5).Locked = True
        Me.TDGridDeducciones.Columns(5).Caption = "Transporte"
        Me.TDGridDeducciones.Columns(6).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(6).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(6).Locked = True
        Me.TDGridDeducciones.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(7).Locked = True
        Me.TDGridDeducciones.Columns(8).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(8).Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns(8).Locked = True
        Me.TDGridDeducciones.Columns(8).Caption = "Veterinario"
        Me.TDGridDeducciones.Columns(9).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(9).Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns(9).Locked = True
        Me.TDGridDeducciones.Columns(10).NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Width = 80
        Me.TDGridDeducciones.Splits(0).DisplayColumns(10).Locked = True

        Me.CmdNomina.Enabled = False
        Me.CmdColillas.Enabled = False
        Me.Button2.Enabled = False
        Me.CmdCerrar.Enabled = False
        Me.CboTipoPlanilla.Text = ""

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub TxtNumNomina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumNomina.TextChanged

    End Sub
End Class