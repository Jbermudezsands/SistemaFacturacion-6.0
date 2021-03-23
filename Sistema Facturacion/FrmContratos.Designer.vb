<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContratos))
        Me.TDGridSolicitud = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.BtnActualizar = New System.Windows.Forms.Button
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OptAnulado = New System.Windows.Forms.RadioButton
        Me.OptActivo = New System.Windows.Forms.RadioButton
        Me.Button3 = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.BtnProcesar = New System.Windows.Forms.Button
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TDGridSolicitud
        '
        Me.TDGridSolicitud.AllowUpdate = False
        Me.TDGridSolicitud.AlternatingRows = True
        Me.TDGridSolicitud.Caption = "Listado de Transformacion de productos"
        Me.TDGridSolicitud.FilterBar = True
        Me.TDGridSolicitud.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridSolicitud.Images.Add(CType(resources.GetObject("TDGridSolicitud.Images"), System.Drawing.Image))
        Me.TDGridSolicitud.Location = New System.Drawing.Point(12, 75)
        Me.TDGridSolicitud.Name = "TDGridSolicitud"
        Me.TDGridSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridSolicitud.PreviewInfo.ZoomFactor = 75
        Me.TDGridSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("TDGridSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridSolicitud.Size = New System.Drawing.Size(965, 335)
        Me.TDGridSolicitud.TabIndex = 250
        Me.TDGridSolicitud.Text = "C1TrueDBGrid1"
        Me.TDGridSolicitud.PropBag = resources.GetString("TDGridSolicitud.PropBag")
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(25, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 253
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1130, 60)
        Me.PictureBox1.TabIndex = 252
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(441, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 13)
        Me.Label9.TabIndex = 254
        Me.Label9.Text = "LISTADO DE CONTRATOS"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(986, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 56)
        Me.Button2.TabIndex = 265
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizar.Location = New System.Drawing.Point(986, 190)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(126, 56)
        Me.BtnActualizar.TabIndex = 263
        Me.BtnActualizar.Text = "Actualiza"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVer.Location = New System.Drawing.Point(986, 133)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(126, 56)
        Me.BtnVer.TabIndex = 262
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(986, 359)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(125, 56)
        Me.BtnSalir.TabIndex = 261
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptAnulado)
        Me.GroupBox1.Controls.Add(Me.OptActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(778, 415)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 38)
        Me.GroupBox1.TabIndex = 266
        Me.GroupBox1.TabStop = False
        '
        'OptAnulado
        '
        Me.OptAnulado.AutoSize = True
        Me.OptAnulado.Location = New System.Drawing.Point(108, 15)
        Me.OptAnulado.Name = "OptAnulado"
        Me.OptAnulado.Size = New System.Drawing.Size(69, 17)
        Me.OptAnulado.TabIndex = 2
        Me.OptAnulado.Text = "Anulados"
        Me.OptAnulado.UseVisualStyleBackColor = True
        '
        'OptActivo
        '
        Me.OptActivo.AutoSize = True
        Me.OptActivo.Checked = True
        Me.OptActivo.Location = New System.Drawing.Point(18, 15)
        Me.OptActivo.Name = "OptActivo"
        Me.OptActivo.Size = New System.Drawing.Size(60, 17)
        Me.OptActivo.TabIndex = 1
        Me.OptActivo.TabStop = True
        Me.OptActivo.Text = "Activos"
        Me.OptActivo.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(986, 247)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(126, 56)
        Me.Button3.TabIndex = 267
        Me.Button3.Text = "Anular"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 422)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(735, 23)
        Me.ProgressBar.TabIndex = 268
        '
        'BtnProcesar
        '
        Me.BtnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProcesar.Location = New System.Drawing.Point(986, 303)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Size = New System.Drawing.Size(125, 56)
        Me.BtnProcesar.TabIndex = 269
        Me.BtnProcesar.Text = "Facturar"
        Me.BtnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProcesar.UseVisualStyleBackColor = True
        '
        'FrmContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 463)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnProcesar)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.BtnVer)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TDGridSolicitud)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmContratos"
        Me.Text = "Listado de Contratos"
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TDGridSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAnulado As System.Windows.Forms.RadioButton
    Friend WithEvents OptActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnProcesar As System.Windows.Forms.Button
End Class
