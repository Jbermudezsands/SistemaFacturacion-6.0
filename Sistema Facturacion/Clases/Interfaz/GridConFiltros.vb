Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

'=====================================================================================================
'  GRID CON FILTROS
'  Aplica el estilo moderno del sistema a un DataGridView y le agrega una fila de filtros (una caja de
'  texto por columna, alineada con la columna) que reemplaza a la FilterBar del C1TrueDBGrid.
'
'  Uso:
'      _grid = New GridConFiltros(MiDataGridView, PanelDondeVanLosFiltros)
'      _grid.AgregarColumna("Campo", "Titulo", 100, "#,##0.00", DataGridViewContentAlignment.MiddleRight)
'      _grid.Enlazar(tabla)
'
'  El panel de filtros debe estar justo encima del grid, en el mismo contenedor, con el mismo Left.
'=====================================================================================================
Public Class GridConFiltros

    Private Const EM_SETCUEBANNER As Integer = &H1501

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
    End Function

    Private ReadOnly _grid As DataGridView
    Private ReadOnly _hostFiltros As Control
    Private ReadOnly _fuente As New BindingSource
    Private ReadOnly _cajas As New List(Of TextBox)
    Private ReadOnly _campos As New List(Of String)
    Private _suspendido As Boolean

    ''' <summary>Se dispara cuando cambia la lista (datos nuevos o filtro aplicado).</summary>
    Public Event ResumenCambiado As EventHandler

    Public Sub New(ByVal grid As DataGridView, ByVal hostFiltros As Control)
        _grid = grid
        _hostFiltros = hostFiltros

        AplicarEstilo()
        _grid.AutoGenerateColumns = False
        _grid.DataSource = _fuente

        AddHandler _fuente.ListChanged, AddressOf AlCambiarLista
        AddHandler _grid.ColumnWidthChanged, Sub(s As Object, e As DataGridViewColumnEventArgs) PosicionarFiltros()
        AddHandler _grid.Scroll, Sub(s As Object, e As ScrollEventArgs) PosicionarFiltros()
        AddHandler _grid.Resize, Sub(s As Object, e As EventArgs) PosicionarFiltros()
        AddHandler _grid.DataBindingComplete, Sub(s As Object, e As DataGridViewBindingCompleteEventArgs) PosicionarFiltros()
    End Sub

#Region "Propiedades"

    ''' <summary>Filas que se ven con el filtro actual.</summary>
    Public ReadOnly Property FilasVisibles() As Integer
        Get
            Return _fuente.Count
        End Get
    End Property

    ''' <summary>Filas totales sin filtro.</summary>
    Public ReadOnly Property FilasTotales() As Integer
        Get
            Dim tabla As DataTable = TryCast(_fuente.DataSource, DataTable)
            If tabla Is Nothing Then Return 0
            Return tabla.Rows.Count
        End Get
    End Property

    ''' <summary>Fila seleccionada en el grid (Nothing si no hay).</summary>
    Public ReadOnly Property FilaActual() As DataRowView
        Get
            Return TryCast(_fuente.Current, DataRowView)
        End Get
    End Property

#End Region

#Region "Configuración"

    Private Sub AplicarEstilo()
        With _grid
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersHeight = 32
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .EnableHeadersVisualStyles = False
            .GridColor = Color.FromArgb(230, 233, 238)
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
    End Sub

    ''' <summary>Agrega una columna de texto al grid y su caja de filtro.</summary>
    Public Sub AgregarColumna(ByVal campo As String, ByVal titulo As String, ByVal pesoAncho As Single, _
                              ByVal formato As String, ByVal alineacion As DataGridViewContentAlignment)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = "Col" & campo
        col.DataPropertyName = campo
        col.HeaderText = titulo
        col.FillWeight = pesoAncho
        col.SortMode = DataGridViewColumnSortMode.Automatic
        col.DefaultCellStyle.Format = formato
        col.DefaultCellStyle.Alignment = alineacion
        _grid.Columns.Add(col)

        Dim caja As New TextBox
        caja.BorderStyle = BorderStyle.FixedSingle
        caja.Font = New Font("Segoe UI", 8.5!)
        caja.ForeColor = Color.FromArgb(30, 41, 59)
        AddHandler caja.TextChanged, Sub(s As Object, e As EventArgs) AplicarFiltros()
        AddHandler caja.HandleCreated, Sub(emisor As Object, e As EventArgs) EstablecerTextoGuia(caja)
        _hostFiltros.Controls.Add(caja)

        _campos.Add(campo)
        _cajas.Add(caja)
        PosicionarFiltros()
    End Sub

    Private Shared Sub EstablecerTextoGuia(ByVal caja As TextBox)
        Try
            SendMessage(caja.Handle, EM_SETCUEBANNER, IntPtr.Zero, "Filtrar...")
        Catch ex As Exception
            'El texto guía es solo decorativo; si el sistema no lo soporta se ignora
        End Try
    End Sub

#End Region

#Region "Datos y filtros"

    ''' <summary>Enlaza una tabla al grid y limpia los filtros.</summary>
    Public Sub Enlazar(ByVal tabla As DataTable)
        LimpiarFiltros()
        _fuente.Filter = Nothing
        _fuente.DataSource = tabla
        PosicionarFiltros()
        RaiseEvent ResumenCambiado(Me, EventArgs.Empty)
    End Sub

    ''' <summary>Borra el texto de todas las cajas de filtro.</summary>
    Public Sub LimpiarFiltros()
        _suspendido = True
        Try
            For Each caja As TextBox In _cajas
                caja.Text = ""
            Next
        Finally
            _suspendido = False
        End Try
        AplicarFiltros()
    End Sub

    Private Sub AplicarFiltros()
        If _suspendido Then Return
        If _fuente.DataSource Is Nothing Then Return

        Dim condiciones As New List(Of String)
        For i As Integer = 0 To _campos.Count - 1
            Dim texto As String = _cajas(i).Text.Trim()
            If texto.Length = 0 Then Continue For

            If EsNumerica(_campos(i)) Then
                texto = texto.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
            End If
            condiciones.Add("CONVERT([" & _campos(i) & "], 'System.String') LIKE '%" & EscaparLike(texto) & "%'")
        Next

        Try
            If condiciones.Count = 0 Then
                _fuente.Filter = Nothing
            Else
                _fuente.Filter = String.Join(" AND ", condiciones.ToArray())
            End If
        Catch ex As Exception
            'Un filtro inválido nunca debe tumbar el formulario: se quita y se deja ver todo
            _fuente.Filter = Nothing
        End Try
    End Sub

    Private Function EsNumerica(ByVal campo As String) As Boolean
        Dim tabla As DataTable = TryCast(_fuente.DataSource, DataTable)
        If tabla Is Nothing OrElse Not tabla.Columns.Contains(campo) Then Return False

        Select Case Type.GetTypeCode(tabla.Columns(campo).DataType)
            Case TypeCode.Byte, TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, _
                 TypeCode.Int64, TypeCode.Single
                Return True
        End Select
        Return False
    End Function

    ''' <summary>Escapa el texto para usarlo dentro de un LIKE de DataView.RowFilter.</summary>
    Private Shared Function EscaparLike(ByVal texto As String) As String
        Dim sb As New System.Text.StringBuilder
        For Each c As Char In texto
            Select Case c
                Case "'"c
                    sb.Append("''")
                Case "%"c, "*"c, "["c, "]"c
                    sb.Append("[").Append(c).Append("]")
                Case Else
                    sb.Append(c)
            End Select
        Next
        Return sb.ToString()
    End Function

    Private Sub AlCambiarLista(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        RaiseEvent ResumenCambiado(Me, EventArgs.Empty)
    End Sub

#End Region

#Region "Posición de los filtros"

    ''' <summary>Alinea cada caja de filtro con su columna (ancho, scroll horizontal, etc.).</summary>
    Private Sub PosicionarFiltros()
        If _cajas.Count = 0 Then Return

        Dim desfase As Integer = _grid.Left - _hostFiltros.Left
        For i As Integer = 0 To _grid.Columns.Count - 1
            If i >= _cajas.Count Then Exit For

            Dim caja As TextBox = _cajas(i)
            Dim rect As Rectangle = _grid.GetColumnDisplayRectangle(i, False)
            caja.Visible = _grid.Columns(i).Visible AndAlso rect.Width > 6
            If caja.Visible Then
                Dim arriba As Integer = Math.Max(0, (_hostFiltros.Height - caja.Height) \ 2)
                caja.SetBounds(desfase + rect.Left + 2, arriba, rect.Width - 4, caja.Height)
            End If
        Next
    End Sub

#End Region

End Class
