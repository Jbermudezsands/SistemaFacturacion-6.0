Public Class FrmRegistroTransporte
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmRegistroTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sqlString As String, ComandoUpdate As New SqlClient.SqlCommand

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")

        sqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo "
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")


        sqlString = "SELECT  DISTINCT   CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN dbo.TipoContrato.TipoContrato ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN TipoContrato_1.TipoContrato  END END AS TipoContrato FROM  Contratos INNER JOIN  Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN   TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato WHERE  (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            Me.CmbContrato1.DataSource = DataSet.Tables("TipoContrato")
        End If



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ButtonGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGrabar.Click

    End Sub

    Private Sub CboCodigoConductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sqlString As String, ComandoUpdate As New SqlClient.SqlCommand

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sqlString = "SELECT  Vehiculo.Placa, Vehiculo.Marca, Vehiculo.TipoVehiculo, Vehiculo.Activo, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Id_Conductor, Conductor.Codigo FROM Vehiculo INNER JOIN Registro_Transporte_Detalle ON Vehiculo.IdVehiculo = Registro_Transporte_Detalle.Id_Vehiculo INNER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo  " & _
                    "WHERE  (Conductor.Codigo = '0001') AND (Conductor.Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class