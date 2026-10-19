' =====================================================================
' frmServiciosMiscelaneos.Designer.vb
' Formulario "Mantenimiento de Servicios y Misceláneos" - Diseño moderno
' Controles estándar de Windows Forms - Compatible con .NET Framework 4.0
' =====================================================================

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiciosMiscelaneos
    Inherits System.Windows.Forms.Form

    'El formulario invalida el método Dispose para limpiar la lista de componentes.
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlFormulario = New System.Windows.Forms.Panel()
        Me.txtCuentaVenta = New System.Windows.Forms.TextBox()
        Me.btnBuscarCuentaVenta = New System.Windows.Forms.Button()
        Me.lblCuentaVenta = New System.Windows.Forms.Label()
        Me.txtCuentaCosto = New System.Windows.Forms.TextBox()
        Me.btnBuscarCuentaCosto = New System.Windows.Forms.Button()
        Me.lblCuentaCosto = New System.Windows.Forms.Label()
        Me.cboTablaIVA = New System.Windows.Forms.ComboBox()
        Me.lblTablaIVA = New System.Windows.Forms.Label()
        Me.cboActivo = New System.Windows.Forms.ComboBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtPrecioDolar = New System.Windows.Forms.TextBox()
        Me.lblPrecioDolar = New System.Windows.Forms.Label()
        Me.txtPrecioCordoba = New System.Windows.Forms.TextBox()
        Me.lblPrecioCordoba = New System.Windows.Forms.Label()
        Me.pnlTipoCalculo = New System.Windows.Forms.Panel()
        Me.rbSubTotal = New System.Windows.Forms.RadioButton()
        Me.rbUnidsFracciones = New System.Windows.Forms.RadioButton()
        Me.rbImporteFijo = New System.Windows.Forms.RadioButton()
        Me.txtNombreServicio = New System.Windows.Forms.TextBox()
        Me.lblNombreServicio = New System.Windows.Forms.Label()
        Me.cboRubro = New System.Windows.Forms.ComboBox()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.btnBuscarServicio = New System.Windows.Forms.Button()
        Me.cboCodigoServicio = New System.Windows.Forms.ComboBox()
        Me.lblCodigoServicio = New System.Windows.Forms.Label()
        Me.rbDescuento = New System.Windows.Forms.RadioButton()
        Me.rbServicio = New System.Windows.Forms.RadioButton()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlFormulario.SuspendLayout()
        Me.pnlTipoCalculo.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblSubtitulo)
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(660, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.AutoSize = True
        Me.lblSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitulo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.lblSubtitulo.Location = New System.Drawing.Point(22, 34)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(86, 13)
        Me.lblSubtitulo.TabIndex = 1
        Me.lblSubtitulo.Text = "Mantenimiento"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(18, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(211, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Servicios y misceláneos"
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlBody.Controls.Add(Me.pnlFormulario)
        Me.pnlBody.Controls.Add(Me.pnlAcciones)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 60)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlBody.Size = New System.Drawing.Size(660, 540)
        Me.pnlBody.TabIndex = 1
        '
        'pnlFormulario
        '
        Me.pnlFormulario.BackColor = System.Drawing.Color.White
        Me.pnlFormulario.Controls.Add(Me.txtCuentaVenta)
        Me.pnlFormulario.Controls.Add(Me.btnBuscarCuentaVenta)
        Me.pnlFormulario.Controls.Add(Me.lblCuentaVenta)
        Me.pnlFormulario.Controls.Add(Me.txtCuentaCosto)
        Me.pnlFormulario.Controls.Add(Me.btnBuscarCuentaCosto)
        Me.pnlFormulario.Controls.Add(Me.lblCuentaCosto)
        Me.pnlFormulario.Controls.Add(Me.cboTablaIVA)
        Me.pnlFormulario.Controls.Add(Me.lblTablaIVA)
        Me.pnlFormulario.Controls.Add(Me.cboActivo)
        Me.pnlFormulario.Controls.Add(Me.lblActivo)
        Me.pnlFormulario.Controls.Add(Me.txtPrecioDolar)
        Me.pnlFormulario.Controls.Add(Me.lblPrecioDolar)
        Me.pnlFormulario.Controls.Add(Me.txtPrecioCordoba)
        Me.pnlFormulario.Controls.Add(Me.lblPrecioCordoba)
        Me.pnlFormulario.Controls.Add(Me.pnlTipoCalculo)
        Me.pnlFormulario.Controls.Add(Me.txtNombreServicio)
        Me.pnlFormulario.Controls.Add(Me.lblNombreServicio)
        Me.pnlFormulario.Controls.Add(Me.cboRubro)
        Me.pnlFormulario.Controls.Add(Me.lblRubro)
        Me.pnlFormulario.Controls.Add(Me.btnBuscarServicio)
        Me.pnlFormulario.Controls.Add(Me.cboCodigoServicio)
        Me.pnlFormulario.Controls.Add(Me.lblCodigoServicio)
        Me.pnlFormulario.Controls.Add(Me.rbDescuento)
        Me.pnlFormulario.Controls.Add(Me.rbServicio)
        Me.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFormulario.Location = New System.Drawing.Point(20, 20)
        Me.pnlFormulario.Name = "pnlFormulario"
        Me.pnlFormulario.Size = New System.Drawing.Size(470, 500)
        Me.pnlFormulario.TabIndex = 0
        '
        'txtCuentaVenta
        '
        Me.txtCuentaVenta.Location = New System.Drawing.Point(240, 389)
        Me.txtCuentaVenta.Name = "txtCuentaVenta"
        Me.txtCuentaVenta.Size = New System.Drawing.Size(150, 23)
        Me.txtCuentaVenta.TabIndex = 21
        '
        'btnBuscarCuentaVenta
        '
        Me.btnBuscarCuentaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCuentaVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarCuentaVenta.Location = New System.Drawing.Point(396, 388)
        Me.btnBuscarCuentaVenta.Name = "btnBuscarCuentaVenta"
        Me.btnBuscarCuentaVenta.Size = New System.Drawing.Size(30, 24)
        Me.btnBuscarCuentaVenta.TabIndex = 22
        Me.btnBuscarCuentaVenta.Text = "..."
        Me.btnBuscarCuentaVenta.UseVisualStyleBackColor = True
        '
        'lblCuentaVenta
        '
        Me.lblCuentaVenta.AutoSize = True
        Me.lblCuentaVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCuentaVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCuentaVenta.Location = New System.Drawing.Point(240, 372)
        Me.lblCuentaVenta.Name = "lblCuentaVenta"
        Me.lblCuentaVenta.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaVenta.TabIndex = 20
        Me.lblCuentaVenta.Text = "Cuenta venta"
        '
        'txtCuentaCosto
        '
        Me.txtCuentaCosto.Location = New System.Drawing.Point(20, 389)
        Me.txtCuentaCosto.Name = "txtCuentaCosto"
        Me.txtCuentaCosto.Size = New System.Drawing.Size(150, 23)
        Me.txtCuentaCosto.TabIndex = 18
        '
        'btnBuscarCuentaCosto
        '
        Me.btnBuscarCuentaCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCuentaCosto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarCuentaCosto.Location = New System.Drawing.Point(176, 388)
        Me.btnBuscarCuentaCosto.Name = "btnBuscarCuentaCosto"
        Me.btnBuscarCuentaCosto.Size = New System.Drawing.Size(30, 24)
        Me.btnBuscarCuentaCosto.TabIndex = 19
        Me.btnBuscarCuentaCosto.Text = "..."
        Me.btnBuscarCuentaCosto.UseVisualStyleBackColor = True
        '
        'lblCuentaCosto
        '
        Me.lblCuentaCosto.AutoSize = True
        Me.lblCuentaCosto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCuentaCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCuentaCosto.Location = New System.Drawing.Point(20, 372)
        Me.lblCuentaCosto.Name = "lblCuentaCosto"
        Me.lblCuentaCosto.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaCosto.TabIndex = 17
        Me.lblCuentaCosto.Text = "Cuenta costo"
        '
        'cboTablaIVA
        '
        Me.cboTablaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTablaIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTablaIVA.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboTablaIVA.Items.AddRange(New Object() {"0%", "15%"})
        Me.cboTablaIVA.Location = New System.Drawing.Point(240, 337)
        Me.cboTablaIVA.Name = "cboTablaIVA"
        Me.cboTablaIVA.Size = New System.Drawing.Size(190, 23)
        Me.cboTablaIVA.TabIndex = 16
        '
        'lblTablaIVA
        '
        Me.lblTablaIVA.AutoSize = True
        Me.lblTablaIVA.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTablaIVA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTablaIVA.Location = New System.Drawing.Point(240, 320)
        Me.lblTablaIVA.Name = "lblTablaIVA"
        Me.lblTablaIVA.Size = New System.Drawing.Size(62, 13)
        Me.lblTablaIVA.TabIndex = 15
        Me.lblTablaIVA.Text = "Tabla I.V.A."
        '
        'cboActivo
        '
        Me.cboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboActivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboActivo.Items.AddRange(New Object() {"Sí", "No"})
        Me.cboActivo.Location = New System.Drawing.Point(20, 337)
        Me.cboActivo.Name = "cboActivo"
        Me.cboActivo.Size = New System.Drawing.Size(190, 23)
        Me.cboActivo.TabIndex = 14
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(20, 320)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(38, 13)
        Me.lblActivo.TabIndex = 13
        Me.lblActivo.Text = "Activo"
        '
        'txtPrecioDolar
        '
        Me.txtPrecioDolar.Location = New System.Drawing.Point(240, 285)
        Me.txtPrecioDolar.Name = "txtPrecioDolar"
        Me.txtPrecioDolar.Size = New System.Drawing.Size(190, 23)
        Me.txtPrecioDolar.TabIndex = 12
        Me.txtPrecioDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioDolar
        '
        Me.lblPrecioDolar.AutoSize = True
        Me.lblPrecioDolar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblPrecioDolar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblPrecioDolar.Location = New System.Drawing.Point(240, 268)
        Me.lblPrecioDolar.Name = "lblPrecioDolar"
        Me.lblPrecioDolar.Size = New System.Drawing.Size(91, 13)
        Me.lblPrecioDolar.TabIndex = 11
        Me.lblPrecioDolar.Text = "Precio unitario $"
        '
        'txtPrecioCordoba
        '
        Me.txtPrecioCordoba.Location = New System.Drawing.Point(20, 285)
        Me.txtPrecioCordoba.Name = "txtPrecioCordoba"
        Me.txtPrecioCordoba.Size = New System.Drawing.Size(190, 23)
        Me.txtPrecioCordoba.TabIndex = 10
        Me.txtPrecioCordoba.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioCordoba
        '
        Me.lblPrecioCordoba.AutoSize = True
        Me.lblPrecioCordoba.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblPrecioCordoba.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblPrecioCordoba.Location = New System.Drawing.Point(20, 268)
        Me.lblPrecioCordoba.Name = "lblPrecioCordoba"
        Me.lblPrecioCordoba.Size = New System.Drawing.Size(98, 13)
        Me.lblPrecioCordoba.TabIndex = 9
        Me.lblPrecioCordoba.Text = "Precio unitario C$"
        '
        'pnlTipoCalculo
        '
        Me.pnlTipoCalculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlTipoCalculo.Controls.Add(Me.rbSubTotal)
        Me.pnlTipoCalculo.Controls.Add(Me.rbUnidsFracciones)
        Me.pnlTipoCalculo.Controls.Add(Me.rbImporteFijo)
        Me.pnlTipoCalculo.Location = New System.Drawing.Point(20, 205)
        Me.pnlTipoCalculo.Name = "pnlTipoCalculo"
        Me.pnlTipoCalculo.Size = New System.Drawing.Size(420, 45)
        Me.pnlTipoCalculo.TabIndex = 8
        '
        'rbSubTotal
        '
        Me.rbSubTotal.AutoSize = True
        Me.rbSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbSubTotal.Location = New System.Drawing.Point(280, 14)
        Me.rbSubTotal.Name = "rbSubTotal"
        Me.rbSubTotal.Size = New System.Drawing.Size(72, 19)
        Me.rbSubTotal.TabIndex = 2
        Me.rbSubTotal.Text = "Sub total"
        Me.rbSubTotal.UseVisualStyleBackColor = True
        '
        'rbUnidsFracciones
        '
        Me.rbUnidsFracciones.AutoSize = True
        Me.rbUnidsFracciones.Checked = True
        Me.rbUnidsFracciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbUnidsFracciones.Location = New System.Drawing.Point(120, 14)
        Me.rbUnidsFracciones.Name = "rbUnidsFracciones"
        Me.rbUnidsFracciones.Size = New System.Drawing.Size(114, 19)
        Me.rbUnidsFracciones.TabIndex = 1
        Me.rbUnidsFracciones.TabStop = True
        Me.rbUnidsFracciones.Text = "Unids/fracciones"
        Me.rbUnidsFracciones.UseVisualStyleBackColor = True
        '
        'rbImporteFijo
        '
        Me.rbImporteFijo.AutoSize = True
        Me.rbImporteFijo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbImporteFijo.Location = New System.Drawing.Point(10, 14)
        Me.rbImporteFijo.Name = "rbImporteFijo"
        Me.rbImporteFijo.Size = New System.Drawing.Size(87, 19)
        Me.rbImporteFijo.TabIndex = 0
        Me.rbImporteFijo.Text = "Importe fijo"
        Me.rbImporteFijo.UseVisualStyleBackColor = True
        '
        'txtNombreServicio
        '
        Me.txtNombreServicio.Location = New System.Drawing.Point(20, 122)
        Me.txtNombreServicio.Multiline = True
        Me.txtNombreServicio.Name = "txtNombreServicio"
        Me.txtNombreServicio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreServicio.Size = New System.Drawing.Size(420, 70)
        Me.txtNombreServicio.TabIndex = 7
        '
        'lblNombreServicio
        '
        Me.lblNombreServicio.AutoSize = True
        Me.lblNombreServicio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblNombreServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblNombreServicio.Location = New System.Drawing.Point(20, 105)
        Me.lblNombreServicio.Name = "lblNombreServicio"
        Me.lblNombreServicio.Size = New System.Drawing.Size(108, 13)
        Me.lblNombreServicio.TabIndex = 6
        Me.lblNombreServicio.Text = "Nombre del servicio"
        '
        'cboRubro
        '
        Me.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRubro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboRubro.Location = New System.Drawing.Point(250, 72)
        Me.cboRubro.Name = "cboRubro"
        Me.cboRubro.Size = New System.Drawing.Size(190, 23)
        Me.cboRubro.TabIndex = 5
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblRubro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblRubro.Location = New System.Drawing.Point(250, 55)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(39, 13)
        Me.lblRubro.TabIndex = 4
        Me.lblRubro.Text = "Rubro"
        '
        'btnBuscarServicio
        '
        Me.btnBuscarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarServicio.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarServicio.Location = New System.Drawing.Point(206, 71)
        Me.btnBuscarServicio.Name = "btnBuscarServicio"
        Me.btnBuscarServicio.Size = New System.Drawing.Size(30, 24)
        Me.btnBuscarServicio.TabIndex = 3
        Me.btnBuscarServicio.Text = "..."
        Me.btnBuscarServicio.UseVisualStyleBackColor = True
        '
        'cboCodigoServicio
        '
        Me.cboCodigoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCodigoServicio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboCodigoServicio.Location = New System.Drawing.Point(20, 72)
        Me.cboCodigoServicio.Name = "cboCodigoServicio"
        Me.cboCodigoServicio.Size = New System.Drawing.Size(180, 23)
        Me.cboCodigoServicio.TabIndex = 2
        '
        'lblCodigoServicio
        '
        Me.lblCodigoServicio.AutoSize = True
        Me.lblCodigoServicio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCodigoServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCodigoServicio.Location = New System.Drawing.Point(20, 55)
        Me.lblCodigoServicio.Name = "lblCodigoServicio"
        Me.lblCodigoServicio.Size = New System.Drawing.Size(102, 13)
        Me.lblCodigoServicio.TabIndex = 1
        Me.lblCodigoServicio.Text = "Código de servicio"
        '
        'rbDescuento
        '
        Me.rbDescuento.AutoSize = True
        Me.rbDescuento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbDescuento.Location = New System.Drawing.Point(140, 20)
        Me.rbDescuento.Name = "rbDescuento"
        Me.rbDescuento.Size = New System.Drawing.Size(81, 19)
        Me.rbDescuento.TabIndex = 0
        Me.rbDescuento.Text = "Descuento"
        Me.rbDescuento.UseVisualStyleBackColor = True
        '
        'rbServicio
        '
        Me.rbServicio.AutoSize = True
        Me.rbServicio.Checked = True
        Me.rbServicio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbServicio.Location = New System.Drawing.Point(20, 20)
        Me.rbServicio.Name = "rbServicio"
        Me.rbServicio.Size = New System.Drawing.Size(66, 19)
        Me.rbServicio.TabIndex = 0
        Me.rbServicio.TabStop = True
        Me.rbServicio.Text = "Servicio"
        Me.rbServicio.UseVisualStyleBackColor = True
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.btnEliminar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnNuevo)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(490, 20)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(150, 500)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.Location = New System.Drawing.Point(10, 454)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 36)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnEliminar.Location = New System.Drawing.Point(10, 98)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(130, 36)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(10, 54)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 36)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnNuevo.Location = New System.Drawing.Point(10, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(130, 36)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "+ Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmServiciosMiscelaneos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(660, 600)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(676, 638)
        Me.Name = "frmServiciosMiscelaneos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Servicios y Misceláneos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.pnlFormulario.ResumeLayout(False)
        Me.pnlFormulario.PerformLayout()
        Me.pnlTipoCalculo.ResumeLayout(False)
        Me.pnlTipoCalculo.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents pnlFormulario As System.Windows.Forms.Panel
    Friend WithEvents rbDescuento As System.Windows.Forms.RadioButton
    Friend WithEvents rbServicio As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscarServicio As System.Windows.Forms.Button
    Friend WithEvents cboCodigoServicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigoServicio As System.Windows.Forms.Label
    Friend WithEvents cboRubro As System.Windows.Forms.ComboBox
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents txtNombreServicio As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreServicio As System.Windows.Forms.Label
    Friend WithEvents pnlTipoCalculo As System.Windows.Forms.Panel
    Friend WithEvents rbSubTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rbUnidsFracciones As System.Windows.Forms.RadioButton
    Friend WithEvents rbImporteFijo As System.Windows.Forms.RadioButton
    Friend WithEvents txtPrecioDolar As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecioDolar As System.Windows.Forms.Label
    Friend WithEvents txtPrecioCordoba As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecioCordoba As System.Windows.Forms.Label
    Friend WithEvents cboTablaIVA As System.Windows.Forms.ComboBox
    Friend WithEvents lblTablaIVA As System.Windows.Forms.Label
    Friend WithEvents cboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtCuentaVenta As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCuentaVenta As System.Windows.Forms.Button
    Friend WithEvents lblCuentaVenta As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCosto As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCuentaCosto As System.Windows.Forms.Button
    Friend WithEvents lblCuentaCosto As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button

End Class
