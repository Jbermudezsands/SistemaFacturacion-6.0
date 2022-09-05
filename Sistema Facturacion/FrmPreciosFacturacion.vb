Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient

Public Class FrmPreciosFacturacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodProducto As String, NombreProducto As String, PrecioProducto As Double, ValidarRegistros As Boolean = False
    Public Cod_TipoPrecio As String, PrecioProductoDolar As Double, IdUnidadMedida As Double, GridOpen As Boolean = False, DescripcionUnidadMedida As String, Cantidad As Double
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Private Sub ActualizaGridPrecios()
        Dim SQLString As String, Id_UnidadMedida As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Id_UnidadMedida = Me.tdbGridUnidadMedida.Columns("idUnidadMedida").Text
        SQLString = "SELECT  TipoPrecio.Tipo_Precio, Precios.Monto_Precio, Precios.Monto_PrecioDolar, Precios.Cod_TipoPrecio,  Precios.idUnidadMedida FROM  Precios INNER JOIN  TipoPrecio ON Precios.Cod_TipoPrecio = TipoPrecio.Cod_TipoPrecio  " & _
                    "WHERE (Precios.Cod_Productos = '" & CodProducto & "') AND (Precios.idUnidadMedida = " & Id_UnidadMedida & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "ListaPrecios")
        Me.tdbGridUndMedidaVrsPrecio.DataSource = DataSet.Tables("ListaPrecios")

        Me.tdbGridUndMedidaVrsPrecio.Splits.Item(0).DisplayColumns("Tipo_Precio").Width = 100
        Me.tdbGridUndMedidaVrsPrecio.Columns("Tipo_Precio").Caption = "Tipo Precio"
        Me.tdbGridUndMedidaVrsPrecio.Splits.Item(0).DisplayColumns("Monto_Precio").Width = 100
        Me.tdbGridUndMedidaVrsPrecio.Columns("Monto_Precio").Caption = "Precio C$"
        Me.tdbGridUndMedidaVrsPrecio.Splits.Item(0).DisplayColumns("Monto_PrecioDolar").Width = 100
        Me.tdbGridUndMedidaVrsPrecio.Columns("Monto_PrecioDolar").Caption = "Precio $"
        Me.tdbGridUndMedidaVrsPrecio.Splits.Item(0).DisplayColumns("Cod_TipoPrecio").Visible = False
        Me.tdbGridUndMedidaVrsPrecio.Splits.Item(0).DisplayColumns("idUnidadMedida").Visible = False

    End Sub
    Public Sub ActualizarGridInsertRowIngresos()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()



        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT idUnidadMedida, Cod_TipoPrecio, Cod_Productos, Unidad_Medida, Precio_Unitario * Cantidad_Unidades As Precio_Unitario, Precio_Unitario_Dolar * Cantidad_Unidades Precio_Unitario_Dolar, Cantidad_Unidades  FROM UnidadMedidaProductos WHERE  (Cod_Productos = '" & CodProducto & "') ORDER BY Unidad_Medida"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "UnidadMedida")
        Me.tdbGridUnidadMedida.DataSource = ds.Tables("DetalleIngresos")
        Me.tdbGridUnidadMedida.DataSource = ds.Tables("UnidadMedida")
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("idUnidadMedida").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_TipoPrecio").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 300
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Button = True
        Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Visible = True
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario_Dolar").Visible = True
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario_Dolar").Width = 70
        Me.tdbGridUnidadMedida.Columns("Precio_Unitario_Dolar").Caption = "Precio $"


    End Sub

    Private Sub FrmPreciosFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LblProducto.Text = Me.CodProducto & " " & Me.NombreProducto

        ActualizarGridInsertRowIngresos()
        Me.LblUnidad.Text = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Unidad_Medida")

    End Sub

    Private Sub tdbGridUnidadMedida_BeforeClose(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbGridUnidadMedida.BeforeClose
        GridOpen = False
    End Sub

    Private Sub tdbGridUnidadMedida_BeforeOpen(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbGridUnidadMedida.BeforeOpen
        GridOpen = True
        Me.LblUnidad.Text = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Unidad_Medida")
        ActualizaGridPrecios()
    End Sub


    Private Sub CmdPegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPegar.Click
        Dim Cantidad_Unidad As Double

        If Me.TxtCantidad.Text = "" Then
            Cantidad = 0
        Else
            Cantidad = Me.TxtCantidad.Text
        End If

        Cantidad_Unidad = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Cantidad_Unidades")
        Me.Cantidad = Cantidad_Unidad * Cantidad

        If Me.GridOpen = False Then

            PrecioProducto = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Precio_Unitario")
            PrecioProductoDolar = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Precio_Unitario_Dolar")
            IdUnidadMedida = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("idUnidadMedida")



        Else

            DescripcionUnidadMedida = Me.tdbGridUndMedidaVrsPrecio.Item(Me.tdbGridUndMedidaVrsPrecio.Row)("Tipo_Precio")
            PrecioProducto = Me.tdbGridUndMedidaVrsPrecio.Item(Me.tdbGridUndMedidaVrsPrecio.Row)("Monto_Precio")
            PrecioProductoDolar = Me.tdbGridUndMedidaVrsPrecio.Item(Me.tdbGridUndMedidaVrsPrecio.Row)("Monto_PrecioDolar")
            IdUnidadMedida = Me.tdbGridUndMedidaVrsPrecio.Item(Me.tdbGridUndMedidaVrsPrecio.Row)("idUnidadMedida")
            Cod_TipoPrecio = Me.tdbGridUndMedidaVrsPrecio.Item(Me.tdbGridUndMedidaVrsPrecio.Row)("Cod_TipoPrecio")

        End If

        Me.Close()
    End Sub

    Private Sub tdbGridUnidadMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbGridUnidadMedida.Click
        Me.LblUnidad.Text = Me.tdbGridUnidadMedida.Item(Me.tdbGridUnidadMedida.Row)("Unidad_Medida")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CostoProducto As Double = 0, CostoProductoD As Double = 0
        Dim Cont As Double, i As Double

        CostoProducto = CostoPromedio(Me.CodProducto)
        CostoProductoD = CostoPromedioDolar

        AjustarPrecios(Me.CodProducto, CostoProducto, CostoProductoD)
        ActualizarGridInsertRowIngresos()
        ActualizaGridPrecios()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class