

Imports System.IO
Imports System.Drawing

Public Class FrmLineaProductos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), RutaCompartida As String

    Private Sub FrmLineaProductos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Linea Produtos")
    End Sub

    Private Sub FrmLineaProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT dbo.Lineas.* FROM  dbo.Lineas", SqlDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("LineaProductos")

        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")) Then
                RutaCompartida = DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")
            End If
        End If

        Me.OpenFileDialog1.Filter = "Image Files (*.jpg)|*.jpg"

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoLinea.TextChanged
        Dim SQL As String = "SELECT dbo.Lineas.* FROM dbo.Lineas WHERE (Cod_Linea = '" & Me.CboCodigoLinea.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        Dim RutaOrigen As String
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")) Then
                Me.TxtNombre.Text = DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")
            End If
            If Not IsDBNull(DataSet.Tables("LineaProductos").Rows(0)("RutaImagen")) Then
                Me.TxtRuta.Text = DataSet.Tables("LineaProductos").Rows(0)("RutaImagen")
            End If
        Else
            Me.TxtNombre.Text = ""
            Me.TxtRuta.Text = ""
        End If

        Me.ImgFoto.Image = Nothing

        If System.IO.Directory.Exists(RutaCompartida) = True Then
            RutaOrigen = RutaCompartida & "\L" & Trim(Me.CboCodigoLinea.Text) & ".jpg"
            If Dir(RutaOrigen) <> "" Then
                Me.ImgFoto.ImageLocation = RutaOrigen
            Else
                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\L" & Me.CboCodigoLinea.Text & ".jpg"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                End If
            End If
        Else
            RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\L" & Me.CboCodigoLinea.Text & ".jpg"
            If System.IO.File.Exists(RutaOrigen) = True Then
                Me.ImgFoto.ImageLocation = RutaOrigen
            End If
        End If

        Me.TxtRuta.Text = RutaOrigen

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        'Try


        If Me.CboCodigoLinea.Text = "" Then
            MsgBox("Se necesita el Codigo de la Linea", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtNombre.Text = "" Then
            MsgBox("Se necesita el Nombre de la linea", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        SQLProveedor = "SELECT dbo.Lineas.* FROM dbo.Lineas WHERE (Cod_Linea = '" & Me.CboCodigoLinea.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Lineas] SET [Descripcion_Linea] = '" & Me.TxtNombre.Text & "', [RutaImagen] = '" & Me.TxtRuta.Text & "' WHERE (Cod_Linea = '" & Me.CboCodigoLinea.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Lineas] ([Cod_Linea] ,[Descripcion_Linea],[RutaImagen]) " & _
                           "VALUES('" & Me.CboCodigoLinea.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtRuta.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Dim Sql As String = "SELECT dbo.Lineas.* FROM  dbo.Lineas"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Tables("LineaProductos").Clear()
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then

            Me.CboCodigoLinea.DataSource = DataSet.Tables("LineaProductos")

        End If

        Me.CboCodigoLinea.Text = ""

        'Catch ex As Exception
        '    MsgBox(Err.Number)
        'End Try

    End Sub



    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT dbo.Lineas.* FROM dbo.Lineas WHERE (Cod_Linea = '" & Me.CboCodigoLinea.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Lineas] WHERE (Cod_Linea = '" & Me.CboCodigoLinea.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Dim Sql As String = "SELECT dbo.Lineas.* FROM  dbo.Lineas"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "LineaProductos")
        If Not DataSet.Tables("LineaProductos").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("LineaProductos")

        End If

        Me.CboCodigoLinea.Text = ""

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoLinea.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoLinea"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoLinea.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregar.Click
        Dim RutaOrigen As String = "", RutaDestino As String
        Dim ancho = 200, alto As Integer = 200



        Me.OpenFileDialog1.ShowDialog()
        RutaOrigen = Me.OpenFileDialog1.FileName.ToString()
        If RutaOrigen = "OpenFileDialog1" Then
            Exit Sub
        End If

        '--------------------------------------VERIFICO EL ANCHO Y ALTO PARA CAMBIARLO -------------------------------
        Dim fs As FileStream = New FileStream(RutaOrigen, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim LaImagen As System.Drawing.Image
        LaImagen = System.Drawing.Image.FromStream(fs)
        'este calculo es para que la foto no pierda proporciones
        'alto = Math.Floor((100 / LaImagen.Width) * LaImagen.Height)
        alto = 52
        Dim NuevoBitmap As Bitmap = New Bitmap(ancho, alto)
        Dim Graficos As Graphics = Graphics.FromImage(NuevoBitmap)
        Graficos.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        Graficos.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Graficos.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        Dim Rectangulo As Rectangle = New Rectangle(0, 0, ancho, alto)
        Graficos.DrawImage(LaImagen, Rectangulo)


        Me.ImgFoto.ImageLocation = RutaOrigen
        'If Dir(RutaCompartida, FileAttribute.Directory) <> "" Then
        If System.IO.Directory.Exists(RutaCompartida) = True Then
            RutaDestino = RutaCompartida & "\L" & Trim(Me.CboCodigoLinea.Text) & ".jpg"
        Else
            RutaDestino = My.Application.Info.DirectoryPath & "\Fotos\L\" & Trim(Me.CboCodigoLinea.Text) & ".jpg"
        End If

        If System.IO.File.Exists(RutaDestino) = True Then
            System.IO.File.Delete(RutaDestino)
            'System.IO.File.Copy(RutaOrigen, RutaDestino)
            Me.TxtRuta.Text = RutaDestino
            NuevoBitmap.Save(RutaDestino, NuevoBitmap.RawFormat)
            fs.Close()
            fs = Nothing
        Else
            'System.IO.File.Copy(RutaOrigen, RutaDestino)
            Me.TxtRuta.Text = RutaDestino
            NuevoBitmap.Save(RutaDestino, NuevoBitmap.RawFormat)
            fs.Close()
            fs = Nothing
        End If
    End Sub

    Private Sub CmdBorrarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarFoto.Click
        Dim RutaOrigen As String, Resultado As Double
        Resultado = MsgBox("¿Esta Seguro de Eliminar la Foto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\L" & Me.CboCodigoLinea.Text & ".bmp"
        If System.IO.File.Exists(RutaOrigen) = True Then
            System.IO.File.Delete(RutaOrigen)
            ImgFoto.ImageLocation = ""
            ImgFoto.Refresh()
        Else
            MsgBox("El archivo no Existe", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If
    End Sub
End Class