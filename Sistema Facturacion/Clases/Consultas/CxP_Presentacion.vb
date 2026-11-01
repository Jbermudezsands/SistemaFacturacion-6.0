Option Strict On
Option Explicit On
Option Infer On

Imports System.Drawing
Imports System.Windows.Forms
Imports C1.Win.C1TrueDBGrid

'=====================================================================================================
'  CUENTAS POR PAGAR - PRESENTACIÓN
'  Colores, estilo del grid y ajuste a la ventana MDI. Misma paleta que Cuentas x Cobrar.
'=====================================================================================================
Public NotInheritable Class CxPEstilos
    Private Sub New()
    End Sub

    Public Shared ReadOnly ColorVencido As Color = Color.FromArgb(185, 28, 28)
    Public Shared ReadOnly ColorFavor As Color = Color.FromArgb(21, 128, 61)
    Public Shared ReadOnly ColorAdvertencia As Color = Color.FromArgb(180, 83, 9)
    Public Shared ReadOnly ColorTexto As Color = Color.FromArgb(71, 85, 105)
    Public Shared ReadOnly ColorValor As Color = Color.FromArgb(31, 41, 55)

    Public Shared Sub AplicarEstiloGrid(grid As C1TrueDBGrid)
        Try
            With grid
                .Caption = ""
                .Font = New Font("Segoe UI", 9.0!)
                .RowHeight = 24
                .FetchRowStyles = True
                .Styles("Normal").Font = New Font("Segoe UI", 9.0!)
                .Styles("Heading").BackColor = Color.FromArgb(232, 237, 243)
                .Styles("Heading").ForeColor = Color.FromArgb(45, 55, 72)
                .Styles("Heading").Font = New Font("Segoe UI Semibold", 9.0!)
                .Styles("EvenRow").BackColor = Color.FromArgb(248, 250, 252)
                .Styles("OddRow").BackColor = Color.White
                .Styles("FilterBar").BackColor = Color.FromArgb(255, 251, 235)
                .Styles("HighlightRow").BackColor = Color.FromArgb(219, 234, 254)
                .Styles("HighlightRow").ForeColor = Color.FromArgb(30, 58, 138)
                .Styles("Selected").BackColor = Color.FromArgb(219, 234, 254)
                .Styles("Selected").ForeColor = Color.FromArgb(30, 58, 138)
            End With
        Catch
            ' Si la versión de ComponentOne no tiene alguno de estos estilos, se deja el aspecto por defecto
        End Try
    End Sub

    Public Shared Sub ConfigurarColumnas(grid As C1TrueDBGrid)
        Try
            Columna(grid, "Fecha_Factura", "Fecha", 80, "dd/MM/yyyy", False)
            Columna(grid, "Numero_Compra", "Compra No", 90, Nothing, False)
            Columna(grid, "Numero_Factura", "Factura No", 85, Nothing, False)
            Columna(grid, "Numero_Recibo", "Pago No", 90, Nothing, False)
            Columna(grid, "NotaDebito", "NB / NC No", 105, Nothing, False)
            Columna(grid, "MontoNota", "Monto NB/NC", 90, DineroCxC.FormatoMonto, True)
            Columna(grid, "Monto", "Cargo", 95, DineroCxC.FormatoMonto, True)
            Columna(grid, "FechaVence", "Vence", 80, "dd/MM/yyyy", False)
            Columna(grid, "Abono", "Abono", 95, DineroCxC.FormatoMonto, True)
            Columna(grid, "Saldo", "Saldo", 95, DineroCxC.FormatoMonto, True)
            Columna(grid, "Moratorio", "Moratorio", 85, DineroCxC.FormatoMonto, True)
            Columna(grid, "Dias", "Días", 50, Nothing, True)
            Columna(grid, "Total", "Total", 100, DineroCxC.FormatoMonto, True)
            Columna(grid, "Observaciones", "Observaciones", 220, Nothing, False)
        Catch
            ' Si el grid aún no tiene las columnas, se deja el aspecto por defecto
        End Try
    End Sub

    Private Shared Sub Columna(grid As C1TrueDBGrid, campo As String, titulo As String, ancho As Integer, formato As String, alinearDerecha As Boolean)
        Dim col = grid.Columns(campo)
        col.Caption = titulo
        If formato IsNot Nothing Then col.NumberFormat = formato
        Dim display = grid.Splits(0).DisplayColumns(campo)
        display.Width = ancho
        If alinearDerecha Then display.Style.HorizontalAlignment = AlignHorzEnum.Far
    End Sub

    ''' <summary>Rojo: compra vencida con saldo. Verde: saldo a favor (se pagó de más o hay devoluciones).</summary>
    Public Shared Sub PintarFila(grid As C1TrueDBGrid, e As FetchRowStyleEventArgs)
        Try
            Dim saldo = grid.Columns("Saldo").CellValue(e.Row)
            Dim dias = grid.Columns("Dias").CellValue(e.Row)
            If saldo Is Nothing OrElse Convert.IsDBNull(saldo) Then Exit Sub
            Dim valor = Convert.ToDecimal(saldo)
            If valor < 0D Then
                e.CellStyle.ForeColor = ColorFavor
            ElseIf valor > 0D AndAlso dias IsNot Nothing AndAlso Not Convert.IsDBNull(dias) AndAlso Convert.ToInt32(dias) > 0 Then
                e.CellStyle.ForeColor = ColorVencido
            End If
        Catch
            ' Un error de formato en una celda no debe tumbar el pintado del grid
        End Try
    End Sub
End Class

'-----------------------------------------------------------------------------------------------------
' Ventana hija MDI: el formulario principal tapa el borde inferior (barra de estado).
' Se mide cuánto queda tapado para dejar ese espacio libre abajo y que el grid no se corte.
'-----------------------------------------------------------------------------------------------------
Public NotInheritable Class CxPAreaMdi
    Private Sub New()
    End Sub

    ''' <summary>Alto, en píxeles, que el formulario principal tapa del área de ventanas hijas.</summary>
    Public Shared Function EspacioTapado(formulario As Form) As Integer
        Try
            Dim principal = formulario.MdiParent
            Dim areaHijas = formulario.Parent      ' MdiClient
            If principal Is Nothing OrElse areaHijas Is Nothing OrElse formulario.WindowState <> FormWindowState.Maximized Then Return 0

            Dim area = principal.RectangleToClient(areaHijas.RectangleToScreen(areaHijas.ClientRectangle))
            Dim limiteVisible = Math.Min(area.Bottom, principal.ClientSize.Height)

            For Each c As Control In principal.Controls
                If c Is areaHijas OrElse Not c.Visible Then Continue For
                Dim cruce = Rectangle.Intersect(c.Bounds, area)
                If cruce.Width > 0 AndAlso cruce.Height > 0 AndAlso cruce.Top > area.Top + area.Height \ 2 Then
                    limiteVisible = Math.Min(limiteVisible, cruce.Top)
                End If
            Next
            Return Math.Max(0, area.Bottom - limiteVisible)
        Catch
            Return 0
        End Try
    End Function

    ''' <summary>Cuando la ventana no está maximizada, la ajusta al área disponible del formulario principal.</summary>
    Public Shared Sub AjustarAlArea(formulario As Form)
        If formulario.MdiParent Is Nothing OrElse formulario.Parent Is Nothing Then Exit Sub
        Dim area = formulario.Parent.ClientSize
        formulario.Size = New Size(Math.Min(formulario.Width, area.Width), Math.Min(formulario.Height, area.Height))
        formulario.Location = New Point(0, 0)
    End Sub
End Class
