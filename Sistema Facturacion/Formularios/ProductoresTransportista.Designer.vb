<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProveedoresTransportados
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedoresTransportados))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.picIcono = New System.Windows.Forms.PictureBox()
        Me.dgvProductores = New System.Windows.Forms.DataGridView()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.lblTotalPorPagar = New System.Windows.Forms.Label()
        Me.lblTotalLitros = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.LblNombreTransportista = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.pnlEncabezado.Controls.Add(Me.lblCerrar)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.picIcono)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(877, 62)
        Me.pnlEncabezado.TabIndex = 0
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblCerrar.Location = New System.Drawing.Point(849, 4)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(21, 21)
        Me.lblCerrar.TabIndex = 2
        Me.lblCerrar.Text = "×"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(242, 26)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(310, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Lista de Productores transportados"
        '
        'picIcono
        '
        Me.picIcono.BackColor = System.Drawing.Color.Transparent
        Me.picIcono.Image = CType(resources.GetObject("picIcono.Image"), System.Drawing.Image)
        Me.picIcono.Location = New System.Drawing.Point(14, 11)
        Me.picIcono.Name = "picIcono"
        Me.picIcono.Size = New System.Drawing.Size(44, 40)
        Me.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcono.TabIndex = 0
        Me.picIcono.TabStop = False
        '
        'dgvProductores
        '
        Me.dgvProductores.AllowUserToAddRows = False
        Me.dgvProductores.AllowUserToDeleteRows = False
        Me.dgvProductores.AllowUserToResizeRows = False
        Me.dgvProductores.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProductores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvProductores.ColumnHeadersHeight = 30
        Me.dgvProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductores.EnableHeadersVisualStyles = False
        Me.dgvProductores.GridColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.dgvProductores.Location = New System.Drawing.Point(20, 95)
        Me.dgvProductores.MultiSelect = False
        Me.dgvProductores.Name = "dgvProductores"
        Me.dgvProductores.ReadOnly = True
        Me.dgvProductores.RowHeadersVisible = False
        Me.dgvProductores.RowTemplate.Height = 26
        Me.dgvProductores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductores.Size = New System.Drawing.Size(845, 364)
        Me.dgvProductores.TabIndex = 1
        '
        'pnlTotales
        '
        Me.pnlTotales.BackColor = System.Drawing.Color.White
        Me.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotales.Controls.Add(Me.lblTotalPorPagar)
        Me.pnlTotales.Controls.Add(Me.lblTotalLitros)
        Me.pnlTotales.Controls.Add(Me.lblTotal)
        Me.pnlTotales.Location = New System.Drawing.Point(18, 465)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(852, 28)
        Me.pnlTotales.TabIndex = 2
        '
        'lblTotalPorPagar
        '
        Me.lblTotalPorPagar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPorPagar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblTotalPorPagar.Location = New System.Drawing.Point(754, -1)
        Me.lblTotalPorPagar.Name = "lblTotalPorPagar"
        Me.lblTotalPorPagar.Size = New System.Drawing.Size(92, 26)
        Me.lblTotalPorPagar.TabIndex = 2
        Me.lblTotalPorPagar.Text = "0.00"
        Me.lblTotalPorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalLitros
        '
        Me.lblTotalLitros.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotalLitros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblTotalLitros.Location = New System.Drawing.Point(550, -2)
        Me.lblTotalLitros.Name = "lblTotalLitros"
        Me.lblTotalLitros.Size = New System.Drawing.Size(55, 26)
        Me.lblTotalLitros.TabIndex = 1
        Me.lblTotalLitros.Text = "0"
        Me.lblTotalLitros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(429, -1)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(104, 26)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNombreTransportista
        '
        Me.LblNombreTransportista.AutoSize = True
        Me.LblNombreTransportista.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreTransportista.Location = New System.Drawing.Point(20, 69)
        Me.LblNombreTransportista.Name = "LblNombreTransportista"
        Me.LblNombreTransportista.Size = New System.Drawing.Size(93, 13)
        Me.LblNombreTransportista.TabIndex = 3
        Me.LblNombreTransportista.Text = "TRANSPORTISTA"
        '
        'frmProveedoresTransportados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(877, 505)
        Me.Controls.Add(Me.LblNombreTransportista)
        Me.Controls.Add(Me.pnlTotales)
        Me.Controls.Add(Me.dgvProductores)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProveedoresTransportados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lista de proveedores transportados"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotales.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents picIcono As System.Windows.Forms.PictureBox
    Friend WithEvents dgvProductores As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTotales As System.Windows.Forms.Panel
    Friend WithEvents lblTotalPorPagar As System.Windows.Forms.Label
    Friend WithEvents lblTotalLitros As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents LblNombreTransportista As Label
End Class
