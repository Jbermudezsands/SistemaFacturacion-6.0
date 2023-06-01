Public Class FrmExportar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object, Registros As Double, CodigoCliente As String, Moneda As String
        Dim SaldoCorriente As Double = 0, Saldo30Dias As Double = 0, Saldo60Dias As Double = 0, Saldo90Dias As Double = 0, SaldoMas90Dias As Double = 0
        Dim DiasMora As Double = 0, SaldoTotal As Double = 0, SaldoMora As Double = 0, Ruta As String, DireccionCliente As String = ""

        My.Application.DoEvents()

        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String = "", iPosicionFila = 0, A As String, B As String, C As String, D As String, F As String, G As String, H As String, I As String, J As String, EE As String
        Dim Contador As Double, iPosicion As Double, iPosicionExcel As Double
        Dim TestString As String, Tipo As String = "J"
        Dim TestArray() As String

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        'oBook = oExcel.Workbooks.Open("C:\ExcemlArchivo.xlsx")
        oSheet = oBook.Worksheets(1)

        'oExcel.Visible = True
        'oExcel.UserControl = True

        If Me.OptTransUnion.Checked = True Then

            oSheet.Range("A1").Value = "Tipo de Registro"
            oSheet.Range("B1").Value = "Consecutivo"
            oSheet.Range("C1").Value = "Tipo de Sujeto"
            oSheet.Range("D1").Value = "Nacionalidad"
            oSheet.Range("E1").Value = "Nombre completo"
            oSheet.Range("F1").Value = "Primer apellido"
            oSheet.Range("G1").Value = "Segundo apellido"
            oSheet.Range("H1").Value = "Apellido de casada"
            oSheet.Range("I1").Value = "Primer nombre"
            oSheet.Range("J1").Value = "Segundo nombre"
            oSheet.Range("K1").Value = "Identificación 1"
            oSheet.Range("L1").Value = "Identificación 2"
            oSheet.Range("M1").Value = "Identificación 3"
            oSheet.Range("N1").Value = "Identificación 4"
            oSheet.Range("O1").Value = "Identificación 5"
            oSheet.Range("P1").Value = "Fecha de Nacimiento"
            oSheet.Range("Q1").Value = "Sexo"
            oSheet.Range("R1").Value = "Estado civil"
            oSheet.Range("S1").Value = "Dirección residencial"
            oSheet.Range("T1").Value = "DirResDivGeo1"
            oSheet.Range("U1").Value = "DirResDivGeo2"
            oSheet.Range("V1").Value = "Dirección laboral"
            oSheet.Range("W1").Value = "DirResDivGeo1"
            oSheet.Range("X1").Value = "DirResDivGeo2"
            oSheet.Range("Y1").Value = "Dirección E- mail"
            oSheet.Range("Z1").Value = "Teléfono residencial"
            oSheet.Range("AA1").Value = "Teléfono laboral"
            oSheet.Range("AB1").Value = "Teléfono celular"
            oSheet.Range("AC1").Value = "Tipo de obligación"
            oSheet.Range("AD1").Value = "Moneda"
            oSheet.Range("AE1").Value = "Identificador tipo de cuenta"
            oSheet.Range("AF1").Value = "Número de obligación"
            oSheet.Range("AG1").Value = "Fecha de otorgamiento"
            oSheet.Range("AH1").Value = "Fecha de vencimiento"
            oSheet.Range("AI1").Value = "Periodo de pago"
            oSheet.Range("AJ1").Value = "Estado"
            oSheet.Range("AK1").Value = "Sub-estado"
            oSheet.Range("AL1").Value = "Calificación"
            oSheet.Range("AM1").Value = "Número días Mora"
            oSheet.Range("AN1").Value = "Valor Limite"
            oSheet.Range("AO1").Value = "Valor Saldo Total"
            oSheet.Range("AP1").Value = "Valor Mora Total"
            oSheet.Range("AQ1").Value = "Valor Cuota"
            oSheet.Range("AR1").Value = "Tipo de deudor"
            oSheet.Range("AS1").Value = "Tipo de garantía"
            oSheet.Range("AT1").Value = "Número garantía"
            oSheet.Range("AU1").Value = "Valor garantía"
            oSheet.Range("AV1").Value = "Descripción"
            oSheet.Range("AW1").Value = "Tipo Cambio"

            'SqlDatos = "SELECT DISTINCT Facturas.Cod_Cliente, MAX(Facturas.Cod_Vendedor) AS Cod_Vendedor, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor) AS NombreVendedor, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Clientes.RUC, Clientes.Direccion_Cliente, Clientes.Municipio, Clientes.Departamento, Clientes.Telefono, Clientes.Limite_Credito FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Nombre_Cliente <> N'******CANCELADO') GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Clientes.RUC, Clientes.Direccion_Cliente, Clientes.Municipio, Clientes.Departamento, Clientes.Telefono, Clientes.Limite_Credito ORDER BY Facturas.Cod_Cliente"
            SqlDatos = "SELECT DISTINCT Facturas.Cod_Cliente, MAX(Facturas.Cod_Vendedor) AS Cod_Vendedor, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor)  AS NombreVendedor, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Clientes.RUC, Clientes.Direccion_Cliente, Clientes.Municipio, Clientes.Departamento, Clientes.Telefono, Clientes.Limite_Credito, COUNT(*) AS Expr1, MAX(Clientes.Cedula) AS Cedula, MAX(Clientes.Estado) AS Estado FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  WHERE (Facturas.Nombre_Cliente <> N'******CANCELADO') GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Clientes.RUC, Clientes.Direccion_Cliente, Clientes.Municipio, Clientes.Departamento, Clientes.Telefono, Clientes.Limite_Credito ORDER BY Facturas.Cod_Cliente "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Visible = True
            Registros = DataSet.Tables("Productos").Rows.Count
            iPosicion = 0
            Contador = 2
            iPosicionExcel = 2

            Do While Registros > iPosicion
                CodigoCliente = DataSet.Tables("Productos").Rows(iPosicion)("Cod_Cliente")

                'If CodigoCliente <> "" Then
                '    If CodigoCliente = "1016" Then
                '        Moneda = "Cordobas"
                '    End If

                'End If

                If Me.OptCordobas.Checked = True Then
                    Moneda = "Cordobas"
                Else
                    Moneda = "Dolares"
                End If

                DiasMora = 0
                If CodigoCliente <> "" Then
                    SaldoCorriente = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, -100, 0)
                    Saldo30Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 1, 30)
                    Saldo60Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 31, 60)
                    Saldo90Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 61, 90)
                    SaldoMas90Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 91, 10000)
                    SaldoTotal = SaldoCorriente + Saldo30Dias + Saldo60Dias + Saldo90Dias + SaldoMas90Dias
                    SaldoMora = Saldo30Dias + Saldo60Dias + Saldo90Dias + SaldoMas90Dias
                    'SaldoMas90Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 91, 1000)
                    If SaldoTotal > 0 Then

                        'If Saldo30Dias > 0 Then
                        '    DiasMora = DiasMaxMora
                        'ElseIf Saldo60Dias > 0 Then
                        '    DiasMora = 60
                        'ElseIf Saldo90Dias > 0 Then
                        '    DiasMora = 90
                        'ElseIf SaldoMas90Dias > 0 Then
                        '    DiasMora = 100

                        'End If

                        DiasMora = DiasMaxMora

                        If Me.OptCordobas.Checked = True Then
                            Moneda = "NIO"
                        Else
                            Moneda = "USD"
                        End If

                        oSheet.Range("A" & Contador).Value = "CRD"
                        oSheet.Range("B" & Contador).Value = iPosicion + 1
                        oSheet.Range("C" & Contador).Value = TipoSujeto(CodigoCliente)
                        oSheet.Range("D" & Contador).Value = "NI"
                        oSheet.Range("E" & Contador).Value = Trim(DataSet.Tables("Productos").Rows(iPosicion)("Nombre_Cliente")) & " " & Trim(DataSet.Tables("Productos").Rows(iPosicion)("Apellido_Cliente"))

                        Tipo = TipoSujeto(CodigoCliente)

                        TestString = DataSet.Tables("Productos").Rows(iPosicion)("Apellido_Cliente")
                        TestArray = Split(TestString)


                        Dim LastNonEmpty As Integer = -1

                        If Tipo <> "J" Then
                            For iPos As Integer = 0 To TestArray.Length - 1
                                If TestArray(iPos) <> "" Then
                                    LastNonEmpty += 1
                                    Select Case iPos
                                        Case 0 : oSheet.Range("F" & Contador).Value = TestArray(iPos)
                                        Case 1 : oSheet.Range("G" & Contador).Value = TestArray(iPos)
                                    End Select
                                End If
                            Next
                        End If
                        'ReDim Preserve TestArray(LastNonEmpty)

                        TestString = DataSet.Tables("Productos").Rows(iPosicion)("Nombre_Cliente")
                        TestArray = Split(TestString)

                        LastNonEmpty = -1
                        For iPos As Integer = 0 To TestArray.Length - 1
                            If TestArray(iPos) <> "" Then
                                LastNonEmpty += 1
                                Select Case iPos
                                    Case 0 : oSheet.Range("I" & Contador).Value = TestArray(iPos)
                                    Case 1 : oSheet.Range("J" & Contador).Value = TestArray(iPos)
                                End Select
                            End If
                        Next

                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Cedula")) Then
                            oSheet.Range("K" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Cedula")
                        End If

                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("RUC")) Then
                            oSheet.Range("L" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("RUC")
                        End If

                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Direccion_Cliente")) Then
                            DireccionCliente = Trim(DataSet.Tables("Productos").Rows(iPosicion)("Direccion_Cliente"))
                            oSheet.Range("S" & Contador).Value = Trim(DireccionCliente)
                        End If
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Municipio")) Then
                            oSheet.Range("T" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Municipio")
                        End If
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Departamento")) Then
                            oSheet.Range("U" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Departamento")
                        End If
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Telefono")) Then
                            oSheet.Range("Z" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Telefono")
                        End If
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Telefono")) Then
                            oSheet.Range("AA" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Telefono")
                        End If
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Telefono")) Then
                            oSheet.Range("AB" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Telefono")
                        End If

                        oSheet.Range("AC" & Contador).Value = "CBR"
                        oSheet.Range("AD" & Contador).Value = Moneda
                        oSheet.Range("AF" & Contador).Value = Trim(CodigoCliente)
                        oSheet.Range("AG" & Contador).Value = Format(Now, "yyyymmdd")  'Pendiente Preguntar
                        oSheet.Range("AI" & Contador).Value = "BIM"
                        oSheet.Range("AJ" & Contador).Value = "VIG"
                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Estado")) Then
                            If DataSet.Tables("Productos").Rows(iPosicion)("Estado") = "" Then
                                If DiasMora > 0 Then
                                    oSheet.Range("AK" & Contador).Value() = "MOR"
                                Else
                                    oSheet.Range("AK" & Contador).Value() = "DIA"
                                End If
                            Else
                                If DiasMora > 0 And DataSet.Tables("Productos").Rows(iPosicion)("Estado") = "DIA" Then
                                    oSheet.Range("AK" & Contador).Value() = "MOR"
                                Else
                                    oSheet.Range("AK" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Estado")
                                End If
                            End If
                        End If

                        oSheet.Range("AM" & Contador).Value = DiasMora

                        If Not IsDBNull(DataSet.Tables("Productos").Rows(iPosicion)("Limite_Credito")) Then
                            oSheet.Range("AN" & Contador).Value = DataSet.Tables("Productos").Rows(iPosicion)("Limite_Credito")
                        End If
                        oSheet.Range("AO" & Contador).Value = SaldoTotal
                        oSheet.Range("AP" & Contador).Value = SaldoMora
                        oSheet.Range("AQ" & Contador).Value = 0
                        oSheet.Range("AR" & Contador).Value = "DIR"
                        oSheet.Range("AS" & Contador).Value = "AVA"

                        Contador = Contador + 1
                    End If

                End If

                Me.Text = "Procesando: " & Trim(CodigoCliente) & " " & DataSet.Tables("Productos").Rows(iPosicion)("Nombre_Cliente")
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                iPosicion = iPosicion + 1


            Loop

            oExcel.Visible = True

            oExcel.UserControl = True

            'Guardaremos el documento en el escritorio con el nombre prueba
            Ruta = "\desktop\TransUnion " & Format(Now, "ddMMyyyy") & ".xls"
            oBook.SaveAs(Environ("UserProfile") & Ruta)

            Me.ProgressBar.Visible = False



        ElseIf Me.OptButton1.Checked = True Then

            oSheet.Range("A1").Value = "Fecha Emisión"
            oSheet.Range("B1").Value = "Persona"
            oSheet.Range("C1").Value = "Movimiento"
            oSheet.Range("D1").Value = "Concepto"
            oSheet.Range("E1").Value = "Referencia"
            oSheet.Range("F1").Value = "Cantidad"
            oSheet.Range("G1").Value = "Importe"
            oSheet.Range("H1").Value = "Fecha Inicio"
            oSheet.Range("I1").Value = "Fecha Termino"
            oSheet.Range("J1").Value = "Horas"


            'SqlDatos = "SELECT SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Detalle_Facturas.Importe * TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteCordobas, MAX(Facturas.MonedaFactura) AS Moneda, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Detalle_Facturas.Importe / TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteDolares, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Cliente, MAX(Facturas.Fecha_Factura) AS Fecha_Factura FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
            '           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') GROUP BY Facturas.Cod_Cliente"
            SqlDatos = "SELECT     SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Detalle_Facturas.Importe * TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteCordobas, MAX(Facturas.MonedaFactura) AS Moneda, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Detalle_Facturas.Importe / TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteDolares, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Cliente, MAX(Facturas.Fecha_Factura) AS Fecha_Factura FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                       "WHERE  (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente"
            MiConexion.Open()

            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataSet.Reset()
            DataAdapter.Fill(DataSet, "Consultas")
            If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
                iPosicionFila = 0
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Visible = True
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Maximum = DataSet.Tables("Consultas").Rows.Count
                Contador = 2

                Do While iPosicionFila < (DataSet.Tables("Consultas").Rows.Count)

                    A = "A" & Contador
                    B = "B" & Contador
                    C = "C" & Contador
                    D = "D" & Contador
                    EE = "E" & Contador
                    F = "F" & Contador
                    G = "G" & Contador
                    H = "H" & Contador
                    I = "I" & Contador
                    J = "J" & Contador

                    oSheet.Range(A).Value = Format(Now, "dd/MM/yyyy")
                    oSheet.Range(B).Value = DataSet.Tables("Consultas").Rows(iPosicionFila)("Cod_Cliente")
                    oSheet.Range(C).Value = "Incidencia"
                    oSheet.Range(D).Value = "102"
                    oSheet.Range(EE).Value = "AAA"
                    oSheet.Range(F).Value = 1
                    oSheet.Range(G).Value = DataSet.Tables("Consultas").Rows(iPosicionFila)("ImporteCordobas")
                    oSheet.Range(H).Value = Me.DTPFechaFin.Value
                    oSheet.Range(I).Value = Me.DTPFechaFin.Value
                    oSheet.Range(J).Value = 0



                    Contador = Contador + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    iPosicionFila = iPosicionFila + 1
                Loop


            End If


            oExcel.Visible = True
            oExcel.UserControl = True
            'Guardaremos el documento en el escritorio con el nombre prueba

            oBook.SaveAs(Environ("UserProfile") & "\desktop\Prueba.xls")

        End If


    End Sub

    Public Function ConsultaSaldoCliente(ByVal CodigoCliente As String, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Moneda As String, ByVal DiasIni As Double, ByVal DiasFin As Double) As Double

        Dim SQlString As String, NumeroRecibo As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, MontoRecibo As Double = 0
        Dim MontoFactura As Double, NumeroFactura As String, MontoMetodoFactura As Double = 0
        Dim TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double = 0
        Dim TotalDebito As Double = 0, TotalCredito As Double = 0

        My.Application.DoEvents()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.NetoPagar * TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.NetoPagar / TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoDolares, DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias,Facturas.Numero_Factura FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE   (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & " ) AND (Clientes.Cod_Cliente = '" & CodigoCliente & "') ORDER BY DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")


        DiasMaxMora = 0
        Registros = DataSet.Tables("Facturas").Rows.Count
        i = 0
        TotalFactura = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteCordobas") + DataSet.Tables("Facturas").Rows(i)("IvaCordobas")
            Else
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteDolares") + DataSet.Tables("Facturas").Rows(i)("IvaDolares")
            End If


            NumeroFactura = DataSet.Tables("Facturas").Rows(i)("Numero_Factura")
            'FechaFactura = DataSet.Tables("Facturas").Rows(i)("Fecha_Factura")
            'FechaVence = DataSet.Tables("Facturas").Rows(i)("Fecha_Vencimiento")
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
            '            "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')  AND (MAX(DetalleRecibo.Fecha_Recibo) <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) "
            SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo " & _
                        "WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente =  '" & CodigoCliente & "')"
            'WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            Registros2 = DataSet.Tables("Recibos").Rows.Count
            j = 0
            MontoRecibo = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    End If
                Else
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    End If
                End If
                If NumeroRecibo = "" Then
                    NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                Else
                    NumeroRecibo = NumeroRecibo & "," & DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                End If
                MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

                j = j + 1
            Loop
            DataSet.Tables("Recibos").Reset()


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaDB")
            Registros2 = DataSet.Tables("NotaDB").Rows.Count
            NumeroNota = ""
            j = 0
            MontoNota = 0
            TotalMontoNotaDB = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                End If
                If NumeroNota = "" Then
                    NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                Else
                    NumeroNota = NumeroNota & "," & DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                End If
                MontoNota = MontoNota + DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaDB = MontoNota
                j = j + 1
            Loop

            DataSet.Tables("NotaDB").Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
            '
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaCR")
            Registros2 = DataSet.Tables("NotaCR").Rows.Count
            NumeroNotaCR = ""
            j = 0
            MontoNotaCR = 0
            TotalMontoNotaCR = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                End If
                If NumeroNotaCR = "" Then
                    NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                Else
                    NumeroNotaCR = NumeroNotaCR & "," & DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                End If
                MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MontoMetodoFactura = 0
            'SQlString = "SELECT * FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "') AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
            SQlString = "SELECT Detalle_MetodoFacturas.Numero_Factura, Detalle_MetodoFacturas.Fecha_Factura, Detalle_MetodoFacturas.Tipo_Factura, Detalle_MetodoFacturas.NombrePago, Detalle_MetodoFacturas.Monto, Detalle_MetodoFacturas.NumeroTarjeta, Detalle_MetodoFacturas.FechaVence, Detalle_MetodoFacturas.Arqueado, MetodoPago.NombrePago AS Expr1, MetodoPago.TipoPago, MetodoPago.Cod_Cuenta, MetodoPago.Moneda FROM Detalle_MetodoFacturas INNER JOIN  MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "') AND (Facturas.Nombre_Cliente <> N'******CANCELADO') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "MetodoFactura")
            If DataSet.Tables("MetodoFactura").Rows.Count <> 0 Then
                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("MetodoFactura").Rows(0)("Fecha_Factura"))
                    End If
                Else
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("MetodoFactura").Rows(0)("Fecha_Factura"))
                    End If
                End If

                MontoMetodoFactura = DataSet.Tables("MetodoFactura").Rows(0)("Monto") * TasaCambioRecibo

            End If
            DataSet.Tables("MetodoFactura").Reset()


            TotalDebito = Format(TotalDebito + MontoFactura + TotalMontoNotaDB, "##,##0.00")
            TotalCredito = Format(TotalCredito + MontoRecibo + MontoMetodoFactura + TotalMontoNotaCR, "##,##0.00")
            TotalFactura = Format(TotalFactura + MontoFactura - MontoRecibo - MontoMetodoFactura - TotalMontoNotaCR + TotalMontoNotaDB, "##,##0.000000")

            If Format(TotalDebito, "##,##0.00") - Format(TotalCredito, "##,##0.00") > 0 Then

                If DataSet.Tables("Facturas").Rows(i)("Dias") > DiasMaxMora Then
                    DiasMaxMora = DataSet.Tables("Facturas").Rows(i)("Dias")
                Else
                    DiasMaxMora = 0
                End If
            End If

            i = i + 1
            Me.ProgressBar1.Value = i

        Loop

        MontoRecibo = 0
        MontoMetodoFactura = 0
        TotalMontoNotaCR = 0
        TotalMontoNotaDB = 0


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota  " & _
        '            "WHERE (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_Nota.Numero_Factura = '0000') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"

        'SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota  " & _
        '                    "WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (Detalle_Nota.Numero_Factura NOT IN (SELECT Numero_Factura FROM Facturas  WHERE (Cod_Cliente = '" & CodigoCliente & "') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))))"

        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB  " & _
                    "WHERE (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Detalle_Nota.Numero_Factura = '0000') AND (NotaDebito.Tipo = 'Debito Clientes') AND (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ")"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDB")
        Registros2 = DataSet.Tables("NotaDB").Rows.Count
        NumeroNota = ""
        j = 0
        MontoNota = 0
        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                End If
            Else
                If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                End If
            End If
            If NumeroNota = "" Then
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            Else
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            End If
            MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            j = j + 1
        Loop

        DataSet.Tables("NotaDB").Reset()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota  " & _
        '            "WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (Detalle_Nota.Numero_Factura NOT IN  (SELECT Numero_Factura FROM Facturas WHERE (Cod_Cliente = '" & CodigoCliente & "') AND (Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))))"

        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB  " & _
                    "WHERE (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Detalle_Nota.Numero_Factura = N'0000') AND (NotaDebito.Tipo = 'Credito Clientes') AND (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ")"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCR")
        Registros2 = DataSet.Tables("NotaCR").Rows.Count
        NumeroNotaCR = ""
        j = 0
        MontoNotaCR = 0
        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                End If
            Else
                If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                End If
            End If
            If NumeroNotaCR = "" Then
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            Else
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            End If
            MontoNotaCR = MontoNotaCR + DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR

            j = j + 1
        Loop
        DataSet.Tables("NotaCR").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo, Recibo.Cod_Cliente, SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) AS Dias FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente  " & _
        '            "HAVING (SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"

        SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo, Recibo.Cod_Cliente, SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) AS Dias FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo  " & _
                    "WHERE (DetalleRecibo.Fecha_Recibo <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente HAVING (SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND(Recibo.Cod_Cliente = '" & CodigoCliente & "') AND (DetalleRecibo.Numero_Factura = N'0')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        Registros2 = DataSet.Tables("Recibos").Rows.Count
        j = 0

        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                End If
            Else
                If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                End If
            End If
            If NumeroRecibo = "" Then
                NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
            Else
                NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
            End If
            MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

            TotalAbonos = TotalAbonos + MontoRecibo
            j = j + 1
        Loop




        ConsultaSaldoCliente = Format(TotalFactura + TotalMontoNotaDB - TotalMontoNotaCR - TotalAbonos, "##,##0.00")



    End Function

    Private Sub FrmExportar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Exportar a Excel")
    End Sub


    Private Sub FrmExportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class