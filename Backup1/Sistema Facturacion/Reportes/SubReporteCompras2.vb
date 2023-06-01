Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 


Public Class SubReporteCompras2
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SqlDatos As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Cantidad As Double

        If Me.TxtCantidad1.Text <> "" Then
            Cantidad = Me.TxtCantidad1.Text
        End If
        TotalUnidades = TotalUnidades + Cantidad
        Me.TxtSaldo.Text = Format(TotalUnidades, "##,##0.00")

        SqlDatos = "SELECT * FROM Compras WHERE (Numero_Compra = '" & Me.TxtNumero.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Compra")
        If Not DataSet.Tables("Compra").Rows.Count = 0 Then
            Me.TxtReferencia.Text = DataSet.Tables("Compra").Rows(0)("Observaciones")
        Else
            Me.TxtReferencia.Text = ""
        End If


        If Me.TxtTipo.Text = "Devolucion de Compra" Then
            Me.TxtCantidad1.Visible = False
            Me.TxtImporte1.Visible = False
            Me.TxtCantidad2.Visible = True
            Me.TxtImporte2.Visible = True
        Else
            Me.TxtCantidad1.Visible = True
            Me.TxtImporte1.Visible = True
            Me.TxtCantidad2.Visible = False
            Me.TxtImporte2.Visible = False
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
