Public Class FrmDeduccionPlanilla


    Private _TipoPlanilla As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _NumeroPlanilla As String
    Private MenuSeleccion As New ContextMenuStrip

    Private Sub ConfigurarMenuSeleccion()

        MenuSeleccion.Items.Clear()

        Dim itemSeleccionar As New ToolStripMenuItem("Seleccionar todos")
        Dim itemDesmarcar As New ToolStripMenuItem("Desmarcar todos")
        Dim itemInvertir As New ToolStripMenuItem("Invertir selección")

        AddHandler itemSeleccionar.Click, AddressOf SeleccionarTodos
        AddHandler itemDesmarcar.Click, AddressOf DesmarcarTodos
        AddHandler itemInvertir.Click, AddressOf InvertirSeleccion

        MenuSeleccion.Items.Add(itemSeleccionar)
        MenuSeleccion.Items.Add(itemDesmarcar)
        MenuSeleccion.Items.Add(itemInvertir)

        Me.dgvDetalle.ContextMenuStrip = MenuSeleccion

    End Sub

    Private Sub SeleccionarTodos(ByVal sender As Object, ByVal e As EventArgs)

        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

            If fila.IsNewRow Then Continue For

            fila.Cells("colSelec").Value = True

        Next

    End Sub

    Private Sub DesmarcarTodos(ByVal sender As Object, ByVal e As EventArgs)

        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

            If fila.IsNewRow Then Continue For

            fila.Cells("colSelec").Value = False

        Next

    End Sub

    Private Sub InvertirSeleccion(ByVal sender As Object, ByVal e As EventArgs)

        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

            If fila.IsNewRow Then Continue For

            Dim seleccionado As Boolean = False

            If fila.Cells("colSelec").Value IsNot Nothing Then
                seleccionado = Convert.ToBoolean(
                fila.Cells("colSelec").Value)
            End If

            fila.Cells("colSelec").Value = Not seleccionado

        Next

    End Sub


    Private Sub ConfigurarGrid()

        With Me.dgvDetalle

            .AutoGenerateColumns = False
            .Columns.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False

            '--------------------------------------------------
            ' SELECCION
            '--------------------------------------------------
            Dim colSeleccion As New DataGridViewCheckBoxColumn
            colSeleccion.Name = "colSelec"
            colSeleccion.HeaderText = ""
            colSeleccion.Width = 35
            colSeleccion.ReadOnly = False
            colSeleccion.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colSeleccion)

            '--------------------------------------------------
            ' CODIGO BENEFICIARIO
            '--------------------------------------------------
            Dim colCodigo As New DataGridViewTextBoxColumn
            colCodigo.Name = "colCodBeneficiario"
            colCodigo.HeaderText = "CODBENEFICIARIO"
            colCodigo.Width = 110
            colCodigo.ReadOnly = True
            colCodigo.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colCodigo)

            '--------------------------------------------------
            ' BENEFICIARIO
            '--------------------------------------------------
            Dim colBeneficiario As New DataGridViewTextBoxColumn
            colBeneficiario.Name = "colTercero"
            colBeneficiario.HeaderText = "BENEFICIARIO"
            colBeneficiario.Width = 280
            colBeneficiario.ReadOnly = True
            colBeneficiario.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colBeneficiario)

            '--------------------------------------------------
            ' TIPO PRODUCTOR
            '--------------------------------------------------
            Dim colTipo As New DataGridViewTextBoxColumn
            colTipo.Name = "colTipoProductor"
            colTipo.HeaderText = "TIPO"
            colTipo.Width = 90
            colTipo.ReadOnly = True
            colTipo.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colTipo)

            '--------------------------------------------------
            ' CANTIDAD
            '--------------------------------------------------
            Dim colCantidad As New DataGridViewTextBoxColumn
            colCantidad.Name = "colCantidad"
            colCantidad.HeaderText = "CANTIDAD"
            colCantidad.Width = 100
            colCantidad.ReadOnly = True
            colCantidad.DefaultCellStyle.Format = "##,##0.000"
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colCantidad.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colCantidad)

            '--------------------------------------------------
            ' MONTO
            '--------------------------------------------------
            Dim colMonto As New DataGridViewTextBoxColumn
            colMonto.Name = "colPrecioFicha"
            colMonto.HeaderText = "MONTO"
            colMonto.Width = 110
            colMonto.ReadOnly = True
            colMonto.DefaultCellStyle.Format = "##,##0.000"
            colMonto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colMonto.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colMonto)

            '--------------------------------------------------
            ' TOTAL DEDUCCION
            '--------------------------------------------------
            Dim colTotal As New DataGridViewTextBoxColumn
            colTotal.Name = "colTotalDeducc"
            colTotal.HeaderText = "TOTAL DEDUCC."
            colTotal.Width = 120
            colTotal.ReadOnly = True
            colTotal.DefaultCellStyle.Format = "##,##0.00"
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colTotal.SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Add(colTotal)

        End With

    End Sub
    Private Sub CargarDetalleNomina()

        Me.dgvDetalle.Rows.Clear()

        If String.IsNullOrWhiteSpace(Me.NumeroPlanilla) Then
            Exit Sub
        End If

        Dim SqlString As String =
        "SELECT CodProductor, TipoProductor, Nombres, Total " &
        "FROM Detalle_Nomina " &
        "WHERE NumNomina = @NumNomina " &
        "ORDER BY CodProductor"

        Try

            Using cn As New SqlClient.SqlConnection(Conexion)

                Using cmd As New SqlClient.SqlCommand(SqlString, cn)

                    cmd.Parameters.AddWithValue("@NumNomina", Me.NumeroPlanilla)

                    cn.Open()

                    Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader()

                        While dr.Read()

                            Dim fila As Integer = Me.dgvDetalle.Rows.Add()

                            Me.dgvDetalle.Rows(fila).Cells("colSelec").Value = False

                            Me.dgvDetalle.Rows(fila).Cells("colCodBeneficiario").Value =
                            dr("CodProductor").ToString()

                            If IsDBNull(dr("Nombres")) Then
                                Me.dgvDetalle.Rows(fila).Cells("colTercero").Value = ""
                            Else
                                Me.dgvDetalle.Rows(fila).Cells("colTercero").Value =
                                dr("Nombres").ToString()
                            End If

                            If IsDBNull(dr("TipoProductor")) Then
                                Me.dgvDetalle.Rows(fila).Cells("colTipoProductor").Value = ""
                            Else
                                Me.dgvDetalle.Rows(fila).Cells("colTipoProductor").Value =
                                dr("TipoProductor").ToString()
                            End If

                            Dim cantidad As Double = 0

                            If Not IsDBNull(dr("Total")) Then
                                cantidad = Convert.ToDouble(dr("Total"))
                            End If

                            Me.dgvDetalle.Rows(fila).Cells("colCantidad").Value = cantidad
                            Me.dgvDetalle.Rows(fila).Cells("colPrecioFicha").Value = 0
                            Me.dgvDetalle.Rows(fila).Cells("colTotalDeducc").Value = 0

                        End While

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MsgBox("Error al cargar el detalle de la planilla: " & ex.Message,
               MsgBoxStyle.Critical, "Zeus Acopio")

        End Try

    End Sub

    Public Property TipoPlanilla As String
        Get
            Return _TipoPlanilla
        End Get
        Set(ByVal value As String)
            _TipoPlanilla = value
        End Set
    End Property

    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(ByVal value As Date)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(ByVal value As Date)
            _FechaHasta = value
        End Set
    End Property

    Public Property NumeroPlanilla As String
        Get
            Return _NumeroPlanilla
        End Get
        Set(ByVal value As String)
            _NumeroPlanilla = value
        End Set
    End Property

    Private Sub CargarTiposDeduccion()

        Me.cboTipoDeduccion.Items.Clear()

        Me.cboTipoDeduccion.Items.Add("Anticipo")
        Me.cboTipoDeduccion.Items.Add("Transporte")
        Me.cboTipoDeduccion.Items.Add("Fondos")
        Me.cboTipoDeduccion.Items.Add("Inseminacion")
        Me.cboTipoDeduccion.Items.Add("Trazabilidad")
        Me.cboTipoDeduccion.Items.Add("OtrasDeducciones")

        Me.cboTipoDeduccion.SelectedIndex = -1

    End Sub

    Private Sub CargarTiposCalculo()

        Me.cboTipo.Items.Clear()

        Me.cboTipo.Items.Add("Valor Fijo")
        Me.cboTipo.Items.Add("Valor por Unidad")
        Me.cboTipo.Items.Add("Valor Distribuido entre unidades")

        Me.cboTipo.SelectedIndex = -1

    End Sub

    Private Sub CargarRedondeos()

        Me.cboRedondeo.Items.Clear()

        Me.cboRedondeo.Items.Add("2")
        Me.cboRedondeo.Items.Add("3")

        Me.cboRedondeo.SelectedIndex = 0

    End Sub

    Private Function ObtenerCampoDeduccion(ByVal tipoDeduccion As String) As String

        Select Case tipoDeduccion

            Case "Anticipo"
                Return "Anticipo"

            Case "Transporte"
                Return "Transporte"

            Case "Fondos"
                Return "Pulperia"

            Case "Inseminacion"
                Return "Inseminacion"

            Case "Trazabilidad"
                Return "Trazabilidad"

            Case "OtrasDeducciones"
                Return "OtrasDeducciones"

            Case Else
                Return ""

        End Select

    End Function

    Private Sub CargarDeduccionActual()

        Dim TipoDeduccion As String = Me.cboTipoDeduccion.Text

        If String.IsNullOrWhiteSpace(TipoDeduccion) Then
            Exit Sub
        End If

        Dim CampoDeduccion As String = ObtenerCampoDeduccion(TipoDeduccion)

        If CampoDeduccion = "" Then
            Exit Sub
        End If

        Try

            '==========================================================
            ' CARGAR LOS VALORES ACTUALES DE Deducciones_Planilla
            '==========================================================

            Dim SqlString As String =
            "SELECT CodProductor, TipoProductor, " &
            "Anticipo, Transporte, Pulperia, Inseminacion, " &
            "Trazabilidad, OtrasDeducciones " &
            "FROM Deducciones_Planilla " &
            "WHERE NumNomina = @NumNomina " &
            "ORDER BY CodProductor"

            Using cn As New SqlClient.SqlConnection(Conexion)

                Using cmd As New SqlClient.SqlCommand(SqlString, cn)

                    cmd.Parameters.AddWithValue("@NumNomina", Me.NumeroPlanilla)

                    cn.Open()

                    Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader()

                        While dr.Read()

                            Dim Codigo As String = dr("CodProductor").ToString()
                            Dim TipoProductor As String = dr("TipoProductor").ToString()

                            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                                If fila.IsNewRow Then
                                    Continue For
                                End If

                                If fila.Cells("colCodBeneficiario").Value Is Nothing Then
                                    Continue For
                                End If

                                If fila.Cells("colTipoProductor").Value Is Nothing Then
                                    Continue For
                                End If

                                If fila.Cells("colCodBeneficiario").Value.ToString() = Codigo AndAlso
                               fila.Cells("colTipoProductor").Value.ToString() = TipoProductor Then

                                    Dim Valor As Double = 0

                                    If Not IsDBNull(dr(CampoDeduccion)) Then
                                        Valor = Convert.ToDouble(dr(CampoDeduccion))
                                    End If

                                    fila.Cells("colTotalDeducc").Value = Valor

                                    Exit For

                                End If

                            Next

                        End While

                    End Using

                End Using

            End Using


            '==========================================================
            ' BUSCAR EL ULTIMO CALCULO REALIZADO
            '==========================================================

            Dim SqlCalculo As String =
            "SELECT TOP 1 TipoCalculo, Monto, Decimales, UnidadesDistribuidas " &
            "FROM Deducciones_Planilla_Calculo " &
            "WHERE NumNomina = @NumNomina " &
            "AND TipoDeduccion = @TipoDeduccion " &
            "ORDER BY IdCalculo DESC"

            Using cn As New SqlClient.SqlConnection(Conexion)

                Using cmd As New SqlClient.SqlCommand(SqlCalculo, cn)

                    cmd.Parameters.AddWithValue("@NumNomina", Me.NumeroPlanilla)
                    cmd.Parameters.AddWithValue("@TipoDeduccion", TipoDeduccion)

                    cn.Open()

                    Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            If Not IsDBNull(dr("TipoCalculo")) Then
                                Me.cboTipo.Text = dr("TipoCalculo").ToString()
                            End If

                            If Not IsDBNull(dr("Monto")) Then
                                Me.txtMonto.Text = Convert.ToDouble(dr("Monto")).ToString("0.000")
                            Else
                                Me.txtMonto.Clear()
                            End If

                            If Not IsDBNull(dr("Decimales")) Then

                                Dim Decimales As Integer = Convert.ToInt32(dr("Decimales"))

                                If Decimales = 2 Then
                                    Me.cboRedondeo.Text = "2"
                                ElseIf Decimales = 3 Then
                                    Me.cboRedondeo.Text = "3"
                                End If

                            End If

                        Else

                            'No existe un cálculo anterior
                            Me.cboTipo.SelectedIndex = -1
                            Me.txtMonto.Clear()
                            Me.cboRedondeo.SelectedIndex = 0

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MsgBox("Error al cargar la deducción: " & ex.Message,
               MsgBoxStyle.Critical,
               "Zeus Acopio")

        End Try

    End Sub

    Private Function ObtenerDecimalesRedondeo() As Integer

        If Me.cboRedondeo.Text = "3" Then
            Return 3
        Else
            Return 2
        End If

    End Function

    Private Sub ActualizarTotalDeduccion()

        Dim Total As Double = 0

        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

            If fila.IsNewRow Then Continue For

            Dim Seleccionado As Boolean = False

            If fila.Cells("colSelec").Value IsNot Nothing Then
                Seleccionado = Convert.ToBoolean(
                fila.Cells("colSelec").Value)
            End If

            If Seleccionado Then

                Dim Valor As Double = 0

                If fila.Cells("colTotalDeducc").Value IsNot Nothing AndAlso
               Not IsDBNull(fila.Cells("colTotalDeducc").Value) Then

                    Double.TryParse(
                    fila.Cells("colTotalDeducc").Value.ToString(),
                    Valor)

                End If

                Total += Valor

            End If

        Next

        Me.LblTotal.Text = Total.ToString("##,##0.00")

    End Sub
    Private Sub FrmDeduccionPlanilla_Load(ByVal sender As System.Object,
                                          ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cboCentroAcopio.Items.Clear()

        If Me.TipoPlanilla <> "" Then
            Me.cboCentroAcopio.Items.Add(Me.TipoPlanilla)
            Me.cboCentroAcopio.SelectedIndex = 0
        End If

        Me.dtpPeriodoDesde.Value = Me.FechaDesde
        Me.dtpPeriodoHasta.Value = Me.FechaHasta
        Me.TxtNumeroPlanilla.Text = Me.NumeroPlanilla

        CargarTiposDeduccion()
        CargarTiposCalculo()
        CargarRedondeos()

        ConfigurarGrid()
        ConfigurarMenuSeleccion()
        CargarDetalleNomina()

    End Sub



    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object,
                                         ByVal e As System.EventArgs) _
                                         Handles cboTipo.SelectedIndexChanged

        If Me.cboTipo.Text = "Valor Distribuido entre unidades" Then
            Me.cboRedondeo.Enabled = True
        Else
            Me.cboRedondeo.Enabled = False
        End If

    End Sub

    Private Sub cboTipoDeduccion_SelectedIndexChanged(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) _
    Handles cboTipoDeduccion.SelectedIndexChanged

        If Me.cboTipoDeduccion.SelectedIndex < 0 Then
            Exit Sub
        End If

        CargarDeduccionActual()

    End Sub

    Private Sub btnDistribuir_Click(ByVal sender As System.Object,
                                ByVal e As System.EventArgs) _
                                Handles btnDistribuir.Click

        Dim TipoCalculo As String = Me.cboTipo.Text

        If String.IsNullOrWhiteSpace(Me.cboTipoDeduccion.Text) Then

            MsgBox("Seleccione el tipo de deducción.",
               MsgBoxStyle.Exclamation,
               "Zeus Acopio")

            Exit Sub

        End If

        If String.IsNullOrWhiteSpace(TipoCalculo) Then

            MsgBox("Seleccione el tipo de cálculo.",
               MsgBoxStyle.Exclamation,
               "Zeus Acopio")

            Exit Sub

        End If

        Dim Monto As Double

        If Not Double.TryParse(Me.txtMonto.Text, Monto) Then

            MsgBox("Digite un monto válido.",
               MsgBoxStyle.Exclamation,
               "Zeus Acopio")

            Me.txtMonto.Focus()
            Exit Sub

        End If

        If Monto < 0 Then

            MsgBox("El monto no puede ser negativo.",
               MsgBoxStyle.Exclamation,
               "Zeus Acopio")

            Exit Sub

        End If

        '----------------------------------------------------------
        ' CONTAR SOCIOS SELECCIONADOS
        '----------------------------------------------------------

        Dim CantidadSeleccionados As Integer = 0

        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

            If fila.IsNewRow Then Continue For

            If Convert.ToBoolean(fila.Cells("colSelec").Value) Then
                CantidadSeleccionados += 1
            End If

        Next

        If CantidadSeleccionados = 0 Then

            MsgBox("Seleccione al menos un socio.",
               MsgBoxStyle.Exclamation,
               "Zeus Acopio")

            Exit Sub

        End If

        '----------------------------------------------------------
        ' VALOR FIJO
        '----------------------------------------------------------

        If TipoCalculo = "Valor Fijo" Then

            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                If fila.IsNewRow Then Continue For

                If Convert.ToBoolean(fila.Cells("colSelec").Value) Then

                    fila.Cells("colPrecioFicha").Value = Monto
                    fila.Cells("colTotalDeducc").Value = Monto

                End If

            Next

            ActualizarTotalDeduccion()

            Exit Sub

        End If

        '----------------------------------------------------------
        ' VALOR POR UNIDAD
        '----------------------------------------------------------

        If TipoCalculo = "Valor por Unidad" Then

            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                If fila.IsNewRow Then Continue For

                If Convert.ToBoolean(fila.Cells("colSelec").Value) Then

                    Dim Cantidad As Double = 0

                    If fila.Cells("colCantidad").Value IsNot Nothing AndAlso
                   Not IsDBNull(fila.Cells("colCantidad").Value) Then

                        Double.TryParse(
                        fila.Cells("colCantidad").Value.ToString(),
                        Cantidad)

                    End If

                    Dim TotalDeduccion As Double = Cantidad * Monto

                    fila.Cells("colPrecioFicha").Value = Monto
                    fila.Cells("colTotalDeducc").Value =
                    Math.Round(TotalDeduccion, 2, MidpointRounding.AwayFromZero)

                End If

            Next

            ActualizarTotalDeduccion()

            Exit Sub

        End If

        '----------------------------------------------------------
        ' VALOR DISTRIBUIDO ENTRE UNIDADES
        '----------------------------------------------------------

        If TipoCalculo = "Valor Distribuido entre unidades" Then

            Dim TotalUnidades As Double = 0

            'Primero sumamos las cantidades seleccionadas
            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                If fila.IsNewRow Then Continue For

                If Convert.ToBoolean(fila.Cells("colSelec").Value) Then

                    Dim Cantidad As Double = 0

                    If fila.Cells("colCantidad").Value IsNot Nothing AndAlso
                   Not IsDBNull(fila.Cells("colCantidad").Value) Then

                        Double.TryParse(
                        fila.Cells("colCantidad").Value.ToString(),
                        Cantidad)

                    End If

                    If Cantidad > 0 Then
                        TotalUnidades += Cantidad
                    End If

                End If

            Next

            If TotalUnidades <= 0 Then

                MsgBox("La cantidad total de leche de los socios seleccionados debe ser mayor que cero.",
                   MsgBoxStyle.Exclamation,
                   "Zeus Acopio")

                Exit Sub

            End If

            Dim Decimales As Integer = ObtenerDecimalesRedondeo()

            'Valor real por unidad antes de redondear
            Dim ValorPorUnidad As Double = Monto / TotalUnidades

            'Valor por unidad que se mostrará
            Dim ValorPorUnidadRedondeado As Double =
            Math.Round(ValorPorUnidad,
                       Decimales,
                       MidpointRounding.AwayFromZero)

            '------------------------------------------------------
            ' PRIMERA DISTRIBUCIÓN
            '------------------------------------------------------

            Dim TotalCalculado As Double = 0

            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                If fila.IsNewRow Then Continue For

                If Convert.ToBoolean(fila.Cells("colSelec").Value) Then

                    Dim Cantidad As Double = 0

                    If fila.Cells("colCantidad").Value IsNot Nothing AndAlso
                   Not IsDBNull(fila.Cells("colCantidad").Value) Then

                        Double.TryParse(
                        fila.Cells("colCantidad").Value.ToString(),
                        Cantidad)

                    End If

                    'Calculamos utilizando el valor real,
                    'no el valor unitario ya redondeado.
                    Dim TotalDeduccion As Double =
                    Cantidad * ValorPorUnidad

                    TotalDeduccion =
                    Math.Round(TotalDeduccion,
                               Decimales,
                               MidpointRounding.AwayFromZero)

                    fila.Cells("colPrecioFicha").Value =
                    ValorPorUnidadRedondeado

                    fila.Cells("colTotalDeducc").Value =
                    TotalDeduccion

                    TotalCalculado += TotalDeduccion

                End If

            Next

            '------------------------------------------------------
            ' AJUSTE POR REDONDEO
            '------------------------------------------------------

            Dim MontoRedondeado As Double =
            Math.Round(Monto,
                       Decimales,
                       MidpointRounding.AwayFromZero)

            Dim Diferencia As Double =
            Math.Round(MontoRedondeado - TotalCalculado,
                       Decimales,
                       MidpointRounding.AwayFromZero)

            If Diferencia <> 0 Then

                'Buscamos el último socio seleccionado
                'con cantidad mayor que cero.
                For i As Integer = Me.dgvDetalle.Rows.Count - 1 To 0 Step -1

                    Dim fila As DataGridViewRow =
                    Me.dgvDetalle.Rows(i)

                    If fila.IsNewRow Then Continue For

                    If Convert.ToBoolean(fila.Cells("colSelec").Value) Then

                        Dim Cantidad As Double = 0

                        If fila.Cells("colCantidad").Value IsNot Nothing AndAlso
                       Not IsDBNull(fila.Cells("colCantidad").Value) Then

                            Double.TryParse(
                            fila.Cells("colCantidad").Value.ToString(),
                            Cantidad)

                        End If

                        If Cantidad > 0 Then

                            Dim ValorActual As Double =
                            Convert.ToDouble(
                                fila.Cells("colTotalDeducc").Value)

                            fila.Cells("colTotalDeducc").Value =
                            Math.Round(
                                ValorActual + Diferencia,
                                Decimales,
                                MidpointRounding.AwayFromZero)

                            Exit For

                        End If

                    End If

                Next

            End If

            ActualizarTotalDeduccion()
            Exit Sub

        End If

    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click

        Try

            '------------------------------------------------------------
            ' Validaciones
            '------------------------------------------------------------
            If Me.cboTipoDeduccion.SelectedIndex < 0 Then
                MessageBox.Show("Seleccione el tipo de deducción.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim tipoCalculo As String = Me.cboTipo.Text.Trim()

            If tipoCalculo = "" Then
                MessageBox.Show("Seleccione el tipo de cálculo.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim monto As Double

            If Not Double.TryParse(Me.txtMonto.Text, monto) Then
                MessageBox.Show("Ingrese un monto válido.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            If monto < 0 Then
                MessageBox.Show("El monto no puede ser negativo.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim campoDeduccion As String =
            ObtenerCampoDeduccion(Me.cboTipoDeduccion.Text)

            If campoDeduccion = "" Then
                MessageBox.Show("No se pudo determinar el campo de deducción.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            '------------------------------------------------------------
            ' Contar productores marcados
            '------------------------------------------------------------
            Dim cantidadMarcados As Integer = 0

            For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                If fila.IsNewRow Then Continue For

                Dim marcado As Boolean = False

                If fila.Cells("colSelec").Value IsNot Nothing Then
                    marcado = Convert.ToBoolean(fila.Cells("colSelec").Value)
                End If

                If marcado Then
                    cantidadMarcados += 1
                End If

            Next

            If cantidadMarcados = 0 Then
                MessageBox.Show("Debe seleccionar al menos un productor.",
                            "Deducciones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            '------------------------------------------------------------
            ' Para distribución entre unidades obtenemos las unidades
            ' utilizadas en el cálculo.
            '------------------------------------------------------------
            Dim unidadesDistribuidas As Double = 0

            If tipoCalculo = "Valor Distribuido entre unidades" Then

                For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                    If fila.IsNewRow Then Continue For

                    Dim marcado As Boolean = False

                    If fila.Cells("colSelec").Value IsNot Nothing Then
                        marcado = Convert.ToBoolean(fila.Cells("colSelec").Value)
                    End If

                    If Not marcado Then Continue For

                    Dim cantidad As Double = 0

                    If fila.Cells("colCantidad").Value IsNot Nothing Then
                        Double.TryParse(
                        fila.Cells("colCantidad").Value.ToString(),
                        cantidad)
                    End If

                    If cantidad > 0 Then
                        unidadesDistribuidas += cantidad
                    End If

                Next

                If unidadesDistribuidas <= 0 Then
                    MessageBox.Show("No existen unidades válidas para distribuir.",
                                "Deducciones",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                    Exit Sub
                End If

            End If

            '------------------------------------------------------------
            ' Confirmación
            '------------------------------------------------------------
            Dim respuesta As DialogResult =
            MessageBox.Show(
                "Se aplicará la deducción '" &
                Me.cboTipoDeduccion.Text &
                "' a " &
                cantidadMarcados.ToString() &
                " productor(es)." &
                Environment.NewLine &
                Environment.NewLine &
                "¿Desea ejecutar el proceso?",
                "Confirmar deducción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then
                Exit Sub
            End If

            '------------------------------------------------------------
            ' Guardado transaccional
            '------------------------------------------------------------
            Using cn As New SqlClient.SqlConnection(Conexion)

                cn.Open()

                Using trans As SqlClient.SqlTransaction = cn.BeginTransaction()

                    Try

                        '------------------------------------------------
                        ' Procesar cada productor marcado
                        '------------------------------------------------
                        For Each fila As DataGridViewRow In Me.dgvDetalle.Rows

                            If fila.IsNewRow Then Continue For

                            Dim marcado As Boolean = False

                            If fila.Cells("colSelec").Value IsNot Nothing Then
                                marcado =
                                Convert.ToBoolean(
                                    fila.Cells("colSelec").Value)
                            End If

                            If Not marcado Then Continue For

                            Dim codProductor As String =
                            Convert.ToString(
                                fila.Cells("colCodBeneficiario").Value).Trim()

                            Dim tipoProductor As String =
                            Convert.ToString(
                                fila.Cells("colTipoProductor").Value).Trim()

                            Dim nombreProductor As String =
                            Convert.ToString(
                                fila.Cells("colTercero").Value).Trim()

                            Dim totalDeduccion As Double = 0

                            If fila.Cells("colTotalDeducc").Value IsNot Nothing Then

                                Double.TryParse(
                                fila.Cells("colTotalDeducc").Value.ToString(),
                                totalDeduccion)

                            End If

                            '--------------------------------------------
                            ' Buscar el registro más reciente
                            '--------------------------------------------
                            Dim idDeduccion As Integer = 0

                            Dim sqlBuscar As String =
                            "SELECT TOP 1 IdDeduccion " &
                            "FROM Deducciones_Planilla " &
                            "WHERE NumNomina = @NumNomina " &
                            "AND CodProductor = @CodProductor " &
                            "AND TipoProductor = @TipoProductor " &
                            "ORDER BY IdDeduccion DESC"

                            Using cmdBuscar As New SqlClient.SqlCommand(
                            sqlBuscar, cn, trans)

                                cmdBuscar.Parameters.AddWithValue(
                                "@NumNomina", Me.TxtNumeroPlanilla.Text.Trim())

                                cmdBuscar.Parameters.AddWithValue(
                                "@CodProductor", codProductor)

                                cmdBuscar.Parameters.AddWithValue(
                                "@TipoProductor", tipoProductor)

                                Dim resultado As Object =
                                cmdBuscar.ExecuteScalar()

                                If resultado IsNot Nothing AndAlso
                               resultado IsNot DBNull.Value Then

                                    idDeduccion = Convert.ToInt32(resultado)

                                End If

                            End Using

                            '--------------------------------------------
                            ' Si existe: actualizar SOLO el campo
                            ' correspondiente a la deducción.
                            '--------------------------------------------
                            If idDeduccion > 0 Then

                                Dim sqlActualizar As String =
                                "UPDATE Deducciones_Planilla " &
                                "SET " & campoDeduccion & " = @Valor " &
                                "WHERE IdDeduccion = @IdDeduccion"

                                Using cmdActualizar As New SqlClient.SqlCommand(
                                sqlActualizar, cn, trans)

                                    cmdActualizar.Parameters.AddWithValue(
                                    "@Valor", totalDeduccion)

                                    cmdActualizar.Parameters.AddWithValue(
                                    "@IdDeduccion", idDeduccion)

                                    cmdActualizar.ExecuteNonQuery()

                                End Using

                            Else

                                '----------------------------------------
                                ' No existe: crear registro nuevo.
                                ' Las demás deducciones quedan en 0.
                                '----------------------------------------
                                Dim sqlInsertar As String =
                                "INSERT INTO Deducciones_Planilla " &
                                "(NumNomina, CodProductor, TipoProductor, " &
                                "NombreProductor, " & campoDeduccion & ") " &
                                "VALUES " &
                                "(@NumNomina, @CodProductor, @TipoProductor, " &
                                "@NombreProductor, @Valor)"

                                Using cmdInsertar As New SqlClient.SqlCommand(
                                sqlInsertar, cn, trans)

                                    cmdInsertar.Parameters.AddWithValue(
                                    "@NumNomina",
                                    Me.TxtNumeroPlanilla.Text.Trim())

                                    cmdInsertar.Parameters.AddWithValue(
                                    "@CodProductor",
                                    codProductor)

                                    cmdInsertar.Parameters.AddWithValue(
                                    "@TipoProductor",
                                    tipoProductor)

                                    cmdInsertar.Parameters.AddWithValue(
                                    "@NombreProductor",
                                    nombreProductor)

                                    cmdInsertar.Parameters.AddWithValue(
                                    "@Valor", totalDeduccion)

                                    cmdInsertar.ExecuteNonQuery()

                                End Using

                            End If

                        Next

                        '------------------------------------------------
                        ' Guardar configuración/historial del cálculo
                        '------------------------------------------------
                        Dim sqlCalculo As String =
                        "INSERT INTO Deducciones_Planilla_Calculo " &
                        "(NumNomina, TipoDeduccion, TipoCalculo, " &
                        "Monto, Decimales, UnidadesDistribuidas) " &
                        "VALUES " &
                        "(@NumNomina, @TipoDeduccion, @TipoCalculo, " &
                        "@Monto, @Decimales, @UnidadesDistribuidas)"

                        Using cmdCalculo As New SqlClient.SqlCommand(
                        sqlCalculo, cn, trans)

                            cmdCalculo.Parameters.AddWithValue(
                            "@NumNomina",
                            Me.TxtNumeroPlanilla.Text.Trim())

                            cmdCalculo.Parameters.AddWithValue(
                            "@TipoDeduccion",
                            Me.cboTipoDeduccion.Text.Trim())

                            cmdCalculo.Parameters.AddWithValue(
                            "@TipoCalculo",
                            tipoCalculo)

                            cmdCalculo.Parameters.AddWithValue(
                            "@Monto", monto)

                            Dim decimales As Integer = 2

                            If Me.cboRedondeo.Text.Trim() <> "" Then
                                Integer.TryParse(
                                Me.cboRedondeo.Text.Trim(),
                                decimales)
                            End If

                            cmdCalculo.Parameters.AddWithValue(
                            "@Decimales", decimales)

                            If tipoCalculo =
                           "Valor Distribuido entre unidades" Then

                                cmdCalculo.Parameters.AddWithValue(
                                "@UnidadesDistribuidas",
                                unidadesDistribuidas)

                            Else

                                cmdCalculo.Parameters.AddWithValue(
                                "@UnidadesDistribuidas",
                                DBNull.Value)

                            End If

                            cmdCalculo.ExecuteNonQuery()

                        End Using

                        '------------------------------------------------
                        ' Confirmar toda la operación
                        '------------------------------------------------
                        trans.Commit()

                    Catch

                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using



            MessageBox.Show(
            "La deducción fue aplicada correctamente.",
            "Deducciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

            'Volver a cargar los valores guardados
            CargarDeduccionActual()

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
            "No fue posible aplicar la deducción." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub
End Class
