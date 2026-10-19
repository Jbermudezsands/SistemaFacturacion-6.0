Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmDesembolsos

    Private Const TITULO As String = "Sistema de Facturación"

    ''' <summary>Código del tipo de préstamo. Lo asigna FrmConsultas al seleccionar el préstamo.</summary>
    Public CodigoTipoPrestamo As String

    Private _prestamoCargado As String = Nothing ' Evita recargar las grillas con el mismo préstamo

    ' Mismas columnas que espera la configuración (PropBag) de cada grilla.
    ' {0} = columna adicional "Desembolso", solo para la grilla de débitos.
    Private Const SQL_MOVIMIENTOS As String = _
        "SELECT MovPrestamo.NumPrestamo, MovPrestamo.CodTipoPrestamo, MovPrestamo.NumCuota, {0}" & _
        "MovPrestamo.Dias, MovPrestamo.Tipo, MovPrestamo.Monto, MovPrestamo.Interes, MovPrestamo.MantoValor, " & _
        "MovPrestamo.Saldo, MovPrestamo.Mora, MovPrestamo.Fecha, MovPrestamo.FechaMora, Prestamo.Cancelado " & _
        "FROM Prestamo INNER JOIN MovPrestamo " & _
        "  ON Prestamo.CodTipoPrestamo = MovPrestamo.CodTipoPrestamo " & _
        " AND Prestamo.NumPrestamo = MovPrestamo.NumPrestamo " & _
        "WHERE MovPrestamo.NumPrestamo = @NumPrestamo " & _
        "  AND MovPrestamo.Tipo = @Tipo " & _
        "  AND Prestamo.Cancelado = 'False' " & _
        "ORDER BY MovPrestamo.NumCuota, MovPrestamo.Fecha"

#Region "Eventos de controles"

    Private Sub CmdButtonSucursal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdButtonSucursal.Click
        ' FrmConsultas llena los datos del préstamo en este formulario
        Quien = "Desembolso"
        My.Forms.FrmConsultas.Show()
    End Sub

    Private Sub CmdDesemolsar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdDesemolsar.Click
        Desembolsar()
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    ' Si el número lo asigna otro formulario (FrmConsultas), se cargan las grillas al instante.
    ' Si lo escribe el usuario, se espera a que salga del campo o presione Enter
    ' (antes se consultaba la base en cada tecla).
    Private Sub TxtNumPrestamo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNumPrestamo.TextChanged
        If TxtNumPrestamo.Focused Then Exit Sub
        CargarMovimientos()
    End Sub

    Private Sub TxtNumPrestamo_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles TxtNumPrestamo.Validated
        CargarMovimientos()
    End Sub

    Private Sub TxtNumPrestamo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TxtNumPrestamo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CargarMovimientos()
        End If
    End Sub

    ' Solo números, separador decimal y teclas de control
    Private Sub TxtDesembolso_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TxtDesembolso.KeyPress
        Dim separador As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then Exit Sub
        If e.KeyChar.ToString() = separador AndAlso Not TxtDesembolso.Text.Contains(separador) Then Exit Sub
        e.Handled = True
    End Sub

    Private Sub TxtDesembolso_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDesembolso.Leave
        Dim monto As Decimal
        If LeerMonto(TxtDesembolso.Text, monto) Then TxtDesembolso.Text = monto.ToString("N2")
    End Sub

    Private Sub TxtDesembolso_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles TxtDesembolso.Enter
        TxtDesembolso.SelectAll()
    End Sub

#End Region

#Region "Lógica del formulario"

    Private Sub CargarMovimientos()
        Dim numero As String = TxtNumPrestamo.Text.Trim()
        Dim NumPrestamo As String

        If numero = "" OrElse numero = _prestamoCargado Then Exit Sub
        _prestamoCargado = numero

        Try
            NumPrestamo = numero ' Variable global usada por otros formularios
            TdbgrDebitos.DataSource = ConsultarMovimientos(numero, "D")
            TDBGrid1.DataSource = ConsultarMovimientos(numero, "C")
        Catch ex As Exception
            _prestamoCargado = Nothing
            MostrarError("No se pudieron cargar los movimientos del préstamo.", ex)
        End Try
    End Sub

    Private Sub Desembolsar()
        Dim numero As String = TxtNumPrestamo.Text.Trim()
        Dim codigoTipo As String = ObtenerCodigoTipoPrestamo()
        Dim monto As Decimal
        Dim fecha As Date = DtpFecha.Value.Date
        Dim NumPrestamo As String

        If numero = "" Then
            Advertir("Seleccione el préstamo a desembolsar.", TxtNumPrestamo)
            Exit Sub
        End If
        If codigoTipo = "" Then
            Advertir("No se identificó el tipo de préstamo. Selecciónelo con el botón de búsqueda.", CmdButtonSucursal)
            Exit Sub
        End If
        If Not LeerMonto(TxtDesembolso.Text, monto) OrElse monto <= 0D Then
            Advertir("Ingrese un monto de desembolso mayor que cero.", TxtDesembolso)
            Exit Sub
        End If

        Dim pregunta As String = "¿Confirma el desembolso de " & monto.ToString("N2") & _
                                 " al préstamo " & numero & " con fecha " & fecha.ToString("dd/MM/yyyy") & "?"
        If MessageBox.Show(pregunta, TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                           MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        CmdDesemolsar.Enabled = False
        Try
            RegistrarDesembolso(numero, codigoTipo, monto, fecha)
            NumPrestamo = numero
            Me.Cursor = Cursors.Default
            MessageBox.Show("El desembolso se registró correctamente.", TITULO, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As DesembolsoException
            MessageBox.Show(ex.Message, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MostrarError("No se pudo registrar el desembolso. No se guardó ningún cambio.", ex)
        Finally
            Me.Cursor = Cursors.Default
            CmdDesemolsar.Enabled = True
        End Try
    End Sub

    Private Function ObtenerCodigoTipoPrestamo() As String
        If Not String.IsNullOrEmpty(CodigoTipoPrestamo) Then Return CodigoTipoPrestamo.Trim()
        Return Convert.ToString(TxtTipoPrestamo.Tag).Trim()
    End Function

#End Region

#Region "Acceso a datos"

    Private Function ConsultarMovimientos(ByVal numero As String, ByVal tipo As String) As DataTable
        Dim columnaExtra As String = ""
        If tipo = "D" Then columnaExtra = "MovPrestamo.Desembolso, "

        Dim tabla As New DataTable()
        Using cn As New SqlConnection(Conexion)
            Using da As New SqlDataAdapter(String.Format(SQL_MOVIMIENTOS, columnaExtra), cn)
                da.SelectCommand.Parameters.AddWithValue("@NumPrestamo", numero)
                da.SelectCommand.Parameters.AddWithValue("@Tipo", tipo)
                da.Fill(tabla)
            End Using
        End Using
        Return tabla
    End Function

    ''' <summary>
    ''' Registra el desembolso en una sola transacción: si cualquier paso falla,
    ''' no se guarda nada.
    ''' </summary>
    Private Sub RegistrarDesembolso(ByVal numero As String, ByVal codigoTipo As String, _
                                    ByVal monto As Decimal, ByVal fecha As Date)
        Using cn As New SqlConnection(Conexion)
            cn.Open()
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    ' 1. Validar el préstamo y bloquear su fila mientras dura la transacción
                    Dim cancelado As Object
                    Using cmd As SqlCommand = NuevoComando(cn, tr, _
                        "SELECT Cancelado FROM Prestamo WITH (UPDLOCK, ROWLOCK) " & _
                        "WHERE NumPrestamo = @NumPrestamo AND CodTipoPrestamo = @CodTipo", _
                        numero, codigoTipo, monto, fecha)
                        cancelado = cmd.ExecuteScalar()
                    End Using

                    If cancelado Is Nothing Then
                        Throw New DesembolsoException("El préstamo " & numero & " no existe para el tipo de préstamo seleccionado.")
                    End If
                    If EsVerdadero(cancelado) Then
                        Throw New DesembolsoException("El préstamo " & numero & " está cancelado; no se le pueden registrar desembolsos.")
                    End If

                    ' 2. Registrar el débito del desembolso
                    Using cmd As SqlCommand = NuevoComando(cn, tr, _
                        "INSERT INTO MovPrestamo (NumPrestamo, CodTipoPrestamo, NumCuota, Tipo, Monto, Interes, " & _
                        "MantoValor, Saldo, Mora, Fecha, Dias, Cancelado, Desembolso) " & _
                        "VALUES (@NumPrestamo, @CodTipo, 1, 'D', @Monto, 0, 0, @Monto, 0, @Fecha, 0, 'False', 'False')", _
                        numero, codigoTipo, monto, fecha)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 3. Sumar el desembolso solo a la ÚLTIMA cuota de crédito pendiente
                    Using cmd As SqlCommand = NuevoComando(cn, tr, _
                        "UPDATE MovPrestamo " & _
                        "SET Monto = ISNULL(Monto, 0) + @Monto, Saldo = ISNULL(Saldo, 0) + @Monto " & _
                        "WHERE NumPrestamo = @NumPrestamo AND CodTipoPrestamo = @CodTipo " & _
                        "  AND Tipo = 'C' AND Cancelado = 'False' " & _
                        "  AND NumCuota = (SELECT MAX(NumCuota) FROM MovPrestamo " & _
                        "                  WHERE NumPrestamo = @NumPrestamo AND CodTipoPrestamo = @CodTipo " & _
                        "                    AND Tipo = 'C' AND Cancelado = 'False')", _
                        numero, codigoTipo, monto, fecha)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 4. Actualizar los totales SOLO de este préstamo
                    Using cmd As SqlCommand = NuevoComando(cn, tr, _
                        "UPDATE Prestamo " & _
                        "SET MontoPrestamo = ISNULL(MontoPrestamo, 0) + @Monto, " & _
                        "    MontoTotal = ISNULL(MontoTotal, 0) + @Monto, " & _
                        "    Saldo = ISNULL(Saldo, 0) + @Monto, " & _
                        "    Entregado = 'False' " & _
                        "WHERE NumPrestamo = @NumPrestamo AND CodTipoPrestamo = @CodTipo", _
                        numero, codigoTipo, monto, fecha)
                        cmd.ExecuteNonQuery()
                    End Using

                    tr.Commit()
                Catch
                    tr.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Shared Function NuevoComando(ByVal cn As SqlConnection, ByVal tr As SqlTransaction, ByVal sql As String, _
                                         ByVal numero As String, ByVal codigoTipo As String, _
                                         ByVal monto As Decimal, ByVal fecha As Date) As SqlCommand
        Dim cmd As New SqlCommand(sql, cn, tr)
        cmd.Parameters.AddWithValue("@NumPrestamo", numero)
        cmd.Parameters.AddWithValue("@CodTipo", codigoTipo)
        cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = monto
        cmd.Parameters.Item("@Monto").Precision = 18
        cmd.Parameters.Item("@Monto").Scale = 2
        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha
        Return cmd
    End Function

#End Region

#Region "Utilidades"

    Private Shared Function LeerMonto(ByVal texto As String, ByRef valor As Decimal) As Boolean
        Return Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, valor)
    End Function

    ' Acepta columnas bit (True/False) o texto ("True"/"False"/"1"/"0")
    Private Shared Function EsVerdadero(ByVal valor As Object) As Boolean
        If valor Is Nothing OrElse IsDBNull(valor) Then Return False
        If TypeOf valor Is Boolean Then Return CBool(valor)
        Dim texto As String = valor.ToString().Trim()
        Return texto = "1" OrElse String.Equals(texto, "True", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub Advertir(ByVal mensaje As String, ByVal control As Control)
        MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        control.Focus()
    End Sub

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & vbCrLf & vbCrLf & "Detalle: " & ex.Message, _
                        TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>Error de validación del negocio (no es un fallo técnico).</summary>
    Private Class DesembolsoException
        Inherits Exception
        Public Sub New(ByVal mensaje As String)
            MyBase.New(mensaje)
        End Sub
    End Class

#End Region

End Class
