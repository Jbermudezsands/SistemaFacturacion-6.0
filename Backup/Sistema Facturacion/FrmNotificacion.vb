Public Class FrmNotificacion
    Public Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub FrmNotificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TrueDBGridComponentes.DataSource = Dataset.Tables("BajoMinimo")
        If Dataset.Tables("BajoMinimo").Rows.Count <> 0 Then
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 400
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion Producto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 80
            Me.TrueDBGridComponentes.Columns("Unidad_Medida").Caption = "Unidad Medida"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Minimo").Width = 63
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Existencia").Width = 63
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Diferencia").Width = 63

        End If


    End Sub
End Class