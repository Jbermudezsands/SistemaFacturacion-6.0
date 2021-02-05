Imports System.Data.SqlClient
Imports System.Threading

Public Class TransformacionNueva
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public dsOrigen As New DataSet, daOrigen As New SqlClient.SqlDataAdapter, CmdBuilderOrigen As New SqlCommandBuilder
    Public dsDestino As New DataSet, daDestino As New SqlClient.SqlDataAdapter, CmdBuilderDestino As New SqlCommandBuilder

    Public Sub InsertarRowGridOrigen()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridOrigen.Row
        CodigoProducto = Me.TrueDBGridOrigen.Columns("Cod_Producto").Text

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


    End Sub

    Public Sub ActualizarGridInsertRowOrigen()
        Dim SqlString As String

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion " & _
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
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridOrigen.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
    End Sub

    Public Sub InsertarRowGridDestino()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridDestino.Row
        CodigoProducto = Me.TrueDBGridDestino.Columns("Cod_Producto").Text

        CmdBuilderDestino.RefreshSchema()
        oTabla = dsDestino.Tables("DetalleDestino").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daDestino.Update(oTabla)
            dsDestino.Tables("DetalleOrigen").AcceptChanges()
            daDestino.Update(dsOrigen.Tables("DetalleDestino"))



            Me.TrueDBGridDestino.Row = iPosicion

        Else
            oTabla = dsDestino.Tables("DetalleDestino").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daDestino.Update(oTabla)
                dsDestino.Tables("DetalleDestino").AcceptChanges()
                daDestino.Update(dsOrigen.Tables("DetalleDestino"))
            End If
        End If

        ActualizarGridInsertRowDestino()


    End Sub


    Public Sub ActualizarGridInsertRowDestino()
        Dim SqlString As String

        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion " & _
                    "WHERE (IdDetalleOrigen = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoTransforma = 'Destino')"
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
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridDestino.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Cantidad").Width = 64

    End Sub
    Private Sub TransformacionNueva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Procesado As Boolean = True, SqlDatos As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")

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
        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Origen')"
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
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridOrigen.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridOrigen.Splits.Item(0).DisplayColumns("Cantidad").Width = 64


        SqlString = "SELECT IdDetalleOrigen, TipoTransforma, Numero_Transforma, Codigo_Producto, Descripcion_Producto, Cantidad FROM Detalle_Transformacion WHERE (IdDetalleOrigen = - 10000000) AND (TipoTransforma = 'Destino')"
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
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridDestino.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridDestino.Splits.Item(0).DisplayColumns("Cantidad").Width = 64


    End Sub

    Private Sub TrueDBGridOrigen_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridOrigen.AfterUpdate
        InsertarRowGridOrigen()
    End Sub

    Private Sub TrueDBGridDestino_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridDestino.BackColorChanged
        InsertarRowGridDestino()
    End Sub


    Private Sub TrueDBGridOrigen_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridOrigen.BeforeUpdate
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text

                    ConsecutivoCompra = BuscaConsecutivo("Transformacion")


                '/////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////
                    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                    DataAdapter.Fill(DataSet, "Configuracion")
                    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
                        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) Then
                            FacturaBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")
                    End If

                        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) Then
                            CompraBodega = DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")
                    End If

                End If

                    If CompraBodega = True Then
                        NumeroCompra = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoCompra, "0000#")
                    Else
                        NumeroCompra = Format(ConsecutivoCompra, "0000#")
                End If
        Else
                'ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
                'NumeroCompra = Format(ConsecutivoCompra, "0000#")
                    NumeroCompra = Me.TxtNumeroEnsamble.Text
        End If




        end if 


    End Sub
End Class