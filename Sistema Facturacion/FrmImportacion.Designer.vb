<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportacion
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportacion))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FrameTipo = New System.Windows.Forms.GroupBox
        Me.OptActualizaInv = New System.Windows.Forms.RadioButton
        Me.OptInventarioIni = New System.Windows.Forms.RadioButton
        Me.ChkProductos = New System.Windows.Forms.CheckBox
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.CmdLeer = New C1.Win.C1Input.C1Button
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage
        Me.TrueDBGridClientes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptProveedores = New System.Windows.Forms.RadioButton
        Me.OptClientes = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtRutaClientes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.C1Button3 = New C1.Win.C1Input.C1Button
        Me.C1Button4 = New C1.Win.C1Input.C1Button
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage
        Me.TrueDBGridPrecios = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button5 = New C1.Win.C1Input.C1Button
        Me.DefaultToolTipController1 = New DevExpress.Utils.DefaultToolTipController(Me.components)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FrameTipo.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.TrueDBGridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.TrueDBGridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(70, 57)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(326, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(195, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "IMPORTACION DE PRODUCTOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(930, 57)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.XtraTabControl1.Location = New System.Drawing.Point(9, 61)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(921, 392)
        Me.XtraTabControl1.TabIndex = 108
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.TrueDBGridConsultas)
        Me.XtraTabPage1.Controls.Add(Me.GroupBox1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(911, 362)
        Me.XtraTabPage1.Text = "Imp Inventario Incial"
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(5, 80)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(903, 279)
        Me.TrueDBGridConsultas.TabIndex = 107
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FrameTipo)
        Me.GroupBox1.Controls.Add(Me.ChkProductos)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtRuta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.C1Button2)
        Me.GroupBox1.Controls.Add(Me.CmdLeer)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(876, 71)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Importacion"
        '
        'FrameTipo
        '
        Me.FrameTipo.Controls.Add(Me.OptActualizaInv)
        Me.FrameTipo.Controls.Add(Me.OptInventarioIni)
        Me.FrameTipo.Location = New System.Drawing.Point(222, 0)
        Me.FrameTipo.Name = "FrameTipo"
        Me.FrameTipo.Size = New System.Drawing.Size(158, 71)
        Me.FrameTipo.TabIndex = 124
        Me.FrameTipo.TabStop = False
        Me.FrameTipo.Text = "Tipo Importacion"
        '
        'OptActualizaInv
        '
        Me.OptActualizaInv.AutoSize = True
        Me.OptActualizaInv.Location = New System.Drawing.Point(17, 43)
        Me.OptActualizaInv.Name = "OptActualizaInv"
        Me.OptActualizaInv.Size = New System.Drawing.Size(121, 17)
        Me.OptActualizaInv.TabIndex = 126
        Me.OptActualizaInv.TabStop = True
        Me.OptActualizaInv.Text = "Actualizar Inventario"
        Me.OptActualizaInv.UseVisualStyleBackColor = True
        '
        'OptInventarioIni
        '
        Me.OptInventarioIni.AutoSize = True
        Me.OptInventarioIni.Checked = True
        Me.OptInventarioIni.Location = New System.Drawing.Point(17, 20)
        Me.OptInventarioIni.Name = "OptInventarioIni"
        Me.OptInventarioIni.Size = New System.Drawing.Size(102, 17)
        Me.OptInventarioIni.TabIndex = 125
        Me.OptInventarioIni.TabStop = True
        Me.OptInventarioIni.Text = "Inventario Inicial"
        Me.OptInventarioIni.UseVisualStyleBackColor = True
        '
        'ChkProductos
        '
        Me.ChkProductos.AutoSize = True
        Me.ChkProductos.Location = New System.Drawing.Point(24, 45)
        Me.ChkProductos.Name = "ChkProductos"
        Me.ChkProductos.Size = New System.Drawing.Size(139, 17)
        Me.ChkProductos.TabIndex = 123
        Me.ChkProductos.Text = "Solo Importar Productos"
        Me.ChkProductos.UseVisualStyleBackColor = True
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(103, 22)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Fecha Compra"
        '
        'TxtRuta
        '
        Me.TxtRuta.Enabled = False
        Me.TxtRuta.Location = New System.Drawing.Point(386, 33)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.Size = New System.Drawing.Size(286, 20)
        Me.TxtRuta.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Ruta Base de Datos"
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button2.Location = New System.Drawing.Point(772, 14)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(88, 48)
        Me.C1Button2.TabIndex = 108
        Me.C1Button2.Tag = "28"
        Me.C1Button2.Text = "Procesar"
        Me.C1Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CmdLeer
        '
        Me.CmdLeer.Image = CType(resources.GetObject("CmdLeer.Image"), System.Drawing.Image)
        Me.CmdLeer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdLeer.Location = New System.Drawing.Point(678, 14)
        Me.CmdLeer.Name = "CmdLeer"
        Me.CmdLeer.Size = New System.Drawing.Size(88, 48)
        Me.CmdLeer.TabIndex = 107
        Me.CmdLeer.Tag = "25"
        Me.CmdLeer.Text = "Leer Archivo"
        Me.CmdLeer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdLeer.UseVisualStyleBackColor = True
        Me.CmdLeer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.TrueDBGridClientes)
        Me.XtraTabPage2.Controls.Add(Me.GroupBox3)
        Me.XtraTabPage2.Controls.Add(Me.GroupBox2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(911, 362)
        Me.XtraTabPage2.Text = "Imp Clientes/Proveedores"
        '
        'TrueDBGridClientes
        '
        Me.TrueDBGridClientes.AllowUpdate = False
        Me.TrueDBGridClientes.AlternatingRows = True
        Me.TrueDBGridClientes.FilterBar = True
        Me.TrueDBGridClientes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridClientes.Images.Add(CType(resources.GetObject("TrueDBGridClientes.Images"), System.Drawing.Image))
        Me.TrueDBGridClientes.Location = New System.Drawing.Point(3, 89)
        Me.TrueDBGridClientes.Name = "TrueDBGridClientes"
        Me.TrueDBGridClientes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridClientes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridClientes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridClientes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridClientes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridClientes.Size = New System.Drawing.Size(892, 267)
        Me.TrueDBGridClientes.TabIndex = 125
        Me.TrueDBGridClientes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridClientes.PropBag = resources.GetString("TrueDBGridClientes.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.OptProveedores)
        Me.GroupBox3.Controls.Add(Me.OptClientes)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Importacion"
        '
        'OptProveedores
        '
        Me.OptProveedores.AutoSize = True
        Me.OptProveedores.Location = New System.Drawing.Point(17, 43)
        Me.OptProveedores.Name = "OptProveedores"
        Me.OptProveedores.Size = New System.Drawing.Size(85, 17)
        Me.OptProveedores.TabIndex = 126
        Me.OptProveedores.TabStop = True
        Me.OptProveedores.Text = "Proveedores"
        Me.OptProveedores.UseVisualStyleBackColor = True
        '
        'OptClientes
        '
        Me.OptClientes.AutoSize = True
        Me.OptClientes.Checked = True
        Me.OptClientes.Location = New System.Drawing.Point(17, 20)
        Me.OptClientes.Name = "OptClientes"
        Me.OptClientes.Size = New System.Drawing.Size(62, 17)
        Me.OptClientes.TabIndex = 125
        Me.OptClientes.TabStop = True
        Me.OptClientes.Text = "Clientes"
        Me.OptClientes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtRutaClientes)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.C1Button3)
        Me.GroupBox2.Controls.Add(Me.C1Button4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(876, 80)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'TxtRutaClientes
        '
        Me.TxtRutaClientes.Enabled = False
        Me.TxtRutaClientes.Location = New System.Drawing.Point(187, 33)
        Me.TxtRutaClientes.Name = "TxtRutaClientes"
        Me.TxtRutaClientes.Size = New System.Drawing.Size(485, 20)
        Me.TxtRutaClientes.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Ruta Base de Datos"
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button3.Location = New System.Drawing.Point(772, 14)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(88, 48)
        Me.C1Button3.TabIndex = 108
        Me.C1Button3.Tag = "28"
        Me.C1Button3.Text = "Procesar"
        Me.C1Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button4.Location = New System.Drawing.Point(678, 14)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(88, 48)
        Me.C1Button4.TabIndex = 107
        Me.C1Button4.Tag = "25"
        Me.C1Button4.Text = "Leer Archivo"
        Me.C1Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button4.UseVisualStyleBackColor = True
        Me.C1Button4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.TrueDBGridPrecios)
        Me.XtraTabPage3.Controls.Add(Me.GroupBox5)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(911, 362)
        Me.XtraTabPage3.Text = "Precios"
        '
        'TrueDBGridPrecios
        '
        Me.TrueDBGridPrecios.AllowUpdate = False
        Me.TrueDBGridPrecios.AlternatingRows = True
        Me.TrueDBGridPrecios.FilterBar = True
        Me.TrueDBGridPrecios.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridPrecios.Images.Add(CType(resources.GetObject("TrueDBGridPrecios.Images"), System.Drawing.Image))
        Me.TrueDBGridPrecios.Location = New System.Drawing.Point(4, 91)
        Me.TrueDBGridPrecios.Name = "TrueDBGridPrecios"
        Me.TrueDBGridPrecios.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridPrecios.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridPrecios.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridPrecios.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridPrecios.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridPrecios.Size = New System.Drawing.Size(892, 267)
        Me.TrueDBGridPrecios.TabIndex = 127
        Me.TrueDBGridPrecios.Text = "C1TrueDBGrid1"
        Me.TrueDBGridPrecios.PropBag = resources.GetString("TrueDBGridPrecios.PropBag")
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.C1Button1)
        Me.GroupBox5.Controls.Add(Me.C1Button5)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(876, 80)
        Me.GroupBox5.TabIndex = 126
        Me.GroupBox5.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox4.TabIndex = 126
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo Importacion"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(11, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton2.TabIndex = 125
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Precios"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(187, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(485, 20)
        Me.TextBox1.TabIndex = 110
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Ruta de Archivos"
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button1.Location = New System.Drawing.Point(772, 14)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(88, 48)
        Me.C1Button1.TabIndex = 108
        Me.C1Button1.Tag = "28"
        Me.C1Button1.Text = "Procesar"
        Me.C1Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button5
        '
        Me.C1Button5.Image = CType(resources.GetObject("C1Button5.Image"), System.Drawing.Image)
        Me.C1Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button5.Location = New System.Drawing.Point(678, 14)
        Me.C1Button5.Name = "C1Button5"
        Me.C1Button5.Size = New System.Drawing.Size(88, 48)
        Me.C1Button5.TabIndex = 107
        Me.C1Button5.Tag = "25"
        Me.C1Button5.Text = "Leer Archivo"
        Me.C1Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button5.UseVisualStyleBackColor = True
        Me.C1Button5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(9, 459)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(682, 23)
        Me.ProgressBar.TabIndex = 109
        '
        'FrmImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 488)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmImportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmImportacion"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FrameTipo.ResumeLayout(False)
        Me.FrameTipo.PerformLayout()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.TrueDBGridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.TrueDBGridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FrameTipo As System.Windows.Forms.GroupBox
    Friend WithEvents OptActualizaInv As System.Windows.Forms.RadioButton
    Friend WithEvents OptInventarioIni As System.Windows.Forms.RadioButton
    Friend WithEvents ChkProductos As System.Windows.Forms.CheckBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdLeer As C1.Win.C1Input.C1Button
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DefaultToolTipController1 As DevExpress.Utils.DefaultToolTipController
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptProveedores As System.Windows.Forms.RadioButton
    Friend WithEvents OptClientes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRutaClientes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents TrueDBGridClientes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button5 As C1.Win.C1Input.C1Button
    Friend WithEvents TrueDBGridPrecios As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
