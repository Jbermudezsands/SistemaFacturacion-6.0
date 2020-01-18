Public Class FrmProcesar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter
    Private Sub CmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConsultar.Click
        Dim SqlString As String

        SqlString = "SELECT DISTINCT YEAR(Fecha_Factura) AS Año, DATENAME(Month, Fecha_Factura) AS Mes, MONTH(Fecha_Factura) AS Nmes, COUNT(Numero_Factura) AS NFacturas FROM Facturas " & _
              "WHERE(Activo = 1) GROUP BY YEAR(Fecha_Factura), DATENAME(Month, Fecha_Factura), MONTH(Fecha_Factura) ORDER BY Año, Nmes"

        ds = New DataSet
        da = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        da.Fill(ds, "DetalleFactura")
        Me.TrueDBGridConsultas.DataSource = ds.Tables("DetalleFactura")
    End Sub

    Private Sub FrmProcesar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class