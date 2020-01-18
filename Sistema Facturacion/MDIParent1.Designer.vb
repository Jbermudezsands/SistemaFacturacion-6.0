<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.NavBarFacturacionHistorico = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarComprasHistoricos = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarControl = New DevExpress.XtraNavBar.NavBarControl
        Me.NavBarProcesos = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarFacturacion = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarCompras = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarPagos = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarRecibo = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarEnsamble = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarArqueo = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarCuentasXCobrar = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarCuentasXPagar = New DevExpress.XtraNavBar.NavBarItem
        Me.Catalogos = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarClientes = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarProveedores = New DevExpress.XtraNavBar.NavBarItem
        Me.Vendedores = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarMultiBodega = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarProductos = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarLinea = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem4 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarTasaCambio = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarServicio = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarCajero = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarLiquidacion = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarTransferencias = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarRubros = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarTipoPrecio = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarTareas = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarNotaDebito = New DevExpress.XtraNavBar.NavBarItem
        Me.Proyectos = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarHistoricos = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarHistoricoFactura = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarHistoricoCompra = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarPlantillas = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarReportes = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarGeneral = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarVentas = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarInventario = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarCtasPagar = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarOpciones = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarExportar = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarImportacion = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarConfigurar = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem3 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarPersonalizar = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarInventarioFisico = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarActualiza = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarActualizacion = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarPerfiles = New DevExpress.XtraNavBar.NavBarItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuServicio = New System.Windows.Forms.ToolStripMenuItem
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuGenerar = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar
        Me.TxtUsuario = New System.Windows.Forms.TextBox
        CType(Me.NavBarControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NavBarFacturacionHistorico
        '
        Me.NavBarFacturacionHistorico.Caption = "Historico Facturacion"
        Me.NavBarFacturacionHistorico.LargeImage = CType(resources.GetObject("NavBarFacturacionHistorico.LargeImage"), System.Drawing.Image)
        Me.NavBarFacturacionHistorico.Name = "NavBarFacturacionHistorico"
        '
        'NavBarComprasHistoricos
        '
        Me.NavBarComprasHistoricos.Caption = "Historico Compras"
        Me.NavBarComprasHistoricos.LargeImage = CType(resources.GetObject("NavBarComprasHistoricos.LargeImage"), System.Drawing.Image)
        Me.NavBarComprasHistoricos.Name = "NavBarComprasHistoricos"
        '
        'NavBarControl
        '
        Me.NavBarControl.ActiveGroup = Me.NavBarProcesos
        Me.NavBarControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NavBarControl.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarProcesos, Me.Catalogos, Me.NavBarHistoricos, Me.NavBarReportes, Me.NavBarOpciones})
        Me.NavBarControl.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarClientes, Me.NavBarProveedores, Me.NavBarProductos, Me.NavBarLinea, Me.NavBarFacturacion, Me.NavBarCompras, Me.NavBarGeneral, Me.NavBarItem2, Me.NavBarConfigurar, Me.NavBarItem3, Me.NavBarItem4, Me.NavBarServicio, Me.Vendedores, Me.NavBarTasaCambio, Me.NavBarPagos, Me.NavBarRecibo, Me.NavBarEnsamble, Me.NavBarArqueo, Me.NavBarPersonalizar, Me.NavBarInventarioFisico, Me.NavBarMultiBodega, Me.NavBarCajero, Me.NavBarVentas, Me.NavBarInventario, Me.NavBarActualiza, Me.NavBarLiquidacion, Me.NavBarFacturacionHistorico, Me.NavBarComprasHistoricos, Me.NavBarHistoricoFactura, Me.NavBarHistoricoCompra, Me.NavBarPlantillas, Me.NavBarRubros, Me.NavBarTareas, Me.NavBarTransferencias, Me.NavBarTipoPrecio, Me.NavBarImportacion, Me.NavBarCuentasXCobrar, Me.NavBarNotaDebito, Me.NavBarCuentasXPagar, Me.NavBarActualizacion, Me.NavBarCtasPagar, Me.Proyectos, Me.NavBarExportar, Me.NavBarPerfiles})
        Me.NavBarControl.Location = New System.Drawing.Point(0, 71)
        Me.NavBarControl.Name = "NavBarControl"
        Me.NavBarControl.Size = New System.Drawing.Size(140, 602)
        Me.NavBarControl.TabIndex = 9
        Me.NavBarControl.Text = "NavBarControl1"
        '
        'NavBarProcesos
        '
        Me.NavBarProcesos.Caption = "Procesos"
        Me.NavBarProcesos.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarFacturacion), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarCompras), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarPagos), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarRecibo), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarEnsamble), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarArqueo), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarCuentasXCobrar), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarCuentasXPagar)})
        Me.NavBarProcesos.Name = "NavBarProcesos"
        '
        'NavBarFacturacion
        '
        Me.NavBarFacturacion.Caption = "Facturacion"
        Me.NavBarFacturacion.LargeImage = CType(resources.GetObject("NavBarFacturacion.LargeImage"), System.Drawing.Image)
        Me.NavBarFacturacion.Name = "NavBarFacturacion"
        '
        'NavBarCompras
        '
        Me.NavBarCompras.Caption = "Compras"
        Me.NavBarCompras.LargeImage = CType(resources.GetObject("NavBarCompras.LargeImage"), System.Drawing.Image)
        Me.NavBarCompras.Name = "NavBarCompras"
        '
        'NavBarPagos
        '
        Me.NavBarPagos.Caption = "Pagos"
        Me.NavBarPagos.LargeImage = CType(resources.GetObject("NavBarPagos.LargeImage"), System.Drawing.Image)
        Me.NavBarPagos.Name = "NavBarPagos"
        '
        'NavBarRecibo
        '
        Me.NavBarRecibo.Caption = "Recibo de Caja"
        Me.NavBarRecibo.LargeImage = CType(resources.GetObject("NavBarRecibo.LargeImage"), System.Drawing.Image)
        Me.NavBarRecibo.Name = "NavBarRecibo"
        '
        'NavBarEnsamble
        '
        Me.NavBarEnsamble.Caption = "Ensamble de Productos"
        Me.NavBarEnsamble.LargeImage = CType(resources.GetObject("NavBarEnsamble.LargeImage"), System.Drawing.Image)
        Me.NavBarEnsamble.Name = "NavBarEnsamble"
        '
        'NavBarArqueo
        '
        Me.NavBarArqueo.Caption = "Arqueo de Caja"
        Me.NavBarArqueo.LargeImage = CType(resources.GetObject("NavBarArqueo.LargeImage"), System.Drawing.Image)
        Me.NavBarArqueo.Name = "NavBarArqueo"
        '
        'NavBarCuentasXCobrar
        '
        Me.NavBarCuentasXCobrar.Caption = "Cuentas x Cobrar"
        Me.NavBarCuentasXCobrar.LargeImage = CType(resources.GetObject("NavBarCuentasXCobrar.LargeImage"), System.Drawing.Image)
        Me.NavBarCuentasXCobrar.Name = "NavBarCuentasXCobrar"
        '
        'NavBarCuentasXPagar
        '
        Me.NavBarCuentasXPagar.Caption = "Cuentas x Pagar"
        Me.NavBarCuentasXPagar.LargeImage = CType(resources.GetObject("NavBarCuentasXPagar.LargeImage"), System.Drawing.Image)
        Me.NavBarCuentasXPagar.Name = "NavBarCuentasXPagar"
        '
        'Catalogos
        '
        Me.Catalogos.Caption = "Catalogos"
        Me.Catalogos.Expanded = True
        Me.Catalogos.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarClientes), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarProveedores), New DevExpress.XtraNavBar.NavBarItemLink(Me.Vendedores), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarMultiBodega), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarProductos), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarLinea), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem4), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarTasaCambio), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarServicio), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarCajero), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarLiquidacion), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarTransferencias), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarRubros), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarTipoPrecio), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarTareas), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarNotaDebito), New DevExpress.XtraNavBar.NavBarItemLink(Me.Proyectos)})
        Me.Catalogos.Name = "Catalogos"
        '
        'NavBarClientes
        '
        Me.NavBarClientes.Caption = "Clientes"
        Me.NavBarClientes.LargeImage = CType(resources.GetObject("NavBarClientes.LargeImage"), System.Drawing.Image)
        Me.NavBarClientes.Name = "NavBarClientes"
        '
        'NavBarProveedores
        '
        Me.NavBarProveedores.Caption = "Proveedores"
        Me.NavBarProveedores.LargeImage = CType(resources.GetObject("NavBarProveedores.LargeImage"), System.Drawing.Image)
        Me.NavBarProveedores.Name = "NavBarProveedores"
        '
        'Vendedores
        '
        Me.Vendedores.Caption = "Vendedores"
        Me.Vendedores.LargeImage = CType(resources.GetObject("Vendedores.LargeImage"), System.Drawing.Image)
        Me.Vendedores.Name = "Vendedores"
        '
        'NavBarMultiBodega
        '
        Me.NavBarMultiBodega.Caption = "Bodegas"
        Me.NavBarMultiBodega.LargeImage = CType(resources.GetObject("NavBarMultiBodega.LargeImage"), System.Drawing.Image)
        Me.NavBarMultiBodega.Name = "NavBarMultiBodega"
        '
        'NavBarProductos
        '
        Me.NavBarProductos.Caption = "Productos"
        Me.NavBarProductos.LargeImage = CType(resources.GetObject("NavBarProductos.LargeImage"), System.Drawing.Image)
        Me.NavBarProductos.Name = "NavBarProductos"
        '
        'NavBarLinea
        '
        Me.NavBarLinea.Caption = "Linea de Productos"
        Me.NavBarLinea.LargeImage = CType(resources.GetObject("NavBarLinea.LargeImage"), System.Drawing.Image)
        Me.NavBarLinea.Name = "NavBarLinea"
        '
        'NavBarItem4
        '
        Me.NavBarItem4.Caption = "Tabla de Impuestos"
        Me.NavBarItem4.LargeImage = CType(resources.GetObject("NavBarItem4.LargeImage"), System.Drawing.Image)
        Me.NavBarItem4.Name = "NavBarItem4"
        '
        'NavBarTasaCambio
        '
        Me.NavBarTasaCambio.Caption = "Tasa de Cambio"
        Me.NavBarTasaCambio.LargeImage = CType(resources.GetObject("NavBarTasaCambio.LargeImage"), System.Drawing.Image)
        Me.NavBarTasaCambio.Name = "NavBarTasaCambio"
        '
        'NavBarServicio
        '
        Me.NavBarServicio.Caption = "Servicios"
        Me.NavBarServicio.LargeImage = CType(resources.GetObject("NavBarServicio.LargeImage"), System.Drawing.Image)
        Me.NavBarServicio.Name = "NavBarServicio"
        '
        'NavBarCajero
        '
        Me.NavBarCajero.Caption = "Cajeros"
        Me.NavBarCajero.LargeImage = CType(resources.GetObject("NavBarCajero.LargeImage"), System.Drawing.Image)
        Me.NavBarCajero.Name = "NavBarCajero"
        '
        'NavBarLiquidacion
        '
        Me.NavBarLiquidacion.Caption = "Liquidacion"
        Me.NavBarLiquidacion.LargeImage = CType(resources.GetObject("NavBarLiquidacion.LargeImage"), System.Drawing.Image)
        Me.NavBarLiquidacion.Name = "NavBarLiquidacion"
        '
        'NavBarTransferencias
        '
        Me.NavBarTransferencias.Caption = "Transferencia Bodegas"
        Me.NavBarTransferencias.LargeImage = CType(resources.GetObject("NavBarTransferencias.LargeImage"), System.Drawing.Image)
        Me.NavBarTransferencias.Name = "NavBarTransferencias"
        '
        'NavBarRubros
        '
        Me.NavBarRubros.Caption = "Rubros"
        Me.NavBarRubros.LargeImage = CType(resources.GetObject("NavBarRubros.LargeImage"), System.Drawing.Image)
        Me.NavBarRubros.Name = "NavBarRubros"
        '
        'NavBarTipoPrecio
        '
        Me.NavBarTipoPrecio.Caption = "Tipo de Precios"
        Me.NavBarTipoPrecio.LargeImage = CType(resources.GetObject("NavBarTipoPrecio.LargeImage"), System.Drawing.Image)
        Me.NavBarTipoPrecio.Name = "NavBarTipoPrecio"
        '
        'NavBarTareas
        '
        Me.NavBarTareas.Caption = "Tareas"
        Me.NavBarTareas.LargeImage = CType(resources.GetObject("NavBarTareas.LargeImage"), System.Drawing.Image)
        Me.NavBarTareas.Name = "NavBarTareas"
        '
        'NavBarNotaDebito
        '
        Me.NavBarNotaDebito.Caption = "Nota Debito,Credito"
        Me.NavBarNotaDebito.LargeImage = CType(resources.GetObject("NavBarNotaDebito.LargeImage"), System.Drawing.Image)
        Me.NavBarNotaDebito.Name = "NavBarNotaDebito"
        '
        'Proyectos
        '
        Me.Proyectos.Caption = "Proyectos"
        Me.Proyectos.LargeImage = CType(resources.GetObject("Proyectos.LargeImage"), System.Drawing.Image)
        Me.Proyectos.Name = "Proyectos"
        '
        'NavBarHistoricos
        '
        Me.NavBarHistoricos.Caption = "Historicos"
        Me.NavBarHistoricos.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarHistoricoFactura), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarHistoricoCompra), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarPlantillas)})
        Me.NavBarHistoricos.Name = "NavBarHistoricos"
        '
        'NavBarHistoricoFactura
        '
        Me.NavBarHistoricoFactura.Caption = "Historico Facturacion"
        Me.NavBarHistoricoFactura.LargeImage = CType(resources.GetObject("NavBarHistoricoFactura.LargeImage"), System.Drawing.Image)
        Me.NavBarHistoricoFactura.Name = "NavBarHistoricoFactura"
        '
        'NavBarHistoricoCompra
        '
        Me.NavBarHistoricoCompra.Caption = "Historico Compras"
        Me.NavBarHistoricoCompra.LargeImage = CType(resources.GetObject("NavBarHistoricoCompra.LargeImage"), System.Drawing.Image)
        Me.NavBarHistoricoCompra.Name = "NavBarHistoricoCompra"
        '
        'NavBarPlantillas
        '
        Me.NavBarPlantillas.Caption = "Plantillas de Ventas/Compras"
        Me.NavBarPlantillas.LargeImage = CType(resources.GetObject("NavBarPlantillas.LargeImage"), System.Drawing.Image)
        Me.NavBarPlantillas.Name = "NavBarPlantillas"
        '
        'NavBarReportes
        '
        Me.NavBarReportes.Caption = "Reportes"
        Me.NavBarReportes.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarGeneral), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarVentas), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarInventario), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarCtasPagar)})
        Me.NavBarReportes.Name = "NavBarReportes"
        '
        'NavBarGeneral
        '
        Me.NavBarGeneral.Caption = "Reportes Generales"
        Me.NavBarGeneral.LargeImage = CType(resources.GetObject("NavBarGeneral.LargeImage"), System.Drawing.Image)
        Me.NavBarGeneral.Name = "NavBarGeneral"
        '
        'NavBarVentas
        '
        Me.NavBarVentas.Caption = "Reportes Ventas/Compras"
        Me.NavBarVentas.LargeImage = CType(resources.GetObject("NavBarVentas.LargeImage"), System.Drawing.Image)
        Me.NavBarVentas.Name = "NavBarVentas"
        '
        'NavBarInventario
        '
        Me.NavBarInventario.Caption = "Reportes Inventario"
        Me.NavBarInventario.LargeImage = CType(resources.GetObject("NavBarInventario.LargeImage"), System.Drawing.Image)
        Me.NavBarInventario.Name = "NavBarInventario"
        '
        'NavBarCtasPagar
        '
        Me.NavBarCtasPagar.Caption = "Reportes Cuentas x Cobrar"
        Me.NavBarCtasPagar.LargeImage = CType(resources.GetObject("NavBarCtasPagar.LargeImage"), System.Drawing.Image)
        Me.NavBarCtasPagar.Name = "NavBarCtasPagar"
        '
        'NavBarOpciones
        '
        Me.NavBarOpciones.Caption = "Opciones"
        Me.NavBarOpciones.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarExportar), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarImportacion), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem2), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarConfigurar), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem3), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarPersonalizar), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarInventarioFisico), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarActualiza), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarActualizacion), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarPerfiles)})
        Me.NavBarOpciones.Name = "NavBarOpciones"
        '
        'NavBarExportar
        '
        Me.NavBarExportar.Caption = "Exportar Excel"
        Me.NavBarExportar.LargeImage = CType(resources.GetObject("NavBarExportar.LargeImage"), System.Drawing.Image)
        Me.NavBarExportar.Name = "NavBarExportar"
        '
        'NavBarImportacion
        '
        Me.NavBarImportacion.Caption = "Importacion"
        Me.NavBarImportacion.LargeImage = CType(resources.GetObject("NavBarImportacion.LargeImage"), System.Drawing.Image)
        Me.NavBarImportacion.Name = "NavBarImportacion"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Caption = "Usuarios"
        Me.NavBarItem2.LargeImage = CType(resources.GetObject("NavBarItem2.LargeImage"), System.Drawing.Image)
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'NavBarConfigurar
        '
        Me.NavBarConfigurar.Caption = "Configurar"
        Me.NavBarConfigurar.LargeImage = CType(resources.GetObject("NavBarConfigurar.LargeImage"), System.Drawing.Image)
        Me.NavBarConfigurar.Name = "NavBarConfigurar"
        '
        'NavBarItem3
        '
        Me.NavBarItem3.Caption = "Contabilizar"
        Me.NavBarItem3.LargeImage = CType(resources.GetObject("NavBarItem3.LargeImage"), System.Drawing.Image)
        Me.NavBarItem3.Name = "NavBarItem3"
        Me.NavBarItem3.Visible = False
        '
        'NavBarPersonalizar
        '
        Me.NavBarPersonalizar.Caption = "Personalizar"
        Me.NavBarPersonalizar.LargeImage = CType(resources.GetObject("NavBarPersonalizar.LargeImage"), System.Drawing.Image)
        Me.NavBarPersonalizar.Name = "NavBarPersonalizar"
        '
        'NavBarInventarioFisico
        '
        Me.NavBarInventarioFisico.Caption = "Inventario Fisico"
        Me.NavBarInventarioFisico.LargeImage = CType(resources.GetObject("NavBarInventarioFisico.LargeImage"), System.Drawing.Image)
        Me.NavBarInventarioFisico.Name = "NavBarInventarioFisico"
        '
        'NavBarActualiza
        '
        Me.NavBarActualiza.Caption = "Ajustes"
        Me.NavBarActualiza.LargeImage = CType(resources.GetObject("NavBarActualiza.LargeImage"), System.Drawing.Image)
        Me.NavBarActualiza.Name = "NavBarActualiza"
        '
        'NavBarActualizacion
        '
        Me.NavBarActualizacion.Caption = "Actualizacion"
        Me.NavBarActualizacion.LargeImage = CType(resources.GetObject("NavBarActualizacion.LargeImage"), System.Drawing.Image)
        Me.NavBarActualizacion.Name = "NavBarActualizacion"
        '
        'NavBarPerfiles
        '
        Me.NavBarPerfiles.Caption = "Perfiles y Accesos"
        Me.NavBarPerfiles.LargeImage = CType(resources.GetObject("NavBarPerfiles.LargeImage"), System.Drawing.Image)
        Me.NavBarPerfiles.Name = "NavBarPerfiles"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuServicio, Me.OpcionesToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem7, Me.MenuGenerar, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 78)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(134, 74)
        Me.ToolStripMenuItem5.Text = "&Clientes"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(126, 74)
        Me.ToolStripMenuItem6.Text = "&Productos"
        '
        'ToolStripMenuServicio
        '
        Me.ToolStripMenuServicio.Image = CType(resources.GetObject("ToolStripMenuServicio.Image"), System.Drawing.Image)
        Me.ToolStripMenuServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuServicio.Name = "ToolStripMenuServicio"
        Me.ToolStripMenuServicio.Size = New System.Drawing.Size(118, 74)
        Me.ToolStripMenuServicio.Text = "&Servicios"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.Image = CType(resources.GetObject("OpcionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpcionesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(136, 74)
        Me.OpcionesToolStripMenuItem.Text = "&Calculadora"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(130, 74)
        Me.ToolStripMenuItem1.Text = "&Liquidacion"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(131, 74)
        Me.ToolStripMenuItem7.Text = "&Usuarios "
        '
        'MenuGenerar
        '
        Me.MenuGenerar.Image = CType(resources.GetObject("MenuGenerar.Image"), System.Drawing.Image)
        Me.MenuGenerar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuGenerar.Name = "MenuGenerar"
        Me.MenuGenerar.Size = New System.Drawing.Size(138, 74)
        Me.MenuGenerar.Text = "Configurar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(92, 74)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 676)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.Size = New System.Drawing.Size(1028, 22)
        Me.C1StatusBar1.TabIndex = 12
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(505, 199)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.TxtUsuario.TabIndex = 14
        Me.TxtUsuario.Text = "Desconocido"
        Me.TxtUsuario.Visible = False
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1028, 698)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.NavBarControl)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ZEUS FACTURACION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.NavBarControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NavBarControl As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents Catalogos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarProcesos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuGenerar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavBarProveedores As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarProductos As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarLinea As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarFacturacion As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarCompras As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarReportes As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarOpciones As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGeneral As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarConfigurar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem3 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarServicio As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Vendedores As DevExpress.XtraNavBar.NavBarItem
    Public WithEvents NavBarClientes As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarTasaCambio As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarPagos As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarRecibo As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarEnsamble As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarArqueo As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarPersonalizar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarInventarioFisico As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarMultiBodega As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarCajero As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarVentas As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarInventario As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarActualiza As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents NavBarLiquidacion As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ToolStripMenuServicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavBarFacturacionHistorico As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarComprasHistoricos As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarHistoricos As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarHistoricoFactura As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarHistoricoCompra As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarPlantillas As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarRubros As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarTareas As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarTransferencias As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarTipoPrecio As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarImportacion As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents NavBarCuentasXCobrar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarNotaDebito As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarCuentasXPagar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarActualizacion As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarCtasPagar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Proyectos As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarExportar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarPerfiles As DevExpress.XtraNavBar.NavBarItem

End Class
