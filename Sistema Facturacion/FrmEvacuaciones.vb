Imports System.Data.SqlClient
Public Class FrmEvacuaciones
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public dsFact As New DataSet, daFact As New SqlClient.SqlDataAdapter, CmdBuilderFact As New SqlCommandBuilder
    Public Sub ActualizarGridInsertRowFact()
        Dim SqlCompras As String, TipoFactura As String
        Dim Dias As Double, SQlString As String, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Integer, Registros As Double, j As Double
        Dim Total As Double = 0, FechaConsulta As Date, FechaIni As Date, FechaFin As Date, NumeroContrato As Double, CodigoCliente As String
        Dim Acumulado As Double = 0, Periodo As Double = 0

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////7777BUSCO EL ID DEL CONTRATO PARA CONSULTARLO //////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IdTipoContrato = 0
        SQlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE  (TipoContrato = '" & Me.CmbContrato2.Text & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            IdTipoContrato = DataSet.Tables("TipoContrato").Rows(0)("idTipoContrato")
        End If

        Dias = DateDiff(DateInterval.Day, Me.DtpFechaIniFact.Value, Me.DtpFechaFinFact.Value) + 1



        dsFact.Tables("Facturacion").Clear()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END AS Nombres, Contratos.Contrato_Variable, Contratos.Contrato_Variable2, Clientes.Cod_Cliente AS Acumulado, Clientes.Cod_Cliente AS Periodo, Clientes.Cod_Cliente AS Total, Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.InventarioFisico As Facturar FROM Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato  WHERE (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL)) AND (TipoContrato.idTipoContrato = " & IdTipoContrato & ") OR (TipoContrato_1.idTipoContrato = " & IdTipoContrato & ")"
        daFact = New SqlDataAdapter(SQlString, MiConexion)
        CmdBuilderFact = New SqlCommandBuilder(daFact)
        daFact.Fill(dsFact, "Facturacion")


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////RECORRO EL DATASET PARA LLENARLO //////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Registros = dsFact.Tables("Facturacion").Rows.Count
        j = 0
        FechaIni = Me.DtpFechaIniFact.Value
        FechaFin = Me.DtpFechaFinFact.Value
        Do While Registros > j

            NumeroContrato = dsFact.Tables("Facturacion").Rows(j)("Numero_Contrato")
            CodigoCliente = dsFact.Tables("Facturacion").Rows(j)("Cod_Cliente")
            Total = 0

            '//////////////////////////BUSCOS LAS EVACUACIONES ACUMULADAS ///////////////////////////////////////////////////////////////////
            Acumulado = 0
            SQlString = "SELECT COUNT(Numero_Contrato) AS Cont FROM Registro_Transporte_Detalle WHERE (Fecha_Registro < CONVERT(DATETIME, '" & Format(FechaIni, "yyyy-MM-dd") & "', 102)) AND (Cod_Cliente = '" & CodigoCliente & "') AND (idTipoContrato = " & IdTipoContrato & ") AND (Numero_Contrato = " & NumeroContrato & ") AND (Procesado = 0)"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Acumulado")
            i = 0
            Do While Not DataSet.Tables("Acumulado").Rows.Count > i
                Acumulado = Acumulado + 1
                i = i + 1
            Loop
            DataSet.Tables("Acumulado").Reset()

            Periodo = 0
            'SQlString = "SELECT COUNT(Numero_Contrato) AS Cont FROM Registro_Transporte_Detalle WHERE (Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(FechaIni, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Cod_Cliente = '" & CodigoCliente & "') AND (idTipoContrato = " & IdTipoContrato & ") AND (Numero_Contrato = " & NumeroContrato & ") AND (Procesado = 0)"
            SQlString = "SELECT  Numero_Contrato AS Cont, Fecha_Registro FROM Registro_Transporte_Detalle WHERE  (Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(FechaIni, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Cod_Cliente = '" & CodigoCliente & "') AND (idTipoContrato = " & IdTipoContrato & ") AND (Numero_Contrato = " & NumeroContrato & ") AND (Procesado = 0)"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Periodo")
            i = 0
            Do While DataSet.Tables("Periodo").Rows.Count > i
                Periodo = Periodo + 1
                i = i + 1
            Loop
            DataSet.Tables("Periodo").Reset()



            Total = Acumulado + Periodo

            dsFact.Tables("Facturacion").Rows(j)("Acumulado") = Acumulado
            dsFact.Tables("Facturacion").Rows(j)("Periodo") = Periodo
            dsFact.Tables("Facturacion").Rows(j)("Total") = Total



            j = j + 1
        Loop

        Me.TDGridFacturacion.DataSource = Me.dsFact.Tables("Facturacion")
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Nombres").Width = 200
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Nombres").Locked = True
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Acumulado").Locked = True
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Periodo").Locked = True
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Total").Locked = True
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Numero_Contrato").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Cod_Cliente").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Contrato_Variable").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Contrato_Variable2").Visible = False


    End Sub
    Public Sub ActualizarGridInsertRow()
        Dim SqlCompras As String, TipoFactura As String
        Dim Dias As Double, SQlString As String, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Integer, Registros As Double, j As Double
        Dim Total As Double = 0, FechaConsulta As Date, FechaIni As Date, FechaFin As Date, NumeroContrato As Double, CodigoCliente As String
        Dim Cant As Double = 0

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////7777BUSCO EL ID DEL CONTRATO PARA CONSULTARLO //////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IdTipoContrato = 0
        SQlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE  (TipoContrato = '" & Me.CmbContrato1.Text & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            IdTipoContrato = DataSet.Tables("TipoContrato").Rows(0)("idTipoContrato")
        End If

        'Me.DTPFechaInicio.Value = DateSerial(Now.Year, Now.Month, 1)
        'Me.DTPFechaFin.Value = DateSerial(Now.Year, Now.Month + 1, 0)

        Dias = DateDiff(DateInterval.Day, Me.DTPFechaInicio.Value, Me.DTPFechaFin.Value) + 1

        For i = 1 To Dias

            If i = 1 Then
                SQlString = "SELECT CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END AS Nombres, Contratos.Contrato_Variable, Contratos.Contrato_Variable2, dbo.Clientes.Cod_Cliente As '" & i & "' "
            Else
                SQlString = SQlString & ",dbo.Clientes.Cod_Cliente As  '" & i & "' "
            End If
        Next


        SQlString = SQlString & ",dbo.Clientes.Cod_Cliente As Total, Contratos.Numero_Contrato, Contratos.Cod_Cliente FROM  Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato  WHERE (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL)) AND (TipoContrato.idTipoContrato = " & IdTipoContrato & ") OR (TipoContrato_1.idTipoContrato = " & IdTipoContrato & ")"

        ds.Tables("DetalleRegistros").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlCompras = "SELECT  CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END AS Nombres, Contratos.Contrato_Variable, Contratos.Contrato_Variable2 FROM Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato  " & _
        '             "WHERE (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL))"
        ds = New DataSet
        da = New SqlDataAdapter(SQlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleRegistros")



        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////RECORRO EL DATASET PARA LLENARLO //////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Registros = ds.Tables("DetalleRegistros").Rows.Count
        j = 0
        FechaIni = Me.DTPFechaInicio.Value
        FechaFin = Me.DTPFechaFin.Value
        Do While Registros > j

            NumeroContrato = ds.Tables("DetalleRegistros").Rows(j)("Numero_Contrato")
            CodigoCliente = ds.Tables("DetalleRegistros").Rows(j)("Cod_Cliente")

            Total = 0

            For i = 1 To Dias
                Cant = 0
                FechaConsulta = DateSerial(FechaIni.Year, FechaFin.Month, i)

                SQlString = "SELECT COUNT(Numero_Contrato) AS Cont FROM Registro_Transporte_Detalle WHERE (Fecha_Registro = CONVERT(DATETIME, '" & Format(FechaConsulta, "yyyy-MM-dd") & "', 102)) AND (Cod_Cliente = '" & CodigoCliente & "') AND (idTipoContrato = " & IdTipoContrato & ") AND (Numero_Contrato = " & NumeroContrato & ") AND (Anulado = 0)"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Contador")
                If DataSet.Tables("Contador").Rows.Count <> 0 Then
                    Cant = DataSet.Tables("Contador").Rows(0)("Cont")
                End If
                DataSet.Tables("Contador").Reset()

                ds.Tables("DetalleRegistros").Rows(j)(i.ToString) = Cant
                Total = Total + Cant
            Next
            ds.Tables("DetalleRegistros").Rows(j)("Total") = Total

            j = j + 1
        Loop

        Me.TDGridSolicitud.DataSource = ds.Tables("DetalleRegistros")
        Me.TDGridSolicitud.Splits(0).DisplayColumns(0).Width = 200
        Me.TDGridSolicitud.Splits(0).DisplayColumns("Contrato_Variable").Visible = False
        Me.TDGridSolicitud.Splits(0).DisplayColumns("Contrato_Variable2").Visible = False
        Me.TDGridSolicitud.Splits(0).DisplayColumns("Numero_Contrato").Visible = False
        Me.TDGridSolicitud.Splits(0).DisplayColumns("Cod_Cliente").Visible = False

        For i = 1 To Dias
            Me.TDGridSolicitud.Splits(0).DisplayColumns(i.ToString).Width = 25
            Me.TDGridSolicitud.Splits(0).DisplayColumns("Total").Width = 40
        Next

    End Sub
    Private Sub EvacuacionesAcumuladas(ByVal Fecha As Date, ByVal CodigoCliente As String, ByVal idContrato As Double)

    End Sub


    Private Sub FrmEvacuaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Dias As Double, SQlString As String, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.DTPFechaInicio.Value = DateSerial(Now.Year, Now.Month, 1)
        Me.DTPFechaFin.Value = DateSerial(Now.Year, Now.Month + 1, 0)

        Me.DtpFechaIniFact.Value = DateSerial(Now.Year, Now.Month, 1)
        Me.DtpFechaFinFact.Value = DateSerial(Now.Year, Now.Month + 1, 0)

        Dias = DateDiff(DateInterval.Day, Me.DTPFechaInicio.Value, Me.DTPFechaFin.Value) + 1

        For i = 1 To Dias

            If i = 1 Then
                SQlString = "SELECT Nombre_Cliente, Cod_Cliente As '" & i & "' "
            Else
                SQlString = SQlString & ",Cod_Cliente As  '" & i & "' "
            End If

        Next

        SQlString = SQlString & ",Cod_Cliente As Total FROM Clientes WHERE (Cod_Cliente = '-10000000')"


        ds = New DataSet
        da = New SqlDataAdapter(SQlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleRegistros")
        Me.TDGridSolicitud.DataSource = ds.Tables("DetalleRegistros")
        Me.TDGridSolicitud.Splits(0).DisplayColumns(0).Width = 200

        For i = 1 To Dias
            Me.TDGridSolicitud.Splits(0).DisplayColumns(i.ToString).Width = 25
        Next


        SQlString = "SELECT  DISTINCT   CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN dbo.TipoContrato.TipoContrato ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN TipoContrato_1.TipoContrato  END END AS TipoContrato FROM  Contratos INNER JOIN  Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN   TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato WHERE  (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            Me.CmbContrato1.DataSource = DataSet.Tables("TipoContrato")
            Me.CmbContrato2.DataSource = DataSet.Tables("TipoContrato")
            'Me.CmbContrato1.Items.Add(DataSet.Tables("TipoContrato").Rows(0)("TipoContrato"))
        End If


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////CARGO EL GRID DE FACTURACION DE CONTRATOS /////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQlString = "SELECT CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END AS Nombres, Contratos.Contrato_Variable, Contratos.Contrato_Variable2, Clientes.Cod_Cliente AS Acumulado, Clientes.Cod_Cliente AS Periodo, Clientes.Cod_Cliente AS Total, Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.InventarioFisico As Facturar  FROM Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato  WHERE (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL)) AND (TipoContrato.idTipoContrato = -1000) OR (TipoContrato_1.idTipoContrato = -1000)"
        dsFact = New DataSet
        daFact = New SqlDataAdapter(SQlString, MiConexion)
        CmdBuilderFact = New SqlCommandBuilder(daFact)
        daFact.Fill(dsFact, "Facturacion")
        Me.TDGridFacturacion.DataSource = dsFact.Tables("Facturacion")
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Nombres").Width = 200
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Numero_Contrato").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Cod_Cliente").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Contrato_Variable").Visible = False
        Me.TDGridFacturacion.Splits(0).DisplayColumns("Contrato_Variable2").Visible = False





    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbContrato1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbContrato1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Iposicion As Double

        Iposicion = Me.TDGridSolicitud.Row
        My.Forms.FrmRegistroTransporte.NumeroContrato = Me.TDGridSolicitud.Item(Iposicion)("Numero_Contrato")
        My.Forms.FrmRegistroTransporte.Nuevo = True
        My.Forms.FrmRegistroTransporte.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ActualizarGridInsertRow()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim CodigoCliente As String, SQlstring As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        CodigoCliente = Me.TDGridSolicitud.Columns("Cod_Cliente").Text

        SQlstring = "SELECT  Registro_Transporte_Detalle.Numero_Registro, Registro_Transporte_Detalle.Fecha_Registro, Conductor.Nombre, Conductor.Licencia, Vehiculo.Placa, Vehiculo.Marca, Registro_Transporte_Detalle.Cod_Cliente, Registro_Transporte_Detalle.Id_Conductor, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Activo, Registro_Transporte_Detalle.Anulado, Registro_Transporte_Detalle.Procesado, Registro_Transporte_Detalle.idTipoContrato, Registro_Transporte_Detalle.Numero_Contrato, Conductor.Codigo FROM Registro_Transporte_Detalle LEFT OUTER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo LEFT OUTER JOIN Vehiculo ON Registro_Transporte_Detalle.Id_Vehiculo = Vehiculo.IdVehiculo  " & _
                    "WHERE (Registro_Transporte_Detalle.Cod_Cliente = '" & CodigoCliente & "') AND (Registro_Transporte_Detalle.Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicio.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Registro_Transporte_Detalle.Anulado = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRegistros")

        My.Forms.FrmDetalleEvacuaciones.CodigoCliente = CodigoCliente
        My.Forms.FrmDetalleEvacuaciones.FechaIni = Me.DTPFechaInicio.Value
        My.Forms.FrmDetalleEvacuaciones.FechaFin = Me.DTPFechaFin.Value


        My.Forms.FrmDetalleEvacuaciones.DTPFechaInicio.Value = Me.DTPFechaInicio.Value
        My.Forms.FrmDetalleEvacuaciones.DTPFechaFin.Value = Me.DTPFechaFin.Value
        My.Forms.FrmDetalleEvacuaciones.LblTipoServicio.Text = Me.CmbContrato1.Text
        My.Forms.FrmDetalleEvacuaciones.LblCliente.Text = Me.TDGridSolicitud.Columns("Nombres").Text



        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.DataSource = DataSet.Tables("DetalleRegistros")
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Numero_Registro").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Cod_Cliente").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Id_Conductor").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Id_Vehiculo").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Activo").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Procesado").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Anulado").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("idTipoContrato").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Numero_Contrato").Visible = False
        My.Forms.FrmDetalleEvacuaciones.TDGridSolicitud.Splits(0).DisplayColumns("Codigo").Visible = False
        My.Forms.FrmDetalleEvacuaciones.ShowDialog()

    End Sub


    Private Sub BtnSalirFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirFacturacion.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim objExcel = New Microsoft.Office.Interop.Excel.Application
        Dim SqlDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NombreEmpresa As String, DireccionEmpresa As String, RutaLogo As String, RUC As String
        Dim Dias As Double, i As Double, j As Double, Reg As Double, H As Double, Totales() As Double, Total As Double = 0

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                RUC = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If

        objExcel.Visible = True 'lo hacemos visible
        objExcel.SheetsInNewWorkbook = 1 'decimos cuantas hojas queremos en el nuevo documento
        objExcel.Workbooks.Add() ' añadimos el objeto al workbook

        'objExcel.ActiveSheet.Cells("A1") = "Factura No"


        objExcel.ActiveSheet.Range("A1:G1").Merge()
        objExcel.ActiveSheet.Range("A1").Value = NombreEmpresa
        objExcel.ActiveSheet.Range("A2:G2").Merge()
        objExcel.ActiveSheet.Range("A2").Value = DireccionEmpresa
        objExcel.ActiveSheet.Range("A3:G3").Merge()
        objExcel.ActiveSheet.Range("A3").Value = "DESDE:" & Format(Me.DTPFechaInicio.Value, "dd/MM/yyyy") & " HASTA:" & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy") & " "


        objExcel.ActiveSheet.Range("A5").Value = "Nombre"
        objExcel.ActiveSheet.Range("B5").Value = "1"
        objExcel.ActiveSheet.Range("C5").Value = "2"
        objExcel.ActiveSheet.Range("D5").Value = "3"
        objExcel.ActiveSheet.Range("E5").Value = "4"
        objExcel.ActiveSheet.Range("E5").Value = "5"
        objExcel.ActiveSheet.Range("F5").Value = "6"
        objExcel.ActiveSheet.Range("G5").Value = "7"
        objExcel.ActiveSheet.Range("G5").Value = "8"
        objExcel.ActiveSheet.Range("H5").Value = "9"
        objExcel.ActiveSheet.Range("I5").Value = "10"
        objExcel.ActiveSheet.Range("J5").Value = "11"
        objExcel.ActiveSheet.Range("K5").Value = "12"
        objExcel.ActiveSheet.Range("L5").Value = "13"
        objExcel.ActiveSheet.Range("M5").Value = "14"
        objExcel.ActiveSheet.Range("N5").Value = "15"
        objExcel.ActiveSheet.Range("O5").Value = "16"
        objExcel.ActiveSheet.Range("P5").Value = "17"
        objExcel.ActiveSheet.Range("Q5").Value = "18"
        objExcel.ActiveSheet.Range("R5").Value = "19"
        objExcel.ActiveSheet.Range("S5").Value = "20"
        objExcel.ActiveSheet.Range("T5").Value = "21"
        objExcel.ActiveSheet.Range("U5").Value = "22"
        objExcel.ActiveSheet.Range("V5").Value = "23"
        objExcel.ActiveSheet.Range("W5").Value = "23"
        objExcel.ActiveSheet.Range("X5").Value = "24"
        objExcel.ActiveSheet.Range("Y5").Value = "25"
        objExcel.ActiveSheet.Range("Z5").Value = "26"
        objExcel.ActiveSheet.Range("AA5").Value = "27"
        objExcel.ActiveSheet.Range("AB5").Value = "28"
        objExcel.ActiveSheet.Range("AC5").Value = "29"
        objExcel.ActiveSheet.Range("AD5").Value = "30"
        objExcel.ActiveSheet.Range("AE5").Value = "31"
        objExcel.ActiveSheet.Range("AF5").Value = "Total"

        objExcel.ActiveSheet.Range("A5", "AF5").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        objExcel.ActiveSheet.Range("A5", "AF5").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        objExcel.ActiveSheet.Range("A5", "AF5").Interior.Color = RGB(217, 217, 217)
        objExcel.ActiveSheet.Columns("A").ColumnWidth = 66
        objExcel.ActiveSheet.Columns("B:AE").ColumnWidth = 3.15



        Dias = DateDiff(DateInterval.Day, Me.DTPFechaInicio.Value, Me.DTPFechaFin.Value) + 1
        Reg = ds.Tables("DetalleRegistros").Rows.Count - 1
        ReDim Totales(32)

        For i = 1 To Dias
            Totales(i) = 0
        Next


        H = 6
        j = 0

        For j = 0 To Reg
            H = H + 1


            objExcel.ActiveSheet.Range("A" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("Nombres")
            If Dias >= 1 Then
                objExcel.ActiveSheet.Range("B" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("1")
                Totales(1) = Totales(1) + ds.Tables("DetalleRegistros").Rows(j)("1")
            End If

            If Dias >= 2 Then
                objExcel.ActiveSheet.Range("C" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("2")
                Totales(2) = Totales(2) + ds.Tables("DetalleRegistros").Rows(j)("2")
            End If
            If Dias >= 3 Then
                objExcel.ActiveSheet.Range("D" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("3")
                Totales(3) = Totales(3) + ds.Tables("DetalleRegistros").Rows(j)("3")
            End If
            If Dias >= 4 Then
                objExcel.ActiveSheet.Range("E" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("4")
                Totales(4) = Totales(4) + ds.Tables("DetalleRegistros").Rows(j)("4")
            End If
            If Dias >= 5 Then
                objExcel.ActiveSheet.Range("E" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("5")
                Totales(5) = Totales(5) + ds.Tables("DetalleRegistros").Rows(j)("5")
            End If
            If Dias >= 6 Then
                objExcel.ActiveSheet.Range("F" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("6")
                Totales(6) = Totales(6) + ds.Tables("DetalleRegistros").Rows(j)("6")
            End If
            If Dias >= 7 Then
                objExcel.ActiveSheet.Range("G" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("7")
                Totales(7) = Totales(7) + ds.Tables("DetalleRegistros").Rows(j)("7")
            End If
            If Dias >= 8 Then
                objExcel.ActiveSheet.Range("H" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("8")
                Totales(8) = Totales(8) + ds.Tables("DetalleRegistros").Rows(j)("8")
            End If
            If Dias >= 9 Then
                objExcel.ActiveSheet.Range("I" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("9")
                Totales(9) = Totales(9) + ds.Tables("DetalleRegistros").Rows(j)("9")
            End If
            If Dias >= 10 Then
                objExcel.ActiveSheet.Range("J" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("10")
                Totales(10) = Totales(10) + ds.Tables("DetalleRegistros").Rows(j)("10")
            End If
            If Dias >= 11 Then
                objExcel.ActiveSheet.Range("K" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("11")
                Totales(11) = Totales(11) + ds.Tables("DetalleRegistros").Rows(j)("11")
            End If
            If Dias >= 12 Then
                objExcel.ActiveSheet.Range("L" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("12")
                Totales(12) = Totales(12) + ds.Tables("DetalleRegistros").Rows(j)("12")
            End If
            If Dias >= 13 Then
                objExcel.ActiveSheet.Range("M" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("13")
                Totales(13) = Totales(13) + ds.Tables("DetalleRegistros").Rows(j)("13")
            End If
            If Dias >= 14 Then
                objExcel.ActiveSheet.Range("N" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("14")
                Totales(14) = Totales(14) + ds.Tables("DetalleRegistros").Rows(j)("14")
            End If
            If Dias >= 15 Then
                objExcel.ActiveSheet.Range("O" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("15")
                Totales(15) = Totales(15) + ds.Tables("DetalleRegistros").Rows(j)("15")
            End If
            If Dias >= 16 Then
                objExcel.ActiveSheet.Range("P" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("16")
                Totales(16) = Totales(16) + ds.Tables("DetalleRegistros").Rows(j)("16")
            End If
            If Dias >= 17 Then
                objExcel.ActiveSheet.Range("Q" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("17")
                Totales(17) = Totales(17) + ds.Tables("DetalleRegistros").Rows(j)("17")
            End If
            If Dias >= 18 Then
                objExcel.ActiveSheet.Range("R" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("18")
                Totales(18) = Totales(18) + ds.Tables("DetalleRegistros").Rows(j)("18")
            End If
            If Dias >= 19 Then
                objExcel.ActiveSheet.Range("S" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("19")
                Totales(10) = Totales(19) + ds.Tables("DetalleRegistros").Rows(j)("19")
            End If
            If Dias >= 20 Then
                objExcel.ActiveSheet.Range("T" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("20")
                Totales(20) = Totales(20) + ds.Tables("DetalleRegistros").Rows(j)("20")
            End If
            If Dias >= 21 Then
                objExcel.ActiveSheet.Range("U" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("21")
                Totales(21) = Totales(21) + ds.Tables("DetalleRegistros").Rows(j)("21")
            End If
            If Dias >= 22 Then
                objExcel.ActiveSheet.Range("V" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("22")
                Totales(22) = Totales(22) + ds.Tables("DetalleRegistros").Rows(j)("22")
            End If
            If Dias >= 23 Then
                objExcel.ActiveSheet.Range("W" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("23")
                Totales(23) = CDbl(Totales(23)) + CDbl(ds.Tables("DetalleRegistros").Rows(j)("23"))
            End If
            If Dias >= 24 Then
                objExcel.ActiveSheet.Range("X" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("24")
                Totales(24) = Totales(24) + ds.Tables("DetalleRegistros").Rows(j)("24")
            End If
            If Dias >= 25 Then
                objExcel.ActiveSheet.Range("Y" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("25")
                Totales(25) = Totales(25) + ds.Tables("DetalleRegistros").Rows(j)("25")
            End If
            If Dias >= 26 Then
                objExcel.ActiveSheet.Range("Z" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("26")
                Totales(26) = Totales(26) + ds.Tables("DetalleRegistros").Rows(j)("26")
            End If
            If Dias >= 27 Then
                objExcel.ActiveSheet.Range("AA" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("27")
                Totales(27) = Totales(27) + ds.Tables("DetalleRegistros").Rows(j)("27")
            End If
            If Dias >= 28 Then
                objExcel.ActiveSheet.Range("AB" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("28")
                Totales(28) = Totales(28) + ds.Tables("DetalleRegistros").Rows(j)("28")
            End If
            If Dias >= 29 Then
                objExcel.ActiveSheet.Range("AC" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("29")
                Totales(29) = Totales(29) + ds.Tables("DetalleRegistros").Rows(j)("29")
            End If
            If Dias >= 30 Then
                objExcel.ActiveSheet.Range("AD" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("30")
                Totales(30) = Totales(30) + ds.Tables("DetalleRegistros").Rows(j)("30")
            End If
            If Dias >= 31 Then
                objExcel.ActiveSheet.Range("AE" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("31")
                Totales(31) = Totales(31) + ds.Tables("DetalleRegistros").Rows(j)("31")
            End If
            objExcel.ActiveSheet.Range("AF" & H).Value = ds.Tables("DetalleRegistros").Rows(j)("Total")
            Totales(32) = Totales(32) + ds.Tables("DetalleRegistros").Rows(j)("Total")

            'objExcel.ActiveSheet.Range("A" & i).Value = CodigoProducto
            'objExcel.ActiveSheet.Range("B" & i).Value = DescripcionProducto

        Next


        H = H + 1
        objExcel.ActiveSheet.Range("A" & H, "AF" & H).Font.Bold = True
        objExcel.ActiveSheet.Range("A" & H).Value = "Totales"
        For i = 1 To Dias
            Total = Total + Totales(i)
            objExcel.ActiveSheet.Cells(H, i).Value = Totales(i)
        Next

        objExcel.ActiveSheet.Range("A" & H).Value = "Totales"
        objExcel.ActiveSheet.Range("AF" & H).Value = Total
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.ActualizarGridInsertRowFact()
    End Sub
End Class