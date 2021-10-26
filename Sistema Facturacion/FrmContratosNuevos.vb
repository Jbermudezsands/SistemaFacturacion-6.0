
Imports System.Data.SqlClient

Public Class FrmContratosNuevos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NumeroContrato As Double, Nuevo As Boolean, CodigoProducto As String, Agregar As Boolean = False, idDetalleContrato As Double = 0
    Public dsContrato1 As New DataSet, daContrato1 As New SqlClient.SqlDataAdapter, CmdBuilder1 As New SqlCommandBuilder
    Public dsContrato2 As New DataSet, daContrato2 As New SqlClient.SqlDataAdapter, CmdBuilder2 As New SqlCommandBuilder
    Public dsDetalleContrato As New DataSet, daDetalleContrato As New SqlClient.SqlDataAdapter, CmdBuilderDetalle As New SqlCommandBuilder
    Public Sub GuardarDetalleContrato(ByVal idDetalleContrato As Double, ByVal Numero_Contrato As Double, ByVal IdContrato As Double, ByVal Tipo_Servicios As String, ByVal Frecuencia As Double, ByVal Inicio_Contrato As Date, ByVal Fin_Contrato As Date, ByVal Precio_Unitario As Double, ByVal Moneda As String, ByVal Activo As Boolean, ByVal Anulado As Boolean, ByVal Retencion1 As Boolean, ByVal Retencion2 As Boolean, ByVal Referencia As String, ByVal DiasFactura As Double, ByVal CodBodega As String, ByVal Contrato_Variable As Boolean, ByVal Direccion As String)
        Dim SQLClientes As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Dataset As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQLClientes = "SELECT Detalle_Contratos.*  FROM Detalle_Contratos WHERE (IdDetalleContrato = " & idDetalleContrato & ") AND (Numero_Contrato = " & NumeroContrato & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(Dataset, "Clientes")
        If Not Dataset.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Detalle_Contratos] SET [Numero_Contrato] = " & NumeroContrato & " ,[IdContrato] = " & IdContrato & " ,[Tipo_Servicios] =  '" & Tipo_Servicios & "' ,[Frecuencia] = '" & Frecuencia & "' ,[Inicio_Contrato] = '" & Format(Inicio_Contrato, "dd/MM/yyyy") & "' ,[Fin_Contrato] =  '" & Format(Fin_Contrato, "dd/MM/yyyy") & "' ,[Precio_Unitario] = " & Precio_Unitario & " ,[Moneda] = '" & Moneda & "' ,[Activo] = '" & Activo & "' ,[Anulado] = '" & Anulado & "' ,[Retencion1] = '" & Retencion1 & "' ,[Retencion2] = '" & Retencion2 & "' ,[Referencia] = '" & Referencia & "' ,[DiasFactura] = " & DiasFactura & " ,[CodBodega] = '" & CodBodega & "' ,[Contrato_Variable] = '" & Contrato_Variable & "' ,[Direccion] = '" & Direccion & "' WHERE (IdDetalleContrato = " & idDetalleContrato & ") AND (Numero_Contrato = " & NumeroContrato & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Detalle_Contratos] ([Numero_Contrato],[IdContrato],[Tipo_Servicios],[Frecuencia],[Inicio_Contrato],[Fin_Contrato],[Precio_Unitario] ,[Moneda] ,[Activo],[Anulado] ,[Retencion1],[Retencion2],[Exonerado] ,[Referencia] ,[DiasFactura],[CodBodega],[Contrato_Variable],[Direccion]) " & _
                           "VALUES (" & NumeroContrato & " ," & IdContrato & " ,'" & Tipo_Servicios & "','" & Frecuencia & "' ,'" & Format(Inicio_Contrato, "dd/MM/yyyy") & "' , '" & Format(Fin_Contrato, "dd/MM/yyyy") & "', " & Precio_Unitario & " ,'" & Moneda & "' ,'" & Activo & "' ,'" & Anulado & "' ,'" & Retencion1 & "' ,'" & Retencion2 & "' ,0,'" & Referencia & "' ," & DiasFactura & " , '" & CodBodega & "' ,'" & Contrato_Variable & "' ,'" & Direccion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
    End Sub



    Public Sub InsertarRowGridContrato1()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridContrato1.Row
        CodigoProducto = Me.TrueDBGridContrato1.Columns(3).Text

        CmdBuilder1.RefreshSchema()
        oTabla = dsContrato1.Tables("DetalleContrato1").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daContrato1.Update(oTabla)
            dsContrato1.Tables("DetalleContrato1").AcceptChanges()
            daContrato1.Update(dsContrato1.Tables("DetalleContrato1"))

            Me.TrueDBGridContrato1.Row = iPosicion

        Else
            oTabla = dsContrato1.Tables("DetalleContrato1").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daContrato1.Update(oTabla)
                dsContrato1.Tables("DetalleContrato1").AcceptChanges()
                daContrato1.Update(dsContrato1.Tables("DetalleContrato1"))
            End If
        End If

        ActualizarGridInsertRowContrato1()

        Bitacora(Now, NombreUsuario, "Contratos", "Se agrego Producto: " & CodigoProducto & " Contrato No." & Me.LblNumeroContrato.Text)
    End Sub

    Public Sub ActualizarGridInsertRowContrato1()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Double



        SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato1.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TContrato")
        If Not DataSet.Tables("TContrato").Rows.Count = 0 Then
            IdTipoContrato = DataSet.Tables("TContrato").Rows(0)("idTipoContrato")
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdDetalleTipoContrato, IdTipoContrato, NumeroContrato, Cod_Productos, Descripcion_Producto, Cantidad FROM DetalleTipoCotrato WHERE (IdTipoContrato = " & IdTipoContrato & ") AND (NumeroContrato = " & NumeroContrato & ")"
        dsContrato1 = New DataSet
        daContrato1 = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder1 = New SqlCommandBuilder(daContrato1)
        daContrato1.Fill(dsContrato1, "DetalleContrato1")
        Me.TrueDBGridContrato1.DataSource = dsContrato1.Tables("DetalleContrato1")
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("IdDetalleTipoContrato").Visible = False
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("IdTipoContrato").Visible = False
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("NumeroContrato").Visible = False
        Me.TrueDBGridContrato1.Columns("Cod_Productos").Caption = "Codigo"
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 74
        Me.TrueDBGridContrato1.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridContrato1.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cantidad").Width = 64

    End Sub


    Public Sub InsertarRowGridContrato2()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridContrato2.Row
        CodigoProducto = Me.TrueDBGridContrato2.Columns(3).Text

        CmdBuilder2.RefreshSchema()
        oTabla = dsContrato2.Tables("DetalleContrato2").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daContrato2.Update(oTabla)
            dsContrato2.Tables("DetalleContrato2").AcceptChanges()
            daContrato2.Update(dsContrato2.Tables("DetalleContrato2"))

            Me.TrueDBGridContrato2.Row = iPosicion

        Else
            oTabla = dsContrato2.Tables("DetalleContrato2").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daContrato2.Update(oTabla)
                dsContrato2.Tables("DetalleContrato2").AcceptChanges()
                daContrato2.Update(dsContrato2.Tables("DetalleContrato2"))
            End If
        End If

        ActualizarGridInsertRowContrato2()

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Se agrego Producto: " & CodigoProducto & " Contrato No." & Me.LblNumeroContrato.Text)
    End Sub

    Public Sub ActualizarGridInsertRowContrato2()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Double



        SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato2.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TContrato")
        If Not DataSet.Tables("TContrato").Rows.Count = 0 Then
            IdTipoContrato = DataSet.Tables("TContrato").Rows(0)("idTipoContrato")
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdDetalleTipoContrato, IdTipoContrato, NumeroContrato, Cod_Productos, Descripcion_Producto, Cantidad FROM DetalleTipoCotrato WHERE (IdTipoContrato = " & IdTipoContrato & ") AND (NumeroContrato = " & NumeroContrato & ")"
        dsContrato2 = New DataSet
        daContrato2 = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder2 = New SqlCommandBuilder(daContrato2)
        daContrato2.Fill(dsContrato2, "DetalleContrato2")
        Me.TrueDBGridContrato2.DataSource = dsContrato2.Tables("DetalleContrato2")
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("IdDetalleTipoContrato").Visible = False
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("IdTipoContrato").Visible = False
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("NumeroContrato").Visible = False
        Me.TrueDBGridContrato2.Columns("Cod_Productos").Caption = "Codigo"
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 74
        Me.TrueDBGridContrato2.Columns("Descripcion_Producto").Caption = "Descripcion"
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
        Me.TrueDBGridContrato2.Columns("Cantidad").Caption = "Cantidad"
        Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cantidad").Width = 64

    End Sub

    Private Sub LimpiaContrato()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter




        Me.TxtCodigoClientes.Text = ""
        Me.CboReferencia.Text = ""
        Me.TxtContactoAdmon.Text = ""
        Me.TxtContactoOperativo.Text = ""
        Me.TxtObservaciones.Text = ""
        Me.ChkActivo.Checked = False
        Me.ChkExonerado.Checked = False

        Me.CmbContrato1.Text = ""
        Me.CmbContrato2.Text = ""
        Me.TxtFrecuencia.Text = ""
        Me.CmbFrecuencia2.Text = ""
        Me.CmbMoneda1.Text = ""
        Me.CmbMoneda2.Text = ""
        Me.DtpInicioContrato1.Text = Now
        Me.DtpFinContrato1.Value = Now
        Me.DtpInicioContrato2.Text = Now
        Me.DtpFinContrato2.Value = Now
        Me.TxtPrecioUnitario.Text = ""
        Me.TxtPrecioUnitario2.Text = ""

        Me.TxtDireccionCotrato2.Text = ""
        Me.TxtDireccionContrato.Text = ""








    End Sub

    Private Sub CargarContrato(ByVal NumeroContrato As String)
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato1 As Double, IdTipoContrato2 As Double, Cont As Double, i As Double = 0

        LimpiaContrato()


        SqlString = "SELECT Contratos.* FROM Contratos  WHERE(Numero_Contrato = " & NumeroContrato & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato")
        If Not DataSet.Tables("Contrato").Rows.Count = 0 Then


            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Cod_Cliente")) Then
                Me.TxtCodigoClientes.Text = DataSet.Tables("Contrato").Rows(0)("Cod_Cliente")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Frecuencia")) Then
                Me.CboReferencia.Text = DataSet.Tables("Contrato").Rows(0)("Frecuencia")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Contacto_Administrativo")) Then
                Me.TxtContactoAdmon.Text = DataSet.Tables("Contrato").Rows(0)("Contacto_Administrativo")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Contacto_Operativo")) Then
                Me.TxtContactoOperativo.Text = DataSet.Tables("Contrato").Rows(0)("Contacto_Operativo")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Observaciones")) Then
                Me.TxtObservaciones.Text = DataSet.Tables("Contrato").Rows(0)("Observaciones")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Frecuencia")) Then
                Me.CboReferencia.Text = DataSet.Tables("Contrato").Rows(0)("Frecuencia")
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////CONSULTO EL DETALLE DE LOS CONTRATOS /////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  TOP (2)  IdDetalleContrato, Numero_Contrato, IdContrato, Tipo_Servicios, Frecuencia, Inicio_Contrato, Fin_Contrato, Precio_Unitario, Moneda, Activo, Anulado, Retencion1, Retencion2, Exonerado, Referencia, DiasFactura, CodBodega, Contrato_Variable, Direccion FROM Detalle_Contratos WHERE (Numero_Contrato = " & NumeroContrato & ") "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleContrato")

            dsDetalleContrato = New DataSet
            daDetalleContrato = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilderDetalle = New SqlCommandBuilder(daDetalleContrato)
            daDetalleContrato.Fill(dsDetalleContrato, "DetalleContrato")
            Me.TDBGridTipoContrato.DataSource = dsContrato1.Tables("DetalleContrato")
            'Cont = DataSet.Tables("DetalleContrato").Rows.Count
            'Do While Cont > i

            '    If i = 1 Then
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Activo")) Then
            '            Me.ChkActivo.Checked = DataSet.Tables("DetalleContrato").Rows(i)("Activo")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Exonerado")) Then
            '            Me.ChkExonerado.Checked = DataSet.Tables("DetalleContrato").Rows(i)("Exonerado")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Tipo_Servicios1")) Then
            '            Me.CmbContrato1.Text = DataSet.Tables("DetalleContrato").Rows(i)("Tipo_Servicios1")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Frecuencia")) Then
            '            Me.CmbFrecuencia1.Text = DataSet.Tables("DetalleContrato").Rows(i)("Frecuencia")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Moneda")) Then
            '            Me.CmbMoneda1.Text = DataSet.Tables("DetalleContrato").Rows(i)("Moneda")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Inicio_Contrato")) Then
            '            Me.DtpInicioContrato1.Text = DataSet.Tables("DetalleContrato").Rows(i)("Inicio_Contrato")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Fin_Contrato")) Then
            '            Me.DtpFinContrato1.Value = DataSet.Tables("DetalleContrato").Rows(i)("Fin_Contrato")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Precio_Unitario")) Then
            '            Me.TxtPrecioUnitario1.Text = DataSet.Tables("DetalleContrato").Rows(i)("Precio_Unitario")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("DiasFactura1")) Then
            '            Me.TxtNumero1.Value = DataSet.Tables("DetalleContrato").Rows(i)("DiasFactura1")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("CodBodega1")) Then
            '            Me.CboCodigoBodega.Text = DataSet.Tables("DetalleContrato").Rows(i)("CodBodega1")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Contrato_Variable")) Then
            '            Me.ChkContratoVariable.Checked = DataSet.Tables("DetalleContrato").Rows(i)("Contrato_Variable")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Direccion")) Then
            '            Me.TxtDireccionContrato.Text = DataSet.Tables("DetalleContrato").Rows(i)("Direccion")
            '        End If

            '    ElseIf i = 2 Then

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Frecuencia2")) Then
            '            Me.CmbFrecuencia2.Text = DataSet.Tables("DetalleContrato").Rows(i)("Frecuencia2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Moneda2")) Then
            '            Me.CmbMoneda2.Text = DataSet.Tables("DetalleContrato").Rows(i)("Moneda2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Inicio_Contrato2")) Then
            '            Me.DtpInicioContrato2.Text = DataSet.Tables("DetalleContrato").Rows(i)("Inicio_Contrato2")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Fin_Contrato2")) Then
            '            Me.DtpFinContrato2.Value = DataSet.Tables("DetalleContrato").Rows(i)("Fin_Contrato2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Precio_Unitario2")) Then
            '            Me.TxtPrecioUnitario2.Text = DataSet.Tables("DetalleContrato").Rows(i)("Precio_Unitario2")
            '        End If
            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Activo2")) Then
            '            Me.ChkActivo2.Checked = DataSet.Tables("DetalleContrato").Rows(i)("Activo2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("DiasFactura2")) Then
            '            Me.TxtNumero2.Value = DataSet.Tables("DetalleContrato").Rows(i)("DiasFactura2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("CodBodega2")) Then
            '            Me.CboCodigoBodega2.Text = DataSet.Tables("DetalleContrato").Rows(i)("CodBodega2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Contrato_Variable2")) Then
            '            Me.ChkContratoVariable2.Checked = DataSet.Tables("DetalleContrato").Rows(i)("Contrato_Variable2")
            '        End If

            '        If Not IsDBNull(DataSet.Tables("DetalleContrato").Rows(i)("Direccion2")) Then
            '            Me.TxtDireccionCotrato2.Text = DataSet.Tables("DetalleContrato").Rows(i)("Direccion2")
            '        End If
            '    End If








            '    i = i + 1
            'Loop






            DataSet.Tables("DetalleContrato").Reset()




            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE CONTRATO1////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato1.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "TContrato1")
            If Not DataSet.Tables("TContrato1").Rows.Count = 0 Then
                IdTipoContrato1 = DataSet.Tables("TContrato1").Rows(0)("idTipoContrato")
            End If

            SqlString = "SELECT IdDetalleTipoContrato, IdTipoContrato, NumeroContrato, Cod_Productos, Descripcion_Producto, Cantidad FROM DetalleTipoCotrato WHERE (IdTipoContrato = " & IdTipoContrato1 & ") AND (NumeroContrato = " & NumeroContrato & ")"
            dsContrato1 = New DataSet
            daContrato1 = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder1 = New SqlCommandBuilder(daContrato1)
            daContrato1.Fill(dsContrato1, "DetalleContrato1")
            Me.TrueDBGridContrato1.DataSource = dsContrato1.Tables("DetalleContrato1")
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("IdDetalleTipoContrato").Visible = False
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("IdTipoContrato").Visible = False
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("NumeroContrato").Visible = False
            Me.TrueDBGridContrato1.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 74
            Me.TrueDBGridContrato1.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridContrato1.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridContrato1.Splits.Item(0).DisplayColumns("Cantidad").Width = 64

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE CONTRATO2////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato2.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "TContrato2")
            If Not DataSet.Tables("TContrato2").Rows.Count = 0 Then
                IdTipoContrato2 = DataSet.Tables("TContrato2").Rows(0)("idTipoContrato")
            End If

            SqlString = "SELECT IdDetalleTipoContrato, IdTipoContrato, NumeroContrato, Cod_Productos, Descripcion_Producto, Cantidad FROM DetalleTipoCotrato WHERE (IdTipoContrato = " & IdTipoContrato2 & ") AND (NumeroContrato = " & NumeroContrato & ")"
            dsContrato2 = New DataSet
            daContrato2 = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder2 = New SqlCommandBuilder(daContrato2)
            daContrato2.Fill(dsContrato2, "DetalleContrato2")
            Me.TrueDBGridContrato2.DataSource = dsContrato2.Tables("DetalleContrato2")
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("IdDetalleTipoContrato").Visible = False
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("IdTipoContrato").Visible = False
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("NumeroContrato").Visible = False
            Me.TrueDBGridContrato2.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 74
            Me.TrueDBGridContrato2.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridContrato2.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridContrato2.Splits.Item(0).DisplayColumns("Cantidad").Width = 64



        End If



    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged

        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DiasCredito As Double = 0, CausaIva As Boolean, SQlString As String


        Try



            SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then


                Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")



                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CausaIva")) Then
                    CausaIva = DataSet.Tables("Clientes").Rows(0)("CausaIva")
                End If

                If CausaIva = True Then
                    Me.ChkExonerado.Checked = False
                Else
                    Me.ChkExonerado.Checked = True
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("DiasCredito")) Then
                    DiasCredito = DataSet.Tables("Clientes").Rows(0)("DiasCredito")
                End If


                SQlString = "SELECT  Contratos.Numero_Contrato, Detalle_Contratos.Tipo_Servicios, Detalle_Contratos.Frecuencia, Detalle_Contratos.Inicio_Contrato, Detalle_Contratos.Fin_Contrato, Detalle_Contratos.IdDetalleContrato FROM Contratos INNER JOIN Detalle_Contratos ON Contratos.Numero_Contrato = Detalle_Contratos.Numero_Contrato  " & _
                            "WHERE  (Contratos.Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleContratos")
                Me.TDBGridTipoContrato.DataSource = DataSet.Tables("DetalleContratos")





            Else

                Me.TxtNombres.Text = ""
                Me.TxtApellidos.Text = ""
                Me.TxtDireccion.Text = ""
                Me.TxtTelefono.Text = ""

            End If



        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub FrmContratosNuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DiasCredito As Double = 0, CausaIva As Boolean, i As Double = 0, Cont As Double
        Dim SqlString As String = ""

        Try

            SqlProveedor = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "TipoContrato")
            Cont = DataSet.Tables("TipoContrato").Rows.Count
            i = 0
            Do While Cont > i
                Me.CmbContrato1.Items.Add(DataSet.Tables("TipoContrato").Rows(i)("TipoContrato"))
                Me.CmbContrato2.Items.Add(DataSet.Tables("TipoContrato").Rows(i)("TipoContrato"))
                i = i + 1
            Loop

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM   Bodegas"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
            If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
                Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            End If
            Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"


            SqlString = "SELECT  * FROM   Bodegas"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas2")
            Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas2")
            If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
                Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
            End If
            Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
            MiConexion.Close()

            'If Cont > 0 Then
            '    Me.CmbContrato1.Text = DataSet.Tables("TipoContrato").Rows(0)("TipoContrato")
            '    Me.CmbContrato2.Text = DataSet.Tables("TipoContrato").Rows(0)("TipoContrato")
            'End If

            If Nuevo = False Then
                CargarContrato(NumeroContrato)
            End If


        Catch ex As Exception
            MsgBox(Err.Description)
        End Try




    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQLClientes As String, Exonerado As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim IdContrato1 As Double, IdContrato2 As Double
        Dim ConsecutivoCompra As Double, NumeroCompra As String, ContratoActivo As Double, ContratoActivo2 As Double
        Dim ContratoVariable As Double, ContratoVariable2 As Double


        If Me.ChkExonerado.Checked = True Then
            Exonerado = 1
        Else
            Exonerado = 0
        End If

        If Me.ChkActivo.Checked = True Then
            ContratoActivo = 1
        Else
            ContratoActivo = 0
        End If

        If Me.ChkActivo2.Checked = True Then
            ContratoActivo2 = 1
        Else
            ContratoActivo2 = 0
        End If

        If Me.ChkContratoVariable.Checked = True Then
            ContratoVariable = 1
        Else
            ContratoVariable = 0
        End If

        If Me.ChkContratoVariable2.Checked = True Then
            ContratoVariable2 = 1
        Else
            ContratoVariable2 = 0
        End If


        If Me.CmbContrato1.Text = "" Then
            MsgBox("Es necesario seleccionar el tipo de contrato", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtPrecioUnitario.Text = "" Then
            MsgBox("Es necesario Seleccionar el precio unitario", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If


        If Me.TxtPrecioUnitario.Text = "" Then
            Me.TxtPrecioUnitario.Text = "0.00"
        End If

        If Me.TxtPrecioUnitario2.Text = "" Then
            Me.TxtPrecioUnitario2.Text = "0.00"
        End If

        If Nuevo = True Then
            '///////////////////////////////////////BUSCO SI TIENE NUMERO DE CONTRATO /////////////////
            SQLClientes = "SELECT  Contratos.* FROM Contratos WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "BuscoContrato")
            If Not DataSet.Tables("BuscoContrato").Rows.Count = 0 Then
                NumeroContrato = DataSet.Tables("BuscoContrato").Rows(0)("Numero_Contrato")
            Else
                ConsecutivoCompra = BuscaConsecutivo("Numero_Contrato")
                NumeroContrato = Format(ConsecutivoCompra, "0000#")
            End If

            Me.LblNumeroContrato.Text = Format(NumeroContrato, "0000#")

        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato1.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato")
        If Not DataSet.Tables("Contrato").Rows.Count = 0 Then
            IdContrato1 = DataSet.Tables("Contrato").Rows(0)("idTipoContrato")
        End If

        SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato2.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato2")
        If Not DataSet.Tables("Contrato2").Rows.Count = 0 Then
            IdContrato2 = DataSet.Tables("Contrato2").Rows(0)("idTipoContrato")
        End If

        If IdContrato2 = 0 Then
            IdContrato2 = IdContrato1
        End If

        If IdContrato1 = 0 Then
            If IdContrato2 = 0 Then
                MsgBox("Es Necesario Seleccionar un Tipo de Contrato", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If
        End If




        SQLClientes = "SELECT Contratos.* FROM Contratos WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Contratos]    SET [Cod_Cliente] = '" & Me.TxtCodigoClientes.Text & "',[Tipo_Servicios1] = '" & Me.CmbContrato1.Text & "' ,[Tipo_Servicios2] = '" & Me.CmbContrato2.Text & "' ,[Frecuencia] = '" & Me.TxtFrecuencia.Text & "' ,[Inicio_Contrato] = '" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato] = '" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' ,[Contacto_Administrativo] =  '" & Me.TxtContactoAdmon.Text & "' ,[Contacto_Operativo] =  '" & Me.TxtContactoOperativo.Text & "' ,[Precio_Unitario] = " & Me.TxtPrecioUnitario.Text & " ,[Moneda] = '" & Me.CmbMoneda1.Text & "' ,[Activo] = " & ContratoActivo & " ,[Activo2] = " & ContratoActivo2 & "  ,[Exonerado] = " & Exonerado & " ,[Referencia] =  '" & Me.CboReferencia.Text & "'  ,[Observaciones] =  '" & Me.TxtObservaciones.Text & "' ,[Precio_Unitario2] =  '" & Me.TxtPrecioUnitario.Text & "' ,[Inicio_Contrato2] = '" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato2] = '" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,[Moneda2] = '" & Me.CmbMoneda1.Text & "' ,[Frecuencia2] = '" & Me.CmbFrecuencia2.Text & "' ,[IdContrato1] = " & IdContrato1 & " ,[IdContrato2] = " & IdContrato2 & ",[DiasFactura1] = " & Me.TxtNumero1.Value & " ,[DiasFactura2] = " & Me.TxtNumero2.Value & ",[CodBodega1] = '" & Me.CboCodigoBodega.Text & "',[CodBodega2] = '" & Me.CboCodigoBodega2.Text & "' ,[Contrato_Variable] = '" & ContratoVariable & "' ,[Contrato_Variable2] = '" & ContratoVariable2 & "', [Direccion] = '" & Me.TxtDireccionContrato.Text & "' ,[Direccion2] = '" & Me.TxtDireccionCotrato2.Text & "'    WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Contratos] ([Cod_Cliente],[Tipo_Servicios1],[Tipo_Servicios2],[Frecuencia],[Inicio_Contrato],[Fin_Contrato] ,[Contacto_Administrativo] ,[Contacto_Operativo],[Precio_Unitario] ,[Moneda],[Activo],[Activo2],[Anulado],[Retencion1],[Retencion2],[Exonerado],[Referencia],[Observaciones],[Precio_Unitario2],[Inicio_Contrato2],[Fin_Contrato2] ,[Moneda2] ,[Frecuencia2] ,[IdContrato1],[IdContrato2],[DiasFactura1],[DiasFactura2],[CodBodega1],[CodBodega2],[Contrato_Variable],[Contrato_Variable2]) " & _
                           "VALUES ('" & Me.TxtCodigoClientes.Text & "','" & Me.CmbContrato1.Text & "' ,'" & Me.CmbContrato2.Text & "' ,'" & Me.TxtFrecuencia.Text & "' ,'" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' , '" & Me.TxtContactoAdmon.Text & "' , '" & Me.TxtContactoOperativo.Text & "' , " & Me.TxtPrecioUnitario.Text & " , '" & Me.CmbMoneda1.Text & "' ," & ContratoActivo & "," & ContratoActivo2 & ",0,0,0, " & Exonerado & ", '" & Me.CboReferencia.Text & "' ,'" & Me.TxtObservaciones.Text & "' , " & Me.TxtPrecioUnitario2.Text & " ,'" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,'" & Me.CmbMoneda1.Text & "' ,'" & Me.CmbFrecuencia2.Text & "'  , " & IdContrato1 & " ," & IdContrato2 & ", " & Me.TxtNumero1.Value & " ," & Me.TxtNumero2.Value & ",'" & Me.CboCodigoBodega.Text & "','" & Me.CboCodigoBodega2.Text & "','" & ContratoVariable & "','" & ContratoVariable2 & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        'LimpiaContrato()


        Bitacora(Now, NombreUsuario, "Clientes", "Grabo contrato nuevo: ")
    End Sub

    Private Sub TrueDBGridContrato1_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridContrato1.AfterUpdate

        Me.InsertarRowGridContrato1()
    End Sub

    Private Sub TrueDBGridContrato1_BeforeClose(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridContrato1.BeforeClose

    End Sub

    Private Sub TrueDBGridContrato1_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridContrato1.BeforeColEdit
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Double

        SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato1.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TContrato")
        If Not DataSet.Tables("TContrato").Rows.Count = 0 Then
            IdTipoContrato = DataSet.Tables("TContrato").Rows(0)("idTipoContrato")
        End If

        Me.TrueDBGridContrato1.Columns("IdTipoContrato").Text = IdTipoContrato
        Me.TrueDBGridContrato1.Columns("NumeroContrato").Text = NumeroContrato



    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridContrato1.ButtonClick

        Quien = "CodigoProductosContratos"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
            Exit Sub
        End If

        CodigoProducto = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridContrato1.Columns("Cod_Productos").Text = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridContrato1.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
        Me.TrueDBGridContrato1.Col = 3
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridContrato1.Click

    End Sub

    Private Sub TrueDBGridContrato2_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridContrato2.AfterUpdate
        Me.InsertarRowGridContrato2()
    End Sub

    Private Sub TrueDBGridContrato2_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridContrato2.ButtonClick
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
            Exit Sub
        End If

        CodigoProducto = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridContrato2.Columns("Cod_Productos").Text = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridContrato2.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
        Me.TrueDBGridContrato2.Col = 3
    End Sub

    Private Sub TrueDBGridContrato2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridContrato2.Click
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato As Double

        SqlString = "SELECT  idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato LIKE '" & Me.CmbContrato2.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TContrato")
        If Not DataSet.Tables("TContrato").Rows.Count = 0 Then
            IdTipoContrato = DataSet.Tables("TContrato").Rows(0)("idTipoContrato")
        End If

        Me.TrueDBGridContrato2.Columns("IdTipoContrato").Text = IdTipoContrato
        Me.TrueDBGridContrato2.Columns("NumeroContrato").Text = NumeroContrato

    End Sub

    Private Sub CmbContrato1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbContrato1.SelectedIndexChanged

    End Sub


    Private Sub BtnBorrarLineaCont1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarLineaCont1.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroFactura As String

        Try

            Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If




            CodProducto = Me.TrueDBGridContrato1.Columns("Cod_Productos").Text

            Bitacora(Now, NombreUsuario, CodProducto, "Se elimino Producto: " & CodProducto & " " & NumeroContrato)

            iPosicion = Me.TrueDBGridContrato1.Row


            If Me.dsContrato1.Tables("DetalleContrato1").Rows.Count <> 0 Then

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                oDataRow = dsContrato1.Tables("DetalleContrato1").Rows(iPosicion)
                oDataRow.Delete()

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
                oTablaBorrados = dsContrato1.Tables("DetalleContrato1").GetChanges(DataRowState.Deleted)
                If Not IsNothing(oTablaBorrados) Then
                    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                    Me.daContrato1.Update(oTablaBorrados)
                End If
                dsContrato1.Tables("DetalleContrato1").AcceptChanges()
                daContrato1.Update(dsContrato1.Tables("DetalleContrato1"))

            End If


        Catch ex As Exception
            MsgBox("Para borrar es necesario Grabar" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub BtnBorrarLineaCont2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarLineaCont2.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroFactura As String

        Try

            Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If




            CodProducto = Me.TrueDBGridContrato2.Columns("Cod_Productos").Text

            Bitacora(Now, NombreUsuario, CodProducto, "Se elimino Producto: " & CodProducto & " " & NumeroContrato)

            iPosicion = Me.dsContrato2.Tables("DetalleContrato2").Rows.Count


            If Me.dsContrato2.Tables("DetalleContrato2").Rows.Count <> 0 Then

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                oDataRow = dsContrato2.Tables("DetalleContrato2").Rows(iPosicion)
                oDataRow.Delete()

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
                oTablaBorrados = dsContrato2.Tables("DetalleContrato2").GetChanges(DataRowState.Deleted)
                If Not IsNothing(oTablaBorrados) Then
                    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                    Me.daContrato2.Update(oTablaBorrados)
                End If
                dsContrato2.Tables("DetalleContrato2").AcceptChanges()
                daContrato2.Update(dsContrato2.Tables("DetalleContrato2"))

            End If


        Catch ex As Exception
            MsgBox("Para borrar es necesario Grabar" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub BtnOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrdenCompra.Click

    End Sub

    Private Sub LblNumeroContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNumeroContrato.Click

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub CmdAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAjustes.Click
        Me.LblNuevo.Text = "NUEVO"
        Me.Agregar = True
        Me.Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim idContrato1 As Double, idContrato2 As Double
        If Me.Agregar = True Then
            Button7_Click(sender, e)

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato1.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato")
            If Not DataSet.Tables("Contrato").Rows.Count = 0 Then
                IdContrato1 = DataSet.Tables("Contrato").Rows(0)("idTipoContrato")
            End If

            SqlString = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato2.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato2")
            If Not DataSet.Tables("Contrato2").Rows.Count = 0 Then
                IdContrato2 = DataSet.Tables("Contrato2").Rows(0)("idTipoContrato")
            End If

            If IdContrato2 = 0 Then
                IdContrato2 = IdContrato1
            End If

            If Me.TxtFrecuencia.Text = "" Then
                Me.TxtFrecuencia.Text = 1
            End If

            If Me.TxtPrecioUnitario.Text = "" Then
                Me.TxtPrecioUnitario.Text = 1
            End If



            GuardarDetalleContrato(0, NumeroContrato, idContrato1, Me.CmbContrato1.Text, Me.TxtFrecuencia.Text, Me.DtpInicioContrato1.Value, Me.DtpFinContrato1.Value, Me.TxtPrecioUnitario.Text, Me.CmbMoneda1.Text, Me.ChkActivo.Checked, False, False, False, Me.TxtFrecuencia.Text, Me.TxtNumero1.Value, Me.CboCodigoBodega.Text, Me.ChkContratoVariable.Checked, Me.TxtDireccionContrato.Text)

            LimpiaContrato()

            MsgBox("Registro Guardado!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        Else
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato1.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato")
            If Not DataSet.Tables("Contrato").Rows.Count = 0 Then
                idContrato1 = DataSet.Tables("Contrato").Rows(0)("idTipoContrato")
            End If

            SqlString = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato2.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Contrato2")
            If Not DataSet.Tables("Contrato2").Rows.Count = 0 Then
                idContrato2 = DataSet.Tables("Contrato2").Rows(0)("idTipoContrato")
            End If

            If idContrato2 = 0 Then
                idContrato2 = idContrato1
            End If

            If Me.TxtFrecuencia.Text = "" Then
                Me.TxtFrecuencia.Text = 1
            End If

            If Me.TxtPrecioUnitario.Text = "" Then
                Me.TxtPrecioUnitario.Text = 1
            End If



            GuardarDetalleContrato(idDetalleContrato, NumeroContrato, idContrato1, Me.CmbContrato1.Text, Me.TxtFrecuencia.Text, Me.DtpInicioContrato1.Value, Me.DtpFinContrato1.Value, Me.TxtPrecioUnitario.Text, Me.CmbMoneda1.Text, Me.ChkActivo.Checked, False, False, False, Me.TxtFrecuencia.Text, Me.TxtNumero1.Value, Me.CboCodigoBodega.Text, Me.ChkContratoVariable.Checked, Me.TxtDireccionContrato.Text)

            LimpiaContrato()

            MsgBox("Registro Modificado!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
        End If
    End Sub

    Private Sub TDBGridTipoContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridTipoContrato.Click

    End Sub

    Private Sub TDBGridTipoContrato_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDBGridTipoContrato.DoubleClick
        Me.LblNuevo.Text = "EDITAR"
        Me.Agregar = False

        Dim SQLClientes As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Dataset As New DataSet
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        If Me.TDBGridTipoContrato.RowCount <> 0 Then

            idDetalleContrato = Me.TDBGridTipoContrato.Columns("IdDetalleContrato").Text
            NumeroContrato = Me.TDBGridTipoContrato.Columns("Numero_Contrato").Text


            SQLClientes = "SELECT Detalle_Contratos.*  FROM Detalle_Contratos WHERE (IdDetalleContrato = " & idDetalleContrato & ") AND (Numero_Contrato = " & NumeroContrato & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(Dataset, "DetalleContrato")
            If Not Dataset.Tables("DetalleContrato").Rows.Count = 0 Then

                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Activo")) Then
                    Me.ChkActivo.Checked = Dataset.Tables("DetalleContrato").Rows(0)("Activo")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Exonerado")) Then
                    Me.ChkExonerado.Checked = Dataset.Tables("DetalleContrato").Rows(0)("Exonerado")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Tipo_Servicios1")) Then
                    Me.CmbContrato1.Text = Dataset.Tables("DetalleContrato").Rows(0)("Tipo_Servicios1")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Frecuencia")) Then
                    Me.TxtFrecuencia.Text = Dataset.Tables("DetalleContrato").Rows(0)("Frecuencia")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Moneda")) Then
                    Me.CmbMoneda1.Text = Dataset.Tables("DetalleContrato").Rows(0)("Moneda")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Inicio_Contrato")) Then
                    Me.DtpInicioContrato1.Text = Dataset.Tables("DetalleContrato").Rows(0)("Inicio_Contrato")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Fin_Contrato")) Then
                    Me.DtpFinContrato1.Value = Dataset.Tables("DetalleContrato").Rows(0)("Fin_Contrato")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Precio_Unitario")) Then
                    Me.TxtPrecioUnitario.Text = Dataset.Tables("DetalleContrato").Rows(0)("Precio_Unitario")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("DiasFactura1")) Then
                    Me.TxtNumero1.Value = Dataset.Tables("DetalleContrato").Rows(0)("DiasFactura1")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("CodBodega1")) Then
                    Me.CboCodigoBodega.Text = Dataset.Tables("DetalleContrato").Rows(0)("CodBodega1")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Contrato_Variable")) Then
                    Me.ChkContratoVariable.Checked = Dataset.Tables("DetalleContrato").Rows(0)("Contrato_Variable")
                End If
                If Not IsDBNull(Dataset.Tables("DetalleContrato").Rows(0)("Direccion")) Then
                    Me.TxtDireccionContrato.Text = Dataset.Tables("DetalleContrato").Rows(0)("Direccion")
                End If

                Me.Button2.Enabled = True


            Else

                Me.CmbContrato1.Text = ""
                Me.CmbContrato2.Text = ""
                Me.TxtFrecuencia.Text = ""
                Me.CmbFrecuencia2.Text = ""
                Me.CmbMoneda1.Text = ""
                Me.CmbMoneda2.Text = ""
                Me.DtpInicioContrato1.Text = Now
                Me.DtpFinContrato1.Value = Now
                Me.DtpInicioContrato2.Text = Now
                Me.DtpFinContrato2.Value = Now
                Me.TxtPrecioUnitario.Text = ""
                Me.TxtPrecioUnitario2.Text = ""

                Me.TxtDireccionCotrato2.Text = ""
                Me.TxtDireccionContrato.Text = ""


            End If

        End If

    End Sub
End Class