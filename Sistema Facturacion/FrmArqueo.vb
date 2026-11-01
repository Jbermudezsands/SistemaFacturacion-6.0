Option Strict On
Option Explicit On

Imports System.Globalization

''' <summary>
''' Arqueo de caja. El formulario solo maneja la pantalla; las reglas, los cálculos y el acceso a datos
''' están en ArqueoServicio, ArqueoCalculadora y ArqueoRepositorio (carpeta Clases\Arqueo).
''' </summary>
Public Class FrmArqueo

    Private Const Titulo As String = "Zeus Facturacion"
    Private Const SinNumero As String = "-----0-----"

    Private _servicio As ArqueoServicio
    Private _cabecera As ArqueoCabecera
    Private _esperado As ArqueoEfectivoEsperado
    Private _resumen As ArqueoResumen

    Private _efectivoCordobas As DataTable
    Private _efectivoDolares As DataTable
    Private _chequesCordobas As DataTable
    Private _chequesDolares As DataTable

    Private _cargando As Boolean
    Private _permiteGrabar As Boolean = True
    Private _permiteImprimir As Boolean = True

    Private ReadOnly _colorTexto As Color = Color.FromArgb(30, 58, 95)
    Private ReadOnly _colorCuadrado As Color = Color.FromArgb(22, 163, 74)
    Private ReadOnly _colorFaltante As Color = Color.FromArgb(185, 28, 28)
    Private ReadOnly _colorSobrante As Color = Color.FromArgb(217, 119, 6)

    '=================================================================================================
    ' CICLO DE VIDA
    '=================================================================================================

    Private Sub FrmArqueo_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        ' Seguridad habilita/deshabilita los botones con Tag; se guarda su resultado y luego se combina con el estado del arqueo
        BtnGrabar.Enabled = True
        BtnImprimir.Enabled = True
        Seguridad.Bloqueo(Me, Acceso, "Arqueo de Caja")
        _permiteGrabar = BtnGrabar.Enabled
        _permiteImprimir = BtnImprimir.Enabled
        AplicarEstado()
    End Sub

    Private Sub FrmArqueo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            _servicio = New ArqueoServicio(Conexion)

            EstilizarGrid(TdbGridCordobas)
            EstilizarGrid(TdbGridDolares)
            EstilizarGrid(TdbGridChequeCordobas)
            EstilizarGrid(TdbGridChequeDolares)

            DTFecha.MaxDate = Date.Today
            CboCajero.DisplayMember = "Nombres"
            CboCajero.ValueMember = "Cod_Cajero"
            CboCajero.DataSource = _servicio.ObtenerCajeros()

            NuevoArqueo()
        Catch ex As Exception
            MostrarError("No se pudo abrir el arqueo de caja.", ex)
        End Try
    End Sub

    '=================================================================================================
    ' ACCIONES
    '=================================================================================================

    Private Sub BtnIniciar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnIniciar.Click
        Dim fondo As Decimal
        If Not LeerMonto(TxtFondoApertura.Text, fondo) Then
            Aviso("El fondo de apertura no es un número válido.")
            TxtFondoApertura.Focus()
            Return
        End If

        Dim codCajero As String = Convert.ToString(CboCajero.SelectedValue)
        If String.IsNullOrWhiteSpace(codCajero) Then
            Aviso("Seleccione un cajero.")
            CboCajero.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim cab As ArqueoCabecera = _servicio.IniciarArqueo(codCajero, DTFecha.Value.Date, fondo)
            CargarArqueo(cab)
            MessageBox.Show("Se inició el arqueo " & cab.Codigo & ". Digite las cantidades contadas y grábelo.",
                            Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As ArgumentException
            Aviso(ex.Message)
        Catch ex As InvalidOperationException
            Aviso(ex.Message)
        Catch ex As Exception
            MostrarError("No se pudo iniciar el arqueo.", ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBuscar.Click
        Quien = "Arqueo"
        My.Forms.FrmConsultas.ShowDialog()

        Dim codigo As String = Convert.ToString(My.Forms.FrmConsultas.Codigo)
        If String.IsNullOrWhiteSpace(codigo) OrElse codigo = SinNumero Then Return

        Try
            Cursor = Cursors.WaitCursor
            CargarArqueo(_servicio.AbrirArqueo(codigo))
        Catch ex As ArgumentException
            Aviso(ex.Message)
        Catch ex As InvalidOperationException
            Aviso(ex.Message)
        Catch ex As Exception
            MostrarError("No se pudo abrir el arqueo.", ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGrabar.Click
        GrabarArqueo(True)
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImprimir.Click
        If _cabecera Is Nothing Then Return

        If _cabecera.EsEditable Then
            If MessageBox.Show("El arqueo aún no está grabado. ¿Desea grabarlo ahora para imprimirlo?",
                               Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            If Not GrabarArqueo(False) Then Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Recalcular()
            ArqueoImpresion.Mostrar(_cabecera, CboCajero.Text, _resumen, _servicio.ObtenerEmpresa(), Conexion)
        Catch ex As Exception
            MostrarError("No se pudo generar el reporte del arqueo.", ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.Click
        If _cabecera IsNot Nothing AndAlso _cabecera.EsEditable Then
            If MessageBox.Show("El arqueo " & _cabecera.Codigo & " aún no se ha grabado. ¿Desea salir de él y empezar uno nuevo?" & vbCrLf &
                               "Podrá retomarlo después desde el botón de búsqueda.",
                               Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If
        End If

        NuevoArqueo()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalir.Click
        Close()
    End Sub

    Private Sub TxtFondoApertura_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtFondoApertura.Leave
        Dim fondo As Decimal
        If LeerMonto(TxtFondoApertura.Text, fondo) Then
            TxtFondoApertura.Text = fondo.ToString("N2")
        End If
    End Sub

    ''' <summary>Al digitar la cantidad de una denominación se recalcula el monto del renglón y los totales.</summary>
    Private Sub GridEfectivo_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) _
        Handles TdbGridCordobas.AfterColUpdate, TdbGridDolares.AfterColUpdate

        If _cargando OrElse e.ColIndex <> 2 Then Return

        Dim grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim valor As Decimal = LeerDecimal(grid.Columns(1).Value)
        Dim cantidad As Decimal = LeerDecimal(grid.Columns(2).Value)

        If cantidad < 0D Then
            Aviso("La cantidad no puede ser negativa.")
            cantidad = 0D
            grid.Columns(2).Text = "0"
        End If

        grid.Columns(3).Text = ArqueoCalculadora.CalcularMonto(valor, cantidad).ToString("N2")
        Recalcular()
    End Sub

    '=================================================================================================
    ' LÓGICA DE PANTALLA
    '=================================================================================================

    Private Function GrabarArqueo(ByVal confirmar As Boolean) As Boolean
        If _cabecera Is Nothing OrElse Not _cabecera.EsEditable Then Return False

        Try
            BindingDetalleCordobas.EndEdit()
            BindingDetalleDolares.EndEdit()
            Recalcular()

            If confirmar Then
                Dim mensaje As String = "¿Desea grabar el arqueo " & _cabecera.Codigo & "?" & vbCrLf &
                                        "Diferencia: " & _resumen.Diferencia.ToString("N2") & vbCrLf & vbCrLf &
                                        "Una vez grabado ya no se podrá modificar."
                If MessageBox.Show(mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return False
                End If
            End If

            Cursor = Cursors.WaitCursor
            _servicio.Guardar(_cabecera, _esperado, _efectivoCordobas, _efectivoDolares, _chequesCordobas, _chequesDolares,
                              TxtObservaciones.Text, TxtPracticadoPor.Text)

            AplicarEstado()
            Recalcular()

            If confirmar Then
                MessageBox.Show("Se grabó el arqueo " & _cabecera.Codigo & ".", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True

        Catch ex As ArgumentException
            Aviso(ex.Message)
        Catch ex As InvalidOperationException
            Aviso(ex.Message)
        Catch ex As Exception
            MostrarError("No se pudo grabar el arqueo.", ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return False
    End Function

    Private Sub NuevoArqueo()
        _cargando = True
        Try
            _cabecera = Nothing
            _esperado = Nothing
            _resumen = Nothing
            _efectivoCordobas = Nothing
            _efectivoDolares = Nothing
            _chequesCordobas = Nothing
            _chequesDolares = Nothing

            BindingDetalleCordobas.DataSource = Nothing
            BindingDetalleDolares.DataSource = Nothing
            BindingDetalleChequeCordobas.DataSource = Nothing
            BindingDetalleChequeDolares.DataSource = Nothing

            TxtNumeroArqueo.Text = SinNumero
            LblNumeroArqueo.Text = "Arqueo Nº —"
            DTFecha.Value = Date.Today
            If CboCajero.Items.Count > 0 Then CboCajero.SelectedIndex = 0
            TxtFondoApertura.Text = "0.00"
            TxtObservaciones.Clear()
            TxtPracticadoPor.Clear()
            MostrarResumen(New ArqueoResumen())
        Finally
            _cargando = False
        End Try

        AplicarEstado()
        LblEstado.ForeColor = _colorTexto
        LblEstado.Text = "Seleccione cajero y fecha para iniciar el arqueo"
    End Sub

    Private Sub CargarArqueo(ByVal cab As ArqueoCabecera)
        _cargando = True
        Try
            _cabecera = cab
            _esperado = _servicio.ObtenerEfectivoEsperado(cab)

            _efectivoCordobas = _servicio.ObtenerDetalleEfectivo(cab, ArqueoMoneda.Cordobas)
            _efectivoDolares = _servicio.ObtenerDetalleEfectivo(cab, ArqueoMoneda.Dolares)
            _chequesCordobas = _servicio.ObtenerDetalleCheques(cab, ArqueoMoneda.Cordobas)
            _chequesDolares = _servicio.ObtenerDetalleCheques(cab, ArqueoMoneda.Dolares)

            CboCajero.SelectedValue = cab.CodCajero
            If DTFecha.MaxDate < cab.Fecha Then DTFecha.MaxDate = cab.Fecha
            DTFecha.Value = cab.Fecha
            TxtFondoApertura.Text = cab.FondoApertura.ToString("N2")
            TxtNumeroArqueo.Text = cab.Codigo
            LblNumeroArqueo.Text = "Arqueo Nº " & cab.Codigo
            TxtObservaciones.Text = cab.Observaciones
            TxtPracticadoPor.Text = cab.PracticadoPor

            EnlazarEfectivo(TdbGridCordobas, BindingDetalleCordobas, _efectivoCordobas)
            EnlazarEfectivo(TdbGridDolares, BindingDetalleDolares, _efectivoDolares)
            EnlazarCheques(TdbGridChequeCordobas, BindingDetalleChequeCordobas, _chequesCordobas)
            EnlazarCheques(TdbGridChequeDolares, BindingDetalleChequeDolares, _chequesDolares)
        Finally
            _cargando = False
        End Try

        AplicarEstado()
        Recalcular()
    End Sub

    Private Sub Recalcular()
        If _cabecera Is Nothing OrElse _esperado Is Nothing Then Return

        Try
            _resumen = _servicio.Calcular(_cabecera, _esperado, _efectivoCordobas, _efectivoDolares, _chequesCordobas, _chequesDolares)
            MostrarResumen(_resumen)
        Catch ex As ArgumentException
            Aviso(ex.Message)
        End Try
    End Sub

    Private Sub MostrarResumen(ByVal resumen As ArqueoResumen)
        TxtSubTotalCordobas.Text = resumen.EfectivoContadoCordobas.ToString("N2")
        TxtSubTotalDolares.Text = resumen.EfectivoContadoDolares.ToString("N2")
        TxtTotalChequeCordobas.Text = resumen.ChequesCordobas.ToString("N2")
        TxtTotalChequeDolares.Text = resumen.ChequesDolares.ToString("N2")
        TxtSumaFacturaCordobas.Text = resumen.EfectivoEsperadoCordobas.ToString("N2")
        TxtSumaFacturaDolares.Text = resumen.EfectivoEsperadoDolares.ToString("N2")
        TxtTasaCambio.Text = resumen.TasaCambio.ToString("N4")
        TxtCordobasDolares.Text = resumen.TotalContado.ToString("N2")
        TxtValorFacturas.Text = resumen.TotalEsperado.ToString("N2")
        TxtDiferencia.Text = resumen.Diferencia.ToString("N2")

        If _cabecera Is Nothing Then
            TxtDiferencia.ForeColor = _colorTexto
            Return
        End If

        If resumen.FaltaTasaCambio Then
            TxtDiferencia.ForeColor = _colorFaltante
            LblEstado.ForeColor = _colorFaltante
            LblEstado.Text = "Falta la tasa de cambio del " & _cabecera.Fecha.ToString("dd/MM/yyyy") & ": los totales no son confiables"
        ElseIf resumen.Diferencia = 0D Then
            TxtDiferencia.ForeColor = _colorCuadrado
            LblEstado.ForeColor = _colorCuadrado
            LblEstado.Text = "Arqueo " & _cabecera.Codigo & " cuadrado"
        ElseIf resumen.Diferencia > 0D Then
            TxtDiferencia.ForeColor = _colorFaltante
            LblEstado.ForeColor = _colorFaltante
            LblEstado.Text = "Arqueo " & _cabecera.Codigo & ": faltante de C$ " & resumen.Diferencia.ToString("N2")
        Else
            TxtDiferencia.ForeColor = _colorSobrante
            LblEstado.ForeColor = _colorSobrante
            LblEstado.Text = "Arqueo " & _cabecera.Codigo & ": sobrante de C$ " & Math.Abs(resumen.Diferencia).ToString("N2")
        End If
    End Sub

    ''' <summary>Habilita o bloquea los controles según haya un arqueo abierto y si este aún admite cambios.</summary>
    Private Sub AplicarEstado()
        Dim hayArqueo As Boolean = _cabecera IsNot Nothing
        Dim editable As Boolean = hayArqueo AndAlso _cabecera.EsEditable

        CboCajero.Enabled = Not hayArqueo
        DTFecha.Enabled = Not hayArqueo
        TxtFondoApertura.Enabled = Not hayArqueo
        BtnIniciar.Enabled = Not hayArqueo

        TxtObservaciones.ReadOnly = Not editable
        TxtPracticadoPor.ReadOnly = Not editable
        TdbGridCordobas.AllowUpdate = editable
        TdbGridDolares.AllowUpdate = editable

        BtnGrabar.Enabled = editable AndAlso _permiteGrabar
        BtnImprimir.Enabled = hayArqueo AndAlso _permiteImprimir
        BtnNuevo.Enabled = hayArqueo
    End Sub

    '=================================================================================================
    ' GRIDS
    '=================================================================================================

    Private Sub EnlazarEfectivo(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal origen As BindingSource, ByVal tabla As DataTable)
        origen.DataSource = tabla
        grid.DataSource = origen

        Dim columnas As C1.Win.C1TrueDBGrid.C1DisplayColumnCollection = grid.Splits.Item(0).DisplayColumns
        columnas(0).Visible = False
        columnas(1).Width = 72
        columnas(2).Width = 72
        columnas(3).Width = 84
        columnas(1).Locked = True
        columnas(3).Locked = True

        grid.Columns(1).Caption = "Valor"
        grid.Columns(2).Caption = "Cantidad"
        grid.Columns(3).Caption = "Monto"
        grid.Columns(1).NumberFormat = "##,##0.00"
        grid.Columns(2).NumberFormat = "##,##0.00"
        grid.Columns(3).NumberFormat = "##,##0.00"
    End Sub

    Private Sub EnlazarCheques(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal origen As BindingSource, ByVal tabla As DataTable)
        origen.DataSource = tabla
        grid.DataSource = origen

        Dim columnas As C1.Win.C1TrueDBGrid.C1DisplayColumnCollection = grid.Splits.Item(0).DisplayColumns
        For i As Integer = 0 To 3
            columnas(i).Locked = True
        Next

        grid.Columns(3).NumberFormat = "##,##0.00"
    End Sub

    ''' <summary>Aplica a los grids de ComponentOne la misma paleta del resto del diseño.</summary>
    Private Sub EstilizarGrid(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        grid.AllowAddNew = False
        grid.AllowDelete = False

        grid.CaptionStyle.BackColor = Color.FromArgb(30, 58, 95)
        grid.CaptionStyle.ForeColor = Color.White
        grid.HeadingStyle.BackColor = Color.FromArgb(236, 240, 245)
        grid.HeadingStyle.ForeColor = Color.FromArgb(30, 58, 95)
        grid.OddRowStyle.BackColor = Color.White
        grid.EvenRowStyle.BackColor = Color.FromArgb(245, 247, 250)
    End Sub

    '=================================================================================================
    ' UTILIDADES
    '=================================================================================================

    Private Shared Function LeerMonto(ByVal texto As String, ByRef valor As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(texto) Then
            valor = 0D
            Return True
        End If

        If Not Decimal.TryParse(texto.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, valor) Then Return False
        Return valor >= 0D
    End Function

    Private Shared Function LeerDecimal(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D

        Dim texto As String = TryCast(valor, String)
        If texto IsNot Nothing Then
            Dim resultado As Decimal
            If Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, resultado) Then Return resultado
            Return 0D
        End If

        Return Convert.ToDecimal(valor)
    End Function

    Private Sub Aviso(ByVal mensaje As String)
        MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & vbCrLf & vbCrLf & ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Class
