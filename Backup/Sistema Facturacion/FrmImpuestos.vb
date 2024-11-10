Public Class FrmImpuestos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmImpuestos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Impuestos")
    End Sub

    Private Sub FrmImpuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT     Cod_Iva, Descripcion_Iva FROM Impuestos"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            Me.CboCodigoImpuesto.DataSource = DataSet.Tables("Impuestos")

        End If
    End Sub

    Private Sub CboCodigoImpuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoImpuesto.TextChanged
        Dim SQL As String = "SELECT  Impuestos.* FROM Impuestos WHERE (Cod_Iva = '" & Me.CboCodigoImpuesto.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        Dim TipoImpuesto As String, Activo As String

        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")) Then
                Me.TxtNombre.Text = DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")
            End If
            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("Impuesto")) Then
                Me.TxtValor.Text = DataSet.Tables("Impuestos").Rows(0)("Impuesto")
            End If
            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("TipoImpuesto")) Then
                TipoImpuesto = DataSet.Tables("Impuestos").Rows(0)("TipoImpuesto")
                Select Case TipoImpuesto
                    Case "IVA"
                        Me.OptIVA.Checked = True
                    Case "RETENCION"
                        Me.OptRetencion.Checked = True
                End Select
            End If

            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("Activo")) Then
                Activo = DataSet.Tables("Impuestos").Rows(0)("Activo")
                If Activo = "SI" Then
                    Me.ChkActivo.Checked = True
                Else
                    Me.ChkActivo.Checked = False
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("ImpuestoxCobrar")) Then
                Me.TxtImpuestoxCobrar.Text = DataSet.Tables("Impuestos").Rows(0)("ImpuestoxCobrar")
            End If

            If Not IsDBNull(DataSet.Tables("Impuestos").Rows(0)("ImpuestoxPagar")) Then
                Me.TxtImpuestoxPagar.Text = DataSet.Tables("Impuestos").Rows(0)("ImpuestoxPagar")
            End If

        Else
            Me.TxtNombre.Text = ""
            Me.TxtValor.Text = ""
            Me.TxtImpuestoxCobrar.Text = ""
            Me.TxtImpuestoxPagar.Text = ""
        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim StrSql As String, Valor As Double, TipoImpuesto As String, Activo As String

        If Me.OptIVA.Checked = True Then
            TipoImpuesto = "IVA"
        Else
            TipoImpuesto = "RETENCION"
        End If

        If Me.ChkActivo.Checked = True Then
            Activo = "SI"
        Else
            Activo = "NO"
        End If

        If Me.TxtNombre.Text = "" Then
            MsgBox("Se necesita el Nombre de la linea", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboCodigoImpuesto.Text = "" Then
            MsgBox("Se necesita el Codigo del Impuesto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtValor.Text = "" Then
            MsgBox("Se necesita el Valor", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtValor.Text) Then
            MsgBox("Para el Campo Valor es necesario que sea numerico", MsgBoxStyle.Critical, "Sistema de Facturacio")
            Exit Sub
        End If

        Valor = Me.TxtValor.Text

        SQLProveedor = "SELECT  Impuestos.* FROM Impuestos WHERE (Cod_Iva = '" & Me.CboCodigoImpuesto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Impuestos] SET [Descripcion_Iva] = '" & Me.TxtNombre.Text & "',[Impuesto] = " & Valor & ",[TipoImpuesto] = '" & TipoImpuesto & "',[Activo] = '" & Activo & "',[ImpuestoxPagar] = '" & Me.TxtImpuestoxPagar.Text & "',[ImpuestoxCobrar] = '" & Me.TxtImpuestoxCobrar.Text & "'  WHERE (Cod_Iva = '" & Me.CboCodigoImpuesto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Impuestos]([Cod_Iva],[Descripcion_Iva],[Impuesto],[TipoImpuesto],[Activo],[ImpuestoxPagar],[ImpuestoxCobrar]) " & _
                           "VALUES('" & Me.CboCodigoImpuesto.Text & "','" & Me.TxtNombre.Text & "'," & Valor & ",'" & TipoImpuesto & "','" & Activo & "','" & Me.TxtImpuestoxPagar.Text & "','" & Me.TxtImpuestoxCobrar.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        StrSql = "SELECT  Cod_Iva, Descripcion_Iva FROM Impuestos"
        DataAdapter = New SqlClient.SqlDataAdapter(StrSql, MiConexion)
        DataSet.Tables("Impuestos").Reset()
        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            Me.CboCodigoImpuesto.DataSource = DataSet.Tables("Impuestos")

        End If
        Me.CboCodigoImpuesto.Text = ""
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




        SQLProveedor = "SELECT  Impuestos.* FROM Impuestos WHERE (Cod_Iva = '" & Me.CboCodigoImpuesto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Impuestos] WHERE (Cod_Iva = '" & Me.CboCodigoImpuesto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        StrSQl = "SELECT  Cod_Iva, Descripcion_Iva FROM Impuestos"
        DataAdapter = New SqlClient.SqlDataAdapter(StrSQl, MiConexion)
        DataSet.Tables("Impuestos").Reset()
        DataAdapter.Fill(DataSet, "Impuestos")
        If Not DataSet.Tables("Impuestos").Rows.Count = 0 Then
            Me.CboCodigoImpuesto.DataSource = DataSet.Tables("Impuestos")

        End If
        Me.CboCodigoImpuesto.Text = ""
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoImpuesto.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoImpuestos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoImpuesto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrarInteres"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtImpuestoxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaPagarInteres"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtImpuestoxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class