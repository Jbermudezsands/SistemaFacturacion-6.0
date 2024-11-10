Public Class FrmProyectos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmProyectos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Proyectos")
    End Sub
    Private Sub Proyectos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String

        Sql = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin, Moneda, VentaEstimada, CostoEstimado, Activo FROM Proyectos "


        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Proyectos")
        End If

        Me.DtpFechaFin.Value = Format(Now, "dd/MM/yyyy")
        Me.DtpFechaInicio.Value = Format(Now, "dd/MM/yyyy")



    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLProyectos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Activo As Boolean = Me.ChkActivo.Checked



        SQLProyectos = "SELECT * FROM Proyectos WHERE  (CodigoProyectos = '" & Me.CboCodigoCliente.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProyectos, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            StrSqlUpdate = "Update Proyectos SET [NombreProyectos] = '" & Me.TxtNombre.Text & "',[FechaInicio] = '" & Me.DtpFechaInicio.Value & "',[FechaFin] = '" & Me.DtpFechaFin.Value & "' ,[Moneda] = '" & Me.TxtMonedaFactura.Text & "'  ,[VentaEstimada] = " & Me.TxtVentaEstimada.Text & " ,[CostoEstimado] = " & Me.TxtCostoEstimado.Text & " ,[Activo] = '" & Activo & "'  WHERE (CodigoProyectos = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Proyectos] ([CodigoProyectos],[NombreProyectos],[FechaInicio],[FechaFin],[Moneda],[VentaEstimada],[CostoEstimado],[Activo]) " & _
                           "VALUES ('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "','" & Me.DtpFechaInicio.Value & "','" & Me.DtpFechaFin.Value & "' ,'" & Me.TxtMonedaFactura.Text & "' ,'" & Me.TxtVentaEstimada.Text & "' ,'" & Me.TxtCostoEstimado.Text & "'  ,'" & Activo & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Bitacora(Now, NombreUsuario, "Proyectos", "Grabo el Proyecto: " & Me.TxtNombre.Text)
        Dim Sql As String = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin, Moneda, VentaEstimada, CostoEstimado, Activo  FROM Proyectos"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Tables("Proyectos").Reset()
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Proyectos")

        End If

        Me.CboCodigoCliente.Text = ""

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub DtpFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaFin.ValueChanged
        Me.TxtDias.Value = DateDiff(DateInterval.Day, Me.DtpFechaInicio.Value, Me.DtpFechaFin.Value)
    End Sub

    Private Sub DtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaInicio.ValueChanged
        Me.TxtDias.Value = DateDiff(DateInterval.Day, Me.DtpFechaInicio.Value, Me.DtpFechaFin.Value)
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQLProyectos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Activo As Boolean = Me.ChkActivo.Checked

        SQLProyectos = "SELECT * FROM Proyectos WHERE  (CodigoProyectos = '" & Me.CboCodigoCliente.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProyectos, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.TxtNombre.Text = DataSet.Tables("Proyectos").Rows(0)("NombreProyectos")
            Me.DtpFechaInicio.Value = DataSet.Tables("Proyectos").Rows(0)("FechaInicio")
            Me.DtpFechaFin.Value = DataSet.Tables("Proyectos").Rows(0)("FechaFin")
            Me.TxtMonedaFactura.Text = DataSet.Tables("Proyectos").Rows(0)("Moneda")
            Me.TxtVentaEstimada.Text = DataSet.Tables("Proyectos").Rows(0)("VentaEstimada")
            Me.TxtCostoEstimado.Text = DataSet.Tables("Proyectos").Rows(0)("CostoEstimado")

            Me.TxtVentaEstimada2.Text = Format(DataSet.Tables("Proyectos").Rows(0)("VentaEstimada"), "##,##0.00")
            Me.TxtCostoEstimado2.Text = Format(DataSet.Tables("Proyectos").Rows(0)("CostoEstimado"), "##,##0.00")
            Me.TxtUtilidadEstimada.Text = CDbl(DataSet.Tables("Proyectos").Rows(0)("VentaEstimada")) - CDbl(DataSet.Tables("Proyectos").Rows(0)("CostoEstimado"))
            Me.TxtPorcientoEstimado.Text = Format(CDbl(DataSet.Tables("Proyectos").Rows(0)("CostoEstimado")) / CDbl(DataSet.Tables("Proyectos").Rows(0)("VentaEstimada")), "0.00%")

            If DataSet.Tables("Proyectos").Rows(0)("Activo") = "True" Then
                Me.ChkActivo.Checked = True
            Else
                Me.ChkActivo.Checked = False
            End If

        Else

            Me.TxtNombre.Text = ""
            Me.DtpFechaInicio.Value = Format(Now, "dd/MM/yyyy")
            Me.DtpFechaFin.Value = Format(Now, "dd/MM/yyyy")
            Me.TxtMonedaFactura.Text = ""
            Me.TxtVentaEstimada.Text = ""
            Me.TxtCostoEstimado.Text = ""
            Me.ChkActivo.Checked = True

            Me.TxtVentaEstimada2.Text = ""
            Me.TxtCostoEstimado2.Text = ""
            Me.TxtUtilidadEstimada.Text = ""
            Me.TxtPorcientoEstimado.Text = ""

        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProyectos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, Resultado As Integer, iResultado As Integer
        Dim Activo As Boolean = Me.ChkActivo.Checked

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Proyecto?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProyectos = "SELECT * FROM Proyectos WHERE  (CodigoProyectos = '" & Me.CboCodigoCliente.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProyectos, MiConexion)
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Proyectos] WHERE (CodigoProyectos = '" & Me.CboCodigoCliente.Text & "') "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Proyectos", "Grabo el Proyecto: " & Me.TxtNombre.Text)
        Dim Sql As String = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin, Moneda, VentaEstimada, CostoEstimado, Activo  FROM Proyectos"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Tables("Proyectos").Reset()
        DataAdapter.Fill(DataSet, "Proyectos")
        If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Proyectos")

        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Proyectos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub FrmProyectos_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

    End Sub
End Class