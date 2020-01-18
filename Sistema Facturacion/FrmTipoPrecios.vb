Public Class FrmTipoPrecios
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQL As String = "SELECT  *  FROM TipoPrecio WHERE  (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecios")
        If Not DataSet.Tables("TipoPrecios").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("TipoPrecios").Rows(0)("Tipo_Precio")) Then
                Me.TxtNombre.Text = DataSet.Tables("TipoPrecios").Rows(0)("Tipo_Precio")
            End If

            If Not IsDBNull(DataSet.Tables("TipoPrecios").Rows(0)("PrecioPorcentual")) Then
                If DataSet.Tables("TipoPrecios").Rows(0)("PrecioPorcentual") = "True" Then
                    Me.OptAplicar.Checked = True
                Else
                    Me.OptQuitar.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("TipoPrecios").Rows(0)("Porciento")) Then
                Me.TxtPorciento.Text = DataSet.Tables("TipoPrecios").Rows(0)("Porciento")
            End If

            If Not IsDBNull(DataSet.Tables("TipoPrecios").Rows(0)("Categoria")) Then
                Me.TxtCategoria.Text = DataSet.Tables("TipoPrecios").Rows(0)("Categoria")
            End If
        Else
            Me.TxtNombre.Text = ""
            Me.TxtPorciento.Text = ""
            Me.TxtCategoria.Text = ""
            Me.OptAplicar.Checked = True
            Me.ProgressBar.Visible = False
            Me.LblProducto.Visible = False
        End If

        Quien = "NOGrabado"
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLRubros As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim PrecioPorcentual As Integer

        If Me.OptAplicar.Checked = True Then
            PrecioPorcentual = 1
        Else
            PrecioPorcentual = 0
            Me.TxtPorciento.Text = 0
        End If



        SQLRubros = "SELECT  *  FROM TipoPrecio WHERE  (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRubros, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [TipoPrecio] SET [Tipo_Precio] =  '" & Me.TxtNombre.Text & "',[PrecioPorcentual] =  " & PrecioPorcentual & ",[Porciento] =  '" & Me.TxtPorciento.Text & "', [Categoria] =  '" & Me.TxtCategoria.Text & "' WHERE (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [TipoPrecio] ([Cod_TipoPrecio],[Tipo_Precio],[PrecioPorcentual],[Porciento],[Categoria]) " & _
                           "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "'," & PrecioPorcentual & ",'" & Me.TxtPorciento.Text & "','" & Me.TxtCategoria.Text & "')"
            
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        If Quien <> "Aplicado" Then
            Quien = "Grabado"
            Button1_Click(sender, e)
        End If


        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM TipoPrecio"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoPrecio")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub FrmTipoPrecios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Tipos de Precios")
    End Sub

    Private Sub FrmTipoPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT  Cod_TipoPrecio, Tipo_Precio FROM TipoPrecio"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoPrecio")
        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Tipo Precio?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        SQLProveedor = "SELECT  *  FROM TipoPrecio WHERE  (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [TipoPrecio]  WHERE (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM TipoPrecio "
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoPrecio")
        End If

        Me.CboCodigoCliente.Text = ""
        Quien = "NOGrabado"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrecios.Click
        Quien = "CodigoTipoPrecio"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CodigoPrecio As String, CodProducto As String
        Dim SqlString As String, CostoUnitario As Double = 0, TasaCambio As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CantRegistro As Double, i As Double, FechaFin As String, PrecioVenta As Double = 0, Incremento As Double = 0

        FechaFin = Format(Now, "dd/MM/yyyy")
        If Me.TxtPorciento.Text = "" Then
            Exit Sub
        End If


        If Me.OptQuitar.Checked = True Then
            StrSqlUpdate = "DELETE FROM [Precios] WHERE (Cod_TipoPrecio = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            If Not Quien = "Grabado" Then
                Quien = "Aplicado"
                CmdGrabar_Click(sender, e)
                Quien = "NOaplicado"
            End If

            Exit Sub
        End If

        Incremento = 1 + (CDbl(Me.TxtPorciento.Text) / 100)
        TasaCambio = BuscaTasaCambio(FechaFin)

        SqlString = "SELECT  * FROM Productos  WHERE  (Activo = 'Activo')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Productos")
        CantRegistro = DataSet.Tables("Productos").Rows.Count

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = CantRegistro
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = True
        Me.LblProducto.Visible = True


        i = 0
        Do While i < CantRegistro


            CodProducto = DataSet.Tables("Productos").Rows(i)("Cod_Productos")
            CodigoPrecio = Me.CboCodigoCliente.Text
            'CostoUnitario = CostoPromedioKardex(CodProducto, FechaFin)
            'PrecioVenta = CostoUnitario * Incremento
            Me.LblProducto.Text = "Procesando: " & CodProducto
            My.Application.DoEvents()


            SqlString = "SELECT Cod_Productos, Cod_TipoPrecio, Monto_Precio, Monto_PrecioDolar FROM Precios WHERE (Cod_Productos = '" & CodProducto & "') AND (Cod_TipoPrecio = '" & CodigoPrecio & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Precios")
            If DataSet.Tables("Precios").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Precios] ([Cod_Productos] ,[Cod_TipoPrecio] ,[Monto_Precio] ,[Monto_PrecioDolar]) " & _
                       "VALUES('" & CodProducto & "','" & CodigoPrecio & "',0,0)"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
            i = i + 1
            Me.ProgressBar.Value = i
        Loop

        If Not Quien = "Grabado" Then
            Quien = "Aplicado"
            CmdGrabar_Click(sender, e)
            Quien = "NOaplicado"
        End If
    End Sub

    Private Sub OptQuitar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptQuitar.CheckedChanged
        If Me.OptQuitar.Checked = True Then
            Me.TxtPorciento.Visible = False
            Me.LblPorciento.Visible = False

        End If
    End Sub

    Private Sub OptAplicar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAplicar.CheckedChanged
        Me.TxtPorciento.Visible = True
        Me.LblPorciento.Visible = True
    End Sub
End Class