Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepAdmision 

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ArepAdmision_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim SqlDatos As String, ds As New DataSet

        Sqldatos = "SELECT * FROM DatosEmpresa"
        ds = BuscaConsulta(SqlDatos, "DatosEmpresa").Copy
        If ds.Tables("DatosEmpresa").Rows.Count <> 0 Then
            Me.LblTitulo.Text = ds.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            'Me.LblDireccion.Text = ds.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
        End If

        Me.TxtImpreso.Text = "Impreso: " & Format(Now, "dd/MM/yyyy HH:mm:ss")


    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub
End Class
