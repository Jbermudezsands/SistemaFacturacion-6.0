Public Class FrmAgregarRecibo
    Public MiConexion As New SqlClient.SqlConnection(Conexion), MonedaRecibo As String
    Private Sub FrmAgregarRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SqlString, MiConexion)

        SqlString = "SELECT  *  FROM MetodoPago"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        Me.CboMetodoPago.DataSource = DataSet.Tables("MetodoPago")
        'If DataSet.Tables("MetodoPago").Rows.Count <> 0 Then
        '    Me.CboMetodoPago.Text = DataSet.Tables("MetodoPago").Rows(0)("NombrePago")
        'End If


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////BUSCO SI TIENE CONFIGURADO EFECTIVO DEFAUL/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'SqlString = "SELECT  * FROM DatosEmpresa "
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DatosEmpresa")
        'If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
        '    If DataSet.Tables("DatosEmpresa").Rows(0)("MetodoPagoDefecto") = "Efectivo" Then
        '*************************************************************************************************************************
        '//////////////////////////////////BUSCO LA FORMA DE PAGO PARA ESTA FACTURA /////////////////////////////////////////////
        '**************************************************************************************************************************
        SqlString = "SELECT  * FROM MetodoPago WHERE  (TipoPago = 'Efectivo') AND (Moneda = '" & MonedaRecibo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Metodo")
        If DataSet.Tables("Metodo").Rows.Count <> 0 Then
            Me.CboMetodoPago.Text = DataSet.Tables("Metodo").Rows(0)("NombrePago")
        End If
        '    End If
        'End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TxtMontoRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMontoRecibo.TextChanged
        Dim Monto As Double, Ret1 As Double = 0, Ret2 As Double = 0

        If Me.TxtMontoRecibo.Text = "" Then
            Exit Sub
        End If

        If IsNumeric(Me.TxtMontoRecibo.Text) Then
            Monto = Me.TxtMontoRecibo.Text
        End If

        If Me.ChkRet1Porciento.Checked = True Then
            Ret1 = Monto * 0.01
            Me.LblRetencion1.Text = Format(Ret1, "##,##0.00")
        Else
            Ret1 = 0
            Me.LblRetencion1.Text = Format(Ret1, "##,##0.00")
        End If

        If Me.ChkRet1Porciento.Checked = True Then
            Ret2 = Monto * 0.02
            Me.LblRetencion2.Text = Format(Ret2, "##,##0.00")
        Else
            Ret2 = 0
            Me.LblRetencion2.Text = Format(Ret2, "##,##0.00")
        End If





    End Sub

    Private Sub ChkRet1Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRet1Porciento.CheckedChanged
        Dim Monto As Double, Ret1 As Double
        If Me.TxtMontoRecibo.Text = "" Then
            Exit Sub
        End If

        If IsNumeric(Me.TxtMontoRecibo.Text) Then
            Monto = Me.TxtMontoRecibo.Text
        End If

        If Me.ChkRet1Porciento.Checked = True Then
            Ret1 = Monto * 0.01
            Me.LblRetencion1.Text = Format(Ret1, "##,##0.00")
        Else
            Ret1 = 0
            Me.LblRetencion1.Text = Format(Ret1, "##,##0.00")
        End If

    End Sub

    Private Sub ChkRet2Porciento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRet2Porciento.CheckedChanged
        Dim Monto As Double, Ret2 As Double

        If Me.TxtMontoRecibo.Text = "" Then
            Exit Sub
        End If

        If IsNumeric(Me.TxtMontoRecibo.Text) Then
            Monto = Me.TxtMontoRecibo.Text
        End If

        If Me.ChkRet2Porciento.Checked = True Then
            Ret2 = Monto * 0.02
            Me.LblRetencion2.Text = Format(Ret2, "##,##0.00")
        Else
            Ret2 = 0
            Me.LblRetencion2.Text = Format(Ret2, "##,##0.00")
        End If
    End Sub
End Class