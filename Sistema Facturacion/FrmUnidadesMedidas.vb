Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient

Public Class FrmUnidadesMedidas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public Cantidad As Double = 0, Precio As Double = 0, Cod_Producto As String
    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmUnidadesMedidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlProductos As String

        SqlProductos = "SELECT Cod_Productos, Unidad_Medida, Cantidad_Unidades, Precio_Unitario FROM UnidadMedidaProductos WHERE  (Cod_Productos = '" & Cod_Producto & "') ORDER BY Unidad_Medida"
        ds = New DataSet
        da = New SqlDataAdapter(SqlProductos, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "UnidadMedida")
        Me.BindingComponentes.DataSource = ds.Tables("UnidadMedida")
        Me.tdbGridUnidadMedida.DataSource = BindingComponentes.DataSource
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 100
        Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Width = 100
        Me.tdbGridUnidadMedida.Columns("Cantidad_Unidades").Caption = "Cant Unidades"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
        Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio Unitario"

    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim iPosicion As Double
        iPosicion = Me.BindingComponentes.Position
        Cantidad = Me.BindingComponentes.Item(iPosicion)("Cantidad_Unidades")
        Precio = Me.BindingComponentes.Item(iPosicion)("Precio_Unitario")
    End Sub
End Class