<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaConductores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaConductores))
        Me.Button2 = New System.Windows.Forms.Button
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.LblProcesando = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdNomina = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Ingresos = New System.Windows.Forms.TabPage
        Me.TDGridIngresos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Deducciones = New System.Windows.Forms.TabPage
        Me.TDGridDeducciones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Configuracion = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtPrecioDomingo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtPrecioSabado = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtPrecioViernes = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtPrecioJueves = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtPrecioMiercoles = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtPrecioMartes = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtBolsa = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPrecioLunes = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtDeduccionPolicia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtIR = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdCalcular = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtNumNomina = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblTotalPlanilla = New System.Windows.Forms.Label
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboTipoPlanilla = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.BindingDeducciones2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.Ingresos.SuspendLayout()
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Deducciones.SuspendLayout()
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Configuracion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboTipoPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDeducciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.AccessibleDescription = Nothing
        Me.Button2.AccessibleName = Nothing
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.BackgroundImage = Nothing
        Me.Button2.Font = Nothing
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.AccessibleDescription = Nothing
        Me.ProgressBar2.AccessibleName = Nothing
        resources.ApplyResources(Me.ProgressBar2, "ProgressBar2")
        Me.ProgressBar2.BackgroundImage = Nothing
        Me.ProgressBar2.Font = Nothing
        Me.ProgressBar2.Name = "ProgressBar2"
        '
        'LblProcesando
        '
        Me.LblProcesando.AccessibleDescription = Nothing
        Me.LblProcesando.AccessibleName = Nothing
        resources.ApplyResources(Me.LblProcesando, "LblProcesando")
        Me.LblProcesando.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblProcesando.Name = "LblProcesando"
        '
        'ProgressBar
        '
        Me.ProgressBar.AccessibleDescription = Nothing
        Me.ProgressBar.AccessibleName = Nothing
        resources.ApplyResources(Me.ProgressBar, "ProgressBar")
        Me.ProgressBar.BackgroundImage = Nothing
        Me.ProgressBar.Font = Nothing
        Me.ProgressBar.Name = "ProgressBar"
        '
        'CmdCerrar
        '
        Me.CmdCerrar.AccessibleDescription = Nothing
        Me.CmdCerrar.AccessibleName = Nothing
        resources.ApplyResources(Me.CmdCerrar, "CmdCerrar")
        Me.CmdCerrar.BackgroundImage = Nothing
        Me.CmdCerrar.Font = Nothing
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.AccessibleDescription = Nothing
        Me.CmdSalir.AccessibleName = Nothing
        resources.ApplyResources(Me.CmdSalir, "CmdSalir")
        Me.CmdSalir.BackgroundImage = Nothing
        Me.CmdSalir.Font = Nothing
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdNomina
        '
        Me.CmdNomina.AccessibleDescription = Nothing
        Me.CmdNomina.AccessibleName = Nothing
        resources.ApplyResources(Me.CmdNomina, "CmdNomina")
        Me.CmdNomina.BackgroundImage = Nothing
        Me.CmdNomina.Font = Nothing
        Me.CmdNomina.Name = "CmdNomina"
        Me.CmdNomina.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = Nothing
        Me.TabControl1.AccessibleName = Nothing
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.BackgroundImage = Nothing
        Me.TabControl1.Controls.Add(Me.Ingresos)
        Me.TabControl1.Controls.Add(Me.Deducciones)
        Me.TabControl1.Controls.Add(Me.Configuracion)
        Me.TabControl1.Font = Nothing
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'Ingresos
        '
        Me.Ingresos.AccessibleDescription = Nothing
        Me.Ingresos.AccessibleName = Nothing
        resources.ApplyResources(Me.Ingresos, "Ingresos")
        Me.Ingresos.BackgroundImage = Nothing
        Me.Ingresos.Controls.Add(Me.TDGridIngresos)
        Me.Ingresos.Font = Nothing
        Me.Ingresos.Name = "Ingresos"
        Me.Ingresos.UseVisualStyleBackColor = True
        '
        'TDGridIngresos
        '
        Me.TDGridIngresos.AccessibleDescription = Nothing
        Me.TDGridIngresos.AccessibleName = Nothing
        resources.ApplyResources(Me.TDGridIngresos, "TDGridIngresos")
        Me.TDGridIngresos.BackgroundImage = Nothing
        Me.TDGridIngresos.ChildGrid = Nothing
        Me.TDGridIngresos.Font = Nothing
        Me.TDGridIngresos.Images.Add(CType(resources.GetObject("TDGridIngresos.Images"), System.Drawing.Image))
        Me.TDGridIngresos.Name = "TDGridIngresos"
        Me.TDGridIngresos.PictureAddnewRow = Nothing
        Me.TDGridIngresos.PictureCurrentRow = Nothing
        Me.TDGridIngresos.PictureFilterBar = Nothing
        Me.TDGridIngresos.PictureFooterRow = Nothing
        Me.TDGridIngresos.PictureHeaderRow = Nothing
        Me.TDGridIngresos.PictureModifiedRow = Nothing
        Me.TDGridIngresos.PictureStandardRow = Nothing
        Me.TDGridIngresos.PreviewInfo.AllowSizing = CType(resources.GetObject("TDGridIngresos.PreviewInfo.AllowSizing"), Boolean)
        Me.TDGridIngresos.PreviewInfo.Caption = resources.GetString("TDGridIngresos.PreviewInfo.Caption")
        Me.TDGridIngresos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridIngresos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridIngresos.PreviewInfo.ToolBars = CType(resources.GetObject("TDGridIngresos.PreviewInfo.ToolBars"), Boolean)
        Me.TDGridIngresos.PreviewInfo.UIStrings.Content = CType(resources.GetObject("TDGridIngresos.PreviewInfo.UIStrings.Content"), String())
        Me.TDGridIngresos.PreviewInfo.ZoomFactor = 75
        Me.TDGridIngresos.PrintInfo.MaxRowHeight = CType(resources.GetObject("TDGridIngresos.PrintInfo.MaxRowHeight"), Integer)
        Me.TDGridIngresos.PrintInfo.OneFormPerPage = CType(resources.GetObject("TDGridIngresos.PrintInfo.OneFormPerPage"), Boolean)
        Me.TDGridIngresos.PrintInfo.OwnerDrawPageFooter = CType(resources.GetObject("TDGridIngresos.PrintInfo.OwnerDrawPageFooter"), Boolean)
        Me.TDGridIngresos.PrintInfo.OwnerDrawPageHeader = CType(resources.GetObject("TDGridIngresos.PrintInfo.OwnerDrawPageHeader"), Boolean)
        Me.TDGridIngresos.PrintInfo.PageFooter = resources.GetString("TDGridIngresos.PrintInfo.PageFooter")
        Me.TDGridIngresos.PrintInfo.PageFooterHeight = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageFooterHeight"), Integer)
        Me.TDGridIngresos.PrintInfo.PageHeader = resources.GetString("TDGridIngresos.PrintInfo.PageHeader")
        Me.TDGridIngresos.PrintInfo.PageHeaderHeight = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageHeaderHeight"), Integer)
        Me.TDGridIngresos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridIngresos.PrintInfo.PrintHorizontalSplits = CType(resources.GetObject("TDGridIngresos.PrintInfo.PrintHorizontalSplits"), Boolean)
        Me.TDGridIngresos.PrintInfo.ProgressCaption = resources.GetString("TDGridIngresos.PrintInfo.ProgressCaption")
        Me.TDGridIngresos.PrintInfo.RepeatColumnFooters = CType(resources.GetObject("TDGridIngresos.PrintInfo.RepeatColumnFooters"), Boolean)
        Me.TDGridIngresos.PrintInfo.RepeatColumnHeaders = CType(resources.GetObject("TDGridIngresos.PrintInfo.RepeatColumnHeaders"), Boolean)
        Me.TDGridIngresos.PrintInfo.RepeatGridHeader = CType(resources.GetObject("TDGridIngresos.PrintInfo.RepeatGridHeader"), Boolean)
        Me.TDGridIngresos.PrintInfo.RepeatSplitHeaders = CType(resources.GetObject("TDGridIngresos.PrintInfo.RepeatSplitHeaders"), Boolean)
        Me.TDGridIngresos.PrintInfo.ShowOptionsDialog = CType(resources.GetObject("TDGridIngresos.PrintInfo.ShowOptionsDialog"), Boolean)
        Me.TDGridIngresos.PrintInfo.ShowProgressForm = CType(resources.GetObject("TDGridIngresos.PrintInfo.ShowProgressForm"), Boolean)
        Me.TDGridIngresos.PrintInfo.ShowSelection = CType(resources.GetObject("TDGridIngresos.PrintInfo.ShowSelection"), Boolean)
        Me.TDGridIngresos.PrintInfo.UseGridColors = CType(resources.GetObject("TDGridIngresos.PrintInfo.UseGridColors"), Boolean)
        Me.TDGridIngresos.RowDivider.Color = CType(resources.GetObject("resource.Color"), System.Drawing.Color)
        Me.TDGridIngresos.RowDivider.Style = CType(resources.GetObject("resource.Style"), C1.Win.C1TrueDBGrid.LineStyleEnum)
        Me.TDGridIngresos.PropBag = resources.GetString("TDGridIngresos.PropBag")
        '
        'Deducciones
        '
        Me.Deducciones.AccessibleDescription = Nothing
        Me.Deducciones.AccessibleName = Nothing
        resources.ApplyResources(Me.Deducciones, "Deducciones")
        Me.Deducciones.BackgroundImage = Nothing
        Me.Deducciones.Controls.Add(Me.TDGridDeducciones)
        Me.Deducciones.Font = Nothing
        Me.Deducciones.Name = "Deducciones"
        Me.Deducciones.UseVisualStyleBackColor = True
        '
        'TDGridDeducciones
        '
        Me.TDGridDeducciones.AccessibleDescription = Nothing
        Me.TDGridDeducciones.AccessibleName = Nothing
        resources.ApplyResources(Me.TDGridDeducciones, "TDGridDeducciones")
        Me.TDGridDeducciones.BackgroundImage = Nothing
        Me.TDGridDeducciones.ChildGrid = Nothing
        Me.TDGridDeducciones.Font = Nothing
        Me.TDGridDeducciones.Images.Add(CType(resources.GetObject("TDGridDeducciones.Images"), System.Drawing.Image))
        Me.TDGridDeducciones.Name = "TDGridDeducciones"
        Me.TDGridDeducciones.PictureAddnewRow = Nothing
        Me.TDGridDeducciones.PictureCurrentRow = Nothing
        Me.TDGridDeducciones.PictureFilterBar = Nothing
        Me.TDGridDeducciones.PictureFooterRow = Nothing
        Me.TDGridDeducciones.PictureHeaderRow = Nothing
        Me.TDGridDeducciones.PictureModifiedRow = Nothing
        Me.TDGridDeducciones.PictureStandardRow = Nothing
        Me.TDGridDeducciones.PreviewInfo.AllowSizing = CType(resources.GetObject("TDGridDeducciones.PreviewInfo.AllowSizing"), Boolean)
        Me.TDGridDeducciones.PreviewInfo.Caption = resources.GetString("TDGridDeducciones.PreviewInfo.Caption")
        Me.TDGridDeducciones.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridDeducciones.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridDeducciones.PreviewInfo.ToolBars = CType(resources.GetObject("TDGridDeducciones.PreviewInfo.ToolBars"), Boolean)
        Me.TDGridDeducciones.PreviewInfo.UIStrings.Content = CType(resources.GetObject("TDGridDeducciones.PreviewInfo.UIStrings.Content"), String())
        Me.TDGridDeducciones.PreviewInfo.ZoomFactor = 75
        Me.TDGridDeducciones.PrintInfo.MaxRowHeight = CType(resources.GetObject("TDGridDeducciones.PrintInfo.MaxRowHeight"), Integer)
        Me.TDGridDeducciones.PrintInfo.OneFormPerPage = CType(resources.GetObject("TDGridDeducciones.PrintInfo.OneFormPerPage"), Boolean)
        Me.TDGridDeducciones.PrintInfo.OwnerDrawPageFooter = CType(resources.GetObject("TDGridDeducciones.PrintInfo.OwnerDrawPageFooter"), Boolean)
        Me.TDGridDeducciones.PrintInfo.OwnerDrawPageHeader = CType(resources.GetObject("TDGridDeducciones.PrintInfo.OwnerDrawPageHeader"), Boolean)
        Me.TDGridDeducciones.PrintInfo.PageFooter = resources.GetString("TDGridDeducciones.PrintInfo.PageFooter")
        Me.TDGridDeducciones.PrintInfo.PageFooterHeight = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PageFooterHeight"), Integer)
        Me.TDGridDeducciones.PrintInfo.PageHeader = resources.GetString("TDGridDeducciones.PrintInfo.PageHeader")
        Me.TDGridDeducciones.PrintInfo.PageHeaderHeight = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PageHeaderHeight"), Integer)
        Me.TDGridDeducciones.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDeducciones.PrintInfo.PrintHorizontalSplits = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PrintHorizontalSplits"), Boolean)
        Me.TDGridDeducciones.PrintInfo.ProgressCaption = resources.GetString("TDGridDeducciones.PrintInfo.ProgressCaption")
        Me.TDGridDeducciones.PrintInfo.RepeatColumnFooters = CType(resources.GetObject("TDGridDeducciones.PrintInfo.RepeatColumnFooters"), Boolean)
        Me.TDGridDeducciones.PrintInfo.RepeatColumnHeaders = CType(resources.GetObject("TDGridDeducciones.PrintInfo.RepeatColumnHeaders"), Boolean)
        Me.TDGridDeducciones.PrintInfo.RepeatGridHeader = CType(resources.GetObject("TDGridDeducciones.PrintInfo.RepeatGridHeader"), Boolean)
        Me.TDGridDeducciones.PrintInfo.RepeatSplitHeaders = CType(resources.GetObject("TDGridDeducciones.PrintInfo.RepeatSplitHeaders"), Boolean)
        Me.TDGridDeducciones.PrintInfo.ShowOptionsDialog = CType(resources.GetObject("TDGridDeducciones.PrintInfo.ShowOptionsDialog"), Boolean)
        Me.TDGridDeducciones.PrintInfo.ShowProgressForm = CType(resources.GetObject("TDGridDeducciones.PrintInfo.ShowProgressForm"), Boolean)
        Me.TDGridDeducciones.PrintInfo.ShowSelection = CType(resources.GetObject("TDGridDeducciones.PrintInfo.ShowSelection"), Boolean)
        Me.TDGridDeducciones.PrintInfo.UseGridColors = CType(resources.GetObject("TDGridDeducciones.PrintInfo.UseGridColors"), Boolean)
        Me.TDGridDeducciones.RowDivider.Color = CType(resources.GetObject("resource.Color1"), System.Drawing.Color)
        Me.TDGridDeducciones.RowDivider.Style = CType(resources.GetObject("resource.Style1"), C1.Win.C1TrueDBGrid.LineStyleEnum)
        Me.TDGridDeducciones.PropBag = resources.GetString("TDGridDeducciones.PropBag")
        '
        'Configuracion
        '
        Me.Configuracion.AccessibleDescription = Nothing
        Me.Configuracion.AccessibleName = Nothing
        resources.ApplyResources(Me.Configuracion, "Configuracion")
        Me.Configuracion.BackgroundImage = Nothing
        Me.Configuracion.Controls.Add(Me.Button1)
        Me.Configuracion.Controls.Add(Me.GroupBox2)
        Me.Configuracion.Font = Nothing
        Me.Configuracion.Name = "Configuracion"
        Me.Configuracion.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = Nothing
        Me.Button1.AccessibleName = Nothing
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackgroundImage = Nothing
        Me.Button1.Font = Nothing
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AccessibleDescription = Nothing
        Me.GroupBox2.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackgroundImage = Nothing
        Me.GroupBox2.Controls.Add(Me.TxtPrecioDomingo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioSabado)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioViernes)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioJueves)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioMiercoles)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioMartes)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TxtBolsa)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioLunes)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtDeduccionPolicia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtIR)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = Nothing
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'TxtPrecioDomingo
        '
        Me.TxtPrecioDomingo.AccessibleDescription = Nothing
        Me.TxtPrecioDomingo.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioDomingo, "TxtPrecioDomingo")
        Me.TxtPrecioDomingo.BackgroundImage = Nothing
        Me.TxtPrecioDomingo.Font = Nothing
        Me.TxtPrecioDomingo.Name = "TxtPrecioDomingo"
        '
        'Label15
        '
        Me.Label15.AccessibleDescription = Nothing
        Me.Label15.AccessibleName = Nothing
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Font = Nothing
        Me.Label15.Name = "Label15"
        '
        'TxtPrecioSabado
        '
        Me.TxtPrecioSabado.AccessibleDescription = Nothing
        Me.TxtPrecioSabado.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioSabado, "TxtPrecioSabado")
        Me.TxtPrecioSabado.BackgroundImage = Nothing
        Me.TxtPrecioSabado.Font = Nothing
        Me.TxtPrecioSabado.Name = "TxtPrecioSabado"
        '
        'Label14
        '
        Me.Label14.AccessibleDescription = Nothing
        Me.Label14.AccessibleName = Nothing
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Font = Nothing
        Me.Label14.Name = "Label14"
        '
        'TxtPrecioViernes
        '
        Me.TxtPrecioViernes.AccessibleDescription = Nothing
        Me.TxtPrecioViernes.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioViernes, "TxtPrecioViernes")
        Me.TxtPrecioViernes.BackgroundImage = Nothing
        Me.TxtPrecioViernes.Font = Nothing
        Me.TxtPrecioViernes.Name = "TxtPrecioViernes"
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = Nothing
        Me.Label13.AccessibleName = Nothing
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Font = Nothing
        Me.Label13.Name = "Label13"
        '
        'TxtPrecioJueves
        '
        Me.TxtPrecioJueves.AccessibleDescription = Nothing
        Me.TxtPrecioJueves.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioJueves, "TxtPrecioJueves")
        Me.TxtPrecioJueves.BackgroundImage = Nothing
        Me.TxtPrecioJueves.Font = Nothing
        Me.TxtPrecioJueves.Name = "TxtPrecioJueves"
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = Nothing
        Me.Label12.AccessibleName = Nothing
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Font = Nothing
        Me.Label12.Name = "Label12"
        '
        'TxtPrecioMiercoles
        '
        Me.TxtPrecioMiercoles.AccessibleDescription = Nothing
        Me.TxtPrecioMiercoles.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioMiercoles, "TxtPrecioMiercoles")
        Me.TxtPrecioMiercoles.BackgroundImage = Nothing
        Me.TxtPrecioMiercoles.Font = Nothing
        Me.TxtPrecioMiercoles.Name = "TxtPrecioMiercoles"
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = Nothing
        Me.Label11.AccessibleName = Nothing
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Font = Nothing
        Me.Label11.Name = "Label11"
        '
        'TxtPrecioMartes
        '
        Me.TxtPrecioMartes.AccessibleDescription = Nothing
        Me.TxtPrecioMartes.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioMartes, "TxtPrecioMartes")
        Me.TxtPrecioMartes.BackgroundImage = Nothing
        Me.TxtPrecioMartes.Font = Nothing
        Me.TxtPrecioMartes.Name = "TxtPrecioMartes"
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = Nothing
        Me.Label10.AccessibleName = Nothing
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Font = Nothing
        Me.Label10.Name = "Label10"
        '
        'TxtBolsa
        '
        Me.TxtBolsa.AccessibleDescription = Nothing
        Me.TxtBolsa.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtBolsa, "TxtBolsa")
        Me.TxtBolsa.BackgroundImage = Nothing
        Me.TxtBolsa.Font = Nothing
        Me.TxtBolsa.Name = "TxtBolsa"
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = Nothing
        Me.Label8.AccessibleName = Nothing
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Font = Nothing
        Me.Label8.Name = "Label8"
        '
        'TxtPrecioLunes
        '
        Me.TxtPrecioLunes.AccessibleDescription = Nothing
        Me.TxtPrecioLunes.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtPrecioLunes, "TxtPrecioLunes")
        Me.TxtPrecioLunes.BackgroundImage = Nothing
        Me.TxtPrecioLunes.Font = Nothing
        Me.TxtPrecioLunes.Name = "TxtPrecioLunes"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = Nothing
        Me.Label6.AccessibleName = Nothing
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Font = Nothing
        Me.Label6.Name = "Label6"
        '
        'TxtDeduccionPolicia
        '
        Me.TxtDeduccionPolicia.AccessibleDescription = Nothing
        Me.TxtDeduccionPolicia.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtDeduccionPolicia, "TxtDeduccionPolicia")
        Me.TxtDeduccionPolicia.BackgroundImage = Nothing
        Me.TxtDeduccionPolicia.Font = Nothing
        Me.TxtDeduccionPolicia.Name = "TxtDeduccionPolicia"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = Nothing
        Me.Label5.AccessibleName = Nothing
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Font = Nothing
        Me.Label5.Name = "Label5"
        '
        'TxtIR
        '
        Me.TxtIR.AccessibleDescription = Nothing
        Me.TxtIR.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtIR, "TxtIR")
        Me.TxtIR.BackgroundImage = Nothing
        Me.TxtIR.Font = Nothing
        Me.TxtIR.Name = "TxtIR"
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = Nothing
        Me.Label4.AccessibleName = Nothing
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Font = Nothing
        Me.Label4.Name = "Label4"
        '
        'CmdCalcular
        '
        Me.CmdCalcular.AccessibleDescription = Nothing
        Me.CmdCalcular.AccessibleName = Nothing
        resources.ApplyResources(Me.CmdCalcular, "CmdCalcular")
        Me.CmdCalcular.BackgroundImage = Nothing
        Me.CmdCalcular.Font = Nothing
        Me.CmdCalcular.Name = "CmdCalcular"
        Me.CmdCalcular.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = Nothing
        Me.Label9.AccessibleName = Nothing
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Name = "Label9"
        '
        'PictureBox2
        '
        Me.PictureBox2.AccessibleDescription = Nothing
        Me.PictureBox2.AccessibleName = Nothing
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.BackgroundImage = Nothing
        Me.PictureBox2.Font = Nothing
        Me.PictureBox2.ImageLocation = Nothing
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.AccessibleDescription = Nothing
        Me.CmdBorraLinea.AccessibleName = Nothing
        resources.ApplyResources(Me.CmdBorraLinea, "CmdBorraLinea")
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.BackgroundImage = Nothing
        Me.CmdBorraLinea.Font = Nothing
        Me.CmdBorraLinea.ImageLocation = Nothing
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = Nothing
        Me.GroupBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackgroundImage = Nothing
        Me.GroupBox1.Controls.Add(Me.TxtNumNomina)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblTotalPlanilla)
        Me.GroupBox1.Controls.Add(Me.DTPFechaIni)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboTipoPlanilla)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = Nothing
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'TxtNumNomina
        '
        Me.TxtNumNomina.AccessibleDescription = Nothing
        Me.TxtNumNomina.AccessibleName = Nothing
        resources.ApplyResources(Me.TxtNumNomina, "TxtNumNomina")
        Me.TxtNumNomina.BackgroundImage = Nothing
        Me.TxtNumNomina.Font = Nothing
        Me.TxtNumNomina.Name = "TxtNumNomina"
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = Nothing
        Me.Label7.AccessibleName = Nothing
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Name = "Label7"
        '
        'LblTotalPlanilla
        '
        Me.LblTotalPlanilla.AccessibleDescription = Nothing
        Me.LblTotalPlanilla.AccessibleName = Nothing
        resources.ApplyResources(Me.LblTotalPlanilla, "LblTotalPlanilla")
        Me.LblTotalPlanilla.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTotalPlanilla.Name = "LblTotalPlanilla"
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.AccessibleDescription = Nothing
        Me.DTPFechaIni.AccessibleName = Nothing
        resources.ApplyResources(Me.DTPFechaIni, "DTPFechaIni")
        Me.DTPFechaIni.BackgroundImage = Nothing
        Me.DTPFechaIni.CalendarFont = Nothing
        Me.DTPFechaIni.CustomFormat = Nothing
        Me.DTPFechaIni.Font = Nothing
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Name = "DTPFechaIni"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.AccessibleDescription = Nothing
        Me.DTPFechaFin.AccessibleName = Nothing
        resources.ApplyResources(Me.DTPFechaFin, "DTPFechaFin")
        Me.DTPFechaFin.BackgroundImage = Nothing
        Me.DTPFechaFin.CalendarFont = Nothing
        Me.DTPFechaFin.CustomFormat = Nothing
        Me.DTPFechaFin.Font = Nothing
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Name = "DTPFechaFin"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = Nothing
        Me.Label3.AccessibleName = Nothing
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Font = Nothing
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'CboTipoPlanilla
        '
        Me.CboTipoPlanilla.AccessibleDescription = Nothing
        Me.CboTipoPlanilla.AccessibleName = Nothing
        Me.CboTipoPlanilla.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        resources.ApplyResources(Me.CboTipoPlanilla, "CboTipoPlanilla")
        Me.CboTipoPlanilla.BackgroundImage = Nothing
        Me.CboTipoPlanilla.Caption = ""
        Me.CboTipoPlanilla.CaptionHeight = 17
        Me.CboTipoPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoPlanilla.ColumnCaptionHeight = 17
        Me.CboTipoPlanilla.ColumnFooterHeight = 17
        Me.CboTipoPlanilla.ContentHeight = 15
        Me.CboTipoPlanilla.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoPlanilla.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoPlanilla.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoPlanilla.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoPlanilla.EditorHeight = 15
        Me.CboTipoPlanilla.Font = Nothing
        Me.CboTipoPlanilla.Images.Add(CType(resources.GetObject("CboTipoPlanilla.Images"), System.Drawing.Image))
        Me.CboTipoPlanilla.ItemHeight = 15
        Me.CboTipoPlanilla.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoPlanilla.MaxDropDownItems = CType(5, Short)
        Me.CboTipoPlanilla.MaxLength = 32767
        Me.CboTipoPlanilla.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoPlanilla.Name = "CboTipoPlanilla"
        Me.CboTipoPlanilla.RowDivider.Color = CType(resources.GetObject("resource.Color2"), System.Drawing.Color)
        Me.CboTipoPlanilla.RowDivider.Style = CType(resources.GetObject("resource.Style2"), C1.Win.C1List.LineStyleEnum)
        Me.CboTipoPlanilla.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoPlanilla.PropBag = resources.GetString("CboTipoPlanilla.PropBag")
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'frmPlanillaConductores
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.LblProcesando)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdNomina)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCalcular)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "frmPlanillaConductores"
        Me.TabControl1.ResumeLayout(False)
        Me.Ingresos.ResumeLayout(False)
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Deducciones.ResumeLayout(False)
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Configuracion.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboTipoPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDeducciones2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents LblProcesando As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdNomina As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Ingresos As System.Windows.Forms.TabPage
    Friend WithEvents TDGridIngresos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Deducciones As System.Windows.Forms.TabPage
    Friend WithEvents TDGridDeducciones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Configuracion As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrecioDomingo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioSabado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioViernes As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioJueves As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioMiercoles As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioMartes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtBolsa As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioLunes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDeduccionPolicia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtIR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdCalcular As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdBorraLinea As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblTotalPlanilla As System.Windows.Forms.Label
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboTipoPlanilla As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingDeducciones2 As System.Windows.Forms.BindingSource
End Class