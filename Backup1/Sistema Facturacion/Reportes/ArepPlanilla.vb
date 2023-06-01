Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document

Public Class ArepPlanilla


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Dim Precio As Double = 0, Lunes As Double = 0, Martes As Double = 0, Miercoles As Double = 0, Jueves As Double = 0, Viernes As Double = 0, Sabado As Double, Domingo As Double

        If Me.TxtPrecio.Text <> "" Then
            Precio = Me.TxtPrecio.Text
        End If





        'me.TxtMontoLunes.Text = 
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub
End Class




