
Imports System.Data.SqlClient

Public Class FrmContratosNuevos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NumeroContrato As Double, Nuevo As Boolean, CodigoProducto As String
    Public dsContrato1 As New DataSet, daContrato1 As New SqlClient.SqlDataAdapter, CmdBuilder1 As New SqlCommandBuilder
    Public dsContrato2 As New DataSet, daContrato2 As New SqlClient.SqlDataAdapter, CmdBuilder2 As New SqlCommandBuilder
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

        Bitacora(Now, NombreUsuario, "Transformacion de productos", "Se agrego Producto: " & CodigoProducto & " Contrato No." & Me.LblNumeroContrato.Text)
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
        Me.CmbFrecuencia1.Text = ""
        Me.CmbFrecuencia2.Text = ""
        Me.CmbMoneda1.Text = ""
        Me.CmbMoneda2.Text = ""
        Me.DtpInicioContrato1.Text = Now
        Me.DtpFinContrato1.Value = Now
        Me.DtpInicioContrato2.Text = Now
        Me.DtpFinContrato2.Value = Now
        Me.TxtPrecioUnitario1.Text = ""
        Me.TxtPrecioUnitario2.Text = ""







    End Sub

    Private Sub CargarContrato(ByVal NumeroContrato As String)
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdTipoContrato1 As Double, IdTipoContrato2 As Double


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
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Activo")) Then
                Me.ChkActivo.Checked = DataSet.Tables("Contrato").Rows(0)("Activo")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Exonerado")) Then
                Me.ChkExonerado.Checked = DataSet.Tables("Contrato").Rows(0)("Exonerado")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Tipo_Servicios1")) Then
                Me.CmbContrato1.Text = DataSet.Tables("Contrato").Rows(0)("Tipo_Servicios1")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Tipo_Servicios2")) Then
                Me.CmbContrato2.Text = DataSet.Tables("Contrato").Rows(0)("Tipo_Servicios2")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Frecuencia")) Then
                Me.CmbFrecuencia1.Text = DataSet.Tables("Contrato").Rows(0)("Frecuencia")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Frecuencia2")) Then
                Me.CmbFrecuencia2.Text = DataSet.Tables("Contrato").Rows(0)("Frecuencia2")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Moneda")) Then
                Me.CmbMoneda1.Text = DataSet.Tables("Contrato").Rows(0)("Moneda")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Moneda2")) Then
                Me.CmbMoneda2.Text = DataSet.Tables("Contrato").Rows(0)("Moneda2")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Inicio_Contrato")) Then
                Me.DtpInicioContrato1.Text = DataSet.Tables("Contrato").Rows(0)("Inicio_Contrato")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Fin_Contrato")) Then
                Me.DtpFinContrato1.Value = DataSet.Tables("Contrato").Rows(0)("Fin_Contrato")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Inicio_Contrato2")) Then
                Me.DtpInicioContrato2.Text = DataSet.Tables("Contrato").Rows(0)("Inicio_Contrato2")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Fin_Contrato2")) Then
                Me.DtpFinContrato2.Value = DataSet.Tables("Contrato").Rows(0)("Fin_Contrato2")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Precio_Unitario")) Then
                Me.TxtPrecioUnitario1.Text = DataSet.Tables("Contrato").Rows(0)("Precio_Unitario")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Precio_Unitario2")) Then
                Me.TxtPrecioUnitario2.Text = DataSet.Tables("Contrato").Rows(0)("Precio_Unitario2")
            End If
            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("Activo2")) Then
                Me.ChkActivo2.Checked = DataSet.Tables("Contrato").Rows(0)("Activo2")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("DiasFactura1")) Then
                Me.TxtNumero1.Value = DataSet.Tables("Contrato").Rows(0)("DiasFactura1")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("DiasFactura2")) Then
                Me.TxtNumero2.Value = DataSet.Tables("Contrato").Rows(0)("DiasFactura2")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("CodBodega1")) Then
                Me.CboCodigoBodega.Text = DataSet.Tables("Contrato").Rows(0)("CodBodega1")
            End If

            If Not IsDBNull(DataSet.Tables("Contrato").Rows(0)("CodBodega2")) Then
                Me.CboCodigoBodega2.Text = DataSet.Tables("Contrato").Rows(0)("CodBodega2")
            End If



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
        Dim DiasCredito As Double = 0, CausaIva As Boolean
        Dim SqlString As String = ""

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

        If Me.CmbContrato1.Text = "" Then
            MsgBox("Es necesario seleccionar el tipo de contrato", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtPrecioUnitario1.Text = "" Then
            MsgBox("Es necesario Seleccionar el precio unitario", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If



        ConsecutivoCompra = BuscaConsecutivo("Transforma")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        Me.LblNumeroContrato.Text = NumeroCompra


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




        SQLClientes = "SELECT Contratos.* FROM Contratos WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Contratos]    SET [Cod_Cliente] = '" & Me.TxtCodigoClientes.Text & "',[Tipo_Servicios1] = '" & Me.CmbContrato1.Text & "' ,[Tipo_Servicios2] = '" & Me.CmbContrato2.Text & "' ,[Frecuencia] = '" & Me.CmbFrecuencia1.Text & "' ,[Inicio_Contrato] = '" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato] = '" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' ,[Contacto_Administrativo] =  '" & Me.TxtContactoAdmon.Text & "' ,[Contacto_Operativo] =  '" & Me.TxtContactoOperativo.Text & "' ,[Precio_Unitario] = " & Me.TxtPrecioUnitario1.Text & " ,[Moneda] = '" & Me.CmbMoneda1.Text & "' ,[Activo] = " & ContratoActivo & " ,[Activo2] = " & ContratoActivo2 & "  ,[Exonerado] = " & Exonerado & " ,[Referencia] =  '" & Me.CboReferencia.Text & "'  ,[Observaciones] =  '" & Me.TxtObservaciones.Text & "' ,[Precio_Unitario2] =  '" & Me.TxtPrecioUnitario1.Text & "' ,[Inicio_Contrato2] = '" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato2] = '" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,[Moneda2] = '" & Me.CmbMoneda1.Text & "' ,[Frecuencia2] = '" & Me.CmbFrecuencia2.Text & "' ,[IdContrato1] = " & IdContrato1 & " ,[IdContrato2] = " & IdContrato2 & ",[DiasFactura1] = " & Me.TxtNumero1.Value & " ,[DiasFactura2] = " & Me.TxtNumero2.Value & ",[CodBodega1] = '" & Me.CboCodigoBodega.Text & "',[CodBodega2] = '" & Me.CboCodigoBodega2.Text & "'  WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Contratos] ([Cod_Cliente],[Tipo_Servicios1],[Tipo_Servicios2],[Frecuencia],[Inicio_Contrato],[Fin_Contrato] ,[Contacto_Administrativo] ,[Contacto_Operativo],[Precio_Unitario] ,[Moneda],[Activo],[Activo2],[Anulado],[Retencion1],[Retencion2],[Exonerado],[Referencia],[Observaciones],[Precio_Unitario2],[Inicio_Contrato2],[Fin_Contrato2] ,[Moneda2] ,[Frecuencia2] ,[IdContrato1],[IdContrato2],[DiasFactura1],[DiasFactura2],[CodBodega1],[CodBodega2]) " & _
                           "VALUES ('" & Me.TxtCodigoClientes.Text & "','" & Me.CmbContrato1.Text & "' ,'" & Me.CmbContrato2.Text & "' ,'" & Me.CmbFrecuencia1.Text & "' ,'" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' , '" & Me.TxtContactoAdmon.Text & "' , '" & Me.TxtContactoOperativo.Text & "' , " & Me.TxtPrecioUnitario1.Text & " , '" & Me.CmbMoneda1.Text & "' ," & ContratoActivo & "," & ContratoActivo2 & ",0,0,0, " & Exonerado & ", '" & Me.CboReferencia.Text & "' ,'" & Me.TxtObservaciones.Text & "' , " & Me.TxtPrecioUnitario2.Text & " ,'" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,'" & Me.CmbMoneda1.Text & "' ,'" & Me.CmbFrecuencia2.Text & "'  , " & IdContrato1 & " ," & IdContrato2 & ", " & Me.TxtNumero1.Value & " ," & Me.TxtNumero2.Value & ",'" & Me.CboCodigoBodega.Text & "','" & Me.CboCodigoBodega2.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        LimpiaContrato()


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

        Quien = "CodigoProductos"
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

            Resultado = MsgBox("�Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

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

            Resultado = MsgBox("�Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

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
End Class