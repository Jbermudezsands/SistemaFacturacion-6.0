Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepCatalogoFoto 

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim CodigoProducto As String, RutaOrigen As String
        CodigoProducto = Me.TxtCodigoProducto.Text
        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.TxtCodigoProducto.Text & ".bmp"
        If Dir(RutaOrigen) <> "" Then
            Me.ImgProducto.Image = New System.Drawing.Bitmap(RutaOrigen)
        Else
            Me.ImgProducto.Image = Nothing
        End If
    End Sub
End Class
