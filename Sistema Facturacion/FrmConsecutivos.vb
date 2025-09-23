Public Class FrmConsecutivos
    Public NumeroFactura As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TxtConsecutivo.Text = "-----0-----"
        Me.Close()
    End Sub

    Private Sub FrmConsecutivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Consecutivofactura As Double
        Me.MinimumSize = Size
        Me.MaximumSize = Size

        If Quien = "Recibo" Then
            If FrmRecibos.ConsecutivoReciboSerie = True Then
                Consecutivofactura = BuscaConsecutivoSerieNoEdita("Recibo", FrmRecibos.CmbSerie.Text)
            Else
                Consecutivofactura = BuscaConsecutivoNoEdita("Recibo_Caja")
            End If

        Else
            Consecutivofactura = BuscaConsecutivoNoEdita("Factura")
        End If

        Me.TxtConsecutivo.Text = Format(Consecutivofactura, "0000#")
        NumeroFactura = Me.TxtConsecutivo.Text
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim SQLUpdate As String, SQlString As String

        If Me.TxtConsecutivo.Text = "" Then
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtConsecutivo.Text) Then
            Me.TxtConsecutivo.Text = ""
            Exit Sub
        ElseIf CDbl(Me.TxtConsecutivo.Text) < 1 Then
            Me.TxtConsecutivo.Text = ""
            Exit Sub

        End If

        NumeroFactura = Format(CDbl(Me.TxtConsecutivo.Text), "0000#") 'Me.TxtConsecutivo.Text

        '--------------------------------------------BUSCO EL CONSECUTIVO ANTEPONIENDO CEROS --------------------------------------
        If Quien = "Recibo" Then
            If FrmRecibos.ConsecutivoReciboSerie = True Then
                NumeroFactura = FrmFacturas.CmbSerie.Text & NumeroFactura
                SQlString = "SELECT * FROM Recibo WHERE (CodReciboPago = '" & NumeroFactura & "')"
                'SQlString = "SELECT Serie, Factura, Cotizacion, SalidaBodega, DevFactura, Transferencia_Enviada, Recibo, Transferencia_Recibida, MercanciaRecibida, DevCompra, OrdenCompra, NotaDebito, NotaCredito FROM ConsecutivoSerie " & _
                '            "WHERE (Serie = '" & FrmRecibos.CmbSerie.Text & "') AND (Recibo = " & NumeroFactura & ")"
                Me.LblTitulo.Text = "CONSECUTIVO RECIBO"
                Me.LblTitulo2.Text = "RECIBO NO"

            Else
                SQlString = "SELECT * FROM Recibo WHERE (CodReciboPago = '" & NumeroFactura & "')"
                Me.LblTitulo.Text = "CONSECUTIVO RECIBO"
                Me.LblTitulo2.Text = "RECIBO NO"
            End If
        Else

            If FrmFacturas.ConsecutivoFacturaSerie = True Then
                NumeroFactura = FrmFacturas.CmbSerie.Text & NumeroFactura
                SQlString = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                Me.LblTitulo.Text = "CONSECUTIVO FACTURA"
                Me.LblTitulo2.Text = "FACTURA NO"

            Else
                SQlString = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
                Me.LblTitulo.Text = "CONSECUTIVO FACTURA"
                Me.LblTitulo2.Text = "FACTURA NO"
            End If
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaFactura")
        If Not DataSet.Tables("BuscaFactura").Rows.Count = 0 Then
            If Quien = "Recibo" Then
                MsgBox("Existe este Numero de Recibo!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                Exit Sub
            Else
                MsgBox("Existe este Numero de Factura!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                Exit Sub
            End If

        End If


        If Quien = "Recibo" Then
            DataSet.Tables("BuscaFactura").Reset()
            If FrmRecibos.ConsecutivoReciboSerie = True Then
                NumeroFactura = FrmRecibos.CmbSerie.Text & Me.TxtConsecutivo.Text
            Else
                NumeroFactura = CDbl(Me.TxtConsecutivo.Text)
            End If
            '--------------------------------------------BUSCO EL CONSECUTIVO SIN LOS CEROS --------------------------------------
            SQlString = "SELECT  *  FROM Recibo WHERE (CodReciboPago = '" & NumeroFactura & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "BuscaFactura")
            If Not DataSet.Tables("BuscaFactura").Rows.Count = 0 Then
                MsgBox("Existe este Numero de Recibo!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                Exit Sub
            End If

        Else
            DataSet.Tables("BuscaFactura").Reset()
            NumeroFactura = CDbl(Me.TxtConsecutivo.Text)
            '--------------------------------------------BUSCO EL CONSECUTIVO SIN LOS CEROS --------------------------------------
            SQlString = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Tipo_Factura = 'Factura')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "BuscaFactura")
            If Not DataSet.Tables("BuscaFactura").Rows.Count = 0 Then
                MsgBox("Existe este Numero de Factura!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                Exit Sub
            End If
        End If


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////ACTUALIZO EL CONSECUTIVO///////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        If Quien = "Recibo" Then
            If FrmRecibos.ConsecutivoReciboSerie = True Then
                NumeroFactura = Mid(NumeroFactura, 2, Len(NumeroFactura))
                SQLUpdate = "UPDATE [ConsecutivoSerie]  SET [Recibo] = " & NumeroFactura & " WHERE (Serie = '" & FrmRecibos.CmbSerie.Text & "') "
            Else
                SQLUpdate = "UPDATE [Consecutivos]  SET [Recibo_Caja] = " & NumeroFactura & ""
            End If
        Else
            SQLUpdate = "UPDATE [Consecutivos]  SET [Factura] = " & NumeroFactura & ""
        End If

        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQLUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Me.Close()
    End Sub

    Private Sub TxtConsecutivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtConsecutivo.TextChanged

    End Sub
End Class