<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcesarRecLeche
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblTotalPlanilla = New System.Windows.Forms.Label
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnProcesar = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnProcesar)
        Me.GroupBox1.Controls.Add(Me.LblTotalPlanilla)
        Me.GroupBox1.Controls.Add(Me.DTPFechaIni)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'LblTotalPlanilla
        '
        Me.LblTotalPlanilla.AutoSize = True
        Me.LblTotalPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPlanilla.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTotalPlanilla.Location = New System.Drawing.Point(545, 48)
        Me.LblTotalPlanilla.Name = "LblTotalPlanilla"
        Me.LblTotalPlanilla.Size = New System.Drawing.Size(25, 24)
        Me.LblTotalPlanilla.TabIndex = 181
        Me.LblTotalPlanilla.Text = "fff"
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(83, 15)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaIni.TabIndex = 179
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(291, 15)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaFin.TabIndex = 178
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "Inicio Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Inicio Periodo"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.Location = New System.Drawing.Point(447, 16)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.BtnProcesar.TabIndex = 182
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 69)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(547, 26)
        Me.ProgressBar.TabIndex = 124
        '
        'FrmProcesarRecLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 106)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmProcesarRecLeche"
        Me.Text = "FrmProcesarRecLeche"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTotalPlanilla As System.Windows.Forms.Label
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnProcesar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
End Class
