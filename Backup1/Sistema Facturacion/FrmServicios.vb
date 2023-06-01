Public Class FrmServicios

    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public MiConexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)
    Private Sub OptImporteFijo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptImporteFijo.CheckedChanged
        If Me.OptImporteFijo.Checked = True Then
            Me.LblDescripcion.Text = "Importe Fijo C$"
            Me.LblDescripcion2.Text = "Importe Fijo $"
            Me.LblDescripcion2.Visible = True
            Me.TxtPrecioDolar.Visible = True
        End If
    End Sub

    Private Sub OptUnidades_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptUnidades.CheckedChanged
        If Me.OptUnidades.Checked = True Then
            Me.LblDescripcion.Text = "Precio Unitario C$"
            Me.LblDescripcion2.Text = "Precio Unitario $"
            Me.LblDescripcion2.Visible = True
            Me.TxtPrecioDolar.Visible = True
        End If
    End Sub

    Private Sub OptSubTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSubTotal.CheckedChanged
        If Me.OptSubTotal.Checked = True Then
            Me.LblDescripcion.Text = "Porciento"
            Me.LblDescripcion2.Visible = False
            Me.TxtPrecioDolar.Visible = False
        End If
    End Sub

    Private Sub OptServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptServicio.CheckedChanged
        If Me.OptServicio.Checked = True Then
            Me.ChkGrabado.Visible = False
        End If
    End Sub

    Private Sub OptDescuento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptDescuento.CheckedChanged
        If Me.OptDescuento.Checked = True Then
            Me.ChkGrabado.Visible = True
        End If
    End Sub

    Private Sub FrmServicios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Servicios")
    End Sub

    Private Sub FrmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String, sql As String
        Dim SqlImpuestos As String = "SELECT * FROM Impuestos"
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE  (Tipo_Producto = 'Servicio') OR (Tipo_Producto = N'Descuento')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If

        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlImpuestos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Impuestos")
        Me.CboIva.DataSource = DataSet.Tables("Impuestos")
        Me.CboIva.DisplayMember = "Descripcion_Iva"

        Sql = "SELECT  * FROM  Rubro"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Rubros")
        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
            Me.CboRubro.DataSource = DataSet.Tables("Rubros")
        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim SQLProductos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim TipoProducto As String, UnidadMedida As String = "Unidades/Fracciones", CodProducto As String = ""
        Dim Iposicion As Double, Codbodega As String
        Try


            If Me.CboCodigoProducto.Text = "" Then
                MsgBox("Se necesita el Codigo del Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub
            End If


            If Me.OptServicio.Checked = True Then
                TipoProducto = "Servicio"

            Else
                TipoProducto = "Descuento"

            End If

            If Me.OptImporteFijo.Checked = True Then
                UnidadMedida = "ImporteFijo"

            ElseIf Me.OptUnidades.Checked = True Then
                UnidadMedida = "Unidades/Fracciones"
            ElseIf Me.OptSubTotal.Checked = True Then
                UnidadMedida = "SubTotal"
            End If

            If Me.TxtPrecioDolar.Text = "" Then
                Me.TxtPrecioDolar.Text = 0
            End If

            If Me.TxtPrecioCordobas.Text = "" Then
                Me.TxtPrecioCordobas.Text = 0
            End If

            If Me.OptServicio.Checked = True Then
                CodProducto = Me.CboCodigoProducto.Text
                'If Mid(Me.CboCodigoProducto.Text, 1, 4) <> "SERV" Then
                '    CodProducto = "SERV" & Me.CboCodigoProducto.Text
                'Else
                '    CodProducto = Me.CboCodigoProducto.Text
                'End If
            ElseIf Me.OptDescuento.Checked = True Then
                If Mid(Me.CboCodigoProducto.Text, 1, 4) <> "DESC" Then
                    CodProducto = "DESC" & Me.CboCodigoProducto.Text
                Else
                    CodProducto = Me.CboCodigoProducto.Text
                End If
            End If


            SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodProducto & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedores")
            If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Productos] SET [Descripcion_Producto] = '" & Me.TxtNombreProducto.Text & "',[Ubicacion] = 'Servicio',[Tipo_Producto] = '" & TipoProducto & "',[Cod_Cuenta_Costo] = '" & Me.TxtCtaCosto.Text & "',[Cod_Cuenta_Ventas] = '" & Me.TxtCuentaVenta.Text & "',[Unidad_Medida] = '" & UnidadMedida & "',[Precio_Venta] = '" & Me.TxtPrecioCordobas.Text & "',[Precio_Lista] = '" & Me.TxtPrecioDolar.Text & "',[Existencia_Negativa] = 'SI',[Cod_Iva] = '" & Me.CboIva.Text & "' ,[Activo] = '" & Me.CboActivo.Text & "' ,[Minimo] = '0' ,[Reorden] = '0',[Nota] = 'Nota:',[Cod_Cuenta_GastoAjuste]= '" & Me.TxtCtaCosto.Text & "',[Cod_Cuenta_IngresoAjuste]= '" & Me.TxtCuentaVenta.Text & "',[CodComponente]= '0',[Cod_Rubro]= '" & Me.CboRubro.Text & "'  WHERE (Cod_Productos = '" & CodProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                MiConexion.Close()
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Tipo_Producto],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro]) " & _
                               "VALUES('" & CodProducto & "','" & Me.TxtNombreProducto.Text & "','Servicio','" & TipoProducto & "' ,'" & Me.TxtCtaCosto.Text & "','" & Me.TxtCuentaVenta.Text & "','" & UnidadMedida & "','" & Me.TxtPrecioCordobas.Text & "','" & Me.TxtPrecioDolar.Text & "','0','SI','" & Me.CboIva.Text & "','" & Me.CboActivo.Text & "','0' ,'0','Nota:','" & Me.TxtCtaCosto.Text & "','" & Me.TxtCuentaVenta.Text & "','0','" & Me.CboRubro.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////BUSCO LAS BODEGAS//////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Iposicion = 0
            SQLProductos = "SELECT  *  FROM Bodegas "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            Do While Iposicion < DataSet.Tables("Bodegas").Rows.Count
                CodBodega = DataSet.Tables("Bodegas").Rows(Iposicion)("Cod_Bodega")

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////BUSCO SI EXISTE EN LAS BODEGAS DETALLES///////////////////////////////////////////////////////
                '(//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQLProductos = "SELECT  * FROM DetalleBodegas WHERE (Cod_Productos = '" & CodProducto & "') AND (Cod_Bodegas = '" & Codbodega & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleBodegas")
                If DataSet.Tables("DetalleBodegas").Rows.Count = 0 Then
                    MiConexion.Open()
                    StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                                   "VALUES('" & Codbodega & "','" & CodProducto & "') "
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If
                DataSet.Tables("DetalleBodegas").Reset()
                Iposicion = Iposicion + 1
            Loop

                Me.CboCodigoProducto.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCosto"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaVentas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentaVenta.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtPrecioCordobas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioCordobas.TextChanged
        Dim TasaCambio As Double

        TasaCambio = BuscaTasaCambio(Format(Now, "dd/MM/yyyy"))

        Me.TxtPrecioDolar.Text = Format(CDbl(Val(Me.TxtPrecioCordobas.Text)) / TasaCambio, "####0.00")
    End Sub

    Private Sub CboCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.TextChanged
        Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim CodImpuesto As String, SqlImpuesto As String


        If Me.CboCodigoProducto.Text = "" Then

            Me.TxtNombreProducto.Text = ""
            Me.TxtCtaCosto.Text = ""
            Me.CboIva.Text = ""
            Me.CboActivo.Text = ""
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text

        SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then


            Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
            If DataSet.Tables("Producto").Rows(0)("Tipo_Producto") = "Servicio" Then
                Me.OptServicio.Checked = True
            Else
                Me.OptDescuento.Checked = True
            End If



            If DataSet.Tables("Producto").Rows(0)("Unidad_Medida") = "Unidades/Fracciones" Then
                Me.OptUnidades.Checked = True
            ElseIf DataSet.Tables("Producto").Rows(0)("Unidad_Medida") = "ImporteFijo" Then
                Me.OptImporteFijo.Checked = True
            ElseIf DataSet.Tables("Producto").Rows(0)("Unidad_Medida") = "SubTotal" Then
                Me.OptSubTotal.Checked = True
            End If


            Me.TxtPrecioDolar.Text = DataSet.Tables("Producto").Rows(0)("Precio_Lista")


            Me.TxtCtaCosto.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Costo")
            Me.TxtPrecioCordobas.Text = DataSet.Tables("Producto").Rows(0)("Precio_Venta")

            '////////BUSCO EL IMPUESTO DEL PRODUCTO///////////////////////
            CodImpuesto = DataSet.Tables("Producto").Rows(0)("Cod_Iva")
            SqlImpuesto = "SELECT * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuesto, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto")
            If Not DataSet.Tables("Impuesto").Rows.Count = 0 Then
                Me.CboIva.Text = DataSet.Tables("Impuesto").Rows(0)("Descripcion_Iva")
            End If

            Me.CboActivo.Text = DataSet.Tables("Producto").Rows(0)("Activo")

            Me.TxtCuentaVenta.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Ventas")


            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Rubro")) Then
                Me.CboRubro.Text = DataSet.Tables("Producto").Rows(0)("Cod_Rubro")
            End If

            MiConexion.Close()
        Else
            Me.TxtCtaCosto.Text = ""
            Me.CboIva.Text = ""
            Me.CboActivo.Text = ""
            Me.TxtCuentaVenta.Text = ""

        End If

        MiConexion.Close()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Try

            Resultado = MsgBox("¿Esta Seguro de Eliminar el Producto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If

            SQLProveedor = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedores")
            If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

                StrSqlUpdate = "DELETE FROM [Productos] WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If

            SQLProveedor = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE  (Tipo_Producto = 'Servicio') OR (Tipo_Producto = N'Descuento')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
            End If

            ActualizaComboProducto()
            Me.CboCodigoProducto.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoServicios"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProducto.Text = My.Forms.FrmConsultas.Codigo
        Me.TxtNombreProducto.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub TxtPrecioDolar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioDolar.TextChanged
        Dim TasaCambio As Double

        TasaCambio = BuscaTasaCambio(Format(Now, "dd/MM/yyyy"))

        Me.TxtPrecioCordobas.Text = Format(CDbl(Val(Me.TxtPrecioDolar.Text)) * TasaCambio, "####0.00")
    End Sub
End Class