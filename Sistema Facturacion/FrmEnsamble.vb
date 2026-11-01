Option Strict On
Option Explicit On
Option Infer On

Imports System.Data
Imports System.Globalization

'=====================================================================================================
'  CONTROL DE ENSAMBLES
'  Formulario delgado: toda la lógica de datos y de negocio vive en las clases de Clases\Ensamble
'  (EnsambleRepositorio, EnsambleServicio, EnsambleProcesoServicio, EnsambleImpresion) y el grid con
'  filtros en Clases\Interfaz\GridConFiltros.
'=====================================================================================================
Public Class FrmEnsamble

    '==========================================================================================
    ' Estado público conservado por compatibilidad con otros módulos (FrmConsultas, Funciones)
    '==========================================================================================
    Public CodComponente As Double
    Public RendimientoGral As Double

    Private Const TITULO As String = "Zeus Facturación"

    Private _servicio As EnsambleServicio
    Private _proceso As EnsambleProcesoServicio
    Private _impresion As EnsambleImpresion
    Private _grid As GridConFiltros
    Private _cambiandoTipo As Boolean

#Region "Servicios"

    Private ReadOnly Property Servicio() As EnsambleServicio
        Get
            If _servicio Is Nothing Then _servicio = New EnsambleServicio(Conexion)
            Return _servicio
        End Get
    End Property

    Private ReadOnly Property Proceso() As EnsambleProcesoServicio
        Get
            If _proceso Is Nothing Then _proceso = New EnsambleProcesoServicio(Conexion)
            Return _proceso
        End Get
    End Property

    Private ReadOnly Property Impresion() As EnsambleImpresion
        Get
            If _impresion Is Nothing Then _impresion = New EnsambleImpresion(Conexion)
            Return _impresion
        End Get
    End Property

#End Region

#Region "Carga del formulario"

    Private Sub FrmEnsamble_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Activated
        Seguridad.Bloqueo(Me, Acceso, "Ensamble")
    End Sub

    Private Sub FrmEnsamble_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AsegurarGrid()
            CargarBodegas()
            DTPFecha.Value = Date.Today
            ActualizarSegunTipo()
            ActualizarNumeroVisible()
        Catch ex As Exception
            MostrarError("No se pudo cargar la información del formulario.", ex)
        End Try
    End Sub

    Private Sub CargarBodegas()
        'Cada combo necesita su propia tabla; si compartieran la fuente, cambiar uno movería al otro
        Dim origen As DataTable = Servicio.ObtenerBodegas()
        Dim destino As DataTable = origen.Copy()

        CboCodigoBodega.DisplayMember = "Cod_Bodega"
        CboCodigoBodega.ValueMember = "Cod_Bodega"
        CboCodigoBodega.DataSource = origen

        CboBodegaDestino.DisplayMember = "Cod_Bodega"
        CboBodegaDestino.ValueMember = "Cod_Bodega"
        CboBodegaDestino.DataSource = destino

        If origen.Rows.Count > 0 Then
            CboCodigoBodega.SelectedIndex = 0
            CboBodegaDestino.SelectedIndex = 0
        End If

        MostrarNombreBodega(CboCodigoBodega, LblNombreBodegaOrigen)
        MostrarNombreBodega(CboBodegaDestino, LblNombreBodegaDestino)
    End Sub

    Private Shared Sub MostrarNombreBodega(ByVal combo As ComboBox, ByVal etiqueta As Label)
        Dim fila As DataRowView = TryCast(combo.SelectedItem, DataRowView)
        If fila IsNot Nothing AndAlso fila.DataView.Table.Columns.Contains("Nombre_Bodega") Then
            etiqueta.Text = Convert.ToString(fila("Nombre_Bodega"))
        Else
            etiqueta.Text = ""
        End If
    End Sub

    Private Sub AsegurarGrid()
        If _grid IsNot Nothing Then Return

        _grid = New GridConFiltros(GridComponentes, PnlFiltros)
        _grid.AgregarColumna(ComponentesGrid.Codigo, "Componente", 90, "", DataGridViewContentAlignment.MiddleLeft)
        _grid.AgregarColumna(ComponentesGrid.Descripcion, "Descripción", 250, "", DataGridViewContentAlignment.MiddleLeft)
        _grid.AgregarColumna(ComponentesGrid.Requerido, "Requerido", 70, "#,##0.####", DataGridViewContentAlignment.MiddleRight)
        _grid.AgregarColumna(ComponentesGrid.Desecho, "Desecho", 70, "#,##0.####", DataGridViewContentAlignment.MiddleRight)
        AddHandler _grid.ResumenCambiado, Sub(s As Object, e As EventArgs) ActualizarResumen()
        _grid.Enlazar(ComponentesGrid.Vacia())
    End Sub

#End Region

#Region "Grid de componentes"

    ''' <summary>
    ''' Muestra los componentes en el grid. Lo usan también las rutinas de Funciones.vb
    ''' (antes manipulaban el C1TrueDBGrid directamente).
    ''' </summary>
    Public Sub MostrarComponentes(ByVal tabla As DataTable)
        AsegurarGrid()
        _grid.Enlazar(ComponentesGrid.Normalizar(tabla))
    End Sub

    Private Sub ActualizarResumen()
        If _grid Is Nothing Then Return

        Dim total As Integer = _grid.FilasTotales
        Dim visibles As Integer = _grid.FilasVisibles
        Dim unidad As String = If(total = 1, " componente", " componentes")

        If visibles = total Then
            LblResumen.Text = total.ToString() & unidad
        Else
            LblResumen.Text = visibles.ToString() & " de " & total.ToString() & unidad
        End If
    End Sub

    Private Sub BtnSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeries.Click
        If _grid Is Nothing OrElse _grid.FilaActual Is Nothing Then Return

        Dim fila As DataRowView = _grid.FilaActual
        Dim codigo As String = Convert.ToString(fila(ComponentesGrid.Codigo))
        Dim nombre As String = Convert.ToString(fila(ComponentesGrid.Descripcion))

        My.Forms.FrmSeries.Tipo = CboTipoProducto.Text
        My.Forms.FrmSeries.CodigoProducto = codigo
        My.Forms.FrmSeries.NombreProducto = nombre
        My.Forms.FrmSeries.Numero = TxtNumeroEnsamble.Text
        My.Forms.FrmSeries.Fecha = DTPFecha.Value
        My.Forms.FrmSeries.Text = codigo & " " & nombre
        My.Forms.FrmSeries.ShowDialog()
    End Sub

#End Region

#Region "Tipo de ensamble"

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged
        If Not _cambiandoTipo Then
            CodComponente = 0
            TxtNumeroEnsamble.Text = TiposEnsamble.SinNumero
            TxtDescripcion.Text = ""
            TxtCodigo.Text = ""
            TxtCantidad.Text = "0"
        End If

        ActualizarSegunTipo()
        ActualizarNumeroVisible()
    End Sub

    ''' <summary>Cambia el tipo sin limpiar el producto, la cantidad ni los componentes.</summary>
    Private Sub CambiarTipoConservandoDatos(ByVal tipo As String)
        _cambiandoTipo = True
        Try
            CboTipoProducto.SelectedItem = tipo
        Finally
            _cambiandoTipo = False
        End Try
    End Sub

    ''' <summary>Muestra solo el botón de proceso que corresponde al tipo elegido.</summary>
    Private Sub ActualizarSegunTipo()
        Dim tipo As String = CboTipoProducto.Text

        CmdOrden.Visible = (tipo = TiposEnsamble.Orden)
        CmdProcesar.Visible = (tipo = TiposEnsamble.Recibido)
        CmdDesahacer.Visible = (tipo = TiposEnsamble.Deshacer)
        CmdEnsambles.Visible = (tipo = TiposEnsamble.Recibido)

        Select Case tipo
            Case TiposEnsamble.Orden
                EstablecerEstado("Orden de ensamble: guárdela y luego conviértala en ensamble recibido.")
            Case TiposEnsamble.Recibido
                EstablecerEstado("Ensamble recibido: sale la materia prima y entra el producto terminado.")
            Case TiposEnsamble.Deshacer
                EstablecerEstado("Deshacer: entran los componentes y sale el producto terminado.")
            Case Else
                EstablecerEstado("Seleccione el tipo de ensamble.")
        End Select
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        ActualizarNumeroVisible()
    End Sub

    Private Sub ActualizarNumeroVisible()
        Dim prefijo As String = If(CboTipoProducto.Text.Length = 0, "Ensamble", CboTipoProducto.Text)
        Dim numero As String = If(TxtNumeroEnsamble.Text = TiposEnsamble.SinNumero, "—", TxtNumeroEnsamble.Text)
        LblNumeroEnsamble.Text = prefijo & " Nº " & numero
    End Sub

    Private Sub CboCodigoBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoBodega.SelectedIndexChanged
        MostrarNombreBodega(CboCodigoBodega, LblNombreBodegaOrigen)
    End Sub

    Private Sub CboBodegaDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBodegaDestino.SelectedIndexChanged
        MostrarNombreBodega(CboBodegaDestino, LblNombreBodegaDestino)
    End Sub

#End Region

#Region "Producto y cantidad"

    Private Sub CmdAgregarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregarProducto.Click
        Ejecutar(AddressOf SeleccionarProducto)
    End Sub

    Private Sub SeleccionarProducto()
        CodComponente = 0
        Quien = "CodigoProductosEnsamble"
        My.Forms.FrmConsultas.ShowDialog()

        Dim consulta As FrmConsultas = My.Forms.FrmConsultas
        If String.IsNullOrEmpty(consulta.Codigo) Then Return

        TxtCodigo.Text = consulta.Codigo
        TxtDescripcion.Text = consulta.Descripcion
        CodComponente = consulta.CodComponente
        TxtCantidad.Text = "1"
        TxtRendimiento.Text = "1"

        Dim producto As DataRow = Servicio.ObtenerProducto(consulta.Codigo)
        If producto IsNot Nothing Then
            LblUnidadMedida.Text = Convert.ToString(producto("Unidad_Medida"))
            If Not IsDBNull(producto("Rendimiento")) Then
                RendimientoGral = Convert.ToDouble(producto("Rendimiento"))
                TxtRendimiento.Text = RendimientoGral.ToString(CultureInfo.CurrentCulture)
            End If
        End If

        MostrarComponentes(Servicio.ObtenerComponentes(CodComponente))
    End Sub

    Private Sub TxtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantidad.TextChanged
        If TxtCantidad.Text.Trim().Length = 0 Then Return

        Dim cantidad As Double
        If Not Double.TryParse(TxtCantidad.Text, NumberStyles.Number, CultureInfo.CurrentCulture, cantidad) Then
            EstablecerEstado("Es necesario digitar la cantidad.")
            Return
        End If

        Try
            MostrarComponentes(Servicio.ObtenerComponentes(CodComponente, cantidad))
        Catch ex As Exception
            EstablecerEstado("No se pudieron cargar los componentes: " & ex.Message)
        End Try

        TxtRendimiento.Text = (cantidad * RendimientoGral).ToString(CultureInfo.CurrentCulture)
    End Sub

    'Solo números y el separador decimal en cantidad y rendimiento
    Private Sub SoloNumeros_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TxtCantidad.KeyPress, TxtRendimiento.KeyPress
        Dim separador As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Return
        If e.KeyChar.ToString() = separador Then Return
        e.Handled = True
    End Sub

#End Region

#Region "Consulta de ensambles guardados"

    Private Sub BtnBuscarEnsamble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarEnsamble.Click
        If CboTipoProducto.SelectedIndex < 0 Then
            EstablecerEstado("Seleccione primero el tipo de ensamble.")
            Return
        End If
        Ejecutar(Sub() CargarDesdeConsulta("Ensambles", False))
    End Sub

    Private Sub CmdEnsambles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEnsambles.Click
        Ejecutar(Sub() CargarDesdeConsulta("Ensamble", True))
    End Sub

    ''' <summary>
    ''' Abre la consulta y carga el ensamble elegido. Con <paramref name="comoReferencia"/> el número
    ''' elegido queda como referencia del nuevo documento (ej. una orden que se va a recibir) en lugar
    ''' de ser el número del documento actual.
    ''' </summary>
    Private Sub CargarDesdeConsulta(ByVal nombreConsulta As String, ByVal comoReferencia As Boolean)
        Quien = nombreConsulta
        My.Forms.FrmConsultas.ShowDialog()

        Dim consulta As FrmConsultas = My.Forms.FrmConsultas
        If String.IsNullOrEmpty(consulta.Codigo) Then Return

        Dim producto As DataRow = Servicio.ObtenerProducto(consulta.CodProducto)
        RendimientoGral = 0
        If producto IsNot Nothing Then
            TxtDescripcion.Text = Convert.ToString(producto("Descripcion_Producto"))
            LblUnidadMedida.Text = Convert.ToString(producto("Unidad_Medida"))
            If Not IsDBNull(producto("Rendimiento")) Then RendimientoGral = Convert.ToDouble(producto("Rendimiento"))
        End If

        CodComponente = consulta.CodComponente
        TxtCodigo.Text = consulta.CodProducto
        TxtCantidad.Text = consulta.Cantidad.ToString(CultureInfo.CurrentCulture)

        If comoReferencia Then
            TxtNumero.Text = consulta.Codigo
        Else
            TxtNumeroEnsamble.Text = consulta.Codigo
        End If

        If consulta.Fecha >= DTPFecha.MinDate AndAlso consulta.Fecha <= DTPFecha.MaxDate Then
            DTPFecha.Value = consulta.Fecha
        End If

        Dim numero As Double = 0
        If consulta.Codigo <> TiposEnsamble.SinNumero Then
            Double.TryParse(consulta.Codigo, NumberStyles.Number, CultureInfo.CurrentCulture, numero)
        End If

        Dim tipo As String = If(comoReferencia, consulta.TipoEnsamble, CboTipoProducto.Text)
        MostrarComponentes(Servicio.ObtenerDetalle(numero, consulta.Fecha, tipo))
    End Sub

#End Region

#Region "Acciones"

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Limpiar()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Ejecutar(Sub()
                     Dim enc As EnsambleEncabezado = GuardarActual()
                     EstablecerEstado(enc.Tipo & " Nº " & TxtNumeroEnsamble.Text & " guardado.")
                 End Sub)
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        If MessageBox.Show("¿Está seguro de eliminar el ensamble?", TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Ejecutar(Sub()
                     Servicio.Eliminar(NumeroActual(), DTPFecha.Value.Date, CboTipoProducto.Text)
                     Limpiar()
                 End Sub)
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Ejecutar(Sub()
                     Dim enc As EnsambleEncabezado = GuardarActual()
                     Impresion.Mostrar(enc, TxtDescripcion.Text)
                 End Sub)
    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Ejecutar(Sub()
                     Dim enc As EnsambleEncabezado = GuardarActual()
                     Proceso.Procesar(enc, RendimientoGral)
                     Limpiar()
                     MessageBox.Show("Proceso terminado.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                 End Sub)
    End Sub

    Private Sub CmdDesahacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDesahacer.Click
        Ejecutar(Sub()
                     Dim enc As EnsambleEncabezado = GuardarActual()
                     Proceso.Deshacer(enc)
                     Limpiar()
                     MessageBox.Show("Proceso terminado.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                 End Sub)
    End Sub

    ''' <summary>Convierte la orden de ensamble guardada en un ensamble recibido listo para procesar.</summary>
    Private Sub CmdOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOrden.Click
        Ejecutar(Sub()
                     Dim numeroOrden As Double = NumeroActual()
                     Dim textoOrden As String = TxtNumeroEnsamble.Text
                     Dim fechaOrden As Date = DTPFecha.Value.Date
                     If numeroOrden = 0 Then
                         Throw New EnsambleNegocioException("Guarde primero la orden de ensamble.")
                     End If

                     TxtNumeroEnsamble.Text = TiposEnsamble.SinNumero
                     CambiarTipoConservandoDatos(TiposEnsamble.Recibido)
                     Try
                         GuardarActual()
                     Catch
                         CambiarTipoConservandoDatos(TiposEnsamble.Orden)
                         TxtNumeroEnsamble.Text = textoOrden
                         Throw
                     End Try

                     Servicio.Inactivar(numeroOrden, fechaOrden, TiposEnsamble.Orden)
                     EstablecerEstado("Orden Nº " & textoOrden & " convertida en ensamble recibido Nº " & TxtNumeroEnsamble.Text & ".")
                 End Sub)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Utilidades"

    ''' <summary>
    ''' Deja el formulario listo para un documento nuevo. Es pública porque
    ''' <c>LimpiaEnsamble</c> (Funciones.vb) la invoca.
    ''' </summary>
    Public Sub Limpiar()
        CodComponente = 0
        RendimientoGral = 0
        TxtCodigo.Text = ""
        TxtDescripcion.Text = ""
        TxtNumeroEnsamble.Text = TiposEnsamble.SinNumero
        TxtNumero.Text = ""
        TxtRendimiento.Text = "0"
        LblUnidadMedida.Text = ""
        TxtCantidad.Text = "1"
        MostrarComponentes(ComponentesGrid.Vacia())
    End Sub

    Private Function NumeroActual() As Double
        If TxtNumeroEnsamble.Text = TiposEnsamble.SinNumero Then Return 0
        Return LeerNumero(TxtNumeroEnsamble.Text)
    End Function

    Private Function ConstruirEncabezado() As EnsambleEncabezado
        Dim enc As New EnsambleEncabezado
        enc.Numero = NumeroActual()
        enc.Fecha = DTPFecha.Value.Date
        enc.Tipo = CboTipoProducto.Text
        enc.CodProducto = TxtCodigo.Text
        enc.Cantidad = LeerNumero(TxtCantidad.Text)
        enc.CodComponente = CodComponente
        enc.Referencias = TxtNumero.Text
        enc.BodegaOrigen = CboCodigoBodega.Text
        enc.BodegaDestino = CboBodegaDestino.Text
        enc.Rendimiento = LeerNumero(TxtRendimiento.Text)
        Return enc
    End Function

    ''' <summary>Guarda el documento en pantalla y muestra el número asignado.</summary>
    Private Function GuardarActual() As EnsambleEncabezado
        Dim enc As EnsambleEncabezado = ConstruirEncabezado()
        enc.Numero = Servicio.Guardar(enc)
        TxtNumeroEnsamble.Text = enc.Numero.ToString("0000#", CultureInfo.InvariantCulture)
        Return enc
    End Function

    Private Shared Function LeerNumero(ByVal texto As String) As Double
        Dim valor As Double
        If Double.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, valor) Then Return valor
        Return 0
    End Function

    ''' <summary>Ejecuta una acción con cursor de espera y manejo uniforme de errores.</summary>
    Private Sub Ejecutar(ByVal accion As Action)
        Dim cursorAnterior As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        PnlAcciones.Enabled = False
        Try
            accion()
        Catch ex As EnsambleNegocioException
            MessageBox.Show(ex.Message, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MostrarError("No se pudo completar la operación.", ex)
        Finally
            PnlAcciones.Enabled = True
            Me.Cursor = cursorAnterior
        End Try
    End Sub

    Private Sub EstablecerEstado(ByVal texto As String)
        LblEstado.Text = texto
    End Sub

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & Environment.NewLine & Environment.NewLine & ex.Message, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

#End Region

End Class
