Public Class FrmClientes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Clientes")
    End Sub
    Private Sub FrmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, SqlConsulta As String = "SELECT Endoso.* FROM Endoso"


        If CodigoClienteNumero = True Then
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
        End If

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If

        If CodigoClienteNumero = True Then
            Me.CboCodigoCliente.Splits.Item(0).DisplayColumns(2).Visible = False
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
        DataAdapter.Fill(DataSet, "Endoso")
        Me.CboEndoso.DataSource = DataSet.Tables("Endoso")

        '---------------------BUSCO LOS DEPARTAMENTOS -------------------------------------------------------------
        SqlConsulta = "SELECT DISTINCT Departamento FROM Clientes "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
        DataAdapter.Fill(DataSet, "Departamentos")
        Me.CboDepartamento.DataSource = DataSet.Tables("Departamentos")

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        CboCodigoVendedor.DataSource = DataSet.Tables("Vendedores")
        MiConexion.Close()

        Me.LblCodigo.Text = "Codigo " & NombreCliente
        Me.LblNombre.Text = "Nombre " & NombreCliente
        Me.LblApellido.Text = "Apellido " & NombreCliente
        Me.LblDireccion.Text = "Direccion " & NombreCliente
        Me.LblTitulo.Text = "REGISTRO DE " & UCase(NombreCliente)
        Me.Text = UCase(NombreCliente)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        If Me.TxtRUC.Text <> "" Then
            Me.TxtApellidos.Text = "RUC #" & Me.TxtRUC.Text
        Else
            'Me.TxtApellidos.Text = " "
        End If


        'SQLClientes = "SELECT *,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') ORDER BY Orden"
        SQLClientes = "SELECT * FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Clientes]  SET [Nombre_Cliente] = '" & Me.TxtNombre.Text & "',[Apellido_Cliente] = '" & Me.TxtApellidos.Text & "',[Direccion_Cliente] = '" & Me.TxtDireccion.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Cod_Cuenta_Cliente] = '" & Me.TxtCtaxCobrar.Text & "',[Limite_Credito] = '" & Me.TxtLimite.Text & "' ,[RUC] ='" & Me.TxtRUC.Text & "'  ,[CausaIva] = '" & Me.ChkCausaIVA.Checked & "' ,[Credito_Disponible] = '" & Me.ChkCreditoDisponible.Checked & "',[Año] = '" & Me.TxtAño.Text & "',[Grado] = '" & Me.TxtGrado.Text & "',[Turno] = '" & Me.CmbTurno.Text & "',[InventarioFisico] = '" & Me.ChkInventario.Checked & "',[DiasCredito] = '" & Me.TxtDiasCredito.Value & "',[Departamento] = '" & Me.CboDepartamento.Text & "' ,[Municipio] = '" & Me.CboMunicipio.Text & "' ,[Endoso] = '" & Me.CboEndoso.Text & "',[Activo] = '" & Me.ChkActivo.Checked & "',[Efectivo] = '" & Me.ChkEfectivo.Checked & "',[Cedula] = '" & Me.TxtCedula.Text & "',[Estado] = '" & Me.CmbEstado.Text & "',[CodVendedor] = '" & Me.CboCodigoVendedor.Text & "',[MonedaCredito] = '" & Me.CboMonedaFactura.Text & "',[BloquearPorLimiteCredito] = '" & Me.ChkBloqueoLimite.Checked & "' WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Clientes] ([Cod_Cliente],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono],[Cod_Cuenta_Cliente],[Año],[Grado],[Turno],[InventarioFisico],[RUC],[Limite_Credito],[DiasCredito],[Departamento],[Municipio],[Endoso],[Activo],[Efectivo],[Cedula],[Estado],[CodVendedor],[CausaIva],[MonedaCredito],[BloquearPorLimiteCredito]) " & _
                           "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellidos.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtAño.Text & "','" & Me.TxtGrado.Text & "','" & Me.CmbTurno.Text & "','" & Me.ChkInventario.Checked & "','" & Me.TxtRUC.Text & "','" & Me.TxtLimite.Text & "','" & Me.TxtDiasCredito.Value & "','" & Me.CboDepartamento.Text & "','" & Me.CboMunicipio.Text & "','" & Me.CboEndoso.Text & "','" & Me.ChkActivo.Checked & "','" & Me.ChkEfectivo.Checked & "','" & Me.TxtCedula.Text & "','" & Me.CmbEstado.Text & "','" & Me.CboCodigoVendedor.Text & "','" & Me.ChkCausaIVA.Checked & "','" & Me.CboMonedaFactura.Text & "','" & Me.ChkBloqueoLimite.Checked & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Bitacora(Now, NombreUsuario, "Clientes", "Grabo el cliente: " & Me.TxtNombre.Text)
        Dim Sql As String = "SELECT Cod_Cliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Tables("Clientes").Reset()
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")

        End If

        Me.CboCodigoCliente.Text = ""

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, StrSQl As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT *,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "') ORDER BY Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Clientes] WHERE (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Clientes", "Borro el cliente: " & Me.TxtNombre.Text)

        StrSQl = "SELECT Cod_Cliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        DataAdapter = New SqlClient.SqlDataAdapter(StrSQl, MiConexion)
        DataSet.Tables("Clientes").Reset()
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")

        End If
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CboCodigoCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQL As String = "SELECT * FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        Dim SqlString As String

        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("MonedaCredito")) Then
                Me.CboMonedaFactura.Text = DataSet.Tables("Clientes").Rows(0)("MonedaCredito")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Año")) Then
                Me.TxtAño.Text = DataSet.Tables("Clientes").Rows(0)("Año")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Grado")) Then
                Me.TxtGrado.Text = DataSet.Tables("Clientes").Rows(0)("Grado")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Turno")) Then
                Me.CmbTurno.Text = DataSet.Tables("Clientes").Rows(0)("Turno")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")) Then
                Me.TxtNombre.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
            End If
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Cod_Cuenta_Cliente")) Then
                Me.TxtCtaxCobrar.Text = DataSet.Tables("Clientes").Rows(0)("Cod_Cuenta_Cliente")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Limite_Credito")) Then
                Me.TxtLimite.Text = DataSet.Tables("Clientes").Rows(0)("Limite_Credito")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("RUC")) Then
                Me.TxtRUC.Text = DataSet.Tables("Clientes").Rows(0)("RUC")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("DiasCredito")) Then
                Me.TxtDiasCredito.Value = DataSet.Tables("Clientes").Rows(0)("DiasCredito")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Departamento")) Then
                Me.CboDepartamento.Text = DataSet.Tables("Clientes").Rows(0)("Departamento")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Municipio")) Then
                Me.CboMunicipio.Text = DataSet.Tables("Clientes").Rows(0)("Municipio")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Endoso")) Then
                Me.CboEndoso.Text = DataSet.Tables("Clientes").Rows(0)("Endoso")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Cedula")) Then
                Me.TxtCedula.Text = DataSet.Tables("Clientes").Rows(0)("Cedula")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Estado")) Then
                Me.CmbEstado.Text = DataSet.Tables("Clientes").Rows(0)("Estado")
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CausaIva")) Then
                If DataSet.Tables("Clientes").Rows(0)("CausaIva") = 0 Then
                    Me.ChkCausaIVA.Checked = False
                Else
                    Me.ChkCausaIVA.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Credito_Disponible")) Then
                If DataSet.Tables("Clientes").Rows(0)("Credito_Disponible") = 0 Then
                    Me.ChkCreditoDisponible.Checked = False
                Else
                    Me.ChkCreditoDisponible.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("InventarioFisico")) Then
                If DataSet.Tables("Clientes").Rows(0)("InventarioFisico") = 0 Then
                    Me.ChkInventario.Checked = False
                Else
                    Me.ChkInventario.Checked = True
                End If
            Else
                Me.ChkInventario.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Activo")) Then
                If DataSet.Tables("Clientes").Rows(0)("Activo") = 0 Then
                    Me.ChkActivo.Checked = False
                Else
                    Me.ChkActivo.Checked = True
                End If
            Else
                Me.ChkActivo.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Efectivo")) Then
                If DataSet.Tables("Clientes").Rows(0)("Efectivo") = 0 Then
                    Me.ChkEfectivo.Checked = False
                Else
                    Me.ChkEfectivo.Checked = True
                End If
            Else
                Me.ChkEfectivo.Checked = False
            End If

            Me.ChkBloqueoLimite.Checked = False
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("BloquearPorLimiteCredito")) Then
                If DataSet.Tables("Clientes").Rows(0)("BloquearPorLimiteCredito") = 0 Then
                    Me.ChkBloqueoLimite.Checked = False
                Else
                    Me.ChkBloqueoLimite.Checked = True
                End If
            End If


            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CodVendedor")) Then
                Me.CboCodigoVendedor.Text = DataSet.Tables("Clientes").Rows(0)("CodVendedor")
            End If


        Else
            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtCtaxCobrar.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtCedula.Text = ""
            Me.CmbEstado.Text = ""

            Me.ChkCausaIVA.Checked = True
            Me.ChkActivo.Checked = True

        End If
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlConsulta As String

        '---------------------BUSCO LOS DEPARTAMENTOS -------------------------------------------------------------
        SqlConsulta = "SELECT DISTINCT Municipio FROM Clientes WHERE  (Departamento LIKE '%" & Me.CboDepartamento.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsulta, MiConexion)
        DataAdapter.Fill(DataSet, "Departamentos")
        Me.CboMunicipio.DataSource = DataSet.Tables("Departamentos")
    End Sub

    Private Sub CboMunicipio_ItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMunicipio.ItemChanged

    End Sub

    Private Sub CboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMunicipio.TextChanged

    End Sub
End Class