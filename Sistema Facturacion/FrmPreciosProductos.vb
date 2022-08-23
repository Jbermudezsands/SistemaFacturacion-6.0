Public Class FrmPreciosProductos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodProducto As String, NombreProducto As String, PrecioProducto As Double, ValidarRegistros As Boolean = False
    Public Cod_TipoPrecio As String, PrecioProductoDolar As Double

    Private Sub cmdAddDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddDocente.Click
        Dim CodigoPrecio As String
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        Quien = "CodigoTipoPrecio"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoPrecio = My.Forms.FrmConsultas.Codigo

        SqlString = "SELECT Cod_Productos, Cod_TipoPrecio, Monto_Precio, Monto_PrecioDolar FROM Precios WHERE (Cod_Productos = '" & CodProducto & "') AND (Cod_TipoPrecio = '" & CodigoPrecio & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
            MsgBox("Este Precio ya fue asignado para este producto", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        Else
            StrSqlUpdate = "INSERT INTO [Precios] ([Cod_Productos] ,[Cod_TipoPrecio] ,[Monto_Precio] ,[Monto_PrecioDolar]) " & _
                           "VALUES('" & CodProducto & "','" & CodigoPrecio & "',0,0)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If




        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT TipoPrecio.Tipo_Precio AS Descripcion, Precios.Monto_Precio, Precios.Monto_PrecioDolar, TipoPrecio.Cod_TipoPrecio FROM  Precios INNER JOIN TipoPrecio ON Precios.Cod_TipoPrecio = TipoPrecio.Cod_TipoPrecio WHERE (Precios.Cod_Productos = '" & CodProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleFactura")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Descripcion Precio"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 140
        Me.TrueDBGridComponentes.Columns(1).Caption = "Precio C$"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridComponentes.Columns(2).Caption = "Precio $"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 70
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False

        If Me.ValidarRegistros = True Then
            If DataSet.Tables("DetalleFactura").Rows.Count = 0 Then
                Me.cmdAddDocente.Visible = True
                Me.CmdPegar.Visible = False
            Else
                Me.cmdAddDocente.Visible = False
                Me.CmdPegar.Visible = True

            End If
        End If

    End Sub

    Private Sub FrmPreciosProductos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.CmdPegar.Location = New Point(7, 354)
        Me.CmdPegar.Visible = False
        Me.cmdAddDocente.Visible = True
    End Sub

    Private Sub PreciosProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow, Iposicion As Double, FechaFin As Date
        Dim CostoUnitario As Double, PrecioVenta As Double, Incremento As Double, TasaCambio As Double, Porciento As Double, PrecioVentaDolar As Double


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '******************************************************************************************************************************
        SqlString = "SELECT TipoPrecio.Tipo_Precio AS Descripcion, Precios.Monto_Precio, Precios.Monto_PrecioDolar, TipoPrecio.Cod_TipoPrecio FROM  Precios INNER JOIN TipoPrecio ON Precios.Cod_TipoPrecio = TipoPrecio.Cod_TipoPrecio WHERE (Precios.Cod_Productos = '-10000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Precios")

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '++++++++++++++++++++++CONSULTO SI EL TIPO DE PRECIO ES PORCENTUAL +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        SqlString = "SELECT  TipoPrecio.Tipo_Precio AS Descripcion, Precios.Monto_Precio, Precios.Monto_PrecioDolar, TipoPrecio.Cod_TipoPrecio, TipoPrecio.PrecioPorcentual, TipoPrecio.Porciento FROM Precios INNER JOIN  TipoPrecio ON Precios.Cod_TipoPrecio = TipoPrecio.Cod_TipoPrecio " & _
                    "WHERE (Precios.Cod_Productos = '" & CodProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PreciosFactura")
        Iposicion = 0
        Do While Iposicion < DataSet.Tables("PreciosFactura").Rows.Count


            If DataSet.Tables("PreciosFactura").Rows(Iposicion)("PrecioPorcentual") = "True" Then
                FechaFin = Format(Now, "dd/MM/yyyy")
                If DataSet.Tables("PreciosFactura").Rows(Iposicion)("Porciento") <> "" Then
                    Porciento = DataSet.Tables("PreciosFactura").Rows(Iposicion)("Porciento")
                End If
                Incremento = 1 + (CDbl(Porciento) / 100)
                TasaCambio = BuscaTasaCambio(FechaFin)
                CostoUnitario = CostoPromedioKardex(CodProducto, FechaFin)
                PrecioVenta = Format(CostoUnitario * Incremento, "##,##0.00")
                PrecioVentaDolar = Format(PrecioVenta / TasaCambio, "##,##0.00")
            Else
                PrecioVenta = DataSet.Tables("PreciosFactura").Rows(Iposicion)("Monto_Precio")
                PrecioVentaDolar = DataSet.Tables("PreciosFactura").Rows(Iposicion)("PrecioDolar")
            End If

            oDataRow = DataSet.Tables("Precios").NewRow
            oDataRow("Descripcion") = DataSet.Tables("PreciosFactura").Rows(Iposicion)("Descripcion")
            oDataRow("Monto_Precio") = PrecioVenta
            oDataRow("Monto_PrecioDolar") = PrecioVentaDolar
            oDataRow("Cod_TipoPrecio") = DataSet.Tables("PreciosFactura").Rows(Iposicion)("Cod_TipoPrecio")
            DataSet.Tables("Precios").Rows.Add(oDataRow)
            Iposicion = Iposicion + 1
        Loop



        Me.LblProducto.Text = CodProducto & " " & NombreProducto
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT TipoPrecio.Tipo_Precio AS Descripcion, Precios.Monto_Precio, Precios.Monto_PrecioDolar, TipoPrecio.Cod_TipoPrecio FROM  Precios INNER JOIN TipoPrecio ON Precios.Cod_TipoPrecio = TipoPrecio.Cod_TipoPrecio WHERE (Precios.Cod_Productos = '" & CodProducto & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleFactura")
        Me.BindingDetalle.DataSource = DataSet.Tables("Precios")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Descripcion Precio"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 140
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(1).Caption = "Precio C$"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridComponentes.Columns(2).Caption = "Precio $"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 70
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim CodigoPrecio As String
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim PrecioDolar As Double, Precio As Double


        PrecioDolar = Me.TrueDBGridComponentes.Columns(2).Text
        Precio = Me.TrueDBGridComponentes.Columns(1).Text
        CodigoPrecio = Me.TrueDBGridComponentes.Columns(3).Text

        SqlString = "SELECT Cod_Productos, Cod_TipoPrecio, Monto_Precio, Monto_PrecioDolar FROM Precios WHERE (Cod_Productos = '" & CodProducto & "') AND (Cod_TipoPrecio = '" & CodigoPrecio & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
            StrSqlUpdate = "UPDATE [Precios] SET [Monto_Precio] = '" & Precio & "' ,[Monto_PrecioDolar] = '" & PrecioDolar & "' WHERE (Cod_Productos = '" & CodProducto & "') AND (Cod_TipoPrecio = '" & CodigoPrecio & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            'StrSqlUpdate = "INSERT INTO [Precios] ([Cod_Productos] ,[Cod_TipoPrecio] ,[Monto_Precio] ,[Monto_PrecioDolar]) " & _
            '               "VALUES('" & CodProducto & "','" & CodigoPrecio & "',0,0)"
            'MiConexion.Open()
            'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            'iResultado = ComandoUpdate.ExecuteNonQuery
            'MiConexion.Close()
        End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub CmdPegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPegar.Click
        Dim Posicion As Double

        Posicion = Me.BindingDetalle.Position
        If FrmFacturas.TxtMonedaFactura.Text = "Cordobas" Then
            PrecioProducto = Me.BindingDetalle.Item(Posicion)("Monto_Precio")

        Else
            PrecioProducto = Me.BindingDetalle.Item(Posicion)("Monto_PrecioDolar")
        End If


        Me.PrecioProductoDolar = Me.BindingDetalle.Item(Posicion)("Monto_PrecioDolar")
        Me.Cod_TipoPrecio = Me.BindingDetalle.Item(Posicion)("Cod_TipoPrecio")

        Me.Close()
    End Sub
End Class