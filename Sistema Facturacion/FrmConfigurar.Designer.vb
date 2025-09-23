<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigurar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigurar))
        Me.ImgLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNombreEmpresa = New System.Windows.Forms.TextBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.TxtRuc = New System.Windows.Forms.TextBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.TxtRutaLogo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtConexion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ChkSincroniza = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtRutaCompartida = New System.Windows.Forms.TextBox()
        Me.CmdRutoLogo = New System.Windows.Forms.Button()
        Me.CmdRutaCompartida = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImgLogo
        '
        Me.ImgLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImgLogo.Location = New System.Drawing.Point(12, 76)
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.Size = New System.Drawing.Size(170, 155)
        Me.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgLogo.TabIndex = 0
        Me.ImgLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Direccion Empresa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Numero Ruc"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Telefono"
        '
        'TxtNombreEmpresa
        '
        Me.TxtNombreEmpresa.Location = New System.Drawing.Point(284, 86)
        Me.TxtNombreEmpresa.Name = "TxtNombreEmpresa"
        Me.TxtNombreEmpresa.Size = New System.Drawing.Size(240, 20)
        Me.TxtNombreEmpresa.TabIndex = 5
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(284, 112)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(240, 66)
        Me.TxtDireccion.TabIndex = 6
        '
        'TxtRuc
        '
        Me.TxtRuc.Location = New System.Drawing.Point(284, 184)
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(240, 20)
        Me.TxtRuc.TabIndex = 7
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(284, 211)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(240, 20)
        Me.TxtTelefono.TabIndex = 8
        '
        'TxtRutaLogo
        '
        Me.TxtRutaLogo.Location = New System.Drawing.Point(127, 247)
        Me.TxtRutaLogo.Name = "TxtRutaLogo"
        Me.TxtRutaLogo.Size = New System.Drawing.Size(351, 20)
        Me.TxtRutaLogo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Ruta Logo"
        '
        'TxtConexion
        '
        Me.TxtConexion.Location = New System.Drawing.Point(127, 305)
        Me.TxtConexion.Multiline = True
        Me.TxtConexion.Name = "TxtConexion"
        Me.TxtConexion.Size = New System.Drawing.Size(397, 61)
        Me.TxtConexion.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Conexion Contable"
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(368, 371)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 61
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(448, 371)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 68)
        Me.Button2.TabIndex = 62
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(84, 328)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 63
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(15, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(70, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 66
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(124, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(311, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "CONFIGURACION DEL SISTEMA  DE FACTURACION"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(2, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(533, 71)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'ChkSincroniza
        '
        Me.ChkSincroniza.AutoSize = True
        Me.ChkSincroniza.Location = New System.Drawing.Point(20, 373)
        Me.ChkSincroniza.Name = "ChkSincroniza"
        Me.ChkSincroniza.Size = New System.Drawing.Size(264, 17)
        Me.ChkSincroniza.TabIndex = 67
        Me.ChkSincroniza.Text = "Sincronizar Tasa de Cambio con Sistema Contable"
        Me.ChkSincroniza.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 276)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Ruta Compartida"
        '
        'TxtRutaCompartida
        '
        Me.TxtRutaCompartida.Location = New System.Drawing.Point(127, 273)
        Me.TxtRutaCompartida.Name = "TxtRutaCompartida"
        Me.TxtRutaCompartida.Size = New System.Drawing.Size(351, 20)
        Me.TxtRutaCompartida.TabIndex = 68
        '
        'CmdRutoLogo
        '
        Me.CmdRutoLogo.Image = CType(resources.GetObject("CmdRutoLogo.Image"), System.Drawing.Image)
        Me.CmdRutoLogo.Location = New System.Drawing.Point(483, 243)
        Me.CmdRutoLogo.Name = "CmdRutoLogo"
        Me.CmdRutoLogo.Size = New System.Drawing.Size(35, 28)
        Me.CmdRutoLogo.TabIndex = 171
        Me.CmdRutoLogo.UseVisualStyleBackColor = True
        '
        'CmdRutaCompartida
        '
        Me.CmdRutaCompartida.Image = CType(resources.GetObject("CmdRutaCompartida.Image"), System.Drawing.Image)
        Me.CmdRutaCompartida.Location = New System.Drawing.Point(482, 271)
        Me.CmdRutaCompartida.Name = "CmdRutaCompartida"
        Me.CmdRutaCompartida.Size = New System.Drawing.Size(35, 28)
        Me.CmdRutaCompartida.TabIndex = 172
        Me.CmdRutaCompartida.UseVisualStyleBackColor = True
        '
        'FrmConfigurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 445)
        Me.Controls.Add(Me.CmdRutaCompartida)
        Me.Controls.Add(Me.CmdRutoLogo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRutaCompartida)
        Me.Controls.Add(Me.ChkSincroniza)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtConexion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtRutaLogo)
        Me.Controls.Add(Me.TxtTelefono)
        Me.Controls.Add(Me.TxtRuc)
        Me.Controls.Add(Me.TxtDireccion)
        Me.Controls.Add(Me.TxtNombreEmpresa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ImgLogo)
        Me.Name = "FrmConfigurar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion General del Sistema"
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuc As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtRutaLogo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtConexion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkSincroniza As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRutaCompartida As System.Windows.Forms.TextBox
    Friend WithEvents CmdRutoLogo As System.Windows.Forms.Button
    Friend WithEvents CmdRutaCompartida As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
End Class
