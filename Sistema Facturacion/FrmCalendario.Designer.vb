<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalendario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalendario))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdPrecios = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtConexion = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Chk2Veces = New System.Windows.Forms.CheckBox
        Me.DTPHora2 = New System.Windows.Forms.DateTimePicker
        Me.LblHora2 = New System.Windows.Forms.Label
        Me.ChkDomingo = New System.Windows.Forms.CheckBox
        Me.ChkSabado = New System.Windows.Forms.CheckBox
        Me.ChkViernes = New System.Windows.Forms.CheckBox
        Me.ChkJueves = New System.Windows.Forms.CheckBox
        Me.ChkMiercoles = New System.Windows.Forms.CheckBox
        Me.ChkMartes = New System.Windows.Forms.CheckBox
        Me.ChkLunes = New System.Windows.Forms.CheckBox
        Me.DTPHora1 = New System.Windows.Forms.DateTimePicker
        Me.LblHora1 = New System.Windows.Forms.Label
        Me.CmbFrecuencia = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.BtnRuta = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdPrecios)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TxtConexion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 82)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base Datos  Respaldar"
        '
        'CmdPrecios
        '
        Me.CmdPrecios.Image = CType(resources.GetObject("CmdPrecios.Image"), System.Drawing.Image)
        Me.CmdPrecios.Location = New System.Drawing.Point(6, 19)
        Me.CmdPrecios.Name = "CmdPrecios"
        Me.CmdPrecios.Size = New System.Drawing.Size(29, 30)
        Me.CmdPrecios.TabIndex = 170
        Me.CmdPrecios.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(-120, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 65
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtConexion
        '
        Me.TxtConexion.Location = New System.Drawing.Point(41, 19)
        Me.TxtConexion.Multiline = True
        Me.TxtConexion.Name = "TxtConexion"
        Me.TxtConexion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConexion.Size = New System.Drawing.Size(413, 47)
        Me.TxtConexion.TabIndex = 64
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(359, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 48)
        Me.Button2.TabIndex = 228
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(138, 302)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 48)
        Me.Button3.TabIndex = 229
        Me.Button3.Text = "GUARDAR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Chk2Veces
        '
        Me.Chk2Veces.AutoSize = True
        Me.Chk2Veces.Checked = True
        Me.Chk2Veces.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk2Veces.Location = New System.Drawing.Point(52, 139)
        Me.Chk2Veces.Name = "Chk2Veces"
        Me.Chk2Veces.Size = New System.Drawing.Size(146, 17)
        Me.Chk2Veces.TabIndex = 247
        Me.Chk2Veces.Text = "Programar 2 Veces al Dia"
        Me.Chk2Veces.UseVisualStyleBackColor = True
        '
        'DTPHora2
        '
        Me.DTPHora2.CustomFormat = "HH:mm:ss"
        Me.DTPHora2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPHora2.Location = New System.Drawing.Point(92, 188)
        Me.DTPHora2.Name = "DTPHora2"
        Me.DTPHora2.Size = New System.Drawing.Size(122, 20)
        Me.DTPHora2.TabIndex = 246
        '
        'LblHora2
        '
        Me.LblHora2.AutoSize = True
        Me.LblHora2.Location = New System.Drawing.Point(49, 190)
        Me.LblHora2.Name = "LblHora2"
        Me.LblHora2.Size = New System.Drawing.Size(42, 13)
        Me.LblHora2.TabIndex = 245
        Me.LblHora2.Text = "Hora 2:"
        '
        'ChkDomingo
        '
        Me.ChkDomingo.AutoSize = True
        Me.ChkDomingo.Location = New System.Drawing.Point(240, 155)
        Me.ChkDomingo.Name = "ChkDomingo"
        Me.ChkDomingo.Size = New System.Drawing.Size(68, 17)
        Me.ChkDomingo.TabIndex = 241
        Me.ChkDomingo.Text = "Domingo"
        Me.ChkDomingo.UseVisualStyleBackColor = True
        Me.ChkDomingo.Visible = False
        '
        'ChkSabado
        '
        Me.ChkSabado.AutoSize = True
        Me.ChkSabado.Location = New System.Drawing.Point(365, 132)
        Me.ChkSabado.Name = "ChkSabado"
        Me.ChkSabado.Size = New System.Drawing.Size(63, 17)
        Me.ChkSabado.TabIndex = 243
        Me.ChkSabado.Text = "Sabado"
        Me.ChkSabado.UseVisualStyleBackColor = True
        Me.ChkSabado.Visible = False
        '
        'ChkViernes
        '
        Me.ChkViernes.AutoSize = True
        Me.ChkViernes.Location = New System.Drawing.Point(301, 132)
        Me.ChkViernes.Name = "ChkViernes"
        Me.ChkViernes.Size = New System.Drawing.Size(61, 17)
        Me.ChkViernes.TabIndex = 242
        Me.ChkViernes.Text = "Viernes"
        Me.ChkViernes.UseVisualStyleBackColor = True
        Me.ChkViernes.Visible = False
        '
        'ChkJueves
        '
        Me.ChkJueves.AutoSize = True
        Me.ChkJueves.Location = New System.Drawing.Point(240, 132)
        Me.ChkJueves.Name = "ChkJueves"
        Me.ChkJueves.Size = New System.Drawing.Size(60, 17)
        Me.ChkJueves.TabIndex = 244
        Me.ChkJueves.Text = "Jueves"
        Me.ChkJueves.UseVisualStyleBackColor = True
        Me.ChkJueves.Visible = False
        '
        'ChkMiercoles
        '
        Me.ChkMiercoles.AutoSize = True
        Me.ChkMiercoles.Location = New System.Drawing.Point(365, 108)
        Me.ChkMiercoles.Name = "ChkMiercoles"
        Me.ChkMiercoles.Size = New System.Drawing.Size(71, 17)
        Me.ChkMiercoles.TabIndex = 240
        Me.ChkMiercoles.Text = "Miercoles"
        Me.ChkMiercoles.UseVisualStyleBackColor = True
        Me.ChkMiercoles.Visible = False
        '
        'ChkMartes
        '
        Me.ChkMartes.AutoSize = True
        Me.ChkMartes.Location = New System.Drawing.Point(301, 109)
        Me.ChkMartes.Name = "ChkMartes"
        Me.ChkMartes.Size = New System.Drawing.Size(58, 17)
        Me.ChkMartes.TabIndex = 239
        Me.ChkMartes.Text = "Martes"
        Me.ChkMartes.UseVisualStyleBackColor = True
        Me.ChkMartes.Visible = False
        '
        'ChkLunes
        '
        Me.ChkLunes.AutoSize = True
        Me.ChkLunes.Location = New System.Drawing.Point(240, 109)
        Me.ChkLunes.Name = "ChkLunes"
        Me.ChkLunes.Size = New System.Drawing.Size(55, 17)
        Me.ChkLunes.TabIndex = 238
        Me.ChkLunes.Text = "Lunes"
        Me.ChkLunes.UseVisualStyleBackColor = True
        Me.ChkLunes.Visible = False
        '
        'DTPHora1
        '
        Me.DTPHora1.CustomFormat = "HH:mm:ss"
        Me.DTPHora1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPHora1.Location = New System.Drawing.Point(92, 162)
        Me.DTPHora1.Name = "DTPHora1"
        Me.DTPHora1.Size = New System.Drawing.Size(122, 20)
        Me.DTPHora1.TabIndex = 237
        '
        'LblHora1
        '
        Me.LblHora1.AutoSize = True
        Me.LblHora1.Location = New System.Drawing.Point(49, 164)
        Me.LblHora1.Name = "LblHora1"
        Me.LblHora1.Size = New System.Drawing.Size(42, 13)
        Me.LblHora1.TabIndex = 236
        Me.LblHora1.Text = "Hora 1:"
        '
        'CmbFrecuencia
        '
        Me.CmbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFrecuencia.FormattingEnabled = True
        Me.CmbFrecuencia.Items.AddRange(New Object() {"Diaria", "Semanal"})
        Me.CmbFrecuencia.Location = New System.Drawing.Point(93, 109)
        Me.CmbFrecuencia.Name = "CmbFrecuencia"
        Me.CmbFrecuencia.Size = New System.Drawing.Size(121, 21)
        Me.CmbFrecuencia.TabIndex = 235
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Frecuencia:"
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(12, 302)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 48)
        Me.Button4.TabIndex = 248
        Me.Button4.Text = "NUEVO"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Ruta Respaldo:"
        '
        'TxtRuta
        '
        Me.TxtRuta.AcceptsReturn = True
        Me.TxtRuta.Location = New System.Drawing.Point(110, 226)
        Me.TxtRuta.Multiline = True
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtRuta.Size = New System.Drawing.Size(356, 47)
        Me.TxtRuta.TabIndex = 250
        '
        'BtnRuta
        '
        Me.BtnRuta.Image = CType(resources.GetObject("BtnRuta.Image"), System.Drawing.Image)
        Me.BtnRuta.Location = New System.Drawing.Point(75, 243)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(29, 30)
        Me.BtnRuta.TabIndex = 251
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'FrmCalendario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 362)
        Me.Controls.Add(Me.BtnRuta)
        Me.Controls.Add(Me.TxtRuta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Chk2Veces)
        Me.Controls.Add(Me.DTPHora2)
        Me.Controls.Add(Me.LblHora2)
        Me.Controls.Add(Me.ChkDomingo)
        Me.Controls.Add(Me.ChkSabado)
        Me.Controls.Add(Me.ChkViernes)
        Me.Controls.Add(Me.ChkJueves)
        Me.Controls.Add(Me.ChkMiercoles)
        Me.Controls.Add(Me.ChkMartes)
        Me.Controls.Add(Me.ChkLunes)
        Me.Controls.Add(Me.DTPHora1)
        Me.Controls.Add(Me.LblHora1)
        Me.Controls.Add(Me.CmbFrecuencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmCalendario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calendario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdPrecios As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtConexion As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Chk2Veces As System.Windows.Forms.CheckBox
    Friend WithEvents DTPHora2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblHora2 As System.Windows.Forms.Label
    Friend WithEvents ChkDomingo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSabado As System.Windows.Forms.CheckBox
    Friend WithEvents ChkViernes As System.Windows.Forms.CheckBox
    Friend WithEvents ChkJueves As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMiercoles As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMartes As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLunes As System.Windows.Forms.CheckBox
    Friend WithEvents DTPHora1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblHora1 As System.Windows.Forms.Label
    Friend WithEvents CmbFrecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnRuta As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog

End Class
