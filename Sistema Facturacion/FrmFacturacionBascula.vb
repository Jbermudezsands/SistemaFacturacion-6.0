Imports System.IO

''' <summary>
''' Facturación de las salidas de báscula pendientes.
'''
''' La lógica (consultas, ticket y facturación) está en <see cref="SalidaBasculaServicio"/>
''' (Clases\Bascula\SalidaBasculaServicio.vb); el formulario solo muestra y recibe las acciones.
''' El grid TrueDBGridConsultas conserva su barra de filtros (FilterBar) y su configuración.
''' </summary>
Public Class FrmFacturacionBascula
    Private _servicio As SalidaBasculaServicio

    Private ReadOnly Property Servicio As SalidaBasculaServicio
        Get
            If _servicio Is Nothing Then _servicio = New SalidaBasculaServicio(Conexion)
            Return _servicio
        End Get
    End Property

    '=================================================================================================
    ' Carga
    '=================================================================================================
    Private Sub FrmFacturacionBascula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BasculaDisenio.EstiloRejillaC1(Me.TrueDBGridConsultas)
        Cargar()
    End Sub


    ''' <summary>Carga las salidas pendientes. Se mantiene el mismo enlace de datos del grid.</summary>
    Private Sub Cargar()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dt As DataTable = Servicio.ListarPendientes()
            Me.BindingDetalle.DataSource = dt
            Me.TrueDBGridConsultas.DataSource = Me.BindingDetalle
            Me.LblResumen.Text = dt.Rows.Count & " salida(s) de báscula pendientes de facturar"
        Catch ex As Exception
            MsgBox("No se pudo cargar el listado: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>Fila seleccionada del grid (respeta los filtros del grid). Nothing si no hay selección.</summary>
    Private Function FilaSeleccionada() As SalidaBasculaFila
        Dim fila As Integer = Me.TrueDBGridConsultas.Row
        If Me.TrueDBGridConsultas.RowCount = 0 OrElse fila < 0 Then
            MsgBox("Seleccione una salida de báscula.", MsgBoxStyle.Information, "Zeus Facturacion")
            Return Nothing
        End If
        Return SalidaBasculaFila.Desde(Function(c As String) Me.TrueDBGridConsultas.Item(fila)(c))
    End Function

    '=================================================================================================
    ' Acciones
    '=================================================================================================
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Cargar()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim f As SalidaBasculaFila = FilaSeleccionada()
        If f Is Nothing Then Exit Sub

        Quien = "SalidaBascula"
        FrmRecepcion.Show()
        FrmRecepcion.DTPFecha.Text = Format(f.Fecha, "dd/MM/yyyy")
        FrmRecepcion.CboConductor.Text = f.Nombres
        FrmRecepcion.CboCodigoProveedor.Text = f.Nombres
        FrmRecepcion.CboTipoRecepcion.Text = f.TipoRecepcion
        FrmRecepcion.TxtNumeroEnsamble.Text = f.NumeroRecepcion
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim f As SalidaBasculaFila = FilaSeleccionada()
        If f Is Nothing Then Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim reporte As New ArepRecepcion
            Dim ticket As DataTable = Servicio.ConstruirTicket(f)
            Dim emp As DataRow = Servicio.DatosEmpresa()

            If emp IsNot Nothing Then
                reporte.LblEncabezado.Text = Convert.ToString(emp("Nombre_Empresa"))
                reporte.LblDireccion.Text = Convert.ToString(emp("Direccion_Empresa"))
                If Not IsDBNull(emp("Numero_Ruc")) Then reporte.LblRuc.Text = "Numero RUC " & Convert.ToString(emp("Numero_Ruc"))
                If Not IsDBNull(emp("Ruta_Logo")) Then
                    Dim rutaLogo As String = Convert.ToString(emp("Ruta_Logo"))
                    If rutaLogo <> "" AndAlso File.Exists(rutaLogo) Then reporte.ImgLogo.Image = New System.Drawing.Bitmap(rutaLogo)
                End If
            End If

            reporte.LblLote.Text = Now.Year & "-" & Now.Month & "-" & Now.Day & "-" & f.CodCliente
            reporte.LblOrden.Text = f.NumeroRecepcion
            reporte.LblFechaOrden.Text = Format(f.Fecha, "dd/MM/yyyy")
            reporte.LblTipoCompra.Text = f.TipoRecepcion
            reporte.LblNombres.Text = f.Nombres
            reporte.LblConductor.Text = f.Conductor
            reporte.LblCedula.Text = f.Cedula
            reporte.LblPlaca.Text = f.Placa

            Dim visor As New FrmViewer()
            visor.arvMain.Document = reporte.Document
            My.Application.DoEvents()
            reporte.DataSource = ticket
            reporte.Run(False)
            visor.Show()
        Catch ex As Exception
            MsgBox("No se pudo generar el ticket: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Dim f As SalidaBasculaFila = FilaSeleccionada()
        If f Is Nothing Then Exit Sub

        If MsgBox("Esta Seguro de Generar la Factura a " & f.NumeroRecepcion, MsgBoxStyle.YesNo, "Zeus Facturacion") <> MsgBoxResult.Yes Then Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            Quien = "NumeroFacturas"
            Dim numero As String = Servicio.Facturar(f, Function() GenerarNumeroFacturaBascula(Servicio.ConsecutivoFacturaManual(), "Factura"))
            Me.Cursor = Cursors.Default

            If numero = "" Then Exit Sub ' el usuario canceló el consecutivo manual
            MsgBox("Se ha Procesado con la Compra " & numero, MsgBoxStyle.Information, "Zeus Facturacion")
            Cargar()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("No se pudo generar la factura: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        End Try
    End Sub

    ''' <summary>Anular la salida seleccionada.</summary>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As SalidaBasculaFila = FilaSeleccionada()
        If f Is Nothing Then Exit Sub

        If MsgBox("¿Desea anular la salida de báscula " & f.NumeroRecepcion & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Zeus Facturacion") <> MsgBoxResult.Yes Then Exit Sub

        Try
            Servicio.Anular(f)
            Cargar()
        Catch ex As Exception
            MsgBox("No se pudo anular: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        End Try
    End Sub

End Class
