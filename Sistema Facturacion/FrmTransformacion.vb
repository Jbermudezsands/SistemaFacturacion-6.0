Public Class FrmTransformacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Public Sub ActualizarGrid()
        Dim SqlString As String = "", DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        If Me.OptTodos.Checked = True Then
            SqlString = "SELECT  Numero_Transforma As Numero, Fecha_Transforma As Fecha, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion  WHERE (Anulado = 0)"
        ElseIf Me.OptActivos.Checked = True Then
            SqlString = "SELECT  Numero_Transforma As Numero, Fecha_Transforma AS Fecha, BodegaOrigen, BodegaDestino, Observaciones, Activo, Procesado, Anulado FROM Transformacion WHERE (Anulado = 0) AND (Activo = 1)"
        End If
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lista")
        Me.TDGridSolicitud.DataSource = DataSet.Tables("Lista")

        If Me.TDGridSolicitud.RowCount <> 0 Then
            Me.TDGridSolicitud.Columns("Numero_Transforma").Caption = "Numero"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Transforma").Width = 80
            Me.TDGridSolicitud.Columns("Fecha_Transforma").Caption = "Fecha"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha").Width = 84
            Me.TDGridSolicitud.Columns("BodegaOrigen").Caption = "Bodega Origen"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("BodegaOrigen").Width = 70
            Me.TDGridSolicitud.Columns("BodegaDestino").Caption = "BodegaDestino"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("BodegaDestino").Width = 70
            Me.TDGridSolicitud.Columns("Observaciones").Caption = "Observaciones"
            Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Observaciones").Width = 150
        End If
        MiConexion.Close()
    End Sub

    Private Sub FrmTransformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizarGrid()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        ActualizarGrid()
    End Sub

    Private Sub OptTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTodos.CheckedChanged
        ActualizarGrid()
    End Sub

    Private Sub OptActivos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptActivos.CheckedChanged
        ActualizarGrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        My.Forms.TransformacionNueva.ShowDialog()
    End Sub
End Class