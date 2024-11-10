<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeriodos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPeriodos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboTipoNomina = New C1.Win.C1List.C1Combo
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbTipoPlanilla = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtAño = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstPlanilla = New System.Windows.Forms.ListBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.CmdGenerar = New System.Windows.Forms.Button
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboTipoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboTipoNomina)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CmbTipoPlanilla)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtAño)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTPFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(508, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CboTipoNomina
        '
        Me.CboTipoNomina.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoNomina.Caption = ""
        Me.CboTipoNomina.CaptionHeight = 17
        Me.CboTipoNomina.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoNomina.ColumnCaptionHeight = 17
        Me.CboTipoNomina.ColumnFooterHeight = 17
        Me.CboTipoNomina.ContentHeight = 15
        Me.CboTipoNomina.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoNomina.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoNomina.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoNomina.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoNomina.EditorHeight = 15
        Me.CboTipoNomina.Images.Add(CType(resources.GetObject("CboTipoNomina.Images"), System.Drawing.Image))
        Me.CboTipoNomina.ItemHeight = 15
        Me.CboTipoNomina.Location = New System.Drawing.Point(75, 60)
        Me.CboTipoNomina.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoNomina.MaxDropDownItems = CType(5, Short)
        Me.CboTipoNomina.MaxLength = 32767
        Me.CboTipoNomina.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoNomina.Name = "CboTipoNomina"
        Me.CboTipoNomina.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoNomina.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoNomina.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoNomina.Size = New System.Drawing.Size(209, 21)
        Me.CboTipoNomina.TabIndex = 121
        Me.CboTipoNomina.PropBag = resources.GetString("CboTipoNomina.PropBag")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo Nomina"
        '
        'CmbTipoPlanilla
        '
        Me.CmbTipoPlanilla.FormattingEnabled = True
        Me.CmbTipoPlanilla.Items.AddRange(New Object() {"Semanal Domingo", "Quincenal", "Mensual"})
        Me.CmbTipoPlanilla.Location = New System.Drawing.Point(381, 60)
        Me.CmbTipoPlanilla.Name = "CmbTipoPlanilla"
        Me.CmbTipoPlanilla.Size = New System.Drawing.Size(121, 21)
        Me.CmbTipoPlanilla.TabIndex = 7
        Me.CmbTipoPlanilla.Text = "Semanal Domingo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Periodo Planilla"
        '
        'TxtAño
        '
        Me.TxtAño.Location = New System.Drawing.Point(381, 29)
        Me.TxtAño.Name = "TxtAño"
        Me.TxtAño.Size = New System.Drawing.Size(100, 20)
        Me.TxtAño.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(316, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Año Actual"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(137, 30)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(97, 20)
        Me.DTPFechaFin.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Inicio"
        '
        'DTPFechaInicio
        '
        Me.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicio.Location = New System.Drawing.Point(20, 30)
        Me.DTPFechaInicio.Name = "DTPFechaInicio"
        Me.DTPFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.DTPFechaInicio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio"
        '
        'lstPlanilla
        '
        Me.lstPlanilla.FormattingEnabled = True
        Me.lstPlanilla.Location = New System.Drawing.Point(12, 118)
        Me.lstPlanilla.Name = "lstPlanilla"
        Me.lstPlanilla.Size = New System.Drawing.Size(508, 225)
        Me.lstPlanilla.TabIndex = 1
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(445, 352)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 119
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CmdGenerar
        '
        Me.CmdGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGenerar.Image = CType(resources.GetObject("CmdGenerar.Image"), System.Drawing.Image)
        Me.CmdGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGenerar.Location = New System.Drawing.Point(221, 349)
        Me.CmdGenerar.Name = "CmdGenerar"
        Me.CmdGenerar.Size = New System.Drawing.Size(75, 66)
        Me.CmdGenerar.TabIndex = 120
        Me.CmdGenerar.Text = "Generar"
        Me.CmdGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGenerar.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(12, 350)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 121
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'FrmPeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 425)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.CmdGenerar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.lstPlanilla)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmPeriodos"
        Me.Text = "FrmPeriodos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboTipoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAño As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoPlanilla As System.Windows.Forms.ComboBox
    Friend WithEvents lstPlanilla As System.Windows.Forms.ListBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CmdGenerar As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboTipoNomina As C1.Win.C1List.C1Combo
End Class
