Public Class FrmBodegas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public DataSet As New DataSet

    Private Sub FrmBodegas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Bodegas")
    End Sub



    Private Sub FrmBodegas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLString As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String = "SELECT Cod_TipoPrecio, Tipo_Precio FROM TipoPrecio "


        SQLString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200



        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrecio")
        If Not DataSet.Tables("TipoPrecio").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoPrecio")
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoBodega_ItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoBodega.ItemChanged
        Dim CodigoBodega As String, SQlString As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSetDetalle As New DataSet

        CodigoBodega = Me.CboCodigoBodega.Text
        DataSetDetalle.Reset()
        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSetDetalle, "Consulta")


        If Not DataSetDetalle.Tables("Consulta").Rows.Count = 0 Then

            Me.TxtNombre.Text = DataSetDetalle.Tables("Consulta").Rows(0)("Nombre_Bodega")
            SQlString = "SELECT  DetalleBodegas.Cod_Productos, Productos.Descripcion_Producto FROM DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)

            DataAdapter.Fill(DataSetDetalle, "DetalleBodegas")
            Me.BindingBodega.DataSource = DataSetDetalle.Tables("DetalleBodegas")
            Me.TrueDBGridConsultas.DataSource = Me.BindingBodega
            Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200

        Else
            Me.TxtNombre.Text = ""
            SQlString = "SELECT  DetalleBodegas.Cod_Productos, Productos.Descripcion_Producto FROM DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)

            DataAdapter.Fill(DataSetDetalle, "DetalleBodegas")
            Me.BindingBodega.DataSource = DataSetDetalle.Tables("DetalleBodegas")
            Me.TrueDBGridConsultas.DataSource = Me.BindingBodega
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200
        End If
    End Sub

    Private Sub CboCodigoBodega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoBodega.TextChanged
        Dim CodigoBodega As String, SQlString As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, CostoPromedio As Double, CostoPromedioDolar As Double
        Dim DataSetDetalle As New DataSet, Existencia As Double, IposicionFila As Double

        CodigoBodega = Me.CboCodigoBodega.Text
        DataSetDetalle.Reset()
        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSetDetalle, "Consulta")


        If Not DataSetDetalle.Tables("Consulta").Rows.Count = 0 Then

            Me.TxtNombre.Text = DataSetDetalle.Tables("Consulta").Rows(0)("Nombre_Bodega")

            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("CuentaInventario")) Then
                Me.TxtCtaInventario.Text = DataSetDetalle.Tables("Consulta").Rows(0)("CuentaInventario")
            End If
            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("CuentaIngresoAjustes")) Then
                Me.TxtIngresoAjuste.Text = DataSetDetalle.Tables("Consulta").Rows(0)("CuentaIngresoAjustes")
            End If
            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("CuentaGastosAjustes")) Then
                Me.TxtGastoAjuste.Text = DataSetDetalle.Tables("Consulta").Rows(0)("CuentaGastosAjustes")
            End If
            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("CuentaVentas")) Then
                Me.TxtCuentaVenta.Text = DataSetDetalle.Tables("Consulta").Rows(0)("CuentaVentas")
            End If
            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("CuentaCostos")) Then
                Me.TxtCtaCosto.Text = DataSetDetalle.Tables("Consulta").Rows(0)("CuentaCostos")
            End If

            If Not IsDBNull(DataSetDetalle.Tables("Consulta").Rows(0)("Cod_TipoPrecio")) Then
                Me.CboCodigoCliente.Text = DataSetDetalle.Tables("Consulta").Rows(0)("Cod_TipoPrecio")
            End If

            SQlString = "SELECT  DetalleBodegas.Cod_Productos, Productos.Descripcion_Producto FROM DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)

            DataAdapter.Fill(DataSetDetalle, "DetalleBodegas")
            Me.BindingBodega.DataSource = DataSetDetalle.Tables("DetalleBodegas")
            Me.TrueDBGridConsultas.DataSource = Me.BindingBodega
            Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200

            '//////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////

            'SQlString = "SELECT * FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodigoBodega & "')"
            SQlString = "SELECT SUM(DetalleBodegas.Existencia) AS Existencia, DetalleBodegas.Cod_Bodegas AS Cod_Bodega, MAX(DetalleBodegas.Cod_Productos) AS Cod_Productos, AVG(Productos.Costo_Promedio) AS Costo_Promedio, AVG(Productos.Costo_Promedio_Dolar) AS Costo_Promedio_Dolar " & _
                        "FROM DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos GROUP BY DetalleBodegas.Cod_Bodegas " & _
                        "HAVING (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSetDetalle, "Bodegas")

            Existencia = 0
            IposicionFila = 0

            If DataSetDetalle.Tables("Bodegas").Rows.Count <> 0 Then

                If Not IsDBNull(DataSetDetalle.Tables("Bodegas").Rows(0)("Existencia")) Then
                    Existencia = DataSetDetalle.Tables("Bodegas").Rows(0)("Existencia")
                End If
                CostoPromedio = DataSetDetalle.Tables("Bodegas").Rows(0)("Costo_Promedio")
                CostoPromedioDolar = DataSetDetalle.Tables("Bodegas").Rows(0)("Costo_Promedio_Dolar")

                Me.TxtExistencia.Text = Format(Existencia, "##,##0.00")
                Me.TxtCostoPromedio.Text = Format(CostoPromedio, "##,##0.00")
                Me.TxtCostoPromedioDolar.Text = Format(CostoPromedioDolar, "##,##0.00")
                Me.TxtExistenciaValores.Text = Format(Existencia * CostoPromedio, "##,##0.00")
                Me.TxtExistenciaValoresDolar.Text = Format(Existencia * CostoPromedioDolar, "##,##0.00")


            End If

        Else
            Me.TxtNombre.Text = ""
            Me.TxtCtaInventario.Text = ""
            Me.TxtIngresoAjuste.Text = ""
            Me.TxtGastoAjuste.Text = ""
            Me.TxtCuentaVenta.Text = ""
            Me.TxtCtaCosto.Text = ""

            SQlString = "SELECT  DetalleBodegas.Cod_Productos, Productos.Descripcion_Producto FROM DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)

            DataAdapter.Fill(DataSetDetalle, "DetalleBodegas")
            Me.BindingBodega.DataSource = DataSetDetalle.Tables("DetalleBodegas")
            Me.TrueDBGridConsultas.DataSource = Me.BindingBodega
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String, iPosicionFila As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        If Me.CboCodigoBodega.Text = "" Then
            MsgBox("Debe Seleccionar una Bodega", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoBodega = Me.CboCodigoBodega.Text



        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "MultiBodega")


        If DataSet.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar un Producto, es necesario que exista la Bodega", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DataSet.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DataSet.Tables("MultiBodega").Reset()
        End If


        If Me.Opt1.Checked = True Then
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL CODIGO DE UN PRODUCTO//////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Quien = "CodigoProducto"
            My.Forms.FrmConsultas.ShowDialog()
            CodigoProducto = My.Forms.FrmConsultas.Codigo

            SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Detalles")
            If Not DataSet.Tables("Detalles").Rows.Count = 0 Then
                '///////////SI EXISTE EL  LO ACTUALIZO////////////////
                MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")

            Else
                MiConexion.Close()
                If CodigoProducto <> "" Then
                    '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                    StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                                   "VALUES('" & CodigoBodega & "','" & CodigoProducto & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

            End If

        Else
            MiConexion.Close()
            MiConexion.Open()
            SQL = "SELECT *  FROM Productos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            MiConexion.Close()
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                iPosicionFila = 0
                Me.ProgressBar.Visible = True
                Me.LblProducto.Visible = True
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Visible = True
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Maximum = DataSet.Tables("ListaProductos").Rows.Count
                Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                    My.Application.DoEvents()

                    CodigoProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                    Me.LblProducto.Text = "Procesando: " & CodigoProducto

                    SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                    DataAdapter.Fill(DataSet, "Detalles")
                    If Not DataSet.Tables("Detalles").Rows.Count = 0 Then
                        '///////////SI EXISTE EL  LO ACTUALIZO////////////////
                        'MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")

                    Else
                        MiConexion.Close()
                        If CodigoProducto <> "" Then
                            '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                                           "VALUES('" & CodigoBodega & "','" & CodigoProducto & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                        End If

                    End If

                    DataSet.Tables("Detalles").Clear()
                    iPosicionFila = iPosicionFila + 1
                    Me.ProgressBar.Value = iPosicionFila
                Loop


            End If
        End If

        Me.ProgressBar.Visible = False
        Me.LblProducto.Visible = False
        ActualizaBodegas()
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim CodigoBodega As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSetDetalle As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        CodigoBodega = Me.CboCodigoBodega.Text
        DataSetDetalle.Reset()
        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSetDetalle, "Consulta")


        If Not DataSetDetalle.Tables("Consulta").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = "UPDATE [Bodegas]  SET [Nombre_Bodega] = '" & Me.TxtNombre.Text & "',[CuentaInventario]='" & Me.TxtCtaInventario.Text & "',[CuentaIngresoAjustes]='" & Me.TxtIngresoAjuste.Text & "',[CuentaGastosAjustes]='" & Me.TxtGastoAjuste.Text & "',[CuentaVentas]='" & Me.TxtCuentaVenta.Text & "',[CuentaCostos]='" & Me.TxtCtaCosto.Text & "',[Cod_TipoPrecio]='" & Me.CboCodigoCliente.Text & "' WHERE (Cod_Bodega = '" & CodigoBodega & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Bodegas] ([Cod_Bodega],[Nombre_Bodega],[CuentaInventario],[CuentaIngresoAjustes],[CuentaGastosAjustes],[CuentaVentas],[CuentaCostos],[Cod_TipoPrecio]) " & _
                           "VALUES('" & CodigoBodega & "','" & Me.TxtNombre.Text & "','" & Me.TxtCtaInventario.Text & "','" & Me.TxtIngresoAjuste.Text & "','" & Me.TxtGastoAjuste.Text & "','" & Me.TxtCuentaVenta.Text & "','" & Me.TxtCtaCosto.Text & "','" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If
        Me.CboCodigoBodega.Text = ""
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim CodigoBodega As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSetDetalle As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Bodega?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If


        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSetDetalle, "Detalles")
        If Not DataSetDetalle.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MsgBox("Existe Productos para esta Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If


        CodigoBodega = Me.CboCodigoBodega.Text
        DataSetDetalle.Reset()
        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSetDetalle, "Consulta")


        If Not DataSetDetalle.Tables("Consulta").Rows.Count = 0 Then
            '///////////SI EXISTE LO BORRO////////////////
            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [Bodegas]  WHERE (Cod_Bodega = '" & CodigoBodega & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el producto de la bodega?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        If Me.CboCodigoBodega.Text = "" Then
            MsgBox("Debe Seleccionar una Bodega", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoBodega = Me.CboCodigoBodega.Text

        'If DataSet.Tables("MultBodega").Rows.Count <> 0 Then
        '    DataSet.Tables("MultiBodega").Reset()
        'End If

        SQL = "SELECT *  FROM Bodegas WHERE (Cod_Bodega = '" & CodigoBodega & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "MultiBodega")


        If DataSet.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar un Producto, es necesario que exista la Bodega", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DataSet.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DataSet.Tables("MultiBodega").Reset()
        End If


        CodigoProducto = Me.TrueDBGridConsultas.Columns(0).Text

        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Detalles")
        If Not DataSet.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MiConexion.Close()
            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [DetalleBodegas] WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


        Else

            MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
        End If

        ActualizaBodegas()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaInventario"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaInventario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaIngresoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtIngresoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CuentaGastoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtGastoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "CuentaCosto"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Quien = "CuentaVentas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentaVenta.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrecios.Click
        Quien = "CodigoTipoPrecio"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class