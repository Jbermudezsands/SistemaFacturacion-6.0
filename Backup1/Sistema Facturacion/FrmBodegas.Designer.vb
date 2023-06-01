<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBodegas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBodegas))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Opt2 = New System.Windows.Forms.RadioButton
        Me.Opt1 = New System.Windows.Forms.RadioButton
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtExistenciaValoresDolar = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtExistencia = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtCostoPromedioDolar = New System.Windows.Forms.TextBox
        Me.TxtExistenciaValores = New System.Windows.Forms.TextBox
        Me.TxtCostoPromedio = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCtaCosto = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtCuentaVenta = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtGastoAjuste = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtIngresoAjuste = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtCtaInventario = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BindingBodega = New System.Windows.Forms.BindingSource(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.LblProducto = New System.Windows.Forms.Label
        Me.CmdPrecios = New System.Windows.Forms.Button
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(13, 148)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(391, 291)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(383, 265)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.TrueDBGridConsultas)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 243)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Opt2)
        Me.GroupBox2.Controls.Add(Me.Opt1)
        Me.GroupBox2.Location = New System.Drawing.Point(138, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 36)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos Agregar"
        '
        'Opt2
        '
        Me.Opt2.AutoSize = True
        Me.Opt2.Location = New System.Drawing.Point(99, 13)
        Me.Opt2.Name = "Opt2"
        Me.Opt2.Size = New System.Drawing.Size(122, 17)
        Me.Opt2.TabIndex = 1
        Me.Opt2.Text = "Todos los Productos"
        Me.Opt2.UseVisualStyleBackColor = True
        '
        'Opt1
        '
        Me.Opt1.AutoSize = True
        Me.Opt1.Checked = True
        Me.Opt1.Location = New System.Drawing.Point(7, 13)
        Me.Opt1.Name = "Opt1"
        Me.Opt1.Size = New System.Drawing.Size(85, 17)
        Me.Opt1.TabIndex = 0
        Me.Opt1.TabStop = True
        Me.Opt1.Text = "Un Producto"
        Me.Opt1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(74, 188)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(55, 49)
        Me.Button5.TabIndex = 133
        Me.Button5.Text = "Quitar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(13, 188)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(55, 49)
        Me.Button4.TabIndex = 132
        Me.Button4.Text = "Agregar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "Productos Asignados"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(6, 19)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(359, 163)
        Me.TrueDBGridConsultas.TabIndex = 130
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(383, 265)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Informacion "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.TxtExistenciaValoresDolar)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.TxtExistencia)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.TxtCostoPromedioDolar)
        Me.GroupBox4.Controls.Add(Me.TxtExistenciaValores)
        Me.GroupBox4.Controls.Add(Me.TxtCostoPromedio)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Location = New System.Drawing.Point(39, 56)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(305, 159)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Producto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Existencia Valores$"
        '
        'TxtExistenciaValoresDolar
        '
        Me.TxtExistenciaValoresDolar.Enabled = False
        Me.TxtExistenciaValoresDolar.Location = New System.Drawing.Point(117, 79)
        Me.TxtExistenciaValoresDolar.Name = "TxtExistenciaValoresDolar"
        Me.TxtExistenciaValoresDolar.Size = New System.Drawing.Size(145, 20)
        Me.TxtExistenciaValoresDolar.TabIndex = 33
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 131)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(90, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Costo Promedio $"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Existencia Unidades"
        '
        'TxtExistencia
        '
        Me.TxtExistencia.Enabled = False
        Me.TxtExistencia.Location = New System.Drawing.Point(117, 28)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(145, 20)
        Me.TxtExistencia.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Existencia Valores"
        '
        'TxtCostoPromedioDolar
        '
        Me.TxtCostoPromedioDolar.Enabled = False
        Me.TxtCostoPromedioDolar.Location = New System.Drawing.Point(117, 131)
        Me.TxtCostoPromedioDolar.Name = "TxtCostoPromedioDolar"
        Me.TxtCostoPromedioDolar.Size = New System.Drawing.Size(145, 20)
        Me.TxtCostoPromedioDolar.TabIndex = 24
        '
        'TxtExistenciaValores
        '
        Me.TxtExistenciaValores.Enabled = False
        Me.TxtExistenciaValores.Location = New System.Drawing.Point(117, 54)
        Me.TxtExistenciaValores.Name = "TxtExistenciaValores"
        Me.TxtExistenciaValores.Size = New System.Drawing.Size(145, 20)
        Me.TxtExistenciaValores.TabIndex = 22
        '
        'TxtCostoPromedio
        '
        Me.TxtCostoPromedio.Enabled = False
        Me.TxtCostoPromedio.Location = New System.Drawing.Point(117, 105)
        Me.TxtCostoPromedio.Name = "TxtCostoPromedio"
        Me.TxtCostoPromedio.Size = New System.Drawing.Size(145, 20)
        Me.TxtCostoPromedio.TabIndex = 9
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Costo Promedio"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(383, 265)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuentas Contables"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button9)
        Me.GroupBox5.Controls.Add(Me.Button7)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.TxtCtaCosto)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.TxtCuentaVenta)
        Me.GroupBox5.Location = New System.Drawing.Point(34, 139)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(310, 100)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cuentas de Costos"
        '
        'Button9
        '
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.Location = New System.Drawing.Point(274, 19)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(29, 30)
        Me.Button9.TabIndex = 181
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(274, 49)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(29, 30)
        Me.Button7.TabIndex = 180
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 178
        Me.Label12.Text = "Cuenta Venta"
        '
        'TxtCtaCosto
        '
        Me.TxtCtaCosto.Location = New System.Drawing.Point(123, 50)
        Me.TxtCtaCosto.Name = "TxtCtaCosto"
        Me.TxtCtaCosto.Size = New System.Drawing.Size(145, 20)
        Me.TxtCtaCosto.TabIndex = 176
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 177
        Me.Label11.Text = "Cuenta Costo"
        '
        'TxtCuentaVenta
        '
        Me.TxtCuentaVenta.Location = New System.Drawing.Point(123, 24)
        Me.TxtCuentaVenta.Name = "TxtCuentaVenta"
        Me.TxtCuentaVenta.Size = New System.Drawing.Size(145, 20)
        Me.TxtCuentaVenta.TabIndex = 179
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.TxtGastoAjuste)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.TxtIngresoAjuste)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.TxtCtaInventario)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(34, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(310, 118)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos del Producto"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(247, 73)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 30)
        Me.Button3.TabIndex = 171
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(247, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 170
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(247, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 30)
        Me.Button1.TabIndex = 169
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtGastoAjuste
        '
        Me.TxtGastoAjuste.Location = New System.Drawing.Point(123, 77)
        Me.TxtGastoAjuste.Name = "TxtGastoAjuste"
        Me.TxtGastoAjuste.Size = New System.Drawing.Size(118, 20)
        Me.TxtGastoAjuste.TabIndex = 31
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 34
        Me.Label25.Text = "Cta Gastos x Ajustes"
        '
        'TxtIngresoAjuste
        '
        Me.TxtIngresoAjuste.Location = New System.Drawing.Point(123, 48)
        Me.TxtIngresoAjuste.Name = "TxtIngresoAjuste"
        Me.TxtIngresoAjuste.Size = New System.Drawing.Size(118, 20)
        Me.TxtIngresoAjuste.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Cta Ingreso x Ajustes"
        '
        'TxtCtaInventario
        '
        Me.TxtCtaInventario.Location = New System.Drawing.Point(123, 21)
        Me.TxtCtaInventario.Name = "TxtCtaInventario"
        Me.TxtCtaInventario.Size = New System.Drawing.Size(118, 20)
        Me.TxtCtaInventario.TabIndex = 29
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Cuenta Inventario"
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(94, 445)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 24
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(13, 445)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 23
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(329, 445)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 22
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(102, 70)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(259, 21)
        Me.CboCodigoBodega.TabIndex = 135
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(102, 97)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(259, 20)
        Me.TxtNombre.TabIndex = 136
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Nombre Bodega"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(367, 70)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 137
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Codigo Bodega"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(425, 60)
        Me.PictureBox1.TabIndex = 140
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 141
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(109, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(193, 13)
        Me.Label9.TabIndex = 142
        Me.Label9.Text = "REGISTRO DE MULTIBODEGAS"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(175, 445)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(148, 26)
        Me.ProgressBar.TabIndex = 143
        Me.ProgressBar.Visible = False
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.Location = New System.Drawing.Point(176, 478)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(94, 13)
        Me.LblProducto.TabIndex = 144
        Me.LblProducto.Text = "Procesado: 00001"
        Me.LblProducto.Visible = False
        '
        'CmdPrecios
        '
        Me.CmdPrecios.Image = CType(resources.GetObject("CmdPrecios.Image"), System.Drawing.Image)
        Me.CmdPrecios.Location = New System.Drawing.Point(317, 123)
        Me.CmdPrecios.Name = "CmdPrecios"
        Me.CmdPrecios.Size = New System.Drawing.Size(29, 30)
        Me.CmdPrecios.TabIndex = 173
        Me.CmdPrecios.UseVisualStyleBackColor = True
        '
        'CboCodigoCliente
        '
        Me.CboCodigoCliente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoCliente.Caption = ""
        Me.CboCodigoCliente.CaptionHeight = 17
        Me.CboCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoCliente.ColumnCaptionHeight = 17
        Me.CboCodigoCliente.ColumnFooterHeight = 17
        Me.CboCodigoCliente.ContentHeight = 15
        Me.CboCodigoCliente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoCliente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoCliente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoCliente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoCliente.EditorHeight = 15
        Me.CboCodigoCliente.Images.Add(CType(resources.GetObject("CboCodigoCliente.Images"), System.Drawing.Image))
        Me.CboCodigoCliente.ItemHeight = 15
        Me.CboCodigoCliente.Location = New System.Drawing.Point(102, 123)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoCliente.TabIndex = 171
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(16, 128)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(76, 13)
        Me.LblCodigo.TabIndex = 172
        Me.LblCodigo.Text = "Tipo de Precio"
        '
        'FrmBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 518)
        Me.Controls.Add(Me.CmdPrecios)
        Me.Controls.Add(Me.CboCodigoCliente)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Bodegas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtCostoPromedioDolar As System.Windows.Forms.TextBox
    Friend WithEvents TxtExistenciaValores As System.Windows.Forms.TextBox
    Friend WithEvents TxtCostoPromedio As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BindingBodega As System.Windows.Forms.BindingSource
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtExistenciaValoresDolar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Opt2 As System.Windows.Forms.RadioButton
    Friend WithEvents Opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtGastoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtIngresoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaInventario As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CmdPrecios As System.Windows.Forms.Button
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
End Class
