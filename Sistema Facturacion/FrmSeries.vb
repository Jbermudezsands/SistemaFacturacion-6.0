Public Class FrmSeries
    Public Tipo As String, Numero As String, Fecha As Date, CodigoProducto As String, NombreProducto As String, Cantidad As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion), DataSet As New DataSet
    Public NumeroSerie(3) As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String, NumeroSerie As String, NumeroSerie2 As String, NumeroSerie3 As String, NumeroSerie4 As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double

        DataSet.Reset()

        Select Case Tipo
            Case "Transferencia Enviada"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Devolucion de Compra"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Mercancia Recibida"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Factura"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Devolucion de Venta"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Salida Bodega"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Ensamble Recibido"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
            Case "Deshacer Ensamble"
                SQlString = "SELECT Id_Series, NSeries, NSeries2, NSeries3, NSeries4 FROM Detalle_ComprasSeries WHERE (Numero_Compra = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Series")
        End Select

        For i = 1 To Cantidad
            oDataRow = DataSet.Tables("Series").NewRow
            oDataRow("Id_Series") = i
            NumeroSerie = BuscaSerie(Me.Numero, Me.Fecha, Me.Tipo, i, Me.CodigoProducto, "NSeries")
            oDataRow("NSeries") = NumeroSerie
            oDataRow("NSeries2") = BuscaSerie(Me.Numero, Me.Fecha, Me.Tipo, i, Me.CodigoProducto, "NSeries2")
            oDataRow("NSeries3") = BuscaSerie(Me.Numero, Me.Fecha, Me.Tipo, i, Me.CodigoProducto, "NSeries3")
            oDataRow("NSeries4") = BuscaSerie(Me.Numero, Me.Fecha, Me.Tipo, i, Me.CodigoProducto, "NSeries4")
            DataSet.Tables("Series").Rows.Add(oDataRow)
        Next



        Me.BindingDetalle.DataSource = DataSet.Tables("Series")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Col = 1
        Me.TrueDBGridComponentes.Row = 0
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(0).Caption = "Linea"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NSeries").Width = 100
        Me.TrueDBGridComponentes.Columns("NSeries").Caption = BuscarNombreSerie("NSeries")
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NSeries2").Width = 100
        Me.TrueDBGridComponentes.Columns("NSeries2").Caption = BuscarNombreSerie("NSeries2")
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NSeries3").Width = 100
        Me.TrueDBGridComponentes.Columns("NSeries3").Caption = BuscarNombreSerie("NSeries3")
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("NSeries4").Width = 100
        Me.TrueDBGridComponentes.Columns("NSeries4").Caption = BuscarNombreSerie("NSeries4")

    End Sub
    Public Function BuscarNombreSerie(ByVal CampoBuscar As String) As String
        Dim SQlString As String, NumeroSerie As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSetBuscar As New DataSet

        SQlString = "SELECT TOP (1) NombreSerie1, NombreSerie2, NombreSerie3, NombreSerie4 FROM Detalle_ComprasSeriesNombre"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSetBuscar, "Series")
        If DataSetBuscar.Tables("Series").Rows.Count <> 0 Then
            Select Case CampoBuscar
                Case "NSeries"
                    If Not IsDBNull(DataSetBuscar.Tables("Series").Rows(0)("NombreSerie1")) Then
                        BuscarNombreSerie = DataSetBuscar.Tables("Series").Rows(0)("NombreSerie1")
                    Else
                        BuscarNombreSerie = "Numero Serie1"
                    End If
                Case "NSeries2"
                    If Not IsDBNull(DataSetBuscar.Tables("Series").Rows(0)("NombreSerie2")) Then
                        BuscarNombreSerie = DataSetBuscar.Tables("Series").Rows(0)("NombreSerie2")
                    Else
                        BuscarNombreSerie = "Numero Serie2"
                    End If

                Case "NSeries3"
                    If Not IsDBNull(DataSetBuscar.Tables("Series").Rows(0)("NombreSerie3")) Then
                        BuscarNombreSerie = DataSetBuscar.Tables("Series").Rows(0)("NombreSerie3")
                    Else
                        BuscarNombreSerie = "Numero Serie3"
                    End If

                Case "NSeries4"
                    If Not IsDBNull(DataSetBuscar.Tables("Series").Rows(0)("NombreSerie4")) Then
                        BuscarNombreSerie = DataSetBuscar.Tables("Series").Rows(0)("NombreSerie4")
                    Else
                        BuscarNombreSerie = "Numero Serie4"
                    End If

            End Select

        End If


    End Function



    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim Filas() As DataRow, Criterios As String, Posicion As Double = 0

        If Me.TrueDBGridComponentes.Columns(1).Text = "" Then
            Exit Sub
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////VERIFICO SI EL NUMERO DE SERIE EXISTE ////////////////////7
        '///////////////////////////////////////////////////////////////////////////////////////////////////
        Criterios = "NSeries= '" & Me.TrueDBGridComponentes.Columns(1).Text & "' "
        Filas = DataSet.Tables("Series").Select(Criterios)
        If Filas.Length = 1 Then
            MsgBox("ya existe este numero de Serie", MsgBoxStyle.Critical, "Zeus Facturacion")
            Me.TrueDBGridComponentes.Columns(1).Text = ""
            Me.TrueDBGridComponentes.Col = 1
            Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row - 1
            Exit Sub
        End If

        Criterios = "NSeries<> '' "
        Filas = DataSet.Tables("Series").Select(Criterios)
        If Filas.Length + 1 > Cantidad Then
            MsgBox("la cantidad de productos es mayor que los numeros de series digitados", MsgBoxStyle.Critical, "Zeus Facturacion")
            Me.TrueDBGridComponentes.Columns(1).Text = ""
            Me.TrueDBGridComponentes.Col = 1
            Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row - 1
            Exit Sub
        End If

        'Posicion = DataSet.Tables("Series").Rows.IndexOf(Filas(0))
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridComponentes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridComponentes.KeyDown
        If e.KeyCode = 13 Then
            Dim Filas() As DataRow, Criterios As String, Posicion As Double = 0

            If Me.TrueDBGridComponentes.Columns(1).Text = "" Then
                Exit Sub
            End If

            '/////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////VERIFICO SI EL NUMERO DE SERIE EXISTE ////////////////////7
            '///////////////////////////////////////////////////////////////////////////////////////////////////
            Criterios = "NSeries= '" & Me.TrueDBGridComponentes.Columns(1).Text & "' "
            Filas = DataSet.Tables("Series").Select(Criterios)
            If Filas.Length = 1 Then
                MsgBox("ya existe este numero de Serie", MsgBoxStyle.Critical, "Zeus Facturacion")
                Me.TrueDBGridComponentes.Columns(1).Text = ""
                Exit Sub
            End If

            Criterios = "NSeries<> '' "
            Filas = DataSet.Tables("Series").Select(Criterios)
            If Cantidad < Filas.Length + 1 Then
                MsgBox("la cantidad de productos es menor que los numeros de series digitados", MsgBoxStyle.Critical, "Zeus Facturacion")
                Me.TrueDBGridComponentes.Columns(1).Text = ""
                Exit Sub
            End If
            'Posicion = DataSet.Tables("Series").Rows.IndexOf(Filas(0))

            If Me.TrueDBGridComponentes.Col = 4 Then
                Me.TrueDBGridComponentes.Col = 1
                Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1
            Else
                Me.TrueDBGridComponentes.Col = Me.TrueDBGridComponentes.Col + 1
            End If

        End If
    End Sub

    Private Sub BindingDetalle_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingDetalle.CurrentChanged

    End Sub

    Private Sub BindingDetalle_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BindingDetalle.PositionChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Registros As String, iPosicion As Double, Serie(3) As String, id As Double, CodigoProducto As String

        Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        id = 1
        Do While iPosicion < Registros
            '/////////////////////////////////////////BUSCO EL NUEMERO DE SERIES //////////////////////////////
            'id = Me.BindingDetalle.Item(iPosicion)("Id_Series")

            CodigoProducto = Me.CodigoProducto
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("NSeries")) Then

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("NSeries")) Then
                    Serie(0) = Me.BindingDetalle.Item(iPosicion)("NSeries")
                Else
                    Serie(0) = ""
                End If


                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("NSeries2")) Then
                    Serie(1) = Me.BindingDetalle.Item(iPosicion)("NSeries2")
                Else
                    Serie(1) = ""
                End If

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("NSeries3")) Then
                    Serie(2) = Me.BindingDetalle.Item(iPosicion)("NSeries3")
                Else
                    Serie(2) = ""
                End If

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("NSeries4")) Then
                    Serie(3) = Me.BindingDetalle.Item(iPosicion)("NSeries4")
                Else
                    Serie(3) = ""
                End If




                If Serie(0).ToString <> "" Then
                    GrabaSeries(Me.Numero, Me.Fecha, Me.Tipo, id, CodigoProducto, Serie(0).ToString, Serie(1).ToString, Serie(2).ToString, Serie(3).ToString)
                    id = id + 1
                End If

            End If

            iPosicion = iPosicion + 1
        Loop

        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, id As Double, Posicion As Double, Fecha2 As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        Fecha2 = Format(Fecha, "yyyy-MM-dd")

        Posicion = Me.BindingDetalle.Position
        id = Me.BindingDetalle.Item(Posicion)("Id_Series")
        SQLProveedor = "SELECT     Detalle_ComprasSeries.* FROM Detalle_ComprasSeries WHERE (Id_Series = " & id & ") AND (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha2 & "', 102)) AND (Tipo_Compra = '" & Tipo & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Detalle_ComprasSeries] WHERE (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha2 & "', 102)) AND (Tipo_Compra = '" & Tipo & "') AND (Id_Series = " & id & ") AND (Cod_Producto = '" & CodigoProducto & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Clientes", "Borro numero de serie: ")
        ActualizaSeries()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
End Class