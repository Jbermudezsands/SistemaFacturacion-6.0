Public Class FrmListaSolicitud
    Public Nuevo As Boolean = False
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public DataSet As New DataSet, DataSetGlobal As New DataSet

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Nuevo = True
        My.Forms.FrmNuevaSolicitud.TxtNumeroEnsamble.Text = "-----0-----"
        My.Forms.FrmNuevaSolicitud.TrueDBGridComponentes.Enabled = True
        My.Forms.FrmNuevaSolicitud.ShowDialog()
        Me.Nuevo = False
        BtnActualizar_Click(sender, e)
    End Sub

    Public Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.OptTodos.Checked = True Then
            SqlString = "SELECT DISTINCT Solicitud_Compra.Numero_Solicitud, Solicitud_Compra.Fecha_Solicitud, Solicitud_Compra.Fecha_Requerido, Solicitud_Compra.Departamento_Solicitante, Solicitud_Compra.Gerencia_Solicitante, Solicitud_Compra.Estado_Solicitud, Solicitud_Compra.Concepto FROM Detalle_Solicitud INNER JOIN Solicitud_Compra ON Detalle_Solicitud.Numero_Solicitud = Solicitud_Compra.Numero_Solicitud  WHERE (Detalle_Solicitud.Activo = 1) AND (Solicitud_Compra.Estado_Solicitud <> 'Anulado')"
        ElseIf Me.OptSinProcesar.Checked = True Then
            SqlString = "SELECT DISTINCT Solicitud_Compra.Numero_Solicitud, Solicitud_Compra.Fecha_Solicitud, Solicitud_Compra.Fecha_Requerido, Solicitud_Compra.Departamento_Solicitante, Solicitud_Compra.Gerencia_Solicitante, Solicitud_Compra.Estado_Solicitud, Solicitud_Compra.Concepto FROM Detalle_Solicitud INNER JOIN Solicitud_Compra ON Detalle_Solicitud.Numero_Solicitud = Solicitud_Compra.Numero_Solicitud  WHERE (Detalle_Solicitud.Activo = 1) AND (Solicitud_Compra.Estado_Solicitud <> 'Anulado') AND (Solicitud_Compra.Estado_Solicitud <> 'Procesado')"
        End If

        MiConexion.Open()
        DataSet.Reset()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lista")
        Me.BindingConsultas.DataSource = DataSet.Tables("Lista")
        Me.TDGridSolicitud.DataSource = Me.BindingConsultas

        Me.TDGridSolicitud.Columns("Numero_Solicitud").Caption = "Num Solictud"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Solicitud").Width = 80
        Me.TDGridSolicitud.Columns("Fecha_Solicitud").Caption = "Fecha Solicitud"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha_Solicitud").Width = 84
        Me.TDGridSolicitud.Columns("Fecha_Requerido").Caption = "Fecha Requerido"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha_Requerido").Width = 96
        Me.TDGridSolicitud.Columns("Departamento_Solicitante").Caption = "Departamento Solicitante"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Departamento_Solicitante").Width = 135
        Me.TDGridSolicitud.Columns("Gerencia_Solicitante").Caption = "Gerencia Solicitante"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Gerencia_Solicitante").Width = 150
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Concepto").Width = 250
        MiConexion.Close()
    End Sub

    Private Sub FrmListaSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Quien = "Load"
        BtnActualizar_Click(sender, e)
    End Sub

    Public Sub Autorizar_Solicitud()
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumSolicitud As String, Resultado As Double, iPosicion As Double

        MiConexion.Close()

        iPosicion = Me.TDGridSolicitud.Row
        NumSolicitud = Me.TDGridSolicitud.Item(iPosicion)("Numero_Solicitud")

        ''''''''''''''''''''''''''''''''CAMBIO EL ESTATUS DE LA SOLICITUD---------------------------------------------
        StrSqlUpdate = "UPDATE [Solicitud_Compra] SET [Estado_Solicitud] = 'Autorizado' WHERE (Numero_Solicitud = '" & NumSolicitud & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery


        StrSqlUpdate = "UPDATE [Detalle_Solicitud] SET [Autorizado] = 'True'  WHERE (Numero_Solicitud = '" & NumSolicitud & "')"
        'MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Autorizado con Exito!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumSolicitud As String, Resultado As Double, iPosicion As Double

        Resultado = MsgBox("�Esta Seguro de Anular la Solicitud?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = 6 Then
            Exit Sub
        End If

        MiConexion.Close()


        iPosicion = Me.TDGridSolicitud.Row
        NumSolicitud = Me.TDGridSolicitud.Item(iPosicion)("Numero_Solicitud")

        StrSqlUpdate = "UPDATE [dbo].[Solicitud_Compra] SET [Estado_Solicitud] = 'Anulado' WHERE (Numero_Solicitud = '" & NumSolicitud & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Me.BtnActualizar_Click(sender, e)
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Me.Nuevo = False
        My.Forms.FrmNuevaSolicitud.TxtNumeroEnsamble.Text = "-----0-----"
        My.Forms.FrmNuevaSolicitud.Estatus = Me.TDGridSolicitud.Columns("Estado_Solicitud").Text
        My.Forms.FrmNuevaSolicitud.TxtNumeroEnsamble.Text = Me.TDGridSolicitud.Columns("Numero_Solicitud").Text
        My.Forms.FrmNuevaSolicitud.ShowDialog()

        Me.Nuevo = False
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Dim Resultado As Double

        Resultado = MsgBox("�Esta Seguro de Autorizar la Solicitud?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = 6 Then
            Exit Sub
        End If

        Autorizar_Solicitud()
        Me.BtnActualizar_Click(sender, e)
    End Sub
    Private Function getFilter() As String
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim tmp As String = ""
        Dim n As Integer

        For Each col In Me.TDGridSolicitud.Columns

            If Trim(col.FilterText) <> "" Then
                n = n + 1
                If n > 1 Then
                    tmp = tmp & " AND "
                End If
                tmp = tmp & col.DataField & " LIKE '*" & col.FilterText & "*'"
            End If
        Next col

        getFilter = tmp

    End Function

    Private Sub TDGridSolicitud_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridSolicitud.FilterChange
        'Dim sb As New System.Text.StringBuilder()
        'Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn



        'For Each dc In Me.TDGridSolicitud.Columns
        '    If dc.FilterText.Length > 0 Then
        '        If sb.Length > 0 Then
        '            sb.Append(" AND ")
        '        End If
        '        sb.Append((dc.DataField + " LIKE " + "'%" + dc.FilterText + "%'"))
        '    End If
        'Next dc


        Me.DataSetGlobal.Tables("Lista").DefaultView.RowFilter = getFilter()  'sb.ToString()



    End Sub

    Private Sub TDGridSolicitud_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles TDGridSolicitud.RowColChange
        If Me.TDGridSolicitud.RowCount > 0 Then
            Select Case Me.TDGridSolicitud.Columns("Estado_Solicitud").Text
                Case "Autorizado" : Me.CmdNuevo.Enabled = False : Me.BtnVer.Enabled = True : Me.Button1.Enabled = True
                Case "Grabado" : Me.CmdNuevo.Enabled = True : Me.BtnVer.Enabled = True : Me.Button1.Enabled = True
                Case "Anulado" : Me.CmdNuevo.Enabled = False : Me.BtnVer.Enabled = False : Me.Button1.Enabled = False
                Case "Procesado" : Me.CmdNuevo.Enabled = False : Me.BtnVer.Enabled = True : Me.Button1.Enabled = False
            End Select
        End If
    End Sub

    Private Sub TDGridSolicitud_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridSolicitud.SizeChanged

    End Sub

    Private Sub TDGridSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridSolicitud.Click

    End Sub

    Private Sub OptTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTodos.CheckedChanged

    End Sub

    Private Sub OptSinProcesar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSinProcesar.CheckedChanged

    End Sub
End Class