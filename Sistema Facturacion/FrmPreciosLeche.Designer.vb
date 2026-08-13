<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreciosLeche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreciosLeche))
        Me.TDGrigPreciosLeche = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BtnAjustar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        CType(Me.TDGrigPreciosLeche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TDGrigPreciosLeche
        '
        Me.TDGrigPreciosLeche.AlternatingRows = True
        Me.TDGrigPreciosLeche.Caption = "Precios Asignados"
        Me.TDGrigPreciosLeche.FilterBar = True
        Me.TDGrigPreciosLeche.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGrigPreciosLeche.Images.Add(CType(resources.GetObject("TDGrigPreciosLeche.Images"), System.Drawing.Image))
        Me.TDGrigPreciosLeche.Location = New System.Drawing.Point(12, 12)
        Me.TDGrigPreciosLeche.Name = "TDGrigPreciosLeche"
        Me.TDGrigPreciosLeche.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGrigPreciosLeche.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGrigPreciosLeche.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGrigPreciosLeche.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGrigPreciosLeche.Size = New System.Drawing.Size(601, 275)
        Me.TDGrigPreciosLeche.TabIndex = 138
        Me.TDGrigPreciosLeche.Text = "C1TrueDBGrid1"
        Me.TDGrigPreciosLeche.PropBag = resources.GetString("TDGrigPreciosLeche.PropBag")
        '
        'BtnAjustar
        '
        Me.BtnAjustar.Image = CType(resources.GetObject("BtnAjustar.Image"), System.Drawing.Image)
        Me.BtnAjustar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAjustar.Location = New System.Drawing.Point(647, 90)
        Me.BtnAjustar.Name = "BtnAjustar"
        Me.BtnAjustar.Size = New System.Drawing.Size(75, 67)
        Me.BtnAjustar.TabIndex = 143
        Me.BtnAjustar.Text = "Ajustar"
        Me.BtnAjustar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAjustar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(647, 221)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 66)
        Me.BtnSalir.TabIndex = 144
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardar.Location = New System.Drawing.Point(647, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 67)
        Me.BtnGuardar.TabIndex = 145
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FrmPreciosLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnAjustar)
        Me.Controls.Add(Me.TDGrigPreciosLeche)
        Me.Name = "FrmPreciosLeche"
        Me.Text = "FrmPreciosLeche"
        CType(Me.TDGrigPreciosLeche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TDGrigPreciosLeche As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnAjustar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents BtnGuardar As Button
End Class
