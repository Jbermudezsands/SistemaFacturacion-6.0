Public Class FrmCompañiaEndoso
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmCompañiaEndoso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, SqlConsulta As String = "SELECT Endoso.* FROM Endoso"


        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If



    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        'SQLClientes = "SELECT *,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') ORDER BY Orden"
        SQLClientes = "SELECT * FROM Endoso WHERE  (Nombre = '" & Me.CboCodigoCliente.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Endoso")
        'If Not DataSet.Tables("Endoso").Rows.Count = 0 Then
        '    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
        '    StrSqlUpdate = "UPDATE [Endoso]  SET [Telefono] = '" & Me.TxtApellidos.Text & "',[Direccion_Cliente] = '" & Me.TxtDireccion.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Cod_Cuenta_Cliente] = '" & Me.TxtCtaxCobrar.Text & "',[Limite_Credito] = '" & Me.TxtLimite.Text & "' ,[RUC] ='" & Me.TxtRUC.Text & "'  ,[CausaIva] = '" & Me.ChkCausaIVA.Checked & "' ,[Credito_Disponible] = '" & Me.ChkCreditoDisponible.Checked & "',[Año] = '" & Me.TxtAño.Text & "',[Grado] = '" & Me.TxtGrado.Text & "',[Turno] = '" & Me.CmbTurno.Text & "',[InventarioFisico] = '" & Me.ChkInventario.Checked & "',[DiasCredito] = '" & Me.TxtDiasCredito.Value & "',[Departamento] = '" & Me.CboDepartamento.Text & "' ,[Municipio] = '" & Me.CboMunicipio.Text & "' ,[Endoso] = '" & Me.CboEndoso.Text & "' WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
        '    MiConexion.Open()
        '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        '    iResultado = ComandoUpdate.ExecuteNonQuery
        '    MiConexion.Close()

        'Else
        '    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
        '    StrSqlUpdate = "INSERT INTO [Clientes] ([Cod_Cliente],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono],[Cod_Cuenta_Cliente],[Año],[Grado],[Turno],[InventarioFisico],[RUC],[Limite_Credito],[DiasCredito],[Departamento],[Municipio],[Endoso]) " & _
        '                   "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellidos.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtAño.Text & "','" & Me.TxtGrado.Text & "','" & Me.CmbTurno.Text & "','" & Me.ChkInventario.Checked & "','" & Me.TxtRUC.Text & "','" & Me.TxtLimite.Text & "','" & Me.TxtDiasCredito.Value & "','" & Me.CboDepartamento.Text & "','" & Me.CboMunicipio.Text & "','" & Me.CboEndoso.Text & "')"
        '    MiConexion.Open()
        '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        '    iResultado = ComandoUpdate.ExecuteNonQuery
        '    MiConexion.Close()

        'End If
        'Bitacora(Now, NombreUsuario, "Clientes", "Grabo el cliente: " & Me.TxtNombre.Text)
        'Dim Sql As String = "SELECT Cod_Cliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataSet.Tables("Clientes").Reset()
        'DataAdapter.Fill(DataSet, "Clientes")
        'If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
        '    Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")

        'End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class