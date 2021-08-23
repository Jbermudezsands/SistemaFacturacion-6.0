Public Class FrmRegistroTransporte
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdConductor As String, CodigoCliente As String, Nuevo As Boolean = True, Procesado As Boolean = False
    Public FechaRegistro As Date, NombreConductor As String, NumeroContrato As String, Placa As String



    Private Sub FrmRegistroTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sqlString As String, ComandoUpdate As New SqlClient.SqlCommand


        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Activo = 1) and (Evacuaciones = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")

        sqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo WHERE (Activo = 1) And (Evacuaciones = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")


        sqlString = "SELECT  DISTINCT   CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN dbo.TipoContrato.TipoContrato ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN TipoContrato_1.TipoContrato  END END AS TipoContrato FROM  Contratos INNER JOIN  Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN   TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato WHERE  (NOT (CASE WHEN dbo.Contratos.Contrato_Variable = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente ELSE CASE WHEN dbo.Contratos.Contrato_Variable2 = 1 THEN Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente END END IS NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            Me.CmbContrato1.DataSource = DataSet.Tables("TipoContrato")
        End If

        If Procesado = True Then
            Me.DTPFecha.Enabled = False
            Me.CboCodigoConductor.Enabled = False
            Me.CboPlaca.Enabled = False
            Me.TxtNumeroContrato.Enabled = False

        End If


        If Nuevo = False Then

            Me.DTPFecha.Value = Format(FechaRegistro, "dd/MM/yyyy")
            Me.CboCodigoConductor.Text = Me.NombreConductor
            Me.CboPlaca.Text = Me.Placa
            Me.TxtNumeroContrato.Text = Me.NumeroContrato

        Else
            Me.TxtNumeroContrato.Text = Me.NumeroContrato

        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreContrato.TextChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoConductor_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoConductor.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, ComandoUpdate As New SqlClient.SqlCommand


        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Nombre = '" & Me.CboCodigoConductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdConductor = DataSet.Tables("Consulta").Rows(0)("Codigo")
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS PLACAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Vehiculo.Placa, Vehiculo.Marca, Vehiculo.TipoVehiculo, Vehiculo.Activo, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Id_Conductor, Conductor.Codigo FROM Vehiculo INNER JOIN Registro_Transporte_Detalle ON Vehiculo.IdVehiculo = Registro_Transporte_Detalle.Id_Vehiculo INNER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo  " & _
                    "WHERE  (Conductor.Codigo = '" & IdConductor & "') AND (Conductor.Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placas")
        If DataSet.Tables("Placas").Rows.Count <> 0 Then
            Me.CboPlaca.Text = DataSet.Tables("Placas").Rows(0)("Placa")
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Conductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoConductor.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Vehiculo"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboPlaca.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "Contrato"
        My.Forms.FrmConsultas.TipoContrato = Me.CmbContrato1.Text
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "" Then
            Me.TxtNumeroContrato.Text = My.Forms.FrmConsultas.Codigo
        End If

        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Me.TxtNombreContrato.Text = My.Forms.FrmConsultas.Descripcion
        End If

    End Sub

    Private Sub ButtonGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGrabar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, ComandoUpdate As New SqlClient.SqlCommand, idVehiculo As Double, idContrato As Double

        If Me.CboCodigoConductor.Text = "" Then
            MsgBox("Seleccione un Conductor", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.CboPlaca.Text = "" Then
            MsgBox("Seleccione un Vehiculo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtNumeroContrato.Text = "" Then
            MsgBox("Seleccione un contrato Valido", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtNombreContrato.Text = "" Then
            MsgBox("Seleccione un contrato Valido", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If



        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CONSULTO EL CODIGO DEL CLIENTE////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Contratos.Numero_Contrato, Clientes.Nombre_Cliente, TipoContrato_1.TipoContrato, TipoContrato.TipoContrato AS Contrato2, Clientes.Cod_Cliente, Contratos.IdContrato1, Contratos.IdContrato2 FROM Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato " & _
                    "WHERE (Clientes.Nombre_Cliente = '" & Me.TxtNombreContrato.Text & "') AND (Contratos.Numero_Contrato = " & Me.TxtNumeroContrato.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cliente")
        If DataSet.Tables("Cliente").Rows.Count <> 0 Then
            CodigoCliente = DataSet.Tables("Cliente").Rows(0)("Cod_Cliente")
            idContrato = DataSet.Tables("Cliente").Rows(0)("IdContrato1")
        Else
            MsgBox("Selecione un contrato Valido, con su su cliente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Nombre = '" & Me.CboCodigoConductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdConductor = DataSet.Tables("Consulta").Rows(0)("Codigo")
        Else
            MsgBox("Es necesario que Seleccione un Conductor", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS PLACAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Placa, Marca, TipoVehiculo, Activo, IdVehiculo FROM Vehiculo WHERE (Placa = '" & Me.CboPlaca.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placas")
        If DataSet.Tables("Placas").Rows.Count <> 0 Then
            idVehiculo = DataSet.Tables("Placas").Rows(0)("IdVehiculo")
        Else
            MsgBox("Se necesita seleccionar un Vehiculo", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If



        GrabarRegistroEvacuaciones(Me.TxtNumeroContrato.Text, Me.DTPFecha.Value, CodigoCliente, IdConductor, idVehiculo, idContrato, False, True, False, True)

        Me.CboPlaca.Text = ""
        Me.CboCodigoConductor.Text = ""
        Me.TxtNombreContrato.Text = ""
        Me.TxtNumeroContrato.Text = ""


    End Sub

    Private Sub TxtNumeroContrato_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroContrato.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, ComandoUpdate As New SqlClient.SqlCommand

        If Me.TxtNombreContrato.Text = "" Then
            Me.TxtNombreContrato.Text = ""
        End If

        If Me.TxtNumeroContrato.Text = "" Then
            Exit Sub
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CONSULTO EL CODIGO DEL CLIENTE////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Contratos.Numero_Contrato, Clientes.Nombre_Cliente, TipoContrato_1.TipoContrato, TipoContrato.TipoContrato AS Contrato2, Clientes.Cod_Cliente FROM Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TipoContrato ON Contratos.IdContrato1 = TipoContrato.idTipoContrato INNER JOIN TipoContrato AS TipoContrato_1 ON Contratos.IdContrato2 = TipoContrato_1.idTipoContrato " & _
                    "WHERE (Contratos.Numero_Contrato = " & Me.TxtNumeroContrato.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cliente")
        If DataSet.Tables("Cliente").Rows.Count <> 0 Then
            Me.TxtNombreContrato.Text = DataSet.Tables("Cliente").Rows(0)("Nombre_Cliente")
        End If


    End Sub
End Class