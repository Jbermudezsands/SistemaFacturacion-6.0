<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroLicencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroLicencia))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtRuc = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtNombreEmpresa = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmdRutoLogo = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.CmdProcesar = New System.Windows.Forms.Button
        Me.LblSerie = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(173, 136)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(232, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(471, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "REGISTRO DE LICENCIAS ZEUS FACTURACION"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtTelefono)
        Me.GroupBox1.Controls.Add(Me.TxtRuc)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.TxtNombreEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 194)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales de la Compañia"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Enabled = False
        Me.TxtTelefono.Location = New System.Drawing.Point(133, 150)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(240, 20)
        Me.TxtTelefono.TabIndex = 16
        '
        'TxtRuc
        '
        Me.TxtRuc.Enabled = False
        Me.TxtRuc.Location = New System.Drawing.Point(133, 123)
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(240, 20)
        Me.TxtRuc.TabIndex = 15
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Enabled = False
        Me.TxtDireccion.Location = New System.Drawing.Point(133, 51)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(240, 66)
        Me.TxtDireccion.TabIndex = 14
        '
        'TxtNombreEmpresa
        '
        Me.TxtNombreEmpresa.Enabled = False
        Me.TxtNombreEmpresa.Location = New System.Drawing.Point(133, 25)
        Me.TxtNombreEmpresa.Name = "TxtNombreEmpresa"
        Me.TxtNombreEmpresa.Size = New System.Drawing.Size(240, 20)
        Me.TxtNombreEmpresa.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Telefono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Numero Ruc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Direccion Empresa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Nombre Empresa"
        '
        'CmdRutoLogo
        '
        Me.CmdRutoLogo.Image = CType(resources.GetObject("CmdRutoLogo.Image"), System.Drawing.Image)
        Me.CmdRutoLogo.Location = New System.Drawing.Point(357, 48)
        Me.CmdRutoLogo.Name = "CmdRutoLogo"
        Me.CmdRutoLogo.Size = New System.Drawing.Size(29, 30)
        Me.CmdRutoLogo.TabIndex = 174
        Me.CmdRutoLogo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "Archivo Licencia"
        '
        'TxtRuta
        '
        Me.TxtRuta.Location = New System.Drawing.Point(98, 54)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.Size = New System.Drawing.Size(253, 20)
        Me.TxtRuta.TabIndex = 172
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.CmdProcesar)
        Me.GroupBox2.Controls.Add(Me.LblSerie)
        Me.GroupBox2.Controls.Add(Me.CmdRutoLogo)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TxtRuta)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(430, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 194)
        Me.GroupBox2.TabIndex = 175
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generar Datos de Licencia"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(287, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 44)
        Me.Button1.TabIndex = 187
        Me.Button1.Text = "Activar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdProcesar.Image = CType(resources.GetObject("CmdProcesar.Image"), System.Drawing.Image)
        Me.CmdProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdProcesar.Location = New System.Drawing.Point(287, 84)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(99, 44)
        Me.CmdProcesar.TabIndex = 186
        Me.CmdProcesar.Text = "Generar"
        Me.CmdProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'LblSerie
        '
        Me.LblSerie.AutoSize = True
        Me.LblSerie.Location = New System.Drawing.Point(98, 25)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(79, 13)
        Me.LblSerie.TabIndex = 175
        Me.LblSerie.Text = "303388388333"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Numero Serie"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'FrmRegistroLicencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 379)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistroLicencia"
        Me.Text = "Registro de Licencias"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuc As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmdRutoLogo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
