Imports System.Math

'Ventana de pagos para facturas de contado. Trabaja en memoria: recibe los metodos ya digitados en la factura
'(MetodosIniciales) y devuelve el resultado en la propiedad Resultado; el grabado lo hace FrmFacturas junto con la factura.
Public Class FrmPagoContado
    Public MontoAPagar As Double = 0
    Public MonedaFactura As String = "Cordobas"
    Public FechaFactura As Date = Date.Today
    Public MetodosIniciales As DataTable = Nothing
    Public Resultado As DataTable = Nothing

    Private ActualizandoMonedaMetodo As Boolean = False
    Private DtMetodos As New DataTable
    'Numero de tarjeta/cheque y vencimiento por metodo, para no perderlos al reaplicar
    Private DatosTarjeta As New System.Collections.Generic.Dictionary(Of String, Object())(StringComparer.OrdinalIgnoreCase)

    Private Sub FrmPagoContado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using cn As New SqlClient.SqlConnection(Conexion)
            Using da As New SqlClient.SqlDataAdapter("SELECT * FROM MetodoPago", cn)
                da.Fill(DtMetodos)
            End Using
        End Using

        Me.CboMetodoPago.DataSource = DtMetodos
        Me.CboMetodoPago.Text = "Efectivo"

        Me.TxtTotalApagar.Text = Format(MontoAPagar, "##,##0.00")
        Borrar(Me.TxtImporte.Text)

        Cargar_Pagos()
    End Sub

    Private Sub Cargar_Pagos()
        Dim Fila As DataRow, Moneda As String

        If MetodosIniciales IsNot Nothing Then
            For Each Fila In MetodosIniciales.Rows
                If IsDBNull(Fila("NombrePago")) OrElse IsDBNull(Fila("Monto")) Then Continue For

                Moneda = MonedaMetodo(CStr(Fila("NombrePago")))
                If Moneda = "" Then Moneda = MonedaFactura

                Me.ListBoxMetodos.Items.Add(CStr(Fila("NombrePago")) & " - " & Moneda & " - " & Format(CDbl(Fila("Monto")), "0.00"))

                If Not IsDBNull(Fila("NumeroTarjeta")) AndAlso Not IsDBNull(Fila("FechaVence")) Then
                    DatosTarjeta(CStr(Fila("NombrePago")).Trim()) = New Object() {Fila("NumeroTarjeta"), Fila("FechaVence")}
                End If
            Next
        End If

        Me.TxtImporte.Text = "0.00"
        Me.txtTotalPagado.Text = CStr(CalcularPago(0, Me.CboMoneda.Text))

        Leer("C")
    End Sub

    '------------------------------------------------------------------------------------------
    ' Datos del catalogo de metodos de pago
    '------------------------------------------------------------------------------------------
    Private Function FilaMetodo(NombrePago As String) As DataRow
        Dim Filas() As DataRow = DtMetodos.Select("NombrePago = '" & Replace(NombrePago.Trim(), "'", "''") & "'")
        If Filas.Length = 0 Then Return Nothing
        Return Filas(0)
    End Function

    Private Function MonedaMetodo(NombrePago As String) As String
        Dim Fila As DataRow = FilaMetodo(NombrePago)
        If Fila Is Nothing OrElse IsDBNull(Fila("Moneda")) Then Return ""
        Return CStr(Fila("Moneda")).Trim()
    End Function

    Private Function TipoMetodo(NombrePago As String) As String
        Dim Fila As DataRow = FilaMetodo(NombrePago)
        If Fila Is Nothing OrElse IsDBNull(Fila("TipoPago")) Then Return ""
        Return CStr(Fila("TipoPago")).Trim()
    End Function

    'Convierte un monto de la moneda indicada a la moneda de la factura
    Private Function ConvertirAMonedaFactura(Monto As Double, Moneda As String) As Double
        Moneda = Moneda.Trim()
        If Moneda = MonedaFactura OrElse Moneda = "" Then Return Monto

        If Moneda = "Cordobas" Then
            Return Monto / BuscaTasaCambio(FechaFactura)
        ElseIf Moneda = "Dolares" Then
            Return Monto * BuscaTasaCambio(FechaFactura)
        End If

        Return Monto
    End Function

    'Interpreta un elemento de ListBoxMetodos con formato "Nombre - Moneda - Monto".
    'Se toman la moneda y el monto desde el final para tolerar guiones en el nombre.
    Private Function ParsearMetodo(Cadena As String, ByRef NombrePago As String, ByRef MonedaPago As String, ByRef Monto As Double) As Boolean
        Dim Separador As String = " - "
        Dim PosMonto As Integer = Cadena.LastIndexOf(Separador)
        If PosMonto <= 0 Then Return False

        Dim PosMoneda As Integer = Cadena.LastIndexOf(Separador, PosMonto - 1)
        If PosMoneda <= 0 Then Return False

        NombrePago = Cadena.Substring(0, PosMoneda).Trim()
        MonedaPago = Cadena.Substring(PosMoneda + Separador.Length, PosMonto - PosMoneda - Separador.Length).Trim()

        Return Double.TryParse(Cadena.Substring(PosMonto + Separador.Length).Trim(),
                               Globalization.NumberStyles.Number,
                               Globalization.CultureInfo.CurrentCulture,
                               Monto)
    End Function

    '------------------------------------------------------------------------------------------
    ' Calculos
    '------------------------------------------------------------------------------------------
    Public Function CalcularPago(Numero_Pantalla As Double, MonedaPantalla As String) As Double
        Dim i As Integer, NombrePago As String = "", MonedaPago As String = "", Monto As Double = 0
        Dim MontoPago As Double = 0, TotalApagar As Double, TotalPagado As Double, Diferencia As Double

        Numero_Pantalla = ConvertirAMonedaFactura(Numero_Pantalla, MonedaPantalla)

        '////////////////////////////DATOS EN PANTALLA ///////////////////////////
        If Me.CboMetodoPago.Text.Trim() <> "" AndAlso TipoMetodo(Me.CboMetodoPago.Text) = "Cambio" Then
            Numero_Pantalla = Numero_Pantalla * -1
        End If

        For i = 0 To Me.ListBoxMetodos.Items.Count - 1
            If Not ParsearMetodo(CStr(Me.ListBoxMetodos.Items(i)), NombrePago, MonedaPago, Monto) Then
                Throw New Exception("El método de pago tiene un formato incorrecto: " & CStr(Me.ListBoxMetodos.Items(i)))
            End If

            If TipoMetodo(NombrePago) = "Cambio" Then
                Monto = Monto * -1
            End If

            MontoPago = MontoPago + ConvertirAMonedaFactura(Monto, MonedaPago)
        Next

        TotalApagar = Val(Replace(Me.TxtTotalApagar.Text, ",", ""))
        TotalPagado = Round(MontoPago + Numero_Pantalla, 2)
        Diferencia = Round(TotalApagar - TotalPagado, 2)

        If Diferencia > 0 Then
            TxtSaldoDeudor.Text = Format(Diferencia, "##,##0.00")
            TxtSaldoFavor.Text = "0.00"
            txtDiferencia.Text = Format(Diferencia, "##,##0.00")
            Me.TxtCambio.Text = "0.00"
        ElseIf Diferencia < 0 Then
            TxtSaldoDeudor.Text = "0.00"
            TxtSaldoFavor.Text = Format(Abs(Diferencia), "##,##0.00")
            txtDiferencia.Text = Format(Diferencia, "##,##0.00")
            TxtCambio.Text = Format(Abs(Diferencia), "##,##0.00")
        Else
            TxtSaldoDeudor.Text = "0.00"
            TxtSaldoFavor.Text = "0.00"
            txtDiferencia.Text = "0.00"
            TxtCambio.Text = "0.00"
        End If

        Return TotalPagado
    End Function

    Public Sub Borrar(Numero As Double)
        Dim Cadena As String, Longitud As Integer, CadenaNueva As String, Numero_Nuevo As Double = 0

        If Numero = 0 Then Exit Sub

        Cadena = CStr(Numero)
        Longitud = Len(Cadena)
        CadenaNueva = Mid(Cadena, 1, Longitud - 1)
        If CadenaNueva <> "" Then
            Numero_Nuevo = Val(CadenaNueva)
        End If

        Me.TxtImporte.Text = Format(Numero_Nuevo, "##,##0.00")
        Me.TxtImporte.Focus()
    End Sub

    Public Sub Leer(Numero As String)
        Dim Numero_Pantalla As Double = 0, TotalApagar As Double = 0, Diferencia As Double = 0
        Dim Cambio As Double = 0, UltDigito As String = ""
        Dim SaldoDeudor As Double = 0, MontoPagado As Double = 0

        If IsNumeric(TxtTotalApagar.Text) Then
            TotalApagar = CDbl(TxtTotalApagar.Text)
        End If

        '////////////////////////////VERIFICO SI EL ULTIMO DIGITO ES PUNTO
        If Me.TxtImporte.Text <> "" Then
            UltDigito = Mid(TxtImporte.Text, Len(TxtImporte.Text), Len(TxtImporte.Text))
        End If

        If IsNumeric(Me.TxtImporte.Text) Then
            Numero_Pantalla = CDbl(Me.TxtImporte.Text)
        Else
            TxtImporte.Text = "0.00"
            Numero_Pantalla = 0
        End If

        Select Case Numero
            Case "C"
                TxtImporte.Text = "0.00"
                TxtCambio.Text = "0.00"
                TxtSaldoFavor.Text = "0.00"
                TxtSaldoDeudor.Text = TxtTotalApagar.Text
                txtTotalPagado.Text = "0.00"
                txtDiferencia.Text = "0.00"

            Case "OK"
                TxtTotalApagar.Text = Format(TotalApagar, "##,##0.00")
                TxtImporte.Text = Format(Numero_Pantalla, "##,##0.00")
                Diferencia = TotalApagar - Numero_Pantalla
                TxtCambio.Text = Format(Diferencia, "##,##0.00")

                If Diferencia > 0 Then
                    TxtSaldoDeudor.Text = Format(Diferencia, "##,##0.00")
                    TxtSaldoFavor.Text = "0.00"
                    txtDiferencia.Text = Format(Diferencia, "##,##0.00")
                ElseIf Diferencia < 0 Then
                    TxtSaldoDeudor.Text = "0.00"
                    TxtSaldoFavor.Text = Format(Abs(Diferencia), "##,##0.00")
                    txtDiferencia.Text = Format(Diferencia, "##,##0.00")
                End If

            Case "DEL"
                Borrar(Val(Replace(TxtImporte.Text, ",", "")))

            Case "."
                'Se parte de la parte entera (el texto puede ser "12.00") y se ignora si ya hay decimales
                If UltDigito <> "." AndAlso Not CStr(Numero_Pantalla).Contains(".") Then
                    TxtImporte.Text = CStr(Numero_Pantalla) & "."
                End If

        End Select

        If IsNumeric(Me.TxtImporte.Text) Then
            If Numero <> "." Then
                Numero_Pantalla = CDbl(Me.TxtImporte.Text)
            End If
        Else
            TxtImporte.Text = "0.00"
            Numero_Pantalla = 0
        End If

        If IsNumeric(Numero) Then
            If UltDigito <> "." Then
                Numero_Pantalla = Val(CStr(Numero_Pantalla) & CStr(Numero))
            Else
                Numero_Pantalla = Val(CStr(Numero_Pantalla) & "." & CStr(Numero))
            End If
        End If

        If Numero <> "." Then
            Me.TxtImporte.Text = CStr(Numero_Pantalla)
        End If

        MontoPagado = CalcularPago(Numero_Pantalla, Me.CboMoneda.Text)

        If MontoPagado >= MontoAPagar Then
            Cambio = MontoPagado - MontoAPagar
            TxtCambio.Text = Format(Cambio, "##,##0.00")
            TxtSaldoFavor.Text = Format(Cambio, "##,##0.00")
            TxtSaldoDeudor.Text = Format(0, "##,##0.00")
            txtTotalPagado.Text = Format(MontoPagado, "##,##0.00")
            'Diferencia = a pagar - pagado (negativa cuando hay cambio), igual que en CalcularPago
            txtDiferencia.Text = Format(-Cambio, "##,##0.00")
        Else
            TxtCambio.Text = Format(0, "##,##0.00")
            TxtSaldoFavor.Text = Format(0, "##,##0.00")
            txtTotalPagado.Text = Format(MontoPagado, "##,##0.00")
            SaldoDeudor = MontoAPagar - MontoPagado
            TxtSaldoDeudor.Text = Format(SaldoDeudor, "##,##0.00")
            txtDiferencia.Text = Format(SaldoDeudor, "##,##0.00")
        End If
    End Sub

    '------------------------------------------------------------------------------------------
    ' Agregar cambio / saldo como metodo
    '------------------------------------------------------------------------------------------
    Private Function BuscaMetodoPorTipo(TipoPago As String) As DataRow
        Dim Filas() As DataRow = DtMetodos.Select("TipoPago LIKE '%" & TipoPago & "%' AND Moneda = '" & MonedaFactura & "'")
        If Filas.Length > 0 Then Return Filas(0)

        Filas = DtMetodos.Select("TipoPago LIKE '%" & TipoPago & "%'")
        If Filas.Length > 0 Then Return Filas(0)

        Return Nothing
    End Function

    Public Sub AgregarMetodo(TipoPago As String)
        Dim Monto As Double = 0, Fila As DataRow

        If TipoPago = "Cambio" Then
            Monto = Val(Replace(Me.TxtCambio.Text, ",", ""))
        ElseIf TipoPago = "Efectivo" Then
            Monto = Val(Replace(Me.TxtSaldoDeudor.Text, ",", ""))
        End If

        If Monto = 0 Then Exit Sub

        Fila = BuscaMetodoPorTipo(TipoPago)
        If Fila Is Nothing Then
            MsgBox("No existe un método de pago de tipo " & TipoPago & " configurado", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        Me.ListBoxMetodos.Items.Add(CStr(Fila("NombrePago")) & " - " & CStr(Fila("Moneda")).Trim() & " - " & Format(Monto, "0.00"))

        Leer("C")
        Me.txtTotalPagado.Text = Format(CalcularPago(0, Me.CboMoneda.Text), "##,##0.00")
    End Sub

    'Pide el numero y vencimiento cuando el metodo es tarjeta o cheque
    Private Sub PedirDatosTarjeta(NombrePago As String)
        Dim Tipo As String = TipoMetodo(NombrePago)

        If Tipo <> "Tarjetas" AndAlso Tipo <> "Cheques" Then Exit Sub

        If Tipo = "Tarjetas" Then
            My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = "####-####-####-####"
        Else
            My.Forms.FrmMetodosPagos.TxtNumeroTarjeta.Mask = ""
        End If

        My.Forms.FrmMetodosPagos.ShowDialog()

        If My.Forms.FrmMetodosPagos.Numero <> "" Then
            Dim FechaVence As Date = FechaFactura
            If My.Forms.FrmMetodosPagos.Fecha <> "" Then
                Date.TryParse(My.Forms.FrmMetodosPagos.Fecha, FechaVence)
            End If
            DatosTarjeta(NombrePago.Trim()) = New Object() {My.Forms.FrmMetodosPagos.Numero, FechaVence}
        End If
    End Sub

    '------------------------------------------------------------------------------------------
    ' Aplicar: arma la tabla de resultado (no graba en la base de datos)
    '------------------------------------------------------------------------------------------
    Private Function ArmarResultado() As Boolean
        Dim i As Integer, NombrePago As String = "", MonedaPago As String = "", Monto As Double = 0
        Dim Totales As New System.Collections.Generic.Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
        Dim Orden As New System.Collections.Generic.List(Of String)
        Dim Datos() As Object = Nothing, Fila As DataRow, Cambio As Double

        '--------- Agrego el cambio como metodo de pago ---------
        Cambio = Val(Replace(Me.TxtCambio.Text, ",", ""))
        If Cambio <> 0 Then
            Dim FilaCambio As DataRow = BuscaMetodoPorTipo("Cambio")
            If FilaCambio IsNot Nothing Then
                Me.ListBoxMetodos.Items.Add(CStr(FilaCambio("NombrePago")) & " - " & CStr(FilaCambio("Moneda")).Trim() & " - " & Format(Cambio, "0.00"))
            End If
        End If

        'La llave primaria incluye NombrePago: los elementos repetidos se suman en una sola fila
        For i = 0 To Me.ListBoxMetodos.Items.Count - 1
            If Not ParsearMetodo(CStr(Me.ListBoxMetodos.Items(i)), NombrePago, MonedaPago, Monto) Then
                MsgBox("El método de pago tiene un formato incorrecto: " & CStr(Me.ListBoxMetodos.Items(i)), MsgBoxStyle.Critical, "Zeus Facturacion")
                Return False
            End If

            If Totales.ContainsKey(NombrePago) Then
                Totales(NombrePago) += CDec(Monto)
            Else
                Totales.Add(NombrePago, CDec(Monto))
                Orden.Add(NombrePago)
            End If
        Next

        Resultado = New DataTable
        Resultado.Columns.Add("NombrePago", GetType(String))
        Resultado.Columns.Add("Monto", GetType(Double))
        Resultado.Columns.Add("NumeroTarjeta", GetType(String))
        Resultado.Columns.Add("FechaVence", GetType(Date))

        For Each NombrePago In Orden
            Fila = Resultado.NewRow()
            Fila("NombrePago") = NombrePago
            Fila("Monto") = CDbl(Totales(NombrePago))

            If DatosTarjeta.TryGetValue(NombrePago, Datos) Then
                Fila("NumeroTarjeta") = CStr(Datos(0))
                Fila("FechaVence") = CDate(Datos(1))
            Else
                Fila("NumeroTarjeta") = "0000"
                Fila("FechaVence") = FechaFactura
            End If

            Resultado.Rows.Add(Fila)
        Next

        Return True
    End Function

    '------------------------------------------------------------------------------------------
    ' Eventos
    '------------------------------------------------------------------------------------------
    Private Sub Cmd1_Click(sender As Object, e As EventArgs) Handles Cmd1.Click
        Leer("1")
    End Sub

    Private Sub Cmd2_Click(sender As Object, e As EventArgs) Handles Cmd2.Click
        Leer("2")
    End Sub

    Private Sub Cmd3_Click(sender As Object, e As EventArgs) Handles Cmd3.Click
        Leer("3")
    End Sub

    Private Sub Cmd4_Click(sender As Object, e As EventArgs) Handles Cmd4.Click
        Leer("4")
    End Sub

    Private Sub Cmd5_Click(sender As Object, e As EventArgs) Handles Cmd5.Click
        Leer("5")
    End Sub

    Private Sub Cmd6_Click(sender As Object, e As EventArgs) Handles Cmd6.Click
        Leer("6")
    End Sub

    Private Sub Cmd7_Click(sender As Object, e As EventArgs) Handles Cmd7.Click
        Leer("7")
    End Sub

    Private Sub Cmd8_Click(sender As Object, e As EventArgs) Handles Cmd8.Click
        Leer("8")
    End Sub

    Private Sub Cmd9_Click(sender As Object, e As EventArgs) Handles Cmd9.Click
        Leer("9")
    End Sub

    Private Sub Cmd0_Click(sender As Object, e As EventArgs) Handles Cmd0.Click
        Leer("0")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Leer(".")
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        Leer("OK")
    End Sub

    Private Sub CmdDEL_Click(sender As Object, e As EventArgs) Handles CmdDEL.Click
        Leer("DEL")
    End Sub

    Private Sub CmdC_Click(sender As Object, e As EventArgs) Handles CmdC.Click
        Leer("C")
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CboMetodoPago_TextChanged(sender As Object, e As EventArgs) Handles CboMetodoPago.TextChanged
        If ActualizandoMonedaMetodo Then Exit Sub

        Try
            ActualizandoMonedaMetodo = True

            CboMoneda.Text = MonedaMetodo(CboMetodoPago.Text)
            Me.TxtImporte.Text = "0.00"
            Leer("C")
        Finally
            ActualizandoMonedaMetodo = False
        End Try
    End Sub

    Private Sub CboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMoneda.SelectedIndexChanged
        If ActualizandoMonedaMetodo Then Exit Sub

        Try
            ActualizandoMonedaMetodo = True
            ActualizarMetodoPagoPorMoneda()
        Finally
            ActualizandoMonedaMetodo = False
        End Try
    End Sub

    'Al cambiar la moneda busca el mismo metodo en la otra moneda (los metodos en dolares terminan en " $")
    Private Sub ActualizarMetodoPagoPorMoneda()
        If CboMetodoPago.SelectedIndex < 0 Then Exit Sub
        If CboMoneda.SelectedIndex < 0 Then Exit Sub

        Dim MetodoActual As String = CboMetodoPago.Text.Trim()
        Dim MonedaActual As String = CboMoneda.Text.Trim()
        Dim NuevoMetodo As String

        If MetodoActual.EndsWith("$") Then
            MetodoActual = MetodoActual.Substring(0, MetodoActual.Length - 1).Trim()
        End If

        If MonedaActual.Equals("Dolares", StringComparison.OrdinalIgnoreCase) Then
            NuevoMetodo = MetodoActual & " $"
        ElseIf MonedaActual.Equals("Cordobas", StringComparison.OrdinalIgnoreCase) Then
            NuevoMetodo = MetodoActual
        Else
            Exit Sub
        End If

        Dim Indice As Integer = CboMetodoPago.FindStringExact(NuevoMetodo)
        If Indice >= 0 Then
            CboMetodoPago.SelectedIndex = Indice
        End If
    End Sub

    'Agrega el importe digitado al ListBoxMetodos con el metodo y moneda seleccionados.
    'Valida que el importe no este en blanco, sea numerico y mayor que cero.
    Private Sub AgregarImporteDigitado()
        If CboMetodoPago.Text.Trim() = "" OrElse CboMoneda.Text.Trim() = "" Then
            MsgBox("Seleccione el método de pago y la moneda", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        Dim Importe As Double = 0
        Dim Texto As String = Me.TxtImporte.Text.Trim()

        If Texto = "" OrElse Not Double.TryParse(Texto, Globalization.NumberStyles.Number, Globalization.CultureInfo.CurrentCulture, Importe) Then
            MsgBox("Digite un importe numérico", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Importe <= 0 Then
            MsgBox("Digite un importe mayor que cero", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        PedirDatosTarjeta(CboMetodoPago.Text.Trim())

        Me.ListBoxMetodos.Items.Add(CboMetodoPago.Text.Trim() & " - " & CboMoneda.Text.Trim() & " - " & Format(Importe, "0.00"))

        Me.TxtImporte.Text = "0.00"
        Me.txtTotalPagado.Text = Format(CalcularPago(0, Me.CboMoneda.Text), "##,##0.00")
    End Sub

    Private Sub C1Button1_Click(sender As Object, e As EventArgs) Handles C1Button1.Click
        AgregarImporteDigitado()
    End Sub

    Private Sub TxtImporte_DoubleClick(sender As Object, e As EventArgs) Handles TxtImporte.DoubleClick
        AgregarImporteDigitado()
    End Sub

    'Doble click sobre el cambio: lo agrega como metodo de tipo "Cambio" (vuelto)
    Private Sub TxtCambio_DoubleClick(sender As Object, e As EventArgs) Handles TxtCambio.DoubleClick
        If Val(Replace(Me.TxtCambio.Text, ",", "")) = 0 Then Exit Sub
        AgregarMetodo("Cambio")
    End Sub

    Private Sub C1Button2_Click(sender As Object, e As EventArgs) Handles C1Button2.Click
        If Me.ListBoxMetodos.SelectedItem Is Nothing Then
            MsgBox("Seleccione el método de pago que desea quitar", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        ListBoxMetodos.Items.Remove(Me.ListBoxMetodos.SelectedItem)

        Me.TxtImporte.Text = "0.00"
        Me.txtTotalPagado.Text = Format(CalcularPago(0, Me.CboMoneda.Text), "##,##0.00")
    End Sub

    Private Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If Val(Me.TxtImporte.Text) <> 0 Then
            MsgBox("Agrego el monto digitado antes de aplicar", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Val(Me.TxtCambio.Text) <> 0 Then
            MsgBox("Aplique el cambio antes de aplicar", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Val(Me.TxtSaldoDeudor.Text) <> 0 Then
            MsgBox("Agrego el saldo pendiente antes de aplicar", vbExclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Not ArmarResultado() Then Exit Sub

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Label4_DoubleClick(sender As Object, e As EventArgs) Handles Label4.DoubleClick
        AgregarMetodo("Cambio")
    End Sub

    Private Sub Label6_DoubleClick(sender As Object, e As EventArgs) Handles Label6.DoubleClick
        AgregarMetodo("Efectivo")
    End Sub
End Class
