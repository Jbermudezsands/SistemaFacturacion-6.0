Imports System.Data.Common
Imports System.Data.SqlTypes
Imports GrapeCity.DD

Public Class FrmActualiza
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public MiconexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.OptCuentasCobrar.Checked = True Then
            Quien = "CuentaCobrar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtDesde.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagar.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtDesde.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptInventario.Checked = True Then
            Quien = "CuentaInventario"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtDesde.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.OptCuentasCobrar.Checked = True Then
            Quien = "CuentaCobrar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtHasta.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagar.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtHasta.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptInventario.Checked = True Then
            Quien = "CuentaInventario"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtHasta.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub CmdIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIniciar.Click
        Dim SqlProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Dataset As New DataSet
        Dim iPosicionFila As Double, CodCuenta As String, DescripcionCuenta As String
        Dim SQLClientes As String, CodCuentaCosto As String = 0, CodCuentaVentas As String = 0, CodLinea As String = 0, CodIva As String = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodBodega As String = "", NombreCliente As String = "", ApellidoCliente As String = "", DireccionCliente As String = "-", TelefonoCliente As String = "505"
        Dim RUCCliente As String = "-"


        SqlProductos = "SELECT *  FROM Cuentas WHERE (CodCuentas BETWEEN '" & Me.TxtDesde.Text & "' AND '" & Me.TxtHasta.Text & "')"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiconexionContabilidad)
        Dataset.Reset()
        DataAdapter.Fill(Dataset, "Consultas")
        If Not Dataset.Tables("Consultas").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar.Minimum = 0
            Me.ProgressBar.Visible = True
            Me.ProgressBar.Value = 0
            Me.ProgressBar.Maximum = Dataset.Tables("Consultas").Rows.Count


            Do While iPosicionFila < (Dataset.Tables("Consultas").Rows.Count)
                My.Application.DoEvents()


                CodCuenta = Dataset.Tables("Consultas").Rows(iPosicionFila)("CodCuentas")
                DescripcionCuenta = Dataset.Tables("Consultas").Rows(iPosicionFila)("DescripcionCuentas")
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Nombre1")) Then
                    NombreCliente = Dataset.Tables("Consultas").Rows(iPosicionFila)("Nombre1")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Nombre2")) Then
                    NombreCliente = NombreCliente & " " & Dataset.Tables("Consultas").Rows(iPosicionFila)("Nombre2")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Apellido1")) Then
                    ApellidoCliente = Dataset.Tables("Consultas").Rows(iPosicionFila)("Apellido1")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Apellido2")) Then
                    ApellidoCliente = ApellidoCliente & " " & Dataset.Tables("Consultas").Rows(iPosicionFila)("Apellido2")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Direccion")) Then
                    DireccionCliente = Dataset.Tables("Consultas").Rows(iPosicionFila)("Direccion")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("Telefono")) Then
                    TelefonoCliente = Dataset.Tables("Consultas").Rows(iPosicionFila)("Telefono")
                End If
                If Not IsDBNull(Dataset.Tables("Consultas").Rows(iPosicionFila)("RUC")) Then
                    RUCCliente = Dataset.Tables("Consultas").Rows(iPosicionFila)("RUC")
                End If

                If NombreCliente = "" Then
                    NombreCliente = DescripcionCuenta
                End If
                If ApellidoCliente = "" Then
                    ApellidoCliente = DescripcionCuenta
                End If

                MiConexion.Close()

                If Me.OptCuentasCobrar.Checked = True Then

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////ACTUALIZO EL CLIENTE///////////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    SQLClientes = "SELECT * FROM Clientes WHERE  (Cod_Cliente = '" & CodCuenta & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Clientes")
                    If Not Dataset.Tables("Clientes").Rows.Count = 0 Then
                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                        StrSqlUpdate = "UPDATE [Clientes] SET [Nombre_Cliente] = '" & NombreCliente & "',[Apellido_Cliente] = '" & ApellidoCliente & "',[Direccion_Cliente] = '" & DireccionCliente & "',[Cod_Cuenta_Cliente] = '" & CodCuenta & "',[RUC] = '" & RUCCliente & "' WHERE (Cod_Cliente = '" & CodCuenta & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    Else
                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                        StrSqlUpdate = "INSERT INTO [Clientes] ([Cod_Cliente],[Nombre_Cliente],[Apellido_Cliente],[Direccion_Cliente],[Telefono],[RUC],[Cod_Cuenta_Cliente]) " &
                        "VALUES('" & CodCuenta & "','" & NombreCliente & "','" & ApellidoCliente & "','" & DireccionCliente & "','" & TelefonoCliente & "','" & RUCCliente & "','" & CodCuenta & "')"


                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If
                ElseIf Me.OptCuentasPagar.Checked = True Then

                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////////////ACTUALIZO LAS CUENTAS X PAGAR //////////////////////////////////////////////////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    SQLClientes = "SELECT * FROM Proveedor WHERE (Cod_Proveedor = '" & CodCuenta & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Clientes")
                    If Not Dataset.Tables("Clientes").Rows.Count = 0 Then
                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                        'StrSqlUpdate = "UPDATE [Proveedor] SET [Cod_Proveedor] = '" & CodCuenta & "',[Nombre_Proveedor] = '" & DescripcionCuenta & "',[Apellido_Proveedor] = '" & DescripcionCuenta & "',[Cod_Cuenta_Proveedor] = '" & CodCuenta & "',[Cod_Cuenta_Pagar] = '" & CodCuenta & "' WHERE (Cod_Proveedor = '" & CodCuenta & "')"
                        StrSqlUpdate = "UPDATE [Proveedor] SET [Nombre_Proveedor] = '" & NombreCliente & "',[Apellido_Proveedor] = '" & ApellidoCliente & "',[Direccion_Proveedor] = '" & DireccionCliente & "',[Telefono] = '" & TelefonoCliente & "',[Cod_Cuenta_Proveedor] = '" & CodCuenta & "',[Cod_Cuenta_Pagar] = '" & CodCuenta & "' WHERE (Cod_Proveedor = '" & CodCuenta & "')"

                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    Else
                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                        StrSqlUpdate = "INSERT INTO [Proveedor] ([Cod_Proveedor],[Nombre_Proveedor],[Apellido_Proveedor],[Direccion_Proveedor],[Telefono],[Cod_Cuenta_Proveedor],[Cod_Cuenta_Pagar]) " &
                                       "VALUES('" & CodCuenta & "','" & NombreCliente & "','" & ApellidoCliente & "','" & DireccionCliente & "','" & TelefonoCliente & "','" & CodCuenta & "','" & CodCuenta & "')"


                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If

                ElseIf Me.OptInventario.Checked = True Then
                    '///////////////////////////////BUSCO LA PRIMERA CUENTA DE COSTO //////////////////////////////////////////////////////////
                    SqlProductos = "SELECT CodCuentas , DescripcionCuentas, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Costos')"
                    MiconexionContabilidad.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiconexionContabilidad)
                    DataAdapter.Fill(Dataset, "ConsultasContables")
                    If Not Dataset.Tables("ConsultasContables").Rows.Count Then
                        CodCuentaCosto = Dataset.Tables("ConsultasContables").Rows(0)("CodCuentas")
                    End If
                    Dataset.Tables("ConsultasContables").Reset()
                    MiconexionContabilidad.Close()

                    '////////////////////////////////////BUSCO LA CUENTA DE INGRESOS/////////////////////////////////////////////////////////////
                    SqlProductos = "SELECT CodCuentas , DescripcionCuentas, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Ingresos - Ventas')"
                    MiconexionContabilidad.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiconexionContabilidad)
                    DataAdapter.Fill(Dataset, "ConsultasContables")
                    If Not Dataset.Tables("ConsultasContables").Rows.Count Then
                        CodCuentaVentas = Dataset.Tables("ConsultasContables").Rows(0)("CodCuentas")
                    End If
                    Dataset.Tables("ConsultasContables").Reset()
                    MiconexionContabilidad.Close()

                    MiConexion.Open()
                    '///////////////////////////////////////BUSCO LA LINEA DE PRODUCTOS///////////////////////////////////////////////////////////
                    SQLClientes = "SELECT * FROM Lineas"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Lineas")
                    If Not Dataset.Tables("Lineas").Rows.Count = 0 Then
                        CodLinea = Dataset.Tables("Lineas").Rows(0)("Cod_Linea")
                    End If


                    '///////////////////////////////////////BUSCO LA TABLA DE IMPUESTOS///////////////////////////////////////////////////////////
                    SQLClientes = "SELECT * FROM Impuestos"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Impuestos")
                    If Not Dataset.Tables("Impuestos").Rows.Count = 0 Then
                        CodIva = Dataset.Tables("Impuestos").Rows(0)("Cod_Iva")
                    End If

                    '///////////////////////////////////////BUSCO LA TABLA DE IMPUESTOS///////////////////////////////////////////////////////////
                    SQLClientes = "SELECT * FROM Bodegas"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Bodegas")
                    If Not Dataset.Tables("Bodegas").Rows.Count = 0 Then
                        CodBodega = Dataset.Tables("Bodegas").Rows(0)("Cod_Bodega")
                    End If
                    Dataset.Tables("Bodegas").Reset()

                    MiConexion.Close()
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////AGREO EL NUEVO PRODUCTO///////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    SQLClientes = "SELECT * FROM Productos WHERE (Cod_Productos = '" & CodCuenta & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Clientes")
                    If Not Dataset.Tables("Clientes").Rows.Count = 0 Then
                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                        'StrSqlUpdate = "UPDATE [Proveedor] SET [Cod_Proveedor] = '" & CodCuenta & "',[Nombre_Proveedor] = '" & DescripcionCuenta & "',[Apellido_Proveedor] = '" & DescripcionCuenta & "',[Cod_Cuenta_Proveedor] = '" & CodCuenta & "',[Cod_Cuenta_Pagar] = '" & CodCuenta & "' WHERE (Cod_Proveedor = '" & CodCuenta & "')"
                        'MiConexion.Open()
                        'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        'iResultado = ComandoUpdate.ExecuteNonQuery
                        'MiConexion.Close()

                    Else
                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                        StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Cod_Linea],[Tipo_Producto],[Cod_Cuenta_Inventario],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente]) " &
                                       "VALUES('" & CodCuenta & "','" & DescripcionCuenta & "','Ninguna','" & CodLinea & "','Productos' ,'" & CodCuenta & "','" & CodCuentaCosto & "','" & CodCuentaVentas & "','UNIDAD','0','0','0','NO','" & CodIva & "','Activo','0' ,'0','Nota:','" & CodCuentaCosto & "','" & CodCuentaVentas & "','0')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If


                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////AGREO EL PRODUCTO A LA BODEGA///////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    SQLClientes = "SELECT *  FROM DetalleBodegas WHERE (Cod_Productos ='" & CodCuenta & "') AND (Cod_Bodegas = '" & CodBodega & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
                    DataAdapter.Fill(Dataset, "Bodegas")
                    If Dataset.Tables("Bodegas").Rows.Count = 0 Then

                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                        StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos],[Existencia]) " &
                                       "VALUES ('" & CodBodega & "','" & CodCuenta & "','0')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If


                End If

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////LIMPIO LAS VARIABLES //////////////////////////////////////////////////////////
                NombreCliente = ""
                ApellidoCliente = ""
                DireccionCliente = "-"
                TelefonoCliente = "505"
                RUCCliente = "-"

                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar.Value = iPosicionFila
            Loop
        End If

    End Sub

    Private Sub FrmActualiza_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ajustes")
    End Sub

    Private Sub FrmActualiza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DTPFechaFin.Value = Now

        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtDesdeProducto.Text = My.Forms.FrmConsultas.Codigo

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtHastaProducto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim iPosicionFila As Double, PrecioCostoDolar As Double
        Dim DataSet As New DataSet, SQLProductos As String, PrecioVenta As Double, PrecioCosto As Double, PrecioVentaDolar As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProductos As String, DescripcionProducto As String
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer, Porcentaje As Double, PrecioVentaAnterior As Double, PrecioVentaDolarAnterior As Double

        MiConexion.Open()

        SQLProductos = "SELECT * FROM Productos WHERE (Cod_Productos BETWEEN '" & Me.TxtDesdeProducto.Text & "' AND '" & Me.TxtHastaProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = DataSet.Tables("ListaProductos").Rows.Count

            Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                My.Application.DoEvents()

                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                DescripcionProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Descripcion_Producto"))
                PrecioCosto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio"))
                PrecioCostoDolar = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio_Dolar"))
                PrecioVentaAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Venta"))
                PrecioVentaDolarAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Lista"))


                Porcentaje = 0
                If Me.TxtPorciento.Text <> "" Then
                    If IsNumeric(Me.TxtPorciento.Text) Then
                        Porcentaje = (CDbl(Me.TxtPorciento.Text) / 100)
                    End If
                End If

                If Porcentaje = 0 Then
                    MsgBox("Se necesita el Porcenta para el Calculo", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If

                If Me.RadioButton1.Checked = True Then
                    PrecioVenta = Format(Math.Abs(PrecioCosto) * (1 + Porcentaje), "##,##0.00")
                    PrecioVentaDolar = Format(Math.Abs(PrecioCostoDolar) * (1 + Porcentaje), "##,##0.00")
                ElseIf Me.RadioButton2.Checked = True Then
                    PrecioVenta = Format(Math.Abs(PrecioVentaAnterior) * (1 + Porcentaje), "##,##0.00")
                    PrecioVentaDolar = Format(Math.Abs(PrecioVentaDolarAnterior) * (1 + Porcentaje), "##,##0.00")
                ElseIf Me.RadioButton3.Checked = True Then
                    PrecioVenta = Format(Math.Abs(PrecioVentaAnterior) * (1 - Porcentaje), "##,##0.00")
                    PrecioVentaDolar = Format(Math.Abs(PrecioVentaDolarAnterior) * (1 - Porcentaje), "##,##0.00")

                    PrecioVenta = Math.Abs(PrecioVenta)
                    PrecioVentaDolar = Math.Abs(PrecioVentaDolar)
                End If


                SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodProductos & "') "
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedores")
                If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    StrSQLUpdate = "UPDATE [Productos] SET [Precio_Venta] = '" & PrecioVenta & "',[Precio_Lista] = '" & PrecioVentaDolar & "',[Costo_Promedio] = '" & Math.Abs(PrecioCosto) & "',[Costo_Promedio_Dolar] = '" & Math.Abs(PrecioCostoDolar) & "'  WHERE (Cod_Productos = '" & CodProductos & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()


                End If


                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar1.Value = iPosicionFila

            Loop
        End If

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtDesdeInventario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtHastaInventario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim iPosicionFila As Double, PrecioCostoDolar As Double
        Dim DataSet As New DataSet, SQLProductos As String, PrecioCosto As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProductos As String, DescripcionProducto As String
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer, PrecioVentaAnterior As Double, PrecioVentaDolarAnterior As Double
        Dim Existencia As Double, Contador As Double = 0, SQLstring As String, CodigoBodega As String, iPosicionFila2 As Double
        Dim ExistenciaBodegas As Double

        MiConexion.Open()

        SQLProductos = "SELECT * FROM Productos WHERE (Cod_Productos BETWEEN '" & Me.TxtDesdeInventario.Text & "' AND '" & Me.TxtHastaInventario.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Visible = True
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Maximum = DataSet.Tables("ListaProductos").Rows.Count

            Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)

                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))

                Me.Text = "Procesando " & Me.ProgressBar2.Value + 1 & " de " & Me.ProgressBar2.Maximum
                Me.LblProcesos.Text = "Procesando Producto" & CodProductos
                My.Application.DoEvents()

                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                DescripcionProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Descripcion_Producto"))
                PrecioCosto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio"))
                PrecioCostoDolar = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio_Dolar"))
                PrecioVentaAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Venta"))
                PrecioVentaDolarAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Lista"))

                PrecioCosto = Math.Abs(PrecioCosto)
                PrecioCostoDolar = Math.Abs(PrecioCostoDolar)
                PrecioVentaAnterior = Math.Abs(PrecioVentaAnterior)
                PrecioVentaDolarAnterior = Math.Abs(PrecioVentaDolarAnterior)

                Existencia = ExistenciaProducto(CodProductos)

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SQLstring = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " &
                            "WHERE (DetalleBodegas.Cod_Productos = '" & CodProductos & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
                DataAdapter.Fill(DataSet, "Bodegas")


                '//////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////
                ExistenciaBodegas = 0
                iPosicionFila2 = 0

                Me.ProgressBar3.Minimum = 0
                Me.ProgressBar3.Visible = True
                Me.ProgressBar3.Value = 0
                Me.ProgressBar3.Maximum = DataSet.Tables("Bodegas").Rows.Count
                Do While iPosicionFila2 < (DataSet.Tables("Bodegas").Rows.Count)
                    My.Application.DoEvents()
                    CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila2)("Cod_Bodegas")



                    SQLProductos = "SELECT DetalleBodegas.*  FROM DetalleBodegas WHERE (Cod_Productos = '" & CodProductos & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                    DataAdapter.Fill(DataSet, "Proveedores")
                    If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                        ExistenciaBodegas = BuscaExistenciaBodega(CodProductos, CodigoBodega)
                        Me.LblProcesos.Text = CodProductos & " Bodega " & CodigoBodega

                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                        StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Existencia] = '" & ExistenciaBodegas & "'  WHERE (Cod_Productos = '" & CodProductos & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If


                    iPosicionFila2 = iPosicionFila2 + 1
                    Me.ProgressBar3.Value = iPosicionFila2
                Loop


                SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodProductos & "') "
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedores")
                If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    'StrSQLUpdate = "UPDATE [Productos] SET [Existencia_Unidades] = '" & Existencia & "',[Costo_Promedio] = '" & Math.Abs(PrecioCosto) & "',[Costo_Promedio_Dolar] = '" & Math.Abs(PrecioCostoDolar) & "',[Precio_Venta] = '" & Math.Abs(PrecioVentaAnterior) & "',[Precio_Lista] = '" & Math.Abs(PrecioVentaDolarAnterior) & "'  WHERE (Cod_Productos = '" & CodProductos & "')"
                    StrSQLUpdate = "UPDATE [Productos] SET [Existencia_Unidades] = '" & Existencia & "',[Costo_Promedio] = '" & Math.Abs(PrecioCosto) & "',[Costo_Promedio_Dolar] = '" & Math.Abs(PrecioCostoDolar) & "',[Precio_Venta] = '" & Math.Abs(PrecioVentaAnterior) & "',[Precio_Lista] = '" & Math.Abs(PrecioVentaDolarAnterior) & "'  WHERE (Cod_Productos = '" & CodProductos & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    Contador = Contador + 1

                End If


                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar2.Value = iPosicionFila
                My.Application.DoEvents()
            Loop
        End If

        MsgBox("Se Actualizaron " & Contador & " de Productos", MsgBoxStyle.Exclamation, " Zeus Facturacion")
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim iPosicionFila As Double, PrecioCostoDolar As Double
        Dim DataSet As New DataSet, SQLProductos As String, PrecioCosto As Double, i As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProductos As String, DescripcionProducto As String
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer, PrecioVentaAnterior As Double, PrecioVentaDolarAnterior As Double
        Dim Existencia As Double, Contador As Double = 0, j As Double = 0
        Dim RegistrosMaximos As Double, SqlSTring As String, CodigoBodega As String, Iposicion As Double
        Dim MonedaCompra As String, Cantidad As Double, Importe As Double
        Dim SqlCompras As String, Registros As String, TasaCambio As Double, FechaCompra As Date, PrecioUnitario As Double
        Dim TotalImporte As Double

        SQLProductos = "SELECT * FROM Productos WHERE (Cod_Productos BETWEEN '" & Me.TxtDesdeCosto.Text & "' AND '" & Me.TxtHastaCosto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar5.Minimum = 0
            Me.ProgressBar5.Visible = True
            Me.ProgressBar5.Value = 0
            Me.ProgressBar5.Maximum = DataSet.Tables("ListaProductos").Rows.Count
            RegistrosMaximos = DataSet.Tables("ListaProductos").Rows.Count

            Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                Me.Text = "Procesando " & Me.ProgressBar5.Value + 1 & " de " & RegistrosMaximos
                My.Application.DoEvents()

                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                DescripcionProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Descripcion_Producto"))
                'PrecioCosto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio"))
                'PrecioCostoDolar = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Costo_Promedio_Dolar"))
                'PrecioVentaAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Venta"))
                'PrecioVentaDolarAnterior = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Lista"))

                'PrecioCosto = Math.Abs(PrecioCosto)
                PrecioCostoDolar = Math.Abs(PrecioCostoDolar)
                PrecioVentaAnterior = Math.Abs(PrecioVentaAnterior)
                PrecioVentaDolarAnterior = Math.Abs(PrecioVentaDolarAnterior)

                Existencia = ExistenciaProducto(CodProductos)

                If Me.OptUltimoPrecio.Checked = True Then

                    SqlCompras = "SELECT * FROM  Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Detalle_Compras.Cod_Producto = '" & CodProductos & "') AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "Compras")
                    Registros = DataSet.Tables("Compras").Rows.Count - 1
                    If DataSet.Tables("Compras").Rows.Count <> 0 Then
                        MonedaCompra = DataSet.Tables("Compras").Rows(Registros)("MonedaCompra")
                        If MonedaCompra = "Cordobas" Then
                            PrecioCosto = Trim(DataSet.Tables("Compras").Rows(Registros)("Precio_Unitario"))
                            FechaCompra = Trim(DataSet.Tables("Compras").Rows(Registros)("Fecha_Compra"))
                            TasaCambio = BuscaTasaCambio(FechaCompra)
                            If TasaCambio = 0 Then
                                MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")

                            Else
                                PrecioCostoDolar = (PrecioCosto / TasaCambio)
                            End If
                        Else
                            PrecioCostoDolar = Trim(DataSet.Tables("Compras").Rows(Registros)("Precio_Unitario"))
                            FechaCompra = Trim(DataSet.Tables("Compras").Rows(Registros)("Fecha_Compra"))
                            TasaCambio = BuscaTasaCambio(FechaCompra)
                            If TasaCambio = 0 Then
                                MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")
                            Else
                                PrecioCosto = (PrecioCosto * TasaCambio)
                            End If
                        End If
                    End If

                    DataSet.Tables("Compras").Clear()

                ElseIf Me.OptPromedio.Checked = True Then

                    If CodProductos = "130-11-02-01" Then
                        'Cantidad = 0
                    End If

                    PrecioCosto = CostoPromedio(CodProductos)

                    'SqlCompras = "SELECT MAX(Detalle_Compras.Numero_Compra) AS Numero_Compra, MAX(Detalle_Compras.Fecha_Compra) AS Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cod_Producto, SUM(Detalle_Compras.Cantidad) AS Cantidad, SUM(Detalle_Compras.Precio_Unitario) AS Precio_Unitario, SUM(Detalle_Compras.Descuento) AS Descuento, SUM(Detalle_Compras.Precio_Neto) AS Precio_Neto, Compras.MonedaCompra, SUM(Detalle_Compras.Precio_Unitario * Detalle_Compras.Cantidad) AS Importe FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra GROUP BY Detalle_Compras.Tipo_Compra, Detalle_Compras.Cod_Producto, Compras.MonedaCompra HAVING (Detalle_Compras.Cod_Producto = '" & CodProductos & "') AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    'DataAdapter.Fill(DataSet, "Compras")
                    'Registros = DataSet.Tables("Compras").Rows.Count - 1
                    'Iposicion = 0
                    'TotalImporte = 0
                    'Cantidad = 0
                    'Do While Iposicion < DataSet.Tables("Compras").Rows.Count
                    '    MonedaCompra = DataSet.Tables("Compras").Rows(Iposicion)("MonedaCompra")
                    '    If MonedaCompra = "Cordobas" Then
                    '        PrecioUnitario = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Precio_Unitario"))
                    '        Cantidad = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Cantidad")) + Cantidad
                    '        Importe = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Importe"))
                    '        TotalImporte = TotalImporte + Importe
                    '        FechaCompra = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Fecha_Compra"))
                    '        TasaCambio = BuscaTasaCambio(FechaCompra)
                    '        If TasaCambio = 0 Then
                    '            MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")

                    '        Else
                    '            PrecioCostoDolar = (TotalImporte / TasaCambio)
                    '        End If
                    '    Else
                    '        PrecioUnitario = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Precio_Unitario"))
                    '        Cantidad = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Cantidad")) + Cantidad
                    '        Importe = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Importe"))
                    '        FechaCompra = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Fecha_Compra"))
                    '        If TasaCambio = 0 Then
                    '            MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")
                    '        Else
                    '            TotalImporte = (Importe * TasaCambio) + TotalImporte
                    '        End If
                    '    End If

                    '    Iposicion = Iposicion + 1

                    'Loop
                    'If Cantidad <> 0 Then
                    '    PrecioCosto = Format(TotalImporte / Cantidad, "##,##0.00")
                    '    PrecioCostoDolar = Format((PrecioCosto / TasaCambio), "##,##0.00")
                    'Else
                    '    PrecioCosto = PrecioUnitario
                    '    If PrecioCosto <> 0 Then
                    '        PrecioCostoDolar = Format((PrecioCosto / TasaCambio), "##,##0.00")
                    '    Else
                    '        PrecioCostoDolar = 0
                    '    End If
                    'End If

                    '    DataSet.Tables("Compras").Reset()


                End If



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO EL PRODUCTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodProductos & "') "
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedores")
                If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                    '///////////SIsEXISTE EL USUARIO LO ACTUALIZO////////////////
                    StrSQLUpdate = "UPDATE [Productos] SET [Costo_Promedio] = '" & Math.Abs(PrecioCosto) & "',[Costo_Promedio_Dolar] = '" & Math.Abs(PrecioCostoDolar) & "' WHERE (Cod_Productos = '" & CodProductos & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    Contador = Contador + 1

                End If

                '*******************************************************************************************
                '/////////////////////////ACTUALIZADO POR BODEGA //////////////////////////////////////////
                '*******************************************************************************************
                If Me.ChkBodega.Checked = True Then



                    SqlSTring = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " &
                                    "WHERE (DetalleBodegas.Cod_Productos = '" & CodProductos & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                    DataAdapter.Fill(DataSet, "Bodegas")

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Existencia = 0
                    i = 0
                    Me.ProgressBar4.Minimum = 0
                    Me.ProgressBar4.Visible = True
                    Me.ProgressBar4.Value = 0
                    Me.ProgressBar4.Maximum = DataSet.Tables("Bodegas").Rows.Count
                    Do While i < (DataSet.Tables("Bodegas").Rows.Count)
                        My.Application.DoEvents()
                        CodigoBodega = DataSet.Tables("Bodegas").Rows(i)("Cod_Bodegas")

                        'ExistenciaBodega = BuscaExistenciaBodega(CodProductos, CodigoBodega)
                        'Existencia = Existencia + ExistenciaBodega

                        If Me.OptUltimoPrecio.Checked = True Then

                            '//////////////////////////////////////////////BUSCO LA ULTIMA COMPRA //////////////////////////////
                            SqlSTring = "SELECT  * FROM  Detalle_Compras INNER JOIN  Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE  (Compras.Cod_Bodega = '" & CodigoBodega & "') AND (Detalle_Compras.Cod_Producto = '" & CodProductos & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                            DataAdapter.Fill(DataSet, "UltCompra")
                            j = DataSet.Tables("UltCompra").Rows.Count - 1
                            If DataSet.Tables("UltCompra").Rows.Count <> 0 Then
                                MonedaCompra = DataSet.Tables("UltCompra").Rows(j)("MonedaCompra")
                                If MonedaCompra = "Cordobas" Then
                                    PrecioCosto = Trim(DataSet.Tables("UltCompra").Rows(j)("Precio_Unitario"))
                                    FechaCompra = Trim(DataSet.Tables("UltCompra").Rows(j)("Fecha_Compra"))
                                    TasaCambio = BuscaTasaCambio(FechaCompra)
                                    If TasaCambio = 0 Then
                                        MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")

                                    Else
                                        PrecioCostoDolar = (PrecioCosto / TasaCambio)
                                    End If
                                Else
                                    PrecioCostoDolar = Trim(DataSet.Tables("UltCompra").Rows(j)("Precio_Unitario"))
                                    FechaCompra = Trim(DataSet.Tables("UltCompra").Rows(j)("Fecha_Compra"))
                                    TasaCambio = BuscaTasaCambio(FechaCompra)
                                    If TasaCambio = 0 Then
                                        MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")
                                    Else
                                        PrecioCosto = (PrecioCosto * TasaCambio)
                                    End If
                                End If

                                DataSet.Tables("UltCompra").Reset()
                                MiConexion.Close()



                                '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
                                StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Costo] = '" & Math.Abs(PrecioCosto) & "',[CostoDolar] = '" & Math.Abs(PrecioCostoDolar) & "'  WHERE (Cod_Productos = '" & CodProductos & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                                MiConexion.Open()
                                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                                iResultado = ComandoUpdate.ExecuteNonQuery
                                MiConexion.Close()
                            End If

                        ElseIf Me.OptPromedio.Checked = True Then

                            SqlCompras = "SELECT MAX(Detalle_Compras.Numero_Compra) AS Numero_Compra, MAX(Detalle_Compras.Fecha_Compra) AS Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cod_Producto, SUM(Detalle_Compras.Cantidad) AS Cantidad, SUM(Detalle_Compras.Precio_Unitario) AS Precio_Unitario, SUM(Detalle_Compras.Descuento) AS Descuento, SUM(Detalle_Compras.Precio_Neto) AS Precio_Neto, Compras.MonedaCompra, SUM(Detalle_Compras.Precio_Unitario * Detalle_Compras.Cantidad) AS Importe FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra GROUP BY Detalle_Compras.Tipo_Compra, Detalle_Compras.Cod_Producto, Compras.MonedaCompra HAVING (Detalle_Compras.Cod_Producto = '" & CodProductos & "') AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                            DataAdapter.Fill(DataSet, "Compras")
                            Registros = DataSet.Tables("Compras").Rows.Count - 1
                            Iposicion = 0
                            TotalImporte = 0
                            Iposicion = 0
                            Cantidad = 0
                            Do While Iposicion < DataSet.Tables("Compras").Rows.Count
                                MonedaCompra = DataSet.Tables("Compras").Rows(Iposicion)("MonedaCompra")
                                If MonedaCompra = "Cordobas" Then
                                    PrecioUnitario = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Precio_Unitario"))
                                    Cantidad = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Cantidad")) + Cantidad
                                    Importe = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Importe"))
                                    TotalImporte = TotalImporte + Importe
                                    FechaCompra = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Fecha_Compra"))
                                    TasaCambio = BuscaTasaCambio(FechaCompra)
                                    If TasaCambio = 0 Then
                                        MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")

                                    Else
                                        PrecioCostoDolar = (PrecioCosto / TasaCambio)
                                    End If
                                Else
                                    PrecioUnitario = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Precio_Unitario"))
                                    Cantidad = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Cantidad")) + Cantidad
                                    Importe = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Importe"))
                                    FechaCompra = Trim(DataSet.Tables("Compras").Rows(Iposicion)("Fecha_Compra"))
                                    If TasaCambio = 0 Then
                                        MsgBox("TASA DE CAMBIO CERO,", MsgBoxStyle.Critical, "Zeus Facturacion ")
                                    Else
                                        TotalImporte = (Importe * TasaCambio) + TotalImporte
                                    End If

                                End If

                                If Cantidad <> 0 Then
                                    PrecioCosto = Format(TotalImporte / Cantidad, "##,##0.00")
                                    PrecioCostoDolar = Format((PrecioCosto / TasaCambio), "##,##0.00")
                                Else
                                    PrecioCosto = PrecioUnitario
                                    If PrecioCosto <> 0 Then
                                        PrecioCostoDolar = Format((PrecioCosto / TasaCambio), "##,##0.00")
                                    Else
                                        PrecioCostoDolar = 0
                                    End If
                                End If
                                'PrecioCosto = Format(TotalImporte / Cantidad, "##,##0.00")
                                'PrecioCostoDolar = Format((PrecioCosto / TasaCambio), "##,##0.00")

                                DataSet.Tables("Compras").Reset()


                                '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
                                StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Costo] = '" & Math.Abs(PrecioCosto) & "',[CostoDolar] = '" & Math.Abs(PrecioCostoDolar) & "'  WHERE (Cod_Productos = '" & CodProductos & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                                MiConexion.Open()
                                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                                iResultado = ComandoUpdate.ExecuteNonQuery
                                MiConexion.Close()

                                Iposicion = Iposicion + 1

                            Loop


                        End If
                        i = i + 1
                        Me.ProgressBar4.Value = i
                    Loop



                End If






                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar5.Value = iPosicionFila

            Loop
        End If

        MsgBox("Se Actualizaron " & Contador & " de Productos", MsgBoxStyle.Exclamation, " Zeus Facturacion")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtDesdeCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtHastaCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim iPosicionFila As Double
        Dim DataSet As New DataSet, SQLProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, FechaCompra As Date, MonedaCompra As String, TipoCompra As String
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer
        Dim Contador As Double = 0, j As Double = 0
        Dim Cantidad As Double, Precio As Double, Codigo As String, Numero As String, SqlString As String, FactCont As Double, i As Double
        Dim NumeroFactura As String, FechaFactura As Date, TipoFactura As String, TasaImpuesto As Double, ImpuestoFact As Double, SubTotalFact As Double, Exonerado As Boolean

        MiConexion.Open()

        If Me.OptImporteFacturas.Checked = True Then

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////BUSCO TODAS LAS FACTURAS ////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT * FROM Facturas"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            FactCont = DataSet.Tables("Facturas").Rows.Count
            i = 0
            Exonerado = False
            NumeroFactura = 0
            FechaFactura = Now
            TipoFactura = ""
            Do While FactCont > i

                NumeroFactura = DataSet.Tables("Facturas").Rows(i)("Numero_Factura")
                FechaFactura = DataSet.Tables("Facturas").Rows(i)("Fecha_Factura")
                TipoFactura = DataSet.Tables("Facturas").Rows(i)("Tipo_Factura")
                Exonerado = DataSet.Tables("Facturas").Rows(i)("Exonerado")


                'SQLProductos = "SELECT  *  FROM Detalle_Facturas "
                SQLProductos = "SELECT     * FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN  Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva " &
                               "WHERE  (Detalle_Facturas.Numero_Factura = '" & NumeroFactura & "') AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME,  '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) "

                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "ListaProductos")
                MiConexion.Close()

                Me.ProgressBarFactura.Minimum = 0
                Me.ProgressBarFactura.Maximum = DataSet.Tables("ListaProductos").Rows.Count
                Me.ProgressBarFactura.Value = 0
                Me.ProgressBarFactura.Visible = True
                SubTotalFact = 0
                ImpuestoFact = 0

                If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                    iPosicionFila = 0
                    Me.ProgressBar6.Minimum = 0
                    Me.ProgressBar6.Visible = True
                    Me.ProgressBar6.Value = 0
                    Me.ProgressBar6.Maximum = DataSet.Tables("ListaProductos").Rows.Count

                    Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                        My.Application.DoEvents()

                        TasaImpuesto = DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Impuesto")

                        Cantidad = DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cantidad")
                        Precio = DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Precio_Unitario")

                        Codigo = DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Producto")
                        Numero = DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Numero_Factura")

                        SubTotalFact = SubTotalFact + (Cantidad * Precio)

                        If TipoFactura = "Cotizacion" Or TipoFactura = "Factura" Then
                            If Exonerado = False Then
                                ImpuestoFact = ImpuestoFact + (Cantidad * Precio * TasaImpuesto)
                            Else
                                ImpuestoFact = 0
                            End If
                        Else
                            ImpuestoFact = 0
                        End If



                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////DETALLE DE FACTURA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////

                        SQLProductos = "SELECT *, Cod_Producto AS Expr6 FROM Detalle_Facturas WHERE  (Numero_Factura = '" & Numero & "') AND(Cod_Producto = '" & Codigo & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                        DataAdapter.Fill(DataSet, "Proveedores")
                        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                            '///////////SIsEXISTE EL USUARIO LO ACTUALIZO////////////////
                            StrSQLUpdate = "UPDATE Detalle_Facturas  SET [Precio_Neto] = " & Precio & " ,[Importe] = " & Precio * Cantidad & " WHERE  (Numero_Factura = '" & Numero & "') AND(Cod_Producto = '" & Codigo & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        iPosicionFila = iPosicionFila + 1
                        Me.ProgressBar6.Value = iPosicionFila
                    Loop
                End If

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////FACTURA/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SQLProductos = "SELECT  Facturas.* FROM Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "Proveedores")
                If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                    '///////////SIsEXISTE EL USUARIO LO ACTUALIZO////////////////
                    StrSQLUpdate = "UPDATE Facturas  SET [SubTotal] = " & Format(SubTotalFact, "####0.00") & " ,[IVA] = " & Format(ImpuestoFact, "####0.00") & ", [NetoPagar] = " & Format(ImpuestoFact + SubTotalFact, "####0.00") & "  WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                Me.ProgressBarFactura.Value = Me.ProgressBarFactura.Visible + 1
                i = i + 1
            Loop
        ElseIf Me.OptVerificarCompras.Checked = True Then
            SQLProductos = "SELECT  * FROM  Compras "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
            DataAdapter.Fill(DataSet, "ListaCompras")
            MiConexion.Close()
            If Not DataSet.Tables("ListaCompras").Rows.Count = 0 Then
                iPosicionFila = 0
                Me.ProgressBar6.Minimum = 0
                Me.ProgressBar6.Visible = True
                Me.ProgressBar6.Value = 0
                Me.ProgressBar6.Maximum = DataSet.Tables("ListaCompras").Rows.Count

                Do While iPosicionFila < (DataSet.Tables("ListaCompras").Rows.Count)
                    Numero = DataSet.Tables("ListaCompras").Rows(iPosicionFila)("Numero_Compra")
                    FechaCompra = DataSet.Tables("ListaCompras").Rows(iPosicionFila)("Fecha_Compra")
                    MonedaCompra = DataSet.Tables("ListaCompras").Rows(iPosicionFila)("MonedaCompra")
                    TipoCompra = DataSet.Tables("ListaCompras").Rows(iPosicionFila)("Tipo_Compra")

                    VerificarCompras(Numero, FechaCompra, MonedaCompra, TipoCompra)
                    iPosicionFila = iPosicionFila + 1
                    Me.ProgressBar6.Value = iPosicionFila
                Loop

            End If


        End If




    End Sub

    Private Sub CmdCostear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCostear.Click
        Dim iPosicionFila As Double, PrecioCostoDolar As Double, NumeroFactura As String = "", TipoSalida As String = "", FechaCompra As Date
        Dim DataSet As New DataSet, SQLProductos As String, PrecioCosto As Double, iPosicionFila2 As Double = 0, iPosicionFila3 As Double = 0
        Dim DataAdapter As New SqlClient.SqlDataAdapter, RegistrosMaximos As Double, SqlSTring As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim CodProductos As String, DescripcionProducto As String, Contador As Double = 0, j As Double = 0, iResultado As Integer
        Dim Cantidad As Double = 0, Registros As Double = 0, PrecioUnitario As Double = 0, StrSQLUpdate As String


        If Me.TxtDesdeCosto.Text = "" And Me.TxtHastaCosto.Text = "" Then
            SQLProductos = "SELECT * FROM Productos "
        Else
            SQLProductos = "SELECT * FROM Productos WHERE (Cod_Productos BETWEEN '" & Me.TxtDesdeCosto.Text & "' AND '" & Me.TxtHastaCosto.Text & "')"
        End If



        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        MiConexion.Close()
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            iPosicionFila = 0
            Me.ProgressBar5.Minimum = 0
            Me.ProgressBar5.Visible = True
            Me.ProgressBar5.Value = 0
            Me.ProgressBar5.Maximum = DataSet.Tables("ListaProductos").Rows.Count
            RegistrosMaximos = DataSet.Tables("ListaProductos").Rows.Count

            Do While iPosicionFila < (DataSet.Tables("ListaProductos").Rows.Count)
                Me.Text = "Procesando " & Me.ProgressBar5.Value + 1 & " de " & RegistrosMaximos
                My.Application.DoEvents()
                CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                DescripcionProducto = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Descripcion_Producto"))

                'If CodProductos = "02RVPAFBID" Then
                '    CodProductos = Trim(DataSet.Tables("ListaProductos").Rows(iPosicionFila)("Cod_Productos"))
                'End If


                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////EL DETALLE DE LA FACTURA LA LLENO DE CERO PARA EL COSTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////
                StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = 0  WHERE (Cod_Producto = '" & CodProductos & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////
                SqlSTring = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " &
                            "WHERE (DetalleBodegas.Cod_Productos = '" & CodProductos & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                DataAdapter.Fill(DataSet, "Bodegas")
                '//////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////
                'Existencia = 0
                'iPosicionFila2 = 0
                'Me.ProgressBar4.Minimum = 0
                'Me.ProgressBar4.Visible = True
                'Me.ProgressBar4.Value = 0
                'Me.ProgressBar4.Maximum = DataSet.Tables("Bodegas").Rows.Count
                'Do While iPosicionFila2 < (DataSet.Tables("Bodegas").Rows.Count)
                'My.Application.DoEvents()
                'CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila2)("Cod_Bodegas")
                'Me.Text = "Procesando el Producto: " & CodProductos & " Bodega: " & CodigoBodega
                'PrecioCosto = CostoPromedioBodega(CodProductos, CodigoBodega)
                'PrecioCostoDolar = CostoPromedioDolar
                ''//////////////////////////////////////////////////////////////////////////////////////////////
                ''///////////////ACTUALIZO EL COSTO DE PRODUCTOS/////////////////////////////////////////////////
                ''/////////////////////////////////////////////////////////////////////////////////////////////
                'StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Costo] = '" & Math.Abs(PrecioCosto) & "',[CostoDolar] = '" & Math.Abs(PrecioCostoDolar) & "'  WHERE (Cod_Productos = '" & CodProductos & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////ASIGNO EL COSTO A TODAS LAS SALIDAS DE ESTE PRODUCTO Y BODEGA/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                'SqlSTring = "SELECT  * FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Facturas.Cod_Bodega = '" & CodigoBodega & "') AND (Facturas.Tipo_Factura <> 'Cotizacion') ORDER BY Facturas.Fecha_Factura"
                SqlSTring = "SELECT  * FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "')  AND (Facturas.Tipo_Factura <> 'Cotizacion') ORDER BY Facturas.Fecha_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                DataAdapter.Fill(DataSet, "Salidas")
                iPosicionFila3 = 0
                Me.ProgressBar4.Minimum = 0
                Me.ProgressBar4.Visible = True
                Me.ProgressBar4.Value = 0
                Me.ProgressBar4.Maximum = DataSet.Tables("Salidas").Rows.Count
                Do While iPosicionFila3 < (DataSet.Tables("Salidas").Rows.Count)

                    FechaCompra = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Fecha_Factura")
                    NumeroFactura = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Numero_Factura")
                    If Not IsDBNull(DataSet.Tables("Salidas").Rows(iPosicionFila3)("Cantidad")) Then
                        Cantidad = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Cantidad")
                    End If
                    TipoSalida = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Tipo_Factura")
                    PrecioCosto = CostoPromedioKardex(CodProductos, FechaCompra)
                    PrecioCostoDolar = CostoPromedioDolar
                    PrecioUnitario = PrecioCosto
                    'PrecioUnitario = DataSet.Tables("Salidas").Rows(iPosicionFila3)("Precio_Unitario")
                    'PrecioCosto = CostoPromedioActualizaBodega(CodProductos, FechaCompra, CodigoBodega)
                    'PrecioCostoDolar = CostoPromedioDolar
                    Me.Text = "Procesando el Producto: " & CodProductos & "Factura No" & NumeroFactura
                    My.Application.DoEvents()

                    '///////////SI EL COSTO ES CERO PERO SE DESCARGAR, SIGNIFICA FACTURACION EN NEGATIVO ///////////
                    If Cantidad <> 0 Then
                        If PrecioCosto = 0 Then
                            SqlSTring = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Costo_Unitario / TasaCambio.MontoTasa AS Costo_UnitarioDolar FROM Detalle_Facturas INNER JOIN TasaCambio ON Detalle_Facturas.Fecha_Factura = TasaCambio.FechaTasa  " &
                                        "WHERE (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Detalle_Facturas.Costo_Unitario <> 0) AND (Detalle_Facturas.Fecha_Factura <= CONVERT(DATETIME,'" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Facturas.Fecha_Factura"
                            DataAdapter = New SqlClient.SqlDataAdapter(SqlSTring, MiConexion)
                            DataAdapter.Fill(DataSet, "UltimoCosto")
                            If DataSet.Tables("UltimoCosto").Rows.Count <> 0 Then
                                Registros = DataSet.Tables("UltimoCosto").Rows.Count
                                PrecioCosto = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_Unitario")
                                PrecioCostoDolar = DataSet.Tables("UltimoCosto").Rows(Registros - 1)("Costo_UnitarioDolar")
                            End If
                            DataSet.Tables("UltimoCosto").Reset()

                        End If
                    End If


                    If TipoSalida = "Transferencia Enviada" Then
                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA ENTRADA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Compras] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Compra = '" & NumeroFactura & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    ElseIf TipoSalida = "Salida Bodega" Then
                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        'StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioUnitario) & "' WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Salida Bodega') AND (Cod_Producto = '" & CodProductos & "')"
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Unitario] = '" & Math.Abs(PrecioCosto) & "',[Precio_Neto] = '" & Math.Abs(PrecioCosto) & "',[Importe] = '" & Math.Abs(PrecioCosto * Cantidad) & "'  WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = 'Salida Bodega') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    Else

                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////ACTUALIZO EL COSTO DE LA SALIDA/////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////
                        StrSQLUpdate = "UPDATE [Detalle_Facturas] SET [Costo_Unitario] = '" & Math.Abs(PrecioCosto) & "' WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaCompra, "yyyy-MM-dd") & "', 102)) AND (Tipo_Factura = '" & TipoSalida & "') AND (Cod_Producto = '" & CodProductos & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If

                    iPosicionFila3 = iPosicionFila3 + 1
                    Me.ProgressBar4.Value = iPosicionFila3
                Loop
                DataSet.Tables("Salidas").Reset()


                'iPosicionFila2 = iPosicionFila2 + 1
                'Me.ProgressBar4.Value = iPosicionFila2
                'Loop

                DataSet.Tables("Bodegas").Reset()


                iPosicionFila = iPosicionFila + 1
                Me.ProgressBar5.Value = iPosicionFila
            Loop

            'DataSet.Tables("ListaProductos").Reset()

        End If



    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoInicio.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoFin.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim NumeroFactura As String = "", TipoSalida As String = ""
        Dim DataSet As New DataSet, iPosicionFila2 As Double = 0, iPosicionFila3 As Double = 0
        Dim DataAdapter As New SqlClient.SqlDataAdapter, ComandoUpdate As New SqlClient.SqlCommand
        Dim Contador As Double = 0, j As Double = 0, iResultado As Integer
        Dim Cantidad As Double = 0, SQlUpdate As String




        '-------------------------------ACTUALIZO LAS COMPRAS ----------------------------------------------
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_Compras]  SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "'  WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '-------------------------------ACTUALIZO LAS COMRPA ----------------------------------------------
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_ComprasSeries]  SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "' WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '-------------------------------ACTUALIZO LAS COMRPA ----------------------------------------------
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_Ensamble] SET [CodProducto] = '" & Me.TxtCodigoFin.Text & "' WHERE (CodProducto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_Facturas]  SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "' WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_FacturasSeries]  SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "' WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_Liquidacion]   SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "' WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SQlUpdate = "UPDATE [Detalle_Plantilla] SET [Cod_Producto] = '" & Me.TxtCodigoFin.Text & "' WHERE (Cod_Producto = '" & Me.TxtCodigoInicio.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()




        If Me.ChkEliminarOrigen.Checked = True Then

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SQlUpdate = "DELETE FROM [DetalleBodegas] WHERE (Cod_Productos = '" & Me.TxtCodigoInicio.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SQlUpdate = "DELETE FROM [Productos] WHERE (Cod_Productos = '" & Me.TxtCodigoInicio.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            MsgBox("Se necesita Ajustar los Costos", MsgBoxStyle.Exclamation, "Zeus Facturacion")

            Me.TxtDesdeCosto.Text = Me.TxtCodigoInicio.Text
            Me.TxtHastaCosto.Text = Me.TxtCodigoInicio.Text

            Me.TabControl1.SelectedTab = Me.TabPage5

        End If

        MsgBox("Se necesita Ajustar los Costos para cada Producto", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        Me.TxtDesdeCosto.Text = Me.TxtCodigoInicio.Text
        Me.TxtHastaCosto.Text = Me.TxtCodigoInicio.Text

        Me.TabControl1.SelectedTab = Me.TabPage5




    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        My.Forms.FrmProcesar.ShowDialog()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.OptCuentasCobrarRe.Checked = True Then
        '    Quien = "CodigoCliente"
        '    My.Forms.FrmConsultas.ShowDialog()
        '    Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        'ElseIf Me.OptCuentasPagarRe.Checked = True Then
        '    Quien = "CuentaPagar"
        '    My.Forms.FrmConsultas.ShowDialog()
        '    Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        'End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.OptCuentasCobrarRe.Checked = True Then
        '    Quien = "CuentaCobrar"
        '    My.Forms.FrmConsultas.ShowDialog()
        '    Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        'ElseIf Me.OptCuentasPagarRe.Checked = True Then
        '    Quien = "CuentaPagar"
        '    My.Forms.FrmConsultas.ShowDialog()
        '    Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        'End If
    End Sub

    Private Sub BtnRebalorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim SqlProductos As String
        'Dim DataAdapter As New SqlClient.SqlDataAdapter, Dataset As New DataSet
        'Dim iPosicionFila As Double, CodCuenta As String, DescripcionCuenta As String
        'Dim SQLClientes As String, CodCuentaCosto As String = 0, CodCuentaVentas As String = 0, CodLinea As String = 0, CodIva As String = 0
        'Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        'Dim CodBodega As String = "", NombreCliente As String = "", ApellidoCliente As String = "", DireccionCliente As String = "-", TelefonoCliente As String = "505"
        'Dim RUCCliente As String = "-"

        'If Me.OptCuentasCobrarRe.Checked = True Then
        '    SqlProductos = "SELECT *  FROM Clientes WHERE (Cod_Cliente BETWEEN '" & Me.TxtRebalorizaDesde.Text & "' AND '" & Me.TxtRebalorizarHasta.Text & "')"
        'ElseIf Me.OptCuentasPagarRe.Checked = True Then
        '    SqlProductos = "SELECT *  FROM Proveedor WHERE (Cod_Proveedor BETWEEN '" & Me.TxtRebalorizaDesde.Text & "' AND '" & Me.TxtRebalorizarHasta.Text & "')"
        'End If
        'MiConexion.Open()

        'DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        'Dataset.Reset()
        'DataAdapter.Fill(Dataset, "Consultas")
        'If Not Dataset.Tables("Consultas").Rows.Count = 0 Then
        '    iPosicionFila = 0
        '    Me.ProgressBar.Minimum = 0
        '    Me.ProgressBar.Visible = True
        '    Me.ProgressBar.Value = 0
        '    Me.ProgressBar.Maximum = Dataset.Tables("Consultas").Rows.Count


        '    Do While iPosicionFila < (Dataset.Tables("Consultas").Rows.Count)
        '        My.Application.DoEvents()


        '        CodCuenta = Dataset.Tables("Consultas").Rows(iPosicionFila)("Cod_Cliente")


        '        MiConexion.Close()

        '        If Me.OptCuentasCobrarRe.Checked = True Then

        '        ElseIf Me.OptCuentasPagarRe.Checked = True Then

        '        End If

        '        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '        '////////////////////////////////////////LIMPIO LAS VARIABLES //////////////////////////////////////////////////////////
        '        NombreCliente = ""
        '        ApellidoCliente = ""
        '        DireccionCliente = "-"
        '        TelefonoCliente = "505"
        '        RUCCliente = "-"

        '        iPosicionFila = iPosicionFila + 1
        '        Me.ProgressBar.Value = iPosicionFila
        '    Loop
        'End If
    End Sub

    Private Sub OptClientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptClientes.CheckedChanged
        If Me.OptClientes.Checked = True Then
            Me.LblNumero.Text = "Codigo Clientes"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = False
        End If
    End Sub

    Private Sub OptFacturas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptFacturas.CheckedChanged
        If Me.OptFacturas.Checked = True Then
            Me.LblNumero.Text = "Numero Factura"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = True
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = True
        End If


    End Sub

    Private Sub OptRecibos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRecibos.CheckedChanged

        If Me.OptRecibos.Checked = True Then
            Me.LblNumero.Text = "Numero Recibo"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = True
        End If


    End Sub

    Private Sub OptTransformacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTransformacion.CheckedChanged

        If Me.OptTransformacion.Checked = True Then
            Me.LblNumero.Text = "Numero Transformacion"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = True
        End If

    End Sub

    Private Sub OptPagos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptPagos.CheckedChanged

        If Me.OptPagos.Checked = True Then
            Me.LblNumero.Text = "Numero Pago Proveedores"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = True
        End If
    End Sub

    Private Sub OptCompras_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCompras.CheckedChanged

        If Me.OptCompras.Checked = True Then
            Me.LblNumero.Text = "Numero Compra"
            Me.BtnEliminar.Enabled = True
            Me.BtnActivar.Enabled = True
            Me.BtnModificar.Enabled = True
            Me.BtnAnular.Enabled = True
        End If
    End Sub

    Private Sub Button22_Click_1(sender As Object, e As EventArgs) Handles Button22.Click
        If Me.OptCordobas.Checked = True Then
            FrmAjustarTodos.OptCordobas.Checked = True
        Else
            FrmAjustarTodos.OptDolares.Checked = True
        End If

        FrmAjustarTodos.DTPFechaFin.Value = Format(Now, "dd/MM/yyyy")
        FrmAjustarTodos.ShowDialog()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim DataSet As New DataSet, SqlString As String = ""
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim Cont As Double = 0, i As Double = 0, NumeroFactura As String = "", FechaNota As Date
        Dim CodClienteFactura As String = "", CodClienteNota As String, TipoNota As String = ""
        Dim NombreCliente As String = "", StrSQLUpdate As String, NumeroNota As String, Moneda As String = "", Observaciones As String, Descripcion As String = "", Monto As Double = 0
        Dim ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer

        SqlString = "SELECT  Detalle_Nota.id_Detalle_Nota, IndiceNota.Numero_Nota AS NUMERONOTAIndice, Detalle_Nota.Numero_Nota, IndiceNota.Fecha_Nota AS FECHANOTAIndice, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, IndiceNota.Cod_Cliente, IndiceNota.Tipo_Nota AS Tipo_NotaIndice, Facturas.Cod_Cliente AS Cod_ClienteFactura, Facturas.Fecha_Factura, Facturas.Nombre_Cliente, IndiceNota.MonedaNota, IndiceNota.Nombre_Cliente, IndiceNota.Observaciones FROM  Detalle_Nota INNER JOIN  IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota <> IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN Facturas ON Detalle_Nota.Numero_Factura = Facturas.Numero_Factura  WHERE (IndiceNota.Tipo_Nota <> N'008') AND (Detalle_Nota.Descripcion <> N'*******ANULADO*******') AND (IndiceNota.Nombre_Cliente <> N'*******ANULADO*******') ORDER BY NUMERONOTAIndice, Tipo_NotaIndice"
        'SqlString = "SELECT Detalle_Nota.id_Detalle_Nota, IndiceNota.Numero_Nota AS NUMERONOTAIndice, Detalle_Nota.Numero_Nota, IndiceNota.Fecha_Nota AS FECHANOTAIndice, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, IndiceNota.Cod_Cliente, IndiceNota.Tipo_Nota AS Tipo_NotaIndice, Facturas.Cod_Cliente AS Cod_ClienteFactura, Facturas.Fecha_Factura, Facturas.Nombre_Cliente, IndiceNota.MonedaNota, IndiceNota.Nombre_Cliente AS Expr1, IndiceNota.Observaciones FROM Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota <> IndiceNota.Fecha_Nota INNER JOIN Facturas ON Detalle_Nota.Numero_Factura = Facturas.Numero_Factura  ORDER BY NUMERONOTAIndice"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        Cont = DataSet.Tables("Notas").Rows.Count
        i = 0
        Me.ProgressBarFactura.Value = 0
        Me.ProgressBarFactura.Minimum = 0
        Me.ProgressBarFactura.Maximum = Cont
        Me.ProgressBarFactura.Visible = True

        Do While Cont > i
            My.Application.DoEvents()
            NumeroFactura = DataSet.Tables("Notas").Rows(i)("Numero_Factura")
            CodClienteNota = DataSet.Tables("Notas").Rows(i)("Cod_Cliente")
            CodClienteFactura = DataSet.Tables("Notas").Rows(i)("Cod_ClienteFactura")
            FechaNota = DataSet.Tables("Notas").Rows(i)("Fecha_Nota")
            TipoNota = DataSet.Tables("Notas").Rows(i)("Tipo_Nota")
            NombreCliente = DataSet.Tables("Notas").Rows(i)("Nombre_Cliente")
            NumeroNota = DataSet.Tables("Notas").Rows(i)("Numero_Nota")
            Moneda = DataSet.Tables("Notas").Rows(i)("MonedaNota")
            Observaciones = DataSet.Tables("Notas").Rows(i)("Observaciones")
            Descripcion = DataSet.Tables("Notas").Rows(i)("Descripcion")
            Monto = DataSet.Tables("Notas").Rows(i)("Monto")

            Me.Text = "Procesando Nota: " & NumeroNota

            '////////////////Actualizo el indice ////////////////////
            '///////////BORRO INDICE NOTA ////////////////
            StrSQLUpdate = "DELETE FROM [dbo].[IndiceNota]  WHERE (Numero_Nota = '" & NumeroNota & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '//////////////BORRO EL DETALLE NOTA //////////////
            StrSQLUpdate = "DELETE FROM [dbo].[Detalle_Nota]  WHERE (Numero_Nota = '" & NumeroNota & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            GrabaNotaDebito(NumeroNota, FechaNota, TipoNota, "1111", Moneda, CodClienteFactura, NombreCliente, Observaciones, True, False, False)
            GrabaDetalleNotaDebito(NumeroNota, FechaNota, TipoNota, Descripcion, NumeroFactura, Monto)


            Me.ProgressBarFactura.Value = ProgressBarFactura.Value + 1
            i = i + 1
        Loop





    End Sub
End Class