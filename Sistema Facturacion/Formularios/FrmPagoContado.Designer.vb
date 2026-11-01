<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagoContado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagoContado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBoxMetodos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtImporte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdDEL = New System.Windows.Forms.Button()
        Me.CmdOK = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Cmd0 = New System.Windows.Forms.Button()
        Me.Cmd3 = New System.Windows.Forms.Button()
        Me.Cmd2 = New System.Windows.Forms.Button()
        Me.Cmd1 = New System.Windows.Forms.Button()
        Me.Cmd6 = New System.Windows.Forms.Button()
        Me.Cmd5 = New System.Windows.Forms.Button()
        Me.Cmd4 = New System.Windows.Forms.Button()
        Me.CmdC = New System.Windows.Forms.Button()
        Me.Cmd9 = New System.Windows.Forms.Button()
        Me.Cmd8 = New System.Windows.Forms.Button()
        Me.Cmd7 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSaldoFavor = New System.Windows.Forms.TextBox()
        Me.TxtSaldoDeudor = New System.Windows.Forms.TextBox()
        Me.txtTotalPagado = New System.Windows.Forms.TextBox()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.BtnAplicar = New C1.Win.C1Input.C1Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.CboMoneda = New System.Windows.Forms.ComboBox()
        Me.CboMetodoPago = New C1.Win.C1List.C1Combo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtTotalApagar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCambio = New System.Windows.Forms.TextBox()
        Me.C1Button1 = New C1.Win.C1Input.C1Button()
        Me.C1Button2 = New C1.Win.C1Input.C1Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboMetodoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(565, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PAGO DIFERIDO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListBoxMetodos
        '
        Me.ListBoxMetodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxMetodos.FormattingEnabled = True
        Me.ListBoxMetodos.ItemHeight = 18
        Me.ListBoxMetodos.Location = New System.Drawing.Point(14, 63)
        Me.ListBoxMetodos.Name = "ListBoxMetodos"
        Me.ListBoxMetodos.Size = New System.Drawing.Size(213, 148)
        Me.ListBoxMetodos.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(427, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 35)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Total A Pagar:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtImporte
        '
        Me.TxtImporte.BackColor = System.Drawing.Color.White
        Me.TxtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporte.Location = New System.Drawing.Point(430, 144)
        Me.TxtImporte.Multiline = True
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(112, 36)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(321, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 36)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Introducir Importe:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CmdDEL)
        Me.GroupBox1.Controls.Add(Me.CmdOK)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Cmd0)
        Me.GroupBox1.Controls.Add(Me.Cmd3)
        Me.GroupBox1.Controls.Add(Me.Cmd2)
        Me.GroupBox1.Controls.Add(Me.Cmd1)
        Me.GroupBox1.Controls.Add(Me.Cmd6)
        Me.GroupBox1.Controls.Add(Me.Cmd5)
        Me.GroupBox1.Controls.Add(Me.Cmd4)
        Me.GroupBox1.Controls.Add(Me.CmdC)
        Me.GroupBox1.Controls.Add(Me.Cmd9)
        Me.GroupBox1.Controls.Add(Me.Cmd8)
        Me.GroupBox1.Controls.Add(Me.Cmd7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 236)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'CmdDEL
        '
        Me.CmdDEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdDEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDEL.Location = New System.Drawing.Point(148, 176)
        Me.CmdDEL.Name = "CmdDEL"
        Me.CmdDEL.Size = New System.Drawing.Size(137, 48)
        Me.CmdDEL.TabIndex = 18
        Me.CmdDEL.Text = "DEL"
        Me.CmdDEL.UseVisualStyleBackColor = True
        '
        'CmdOK
        '
        Me.CmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOK.Location = New System.Drawing.Point(219, 69)
        Me.CmdOK.Name = "CmdOK"
        Me.CmdOK.Size = New System.Drawing.Size(66, 102)
        Me.CmdOK.TabIndex = 17
        Me.CmdOK.Text = "OK"
        Me.CmdOK.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(78, 176)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(66, 48)
        Me.Button12.TabIndex = 16
        Me.Button12.Text = "."
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Cmd0
        '
        Me.Cmd0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd0.Location = New System.Drawing.Point(8, 176)
        Me.Cmd0.Name = "Cmd0"
        Me.Cmd0.Size = New System.Drawing.Size(66, 48)
        Me.Cmd0.TabIndex = 15
        Me.Cmd0.Text = "0"
        Me.Cmd0.UseVisualStyleBackColor = True
        '
        'Cmd3
        '
        Me.Cmd3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd3.Location = New System.Drawing.Point(148, 123)
        Me.Cmd3.Name = "Cmd3"
        Me.Cmd3.Size = New System.Drawing.Size(66, 48)
        Me.Cmd3.TabIndex = 14
        Me.Cmd3.Text = "3"
        Me.Cmd3.UseVisualStyleBackColor = True
        '
        'Cmd2
        '
        Me.Cmd2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd2.Location = New System.Drawing.Point(78, 123)
        Me.Cmd2.Name = "Cmd2"
        Me.Cmd2.Size = New System.Drawing.Size(66, 48)
        Me.Cmd2.TabIndex = 13
        Me.Cmd2.Text = "2"
        Me.Cmd2.UseVisualStyleBackColor = True
        '
        'Cmd1
        '
        Me.Cmd1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd1.Location = New System.Drawing.Point(8, 123)
        Me.Cmd1.Name = "Cmd1"
        Me.Cmd1.Size = New System.Drawing.Size(66, 48)
        Me.Cmd1.TabIndex = 12
        Me.Cmd1.Text = "1"
        Me.Cmd1.UseVisualStyleBackColor = True
        '
        'Cmd6
        '
        Me.Cmd6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd6.Location = New System.Drawing.Point(148, 69)
        Me.Cmd6.Name = "Cmd6"
        Me.Cmd6.Size = New System.Drawing.Size(66, 48)
        Me.Cmd6.TabIndex = 11
        Me.Cmd6.Text = "6"
        Me.Cmd6.UseVisualStyleBackColor = True
        '
        'Cmd5
        '
        Me.Cmd5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd5.Location = New System.Drawing.Point(78, 69)
        Me.Cmd5.Name = "Cmd5"
        Me.Cmd5.Size = New System.Drawing.Size(66, 48)
        Me.Cmd5.TabIndex = 10
        Me.Cmd5.Text = "5"
        Me.Cmd5.UseVisualStyleBackColor = True
        '
        'Cmd4
        '
        Me.Cmd4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd4.Location = New System.Drawing.Point(8, 69)
        Me.Cmd4.Name = "Cmd4"
        Me.Cmd4.Size = New System.Drawing.Size(66, 48)
        Me.Cmd4.TabIndex = 9
        Me.Cmd4.Text = "4"
        Me.Cmd4.UseVisualStyleBackColor = True
        '
        'CmdC
        '
        Me.CmdC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdC.Location = New System.Drawing.Point(219, 15)
        Me.CmdC.Name = "CmdC"
        Me.CmdC.Size = New System.Drawing.Size(66, 48)
        Me.CmdC.TabIndex = 8
        Me.CmdC.Text = "C"
        Me.CmdC.UseVisualStyleBackColor = True
        '
        'Cmd9
        '
        Me.Cmd9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd9.Location = New System.Drawing.Point(148, 15)
        Me.Cmd9.Name = "Cmd9"
        Me.Cmd9.Size = New System.Drawing.Size(66, 48)
        Me.Cmd9.TabIndex = 7
        Me.Cmd9.Text = "9"
        Me.Cmd9.UseVisualStyleBackColor = True
        '
        'Cmd8
        '
        Me.Cmd8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd8.Location = New System.Drawing.Point(78, 15)
        Me.Cmd8.Name = "Cmd8"
        Me.Cmd8.Size = New System.Drawing.Size(66, 48)
        Me.Cmd8.TabIndex = 1
        Me.Cmd8.Text = "8"
        Me.Cmd8.UseVisualStyleBackColor = True
        '
        'Cmd7
        '
        Me.Cmd7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd7.Location = New System.Drawing.Point(8, 15)
        Me.Cmd7.Name = "Cmd7"
        Me.Cmd7.Size = New System.Drawing.Size(66, 48)
        Me.Cmd7.TabIndex = 0
        Me.Cmd7.Text = "7"
        Me.Cmd7.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(355, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Saldo A Favor:"
        Me.Label5.Visible = False
        '
        'TxtSaldoFavor
        '
        Me.TxtSaldoFavor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSaldoFavor.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.TxtSaldoFavor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoFavor.ForeColor = System.Drawing.Color.White
        Me.TxtSaldoFavor.Location = New System.Drawing.Point(358, 361)
        Me.TxtSaldoFavor.Name = "TxtSaldoFavor"
        Me.TxtSaldoFavor.Size = New System.Drawing.Size(149, 20)
        Me.TxtSaldoFavor.TabIndex = 8
        Me.TxtSaldoFavor.Text = "0.00"
        Me.TxtSaldoFavor.Visible = False
        '
        'TxtSaldoDeudor
        '
        Me.TxtSaldoDeudor.BackColor = System.Drawing.Color.White
        Me.TxtSaldoDeudor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoDeudor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtSaldoDeudor.Location = New System.Drawing.Point(116, 19)
        Me.TxtSaldoDeudor.Multiline = True
        Me.TxtSaldoDeudor.Name = "TxtSaldoDeudor"
        Me.TxtSaldoDeudor.Size = New System.Drawing.Size(112, 36)
        Me.TxtSaldoDeudor.TabIndex = 10
        Me.TxtSaldoDeudor.Text = "0.00"
        Me.TxtSaldoDeudor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.Color.White
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPagado.Location = New System.Drawing.Point(116, 58)
        Me.txtTotalPagado.Multiline = True
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.Size = New System.Drawing.Size(112, 36)
        Me.txtTotalPagado.TabIndex = 12
        Me.txtTotalPagado.Text = "0.00"
        Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiferencia.BackColor = System.Drawing.Color.White
        Me.txtDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferencia.ForeColor = System.Drawing.Color.Black
        Me.txtDiferencia.Location = New System.Drawing.Point(358, 383)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Size = New System.Drawing.Size(149, 20)
        Me.txtDiferencia.TabIndex = 14
        Me.txtDiferencia.Text = "0"
        Me.txtDiferencia.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(443, 419)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(92, 42)
        Me.BtnCancelar.TabIndex = 18
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        Me.BtnCancelar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BtnAplicar
        '
        Me.BtnAplicar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAplicar.Image = CType(resources.GetObject("BtnAplicar.Image"), System.Drawing.Image)
        Me.BtnAplicar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAplicar.Location = New System.Drawing.Point(334, 419)
        Me.BtnAplicar.Name = "BtnAplicar"
        Me.BtnAplicar.Size = New System.Drawing.Size(93, 42)
        Me.BtnAplicar.TabIndex = 17
        Me.BtnAplicar.Text = "Aplicar"
        Me.BtnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAplicar.UseVisualStyleBackColor = True
        Me.BtnAplicar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(233, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 137
        Me.Label28.Text = "Moneda"
        '
        'CboMoneda
        '
        Me.CboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMoneda.FormattingEnabled = True
        Me.CboMoneda.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CboMoneda.Location = New System.Drawing.Point(283, 100)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(121, 32)
        Me.CboMoneda.TabIndex = 136
        '
        'CboMetodoPago
        '
        Me.CboMetodoPago.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMetodoPago.Caption = ""
        Me.CboMetodoPago.CaptionHeight = 17
        Me.CboMetodoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMetodoPago.ColumnCaptionHeight = 17
        Me.CboMetodoPago.ColumnFooterHeight = 17
        Me.CboMetodoPago.ContentHeight = 24
        Me.CboMetodoPago.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMetodoPago.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMetodoPago.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMetodoPago.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMetodoPago.EditorHeight = 24
        Me.CboMetodoPago.Images.Add(CType(resources.GetObject("CboMetodoPago.Images"), System.Drawing.Image))
        Me.CboMetodoPago.ItemHeight = 15
        Me.CboMetodoPago.Location = New System.Drawing.Point(236, 64)
        Me.CboMetodoPago.MatchEntryTimeout = CType(2000, Long)
        Me.CboMetodoPago.MaxDropDownItems = CType(5, Short)
        Me.CboMetodoPago.MaxLength = 32767
        Me.CboMetodoPago.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMetodoPago.Name = "CboMetodoPago"
        Me.CboMetodoPago.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMetodoPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMetodoPago.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMetodoPago.Size = New System.Drawing.Size(168, 30)
        Me.CboMetodoPago.TabIndex = 134
        Me.CboMetodoPago.PropBag = resources.GetString("CboMetodoPago.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(233, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 135
        Me.Label11.Text = "Nombre Forma de Pago"
        '
        'TxtTotalApagar
        '
        Me.TxtTotalApagar.BackColor = System.Drawing.Color.White
        Me.TxtTotalApagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalApagar.Location = New System.Drawing.Point(428, 102)
        Me.TxtTotalApagar.Multiline = True
        Me.TxtTotalApagar.Name = "TxtTotalApagar"
        Me.TxtTotalApagar.Size = New System.Drawing.Size(114, 36)
        Me.TxtTotalApagar.TabIndex = 138
        Me.TxtTotalApagar.Text = "0.00"
        Me.TxtTotalApagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(320, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 35)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Cambio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCambio
        '
        Me.TxtCambio.BackColor = System.Drawing.Color.White
        Me.TxtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCambio.Location = New System.Drawing.Point(430, 186)
        Me.TxtCambio.Multiline = True
        Me.TxtCambio.Name = "TxtCambio"
        Me.TxtCambio.Size = New System.Drawing.Size(112, 36)
        Me.TxtCambio.TabIndex = 140
        Me.TxtCambio.Text = "0.00"
        Me.TxtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'C1Button1
        '
        Me.C1Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.C1Button1.Location = New System.Drawing.Point(236, 138)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(43, 42)
        Me.C1Button1.TabIndex = 141
        Me.C1Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button2
        '
        Me.C1Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.C1Button2.Location = New System.Drawing.Point(236, 183)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(43, 40)
        Me.C1Button2.TabIndex = 142
        Me.C1Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 35)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Total Pagado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 35)
        Me.Label6.TabIndex = 144
        Me.Label6.Text = "Pendiente"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TxtSaldoDeudor)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTotalPagado)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(311, 229)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 103)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        '
        'FrmPagoContado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(564, 474)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.TxtCambio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtTotalApagar)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.CboMoneda)
        Me.Controls.Add(Me.CboMetodoPago)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAplicar)
        Me.Controls.Add(Me.txtDiferencia)
        Me.Controls.Add(Me.TxtSaldoFavor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtImporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBoxMetodos)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagoContado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de la Factura"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.CboMetodoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListBoxMetodos As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtImporte As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Cmd7 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Cmd0 As Button
    Friend WithEvents Cmd3 As Button
    Friend WithEvents Cmd2 As Button
    Friend WithEvents Cmd1 As Button
    Friend WithEvents Cmd6 As Button
    Friend WithEvents Cmd5 As Button
    Friend WithEvents Cmd4 As Button
    Friend WithEvents CmdC As Button
    Friend WithEvents Cmd9 As Button
    Friend WithEvents Cmd8 As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents CmdDEL As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtSaldoFavor As TextBox
    Friend WithEvents TxtSaldoDeudor As TextBox
    Friend WithEvents txtTotalPagado As TextBox
    Friend WithEvents txtDiferencia As TextBox
    Friend WithEvents BtnAplicar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents Label28 As Label
    Friend WithEvents CboMoneda As ComboBox
    Friend WithEvents CboMetodoPago As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtTotalApagar As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtCambio As TextBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
End Class
