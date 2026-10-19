Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmCreditosNuevos

    '==========================================================================================
    ' Variables públicas conservadas por compatibilidad con otros módulos del sistema
    '==========================================================================================
    Public MaximoCuotas As Double
    Public InteresDeslizamiento As Double
    Public DataSetCredito As New DataSet

    Private Const TABLA_PLAN As String = "DetalleCredito"
    Private _cargando As Boolean = True

#Region "Carga del formulario"

    Private Sub FrmCreditosNuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cargando = True
        Try
            ConfigurarGrid()
            CargarCatalogos()
            CargarConsecutivo()

            CboDias.Text = "30"
            DtpFechaINI.Value = Date.Today
            DtpFechaVencimiento.Value = Date.Today.AddMonths(1)
        Catch ex As Exception
            MostrarError("No se pudo cargar la información del formulario.", ex)
        Finally
            _cargando = False
        End Try

        SincronizarSucursal()
        SincronizarFinanciamiento()
        SincronizarProductor()
        SincronizarTipoPrestamo()
        ActualizarCuota()
        ActualizarNumeroPrestamo()
    End Sub

    Private Sub CargarCatalogos()
        '--- Sucursales (el código es la primera columna de la tabla)
        Dim sucursales As DataTable = ObtenerTabla("SELECT * FROM dbo.Sucursal ORDER BY Nombre_Sucursal")
        CboSucursal.DisplayMember = "Nombre_Sucursal"
        CboSucursal.ValueMember = sucursales.Columns(0).ColumnName
        CboSucursal.DataSource = sucursales

        '--- Fuentes de financiamiento
        Dim fuentes As DataTable = ObtenerTabla("SELECT CodigoFuente, DescripcionFuente FROM dbo.FuentesFinanciamiento ORDER BY DescripcionFuente")
        CboFinanciamiento.DisplayMember = "DescripcionFuente"
        CboFinanciamiento.ValueMember = "CodigoFuente"
        CboFinanciamiento.DataSource = fuentes

        '--- Productores (beneficiarios)
        Dim productores As DataTable = ObtenerTabla( _
            "SELECT CodProductor, " & _
            "       LTRIM(RTRIM(ISNULL(NombreProductor,'') + ' ' + ISNULL(ApellidoProductor,''))) AS NombreCompleto, " & _
            "       CAST(CodProductor AS varchar(50)) + ' - ' + LTRIM(RTRIM(ISNULL(NombreProductor,'') + ' ' + ISNULL(ApellidoProductor,''))) AS Descripcion " & _
            "FROM dbo.Productor WHERE TipoProductor = 'Productor' ORDER BY CodProductor")
        CboCodigoProductor.DisplayMember = "Descripcion"
        CboCodigoProductor.ValueMember = "CodProductor"
        CboCodigoProductor.DataSource = productores
        CboCodigoProductor.SelectedIndex = -1

        '--- Tipos de préstamo (se traen todos los parámetros para no volver a consultar)
        Dim tipos As DataTable = ObtenerTabla( _
            "SELECT CodTipoPrestamo, TipoPrestamo, InteresDiario, MaxCuotas, InteresDeslizamiento, " & _
            "       CAST(CodTipoPrestamo AS varchar(50)) + ' - ' + ISNULL(TipoPrestamo,'') AS Descripcion " & _
            "FROM dbo.TipoPrestamo ORDER BY CodTipoPrestamo")
        CboTipoPrestamos.DisplayMember = "Descripcion"
        CboTipoPrestamos.ValueMember = "CodTipoPrestamo"
        CboTipoPrestamos.DataSource = tipos
        CboTipoPrestamos.SelectedIndex = -1
    End Sub

    Private Sub CargarConsecutivo()
        Dim tabla As DataTable = ObtenerTabla("SELECT ISNULL(MAX(NumPrestamo), 0) + 1 AS Siguiente FROM dbo.Prestamo")
        TxtConsecutivo.Text = Convert.ToString(tabla.Rows(0)("Siguiente"))
    End Sub

    Private Sub ConfigurarGrid()
        With TDGridCredito
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowTemplate.Height = 26

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 95)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)
            .DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59)
            .DefaultCellStyle.Padding = New Padding(6, 0, 6, 0)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252)
        End With

        AgregarColumna("NumCuota", "Nº", 50, "0", DataGridViewContentAlignment.MiddleCenter)
        AgregarColumna("FechaPago", "Fecha de pago", 110, "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter)
        AgregarColumna("Cuota", "Principal", 120, "#,##0.00", DataGridViewContentAlignment.MiddleRight)
        AgregarColumna("Interes", "Interés", 120, "#,##0.00", DataGridViewContentAlignment.MiddleRight)
        AgregarColumna("MantoValor", "Mant. de valor", 120, "#,##0.00", DataGridViewContentAlignment.MiddleRight)
        AgregarColumna("Pago", "Total cuota", 130, "#,##0.00", DataGridViewContentAlignment.MiddleRight)
    End Sub

    Private Sub AgregarColumna(ByVal campo As String, ByVal titulo As String, ByVal pesoAncho As Single, _
                               ByVal formato As String, ByVal alineacion As DataGridViewContentAlignment)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = "Col" & campo
        col.DataPropertyName = campo
        col.HeaderText = titulo
        col.FillWeight = pesoAncho
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.DefaultCellStyle.Format = formato
        col.DefaultCellStyle.Alignment = alineacion
        TDGridCredito.Columns.Add(col)
    End Sub

#End Region

#Region "Selección de catálogos"

    Private Sub CboSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSucursal.SelectedIndexChanged
        If Not _cargando Then SincronizarSucursal()
    End Sub

    Private Sub CboFinanciamiento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboFinanciamiento.SelectedIndexChanged
        If Not _cargando Then SincronizarFinanciamiento()
    End Sub

    Private Sub CboCodigoProductor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProductor.SelectedIndexChanged
        If Not _cargando Then SincronizarProductor()
    End Sub

    Private Sub CboCodigoProductor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProductor.Leave
        'Si el usuario escribió algo que no existe en la lista, se limpia
        If CboCodigoProductor.SelectedIndex = -1 Then
            CboCodigoProductor.Text = ""
            SincronizarProductor()
        End If
    End Sub

    Private Sub CboTipoPrestamos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipoPrestamos.SelectedIndexChanged
        If Not _cargando Then SincronizarTipoPrestamo()
    End Sub

    Private Sub SincronizarSucursal()
        TxtCodSucursal.Text = ValorSeleccionado(CboSucursal)
        ActualizarNumeroPrestamo()
    End Sub

    Private Sub SincronizarFinanciamiento()
        TxtFinanciamiento.Text = ValorSeleccionado(CboFinanciamiento)
        ActualizarNumeroPrestamo()
    End Sub

    Private Sub SincronizarProductor()
        Dim fila As DataRowView = TryCast(CboCodigoProductor.SelectedItem, DataRowView)
        If fila Is Nothing Then
            TxtCodBeneficiario.Text = ""
            LblNombreProductor.Text = ""
        Else
            TxtCodBeneficiario.Text = Convert.ToString(fila("CodProductor")).Trim()
            LblNombreProductor.Text = Convert.ToString(fila("NombreCompleto"))
        End If
        ActualizarNumeroPrestamo()
    End Sub

    Private Sub SincronizarTipoPrestamo()
        Dim fila As DataRowView = TryCast(CboTipoPrestamos.SelectedItem, DataRowView)

        If fila Is Nothing Then
            TxtModalidad.Text = ""
            TxtInteresDiario.Text = ""
            MaximoCuotas = 0
            InteresDeslizamiento = 0
            TxtNumeroCuotas.Maximum = 1000
        Else
            TxtModalidad.Text = Convert.ToString(fila("TipoPrestamo"))
            TxtInteresDiario.Text = ADecimal(fila("InteresDiario")).ToString("0.######")
            MaximoCuotas = CDbl(ADecimal(fila("MaxCuotas")))
            InteresDeslizamiento = CDbl(ADecimal(fila("InteresDeslizamiento")))

            If MaximoCuotas >= 1 Then
                If TxtNumeroCuotas.Value > CDec(MaximoCuotas) Then TxtNumeroCuotas.Value = CDec(MaximoCuotas)
                TxtNumeroCuotas.Maximum = CDec(MaximoCuotas)
            Else
                TxtNumeroCuotas.Maximum = 1000
            End If
        End If

        LimpiarPlan()
    End Sub

    Private Sub ActualizarNumeroPrestamo()
        If TxtCodBeneficiario.Text = "" Then
            LblNumeroPrestamo.Text = "Préstamo Nº " & TxtConsecutivo.Text
        Else
            LblNumeroPrestamo.Text = "Préstamo Nº " & NumeroPrestamo()
        End If
    End Sub

    Private Function NumeroPrestamo() As String
        Return TxtConsecutivo.Text & "-" & TxtFinanciamiento.Text & "-" & TxtCodSucursal.Text & "-" & TxtCodBeneficiario.Text
    End Function

#End Region

#Region "Botones de búsqueda (FrmConsultas)"

    Private Sub BtnBuscarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarSucursal.Click
        SeleccionarPorCodigo(CboSucursal, AbrirConsulta("CodigoSucursal"))
    End Sub

    Private Sub BtnBuscarFinanciamiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarFinanciamiento.Click
        SeleccionarPorCodigo(CboFinanciamiento, AbrirConsulta("CodigoFinanciamiento"))
    End Sub

    Private Sub BtnBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProductor.Click
        SeleccionarPorCodigo(CboCodigoProductor, AbrirConsulta("CodigoProductor"))
    End Sub

    Private Function AbrirConsulta(ByVal tipoConsulta As String) As String
        Quien = tipoConsulta
        My.Forms.FrmConsultas.ShowDialog()
        Return Convert.ToString(My.Forms.FrmConsultas.Codigo).Trim()
    End Function

    Private Sub SeleccionarPorCodigo(ByVal combo As ComboBox, ByVal codigo As String)
        If codigo = "" Then Exit Sub
        For i As Integer = 0 To combo.Items.Count - 1
            Dim fila As DataRowView = TryCast(combo.Items(i), DataRowView)
            If fila IsNot Nothing AndAlso Convert.ToString(fila(combo.ValueMember)).Trim() = codigo Then
                combo.SelectedIndex = i
                Exit Sub
            End If
        Next
        MessageBox.Show("El código '" & codigo & "' no se encontró en la lista.", "Zeus Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Datos del plan (monto, cuotas, fechas)"

    Private Sub TxtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress, TxtInteresDiario.KeyPress
        Dim sepDecimal As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Exit Sub
        If e.KeyChar.ToString() = sepDecimal AndAlso Not CType(sender, TextBox).Text.Contains(sepDecimal) Then Exit Sub
        e.Handled = True
    End Sub

    Private Sub TxtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.Enter
        'Al entrar se quita el formato de miles para facilitar la edición
        Dim monto As Decimal = ObtenerMonto()
        TxtMonto.Text = If(monto = 0D, "", monto.ToString("0.00"))
        TxtMonto.SelectAll()
    End Sub

    Private Sub TxtMonto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.Leave
        TxtMonto.Text = ObtenerMonto().ToString("#,##0.00")
    End Sub

    Private Sub ParametrosPlan_Changed(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TxtMonto.TextChanged, TxtNumeroCuotas.ValueChanged, CboDias.TextChanged, DtpFechaINI.ValueChanged, _
                DtpFechaVencimiento.ValueChanged, ChkCadaMes.CheckedChanged, ChkCuotaNivelada.CheckedChanged, _
                OptUS.CheckedChanged, TxtInteresDiario.TextChanged
        If _cargando Then Exit Sub
        ActualizarCuota()
        LimpiarPlan()
    End Sub

    Private Sub Chkvence_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkvence.CheckedChanged
        Dim alVencimiento As Boolean = Chkvence.Checked
        DtpFechaVencimiento.Enabled = alVencimiento
        TxtNumeroCuotas.Enabled = Not alVencimiento
        CboDias.Enabled = Not alVencimiento
        ChkCadaMes.Enabled = Not alVencimiento
        ChkCuotaNivelada.Enabled = Not alVencimiento
        If alVencimiento Then TxtNumeroCuotas.Value = 1
        If _cargando Then Exit Sub
        ActualizarCuota()
        LimpiarPlan()
    End Sub

    Private Sub ActualizarCuota()
        Dim monto As Decimal = ObtenerMonto()
        Dim cuotas As Decimal = TxtNumeroCuotas.Value
        If monto > 0D AndAlso cuotas > 0D Then
            TxtCuota.Text = Redondear(monto / cuotas).ToString("#,##0.00")
        Else
            TxtCuota.Text = "0.00"
        End If
    End Sub

#End Region

#Region "Cálculo del plan de pagos"

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        If Not ValidarCalculo() Then Exit Sub

        Try
            Dim plan As DataTable = CrearTablaPlan()
            Dim monto As Decimal = ObtenerMonto()
            Dim inicio As Date = DtpFechaINI.Value.Date
            Dim tasaInteres As Decimal = ObtenerDecimal(TxtInteresDiario.Text) / 100D
            Dim tasaManto As Decimal = 0D
            If OptCS.Checked Then tasaManto = CDec(InteresDeslizamiento) / 100D 'Mantenimiento de valor solo en córdobas

            If Chkvence.Checked Then
                CalcularAlVencimiento(plan, monto, inicio, DtpFechaVencimiento.Value.Date, tasaInteres, tasaManto)
            Else
                Dim cuotas As Integer = CInt(TxtNumeroCuotas.Value)
                Dim fechas As List(Of Date) = GenerarFechas(inicio, cuotas, ObtenerEntero(CboDias.Text), ChkCadaMes.Checked)

                If ChkCuotaNivelada.Checked Then
                    CalcularNivelada(plan, monto, inicio, fechas, tasaInteres, tasaManto)
                Else
                    CalcularSobreSaldo(plan, monto, inicio, fechas, tasaInteres, tasaManto)
                End If
            End If

            If DataSetCredito.Tables.Contains(TABLA_PLAN) Then DataSetCredito.Tables.Remove(TABLA_PLAN)
            DataSetCredito.Tables.Add(plan)

            TDGridCredito.DataSource = plan
            ActualizarTotales()
        Catch ex As Exception
            MostrarError("Ocurrió un error al calcular el plan de pagos.", ex)
        End Try
    End Sub

    Private Function ValidarCalculo() As Boolean
        If CboTipoPrestamos.SelectedIndex = -1 Then
            Return Advertir("Seleccione el tipo de préstamo.", CboTipoPrestamos)
        End If
        If ObtenerMonto() <= 0D Then
            Return Advertir("El monto del préstamo debe ser mayor que cero.", TxtMonto)
        End If

        Dim interes As Decimal
        If Not Decimal.TryParse(TxtInteresDiario.Text, NumberStyles.Number, CultureInfo.CurrentCulture, interes) OrElse interes < 0D Then
            Return Advertir("El interés diario no es válido.", TxtInteresDiario)
        End If

        If Chkvence.Checked Then
            If DtpFechaVencimiento.Value.Date <= DtpFechaINI.Value.Date Then
                Return Advertir("La fecha de vencimiento debe ser posterior a la fecha inicial.", DtpFechaVencimiento)
            End If
        Else
            Dim dias As Integer = ObtenerEntero(CboDias.Text)
            If dias <= 0 Then
                Return Advertir("Los días del período del préstamo son erróneos.", CboDias)
            End If
            If ChkCadaMes.Checked AndAlso dias > 31 Then
                Return Advertir("Con 'Día fijo de cada mes' indique un día entre 1 y 31.", CboDias)
            End If
        End If
        Return True
    End Function

    ''' <summary>Pago único al vencimiento.</summary>
    Private Sub CalcularAlVencimiento(ByVal plan As DataTable, ByVal monto As Decimal, ByVal inicio As Date, ByVal vence As Date, _
                                      ByVal tasaInteres As Decimal, ByVal tasaManto As Decimal)
        Dim dias As Integer = (vence - inicio).Days
        AgregarCuota(plan, 1, monto, monto * tasaInteres * dias, monto * tasaManto * dias, vence)
    End Sub

    ''' <summary>Cuota nivelada: el interés y el mantenimiento de valor totales se reparten en partes iguales.</summary>
    Private Sub CalcularNivelada(ByVal plan As DataTable, ByVal monto As Decimal, ByVal inicio As Date, ByVal fechas As List(Of Date), _
                                 ByVal tasaInteres As Decimal, ByVal tasaManto As Decimal)
        Dim n As Integer = fechas.Count
        Dim totalInteres As Decimal = 0D
        Dim totalManto As Decimal = 0D
        Dim anterior As Date = inicio

        For i As Integer = 1 To n
            Dim dias As Integer = (fechas(i - 1) - anterior).Days
            Dim principal As Decimal = PrincipalCuota(monto, n, i)
            'Igual que el sistema original: el interés se calcula sobre el principal de cada cuota
            totalInteres += principal * tasaInteres * dias
            totalManto += principal * tasaManto * dias
            anterior = fechas(i - 1)
        Next

        Dim interesCuota As Decimal = Redondear(totalInteres / n)
        Dim mantoCuota As Decimal = Redondear(totalManto / n)

        For i As Integer = 1 To n
            AgregarCuota(plan, i, PrincipalCuota(monto, n, i), interesCuota, mantoCuota, fechas(i - 1))
        Next
    End Sub

    ''' <summary>Cuota fija de principal con interés y mantenimiento de valor sobre el saldo pendiente.</summary>
    Private Sub CalcularSobreSaldo(ByVal plan As DataTable, ByVal monto As Decimal, ByVal inicio As Date, ByVal fechas As List(Of Date), _
                                   ByVal tasaInteres As Decimal, ByVal tasaManto As Decimal)
        Dim n As Integer = fechas.Count
        Dim saldo As Decimal = monto
        Dim anterior As Date = inicio

        For i As Integer = 1 To n
            Dim dias As Integer = (fechas(i - 1) - anterior).Days
            Dim principal As Decimal = PrincipalCuota(monto, n, i)
            AgregarCuota(plan, i, principal, saldo * tasaInteres * dias, saldo * tasaManto * dias, fechas(i - 1))
            saldo -= principal
            anterior = fechas(i - 1)
        Next
    End Sub

    ''' <summary>Principal de la cuota i. La última cuota absorbe la diferencia por redondeo.</summary>
    Private Function PrincipalCuota(ByVal monto As Decimal, ByVal n As Integer, ByVal i As Integer) As Decimal
        Dim cuotaBase As Decimal = Redondear(monto / n)
        If i = n Then Return monto - cuotaBase * (n - 1)
        Return cuotaBase
    End Function

    Private Function GenerarFechas(ByVal inicio As Date, ByVal cuotas As Integer, ByVal dias As Integer, ByVal cadaMes As Boolean) As List(Of Date)
        Dim fechas As New List(Of Date)

        If cadaMes Then
            'El día indicado de cada mes, a partir del mes siguiente a la fecha inicial.
            'Si el mes no tiene ese día (ej. 31 en abril) se usa el último día del mes.
            Dim primerMes As Date = New Date(inicio.Year, inicio.Month, 1).AddMonths(1)
            For i As Integer = 0 To cuotas - 1
                Dim mes As Date = primerMes.AddMonths(i)
                Dim dia As Integer = Math.Min(dias, Date.DaysInMonth(mes.Year, mes.Month))
                fechas.Add(New Date(mes.Year, mes.Month, dia))
            Next
        Else
            'Cada X días a partir de la fecha inicial
            Dim fecha As Date = inicio
            For i As Integer = 0 To cuotas - 1
                fecha = fecha.AddDays(dias)
                fechas.Add(fecha)
            Next
        End If

        Return fechas
    End Function

    Private Function CrearTablaPlan() As DataTable
        Dim tabla As New DataTable(TABLA_PLAN)
        tabla.Columns.Add("NumCuota", GetType(Integer))
        tabla.Columns.Add("Cuota", GetType(Decimal))
        tabla.Columns.Add("Interes", GetType(Decimal))
        tabla.Columns.Add("MantoValor", GetType(Decimal))
        tabla.Columns.Add("Pago", GetType(Decimal))
        tabla.Columns.Add("FechaPago", GetType(Date))
        Return tabla
    End Function

    Private Sub AgregarCuota(ByVal plan As DataTable, ByVal numero As Integer, ByVal principal As Decimal, ByVal interes As Decimal, _
                             ByVal manto As Decimal, ByVal fecha As Date)
        Dim fila As DataRow = plan.NewRow()
        fila("NumCuota") = numero
        fila("Cuota") = Redondear(principal)
        fila("Interes") = Redondear(interes)
        fila("MantoValor") = Redondear(manto)
        fila("Pago") = Redondear(principal) + Redondear(interes) + Redondear(manto)
        fila("FechaPago") = fecha
        plan.Rows.Add(fila)
    End Sub

    Private Function PlanActual() As DataTable
        If DataSetCredito.Tables.Contains(TABLA_PLAN) Then Return DataSetCredito.Tables(TABLA_PLAN)
        Return Nothing
    End Function

    Private Function HayPlan() As Boolean
        Dim plan As DataTable = PlanActual()
        Return plan IsNot Nothing AndAlso plan.Rows.Count > 0
    End Function

    Private Sub LimpiarPlan()
        Dim plan As DataTable = PlanActual()
        If plan IsNot Nothing Then plan.Rows.Clear()
        LblTotales.Text = "Calcule el plan para ver totales"
    End Sub

    Private Sub ActualizarTotales()
        Dim plan As DataTable = PlanActual()
        If plan Is Nothing OrElse plan.Rows.Count = 0 Then
            LblTotales.Text = "Calcule el plan para ver totales"
            Exit Sub
        End If

        Dim interes As Decimal = 0D, manto As Decimal = 0D, total As Decimal = 0D
        For Each fila As DataRow In plan.Rows
            interes += CDec(fila("Interes"))
            manto += CDec(fila("MantoValor"))
            total += CDec(fila("Pago"))
        Next

        Dim simbolo As String = If(OptUS.Checked, "US$ ", "C$ ")
        LblTotales.Text = String.Format("Interés: {0}{1:#,##0.00}      Mant. valor: {0}{2:#,##0.00}      Total a pagar: {0}{3:#,##0.00}", _
                                        simbolo, interes, manto, total)
    End Sub

#End Region

#Region "Guardar"

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not ValidarGuardar() Then Exit Sub

        If MessageBox.Show("¿Desea grabar el préstamo por " & TxtMonto.Text & " a nombre de " & LblNombreProductor.Text & "?", _
                           "Zeus Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Dim numero As String = GrabarPrestamo()
            If numero <> "" Then
                MessageBox.Show("Se grabó con éxito el préstamo " & numero & ".", "Zeus Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarFormulario()
            End If
        Catch ex As Exception
            MostrarError("No se pudo grabar el préstamo. No se guardó ningún dato.", ex)
        End Try
    End Sub

    Private Function ValidarGuardar() As Boolean
        If CboSucursal.SelectedIndex = -1 Then Return Advertir("Seleccione la sucursal.", CboSucursal)
        If CboFinanciamiento.SelectedIndex = -1 Then Return Advertir("Seleccione la fuente de financiamiento.", CboFinanciamiento)
        If CboCodigoProductor.SelectedIndex = -1 Then Return Advertir("Seleccione el beneficiario.", CboCodigoProductor)
        If CboTipoPrestamos.SelectedIndex = -1 Then Return Advertir("Seleccione el tipo de préstamo.", CboTipoPrestamos)
        If Not HayPlan() Then Return Advertir("Calcule el plan de pagos antes de guardar.", BtnCalcular)
        Return True
    End Function

    ''' <summary>Graba encabezado y detalle en una sola transacción. Devuelve el número de préstamo o "" si ya existía.</summary>
    Private Function GrabarPrestamo() As String
        Dim plan As DataTable = PlanActual()
        Dim totalInteres As Decimal = 0D, totalManto As Decimal = 0D
        For Each fila As DataRow In plan.Rows
            totalInteres += CDec(fila("Interes"))
            totalManto += CDec(fila("MantoValor"))
        Next
        Dim fechaVence As Date = CDate(plan.Rows(plan.Rows.Count - 1)("FechaPago"))
        Dim fechaInicial As Date = DtpFechaINI.Value.Date

        Using cn As New SqlConnection(Conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction()
                Try
                    '--- Consecutivo tomado dentro de la transacción para evitar duplicados entre usuarios
                    Using cmd As New SqlCommand("SELECT ISNULL(MAX(IdPrestamos), 0) + 1 FROM dbo.Prestamo WITH (UPDLOCK, HOLDLOCK)", cn, tx)
                        TxtConsecutivo.Text = Convert.ToString(cmd.ExecuteScalar())
                    End Using
                    Dim numero As String = NumeroPrestamo()

                    Using cmd As New SqlCommand("SELECT COUNT(*) FROM dbo.Prestamo WHERE NumPrestamo = @NumPrestamo", cn, tx)
                        cmd.Parameters.AddWithValue("@NumPrestamo", numero)
                        If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                            tx.Rollback()
                            MessageBox.Show("Ya existe el préstamo " & numero & ".", "Zeus Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return ""
                        End If
                    End Using

                    '--- Encabezado
                    Dim sqlEncabezado As String = _
                        "INSERT INTO dbo.Prestamo (NumPrestamo, IdPrestamos, CodTipoPrestamo, CodProductor, TipoProductor, CantCuotas, PorcInteres, " & _
                        "  MontoPrestamo, MontoInteres, MontoMantoValor, FechaInicial, Moneda, FechaUltMov, FechaVencimiento, CantDias, DeCadaMes, " & _
                        "  CodSucursal, CodFuente, MontoCuota, CuotaNivelada) " & _
                        "VALUES (@NumPrestamo, @IdPrestamos, @CodTipoPrestamo, @CodProductor, 'Productor', @CantCuotas, @PorcInteres, " & _
                        "  @MontoPrestamo, @MontoInteres, @MontoMantoValor, @FechaInicial, @Moneda, @FechaUltMov, @FechaVencimiento, @CantDias, @DeCadaMes, " & _
                        "  @CodSucursal, @CodFuente, @MontoCuota, @CuotaNivelada)"

                    Using cmd As New SqlCommand(sqlEncabezado, cn, tx)
                        cmd.Parameters.AddWithValue("@NumPrestamo", numero)
                        cmd.Parameters.AddWithValue("@IdPrestamos", CInt(TxtConsecutivo.Text))
                        cmd.Parameters.AddWithValue("@CodTipoPrestamo", CboTipoPrestamos.SelectedValue)
                        cmd.Parameters.AddWithValue("@CodProductor", TxtCodBeneficiario.Text)
                        cmd.Parameters.AddWithValue("@CantCuotas", plan.Rows.Count)
                        cmd.Parameters.AddWithValue("@PorcInteres", ObtenerDecimal(TxtInteresDiario.Text))
                        cmd.Parameters.AddWithValue("@MontoPrestamo", ObtenerMonto())
                        cmd.Parameters.AddWithValue("@MontoInteres", totalInteres)
                        cmd.Parameters.AddWithValue("@MontoMantoValor", totalManto)
                        cmd.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = fechaInicial
                        cmd.Parameters.AddWithValue("@Moneda", If(OptUS.Checked, "Dolares", "Cordobas"))
                        cmd.Parameters.Add("@FechaUltMov", SqlDbType.DateTime).Value = fechaInicial
                        cmd.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = fechaVence
                        cmd.Parameters.AddWithValue("@CantDias", ObtenerEntero(CboDias.Text))
                        cmd.Parameters.AddWithValue("@DeCadaMes", If(ChkCadaMes.Checked, 1, 0))
                        cmd.Parameters.AddWithValue("@CodSucursal", TxtCodSucursal.Text)
                        cmd.Parameters.AddWithValue("@CodFuente", TxtFinanciamiento.Text)
                        cmd.Parameters.AddWithValue("@MontoCuota", CDec(plan.Rows(0)("Cuota")))
                        cmd.Parameters.AddWithValue("@CuotaNivelada", If(ChkCuotaNivelada.Checked, 1, 0))
                        cmd.ExecuteNonQuery()
                    End Using

                    '--- Detalle
                    Dim sqlDetalle As String = _
                        "INSERT INTO dbo.DetalleCredito (NumeroCredito, NumCuota, FechaPago, MantoValor, Pago, AmortizaPrincipal, InteresDevengado, " & _
                        "  Cuota, Saldo, SaldoCuota, FechaUltMov) " & _
                        "VALUES (@NumeroCredito, @NumCuota, @FechaPago, @MantoValor, @Pago, 0, @InteresDevengado, @Cuota, @Pago, @Pago, @FechaUltMov)"

                    For Each fila As DataRow In plan.Rows
                        Using cmd As New SqlCommand(sqlDetalle, cn, tx)
                            cmd.Parameters.AddWithValue("@NumeroCredito", numero)
                            cmd.Parameters.AddWithValue("@NumCuota", CInt(fila("NumCuota")))
                            cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = CDate(fila("FechaPago"))
                            cmd.Parameters.AddWithValue("@MantoValor", CDec(fila("MantoValor")))
                            cmd.Parameters.AddWithValue("@Pago", CDec(fila("Pago")))
                            cmd.Parameters.AddWithValue("@InteresDevengado", CDec(fila("Interes")))
                            cmd.Parameters.AddWithValue("@Cuota", CDec(fila("Cuota")))
                            cmd.Parameters.Add("@FechaUltMov", SqlDbType.DateTime).Value = fechaInicial
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tx.Commit()
                    Return numero
                Catch
                    Try
                        tx.Rollback()
                    Catch
                        'La transacción ya pudo haberse cerrado
                    End Try
                    Throw
                End Try
            End Using
        End Using
    End Function

    Private Sub LimpiarFormulario()
        _cargando = True
        Try
            CboCodigoProductor.SelectedIndex = -1
            CboCodigoProductor.Text = ""
            TxtMonto.Text = "0.00"
            TxtNumeroCuotas.Value = 1
            Chkvence.Checked = False
            ChkCadaMes.Checked = False
            ChkCuotaNivelada.Checked = False
            OptUS.Checked = True
            DtpFechaINI.Value = Date.Today
            CargarConsecutivo()
        Finally
            _cargando = False
        End Try

        SincronizarProductor()
        ActualizarCuota()
        LimpiarPlan()
        CboCodigoProductor.Focus()
    End Sub

#End Region

#Region "Imprimir y salir"

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If Not HayPlan() Then
            Advertir("Calcule el plan de pagos antes de imprimir.", BtnCalcular)
            Exit Sub
        End If

        Try
            Dim reporte As New ArepCuotas
            Dim empresa As DataTable = ObtenerTabla("SELECT TOP 1 * FROM dbo.DatosEmpresa")

            If empresa.Rows.Count > 0 Then
                Dim datos As DataRow = empresa.Rows(0)
                reporte.TxtTitutlo.Text = Convert.ToString(datos("Nombre_Empresa"))
                reporte.TxtDireccion.Text = Convert.ToString(datos("Direccion_Empresa"))
                If Not IsDBNull(datos("Numero_Ruc")) Then
                    reporte.TxtRuc.Text = "Numero RUC:  " & Convert.ToString(datos("Numero_Ruc"))
                End If
                If Not IsDBNull(datos("Ruta_Logo")) Then
                    Dim rutaLogo As String = Convert.ToString(datos("Ruta_Logo"))
                    If rutaLogo <> "" AndAlso IO.File.Exists(rutaLogo) Then
                        reporte.ImgLogo.Image = New System.Drawing.Bitmap(rutaLogo)
                    End If
                End If
            End If

            Dim moneda As String = If(OptUS.Checked, "Dolares", "Cordobas")
            reporte.TxtBeneficiario.Text = LblNombreProductor.Text
            reporte.TxtCreditoNo.Text = NumeroPrestamo()
            reporte.Barcode.Text = NumeroPrestamo()
            reporte.TxtModalidad.Text = TxtModalidad.Text
            reporte.TxtInteres.Text = TxtInteresDiario.Text & " %"
            reporte.TxtMonto.Text = ObtenerMonto().ToString("#,##0.00") & "  " & moneda
            reporte.TxtFechaInicial.Text = DtpFechaINI.Value.ToString("dd/MM/yyyy")
            reporte.DataSource = PlanActual()

            Dim visor As New FrmViewer()
            visor.arvMain.Document = reporte.Document
            visor.Show()
            reporte.Run(True)
        Catch ex As Exception
            MostrarError("No se pudo generar el reporte.", ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Utilidades"

    Private Function ObtenerTabla(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable
        Using cn As New SqlConnection(Conexion)
            Using cmd As New SqlCommand(sql, cn)
                If parametros IsNot Nothing AndAlso parametros.Length > 0 Then cmd.Parameters.AddRange(parametros)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    Private Function ValorSeleccionado(ByVal combo As ComboBox) As String
        If combo.SelectedIndex = -1 OrElse combo.SelectedValue Is Nothing Then Return ""
        Return Convert.ToString(combo.SelectedValue).Trim()
    End Function

    Private Function ObtenerMonto() As Decimal
        Return ObtenerDecimal(TxtMonto.Text)
    End Function

    Private Function ObtenerDecimal(ByVal texto As String) As Decimal
        Dim valor As Decimal
        If Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, valor) Then Return valor
        Return 0D
    End Function

    Private Function ObtenerEntero(ByVal texto As String) As Integer
        Dim valor As Integer
        If Integer.TryParse(texto.Trim(), valor) Then Return valor
        Return 0
    End Function

    Private Function ADecimal(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
        Return Convert.ToDecimal(valor)
    End Function

    Private Function Redondear(ByVal valor As Decimal) As Decimal
        Return Math.Round(valor, 2, MidpointRounding.AwayFromZero)
    End Function

    Private Function Advertir(ByVal mensaje As String, ByVal control As Control) As Boolean
        MessageBox.Show(mensaje, "Zeus Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        If control IsNot Nothing AndAlso control.CanFocus Then control.Focus()
        Return False
    End Function

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & Environment.NewLine & Environment.NewLine & ex.Message, "Zeus Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

#End Region

End Class
