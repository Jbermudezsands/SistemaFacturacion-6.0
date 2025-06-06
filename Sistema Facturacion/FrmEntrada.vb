
Public Class FrmEntrada

    Public MiConexion As New SqlClient.SqlConnection

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim fileReader As String, Ruta As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Ruta = My.Application.Info.DirectoryPath & "\SysInfo.txt"
        'fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        ''fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\jbermudez\Sistemas\Excelencia\ExcelenciaAcademica\Excelencia\SysInfo.txt")
        ''Conexion = "Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=Proyecto_Excelencia;Data Source=JUAN1\SQL2005"
        ''Conexion = fileReader

        'Centrar el Panel
        'Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize       'Captura el Tamaño del Monitor
        'Dim alto As Int32 = (desktopSize.Height - 280) \ 2
        'Dim ancho As Int32 = (desktopSize.Width - 500) \ 2
        'Panel1.Location = New Point(ancho, alto)
        'Me.cmdEntrar.Location = New Point(ancho, alto)
        'Fin centrar el Panel

        'Mostrar Fecha y Hora
        lblFecha.Text = DateTime.Now.ToLongDateString()
        lblHora.Text = DateTime.Now.ToLongTimeString()

        MiConexion = New SqlClient.SqlConnection(Conexion)

        Version = My.Application.Info.Version.ToString
        Me.LblVersion.Text = "V." & Mid(Version, 1, Len(Version) - 2)


        '////////////////////Declaro las Consultas a Utilizar/////////////////////////////////////////////////
        Dim strSQL As String = "SELECT Usuario FROM Usuarios "
        Dim SqlDatosEmpresa As String

        '/////////////////////////Declaro las variables de Conexion//////////////////////////////////////// 

        Dim DRUsuarios As SqlClient.SqlDataReader
        Dim DTUsuarios As New DataTable
        Dim CmUsuarios As SqlClient.SqlCommand

        '///////////////////Establecemos Conexion con la Base de Datos///////////////////////////////////////
        CmUsuarios = New SqlClient.SqlCommand(strSQL, MiConexion)

        '////////////////Abrimos Conexion con la Base de Datos////////////////////////////
        MiConexion.Open()

        '///////Ejecutamos la Sentencias SQL////////////////////////////////////////////
        DRUsuarios = CmUsuarios.ExecuteReader()

        '///////Cargamos los Resultados en el Objeto Table////////////////////////////////////////
        DTUsuarios.Load(DRUsuarios, LoadOption.OverwriteChanges)
        Me.cboUsuario.DataSource = DTUsuarios
        CmUsuarios = Nothing

        SqlDatosEmpresa = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatosEmpresa, MiConexion)
        DataAdapter.Fill(Dataset, "DatosEmpresa")
        If Not Dataset.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(Dataset.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")) Then
                ConexionContabilidad = Dataset.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")
            End If
            If Not IsDBNull(Dataset.Tables("DatosEmpresa").Rows(0)("NombreCliente")) Then
                NombreCliente = Dataset.Tables("DatosEmpresa").Rows(0)("NombreCliente")
            End If

        End If



        Me.CboUsuario.Splits.Item(0).DisplayColumns(0).Width = 200

        ''If DTUsuarios.Rows.Count = 0 Then
        'Me.Hide()
        'If NombreCliente = "Alumnos" Then
        '    My.Forms.MDIParent1.NavBarEnsamble.Visible = False
        '    My.Forms.MDIParent1.NavBarPagos.Visible = False
        '    My.Forms.MDIParent1.Vendedores.Visible = False
        '    My.Forms.MDIParent1.NavBarLiquidacion.Visible = False
        '    My.Forms.MDIParent1.NavBarTransferencias.Visible = False

        '    My.Forms.MDIParent1.ShowDialog()
        'Else
        '    My.Forms.MDIParent1.ShowDialog()
        'End If
        'Me.Close()
        ''End If

        MiConexion.Close()


    End Sub

    Private Sub cmdEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntrar.Click
        Dim DataSetUsuario As New DataSet
        Dim DataAdapterUsuario As New SqlClient.SqlDataAdapter
        Dim SqlUsuario As String


        Dim Contraseña As String, Usuario As String, BDContraseña As String


        If Me.CboUsuario.Text = "" Then
            MsgBox("Seleccione un Usuario", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Not Me.txtPassword.Text = "" Then
            Contraseña = Me.txtPassword.Text
            Usuario = Me.CboUsuario.Text
            NombreUsuario = Me.CboUsuario.Text
            'My.Forms.MDIParent1.TxtUsuario.Text = NombreUsuario

            MiConexion.Open()
            SqlUsuario = "SELECT * FROM Usuarios WHERE (Usuario = '" & Usuario & "')"

            DataAdapterUsuario = New SqlClient.SqlDataAdapter(SqlUsuario, MiConexion)
            DataAdapterUsuario.Fill(DataSetUsuario, "Usuarios")
            If Not DataSetUsuario.Tables("Usuarios").Rows.Count = 0 Then
                BDContraseña = DataSetUsuario.Tables("Usuarios").Rows(0)("Contraseña")
                Acceso = DataSetUsuario.Tables("Usuarios").Rows(0)("Nivel")
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("Bodega")) Then
                    UsuarioBodega = DataSetUsuario.Tables("Usuarios").Rows(0)("Bodega")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("TipoFactura")) Then
                    UsuarioTipoFactura = DataSetUsuario.Tables("Usuarios").Rows(0)("TipoFactura")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("SerieFactura")) Then
                    UsuarioTipoSerie = DataSetUsuario.Tables("Usuarios").Rows(0)("SerieFactura")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodVendedor")) Then
                    UsuarioVendedor = DataSetUsuario.Tables("Usuarios").Rows(0)("CodVendedor")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodCliente")) Then
                    UsuarioCliente = DataSetUsuario.Tables("Usuarios").Rows(0)("CodCliente")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("BodegaCompra")) Then
                    UsuarioBodegaCompra = DataSetUsuario.Tables("Usuarios").Rows(0)("BodegaCompra")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("TipoCompra")) Then
                    UsuarioTipoCompra = DataSetUsuario.Tables("Usuarios").Rows(0)("TipoCompra")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("RecibeNotificacion")) Then
                    RecibeNotificacion = DataSetUsuario.Tables("Usuarios").Rows(0)("RecibeNotificacion")
                Else
                    RecibeNotificacion = False
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodProveedor")) Then
                    UsuarioProveedor = DataSetUsuario.Tables("Usuarios").Rows(0)("CodProveedor")
                End If

                If BDContraseña = Contraseña Then
                    MiConexion.Close()
                    Me.Hide()
                    If NombreCliente = "Alumnos" Then
                        'My.Forms.MDIParent1.NavBarEnsamble.Visible = False
                        'My.Forms.MDIParent1.NavBarPagos.Visible = False
                        'My.Forms.MDIParent1.Vendedores.Visible = False
                        'My.Forms.MDIParent1.NavBarLiquidacion.Visible = False
                        'My.Forms.MDIParent1.NavBarTransferencias.Visible = False

                        'My.Forms.MDIParent1.ShowDialog()
                        My.Forms.MDIMain.ShowDialog()
                    Else
                        Bitacora(Now, NombreUsuario, "Entrada", "Entrando al Sistema de Facturacion")
                        'My.Forms.MDIParent1.ShowDialog()
                        My.Forms.MDIMain.ShowDialog()
                    End If


                    Me.Timer1.Enabled = False
                    Me.Close()


                    'Me.Hide()
                    'My.Forms.MDIParent1.ShowDialog()
                    'Me.Close()
                Else
                    MsgBox("Contraseña Incorrecta", MsgBoxStyle.Exclamation, "Sistema Facturacion")
                    MiConexion.Close()
                    Exit Sub
                End If


            End If




            MiConexion.Close()

        Else
            MsgBox("Digite la Contraseña", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmdEntrar.PerformClick()
        End If
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmin.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrar.Click
        If MessageBox.Show("Estas seguro que desea Salir", "◄ AVISO | ZEUS FACTURACION ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Actualizar cada segundo la Hora
        lblHora.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.Size = New Size(100, 92)
        'PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Size = New Size(90, 85)
        'PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim DataSetUsuario As New DataSet
        Dim DataAdapterUsuario As New SqlClient.SqlDataAdapter
        Dim SqlUsuario As String


        Dim Contraseña As String, Usuario As String, BDContraseña As String


        If Me.CboUsuario.Text = "" Then
            MsgBox("Seleccione un Usuario", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Not Me.txtPassword.Text = "" Then
            Contraseña = Me.txtPassword.Text
            Usuario = Me.CboUsuario.Text
            NombreUsuario = Me.CboUsuario.Text
            'My.Forms.MDIParent1.TxtUsuario.Text = NombreUsuario

            MiConexion.Open()
            SqlUsuario = "SELECT * FROM Usuarios WHERE (Usuario = '" & Usuario & "')"

            DataAdapterUsuario = New SqlClient.SqlDataAdapter(SqlUsuario, MiConexion)
            DataAdapterUsuario.Fill(DataSetUsuario, "Usuarios")
            If Not DataSetUsuario.Tables("Usuarios").Rows.Count = 0 Then
                BDContraseña = DataSetUsuario.Tables("Usuarios").Rows(0)("Contraseña")
                Acceso = DataSetUsuario.Tables("Usuarios").Rows(0)("Nivel")
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("Bodega")) Then
                    UsuarioBodega = DataSetUsuario.Tables("Usuarios").Rows(0)("Bodega")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("TipoFactura")) Then
                    UsuarioTipoFactura = DataSetUsuario.Tables("Usuarios").Rows(0)("TipoFactura")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("SerieFactura")) Then
                    UsuarioTipoSerie = DataSetUsuario.Tables("Usuarios").Rows(0)("SerieFactura")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodVendedor")) Then
                    UsuarioVendedor = DataSetUsuario.Tables("Usuarios").Rows(0)("CodVendedor")
                End If
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodCliente")) Then
                    UsuarioCliente = DataSetUsuario.Tables("Usuarios").Rows(0)("CodCliente")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("BodegaCompra")) Then
                    UsuarioBodegaCompra = DataSetUsuario.Tables("Usuarios").Rows(0)("BodegaCompra")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("TipoCompra")) Then
                    UsuarioTipoCompra = DataSetUsuario.Tables("Usuarios").Rows(0)("TipoCompra")
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("RecibeNotificacion")) Then
                    RecibeNotificacion = DataSetUsuario.Tables("Usuarios").Rows(0)("RecibeNotificacion")
                Else
                    RecibeNotificacion = False
                End If

                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("CodProveedor")) Then
                    UsuarioProveedor = DataSetUsuario.Tables("Usuarios").Rows(0)("CodProveedor")
                End If

                If BDContraseña = Contraseña Then
                    MiConexion.Close()
                    Me.Hide()
                    If NombreCliente = "Alumnos" Then
                        'My.Forms.MDIParent1.NavBarEnsamble.Visible = False
                        'My.Forms.MDIParent1.NavBarPagos.Visible = False
                        'My.Forms.MDIParent1.Vendedores.Visible = False
                        'My.Forms.MDIParent1.NavBarLiquidacion.Visible = False
                        'My.Forms.MDIParent1.NavBarTransferencias.Visible = False

                        'My.Forms.MDIParent1.ShowDialog()
                        My.Forms.MDIMain.ShowDialog()
                    Else
                        Bitacora(Now, NombreUsuario, "Entrada", "Entrando al Sistema de Facturacion")
                        My.Forms.MDIMain.ShowDialog()
                        'My.Forms.MDIParent1.ShowDialog()
                    End If


                    Me.Timer1.Enabled = False
                    Me.Close()


                    'Me.Hide()
                    'My.Forms.MDIParent1.ShowDialog()
                    'Me.Close()
                Else
                    MsgBox("Contraseña Incorrecta", MsgBoxStyle.Exclamation, "Sistema Facturacion")
                    MiConexion.Close()
                    Exit Sub
                End If


            End If




            MiConexion.Close()

        Else
            MsgBox("Digite la Contraseña", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CboUsuario_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboUsuario.MouseEnter

    End Sub



    Private Sub CboUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUsuario.TextChanged

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub
End Class