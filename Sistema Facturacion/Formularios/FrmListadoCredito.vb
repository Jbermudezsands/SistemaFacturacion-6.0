Imports System.Data.SqlClient
Imports System.IO

Public Class FrmListadoCredito

    Private Const TITULO As String = "Sistema de Facturación"

    Private Const SQL_LISTADO As String =
        "SELECT Prestamo.NumPrestamo, Prestamo.CodTipoPrestamo, Prestamo.CodProductor, " &
        "       Productor.NombreProductor, Productor.ApellidoProductor, Productor.Cedula, " &
        "       TipoPrestamo.TipoPrestamo, Prestamo.CantCuotas, Prestamo.PorcInteres, " &
        "       Prestamo.MontoPrestamo, Prestamo.MontoInteres, Prestamo.MontoPrestamo, Prestamo.MontoMantoValor, " &
        "       Prestamo.MontoTotal, Prestamo.FechaInicial, Prestamo.Moneda, Prestamo.FechaUltMov, " &
        "       Prestamo.FechaVencimiento, Prestamo.Saldo, Prestamo.CantDias, Prestamo.Reestructurado, " &
        "       Prestamo.Cancelado, Prestamo.Anulado, Prestamo.Entregado, Prestamo.Incobrable " &
        "FROM Prestamo " &
        "INNER JOIN Productor ON Prestamo.CodProductor = Productor.CodProductor " &
        "INNER JOIN TipoPrestamo ON Prestamo.CodTipoPrestamo = TipoPrestamo.CodTipoPrestamo " &
        "ORDER BY Prestamo.FechaInicial DESC, Prestamo.NumPrestamo DESC"

    Private Const SQL_ESTADO_CUENTA As String = _
        "SELECT Prestamo.NumPrestamo, Prestamo.CodTipoPrestamo, TipoPrestamo.TipoPrestamo, Prestamo.PorcInteres, " & _
        "       Prestamo.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS NombreSocio, " & _
        "       Prestamo.CantCuotas, Prestamo.MontoPrestamo, Prestamo.MontoInteres, Prestamo.MontoMantoValor, " & _
        "       Prestamo.MontoTotal, Prestamo.FechaInicial, Prestamo.Moneda, Prestamo.FechaUltMov, " & _
        "       Prestamo.FechaVencimiento, Prestamo.CantDias, Prestamo.Reestructurado, Prestamo.Cancelado, " & _
        "       Prestamo.DeCadaMes, MovPrestamo.NumCuota, MovPrestamo.Tipo, MovPrestamo.Monto, MovPrestamo.Interes, " & _
        "       MovPrestamo.MantoValor, MovPrestamo.Saldo, MovPrestamo.Mora, MovPrestamo.Fecha, MovPrestamo.FechaMora, " & _
        "       MovPrestamo.Dias, MovPrestamo.Cancelado, " & _
        "       MovPrestamo.Monto + MovPrestamo.Interes + MovPrestamo.MantoValor AS TotalCuota " & _
        "FROM Prestamo " & _
        "INNER JOIN Productor ON Productor.CodProductor = Prestamo.CodProductor " & _
        "INNER JOIN MovPrestamo ON MovPrestamo.NumPrestamo = Prestamo.NumPrestamo " & _
        "                      AND MovPrestamo.CodTipoPrestamo = Prestamo.CodTipoPrestamo " & _
        "INNER JOIN TipoPrestamo ON TipoPrestamo.CodTipoPrestamo = Prestamo.CodTipoPrestamo " & _
        "WHERE Prestamo.NumPrestamo = @NumPrestamo AND Prestamo.CodTipoPrestamo = @CodTipo " & _
        "ORDER BY MovPrestamo.Fecha, MovPrestamo.NumCuota"

#Region "Eventos"

    Private Sub FrmListadoCredito_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CargarListado()
    End Sub

    Private Sub BtnEstado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEstado.Click
        MostrarEstadoCuenta()
    End Sub

    Private Sub TrueDBGridConsultas_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TrueDBGridConsultas.DoubleClick
        MostrarEstadoCuenta()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnActualizar.Click
        CargarListado()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BindingPrestamos_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles BindingPrestamos.ListChanged
        ActualizarResumen()
    End Sub

#End Region

#Region "Lógica"

    Private Sub CargarListado()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim tabla As New DataTable()
            Using da As New SqlDataAdapter(SQL_LISTADO, Conexion)
                da.Fill(tabla)
            End Using

            BindingPrestamos.DataSource = tabla
            TrueDBGridConsultas.DataSource = BindingPrestamos
            OcultarColumna("CodTipoPrestamo")
            ActualizarResumen()
        Catch ex As Exception
            MostrarError("No se pudo cargar el listado de créditos.", ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MostrarEstadoCuenta()
        Dim fila As DataRowView = TryCast(BindingPrestamos.Current, DataRowView)
        If fila Is Nothing Then
            MessageBox.Show("Seleccione un préstamo de la lista.", TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim numero As String = Convert.ToString(fila("NumPrestamo"))
        Dim codigoTipo As String = Convert.ToString(fila("CodTipoPrestamo"))

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim reporte As New ArepEstado()
            CargarEncabezadoEmpresa(reporte)
            reporte.DataSource = ConsultarEstadoCuenta(numero, codigoTipo)

            Dim visor As New FrmViewer()
            visor.arvMain.Document = reporte.Document
            visor.Show()
            reporte.Run(True)
        Catch ex As Exception
            MostrarError("No se pudo generar el estado de cuenta del préstamo " & numero & ".", ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarEncabezadoEmpresa(ByVal reporte As ArepEstado)
        Dim empresa As New DataTable()
        Using da As New SqlDataAdapter("SELECT TOP 1 Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Ruta_Logo FROM DatosEmpresa", Conexion)
            da.Fill(empresa)
        End Using
        If empresa.Rows.Count = 0 Then Exit Sub

        Dim datos As DataRow = empresa.Rows(0)
        reporte.TxtTitutlo.Text = Convert.ToString(datos("Nombre_Empresa"))
        reporte.TxtDireccion.Text = Convert.ToString(datos("Direccion_Empresa"))

        Dim ruc As String = Convert.ToString(datos("Numero_Ruc")).Trim()
        If ruc <> "" Then reporte.TxtRuc.Text = "Número RUC: " & ruc

        Dim rutaLogo As String = Convert.ToString(datos("Ruta_Logo")).Trim()
        If rutaLogo <> "" AndAlso File.Exists(rutaLogo) Then
            ' Se copia la imagen a memoria para no dejar el archivo bloqueado
            Using fs As New FileStream(rutaLogo, FileMode.Open, FileAccess.Read)
                Using original As Image = Image.FromStream(fs)
                    reporte.ImgLogo.Image = New Bitmap(original)
                End Using
            End Using
        End If
    End Sub

    Private Function ConsultarEstadoCuenta(ByVal numero As String, ByVal codigoTipo As String) As DataTable
        Dim tabla As New DataTable()
        Using cn As New SqlConnection(Conexion)
            Using da As New SqlDataAdapter(SQL_ESTADO_CUENTA, cn)
                da.SelectCommand.Parameters.AddWithValue("@NumPrestamo", numero)
                da.SelectCommand.Parameters.AddWithValue("@CodTipo", codigoTipo)
                da.Fill(tabla)
            End Using
        End Using
        Return tabla
    End Function

#End Region

#Region "Interfaz"

    Private Sub ActualizarResumen()
        Dim total As Integer = BindingPrestamos.Count
        If total = 1 Then
            LblResumen.Text = "1 préstamo"
        Else
            LblResumen.Text = total.ToString("N0") & " préstamos"
        End If
        BtnEstado.Enabled = total > 0
    End Sub

    ' La columna se usa para el estado de cuenta, pero no hace falta mostrarla
    Private Sub OcultarColumna(ByVal nombre As String)
        Try
            For Each columna As C1.Win.C1TrueDBGrid.C1DisplayColumn In TrueDBGridConsultas.Splits(0).DisplayColumns
                If String.Equals(columna.DataColumn.DataField, nombre, StringComparison.OrdinalIgnoreCase) Then
                    columna.Visible = False
                End If
            Next
        Catch
            ' Si la grilla no tiene esa columna, no hay nada que ocultar
        End Try
    End Sub

    Private Sub MostrarError(ByVal mensaje As String, ByVal ex As Exception)
        MessageBox.Show(mensaje & vbCrLf & vbCrLf & "Detalle: " & ex.Message,
                        TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub PnlContenido_Paint(sender As Object, e As PaintEventArgs) Handles PnlContenido.Paint

    End Sub

#End Region

End Class
