Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepCatalogoProductos 
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SqlString As String, Existencia As Double = 0, iPosicionFila As Double = 0, CodigoBodega As String
        Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////
        CodigoProducto = Me.TxtCodigo.Text
        SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                    "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////
        Existencia = 0
        iPosicionFila = 0
        Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
            My.Application.DoEvents()
            CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")
            'ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
            'Existencia = Existencia + ExistenciaBodega
            MiConexion.Close()
            FrmReportes.Text = " Procesando " & CodigoProducto
            iPosicionFila = iPosicionFila + 1
        Loop
        Me.TxtExistencia.Text = Format(Existencia, "##,##0.00")
        DataSet.Tables("Bodegas").Reset()

    End Sub
End Class
