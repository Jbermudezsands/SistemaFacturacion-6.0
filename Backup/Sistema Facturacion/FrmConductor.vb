Public Class FrmConductor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Sub LimpiaConductor()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")
        'If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
        '    Me.CboCodigoConductor.Text = DataSet.Tables("Conductor").Rows(0)("Nombre")
        'End If
        'Me.CboCodigoConductor.Columns(0).Caption = "Codigo"

        Me.ChkConductores.Checked = False
        Me.TxtCedula.Text = ""
        Me.TxtLicencia.Text = ""
        Me.TxtMotivo.Text = ""
        Me.TxtNombre.Text = ""
        Me.CboCodigoConductor.Text = ""
        Me.CboLstaNegra.Text = "No"
        Me.CboActivo.Text = "Activo"
        Me.TxtCtaxPagar.Text = ""

    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub



    Private Sub FrmConductor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboCodigoConductor.DataSource = DataSet.Tables("Conductor")
        'If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
        '    Me.CboCodigoConductor.Text = DataSet.Tables("Conductor").Rows(0)("Nombre")
        'End If
        'Me.CboCodigoConductor.Columns(0).Caption = "Codigo"
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboCodigoConductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoConductor.TextChanged

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Codigo As String
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Codigo = Me.CboCodigoConductor.Text
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra, Evacuaciones FROM Conductor WHERE (Codigo = '" & Codigo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Nombre")) Then
                Me.TxtNombre.Text = DataSet.Tables("Conductor").Rows(0)("Nombre")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cedula")) Then
                Me.TxtCedula.Text = DataSet.Tables("Conductor").Rows(0)("Cedula")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Licencia")) Then
                Me.TxtLicencia.Text = DataSet.Tables("Conductor").Rows(0)("Licencia")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("RazonListaNegra")) Then
                Me.TxtMotivo.Text = DataSet.Tables("Conductor").Rows(0)("RazonListaNegra")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Activo")) Then
                If DataSet.Tables("Conductor").Rows(0)("Activo") = True Then
                    Me.CboActivo.Text = "Activo"
                Else
                    Me.CboActivo.Text = "Inactivo"
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("ListaNegra")) Then
                If DataSet.Tables("Conductor").Rows(0)("ListaNegra") = True Then
                    Me.CboLstaNegra.Text = "Activo"
                Else
                    Me.CboLstaNegra.Text = "Inactivo"
                End If
            End If


            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Evacuaciones")) Then
                Me.ChkConductores.Checked = DataSet.Tables("Conductor").Rows(0)("Evacuaciones")
            End If

        End If
        Me.CboCodigoConductor.Columns(0).Caption = "Codigo"

        MiConexion.Close()

    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        LimpiaConductor()
    End Sub

    Private Sub ButtonGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGrabar.Click
        Dim SQLString As String, Activo As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim ListaNegra As Double, Evacuaciones As Double


        If Me.CboActivo.Text = "Activo" Then
            Activo = 1
        Else
            Activo = 0
        End If

        If Me.CboLstaNegra.Text = "Activo" Then
            ListaNegra = 1
        Else
            ListaNegra = 0
        End If

        If Me.ChkConductores.Checked = True Then
            Evacuaciones = 1
        Else
            Evacuaciones = 0
        End If

        MiConexion.Close()

        SQLString = "SELECT  Codigo, Nombre, Cedula, Activo FROM Conductor WHERE (Codigo = '" & Me.CboCodigoConductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Conductor]  SET [Nombre] = '" & Me.TxtNombre.Text & "',[Cedula] = '" & Me.TxtCedula.Text & "',[Licencia] = '" & Me.TxtLicencia.Text & "'  ,[Activo] = " & Activo & ",[ListaNegra] = " & ListaNegra & ",[RazonListaNegra]= '" & Me.TxtMotivo.Text & "' ,[Cuenta_Contable]= '" & Me.TxtCtaxPagar.Text & "',[Evacuaciones]= " & Evacuaciones & "  WHERE (Activo = 1) AND (Codigo = '" & Me.CboCodigoConductor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Conductor] ([Codigo],[Nombre],[Cedula],[Licencia],[ListaNegra],[RazonListaNegra],[Activo],[Cuenta_Contable],[Evacuaciones]) VALUES ('" & Me.CboCodigoConductor.Text & "' ,'" & Me.TxtNombre.Text & "' ,'" & Me.TxtCedula.Text & "', '" & Me.TxtLicencia.Text & "', " & ListaNegra & ", '" & Me.TxtMotivo.Text & "', " & Activo & ", '" & Me.TxtCtaxPagar.Text & "', " & Evacuaciones & ") "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        LimpiaConductor()

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Conductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoConductor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class