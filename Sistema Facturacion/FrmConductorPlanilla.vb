Public Class FrmConductorPlanilla

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

        Me.TxtCedula.Text = ""
        Me.TxtLicencia.Text = ""
        Me.TxtMotivo.Text = ""
        Me.TxtNombre.Text = ""
        Me.CboCodigoConductor.Text = ""
        Me.CboLstaNegra.Text = "No"
        Me.CboActivo.Text = "Activo"
        Me.TxtCtaxPagar.Text = ""
        Me.TxtCtaBanco.Text = ""
        Me.TxtAnticipo.Text = ""
        Me.TxtCtaBolsa.Text = ""
        Me.TxtCtaGastoPlanilla.Text = ""
        Me.TxtCtaInseminacion.Text = ""
        Me.TxtCtaIr.Text = ""
        Me.TxtCtaOtras.Text = ""
        Me.TxtCtaTransporte.Text = ""
        Me.TxtCtaTrazabilidad.Text = ""
        Me.TxtCtaVeterinario.Text = ""
        Me.TxtPrecio.Text = ""
        Me.TxtPulperia.Text = ""



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
        SqlString = "SELECT * FROM Conductor WHERE (Codigo = '" & Codigo & "')"
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

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Precio")) Then
                Me.TxtPrecio.Text = DataSet.Tables("Conductor").Rows(0)("Precio")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Banco")) Then
                Me.TxtCtaBanco.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Banco")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_IR")) Then
                Me.TxtCtaIr.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_IR")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Bolsa")) Then
                Me.TxtCtaBolsa.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Bolsa")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Anticipo")) Then
                Me.TxtAnticipo.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Anticipo")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Pulperia")) Then
                Me.TxtPulperia.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Pulperia")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Transporte")) Then
                Me.TxtCtaTransporte.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Transporte")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Inseminacion")) Then
                Me.TxtCtaInseminacion.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Inseminacion")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Trazabilidad")) Then
                Me.TxtCtaTrazabilidad.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Trazabilidad")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Veterinario")) Then
                Me.TxtCtaVeterinario.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Veterinario")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Otras")) Then
                Me.TxtCtaOtras.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Otras")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_GastoPlanilla")) Then
                Me.TxtCtaGastoPlanilla.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_GastoPlanilla")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Cuenta_Contable")) Then
                Me.TxtCtaxPagar.Text = DataSet.Tables("Conductor").Rows(0)("Cuenta_Contable")
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
        Dim ListaNegra As Double


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

        MiConexion.Close()

        SQLString = "SELECT  Codigo, Nombre, Cedula, Activo FROM Conductor WHERE (Codigo = '" & Me.CboCodigoConductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Conductor]  SET [Nombre] = '" & Me.TxtNombre.Text & "',[Cedula] = '" & Me.TxtCedula.Text & "',[Licencia] = '" & Me.TxtLicencia.Text & "'  ,[Activo] = " & Activo & ",[ListaNegra] = " & ListaNegra & ",[RazonListaNegra]= '" & Me.TxtMotivo.Text & "' ,[Cuenta_Contable]= '" & Me.TxtCtaxPagar.Text & "', [Precio]= '" & Me.TxtPrecio.Text & "', [Cuenta_Banco]= '" & Me.TxtCtaBanco.Text & "', [Cuenta_IR]= '" & Me.TxtCtaIr.Text & "', [Cuenta_Bolsa]= '" & Me.TxtCtaBolsa.Text & "', [Cuenta_Anticipo]= '" & Me.TxtAnticipo.Text & "',  [Cuenta_Pulperia]= '" & Me.TxtPulperia.Text & "',[Cuenta_Transporte]= '" & Me.TxtCtaTransporte.Text & "', [Cuenta_Inseminacion]= '" & Me.TxtCtaInseminacion.Text & "', [Cuenta_Trazabilidad]= '" & Me.TxtCtaTrazabilidad.Text & "', [Cuenta_Veterinario]= '" & Me.TxtCtaVeterinario.Text & "', [Cuenta_Otras]= '" & Me.TxtCtaOtras.Text & "', [Cuenta_GastoPlanilla]= '" & Me.TxtCtaGastoPlanilla.Text & "'  WHERE (Activo = 1) AND (Codigo = '" & Me.CboCodigoConductor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Conductor] ([Codigo],[Nombre],[Cedula],[Licencia],[ListaNegra],[RazonListaNegra],[Activo],[Cuenta_Contable],[Precio],[Cuenta_Banco],[Cuenta_IR],[Cuenta_Bolsa],[Cuenta_Anticipo],[Cuenta_Pulperia],[Cuenta_Transporte],[Cuenta_Inseminacion],[Cuenta_Trazabilidad],[Cuenta_Veterinario],[Cuenta_Otras],[Cuenta_GastoPlanilla]) VALUES ('" & Me.CboCodigoConductor.Text & "' ,'" & Me.TxtNombre.Text & "' ,'" & Me.TxtCedula.Text & "', '" & Me.TxtLicencia.Text & "', " & ListaNegra & ", '" & Me.TxtMotivo.Text & "', " & Activo & ", '" & Me.TxtCtaxPagar.Text & "', '" & Me.TxtPrecio.Text & "', '" & Me.TxtCtaBanco.Text & "', '" & Me.TxtCtaIr.Text & "', '" & Me.TxtCtaBolsa.Text & "', '" & Me.TxtAnticipo.Text & "', '" & Me.TxtPulperia.Text & "', '" & Me.TxtCtaTransporte.Text & "', '" & Me.TxtCtaInseminacion.Text & "', '" & Me.TxtCtaTrazabilidad.Text & "', '" & Me.TxtCtaVeterinario.Text & "', '" & Me.TxtCtaOtras.Text & "', '" & Me.TxtCtaGastoPlanilla.Text & "') "


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

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaTransporte.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaInseminacion.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaTrazabilidad.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaBolsa.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtAnticipo.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaVeterinario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtPulperia.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaOtras.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaGastoPlanilla.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaBanco.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Quien = "CuentasContables"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaIr.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class