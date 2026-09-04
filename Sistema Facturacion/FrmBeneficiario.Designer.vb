<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBeneficiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBeneficiario))
        Me.TxtNumeroCedula = New System.Windows.Forms.MaskedTextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CboCodigoProductor = New C1.Win.C1List.C1Combo()
        Me.CboSexo = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DTFechaNacimientos = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTFechaAdmision = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.LblApellido = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.LblDireccion = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CmdAgregar = New System.Windows.Forms.Button()
        Me.CmdBorrarFoto = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.ChkProductor = New System.Windows.Forms.CheckBox()
        Me.ChkProveedor = New System.Windows.Forms.CheckBox()
        Me.ChkEmpleado = New System.Windows.Forms.CheckBox()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkTransportista = New System.Windows.Forms.CheckBox()
        Me.ChkSocio = New System.Windows.Forms.CheckBox()
        Me.ChkPreSocio = New System.Windows.Forms.CheckBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CboEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtRuc = New System.Windows.Forms.MaskedTextBox()
        Me.ImgFoto = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabGeneral = New System.Windows.Forms.TabPage()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TxtCuentBanco = New System.Windows.Forms.TextBox()
        Me.TabClientes = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkEfectivo = New System.Windows.Forms.CheckBox()
        Me.CboMunicipio = New C1.Win.C1List.C1Combo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CboDepartamento = New C1.Win.C1List.C1Combo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboEndoso = New C1.Win.C1List.C1Combo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtCtaxCobrar = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkBloqueoLimite = New System.Windows.Forms.CheckBox()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtCedula = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CboMonedaCliente = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkCreditoDisponible = New System.Windows.Forms.CheckBox()
        Me.ChkCausaIVA = New System.Windows.Forms.CheckBox()
        Me.C1Combo1 = New C1.Win.C1List.C1Combo()
        Me.TxtRuc2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCreditoDisCliente = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtCreditoAcumuladoCliente = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtLimiteCliente = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabSocio = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Lbl = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.TxtCtasCobrarSocio = New System.Windows.Forms.TextBox()
        Me.TxtFondosAdmonSocio = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TxtCtaxPagarSocio = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtCtaOtrasSocio = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtCtaVeterinarioSocio = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TxtCtaTrazabilidadSocio = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TxtCtaInseminacionSocio = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TxtCtaTransporteSocio = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TxtCtaGastoSocio = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TxtAnticipoSocio = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TxtCtaBolsaSocio = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtCtaIrSocio = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TxtCtaBancoSocio = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CboTransportistaSocio = New C1.Win.C1List.C1Combo()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.TxtPrecioSocio = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.CboTipoNominaSocio = New C1.Win.C1List.C1Combo()
        Me.CboCooperativaSocio = New C1.Win.C1List.C1Combo()
        Me.CboDepartamentosSocio = New C1.Win.C1List.C1Combo()
        Me.CboEscolaridadSocio = New C1.Win.C1List.C1Combo()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CboRutaSocio = New C1.Win.C1List.C1Combo()
        Me.TabPreSocio = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.TxtCtaxPagarPreSocio = New System.Windows.Forms.TextBox()
        Me.TxtFondosAdmonPreSocio = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtCtaOtrasPreSocio = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TxtCtasCobrarPreSocio = New System.Windows.Forms.TextBox()
        Me.TxtCtaVeterinarioPreSocio = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtCtaTrazabilidadPreSocio = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TxtCtaInseminacionPreSocio = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TxtCtaTransportePreSocio = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.TxtCtaGastoPreSocio = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TxtAnticipoPreSocio = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.TxtCtaBolsaPreSocio = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TxtCtaIrPreSocio = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TxtCtaBancoPreSocio = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CboTransportistaPreSocio = New C1.Win.C1List.C1Combo()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.TxtPrecioPreSocio = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.CboTipoNominaPreSocio = New C1.Win.C1List.C1Combo()
        Me.CboRutaPreSocio = New C1.Win.C1List.C1Combo()
        Me.CboCooperativaPreSocio = New C1.Win.C1List.C1Combo()
        Me.CboDepartamentosPreSocio = New C1.Win.C1List.C1Combo()
        Me.CboEscolaridadPreSocio = New C1.Win.C1List.C1Combo()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabProductor = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Button37 = New System.Windows.Forms.Button()
        Me.TxtCtaxPagarProductor = New System.Windows.Forms.TextBox()
        Me.TxtFondosAdmonProductor = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TxtCtaOtrasProductor = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TxtCtasCobrarProductor = New System.Windows.Forms.TextBox()
        Me.TxtCtaVeterinarioProductor = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.TxtCtaTrazabilidadProductor = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TxtCtaInseminacionProductor = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.TxtCtaTransporteProductor = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Button38 = New System.Windows.Forms.Button()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.TxtCtaGastoProductor = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TxtAnticipoProductor = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.TxtCtaBolsaProductor = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.TxtCtaIrProductor = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.TxtCtaBancoProductor = New System.Windows.Forms.TextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.CboTransportistaProductor = New C1.Win.C1List.C1Combo()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.TxtPrecioProductor = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.CboTipoNominaProductor = New C1.Win.C1List.C1Combo()
        Me.CboRutaProductor = New C1.Win.C1List.C1Combo()
        Me.CboCooperativaProductor = New C1.Win.C1List.C1Combo()
        Me.CboDepartamentosProductor = New C1.Win.C1List.C1Combo()
        Me.CboEscolaridadProductor = New C1.Win.C1List.C1Combo()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.TabTransportista = New System.Windows.Forms.TabPage()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Button44 = New System.Windows.Forms.Button()
        Me.TxtCtaFondos = New System.Windows.Forms.TextBox()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.TxtCtaOtras = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.TxtCtaVeterinario = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Button47 = New System.Windows.Forms.Button()
        Me.TxtCtaTrazabilidad = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Button48 = New System.Windows.Forms.Button()
        Me.TxtCtaInseminacion = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Button49 = New System.Windows.Forms.Button()
        Me.TxtCtaTransporte = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Button50 = New System.Windows.Forms.Button()
        Me.TxtCtaGastoPlanilla = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Button51 = New System.Windows.Forms.Button()
        Me.TxtAnticipo = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Button52 = New System.Windows.Forms.Button()
        Me.TxtCtaBolsa = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Button53 = New System.Windows.Forms.Button()
        Me.TxtCtaIr = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Button54 = New System.Windows.Forms.Button()
        Me.TxtCtaBanco = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.TabProveedor = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.CboMunicipioProveedor = New C1.Win.C1List.C1Combo()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.CboDepartamentoProveedor = New C1.Win.C1List.C1Combo()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.CboEndosoProveedor = New C1.Win.C1List.C1Combo()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.TxtDiasCreditoProveedor = New System.Windows.Forms.NumericUpDown()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.CboMonedaProveedor = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.TxtCreditoDisProveedor = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.TxtCreditoAcumuladoProvee = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.TxtLimiteProveedor = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.TxtCtasxPagarProveedor = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.TabEmpleado = New System.Windows.Forms.TabPage()
        CType(Me.CboCodigoProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.TabClientes.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TxtDiasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSocio.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.CboTransportistaSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoNominaSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCooperativaSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamentosSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEscolaridadSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboRutaSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPreSocio.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.CboTransportistaPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoNominaPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboRutaPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCooperativaPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamentosPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEscolaridadPreSocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabProductor.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.CboTransportistaProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoNominaProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboRutaProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCooperativaProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamentosProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEscolaridadProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabTransportista.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TabProveedor.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.CboMunicipioProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamentoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEndosoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDiasCreditoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNumeroCedula
        '
        Me.TxtNumeroCedula.Location = New System.Drawing.Point(469, 91)
        Me.TxtNumeroCedula.Mask = "0000000000000>A"
        Me.TxtNumeroCedula.Name = "TxtNumeroCedula"
        Me.TxtNumeroCedula.Size = New System.Drawing.Size(135, 20)
        Me.TxtNumeroCedula.TabIndex = 108
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(425, 98)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 13)
        Me.Label29.TabIndex = 185
        Me.Label29.Text = "Cedula"
        '
        'CboCodigoProductor
        '
        Me.CboCodigoProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProductor.Caption = ""
        Me.CboCodigoProductor.CaptionHeight = 17
        Me.CboCodigoProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProductor.ColumnCaptionHeight = 17
        Me.CboCodigoProductor.ColumnFooterHeight = 17
        Me.CboCodigoProductor.ContentHeight = 15
        Me.CboCodigoProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProductor.EditorHeight = 15
        Me.CboCodigoProductor.Images.Add(CType(resources.GetObject("CboCodigoProductor.Images"), System.Drawing.Image))
        Me.CboCodigoProductor.ItemHeight = 15
        Me.CboCodigoProductor.Location = New System.Drawing.Point(121, 152)
        Me.CboCodigoProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProductor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProductor.MaxLength = 32767
        Me.CboCodigoProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProductor.Name = "CboCodigoProductor"
        Me.CboCodigoProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProductor.Size = New System.Drawing.Size(208, 21)
        Me.CboCodigoProductor.TabIndex = 100
        Me.CboCodigoProductor.PropBag = resources.GetString("CboCodigoProductor.PropBag")
        '
        'CboSexo
        '
        Me.CboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo.FormattingEnabled = True
        Me.CboSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.CboSexo.Location = New System.Drawing.Point(469, 66)
        Me.CboSexo.Name = "CboSexo"
        Me.CboSexo.Size = New System.Drawing.Size(135, 21)
        Me.CboSexo.TabIndex = 107
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(432, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(31, 13)
        Me.Label27.TabIndex = 183
        Me.Label27.Text = "Sexo"
        '
        'DTFechaNacimientos
        '
        Me.DTFechaNacimientos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFechaNacimientos.Location = New System.Drawing.Point(469, 42)
        Me.DTFechaNacimientos.Name = "DTFechaNacimientos"
        Me.DTFechaNacimientos.Size = New System.Drawing.Size(135, 20)
        Me.DTFechaNacimientos.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Fecha Nacimiento"
        '
        'DTFechaAdmision
        '
        Me.DTFechaAdmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFechaAdmision.Location = New System.Drawing.Point(469, 16)
        Me.DTFechaAdmision.Name = "DTFechaAdmision"
        Me.DTFechaAdmision.Size = New System.Drawing.Size(135, 20)
        Me.DTFechaAdmision.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(372, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Fecha Admision"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(123, 205)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(249, 20)
        Me.TxtApellidos.TabIndex = 102
        '
        'LblApellido
        '
        Me.LblApellido.AutoSize = True
        Me.LblApellido.Location = New System.Drawing.Point(17, 205)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(93, 13)
        Me.LblApellido.TabIndex = 180
        Me.LblApellido.Text = "Apellido Productor"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(121, 228)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDireccion.Size = New System.Drawing.Size(251, 49)
        Me.TxtDireccion.TabIndex = 103
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(18, 228)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(101, 13)
        Me.LblDireccion.TabIndex = 179
        Me.LblDireccion.Text = "Direccion Productor"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(123, 181)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(249, 20)
        Me.TxtNombre.TabIndex = 101
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(17, 181)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(93, 13)
        Me.LblNombre.TabIndex = 178
        Me.LblNombre.Text = "Nombre Productor"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(17, 152)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(89, 13)
        Me.LblCodigo.TabIndex = 177
        Me.LblCodigo.Text = "Codigo Productor"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CmdAgregar)
        Me.GroupBox6.Controls.Add(Me.CmdBorrarFoto)
        Me.GroupBox6.Location = New System.Drawing.Point(180, 15)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(148, 105)
        Me.GroupBox6.TabIndex = 171
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Foto"
        '
        'CmdAgregar
        '
        Me.CmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAgregar.Image = CType(resources.GetObject("CmdAgregar.Image"), System.Drawing.Image)
        Me.CmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdAgregar.Location = New System.Drawing.Point(6, 19)
        Me.CmdAgregar.Name = "CmdAgregar"
        Me.CmdAgregar.Size = New System.Drawing.Size(65, 67)
        Me.CmdAgregar.TabIndex = 121
        Me.CmdAgregar.Text = "Agregar"
        Me.CmdAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdAgregar.UseVisualStyleBackColor = True
        '
        'CmdBorrarFoto
        '
        Me.CmdBorrarFoto.Image = CType(resources.GetObject("CmdBorrarFoto.Image"), System.Drawing.Image)
        Me.CmdBorrarFoto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdBorrarFoto.Location = New System.Drawing.Point(77, 19)
        Me.CmdBorrarFoto.Name = "CmdBorrarFoto"
        Me.CmdBorrarFoto.Size = New System.Drawing.Size(65, 67)
        Me.CmdBorrarFoto.TabIndex = 122
        Me.CmdBorrarFoto.Text = "Borrar"
        Me.CmdBorrarFoto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdBorrarFoto.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(225, 24)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(293, 13)
        Me.LblTitulo.TabIndex = 189
        Me.LblTitulo.Text = "REGISTRO CODIGOS UNICOS O BENEFICIARIOS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(78, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 188
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(734, 60)
        Me.PictureBox1.TabIndex = 187
        Me.PictureBox1.TabStop = False
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(335, 139)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 120
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(638, 260)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 118
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(642, 86)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 117
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
        Me.Button8.Location = New System.Drawing.Point(638, 333)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 119
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ChkProductor
        '
        Me.ChkProductor.AutoSize = True
        Me.ChkProductor.Checked = True
        Me.ChkProductor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkProductor.Location = New System.Drawing.Point(119, 45)
        Me.ChkProductor.Name = "ChkProductor"
        Me.ChkProductor.Size = New System.Drawing.Size(72, 17)
        Me.ChkProductor.TabIndex = 113
        Me.ChkProductor.Text = "Productor"
        Me.ChkProductor.UseVisualStyleBackColor = True
        '
        'ChkProveedor
        '
        Me.ChkProveedor.AutoSize = True
        Me.ChkProveedor.Checked = True
        Me.ChkProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkProveedor.Location = New System.Drawing.Point(119, 70)
        Me.ChkProveedor.Name = "ChkProveedor"
        Me.ChkProveedor.Size = New System.Drawing.Size(75, 17)
        Me.ChkProveedor.TabIndex = 114
        Me.ChkProveedor.Text = "Proveedor"
        Me.ChkProveedor.UseVisualStyleBackColor = True
        '
        'ChkEmpleado
        '
        Me.ChkEmpleado.AutoSize = True
        Me.ChkEmpleado.Checked = True
        Me.ChkEmpleado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEmpleado.Location = New System.Drawing.Point(121, 19)
        Me.ChkEmpleado.Name = "ChkEmpleado"
        Me.ChkEmpleado.Size = New System.Drawing.Size(73, 17)
        Me.ChkEmpleado.TabIndex = 115
        Me.ChkEmpleado.Text = "Empleado"
        Me.ChkEmpleado.UseVisualStyleBackColor = True
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Checked = True
        Me.ChkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCliente.Location = New System.Drawing.Point(23, 18)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(58, 17)
        Me.ChkCliente.TabIndex = 112
        Me.ChkCliente.Text = "Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTransportista)
        Me.GroupBox1.Controls.Add(Me.ChkSocio)
        Me.GroupBox1.Controls.Add(Me.ChkPreSocio)
        Me.GroupBox1.Controls.Add(Me.ChkCliente)
        Me.GroupBox1.Controls.Add(Me.ChkEmpleado)
        Me.GroupBox1.Controls.Add(Me.ChkProductor)
        Me.GroupBox1.Controls.Add(Me.ChkProveedor)
        Me.GroupBox1.Location = New System.Drawing.Point(389, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 121)
        Me.GroupBox1.TabIndex = 198
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'ChkTransportista
        '
        Me.ChkTransportista.AutoSize = True
        Me.ChkTransportista.Checked = True
        Me.ChkTransportista.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTransportista.Location = New System.Drawing.Point(23, 93)
        Me.ChkTransportista.Name = "ChkTransportista"
        Me.ChkTransportista.Size = New System.Drawing.Size(87, 17)
        Me.ChkTransportista.TabIndex = 118
        Me.ChkTransportista.Text = "Transportista"
        Me.ChkTransportista.UseVisualStyleBackColor = True
        '
        'ChkSocio
        '
        Me.ChkSocio.AutoSize = True
        Me.ChkSocio.Checked = True
        Me.ChkSocio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSocio.Location = New System.Drawing.Point(23, 42)
        Me.ChkSocio.Name = "ChkSocio"
        Me.ChkSocio.Size = New System.Drawing.Size(53, 17)
        Me.ChkSocio.TabIndex = 117
        Me.ChkSocio.Text = "Socio"
        Me.ChkSocio.UseVisualStyleBackColor = True
        '
        'ChkPreSocio
        '
        Me.ChkPreSocio.AutoSize = True
        Me.ChkPreSocio.Checked = True
        Me.ChkPreSocio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPreSocio.Location = New System.Drawing.Point(23, 67)
        Me.ChkPreSocio.Name = "ChkPreSocio"
        Me.ChkPreSocio.Size = New System.Drawing.Size(72, 17)
        Me.ChkPreSocio.TabIndex = 116
        Me.ChkPreSocio.Text = "Pre-Socio"
        Me.ChkPreSocio.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(186, 129)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 116
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Telefono:"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(469, 138)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(135, 20)
        Me.TxtTelefono.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(401, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Estado Civil"
        '
        'CboEstadoCivil
        '
        Me.CboEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstadoCivil.FormattingEnabled = True
        Me.CboEstadoCivil.Items.AddRange(New Object() {"Soltero", "Casado"})
        Me.CboEstadoCivil.Location = New System.Drawing.Point(469, 161)
        Me.CboEstadoCivil.Name = "CboEstadoCivil"
        Me.CboEstadoCivil.Size = New System.Drawing.Size(135, 21)
        Me.CboEstadoCivil.TabIndex = 111
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(433, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "RUC"
        '
        'TxtRuc
        '
        Me.TxtRuc.Location = New System.Drawing.Point(469, 115)
        Me.TxtRuc.Mask = "A<000000000000>A"
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(135, 20)
        Me.TxtRuc.TabIndex = 109
        '
        'ImgFoto
        '
        Me.ImgFoto.Image = CType(resources.GetObject("ImgFoto.Image"), System.Drawing.Image)
        Me.ImgFoto.Location = New System.Drawing.Point(20, 15)
        Me.ImgFoto.Name = "ImgFoto"
        Me.ImgFoto.Size = New System.Drawing.Size(154, 129)
        Me.ImgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgFoto.TabIndex = 205
        Me.ImgFoto.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabGeneral)
        Me.TabControl1.Controls.Add(Me.TabClientes)
        Me.TabControl1.Controls.Add(Me.TabSocio)
        Me.TabControl1.Controls.Add(Me.TabPreSocio)
        Me.TabControl1.Controls.Add(Me.TabProductor)
        Me.TabControl1.Controls.Add(Me.TabTransportista)
        Me.TabControl1.Controls.Add(Me.TabProveedor)
        Me.TabControl1.Controls.Add(Me.TabEmpleado)
        Me.TabControl1.Location = New System.Drawing.Point(12, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(624, 343)
        Me.TabControl1.TabIndex = 206
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.Label91)
        Me.TabGeneral.Controls.Add(Me.TxtCuentBanco)
        Me.TabGeneral.Controls.Add(Me.ImgFoto)
        Me.TabGeneral.Controls.Add(Me.TxtRuc)
        Me.TabGeneral.Controls.Add(Me.GroupBox6)
        Me.TabGeneral.Controls.Add(Me.Label5)
        Me.TabGeneral.Controls.Add(Me.ChkActivo)
        Me.TabGeneral.Controls.Add(Me.LblCodigo)
        Me.TabGeneral.Controls.Add(Me.CboEstadoCivil)
        Me.TabGeneral.Controls.Add(Me.LblNombre)
        Me.TabGeneral.Controls.Add(Me.Label4)
        Me.TabGeneral.Controls.Add(Me.TxtNombre)
        Me.TabGeneral.Controls.Add(Me.TxtTelefono)
        Me.TabGeneral.Controls.Add(Me.LblDireccion)
        Me.TabGeneral.Controls.Add(Me.Label3)
        Me.TabGeneral.Controls.Add(Me.TxtDireccion)
        Me.TabGeneral.Controls.Add(Me.GroupBox1)
        Me.TabGeneral.Controls.Add(Me.LblApellido)
        Me.TabGeneral.Controls.Add(Me.TxtApellidos)
        Me.TabGeneral.Controls.Add(Me.CboCodigoProductor)
        Me.TabGeneral.Controls.Add(Me.Button6)
        Me.TabGeneral.Controls.Add(Me.Label1)
        Me.TabGeneral.Controls.Add(Me.DTFechaAdmision)
        Me.TabGeneral.Controls.Add(Me.Label2)
        Me.TabGeneral.Controls.Add(Me.TxtNumeroCedula)
        Me.TabGeneral.Controls.Add(Me.DTFechaNacimientos)
        Me.TabGeneral.Controls.Add(Me.Label29)
        Me.TabGeneral.Controls.Add(Me.Label27)
        Me.TabGeneral.Controls.Add(Me.CboSexo)
        Me.TabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeneral.Size = New System.Drawing.Size(616, 317)
        Me.TabGeneral.TabIndex = 0
        Me.TabGeneral.Text = "Generales"
        Me.TabGeneral.UseVisualStyleBackColor = True
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(15, 283)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(75, 13)
        Me.Label91.TabIndex = 207
        Me.Label91.Text = "Cuenta Banco"
        '
        'TxtCuentBanco
        '
        Me.TxtCuentBanco.Location = New System.Drawing.Point(121, 283)
        Me.TxtCuentBanco.Name = "TxtCuentBanco"
        Me.TxtCuentBanco.Size = New System.Drawing.Size(249, 20)
        Me.TxtCuentBanco.TabIndex = 206
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.GroupBox3)
        Me.TabClientes.Controls.Add(Me.GroupBox2)
        Me.TabClientes.Location = New System.Drawing.Point(4, 22)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClientes.Size = New System.Drawing.Size(616, 317)
        Me.TabClientes.TabIndex = 1
        Me.TabClientes.Text = "Clientes"
        Me.TabClientes.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkEfectivo)
        Me.GroupBox3.Controls.Add(Me.CboMunicipio)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.CboDepartamento)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CboEndoso)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.TxtCtaxCobrar)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(572, 125)
        Me.GroupBox3.TabIndex = 158
        Me.GroupBox3.TabStop = False
        '
        'ChkEfectivo
        '
        Me.ChkEfectivo.AutoSize = True
        Me.ChkEfectivo.Location = New System.Drawing.Point(175, 97)
        Me.ChkEfectivo.Name = "ChkEfectivo"
        Me.ChkEfectivo.Size = New System.Drawing.Size(101, 17)
        Me.ChkEfectivo.TabIndex = 166
        Me.ChkEfectivo.Text = "Cliente Contado"
        Me.ChkEfectivo.UseVisualStyleBackColor = True
        '
        'CboMunicipio
        '
        Me.CboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMunicipio.Caption = ""
        Me.CboMunicipio.CaptionHeight = 17
        Me.CboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMunicipio.ColumnCaptionHeight = 17
        Me.CboMunicipio.ColumnFooterHeight = 17
        Me.CboMunicipio.ContentHeight = 15
        Me.CboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMunicipio.EditorHeight = 15
        Me.CboMunicipio.Images.Add(CType(resources.GetObject("CboMunicipio.Images"), System.Drawing.Image))
        Me.CboMunicipio.ItemHeight = 15
        Me.CboMunicipio.Location = New System.Drawing.Point(125, 44)
        Me.CboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.CboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.CboMunicipio.MaxLength = 32767
        Me.CboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMunicipio.Name = "CboMunicipio"
        Me.CboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMunicipio.Size = New System.Drawing.Size(150, 21)
        Me.CboMunicipio.TabIndex = 165
        Me.CboMunicipio.PropBag = resources.GetString("CboMunicipio.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(55, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "Municipio"
        '
        'CboDepartamento
        '
        Me.CboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamento.Caption = ""
        Me.CboDepartamento.CaptionHeight = 17
        Me.CboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamento.ColumnCaptionHeight = 17
        Me.CboDepartamento.ColumnFooterHeight = 17
        Me.CboDepartamento.ContentHeight = 15
        Me.CboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamento.EditorHeight = 15
        Me.CboDepartamento.Images.Add(CType(resources.GetObject("CboDepartamento.Images"), System.Drawing.Image))
        Me.CboDepartamento.ItemHeight = 15
        Me.CboDepartamento.Location = New System.Drawing.Point(125, 19)
        Me.CboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamento.MaxLength = 32767
        Me.CboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamento.Size = New System.Drawing.Size(150, 21)
        Me.CboDepartamento.TabIndex = 163
        Me.CboDepartamento.PropBag = resources.GetString("CboDepartamento.PropBag")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 162
        Me.Label8.Text = "Departamento"
        '
        'CboEndoso
        '
        Me.CboEndoso.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEndoso.Caption = ""
        Me.CboEndoso.CaptionHeight = 17
        Me.CboEndoso.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEndoso.ColumnCaptionHeight = 17
        Me.CboEndoso.ColumnFooterHeight = 17
        Me.CboEndoso.ContentHeight = 15
        Me.CboEndoso.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEndoso.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEndoso.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEndoso.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEndoso.EditorHeight = 15
        Me.CboEndoso.Images.Add(CType(resources.GetObject("CboEndoso.Images"), System.Drawing.Image))
        Me.CboEndoso.ItemHeight = 15
        Me.CboEndoso.Location = New System.Drawing.Point(126, 70)
        Me.CboEndoso.MatchEntryTimeout = CType(2000, Long)
        Me.CboEndoso.MaxDropDownItems = CType(5, Short)
        Me.CboEndoso.MaxLength = 32767
        Me.CboEndoso.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEndoso.Name = "CboEndoso"
        Me.CboEndoso.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEndoso.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEndoso.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEndoso.Size = New System.Drawing.Size(150, 21)
        Me.CboEndoso.TabIndex = 160
        Me.CboEndoso.PropBag = resources.GetString("CboEndoso.PropBag")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "Compañia Endoso"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(531, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 28)
        Me.Button1.TabIndex = 158
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(377, 24)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(285, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "Cuenta  x Cobrar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkBloqueoLimite)
        Me.GroupBox2.Controls.Add(Me.CmbEstado)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TxtCedula)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TxtDiasCredito)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.CboMonedaCliente)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.ChkCreditoDisponible)
        Me.GroupBox2.Controls.Add(Me.ChkCausaIVA)
        Me.GroupBox2.Controls.Add(Me.C1Combo1)
        Me.GroupBox2.Controls.Add(Me.TxtRuc2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TxtCreditoDisCliente)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TxtCreditoAcumuladoCliente)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtLimiteCliente)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(572, 169)
        Me.GroupBox2.TabIndex = 157
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Credito"
        '
        'ChkBloqueoLimite
        '
        Me.ChkBloqueoLimite.AutoSize = True
        Me.ChkBloqueoLimite.Location = New System.Drawing.Point(405, 72)
        Me.ChkBloqueoLimite.Name = "ChkBloqueoLimite"
        Me.ChkBloqueoLimite.Size = New System.Drawing.Size(146, 17)
        Me.ChkBloqueoLimite.TabIndex = 140
        Me.ChkBloqueoLimite.Text = "Bloqueo Limite de Credito"
        Me.ChkBloqueoLimite.UseVisualStyleBackColor = True
        '
        'CmbEstado
        '
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"DIA", "MOR", "CJU", "IRR", "REF", "CAS", "VOL", "PJU", "GAR"})
        Me.CmbEstado.Location = New System.Drawing.Point(279, 114)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(107, 21)
        Me.CmbEstado.TabIndex = 139
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(225, 117)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 138
        Me.Label17.Text = "Estado"
        Me.Label17.Visible = False
        '
        'TxtCedula
        '
        Me.TxtCedula.Enabled = False
        Me.TxtCedula.Location = New System.Drawing.Point(279, 82)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(107, 20)
        Me.TxtCedula.TabIndex = 137
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(225, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Cedula"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Location = New System.Drawing.Point(111, 128)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(108, 20)
        Me.TxtDiasCredito.TabIndex = 135
        Me.TxtDiasCredito.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "Dias Credito"
        '
        'CboMonedaCliente
        '
        Me.CboMonedaCliente.FormattingEnabled = True
        Me.CboMonedaCliente.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CboMonedaCliente.Location = New System.Drawing.Point(112, 23)
        Me.CboMonedaCliente.Name = "CboMonedaCliente"
        Me.CboMonedaCliente.Size = New System.Drawing.Size(107, 21)
        Me.CboMonedaCliente.TabIndex = 133
        Me.CboMonedaCliente.Text = "Cordobas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Moneda Factura"
        '
        'ChkCreditoDisponible
        '
        Me.ChkCreditoDisponible.AutoSize = True
        Me.ChkCreditoDisponible.Location = New System.Drawing.Point(405, 49)
        Me.ChkCreditoDisponible.Name = "ChkCreditoDisponible"
        Me.ChkCreditoDisponible.Size = New System.Drawing.Size(111, 17)
        Me.ChkCreditoDisponible.TabIndex = 123
        Me.ChkCreditoDisponible.Text = "Credito Disponible"
        Me.ChkCreditoDisponible.UseVisualStyleBackColor = True
        '
        'ChkCausaIVA
        '
        Me.ChkCausaIVA.AutoSize = True
        Me.ChkCausaIVA.Checked = True
        Me.ChkCausaIVA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCausaIVA.Location = New System.Drawing.Point(405, 22)
        Me.ChkCausaIVA.Name = "ChkCausaIVA"
        Me.ChkCausaIVA.Size = New System.Drawing.Size(76, 17)
        Me.ChkCausaIVA.TabIndex = 122
        Me.ChkCausaIVA.Text = "Causa IVA"
        Me.ChkCausaIVA.UseVisualStyleBackColor = True
        '
        'C1Combo1
        '
        Me.C1Combo1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo1.Caption = ""
        Me.C1Combo1.CaptionHeight = 17
        Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo1.ColumnCaptionHeight = 17
        Me.C1Combo1.ColumnFooterHeight = 17
        Me.C1Combo1.ContentHeight = 15
        Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo1.EditorHeight = 15
        Me.C1Combo1.Images.Add(CType(resources.GetObject("C1Combo1.Images"), System.Drawing.Image))
        Me.C1Combo1.ItemHeight = 15
        Me.C1Combo1.Location = New System.Drawing.Point(281, 25)
        Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo1.MaxDropDownItems = CType(5, Short)
        Me.C1Combo1.MaxLength = 32767
        Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo1.Name = "C1Combo1"
        Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo1.Size = New System.Drawing.Size(105, 21)
        Me.C1Combo1.TabIndex = 121
        Me.C1Combo1.Visible = False
        Me.C1Combo1.PropBag = resources.GetString("C1Combo1.PropBag")
        '
        'TxtRuc2
        '
        Me.TxtRuc2.Enabled = False
        Me.TxtRuc2.Location = New System.Drawing.Point(279, 56)
        Me.TxtRuc2.Name = "TxtRuc2"
        Me.TxtRuc2.Size = New System.Drawing.Size(107, 20)
        Me.TxtRuc2.TabIndex = 103
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(225, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "R.U.C"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(225, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Intereses"
        Me.Label13.Visible = False
        '
        'TxtCreditoDisCliente
        '
        Me.TxtCreditoDisCliente.Enabled = False
        Me.TxtCreditoDisCliente.Location = New System.Drawing.Point(112, 102)
        Me.TxtCreditoDisCliente.Name = "TxtCreditoDisCliente"
        Me.TxtCreditoDisCliente.Size = New System.Drawing.Size(107, 20)
        Me.TxtCreditoDisCliente.TabIndex = 100
        Me.TxtCreditoDisCliente.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "Credito Disponible"
        '
        'TxtCreditoAcumuladoCliente
        '
        Me.TxtCreditoAcumuladoCliente.Enabled = False
        Me.TxtCreditoAcumuladoCliente.Location = New System.Drawing.Point(112, 76)
        Me.TxtCreditoAcumuladoCliente.Name = "TxtCreditoAcumuladoCliente"
        Me.TxtCreditoAcumuladoCliente.Size = New System.Drawing.Size(107, 20)
        Me.TxtCreditoAcumuladoCliente.TabIndex = 98
        Me.TxtCreditoAcumuladoCliente.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 13)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "Credito Acumulado"
        '
        'TxtLimiteCliente
        '
        Me.TxtLimiteCliente.AcceptsReturn = True
        Me.TxtLimiteCliente.Location = New System.Drawing.Point(112, 50)
        Me.TxtLimiteCliente.Name = "TxtLimiteCliente"
        Me.TxtLimiteCliente.Size = New System.Drawing.Size(107, 20)
        Me.TxtLimiteCliente.TabIndex = 96
        Me.TxtLimiteCliente.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Limite de Credito"
        '
        'TabSocio
        '
        Me.TabSocio.Controls.Add(Me.GroupBox13)
        Me.TabSocio.Controls.Add(Me.GroupBox4)
        Me.TabSocio.Location = New System.Drawing.Point(4, 22)
        Me.TabSocio.Name = "TabSocio"
        Me.TabSocio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSocio.Size = New System.Drawing.Size(616, 317)
        Me.TabSocio.TabIndex = 2
        Me.TabSocio.Text = "Socio"
        Me.TabSocio.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Button16)
        Me.GroupBox13.Controls.Add(Me.Button15)
        Me.GroupBox13.Controls.Add(Me.Button14)
        Me.GroupBox13.Controls.Add(Me.Button2)
        Me.GroupBox13.Controls.Add(Me.Button3)
        Me.GroupBox13.Controls.Add(Me.Button13)
        Me.GroupBox13.Controls.Add(Me.Button12)
        Me.GroupBox13.Controls.Add(Me.Lbl)
        Me.GroupBox13.Controls.Add(Me.Button11)
        Me.GroupBox13.Controls.Add(Me.TxtCtasCobrarSocio)
        Me.GroupBox13.Controls.Add(Me.TxtFondosAdmonSocio)
        Me.GroupBox13.Controls.Add(Me.Label36)
        Me.GroupBox13.Controls.Add(Me.TxtCtaxPagarSocio)
        Me.GroupBox13.Controls.Add(Me.Label28)
        Me.GroupBox13.Controls.Add(Me.TxtCtaOtrasSocio)
        Me.GroupBox13.Controls.Add(Me.Label39)
        Me.GroupBox13.Controls.Add(Me.TxtCtaVeterinarioSocio)
        Me.GroupBox13.Controls.Add(Me.Label40)
        Me.GroupBox13.Controls.Add(Me.TxtCtaTrazabilidadSocio)
        Me.GroupBox13.Controls.Add(Me.Label41)
        Me.GroupBox13.Controls.Add(Me.TxtCtaInseminacionSocio)
        Me.GroupBox13.Controls.Add(Me.Label42)
        Me.GroupBox13.Controls.Add(Me.TxtCtaTransporteSocio)
        Me.GroupBox13.Controls.Add(Me.Label44)
        Me.GroupBox13.Controls.Add(Me.Button10)
        Me.GroupBox13.Controls.Add(Me.Button9)
        Me.GroupBox13.Controls.Add(Me.Button7)
        Me.GroupBox13.Controls.Add(Me.Button5)
        Me.GroupBox13.Controls.Add(Me.Button4)
        Me.GroupBox13.Controls.Add(Me.TxtCtaGastoSocio)
        Me.GroupBox13.Controls.Add(Me.Label45)
        Me.GroupBox13.Controls.Add(Me.TxtAnticipoSocio)
        Me.GroupBox13.Controls.Add(Me.Label35)
        Me.GroupBox13.Controls.Add(Me.TxtCtaBolsaSocio)
        Me.GroupBox13.Controls.Add(Me.Label34)
        Me.GroupBox13.Controls.Add(Me.TxtCtaIrSocio)
        Me.GroupBox13.Controls.Add(Me.Label31)
        Me.GroupBox13.Controls.Add(Me.TxtCtaBancoSocio)
        Me.GroupBox13.Controls.Add(Me.Label38)
        Me.GroupBox13.Location = New System.Drawing.Point(14, 111)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(596, 201)
        Me.GroupBox13.TabIndex = 2
        Me.GroupBox13.TabStop = False
        '
        'Button16
        '
        Me.Button16.Image = CType(resources.GetObject("Button16.Image"), System.Drawing.Image)
        Me.Button16.Location = New System.Drawing.Point(494, 145)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(35, 28)
        Me.Button16.TabIndex = 199
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(494, 118)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 28)
        Me.Button15.TabIndex = 198
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.Location = New System.Drawing.Point(494, 91)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(35, 28)
        Me.Button14.TabIndex = 197
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(494, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 28)
        Me.Button2.TabIndex = 175
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(221, 150)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 28)
        Me.Button3.TabIndex = 176
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.Location = New System.Drawing.Point(494, 64)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(35, 28)
        Me.Button13.TabIndex = 196
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.Location = New System.Drawing.Point(494, 36)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(35, 28)
        Me.Button12.TabIndex = 195
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Location = New System.Drawing.Point(266, 181)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(70, 13)
        Me.Lbl.TabIndex = 172
        Me.Lbl.Text = "Ctas x Cobrar"
        '
        'Button11
        '
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.Location = New System.Drawing.Point(494, 8)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(35, 28)
        Me.Button11.TabIndex = 194
        Me.Button11.UseVisualStyleBackColor = True
        '
        'TxtCtasCobrarSocio
        '
        Me.TxtCtasCobrarSocio.Location = New System.Drawing.Point(388, 171)
        Me.TxtCtasCobrarSocio.Name = "TxtCtasCobrarSocio"
        Me.TxtCtasCobrarSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtasCobrarSocio.TabIndex = 166
        '
        'TxtFondosAdmonSocio
        '
        Me.TxtFondosAdmonSocio.AcceptsReturn = True
        Me.TxtFondosAdmonSocio.Location = New System.Drawing.Point(388, 119)
        Me.TxtFondosAdmonSocio.Name = "TxtFondosAdmonSocio"
        Me.TxtFondosAdmonSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtFondosAdmonSocio.TabIndex = 192
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(264, 122)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(113, 13)
        Me.Label36.TabIndex = 190
        Me.Label36.Text = "Administracion Fondos"
        '
        'TxtCtaxPagarSocio
        '
        Me.TxtCtaxPagarSocio.AcceptsReturn = True
        Me.TxtCtaxPagarSocio.Location = New System.Drawing.Point(115, 152)
        Me.TxtCtaxPagarSocio.Name = "TxtCtaxPagarSocio"
        Me.TxtCtaxPagarSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaxPagarSocio.TabIndex = 167
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 159)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 13)
        Me.Label28.TabIndex = 173
        Me.Label28.Text = "Ctas x Pagar"
        '
        'TxtCtaOtrasSocio
        '
        Me.TxtCtaOtrasSocio.Location = New System.Drawing.Point(388, 145)
        Me.TxtCtaOtrasSocio.Name = "TxtCtaOtrasSocio"
        Me.TxtCtaOtrasSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaOtrasSocio.TabIndex = 193
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(266, 153)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(98, 13)
        Me.Label39.TabIndex = 191
        Me.Label39.Text = "Otras Deducciones"
        '
        'TxtCtaVeterinarioSocio
        '
        Me.TxtCtaVeterinarioSocio.Location = New System.Drawing.Point(388, 93)
        Me.TxtCtaVeterinarioSocio.Name = "TxtCtaVeterinarioSocio"
        Me.TxtCtaVeterinarioSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaVeterinarioSocio.TabIndex = 189
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(266, 100)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(113, 13)
        Me.Label40.TabIndex = 188
        Me.Label40.Text = "Productos Veterinarios"
        '
        'TxtCtaTrazabilidadSocio
        '
        Me.TxtCtaTrazabilidadSocio.Location = New System.Drawing.Point(388, 67)
        Me.TxtCtaTrazabilidadSocio.Name = "TxtCtaTrazabilidadSocio"
        Me.TxtCtaTrazabilidadSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTrazabilidadSocio.TabIndex = 187
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(266, 74)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(64, 13)
        Me.Label41.TabIndex = 186
        Me.Label41.Text = "Trazabilidad"
        '
        'TxtCtaInseminacionSocio
        '
        Me.TxtCtaInseminacionSocio.Location = New System.Drawing.Point(388, 39)
        Me.TxtCtaInseminacionSocio.Name = "TxtCtaInseminacionSocio"
        Me.TxtCtaInseminacionSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaInseminacionSocio.TabIndex = 185
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(266, 43)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(69, 13)
        Me.Label42.TabIndex = 184
        Me.Label42.Text = "Inseminacion"
        '
        'TxtCtaTransporteSocio
        '
        Me.TxtCtaTransporteSocio.Location = New System.Drawing.Point(388, 13)
        Me.TxtCtaTransporteSocio.Name = "TxtCtaTransporteSocio"
        Me.TxtCtaTransporteSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTransporteSocio.TabIndex = 183
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(264, 19)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(58, 13)
        Me.Label44.TabIndex = 182
        Me.Label44.Text = "Transporte"
        '
        'Button10
        '
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(221, 123)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(35, 28)
        Me.Button10.TabIndex = 181
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.Location = New System.Drawing.Point(221, 94)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(35, 28)
        Me.Button9.TabIndex = 180
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(221, 66)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(35, 28)
        Me.Button7.TabIndex = 179
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(221, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(35, 28)
        Me.Button5.TabIndex = 178
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(221, 11)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(35, 28)
        Me.Button4.TabIndex = 177
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtCtaGastoSocio
        '
        Me.TxtCtaGastoSocio.Location = New System.Drawing.Point(115, 19)
        Me.TxtCtaGastoSocio.Name = "TxtCtaGastoSocio"
        Me.TxtCtaGastoSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaGastoSocio.TabIndex = 176
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(8, 26)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(71, 13)
        Me.Label45.TabIndex = 175
        Me.Label45.Text = "Gasto Planilla"
        '
        'TxtAnticipoSocio
        '
        Me.TxtAnticipoSocio.AcceptsReturn = True
        Me.TxtAnticipoSocio.Location = New System.Drawing.Point(115, 126)
        Me.TxtAnticipoSocio.Name = "TxtAnticipoSocio"
        Me.TxtAnticipoSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtAnticipoSocio.TabIndex = 173
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(8, 129)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 13)
        Me.Label35.TabIndex = 172
        Me.Label35.Text = "Anticipo de Planilla"
        '
        'TxtCtaBolsaSocio
        '
        Me.TxtCtaBolsaSocio.Location = New System.Drawing.Point(115, 98)
        Me.TxtCtaBolsaSocio.Name = "TxtCtaBolsaSocio"
        Me.TxtCtaBolsaSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBolsaSocio.TabIndex = 170
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(8, 103)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(86, 13)
        Me.Label34.TabIndex = 169
        Me.Label34.Text = "Bolsa de Valores"
        '
        'TxtCtaIrSocio
        '
        Me.TxtCtaIrSocio.Location = New System.Drawing.Point(115, 72)
        Me.TxtCtaIrSocio.Name = "TxtCtaIrSocio"
        Me.TxtCtaIrSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaIrSocio.TabIndex = 167
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(8, 74)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 13)
        Me.Label31.TabIndex = 166
        Me.Label31.Text = "Cuenta IR"
        '
        'TxtCtaBancoSocio
        '
        Me.TxtCtaBancoSocio.Location = New System.Drawing.Point(115, 44)
        Me.TxtCtaBancoSocio.Name = "TxtCtaBancoSocio"
        Me.TxtCtaBancoSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBancoSocio.TabIndex = 164
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(8, 46)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(75, 13)
        Me.Label38.TabIndex = 141
        Me.Label38.Text = "Cuenta Banco"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CboTransportistaSocio)
        Me.GroupBox4.Controls.Add(Me.Label98)
        Me.GroupBox4.Controls.Add(Me.TxtPrecioSocio)
        Me.GroupBox4.Controls.Add(Me.Label92)
        Me.GroupBox4.Controls.Add(Me.CboTipoNominaSocio)
        Me.GroupBox4.Controls.Add(Me.CboCooperativaSocio)
        Me.GroupBox4.Controls.Add(Me.CboDepartamentosSocio)
        Me.GroupBox4.Controls.Add(Me.CboEscolaridadSocio)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.CboRutaSocio)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(588, 103)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'CboTransportistaSocio
        '
        Me.CboTransportistaSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTransportistaSocio.Caption = ""
        Me.CboTransportistaSocio.CaptionHeight = 17
        Me.CboTransportistaSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTransportistaSocio.ColumnCaptionHeight = 17
        Me.CboTransportistaSocio.ColumnFooterHeight = 17
        Me.CboTransportistaSocio.ContentHeight = 15
        Me.CboTransportistaSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTransportistaSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTransportistaSocio.DropDownWidth = 300
        Me.CboTransportistaSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTransportistaSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTransportistaSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTransportistaSocio.EditorHeight = 15
        Me.CboTransportistaSocio.Images.Add(CType(resources.GetObject("CboTransportistaSocio.Images"), System.Drawing.Image))
        Me.CboTransportistaSocio.ItemHeight = 15
        Me.CboTransportistaSocio.Location = New System.Drawing.Point(317, 42)
        Me.CboTransportistaSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboTransportistaSocio.MaxDropDownItems = CType(5, Short)
        Me.CboTransportistaSocio.MaxLength = 32767
        Me.CboTransportistaSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTransportistaSocio.Name = "CboTransportistaSocio"
        Me.CboTransportistaSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTransportistaSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTransportistaSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTransportistaSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboTransportistaSocio.TabIndex = 181
        Me.CboTransportistaSocio.PropBag = resources.GetString("CboTransportistaSocio.PropBag")
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Location = New System.Drawing.Point(242, 47)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(68, 13)
        Me.Label98.TabIndex = 182
        Me.Label98.Text = "Transportista"
        '
        'TxtPrecioSocio
        '
        Me.TxtPrecioSocio.Location = New System.Drawing.Point(317, 73)
        Me.TxtPrecioSocio.Name = "TxtPrecioSocio"
        Me.TxtPrecioSocio.Size = New System.Drawing.Size(79, 20)
        Me.TxtPrecioSocio.TabIndex = 180
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(242, 79)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(73, 13)
        Me.Label92.TabIndex = 179
        Me.Label92.Text = "Precio Leche:"
        '
        'CboTipoNominaSocio
        '
        Me.CboTipoNominaSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoNominaSocio.Caption = ""
        Me.CboTipoNominaSocio.CaptionHeight = 17
        Me.CboTipoNominaSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoNominaSocio.ColumnCaptionHeight = 17
        Me.CboTipoNominaSocio.ColumnFooterHeight = 17
        Me.CboTipoNominaSocio.ContentHeight = 15
        Me.CboTipoNominaSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoNominaSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTipoNominaSocio.DropDownWidth = 300
        Me.CboTipoNominaSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoNominaSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoNominaSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoNominaSocio.EditorHeight = 15
        Me.CboTipoNominaSocio.Images.Add(CType(resources.GetObject("CboTipoNominaSocio.Images"), System.Drawing.Image))
        Me.CboTipoNominaSocio.ItemHeight = 15
        Me.CboTipoNominaSocio.Location = New System.Drawing.Point(317, 13)
        Me.CboTipoNominaSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoNominaSocio.MaxDropDownItems = CType(5, Short)
        Me.CboTipoNominaSocio.MaxLength = 32767
        Me.CboTipoNominaSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoNominaSocio.Name = "CboTipoNominaSocio"
        Me.CboTipoNominaSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoNominaSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoNominaSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoNominaSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoNominaSocio.TabIndex = 178
        Me.CboTipoNominaSocio.PropBag = resources.GetString("CboTipoNominaSocio.PropBag")
        '
        'CboCooperativaSocio
        '
        Me.CboCooperativaSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCooperativaSocio.Caption = ""
        Me.CboCooperativaSocio.CaptionHeight = 17
        Me.CboCooperativaSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCooperativaSocio.ColumnCaptionHeight = 17
        Me.CboCooperativaSocio.ColumnFooterHeight = 17
        Me.CboCooperativaSocio.ContentHeight = 15
        Me.CboCooperativaSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCooperativaSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCooperativaSocio.DropDownWidth = 300
        Me.CboCooperativaSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCooperativaSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCooperativaSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCooperativaSocio.EditorHeight = 15
        Me.CboCooperativaSocio.Images.Add(CType(resources.GetObject("CboCooperativaSocio.Images"), System.Drawing.Image))
        Me.CboCooperativaSocio.ItemHeight = 15
        Me.CboCooperativaSocio.Location = New System.Drawing.Point(101, 71)
        Me.CboCooperativaSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboCooperativaSocio.MaxDropDownItems = CType(5, Short)
        Me.CboCooperativaSocio.MaxLength = 32767
        Me.CboCooperativaSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCooperativaSocio.Name = "CboCooperativaSocio"
        Me.CboCooperativaSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCooperativaSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCooperativaSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCooperativaSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboCooperativaSocio.TabIndex = 165
        Me.CboCooperativaSocio.PropBag = resources.GetString("CboCooperativaSocio.PropBag")
        '
        'CboDepartamentosSocio
        '
        Me.CboDepartamentosSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamentosSocio.Caption = ""
        Me.CboDepartamentosSocio.CaptionHeight = 17
        Me.CboDepartamentosSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamentosSocio.ColumnCaptionHeight = 17
        Me.CboDepartamentosSocio.ColumnFooterHeight = 17
        Me.CboDepartamentosSocio.ContentHeight = 15
        Me.CboDepartamentosSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamentosSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDepartamentosSocio.DropDownWidth = 300
        Me.CboDepartamentosSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamentosSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamentosSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamentosSocio.EditorHeight = 15
        Me.CboDepartamentosSocio.Images.Add(CType(resources.GetObject("CboDepartamentosSocio.Images"), System.Drawing.Image))
        Me.CboDepartamentosSocio.ItemHeight = 15
        Me.CboDepartamentosSocio.Location = New System.Drawing.Point(101, 44)
        Me.CboDepartamentosSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamentosSocio.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamentosSocio.MaxLength = 32767
        Me.CboDepartamentosSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamentosSocio.Name = "CboDepartamentosSocio"
        Me.CboDepartamentosSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamentosSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamentosSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamentosSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboDepartamentosSocio.TabIndex = 164
        Me.CboDepartamentosSocio.PropBag = resources.GetString("CboDepartamentosSocio.PropBag")
        '
        'CboEscolaridadSocio
        '
        Me.CboEscolaridadSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEscolaridadSocio.Caption = ""
        Me.CboEscolaridadSocio.CaptionHeight = 17
        Me.CboEscolaridadSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEscolaridadSocio.ColumnCaptionHeight = 17
        Me.CboEscolaridadSocio.ColumnFooterHeight = 17
        Me.CboEscolaridadSocio.ContentHeight = 15
        Me.CboEscolaridadSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEscolaridadSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEscolaridadSocio.DropDownWidth = 300
        Me.CboEscolaridadSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEscolaridadSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEscolaridadSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEscolaridadSocio.EditorHeight = 15
        Me.CboEscolaridadSocio.Images.Add(CType(resources.GetObject("CboEscolaridadSocio.Images"), System.Drawing.Image))
        Me.CboEscolaridadSocio.ItemHeight = 15
        Me.CboEscolaridadSocio.Location = New System.Drawing.Point(101, 16)
        Me.CboEscolaridadSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboEscolaridadSocio.MaxDropDownItems = CType(5, Short)
        Me.CboEscolaridadSocio.MaxLength = 32767
        Me.CboEscolaridadSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEscolaridadSocio.Name = "CboEscolaridadSocio"
        Me.CboEscolaridadSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEscolaridadSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEscolaridadSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEscolaridadSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboEscolaridadSocio.TabIndex = 163
        Me.CboEscolaridadSocio.PropBag = resources.GetString("CboEscolaridadSocio.PropBag")
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(242, 19)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(30, 13)
        Me.Label26.TabIndex = 171
        Me.Label26.Text = "Ruta"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 76)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 170
        Me.Label19.Text = "Cooperativa"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Departamentos"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 168
        Me.Label21.Text = "Escolaridad"
        '
        'CboRutaSocio
        '
        Me.CboRutaSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboRutaSocio.Caption = ""
        Me.CboRutaSocio.CaptionHeight = 17
        Me.CboRutaSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboRutaSocio.ColumnCaptionHeight = 17
        Me.CboRutaSocio.ColumnFooterHeight = 17
        Me.CboRutaSocio.ContentHeight = 15
        Me.CboRutaSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboRutaSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboRutaSocio.DropDownWidth = 300
        Me.CboRutaSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboRutaSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRutaSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboRutaSocio.EditorHeight = 15
        Me.CboRutaSocio.Images.Add(CType(resources.GetObject("CboRutaSocio.Images"), System.Drawing.Image))
        Me.CboRutaSocio.ItemHeight = 15
        Me.CboRutaSocio.Location = New System.Drawing.Point(113, 16)
        Me.CboRutaSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboRutaSocio.MaxDropDownItems = CType(5, Short)
        Me.CboRutaSocio.MaxLength = 32767
        Me.CboRutaSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboRutaSocio.Name = "CboRutaSocio"
        Me.CboRutaSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboRutaSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboRutaSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboRutaSocio.Size = New System.Drawing.Size(47, 21)
        Me.CboRutaSocio.TabIndex = 174
        Me.CboRutaSocio.Visible = False
        Me.CboRutaSocio.PropBag = resources.GetString("CboRutaSocio.PropBag")
        '
        'TabPreSocio
        '
        Me.TabPreSocio.Controls.Add(Me.GroupBox7)
        Me.TabPreSocio.Controls.Add(Me.GroupBox5)
        Me.TabPreSocio.Location = New System.Drawing.Point(4, 22)
        Me.TabPreSocio.Name = "TabPreSocio"
        Me.TabPreSocio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPreSocio.Size = New System.Drawing.Size(616, 317)
        Me.TabPreSocio.TabIndex = 3
        Me.TabPreSocio.Text = "Pre-Socio"
        Me.TabPreSocio.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button19)
        Me.GroupBox7.Controls.Add(Me.Button17)
        Me.GroupBox7.Controls.Add(Me.Button20)
        Me.GroupBox7.Controls.Add(Me.Button18)
        Me.GroupBox7.Controls.Add(Me.Button21)
        Me.GroupBox7.Controls.Add(Me.Button22)
        Me.GroupBox7.Controls.Add(Me.Button23)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.Button24)
        Me.GroupBox7.Controls.Add(Me.TxtCtaxPagarPreSocio)
        Me.GroupBox7.Controls.Add(Me.TxtFondosAdmonPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.TxtCtaOtrasPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label37)
        Me.GroupBox7.Controls.Add(Me.TxtCtasCobrarPreSocio)
        Me.GroupBox7.Controls.Add(Me.TxtCtaVeterinarioPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label43)
        Me.GroupBox7.Controls.Add(Me.TxtCtaTrazabilidadPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label46)
        Me.GroupBox7.Controls.Add(Me.TxtCtaInseminacionPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label47)
        Me.GroupBox7.Controls.Add(Me.TxtCtaTransportePreSocio)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.Button25)
        Me.GroupBox7.Controls.Add(Me.Button26)
        Me.GroupBox7.Controls.Add(Me.Button27)
        Me.GroupBox7.Controls.Add(Me.Button28)
        Me.GroupBox7.Controls.Add(Me.Button29)
        Me.GroupBox7.Controls.Add(Me.TxtCtaGastoPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Controls.Add(Me.TxtAnticipoPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label50)
        Me.GroupBox7.Controls.Add(Me.TxtCtaBolsaPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label51)
        Me.GroupBox7.Controls.Add(Me.TxtCtaIrPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label52)
        Me.GroupBox7.Controls.Add(Me.TxtCtaBancoPreSocio)
        Me.GroupBox7.Controls.Add(Me.Label53)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(596, 201)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        '
        'Button19
        '
        Me.Button19.Image = CType(resources.GetObject("Button19.Image"), System.Drawing.Image)
        Me.Button19.Location = New System.Drawing.Point(494, 135)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(35, 28)
        Me.Button19.TabIndex = 199
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Image = CType(resources.GetObject("Button17.Image"), System.Drawing.Image)
        Me.Button17.Location = New System.Drawing.Point(494, 164)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(35, 28)
        Me.Button17.TabIndex = 176
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Image = CType(resources.GetObject("Button20.Image"), System.Drawing.Image)
        Me.Button20.Location = New System.Drawing.Point(494, 110)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(35, 28)
        Me.Button20.TabIndex = 198
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(221, 146)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(35, 28)
        Me.Button18.TabIndex = 175
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Image = CType(resources.GetObject("Button21.Image"), System.Drawing.Image)
        Me.Button21.Location = New System.Drawing.Point(494, 85)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(35, 28)
        Me.Button21.TabIndex = 197
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Image = CType(resources.GetObject("Button22.Image"), System.Drawing.Image)
        Me.Button22.Location = New System.Drawing.Point(494, 61)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(35, 28)
        Me.Button22.TabIndex = 196
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Image = CType(resources.GetObject("Button23.Image"), System.Drawing.Image)
        Me.Button23.Location = New System.Drawing.Point(494, 36)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(35, 28)
        Me.Button23.TabIndex = 195
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(266, 167)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 173
        Me.Label22.Text = "Ctas x Pagar"
        '
        'Button24
        '
        Me.Button24.Image = CType(resources.GetObject("Button24.Image"), System.Drawing.Image)
        Me.Button24.Location = New System.Drawing.Point(494, 11)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(35, 28)
        Me.Button24.TabIndex = 194
        Me.Button24.UseVisualStyleBackColor = True
        '
        'TxtCtaxPagarPreSocio
        '
        Me.TxtCtaxPagarPreSocio.AcceptsReturn = True
        Me.TxtCtaxPagarPreSocio.Location = New System.Drawing.Point(388, 165)
        Me.TxtCtaxPagarPreSocio.Name = "TxtCtaxPagarPreSocio"
        Me.TxtCtaxPagarPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaxPagarPreSocio.TabIndex = 167
        '
        'TxtFondosAdmonPreSocio
        '
        Me.TxtFondosAdmonPreSocio.AcceptsReturn = True
        Me.TxtFondosAdmonPreSocio.Location = New System.Drawing.Point(388, 113)
        Me.TxtFondosAdmonPreSocio.Name = "TxtFondosAdmonPreSocio"
        Me.TxtFondosAdmonPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtFondosAdmonPreSocio.TabIndex = 192
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(264, 116)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 13)
        Me.Label33.TabIndex = 190
        Me.Label33.Text = "Administracion Fondos"
        '
        'TxtCtaOtrasPreSocio
        '
        Me.TxtCtaOtrasPreSocio.Location = New System.Drawing.Point(388, 138)
        Me.TxtCtaOtrasPreSocio.Name = "TxtCtaOtrasPreSocio"
        Me.TxtCtaOtrasPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaOtrasPreSocio.TabIndex = 193
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 151)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 13)
        Me.Label23.TabIndex = 172
        Me.Label23.Text = "Ctas x Cobrar"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(264, 143)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(98, 13)
        Me.Label37.TabIndex = 191
        Me.Label37.Text = "Otras Deducciones"
        '
        'TxtCtasCobrarPreSocio
        '
        Me.TxtCtasCobrarPreSocio.Location = New System.Drawing.Point(115, 148)
        Me.TxtCtasCobrarPreSocio.Name = "TxtCtasCobrarPreSocio"
        Me.TxtCtasCobrarPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtasCobrarPreSocio.TabIndex = 166
        '
        'TxtCtaVeterinarioPreSocio
        '
        Me.TxtCtaVeterinarioPreSocio.Location = New System.Drawing.Point(388, 90)
        Me.TxtCtaVeterinarioPreSocio.Name = "TxtCtaVeterinarioPreSocio"
        Me.TxtCtaVeterinarioPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaVeterinarioPreSocio.TabIndex = 189
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(266, 93)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(113, 13)
        Me.Label43.TabIndex = 188
        Me.Label43.Text = "Productos Veterinarios"
        '
        'TxtCtaTrazabilidadPreSocio
        '
        Me.TxtCtaTrazabilidadPreSocio.Location = New System.Drawing.Point(388, 66)
        Me.TxtCtaTrazabilidadPreSocio.Name = "TxtCtaTrazabilidadPreSocio"
        Me.TxtCtaTrazabilidadPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTrazabilidadPreSocio.TabIndex = 187
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(266, 69)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(64, 13)
        Me.Label46.TabIndex = 186
        Me.Label46.Text = "Trazabilidad"
        '
        'TxtCtaInseminacionPreSocio
        '
        Me.TxtCtaInseminacionPreSocio.Location = New System.Drawing.Point(388, 41)
        Me.TxtCtaInseminacionPreSocio.Name = "TxtCtaInseminacionPreSocio"
        Me.TxtCtaInseminacionPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaInseminacionPreSocio.TabIndex = 185
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(266, 46)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(69, 13)
        Me.Label47.TabIndex = 184
        Me.Label47.Text = "Inseminacion"
        '
        'TxtCtaTransportePreSocio
        '
        Me.TxtCtaTransportePreSocio.Location = New System.Drawing.Point(388, 16)
        Me.TxtCtaTransportePreSocio.Name = "TxtCtaTransportePreSocio"
        Me.TxtCtaTransportePreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTransportePreSocio.TabIndex = 183
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(264, 19)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(58, 13)
        Me.Label48.TabIndex = 182
        Me.Label48.Text = "Transporte"
        '
        'Button25
        '
        Me.Button25.Image = CType(resources.GetObject("Button25.Image"), System.Drawing.Image)
        Me.Button25.Location = New System.Drawing.Point(221, 118)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(35, 28)
        Me.Button25.TabIndex = 181
        Me.Button25.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.Image = CType(resources.GetObject("Button26.Image"), System.Drawing.Image)
        Me.Button26.Location = New System.Drawing.Point(221, 89)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(35, 28)
        Me.Button26.TabIndex = 180
        Me.Button26.UseVisualStyleBackColor = True
        '
        'Button27
        '
        Me.Button27.Image = CType(resources.GetObject("Button27.Image"), System.Drawing.Image)
        Me.Button27.Location = New System.Drawing.Point(221, 63)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(35, 28)
        Me.Button27.TabIndex = 179
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Button28
        '
        Me.Button28.Image = CType(resources.GetObject("Button28.Image"), System.Drawing.Image)
        Me.Button28.Location = New System.Drawing.Point(221, 37)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(35, 28)
        Me.Button28.TabIndex = 178
        Me.Button28.UseVisualStyleBackColor = True
        '
        'Button29
        '
        Me.Button29.Image = CType(resources.GetObject("Button29.Image"), System.Drawing.Image)
        Me.Button29.Location = New System.Drawing.Point(221, 11)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(35, 28)
        Me.Button29.TabIndex = 177
        Me.Button29.UseVisualStyleBackColor = True
        '
        'TxtCtaGastoPreSocio
        '
        Me.TxtCtaGastoPreSocio.Location = New System.Drawing.Point(115, 19)
        Me.TxtCtaGastoPreSocio.Name = "TxtCtaGastoPreSocio"
        Me.TxtCtaGastoPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaGastoPreSocio.TabIndex = 176
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(8, 26)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(71, 13)
        Me.Label49.TabIndex = 175
        Me.Label49.Text = "Gasto Planilla"
        '
        'TxtAnticipoPreSocio
        '
        Me.TxtAnticipoPreSocio.AcceptsReturn = True
        Me.TxtAnticipoPreSocio.Location = New System.Drawing.Point(115, 120)
        Me.TxtAnticipoPreSocio.Name = "TxtAnticipoPreSocio"
        Me.TxtAnticipoPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtAnticipoPreSocio.TabIndex = 173
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(8, 120)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 13)
        Me.Label50.TabIndex = 172
        Me.Label50.Text = "Anticipo de Planilla"
        '
        'TxtCtaBolsaPreSocio
        '
        Me.TxtCtaBolsaPreSocio.Location = New System.Drawing.Point(115, 94)
        Me.TxtCtaBolsaPreSocio.Name = "TxtCtaBolsaPreSocio"
        Me.TxtCtaBolsaPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBolsaPreSocio.TabIndex = 170
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(8, 94)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(86, 13)
        Me.Label51.TabIndex = 169
        Me.Label51.Text = "Bolsa de Valores"
        '
        'TxtCtaIrPreSocio
        '
        Me.TxtCtaIrPreSocio.Location = New System.Drawing.Point(115, 68)
        Me.TxtCtaIrPreSocio.Name = "TxtCtaIrPreSocio"
        Me.TxtCtaIrPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaIrPreSocio.TabIndex = 167
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(8, 71)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(55, 13)
        Me.Label52.TabIndex = 166
        Me.Label52.Text = "Cuenta IR"
        '
        'TxtCtaBancoPreSocio
        '
        Me.TxtCtaBancoPreSocio.Location = New System.Drawing.Point(115, 42)
        Me.TxtCtaBancoPreSocio.Name = "TxtCtaBancoPreSocio"
        Me.TxtCtaBancoPreSocio.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBancoPreSocio.TabIndex = 164
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(8, 45)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(75, 13)
        Me.Label53.TabIndex = 141
        Me.Label53.Text = "Cuenta Banco"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CboTransportistaPreSocio)
        Me.GroupBox5.Controls.Add(Me.Label99)
        Me.GroupBox5.Controls.Add(Me.TxtPrecioPreSocio)
        Me.GroupBox5.Controls.Add(Me.Label93)
        Me.GroupBox5.Controls.Add(Me.CboTipoNominaPreSocio)
        Me.GroupBox5.Controls.Add(Me.CboRutaPreSocio)
        Me.GroupBox5.Controls.Add(Me.CboCooperativaPreSocio)
        Me.GroupBox5.Controls.Add(Me.CboDepartamentosPreSocio)
        Me.GroupBox5.Controls.Add(Me.CboEscolaridadPreSocio)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(563, 110)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'CboTransportistaPreSocio
        '
        Me.CboTransportistaPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTransportistaPreSocio.Caption = ""
        Me.CboTransportistaPreSocio.CaptionHeight = 17
        Me.CboTransportistaPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTransportistaPreSocio.ColumnCaptionHeight = 17
        Me.CboTransportistaPreSocio.ColumnFooterHeight = 17
        Me.CboTransportistaPreSocio.ContentHeight = 15
        Me.CboTransportistaPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTransportistaPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTransportistaPreSocio.DropDownWidth = 300
        Me.CboTransportistaPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTransportistaPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTransportistaPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTransportistaPreSocio.EditorHeight = 15
        Me.CboTransportistaPreSocio.Images.Add(CType(resources.GetObject("CboTransportistaPreSocio.Images"), System.Drawing.Image))
        Me.CboTransportistaPreSocio.ItemHeight = 15
        Me.CboTransportistaPreSocio.Location = New System.Drawing.Point(340, 42)
        Me.CboTransportistaPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboTransportistaPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboTransportistaPreSocio.MaxLength = 32767
        Me.CboTransportistaPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTransportistaPreSocio.Name = "CboTransportistaPreSocio"
        Me.CboTransportistaPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTransportistaPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTransportistaPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTransportistaPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboTransportistaPreSocio.TabIndex = 183
        Me.CboTransportistaPreSocio.PropBag = resources.GetString("CboTransportistaPreSocio.PropBag")
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Location = New System.Drawing.Point(265, 47)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(68, 13)
        Me.Label99.TabIndex = 184
        Me.Label99.Text = "Transportista"
        '
        'TxtPrecioPreSocio
        '
        Me.TxtPrecioPreSocio.Location = New System.Drawing.Point(340, 69)
        Me.TxtPrecioPreSocio.Name = "TxtPrecioPreSocio"
        Me.TxtPrecioPreSocio.Size = New System.Drawing.Size(79, 20)
        Me.TxtPrecioPreSocio.TabIndex = 182
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(265, 72)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(73, 13)
        Me.Label93.TabIndex = 181
        Me.Label93.Text = "Precio Leche:"
        '
        'CboTipoNominaPreSocio
        '
        Me.CboTipoNominaPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoNominaPreSocio.Caption = ""
        Me.CboTipoNominaPreSocio.CaptionHeight = 17
        Me.CboTipoNominaPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoNominaPreSocio.ColumnCaptionHeight = 17
        Me.CboTipoNominaPreSocio.ColumnFooterHeight = 17
        Me.CboTipoNominaPreSocio.ContentHeight = 15
        Me.CboTipoNominaPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoNominaPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTipoNominaPreSocio.DropDownWidth = 300
        Me.CboTipoNominaPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoNominaPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoNominaPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoNominaPreSocio.EditorHeight = 15
        Me.CboTipoNominaPreSocio.Images.Add(CType(resources.GetObject("CboTipoNominaPreSocio.Images"), System.Drawing.Image))
        Me.CboTipoNominaPreSocio.ItemHeight = 15
        Me.CboTipoNominaPreSocio.Location = New System.Drawing.Point(340, 14)
        Me.CboTipoNominaPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoNominaPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboTipoNominaPreSocio.MaxLength = 32767
        Me.CboTipoNominaPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoNominaPreSocio.Name = "CboTipoNominaPreSocio"
        Me.CboTipoNominaPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoNominaPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoNominaPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoNominaPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoNominaPreSocio.TabIndex = 179
        Me.CboTipoNominaPreSocio.PropBag = resources.GetString("CboTipoNominaPreSocio.PropBag")
        '
        'CboRutaPreSocio
        '
        Me.CboRutaPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboRutaPreSocio.Caption = ""
        Me.CboRutaPreSocio.CaptionHeight = 17
        Me.CboRutaPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboRutaPreSocio.ColumnCaptionHeight = 17
        Me.CboRutaPreSocio.ColumnFooterHeight = 17
        Me.CboRutaPreSocio.ContentHeight = 15
        Me.CboRutaPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboRutaPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboRutaPreSocio.DropDownWidth = 300
        Me.CboRutaPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboRutaPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRutaPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboRutaPreSocio.EditorHeight = 15
        Me.CboRutaPreSocio.Images.Add(CType(resources.GetObject("CboRutaPreSocio.Images"), System.Drawing.Image))
        Me.CboRutaPreSocio.ItemHeight = 15
        Me.CboRutaPreSocio.Location = New System.Drawing.Point(-3, 97)
        Me.CboRutaPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboRutaPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboRutaPreSocio.MaxLength = 32767
        Me.CboRutaPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboRutaPreSocio.Name = "CboRutaPreSocio"
        Me.CboRutaPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboRutaPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboRutaPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboRutaPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboRutaPreSocio.TabIndex = 174
        Me.CboRutaPreSocio.Visible = False
        Me.CboRutaPreSocio.PropBag = resources.GetString("CboRutaPreSocio.PropBag")
        '
        'CboCooperativaPreSocio
        '
        Me.CboCooperativaPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCooperativaPreSocio.Caption = ""
        Me.CboCooperativaPreSocio.CaptionHeight = 17
        Me.CboCooperativaPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCooperativaPreSocio.ColumnCaptionHeight = 17
        Me.CboCooperativaPreSocio.ColumnFooterHeight = 17
        Me.CboCooperativaPreSocio.ContentHeight = 15
        Me.CboCooperativaPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCooperativaPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCooperativaPreSocio.DropDownWidth = 300
        Me.CboCooperativaPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCooperativaPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCooperativaPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCooperativaPreSocio.EditorHeight = 15
        Me.CboCooperativaPreSocio.Images.Add(CType(resources.GetObject("CboCooperativaPreSocio.Images"), System.Drawing.Image))
        Me.CboCooperativaPreSocio.ItemHeight = 15
        Me.CboCooperativaPreSocio.Location = New System.Drawing.Point(101, 71)
        Me.CboCooperativaPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboCooperativaPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboCooperativaPreSocio.MaxLength = 32767
        Me.CboCooperativaPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCooperativaPreSocio.Name = "CboCooperativaPreSocio"
        Me.CboCooperativaPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCooperativaPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCooperativaPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCooperativaPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboCooperativaPreSocio.TabIndex = 165
        Me.CboCooperativaPreSocio.PropBag = resources.GetString("CboCooperativaPreSocio.PropBag")
        '
        'CboDepartamentosPreSocio
        '
        Me.CboDepartamentosPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamentosPreSocio.Caption = ""
        Me.CboDepartamentosPreSocio.CaptionHeight = 17
        Me.CboDepartamentosPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamentosPreSocio.ColumnCaptionHeight = 17
        Me.CboDepartamentosPreSocio.ColumnFooterHeight = 17
        Me.CboDepartamentosPreSocio.ContentHeight = 15
        Me.CboDepartamentosPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamentosPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDepartamentosPreSocio.DropDownWidth = 300
        Me.CboDepartamentosPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamentosPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamentosPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamentosPreSocio.EditorHeight = 15
        Me.CboDepartamentosPreSocio.Images.Add(CType(resources.GetObject("CboDepartamentosPreSocio.Images"), System.Drawing.Image))
        Me.CboDepartamentosPreSocio.ItemHeight = 15
        Me.CboDepartamentosPreSocio.Location = New System.Drawing.Point(101, 44)
        Me.CboDepartamentosPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamentosPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamentosPreSocio.MaxLength = 32767
        Me.CboDepartamentosPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamentosPreSocio.Name = "CboDepartamentosPreSocio"
        Me.CboDepartamentosPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamentosPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamentosPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamentosPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboDepartamentosPreSocio.TabIndex = 164
        Me.CboDepartamentosPreSocio.PropBag = resources.GetString("CboDepartamentosPreSocio.PropBag")
        '
        'CboEscolaridadPreSocio
        '
        Me.CboEscolaridadPreSocio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEscolaridadPreSocio.Caption = ""
        Me.CboEscolaridadPreSocio.CaptionHeight = 17
        Me.CboEscolaridadPreSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEscolaridadPreSocio.ColumnCaptionHeight = 17
        Me.CboEscolaridadPreSocio.ColumnFooterHeight = 17
        Me.CboEscolaridadPreSocio.ContentHeight = 15
        Me.CboEscolaridadPreSocio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEscolaridadPreSocio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEscolaridadPreSocio.DropDownWidth = 300
        Me.CboEscolaridadPreSocio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEscolaridadPreSocio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEscolaridadPreSocio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEscolaridadPreSocio.EditorHeight = 15
        Me.CboEscolaridadPreSocio.Images.Add(CType(resources.GetObject("CboEscolaridadPreSocio.Images"), System.Drawing.Image))
        Me.CboEscolaridadPreSocio.ItemHeight = 15
        Me.CboEscolaridadPreSocio.Location = New System.Drawing.Point(101, 16)
        Me.CboEscolaridadPreSocio.MatchEntryTimeout = CType(2000, Long)
        Me.CboEscolaridadPreSocio.MaxDropDownItems = CType(5, Short)
        Me.CboEscolaridadPreSocio.MaxLength = 32767
        Me.CboEscolaridadPreSocio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEscolaridadPreSocio.Name = "CboEscolaridadPreSocio"
        Me.CboEscolaridadPreSocio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEscolaridadPreSocio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEscolaridadPreSocio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEscolaridadPreSocio.Size = New System.Drawing.Size(135, 21)
        Me.CboEscolaridadPreSocio.TabIndex = 163
        Me.CboEscolaridadPreSocio.PropBag = resources.GetString("CboEscolaridadPreSocio.PropBag")
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(267, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 13)
        Me.Label24.TabIndex = 171
        Me.Label24.Text = "Ruta"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 76)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 170
        Me.Label25.Text = "Cooperativa"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 49)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 169
        Me.Label30.Text = "Departamentos"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 168
        Me.Label32.Text = "Escolaridad"
        '
        'TabProductor
        '
        Me.TabProductor.Controls.Add(Me.GroupBox9)
        Me.TabProductor.Controls.Add(Me.GroupBox8)
        Me.TabProductor.Location = New System.Drawing.Point(4, 22)
        Me.TabProductor.Name = "TabProductor"
        Me.TabProductor.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProductor.Size = New System.Drawing.Size(616, 317)
        Me.TabProductor.TabIndex = 5
        Me.TabProductor.Text = "Productor"
        Me.TabProductor.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Button32)
        Me.GroupBox9.Controls.Add(Me.Button30)
        Me.GroupBox9.Controls.Add(Me.Button33)
        Me.GroupBox9.Controls.Add(Me.Button31)
        Me.GroupBox9.Controls.Add(Me.Button34)
        Me.GroupBox9.Controls.Add(Me.Button35)
        Me.GroupBox9.Controls.Add(Me.Button36)
        Me.GroupBox9.Controls.Add(Me.Label54)
        Me.GroupBox9.Controls.Add(Me.Button37)
        Me.GroupBox9.Controls.Add(Me.TxtCtaxPagarProductor)
        Me.GroupBox9.Controls.Add(Me.TxtFondosAdmonProductor)
        Me.GroupBox9.Controls.Add(Me.Label60)
        Me.GroupBox9.Controls.Add(Me.TxtCtaOtrasProductor)
        Me.GroupBox9.Controls.Add(Me.Label55)
        Me.GroupBox9.Controls.Add(Me.Label61)
        Me.GroupBox9.Controls.Add(Me.TxtCtasCobrarProductor)
        Me.GroupBox9.Controls.Add(Me.TxtCtaVeterinarioProductor)
        Me.GroupBox9.Controls.Add(Me.Label62)
        Me.GroupBox9.Controls.Add(Me.TxtCtaTrazabilidadProductor)
        Me.GroupBox9.Controls.Add(Me.Label63)
        Me.GroupBox9.Controls.Add(Me.TxtCtaInseminacionProductor)
        Me.GroupBox9.Controls.Add(Me.Label64)
        Me.GroupBox9.Controls.Add(Me.TxtCtaTransporteProductor)
        Me.GroupBox9.Controls.Add(Me.Label65)
        Me.GroupBox9.Controls.Add(Me.Button38)
        Me.GroupBox9.Controls.Add(Me.Button39)
        Me.GroupBox9.Controls.Add(Me.Button40)
        Me.GroupBox9.Controls.Add(Me.Button41)
        Me.GroupBox9.Controls.Add(Me.Button42)
        Me.GroupBox9.Controls.Add(Me.TxtCtaGastoProductor)
        Me.GroupBox9.Controls.Add(Me.Label66)
        Me.GroupBox9.Controls.Add(Me.TxtAnticipoProductor)
        Me.GroupBox9.Controls.Add(Me.Label67)
        Me.GroupBox9.Controls.Add(Me.TxtCtaBolsaProductor)
        Me.GroupBox9.Controls.Add(Me.Label68)
        Me.GroupBox9.Controls.Add(Me.TxtCtaIrProductor)
        Me.GroupBox9.Controls.Add(Me.Label69)
        Me.GroupBox9.Controls.Add(Me.TxtCtaBancoProductor)
        Me.GroupBox9.Controls.Add(Me.Label70)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 108)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(596, 201)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        '
        'Button32
        '
        Me.Button32.Image = CType(resources.GetObject("Button32.Image"), System.Drawing.Image)
        Me.Button32.Location = New System.Drawing.Point(494, 142)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(35, 28)
        Me.Button32.TabIndex = 199
        Me.Button32.UseVisualStyleBackColor = True
        '
        'Button30
        '
        Me.Button30.Image = CType(resources.GetObject("Button30.Image"), System.Drawing.Image)
        Me.Button30.Location = New System.Drawing.Point(494, 170)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(35, 28)
        Me.Button30.TabIndex = 176
        Me.Button30.UseVisualStyleBackColor = True
        '
        'Button33
        '
        Me.Button33.Image = CType(resources.GetObject("Button33.Image"), System.Drawing.Image)
        Me.Button33.Location = New System.Drawing.Point(494, 113)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(35, 28)
        Me.Button33.TabIndex = 198
        Me.Button33.UseVisualStyleBackColor = True
        '
        'Button31
        '
        Me.Button31.Image = CType(resources.GetObject("Button31.Image"), System.Drawing.Image)
        Me.Button31.Location = New System.Drawing.Point(222, 139)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(35, 28)
        Me.Button31.TabIndex = 175
        Me.Button31.UseVisualStyleBackColor = True
        '
        'Button34
        '
        Me.Button34.Image = CType(resources.GetObject("Button34.Image"), System.Drawing.Image)
        Me.Button34.Location = New System.Drawing.Point(494, 86)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(35, 28)
        Me.Button34.TabIndex = 197
        Me.Button34.UseVisualStyleBackColor = True
        '
        'Button35
        '
        Me.Button35.Image = CType(resources.GetObject("Button35.Image"), System.Drawing.Image)
        Me.Button35.Location = New System.Drawing.Point(494, 60)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(35, 28)
        Me.Button35.TabIndex = 196
        Me.Button35.UseVisualStyleBackColor = True
        '
        'Button36
        '
        Me.Button36.Image = CType(resources.GetObject("Button36.Image"), System.Drawing.Image)
        Me.Button36.Location = New System.Drawing.Point(494, 36)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(35, 28)
        Me.Button36.TabIndex = 195
        Me.Button36.UseVisualStyleBackColor = True
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(264, 170)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(67, 13)
        Me.Label54.TabIndex = 173
        Me.Label54.Text = "Ctas x Pagar"
        '
        'Button37
        '
        Me.Button37.Image = CType(resources.GetObject("Button37.Image"), System.Drawing.Image)
        Me.Button37.Location = New System.Drawing.Point(494, 11)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(35, 28)
        Me.Button37.TabIndex = 194
        Me.Button37.UseVisualStyleBackColor = True
        '
        'TxtCtaxPagarProductor
        '
        Me.TxtCtaxPagarProductor.AcceptsReturn = True
        Me.TxtCtaxPagarProductor.Location = New System.Drawing.Point(388, 169)
        Me.TxtCtaxPagarProductor.Name = "TxtCtaxPagarProductor"
        Me.TxtCtaxPagarProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaxPagarProductor.TabIndex = 167
        '
        'TxtFondosAdmonProductor
        '
        Me.TxtFondosAdmonProductor.AcceptsReturn = True
        Me.TxtFondosAdmonProductor.Location = New System.Drawing.Point(388, 118)
        Me.TxtFondosAdmonProductor.Name = "TxtFondosAdmonProductor"
        Me.TxtFondosAdmonProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtFondosAdmonProductor.TabIndex = 192
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(264, 121)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(113, 13)
        Me.Label60.TabIndex = 190
        Me.Label60.Text = "Administracion Fondos"
        '
        'TxtCtaOtrasProductor
        '
        Me.TxtCtaOtrasProductor.Location = New System.Drawing.Point(388, 144)
        Me.TxtCtaOtrasProductor.Name = "TxtCtaOtrasProductor"
        Me.TxtCtaOtrasProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaOtrasProductor.TabIndex = 193
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(8, 146)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(70, 13)
        Me.Label55.TabIndex = 172
        Me.Label55.Text = "Ctas x Cobrar"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(264, 145)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(98, 13)
        Me.Label61.TabIndex = 191
        Me.Label61.Text = "Otras Deducciones"
        '
        'TxtCtasCobrarProductor
        '
        Me.TxtCtasCobrarProductor.Location = New System.Drawing.Point(115, 143)
        Me.TxtCtasCobrarProductor.Name = "TxtCtasCobrarProductor"
        Me.TxtCtasCobrarProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtasCobrarProductor.TabIndex = 166
        '
        'TxtCtaVeterinarioProductor
        '
        Me.TxtCtaVeterinarioProductor.Location = New System.Drawing.Point(388, 94)
        Me.TxtCtaVeterinarioProductor.Name = "TxtCtaVeterinarioProductor"
        Me.TxtCtaVeterinarioProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaVeterinarioProductor.TabIndex = 189
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(266, 95)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(113, 13)
        Me.Label62.TabIndex = 188
        Me.Label62.Text = "Productos Veterinarios"
        '
        'TxtCtaTrazabilidadProductor
        '
        Me.TxtCtaTrazabilidadProductor.Location = New System.Drawing.Point(388, 69)
        Me.TxtCtaTrazabilidadProductor.Name = "TxtCtaTrazabilidadProductor"
        Me.TxtCtaTrazabilidadProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTrazabilidadProductor.TabIndex = 187
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(266, 71)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(64, 13)
        Me.Label63.TabIndex = 186
        Me.Label63.Text = "Trazabilidad"
        '
        'TxtCtaInseminacionProductor
        '
        Me.TxtCtaInseminacionProductor.Location = New System.Drawing.Point(388, 43)
        Me.TxtCtaInseminacionProductor.Name = "TxtCtaInseminacionProductor"
        Me.TxtCtaInseminacionProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaInseminacionProductor.TabIndex = 185
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(266, 46)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(69, 13)
        Me.Label64.TabIndex = 184
        Me.Label64.Text = "Inseminacion"
        '
        'TxtCtaTransporteProductor
        '
        Me.TxtCtaTransporteProductor.Location = New System.Drawing.Point(388, 16)
        Me.TxtCtaTransporteProductor.Name = "TxtCtaTransporteProductor"
        Me.TxtCtaTransporteProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTransporteProductor.TabIndex = 183
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(264, 19)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(58, 13)
        Me.Label65.TabIndex = 182
        Me.Label65.Text = "Transporte"
        '
        'Button38
        '
        Me.Button38.Image = CType(resources.GetObject("Button38.Image"), System.Drawing.Image)
        Me.Button38.Location = New System.Drawing.Point(221, 112)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(35, 28)
        Me.Button38.TabIndex = 181
        Me.Button38.UseVisualStyleBackColor = True
        '
        'Button39
        '
        Me.Button39.Image = CType(resources.GetObject("Button39.Image"), System.Drawing.Image)
        Me.Button39.Location = New System.Drawing.Point(221, 85)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(35, 28)
        Me.Button39.TabIndex = 180
        Me.Button39.UseVisualStyleBackColor = True
        '
        'Button40
        '
        Me.Button40.Image = CType(resources.GetObject("Button40.Image"), System.Drawing.Image)
        Me.Button40.Location = New System.Drawing.Point(221, 61)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(35, 28)
        Me.Button40.TabIndex = 179
        Me.Button40.UseVisualStyleBackColor = True
        '
        'Button41
        '
        Me.Button41.Image = CType(resources.GetObject("Button41.Image"), System.Drawing.Image)
        Me.Button41.Location = New System.Drawing.Point(221, 38)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(35, 28)
        Me.Button41.TabIndex = 178
        Me.Button41.UseVisualStyleBackColor = True
        '
        'Button42
        '
        Me.Button42.Image = CType(resources.GetObject("Button42.Image"), System.Drawing.Image)
        Me.Button42.Location = New System.Drawing.Point(221, 11)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(35, 28)
        Me.Button42.TabIndex = 177
        Me.Button42.UseVisualStyleBackColor = True
        '
        'TxtCtaGastoProductor
        '
        Me.TxtCtaGastoProductor.Location = New System.Drawing.Point(115, 19)
        Me.TxtCtaGastoProductor.Name = "TxtCtaGastoProductor"
        Me.TxtCtaGastoProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaGastoProductor.TabIndex = 176
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(8, 26)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(71, 13)
        Me.Label66.TabIndex = 175
        Me.Label66.Text = "Gasto Planilla"
        '
        'TxtAnticipoProductor
        '
        Me.TxtAnticipoProductor.AcceptsReturn = True
        Me.TxtAnticipoProductor.Location = New System.Drawing.Point(115, 117)
        Me.TxtAnticipoProductor.Name = "TxtAnticipoProductor"
        Me.TxtAnticipoProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtAnticipoProductor.TabIndex = 173
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(8, 118)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(96, 13)
        Me.Label67.TabIndex = 172
        Me.Label67.Text = "Anticipo de Planilla"
        '
        'TxtCtaBolsaProductor
        '
        Me.TxtCtaBolsaProductor.Location = New System.Drawing.Point(115, 90)
        Me.TxtCtaBolsaProductor.Name = "TxtCtaBolsaProductor"
        Me.TxtCtaBolsaProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBolsaProductor.TabIndex = 170
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(8, 90)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(86, 13)
        Me.Label68.TabIndex = 169
        Me.Label68.Text = "Bolsa de Valores"
        '
        'TxtCtaIrProductor
        '
        Me.TxtCtaIrProductor.Location = New System.Drawing.Point(115, 66)
        Me.TxtCtaIrProductor.Name = "TxtCtaIrProductor"
        Me.TxtCtaIrProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaIrProductor.TabIndex = 167
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(8, 69)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(55, 13)
        Me.Label69.TabIndex = 166
        Me.Label69.Text = "Cuenta IR"
        '
        'TxtCtaBancoProductor
        '
        Me.TxtCtaBancoProductor.Location = New System.Drawing.Point(115, 42)
        Me.TxtCtaBancoProductor.Name = "TxtCtaBancoProductor"
        Me.TxtCtaBancoProductor.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBancoProductor.TabIndex = 164
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(8, 48)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(75, 13)
        Me.Label70.TabIndex = 141
        Me.Label70.Text = "Cuenta Banco"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.CboTransportistaProductor)
        Me.GroupBox8.Controls.Add(Me.Label100)
        Me.GroupBox8.Controls.Add(Me.TxtPrecioProductor)
        Me.GroupBox8.Controls.Add(Me.Label94)
        Me.GroupBox8.Controls.Add(Me.CboTipoNominaProductor)
        Me.GroupBox8.Controls.Add(Me.CboRutaProductor)
        Me.GroupBox8.Controls.Add(Me.CboCooperativaProductor)
        Me.GroupBox8.Controls.Add(Me.CboDepartamentosProductor)
        Me.GroupBox8.Controls.Add(Me.CboEscolaridadProductor)
        Me.GroupBox8.Controls.Add(Me.Label56)
        Me.GroupBox8.Controls.Add(Me.Label57)
        Me.GroupBox8.Controls.Add(Me.Label58)
        Me.GroupBox8.Controls.Add(Me.Label59)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(596, 103)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        '
        'CboTransportistaProductor
        '
        Me.CboTransportistaProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTransportistaProductor.Caption = ""
        Me.CboTransportistaProductor.CaptionHeight = 17
        Me.CboTransportistaProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTransportistaProductor.ColumnCaptionHeight = 17
        Me.CboTransportistaProductor.ColumnFooterHeight = 17
        Me.CboTransportistaProductor.ContentHeight = 15
        Me.CboTransportistaProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTransportistaProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTransportistaProductor.DropDownWidth = 300
        Me.CboTransportistaProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTransportistaProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTransportistaProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTransportistaProductor.EditorHeight = 15
        Me.CboTransportistaProductor.Images.Add(CType(resources.GetObject("CboTransportistaProductor.Images"), System.Drawing.Image))
        Me.CboTransportistaProductor.ItemHeight = 15
        Me.CboTransportistaProductor.Location = New System.Drawing.Point(340, 42)
        Me.CboTransportistaProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboTransportistaProductor.MaxDropDownItems = CType(5, Short)
        Me.CboTransportistaProductor.MaxLength = 32767
        Me.CboTransportistaProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTransportistaProductor.Name = "CboTransportistaProductor"
        Me.CboTransportistaProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTransportistaProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTransportistaProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTransportistaProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboTransportistaProductor.TabIndex = 185
        Me.CboTransportistaProductor.PropBag = resources.GetString("CboTransportistaProductor.PropBag")
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(265, 47)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(68, 13)
        Me.Label100.TabIndex = 186
        Me.Label100.Text = "Transportista"
        '
        'TxtPrecioProductor
        '
        Me.TxtPrecioProductor.Location = New System.Drawing.Point(340, 69)
        Me.TxtPrecioProductor.Name = "TxtPrecioProductor"
        Me.TxtPrecioProductor.Size = New System.Drawing.Size(79, 20)
        Me.TxtPrecioProductor.TabIndex = 184
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(265, 75)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(73, 13)
        Me.Label94.TabIndex = 183
        Me.Label94.Text = "Precio Leche:"
        '
        'CboTipoNominaProductor
        '
        Me.CboTipoNominaProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoNominaProductor.Caption = ""
        Me.CboTipoNominaProductor.CaptionHeight = 17
        Me.CboTipoNominaProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoNominaProductor.ColumnCaptionHeight = 17
        Me.CboTipoNominaProductor.ColumnFooterHeight = 17
        Me.CboTipoNominaProductor.ContentHeight = 15
        Me.CboTipoNominaProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoNominaProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTipoNominaProductor.DropDownWidth = 300
        Me.CboTipoNominaProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoNominaProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoNominaProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoNominaProductor.EditorHeight = 15
        Me.CboTipoNominaProductor.Images.Add(CType(resources.GetObject("CboTipoNominaProductor.Images"), System.Drawing.Image))
        Me.CboTipoNominaProductor.ItemHeight = 15
        Me.CboTipoNominaProductor.Location = New System.Drawing.Point(340, 14)
        Me.CboTipoNominaProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoNominaProductor.MaxDropDownItems = CType(5, Short)
        Me.CboTipoNominaProductor.MaxLength = 32767
        Me.CboTipoNominaProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoNominaProductor.Name = "CboTipoNominaProductor"
        Me.CboTipoNominaProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoNominaProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoNominaProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoNominaProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoNominaProductor.TabIndex = 179
        Me.CboTipoNominaProductor.PropBag = resources.GetString("CboTipoNominaProductor.PropBag")
        '
        'CboRutaProductor
        '
        Me.CboRutaProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboRutaProductor.Caption = ""
        Me.CboRutaProductor.CaptionHeight = 17
        Me.CboRutaProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboRutaProductor.ColumnCaptionHeight = 17
        Me.CboRutaProductor.ColumnFooterHeight = 17
        Me.CboRutaProductor.ContentHeight = 15
        Me.CboRutaProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboRutaProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboRutaProductor.DropDownWidth = 300
        Me.CboRutaProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboRutaProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRutaProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboRutaProductor.EditorHeight = 15
        Me.CboRutaProductor.Images.Add(CType(resources.GetObject("CboRutaProductor.Images"), System.Drawing.Image))
        Me.CboRutaProductor.ItemHeight = 15
        Me.CboRutaProductor.Location = New System.Drawing.Point(101, 71)
        Me.CboRutaProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboRutaProductor.MaxDropDownItems = CType(5, Short)
        Me.CboRutaProductor.MaxLength = 32767
        Me.CboRutaProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboRutaProductor.Name = "CboRutaProductor"
        Me.CboRutaProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboRutaProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboRutaProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboRutaProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboRutaProductor.TabIndex = 174
        Me.CboRutaProductor.Visible = False
        Me.CboRutaProductor.PropBag = resources.GetString("CboRutaProductor.PropBag")
        '
        'CboCooperativaProductor
        '
        Me.CboCooperativaProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCooperativaProductor.Caption = ""
        Me.CboCooperativaProductor.CaptionHeight = 17
        Me.CboCooperativaProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCooperativaProductor.ColumnCaptionHeight = 17
        Me.CboCooperativaProductor.ColumnFooterHeight = 17
        Me.CboCooperativaProductor.ContentHeight = 15
        Me.CboCooperativaProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCooperativaProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCooperativaProductor.DropDownWidth = 300
        Me.CboCooperativaProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCooperativaProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCooperativaProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCooperativaProductor.EditorHeight = 15
        Me.CboCooperativaProductor.Images.Add(CType(resources.GetObject("CboCooperativaProductor.Images"), System.Drawing.Image))
        Me.CboCooperativaProductor.ItemHeight = 15
        Me.CboCooperativaProductor.Location = New System.Drawing.Point(101, 71)
        Me.CboCooperativaProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCooperativaProductor.MaxDropDownItems = CType(5, Short)
        Me.CboCooperativaProductor.MaxLength = 32767
        Me.CboCooperativaProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCooperativaProductor.Name = "CboCooperativaProductor"
        Me.CboCooperativaProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCooperativaProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCooperativaProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCooperativaProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboCooperativaProductor.TabIndex = 165
        Me.CboCooperativaProductor.PropBag = resources.GetString("CboCooperativaProductor.PropBag")
        '
        'CboDepartamentosProductor
        '
        Me.CboDepartamentosProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamentosProductor.Caption = ""
        Me.CboDepartamentosProductor.CaptionHeight = 17
        Me.CboDepartamentosProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamentosProductor.ColumnCaptionHeight = 17
        Me.CboDepartamentosProductor.ColumnFooterHeight = 17
        Me.CboDepartamentosProductor.ContentHeight = 15
        Me.CboDepartamentosProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamentosProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDepartamentosProductor.DropDownWidth = 300
        Me.CboDepartamentosProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamentosProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamentosProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamentosProductor.EditorHeight = 15
        Me.CboDepartamentosProductor.Images.Add(CType(resources.GetObject("CboDepartamentosProductor.Images"), System.Drawing.Image))
        Me.CboDepartamentosProductor.ItemHeight = 15
        Me.CboDepartamentosProductor.Location = New System.Drawing.Point(101, 44)
        Me.CboDepartamentosProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamentosProductor.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamentosProductor.MaxLength = 32767
        Me.CboDepartamentosProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamentosProductor.Name = "CboDepartamentosProductor"
        Me.CboDepartamentosProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamentosProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamentosProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamentosProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboDepartamentosProductor.TabIndex = 164
        Me.CboDepartamentosProductor.PropBag = resources.GetString("CboDepartamentosProductor.PropBag")
        '
        'CboEscolaridadProductor
        '
        Me.CboEscolaridadProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEscolaridadProductor.Caption = ""
        Me.CboEscolaridadProductor.CaptionHeight = 17
        Me.CboEscolaridadProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEscolaridadProductor.ColumnCaptionHeight = 17
        Me.CboEscolaridadProductor.ColumnFooterHeight = 17
        Me.CboEscolaridadProductor.ContentHeight = 15
        Me.CboEscolaridadProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEscolaridadProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEscolaridadProductor.DropDownWidth = 300
        Me.CboEscolaridadProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEscolaridadProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEscolaridadProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEscolaridadProductor.EditorHeight = 15
        Me.CboEscolaridadProductor.Images.Add(CType(resources.GetObject("CboEscolaridadProductor.Images"), System.Drawing.Image))
        Me.CboEscolaridadProductor.ItemHeight = 15
        Me.CboEscolaridadProductor.Location = New System.Drawing.Point(101, 16)
        Me.CboEscolaridadProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboEscolaridadProductor.MaxDropDownItems = CType(5, Short)
        Me.CboEscolaridadProductor.MaxLength = 32767
        Me.CboEscolaridadProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEscolaridadProductor.Name = "CboEscolaridadProductor"
        Me.CboEscolaridadProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEscolaridadProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEscolaridadProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEscolaridadProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboEscolaridadProductor.TabIndex = 163
        Me.CboEscolaridadProductor.PropBag = resources.GetString("CboEscolaridadProductor.PropBag")
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(267, 14)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(30, 13)
        Me.Label56.TabIndex = 171
        Me.Label56.Text = "Ruta"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(6, 76)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(64, 13)
        Me.Label57.TabIndex = 170
        Me.Label57.Text = "Cooperativa"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(6, 49)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(79, 13)
        Me.Label58.TabIndex = 169
        Me.Label58.Text = "Departamentos"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(6, 22)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(62, 13)
        Me.Label59.TabIndex = 168
        Me.Label59.Text = "Escolaridad"
        '
        'TabTransportista
        '
        Me.TabTransportista.Controls.Add(Me.TextBox3)
        Me.TabTransportista.Controls.Add(Me.Label97)
        Me.TabTransportista.Controls.Add(Me.GroupBox14)
        Me.TabTransportista.Controls.Add(Me.GroupBox12)
        Me.TabTransportista.Location = New System.Drawing.Point(4, 22)
        Me.TabTransportista.Name = "TabTransportista"
        Me.TabTransportista.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTransportista.Size = New System.Drawing.Size(616, 317)
        Me.TabTransportista.TabIndex = 4
        Me.TabTransportista.Text = "Transportista"
        Me.TabTransportista.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(536, 107)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(66, 20)
        Me.TextBox3.TabIndex = 198
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(479, 110)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(40, 13)
        Me.Label97.TabIndex = 197
        Me.Label97.Text = "Precio:"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.TextBox2)
        Me.GroupBox14.Controls.Add(Me.Label96)
        Me.GroupBox14.Controls.Add(Me.TextBox1)
        Me.GroupBox14.Controls.Add(Me.Label95)
        Me.GroupBox14.Location = New System.Drawing.Point(473, 12)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(138, 84)
        Me.GroupBox14.TabIndex = 196
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Deducciones"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(63, 46)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(66, 20)
        Me.TextBox2.TabIndex = 183
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(6, 53)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(33, 13)
        Me.Label96.TabIndex = 182
        Me.Label96.Text = "IMI %"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(63, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 181
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(6, 26)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(29, 13)
        Me.Label95.TabIndex = 180
        Me.Label95.Text = "IR %"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Button44)
        Me.GroupBox12.Controls.Add(Me.TxtCtaFondos)
        Me.GroupBox12.Controls.Add(Me.Button45)
        Me.GroupBox12.Controls.Add(Me.Label80)
        Me.GroupBox12.Controls.Add(Me.TxtCtaOtras)
        Me.GroupBox12.Controls.Add(Me.Label81)
        Me.GroupBox12.Controls.Add(Me.Button46)
        Me.GroupBox12.Controls.Add(Me.TxtCtaVeterinario)
        Me.GroupBox12.Controls.Add(Me.Label82)
        Me.GroupBox12.Controls.Add(Me.Button47)
        Me.GroupBox12.Controls.Add(Me.TxtCtaTrazabilidad)
        Me.GroupBox12.Controls.Add(Me.Label83)
        Me.GroupBox12.Controls.Add(Me.Button48)
        Me.GroupBox12.Controls.Add(Me.TxtCtaInseminacion)
        Me.GroupBox12.Controls.Add(Me.Label84)
        Me.GroupBox12.Controls.Add(Me.Button49)
        Me.GroupBox12.Controls.Add(Me.TxtCtaTransporte)
        Me.GroupBox12.Controls.Add(Me.Label85)
        Me.GroupBox12.Controls.Add(Me.Button50)
        Me.GroupBox12.Controls.Add(Me.TxtCtaGastoPlanilla)
        Me.GroupBox12.Controls.Add(Me.Label86)
        Me.GroupBox12.Controls.Add(Me.Button51)
        Me.GroupBox12.Controls.Add(Me.TxtAnticipo)
        Me.GroupBox12.Controls.Add(Me.Label87)
        Me.GroupBox12.Controls.Add(Me.Button52)
        Me.GroupBox12.Controls.Add(Me.TxtCtaBolsa)
        Me.GroupBox12.Controls.Add(Me.Label88)
        Me.GroupBox12.Controls.Add(Me.Button53)
        Me.GroupBox12.Controls.Add(Me.TxtCtaIr)
        Me.GroupBox12.Controls.Add(Me.Label89)
        Me.GroupBox12.Controls.Add(Me.Button54)
        Me.GroupBox12.Controls.Add(Me.TxtCtaBanco)
        Me.GroupBox12.Controls.Add(Me.Label90)
        Me.GroupBox12.Location = New System.Drawing.Point(3, 11)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(468, 293)
        Me.GroupBox12.TabIndex = 3
        Me.GroupBox12.TabStop = False
        '
        'Button44
        '
        Me.Button44.Image = CType(resources.GetObject("Button44.Image"), System.Drawing.Image)
        Me.Button44.Location = New System.Drawing.Point(225, 250)
        Me.Button44.Name = "Button44"
        Me.Button44.Size = New System.Drawing.Size(29, 30)
        Me.Button44.TabIndex = 194
        Me.Button44.UseVisualStyleBackColor = True
        Me.Button44.Visible = False
        '
        'TxtCtaFondos
        '
        Me.TxtCtaFondos.AcceptsReturn = True
        Me.TxtCtaFondos.Location = New System.Drawing.Point(119, 256)
        Me.TxtCtaFondos.Name = "TxtCtaFondos"
        Me.TxtCtaFondos.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaFondos.TabIndex = 192
        Me.TxtCtaFondos.Visible = False
        '
        'Button45
        '
        Me.Button45.Image = CType(resources.GetObject("Button45.Image"), System.Drawing.Image)
        Me.Button45.Location = New System.Drawing.Point(225, 218)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(29, 30)
        Me.Button45.TabIndex = 195
        Me.Button45.UseVisualStyleBackColor = True
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(0, 259)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(113, 13)
        Me.Label80.TabIndex = 190
        Me.Label80.Text = "Administracion Fondos"
        Me.Label80.Visible = False
        '
        'TxtCtaOtras
        '
        Me.TxtCtaOtras.Location = New System.Drawing.Point(119, 224)
        Me.TxtCtaOtras.Name = "TxtCtaOtras"
        Me.TxtCtaOtras.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaOtras.TabIndex = 193
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(15, 227)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(98, 13)
        Me.Label81.TabIndex = 191
        Me.Label81.Text = "Otras Deducciones"
        '
        'Button46
        '
        Me.Button46.Image = CType(resources.GetObject("Button46.Image"), System.Drawing.Image)
        Me.Button46.Location = New System.Drawing.Point(225, 182)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(29, 30)
        Me.Button46.TabIndex = 189
        Me.Button46.UseVisualStyleBackColor = True
        '
        'TxtCtaVeterinario
        '
        Me.TxtCtaVeterinario.Location = New System.Drawing.Point(119, 187)
        Me.TxtCtaVeterinario.Name = "TxtCtaVeterinario"
        Me.TxtCtaVeterinario.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaVeterinario.TabIndex = 188
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(2, 191)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(113, 13)
        Me.Label82.TabIndex = 187
        Me.Label82.Text = "Productos Veterinarios"
        '
        'Button47
        '
        Me.Button47.Image = CType(resources.GetObject("Button47.Image"), System.Drawing.Image)
        Me.Button47.Location = New System.Drawing.Point(224, 82)
        Me.Button47.Name = "Button47"
        Me.Button47.Size = New System.Drawing.Size(29, 30)
        Me.Button47.TabIndex = 186
        Me.Button47.UseVisualStyleBackColor = True
        '
        'TxtCtaTrazabilidad
        '
        Me.TxtCtaTrazabilidad.Location = New System.Drawing.Point(119, 85)
        Me.TxtCtaTrazabilidad.Name = "TxtCtaTrazabilidad"
        Me.TxtCtaTrazabilidad.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTrazabilidad.TabIndex = 185
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(49, 88)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(64, 13)
        Me.Label83.TabIndex = 184
        Me.Label83.Text = "Trazabilidad"
        '
        'Button48
        '
        Me.Button48.Image = CType(resources.GetObject("Button48.Image"), System.Drawing.Image)
        Me.Button48.Location = New System.Drawing.Point(225, 50)
        Me.Button48.Name = "Button48"
        Me.Button48.Size = New System.Drawing.Size(29, 30)
        Me.Button48.TabIndex = 183
        Me.Button48.UseVisualStyleBackColor = True
        '
        'TxtCtaInseminacion
        '
        Me.TxtCtaInseminacion.Location = New System.Drawing.Point(119, 55)
        Me.TxtCtaInseminacion.Name = "TxtCtaInseminacion"
        Me.TxtCtaInseminacion.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaInseminacion.TabIndex = 182
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(44, 59)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(69, 13)
        Me.Label84.TabIndex = 181
        Me.Label84.Text = "Inseminacion"
        '
        'Button49
        '
        Me.Button49.Image = CType(resources.GetObject("Button49.Image"), System.Drawing.Image)
        Me.Button49.Location = New System.Drawing.Point(225, 19)
        Me.Button49.Name = "Button49"
        Me.Button49.Size = New System.Drawing.Size(29, 30)
        Me.Button49.TabIndex = 180
        Me.Button49.UseVisualStyleBackColor = True
        '
        'TxtCtaTransporte
        '
        Me.TxtCtaTransporte.Location = New System.Drawing.Point(119, 24)
        Me.TxtCtaTransporte.Name = "TxtCtaTransporte"
        Me.TxtCtaTransporte.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaTransporte.TabIndex = 179
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(55, 24)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(58, 13)
        Me.Label85.TabIndex = 178
        Me.Label85.Text = "Transporte"
        '
        'Button50
        '
        Me.Button50.Image = CType(resources.GetObject("Button50.Image"), System.Drawing.Image)
        Me.Button50.Location = New System.Drawing.Point(434, 18)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(29, 30)
        Me.Button50.TabIndex = 177
        Me.Button50.UseVisualStyleBackColor = True
        '
        'TxtCtaGastoPlanilla
        '
        Me.TxtCtaGastoPlanilla.Location = New System.Drawing.Point(331, 21)
        Me.TxtCtaGastoPlanilla.Name = "TxtCtaGastoPlanilla"
        Me.TxtCtaGastoPlanilla.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaGastoPlanilla.TabIndex = 176
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(260, 24)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(71, 13)
        Me.Label86.TabIndex = 175
        Me.Label86.Text = "Gasto Planilla"
        '
        'Button51
        '
        Me.Button51.Image = CType(resources.GetObject("Button51.Image"), System.Drawing.Image)
        Me.Button51.Location = New System.Drawing.Point(225, 146)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(29, 30)
        Me.Button51.TabIndex = 174
        Me.Button51.UseVisualStyleBackColor = True
        '
        'TxtAnticipo
        '
        Me.TxtAnticipo.AcceptsReturn = True
        Me.TxtAnticipo.Location = New System.Drawing.Point(119, 152)
        Me.TxtAnticipo.Name = "TxtAnticipo"
        Me.TxtAnticipo.Size = New System.Drawing.Size(100, 20)
        Me.TxtAnticipo.TabIndex = 173
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(17, 155)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(96, 13)
        Me.Label87.TabIndex = 172
        Me.Label87.Text = "Anticipo de Planilla"
        '
        'Button52
        '
        Me.Button52.Image = CType(resources.GetObject("Button52.Image"), System.Drawing.Image)
        Me.Button52.Location = New System.Drawing.Point(225, 112)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(29, 30)
        Me.Button52.TabIndex = 171
        Me.Button52.UseVisualStyleBackColor = True
        '
        'TxtCtaBolsa
        '
        Me.TxtCtaBolsa.Location = New System.Drawing.Point(119, 117)
        Me.TxtCtaBolsa.Name = "TxtCtaBolsa"
        Me.TxtCtaBolsa.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBolsa.TabIndex = 170
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(22, 117)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(86, 13)
        Me.Label88.TabIndex = 169
        Me.Label88.Text = "Bolsa de Valores"
        '
        'Button53
        '
        Me.Button53.Image = CType(resources.GetObject("Button53.Image"), System.Drawing.Image)
        Me.Button53.Location = New System.Drawing.Point(434, 90)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(29, 30)
        Me.Button53.TabIndex = 168
        Me.Button53.UseVisualStyleBackColor = True
        '
        'TxtCtaIr
        '
        Me.TxtCtaIr.Location = New System.Drawing.Point(328, 92)
        Me.TxtCtaIr.Name = "TxtCtaIr"
        Me.TxtCtaIr.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaIr.TabIndex = 167
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(272, 92)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(55, 13)
        Me.Label89.TabIndex = 166
        Me.Label89.Text = "Cuenta IR"
        '
        'Button54
        '
        Me.Button54.Image = CType(resources.GetObject("Button54.Image"), System.Drawing.Image)
        Me.Button54.Location = New System.Drawing.Point(434, 54)
        Me.Button54.Name = "Button54"
        Me.Button54.Size = New System.Drawing.Size(29, 30)
        Me.Button54.TabIndex = 165
        Me.Button54.UseVisualStyleBackColor = True
        '
        'TxtCtaBanco
        '
        Me.TxtCtaBanco.Location = New System.Drawing.Point(328, 52)
        Me.TxtCtaBanco.Name = "TxtCtaBanco"
        Me.TxtCtaBanco.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaBanco.TabIndex = 164
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(256, 59)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(75, 13)
        Me.Label90.TabIndex = 141
        Me.Label90.Text = "Cuenta Banco"
        '
        'TabProveedor
        '
        Me.TabProveedor.Controls.Add(Me.GroupBox11)
        Me.TabProveedor.Controls.Add(Me.GroupBox10)
        Me.TabProveedor.Location = New System.Drawing.Point(4, 22)
        Me.TabProveedor.Name = "TabProveedor"
        Me.TabProveedor.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProveedor.Size = New System.Drawing.Size(616, 317)
        Me.TabProveedor.TabIndex = 6
        Me.TabProveedor.Text = "Proveedor"
        Me.TabProveedor.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.CboMunicipioProveedor)
        Me.GroupBox11.Controls.Add(Me.Label77)
        Me.GroupBox11.Controls.Add(Me.CboDepartamentoProveedor)
        Me.GroupBox11.Controls.Add(Me.Label78)
        Me.GroupBox11.Controls.Add(Me.CboEndosoProveedor)
        Me.GroupBox11.Controls.Add(Me.Label79)
        Me.GroupBox11.Controls.Add(Me.TxtDiasCreditoProveedor)
        Me.GroupBox11.Controls.Add(Me.Label72)
        Me.GroupBox11.Controls.Add(Me.CboMonedaProveedor)
        Me.GroupBox11.Controls.Add(Me.Label73)
        Me.GroupBox11.Controls.Add(Me.TxtCreditoDisProveedor)
        Me.GroupBox11.Controls.Add(Me.Label74)
        Me.GroupBox11.Controls.Add(Me.TxtCreditoAcumuladoProvee)
        Me.GroupBox11.Controls.Add(Me.Label75)
        Me.GroupBox11.Controls.Add(Me.TxtLimiteProveedor)
        Me.GroupBox11.Controls.Add(Me.Label76)
        Me.GroupBox11.Location = New System.Drawing.Point(20, 87)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(578, 206)
        Me.GroupBox11.TabIndex = 142
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Referencias Credito"
        '
        'CboMunicipioProveedor
        '
        Me.CboMunicipioProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMunicipioProveedor.Caption = ""
        Me.CboMunicipioProveedor.CaptionHeight = 17
        Me.CboMunicipioProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMunicipioProveedor.ColumnCaptionHeight = 17
        Me.CboMunicipioProveedor.ColumnFooterHeight = 17
        Me.CboMunicipioProveedor.ContentHeight = 15
        Me.CboMunicipioProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMunicipioProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMunicipioProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMunicipioProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMunicipioProveedor.EditorHeight = 15
        Me.CboMunicipioProveedor.Images.Add(CType(resources.GetObject("CboMunicipioProveedor.Images"), System.Drawing.Image))
        Me.CboMunicipioProveedor.ItemHeight = 15
        Me.CboMunicipioProveedor.Location = New System.Drawing.Point(391, 48)
        Me.CboMunicipioProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboMunicipioProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboMunicipioProveedor.MaxLength = 32767
        Me.CboMunicipioProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMunicipioProveedor.Name = "CboMunicipioProveedor"
        Me.CboMunicipioProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMunicipioProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMunicipioProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMunicipioProveedor.Size = New System.Drawing.Size(150, 21)
        Me.CboMunicipioProveedor.TabIndex = 171
        Me.CboMunicipioProveedor.PropBag = resources.GetString("CboMunicipioProveedor.PropBag")
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(321, 48)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(52, 13)
        Me.Label77.TabIndex = 170
        Me.Label77.Text = "Municipio"
        '
        'CboDepartamentoProveedor
        '
        Me.CboDepartamentoProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamentoProveedor.Caption = ""
        Me.CboDepartamentoProveedor.CaptionHeight = 17
        Me.CboDepartamentoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamentoProveedor.ColumnCaptionHeight = 17
        Me.CboDepartamentoProveedor.ColumnFooterHeight = 17
        Me.CboDepartamentoProveedor.ContentHeight = 15
        Me.CboDepartamentoProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamentoProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamentoProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamentoProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamentoProveedor.EditorHeight = 15
        Me.CboDepartamentoProveedor.Images.Add(CType(resources.GetObject("CboDepartamentoProveedor.Images"), System.Drawing.Image))
        Me.CboDepartamentoProveedor.ItemHeight = 15
        Me.CboDepartamentoProveedor.Location = New System.Drawing.Point(391, 23)
        Me.CboDepartamentoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamentoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamentoProveedor.MaxLength = 32767
        Me.CboDepartamentoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamentoProveedor.Name = "CboDepartamentoProveedor"
        Me.CboDepartamentoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamentoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamentoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamentoProveedor.Size = New System.Drawing.Size(150, 21)
        Me.CboDepartamentoProveedor.TabIndex = 169
        Me.CboDepartamentoProveedor.PropBag = resources.GetString("CboDepartamentoProveedor.PropBag")
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(299, 23)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(74, 13)
        Me.Label78.TabIndex = 168
        Me.Label78.Text = "Departamento"
        '
        'CboEndosoProveedor
        '
        Me.CboEndosoProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEndosoProveedor.Caption = ""
        Me.CboEndosoProveedor.CaptionHeight = 17
        Me.CboEndosoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEndosoProveedor.ColumnCaptionHeight = 17
        Me.CboEndosoProveedor.ColumnFooterHeight = 17
        Me.CboEndosoProveedor.ContentHeight = 15
        Me.CboEndosoProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEndosoProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEndosoProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEndosoProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEndosoProveedor.EditorHeight = 15
        Me.CboEndosoProveedor.Images.Add(CType(resources.GetObject("CboEndosoProveedor.Images"), System.Drawing.Image))
        Me.CboEndosoProveedor.ItemHeight = 15
        Me.CboEndosoProveedor.Location = New System.Drawing.Point(392, 74)
        Me.CboEndosoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboEndosoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboEndosoProveedor.MaxLength = 32767
        Me.CboEndosoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEndosoProveedor.Name = "CboEndosoProveedor"
        Me.CboEndosoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEndosoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEndosoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEndosoProveedor.Size = New System.Drawing.Size(150, 21)
        Me.CboEndosoProveedor.TabIndex = 166
        Me.CboEndosoProveedor.PropBag = resources.GetString("CboEndosoProveedor.PropBag")
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(286, 74)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(93, 13)
        Me.Label79.TabIndex = 167
        Me.Label79.Text = "Compañia Endoso"
        '
        'TxtDiasCreditoProveedor
        '
        Me.TxtDiasCreditoProveedor.Location = New System.Drawing.Point(113, 133)
        Me.TxtDiasCreditoProveedor.Name = "TxtDiasCreditoProveedor"
        Me.TxtDiasCreditoProveedor.Size = New System.Drawing.Size(108, 20)
        Me.TxtDiasCreditoProveedor.TabIndex = 145
        Me.TxtDiasCreditoProveedor.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(11, 136)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(64, 13)
        Me.Label72.TabIndex = 144
        Me.Label72.Text = "Dias Credito"
        '
        'CboMonedaProveedor
        '
        Me.CboMonedaProveedor.FormattingEnabled = True
        Me.CboMonedaProveedor.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CboMonedaProveedor.Location = New System.Drawing.Point(114, 28)
        Me.CboMonedaProveedor.Name = "CboMonedaProveedor"
        Me.CboMonedaProveedor.Size = New System.Drawing.Size(107, 21)
        Me.CboMonedaProveedor.TabIndex = 143
        Me.CboMonedaProveedor.Text = "Cordobas"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(16, 31)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(85, 13)
        Me.Label73.TabIndex = 142
        Me.Label73.Text = "Moneda Factura"
        '
        'TxtCreditoDisProveedor
        '
        Me.TxtCreditoDisProveedor.Enabled = False
        Me.TxtCreditoDisProveedor.Location = New System.Drawing.Point(114, 107)
        Me.TxtCreditoDisProveedor.Name = "TxtCreditoDisProveedor"
        Me.TxtCreditoDisProveedor.Size = New System.Drawing.Size(107, 20)
        Me.TxtCreditoDisProveedor.TabIndex = 141
        Me.TxtCreditoDisProveedor.Text = "0"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(12, 110)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(92, 13)
        Me.Label74.TabIndex = 140
        Me.Label74.Text = "Credito Disponible"
        '
        'TxtCreditoAcumuladoProvee
        '
        Me.TxtCreditoAcumuladoProvee.Enabled = False
        Me.TxtCreditoAcumuladoProvee.Location = New System.Drawing.Point(114, 81)
        Me.TxtCreditoAcumuladoProvee.Name = "TxtCreditoAcumuladoProvee"
        Me.TxtCreditoAcumuladoProvee.Size = New System.Drawing.Size(107, 20)
        Me.TxtCreditoAcumuladoProvee.TabIndex = 139
        Me.TxtCreditoAcumuladoProvee.Text = "0"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(12, 84)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(96, 13)
        Me.Label75.TabIndex = 138
        Me.Label75.Text = "Credito Acumulado"
        '
        'TxtLimiteProveedor
        '
        Me.TxtLimiteProveedor.AcceptsReturn = True
        Me.TxtLimiteProveedor.Location = New System.Drawing.Point(114, 55)
        Me.TxtLimiteProveedor.Name = "TxtLimiteProveedor"
        Me.TxtLimiteProveedor.Size = New System.Drawing.Size(107, 20)
        Me.TxtLimiteProveedor.TabIndex = 137
        Me.TxtLimiteProveedor.Text = "0"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(12, 58)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(85, 13)
        Me.Label76.TabIndex = 136
        Me.Label76.Text = "Limite de Credito"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Button43)
        Me.GroupBox10.Controls.Add(Me.TxtCtasxPagarProveedor)
        Me.GroupBox10.Controls.Add(Me.Label71)
        Me.GroupBox10.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(578, 74)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        '
        'Button43
        '
        Me.Button43.Image = CType(resources.GetObject("Button43.Image"), System.Drawing.Image)
        Me.Button43.Location = New System.Drawing.Point(250, 12)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(35, 28)
        Me.Button43.TabIndex = 113
        Me.Button43.UseVisualStyleBackColor = True
        '
        'TxtCtasxPagarProveedor
        '
        Me.TxtCtasxPagarProveedor.Location = New System.Drawing.Point(96, 16)
        Me.TxtCtasxPagarProveedor.Name = "TxtCtasxPagarProveedor"
        Me.TxtCtasxPagarProveedor.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtasxPagarProveedor.TabIndex = 112
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(10, 19)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(80, 13)
        Me.Label71.TabIndex = 114
        Me.Label71.Text = "Cuenta x Pagar"
        '
        'TabEmpleado
        '
        Me.TabEmpleado.Location = New System.Drawing.Point(4, 22)
        Me.TabEmpleado.Name = "TabEmpleado"
        Me.TabEmpleado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmpleado.Size = New System.Drawing.Size(616, 317)
        Me.TabEmpleado.TabIndex = 7
        Me.TabEmpleado.Text = "Empleado"
        Me.TabEmpleado.UseVisualStyleBackColor = True
        '
        'FrmBeneficiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 419)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBeneficiario"
        Me.Text = "Registro Codigo Unico"
        CType(Me.CboCodigoProductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        Me.TabClientes.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TxtDiasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSocio.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.CboTransportistaSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoNominaSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCooperativaSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamentosSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEscolaridadSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboRutaSocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPreSocio.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.CboTransportistaPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoNominaPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboRutaPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCooperativaPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamentosPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEscolaridadPreSocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabProductor.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.CboTransportistaProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoNominaProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboRutaProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCooperativaProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamentosProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEscolaridadProductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabTransportista.ResumeLayout(False)
        Me.TabTransportista.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.TabProveedor.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.CboMunicipioProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamentoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEndosoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDiasCreditoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNumeroCedula As MaskedTextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents CboCodigoProductor As C1.Win.C1List.C1Combo
    Friend WithEvents CboSexo As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents DTFechaNacimientos As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DTFechaAdmision As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtApellidos As TextBox
    Friend WithEvents LblApellido As Label
    Friend WithEvents TxtDireccion As TextBox
    Friend WithEvents LblDireccion As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblCodigo As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CmdAgregar As Button
    Friend WithEvents CmdBorrarFoto As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button6 As Button
    Friend WithEvents ButtonBorrar As Button
    Friend WithEvents ButtonAgregar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents ChkProductor As CheckBox
    Friend WithEvents ChkProveedor As CheckBox
    Friend WithEvents ChkEmpleado As CheckBox
    Friend WithEvents ChkCliente As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChkActivo As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtTelefono As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CboEstadoCivil As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtRuc As MaskedTextBox
    Friend WithEvents ImgFoto As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabGeneral As TabPage
    Friend WithEvents TabClientes As TabPage
    Friend WithEvents ChkPreSocio As CheckBox
    Friend WithEvents ChkSocio As CheckBox
    Friend WithEvents ChkTransportista As CheckBox
    Friend WithEvents TabSocio As TabPage
    Friend WithEvents TabPreSocio As TabPage
    Friend WithEvents TabTransportista As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ChkBloqueoLimite As CheckBox
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtDiasCredito As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents CboMonedaCliente As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ChkCreditoDisponible As CheckBox
    Friend WithEvents ChkCausaIVA As CheckBox
    Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
    Friend WithEvents TxtRuc2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtCreditoDisCliente As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtCreditoAcumuladoCliente As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtLimiteCliente As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ChkEfectivo As CheckBox
    Friend WithEvents CboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents Label9 As Label
    Friend WithEvents CboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents Label8 As Label
    Friend WithEvents CboEndoso As C1.Win.C1List.C1Combo
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtCtaxCobrar As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CboCooperativaSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboDepartamentosSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboEscolaridadSocio As C1.Win.C1List.C1Combo
    Friend WithEvents Label28 As Label
    Friend WithEvents TxtCtaxPagarSocio As TextBox
    Friend WithEvents Lbl As Label
    Friend WithEvents TxtCtasCobrarSocio As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CboRutaSocio As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents TxtCtaGastoSocio As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents TxtAnticipoSocio As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents TxtCtaBolsaSocio As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TxtCtaIrSocio As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TxtCtaBancoSocio As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents TxtFondosAdmonSocio As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents TxtCtaOtrasSocio As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents TxtCtaVeterinarioSocio As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TxtCtaTrazabilidadSocio As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TxtCtaInseminacionSocio As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents TxtCtaTransporteSocio As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents TxtFondosAdmonPreSocio As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents TxtCtaOtrasPreSocio As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TxtCtaVeterinarioPreSocio As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents TxtCtaTrazabilidadPreSocio As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents TxtCtaInseminacionPreSocio As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents TxtCtaTransportePreSocio As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Button25 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents Button28 As Button
    Friend WithEvents Button29 As Button
    Friend WithEvents TxtCtaGastoPreSocio As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents TxtAnticipoPreSocio As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents TxtCtaBolsaPreSocio As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents TxtCtaIrPreSocio As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents TxtCtaBancoPreSocio As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents CboRutaPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboCooperativaPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboDepartamentosPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboEscolaridadPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtCtaxPagarPreSocio As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtCtasCobrarPreSocio As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents TabProductor As TabPage
    Friend WithEvents TabProveedor As TabPage
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Button32 As Button
    Friend WithEvents Button33 As Button
    Friend WithEvents Button34 As Button
    Friend WithEvents Button35 As Button
    Friend WithEvents Button36 As Button
    Friend WithEvents Button37 As Button
    Friend WithEvents TxtFondosAdmonProductor As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents TxtCtaOtrasProductor As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents TxtCtaVeterinarioProductor As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents TxtCtaTrazabilidadProductor As TextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents TxtCtaInseminacionProductor As TextBox
    Friend WithEvents Label64 As Label
    Friend WithEvents TxtCtaTransporteProductor As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Button38 As Button
    Friend WithEvents Button39 As Button
    Friend WithEvents Button40 As Button
    Friend WithEvents Button41 As Button
    Friend WithEvents Button42 As Button
    Friend WithEvents TxtCtaGastoProductor As TextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents TxtAnticipoProductor As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents TxtCtaBolsaProductor As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents TxtCtaIrProductor As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents TxtCtaBancoProductor As TextBox
    Friend WithEvents Label70 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Button30 As Button
    Friend WithEvents Button31 As Button
    Friend WithEvents CboRutaProductor As C1.Win.C1List.C1Combo
    Friend WithEvents CboCooperativaProductor As C1.Win.C1List.C1Combo
    Friend WithEvents CboDepartamentosProductor As C1.Win.C1List.C1Combo
    Friend WithEvents CboEscolaridadProductor As C1.Win.C1List.C1Combo
    Friend WithEvents Label54 As Label
    Friend WithEvents TxtCtaxPagarProductor As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents TxtCtasCobrarProductor As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents Button43 As Button
    Friend WithEvents TxtCtasxPagarProveedor As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents TxtDiasCreditoProveedor As NumericUpDown
    Friend WithEvents Label72 As Label
    Friend WithEvents CboMonedaProveedor As ComboBox
    Friend WithEvents Label73 As Label
    Friend WithEvents TxtCreditoDisProveedor As TextBox
    Friend WithEvents Label74 As Label
    Friend WithEvents TxtCreditoAcumuladoProvee As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents TxtLimiteProveedor As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents TabEmpleado As TabPage
    Friend WithEvents CboMunicipioProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label77 As Label
    Friend WithEvents CboDepartamentoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label78 As Label
    Friend WithEvents CboEndosoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label79 As Label
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Button44 As Button
    Friend WithEvents TxtCtaFondos As TextBox
    Friend WithEvents Button45 As Button
    Friend WithEvents Label80 As Label
    Friend WithEvents TxtCtaOtras As TextBox
    Friend WithEvents Label81 As Label
    Friend WithEvents Button46 As Button
    Friend WithEvents TxtCtaVeterinario As TextBox
    Friend WithEvents Label82 As Label
    Friend WithEvents Button47 As Button
    Friend WithEvents TxtCtaTrazabilidad As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents Button48 As Button
    Friend WithEvents TxtCtaInseminacion As TextBox
    Friend WithEvents Label84 As Label
    Friend WithEvents Button49 As Button
    Friend WithEvents TxtCtaTransporte As TextBox
    Friend WithEvents Label85 As Label
    Friend WithEvents Button50 As Button
    Friend WithEvents TxtCtaGastoPlanilla As TextBox
    Friend WithEvents Label86 As Label
    Friend WithEvents Button51 As Button
    Friend WithEvents TxtAnticipo As TextBox
    Friend WithEvents Label87 As Label
    Friend WithEvents Button52 As Button
    Friend WithEvents TxtCtaBolsa As TextBox
    Friend WithEvents Label88 As Label
    Friend WithEvents Button53 As Button
    Friend WithEvents TxtCtaIr As TextBox
    Friend WithEvents Label89 As Label
    Friend WithEvents Button54 As Button
    Friend WithEvents TxtCtaBanco As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents TxtCuentBanco As TextBox
    Friend WithEvents CboTipoNominaSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboTipoNominaPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents CboTipoNominaProductor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtPrecioSocio As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents TxtPrecioPreSocio As TextBox
    Friend WithEvents Label93 As Label
    Friend WithEvents TxtPrecioProductor As TextBox
    Friend WithEvents Label94 As Label
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label96 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label95 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label97 As Label
    Friend WithEvents CboTransportistaSocio As C1.Win.C1List.C1Combo
    Friend WithEvents Label98 As Label
    Friend WithEvents CboTransportistaPreSocio As C1.Win.C1List.C1Combo
    Friend WithEvents Label99 As Label
    Friend WithEvents CboTransportistaProductor As C1.Win.C1List.C1Combo
    Friend WithEvents Label100 As Label
End Class
