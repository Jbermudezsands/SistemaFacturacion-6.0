<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepararLotes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepararLotes))
        Me.TrueDBGridLotes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnRepararLinea = New System.Windows.Forms.Button()
        Me.BtnRepararTodo = New System.Windows.Forms.Button()
        CType(Me.TrueDBGridLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGridLotes
        '
        Me.TrueDBGridLotes.AllowUpdate = False
        Me.TrueDBGridLotes.AlternatingRows = True
        Me.TrueDBGridLotes.FilterBar = True
        Me.TrueDBGridLotes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridLotes.Images.Add(CType(resources.GetObject("TrueDBGridLotes.Images"), System.Drawing.Image))
        Me.TrueDBGridLotes.Location = New System.Drawing.Point(12, 59)
        Me.TrueDBGridLotes.Name = "TrueDBGridLotes"
        Me.TrueDBGridLotes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridLotes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridLotes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridLotes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridLotes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridLotes.Size = New System.Drawing.Size(892, 379)
        Me.TrueDBGridLotes.TabIndex = 126
        Me.TrueDBGridLotes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridLotes.PropBag = resources.GetString("TrueDBGridLotes.PropBag")
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(910, 382)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(124, 56)
        Me.BtnSalir.TabIndex = 262
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1064, 57)
        Me.PictureBox1.TabIndex = 263
        Me.PictureBox1.TabStop = False
        '
        'BtnRepararLinea
        '
        Me.BtnRepararLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRepararLinea.Image = CType(resources.GetObject("BtnRepararLinea.Image"), System.Drawing.Image)
        Me.BtnRepararLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRepararLinea.Location = New System.Drawing.Point(910, 59)
        Me.BtnRepararLinea.Name = "BtnRepararLinea"
        Me.BtnRepararLinea.Size = New System.Drawing.Size(124, 56)
        Me.BtnRepararLinea.TabIndex = 264
        Me.BtnRepararLinea.Text = "Reparar Linea"
        Me.BtnRepararLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRepararLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRepararLinea.UseVisualStyleBackColor = True
        '
        'BtnRepararTodo
        '
        Me.BtnRepararTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRepararTodo.Image = CType(resources.GetObject("BtnRepararTodo.Image"), System.Drawing.Image)
        Me.BtnRepararTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRepararTodo.Location = New System.Drawing.Point(910, 121)
        Me.BtnRepararTodo.Name = "BtnRepararTodo"
        Me.BtnRepararTodo.Size = New System.Drawing.Size(124, 56)
        Me.BtnRepararTodo.TabIndex = 265
        Me.BtnRepararTodo.Text = "Reparar Todo"
        Me.BtnRepararTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRepararTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRepararTodo.UseVisualStyleBackColor = True
        '
        'FrmRepararLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 450)
        Me.Controls.Add(Me.BtnRepararTodo)
        Me.Controls.Add(Me.BtnRepararLinea)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.TrueDBGridLotes)
        Me.Name = "FrmRepararLotes"
        Me.Text = "FrmRepararLotes"
        CType(Me.TrueDBGridLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TrueDBGridLotes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnSalir As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnRepararLinea As Button
    Friend WithEvents BtnRepararTodo As Button
End Class
