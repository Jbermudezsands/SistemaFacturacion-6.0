Imports System.Math

Public Class FrmAgregarNotaCredito
    Public Numero_Factura As String, Fecha_Factura As String, MontoFactura As Double, ds As New DataSet, Numero_Nota As String = "", MontoNota As Double, MonedaEstado As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmAgregarNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LblNumeroFactura.Text = Numero_Factura
        Me.LblMontoFactura.Text = MontoFactura
        Me.TxtMontoRecibo.Text = MontoFactura

        Me.LblNumeroNota.Text = ""
        Me.LblMontoNota.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.TDGridImpuestos.Visible = True
        Me.GroupBox1.Visible = False
        Me.Size = New Size(935, 420)


        Me.TDGridImpuestos.DataSource = ds.Tables("TotalVentas")
        Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
        Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
        Me.TDGridImpuestos.Columns(3).Caption = "DB/CR No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 80
        Me.TDGridImpuestos.Columns(4).Caption = "Monto NB/CR"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 75
        Me.TDGridImpuestos.Columns(5).Caption = "Cargo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
        Me.TDGridImpuestos.Columns(5).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(6).Caption = "Fecha Vence"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 73
        Me.TDGridImpuestos.Columns(7).Caption = "Abono"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
        Me.TDGridImpuestos.Columns(7).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(8).Caption = "Saldo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 70
        Me.TDGridImpuestos.Columns(8).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(9).Caption = "Moratorio"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70
        Me.TDGridImpuestos.Columns(9).NumberFormat = "##,##0.00"
        Me.TDGridImpuestos.Columns(10).Caption = "Dias"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(10).Width = 40
        Me.TDGridImpuestos.Columns(11).Caption = "Total"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(11).Width = 70
        Me.TDGridImpuestos.Columns(11).NumberFormat = "##,##0.00"

        ds.Tables("TotalVentas").DefaultView.RowFilter = "Numero_Factura = 0000"

    End Sub

    Private Sub TDGridImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.Click

    End Sub

    Private Sub TDGridImpuestos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.DoubleClick

        Dim Cadena(2) As String

        Numero_Nota = Me.TDGridImpuestos.Columns("NotaDebito").Text
        Cadena = Numero_Nota.Split(":")
        If Cadena.Length = 2 Then
            Numero_Nota = Cadena(1)
        Else
            Numero_Nota = ""
        End If

        MontoNota = Me.TDGridImpuestos.Columns("MontoNota").Text

        Me.LblNumeroNota.Text = Numero_Nota
        Me.LblMontoNota.Text = MontoNota

        Me.TDGridImpuestos.Visible = False
        Me.GroupBox1.Visible = True


        Me.Size = New Size(609, 351)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQlString As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, MontoNota As String, Monto As Double, MonedaNota As String, MontoAplicar As Double
        Dim TasaCambio As Double, FechaNota As Date, IdDetalleNota As Double

        If Not IsNumeric(Me.TxtMontoRecibo.Text) Then
            MsgBox("El Numero Digitado no es Numerico!", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CONSULTO INFORMACION DEL DETALLE DE NOMINA ///////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT  Detalle_Nota.*, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota " & _
                    "WHERE (Detalle_Nota.Numero_Nota = '" & Numero_Nota & "') ORDER BY Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Fecha_Nota"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then



            MontoNota = DataSet.Tables("Consulta").Rows(0)("Monto")
            Monto = CDbl(Me.TxtMontoRecibo.Text)
            MonedaNota = DataSet.Tables("Consulta").Rows(0)("MonedaNota")
            FechaNota = DataSet.Tables("Consulta").Rows(0)("Fecha_Nota")
            IdDetalleNota = DataSet.Tables("Consulta").Rows(0)("id_Detalle_Nota")

            Monto = Format(Monto, "##,##0.00")

            If MonedaNota <> MonedaEstado Then
                If MonedaNota = "Cordobas" Then
                    If MonedaEstado = "Cordobas" Then
                        If Monto >= MontoNota Then
                            MsgBox("El monto de Digitado es mayor, a la Nota", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Exit Sub
                        End If

                        MontoAplicar = MontoNota - Monto
                    Else
                        TasaCambio = BuscaTasaCambio(FechaNota)
                        If TasaCambio <> 0 Then
                            MsgBox("Tasa de Cambio de existe!!! " & FechaNota, MsgBoxStyle.Exclamation, "Zeus Facturacion")
                            Exit Sub
                        End If

                        If Monto >= Format((MontoNota / TasaCambio), "##,##0.00") Then
                            MsgBox("El monto de Digitado es mayor, a la Nota", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Exit Sub
                        End If


                        Monto = Format((Monto * TasaCambio), "##,##0.00")
                        MontoAplicar = MontoNota - Monto

                    End If
                Else

                    '''' LA VENTANA DE CUENTAS X COBRAR ES DOLARES //////////////////////////////////////

                    If MonedaEstado = "Cordobas" Then
                        TasaCambio = BuscaTasaCambio(FechaNota)
                        If TasaCambio = 0 Then
                            MsgBox("Tasa de Cambio de existe!!! " & FechaNota, MsgBoxStyle.Exclamation, "Zeus Facturacion")
                            Exit Sub
                        End If

                        If Monto >= Format((MontoNota * TasaCambio), "##,##0.00") Then
                            MsgBox("El monto de Digitado es mayor, a la Nota", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Exit Sub
                        End If

                        Monto = Format((Monto / TasaCambio), "##,##0.00")
                        MontoAplicar = MontoNota - Monto

                    Else

                        If Monto >= MontoNota Then
                            MsgBox("El monto de Digitado es mayor, a la Nota", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Exit Sub
                        End If

                        MontoAplicar = MontoNota - Monto
                    End If


                End If

            End If




            InsertarDetalleNotaDebito(Numero_Nota, DataSet.Tables("Consulta").Rows(0)("Fecha_Nota"), DataSet.Tables("Consulta").Rows(0)("Tipo_Nota"), DataSet.Tables("Consulta").Rows(0)("Descripcion"), Me.LblNumeroFactura.Text, Monto)
            GrabaDetalleNotaDebito(Numero_Nota, DataSet.Tables("Consulta").Rows(0)("Fecha_Nota"), DataSet.Tables("Consulta").Rows(0)("Tipo_Nota"), DataSet.Tables("Consulta").Rows(0)("Descripcion"), Me.LblNumeroFactura.Text, MontoAplicar)
        End If

        Me.Close()


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class