Public Class FrmListaLotes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public CodigoProducto As String, FechaVence As Date, NombreLote As String, NumeroLote As String, Activo As Boolean
    Private Sub FrmListaLotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SQlString = "SELECT  *  FROM Lote"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")

        Me.BindingDetalle.DataSource = DataSet.Tables("Lotes")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Posicion As Double
        If Me.BindingDetalle.Count <> 0 Then
            Posicion = Me.BindingDetalle.Position
            FechaVence = Me.BindingDetalle.Item(Posicion)("FechaVence")
            NumeroLote = Me.BindingDetalle.Item(Posicion)("Numero_Lote")
            NombreLote = Me.BindingDetalle.Item(Posicion)("Nombre_Lote")
            Activo = Me.BindingDetalle.Item(Posicion)("Activo")
            Me.Close()
        End If
    End Sub
End Class