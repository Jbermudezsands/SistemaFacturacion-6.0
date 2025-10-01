<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaLotes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaLotes))
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowUpdate = False
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Detalle de Productos por Lotes"
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 12)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(557, 208)
        Me.TrueDBGridComponentes.TabIndex = 211
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(494, 226)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 212
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 226)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 213
        Me.Button1.Text = "Pegar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(91, 226)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 34)
        Me.Button2.TabIndex = 214
        Me.Button2.Text = "Agregar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmListaLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 262)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListaLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmListaLotes"
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents Button2 As Button
End Class
