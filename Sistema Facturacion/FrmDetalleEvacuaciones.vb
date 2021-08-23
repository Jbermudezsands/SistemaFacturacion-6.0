Public Class FrmDetalleEvacuaciones
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim Fecha As Date, Numero_Registro As Double, SQLString As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        Numero_Registro = Me.TDGridSolicitud.Columns("Numero_Registro").Text
        Fecha = Me.TDGridSolicitud.Columns("Fecha_Registro").Text

        SQLString = "SELECT  Registro_Transporte_Detalle.Numero_Registro, Registro_Transporte_Detalle.Fecha_Registro, Conductor.Nombre, Conductor.Licencia, Vehiculo.Placa, Vehiculo.Marca, Registro_Transporte_Detalle.Cod_Cliente, Registro_Transporte_Detalle.Id_Conductor, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Activo, Registro_Transporte_Detalle.Anulado, Registro_Transporte_Detalle.Procesado, Registro_Transporte_Detalle.idTipoContrato, Registro_Transporte_Detalle.Numero_Contrato, Conductor.Codigo FROM  Registro_Transporte_Detalle INNER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo INNER JOIN Vehiculo ON Registro_Transporte_Detalle.Id_Vehiculo = Vehiculo.IdVehiculo  " & _
            "WHERE (Registro_Transporte_Detalle.Numero_Registro = " & Numero_Registro & ") AND (Registro_Transporte_Detalle.Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Registro_Transporte_Detalle.Anulado = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRegistros")

        If DataSet.Tables("DetalleRegistros").Rows.Count <> 0 Then
            FrmRegistroTransporte.Nuevo = False
            FrmRegistroTransporte.FechaRegistro = DataSet.Tables("DetalleRegistros").Rows(0)("Fecha_Registro")
            'FrmRegistroTransporte.CmbContrato1.Text = DataSet.Tables("DetalleRegistros").Rows(0)("Fecha_Registro")
            FrmRegistroTransporte.NombreConductor = DataSet.Tables("DetalleRegistros").Rows(0)("Nombre")
            FrmRegistroTransporte.Placa = DataSet.Tables("DetalleRegistros").Rows(0)("Placa")
            FrmRegistroTransporte.NumeroContrato = DataSet.Tables("DetalleRegistros").Rows(0)("Numero_Contrato")
            FrmRegistroTransporte.ShowDialog()
        End If

        DataSet.Tables("DetalleRegistros").Reset()


        'FrmRegistroTransporte.TxtNombreContrato.Text




    End Sub

    Private Sub FrmDetalleEvacuaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Numero_Registro As String, Fecha As Date, SqlString As String, NumeroContrato As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, CodigoCliente As String = ""
        Dim ComandoUpdate As New SqlClient.SqlCommand, idVehiculo As Double, idContrato As Double, IdConductor As Double

        If MsgBox("Esta Seguro de Anular el registro", MsgBoxStyle.YesNo, "Zeus Facturacion") = MsgBoxResult.No Then
            Exit Sub
        End If


        Numero_Registro = Me.TDGridSolicitud.Columns("Numero_Registro").Text
        Fecha = Me.TDGridSolicitud.Columns("Fecha_Registro").Text

        SQLString = "SELECT  Registro_Transporte_Detalle.Numero_Registro, Registro_Transporte_Detalle.Fecha_Registro, Conductor.Nombre, Conductor.Licencia, Vehiculo.Placa, Vehiculo.Marca, Registro_Transporte_Detalle.Cod_Cliente, Registro_Transporte_Detalle.Id_Conductor, Registro_Transporte_Detalle.Id_Vehiculo, Registro_Transporte_Detalle.Activo, Registro_Transporte_Detalle.Anulado, Registro_Transporte_Detalle.Procesado, Registro_Transporte_Detalle.idTipoContrato, Registro_Transporte_Detalle.Numero_Contrato, Conductor.Codigo FROM  Registro_Transporte_Detalle INNER JOIN Conductor ON Registro_Transporte_Detalle.Id_Conductor = Conductor.Codigo INNER JOIN Vehiculo ON Registro_Transporte_Detalle.Id_Vehiculo = Vehiculo.IdVehiculo  " & _
            "WHERE (Registro_Transporte_Detalle.Numero_Registro = " & Numero_Registro & ") AND (Registro_Transporte_Detalle.Fecha_Registro BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Registro_Transporte_Detalle.Anulado = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRegistros")

        If DataSet.Tables("DetalleRegistros").Rows.Count <> 0 Then

            CodigoCliente = DataSet.Tables("DetalleRegistros").Rows(0)("Cod_Cliente")
            NumeroContrato = DataSet.Tables("DetalleRegistros").Rows(0)("Numero_Contrato")
            IdConductor = DataSet.Tables("DetalleRegistros").Rows(0)("Id_Conductor")
            idVehiculo = DataSet.Tables("DetalleRegistros").Rows(0)("Id_Vehiculo")
            idContrato = DataSet.Tables("DetalleRegistros").Rows(0)("idTipoContrato")

        End If

        GrabarRegistroEvacuaciones(NumeroContrato, Fecha, CodigoCliente, IdConductor, idVehiculo, idContrato, True, True, False, True)
    End Sub
End Class