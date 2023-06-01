Public Class FrmRevalorizar
    Public MiConexion As New SqlClient.SqlConnection(Conexion), DataSetRegistros As New DataSet

    Private Sub FrmRevalorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If Me.OptCuentasCobrarRe.Checked = True Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagarRe.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If Me.OptCuentasCobrarRe.Checked = True Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagarRe.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click

    End Sub

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        Dim oDataRow As DataRow
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sqlstring As String, SqlDatos As String, Registros As Double, i As Double, CodigoCliente As String, j As Double, Cont As Double



        If Me.OptCuentasCobrarRe.Checked = True Then

            '*******************************************************************************************************************************
            '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
            '*******************************************************************************************************************************
            DataSetRegistros.Reset()
            Sqlstring = "SELECT Facturas.MarcaRevalorizar, Clientes.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Facturas.SubTotal AS Saldo, Facturas.SubTotal AS SaldoME, Facturas.NetoPagar AS TasaCambio, Facturas.NetoPagar AS Diferencia FROM  Clientes INNER JOIN Facturas ON Clientes.Cod_Cliente = Facturas.Cod_Cliente WHERE (Clientes.Cod_Cliente = N'-1000000')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSetRegistros, "Clientes")

            '*******************************************************************************************************************************
            '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
            '*******************************************************************************************************************************
            Sqlstring = Sqlstring = "SELECT Facturas.MarcaRevalorizar, Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.SubTotal As Saldo, Facturas.SubTotal As SaldoDolar, Facturas.SubTotal As Diferencia  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                    "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(DataSetRegistros, "Facturas")


            If Me.TxtRebalorizaDesde.Text = "" And Me.TxtRebalorizarHasta.Text = "" Then
                'SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente,Clientes.Apellido_Cliente ORDER BY Facturas.Cod_Cliente"
                SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente  ORDER BY Clientes.Cod_Cliente"
            Else
                'SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente,Clientes.Apellido_Cliente HAVING (Facturas.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') ORDER BY Facturas.Cod_Cliente"
                SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente HAVING  (Clientes.Cod_Cliente BETWEEN '" & Me.TxtRebalorizaDesde.Text & "' AND '" & Me.TxtRebalorizarHasta.Text & "') ORDER BY Clientes.Cod_Cliente"
            End If

            DataSet.Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////AGREGO LA CONSULTA PARA TODOS LOS CLIENTES SELECCIONADOS //////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            Registros = DataSet.Tables("Clientes").Rows.Count


            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = DataSet.Tables("Clientes").Rows.Count
            i = 0
            Registros = DataSet.Tables("Clientes").Rows.Count
            Do While Registros > i

                CodigoCliente = DataSet.Tables("Clientes").Rows(i)("Cod_Cliente")

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Sqlstring = "SELECT *  FROM Facturas WHERE (Tipo_Factura = 'Factura') AND (Cod_Cliente = '" & CodigoCliente & "') AND (Nombre_Cliente <> N'******CANCELADO') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (MonedaFactura = 'Dolares')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "Facturas")
                Registros = DataSet.Tables("Facturas").Rows.Count

                Me.ProgressBar2.Minimum = 0
                Me.ProgressBar2.Visible = True
                Me.ProgressBar2.Value = 0
                Me.ProgressBar2.Maximum = DataSet.Tables("Facturas").Rows.Count
                j = 0
                Cont = DataSet.Tables("Facturas").Rows.Count
                Do While Cont > j



                    j = +1
                Loop




                i = i + 1
            Loop








        ElseIf Me.OptCuentasPagarRe.Checked = True Then



        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class