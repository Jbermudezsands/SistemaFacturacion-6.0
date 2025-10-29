Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Web.UI.WebControls
Imports C1.Win.C1TrueDBGrid

Public Class FrmTransferencias
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CantidadAnterior As Double, PrecioAnterior As Double, NumeroEnsamble As String, NumeroTranferencia As String = "-----0-----", CodBodega1 As String, CodBodega2 As String, FechaTransferencia As Date, FacturaTarea As Boolean = False
    Public NumeroLote As String = "SINLOTE", FechaLote As Date = "01/01/1900"
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public dsCompra As New DataSet, daCompra As New SqlClient.SqlDataAdapter, CmdBuilderCompra As New SqlCommandBuilder
    Public WithEvents backgroundWorkerGrabar As System.ComponentModel.BackgroundWorker
    Private TransferenciaPendiente As Boolean = False

    Private Sub ConfigurarAdaptadorDetalleFactura(ByVal cnn As SqlConnection)

        da = New SqlDataAdapter()

        ' === INSERT COMMAND ===
        Dim insertCmd As New SqlCommand("
        INSERT INTO Detalle_Facturas
            (Cod_Producto, Descripcion_Producto, CodTarea, Cantidad, Precio_Unitario,
             Descuento, Precio_Neto, Importe, Numero_Factura, Fecha_Factura, Tipo_Factura)
              
        VALUES
            (@Cod_Producto, @Descripcion, @NumeroLote, @Cantidad, @PrecioUnitario,
             @Descuento, @PrecioNeto, @Importe, @NumeroFactura, @FechaFactura, @TipoFactura);
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS id_Detalle_Factura;", cnn)

        ' === parámetros de entrada ===
        insertCmd.Parameters.Add("@NumeroFactura", SqlDbType.VarChar, 50, "Numero_Factura")
        insertCmd.Parameters.Add("@FechaFactura", SqlDbType.DateTime, 0, "Fecha_Factura")
        insertCmd.Parameters.Add("@TipoFactura", SqlDbType.VarChar, 50, "Tipo_Factura")
        insertCmd.Parameters.Add("@Cod_Producto", SqlDbType.VarChar, 50, "Cod_Producto")
        insertCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200, "Descripcion_Producto")
        insertCmd.Parameters.Add("@NumeroLote", SqlDbType.VarChar, 200, "CodTarea")
        insertCmd.Parameters.Add("@Cantidad", SqlDbType.Decimal, 0, "Cantidad")
        insertCmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal, 0, "Precio_Unitario")
        insertCmd.Parameters.Add("@Descuento", SqlDbType.Decimal, 0, "Descuento")
        insertCmd.Parameters.Add("@PrecioNeto", SqlDbType.Decimal, 0, "Precio_Neto")
        insertCmd.Parameters.Add("@Importe", SqlDbType.Decimal, 0, "Importe")

        da.InsertCommand = insertCmd
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord


        ' === UPDATE COMMAND ===
        Dim updateCmd As New SqlCommand("
        UPDATE Detalle_Facturas
        SET Cod_Producto = @Cod_Producto,
            Descripcion_Producto = @Descripcion,
            CodTarea = @NumeroLote,
            Cantidad = @Cantidad,
            Precio_Unitario = @PrecioUnitario,
            Descuento = @Descuento,
            Precio_Neto = @PrecioNeto,
            Importe = @Importe
        WHERE id_Detalle_Factura = @IdDetalleFactura", cnn)

        updateCmd.Parameters.Add("@Cod_Producto", SqlDbType.VarChar, 50, "Cod_Producto")
        updateCmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200, "Descripcion_Producto")
        updateCmd.Parameters.Add("@Cantidad", SqlDbType.Decimal, 0, "Cantidad")
        updateCmd.Parameters.Add("@NumeroLote", SqlDbType.VarChar, 200, "CodTarea")
        updateCmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal, 0, "Precio_Unitario")
        updateCmd.Parameters.Add("@Descuento", SqlDbType.Decimal, 0, "Descuento")
        updateCmd.Parameters.Add("@PrecioNeto", SqlDbType.Decimal, 0, "Precio_Neto")
        updateCmd.Parameters.Add("@Importe", SqlDbType.Decimal, 0, "Importe")
        updateCmd.Parameters.Add("@IdDetalleFactura", SqlDbType.Int, 0, "id_Detalle_Factura")

        da.UpdateCommand = updateCmd

        ' === DELETE COMMAND ===
        Dim deleteCmd As New SqlCommand("
        DELETE FROM Detalle_Facturas
        WHERE id_Detalle_Factura = @IdDetalleFactura", cnn)

        deleteCmd.Parameters.Add("@IdDetalleFactura", SqlDbType.Int, 0, "id_Detalle_Factura")

        da.DeleteCommand = deleteCmd

    End Sub

    Private Sub BloquearControlesDuranteTransferencia(Bloquear As Boolean)
        If Bloquear = True Then
            CmdNuevo.Enabled = False
            Me.ButtonBorrar.Enabled = False
            CboCodigoBodega.Enabled = False
            CboCodigoBodega2.Enabled = False
        Else
            CmdNuevo.Enabled = True
            Me.ButtonBorrar.Enabled = True
            CboCodigoBodega.Enabled = True
            CboCodigoBodega2.Enabled = True
        End If
    End Sub


    '////////////////////////////////////PROCESOS GRABAR COMPRAS CON HILOS //////////////
    Private Sub backgroundWorkerGrabar_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerGrabar.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim dsDetalle As New DataSet
        Dim args As ArgsTransferencias = e.Argument(0), Quien As String = ""

        dsDetalle = e.Argument(1)

        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            GrabarTransferenciasWorker(args, dsDetalle, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerGrabar_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerGrabar.RunWorkerCompleted



        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Transferencias", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Transferencias", "Hilo Cancelado")
        Else
            TransferenciaPendiente = False
            MDIMain.txtSPlano2.Text = ""

        End If

    End Sub
    Private Sub backgroundWorkerGrabar_ProgressChanged(
ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
Handles backgroundWorkerGrabar.ProgressChanged


        MDIMain.txtSPlano2.Text = "Trns:" & e.UserState.ToString


    End Sub
    Private Sub InsertarDetalleFacturaYActualizarDS(fila As DataRow, cnn As SqlConnection)
        Dim sql As String = "
        INSERT INTO Detalle_Facturas
            (Cod_Producto, Descripcion_Producto, CodTarea, Cantidad, Precio_Unitario,
             Descuento, Precio_Neto, Importe, Numero_Factura, Fecha_Factura, Tipo_Factura)
        VALUES
            (@Cod_Producto, @Descripcion, @CodTarea, @Cantidad, @Precio_Unitario,
             @Descuento, @Precio_Neto, @Importe, @Numero_Factura, @Fecha_Factura, @Tipo_Factura);
        SELECT CAST(SCOPE_IDENTITY() AS INT);"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Using cmd As New SqlCommand(sql, cnn)
            cmd.Parameters.AddWithValue("@Cod_Producto", fila("Cod_Producto"))
            cmd.Parameters.AddWithValue("@Descripcion", fila("Descripcion_Producto"))
            cmd.Parameters.AddWithValue("@CodTarea", fila("CodTarea"))
            cmd.Parameters.AddWithValue("@Cantidad", fila("Cantidad"))
            cmd.Parameters.AddWithValue("@Precio_Unitario", fila("Precio_Unitario"))
            cmd.Parameters.AddWithValue("@Descuento", fila("Descuento"))
            cmd.Parameters.AddWithValue("@Precio_Neto", fila("Precio_Neto"))
            cmd.Parameters.AddWithValue("@Importe", fila("Importe"))
            cmd.Parameters.AddWithValue("@Numero_Factura", fila("Numero_Factura"))
            cmd.Parameters.AddWithValue("@Fecha_Factura", fila("Fecha_Factura"))
            cmd.Parameters.AddWithValue("@Tipo_Factura", fila("Tipo_Factura"))

            Dim newId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            fila("Id_Detalle_Factura") = newId
            fila.AcceptChanges()
        End Using
    End Sub

    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable
        Dim iPosicion As Double = Me.TrueDBGridComponentes.Row

        Try
            ' === Validar conexión ===
            If MiConexion Is Nothing Then Throw New Exception("La conexión no ha sido inicializada.")
            If MiConexion.State <> ConnectionState.Open Then MiConexion.Open()

            ' === Buscar filas nuevas ===
            oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Added)

            ' === INSERTAR FILAS NUEVAS ===
            If oTabla IsNot Nothing AndAlso oTabla.Rows.Count > 0 Then

                For Each fila As DataRow In oTabla.Rows
                    Try
                        ' 🔹 Insertar registro y obtener su ID real desde SQL
                        InsertarDetalleFacturaYActualizarDS(fila, MiConexion)

                        ' 🔹 Obtener el ID recién asignado por la función
                        Dim nuevoId As Integer = CInt(fila("Id_Detalle_Factura"))

                        ' 🔹 Buscar la fila correspondiente en el DataSet principal
                        '    (la que todavía no tenía ID asignado)
                        Dim filaOriginal() As DataRow = ds.Tables("DetalleFactura").Select("Id_Detalle_Factura IS NULL OR Id_Detalle_Factura = 0")

                        If filaOriginal.Length > 0 Then
                            filaOriginal(0)("Id_Detalle_Factura") = nuevoId
                            filaOriginal(0).AcceptChanges()
                        End If

                    Catch ex As Exception
                        MsgBox("Error al insertar detalle: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                Next

                ' 🔹 Sincronizar dataset principal y refrescar grid
                ds.Tables("DetalleFactura").AcceptChanges()
                Me.TrueDBGridComponentes.Refresh()
                Me.TrueDBGridComponentes.Row = iPosicion

                ' === SI NO HAY FILAS NUEVAS, BUSCAR MODIFICADAS ===
            Else
                oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Modified)
                If oTabla IsNot Nothing AndAlso oTabla.Rows.Count > 0 Then
                    da.Update(oTabla)
                    ds.Tables("DetalleFactura").AcceptChanges()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error en InsertarRowGrid: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub






    'Public Sub InsertarRowGrid()
    '    Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

    '    iPosicion = Me.TrueDBGridComponentes.Row
    '    CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

    '    CmdBuilder.RefreshSchema()
    '    oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Added)
    '    If Not IsNothing(oTabla) Then
    '        '//////////////////SI  TIENE REGISTROS NUEVOS 
    '        da.Update(oTabla)
    '        ds.Tables("DetalleFactura").AcceptChanges()
    '        da.Update(ds.Tables("DetalleFactura"))

    '        'ActualizarGridInsertRow()

    '        Me.TrueDBGridComponentes.Row = iPosicion

    '    Else
    '        oTabla = ds.Tables("DetalleFactura").GetChanges(DataRowState.Modified)
    '        If Not IsNothing(oTabla) Then
    '            da.Update(oTabla)
    '            ds.Tables("DetalleFactura").AcceptChanges()
    '            da.Update(ds.Tables("DetalleFactura"))
    '        End If
    '    End If

    '    'ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)

    '    AgregarLineaCompraMemoria(CodigoProducto,
    '                      Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Value,
    '                      Me.TrueDBGridComponentes.Columns("Cantidad").Value,
    '                      Me.TrueDBGridComponentes.Columns("Precio_Unitario").Value,
    '                      Me.TrueDBGridComponentes.Columns("Descuento").Value,
    '                      Me.TrueDBGridComponentes.Columns("Precio_Neto").Value,
    '                      Me.TrueDBGridComponentes.Columns("Importe").Value,
    '                      NumeroLote,
    '                      FechaLote, Me.TrueDBGridComponentes.Columns("id_Detalle_Compra").Value)

    '    ' Luego, actualizar el dataset de compras contra la base
    '    InsertarRowGridCompra()


    'End Sub


    Public Sub InsertarRowGridCompra()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        Try

            iPosicion = Me.TrueDBGridComponentes.Row
            CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

            CmdBuilder.RefreshSchema()
            oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Added)
            If Not IsNothing(oTabla) Then
                '//////////////////SI  TIENE REGISTROS NUEVOS 
                da.Update(oTabla)
                ds.Tables("DetalleCompra").AcceptChanges()
                da.Update(ds.Tables("DetalleCompra"))

                'ActualizarGridInsertRow()

                Me.TrueDBGridComponentes.Row = iPosicion

            Else
                oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
                If Not IsNothing(oTabla) Then
                    da.Update(oTabla)
                    ds.Tables("DetalleCompra").AcceptChanges()
                    da.Update(ds.Tables("DetalleCompra"))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al actualizar Detalle_Compras: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
    Public Sub Limpiar_Pantalla()

        BloquearControlesDuranteTransferencia(False)

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.TxtNumeroEnsamble.Text = "----0-----"
        Me.CboCodigoBodega.Enabled = True
        Me.CboCodigoBodega2.Enabled = True

        Cargar_grid(True, "", Now, "")

    End Sub

    Public Sub Cargar_Grid(LimpiarPantalla As Boolean, NumeroTransferencia As String, FechaTransferencia As Date, TipoFactura As String)
        Dim Procesado As Boolean = True
        Dim SqlString As String
        Dim Fecha As String = Format(FechaTransferencia, "yyyy-MM-dd")

        ConfigurarAdaptadorDetalleFactura(MiConexion)

        '=== Definir la consulta SQL según modo ===
        If LimpiarPantalla = True Then
            Procesado = False

            If FacturaTarea = True Then
                ' --- Empresa con LOTES ---
                SqlString = "
                SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,
                       Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,
                       Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe,
                       Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura,
                       Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura
                FROM Detalle_Facturas
                WHERE Detalle_Facturas.Numero_Factura = N'-1'"
            Else
                ' --- Empresa sin LOTES ---
                SqlString = "
                SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,
                       Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,
                       Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto,
                       Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,
                       Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura,
                       Detalle_Facturas.Tipo_Factura
                FROM Detalle_Facturas
                WHERE Detalle_Facturas.Numero_Factura = N'-1'"
            End If

        Else
            '=== MODO CONSULTA (transferencia ya guardada)
            If FacturaTarea = True Then
                SqlString = "
                SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,
                       Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,
                       Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe,
                       Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura,
                       Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura
                FROM Detalle_Facturas
                WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroTransferencia & "')
                  AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102))
                  AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')
                ORDER BY Detalle_Facturas.id_Detalle_Factura"
            Else
                SqlString = "
                SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,
                       Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,
                       Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto,
                       Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura,
                       Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura,
                       Detalle_Facturas.Tipo_Factura
                FROM Detalle_Facturas
                WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroTransferencia & "')
                  AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102))
                  AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "')
                ORDER BY Detalle_Facturas.id_Detalle_Factura"
            End If
        End If

        '=== Usar el mismo DataAdapter configurado ===
        da.SelectCommand = New SqlClient.SqlCommand(SqlString, MiConexion)

        '=== Limpiar la tabla existente ===
        If ds.Tables.Contains("DetalleFactura") Then
            ds.Tables("DetalleFactura").Clear()
        End If

        '=== Cargar datos ===
        da.Fill(ds, "DetalleFactura")

        '=== Enlazar el grid ===
        Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle

        '=== Aplicar formato ===
        FormatearColumnasSegunFacturaTarea()
    End Sub

    Private Sub FormatearColumnasSegunFacturaTarea()
        With Me.TrueDBGridComponentes

            '========================= COLUMNA CÓDIGO =========================
            .Columns("Cod_Producto").Caption = "Código"
            .Splits(0).DisplayColumns("Cod_Producto").Button = True
            .Splits(0).DisplayColumns("Cod_Producto").Width = 80
            .Splits(0).DisplayColumns("Cod_Producto").Locked = False

            '====================== COLUMNA DESCRIPCIÓN =======================
            .Columns("Descripcion_Producto").Caption = "Descripción"
            .Splits(0).DisplayColumns("Descripcion_Producto").Width = 260
            .Splits(0).DisplayColumns("Descripcion_Producto").Locked = True

            '========================= COLUMNA CANTIDAD =========================
            .Columns("Cantidad").Caption = "Cantidad"
            .Splits(0).DisplayColumns("Cantidad").Width = 60
            .Splits(0).DisplayColumns("Cantidad").Locked = False

            '========================= COLUMNA PRECIO UNITARIO ==================
            .Columns("Precio_Unitario").Caption = "Costo Unit."
            .Splits(0).DisplayColumns("Precio_Unitario").Width = 70
            .Splits(0).DisplayColumns("Precio_Unitario").Locked = True

            '========================= COLUMNA DESCUENTO ========================
            .Columns("Descuento").Caption = "% Desc"
            .Splits(0).DisplayColumns("Descuento").Width = 45
            .Splits(0).DisplayColumns("Descuento").Visible = False
            .Splits(0).DisplayColumns("Descuento").Locked = False

            '========================= COLUMNA PRECIO NETO ======================
            .Columns("Precio_Neto").Caption = "Costo Neto"
            .Splits(0).DisplayColumns("Precio_Neto").Width = 80
            .Splits(0).DisplayColumns("Precio_Neto").Locked = True

            '========================= COLUMNA IMPORTE ==========================
            .Columns("Importe").Caption = "Importe"
            .Splits(0).DisplayColumns("Importe").Width = 80
            .Splits(0).DisplayColumns("Importe").Locked = True

            '========================= COLUMNA ID DETALLE =======================

            .Splits(0).DisplayColumns("id_Detalle_Factura").Visible = False
            .Splits(0).DisplayColumns("Numero_Factura").Visible = False
            .Splits(0).DisplayColumns("Fecha_Factura").Visible = False
            .Splits(0).DisplayColumns("Tipo_Factura").Visible = False



            '========================= COLUMNA LOTE (CODTAREA) ==================
            If FacturaTarea = True Then
                ' Si la empresa maneja lotes y el campo existe en la consulta
                If ds.Tables("DetalleFactura").Columns.Contains("CodTarea") Then
                    .Columns("CodTarea").Caption = "Lote"
                    .Splits(0).DisplayColumns("CodTarea").Width = 100
                    .Splits(0).DisplayColumns("CodTarea").Button = True
                    .Splits(0).DisplayColumns("CodTarea").Locked = False
                    .Splits(0).DisplayColumns("CodTarea").Visible = True
                End If
            Else
                ' Si la empresa no maneja lotes, ocúltala si existe
                .Splits(0).DisplayColumns("CodTarea").Visible = False

            End If

            '========================= AJUSTES GENERALES ========================
            .AllowUpdate = True
            .AllowDelete = False
            .AllowAddNew = True
            .MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow

        End With
    End Sub


    'Public Sub Cargar_grid(LimpiarPantalla As Boolean, NumeroTransferencia As String, FechaTransferencia As Date, TipoFactura As String)
    '    Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
    '    Dim Procesado As Boolean = True, Fecha As String

    '    Fecha = Format(FechaTransferencia, "yyyy-MM-dd")

    '    If LimpiarPantalla = True Then
    '        If FacturaTarea = True Then

    '            Procesado = False
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
    '            ds = New DataSet
    '            da = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilder = New SqlCommandBuilder(da)
    '            da.Fill(ds, "DetalleFactura")
    '            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
    '            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
    '            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 80
    '            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
    '            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"

    '            '/////////////// CONSULTA PARA LAS ENTRADAS /////////////
    '            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras WHERE (Detalle_Compras.Numero_Compra = '-1')"
    '            dsCompra = New DataSet
    '            daCompra = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilderCompra = New SqlCommandBuilder(daCompra)
    '            daCompra.Fill(dsCompra, "DetalleCompra")

    '        Else

    '            Procesado = False
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
    '            ds = New DataSet
    '            da = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilder = New SqlCommandBuilder(da)
    '            da.Fill(ds, "DetalleFactura")
    '            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
    '            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
    '            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 80
    '            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

    '            '/////////////// CONSULTA PARA LAS ENTRADAS /////////////
    '            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras WHERE (Detalle_Compras.Numero_Compra = '-1')"
    '            dsCompra = New DataSet
    '            daCompra = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilderCompra = New SqlCommandBuilder(daCompra)
    '            daCompra.Fill(dsCompra, "DetalleCompra")
    '        End If
    '    Else

    '        If FacturaTarea = True Then

    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura FROM Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroTransferencia & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
    '            ds = New DataSet
    '            da = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilder = New SqlCommandBuilder(da)
    '            da.Fill(ds, "DetalleFactura")
    '            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
    '            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
    '            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 80
    '            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
    '            Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"

    '            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
    '                        "WHERE (Detalle_Compras.Numero_Compra = '" & NumeroTransferencia & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoFactura & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
    '            dsCompra = New DataSet
    '            daCompra = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilderCompra = New SqlCommandBuilder(daCompra)
    '            daCompra.Fill(dsCompra, "DetalleCompra")
    '        Else

    '            '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
    '            SqlString = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM  Detalle_Facturas WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroTransferencia & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
    '            ds = New DataSet
    '            da = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilder = New SqlCommandBuilder(da)
    '            da.Fill(ds, "DetalleFactura")
    '            Me.BindingDetalle.DataSource = ds.Tables("DetalleFactura")
    '            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
    '            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 80
    '            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
    '            Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
    '            Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
    '            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

    '            SqlString = "SELECT  Detalle_Compras.Cod_Producto, Detalle_Compras.Descripcion_Producto, Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Detalle_Compras.Importe,Detalle_Compras.id_Detalle_Compra, Detalle_Compras.Numero_Lote,Detalle_Compras.Fecha_Vence, TasaCambio, Numero_Compra, Fecha_Compra, Tipo_Compra FROM  Detalle_Compras  " &
    '                        "WHERE (Detalle_Compras.Numero_Compra = '" & NumeroTransferencia & "') AND (Detalle_Compras.Tipo_Compra = '" & TipoFactura & "') ORDER BY Detalle_Compras.id_Detalle_Compra"
    '            dsCompra = New DataSet
    '            daCompra = New SqlDataAdapter(SqlString, MiConexion)
    '            CmdBuilderCompra = New SqlCommandBuilder(daCompra)
    '            daCompra.Fill(dsCompra, "DetalleCompra")
    '        End If

    '    End If



    'End Sub



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


        If MiConexion.State = ConnectionState.Closed Then
            MiConexion.Open()
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
            If Not DataSet.Tables("Bodegas2").Rows.Count > 1 Then
                Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(1)("Cod_Bodega")
            Else
                Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
            End If
        End If
            Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
        MiConexion.Close()

        If NumeroTranferencia <> "-----0-----" Then
            Me.CboCodigoBodega.Text = FrmTransferenciaListado.TrueDBGridConsultas.Columns(4).Text
            Me.CboCodigoBodega2.Text = FrmTransferenciaListado.TrueDBGridConsultas.Columns(5).Text
            Me.DTPFecha.Value = FechaTransferencia
            Me.TxtNumeroEnsamble.Text = NumeroTranferencia


            'Procesado = FrmTransferenciaListado.TrueDBGridConsultas.Columns("Importe").Text
        ElseIf FacturaTarea = True Then

            Procesado = False

            Cargar_grid(True, "", Now, "")


            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '    SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto,Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            '    DataAdapter.Fill(DataSet, "DetalleFactura")
            '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
            '    Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"


            'Else

            '    Procesado = False
            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
            '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '    SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
            '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            '    DataAdapter.Fill(DataSet, "DetalleFactura")
            '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
            '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
            '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
            '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        End If



        If Procesado = True Then
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = False
            Me.Button4.Enabled = False
            Me.CboCodigoBodega.Enabled = False
            Me.CboCodigoBodega2.Enabled = False
        Else
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
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

            If FacturaTarea = True Then
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
                    Case 2 'Columna de lotes


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

                    Case 5
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

            Else

                '/////////////NO ES POR LOTE TIENE UNA COLUMNA MENOS ///////////////
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


            End If


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


        CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
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

        InsertarRowGrid()

        'For Each fila As DataRow In ds.Tables("DetalleFactura").Rows
        '    MsgBox("Fila ID: " & fila("id_Detalle_Factura").ToString())
        'Next

    End Sub

    Private Sub TrueDBGridComponentes_BeforeClose(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeClose

    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double
        Dim SqlString As String = "", CodigoBodega As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try

            Me.TrueDBGridComponentes.Columns("Numero_Factura").Text = Me.TxtNumeroEnsamble.Text
            Me.TrueDBGridComponentes.Columns("Fecha_Factura").Text = Format(DTPFecha.Value, "dd/MM/yyyy")
            Me.TrueDBGridComponentes.Columns("Tipo_Factura").Text = "Transferencia Enviada"

            Cols = e.ColIndex
            If FacturaTarea = True Then
                Select Case Cols
                    Case 3
                        If Not IsNumeric(Me.TrueDBGridComponentes.Columns("Cantidad").Text) Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                        End If


                        If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then
                            iPosicion = Me.BindingDetalle.Position
                            CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                        Else
                            CantidadAnterior = 0
                        End If
                    Case 4
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


            Else 'Facturacion sin lotes

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

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim SqlString As String = "", CodigoBodega As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Cantidad As Double, iPosicion As Double = 0, Existencia As Double, CodigoProducto As String
        Dim Args As ReporteExistenciaLote = New ReporteExistenciaLote, resul As ReporteExistenciaLote = New ReporteExistenciaLote

        If FacturaTarea = True Then

            Select Case e.ColIndex
                Case 2 'verifico si el lote existe 
                    If Me.TrueDBGridComponentes.Columns("CodTarea").Text <> "" Or Me.TrueDBGridComponentes.Columns("CodTarea").Text = "SINLOTE" Then
                        NumeroLote = Me.TrueDBGridComponentes.Columns("CodTarea").Text

                        SqlString = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & NumeroLote & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaLote")
                        If DataSet.Tables("BuscaLote").Rows.Count = 0 Then
                            MsgBox("Este Lote no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            e.Cancel = True
                            Exit Sub

                        Else
                            Me.TrueDBGridComponentes.Columns("CodTarea").Text = "SINLOTE"
                        End If
                    End If

                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0


                Case 3

                    iPosicion = Me.BindingDetalle.Position
                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    CodigoBodega = Me.CboCodigoBodega.Text
                    CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

                    Args.Codigo_Bodega = Me.CboCodigoBodega.Text
                    Args.Codigo_Producto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
                    Args.Fecha_Reporte = Me.DTPFecha.Value
                    Args.Numero_Lote = Me.TrueDBGridComponentes.Columns("CodTarea").Text

                    resul = BuscaExistenciaBodegaLote(Args)
                    Existencia = resul.Existencia_Lote

                    'Existencia = BuscaInventarioInicialBodega(CodigoProducto, DateAdd(DateInterval.Day, 1, Me.DTPFecha.Value), CodigoBodega)

                    DataSet.Reset()

                    If Cantidad > Existencia Then
                        MsgBox("NO Tiene Existencia, Disponible: " & Existencia, MsgBoxStyle.Critical, "Zeus Facturacion")
                        If Existencia > 0 Then
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = Existencia
                        Else
                            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
                        End If
                        e.Cancel = True
                    End If
            End Select


        Else 'Factura sin Lotes

            Select Case e.ColIndex

                Case 2
                    iPosicion = Me.BindingDetalle.Position
                    Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    CodigoBodega = Me.CboCodigoBodega.Text
                    CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text
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

        End If


    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim RstCosto As New RstCostoPromedio
        Dim Numero_lote As String = ""

        If e.ColIndex = 0 Then
            Quien = "CodigoProductosDetalle"
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                My.Application.DoEvents()

                '////////////BUSCO EL LOTE CON EXISTENCIA QUE ESTE POR VENCER ///////////
                If FacturaTarea = True Then
                    Numero_lote = LoteDefectoFacturas(My.Forms.FrmConsultas.Codigo, Me.CboCodigoBodega.Text, DTPFecha.Value)
                    Me.TrueDBGridComponentes.Columns("CodTarea").Text = Numero_lote
                End If


                'Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = My.Forms.FrmConsultas.Precio
                RstCosto = CostoPromedioKardex(My.Forms.FrmConsultas.Codigo, Me.DTPFecha.Value)
                Me.TrueDBGridComponentes.Columns("Precio_Unitario").Text = RstCosto.Costo_Cordoba

            Else

                Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = ""
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = ""
                Me.TrueDBGridComponentes.Columns("Cantidad").Text = ""


                If FacturaTarea = True Then
                    Me.TrueDBGridComponentes.Columns("CodTarea").Text = ""
                End If

            End If

        ElseIf e.ColIndex = 2 Then

            If FacturaTarea = True Then
                Quien = "CodigoTarea"
                'My.Forms.FrmConsultas.ShowDialog()

                Dim Posicion As Double
                If Me.BindingDetalle.Count <> 0 Then
                    My.Forms.FrmLotes.TipoDocumento = Me.CboTipoProducto.Text
                    Posicion = Me.BindingDetalle.Position
                    My.Forms.FrmLotesFactura.CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text    'Me.BindingDetalle.Item(Posicion)("Cod_Productos")
                    My.Forms.FrmLotesFactura.NombreProducto = Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text   'Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                    My.Forms.FrmLotesFactura.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                    My.Forms.FrmLotesFactura.Fecha = Me.DTPFecha.Value
                    My.Forms.FrmLotesFactura.LblProducto.Text = Me.TrueDBGridComponentes.Columns("Cod_Productos").Text + " " + Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text
                    'If Me.TrueDBGridComponentes.Columns("Cantidad").Text <> "" Then    'Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                    '    My.Forms.FrmLotesFactura.Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    'Else
                    '    My.Forms.FrmLotesFactura.Cantidad = 1
                    'End If
                    Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
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

                Cargar_grid(False, Me.TxtNumeroEnsamble.Text, Fecha, TipoFactura)

                '****************CODIGO RETIRADO   22/10/2025 ****************************
                'If FacturaTarea = True Then

                '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '    SqlCompras = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.CodTarea, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " &
                '                 "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                '    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                '    DataAdapter.Fill(DataSet, "DetalleFactura")
                '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
                '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
                '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
                '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("CodTarea").Button = True
                '    Me.TrueDBGridComponentes.Columns("CodTarea").Caption = "Lote"



                'Else

                '    '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                '    SqlCompras = "SELECT Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario,Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM  Productos INNER JOIN Detalle_Facturas ON Productos.Cod_Productos = Detalle_Facturas.Cod_Producto " &
                '        "WHERE (Detalle_Facturas.Numero_Factura = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Facturas.Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Facturas.Tipo_Factura = '" & TipoFactura & "') ORDER BY id_Detalle_Factura"
                '    DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                '    DataAdapter.Fill(DataSet, "DetalleFactura")
                '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
                '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
                '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
                '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
                '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
                '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
                '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

                'End If
            End If
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
    Public Sub Grabar()
        Dim Args As New ArgsTransferencias
        Dim dsDetalle As DataSet

        If Me.CboCodigoBodega.Text = Me.CboCodigoBodega2.Text Then
            MsgBox("Es neceario que las Bodegas sean distintas", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Args.Fecha = Me.DTPFecha.Value
        Args.CodigoBodegaOrigen = Me.CboCodigoBodega.Text
        Args.CodigoBodegaDestino = Me.CboCodigoBodega2.Text
        If Me.TxtTotalCosto.Text <> "" Then
            Args.SubTotal = Me.TxtTotalCosto.Text
        Else
            Args.SubTotal = 0
        End If
        Args.Observaciones = Me.TxtObservaciones.Text
        Args.Numero = Me.TxtNumeroEnsamble.Text
        Args.Tipo = Me.CboTipoProducto.Text

        Args.ModoOperacion = If(Me.TxtNumeroEnsamble.Text = "-----0-----", "Nuevo", "Editar")
        Args.Usuario = NombreUsuario

        '/////////////////////////////Copio los DataSet ///////////////////////////
        dsDetalle = ds.Copy

        Dim worker As BackgroundWorker
        worker = New BackgroundWorker()
        AddHandler worker.DoWork, AddressOf backgroundWorkerGrabar_DoWork
        AddHandler worker.ProgressChanged, AddressOf backgroundWorkerGrabar_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerGrabar_RunWorkerCompleted
        worker.RunWorkerAsync({Args, dsDetalle})


    End Sub

    Private Sub InsertarDetalleTransferencia(dsTransferencia As DataSet, NumeroFactura As String, Fecha As Date, cnn As SqlConnection, trans As SqlTransaction, worker As BackgroundWorker)
        Dim totalRegistros As Integer = dsTransferencia.Tables("DetalleFactura").Rows.Count

        For i As Integer = 0 To totalRegistros - 1
            Dim fila As DataRow = dsTransferencia.Tables("DetalleFactura").Rows(i)
            If worker.CancellationPending Then Exit Sub

            Dim CodigoProducto As String = fila("Cod_Producto").ToString()
            Dim Descripcion_Producto As String = If(IsDBNull(fila("Descripcion_Producto")), "", fila("Descripcion_Producto").ToString())
            Dim Cantidad As Double = If(IsDBNull(fila("Cantidad")), 0, CDbl(fila("Cantidad")))
            Dim PrecioUnitario As Double = If(IsDBNull(fila("Precio_Unitario")), 0, CDbl(fila("Precio_Unitario")))
            Dim Descuento As Double = If(IsDBNull(fila("Descuento")), 0, CDbl(fila("Descuento")))
            Dim PrecioNeto As Double = If(IsDBNull(fila("Precio_Neto")), 0, CDbl(fila("Precio_Neto")))
            Dim Importe As Double = If(IsDBNull(fila("Importe")), 0, CDbl(fila("Importe")))
            Dim CodTarea As String = If(IsDBNull(fila("CodTarea")), "SINLOTE", fila("CodTarea").ToString())

            ' Reportar progreso
            worker.ReportProgress(CInt((i + 1) / totalRegistros * 100), CodigoProducto)

            ' === Insertar detalle en Detalle_Compras ===
            Using cmdInsert As New SqlCommand("
            INSERT INTO Detalle_Compras
                (Cod_Producto, Descripcion_Producto, Numero_Lote, Cantidad, Precio_Unitario,
                 Descuento, Precio_Neto, Importe, Numero_Compra, Fecha_Compra, Tipo_Compra)
            VALUES
                (@Cod_Producto, @Descripcion_Producto, @CodTarea, @Cantidad, @Precio_Unitario,
                 @Descuento, @Precio_Neto, @Importe, @Numero_Factura, @Fecha_Factura, 'Transferencia Recibida')", cnn, trans)

                cmdInsert.Parameters.AddWithValue("@Cod_Producto", CodigoProducto)
                cmdInsert.Parameters.AddWithValue("@Descripcion_Producto", Descripcion_Producto)
                cmdInsert.Parameters.AddWithValue("@CodTarea", CodTarea)
                cmdInsert.Parameters.AddWithValue("@Cantidad", Cantidad)
                cmdInsert.Parameters.AddWithValue("@Precio_Unitario", PrecioUnitario)
                cmdInsert.Parameters.AddWithValue("@Descuento", Descuento)
                cmdInsert.Parameters.AddWithValue("@Precio_Neto", PrecioNeto)
                cmdInsert.Parameters.AddWithValue("@Importe", Importe)
                cmdInsert.Parameters.AddWithValue("@Numero_Factura", NumeroFactura)
                cmdInsert.Parameters.AddWithValue("@Fecha_Factura", Fecha)

                cmdInsert.ExecuteNonQuery()
            End Using
        Next
    End Sub



    Public Sub GrabarTransferenciasWorker(Args As ArgsTransferencias, dsTransferencia As DataSet, worker As BackgroundWorker, e As DoWorkEventArgs)
        Dim NumeroFactura As String = ""
        Dim Fecha As Date = Args.Fecha
        Dim BodegaOrigen As String = Args.CodigoBodegaOrigen
        Dim BodegaDestino As String = Args.CodigoBodegaDestino
        Dim Total As Double = Args.SubTotal
        Dim Observaciones As String = Args.Observaciones

        Try
            Using cnn As New SqlConnection(Conexion)
                cnn.Open()
                Dim trans As SqlTransaction = cnn.BeginTransaction()

                Try
                    ' === 1️⃣ Obtener o generar número de transferencia ===
                    NumeroFactura = GenerarNumeroTransferencia(Args.Numero, Args.Tipo, BodegaOrigen)

                    ' === 2️⃣ Grabar o actualizar encabezados ===
                    GrabaTransferenciasSalida(NumeroFactura, Fecha, "Transferencia Enviada",
                                          BodegaOrigen, BodegaOrigen, BodegaDestino, Total, Observaciones)

                    GrabaTransferenciasEntrada(NumeroFactura, Fecha, "Transferencia Recibida",
                                           BodegaDestino, BodegaOrigen, BodegaDestino, Total, Observaciones)

                    ' === 3️⃣ Ejecutar según el modo de operación ===
                    Select Case Args.ModoOperacion.ToUpper()
                        Case "NUEVO"
                            ' 🔹 Insertar nuevos detalles (sin borrar)
                            InsertarDetalleTransferencia(dsTransferencia, NumeroFactura, Fecha, cnn, trans, worker)

                        Case "EDITAR"
                            ' 🔹 Borrar detalles previos en Detalle_Compras y volver a insertar
                            Using cmdDelete As New SqlCommand("
                            DELETE FROM Detalle_Compras 
                            WHERE Numero_Compra = @Numero AND Tipo_Compra = 'Transferencia Recibida'", cnn, trans)
                                cmdDelete.Parameters.AddWithValue("@Numero", NumeroFactura)
                                cmdDelete.ExecuteNonQuery()
                            End Using

                            InsertarDetalleTransferencia(dsTransferencia, NumeroFactura, Fecha, cnn, trans, worker)

                        Case "CONFIRMAR"
                            ' 🔹 Solo actualizar estado en encabezados
                            Using cmdEstado As New SqlCommand("
                            UPDATE Compras SET Estado = 'Confirmada' 
                            WHERE Numero_Compra = @Numero AND Tipo_Compra = 'Transferencia Recibida';
                            UPDATE Transferencias SET Estado = 'Confirmada'
                            WHERE Numero_Compra = @Numero AND Tipo_Compra = 'Transferencia Enviada';", cnn, trans)
                                cmdEstado.Parameters.AddWithValue("@Numero", NumeroFactura)
                                cmdEstado.ExecuteNonQuery()
                            End Using
                    End Select

                    ' === Confirmar transacción ===
                    trans.Commit()

                Catch ex As Exception
                    trans.Rollback()
                    Throw
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Error al grabar transferencia: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    'Public Sub GrabarTransferenciasWorker(Args As ArgsTransferencias, dsTransferencia As DataSet, worker As BackgroundWorker, e As DoWorkEventArgs)
    '    Dim NumeroFactura As String, Fecha As Date, BodegaOrigen As String, BodegaDestino As String
    '    Dim iPosicion As Double, Registros As Double, Total As Double
    '    Dim Monto As Double, CodTarea As String = Nothing, Observaciones As String
    '    Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
    '    Dim Descripcion_Producto As String, IdDetalle As Double = -1
    '    Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

    '    Fecha = Args.Fecha
    '    BodegaOrigen = Args.CodigoBodegaOrigen
    '    BodegaDestino = Args.CodigoBodegaDestino
    '    Total = Args.SubTotal
    '    Observaciones = Args.Observaciones

    '    '////////////////////////////////////////////////////////////////////////////////////////////////////
    '    '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7

    '    NumeroFactura = GenerarNumeroTransferencia(Args.Numero, Args.Tipo, BodegaOrigen)

    '    '////////////////////////////////////////////////////////////////////////////////////////////////////
    '    '/////////////////////////////GRABO EL ENCABEZADO DE TRANSFERENCIA SALIDA Y ENTRADA/////////////////////////////////////////////
    '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
    '    GrabaTransferenciasSalida(NumeroFactura, Fecha, "Transferencia Enviada", BodegaOrigen, BodegaOrigen, BodegaDestino, Total, Observaciones)
    '    GrabaTransferenciasEntrada(NumeroFactura, Fecha, "Transferencia Recibida", BodegaDestino, BodegaOrigen, BodegaDestino, Total, Observaciones)

    '    Registros = dsTransferencia.Tables("DetalleFactura").Rows.Count
    '    iPosicion = 0
    '    Monto = 0
    '    Do While iPosicion < Registros

    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("id_Detalle_Factura")) Then
    '            IdDetalle = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("id_Detalle_Factura")
    '        Else
    '            IdDetalle = -1
    '        End If

    '        CodigoProducto = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Cod_Productos")

    '        '///////////////PROGRESO DEL HILO GRABAR //////////////////////////
    '        worker.ReportProgress(iPosicion, CodigoProducto)


    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Precio_Unitario")) Then
    '            PrecioUnitario = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Precio_Unitario")
    '        Else
    '            PrecioUnitario = 0
    '        End If
    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Descuento")) Then
    '            Descuento = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Descuento")
    '        End If
    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Precio_Neto")) Then
    '            PrecioNeto = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Precio_Neto")
    '        Else
    '            PrecioNeto = 0
    '        End If
    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Importe")) Then
    '            Importe = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Importe")
    '        Else
    '            Importe = 0
    '        End If
    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Cantidad")) Then
    '            Cantidad = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Cantidad")
    '        Else
    '            Cantidad = 0
    '        End If

    '        If FacturaTarea = True Then
    '            If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")) Then
    '                NumeroLote = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("CodTarea")
    '            Else
    '                NumeroLote = "SINLOTE"
    '            End If
    '            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")) Then
    '            '    FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")
    '            'Else
    '            '    FechaLote = "01/01/1900"
    '            'End If
    '        End If

    '        If Not IsDBNull(dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Descripcion_Producto")) Then
    '            Descripcion_Producto = dsTransferencia.Tables("DetalleFactura").Rows(iPosicion)("Descripcion_Producto")
    '        Else
    '            Descripcion_Producto = ""
    '        End If

    '        If CodigoProducto <> "" Then
    '            '////////////////////////////////////////////////////////////////////////////////////////////////////
    '            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
    '            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
    '            GrabaDetalleTransferenciaSalida(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Fecha, "Transferencia Enviada", NumeroLote)
    '            If IdDetalle = -1 Then
    '                '//////////////////busco el id detalle nuevo cuando se graba una linea nueva de las transferencia ///////////////
    '                IdDetalle = BuscaProductoIdFactura(NumeroFactura, Me.DTPFecha.Value, "Transferencia Enviada", CodigoProducto, Cantidad)
    '            End If
    '            GrabaDetalleTransferenciaEntrada(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Fecha, "Transferencia Recibida", NumeroLote)

    '        Else
    '            'Me.BindingDetalle.RemoveCurrent()
    '        End If

    '        iPosicion = iPosicion + 1
    '    Loop

    'End Sub

    Private Sub TrueDBGridComponentes_Click(sender As Object, e As EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim NumeroFactura As String
        Dim iPosicion As Double, Registros As Double
        Dim Monto As Double, CodTarea As String = Nothing
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim Descripcion_Producto As String, IdDetalle As Double = -1
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try
            ' === VALIDACIONES ===
            If Me.CboCodigoBodega.Text = Me.CboCodigoBodega2.Text Then
                MsgBox("Las bodegas de origen y destino deben ser diferentes.", MsgBoxStyle.Critical, "Zeus Facturación")
                Exit Sub
            End If

            If Me.BindingDetalle.Count = 0 Then
                MsgBox("No hay productos en la transferencia.", MsgBoxStyle.Exclamation, "Zeus Facturación")
                Exit Sub
            End If


            Grabar()

        Catch ex As Exception
            MsgBox("Error al grabar transferencia: " & ex.Message, MsgBoxStyle.Critical)
        End Try


        '****************CODIGO RETIRADO 22/10/2025 ************************
        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7

        'NumeroFactura = GenerarNumeroTransferencia(Me.TxtNumeroEnsamble.Text, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Columns(0).Text)


        '****************CODIGO RETIRADO 22/10/2025 ************************
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "Transferencia Enviada"
        '            ConsecutivoFactura = BuscaConsecutivo("Transferencia_Enviada")
        '    End Select

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////BUSCO SI TIENE ACTIVADA LA OPCION DE CONSECUTIVO X BODEGA /////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////
        '    SqlConsecutivo = "SELECT * FROM  DatosEmpresa"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        '    DataAdapter.Fill(DataSet, "Configuracion")
        '    If Not DataSet.Tables("Configuracion").Rows.Count = 0 Then
        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoFacBodega")) = True Then
        '            FacturaBodega = True
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Configuracion").Rows(0)("ConsecutivoComBodega")) = True Then
        '            CompraBodega = True
        '        End If

        '    End If

        '    If FacturaBodega = True Then
        '        NumeroFactura = Me.CboCodigoBodega.Columns(0).Text & "-" & Format(ConsecutivoFactura, "0000#")
        '    Else
        '        NumeroFactura = Format(ConsecutivoFactura, "0000#")
        '    End If
        'Else
        '    'ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
        '    'NumeroFactura = Format(ConsecutivoFactura, "0000#")
        '    NumeroFactura = Me.TxtNumeroEnsamble.Text
        'End If




        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL ENCABEZADO DE TRANSFERENCIA SALIDA Y ENTRADA/////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaTransferenciasSalida(NumeroFactura, Me.DTPFecha.Value, "Transferencia Enviada", Me.CboCodigoBodega.Text, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text, Me.TxtTotalCosto.Text, Me.TxtObservaciones.Text)
        'GrabaTransferenciasEntrada(NumeroFactura, Me.DTPFecha.Value, "Transferencia Recibida", Me.CboCodigoBodega2.Text, Me.CboCodigoBodega.Text, Me.CboCodigoBodega2.Text, Me.TxtTotalCosto.Text, Me.TxtObservaciones.Text)


        'Registros = Me.BindingDetalle.Count
        'Registros = Me.BindingDetalle.Count
        'iPosicion = 0
        'Monto = 0
        'Do While iPosicion < Registros

        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
        '        IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
        '    Else
        '        IdDetalle = -1
        '    End If

        '    CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")) Then
        '        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        '    Else
        '        PrecioUnitario = 0
        '    End If
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '        Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        '    End If
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Precio_Neto")) Then
        '        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        '    Else
        '        PrecioNeto = 0
        '    End If
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Importe")) Then
        '        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        '    Else
        '        Importe = 0
        '    End If
        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        '    Else
        '        Cantidad = 0
        '    End If

        '    If FacturaTarea = True Then
        '        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("CodTarea")) Then
        '            NumeroLote = Me.BindingDetalle.Item(iPosicion)("CodTarea")
        '        Else
        '            NumeroLote = "SINLOTE"
        '        End If
        '        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")) Then
        '        '    FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Lote")
        '        'Else
        '        '    FechaLote = "01/01/1900"
        '        'End If
        '    End If

        '    If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")) Then
        '        Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
        '    Else
        '        Descripcion_Producto = ""
        '    End If

        '    If CodigoProducto <> "" Then
        '        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '        '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
        '        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        '        GrabaDetalleTransferenciaSalida(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Me.DTPFecha.Value, "Transferencia Enviada", NumeroLote)
        '        If IdDetalle = -1 Then
        '            '//////////////////busco el id detalle nuevo cuando se graba una linea nueva de las transferencia ///////////////
        '            IdDetalle = BuscaProductoIdFactura(NumeroFactura, Me.DTPFecha.Value, "Transferencia Enviada", CodigoProducto, Cantidad)
        '        End If
        '        GrabaDetalleTransferenciaEntrada(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle, Me.DTPFecha.Value, "Transferencia Recibida", NumeroLote)

        '    Else
        '        Me.BindingDetalle.RemoveCurrent()
        '    End If

        '    iPosicion = iPosicion + 1
        'Loop

        'Me.TxtNumeroEnsamble.Text = NumeroFactura

        'If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
        '    Me.CboCodigoBodega.Enabled = False
        '    Me.CboCodigoBodega2.Enabled = False
        'Else
        '    Me.CboCodigoBodega.Enabled = True
        '    Me.CboCodigoBodega2.Enabled = True
        'End If

        'Limpiar_Pantalla()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter



        Me.TxtNumeroEnsamble.Text = "-----0-----"

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        If MiConexion.State <> ConnectionState.Open Then MiConexion.Open()

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
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
            If Not DataSet.Tables("Bodegas2").Rows.Count > 1 Then
                Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(1)("Cod_Bodega")
            Else
                Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
            End If
        End If
            Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"
        MiConexion.Close()

        Limpiar_Pantalla()

        '**********CODIGO RETIRADO 22/10/2025 ***********************
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



        Limpiar_Pantalla()

        '***************CODIGO RETIRADO 22/10/2025********************************
        'If FacturaTarea = True Then

        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.CodTarea As Lote FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "DetalleFactura")
        '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
        '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
        '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
        '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Lote").Button = True

        'Else
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.id_Detalle_Factura FROM Detalle_Facturas INNER JOIN  Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos WHERE (Detalle_Facturas.Numero_Factura = N'-1')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "DetalleFactura")
        '    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        '    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        '    Me.TrueDBGridComponentes.Columns("Cod_Productos").Caption = "Codigo"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Button = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Productos").Width = 80
        '    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 260
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 54
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
        '    Me.TrueDBGridComponentes.Columns("Precio_Unitario").Caption = "Costo Unit"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 62
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Unitario").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Descuento").Caption = "%Desc"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Width = 43
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descuento").Visible = False
        '    Me.TrueDBGridComponentes.Columns("Precio_Neto").Caption = "Costo Neto"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Width = 65
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Neto").Locked = True
        '    Me.TrueDBGridComponentes.Columns("Importe").Caption = "Importe"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Width = 61
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Importe").Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("id_Detalle_Factura").Visible = False

        'End If

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

    Private Sub TrueDBGridComponentes_BeforeUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim SQL As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroLote As String = "", NumeroFactura As String
        Dim Fecha As Date = DTPFecha.Value, BodegaOrigen As String = Me.CboCodigoBodega.Text, BodegaDestino As String = CboCodigoBodega2.Text
        Dim Observaciones As String = Me.TxtObservaciones.Text, Total As Double

        If TxtTotalCosto.Text <> "" Then
            Total = TxtTotalCosto.Text
        Else
            Total = 0
        End If

        '/////////BUSCO EL CONSECUTIVO TRANSFERENCIA //////////////////
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroFacturas"
            NumeroFactura = GenerarNumeroTransferencia(TxtNumeroEnsamble.Text, Me.CboTipoProducto.Text, CboCodigoBodega.Text)
            If NumeroFactura = "-00001" Then
                Me.TxtNumeroEnsamble.Text = "-----0-----"
                e.Cancel = True
            Else
                Me.TxtNumeroEnsamble.Text = NumeroFactura
            End If

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE TRANSFERENCIA SALIDA Y ENTRADA/////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaTransferenciasSalida(NumeroFactura, Fecha, "Transferencia Enviada", BodegaOrigen, BodegaOrigen, BodegaDestino, Total, Observaciones)
            GrabaTransferenciasEntrada(NumeroFactura, Fecha, "Transferencia Recibida", BodegaDestino, BodegaOrigen, BodegaDestino, Total, Observaciones)
        Else
            NumeroFactura = Me.TxtNumeroEnsamble.Text
        End If


        Me.TrueDBGridComponentes.Columns("Numero_Factura").Text = NumeroFactura
        Me.TrueDBGridComponentes.Columns("Fecha_Factura").Text = Format(DTPFecha.Value, "dd/MM/yyyy")
        Me.TrueDBGridComponentes.Columns("Tipo_Factura").Text = "Transferencia Enviada"

        '/////si actualiza queda pendiente grabar 
        TransferenciaPendiente = True
    End Sub

    Private Sub FrmTransferencias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If TransferenciaPendiente Then
            Dim resp = MsgBox("Debe grabar o cancelar la transferencia actual antes de salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            e.Cancel = True
        End If
    End Sub
End Class