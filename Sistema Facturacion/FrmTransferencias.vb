Imports System.Data.Common
Imports System.Data.SqlTypes

Public Class FrmTransferencias
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CantidadAnterior As Double, PrecioAnterior As Double, NumeroEnsamble As String, NumeroTranferencia As String = "-----0-----", CodBodega1 As String, CodBodega2 As String, FechaTransferencia As Date, FacturaTarea As Boolean = False
    Public NumeroLote As String = "SINLOTE", FechaLote As Date = "01/01/1900"
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
    Public Sub Limpiar_Pantalla()
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Procesado As Boolean = True, SqlDatos As String

        If FacturaTarea = True Then

            Procesado = False
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"


        Else

            Procesado = False
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        End If
    End Sub




    Private Sub FrmTransferencias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Transferencia de Bodegas")
    End Sub

    Private Sub FrmTransferencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Procesado As Boolean = True, SqlDatos As String


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            FacturaTarea = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If

        If FacturaTarea = True Then
            Me.Size = New Size(776, 552)
            Me.TrueDBGridComponentes.Size = New Size(736, 193)
            Me.Button8.Location = New Point(673, 443)
            Me.TxtTotalCosto.Location = New Point(648, 413)
            Me.Label5.Location = New Point(530, 417)
            Me.GroupBox1.Size = New Size(742, 50)
            Me.GroupBox2.Size = New Size(742, 50)
            Me.TxtNumeroEnsamble.Location = New Point(600, 16)
            Me.Label3.Location = New Point(555, 19)
            Me.Button6.Location = New Point(699, 12)

        End If



        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
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

        If NumeroTranferencia <> "-----0-----" Then
            Me.CboCodigoBodega.Text = FrmTransferenciaListado.TrueDBGridConsultas.Columns(4).Text
            Me.CboCodigoBodega2.Text = FrmTransferenciaListado.TrueDBGridConsultas.Columns(5).Text
            Me.DTPFecha.Value = FechaTransferencia
            Me.TxtNumeroEnsamble.Text = NumeroTranferencia


            Procesado = FrmTransferenciaListado.TrueDBGridConsultas.Columns("Importe").Text
        ElseIf FacturaTarea = True Then

            Procesado = False
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"


        Else

            Procesado = False
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        End If



        If Procesado = True Then
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = False
            Me.Button4.Enabled = False
            Me.CboCodigoBodega.Enabled = False
            Me.CboCodigoBodega2.Enabled = False
        Else
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Enabled = True
            Me.Button4.Enabled = True
            Me.CboCodigoBodega.Enabled = True
            Me.CboCodigoBodega2.Enabled = True
        End If

        If UsuarioBodega <> "Ninguna" Then
            If Acceso = "Administrador" Then
                If NumeroTranferencia = "-----0-----" Then
                    Me.CboCodigoBodega.Text = UsuarioBodega
                    Me.CboCodigoBodega.Enabled = True
                End If
            ElseIf NumeroTranferencia = "-----0-----" Then
                Me.CboCodigoBodega.Text = UsuarioBodega
                'Me.CboCodigoBodega.Enabled = False

            End If

        End If

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String, Cantidad As Double, PrecioCompra As Double, Descuento As Double, FOB As Double
        Dim Importe As Double, CodigoBodega As String = ""
        Dim RstCosto As New RstCostoPromedio

        Try


            Select Case Me.TrueDBGridComponentes.Col

                Case 0
                    If Me.TrueDBGridComponentes.Columns("Cod_Productos").Text = "" Then
                        Exit Sub
                    Else
                        CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text
                        CodigoBodega = Me.CboCodigoBodega.Text
                        SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, DetalleBodegas.Costo, DetalleBodegas.Existencia_Unidades, Productos.Cod_Iva FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos  " &
                                    "WHERE (Productos.Tipo_Producto <> 'Ensambles') AND (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Cod_Productos = '" & CodProducto & "') ORDER BY Productos.Cod_Productos"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count <> 0 Then
                            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")

                            RstCosto = CostoPromedioKardex(CodProducto, Me.DTPFecha.Value)
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = RstCosto.Costo_Cordoba

                        Else
                            MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Quien = "CodigoProductosDetalle"
                            My.Forms.FrmConsultas.ShowDialog()
                            Me.TrueDBGridComponentes.Columns("Cod_Productos").Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                            'Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                            RstCosto = CostoPromedioKardex(My.Forms.FrmConsultas.Codigo, Me.DTPFecha.Value)
                            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = RstCosto.Costo_Cordoba
                        End If
                    End If
                Case 2
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Descuento").Text) <> 0 Then
                        Descuento = Me.TrueDBGridComponentes.Columns("Descuento").Text
                    End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(FOB, "##,##0.00")

                    Importe = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Importe, "##,##0.00")

                Case 3
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Descuento").Text) <> 0 Then
                        Descuento = Me.TrueDBGridComponentes.Columns("Descuento").Text
                    End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(FOB, "##,##0.00")

                    Importe = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Importe, "##,##0.00")

                Case 4
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Descuento").Text) <> 0 Then
                        Descuento = Me.TrueDBGridComponentes.Columns("Descuento").Text
                    End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Text = Format(FOB, "##,##0.00")

                    Importe = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("Importe").Text = Format(Importe, "##,##0.00")

            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate
        Me.CboCodigoBodega.Enabled = False
        Me.CboCodigoBodega2.Enabled = False
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoProducto As String
        Dim PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim Registros As Double, iPosicion As Double, PrecioCompra As Double, IposicionFila As Double


        Registros = Me.BindingDetalle.Count
        iPosicion = Me.BindingDetalle.Position


        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        If IsNumeric(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////SUMO LOS TOTALES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        PrecioCompra = 0
        IposicionFila = 0

        Do While IposicionFila < Registros
            My.Application.DoEvents()
            If Not IsDBNull(Me.BindingDetalle.Item(IposicionFila)("Precio_Neto")) Then
                PrecioCompra = PrecioCompra + Me.BindingDetalle.Item(IposicionFila)("Precio_Neto")
            End If

            Me.TxtTotalCosto.Text = Format(PrecioCompra, "##,##0.00")
            IposicionFila = IposicionFila + 1
        Loop

        CodigoProducto = 0
        PrecioUnitario = 0
        Descuento = 0
        PrecioNeto = 0
        Importe = 0
        Cantidad = 0

        Me.TrueDBGridComponentes.Col = 0


        Me.CboCodigoBodega.Enabled = False
        Me.CboCodigoBodega2.Enabled = False


    End Sub

    Private Sub TrueDBGridComponentes_BeforeClose(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeClose

    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double
        Dim SqlString As String = "", CodigoBodega As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try


            Cols = e.ColIndex
            Select Case Cols
                Case 2
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                    End If


                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                        iPosicion = Me.BindingDetalle.Position
                        CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                    Else
                        CantidadAnterior = 0
                    End If
                Case 3
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text) Then
                        Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = 0
                    End If


                    If Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text <> "" Then
                        iPosicion = Me.BindingDetalle.Position
                        PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                    Else
                        PrecioAnterior = 0
                    End If
            End Select




        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim SqlString As String = "", CodigoBodega As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Cantidad As Double, iPosicion As Double = 0, Existencia As Double, CodigoProducto As String

        Select Case e.ColIndex

            Case 2
                iPosicion = Me.BindingDetalle.Position
                Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                CodigoBodega = Me.CboCodigoBodega.Text
                CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text
                'SqlString = "SELECT  Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, DetalleBodegas.Costo, DetalleBodegas.Existencia, Productos.Cod_Iva FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos " & _
                '            "WHERE (Productos.Tipo_Producto <> 'Ensambles') AND (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Cod_Productos = '" & CodigoProducto & "') ORDER BY Productos.Cod_Productos"
                ''DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "Productos")
                'If DataSet.Tables("Productos").Rows.Count <> 0 Then
                '    Existencia = DataSet.Tables("Productos").Rows(0)("Existencia")
                'End If

                'Existencia = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
                Existencia = BuscaInventarioInicialBodega(CodigoProducto, DateAdd(DateInterval.Day, 1, Me.DTPFecha.Value), CodigoBodega)

                DataSet.Reset()

                If Cantidad > Existencia Then
                    MsgBox("No puede transferir mas de lo que existe en Bodega EXISTENCIA " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                    If Existencia > 0 Then
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                    Else
                        Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                    End If
                End If
        End Select
    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim RstCosto As New RstCostoPromedio

        If e.ColIndex = 0 Then
            Quien = "CodigoProductosDetalle"
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.TrueDBGridComponentes.Columns("Cod_Productos").Text = My.Forms.FrmConsultas.Codigo
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                'Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                RstCosto = CostoPromedioKardex(My.Forms.FrmConsultas.Codigo, Me.DTPFecha.Value)
                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = RstCosto.Costo_Cordoba

            Else

                Me.TrueDBGridComponentes.Columns("Cod_Productos").Text = ""
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = ""
                Me.TrueDBGridComponentes.Columns("Cantidad").Text = ""

            End If

        ElseIf e.ColIndex = 8 Then

            If FacturaTarea = True Then
                Quien = "CodigoTarea"
                'My.Forms.FrmConsultas.ShowDialog()

                Dim Posicion As Double
                If Me.BindingDetalle.Count <> 0 Then
                    My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                    Posicion = Me.BindingDetalle.Position
                    My.Forms.FrmLotesFactura.CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text    'Me.BindingDetalle.Item(Posicion)("Cod_Productos")
                    My.Forms.FrmLotesFactura.NombreProducto = Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text   'Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                    My.Forms.FrmLotesFactura.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                    My.Forms.FrmLotesFactura.Fecha = Me.DTPFecha.Value
                    My.Forms.FrmLotesFactura.LblProducto.Text = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text + " " + Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text
                    If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then    'Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                        My.Forms.FrmLotesFactura.Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    Else
                        My.Forms.FrmLotesFactura.Cantidad = 1
                    End If
                    My.Forms.FrmLotesFactura.LblCantidad.Text = Me.TrueDBGridComponentes.Columns("Cantidad").Text  'Me.BindingDetalle.Item(Posicion)("Cantidad")
                    My.Forms.FrmLotesFactura.CodigoBodega = Me.CboCodigoBodega.Text
                    My.Forms.FrmLotesFactura.TipoDocumento = Me.CboTipoProducto.Text
                    My.Forms.FrmLotesFactura.ShowDialog()
                End If




                'If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
                '    Exit Sub
                'End If
                Me.TrueDBGridComponentes.Columns("CodTarea").Text = My.Forms.FrmLotesFactura.NLotes
            End If

        End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "NumeroFacturas" Then
            Exit Sub
        End If

        DataSet.Reset()

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT  * FROM Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "')  AND (Activo = 1)"

            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If Not DataSet.Tables("Facturas").Rows.Count = 0 Then
                '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////

                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Observaciones")) Then
                    Me.TxtObservaciones.Text = DataSet.Tables("Facturas").Rows(0)("Observaciones")
                End If
                Me.TxtTotalCosto.Text = DataSet.Tables("Facturas").Rows(0)("SubTotal")
                Me.CboCodigoBodega.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Bodega")
                Me.CboCodigoBodega2.Text = DataSet.Tables("Facturas").Rows(0)("Nuestra_Referencia")


                If FacturaTarea = True Then

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlCompras = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " &
                                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleFactura")
                    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                    Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"



                Else

                    '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                    SqlCompras = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleFactura")
                    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
                    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
                    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim ConsecutivoFactura As Double, NumeroFactura As String
        Dim iPosicion As Double, Registros As Double
        Dim Monto As Double, CodTarea As String = Nothing
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim Descripcion_Producto As String, IdDetalle As Double = -1, SqlConsecutivo As String, FacturaBodega As Boolean = False, CompraBodega As Boolean = False
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.CboCodigoBodega.Text = Me.CboCodigoBodega2.Text Then
            MsgBox("Es neceario que las Bodegas sean distintas", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case Me.CboTipoProducto.Text
                Case "Transferencia Enviada"
                    ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
            End Select

            '/////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////
            SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
            DataAdapter.Fill(DataSet, "Configuracion")
            If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) = True Then
                    FacturaBodega = True
                End If

                If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) = True Then
                    CompraBodega = True
                End If

            End If

            If FacturaBodega = True Then
                NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
            Else
                NumeroFactura = Format(ConsecutivoFactura, "0000#")
            End If
        Else
            'ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            'NumeroFactura = Format(ConsecutivoFactura, "0000#")
            NumeroFactura = Me.TxtNumeroEnsamble.Text
        End If




        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE TRANSFERENCIA SALIDA Y ENTRADA/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaTransferenciasSalida(NumeroFactura, Me.DTPFecha.Value, "Transferencia Enviada", Me.CboCodigoBodega.Text, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text)
        GrabaTransferenciasEntrada(NumeroFactura, Me.DTPFecha.Value, "Transferencia Recibida", Me.CboCodigoBodega2.Text, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text)


        Registros = Me.BindingDetalle.Count
        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        Monto = 0
        Do While iPosicion < Registros

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            Else
                IdDetalle = -1
            End If

            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
            Else
                PrecioUnitario = 0
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
            Else
                PrecioNeto = 0
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
            Else
                Importe = 0
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
            Else
                Cantidad = 0
            End If

            If FacturaTarea = True Then
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
                    NumeroLote = Me.BindingDetalle.Item(iPosicion)("CodTarea")
                Else
                    NumeroLote = "SINLOTE"
                End If
                'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")) Then
                '    FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")
                'Else
                '    FechaLote = "01/01/1900"
                'End If
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
            Else
                Descripcion_Producto = ""
            End If

            If CodigoProducto <> "" Then
                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
                GrabaDetalleTransferenciaSalida(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Me.DTPFecha.Value, "Transferencia Enviada", NumeroLote)
                If IdDetalle = -1 Then
                    '//////////////////busco el id detalle nuevo cuando se graba una linea nueva de las transferencia ///////////////
                    IdDetalle = BuscaProductoIdFactura(NumeroFactura, Me.DTPFecha.Value, "Transferencia Enviada", CodigoProducto, Cantidad)
                End If
                GrabaDetalleTransferenciaEntrada(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Me.DTPFecha.Value, "Transferencia Recibida", NumeroLote)

            Else
                Me.BindingDetalle.RemoveCurrent()
            End If

            iPosicion = iPosicion + 1
        Loop

        Me.TxtNumeroEnsamble.Text = NumeroFactura

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Me.CboCodigoBodega.Enabled = False
            Me.CboCodigoBodega2.Enabled = False
        Else
            Me.CboCodigoBodega.Enabled = True
            Me.CboCodigoBodega2.Enabled = True
        End If
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.TxtNumeroEnsamble.Text = "-----0-----"

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
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



        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DetalleFactura")
        'Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        'Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        'Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
        'Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
        'Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
        'Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
        'Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
        'Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
        'Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        Limpiar_Pantalla()


        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Me.CboCodigoBodega.Enabled = False
            Me.CboCodigoBodega2.Enabled = False
        Else
            Me.CboCodigoBodega.Enabled = True
            Me.CboCodigoBodega2.Enabled = True
        End If

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Existencia As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, StrSQLUpdate As String = ""
        Dim SQlProductos As String = "", iPosicionFila As Double = 0

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Transferencia?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA FACTURA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Facturas]  SET [Activo] = 'False',[Cancelado] = 'True',[Nombre_Cliente] = '******CANCELADO',[Apellido_Cliente] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " &
                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        SqlCompras = "UPDATE [Detalle_Facturas]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0,[Costo_Unitario] = 0 " &
                     "WHERE  (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = 'Transferencia Enviada') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Elimino la Transferencia: " & Me.TxtNumeroEnsamble.Text)


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Compras]  SET [Activo] = 'False',[Nombre_Proveedor] = '******CANCELADO',[Apellido_Proveedor] = '******',[SubTotal]=0,[IVA]=0,[Pagado]=0,[NetoPagar]=0 " &
                     "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        SqlCompras = "UPDATE [Detalle_Compras]  SET [Cantidad] = 0,[Precio_Unitario] = 0,[Descuento] = 0,[Precio_Neto] = 0 ,[Importe] = 0 " &
                     "WHERE  (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Compra = 'Transferencia Recibida') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////ACTUALIZO LAS BODEGAS /////////////////////////////////////
        '///////////////////////////////////////////////////////DESPUS DE ELIMINAR /////////////////////////////////////////


        Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Eliminar la Transferencia: " & Me.TxtNumeroEnsamble.Text)



        Dim Sql As String = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega AS BodegaOrigen, Bodegas_1.Nombre_Bodega AS BodegaDestino, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Facturas.TransferenciaProcesada,Facturas.Cancelado FROM Facturas INNER JOIN Bodegas ON Facturas.Su_Referencia = Bodegas.Cod_Bodega INNER JOIN Bodegas AS Bodegas_1 ON Facturas.Nuestra_Referencia = Bodegas_1.Cod_Bodega  " &
                            "WHERE (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Facturas.Numero_Factura"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Transferencias")
        FrmTransferenciaListado.TrueDBGridConsultas.DataSource = DataSet.Tables("Transferencias")
        FrmTransferenciaListado.TrueDBGridConsultas.Columns(0).Caption = "No.Transferencia"
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 91
        FrmTransferenciaListado.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 79
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 140
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 140
        FrmTransferenciaListado.TrueDBGridConsultas.Columns(4).Caption = "Cod Origen"
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 75
        FrmTransferenciaListado.TrueDBGridConsultas.Columns(5).Caption = "Cod Destino"
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 75
        FrmTransferenciaListado.TrueDBGridConsultas.Columns(6).Caption = "Procesado"
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 75
        FrmTransferenciaListado.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 75

        MsgBox("PROCESO TERMINADO", MsgBoxStyle.Exclamation, "Zeus Facturacion")


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Transferencias"
        My.Forms.FrmConsultas.ShowDialog()
        Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
        Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
        'Me.CboCodigoBodega.Enabled = False
        'Me.CboCodigoBodega2.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim RutaLogo As String, SqlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SQLTransferencias As String
        Dim SqlDatos As String, Fecha As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim ArepFacturas As New ArepFacturas
        Dim ArepTransferencias As New ArepTransferencias


        '////////////////////////////////EJECUTO EL BOTON GRABAR ///////////////////////////////////////////////////
        CmdGrabar_Click(sender, e)


        '//////////////////////////////////BUSCO LOS DATOS DE LA EMPRESA PARA IMPRIMIRLOS///////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepTransferencias.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepTransferencias.LblRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
            ArepTransferencias.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepTransferencias.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")



            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepTransferencias.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                ArepTransferencias.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepTransferencias.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepTransferencias.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        ArepTransferencias.LblBodegaOrigen.Text = Me.CboCodigoBodega.Columns(1).Text
        ArepTransferencias.LblBodegaDestino.Text = Me.CboCodigoBodega2.Columns(1).Text
        ArepTransferencias.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepTransferencias.LblFechaOrden.Text = Me.DTPFecha.Value
        ArepTransferencias.TxtObservaciones.Text = Me.TxtObservaciones.Text

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////"

        If FacturaTarea = True Then
            SQLTransferencias = "SELECT Detalle_Facturas.CodTarea As Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe,Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"

        Else
            SQLTransferencias = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe,Productos.Unidad_Medida FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & Me.CboTipoProducto.Text & "')"
        End If


        SQL.ConnectionString = Conexion
        SQL.SQL = SQLTransferencias
        ArepTransferencias.DataSource = SQL

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepTransferencias.Document

        ArepTransferencias.Run(False)
        ViewerForm.ShowDialog()

        Me.TxtNumeroEnsamble.Text = "----0-----"

        If FacturaTarea = True Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.CodTarea As Lote FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Lote").Button = True

        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleFactura")
            Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        End If

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Me.CboCodigoBodega.Enabled = False
            Me.CboCodigoBodega2.Enabled = False
        Else
            Me.CboCodigoBodega.Enabled = True
            Me.CboCodigoBodega2.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim SqlString As String, idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, DiferenciaCantidad As Double, DiferenciaPrecio As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        FechaFactura = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        CodProducto = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text
        iPosicion = Me.BindingDetalle.Position
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
        Else
            idDetalle = -1
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
            PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
            PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        End If
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
            Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        End If

        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
            Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        End If
        NombreProducto = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

        Me.BindingDetalle.RemoveCurrent()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA FACTURA///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT * FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "')  AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Factura = '" & idDetalle & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = " DELETE FROM Detalle_Facturas WHERE (Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Factura = '" & idDetalle & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Select Case Me.CboTipoProducto.Text
                Case "Transferencia Enviada"
                    DiferenciaCantidad = CDbl(CantidadAnterior) - CDbl(Cantidad)
                    DiferenciaPrecio = CDbl(PrecioNeto) - CDbl(PrecioAnterior)
                    ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                Case "Transferencia Recibida"
                    DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                    ExistenciasCostos(CodProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
            End Select
        End If

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA FACTURA///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT * FROM Detalle_Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (id_Detalle_Transferencia = '" & idDetalle & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = " DELETE FROM Detalle_Compras WHERE (Numero_Compra = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Compra = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (id_Detalle_Transferencia = '" & idDetalle & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If


    End Sub

    Private Sub TrueDBGridComponentes_ContextMenuStripChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.ContextMenuStripChanged

    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Dim Posicion As Double
        If Me.BindingDetalle.Count <> 0 Then
            My.Forms.FrmSeries.Tipo = Me.CboTipoProducto.Text
            Posicion = Me.BindingDetalle.Position
            My.Forms.FrmSeries.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Productos")
            My.Forms.FrmSeries.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.Numero = Me.TxtNumeroEnsamble.Text
            My.Forms.FrmSeries.Fecha = Me.DTPFecha.Value
            My.Forms.FrmSeries.Text = Me.BindingDetalle.Item(Posicion)("Cod_Productos") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmSeries.ShowDialog()
        End If
    End Sub

    Private Sub C1Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        Dim Posicion As Double
        If Me.BindingDetalle.Count <> 0 Then
            My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
            Posicion = Me.BindingDetalle.Position
            My.Forms.FrmLotesFactura.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Productos")
            My.Forms.FrmLotesFactura.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            My.Forms.FrmLotesFactura.NumeroDocumento = Me.TxtNumeroEnsamble.Text
            My.Forms.FrmLotesFactura.Fecha = Me.DTPFecha.Value
            My.Forms.FrmLotesFactura.LblProducto.Text = Me.BindingDetalle.Item(Posicion)("Cod_Productos") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
            If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                My.Forms.FrmLotesFactura.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
            Else
                My.Forms.FrmLotesFactura.Cantidad = 1
            End If
            My.Forms.FrmLotesFactura.LblCantidad.Text = Me.BindingDetalle.Item(Posicion)("Cantidad")
            My.Forms.FrmLotesFactura.CodigoBodega = Me.CboCodigoBodega.Text
            My.Forms.FrmLotesFactura.TipoDocumento = Me.CboTipoProducto.Text
            My.Forms.FrmLotesFactura.ShowDialog()
        End If
    End Sub

    Private Sub CboCodigoBodega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoBodega.TextChanged

    End Sub
End Class