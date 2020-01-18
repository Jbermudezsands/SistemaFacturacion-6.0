Imports System.Math

Public Class FrmAjustes
    Public MiConexion As New SqlClient.SqlConnection(Conexion), ConsecutivoConSerie As Boolean

    Private Sub FrmAjustes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, SqlConsulta As String = "SELECT Endoso.* FROM Endoso", SqlString As String


        If CodigoClienteNumero = True Then
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden FROM Clientes ORDER BY Orden"
        Else
            Sql = "SELECT Cod_Cliente AS CodigoCliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
        End If

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()

        SqlString = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie") = True Then
                    ConsecutivoConSerie = True
                Else
                    Me.CmbSerie.Visible = False
                    ConsecutivoConSerie = False
                End If
            End If

        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dv As DataView, Filtro As String, Registros As Double, i As Double, Monto As Double, FechaFactura As Date
        Dim Consecutivo As Double, SQlstring As String, TipoNota As String = "Credito Clientes", Moneda As String, CodigoNota As String = "", Descripcion As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, NumeroFactura As String
        Dim NumeroNota As String, Consecutivoconserie As Boolean = True

        Filtro = "Fecha_Factura >= '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "' AND Fecha_Factura <= '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "' AND Total <= " & Me.TxtMonto.Value & " "
        dv = New DataView(FrmCuentasXCobrar.DatasetReporte.Tables("TotalVentas"))
        dv.RowFilter = Filtro
        Registros = dv.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Registros
        Me.ProgressBar1.Value = 0

        MsgBox("Se Procesaran " & Registros & " Facturas", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        For Each fila As DataRowView In dv
            Monto = fila.Item("Total")
            FechaFactura = fila.Item("Fecha_Factura")
            NumeroFactura = fila.Item("Numero_Factura")

            Select Case Monto
                Case Is > 0 : TipoNota = "Credito Clientes"
                Case Is < 0 : TipoNota = "Debito Clientes"
                Case 0 : TipoNota = "Ninguno"
            End Select

            If Me.OptCordobas.Checked = True Then
                Moneda = "Cordobas"
            Else
                Moneda = "Dolares"
            End If

            If TipoNota <> "Ninguno" Then

                '///////////////////////////////////////////BUSCO EL CONSECUTIVO POR NOTA ////////////////////////////////////////////////////
                If Consecutivoconserie = False Then
                    Select Case TipoNota
                        Case "Debito Clientes" : Consecutivo = BuscaConsecutivo("NotaDebito")
                        Case "Credito Clientes" : Consecutivo = BuscaConsecutivo("NotaCredito")
                        Case "Debito Proveedores" : Consecutivo = BuscaConsecutivo("NotaDebitoProveedor")
                        Case "Credito Proveedores" : Consecutivo = BuscaConsecutivo("NotaCreditoProveedor")
                    End Select
                    NumeroNota = Format(Consecutivo, "0000#")
                Else
                    If Me.ChkSseries.Checked = False Then
                        Select Case TipoNota
                            Case "Debito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaDebito", Me.CmbSerie.Text)
                            Case "Credito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaCredito", Me.CmbSerie.Text)
                            Case "Debito Proveedores" : Consecutivo = BuscaConsecutivoSerie("NotaDebitoProveedor", Me.CmbSerie.Text)
                            Case "Credito Proveedores" : Consecutivo = BuscaConsecutivoSerie("NotaCreditoProveedor", Me.CmbSerie.Text)
                        End Select
                        NumeroNota = Me.CmbSerie.Text & Format(Consecutivo, "0000#")
                    Else
                        Select Case TipoNota
                            Case "Debito Clientes" : Consecutivo = BuscaConsecutivo("NotaDebito")
                            Case "Credito Clientes" : Consecutivo = BuscaConsecutivo("NotaCredito")
                            Case "Debito Proveedores" : Consecutivo = BuscaConsecutivo("NotaDebitoProveedor")
                            Case "Credito Proveedores" : Consecutivo = BuscaConsecutivo("NotaCreditoProveedor")
                        End Select
                        NumeroNota = Format(Consecutivo, "0000#")
                    End If
                End If


                Select Case TipoNota
                    Case "Credito Clientes"

                        Quien = "CtasXcob"

                        If Moneda = "Cordobas" Then
                            '///////////////////////////////////////////////////////////////////////////////////////////////
                            SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif C$')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                                Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                            Else
                                MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                                Exit Sub
                            End If

                        ElseIf Moneda = "Dolares" Then
                            '///////////////////////////////////////////////////////////////////////////////////////////////
                            SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif $')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                                Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                            Else
                                MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                                Exit Sub
                            End If
                        End If


                        GrabaNotaDebito(NumeroNota, FechaFactura, CodigoNota, Monto, Moneda, Me.CboCodigoCliente.Text, Me.TxtNombre.Text, "Ajuste Automatico Zeus Facturacion", True, False)
                        GrabaDetalleNotaDebito(NumeroNota, FechaFactura, CodigoNota, Descripcion, NumeroFactura, Monto)


                    Case "Debito Clientes"


                        Quien = "CtasXcob"

                        If Moneda = "Cordobas" Then
                            '///////////////////////////////////////////////////////////////////////////////////////////////
                            SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif C$')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                                Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                            Else
                                MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                                Exit Sub
                            End If

                        ElseIf Moneda = "Dolares" Then
                            '///////////////////////////////////////////////////////////////////////////////////////////////
                            SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif $')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                                Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                            Else
                                MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                                Exit Sub
                            End If

                        End If



                        GrabaNotaDebito(NumeroNota, FechaFactura, CodigoNota, Abs(Monto), Moneda, Me.CboCodigoCliente.Text, Me.TxtNombre.Text, "Ajuste Automatico Zeus Facturacion", True, False)
                        GrabaDetalleNotaDebito(NumeroNota, FechaFactura, CodigoNota, Descripcion, NumeroFactura, Abs(Monto))



                End Select

            End If

            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Next

        My.Forms.FrmCuentasXCobrar.CmdGrabar.PerformClick()

    End Sub

    Private Sub ChkSseries_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSseries.CheckedChanged
        If Me.ChkSseries.Checked = True Then
            Me.CmbSerie.Visible = False
        Else
            Me.CmbSerie.Visible = True

        End If
    End Sub
End Class