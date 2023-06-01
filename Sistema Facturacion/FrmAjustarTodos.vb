Public Class FrmAjustarTodos
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoDesde.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles FrmAjusteRango.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoHasta.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlString As String, DataSet As New DataSet
        Dim NumeroRecibo As String = "", MontoRecibo As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim CodigoCliente As String, DataSetReporte As New DataSet, NombreCliente As String, j As Double

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Clientes.* FROM  Clientes WHERE (Cod_Cliente BETWEEN '" & Me.CboCodigoDesde.Text & "' AND '" & CboCodigoHasta.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        Registros = DataSet.Tables("Clientes").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Clientes").Rows.Count
        Do While Registros > i
            NumeroRecibo = ""
            My.Application.DoEvents()
            CodigoCliente = DataSet.Tables("Clientes").Rows(i)("Cod_Cliente")
            NombreCliente = DataSet.Tables("Clientes").Rows(i)("Nombre_Cliente")

            Ajustar_CtaxCobrar(DTPFechaInicio.Value, DTPFechaFin.Value, Me.OptCordobas.Checked, Me.ChkSseries.Checked, Me.TxtMonto.Value, CodigoCliente, NombreCliente, "AjustarTodos")

            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            i = i + 1
        Loop

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmAjustarTodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, SQLString As String = ""

        If CodigoClienteNumero = True Then
            SQLString = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            SQLString = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoDesde.DataSource = DataSet.Tables("Clientes")
            Me.CboCodigoHasta.DataSource = DataSet.Tables("Clientes")
        End If
    End Sub
End Class