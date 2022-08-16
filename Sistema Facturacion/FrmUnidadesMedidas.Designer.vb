<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnidadesMedidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnidadesMedidas))
        Me.tdbGridUnidadMedida = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdGuardar = New System.Windows.Forms.Button
        Me.BindingComponentes = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.tdbGridUnidadMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbGridUnidadMedida
        '
        Me.tdbGridUnidadMedida.AllowAddNew = True
        Me.tdbGridUnidadMedida.AlternatingRows = True
        Me.tdbGridUnidadMedida.Caption = "Unidades de Medida"
        Me.tdbGridUnidadMedida.FilterBar = True
        Me.tdbGridUnidadMedida.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbGridUnidadMedida.Images.Add(CType(resources.GetObject("tdbGridUnidadMedida.Images"), System.Drawing.Image))
        Me.tdbGridUnidadMedida.Location = New System.Drawing.Point(12, 12)
        Me.tdbGridUnidadMedida.Name = "tdbGridUnidadMedida"
        Me.tdbGridUnidadMedida.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbGridUnidadMedida.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbGridUnidadMedida.PreviewInfo.ZoomFactor = 75
        Me.tdbGridUnidadMedida.PrintInfo.PageSettings = CType(resources.GetObject("tdbGridUnidadMedida.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbGridUnidadMedida.Size = New System.Drawing.Size(515, 128)
        Me.tdbGridUnidadMedida.TabIndex = 139
        Me.tdbGridUnidadMedida.Text = "C1TrueDBGrid1"
        Me.tdbGridUnidadMedida.PropBag = resources.GetString("tdbGridUnidadMedida.PropBag")
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(452, 146)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 34)
        Me.CmdCerrar.TabIndex = 141
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(12, 146)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 34)
        Me.CmdGuardar.TabIndex = 140
        Me.CmdGuardar.Text = "Pegar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'FrmUnidadesMedidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 188)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.tdbGridUnidadMedida)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUnidadesMedidas"
        Me.Text = "FrmUnidadesMedidas"
        CType(Me.tdbGridUnidadMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tdbGridUnidadMedida As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents BindingComponentes As System.Windows.Forms.BindingSource
End Class
