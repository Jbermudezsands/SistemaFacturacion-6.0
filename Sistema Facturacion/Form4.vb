Public Class Form4
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Año As String, Mes As String, Dia As String

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String


        If Quien = "Recepcion" Then
            Me.CboTipoRecepcion.Text = "Recepcion"
        ElseIf Quien = "SalidaBascula" Then
            Me.CboTipoRecepcion.Text = "Salidabascula"
        End If


        DataSet.Reset()

        MiConexion.Open()

        sql = "SELECT * FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")

        Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
        Me.CboCodigoProveedor.Columns(1).Caption = "Proveedor"
        Me.CboCodigoProveedor.Columns(2).Caption = "Origen"

        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
            Me.CboCodigoProducto.Text = DataSet.Tables("ListaProductos").Rows(0)("Descripcion_Producto")
        End If


        Me.CboCodigoProducto.Splits(0).DisplayColumns(1).Width = 400










    End Sub
End Class