<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMedicamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMedicamentos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdGuardar = New System.Windows.Forms.Button
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(345, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 18)
        Me.Label1.TabIndex = 366
        Me.Label1.Text = "Receta de Medicamentos"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(26, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 365
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(-2, 1)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(929, 60)
        Me.PictureBox4.TabIndex = 364
        Me.PictureBox4.TabStop = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = CType(resources.GetObject("CmdEliminar.Image"), System.Drawing.Image)
        Me.CmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEliminar.Location = New System.Drawing.Point(827, 104)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(75, 34)
        Me.CmdEliminar.TabIndex = 363
        Me.CmdEliminar.Text = "Eliminar"
        Me.CmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(827, 411)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 34)
        Me.CmdCerrar.TabIndex = 362
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(827, 67)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 34)
        Me.CmdGuardar.TabIndex = 361
        Me.CmdGuardar.Text = "Generar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "LISTADO DE PRE-CONSULTAS"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(13, 67)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(808, 378)
        Me.TrueDBGridConsultas.TabIndex = 360
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'FrmMedicamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 454)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.CmdEliminar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.TrueDBGridConsultas)
        Me.Name = "FrmMedicamentos"
        Me.Text = "FrmMedicamentos"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
