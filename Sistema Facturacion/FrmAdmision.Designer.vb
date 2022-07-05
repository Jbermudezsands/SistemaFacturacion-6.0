<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdmision
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
        Me.components = New System.ComponentModel.Container
        Me.ImgFoto = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtComarca = New System.Windows.Forms.TextBox
        Me.TxtMunicipio = New System.Windows.Forms.TextBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnConsultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtLetra = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdGuardar = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.DTPFecha = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgFoto
        '
        Me.ImgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgFoto.Location = New System.Drawing.Point(12, 109)
        Me.ImgFoto.Name = "ImgFoto"
        Me.ImgFoto.Size = New System.Drawing.Size(160, 208)
        Me.ImgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgFoto.TabIndex = 232
        Me.ImgFoto.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtComarca)
        Me.GroupBox1.Controls.Add(Me.TxtMunicipio)
        Me.GroupBox1.Controls.Add(Me.TxtLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.BtnConsultar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtApellidos)
        Me.GroupBox1.Controls.Add(Me.TxtLetra)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.TxtNombres)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(178, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 208)
        Me.GroupBox1.TabIndex = 233
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generales"
        '
        'TxtComarca
        '
        Me.TxtComarca.Enabled = False
        Me.TxtComarca.Location = New System.Drawing.Point(111, 180)
        Me.TxtComarca.Name = "TxtComarca"
        Me.TxtComarca.Size = New System.Drawing.Size(218, 20)
        Me.TxtComarca.TabIndex = 235
        '
        'TxtMunicipio
        '
        Me.TxtMunicipio.Enabled = False
        Me.TxtMunicipio.Location = New System.Drawing.Point(111, 155)
        Me.TxtMunicipio.Name = "TxtMunicipio"
        Me.TxtMunicipio.Size = New System.Drawing.Size(218, 20)
        Me.TxtMunicipio.TabIndex = 234
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Enabled = False
        Me.TxtLocalidad.Location = New System.Drawing.Point(111, 130)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(218, 20)
        Me.TxtLocalidad.TabIndex = 233
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(54, 180)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 232
        Me.Label21.Text = "Comarca:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(54, 158)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 231
        Me.Label15.Text = "Municipio:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(51, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 230
        Me.Label14.Text = "Localidadl:"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(111, 103)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 215
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 214
        Me.Label11.Text = "Unidad de Salud:"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Location = New System.Drawing.Point(229, 19)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(29, 30)
        Me.BtnConsultar.TabIndex = 173
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Numero Expediente:"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Enabled = False
        Me.TxtApellidos.Location = New System.Drawing.Point(111, 78)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(218, 20)
        Me.TxtApellidos.TabIndex = 171
        '
        'TxtLetra
        '
        Me.TxtLetra.Enabled = False
        Me.TxtLetra.Location = New System.Drawing.Point(111, 24)
        Me.TxtLetra.Name = "TxtLetra"
        Me.TxtLetra.Size = New System.Drawing.Size(40, 20)
        Me.TxtLetra.TabIndex = 167
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Apellidos:"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Location = New System.Drawing.Point(157, 24)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(69, 20)
        Me.TxtCodigo.TabIndex = 168
        '
        'TxtNombres
        '
        Me.TxtNombres.Enabled = False
        Me.TxtNombres.Location = New System.Drawing.Point(111, 53)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(218, 20)
        Me.TxtNombres.TabIndex = 169
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Nombres:"
        '
        'Button6
        '
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(525, 153)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 34)
        Me.Button6.TabIndex = 236
        Me.Button6.Text = "Imprimir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(526, 281)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 34)
        Me.CmdCerrar.TabIndex = 235
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = Global.Sistema_Facturacion.My.Resources.Resources.Unpinned
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(526, 114)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 34)
        Me.CmdGuardar.TabIndex = 234
        Me.CmdGuardar.Text = "Generar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.DTPFecha)
        Me.GroupBox9.Controls.Add(Me.LblHora)
        Me.GroupBox9.Controls.Add(Me.lbldatosre)
        Me.GroupBox9.Location = New System.Drawing.Point(59, 12)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(448, 91)
        Me.GroupBox9.TabIndex = 237
        Me.GroupBox9.TabStop = False
        '
        'DTPFecha
        '
        Me.DTPFecha.AutoSize = True
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.ForeColor = System.Drawing.Color.Black
        Me.DTPFecha.Location = New System.Drawing.Point(33, 38)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(169, 33)
        Me.DTPFecha.TabIndex = 182
        Me.DTPFecha.Text = "20/10/2017"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.Black
        Me.LblHora.Location = New System.Drawing.Point(208, 38)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(205, 33)
        Me.LblHora.TabIndex = 181
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.Black
        Me.lbldatosre.Location = New System.Drawing.Point(124, -1)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(175, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS DE ADMISION"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'FrmAdmision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 344)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ImgFoto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAdmision"
        Me.Text = "FrmAdmision"
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgFoto As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtLetra As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtComarca As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFecha As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
