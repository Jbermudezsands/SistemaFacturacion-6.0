Public Class FrmListaOrdenCompra
    Public Nuevo As Boolean = False
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlString = "SELECT  DISTINCT Compras.Numero_Compra, Compras.Fecha_Compra, Compras.MonedaCompra, Compras.Nombre_Proveedor, Detalle_Solicitud.Numero_Solicitud, Compras.Estatus, Compras.FechaHora FROM Compras LEFT OUTER JOIN Detalle_Solicitud ON Compras.Numero_Compra = Detalle_Solicitud.Orden_Compra  " &
                    "WHERE (Compras.Tipo_Compra = 'Orden de Compra') AND (Compras.Cancelado = 0) ORDER BY Compras.Estatus DESC, Compras.Fecha_Compra DESC, Compras.Numero_Compra"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lista")
        Me.TDGridSolicitud.DataSource = DataSet.Tables("Lista")

        Me.TDGridSolicitud.Columns("Numero_Compra").Caption = "Num Orden"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Compra").Width = 70
        Me.TDGridSolicitud.Columns("Fecha_Compra").Caption = "Fecha Orden"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Fecha_Compra").Width = 80
        Me.TDGridSolicitud.Columns("MonedaCompra").Caption = "Moneda"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("MonedaCompra").Width = 70
        Me.TDGridSolicitud.Columns("Nombre_Proveedor").Caption = "Proveedor"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Nombre_Proveedor").Width = 300
        Me.TDGridSolicitud.Columns("Numero_Solicitud").Caption = "Num Solicitud"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Solicitud").Width = 80
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Estatus").Width = 80
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("FechaHora").Visible = False

        MiConexion.Close()
    End Sub

    Private Sub FrmListaOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Forms.FrmCompras.CboTipoProducto.Enabled = True
        My.Forms.FrmCompras.GroupBox1.Enabled = True
        My.Forms.FrmCompras.GroupBox5.Enabled = True
        My.Forms.FrmCompras.TrueDBGridComponentes.Enabled = True

        Me.BtnActualizar_Click(sender, e)
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmCompras.CboTipoProducto.Text = "Orden de Compra"
        My.Forms.FrmCompras.CboTipoProducto.Enabled = False
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim Fecha_Compra As Date, Fecha_Hora As Date, NumeroCompra As String


        NumeroCompra = Me.TDGridSolicitud.Columns("Numero_Compra").Text
        Fecha_Compra = Me.TDGridSolicitud.Columns("Fecha_Compra").Text
        Fecha_Hora = Me.TDGridSolicitud.Columns("FechaHora").Text

        My.Forms.FrmCompras.Fecha_Compra = Fecha_Compra
        My.Forms.FrmCompras.FechaHoraCompra = Fecha_Hora
        My.Forms.FrmCompras.NumeroCompra = NumeroCompra

        My.Forms.FrmCompras.EsSolicitud = True
        '//////////////////////////////////////////CARGO LA ORDEN DE COMPRA EN EL MODULO DE COMPRAS //////////////
        'My.Forms.FrmCompras.CboTipoProducto.Enabled = False
        'My.Forms.FrmCompras.GroupBox1.Enabled = False
        'My.Forms.FrmCompras.GroupBox5.Enabled = False

        My.Forms.FrmCompras.TrueDBGridComponentes.Enabled = False
        'My.Forms.FrmCompras.CargarCompra(Fecha_Compra, Fecha_Hora, NumeroCompra, "Orden de Compra")
        My.Forms.FrmCompras.ShowDialog()
        My.Forms.FrmCompras.EsSolicitud = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Compra?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        Numero = Me.TDGridSolicitud.Columns("Numero_Compra").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha_Compra").Text), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0, [Estatus]= 'Anulado' " & _
                     "WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Dim Idetalle As Double = 0, CodigoProducto As String = "", DiferenciaCantidad As Double = 0
        SQlProductos = "SELECT * FROM Detalle_Compras WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        MiConexion.Close()
        IposicionFila = 0
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            Do While IposicionFila < (DataSet.Tables("Detalle").Rows.Count)

                Idetalle = DataSet.Tables("Detalle").Rows(IposicionFila)("id_Detalle_Compra")
                CodigoProducto = DataSet.Tables("Detalle").Rows(IposicionFila)("Cod_Producto")
                DiferenciaCantidad = DataSet.Tables("Detalle").Rows(IposicionFila)("Cantidad") * -1

                'ExistenciasCostos(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                'CostoBodega(CodigoProducto, DiferenciaCantidad, 0, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text, Me.DTPFecha.Value)


                SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " & _
                             "WHERE  (Numero_Compra = '" & Numero & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Orden de Compra') AND (id_Detalle_Compra = " & Idetalle & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
                '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////

                'ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, Me.CboCodigoBodega.Text)

                '////////////////////////////////////////////ACTUALIZO LA EXISTENCIA DE LA BODEGA////////////////////////////////////////////////////////
                'SqlCompras = "UPDATE [DetalleBodegas] SET [Existencia] = " & ExistenciaBodega & " " & _
                '            "WHERE (Cod_Bodegas = '" & Me.CboCodigoBodega.Text & "') AND (Cod_Productos = '" & CodigoProducto & "') "
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

                IposicionFila = IposicionFila + 1
            Loop
        End If

        Bitacora(Now, NombreUsuario, "Orden de Compra", "Eliminar la Orden Compra: " & Numero)


    End Sub
End Class