Public Class FrmDetalleEvacuaciones

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim Fecha As Date, Numero_Registro As Double, SQLString As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        Numero_Registro = Me.TDGridSolicitud.Columns("Numero_Registro").Text
        Fecha = Me.TDGridSolicitud.Columns("Fecha_Registro").Text

        'SQLString = "SELECT  Registro_Transporte_Detalle.Numero_Registro, Registro_Transporte_Detalle.Fecha_Registro, Conductor.Nombre, Conductor.Licencia, Vehiculo.Placa, Vehiculo.Marca, Registro_Transporte_Detalle.Cod_Cliente, Registro_Transporte_Detalle.Id_Conductor, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Activo, Registro_Transporte_Detalle.Anulado, Registro_Transporte_Detalle.Procesado, Registro_Transporte_Detalle.idTipoContrato, Registro_Transporte_Detalle.Numero_Contrato, Conductor.Codigo FROM  Registro_Transporte_Detalle INNER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo INNER JOIN Vehiculo ON Registro_Transporte_Detalle.Id_Vehiculo = Vehiculo.IdVehiculo  " & _
        '    "WHERE (Registro_Transporte_Detalle.Numero_Registro = " & Numero_Registro & ") AND (Registro_Transporte_Detalle.Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Registro_Transporte_Detalle.Anulado = 0)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleRegistros")


    End Sub

    Private Sub FrmDetalleEvacuaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class