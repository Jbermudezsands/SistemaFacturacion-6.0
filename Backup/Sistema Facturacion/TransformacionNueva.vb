Imports System.Data.SqlClient
Imports System.Threading
Imports System.Math

Public Class TransformacionNueva
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public dsOrigen As New DataSet, daOrigen As New SqlClient.SqlDataAdapter, CmdBuilderOrigen As New SqlCommandBuilder
    Public dsDestino As New DataSet, daDestino As New SqlClient.SqlDataAdapter, CmdBuilderDestino As New SqlCommandBuilder
    Public Nuevo As Boolean = False



    Public Sub InsertarRowGridOrigen()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridOrigen.Row
        CodigoProducto = Me.TrueDBGridOrigen.Columns(3).Text

        CmdBuilderOrigen.RefreshSchema()
        oTabla = dsOrigen.Tables("DetalleOrigen").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daOrigen.Update(oTabla)
            dsOrigen.Tables("DetalleOrigen").AcceptChanges()
            daOrigen.Update(dsOrigen.Tables("DetalleOrigen"))

            Me.TrueDBGridOrigen.Row = iPosicion

        Else
            oTabla = dsOrigen.Tables("DetalleOrigen").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daOrigen.Update(oTabla)
                dsOrigen.Tables("DetalleOrigen").AcceptChanges()
                daOrigen.Update(dsOrigen.Tables("DetalleOrigen"))
            End If
        End If

        ActualizarGridInsertRowOrigen()

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Se agrego Producto: " & CodigoProducto & " Transformacion No." & Me.TxtNumeroEnsamble.Text)
    End Sub

    Public Sub ActualizarGridInsertRowOrigen()
        Dim SqlString As String

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad, Merma, Basura, Porciento_Basura , Porciento_Merma  FROM Detalle_Transformacion " & _
                    "WHERE (Numero_Transforma = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoTransforma = 'Origen')"
        dsOrigen = New DataSet
        daOrigen = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderOrigen = New SqlCommandBuilder(daOrigen)
        daOrigen.Fill(dsOrigen, "DetalleOrigen")
        Me.BindingDetalleOrigen.DataSource = dsOrigen.Tables("DetalleOrigen")
        Me.TrueDBGridOrigen.DataSource = Me.BindingDetalleOrigen
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        Me.TrueDBGridOrigen.Columns("Codigo_Producto").Caption = "Codigo"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        Me.TrueDBGridOrigen.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 215
        Me.TrueDBGridOrigen.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Merma").Width = 45
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Basura").Width = 45
        Me.TrueDBGridOrigen.Columns("Porciento_Basura").Caption = "%Bas"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Porciento_Basura").Width = 40
        Me.TrueDBGridOrigen.Columns("Porciento_Merma").Caption = "%Mer"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Porciento_Merma").Width = 40
        Me.TrueDBGridOrigen.Columns("Porciento_Merma").NumberFormat = "0.00%"
        Me.TrueDBGridOrigen.Columns("Porciento_Basura").NumberFormat = "0.00%"

    End Sub

    Public Sub InsertarRowGridDestino()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridDestino.Row
        CodigoProducto = Me.TrueDBGridDestino.Columns("Codigo_Producto").Text

        CmdBuilderDestino.RefreshSchema()
        oTabla = dsDestino.Tables("DetalleDestino").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daDestino.Update(oTabla)
            dsDestino.Tables("DetalleDestino").AcceptChanges()
            daDestino.Update(dsDestino.Tables("DetalleDestino"))
            Me.TrueDBGridDestino.Row = iPosicion

        Else
            oTabla = dsDestino.Tables("DetalleDestino").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daDestino.Update(oTabla)
                dsDestino.Tables("DetalleDestino").AcceptChanges()
                daDestino.Update(dsDestino.Tables("DetalleDestino"))
            End If
        End If

        ActualizarGridInsertRowDestino()

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Se agrego Producto: " & CodigoProducto & " Transformacion No." & Me.TxtNumeroEnsamble.Text)
    End Sub


    Public Sub ActualizarGridInsertRowDestino()
        Dim SqlString As String

        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad ,Merma, Basura, Porciento_Basura , Porciento_Merma FROM Detalle_Transformacion " & _
                    "WHERE (Numero_Transforma = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoTransforma = 'Destino')"
        dsDestino = New DataSet
        daDestino = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderDestino = New SqlCommandBuilder(daDestino)
        daDestino.Fill(dsDestino, "DetalleDestino")
        Me.BindingDetalleDestino.DataSource = dsDestino.Tables("DetalleDestino")
        Me.TrueDBGridDestino.DataSource = Me.BindingDetalleDestino
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        Me.TrueDBGridDestino.Columns("Codigo_Producto").Caption = "Codigo"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        Me.TrueDBGridDestino.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 215
        Me.TrueDBGridDestino.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Merma").Width = 45
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Basura").Width = 45
        Me.TrueDBGridDestino.Columns("Porciento_Basura").Caption = "%Bas"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Porciento_Basura").Width = 40
        Me.TrueDBGridDestino.Columns("Porciento_Merma").Caption = "%Mer"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Porciento_Merma").Width = 40
        Me.TrueDBGridDestino.Columns("Porciento_Merma").NumberFormat = "0.00%"
        Me.TrueDBGridDestino.Columns("Porciento_Basura").NumberFormat = "0.00%"


    End Sub
    Private Sub TransformacionNueva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        If Nuevo = True Then
            LimpiarPantalla()

        Else
            CargarPantalla()
        End If




        'Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim Procesado As Boolean = True, SqlDatos As String

        'Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        'Me.TxtNumeroEnsamble.Text = "-----0-----"


        ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT  * FROM   Bodegas"
        'MiConexion.Open()
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Bodegas")
        'Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        'If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
        '    Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")

        'End If
        'Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        'Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


        'SqlString = "SELECT  * FROM   Bodegas"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Bodegas2")
        'Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas2")
        'If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
        '    Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
        'End If
        'Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        'Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
        'MiConexion.Close()



        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Origen')"
        'dsOrigen = New DataSet
        'daOrigen = New SqlDataAdapter(SqlString, MiConexion)
        'CmdBuilderOrigen = New SqlCommandBuilder(daOrigen)
        'daOrigen.Fill(dsOrigen, "DetalleOrigen")
        'Me.BindingDetalleOrigen.DataSource = dsOrigen.Tables("DetalleOrigen")
        'Me.TrueDBGridOrigen.DataSource = Me.BindingDetalleOrigen
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        'Me.TrueDBGridOrigen.Columns("Codigo_Producto").Caption = "Codigo"
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        'Me.TrueDBGridOrigen.Columns("Descripcion_Producto").Caption = "Descripcion"
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        'Me.TrueDBGridOrigen.Columns("Cantidad").Caption = "Cantidad"
        'Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Cantidad").Width = 64


        'SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Destino')"
        'dsDestino = New DataSet
        'daDestino = New SqlDataAdapter(SqlString, MiConexion)
        'CmdBuilderDestino = New SqlCommandBuilder(daDestino)
        'daDestino.Fill(dsDestino, "DetalleDestino")
        'Me.BindingDetalleDestino.DataSource = dsDestino.Tables("DetalleDestino")
        'Me.TrueDBGridDestino.DataSource = Me.BindingDetalleDestino
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        'Me.TrueDBGridDestino.Columns("Codigo_Producto").Caption = "Codigo"
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        'Me.TrueDBGridDestino.Columns("Descripcion_Producto").Caption = "Descripcion"
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        'Me.TrueDBGridDestino.Columns("Cantidad").Caption = "Cantidad"
        'Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Cantidad").Width = 64


    End Sub
    Public Sub CargarPantalla()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Procesado As Boolean = True, SqlDatos As String


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


        SqlString = "SELECT  * FROM   Bodegas"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas2")
        Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas2")
        If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
            Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"



        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7/
        '///////////////////////////////////////////////////////CREO UNA CONSULTA PARA CARGAR LA TRASFORMACION ////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Transformacion.* FROM Transformacion WHERE (Numero_Transforma = '" & Me.TxtNumeroEnsamble.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Transformacion")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Transformacion")
        If Not DataSet.Tables("Transformacion").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Transformacion").Rows(0)("BodegaOrigen")
            Me.CboCodigoBodega2.Text = DataSet.Tables("Transformacion").Rows(0)("BodegaDestino")
            Me.DTPFecha.Value = DataSet.Tables("Transformacion").Rows(0)("Fecha_Transforma")
            Me.TxtObservaciones.Text = DataSet.Tables("Transformacion").Rows(0)("Observaciones")

            ActualizarGridInsertRowOrigen()
            ActualizarGridInsertRowDestino()

        End If


        MiConexion.Close()
    End Sub


    Public Sub LimpiarPantalla()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Procesado As Boolean = True, SqlDatos As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtObservaciones.Text = ""

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


        SqlString = "SELECT  * FROM   Bodegas"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas2")
        Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas2")
        If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
            Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
        MiConexion.Close()




        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad, Merma, Basura, Porciento_Basura, Porciento_Merma  FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Origen')"
        dsOrigen = New DataSet
        daOrigen = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderOrigen = New SqlCommandBuilder(daOrigen)
        daOrigen.Fill(dsOrigen, "DetalleOrigen")
        Me.BindingDetalleOrigen.DataSource = dsOrigen.Tables("DetalleOrigen")
        Me.TrueDBGridOrigen.DataSource = Me.BindingDetalleOrigen
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        Me.TrueDBGridOrigen.Columns("Codigo_Producto").Caption = "Codigo"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        Me.TrueDBGridOrigen.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 215
        Me.TrueDBGridOrigen.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Merma").Width = 45
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Basura").Width = 45
        Me.TrueDBGridOrigen.Columns("Porciento_Basura").Caption = "%Bas"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Porciento_Basura").Width = 40
        Me.TrueDBGridOrigen.Columns("Porciento_Merma").Caption = "%Mer"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Porciento_Merma").Width = 40
        Me.TrueDBGridOrigen.Columns("Porciento_Merma").NumberFormat = "0.00%"
        Me.TrueDBGridOrigen.Columns("Porciento_Basura").NumberFormat = "0.00%"


        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad, Merma, Basura, Porciento_Basura , Porciento_Merma  FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Destino')"
        dsDestino = New DataSet
        daDestino = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilderDestino = New SqlCommandBuilder(daDestino)
        daDestino.Fill(dsDestino, "DetalleDestino")
        Me.BindingDetalleDestino.DataSource = dsDestino.Tables("DetalleDestino")
        Me.TrueDBGridDestino.DataSource = Me.BindingDetalleDestino
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("IdDetalleOrigen").Visible = False
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("TipoTransforma").Visible = False
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Numero_Transforma").Visible = False
        Me.TrueDBGridDestino.Columns("Codigo_Producto").Caption = "Codigo"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Button = True
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Codigo_Producto").Width = 74
        Me.TrueDBGridDestino.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 215
        Me.TrueDBGridDestino.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Merma").Width = 45
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Basura").Width = 45
        Me.TrueDBGridDestino.Columns("Porciento_Basura").Caption = "%Bas"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Porciento_Basura").Width = 40
        Me.TrueDBGridDestino.Columns("Porciento_Merma").Caption = "%Mer"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Porciento_Merma").Width = 40
        Me.TrueDBGridDestino.Columns("Porciento_Merma").NumberFormat = "0.00%"
        Me.TrueDBGridDestino.Columns("Porciento_Basura").NumberFormat = "0.00%"


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////DATOS POR DEFECTO //////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        If UsuarioBodegaCompra <> "" Then
            Me.CboCodigoBodega.Text = UsuarioBodegaCompra
            Me.CboCodigoBodega2.Text = UsuarioBodegaCompra
        End If

    End Sub

    Private Sub TrueDBGridOrigen_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridOrigen.AfterColUpdate



    End Sub


    Private Sub TrueDBGridOrigen_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridOrigen.AfterUpdate

        InsertarRowGridOrigen()

        Me.TrueDBGridOrigen.Col = 3
        'Me.TrueDBGridOrigen.Row = Me.TrueDBGridOrigen.Row + 1

    End Sub
    Private Sub TrueDBGridDestino_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridDestino.AfterUpdate

        InsertarRowGridDestino()

        Me.TrueDBGridDestino.Col = 3
        'Me.TrueDBGridDestino.Row = Me.TrueDBGridDestino.Row + 1
    End Sub

    Private Sub TrueDBGridOrigen_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridOrigen.BeforeColUpdate
        Dim CantMerma As Double, CantBasura As Double, CantTotal As Double, PBasura As Double, PMerma As Double

        CantTotal = 0
        If Me.TrueDBGridOrigen.Columns("Cantidad").Text <> "" Then
            CantTotal = Me.TrueDBGridOrigen.Columns("Cantidad").Text
        End If

        CantMerma = 0
        If Me.TrueDBGridOrigen.Columns("Merma").Text <> "" Then
            CantMerma = Me.TrueDBGridOrigen.Columns("Merma").Text
        End If

        CantBasura = 0
        If Me.TrueDBGridOrigen.Columns("Basura").Text <> "" Then
            CantBasura = Me.TrueDBGridOrigen.Columns("Basura").Text
        End If


        PBasura = CantBasura / CantTotal
        PMerma = CantMerma / CantTotal

        Me.TrueDBGridOrigen.Columns("Porciento_Basura").Text = PBasura
        Me.TrueDBGridOrigen.Columns("Porciento_Merma").Text = PMerma
    End Sub

    Private Sub TrueDBGridOrigen_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridOrigen.BeforeUpdate
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroCompra As String



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            ConsecutivoCompra = BuscaConsecutivo("Transforma")
            NumeroCompra = Format(ConsecutivoCompra, "0000#")
            Me.TxtNumeroEnsamble.Text = NumeroCompra

        Else
            'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If

        If Me.TrueDBGridOrigen.Columns("Cantidad").Text = "" Then
            Me.TrueDBGridOrigen.Columns("Cantidad").Text = 0
        Else
            Me.TrueDBGridOrigen.Columns("Cantidad").Text = Abs(CDbl(Me.TrueDBGridOrigen.Columns("Cantidad").Text))
        End If

        If Me.TrueDBGridOrigen.Columns("Merma").Text = "" Then
            Me.TrueDBGridOrigen.Columns("Merma").Text = 0
        Else
            Me.TrueDBGridOrigen.Columns("Merma").Text = Abs(CDbl(Me.TrueDBGridOrigen.Columns("Merma").Text))
        End If

        If Me.TrueDBGridOrigen.Columns("Basura").Text = "" Then
            Me.TrueDBGridOrigen.Columns("Basura").Text = 0
        Else
            Me.TrueDBGridOrigen.Columns("Basura").Text = Abs(CDbl(Me.TrueDBGridOrigen.Columns("Basura").Text))
        End If

        If Me.TrueDBGridOrigen.Columns("Porciento_Merma").Text = "" Then
            Me.TrueDBGridOrigen.Columns("Porciento_Merma").Text = 0
        Else
            'Me.TrueDBGridOrigen.Columns("Porciento_Merma").Text = Abs(CDbl(Me.TrueDBGridOrigen.Columns("Porciento_Merma").Text))
        End If

        If Me.TrueDBGridOrigen.Columns("Porciento_Basura").Text = "" Then
            Me.TrueDBGridOrigen.Columns("Porciento_Basura").Text = 0
        Else
            'Me.TrueDBGridOrigen.Columns("Porciento_Basura").Text = Abs(CDbl(Me.TrueDBGridOrigen.Columns("Porciento_Basura").Text))
        End If

        Me.TrueDBGridOrigen.Columns("TipoTransforma").Text = "Origen"
        Me.TrueDBGridOrigen.Columns("Numero_Transforma").Text = NumeroCompra

        GrabaTransformacion(NumeroCompra, Me.DTPFecha.Value, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text, Me.TxtObservaciones.Text)


    End Sub

    Public Sub GrabaTransformacion(ByVal NumeroTransforma As String, ByVal FechaTransforma As Date, ByVal BodegaOrigen As String, ByVal BodegaDestino As String, ByVal Observaciones As String)
        Dim SqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SqlString As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT  Numero_Transforma, Fecha_Transforma, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion  " & _
                    "WHERE  (Numero_Transforma = '" & NumeroTransforma & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Transformacion")
        If DataSet.Tables("Transformacion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlUpdate = "INSERT INTO [Transformacion] ([Numero_Transforma],[Fecha_Transforma],[BodegaOrigen],[BodegaDestino],[Observaciones],[Activo],[Procesado],[Anulado]) " & _
                        "VALUES ('" & NumeroTransforma & "' ,CONVERT(DATETIME, '" & Format(FechaTransforma, "yyyy-MM-dd") & "', 102), '" & BodegaOrigen & "' ,'" & BodegaDestino & "','" & Observaciones & "',1 ,0,0)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlUpdate = "UPDATE [Transformacion]  SET [Fecha_Transforma] = CONVERT(DATETIME, '" & Format(FechaTransforma, "yyyy-MM-dd") & "', 102) ,[BodegaOrigen] = '" & BodegaOrigen & "' ,[BodegaDestino] = '" & BodegaDestino & "' ,[Observaciones] = '" & Observaciones & "' ,[Activo] = 1 ,[Procesado] = 0 ,[Anulado] = 0 " & _
                        "WHERE  (Numero_Transforma = '" & NumeroTransforma & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If
    End Sub


    Private Sub TrueDBGridOrigen_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridOrigen.ButtonClick
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, CodigoProducto As String

        Quien = "CodigoProductosBodega"
        My.Forms.FrmConsultas.CodBodega = Me.CboCodigoBodega.Text
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TrueDBGridOrigen.Columns("Codigo_Producto").Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridOrigen.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
            CodigoProducto = My.Forms.FrmConsultas.Codigo



        End If
    End Sub

    Private Sub TrueDBGridDestino_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridDestino.BeforeColUpdate
        Dim CantMerma As Double, CantBasura As Double, CantTotal As Double, PBasura As Double, PMerma As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, CodigoProducto As String

        CantTotal = 0
        If Me.TrueDBGridDestino.Columns("Cantidad").Text <> "" Then
            CantTotal = Me.TrueDBGridDestino.Columns("Cantidad").Text
        End If

        CantMerma = 0
        If Me.TrueDBGridDestino.Columns("Merma").Text <> "" Then
            CantMerma = Me.TrueDBGridDestino.Columns("Merma").Text
        End If

        CantBasura = 0
        If Me.TrueDBGridDestino.Columns("Basura").Text <> "" Then
            CantBasura = Me.TrueDBGridDestino.Columns("Basura").Text
        End If


        If CantMerma = 0 Then
            If CantBasura = 0 Then
                CodigoProducto = Me.TrueDBGridDestino.Columns("Codigo_Producto").Text
                SqlString = "SELECT  * FROM Productos  " & _
                "WHERE  (Cod_Productos = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Producto")
                If DataSet.Tables("Producto").Rows.Count <> 0 Then
                    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Merma")) Then
                        PMerma = DataSet.Tables("Producto").Rows(0)("Merma")
                    Else
                        PMerma = 0
                    End If

                    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Desperdicio")) Then
                        PBasura = DataSet.Tables("Producto").Rows(0)("Desperdicio")
                    Else
                        PBasura = 0
                    End If
                End If

                Me.TrueDBGridDestino.Columns("Porciento_Basura").Text = PBasura
                Me.TrueDBGridDestino.Columns("Porciento_Merma").Text = PMerma

                CantMerma = Format(CantTotal * PMerma, "##,##0.0000")
                CantBasura = Format(CantTotal * PBasura, "##,##0.0000")

                Me.TrueDBGridDestino.Columns("Merma").Text = Format(CantMerma, "##,##0.0000")
                Me.TrueDBGridDestino.Columns("Basura").Text = Format(CantBasura, "##,##0.0000")

            End If
        End If



        PBasura = CantBasura / CantTotal
        PMerma = CantMerma / CantTotal

        Me.TrueDBGridDestino.Columns("Porciento_Basura").Text = PBasura
        Me.TrueDBGridDestino.Columns("Porciento_Merma").Text = PMerma


    End Sub

    Private Sub TrueDBGridDestino_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridDestino.BeforeUpdate
        Dim ConsecutivoCompra As Double, SqlConsecutivo As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroCompra As String



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            ConsecutivoCompra = BuscaConsecutivo("Transforma")
            NumeroCompra = Format(ConsecutivoCompra, "0000#")
            Me.TxtNumeroEnsamble.Text = NumeroCompra

        Else
            'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
            'NumeroCompra = Format(ConsecutivoCompra, "0000#")
            NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If

        If Me.TrueDBGridDestino.Columns("Cantidad").Text = "" Then
            Me.TrueDBGridDestino.Columns("Cantidad").Text = 0
        Else
            Me.TrueDBGridDestino.Columns("Cantidad").Text = Abs(CDbl(Me.TrueDBGridDestino.Columns("Cantidad").Text))
        End If

        If Me.TrueDBGridDestino.Columns("Merma").Text = "" Then
            Me.TrueDBGridDestino.Columns("Merma").Text = 0
        Else
            Me.TrueDBGridDestino.Columns("Merma").Text = Abs(CDbl(Me.TrueDBGridDestino.Columns("Merma").Text))
        End If

        If Me.TrueDBGridDestino.Columns("Basura").Text = "" Then
            Me.TrueDBGridDestino.Columns("Basura").Text = 0
        Else
            Me.TrueDBGridDestino.Columns("Basura").Text = Abs(CDbl(Me.TrueDBGridDestino.Columns("Basura").Text))
        End If

        If Me.TrueDBGridDestino.Columns("Porciento_Merma").Text = "" Then
            Me.TrueDBGridDestino.Columns("Porciento_Merma").Text = 0
        Else
            'Me.TrueDBGridDestino.Columns("Porciento_Merma").Text = Abs(CDbl(Me.TrueDBGridDestino.Columns("Porciento_Merma").Text))
        End If

        If Me.TrueDBGridDestino.Columns("Porciento_Basura").Text = "" Then
            Me.TrueDBGridDestino.Columns("Porciento_Basura").Text = 0
        Else
            'Me.TrueDBGridDestino.Columns("Porciento_Basura").Text = Abs(CDbl(Me.TrueDBGridDestino.Columns("Porciento_Basura").Text))
        End If

        Me.TrueDBGridDestino.Columns("TipoTransforma").Text = "Destino"
        Me.TrueDBGridDestino.Columns("Numero_Transforma").Text = NumeroCompra

        GrabaTransformacion(NumeroCompra, Me.DTPFecha.Value, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text, Me.TxtObservaciones.Text)
    End Sub


    Private Sub TrueDBGridDestino_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridDestino.ButtonClick

        Quien = "CodigoProductosBodega"
        My.Forms.FrmConsultas.CodBodega = Me.CboCodigoBodega.Text
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TrueDBGridDestino.Columns("Codigo_Producto").Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridDestino.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion

        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim oDataRow As DataRow, oTablaBorrados As DataTable
        Dim Resultado As Double, CodProducto As String, iPosicion As Double

        Resultado = MsgBox("�Esta Seguro de Eliminar la Linea?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If





        CodProducto = Me.TrueDBGridOrigen.Columns("Codigo_Producto").Text
        iPosicion = Me.BindingDetalleOrigen.Position

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        oDataRow = dsOrigen.Tables("DetalleOrigen").Rows(iPosicion)
        oDataRow.Delete()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
        oTablaBorrados = dsOrigen.Tables("DetalleOrigen").GetChanges(DataRowState.Deleted)
        If Not IsNothing(oTablaBorrados) Then
            '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            daOrigen.Update(oTablaBorrados)
        End If
        dsOrigen.Tables("DetalleOrigen").AcceptChanges()
        daOrigen.Update(dsOrigen.Tables("DetalleOrigen"))

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Elimino Producto: " & CodProducto & " Transformacion No." & Me.TxtNumeroEnsamble.Text)
    End Sub

    Private Sub BtnBorrarLineaDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarLineaDestino.Click
        Dim oDataRow As DataRow, oTablaBorrados As DataTable
        Dim Resultado As Double, CodProducto As String, iPosicion As Double

        Resultado = MsgBox("�Esta Seguro de Eliminar la Linea?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        CodProducto = Me.TrueDBGridOrigen.Columns("Codigo_Producto").Text
        iPosicion = Me.BindingDetalleOrigen.Position

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        oDataRow = dsDestino.Tables("DetalleDestino").Rows(iPosicion)
        oDataRow.Delete()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
        oTablaBorrados = dsDestino.Tables("DetalleDestino").GetChanges(DataRowState.Deleted)
        If Not IsNothing(oTablaBorrados) Then
            '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            daDestino.Update(oTablaBorrados)
        End If
        dsDestino.Tables("DetalleDestino").AcceptChanges()
        daDestino.Update(dsOrigen.Tables("DetalleDestino"))

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Elimino Producto: " & CodProducto & " Transformacion No." & Me.TxtNumeroEnsamble.Text)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TrueDBGridOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridOrigen.Click

    End Sub

    Private Sub TrueDBGridDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridDestino.Click

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        MiConexion.Close()
        Numero = Me.TxtNumeroEnsamble.Text
        Fecha = Format(CDate(Me.DTPFecha.Value), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Transformacion]  SET [Observaciones] = '" & Me.TxtObservaciones.Text & "'  WHERE (Numero_Transforma = '" & Numero & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        LimpiarPantalla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepTransformacion As New ArepTransformacion

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            MsgBox("No se puede imprimir sin registrar la transformacion", MsgBoxStyle.Critical, " Zeus Facturacion")
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ArepTransformacion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepTransformacion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                ArepTransformacion.RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If


        ArepTransformacion.Document.Name = "Reporte de Transformacion"
        ArepTransformacion.Numero = Me.TxtNumeroEnsamble.Text
        ArepTransformacion.LblNumero.Text = Me.TxtNumeroEnsamble.Text
        ArepTransformacion.LblFecha.Text = Me.DTPFecha.Value
        ArepTransformacion.TxtObservaciones.Text = Me.TxtObservaciones.Text

        SqlDatos = "SELECT  Transformacion.Numero_Transforma, Transformacion.Fecha_Transforma, Transformacion.BodegaOrigen, Transformacion.BodegaDestino, Transformacion.Observaciones, Transformacion.Activo, Transformacion.Procesado, Transformacion.Anulado, Bodegas_1.Nombre_Bodega AS DBodegaDestino, Bodegas.Nombre_Bodega AS DBodegaOrigen FROM Transformacion INNER JOIN  Bodegas ON Transformacion.BodegaOrigen = Bodegas.Cod_Bodega INNER JOIN  Bodegas AS Bodegas_1 ON Transformacion.BodegaDestino = Bodegas_1.Cod_Bodega  " & _
                   "WHERE  (Transformacion.Numero_Transforma = '" & Me.TxtNumeroEnsamble.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            ArepTransformacion.LblBodegaOrigen.Text = DataSet.Tables("Consulta").Rows(0)("DBodegaOrigen")
            ArepTransformacion.LblBodegaDestino.Text = DataSet.Tables("Consulta").Rows(0)("DBodegaDestino")
        End If


        Dim ViewerForm As New FrmViewer()

        ViewerForm.arvMain.Document = ArepTransformacion.Document
        ViewerForm.Show()
        ArepTransformacion.Run(False)


    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TrueDBGridDestino_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridDestino.DataSourceChanged

    End Sub
End Class