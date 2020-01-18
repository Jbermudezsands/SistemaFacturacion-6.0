Public Class FrmLotesFactura
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public CodigoProducto As String, NombreProducto As String, Cantidad As Double, NumeroDocumento As String, TipoDocumento As String, Fecha As Date, CodigoBodega As String, NLotes As String
    Public Function LoteRecomendado(ByVal CodigoProducto As String, ByVal NumeroLote As String, ByVal CodigoBodega As String) As String
        Dim SQlString As String, iPosicion As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0
        Dim ExistenciaLote As Double, FechaVence As Date
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQlString = "SELECT     MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote WHERE  (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Lote.Activo = 1) GROUP BY Detalle_Compras.Numero_Lote, Lote.FechaVence  HAVING(Not (Detalle_Compras.Numero_Lote Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")
        iPosicion = 0
        LoteRecomendado = "--0--"

        Do While DataSet.Tables("Lotes").Rows.Count > iPosicion

            'CodigoProducto = DataSet.Tables("Lotes").Rows(iPosicion)("Cod_Producto")
            NumeroLote = DataSet.Tables("Lotes").Rows(iPosicion)("Numero_Lote")
            If Not IsDBNull(DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")) Then
                FechaVence = DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")
            End If

            ExistenciaLote = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega, NumeroLote)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////


            If ExistenciaLote = 0 Then
                'MiConexion.Close()
                'StrSqlUpdate = "UPDATE [Lote] SET [Activo] = 0 WHERE (Numero_Lote = '" & NumeroLote & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

            Else
                LoteRecomendado = ExistenciaLote
            End If

            iPosicion = iPosicion + 1
        Loop



    End Function



    Private Sub FrmLotesFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String, iPosicion As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0
        Dim ExistenciaLote As Double, FechaVence As Date, NumeroLote As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        ''*******************************************************************************************************************************
        ''/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        ''*******************************************************************************************************************************
        SQlString = "SELECT Numero_Lote, FechaVence, Cantidad as Existencia FROM Detalle_Lote WHERE (Numero_Documento = '-1000000000') AND (Fecha = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "ExistenciaLotes")




        SQlString = "SELECT     MAX(Detalle_Compras.Cod_Producto) AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote WHERE  (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "') AND (Lote.Activo = 1) GROUP BY Detalle_Compras.Numero_Lote, Lote.FechaVence  HAVING(Not (Detalle_Compras.Numero_Lote Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")
        iPosicion = 0

        Do While DataSet.Tables("Lotes").Rows.Count > iPosicion

            'CodigoProducto = DataSet.Tables("Lotes").Rows(iPosicion)("Cod_Producto")
            NumeroLote = DataSet.Tables("Lotes").Rows(iPosicion)("Numero_Lote")
            If Not IsDBNull(DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")) Then
                FechaVence = DataSet.Tables("Lotes").Rows(iPosicion)("FechaVence")
            End If

            ExistenciaLote = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega, NumeroLote)

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////SI LA EXISTENCIA DEL LOTE ES CERO LO INACTIVO ///////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////

            If ExistenciaLote = 0 Then
                'MiConexion.Close()
                'StrSqlUpdate = "UPDATE [Lote] SET [Activo] = 0 WHERE (Numero_Lote = '" & NumeroLote & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

            Else
                oDataRow = DataSet.Tables("ExistenciaLotes").NewRow
                oDataRow("Numero_Lote") = NumeroLote
                oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
                oDataRow("Existencia") = ExistenciaLote
                DataSet.Tables("ExistenciaLotes").Rows.Add(oDataRow)
            End If







            iPosicion = iPosicion + 1
        Loop

        Me.BindingDetalle.DataSource = DataSet.Tables("ExistenciaLotes")
        Me.C1TrueDBGrid1.DataSource = Me.BindingDetalle.DataSource


        'SQlString = "SELECT Cantidad, Numero_Lote, Cantidad As Disponible, FechaVence FROM Detalle_Lote WHERE (Numero_Documento = '-1000000000') AND (Fecha = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Lotes"

        'ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
        'ExistenciaSinLote = BuscaExistenciaLoteTotal(CodigoProducto, "SIN LOTE", CodigoBodega)
        'ExistenciaLote = BuscaExistenciaLote(CodigoProducto, CodigoBodega)
        'If ExistenciaSinLote < 0 Then
        '    ExistenciaSinLote = ExistenciaBodega - Math.Abs(ExistenciaSinLote) - ExistenciaLote
        'Else
        '    ExistenciaSinLote = ExistenciaBodega - ExistenciaSinLote - ExistenciaLote
        'End If

        'SQlString = "SELECT id_Detalle_Lote, Cantidad, Numero_Lote, FechaVence, Tipo_Documento, Numero_Documento, Fecha, Codigo_Producto  FROM Detalle_Lote WHERE (Codigo_Producto = '" & CodigoProducto & "') AND (Tipo_Documento = 'Mercancia Recibida')"
        ''SQlString = "SELECT SUM(Cantidad) AS Cantidad, Numero_Lote, MIN(FechaVence) AS FechaVence, MAX(Tipo_Documento) AS Tipo_Documento, MAX(Fecha) AS Fecha, MAX(Codigo_Producto) AS Codigo_Producto FROM Detalle_Lote WHERE  (Tipo_Documento = 'Mercancia Recibida') AND (Codigo_Producto = '" & CodigoProducto & "') GROUP BY Numero_Lote"

        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "ListaLotes")
        'Registro = DataSet.Tables("ListaLotes").Rows.Count


        'If Registro = 0 Then
        '    If ExistenciaSinLote > 0 Then
        '        oDataRow = DataSet.Tables("Lotes").NewRow
        '        oDataRow("Cantidad") = 0
        '        oDataRow("Numero_Lote") = "SIN LOTE"
        '        oDataRow("Disponible") = ExistenciaSinLote
        '        oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
        '        DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '    End If
        'End If
        'i = 0
        'ExistenciaLote = 0
        'Do While Registro > i

        '    CodigoLote = DataSet.Tables("ListaLotes").Rows(i)("Numero_Lote")
        '    FechaVence = DataSet.Tables("ListaLotes").Rows(i)("FechaVence")
        '    'ExistenciaLote = BuscaExistenciaLote(CodigoProducto, CodigoLote)
        '    ExistenciaLote = BuscaExistenciaLoteTotal(CodigoProducto, CodigoLote, CodigoBodega)



        '    If i = 0 Then
        '        If ExistenciaSinLote > 0 Then
        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = "SIN LOTE"
        '            oDataRow("Disponible") = ExistenciaSinLote
        '            oDataRow("FechaVence") = Format(Now, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)

        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = CodigoLote
        '            oDataRow("Disponible") = ExistenciaLote
        '            oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '        Else
        '            oDataRow = DataSet.Tables("Lotes").NewRow
        '            oDataRow("Cantidad") = 0
        '            oDataRow("Numero_Lote") = CodigoLote
        '            oDataRow("Disponible") = ExistenciaLote
        '            oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
        '            DataSet.Tables("Lotes").Rows.Add(oDataRow)
        '        End If





        '    End If

        '    i = i + 1
        'Loop


        'DataSet.Tables("Lotes").Dispose()

        'SQlString = "SELECT Numero_Lote, Codigo_Producto, Fecha, Cantidad, Tipo_Documento As Tipo,Numero_Documento As Numero,id_Detalle_Lote FROM Detalle_Lote WHERE (Tipo_Documento = 'Factura') AND (Codigo_Producto = '" & CodigoProducto & " ')" 'AND (Numero_Documento = '" & NumeroDocumento & " ')
        ''SQlString = "SELECT * FROM Lote  WHERE(Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleLotes")
        'DataSet.Tables("DetalleLotes").Dispose()

        ''Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False


        'DataSet.Relations.Add("RelacionLotes", DataSet.Tables("Lotes").Columns("Numero_Lote"), DataSet.Tables("DetalleLotes").Columns("Numero_Lote"))


        ''///////Relacion entre Grid .....
        'Me.TrueDBGridComponentes.DataSource = DataSet
        'Me.TrueDBGridComponentes.DataMember = "Lotes"
        'Me.BindingDetalle.DataSource = DataSet.Tables("Lotes")

        'Me.TrueDBGridComponentes.Col = 1
        'Me.TrueDBGridComponentes.Row = 0
        'Me.TrueDBGridComponentes.Columns(0).Caption = "Numero Lote"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 73
        'Me.TrueDBGridComponentes.Columns(1).Caption = "Nombre Lote"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 254
        'Me.TrueDBGridComponentes.Columns(2).Caption = "Disponible"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 73
        'Me.TrueDBGridComponentes.Columns(3).Caption = "Fecha Vence"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 93

        'Me.TrueDBGridDetalle.DataSource = DataSet
        'Me.TrueDBGridDetalle.DataMember = "Lotes.RelacionLotes"
        'Me.TrueDBGridComponentes.ChildGrid = Me.TrueDBGridDetalle

        'Me.TrueDBGridDetalle.Splits.Item(0).DisplayColumns(6).Visible = False

        'SQlString = "SELECT * FROM Lote  WHERE(Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "LotesFactura")
        '


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Registros As String, iPosicion As Double, NombreLote As String, id As Double, CodigoProducto As String, FechaVence As Date, CantidadLote As Double

        'Me.BindingDetalle.MoveFirst()
        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0

        iPosicion = Me.BindingDetalle.Position
        If iPosicion = -1 Then
            Exit Sub
        End If

        NLotes = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        NLotes = Me.C1TrueDBGrid1.Columns(0).Text
        Fecha = Me.C1TrueDBGrid1.Columns(1).Text

        'Do While iPosicion < Registros
        '    '/////////////////////////////////////////BUSCO EL NUEMERO DE SERIES //////////////////////////////
        '    'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")) Then
        '    '    id = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")
        '    'Else
        '    '    id = -1000000
        '    'End If

        '    CodigoProducto = Me.CodigoProducto
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '        NombreLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
        '        FechaVence = Me.BindingDetalle.Item(iPosicion)("FechaVence")
        '        CantidadLote = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '        If CantidadLote <> 0 Then
        '            GrabaDetalleLotes(Me.NumeroDocumento, Me.Fecha, Me.TipoDocumento, id, CodigoProducto, CantidadLote, NombreLote, FechaVence)
        '        End If


        '    End If

        '    iPosicion = iPosicion + 1
        'Loop

        'FrmFacturas.Graba()

        Me.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TrueDBGridDetalle_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridDetalle.BeforeDelete
        Dim IdDetalle As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        If MsgBox("Esta Seguro de eliminar el Registro", MsgBoxStyle.YesNo, "Zeus Facturacion") = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        IdDetalle = Me.TrueDBGridDetalle.Columns(5).Text

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LOS LOTES///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        MiConexion.Close()
        StrSqlUpdate = "DELETE FROM [Detalle_Lote] WHERE (id_Detalle_Lote = " & IdDetalle & ") AND (Tipo_Documento = 'Factura') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

    End Sub



    Private Sub TrueDBGridDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridDetalle.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class