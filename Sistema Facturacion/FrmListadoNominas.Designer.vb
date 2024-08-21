<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoNominas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoNominas))
        Me.TDGridListadoNomina = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CmdColillas = New System.Windows.Forms.Button()
        Me.CmdNomina = New System.Windows.Forms.Button()
        Me.CmdSalir = New System.Windows.Forms.Button()
        CType(Me.TDGridListadoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TDGridListadoNomina
        '
        Me.TDGridListadoNomina.AlternatingRows = True
        Me.TDGridListadoNomina.Caption = "Listado de Nominas"
        Me.TDGridListadoNomina.FilterBar = True
        Me.TDGridListadoNomina.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridListadoNomina.Images.Add(CType(resources.GetObject("TDGridListadoNomina.Images"), System.Drawing.Image))
        Me.TDGridListadoNomina.Location = New System.Drawing.Point(12, 63)
        Me.TDGridListadoNomina.Name = "TDGridListadoNomina"
        Me.TDGridListadoNomina.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridListadoNomina.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridListadoNomina.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridListadoNomina.PrintInfo.PageSettings = CType(resources.GetObject("TDGridListadoNomina.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridListadoNomina.Size = New System.Drawing.Size(787, 305)
        Me.TDGridListadoNomina.TabIndex = 171
        Me.TDGridListadoNomina.Text = "C1TrueDBGrid1"
        Me.TDGridListadoNomina.PropBag = resources.GetString("TDGridListadoNomina.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(287, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(244, 16)
        Me.Label9.TabIndex = 174
        Me.Label9.Text = "LISTADO DE NOMINAS PROCESADAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 173
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.Location = New System.Drawing.Point(-1, -3)
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.Size = New System.Drawing.Size(969, 60)
        Me.CmdBorraLinea.TabIndex = 172
        Me.CmdBorraLinea.TabStop = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(815, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 186
        Me.Button2.Text = "Imp Colillas"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdColillas
        '
        Me.CmdColillas.Image = CType(resources.GetObject("CmdColillas.Image"), System.Drawing.Image)
        Me.CmdColillas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdColillas.Location = New System.Drawing.Point(815, 136)
        Me.CmdColillas.Name = "CmdColillas"
        Me.CmdColillas.Size = New System.Drawing.Size(75, 67)
        Me.CmdColillas.TabIndex = 185
        Me.CmdColillas.Text = "Imp Recep"
        Me.CmdColillas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdColillas.UseVisualStyleBackColor = True
        '
        'CmdNomina
        '
        Me.CmdNomina.Image = CType(resources.GetObject("CmdNomina.Image"), System.Drawing.Image)
        Me.CmdNomina.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNomina.Location = New System.Drawing.Point(815, 63)
        Me.CmdNomina.Name = "CmdNomina"
        Me.CmdNomina.Size = New System.Drawing.Size(75, 67)
        Me.CmdNomina.TabIndex = 184
        Me.CmdNomina.Text = "Imp Nomina"
        Me.CmdNomina.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNomina.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = CType(resources.GetObject("CmdSalir.Image"), System.Drawing.Image)
        Me.CmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdSalir.Location = New System.Drawing.Point(815, 301)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 67)
        Me.CmdSalir.TabIndex = 187
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'FrmListadoNominas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 392)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdColillas)
        Me.Controls.Add(Me.CmdNomina)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.Controls.Add(Me.TDGridListadoNomina)
        Me.Name = "FrmListadoNominas"
        Me.Text = "FrmListadoNominas"
        CType(Me.TDGridListadoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TDGridListadoNomina As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdBorraLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmdColillas As System.Windows.Forms.Button
    Friend WithEvents CmdNomina As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
End Class
