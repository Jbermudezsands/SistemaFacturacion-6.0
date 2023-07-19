Imports System.IO
Imports System.Drawing


Public Class FrmConfigurar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FrmConfigurar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Configurar")
    End Sub

    Private Sub FrmConfigurar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim MyRuta As String
        Dim myImagenConsulta As Image, Logo As String = ""
        Try


            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                Me.TxtNombreEmpresa.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                Me.TxtDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    Me.TxtRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                End If

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("SincronizarTasa")) Then
                    If DataSet.Tables("DatosEmpresa").Rows(0)("SincronizarTasa") = 0 Then
                        Me.ChkSincroniza.Checked = False
                    Else
                        Me.ChkSincroniza.Checked = True
                    End If
                End If

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Logo")) Then
                    Logo = DataSet.Tables("DatosEmpresa").Rows(0)("Logo")
                    myImagenConsulta = BytesToImagen(StringtoByte(Logo))
                    Me.ImgLogo.Image = myImagenConsulta
                End If

                'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                '    Me.TxtRutaLogo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")

                '    ImgLogo.ImageLocation = Me.TxtRutaLogo.Text
                '    MyRuta = Dir(Me.TxtRutaLogo.Text)
                '    If MyRuta <> "" Then
                '        ImgLogo.Load()
                '    Else
                '        MsgBox("No Existe imagen para esta ruta", MsgBoxStyle.Critical, "Zeus Facturacion")
                '        Exit Sub
                '    End If
                'End If





                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")) Then
                    Me.TxtRutaCompartida.Text = DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")
                End If

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")) Then
                    Me.TxtConexion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")
                End If



            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Sincroniza As Boolean
        Dim CharLogo As String, LogoImg As Image
        Dim Foto As String = ""

        If Me.TxtNombreEmpresa.Text = "" Then
            MsgBox("Se Necesita el Nombre de la Empresa", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtDireccion.Text = "" Then
            MsgBox("Se necesita la Direccion", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtRutaLogo.Text = "" Then
            MsgBox("Se necesita una Ubicacion", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        'If Me.TxtRutaCompartida.Text = "" Then
        '    Me.TxtRutaCompartida.Text = My.Application.Info.DirectoryPath & "\Fotos\"
        'ElseIf Dir(Me.TxtRutaCompartida.Text, FileAttribute.Directory) = "" Then
        '    Me.TxtRutaCompartida.Text = My.Application.Info.DirectoryPath & "\Fotos\"
        'End If

        If Me.ChkSincroniza.Checked = True Then
            Sincroniza = True
        Else
            Sincroniza = False
        End If

        Foto = bytesToString(ImagenToBytes(Me.ImgLogo.Image))


        'LogoImg = Me.ImgLogo.Image
        ''CharLogo = bytesToString(ImagenToBytes(LogoImg))
        'CharLogo = bytesToString(Imagen_A_Bytes(Me.TxtRutaLogo.Text))

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            MiConexion.Open()
            StrSqlUpdate = "UPDATE [DatosEmpresa] SET [Nombre_Empresa] = '" & Me.TxtNombreEmpresa.Text & "',[Direccion_Empresa] = '" & Me.TxtDireccion.Text & "',[Numero_Ruc] = '" & Me.TxtRuc.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Ruta_Logo] = '" & Me.TxtRutaLogo.Text & "',[RutaCompartida] = '" & Me.TxtRutaCompartida.Text & "', [Conexion_Contabilidad] = '" & Me.TxtConexion.Text & "',[SincronizarTasa] = '" & Sincroniza & "' ,[Logo] = '" & Foto & "' "
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
            MsgBox("Registros Actualizados", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            If Not Me.TxtConexion.Text = "" Then
                ConexionContabilidad = Me.TxtConexion.Text
            Else
                ConexionContabilidad = ""
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mydlg As New MSDASC.DataLinks
        Dim ADOcon As New ADODB.Connection


        Try


            ADOcon = mydlg.PromptNew
            If Not IsDBNull(ADOcon.ConnectionString) Then
                Me.TxtConexion.Text = ADOcon.ConnectionString
            Else
                Me.TxtConexion.Text = ""
            End If

            'Dim RutaReportes As String
            'RutaReportes = My.Application.Info.DirectoryPath & "\CreateConnectString.exe"
            'Shell(RutaReportes)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdRutoLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRutoLogo.Click
        Dim RutaBD As String
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaLogo.Text = RutaBD
        If Not Me.TxtRutaLogo.Text = "OpenFileDialog1" Then
            'ImgLogo.ImageLocation = Me.TxtRutaLogo.Text
            ''ImgLogo.ImageLocation = cargarImagen(Me.TxtRutaLogo.Text)
            'ImgLogo.Load()

            Me.ImgLogo.Image = CambiarTamañoImage(Image.FromFile(Me.TxtRutaLogo.Text))
        Else

            Me.TxtRutaLogo.Text = ""
        End If
    End Sub



    Private Sub CmdRutaCompartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRutaCompartida.Click
        Dim RutaBD As String
        Me.FolderBrowserDialog.ShowDialog()
        RutaBD = FolderBrowserDialog.SelectedPath
        Me.TxtRutaCompartida.Text = RutaBD

    End Sub
End Class