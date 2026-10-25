<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpresoras
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
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlCard = New System.Windows.Forms.Panel()
        Me.CmbImpresorasComandaBar = New System.Windows.Forms.ComboBox()
        Me.LblComandaBar = New System.Windows.Forms.Label()
        Me.CmbImpresorasComanda = New System.Windows.Forms.ComboBox()
        Me.LblComanda = New System.Windows.Forms.Label()
        Me.CmbImpresorasRecibo = New System.Windows.Forms.ComboBox()
        Me.LblRecibo = New System.Windows.Forms.Label()
        Me.CmbImpresorasRemision = New System.Windows.Forms.ComboBox()
        Me.LblFactura = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.PnlHeader.SuspendLayout()
        Me.PnlCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(460, 60)
        Me.PnlHeader.TabIndex = 0
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(20, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(259, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Impresora que usa cada documento del sistema"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(17, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(120, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Impresoras"
        '
        'PnlCard
        '
        Me.PnlCard.BackColor = System.Drawing.Color.White
        Me.PnlCard.Controls.Add(Me.CmbImpresorasComandaBar)
        Me.PnlCard.Controls.Add(Me.LblComandaBar)
        Me.PnlCard.Controls.Add(Me.CmbImpresorasComanda)
        Me.PnlCard.Controls.Add(Me.LblComanda)
        Me.PnlCard.Controls.Add(Me.CmbImpresorasRecibo)
        Me.PnlCard.Controls.Add(Me.LblRecibo)
        Me.PnlCard.Controls.Add(Me.CmbImpresorasRemision)
        Me.PnlCard.Controls.Add(Me.LblFactura)
        Me.PnlCard.Location = New System.Drawing.Point(20, 65)
        Me.PnlCard.Name = "PnlCard"
        Me.PnlCard.Size = New System.Drawing.Size(420, 330)
        Me.PnlCard.TabIndex = 1
        '
        'CmbImpresorasComandaBar
        '
        Me.CmbImpresorasComandaBar.BackColor = System.Drawing.Color.White
        Me.CmbImpresorasComandaBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbImpresorasComandaBar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbImpresorasComandaBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CmbImpresorasComandaBar.FormattingEnabled = True
        Me.CmbImpresorasComandaBar.Location = New System.Drawing.Point(20, 264)
        Me.CmbImpresorasComandaBar.Name = "CmbImpresorasComandaBar"
        Me.CmbImpresorasComandaBar.Size = New System.Drawing.Size(380, 25)
        Me.CmbImpresorasComandaBar.TabIndex = 7
        '
        'LblComandaBar
        '
        Me.LblComandaBar.AutoSize = True
        Me.LblComandaBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblComandaBar.Location = New System.Drawing.Point(20, 244)
        Me.LblComandaBar.Name = "LblComandaBar"
        Me.LblComandaBar.Size = New System.Drawing.Size(151, 15)
        Me.LblComandaBar.TabIndex = 6
        Me.LblComandaBar.Text = "Impresora de Comanda Bar"
        '
        'CmbImpresorasComanda
        '
        Me.CmbImpresorasComanda.BackColor = System.Drawing.Color.White
        Me.CmbImpresorasComanda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbImpresorasComanda.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbImpresorasComanda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CmbImpresorasComanda.FormattingEnabled = True
        Me.CmbImpresorasComanda.Location = New System.Drawing.Point(20, 188)
        Me.CmbImpresorasComanda.Name = "CmbImpresorasComanda"
        Me.CmbImpresorasComanda.Size = New System.Drawing.Size(380, 25)
        Me.CmbImpresorasComanda.TabIndex = 5
        '
        'LblComanda
        '
        Me.LblComanda.AutoSize = True
        Me.LblComanda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblComanda.Location = New System.Drawing.Point(20, 168)
        Me.LblComanda.Name = "LblComanda"
        Me.LblComanda.Size = New System.Drawing.Size(179, 15)
        Me.LblComanda.TabIndex = 4
        Me.LblComanda.Text = "Impresora de Comanda (Cocina)"
        '
        'CmbImpresorasRecibo
        '
        Me.CmbImpresorasRecibo.BackColor = System.Drawing.Color.White
        Me.CmbImpresorasRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbImpresorasRecibo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbImpresorasRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CmbImpresorasRecibo.FormattingEnabled = True
        Me.CmbImpresorasRecibo.Location = New System.Drawing.Point(20, 112)
        Me.CmbImpresorasRecibo.Name = "CmbImpresorasRecibo"
        Me.CmbImpresorasRecibo.Size = New System.Drawing.Size(380, 25)
        Me.CmbImpresorasRecibo.TabIndex = 3
        '
        'LblRecibo
        '
        Me.LblRecibo.AutoSize = True
        Me.LblRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblRecibo.Location = New System.Drawing.Point(20, 92)
        Me.LblRecibo.Name = "LblRecibo"
        Me.LblRecibo.Size = New System.Drawing.Size(115, 15)
        Me.LblRecibo.TabIndex = 2
        Me.LblRecibo.Text = "Impresora de Recibo"
        '
        'CmbImpresorasRemision
        '
        Me.CmbImpresorasRemision.BackColor = System.Drawing.Color.White
        Me.CmbImpresorasRemision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbImpresorasRemision.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbImpresorasRemision.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CmbImpresorasRemision.FormattingEnabled = True
        Me.CmbImpresorasRemision.Location = New System.Drawing.Point(20, 36)
        Me.CmbImpresorasRemision.Name = "CmbImpresorasRemision"
        Me.CmbImpresorasRemision.Size = New System.Drawing.Size(380, 25)
        Me.CmbImpresorasRemision.TabIndex = 1
        '
        'LblFactura
        '
        Me.LblFactura.AutoSize = True
        Me.LblFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblFactura.Location = New System.Drawing.Point(20, 16)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(118, 15)
        Me.LblFactura.TabIndex = 0
        Me.LblFactura.Text = "Impresora de Factura"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardar.FlatAppearance.BorderSize = 0
        Me.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(20, 400)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(140, 42)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BtnSalir.Location = New System.Drawing.Point(300, 400)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(140, 42)
        Me.BtnSalir.TabIndex = 3
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmImpresoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(460, 448)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.PnlCard)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpresoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresoras"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlCard.ResumeLayout(False)
        Me.PnlCard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlCard As System.Windows.Forms.Panel
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents CmbImpresorasRemision As System.Windows.Forms.ComboBox
    Friend WithEvents LblRecibo As System.Windows.Forms.Label
    Friend WithEvents CmbImpresorasRecibo As System.Windows.Forms.ComboBox
    Friend WithEvents LblComanda As System.Windows.Forms.Label
    Friend WithEvents CmbImpresorasComanda As System.Windows.Forms.ComboBox
    Friend WithEvents LblComandaBar As System.Windows.Forms.Label
    Friend WithEvents CmbImpresorasComandaBar As System.Windows.Forms.ComboBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
End Class
