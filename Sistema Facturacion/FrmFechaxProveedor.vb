Public Class FrmFechaxProveedor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public TieneContrato As Boolean = False
    Public FechaCompra As Date, Codigo_Proveedor As String

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        FechaCompra = Me.DTPFechaRequerido.Value
        Codigo_Proveedor = TxtCodigoProveedor.Text
        Quien = "Cancelar"
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo

    End Sub

    Private Sub TxtCodigoProveedor_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtCodigoProveedor.Text = "" Then
            Exit Sub
        End If

        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")

            '////////////////////////////BUSCO SI TIENE CONTRATOS ////////////////////////////
            SqlProveedor = "SELECT Contrato_Proveedor.Codigo_Proveedor, Contrato_Proveedor.Numero_Contrato, Detalle_Contratos_Productos.Cod_Productos, Detalle_Contratos_Productos.Descripcion_Productos FROM Contrato_Proveedor INNER JOIN Detalle_Contratos_Productos ON Contrato_Proveedor.Numero_Contrato = Detalle_Contratos_Productos.Numero_Contrato WHERE  (Contrato_Proveedor.Codigo_Proveedor = '" & Me.TxtCodigoProveedor.Text & "') AND (Detalle_Contratos_Productos.Tipo_Contrato = 'Proveedores')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Contratos")
            If Not DataSet.Tables("Contratos").Rows.Count = 0 Then
                TieneContrato = True
            Else
                TieneContrato = False
            End If

        Else
            MsgBox("Codigo Proveedor Not Existe!!!", vbCritical, "Zeus Facturacion")
            Me.TxtNombres.Text = ""
            TieneContrato = False
            Me.TxtCodigoProveedor.Text = ""

        End If

    End Sub

    Private Sub FrmFechaxProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Size
        Me.MaximumSize = Size
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        If Me.TxtCodigoProveedor.Text = "" Then
            MsgBox("Codigo en Blanco", vbCritical, "Zeus Facturacion")
            Exit Sub
        End If

        Quien = "Aceptar"
        FechaCompra = Me.DTPFechaRequerido.Value
        Codigo_Proveedor = TxtCodigoProveedor.Text
        Me.Close()
    End Sub
End Class