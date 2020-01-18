Public Class FrmUsuarios
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmUsuarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Usuarios")
    End Sub
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Registros As Double = 0, i As Double = 0
        Dim SqlString As String, oDataRow As DataRow

        'Me.LblTipoFactura.Visible = False
        'Me.CboTipoProducto.Visible = False
        'Me.LblVendedor.Visible = False
        'Me.CboCodigoVendedor.Visible = False
        'Me.LblCodigo.Visible = False
        'Me.CboCodigoCliente.Visible = False
        'Me.Size = New Size(325, 342)
        'Me.LblConfirmar.Location = New Point(18, 299)
        'Me.TxtConfirmar.Location = New Point(101, 301)
        'Me.TxtContraseña.Location = New Point(101, 292)
        'Me.LblContraseña.Location = New Point(18, 290)

        Me.CboTipoProducto.Text = "Factura"

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT  NombrePerfil FROM Perfil "
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")
        CboNivel.DataSource = DataSet.Tables("Perfil")
        If Not DataSet.Tables("Perfil").Rows.Count = 0 Then
            Me.CboNivel.Text = DataSet.Tables("Perfil").Rows(0)("NombrePerfil")
        End If
        MiConexion.Close()



        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************

        SqlString = "SELECT Cod_Bodega, Nombre_Bodega FROM Bodegas WHERE (Cod_Bodega = '-1000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ListaBodegas")

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")

        Registros = DataSet.Tables("Bodegas").Rows.Count
        i = 0
        Do While Registros > i
            If i = 0 Then
                oDataRow = DataSet.Tables("ListaBodegas").NewRow
                oDataRow("Cod_Bodega") = "Ninguna"
                oDataRow("Nombre_Bodega") = "Ninguna"
                DataSet.Tables("ListaBodegas").Rows.Add(oDataRow)
            End If

            oDataRow = DataSet.Tables("ListaBodegas").NewRow
            oDataRow("Cod_Bodega") = DataSet.Tables("Bodegas").Rows(i)("Cod_Bodega")
            oDataRow("Nombre_Bodega") = DataSet.Tables("Bodegas").Rows(i)("Nombre_Bodega")
            DataSet.Tables("ListaBodegas").Rows.Add(oDataRow)
            i = i + 1
        Loop
        If DataSet.Tables("Bodegas").Rows.Count <> 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If

        Me.CboCodigoBodega.DataSource = DataSet.Tables("ListaBodegas")
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


        If Acceso = "Administrador" Then
            SqlUsuarios = "SELECT Usuario  FROM Usuarios"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)
            DataAdapter.Fill(DataSet, "ListaUsuarios")
            If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
                Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")
            End If

            Me.CboNivel.Enabled = True
            Me.CboCodigoBodega.Enabled = True
            Me.ButtonBorrar.Enabled = True
            Me.CboTipoProducto.Enabled = True
            Me.CboCodigoVendedor.Enabled = True
            Me.CboCodigoCliente.Enabled = True
        Else
            SqlUsuarios = "SELECT Usuario FROM Usuarios WHERE (Nivel = '" & Acceso & "') AND (Usuario = '" & NombreUsuario & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)
            DataAdapter.Fill(DataSet, "ListaUsuarios")
            If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
                Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")
            End If

            Me.CboNivel.Enabled = False
            Me.CboCodigoBodega.Enabled = False
            Me.ButtonBorrar.Enabled = False
            Me.CboTipoProducto.Enabled = False
            Me.CboCodigoVendedor.Enabled = False
            Me.CboCodigoCliente.Enabled = False
        End If


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
        'MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        CboCodigoVendedor.DataSource = DataSet.Tables("Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.Text = DataSet.Tables("Vendedores").Rows(0)("Cod_Vendedor")
        End If
        MiConexion.Close()


        Dim Sql As String = "SELECT Cod_Cliente As Codigo, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
            Me.CboCodigoCliente.Text = DataSet.Tables("Clientes").Rows(0)("Codigo")
        End If


    End Sub

    Private Sub CboUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUsuario.TextChanged
        Dim StrUsuario As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        StrUsuario = "Select * FROM Usuarios Where Usuario = '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(StrUsuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            Me.CboNivel.Text = DataSet.Tables("Usuario").Rows(0)("Nivel")
            Me.TxtContraseña.Text = DataSet.Tables("Usuario").Rows(0)("Contraseña")
            If Not IsDBNull(DataSet.Tables("Usuario").Rows(0)("Bodega")) Then
                Me.CboCodigoBodega.Text = DataSet.Tables("Usuario").Rows(0)("Bodega")
            End If
        Else
            Me.CboNivel.Text = ""
            Me.TxtContraseña.Text = ""
            Me.TxtConfirmar.Text = ""
            Me.CboCodigoBodega.Text = ""
        End If
    End Sub

    Private Sub TxtContraseña_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtContraseña.TextChanged
        If Not Me.TxtContraseña.Text = "" Then
            Me.TxtConfirmar.Visible = True
            Me.LblConfirmar.Visible = True
        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim strusuario As String, SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        If Not Me.TxtContraseña.Text = Me.TxtConfirmar.Text Then
            MsgBox("LAS CONTRASEÑAS NO COINCIDEN!", MsgBoxStyle.Critical, "Sistema de Factuacion")
            Exit Sub
        End If

        If Me.CboNivel.Text = "" Then
            MsgBox("El nivel no puede quedar Vacio", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtContraseña.Text = "" Then
            MsgBox("La Contraseña no puede quedar Vacia", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub

        End If

        'If Not IsNumeric(Me.CboNivel.Text) Then
        '    MsgBox("El Campo Nivel Tiene que ser Numerico", MsgBoxStyle.Critical, "Sistema de Facturacion")
        '    Exit Sub
        'End If

        strusuario = "Select * FROM Usuarios Where Usuario= '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(strusuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            MiConexion.Close()
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            StrSqlUpdate = "UPDATE [Usuarios] SET [Contraseña] = '" & Me.TxtContraseña.Text & "',[Nivel] = '" & Me.CboNivel.Text & "',[Bodega]= '" & Me.CboCodigoBodega.Text & "',[TipoFactura]= '" & Me.CboTipoProducto.Text & "',[CodVendedor]= '" & Me.CboCodigoVendedor.Text & "',[CodCliente]= '" & Me.CboCodigoCliente.Text & "',[SerieFactura]= '" & Me.CmbSerie.Text & "'    " & _
                           "WHERE [Usuario] = '" & Me.CboUsuario.Text & "' "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            'Nivel = Me.CboNivel.Text
            StrSqlUpdate = "INSERT INTO [Usuarios] ([Usuario],[Contraseña],[Nivel],[Bodega],[TipoFactura],[CodVendedor],[CodCliente],[SerieFactura]) " & _
                           "VALUES('" & Me.CboUsuario.Text & "','" & Me.TxtContraseña.Text & "','" & Me.CboNivel.Text & "','" & Me.CboCodigoBodega.Text & "','" & Me.CboTipoProducto.Text & "','" & Me.CboCodigoVendedor.Text & "','" & Me.CboCodigoCliente.Text & "','" & Me.CmbSerie.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        SqlUsuarios = "SELECT Usuario  FROM Usuarios"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)

        DataAdapter.Fill(DataSet, "ListaUsuarios")
        DataSet.Tables("ListaUsuarios").Reset()
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")

        End If

        MsgBox("El usuario se Grabo Correctamente!!", MsgBoxStyle.Information, "Sistema de Facturacion")
        Me.CboUsuario.Text = ""
        Me.TxtConfirmar.Visible = False
        Me.LblConfirmar.Visible = False

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim strusuario As String, SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        strusuario = "Select * FROM Usuarios Where Usuario= '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(strusuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [Usuarios] " & _
                           "WHERE [Usuario] = '" & Me.CboUsuario.Text & "' "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        SqlUsuarios = "SELECT Usuario  FROM Usuarios"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)

        DataAdapter.Fill(DataSet, "ListaUsuarios")
        DataSet.Tables("ListaUsuarios").Reset()
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")

        End If

        MsgBox("El Usuario se Elimino Correctamente", MsgBoxStyle.Information, "Sistema de Facturacion")

        Me.CboUsuario.Text = ""
        Me.TxtConfirmar.Visible = False
        Me.LblConfirmar.Visible = False
    End Sub

    Private Sub CboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SqlUsuarios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        If Me.CboNivel.Text = "Vendedores" Then
            Me.Size = New Size(326, 440)
            Me.LblTipoFactura.Visible = True
            Me.CboTipoProducto.Visible = True
            Me.LblVendedor.Visible = True
            Me.CboCodigoVendedor.Visible = True
            Me.LblCodigo.Visible = True
            Me.CboCodigoCliente.Visible = True
            Me.CmbSerie.Visible = True
            Me.Label3.Visible = True


            Me.TxtConfirmar.Location = New Point(101, 290)
            Me.TxtContraseña.Location = New Point(101, 262)
            Me.LblContraseña.Location = New Point(18, 264)
            Me.LblConfirmar.Location = New Point(18, 292)

        ElseIf Me.CboNivel.Text = "Vendedores 2" Then
            Me.Size = New Size(326, 440)
            Me.LblTipoFactura.Visible = True
            Me.CboTipoProducto.Visible = True
            Me.LblVendedor.Visible = True
            Me.CboCodigoVendedor.Visible = True
            Me.LblCodigo.Visible = True
            Me.CboCodigoCliente.Visible = True
            Me.CmbSerie.Visible = True
            Me.Label3.Visible = True


            Me.TxtConfirmar.Location = New Point(101, 290)
            Me.TxtContraseña.Location = New Point(101, 262)
            Me.LblContraseña.Location = New Point(18, 264)
            Me.LblConfirmar.Location = New Point(18, 292)

        Else

            Me.LblTipoFactura.Visible = False
            Me.CboTipoProducto.Visible = False
            Me.LblVendedor.Visible = False
            Me.CboCodigoVendedor.Visible = False
            Me.LblCodigo.Visible = False
            Me.CboCodigoCliente.Visible = False
            Me.Size = New Size(325, 342)
            Me.TxtConfirmar.Location = New Point(101, 188)
            Me.TxtContraseña.Location = New Point(101, 160)
            Me.LblContraseña.Location = New Point(18, 160)
            Me.LblConfirmar.Location = New Point(18, 190)

            Me.CmbSerie.Visible = False
            Me.Label3.Visible = False
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        'MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()
    End Sub

    Private Sub CboNivel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboNivel.TextChanged

    End Sub
End Class