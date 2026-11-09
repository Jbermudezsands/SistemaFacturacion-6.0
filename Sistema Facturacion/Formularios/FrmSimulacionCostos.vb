Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Muestra el resultado de la SIMULACION del ajuste de costos: las filas de facturas/compras que cambiarian.
''' Solo lectura: no modifica la base de datos. Se construye por codigo (sin Designer).
''' </summary>
Public Class FrmSimulacionCostos
    Inherits Form

    Private ReadOnly _resumen As ResumenReparacion
    Private ReadOnly _tabla As New DataTable("Cambios")
    Private ReadOnly _vista As DataView
    Private ReadOnly Grid As New DataGridView
    Private ReadOnly TxtFiltro As New TextBox
    Private ReadOnly LblResumen As New Label
    Private ReadOnly ChkOcultar As New CheckBox
    Private ReadOnly TxtTolerancia As New TextBox
    Private ReadOnly LblConteo As New Label
    Private ReadOnly BtnExportar As New Button
    Private ReadOnly BtnCerrar As New Button

    Public Sub New(ByVal resumen As ResumenReparacion)
        _resumen = resumen

        Me.Text = "Simulacion de ajuste de costos (no se modifico la base de datos)"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(980, 520)
        Me.MinimumSize = New Size(700, 360)

        LblResumen.AutoSize = False
        LblResumen.SetBounds(12, 8, 956, 62)
        LblResumen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LblResumen.Text = ConstruirResumen()

        Dim lblF As New Label
        lblF.Text = "Filtrar (producto, documento, tipo):"
        lblF.AutoSize = True
        lblF.Location = New Point(12, 78)
        TxtFiltro.SetBounds(220, 74, 160, 22)

        ChkOcultar.Text = "Ocultar sin diferencia real (menor a):"
        ChkOcultar.AutoSize = True
        ChkOcultar.Checked = True
        ChkOcultar.Location = New Point(395, 76)
        TxtTolerancia.SetBounds(625, 74, 70, 22)
        TxtTolerancia.Text = "0.0001"
        LblConteo.AutoSize = True
        LblConteo.Location = New Point(710, 78)

        BtnExportar.Text = "Exportar CSV"
        BtnExportar.SetBounds(12, 482, 110, 28)
        BtnExportar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnCerrar.Text = "Cerrar"
        BtnCerrar.SetBounds(858, 482, 110, 28)
        BtnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

        ConstruirTabla()
        _vista = New DataView(_tabla)

        Grid.SetBounds(12, 104, 956, 370)
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.ReadOnly = True
        Grid.AllowUserToAddRows = False
        Grid.AllowUserToDeleteRows = False
        Grid.RowHeadersVisible = False
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Grid.BackgroundColor = Color.White
        Grid.BorderStyle = BorderStyle.FixedSingle
        Grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        Grid.GridColor = Color.FromArgb(200, 220, 240)
        Grid.EnableHeadersVisualStyles = False
        Grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 78, 121)
        Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 78, 121)
        Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Grid.ColumnHeadersHeight = 30
        Grid.DefaultCellStyle.BackColor = Color.White
        Grid.DefaultCellStyle.ForeColor = Color.Black
        Grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215)
        Grid.DefaultCellStyle.SelectionForeColor = Color.White
        Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 240, 252)
        Grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black
        Grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215)
        Grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White
        Grid.RowTemplate.Height = 24
        FormatearColumnas()
        Grid.DataSource = _vista

        Me.Controls.AddRange(New Control() {LblResumen, lblF, TxtFiltro, ChkOcultar, TxtTolerancia, LblConteo, Grid, BtnExportar, BtnCerrar})
        Me.CancelButton = BtnCerrar

        AddHandler TxtFiltro.TextChanged, AddressOf TxtFiltro_TextChanged
        AddHandler ChkOcultar.CheckedChanged, AddressOf TxtFiltro_TextChanged
        AddHandler TxtTolerancia.TextChanged, AddressOf TxtFiltro_TextChanged
        AplicarFiltro()
        AddHandler BtnExportar.Click, AddressOf BtnExportar_Click
        AddHandler BtnCerrar.Click, AddressOf BtnCerrar_Click
    End Sub

    Private Function ConstruirResumen() As String
        Dim sb As New StringBuilder
        sb.Append("Productos revisados: ").Append(_resumen.Productos)
        sb.Append("   |   Con cambios: ").Append(_resumen.ProductosConCambios)
        sb.Append("   |   Filas de facturas: ").Append(_resumen.FilasFacturaModificadas)
        sb.Append("   |   Filas de compras: ").Append(_resumen.FilasCompraModificadas)
        sb.AppendLine()
        If _resumen.FechaDesde.HasValue Then
            sb.Append("Ajuste desde el ").Append(_resumen.FechaDesde.Value.ToString("dd/MM/yyyy")).Append(": las filas anteriores no se tocan.")
        Else
            sb.Append("Ajuste de TODO el historial (sin fecha de inicio).")
        End If
        If _resumen.Cancelado Then sb.Append("   ** Simulacion cancelada: resultado parcial **")
        If _resumen.DetalleTruncado Then sb.Append("   ** Se muestran solo las primeras " & _resumen.Detalles.Count & " filas **")
        If _resumen.Errores.Count > 0 Then
            sb.AppendLine()
            sb.Append("Errores en " & _resumen.Errores.Count & " producto(s). Primero: " & _resumen.Errores(0))
        End If
        Return sb.ToString()
    End Function

    Private Sub ConstruirTabla()
        _tabla.Columns.Add("Producto", GetType(String))
        _tabla.Columns.Add("Tabla", GetType(String))
        _tabla.Columns.Add("Tipo", GetType(String))
        _tabla.Columns.Add("Documento", GetType(String))
        _tabla.Columns.Add("Fecha", GetType(Date))
        _tabla.Columns.Add("Cantidad", GetType(Double))
        _tabla.Columns.Add("CostoAnterior", GetType(Double))
        _tabla.Columns.Add("CostoNuevo", GetType(Double))
        _tabla.Columns.Add("Diferencia", GetType(Double))
        _tabla.Columns.Add("ImporteAnterior", GetType(Double))
        _tabla.Columns.Add("ImporteNuevo", GetType(Double))
        _tabla.Columns.Add("MayorDif", GetType(Double))

        _tabla.BeginLoadData()
        For Each d As CambioCostoDetalle In _resumen.Detalles
            Dim r As DataRow = _tabla.NewRow()
            r("Producto") = d.CodigoProducto
            r("Tabla") = d.Tabla
            r("Tipo") = d.Tipo
            r("Documento") = d.Numero
            r("Fecha") = d.Fecha
            r("Cantidad") = Valor(d.Cantidad)
            r("CostoAnterior") = Valor(d.CostoAnterior)
            r("CostoNuevo") = Valor(d.CostoNuevo)
            If d.CostoAnterior.HasValue AndAlso d.CostoNuevo.HasValue Then
                r("Diferencia") = d.CostoNuevo.Value - d.CostoAnterior.Value
            Else
                r("Diferencia") = DBNull.Value
            End If
            r("ImporteAnterior") = Valor(d.ImporteAnterior)
            r("ImporteNuevo") = Valor(d.ImporteNuevo)
            r("MayorDif") = d.MaxDiferencia
            _tabla.Rows.Add(r)
        Next
        _tabla.EndLoadData()
    End Sub

    Private Shared Function Valor(ByVal v As Double?) As Object
        If v.HasValue Then Return v.Value
        Return DBNull.Value
    End Function

    ' Columnas explicitas: las automaticas solo existen despues de mostrar el formulario.
    Private Sub FormatearColumnas()
        Grid.AutoGenerateColumns = False
        Grid.Columns.Clear()
        AgregarColumna("Producto", "Producto", False)
        AgregarColumna("Tabla", "Tabla", False)
        AgregarColumna("Tipo", "Tipo", False)
        AgregarColumna("Documento", "Documento", False)
        AgregarColumna("Fecha", "Fecha", False).DefaultCellStyle.Format = "dd/MM/yyyy"
        AgregarColumna("Cantidad", "Cantidad", True)
        AgregarColumna("CostoAnterior", "Costo anterior", True)
        AgregarColumna("CostoNuevo", "Costo nuevo", True)
        AgregarColumna("Diferencia", "Dif. costo", True).DefaultCellStyle.Format = "N8"
        AgregarColumna("ImporteAnterior", "Importe anterior", True)
        AgregarColumna("ImporteNuevo", "Importe nuevo", True)
        AgregarColumna("MayorDif", "Mayor dif.", True).DefaultCellStyle.Format = "N8"
    End Sub

    Private Function AgregarColumna(ByVal propiedad As String, ByVal titulo As String, ByVal numerica As Boolean) As DataGridViewTextBoxColumn
        Dim c As New DataGridViewTextBoxColumn
        c.DataPropertyName = propiedad
        c.Name = propiedad
        c.HeaderText = titulo
        If numerica Then
            c.DefaultCellStyle.Format = "N4"
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        Grid.Columns.Add(c)
        Return c
    End Function

    Private Sub TxtFiltro_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        AplicarFiltro()
    End Sub

    Private Sub AplicarFiltro()
        Dim partes As New List(Of String)
        Dim t As String = TxtFiltro.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
        If t.Length > 0 Then
            partes.Add("(Producto LIKE '%" & t & "%' OR Documento LIKE '%" & t & "%' OR Tipo LIKE '%" & t & "%')")
        End If

        Dim tol As Double
        If ChkOcultar.Checked AndAlso Double.TryParse(TxtTolerancia.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, tol) AndAlso tol >= 0 Then
            partes.Add("MayorDif > " & tol.ToString("0.##########", CultureInfo.InvariantCulture))
        End If

        _vista.RowFilter = String.Join(" AND ", partes.ToArray())
        LblConteo.Text = "Mostrando " & _vista.Count & " de " & _tabla.Rows.Count
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Using dlg As New SaveFileDialog
            dlg.Filter = "CSV (*.csv)|*.csv"
            dlg.FileName = "SimulacionCostos_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            Dim inv As CultureInfo = CultureInfo.InvariantCulture
            Dim sb As New StringBuilder
            sb.AppendLine("Producto,Tabla,Tipo,Documento,Fecha,Cantidad,CostoAnterior,CostoNuevo,Diferencia,ImporteAnterior,ImporteNuevo")
            For Each rv As DataRowView In _vista
                Dim r As DataRow = rv.Row
                sb.AppendLine(Csv(r("Producto")) & "," & Csv(r("Tabla")) & "," & Csv(r("Tipo")) & "," & Csv(r("Documento")) & "," &
                              CType(r("Fecha"), Date).ToString("yyyy-MM-dd", inv) & "," & Num(r("Cantidad")) & "," & Num(r("CostoAnterior")) & "," &
                              Num(r("CostoNuevo")) & "," & Num(r("Diferencia")) & "," & Num(r("ImporteAnterior")) & "," & Num(r("ImporteNuevo")))
            Next
            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8)
            MessageBox.Show("Exportado: " & dlg.FileName, Me.Text)
        End Using
    End Sub

    Private Shared Function Csv(ByVal o As Object) As String
        Dim s As String = If(o Is Nothing OrElse o Is DBNull.Value, "", Convert.ToString(o))
        Return """" & s.Replace("""", """""") & """"
    End Function

    Private Shared Function Num(ByVal o As Object) As String
        If o Is Nothing OrElse o Is DBNull.Value Then Return ""
        Return Convert.ToDouble(o).ToString("0.000000000", CultureInfo.InvariantCulture)
    End Function

    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

End Class
