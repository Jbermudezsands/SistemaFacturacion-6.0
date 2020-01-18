Public Class FrmNotaDebito
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CuentaGeneral"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentas.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub C1Combo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCodigo.TextChanged
        Dim SQL As String = "SELECT  *  FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Notas").Rows(0)("Tipo")) Then
                Me.CmbTipo.Text = DataSet.Tables("Notas").Rows(0)("Tipo")
            End If
            If Not IsDBNull(DataSet.Tables("Notas").Rows(0)("Descripcion")) Then
                Me.TxtDescripcion.Text = DataSet.Tables("Notas").Rows(0)("Descripcion")
            End If
            If Not IsDBNull(DataSet.Tables("Notas").Rows(0)("CuentaContable")) Then
                Me.TxtCuentas.Text = DataSet.Tables("Notas").Rows(0)("CuentaContable")
            End If



        Else
            Me.TxtCuentas.Text = ""
            Me.TxtDescripcion.Text = ""

        End If


    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CmbCodigo.Text = ""
        Me.TxtCuentas.Text = ""
        Me.TxtDescripcion.Text = ""

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQL As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        SQL = "SELECT  *  FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE NotaDebito  SET [Descripcion] = '" & Me.TxtDescripcion.Text & "' ,[CuentaContable] = '" & Me.TxtCuentas.Text & "' WHERE (CodigoNB = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO NotaDebito ([CodigoNB],[Tipo],[Descripcion],[CuentaContable]) " & _
                           "VALUES ('" & Me.CmbCodigo.Text & "','" & Me.CmbTipo.Text & "','" & Me.TxtDescripcion.Text & "','" & Me.TxtCuentas.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Bitacora(Now, NombreUsuario, "NOTA DEBITO,CREDITO", "Grabo DB: " & Me.TxtDescripcion.Text)
        Dim SqlString As String = "SELECT  *  FROM NotaDebito "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Tables("Notas").Reset()
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")

        End If

        CmdNuevo_Click(sender, e)
    End Sub

    Private Sub FrmNotaDebito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Tipos de Precios")
    End Sub

    Private Sub FrmNotaDebito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String = "SELECT  * FROM NotaDebito "
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataSet.Tables("Notas").Reset()
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Notas")

        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar esta Nota?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT  *  FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "NOTA DEBITO,CREDITO", "Elimino DBCR: " & Me.TxtDescripcion.Text)
        Dim SqlString As String = "SELECT  *  FROM NotaDebito "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Tables("Notas").Reset()
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoNotas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbCodigo.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class