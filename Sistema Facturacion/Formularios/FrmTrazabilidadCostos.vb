Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Consulta de la trazabilidad de ajustes de costo (tabla AjusteCostosLog): que linea se modifico, como estaba antes,
''' como quedo, quien lo hizo, desde que formulario y por que documento. Doble clic en una fila = ver todo su lote.
''' Controles creados por codigo (sin Designer), tamano pensado para el area util del MDI.
''' </summary>
Public Class FrmTrazabilidadCostos
    Inherits Form

    Private ReadOnly _repositorio As RepositorioTrazabilidadCostos

    Private TxtProducto As TextBox
    Private TxtDocumento As TextBox
    Private TxtOrigen As TextBox
    Private TxtUsuario As TextBox
    Private DtpDesde As DateTimePicker
    Private DtpHasta As DateTimePicker
    Private LblLote As Label
    Private LblResumen As Label
    Private Grid As DataGridView
    Private BtnBuscar As Button
    Private BtnLimpiar As Button
    Private BtnVerLote As Button
    Private BtnCerrar As Button

    Private _loteFiltrado As Guid? = Nothing

    Public Sub New()
        _repositorio = New RepositorioTrazabilidadCostos(Conexion)
        ConstruirControles()
    End Sub

    ' ------------------------------------------------------------------
    ' Interfaz
    ' ------------------------------------------------------------------

    Private Sub ConstruirControles()
        Me.Text = "Trazabilidad de ajustes de costo"
        Me.ClientSize = New Size(980, 520)
        Me.MinimumSize = New Size(760, 420)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.BackColor = Color.FromArgb(240, 242, 245)
        Me.KeyPreview = True

        ' Encabezado
        Dim PnlHeader As New Panel
        PnlHeader.Dock = DockStyle.Top
        PnlHeader.Height = 58
        PnlHeader.BackColor = Color.FromArgb(31, 56, 100)
        Dim LblTitulo As New Label
        LblTitulo.Text = "Trazabilidad de ajustes de costo"
        LblTitulo.ForeColor = Color.White
        LblTitulo.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        LblTitulo.AutoSize = True
        LblTitulo.Location = New Point(16, 8)
        Dim LblSub As New Label
        LblSub.Text = "Que se modifico, como estaba antes y quien lo hizo. Doble clic en una fila para ver todo su lote."
        LblSub.ForeColor = Color.FromArgb(200, 214, 235)
        LblSub.AutoSize = True
        LblSub.Location = New Point(18, 34)
        PnlHeader.Controls.Add(LblTitulo)
        PnlHeader.Controls.Add(LblSub)

        ' Barra inferior
        Dim PnlAcciones As New Panel
        PnlAcciones.Dock = DockStyle.Bottom
        PnlAcciones.Height = 56
        PnlAcciones.BackColor = Color.White
        BtnBuscar = CrearBoton("Buscar", 16, 10)
        BtnLimpiar = CrearBoton("Limpiar", 124, 10)
        BtnVerLote = CrearBoton("Ver lote", 232, 10)
        BtnCerrar = CrearBoton("Cerrar", 340, 10)
        LblResumen = New Label
        LblResumen.AutoSize = False
        LblResumen.Location = New Point(456, 10)
        LblResumen.Size = New Size(500, 36)
        LblResumen.TextAlign = ContentAlignment.MiddleLeft
        LblResumen.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        PnlAcciones.Controls.AddRange(New Control() {BtnBuscar, BtnLimpiar, BtnVerLote, BtnCerrar, LblResumen})

        ' Tarjeta de filtros
        Dim PnlFiltros As New Panel
        PnlFiltros.BackColor = Color.White
        PnlFiltros.Location = New Point(16, 66)
        PnlFiltros.Size = New Size(948, 76)
        PnlFiltros.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        TxtProducto = AgregarFiltro(PnlFiltros, "Producto", 8, 4, 150)
        TxtDocumento = AgregarFiltro(PnlFiltros, "Documento", 170, 4, 130)
        TxtOrigen = AgregarFiltro(PnlFiltros, "Formulario / origen", 312, 4, 170)
        TxtUsuario = AgregarFiltro(PnlFiltros, "Usuario", 494, 4, 150)

        Dim LblD As New Label
        LblD.Text = "Desde"
        LblD.AutoSize = True
        LblD.Location = New Point(8, 40)
        DtpDesde = New DateTimePicker
        DtpDesde.Format = DateTimePickerFormat.Short
        DtpDesde.ShowCheckBox = True
        DtpDesde.Checked = False
        DtpDesde.Location = New Point(8, 54)
        DtpDesde.Size = New Size(150, 20)
        Dim LblH As New Label
        LblH.Text = "Hasta"
        LblH.AutoSize = True
        LblH.Location = New Point(170, 40)
        DtpHasta = New DateTimePicker
        DtpHasta.Format = DateTimePickerFormat.Short
        DtpHasta.ShowCheckBox = True
        DtpHasta.Checked = False
        DtpHasta.Location = New Point(170, 54)
        DtpHasta.Size = New Size(130, 20)
        LblLote = New Label
        LblLote.AutoSize = True
        LblLote.ForeColor = Color.FromArgb(180, 60, 0)
        LblLote.Location = New Point(312, 57)
        PnlFiltros.Controls.AddRange(New Control() {LblD, DtpDesde, LblH, DtpHasta, LblLote})

        ' Grid
        Grid = New DataGridView
        Grid.Location = New Point(16, 150)
        Grid.Size = New Size(948, 306)
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.ReadOnly = True
        Grid.AllowUserToAddRows = False
        Grid.AllowUserToDeleteRows = False
        Grid.AllowUserToResizeRows = False
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Grid.MultiSelect = False
        Grid.RowHeadersVisible = False
        Grid.BackgroundColor = Color.White
        Grid.BorderStyle = BorderStyle.None
        Grid.ColumnHeadersHeight = 32
        Grid.RowTemplate.Height = 26
        Grid.AutoGenerateColumns = False
        Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 252)

        Me.Controls.Add(Grid)
        Me.Controls.Add(PnlFiltros)
        Me.Controls.Add(PnlAcciones)
        Me.Controls.Add(PnlHeader)
        PnlHeader.SendToBack()
        PnlAcciones.SendToBack()
        Grid.BringToFront()

        AgregarColumnas()

        AddHandler BtnBuscar.Click, AddressOf BtnBuscar_Click
        AddHandler BtnLimpiar.Click, AddressOf BtnLimpiar_Click
        AddHandler BtnVerLote.Click, AddressOf BtnVerLote_Click
        AddHandler BtnCerrar.Click, AddressOf BtnCerrar_Click
        AddHandler Grid.CellDoubleClick, AddressOf Grid_CellDoubleClick
        AddHandler Me.Load, AddressOf Formulario_Load
        AddHandler Me.KeyDown, AddressOf Formulario_KeyDown
    End Sub

    Private Shared Function CrearBoton(ByVal texto As String, ByVal x As Integer, ByVal y As Integer) As Button
        Dim b As New Button
        b.Text = texto
        b.Location = New Point(x, y)
        b.Size = New Size(96, 36)
        Return b
    End Function

    Private Shared Function AgregarFiltro(ByVal padre As Panel, ByVal titulo As String, ByVal x As Integer, ByVal y As Integer, ByVal ancho As Integer) As TextBox
        Dim l As New Label
        l.Text = titulo
        l.AutoSize = True
        l.Location = New Point(x, y + 4)
        Dim t As New TextBox
        t.Location = New Point(x, y + 20)
        t.Size = New Size(ancho, 20)
        padre.Controls.Add(l)
        padre.Controls.Add(t)
        Return t
    End Function

    Private Sub AgregarColumnas()
        AgregarColumna("FechaHora", "Fecha y hora", 118, "dd/MM/yyyy HH:mm", False)
        AgregarColumna("Usuario", "Usuario", 80, Nothing, False)
        AgregarColumna("Origen", "Formulario / origen", 150, Nothing, False)
        AgregarColumna("Referencia", "Referencia", 150, Nothing, False)
        AgregarColumna("Tipo_Documento", "Tipo", 100, Nothing, False)
        AgregarColumna("Numero_Documento", "Documento", 80, Nothing, False)
        AgregarColumna("Fecha_Documento", "Fecha doc.", 75, "dd/MM/yyyy", False)
        AgregarColumna("Cod_Producto", "Producto", 90, Nothing, False)
        AgregarColumna("Cantidad", "Cantidad", 70, "N2", True)
        AgregarColumna("Costo_Anterior", "Costo antes", 90, "N6", True)
        AgregarColumna("Costo_Nuevo", "Costo nuevo", 90, "N6", True)
        AgregarColumna("Dif_Costo", "Diferencia", 90, "N6", True)
        AgregarColumna("PrecioUnitario_Anterior", "Precio antes", 90, "N6", True)
        AgregarColumna("PrecioUnitario_Nuevo", "Precio nuevo", 90, "N6", True)
        AgregarColumna("Importe_Anterior", "Importe antes", 90, "N4", True)
        AgregarColumna("Importe_Nuevo", "Importe nuevo", 90, "N4", True)
        AgregarColumna("Tabla", "Tabla", 100, Nothing, False)
        AgregarColumna("IdDetalle", "Id detalle", 70, "0", True)
        AgregarColumna("Equipo", "Equipo", 90, Nothing, False)
        AgregarColumna("Observaciones", "Observaciones", 200, Nothing, False)
    End Sub

    Private Sub AgregarColumna(ByVal campo As String, ByVal titulo As String, ByVal ancho As Integer, ByVal formato As String, ByVal derecha As Boolean)
        Dim c As New DataGridViewTextBoxColumn
        c.DataPropertyName = campo
        c.Name = "col" & campo
        c.HeaderText = titulo
        c.Width = ancho
        c.SortMode = DataGridViewColumnSortMode.Automatic
        If formato IsNot Nothing Then c.DefaultCellStyle.Format = formato
        If derecha Then c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid.Columns.Add(c)
    End Sub

    ' ------------------------------------------------------------------
    ' Eventos
    ' ------------------------------------------------------------------

    Private Sub Formulario_Load(ByVal sender As Object, ByVal e As EventArgs)
        DtpDesde.Value = Date.Today.AddDays(-30)
        Buscar()
    End Sub

    Private Sub Formulario_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter AndAlso Not Grid.Focused Then
            Buscar()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Buscar()
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs)
        TxtProducto.Text = ""
        TxtDocumento.Text = ""
        TxtOrigen.Text = ""
        TxtUsuario.Text = ""
        DtpDesde.Checked = False
        DtpHasta.Checked = False
        _loteFiltrado = Nothing
        Buscar()
    End Sub

    Private Sub BtnVerLote_Click(ByVal sender As Object, ByVal e As EventArgs)
        VerLoteDeFilaActual()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then VerLoteDeFilaActual()
    End Sub

    Private Sub VerLoteDeFilaActual()
        If Grid.CurrentRow Is Nothing Then Return
        Dim fila As DataRowView = TryCast(Grid.CurrentRow.DataBoundItem, DataRowView)
        If fila Is Nothing OrElse IsDBNull(fila("Lote")) Then Return
        _loteFiltrado = CType(fila("Lote"), Guid)
        ' Al ver un lote se ignoran los demas filtros para mostrarlo completo.
        Buscar()
    End Sub

    ' ------------------------------------------------------------------
    ' Consulta
    ' ------------------------------------------------------------------

    Private Sub Buscar()
        Dim f As New FiltroTrazabilidadCostos
        If _loteFiltrado.HasValue Then
            f.Lote = _loteFiltrado
            LblLote.Text = "Mostrando solo el lote " & _loteFiltrado.Value.ToString().Substring(0, 8) & "... (Limpiar para quitarlo)"
        Else
            f.Producto = TxtProducto.Text.Trim()
            f.Documento = TxtDocumento.Text.Trim()
            f.Origen = TxtOrigen.Text.Trim()
            f.Usuario = TxtUsuario.Text.Trim()
            If DtpDesde.Checked Then f.Desde = DtpDesde.Value.Date
            If DtpHasta.Checked Then f.Hasta = DtpHasta.Value.Date
            LblLote.Text = ""
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim tabla As DataTable = _repositorio.Buscar(f)
            Grid.DataSource = tabla
            Dim texto As String = tabla.Rows.Count.ToString() & " ajuste(s)"
            If tabla.Rows.Count >= f.Maximo Then texto &= " (se muestran los " & f.Maximo.ToString() & " mas recientes; afine los filtros)"
            LblResumen.Text = texto
        Catch ex As SqlException
            Grid.DataSource = Nothing
            If ex.Number = 208 Then
                LblResumen.Text = "Falta la tabla AjusteCostosLog."
                MessageBox.Show("La tabla AjusteCostosLog no existe. Ejecute el script 'Cambios Script\Año 2026\11.Noviembre\5.AjusteCostosLog - Trazabilidad de ajustes.sql' en la base de datos.",
                                "Zeus Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("No se pudo consultar la trazabilidad: " & ex.Message, "Zeus Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo consultar la trazabilidad: " & ex.Message, "Zeus Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
