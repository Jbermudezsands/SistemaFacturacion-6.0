Public Class FrmVehiculo
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Quien = "Vehiculo"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboPlaca.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CboPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPlaca.TextChanged
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Activo As Boolean


        '////////////////////////////////////////////////BUSCO DATOS DEL CONDUCTOR ///////////////////////////////////
        SqlString = "SELECT  Placa, Marca, TipoVehiculo, Activo FROM Vehiculo WHERE (Placa = '" & Me.CboPlaca.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Datos")
        If Not DataSet.Tables("Datos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Marca")) Then
                Me.TxtMarca.Text = DataSet.Tables("Datos").Rows(0)("Marca")
            End If

            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Activo")) Then
                Activo = DataSet.Tables("Datos").Rows(0)("Activo")
                If Activo = True Then
                    Me.CboActivo.Text = "Activo"
                Else
                    Me.CboActivo.Text = "Inactivo"
                End If

            End If
            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("TipoVehiculo")) Then
                Me.CboTipo.Text = DataSet.Tables("Datos").Rows(0)("TipoVehiculo")
            End If
        End If



    End Sub

    Private Sub Vehiculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")
        'If Not DataSet.Tables("Placa").Rows.Count = 0 Then
        '    Me.CboPlaca.Text = DataSet.Tables("Placa").Rows(0)("Placa")
        'End If
        'Me.CboPlaca.Columns(0).Caption = "Placa"

        SqlString = "SELECT DISTINCT TipoVehiculo FROM Vehiculo WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Tipo")
        Me.CboTipo.DataSource = DataSet.Tables("Tipo")
        'If Not DataSet.Tables("Tipo").Rows.Count = 0 Then
        '    Me.CboTipo.Text = DataSet.Tables("Tipo").Rows(0)("TipoVehiculo")
        'End If
        'Me.CboPlaca.Columns(0).Caption = "Placa"



    End Sub

    Public Sub LimpiaVehiculo()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")
        'If Not DataSet.Tables("Placa").Rows.Count = 0 Then
        '    Me.CboPlaca.Text = DataSet.Tables("Placa").Rows(0)("Placa")
        'End If
        'Me.CboPlaca.Columns(0).Caption = "Placa"


        Me.CboPlaca.Text = ""
        Me.TxtMarca.Text = ""
        Me.CboTipo.Text = ""
        Me.CboActivo.Text = "Activo"
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.LimpiaVehiculo()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLString As String, Activo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQLString = "SELECT  Placa, Marca, TipoVehiculo, Activo FROM Vehiculo WHERE (Activo = 1) AND (Placa = '" & Me.CboPlaca.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then

            If Me.CboActivo.Text = "Activo" Then
                Activo = 1
            Else
                Activo = 0
            End If

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Vehiculo]  SET [Marca] = '" & Me.TxtMarca.Text & "',[TipoVehiculo] = '" & Me.CboTipo.Text & "' ,[Activo] = " & Activo & "  WHERE (Activo = 1) AND (Placa = '" & Me.CboPlaca.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Vehiculo] ([Placa],[Marca],[TipoVehiculo],[Activo]) VALUES ('" & Me.CboPlaca.Text & "' ,'" & Me.TxtMarca.Text & "' ,'" & Me.CboTipo.Text & "', " & Activo & ") "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        LimpiaVehiculo()


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, StrSQl As String, IdVehiculo As Double

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLString = "SELECT  Placa, Marca, TipoVehiculo, Activo, IdVehiculo FROM Vehiculo WHERE (Placa = '" & Me.CboPlaca.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            IdVehiculo = DataSet.Tables("Clientes").Rows(0)("IdVehiculo")

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            '---------------ANTES DE BORRAR VERIFICO SI EXISTE PLACAS PARA LA RECEPCION ---------------------
            SQLString = "SELECT  NumeroRecepcion FROM Recepcion WHERE  (Id_Vehiculo = " & IdVehiculo & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultaRec")
            If Not DataSet.Tables("ConsultaRec").Rows.Count = 0 Then
                MsgBox("Existen Registros en Recepciones", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            StrSqlUpdate = "DELETE FROM [Vehiculo] WHERE (Id_Vehiculo = " & IdVehiculo & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Clientes", "Borro el vehiculo: " & Me.CboPlaca.Text)

        LimpiaVehiculo()

    End Sub
End Class