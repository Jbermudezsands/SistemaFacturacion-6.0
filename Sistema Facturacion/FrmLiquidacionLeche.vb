Imports System.Data.SqlClient

Public Class FrmPlanillaLiquidacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public dsEgreso As New DataSet, daEgreso As New SqlClient.SqlDataAdapter, CmdBuilderEgreso As New SqlCommandBuilder
    Public Codigo_Proveedor As String, Nombre_Proveedor As String
    Public Sub CargarLiquidacion(ByVal NumeroLiquidacion As String)

        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT  idDetalleLiquidacion, NumeroLiquidacion, Codigo_Productor, Nombre_Productor, Fecha, Cantidad_Enviada, Cantidad_Recibida, Diferencia, Agua, Litros_Agua, Ajuste_Cordobas, TotalLitros, Precio_Unitario, Total_Ingresos FROM DetalleLiquidacionLeche WHERE  (NumeroLiquidacion = '" & NumeroLiquidacion & "')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")
        Me.TDGridIngresos.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Width = 70
        Me.TDGridIngresos.Columns("Codigo_Productor").Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Enviada").Caption = "Cantidad Enviada"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Recibida").Caption = "Cantidad Recibida"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Locked = False
        Me.TDGridIngresos.Columns("Litros_Agua").Caption = "Litros Agua"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Locked = False
        Me.TDGridIngresos.Columns("Ajuste_Cordobas").Caption = "Ajuste Cordobas"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Locked = False
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Locked = False
        Me.TDGridIngresos.Columns("Total_Ingresos").Caption = "Total Ingresos"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Columns("TotalLitros").Caption = "Total Litros"
        Me.TDGridIngresos.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "PrecioUnit"



        SqlString = "SELECT idDetalleLiquidacion, NumeroLiquidacion, Ir, Retencion, Productos_Veterinarios, Bolsa, Anticipos, Reembolso, Pagos_Ant_Retenidos, Total_Deducciones FROM DetalleLiquidacionLeche WHERE (NumeroLiquidacion ='" & NumeroLiquidacion & "')"
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Width = 50
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Width = 70
        Me.TDGridDeducciones.Columns("Retencion").Caption = "Retencion Definitiva"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Retencion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").Width = 70
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").Caption = "Productos Veterinarios"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 70
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").Width = 70
        Me.TDGridDeducciones.Columns("Anticipos").Caption = "Anticipos"
        Me.TDGridDeducciones.Columns("Anticipos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").Width = 70
        Me.TDGridDeducciones.Columns("Reembolso").Caption = "Reembolso"
        Me.TDGridDeducciones.Columns("Reembolso").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").Width = 70
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").Caption = "Pagos Ant Retenidos"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Width = 70
        Me.TDGridDeducciones.Columns("Total_Deducciones").Caption = "Total Deducciones"
        Me.TDGridDeducciones.Columns("Total_Deducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Locked = True


    End Sub




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
        SqlString = "SELECT  idDetalleLiquidacion, NumeroLiquidacion, Codigo_Productor, Nombre_Productor, Fecha, Cantidad_Enviada, Cantidad_Recibida, Diferencia, Agua, Litros_Agua, Ajuste_Cordobas, TotalLitros, Precio_Unitario, Total_Ingresos FROM DetalleLiquidacionLeche WHERE  (NumeroLiquidacion = '" & Me.TxtNumNomina.Text & "')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")

        Me.TDGridIngresos.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Width = 70
        Me.TDGridIngresos.Columns("Codigo_Productor").Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Enviada").Caption = "Cantidad Enviada"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Recibida").Caption = "Cantidad Recibida"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Locked = False
        Me.TDGridIngresos.Columns("Litros_Agua").Caption = "Litros Agua"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Locked = False
        Me.TDGridIngresos.Columns("Ajuste_Cordobas").Caption = "Ajuste Cordobas"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Locked = False
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Locked = False
        Me.TDGridIngresos.Columns("Total_Ingresos").Caption = "Total Ingresos"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Columns("TotalLitros").Caption = "Total Litros"
        Me.TDGridIngresos.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "PrecioUnit"



        SqlString = "SELECT idDetalleLiquidacion, NumeroLiquidacion, Ir, Retencion, Productos_Veterinarios, Bolsa, Anticipos, Reembolso, Pagos_Ant_Retenidos, Total_Deducciones FROM DetalleLiquidacionLeche WHERE (NumeroLiquidacion ='" & Me.TxtNumNomina.Text & "')"
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")

        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Width = 50
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Width = 70
        Me.TDGridDeducciones.Columns("Retencion").Caption = "Retencion Definitiva"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Retencion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").Width = 70
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").Caption = "Productos Veterinarios"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 70
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").Width = 70
        Me.TDGridDeducciones.Columns("Anticipos").Caption = "Anticipos"
        Me.TDGridDeducciones.Columns("Anticipos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").Width = 70
        Me.TDGridDeducciones.Columns("Reembolso").Caption = "Reembolso"
        Me.TDGridDeducciones.Columns("Reembolso").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").Width = 70
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").Caption = "Pagos Ant Retenidos"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Width = 70
        Me.TDGridDeducciones.Columns("Total_Deducciones").Caption = "Total Deducciones"
        Me.TDGridDeducciones.Columns("Total_Deducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Locked = True

    End Sub

    Public Sub InsertarRowGridEgresos()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TDGridDeducciones.Row


        CmdBuilderEgreso.RefreshSchema()
        oTabla = dsEgreso.Tables("DetalleEgresos").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daEgreso.Update(oTabla)
            dsEgreso.Tables("DetalleEgresos").AcceptChanges()
            daEgreso.Update(dsEgreso.Tables("DetalleEgresos"))

            ActualizarGridInsertRowIngresos()

            Me.TDGridDeducciones.Row = iPosicion

        Else
            oTabla = dsEgreso.Tables("DetalleEgresos").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daEgreso.Update(oTabla)
                dsEgreso.Tables("DetalleEgresos").AcceptChanges()
                daEgreso.Update(dsEgreso.Tables("DetalleEgresos"))
            End If
        End If

    End Sub

    Public Sub ActualizarGridInsertRowEgresos()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT  idDetalleLiquidacion, NumeroLiquidacion, Codigo_Productor, Nombre_Productor, Fecha, Cantidad_Enviada, Cantidad_Recibida, Diferencia, Agua, Litros_Agua, Ajuste_Cordobas, TotalLitros, Precio_Unitario, Total_Ingresos FROM DetalleLiquidacionLeche WHERE  (NumeroLiquidacion = '" & Me.TxtNumNomina.Text & "')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")

        Me.TDGridIngresos.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Width = 70
        Me.TDGridIngresos.Columns("Codigo_Productor").Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Enviada").Caption = "Cantidad Enviada"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Recibida").Caption = "Cantidad Recibida"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Locked = False
        Me.TDGridIngresos.Columns("Litros_Agua").Caption = "Litros Agua"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Locked = False
        Me.TDGridIngresos.Columns("Ajuste_Cordobas").Caption = "Ajuste Cordobas"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Locked = False
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Locked = False
        Me.TDGridIngresos.Columns("Total_Ingresos").Caption = "Total Ingresos"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Columns("TotalLitros").Caption = "Total Litros"
        Me.TDGridIngresos.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "PrecioUnit"



        SqlString = "SELECT NumeroLiquidacion, Ir, Retencion, Productos_Veterinarios, Bolsa, Anticipos, Reembolso, Pagos_Ant_Retenidos, Total_Deducciones FROM DetalleLiquidacionLeche WHERE (NumeroLiquidacion ='" & Me.TxtNumNomina.Text & "')"
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Width = 50
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Width = 70
        Me.TDGridDeducciones.Columns("Retencion").Caption = "Retencion Definitiva"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Retencion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").Width = 70
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").Caption = "Productos Veterinarios"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 70
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").Width = 70
        Me.TDGridDeducciones.Columns("Anticipos").Caption = "Anticipos"
        Me.TDGridDeducciones.Columns("Anticipos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").Width = 70
        Me.TDGridDeducciones.Columns("Reembolso").Caption = "Reembolso"
        Me.TDGridDeducciones.Columns("Reembolso").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").Width = 70
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").Caption = "Pagos Ant Retenidos"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Width = 70
        Me.TDGridDeducciones.Columns("Total_Deducciones").Caption = "Total Deducciones"
        Me.TDGridDeducciones.Columns("Total_Deducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Locked = True

    End Sub

    Private Sub TDGridIngresos_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridIngresos.AfterColEdit
        Dim Fecha As Date

        'Fecha = Me.TDGridIngresos.Columns("Fecha").Text

        'If Fecha < Me.DTPFechaIni.Value Then
        '    MsgBox("La Fecha Esta Fuera del Rango", MsgBoxStyle.Critical, "Zeus Facturacion")
        '    Me.TDGridIngresos.Columns("Fecha").Text = Format(Me.DTPFechaIni.Value, "dd/MM/yyyy")
        'ElseIf Fecha > Me.DTPFechaFin.Value Then
        '    MsgBox("La Fecha Esta Fuera del Rango", MsgBoxStyle.Critical, "Zeus Facturacion")
        '    Me.TDGridIngresos.Columns("Fecha").Text = Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
        'End If


    End Sub
    Private Sub TDGridIngresos_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridIngresos.AfterUpdate
        InsertarRowGridIngresos()
    End Sub



    Private Sub TDGridIngresos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridIngresos.AfterColUpdate
        Dim TotalLitros As Double, TotalIngresos As Double, PrecioUnitario As Double, Cantidad_Enviada As Double, Cantidad_Recibida As Double, Diferencia As Double, Litros_Agua As Double, Ajuste_Cordobas As Double, Sabado As Double, Domingo As Double
        Dim Agua As String, Fecha As Date


        If IsNumeric(Me.TDGridIngresos.Columns("Cantidad_Enviada").Text) Then
            Cantidad_Enviada = Me.TDGridIngresos.Columns("Cantidad_Enviada").Text
        Else
            Cantidad_Enviada = 0
        End If

        If IsNumeric(Me.TDGridIngresos.Columns("Cantidad_Recibida").Text) Then
            Cantidad_Recibida = Me.TDGridIngresos.Columns("Cantidad_Recibida").Text
        Else
            Cantidad_Recibida = 0
        End If

        If Me.TDGridIngresos.Columns("Agua").Text <> "" Then
            Agua = Me.TDGridIngresos.Columns("Agua").Text
        Else
            Agua = "0%"
        End If

        If IsNumeric(Me.TDGridIngresos.Columns("Litros_Agua").Text) Then
            Litros_Agua = Me.TDGridIngresos.Columns("Litros_Agua").Text
        Else
            Litros_Agua = 0
        End If

        If IsNumeric(Me.TDGridIngresos.Columns("Ajuste_Cordobas").Text) Then
            Ajuste_Cordobas = Me.TDGridIngresos.Columns("Ajuste_Cordobas").Text
        Else
            Ajuste_Cordobas = 0
        End If

        Diferencia = Cantidad_Enviada - Cantidad_Recibida
        Me.TDGridIngresos.Columns("Diferencia").Text = Diferencia

        TotalLitros = Cantidad_Recibida - Litros_Agua
        Me.TDGridIngresos.Columns("TotalLitros").Text = TotalLitros

        If IsNumeric(Me.TxtPrecioUnitario.Text) Then
            PrecioUnitario = Me.TxtPrecioUnitario.Text
            Me.TDGridIngresos.Columns("Precio_Unitario").Text = Format(PrecioUnitario, "##,##0.00")
        Else
            PrecioUnitario = 0
        End If

        TotalIngresos = (TotalLitros * PrecioUnitario) + Ajuste_Cordobas

        Me.TDGridIngresos.Columns("Total_Ingresos").Text = Format(TotalIngresos, "##,##0.00")
        Me.TDGridIngresos.Columns("NumeroLiquidacion").Text = Me.TxtNumNomina.Text

        Me.TDGridIngresos.Col = 0
        Me.TDGridIngresos.Row = Me.TDGridIngresos.Row + 1

    End Sub

    Private Sub FrmLiquidacionLeche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, SqlConsulta As String = "SELECT Endoso.* FROM Endoso"
        Dim SqlString As String
        Dim NumNomina As String, Año As Double, Mes As Double, Periodo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.CmdNomina.Enabled = False

        SqlString = "SELECT  NominaTransportista.* FROM NominaTransportista  WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If DataSet.Tables("TipoNomina").Rows.Count <> 0 Then
            Me.DTPFechaIni.Value = DataSet.Tables("TipoNomina").Rows(0)("FechaInicial")
            Me.DTPFechaFin.Value = DataSet.Tables("TipoNomina").Rows(0)("FechaFinal")
            'Me.CmdCalcular.Enabled = True

            NumNomina = DataSet.Tables("TipoNomina").Rows(0)("NumPlanilla")
            Año = DataSet.Tables("TipoNomina").Rows(0)("Año")
            Mes = DataSet.Tables("TipoNomina").Rows(0)("mes")
            Periodo = DataSet.Tables("TipoNomina").Rows(0)("Periodo")

            'Me.TxtNumNomina.Text = NumNomina

        Else
            'MsgBox("Se necesitan Nominas Activas para Calcular Planilla de Conductores", MsgBoxStyle.Critical, "Zeus Facturacion")
            'Exit Sub
        End If



        If CodigoClienteNumero = True Then
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
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



        'SqlString = "SELECT  NominaLiquidacion.* FROM NominaLiquidacion  WHERE(Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "NominaLiquidacion")
        'If DataSet.Tables("NominaLiquidacion").Rows.Count <> 0 Then


        '    Me.DTPFechaIni.Value = DataSet.Tables("NominaLiquidacion").Rows(0)("FechaInicial")
        '    Me.DTPFechaFin.Value = DataSet.Tables("NominaLiquidacion").Rows(0)("FechaFinal")
        '    Me.CmdCalcular.Enabled = True

        '    NumNomina = DataSet.Tables("NominaLiquidacion").Rows(0)("NumPlanilla")
        '    Año = DataSet.Tables("NominaLiquidacion").Rows(0)("Año")
        '    Mes = DataSet.Tables("NominaLiquidacion").Rows(0)("mes")
        '    Periodo = DataSet.Tables("NominaLiquidacion").Rows(0)("Periodo")

        '    Me.TxtNumNomina.Text = NumNomina

        'Else
        '    MsgBox("Se necesitan Nominas Activas para Calcular Planilla de Liquidacion", MsgBoxStyle.Critical, "Zeus Facturacion")
        '    Exit Sub
        'End If


        SqlString = "SELECT  idDetalleLiquidacion, NumeroLiquidacion, Codigo_Productor, Nombre_Productor, Fecha, Cantidad_Enviada, Cantidad_Recibida, Diferencia, Agua, Litros_Agua, Ajuste_Cordobas, TotalLitros, Precio_Unitario, Total_Ingresos FROM DetalleLiquidacionLeche WHERE  (NumeroLiquidacion = N'-10000')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")
        Me.TDGridIngresos.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Width = 70
        Me.TDGridIngresos.Columns("Codigo_Productor").Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Enviada").Caption = "Cantidad Enviada"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Recibida").Caption = "Cantidad Recibida"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Locked = False
        Me.TDGridIngresos.Columns("Litros_Agua").Caption = "Litros Agua"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Locked = False
        Me.TDGridIngresos.Columns("Ajuste_Cordobas").Caption = "Ajuste Cordobas"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Locked = False
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Locked = False
        Me.TDGridIngresos.Columns("Total_Ingresos").Caption = "Total Ingresos"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Columns("TotalLitros").Caption = "Total Litros"
        Me.TDGridIngresos.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "PrecioUnit"



        SqlString = "SELECT idDetalleLiquidacion, NumeroLiquidacion, Ir, Retencion, Productos_Veterinarios, Bolsa, Anticipos, Reembolso, Pagos_Ant_Retenidos, Total_Deducciones FROM DetalleLiquidacionLeche WHERE (NumeroLiquidacion = N'-1000')"

        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Width = 50
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Width = 70
        Me.TDGridDeducciones.Columns("Retencion").Caption = "Retencion Definitiva"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Retencion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").Width = 70
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").Caption = "Productos Veterinarios"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 70
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").Width = 70
        Me.TDGridDeducciones.Columns("Anticipos").Caption = "Anticipos"
        Me.TDGridDeducciones.Columns("Anticipos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").Width = 70
        Me.TDGridDeducciones.Columns("Reembolso").Caption = "Reembolso"
        Me.TDGridDeducciones.Columns("Reembolso").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").Width = 70
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").Caption = "Pagos Ant Retenidos"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Width = 70
        Me.TDGridDeducciones.Columns("Total_Deducciones").Caption = "Total Deducciones"
        Me.TDGridDeducciones.Columns("Total_Deducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Locked = True

 


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCalcular.Click
        Dim SqlString As String, iPosicion As Double, Registros As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Fecha As Date, PorcientoPolicia As Double, Reembolso As Double, StrSqlUpdate As String
        Dim iPosicion2 As Double = 0, Registros2 As Double = 0, Contador As Double = 1, PrecioUnitario As Double, PorcientoIr As Double
        Dim Anticipo As Double, PagosRetenidos As Double, idDetalleLiquidacion As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim PorcientoBolsa As Double = 0, MontoBolsa As Double = 0, ProductosVeterinarios As Double = 0, CantLunes As Double = 0, CantMartes As Double = 0, CantMiercoles As Double = 0, CantJueves As Double = 0, CantViernes As Double = 0, CantSabado As Double = 0, CantDomingo As Double = 0
        Dim TotalIngresos As Double, Ir As Double, Bolsa As Double, RetDefitiva As Double, TotalDeducciones As Double = 0



        If Me.CboCodigoCliente.Text = "" Then
            MsgBox("Seleccione un Cliente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Fecha = Me.DTPFechaIni.Value

        PorcientoIr = Val(Me.TxtIR.Text) / 100
        PorcientoBolsa = Val(Me.TxtBolsa.Text) / 100
        PorcientoPolicia = Val(Me.TxtDeduccionPolicia.Text) / 100
        PrecioUnitario = Val(Me.TxtPrecioUnitario.Text)


        iPosicion = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0
        Registros = Me.TDGridIngresos.RowCount
        Me.ProgressBar.Maximum = Registros



        Do While iPosicion < Registros

            TotalIngresos = Me.TDGridIngresos.Item(iPosicion)("Total_Ingresos")
            Ir = TotalIngresos * PorcientoIr
            Bolsa = TotalIngresos * PorcientoBolsa
            RetDefitiva = TotalIngresos * PorcientoPolicia


            idDetalleLiquidacion = Me.TDGridDeducciones.Item(iPosicion)("idDetalleLiquidacion")

            If Me.TDGridDeducciones.Item(iPosicion)("Productos_Veterinarios").ToString <> "" Then
                ProductosVeterinarios = Me.TDGridDeducciones.Item(iPosicion)("Productos_Veterinarios")
            Else
                ProductosVeterinarios = 0
            End If

            If Me.TDGridDeducciones.Item(iPosicion)("Anticipos").ToString <> "" Then
                Anticipo = Me.TDGridDeducciones.Item(iPosicion)("Anticipos")
            Else
                Anticipo = 0
            End If

            If Me.TDGridDeducciones.Item(iPosicion)("Reembolso").ToString <> "" Then
                Reembolso = Me.TDGridDeducciones.Item(iPosicion)("Reembolso")
            Else
                Reembolso = 0
            End If

            If Me.TDGridDeducciones.Item(iPosicion)("Pagos_Ant_Retenidos").ToString <> "" Then
                PagosRetenidos = Me.TDGridDeducciones.Item(iPosicion)("Pagos_Ant_Retenidos")
            Else
                PagosRetenidos = 0
            End If

            TotalDeducciones = Ir + Bolsa + RetDefitiva + ProductosVeterinarios + Anticipo + Reembolso + PagosRetenidos

            Me.TDGridDeducciones.Item(iPosicion)("Total_Deducciones") = Format(TotalDeducciones, "##,##0.00")
            Me.TDGridDeducciones.Item(iPosicion)("Ir") = Format(Ir, "##,##0.00")
            Me.TDGridDeducciones.Item(iPosicion)("Bolsa") = Format(Bolsa, "##,##0.00")
            Me.TDGridDeducciones.Item(iPosicion)("Retencion") = Format(RetDefitiva, "##,##0.00")


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////ACTUALIZO LOS  EGRESOS DE CADA LINEA /////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MiConexion.Close()
            StrSqlUpdate = "UPDATE [DetalleLiquidacionLeche] SET [Ir] = " & Ir & " ,[Retencion] = " & RetDefitiva & " ,[Productos_Veterinarios] = " & ProductosVeterinarios & ",[Bolsa] = " & Bolsa & " ,[Anticipos] = " & Anticipo & " ,[Reembolso] = " & Reembolso & " ,[Pagos_Ant_Retenidos] = " & PagosRetenidos & "  ,[Total_Deducciones] = " & TotalDeducciones & " WHERE(idDetalleLiquidacion = " & idDetalleLiquidacion & ") "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            iPosicion = iPosicion + 1
            Me.ProgressBar.Value = iPosicion
        Loop


        'Me.InsertarRowGridEgresos()

        ds.Tables("DetalleIngresos").Reset()
        SqlString = "SELECT  idDetalleLiquidacion, NumeroLiquidacion, Codigo_Productor, Nombre_Productor, Fecha, Cantidad_Enviada, Cantidad_Recibida, Diferencia, Agua, Litros_Agua, Ajuste_Cordobas, TotalLitros, Precio_Unitario, Total_Ingresos FROM DetalleLiquidacionLeche WHERE  (NumeroLiquidacion = '" & Me.TxtNumNomina.Text & "')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleIngresos")
        Me.TDGridIngresos.DataSource = ds.Tables("DetalleIngresos")

        Me.TDGridIngresos.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Width = 70
        Me.TDGridIngresos.Columns("Codigo_Productor").Caption = "Codigo"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Codigo_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Width = 190
        Me.TDGridIngresos.Splits(0).DisplayColumns("Nombre_Productor").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Fecha").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Enviada").Caption = "Cantidad Enviada"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Enviada").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").Locked = False
        Me.TDGridIngresos.Columns("Cantidad_Recibida").Caption = "Cantidad Recibida"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Cantidad_Recibida").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Diferencia").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Agua").Locked = False
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Litros_Agua").Locked = False
        Me.TDGridIngresos.Columns("Litros_Agua").Caption = "Litros Agua"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").Locked = False
        Me.TDGridIngresos.Columns("Ajuste_Cordobas").Caption = "Ajuste Cordobas"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Ajuste_Cordobas").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Width = 61
        Me.TDGridIngresos.Splits(0).DisplayColumns("TotalLitros").Locked = True
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").Locked = False
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Precio_Unitario").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Width = 70
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").Locked = False
        Me.TDGridIngresos.Columns("Total_Ingresos").Caption = "Total Ingresos"
        Me.TDGridIngresos.Splits(0).DisplayColumns("Total_Ingresos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridIngresos.Columns("TotalLitros").Caption = "Total Litros"
        Me.TDGridIngresos.Columns("Precio_Unitario").NumberFormat = "##,##0.00"
        Me.TDGridIngresos.Columns("Precio_Unitario").Caption = "PrecioUnit"



        SqlString = "SELECT idDetalleLiquidacion, NumeroLiquidacion, Ir, Retencion, Productos_Veterinarios, Bolsa, Anticipos, Reembolso, Pagos_Ant_Retenidos, Total_Deducciones FROM DetalleLiquidacionLeche WHERE (NumeroLiquidacion ='" & Me.TxtNumNomina.Text & "')"
        dsEgreso = New DataSet
        daEgreso = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderEgreso = New SqlCommandBuilder(daEgreso)
        daEgreso.Fill(dsEgreso, "DetalleEgresos")
        Me.TDGridDeducciones.DataSource = dsEgreso.Tables("DetalleEgresos")
        Me.TDGridDeducciones.Splits(0).DisplayColumns("idDetalleLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Width = 50
        Me.TDGridDeducciones.Splits(0).DisplayColumns("NumeroLiquidacion").Visible = False
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Width = 70
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Ir").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Width = 70
        Me.TDGridDeducciones.Columns("Retencion").Caption = "Retencion Definitiva"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Retencion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Retencion").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").Width = 70
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").Caption = "Productos Veterinarios"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Productos_Veterinarios").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Productos_Veterinarios").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Width = 70
        Me.TDGridDeducciones.Columns("Bolsa").Caption = "Bolsa"
        Me.TDGridDeducciones.Columns("Bolsa").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Bolsa").Locked = True
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").Width = 70
        Me.TDGridDeducciones.Columns("Anticipos").Caption = "Anticipos"
        Me.TDGridDeducciones.Columns("Anticipos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Anticipos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").Width = 70
        Me.TDGridDeducciones.Columns("Reembolso").Caption = "Reembolso"
        Me.TDGridDeducciones.Columns("Reembolso").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Reembolso").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").Width = 70
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").Caption = "Pagos Ant Retenidos"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Pagos_Ant_Retenidos").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Columns("Pagos_Ant_Retenidos").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Width = 70
        Me.TDGridDeducciones.Columns("Total_Deducciones").Caption = "Total Deducciones"
        Me.TDGridDeducciones.Columns("Total_Deducciones").NumberFormat = "##,##0.00"
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TDGridDeducciones.Splits(0).DisplayColumns("Total_Deducciones").Locked = True



        Me.CmdNomina.Enabled = True
        Me.Button2.Enabled = True
        Me.CmdCerrar.Enabled = True


    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub GrabaLiquidacionLeche(ByVal NumeroLiquidacion As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlCompras = "SELECT LiquidacionLeche.* FROM LiquidacionLeche WHERE (NumeroLiquidacion = '" & NumeroLiquidacion & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count = 0 Then

            '/////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "INSERT INTO [LiquidacionLeche] ([NumeroLiquidacion],[FechaInicio],[FechaFin],[Cod_Bodega],[Cod_Proveedor],[PorcientoIR],[PorcientoPolicia],[PrecioUnitario],[Activo],[Contabilizado],[Marca],[Bolsa]) " & _
                         "VALUES  ('" & NumeroLiquidacion & "' ,CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) , CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102),'" & Me.CboCodigoBodega.Text & "', '" & Me.CboCodigoCliente.Text & "' ,'" & Me.TxtIR.Text & "' ,'" & Me.TxtDeduccionPolicia.Text & "', '" & Me.TxtPrecioUnitario.Text & "',1,0,1, " & Me.TxtBolsa.Text & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "UPDATE [LiquidacionLeche] SET [FechaInicio] = CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) ,[FechaFin] = CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102) ,[Cod_Bodega] = '" & Me.CboCodigoBodega.Text & "',[Cod_Proveedor] = '" & Me.CboCodigoCliente.Text & "',[PorcientoIR] = '" & Me.TxtIR.Text & "' ,[PorcientoPolicia] = '" & Me.TxtDeduccionPolicia.Text & "',[PrecioUnitario] = '" & Me.TxtPrecioUnitario.Text & "', [Bolsa] = '" & Me.TxtBolsa.Text & "'  WHERE (NumeroLiquidacion = '" & NumeroLiquidacion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim ConsecutivoLiquida As Double = 0, NumeroLiquida As String
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        Me.BtnGenerar.Enabled = False

        codigo_Proveedor = ""
        Nombre_Proveedor = ""





        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumNomina.Text = "-----0-----" Then
            ConsecutivoLiquida = BuscaConsecutivo("LiquidacionLeche")
        Else
            ConsecutivoLiquida = Me.TxtNumNomina.Text
        End If

        NumeroLiquida = Format(ConsecutivoLiquida, "0000#")
        GrabaLiquidacionLeche(NumeroLiquida)

        Me.TxtNumNomina.Text = NumeroLiquida

        Me.TDGridIngresos.AllowAddNew = True

        SqlCompras = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TDGridIngresos.Columns("Codigo_Productor").Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Cliente")
            Me.TDGridIngresos.Columns("Nombre_Productor").Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Cliente")
            Me.TDGridIngresos.Columns("Fecha").Text = Format(Me.DTPFechaIni.Value, "dd/MM/yyyy")
            Me.TDGridIngresos.Columns("Cantidad_Enviada").Text = 0
            Me.TDGridIngresos.Columns("Cantidad_Recibida").Text = 0
            Me.TDGridIngresos.Columns("Diferencia").Text = 0
            Me.TDGridIngresos.Columns("Agua").Text = 0
            Me.TDGridIngresos.Columns("Litros_Agua").Text = 0
            Me.TDGridIngresos.Columns("Ajuste_Cordobas").Text = 0
            Me.TDGridIngresos.Columns("TotalLitros").Text = 0
            Me.TDGridIngresos.Columns("Precio_Unitario").Text = 0
            Me.TDGridIngresos.Columns("Total_Ingresos").Text = 0
        End If


        Me.CmdCalcular.Enabled = True
        Me.CmdNomina.Enabled = True
        Me.CmdCerrar.Enabled = True

        ''//////////////////////////////////////////Grabo el Detalle en Cero /////////////////////
        'SqlCompras = "INSERT INTO [LiquidacionLeche] ([NumeroLiquidacion],[FechaInicio],[FechaFin],[Cod_Bodega],[Cod_Proveedor],[PorcientoIR],[PorcientoPolicia],[PrecioUnitario],[Activo],[Contabilizado],[Marca]) " & _
        '     "VALUES  ('" & NumeroLiquidacion & "' ,CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) , CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102),'" & Me.CboCodigoBodega.Text & "', '" & Me.CboCodigoCliente.Text & "' ,'" & Me.TxtIR.Text & "' ,'" & Me.TxtDeduccionPolicia.Text & "', '" & Me.TxtPrecioUnitario.Text & "',1,0,1)"
        'MiConexion.Open()
        'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        'iResultado = ComandoUpdate.ExecuteNonQuery
        'MiConexion.Close()

    End Sub

    Private Sub TDGridIngresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridIngresos.Click

    End Sub

    Private Sub TDGridIngresos_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDGridIngresos.BeforeUpdate
        Dim SqlCompras As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlCompras = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TDGridIngresos.Columns("Codigo_Productor").Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Proveedor")
            Me.TDGridIngresos.Columns("Nombre_Productor").Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
        End If

        If Me.TDGridIngresos.Columns("Fecha").Text = "" Then
            Me.TDGridIngresos.Columns("Fecha").Text = Format(Now, "dd/MM/yyyy")
        End If

        If Me.TDGridIngresos.Columns("Cantidad_Enviada").Text = "" Then
            Me.TDGridIngresos.Columns("Cantidad_Enviada").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Cantidad_Recibida").Text = "" Then
            Me.TDGridIngresos.Columns("Cantidad_Recibida").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Diferencia").Text = "" Then
            Me.TDGridIngresos.Columns("Diferencia").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Agua").Text = "" Then
            Me.TDGridIngresos.Columns("Agua").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Litros_Agua").Text = "" Then
            Me.TDGridIngresos.Columns("Litros_Agua").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Ajuste_Cordobas").Text = "" Then
            Me.TDGridIngresos.Columns("Ajuste_Cordobas").Text = 0
        End If

        If Me.TDGridIngresos.Columns("TotalLitros").Text = "" Then
            Me.TDGridIngresos.Columns("TotalLitros").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Precio_Unitario").Text = "" Then
            Me.TDGridIngresos.Columns("Precio_Unitario").Text = 0
        End If

        If Me.TDGridIngresos.Columns("Total_Ingresos").Text = "" Then
            Me.TDGridIngresos.Columns("Total_Ingresos").Text = 0
        End If


    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Numero_Liquidacion As String = "", SqlCompras As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        Quien = "LiquidacionLeche"
        My.Forms.FrmConsultas.ShowDialog()
        Numero_Liquidacion = My.Forms.FrmConsultas.Codigo
        Me.TxtNumNomina.Text = Numero_Liquidacion
        Me.CargarLiquidacion(Numero_Liquidacion)

        '/////////////////////////////////////////////BUSCO LA LIQUIDACION PARA CARGAR LOS DATOS DE ENCABEZADO ///////////////////////////////////////////
        SqlCompras = "SELECT NumeroLiquidacion, FechaInicio, FechaFin, Cod_Bodega, Cod_Proveedor, Bolsa, PorcientoIR, PorcientoPolicia, PrecioUnitario, Activo, Contabilizado, Marca  FROM LiquidacionLeche  WHERE  (NumeroLiquidacion = '" & Numero_Liquidacion & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "LiquiacionLeche")
        If Not DataSet.Tables("LiquiacionLeche").Rows.Count = 0 Then
            'Me.CboCodigoBodega.Text = DataSet.Tables("LiquidacionLeche").Rows(0)("Cod_Bodega")
            'Me.DTPFechaIni.Value = DataSet.Tables("LiquidacionLeche").Rows(0)("FechaInicio")
            'Me.DTPFechaFin.Value = DataSet.Tables("LiquidacionLeche").Rows(0)("FechaFin")
            'Me.CboCodigoCliente.Text = DataSet.Tables("LiquidacionLeche").Rows(0)("Cod_Proveedor")
            'Me.TxtIR.Text = DataSet.Tables("LiquidacionLeche").Rows(0)("PorcientoIR")
            'Me.TxtBolsa.Text = DataSet.Tables("LiquidacionLeche").Rows(0)("Bolsa")


        End If

        Me.BtnGenerar.Enabled = False
        Me.CmdCalcular.Enabled = True
        Me.CmdNomina.Enabled = False
        Me.CmdCerrar.Enabled = False

    End Sub

    Private Sub TDGridDeducciones_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridDeducciones.AfterColEdit
        Dim TotalIngresos As Double, Ir As Double, Bolsa As Double, RetDefitiva As Double, TotalDeducciones As Double = 0
        Dim ProductosVeterinarios As Double = 0, Anticipo As Double = 0, Reembolso As Double, PagosRetenidos As Double
        Dim iPosicion As Double

        iPosicion = Me.TDGridDeducciones.Row

        If Me.TDGridDeducciones.Item(iPosicion)("Productos_Veterinarios").ToString <> "" Then
            ProductosVeterinarios = Me.TDGridDeducciones.Item(iPosicion)("Productos_Veterinarios")
        Else
            ProductosVeterinarios = 0
        End If

        If Me.TDGridDeducciones.Item(iPosicion)("Anticipos").ToString <> "" Then
            Anticipo = Me.TDGridDeducciones.Item(iPosicion)("Anticipos")
        Else
            Anticipo = 0
        End If

        If Me.TDGridDeducciones.Item(iPosicion)("Reembolso").ToString <> "" Then
            Reembolso = Me.TDGridDeducciones.Item(iPosicion)("Reembolso")
        Else
            Reembolso = 0
        End If

        If Me.TDGridDeducciones.Item(iPosicion)("Pagos_Ant_Retenidos").ToString <> "" Then
            PagosRetenidos = Me.TDGridDeducciones.Item(iPosicion)("Pagos_Ant_Retenidos")
        Else
            PagosRetenidos = 0
        End If

        TotalDeducciones = Ir + Bolsa + RetDefitiva + ProductosVeterinarios + Anticipo + Reembolso + PagosRetenidos

        Me.TDGridDeducciones.Item(iPosicion)("Total_Deducciones") = Format(TotalDeducciones, "##,##0.00")



    End Sub

    Private Sub TDGridDeducciones_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridDeducciones.AfterUpdate
        Me.InsertarRowGridEgresos()
    End Sub

    Private Sub TDGridDeducciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridDeducciones.Click



    End Sub

    Private Sub TxtNumNomina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumNomina.TextChanged

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.TxtNumNomina.Text = "-----0-----"
        Me.CargarLiquidacion(Me.TxtNumNomina.Text)

        Me.BtnGenerar.Enabled = True
        Me.CmdNomina.Enabled = False
        Me.CmdCerrar.Enabled = False
        Me.CmdCalcular.Enabled = False

    End Sub

    Private Sub TDGridIngresos_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridIngresos.BackColorChanged

    End Sub

    Private Sub CmdNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNomina.Click
        Dim SQLString As String, ArepLiquidacionLeche As New ArepLiquidacionLeche, SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim SqlDatos As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, RutaLogo As String



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO LOS DATOS DE LA EMPRESA/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepLiquidacionLeche.LblTitulo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepLiquidacionLeche.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepLiquidacionLeche.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepLiquidacionLeche.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        SQLString = "SELECT  LiquidacionLeche.NumeroLiquidacion, LiquidacionLeche.FechaInicio, LiquidacionLeche.FechaFin, LiquidacionLeche.Cod_Bodega, LiquidacionLeche.Cod_Proveedor, LiquidacionLeche.PorcientoIR, LiquidacionLeche.PorcientoPolicia, LiquidacionLeche.PrecioUnitario, LiquidacionLeche.Activo, LiquidacionLeche.Contabilizado, LiquidacionLeche.Marca, LiquidacionLeche.Bolsa, DetalleLiquidacionLeche.idDetalleLiquidacion, DetalleLiquidacionLeche.NumeroLiquidacion AS Expr1, DetalleLiquidacionLeche.Codigo_Productor, DetalleLiquidacionLeche.Nombre_Productor, DetalleLiquidacionLeche.Fecha, DetalleLiquidacionLeche.Cantidad_Enviada, DetalleLiquidacionLeche.Cantidad_Recibida, DetalleLiquidacionLeche.Diferencia, DetalleLiquidacionLeche.Agua, DetalleLiquidacionLeche.Litros_Agua, DetalleLiquidacionLeche.Ajuste_Cordobas, DetalleLiquidacionLeche.TotalLitros, DetalleLiquidacionLeche.Precio_Unitario, DetalleLiquidacionLeche.Total_Ingresos, DetalleLiquidacionLeche.Enfriamiento, DetalleLiquidacionLeche.Transporte, DetalleLiquidacionLeche.Ir, DetalleLiquidacionLeche.Retencion, DetalleLiquidacionLeche.Productos_Veterinarios, DetalleLiquidacionLeche.Bolsa AS BolsaD, DetalleLiquidacionLeche.Anticipos, DetalleLiquidacionLeche.Reembolso, DetalleLiquidacionLeche.Pagos_Ant_Retenidos, DetalleLiquidacionLeche.Total_Deducciones, DetalleLiquidacionLeche.Total_Ingresos - DetalleLiquidacionLeche.Total_Deducciones AS NetoPagar  FROM  LiquidacionLeche INNER JOIN DetalleLiquidacionLeche ON LiquidacionLeche.NumeroLiquidacion = DetalleLiquidacionLeche.NumeroLiquidacion  " & _
                    "WHERE (LiquidacionLeche.NumeroLiquidacion = '" & Me.TxtNumNomina.Text & "')"
        SQL.ConnectionString = Conexion
        Sql.SQL = SQLString
        ArepLiquidacionLeche.DataSource = SQL
        ArepLiquidacionLeche.Document.Name = "Reporte de Liquidacion"

        Dim ViewerForm As New FrmViewer()

        ViewerForm.arvMain.Document = ArepLiquidacionLeche.Document
        ViewerForm.Show()
        ArepLiquidacionLeche.Run(True)
    End Sub
End Class