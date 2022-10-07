Public Class FrmEnsamble
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodComponente As Double, CodReciboEnsamble As Double = 0, RendimientoGral As Double = 0
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmEnsamble_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ensamble")
    End Sub

    Private Sub FrmEnsamble_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQLString As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")


        SQLString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
    End Sub

    Private Sub CmdAgregarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregarProducto.Click

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String


        CodComponente = 0
        Quien = "CodigoProductosEnsamble"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigo.Text = My.Forms.FrmConsultas.Codigo
        Me.TxtDescripcion.Text = My.Forms.FrmConsultas.Descripcion
        CodComponente = My.Forms.FrmConsultas.CodComponente
        Me.TxtCantidad.Text = 1
        Me.TxtRendimiento.Text = 1


        SqlString = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & My.Forms.FrmConsultas.Codigo & "') "
        MiConexion.Close()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            Me.LblUnidadMedida.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Rendimiento")) Then
                Me.TxtRendimiento.Text = DataSet.Tables("Producto").Rows(0)("Rendimiento")
                RendimientoGral = DataSet.Tables("Producto").Rows(0)("Rendimiento")
            End If
        End If


        '//////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////BUSCO LOS COMPONENTES DEL PRODUCTO/////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Componentes")
        Me.BindingComponentes.DataSource = DataSet.Tables("Componentes")
        Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Componente"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 250
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 68
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True

    End Sub

    Private Sub TxtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantidad.TextChanged
        Dim Cantidad As Double = 0, Rendimiento As Double = 0

        If Me.TxtCantidad.Text = "" Then
            Exit Sub
        ElseIf Not IsNumeric(Me.TxtCantidad.Text) Then
            MsgBox("Es necesario digitar la cantidad", MsgBoxStyle.Critical, "Sistema Contable")
            Exit Sub
        End If

        ActualizaComponenteEnsamble(CodComponente, CDbl(Me.TxtCantidad.Text))
        Cantidad = Me.TxtCantidad.Text
        If Me.TxtRendimiento.Text <> "" Then
            Rendimiento = Me.TxtRendimiento.Text
        Else
            Rendimiento = 0
        End If

        Me.TxtRendimiento.Text = Cantidad * RendimientoGral

    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim ConsecutivoEnsamble As Double, SQLEnsamble As String, CodProducto As String, Fecha As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SubTotal As Double = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim iPosicionFila As Double, Cantidad As Double, Requerido As Double, Desecho As Double, Sql As String

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Es necesario Seleccionar el Tipo de Ensamble", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtCodigo.Text = "" Then
            MsgBox("Es necesario Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtCantidad.Text = "" Then
            MsgBox("Es necesario digitar la Cantidad", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Ensamble Recibido"
                    ConsecutivoEnsamble = BuscaConsecutivo("Ensamble_Recibido")
                Case "Orden de Ensamble"
                    ConsecutivoEnsamble = BuscaConsecutivo("Orden_Ensamble")
                Case "Deshacer Ensamble"
                    ConsecutivoEnsamble = BuscaConsecutivo("Deshacer_Ensamble")
            End Select
        Else
            ConsecutivoEnsamble = Me.TxtNumeroEnsamble.Text
        End If

        Me.TxtNumeroEnsamble.Text = ConsecutivoEnsamble
        Cantidad = Me.TxtCantidad.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        SQLEnsamble = "SELECT Ensamble.*  FROM Ensamble  " & _
                      "WHERE (Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQLEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "Ensambles")
        If DataSet.Tables("Ensambles").Rows.Count = 0 Then
            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
            StrSqlUpdate = "INSERT INTO [Ensamble] ([Cod_ReciboEnsamble],[Fecha_Ensamble],[SubTotalEnsamble],[Cod_ProductoEnsamble],[Cantidad_Principal] ,[Tipo_Ensamble],[Cod_Contratista] ,[Cod_Componente],[Referencias],[CodBodega]) " & _
                           "VALUES(" & ConsecutivoEnsamble & ",'" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "'," & SubTotal & " , '" & Me.TxtCodigo.Text & "' ,'" & Me.TxtCantidad.Text & "' ,'" & Me.CboTipoProducto.Text & "',0,'" & CodComponente & "', '" & Me.TxtNumero.Text & "','" & Me.CboCodigoBodega.Text & "')"


            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
            StrSqlUpdate = "UPDATE [Ensamble] SET [SubTotalEnsamble] = " & SubTotal & " ,[Cantidad_Principal] = '" & Me.TxtCantidad.Text & "' ,[Cod_Componente] = '" & CodComponente & "',[CodBodega]= '" & Me.CboCodigoBodega.Text & "' " & _
                           "WHERE (Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If



        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////GRABO EL DETALLE DEL ENSAMBLE///////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLEnsamble = "SELECT  Cod_Componente, Cod_Producto, Descripcion_Producto, Requerido * " & Cantidad & " AS Requerido, Recuperable, Desecho * " & Cantidad & " AS Desecho  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "Componentes")
        iPosicionFila = 0
        Do While iPosicionFila < (DataSet.Tables("Componentes").Rows.Count)
            My.Application.DoEvents()

            Requerido = DataSet.Tables("Componentes").Rows(iPosicionFila)("Requerido")
            Desecho = DataSet.Tables("Componentes").Rows(iPosicionFila)("Desecho")
            CodProducto = DataSet.Tables("Componentes").Rows(iPosicionFila)("Cod_Producto")

            Sql = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
                  "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') AND (CodProducto = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleEnsamble")
            If DataSet.Tables("DetalleEnsamble").Rows.Count = 0 Then

                MiConexion.Close()
                '///////////SI NO EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "INSERT INTO [Detalle_Ensamble] ([Cod_ReciboEnsamble],[Fecha_Ensamble] ,[Tipo_Ensamble] ,[CodProducto] ,[Cantidad_Ensamble] ,[Valor_Ensamble] ,[Desecho] ,[Valor_Desecho]) " & _
                               "VALUES (" & ConsecutivoEnsamble & ",'" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "' ,'" & Me.CboTipoProducto.Text & "' ,'" & CodProducto & "' ," & Requerido & " ,0 ," & Desecho & " ,0) "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                MiConexion.Close()
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Detalle_Ensamble] SET [Cantidad_Ensamble] = " & Requerido & " ,[Valor_Ensamble] = 0 ,[Desecho] = " & Desecho & " ,[Valor_Desecho] = 0 " & _
                               "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') AND (CodProducto = '" & CodProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If

            iPosicionFila = iPosicionFila + 1
        Loop


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String, CodReciboEnsamble As Double, Fecha As String, TipoEnsamble As String

        Quien = "Ensambles"
        My.Forms.FrmConsultas.ShowDialog()

        Me.TxtCodigo.Text = FrmConsultas.CodProducto
        Me.TxtCantidad.Text = FrmConsultas.Cantidad
        Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo
        If FrmConsultas.Codigo <> "-----0-----" Then
            CodReciboEnsamble = FrmConsultas.Codigo

        End If
        Me.DTPFecha.Value = FrmConsultas.Fecha
        Fecha = Format(FrmConsultas.Fecha, "yyyy-MM-dd")
        CodComponente = FrmConsultas.CodComponente
        TipoEnsamble = FrmConsultas.TipoEnsamble

        Sql = "SELECT  *   FROM  Productos WHERE  (Cod_Productos = '" & Me.TxtCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            Me.TxtDescripcion.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
        End If

        Sql = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
              "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & CodReciboEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleEnsamble")
        Me.BindingComponentes.DataSource = DataSet.Tables("DetalleEnsamble")
        Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridComponentes.Columns(3).Caption = "Componente"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 250
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Columns(5).Caption = "Requerido"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 68
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False

    End Sub

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged
        If Quien <> "NUEVO" Then
            CodComponente = 0
            Me.TxtNumeroEnsamble.Text = "-----0-----"
            Me.TxtDescripcion.Text = ""
            Me.TxtCodigo.Text = ""
            Me.TxtCantidad.Text = 0
        End If

        If Me.CboTipoProducto.Text = "Deshacer Ensamble" Then
            'Me.CmdAgregarProducto.Visible = False
            'Me.TxtCantidad.Enabled = False
            Me.CmdOrden.Visible = False
            Me.CmdEnsambles.Visible = False
            Me.CmdDesahacer.Visible = True
        ElseIf Me.CboTipoProducto.Text = "Ensamble Recibido" Then
            Me.CmdAgregarProducto.Visible = True
            Me.CmdEnsambles.Visible = False
            Me.TxtCantidad.Enabled = True
            Me.CmdOrden.Visible = False
            Me.CmdEnsambles.Visible = True
            Me.CmdDesahacer.Visible = False
        ElseIf Me.CboTipoProducto.Text = "Orden de Ensamble" Then
            Me.CmdAgregarProducto.Visible = True
            Me.CmdEnsambles.Visible = False
            Me.TxtCantidad.Enabled = True
            Me.CmdOrden.Visible = True
            Me.CmdEnsambles.Visible = False
            Me.CmdDesahacer.Visible = False
        End If
    End Sub

    Private Sub CmdEnsambles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEnsambles.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TipoEnsamble As String
        Dim Sql As String, CodReciboEnsamble As Double, Fecha As String

        Quien = "Ensamble"
        My.Forms.FrmConsultas.ShowDialog()

        Me.TxtCodigo.Text = FrmConsultas.CodProducto
        Me.TxtCantidad.Text = FrmConsultas.Cantidad
        'Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo
        Me.TxtNumero.Text = FrmConsultas.Codigo

        If FrmConsultas.Codigo <> "-----0-----" Then
            CodReciboEnsamble = FrmConsultas.Codigo

        End If
        Me.DTPFecha.Value = FrmConsultas.Fecha
        Fecha = Format(FrmConsultas.Fecha, "yyyy-MM-dd")
        CodComponente = FrmConsultas.CodComponente
        TipoEnsamble = FrmConsultas.TipoEnsamble


        Sql = "SELECT  *   FROM  Productos WHERE  (Cod_Productos = '" & Me.TxtCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            Me.TxtDescripcion.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
        End If

        Sql = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
              "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & CodReciboEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & TipoEnsamble & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleEnsamble")
        Me.BindingComponentes.DataSource = DataSet.Tables("DetalleEnsamble")
        Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Visible = False
        Me.TrueDBGridComponentes.Columns(3).Caption = "Componente"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 250
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Columns(5).Caption = "Requerido"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 68
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 74
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Visible = False

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim ArepEnsamble As New ArpEnsamble, RutaLogo As String, SQLEnsamble As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim ConsecutivoEnsamble As Double, Fecha As String


        ButtonAgregar_Click(sender, e)
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ArepEnsamble.LblEncabezado1.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepEnsamble.LblDireccion1.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepEnsamble.LblDireccion2.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")

                If Dir(RutaLogo) <> "" Then
                    ArepEnsamble.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If

        End If

        ConsecutivoEnsamble = Me.TxtNumeroEnsamble.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////CARGO EL REPORTE///////////////////////////////////////////////////////////////////7
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLEnsamble = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
              "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') "

        SQL.ConnectionString = Conexion
        SQL.SQL = SQLEnsamble

        ArepEnsamble.Document.Name = "Reporte de Ensamble"
        ArepEnsamble.TxtTipoEnsamble.Text = Me.CboTipoProducto.Text
        ArepEnsamble.TxtFecha.Text = Me.DTPFecha.Value
        ArepEnsamble.TxtNumero.Text = Me.TxtNumeroEnsamble.Text
        ArepEnsamble.TxtCodigo.Text = Me.TxtCodigo.Text
        ArepEnsamble.TxtDescripcion.Text = Me.TxtDescripcion.Text
        ArepEnsamble.TxtCantidad.Text = Me.TxtCantidad.Text
        ArepEnsamble.DataSource = SQL
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepEnsamble.Document
        ViewerForm.Show()
        ArepEnsamble.Run(False)
        'ArepEnsamble.Show()
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged


    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim ConsecutivoEnsamble As Double, Fecha As String, SQlEnsamble As String
        Dim DataAdapter = New SqlClient.SqlDataAdapter, DataSet As New DataSet, IposicionFila As Double = 0
        Dim ConsecutivoCompra As Double, NumeroCompra As String, SqlString As String, CodCliente As String, CodProveedor As String, NombreProveedor As String
        Dim CodProductos As String, PrecioCompra As Double, Importe As Double, Cantidad As Double
        Dim ConsecutivoFactura As Double, NumeroFactura As String = "", NombreProductos As String, TPrecioUnitario As Double = 0
        Dim TipoServicio As String, TImporte As Double = 0, TasaCompra As Double, SqlCompras As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Registros As Double = 0, Existencia As Double, CodigoProyecto As String
        Dim CantidadReal As Double = 0



        ButtonAgregar_Click(sender, e)
        ConsecutivoEnsamble = Me.TxtNumeroEnsamble.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
        SqlString = "SELECT  * FROM Clientes WHERE(InventarioFisico = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultasCliente")
        If DataSet.Tables("ConsultasCliente").Rows.Count <> 0 Then
            CodCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Cod_Cliente")
            NombreCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Nombre_Cliente")
        Else
            MsgBox("Seleccione una Cuenta cliente para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If


        '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
        SqlString = "SELECT  * FROM Proveedor  WHERE(InventarioFisico = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultasProveedor")
        If DataSet.Tables("ConsultasProveedor").Rows.Count <> 0 Then
            CodProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Cod_Proveedor")
            NombreProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Nombre_Proveedor")
        Else
            MsgBox("Seleccione una Cuenta Proveedor para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////VERIFICO LOS PRODUCTOS ANTES DE AGREGARLOS///////////////////////////////////////////////////////////////////7
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlEnsamble = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
              "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') "

        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        IposicionFila = 0
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Do While IposicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                CodProductos = DataSet.Tables("ListaProductos").Rows(IposicionFila)("CodProducto")

                '//////////////////////////////BUSCO SI EL PRODUCTO ES SERVICIO PARA BUSCAR EL COSTO //////////////////////////////////////////////////////

                SQlEnsamble = "SELECT  * FROM Productos WHERE (Tipo_Producto = 'Servicio') AND (Activo = Activo) AND (Cod_Productos = '" & CodProductos & "')"
                MiConexion.Open()
                DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
                DataAdapter.Fill(DataSet, "Servicio")
                MiConexion.Close()
                If DataSet.Tables("Servicio").Rows.Count = 0 Then
                    StringMoneda = ""
                    'PrecioCompra = UltimoPrecioCompra(CodProductos) * TasaCambioCompara(Fecha, StringMoneda, "Cordobas")
                    Cantidad = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Cantidad_Ensamble")
                    PrecioCompra = CostoPromedioKardex(CodProductos, Fecha)
                    '///////////SI EL COSTO ES CERO PERO SE DESCARGAR, SIGNIFICA FACTURACION EN NEGATIVO ///////////
                    If Cantidad <> 0 Then
                        If PrecioCompra = 0 Then
                            SqlString = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Costo_Unitario / TasaCambio.MontoTasa AS Costo_UnitarioDolar FROM Detalle_Facturas INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                        "WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Detalle_Facturas.Costo_Unitario <> 0) AND (Detalle_Facturas.Fecha_Factura <= CONVERT(DATETIME,'" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Facturas.Fecha_Factura"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                            DataAdapter.Fill(DataSet, "UltimoCosto")
                            If DataSet.Tables("UltimoCosto").Rows.Count <> 0 Then
                                Registros = DataSet.Tables("UltimoCosto").Rows.Count
                                PrecioCompra = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_Unitario")
                            End If
                            DataSet.Tables("UltimoCosto").Reset()

                        End If
                    End If


                    If PrecioCompra <= 0 Then
                        MsgBox("No Existe Costo para el Producto" & CodProductos, MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                    Existencia = BuscaExistenciaBodega(CodProductos, Me.CboCodigoBodega.Text)

                    If Cantidad > Existencia Then
                        MsgBox("No Existe inventario para este ensamble" & CodProductos, MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If



                End If

                IposicionFila = IposicionFila + 1
            Loop
        End If




        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////CARGO LOS PRODUCTOS///////////////////////////////////////////////////////////////////7
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlEnsamble = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
              "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') "

        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            IposicionFila = 0
            TPrecioUnitario = 0
            TImporte = 0
            Do While IposicionFila < (DataSet.Tables("ListaProductos").Rows.Count)

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL ENCABEZADO DE LA SALIDA DE BODEGA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                If IposicionFila = 0 Then
                    ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
                    NumeroFactura = Format(ConsecutivoFactura, "0000#")
                    GrabaEncabezadoFacturas(NumeroFactura, Fecha, "Salida Bodega", CodCliente, Me.CboCodigoBodega.Text, NombreCliente, NombreCliente, Fecha, Val(0), 0, Val(0), Val(0), "Cordobas", "Procesado por Ensamble " & ConsecutivoEnsamble)
                    SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False' " & _
                                 "WHERE  (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Salida Bodega')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()


                End If

                CodProductos = DataSet.Tables("ListaProductos").Rows(IposicionFila)("CodProducto")

                '//////////////////////////////BUSCO SI EL PRODUCTO ES SERVICIO PARA BUSCAR EL COSTO //////////////////////////////////////////////////////

                SQlEnsamble = "SELECT  * FROM Productos WHERE (Tipo_Producto = 'Servicio') AND (Activo = Activo) AND (Cod_Productos = '" & CodProductos & "')"
                MiConexion.Open()
                DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
                DataAdapter.Fill(DataSet, "Servicio")
                MiConexion.Close()
                If DataSet.Tables("Servicio").Rows.Count = 0 Then
                    StringMoneda = ""
                    'PrecioCompra = UltimoPrecioCompra(CodProductos) * TasaCambioCompara(Fecha, StringMoneda, "Cordobas")
                    Cantidad = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Cantidad_Ensamble")
                    PrecioCompra = CostoPromedioKardex(CodProductos, Fecha)
                    '///////////SI EL COSTO ES CERO PERO SE DESCARGAR, SIGNIFICA FACTURACION EN NEGATIVO ///////////
                    If Cantidad <> 0 Then
                        If PrecioCompra = 0 Then
                            SqlString = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Costo_Unitario / TasaCambio.MontoTasa AS Costo_UnitarioDolar FROM Detalle_Facturas INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                        "WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Detalle_Facturas.Costo_Unitario <> 0) AND (Detalle_Facturas.Fecha_Factura <= CONVERT(DATETIME,'" & Format(Fecha, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Facturas.Fecha_Factura"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                            DataAdapter.Fill(DataSet, "UltimoCosto")
                            If DataSet.Tables("UltimoCosto").Rows.Count <> 0 Then
                                Registros = DataSet.Tables("UltimoCosto").Rows.Count
                                PrecioCompra = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_Unitario")
                            End If
                            DataSet.Tables("UltimoCosto").Reset()

                        End If
                    End If

                    TPrecioUnitario = TPrecioUnitario + PrecioCompra
                    Importe = Cantidad * PrecioCompra
                    TImporte = TImporte + Importe


                Else
                    TipoServicio = DataSet.Tables("Servicio").Rows(0)("Unidad_Medida")
                    Select Case TipoServicio
                        Case "ImporteFijo"
                            Cantidad = 1
                            PrecioCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                            TPrecioUnitario = TPrecioUnitario + PrecioCompra
                            Importe = Cantidad * PrecioCompra
                            TImporte = TImporte + Importe
                        Case "Unidades/Fracciones"
                            Cantidad = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Cantidad_Ensamble")
                            PrecioCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                            TPrecioUnitario = TPrecioUnitario + PrecioCompra
                            Importe = Cantidad * PrecioCompra
                            TImporte = TImporte + Importe
                        Case "SubTotal"
                            Cantidad = 1
                            TasaCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                            PrecioCompra = TImporte * (TasaCompra / 100)
                            TPrecioUnitario = TPrecioUnitario + PrecioCompra
                            Importe = Cantidad * PrecioCompra
                            TImporte = TImporte + Importe

                    End Select




                End If

                'PrecioVenta = UltimoPrecioVenta(CodProductos)

                NombreProductos = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Descripcion_Producto")
                GrabaDetalleFacturaSalida(NumeroFactura, CodProductos, NombreProductos, PrecioCompra, 0, PrecioCompra, Importe, Cantidad, "Cordobas", Fecha, "Salida Bodega", PrecioCompra)
                ActualizaExistencia(CodProductos)

                IposicionFila = IposicionFila + 1
            Loop
        End If

        ActulizacionFacturaEnsamble(NumeroFactura, "Salida Bodega", Fecha, True)


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////TOTAL SALIDA DE BODEGA ///////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT SUM(Cantidad) AS Expr1, SUM(Costo_Unitario) AS Precio_Unitario, SUM(Precio_Unitario) AS Precio_Unitario, SUM(Cantidad * Costo_Unitario) AS Importe  FROM Detalle_Facturas " & _
                    "WHERE (Tipo_Factura = 'Salida Bodega') AND (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102))"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Total")
        MiConexion.Close()
        If Not DataSet.Tables("Total").Rows.Count = 0 Then
            TImporte = DataSet.Tables("Total").Rows(0)("Importe")
        End If
        DataSet.Tables("Total").Reset()

        IposicionFila = 0
        NumeroCompra = 0
        CodProductos = Me.TxtCodigo.Text
        Cantidad = Me.TxtCantidad.Text
        PrecioCompra = TImporte / Cantidad
        Importe = Cantidad * PrecioCompra

        CodigoProyecto = ""
        'If Not Me.CboProyecto.Text = "" Then
        '    CodigoProyecto = Me.CboProyecto.Columns(0).Text
        'End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////GENERO LA COMPRA PARA ENTRADA DE INVENTARIO //////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If IposicionFila = 0 Then
            ConsecutivoCompra = BuscaConsecutivo("Compra")
            NumeroCompra = Format(ConsecutivoCompra, "0000#")
            GrabaEncabezadoCompras(NumeroCompra, Fecha, "Mercancia Recibida", CodProveedor, Me.CboCodigoBodega.Text, NombreCliente, NombreCliente, Fecha, Val(0), 0, Val(0), Val(0), "Cordobas", "Procesado por Ensamble " & ConsecutivoEnsamble, CodigoProyecto, False)
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False' " & _
                         "WHERE  (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Mercancia Recibida')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        '------------------AJUSTO LA ENTRADA BASADO EN LO ESTIMADO ----------------------
        If Me.TxtRendimiento.Text <> 0 Then
            CantidadReal = RendimientoGral
            Cantidad = Cantidad * CantidadReal
            PrecioCompra = PrecioCompra / Cantidad

        End If


        GrabaDetalleCompraLiquidacion(NumeroCompra, CodProductos, PrecioCompra, 0, PrecioCompra, Importe, Cantidad, "Cordobas", Fecha, "0000", "01/01/1900")
        ActualizaExistencia(CodProductos)
        ActulizacionCompraEnsamble(NumeroCompra, "Mercancia Recibida", Fecha, True)

        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [Ensamble] SET [Activo]= 0 " & _
                       "WHERE (Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        LimpiaEnsamble()
        MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Zeus Facturacion")

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, SqlEnsamble As String, IposicionFila = 0

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Esamble?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SqlEnsamble = "SELECT Ensamble.*  FROM Ensamble  WHERE (Cod_ReciboEnsamble = " & Me.TxtNumeroEnsamble.Text & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Me.DTPFecha.Value & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            MiConexion.Close()
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////BORRO EL DETALLE ENSAMBLE//////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            StrSqlUpdate = "DELETE FROM [Detalle_Ensamble] WHERE (Cod_ReciboEnsamble = " & Me.TxtNumeroEnsamble.Text & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Me.DTPFecha.Value & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            StrSqlUpdate = "DELETE FROM [Ensamble] WHERE (Cod_ReciboEnsamble = " & Me.TxtNumeroEnsamble.Text & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Me.DTPFecha.Value & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Ensamble", "Borro el ensamble: " & Me.TxtNumeroEnsamble.Text)

        LimpiaEnsamble()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaEnsamble()
    End Sub

    Private Sub CmdOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOrden.Click
        Dim DataAdapter = New SqlClient.SqlDataAdapter, DataSet As New DataSet, IposicionFila As Double = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////INACTIVO LA ORDEN DE ENSAMBLE///////////////////////////////////////////////
        StrSqlUpdate = "UPDATE [Ensamble] SET [Activo]= 0 " & _
                       "WHERE (Cod_ReciboEnsamble = " & Me.TxtNumeroEnsamble.Text & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Me.DTPFecha.Value & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Quien = "NUEVO"
        Me.CboTipoProducto.Text = "Ensamble Recibido"
        Quien = ""
        ButtonAgregar_Click(sender, e)





    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged

    End Sub

    Private Sub CmdDesahacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDesahacer.Click
        Dim ConsecutivoEnsamble As Double, Fecha As String, SQlEnsamble As String
        Dim DataAdapter = New SqlClient.SqlDataAdapter, DataSet As New DataSet, IposicionFila As Double = 0
        Dim ConsecutivoCompra As Double, NumeroCompra As String = "", SqlString As String, CodCliente As String, CodProveedor As String, NombreProveedor As String
        Dim CodProductos As String, PrecioCompra As Double, Importe As Double, Cantidad As Double
        Dim ConsecutivoFactura As Double, NumeroFactura As String = "", NombreProductos As String, TPrecioUnitario As Double = 0
        Dim TipoServicio As String, TImporte As Double = 0, TasaCompra As Double, CodigoProyecto As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Registros As Double




        ButtonAgregar_Click(sender, e)
        ConsecutivoEnsamble = Me.TxtNumeroEnsamble.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
            SqlString = "SELECT  * FROM Clientes WHERE(InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultasCliente")
            If DataSet.Tables("ConsultasCliente").Rows.Count <> 0 Then
                CodCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Cod_Cliente")
                NombreCliente = DataSet.Tables("ConsultasCliente").Rows(0)("Nombre_Cliente")
            Else
                MsgBox("Seleccione una Cuenta cliente para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            '////////////////////BUSCO EL CLIENTE PARA INVENTARIO //////////////////////////////////////
            SqlString = "SELECT  * FROM Proveedor  WHERE(InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultasProveedor")
            If DataSet.Tables("ConsultasProveedor").Rows.Count <> 0 Then
                CodProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Cod_Proveedor")
                NombreProveedor = DataSet.Tables("ConsultasProveedor").Rows(0)("Nombre_Proveedor")
            Else
                MsgBox("Seleccione una Cuenta Proveedor para Ajustes de Inventario", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If



        CodigoProyecto = ""
        'If Not Me.CboProyecto.Text = "" Then
        '    CodigoProyecto = Me.CboProyecto.Columns(0).Text
        'End If




            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////CARGO LOS PRODUCTOS///////////////////////////////////////////////////////////////////7
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlEnsamble = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
                  "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') "

            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()

            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                IposicionFila = 0
                TPrecioUnitario = 0
            TImporte = 0

                Do While IposicionFila < (DataSet.Tables("ListaProductos").Rows.Count)

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////GENERO LA COMPRA PARA ENTRADA DE INVENTARIO //////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    If IposicionFila = 0 Then
                        ConsecutivoCompra = BuscaConsecutivo("Compra")
                        NumeroCompra = Format(ConsecutivoCompra, "0000#")
                    GrabaEncabezadoCompras(NumeroCompra, Fecha, "Mercancia Recibida", CodProveedor, Me.CboCodigoBodega.Text, NombreCliente, NombreCliente, Fecha, Val(0), 0, Val(0), Val(0), "Cordobas", "Procesado por DesEnsamble " & ConsecutivoEnsamble, CodigoProyecto, False)
                    End If

                    CodProductos = DataSet.Tables("ListaProductos").Rows(IposicionFila)("CodProducto")

                    '//////////////////////////////BUSCO SI EL PRODUCTO ES SERVICIO PARA BUSCAR EL COSTO //////////////////////////////////////////////////////
                    SQlEnsamble = "SELECT  * FROM Productos WHERE (Tipo_Producto = 'Servicio') AND (Activo = Activo) AND (Cod_Productos = '" & CodProductos & "')"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlEnsamble, MiConexion)
                    DataAdapter.Fill(DataSet, "Servicio")
                    MiConexion.Close()
                    If DataSet.Tables("Servicio").Rows.Count = 0 Then
                    'PrecioCompra = UltimoPrecioCompra(CodProductos)

                    Cantidad = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Cantidad_Ensamble")
                    PrecioCompra = CostoPromedioKardex(CodProductos, Fecha)
                    TPrecioUnitario = TPrecioUnitario + PrecioCompra
                    '///////////SI EL COSTO ES CERO PERO SE DESCARGAR, SIGNIFICA FACTURACION EN NEGATIVO ///////////
                    If Cantidad <> 0 Then
                        If PrecioCompra = 0 Then
                            SqlString = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Costo_Unitario / TasaCambio.MontoTasa AS Costo_UnitarioDolar FROM Detalle_Facturas INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                        "WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Detalle_Facturas.Costo_Unitario <> 0) AND (Detalle_Facturas.Fecha_Factura <= CONVERT(DATETIME,'" & Format(Fecha, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Facturas.Fecha_Factura"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                            DataAdapter.Fill(DataSet, "UltimoCosto")
                            If DataSet.Tables("UltimoCosto").Rows.Count <> 0 Then
                                Registros = DataSet.Tables("UltimoCosto").Rows.Count
                                PrecioCompra = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_Unitario")
                            End If
                            DataSet.Tables("UltimoCosto").Reset()

                        End If
                    End If

                        Importe = Cantidad * PrecioCompra
                        TImporte = TImporte + Importe
                    Else
                        TipoServicio = DataSet.Tables("Servicio").Rows(0)("Unidad_Medida")
                        Select Case TipoServicio
                            Case "ImporteFijo"
                                Cantidad = 1
                                PrecioCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                                TPrecioUnitario = TPrecioUnitario + PrecioCompra
                                Importe = Cantidad * PrecioCompra
                                TImporte = TImporte + Importe
                            Case "Unidades/Fracciones"
                                Cantidad = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Cantidad_Ensamble")
                                PrecioCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                                TPrecioUnitario = TPrecioUnitario + PrecioCompra
                                Importe = Cantidad * PrecioCompra
                                TImporte = TImporte + Importe
                            Case "SubTotal"
                                Cantidad = 1
                                TasaCompra = DataSet.Tables("Servicio").Rows(0)("Precio_Venta")
                                PrecioCompra = TImporte * (TasaCompra / 100)
                                TPrecioUnitario = TPrecioUnitario + PrecioCompra
                                Importe = Cantidad * PrecioCompra
                                TImporte = TImporte + Importe

                        End Select




                    End If

                    'PrecioVenta = UltimoPrecioVenta(CodProductos)

                GrabaDetalleCompraLiquidacion(NumeroCompra, CodProductos, PrecioCompra, 0, PrecioCompra, Importe, Cantidad, "Cordobas", Fecha, "0000", "01/01/1900")
                    ActualizaExistencia(CodProductos)


                    IposicionFila = IposicionFila + 1
                Loop
            End If

        ActulizacionCompra(NumeroCompra, "Mercancia Recibida", Fecha, True)



        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////TOTAL SALIDA DE BODEGA ///////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  SUM(Cantidad) AS Cantidad, SUM(Precio_Unitario) AS Precio_Unitario, SUM(Cantidad * Precio_Unitario) AS Importe FROM Detalle_Compras WHERE (Numero_Compra = '" & NumeroCompra & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = 'Mercancia Recibida')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Total")
        MiConexion.Close()
        If Not DataSet.Tables("Total").Rows.Count = 0 Then
            TImporte = DataSet.Tables("Total").Rows(0)("Importe")
        End If
        DataSet.Tables("Total").Reset()



            IposicionFila = 0
            NumeroCompra = 0
            CodProductos = Me.TxtCodigo.Text
            Cantidad = Me.TxtCantidad.Text
            PrecioCompra = TImporte / Cantidad
            Importe = Cantidad * PrecioCompra

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA SALIDA DE BODEGA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If IposicionFila = 0 Then
                ConsecutivoFactura = BuscaConsecutivo("SalidaBodega")
                NumeroFactura = Format(ConsecutivoFactura, "0000#")
                GrabaEncabezadoFacturas(NumeroFactura, Fecha, "Salida Bodega", CodCliente, Me.CboCodigoBodega.Text, NombreCliente, NombreCliente, Fecha, Val(0), 0, Val(0), Val(0), "Cordobas", "Procesado por DesEnsamble " & ConsecutivoEnsamble)
            End If

            NombreProductos = DataSet.Tables("ListaProductos").Rows(IposicionFila)("Descripcion_Producto")
        GrabaDetalleFacturaSalida(NumeroFactura, CodProductos, NombreProductos, PrecioCompra, 0, PrecioCompra, Importe, Cantidad, "Cordobas", Fecha, "Salida Bodega", PrecioCompra)
            ActualizaExistencia(CodProductos)
            ActulizacionFactura(NumeroFactura, "Salida Bodega", Fecha, True)

            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
            StrSqlUpdate = "UPDATE [Ensamble] SET [Activo]= 0 " & _
                           "WHERE (Cod_ReciboEnsamble = " & ConsecutivoEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            LimpiaEnsamble()
            MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Zeus Facturacion")
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim ConsecutivoEnsamble As Double, SQLEnsamble As String, CodProducto As String, Fecha As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SubTotal As Double = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim iPosicionFila As Double, Cantidad As Double, Requerido As Double, Desecho As Double, Sql As String
        Dim NumeroEnsamble As String = ""

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Es necesario Seleccionar el Tipo de Ensamble", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtCodigo.Text = "" Then
            MsgBox("Es necesario Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtCantidad.Text = "" Then
            MsgBox("Es necesario digitar la Cantidad", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Ensamble Recibido"
                    ConsecutivoEnsamble = BuscaConsecutivo("Ensamble_Recibido")
                Case "Orden de Ensamble"
                    ConsecutivoEnsamble = BuscaConsecutivo("Orden_Ensamble")
                Case "Deshacer Ensamble"
                    ConsecutivoEnsamble = BuscaConsecutivo("Deshacer_Ensamble")
            End Select

            NumeroEnsamble = Format(ConsecutivoEnsamble, "0000#")
        Else
            NumeroEnsamble = Me.TxtNumeroEnsamble.Text
        End If

        Me.TxtNumeroEnsamble.Text = NumeroEnsamble
        Cantidad = Me.TxtCantidad.Text
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        SQLEnsamble = "SELECT Ensamble.*  FROM Ensamble  " & _
                      "WHERE (Cod_ReciboEnsamble = " & NumeroEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

        DataAdapter = New SqlClient.SqlDataAdapter(SQLEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "Ensambles")
        If DataSet.Tables("Ensambles").Rows.Count = 0 Then
            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
            StrSqlUpdate = "INSERT INTO [Ensamble] ([Cod_ReciboEnsamble],[Fecha_Ensamble],[SubTotalEnsamble],[Cod_ProductoEnsamble],[Cantidad_Principal] ,[Tipo_Ensamble],[Cod_Contratista] ,[Cod_Componente],[Referencias],[CodBodega],[Rendimiento]) " & _
                           "VALUES(" & NumeroEnsamble & ",'" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "'," & SubTotal & " , '" & Me.TxtCodigo.Text & "' ,'" & Me.TxtCantidad.Text & "' ,'" & Me.CboTipoProducto.Text & "',0,'" & CodComponente & "','" & Me.TxtNumero.Text & "','" & Me.CboCodigoBodega.Text & "'," & Me.TxtRendimiento.Text & ")"


            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////SI NO EXISTE EL ENSAMBLE LO AGREGO///////////////////////////////////////////////
            StrSqlUpdate = "UPDATE [Ensamble] SET [SubTotalEnsamble] = " & SubTotal & " ,[Cantidad_Principal] = '" & Me.TxtCantidad.Text & "' ,[Cod_Componente] = '" & CodComponente & "',[CodBodega]= '" & Me.CboCodigoBodega.Text & "',[Rendimiento]= " & Me.TxtRendimiento.Text & " " & _
                           "WHERE (Cod_ReciboEnsamble = " & NumeroEnsamble & ") AND (Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "')"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If



        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////GRABO EL DETALLE DEL ENSAMBLE///////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLEnsamble = "SELECT  Cod_Componente, Cod_Producto, Descripcion_Producto, Requerido * " & Cantidad & " AS Requerido, Recuperable, Desecho * " & Cantidad & " AS Desecho  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLEnsamble, MiConexion)
        DataAdapter.Fill(DataSet, "Componentes")
        iPosicionFila = 0
        Do While iPosicionFila < (DataSet.Tables("Componentes").Rows.Count)
            My.Application.DoEvents()

            Requerido = DataSet.Tables("Componentes").Rows(iPosicionFila)("Requerido")
            Desecho = DataSet.Tables("Componentes").Rows(iPosicionFila)("Desecho")
            CodProducto = DataSet.Tables("Componentes").Rows(iPosicionFila)("Cod_Producto")

            Sql = "SELECT  Detalle_Ensamble.Cod_ReciboEnsamble, Detalle_Ensamble.Fecha_Ensamble, Detalle_Ensamble.Tipo_Ensamble, Detalle_Ensamble.CodProducto,Productos.Descripcion_Producto, Detalle_Ensamble.Cantidad_Ensamble, Detalle_Ensamble.Valor_Ensamble, Detalle_Ensamble.Desecho, Detalle_Ensamble.Valor_Desecho FROM  Detalle_Ensamble INNER JOIN Productos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos  " & _
                  "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & NumeroEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') AND (CodProducto = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleEnsamble")
            If DataSet.Tables("DetalleEnsamble").Rows.Count = 0 Then

                MiConexion.Close()
                '///////////SI NO EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "INSERT INTO [Detalle_Ensamble] ([Cod_ReciboEnsamble],[Fecha_Ensamble] ,[Tipo_Ensamble] ,[CodProducto] ,[Cantidad_Ensamble] ,[Valor_Ensamble] ,[Desecho] ,[Valor_Desecho]) " & _
                               "VALUES (" & NumeroEnsamble & ",'" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "' ,'" & Me.CboTipoProducto.Text & "' ,'" & CodProducto & "' ," & Requerido & " ,0 ," & Desecho & " ,0) "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                MiConexion.Close()
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Detalle_Ensamble] SET [Cantidad_Ensamble] = " & Requerido & " ,[Valor_Ensamble] = 0 ,[Desecho] = " & Desecho & " ,[Valor_Desecho] = 0 " & _
                               "WHERE (Detalle_Ensamble.Cod_ReciboEnsamble = " & NumeroEnsamble & ") AND (Detalle_Ensamble.Fecha_Ensamble = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Ensamble.Tipo_Ensamble = '" & Me.CboTipoProducto.Text & "') AND (CodProducto = '" & CodProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If

            iPosicionFila = iPosicionFila + 1
        Loop

        'LimpiaEnsamble()

    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Dim Posicion As Double
        If Me.BindingComponentes.Count <> 0 Then
            My.Forms.FrmSeries.Tipo = Me.CboTipoProducto.Text
            Posicion = Me.BindingComponentes.Position
            My.Forms.FrmSeries.CodigoProducto = Me.BindingComponentes.Item(Posicion)("Cod_Producto")
            My.Forms.FrmSeries.NombreProducto = Me.BindingComponentes.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.Numero = Me.TxtNumeroEnsamble.Text
            My.Forms.FrmSeries.Fecha = Me.DTPFecha.Value
            My.Forms.FrmSeries.Text = Me.BindingComponentes.Item(Posicion)("Cod_Producto") + " " + Me.BindingComponentes.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.ShowDialog()
        End If
    End Sub
End Class