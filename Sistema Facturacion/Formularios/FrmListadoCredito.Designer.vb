<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoCredito
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoCredito))
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblResumen = New System.Windows.Forms.Label()
        Me.PnlContenido = New System.Windows.Forms.Panel()
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.PnlSeparador = New System.Windows.Forms.Panel()
        Me.BtnEstado = New System.Windows.Forms.Button()
        Me.BtnAmortizacion = New System.Windows.Forms.Button()
        Me.BtnIncobrables = New System.Windows.Forms.Button()
        Me.BtnAnular = New System.Windows.Forms.Button()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BindingPrestamos = New System.Windows.Forms.BindingSource(Me.components)
        Me.PnlHeader.SuspendLayout()
        Me.PnlContenido.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        CType(Me.BindingPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblResumen)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(900, 72)
        Me.PnlHeader.TabIndex = 2
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(19, 12)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(195, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Listado de créditos"
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(22, 44)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(347, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Préstamos otorgados · use la fila de filtros de la tabla para buscar"
        '
        'LblResumen
        '
        Me.LblResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblResumen.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResumen.ForeColor = System.Drawing.Color.White
        Me.LblResumen.Location = New System.Drawing.Point(664, 26)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(220, 20)
        Me.LblResumen.TabIndex = 2
        Me.LblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlContenido
        '
        Me.PnlContenido.Controls.Add(Me.TrueDBGridConsultas)
        Me.PnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlContenido.Location = New System.Drawing.Point(0, 72)
        Me.PnlContenido.Name = "PnlContenido"
        Me.PnlContenido.Padding = New System.Windows.Forms.Padding(16)
        Me.PnlContenido.Size = New System.Drawing.Size(900, 446)
        Me.PnlContenido.TabIndex = 0
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "Préstamos otorgados"
        Me.TrueDBGridConsultas.CaptionHeight = 17
        Me.TrueDBGridConsultas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Arrastre aquí un encabezado de columna para agrupar"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(16, 16)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.RowHeight = 15
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(868, 414)
        Me.TrueDBGridConsultas.TabIndex = 0
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.White
        Me.PnlFooter.Controls.Add(Me.PnlSeparador)
        Me.PnlFooter.Controls.Add(Me.BtnEstado)
        Me.PnlFooter.Controls.Add(Me.BtnAmortizacion)
        Me.PnlFooter.Controls.Add(Me.BtnIncobrables)
        Me.PnlFooter.Controls.Add(Me.BtnAnular)
        Me.PnlFooter.Controls.Add(Me.BtnActualizar)
        Me.PnlFooter.Controls.Add(Me.BtnSalir)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 518)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(900, 62)
        Me.PnlFooter.TabIndex = 1
        '
        'PnlSeparador
        '
        Me.PnlSeparador.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PnlSeparador.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSeparador.Location = New System.Drawing.Point(0, 0)
        Me.PnlSeparador.Name = "PnlSeparador"
        Me.PnlSeparador.Size = New System.Drawing.Size(900, 1)
        Me.PnlSeparador.TabIndex = 10
        '
        'BtnEstado
        '
        Me.BtnEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEstado.FlatAppearance.BorderSize = 0
        Me.BtnEstado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.BtnEstado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEstado.ForeColor = System.Drawing.Color.White
        Me.BtnEstado.Location = New System.Drawing.Point(16, 14)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(130, 34)
        Me.BtnEstado.TabIndex = 0
        Me.BtnEstado.Text = "Estado de cuenta"
        Me.BtnEstado.UseVisualStyleBackColor = False
        '
        'BtnAmortizacion
        '
        Me.BtnAmortizacion.BackColor = System.Drawing.Color.White
        Me.BtnAmortizacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAmortizacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BtnAmortizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnAmortizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAmortizacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.BtnAmortizacion.Location = New System.Drawing.Point(154, 14)
        Me.BtnAmortizacion.Name = "BtnAmortizacion"
        Me.BtnAmortizacion.Size = New System.Drawing.Size(110, 34)
        Me.BtnAmortizacion.TabIndex = 1
        Me.BtnAmortizacion.Text = "Amortización"
        Me.BtnAmortizacion.UseVisualStyleBackColor = False
        '
        'BtnIncobrables
        '
        Me.BtnIncobrables.BackColor = System.Drawing.Color.White
        Me.BtnIncobrables.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIncobrables.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BtnIncobrables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnIncobrables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIncobrables.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.BtnIncobrables.Location = New System.Drawing.Point(272, 14)
        Me.BtnIncobrables.Name = "BtnIncobrables"
        Me.BtnIncobrables.Size = New System.Drawing.Size(100, 34)
        Me.BtnIncobrables.TabIndex = 2
        Me.BtnIncobrables.Text = "Incobrables"
        Me.BtnIncobrables.UseVisualStyleBackColor = False
        '
        'BtnAnular
        '
        Me.BtnAnular.BackColor = System.Drawing.Color.White
        Me.BtnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAnular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.BtnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.BtnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAnular.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.BtnAnular.Location = New System.Drawing.Point(380, 14)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(90, 34)
        Me.BtnAnular.TabIndex = 3
        Me.BtnAnular.Text = "Anular"
        Me.BtnAnular.UseVisualStyleBackColor = False
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.BackColor = System.Drawing.Color.White
        Me.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BtnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnActualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.BtnActualizar.Location = New System.Drawing.Point(696, 14)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 34)
        Me.BtnActualizar.TabIndex = 4
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.BtnSalir.Location = New System.Drawing.Point(794, 14)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 34)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BindingPrestamos
        '
        '
        'FrmListadoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(900, 580)
        Me.Controls.Add(Me.PnlContenido)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(760, 480)
        Me.Name = "FrmListadoCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de créditos"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlContenido.ResumeLayout(False)
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFooter.ResumeLayout(False)
        CType(Me.BindingPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblResumen As System.Windows.Forms.Label
    Friend WithEvents PnlContenido As System.Windows.Forms.Panel
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents BtnEstado As System.Windows.Forms.Button
    Friend WithEvents BtnAmortizacion As System.Windows.Forms.Button
    Friend WithEvents BtnIncobrables As System.Windows.Forms.Button
    Friend WithEvents BtnAnular As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BindingPrestamos As System.Windows.Forms.BindingSource
End Class
