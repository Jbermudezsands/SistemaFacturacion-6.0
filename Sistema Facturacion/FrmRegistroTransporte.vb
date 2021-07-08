Public Class FrmRegistroTransporte
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmRegistroTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sqlString As String, ComandoUpdate As New SqlClient.SqlCommand

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")

        sqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo "
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")

        sqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo "
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")




    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class