Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

'=====================================================================================================
'  ESTILO MODERNO REUTILIZABLE PARA FORMULARIOS DE BÁSCULA (Recepción, Báscula, Facturación...)
'
'  Cambia solo la apariencia y la disposición (colores, fuentes, botones planos, fecha y hora grandes);
'  no toca la lógica ni los datos de los formularios.
'=====================================================================================================
Public NotInheritable Class BasculaDisenio

    Private Sub New()
    End Sub

    Public Shared ReadOnly ColorFondo As Color = Color.FromArgb(243, 245, 248)
    Public Shared ReadOnly ColorPrimario As Color = Color.FromArgb(27, 94, 32)     ' verde de la marca
    Public Shared ReadOnly ColorPrimarioOscuro As Color = Color.FromArgb(20, 70, 24)
    Public Shared ReadOnly ColorPeligro As Color = Color.FromArgb(192, 57, 43)
    Public Shared ReadOnly ColorNeutro As Color = Color.FromArgb(52, 73, 94)
    Public Shared ReadOnly ColorTexto As Color = Color.FromArgb(33, 37, 41)
    Public Shared ReadOnly ColorEncabezado As Color = Color.FromArgb(30, 58, 95)

    Public Const FuenteBase As String = "Segoe UI"

    ''' <summary>Fondo, fuente y maximizado. Llamar en el Load del formulario.</summary>
    Public Shared Sub PrepararFormulario(ByVal frm As Form, ByVal maximizar As Boolean)
        ' Sin esto, cambiar la fuente del formulario reescala (agranda) todos sus controles.
        frm.AutoScaleMode = AutoScaleMode.None
        frm.BackColor = ColorFondo
        If frm.Font.Name <> FuenteBase Then frm.Font = New Font(FuenteBase, 9.75!, FontStyle.Regular, GraphicsUnit.Point)
        frm.MinimumSize = New Size(1024, 640)
        frm.StartPosition = FormStartPosition.CenterScreen
        If maximizar Then frm.WindowState = FormWindowState.Maximized
    End Sub

    ''' <summary>Botón plano con color de acento.</summary>
    Public Shared Sub EstiloBoton(ByVal btn As Button, ByVal color As Color)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = color
        btn.ForeColor = Color.White
        btn.UseVisualStyleBackColor = False
        btn.Cursor = Cursors.Hand
        If btn.Font.Name <> FuenteBase OrElse btn.Font.Size <> 11.0! OrElse Not btn.Font.Bold Then btn.Font = New Font(FuenteBase, 11.0!, FontStyle.Bold, GraphicsUnit.Point)
        btn.ImageAlign = ContentAlignment.MiddleLeft
        btn.TextAlign = ContentAlignment.MiddleCenter
        btn.TextImageRelation = TextImageRelation.ImageBeforeText
    End Sub

    ''' <summary>GroupBox como tarjeta blanca.</summary>
    Public Shared Sub EstiloTarjeta(ByVal gb As GroupBox)
        gb.BackColor = Color.White
        gb.ForeColor = ColorTexto
        gb.FlatStyle = FlatStyle.Standard
        If gb.Font.Name <> FuenteBase Then gb.Font = New Font(FuenteBase, 9.75!, FontStyle.Regular, GraphicsUnit.Point)
        TextoOscuro(gb)
    End Sub

    ''' <summary>Las etiquetas del diseño anterior eran blancas (fondo oscuro): en tarjeta blanca se oscurecen.</summary>
    Private Shared Sub TextoOscuro(ByVal contenedor As Control)
        For Each c As Control In contenedor.Controls
            If TypeOf c Is Label OrElse TypeOf c Is CheckBox OrElse TypeOf c Is RadioButton Then
                If c.ForeColor.GetBrightness() > 0.8! Then c.ForeColor = ColorTexto
            ElseIf c.HasChildren AndAlso Not (TypeOf c Is TextBox) Then
                TextoOscuro(c)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Pone la fecha y la hora SIEMPRE grandes: el tamaño de letra crece con el ancho disponible
    ''' (mínimo 28 pt) y los dos textos se centran en la tarjeta.
    ''' </summary>
    Public Shared Sub AjustarFechaHora(ByVal tarjeta As Control, ByVal lblFecha As Label, ByVal lblHora As Label)
        If tarjeta.Width <= 0 OrElse tarjeta.Height <= 0 Then Return

        Dim mitad As Integer = CInt((tarjeta.Width - 24) / 2)
        Dim tam As Single = 28.0!
        Dim maxTam As Single = 44.0!

        ' El más largo de los dos textos decide el tamaño: no debe salirse de su mitad.
        Dim textoFecha As String = "00/00/0000"
        Dim textoHora As String = "00:00:00 PM"

        Dim t As Single = maxTam
        Do While t > 28.0!
            Using f As New Font(FuenteBase, t, FontStyle.Bold, GraphicsUnit.Point)
                Dim a As Size = TextRenderer.MeasureText(textoFecha, f)
                Dim b As Size = TextRenderer.MeasureText(textoHora, f)
                If a.Width <= mitad AndAlso b.Width <= mitad AndAlso a.Height + 22 <= tarjeta.Height Then Exit Do
            End Using
            t -= 2.0!
        Loop
        tam = Math.Max(28.0!, t)

        For Each lbl As Label In New Label() {lblFecha, lblHora}
            lbl.AutoSize = False
            If lbl.Font.Size <> tam OrElse lbl.Font.Style <> FontStyle.Bold Then lbl.Font = New Font(FuenteBase, tam, FontStyle.Bold, GraphicsUnit.Point)
            lbl.ForeColor = ColorPrimarioOscuro
            lbl.TextAlign = ContentAlignment.MiddleCenter
            lbl.Height = tarjeta.Height - 26
            lbl.Width = mitad
            lbl.Top = 20
        Next
        lblFecha.Left = 8
        lblHora.Left = 16 + mitad
    End Sub

    ''' <summary>Reparte los botones de un panel en columna ocupando todo su alto.</summary>
    Public Shared Sub DistribuirBotonesVertical(ByVal panel As Control, ByVal colores As Dictionary(Of Control, Color))
        Dim botones As New System.Collections.Generic.List(Of Button)
        For Each c As Control In panel.Controls
            Dim b As Button = TryCast(c, Button)
            If b IsNot Nothing AndAlso b.Visible Then botones.Add(b)
        Next
        If botones.Count = 0 Then Return
        botones.Sort(Function(a As Button, b As Button) a.Top.CompareTo(b.Top))

        Dim margen As Integer = 8
        Dim util As Integer = panel.Height - 28 - margen
        Dim alto As Integer = Math.Min(72, Math.Max(44, CInt((util - margen * (botones.Count - 1)) / botones.Count)))
        Dim y As Integer = 20
        For Each b As Button In botones
            b.SetBounds(margen, y, panel.Width - margen * 2, alto)
            y += alto + margen
            Dim col As Color = ColorPrimario
            If colores IsNot Nothing AndAlso colores.ContainsKey(b) Then col = colores(b)
            EstiloBoton(b, col)
        Next
    End Sub

    ''' <summary>Reparte los botones visibles de un panel en una fila ocupando todo su ancho.</summary>
    Public Shared Sub DistribuirBotonesHorizontal(ByVal panel As Control, ByVal colores As Dictionary(Of Control, Color))
        Dim botones As New System.Collections.Generic.List(Of Button)
        For Each c As Control In panel.Controls
            Dim b As Button = TryCast(c, Button)
            If b IsNot Nothing AndAlso b.Visible Then botones.Add(b)
        Next
        If botones.Count = 0 Then Return
        botones.Sort(Function(a As Button, b As Button) a.Left.CompareTo(b.Left))

        Dim margen As Integer = 8
        Dim ancho As Integer = Math.Min(190, Math.Max(90, CInt((panel.Width - margen * (botones.Count + 1)) / botones.Count)))
        Dim x As Integer = margen
        For Each b As Button In botones
            b.SetBounds(x, 20, ancho, Math.Max(40, panel.Height - 28))
            x += ancho + margen
            Dim col As Color = ColorPrimario
            If colores IsNot Nothing AndAlso colores.ContainsKey(b) Then col = colores(b)
            EstiloBoton(b, col)
        Next
    End Sub

    ''' <summary>Texto y color del indicador de estado de la báscula.</summary>
    Public Shared Sub MostrarEstado(ByVal lbl As Label, ByVal estado As EstadoBascula)
        lbl.AutoSize = False
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.Font = New Font(FuenteBase, 12.0!, FontStyle.Bold, GraphicsUnit.Point)
        lbl.ForeColor = Color.White
        Select Case estado
            Case EstadoBascula.Conectado
                lbl.Text = "CONECTADO"
                lbl.BackColor = ColorPrimario
            Case EstadoBascula.Reconectando
                lbl.Text = "RECONECTANDO"
                lbl.BackColor = Color.FromArgb(230, 126, 34)
            Case EstadoBascula.Error
                lbl.Text = "ERROR"
                lbl.BackColor = ColorPeligro
            Case Else
                lbl.Text = "DESCONECTADO"
                lbl.BackColor = Color.FromArgb(108, 117, 125)
        End Select
    End Sub

    ''' <summary>Aplica el estilo a todos los botones normales de un contenedor (recursivo).</summary>
    Public Shared Sub EstiloBotonesDe(ByVal contenedor As Control, ByVal color As Color)
        For Each c As Control In contenedor.Controls
            Dim b As Button = TryCast(c, Button)
            If b IsNot Nothing Then EstiloBoton(b, color)
            If c.HasChildren Then EstiloBotonesDe(c, color)
        Next
    End Sub

    ''' <summary>Encabezado de la rejilla C1 (aplica si el control expone HeadingStyle).</summary>
    Public Shared Sub EstiloRejillaC1(ByVal grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            grid.Font = New Font(FuenteBase, 10.5!, FontStyle.Regular, GraphicsUnit.Point)
            grid.HeadingStyle.BackColor = ColorEncabezado
            grid.HeadingStyle.ForeColor = Color.White
            grid.HeadingStyle.Font = New Font(FuenteBase, 10.0!, FontStyle.Bold, GraphicsUnit.Point)
            ' Título ("Listado de Productos") sobre fondo celeste: texto azul oscuro, no blanco.
            grid.CaptionStyle.ForeColor = Color.FromArgb(30, 58, 95)
            grid.CaptionStyle.Font = New Font(FuenteBase, 10.0!, FontStyle.Bold, GraphicsUnit.Point)
            ' Texto de las filas legible sobre el fondo claro.
            grid.Style.ForeColor = Color.FromArgb(33, 37, 41)
            grid.EvenRowStyle.ForeColor = Color.FromArgb(33, 37, 41)
            grid.OddRowStyle.ForeColor = Color.FromArgb(33, 37, 41)
            grid.RowHeight = 28
            grid.ColumnHeaders = True
        Catch
            ' el estilo no es crítico
        End Try
    End Sub
End Class
