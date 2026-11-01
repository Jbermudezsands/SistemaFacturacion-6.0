Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Pantalla de validacion del Motor de Costos (Fase 5). Compara CostoPromedioKardex (original)
''' contra el motor para un rango de productos. Solo lectura: no modifica datos.
''' Se construye por codigo (sin Designer).
''' </summary>
Public Class FrmComparadorCostos
    Inherits Form

    Private ReadOnly TxtDesde As New TextBox
    Private ReadOnly TxtHasta As New TextBox
    Private ReadOnly TxtMaxFechas As New NumericUpDown
    Private ReadOnly TxtTolerancia As New TextBox
    Private ReadOnly BtnComparar As New Button
    Private ReadOnly BtnCancelar As New Button
    Private ReadOnly BtnExportar As New Button
    Private ReadOnly Barra As New ProgressBar
    Private ReadOnly TxtLog As New TextBox

    Private _comparador As ComparadorCostos
    Private _resumen As ResumenComparacion

    Public Sub New()
        Me.Text = "Comparador Motor de Costos vs CostoPromedioKardex"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(760, 520)

        Dim y As Integer = 12
        AgregarEtiqueta("Producto desde:", 12, y + 3)
        TxtDesde.SetBounds(110, y, 150, 22)
        AgregarEtiqueta("hasta:", 275, y + 3)
        TxtHasta.SetBounds(320, y, 150, 22)

        y += 30
        AgregarEtiqueta("Fechas por producto (0 = todas):", 12, y + 3)
        TxtMaxFechas.SetBounds(200, y, 70, 22)
        TxtMaxFechas.Minimum = 0
        TxtMaxFechas.Maximum = 100000
        TxtMaxFechas.Value = 10
        AgregarEtiqueta("Tolerancia:", 290, y + 3)
        TxtTolerancia.SetBounds(360, y, 80, 22)
        TxtTolerancia.Text = "0.000001"

        BtnComparar.Text = "Comparar"
        BtnComparar.SetBounds(12, y + 32, 90, 28)
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.Enabled = False
        BtnCancelar.SetBounds(110, y + 32, 90, 28)
        BtnExportar.Text = "Exportar CSV"
        BtnExportar.Enabled = False
        BtnExportar.SetBounds(208, y + 32, 100, 28)

        Barra.SetBounds(12, y + 68, 720, 18)
        Barra.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        TxtLog.Multiline = True
        TxtLog.ScrollBars = ScrollBars.Both
        TxtLog.ReadOnly = True
        TxtLog.WordWrap = False
        TxtLog.Font = New Font("Consolas", 9.0F)
        TxtLog.SetBounds(12, y + 94, 720, 330)
        TxtLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        Me.Controls.AddRange(New Control() {TxtDesde, TxtHasta, TxtMaxFechas, TxtTolerancia, BtnComparar, BtnCancelar, BtnExportar, Barra, TxtLog})

        AddHandler BtnComparar.Click, AddressOf BtnComparar_Click
        AddHandler BtnCancelar.Click, AddressOf BtnCancelar_Click
        AddHandler BtnExportar.Click, AddressOf BtnExportar_Click
    End Sub

    Private Sub AgregarEtiqueta(ByVal texto As String, ByVal x As Integer, ByVal y As Integer)
        Dim l As New Label
        l.Text = texto
        l.AutoSize = True
        l.Location = New Point(x, y)
        Me.Controls.Add(l)
    End Sub

    Private Sub BtnComparar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim tolerancia As Double
        If Not Double.TryParse(TxtTolerancia.Text, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, tolerancia) Then
            MessageBox.Show("La tolerancia debe ser un numero con punto decimal (ejemplo 0.000001).", Me.Text)
            Return
        End If

        BtnComparar.Enabled = False
        BtnCancelar.Enabled = True
        BtnExportar.Enabled = False
        TxtLog.Clear()

        Try
            Dim repo As New RepositorioMovimientos(Conexion)
            Dim codigos As List(Of String) = repo.ListarProductos(TxtDesde.Text.Trim(), TxtHasta.Text.Trim())
            Barra.Minimum = 0
            Barra.Maximum = Math.Max(1, codigos.Count)
            Barra.Value = 0
            Log("Productos a comparar: " & codigos.Count)

            _comparador = New ComparadorCostos(Conexion)
            AddHandler _comparador.Progreso, AddressOf OnProgreso
            _resumen = _comparador.Comparar(codigos, CInt(TxtMaxFechas.Value), tolerancia)

            Log("")
            Log("Fechas comparadas : " & _resumen.FechasComparadas)
            Log("Diferencias       : " & _resumen.Diferencias.Count)
            Log("Errores           : " & _resumen.Errores.Count)
            Log("Advertencias      : " & _resumen.Advertencias.Count)
            Log("Tiempo original   : " & _resumen.MsOriginal & " ms")
            Log("Tiempo motor      : " & _resumen.MsMotor & " ms (carga + calculo)")
            If _resumen.Cancelado Then Log("** Proceso cancelado **")
            Log("")
            For Each d As DiferenciaCosto In _resumen.Diferencias
                Log(String.Format("DIF {0} {1:yyyy-MM-dd} C$ orig={2:0.000000000} motor={3:0.000000000} | US$ orig={4:0.000000000} motor={5:0.000000000} [{6}] {7}",
                                  d.CodigoProducto, d.Fecha, d.OriginalCordoba, d.MotorCordoba, d.OriginalDolar, d.MotorDolar, d.OrigenMotor, d.Nota))
            Next
            For Each er As String In _resumen.Errores
                Log("ERR " & er)
            Next
            BtnExportar.Enabled = True
        Catch ex As Exception
            Log("ERROR: " & ex.Message)
        Finally
            If _comparador IsNot Nothing Then RemoveHandler _comparador.Progreso, AddressOf OnProgreso
            BtnComparar.Enabled = True
            BtnCancelar.Enabled = False
        End Try
    End Sub

    Private Sub OnProgreso(ByVal actual As Integer, ByVal total As Integer, ByVal mensaje As String)
        Barra.Value = Math.Min(Barra.Maximum, actual)
        Me.Text = "Comparando " & actual & " de " & total & " - " & mensaje
        Application.DoEvents()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If _comparador IsNot Nothing Then _comparador.Cancelar = True
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If _resumen Is Nothing Then Return
        Using dlg As New SaveFileDialog
            dlg.Filter = "CSV (*.csv)|*.csv"
            dlg.FileName = "ComparacionCostos_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                ComparadorCostos.ExportarCsv(_resumen, dlg.FileName)
                Log("Exportado: " & dlg.FileName)
            End If
        End Using
    End Sub

    Private Sub Log(ByVal texto As String)
        TxtLog.AppendText(texto & Environment.NewLine)
    End Sub

End Class
