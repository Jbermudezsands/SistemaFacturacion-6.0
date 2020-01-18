Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepCotizacionFoto 

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim CodigoProducto As String, RutaOrigen As String
        CodigoProducto = Me.TxtCodProducto.Text
        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & CodigoProducto & ".bmp"
        If Dir(RutaOrigen) <> "" Then
            Me.ImgProducto.Image = New System.Drawing.Bitmap(RutaOrigen)
        Else
            Me.ImgProducto.Image = Nothing
        End If
    End Sub
End Class
