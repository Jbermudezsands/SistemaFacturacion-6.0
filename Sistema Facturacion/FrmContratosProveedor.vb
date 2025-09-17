Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Diagnostics.Contracts

Public Class FrmContratosProveedor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Numero_Contrato As String
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("Detalle").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("Detalle").AcceptChanges()
            da.Update(ds.Tables("Detalle"))

            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("Detalle").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("Detalle").AcceptChanges()
                da.Update(ds.Tables("Detalle"))
            End If
        End If



    End Sub

    Public Sub Cargar_Grid_Detalle(Numero_Contrato As String)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        SqlString = "SELECT id_Detalle_Productos, Numero_Contrato, Tipo_Contrato, Cod_Productos, Descripcion_Productos, Cantidad, Precio_Unitario FROM Detalle_Contratos_Productos WHERE  (Numero_Contrato = '" & Numero_Contrato & "') AND (Tipo_Contrato = 'Proveedores')"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "Detalle")
        Me.TrueDBGridComponentes.DataSource = ds.Tables("Detalle")
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Productos").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Contrato").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Tipo_Contrato").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 100
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Locked = True
        Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Productos").Width = 300
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Productos").Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 70
        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Precio"

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
    Public Sub Cargar_Contrato(Numero_Contrato As String)
        Dim Contrato As TablaContrato_Proveedor = New TablaContrato_Proveedor
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        If Numero_Contrato = "-----0-----" Then
            Exit Sub
        End If

        Contrato = Cargar_Contrato_Proveedor(Numero_Contrato)
        If Contrato IsNot Nothing Then

            Me.TxtNumeroContrato.Text = Contrato.Numero_Contrato
            Me.CboCodigoProveedor.Text = Contrato.Codigo_Proveedor
            Me.TxtContacto.Text = Contrato.Contacto_Proveedor
            Me.TxtTelefono.Text = Contrato.Telefono_Contacto
            Me.TxtDescripcion.Text = Contrato.Descripcion
            Me.DtpInicioContrato.Value = Contrato.Fecha_Inicio
            Me.DtpInicioContrato.Value = Contrato.Fecha_Fin
            CmbTipoServicio.Text = Contrato.Tipo_Servicio
            CmbTipoContrato.Text = Contrato.Tipo_Contrato
            txtModelo.Text = Contrato.ModeloContrato
            TxtDiasRespuesta.Text = Contrato.Num_Respuesta
            TxtDiasResolucion.Text = Contrato.Num_Resolucion
            CmbDiasRespuesta.Text = Contrato.Tiempo_Respuesta
            CmbDiasResolucion.Text = Contrato.Tiempo_Resolucion
            CmbEstado.Text = Contrato.Estado
            TxtComentarios.Text = Contrato.Comentarios
            ChkLunes.Checked = Contrato.Cobertura_Lunes
            ChkMartes.Checked = Contrato.Cobertura_Martes
            ChkMiercoles.Checked = Contrato.Cobertura_Miercoles
            ChkJueves.Checked = Contrato.Cobertura_Jueves
            ChkViernes.Checked = Contrato.Cobertura_Viernes
            ChkSabado.Checked = Contrato.Cobertura_Sabado
            ChkDomingo.Checked = Contrato.Cobertura_Domingo
            TxtLunesInicio.Text = Format(Contrato.Lunes_Inicio, "HH:mm")
            TxtLunesFin.Text = Format(Contrato.Lunes_Fin, "HH:mm")
            TxtMartesInicio.Text = Format(Contrato.Martes_Inicio, "HH:mm")
            TxtMartesFin.Text = Format(Contrato.Martes_Fin, "HH:mm")
            TxtMiercolesInicio.Text = Format(Contrato.Miercoles_Inicio, "HH:mm")
            TxtMiercolesFin.Text = Format(Contrato.Miercoles_Fin, "HH:mm")
            TxtJuevesInicio.Text = Format(Contrato.Jueves_Inicio, "HH:mm")
            TxtJuevesFin.Text = Format(Contrato.Jueves_Fin, "HH:mm")
            TxtViernesInicio.Text = Format(Contrato.Viernes_Inicio, "HH:mm")
            TxtViernesFin.Text = Format(Contrato.Viernes_Fin, "HH:mm")
            TxtSabadoInicio.Text = Format(Contrato.Sabado_Inicio, "HH:mm")
            TxtSabadoFin.Text = Format(Contrato.Sabado_Fin, "HH:mm")
            TxtDomingoInicio.Text = Format(Contrato.Domingo_Inicio, "HH:mm")
            TxtDomingoFin.Text = Format(Contrato.Domingo_Fin, "HH:mm")

            If Contrato.Estado = "Cancelado" Then
                CmbEstado.Enabled = False
                Me.Button1.Enabled = False
                Me.Button2.Enabled = False
                Me.CmdGuardar.Enabled = False
                Me.CmdEliminar.Enabled = False
                Me.Button4.Enabled = False
            Else
                CmbEstado.Enabled = True
                Me.Button1.Enabled = True
                Me.Button2.Enabled = True
                Me.CmdGuardar.Enabled = True
                Me.CmdEliminar.Enabled = True
                Me.Button4.Enabled = True
            End If

            Cargar_Grid_Detalle(Contrato.Numero_Contrato)

        Else
            MsgBox("Contrato no Existe", vbCritical, "Zeus Facturacion")
        End If

    End Sub


    Private Sub Limpiar_Contrato()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        Me.TxtNumeroContrato.Text = "-----0-----"
        Me.CboCodigoProveedor.Text = ""
        Me.TxtContacto.Text = ""
        Me.TxtTelefono.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.DtpInicioContrato.Value = Format(Now, "dd/MM/yyyy")
        Me.DtpInicioContrato.Value = Format(Now, "dd/MM/yyyy")
        CmbTipoServicio.Text = "Regular"
        CmbTipoContrato.Text = "Servicios"
        txtModelo.Text = ""
        TxtDiasRespuesta.Text = "1"
        TxtDiasResolucion.Text = "1"
        CmbDiasResolucion.Text = "Dias"
        CmbDiasRespuesta.Text = "Dias"
        CmbEstado.Text = "Autorizado"
        TxtComentarios.Text = ""
        ChkLunes.Checked = False
        ChkMartes.Checked = False
        ChkMiercoles.Checked = False
        ChkJueves.Checked = False
        ChkViernes.Checked = False
        ChkSabado.Checked = False
        ChkDomingo.Checked = False
        TxtLunesInicio.Text = ""
        TxtLunesFin.Text = ""
        TxtMartesInicio.Text = ""
        TxtMartesFin.Text = ""
        TxtMiercolesInicio.Text = ""
        TxtMiercolesFin.Text = ""
        TxtJuevesInicio.Text = ""
        TxtJuevesFin.Text = ""
        TxtViernesInicio.Text = ""
        TxtViernesFin.Text = ""
        TxtSabadoInicio.Text = ""
        TxtSabadoFin.Text = ""
        TxtDomingoInicio.Text = ""
        TxtDomingoFin.Text = ""

        Cargar_Grid_Detalle("-----0-----")
    End Sub


    Private Sub CboCodigoProveedor_TextChanged(sender As Object, e As EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String = ""

        'SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        SqlProveedor = "SELECT  Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor, Contrato_Proveedor.Telefono_Contacto, Proveedor.Direccion_Proveedor, Contrato_Proveedor.Contacto_Proveedor FROM  Contrato_Proveedor RIGHT OUTER JOIN Proveedor ON Contrato_Proveedor.Codigo_Proveedor = Proveedor.Cod_Proveedor WHERE (Proveedor.Cod_Proveedor <> N'' AND Proveedor.Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            'If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
            '    Me.TxtDescripcion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
            'End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono_Contacto")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono_Contacto")
            End If

            'If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Contacto_Proveedor")) Then
            '    Me.TxtContacto.Text = DataSet.Tables("Proveedor").Rows(0)("Contacto_Proveedor")
            'End If

        End If
    End Sub

    Private Sub FrmContratosProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Size
        Me.MaximumSize = Size


        Me.TabControl1.SelectedTab = Generales

        Dim Sql As String = "SELECT * FROM Proveedor"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Limpiar_Contrato()
        Cargar_Contrato(Numero_Contrato)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Contrato As TablaContrato_Proveedor = New TablaContrato_Proveedor
        Dim Numero_Contrato As String

        If Me.CboCodigoProveedor.Text = "" Then
            MsgBox("Se necesito codigo Proveedo", vbCritical, "Zeus Facturacion")
            Exit Sub
        End If

        '///////////Grabo el encabezado del contrato ///////////
        Numero_Contrato = GrabarEncabezado()
        Limpiar_Contrato()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, Dataset As New DataSet
        Dim SQlString As String, StrSqlUpdate As String, NumeroContrato As String
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Contrato?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        NumeroContrato = Me.TxtNumeroContrato.Text

        SQlString = "SELECT  * FROM  Contrato_Proveedor WHERE (Numero_Contrato = '" & NumeroContrato & "') "
        Dataset = FillConsultaSQL(SQlString, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count <> 0 Then
            StrSqlUpdate = "DELETE FROM Contrato_Proveedor  WHERE (Numero_Contrato = '" & NumeroContrato & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Bitacora(Now, NombreUsuario, "Contrato Proveedores", "Borro el Contrato: " & NumeroContrato)
        Else
            Bitacora(Now, NombreUsuario, "Contrato Proveedores", "Intento Borrar Contrato: " & NumeroContrato)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.GroupBoxImportar.Location = New Point(12, 12)
        Me.GroupBoxImportar.Visible = True
    End Sub

    Private Sub BtnAbrir_Click(sender As Object, e As EventArgs) Handles BtnAbrir.Click
        Dim RutaBD As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String
        Dim Cont As Double, i As Double, oDataRow As DataRow, Registros As Double = 0
        Dim ConexionExcel As String, MiConexionExcel As New OleDb.OleDbConnection, DataAdapterExcel As New OleDb.OleDbDataAdapter
        Dim DetalleProductos As TablaDetalle_Contratos_Productos = New TablaDetalle_Contratos_Productos
        Dim Producto As TablaProductos = New TablaProductos

        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName

        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        DataSet.Reset()
        SqlString = "SELECT Cod_Productos, Descripcion_Productos, Cantidad, Precio_Unitario FROM Detalle_Contratos_Productos  WHERE  (Numero_Contrato = N'-10000') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleCompra")

        ConexionExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties = 'Excel 4.0'; Data Source= " & RutaBD & " "
        MiConexionExcel = New OleDb.OleDbConnection(ConexionExcel)
        DataAdapterExcel = New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", MiConexionExcel)
        DataAdapterExcel.Fill(DataSet, "ConsultaExcel")
        Cont = DataSet.Tables("ConsultaExcel").Rows.Count
        i = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Cont
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = True
        Do While Cont > i
            If Not IsDBNull(DataSet.Tables("ConsultaExcel").Rows(i)("CodigoProducto")) Then
                DetalleProductos.Cod_Productos = DataSet.Tables("ConsultaExcel").Rows(i)("CodigoProducto")
                Producto = Buscar_Productos(DetalleProductos.Cod_Productos)
                If Producto IsNot Nothing Then
                    DetalleProductos.Descripcion_Productos = Producto.Descripcion_Producto
                    DetalleProductos.Cantidad = DataSet.Tables("ConsultaExcel").Rows(i)("Cantidad")
                    DetalleProductos.Precio_Unitario = DataSet.Tables("ConsultaExcel").Rows(i)("PrecioUnitario")

                    oDataRow = DataSet.Tables("DetalleCompra").NewRow
                    oDataRow("Cod_Productos") = DetalleProductos.Cod_Productos
                    oDataRow("Descripcion_Productos") = DetalleProductos.Descripcion_Productos
                    oDataRow("Cantidad") = DetalleProductos.Cantidad
                    oDataRow("Precio_Unitario") = DetalleProductos.Precio_Unitario
                    DataSet.Tables("DetalleCompra").Rows.Add(oDataRow)
                Else
                    Me.TxtError.Text = Me.TxtError.Text & "El produto no Existe:" & DetalleProductos.Cod_Productos
                End If

            Else
                Me.TxtError.Text = Me.TxtError.Text & "Campo producto en blanco"
            End If


            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            i = i + 1
        Loop

        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("DetalleCompra")
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 100
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Descripcion_Productos").Width = 434
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.GroupBoxImportar.Location = New Point(952, 12)
        Me.GroupBoxImportar.Visible = True
    End Sub

    Private Sub BtnQuitar_Click(sender As Object, e As EventArgs) Handles BtnQuitar.Click
        Dim Cont As Double
        Me.TrueDBGridConsultas.Delete()
        Cont = Me.TrueDBGridConsultas.RowCount
        Me.LblTotalRegistros.Text = "Total Registros: " & Cont
    End Sub

    Private Sub TrueDBGridComponentes_Click(sender As Object, e As EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Public Function GrabarEncabezado() As String
        Dim contrato As TablaContrato_Proveedor = New TablaContrato_Proveedor


        If Me.TxtNumeroContrato.Text = "-----0-----" Then
            Numero_Contrato = Format(BuscaConsecutivo("Numero_Contrato_Proveedor"), "0000#")
            Me.TxtNumeroContrato.Text = Numero_Contrato
        Else
            Numero_Contrato = Me.TxtNumeroContrato.Text
        End If

        contrato.Numero_Contrato = Numero_Contrato
        If Me.CboCodigoProveedor.Text <> "" Then
            contrato.Codigo_Proveedor = Me.CboCodigoProveedor.Text
        End If
        If Me.TxtContacto.Text <> "" Then
            contrato.Contacto_Proveedor = Me.TxtContacto.Text
        End If
        If Me.TxtTelefono.Text <> "" Then
            contrato.Telefono_Contacto = Me.TxtTelefono.Text
        End If
        If Me.TxtDescripcion.Text <> "" Then
            contrato.Descripcion = Me.TxtDescripcion.Text
        End If
        contrato.Fecha_Inicio = Me.DtpInicioContrato.Value
        contrato.Fecha_Fin = Me.DtpInicioContrato.Value
        contrato.Tipo_Servicio = CmbTipoServicio.Text
        contrato.Tipo_Contrato = CmbTipoContrato.Text
        If txtModelo.Text <> "" Then
            contrato.ModeloContrato = txtModelo.Text
        End If
        If TxtDiasRespuesta.Text <> "" Then
            contrato.Num_Respuesta = TxtDiasRespuesta.Text
        End If
        If TxtDiasResolucion.Text <> "" Then
            contrato.Num_Resolucion = TxtDiasResolucion.Text
        End If
        contrato.Tiempo_Respuesta = CmbDiasRespuesta.Text
        contrato.Tiempo_Resolucion = CmbDiasResolucion.Text
        contrato.Estado = CmbEstado.Text
        If TxtComentarios.Text <> "" Then
            contrato.Comentarios = TxtComentarios.Text
        End If
        contrato.Cobertura_Lunes = ChkLunes.Checked
        contrato.Cobertura_Martes = ChkMartes.Checked
        contrato.Cobertura_Miercoles = ChkMiercoles.Checked
        contrato.Cobertura_Jueves = ChkJueves.Checked
        contrato.Cobertura_Viernes = ChkViernes.Checked
        contrato.Cobertura_Sabado = ChkSabado.Checked
        contrato.Cobertura_Domingo = ChkDomingo.Checked
        If TxtLunesInicio.Text <> "  :" Then
            contrato.Lunes_Inicio = TxtLunesInicio.Text
        End If
        If TxtLunesFin.Text <> "  :" Then
            contrato.Lunes_Fin = TxtLunesFin.Text
        End If
        If TxtMartesInicio.Text <> "  :" Then
            contrato.Martes_Inicio = TxtMartesInicio.Text
        End If
        If TxtMartesFin.Text <> "  :" Then
            contrato.Martes_Fin = TxtMartesFin.Text
        End If
        If TxtMiercolesInicio.Text <> "  :" Then
            contrato.Miercoles_Inicio = TxtMiercolesInicio.Text
        End If
        If TxtMiercolesFin.Text <> "  :" Then
            contrato.Miercoles_Fin = TxtMiercolesFin.Text
        End If
        If TxtJuevesInicio.Text <> "  :" Then
            contrato.Jueves_Inicio = TxtJuevesInicio.Text
        End If
        If TxtJuevesFin.Text <> "  :" Then
            contrato.Jueves_Fin = TxtJuevesFin.Text
        End If
        If TxtViernesInicio.Text <> "  :" Then
            contrato.Viernes_Inicio = TxtViernesInicio.Text
        End If
        If TxtViernesFin.Text <> "  :" Then
            contrato.Viernes_Fin = TxtViernesFin.Text
        End If
        If TxtSabadoInicio.Text <> "  :" Then
            contrato.Sabado_Inicio = TxtSabadoInicio.Text
        End If
        If TxtSabadoFin.Text <> "  :" Then
            contrato.Sabado_Fin = TxtSabadoFin.Text
        End If
        If TxtDomingoInicio.Text <> "  :" Then
            contrato.Domingo_Inicio = TxtDomingoInicio.Text
        End If
        If TxtDomingoFin.Text <> "  :" Then
            contrato.Domingo_Fin = TxtDomingoFin.Text
        End If

        Gravar_Contrato_Proveedor(contrato)

        Return Numero_Contrato

    End Function

    Private Sub CmdEliminar_Click(sender As Object, e As EventArgs) Handles CmdEliminar.Click
        Dim Resultado As Double, iPosicion As Double
        Dim oDataRow As DataRow, oTablaBorrados As DataTable

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        iPosicion = Me.TrueDBGridComponentes.Row

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        oDataRow = ds.Tables("Detalle").Rows(iPosicion)
        oDataRow.Delete()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
        oTablaBorrados = ds.Tables("Detalle").GetChanges(DataRowState.Deleted)
        If Not IsNothing(oTablaBorrados) Then
            '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            da.Update(oTablaBorrados)
        End If
        ds.Tables("Detalle").AcceptChanges()
        da.Update(ds.Tables("Detalle"))
    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles CmdGuardar.Click
        Dim DetalleContrato As TablaDetalle_Contratos_Productos = New TablaDetalle_Contratos_Productos
        Dim Numero_Contrato As String = "-----0-----"
        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()


        If Me.TxtNumeroContrato.Text = "-----0-----" Then
            Numero_Contrato = GrabarEncabezado()
        Else
            Numero_Contrato = Me.TxtNumeroContrato.Text
        End If


        DetalleContrato.Numero_Contrato = Numero_Contrato
        DetalleContrato.Tipo_Contrato = "Proveedores"
        DetalleContrato.Cod_Productos = My.Forms.FrmConsultas.Codigo
        DetalleContrato.Descripcion_Productos = My.Forms.FrmConsultas.Descripcion
        DetalleContrato.Cantidad = 1
        DetalleContrato.Precio_Unitario = 1

        If DetalleContrato.Cod_Productos IsNot Nothing Then
            Grabar_Detalle_ContratoProveedor(DetalleContrato)
        End If

        Cargar_Grid_Detalle(Numero_Contrato)

    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        Dim Cont As Double = Me.TrueDBGridConsultas.RowCount, i As Double = 0
        Dim DetalleContrato As TablaDetalle_Contratos_Productos = New TablaDetalle_Contratos_Productos
        Dim Numero_Contrato As String


        '///////////Grabo el encabezado del contrato ///////////
        Numero_Contrato = GrabarEncabezado()

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Cont
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Value = 0

        Do While Cont > i
            DetalleContrato.Numero_Contrato = Numero_Contrato
            DetalleContrato.Tipo_Contrato = "Proveedores"
            DetalleContrato.Cod_Productos = Me.TrueDBGridConsultas.Item(i)("Cod_Productos")
            DetalleContrato.Descripcion_Productos = Me.TrueDBGridConsultas.Item(i)("Descripcion_Productos")
            DetalleContrato.Cantidad = Me.TrueDBGridConsultas.Item(i)("Cantidad")
            DetalleContrato.Precio_Unitario = Me.TrueDBGridConsultas.Item(i)("Precio_Unitario")

            Grabar_Detalle_ContratoProveedor(DetalleContrato)

            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            i = i + 1
        Loop

        Cargar_Contrato(Numero_Contrato)

    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(sender As Object, e As EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        InsertarRowGrid()
    End Sub
End Class