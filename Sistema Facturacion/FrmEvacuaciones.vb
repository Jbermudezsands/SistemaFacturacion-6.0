Imports System.Data.SqlClient
Public Class FrmEvacuaciones
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder

    Private Sub FrmEvacuaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Dias As Double, SQlString As String, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.DTPFechaInicio.Value = DateSerial(Now.Year, Now.Month, 1)
        Me.DTPFechaFin.Value = DateSerial(Now.Year, Now.Month + 1, 0)

        Dias = DateDiff(DateInterval.Day, Me.DTPFechaInicio.Value, Me.DTPFechaFin.Value) + 1

        For i = 1 To Dias

            If i = 1 Then
                SQlString = "SELECT Nombre_Cliente, Cod_Cliente As '" & i & "' "
            Else
                SQlString = SQlString & ",Cod_Cliente As  '" & i & "' "
            End If



        Next

        SQlString = SQlString & " FROM Clientes WHERE (Cod_Cliente = '-10000000')"


        ds = New DataSet
        da = New SqlDataAdapter(SQlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleRegistros")
        Me.TDGridSolicitud.DataSource = ds.Tables("DetalleRegistros")
        Me.TDGridSolicitud.Splits(0).DisplayColumns(0).Width = 200

        For i = 1 To Dias
            Me.TDGridSolicitud.Splits(0).DisplayColumns(i.ToString).Width = 25
        Next


        Sqlstring = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "TipoContrato")
        If DataSet.Tables("TipoContrato").Rows.Count <> 0 Then
            Me.CmbContrato1.Items.Add(DataSet.Tables("TipoContrato").Rows(0)("TipoContrato"))
        End If


    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbContrato1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbContrato1.SelectedIndexChanged

    End Sub
End Class