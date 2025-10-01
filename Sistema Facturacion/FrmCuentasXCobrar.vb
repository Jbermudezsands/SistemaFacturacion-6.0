Imports System.ComponentModel
Imports System.Math

Public Class FrmCuentasXCobrar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public DatasetReporte As New DataSet, ds As New DataSet
    Public TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0, TotalMora As Double, TotalMontoNotaDB As Double, TotalMontoNotaCR As Double
    Public dv As New DataView
    Public WithEvents backgroundWorkerCalcular As System.ComponentModel.BackgroundWorker


    '////////////////////////////////////PROCESOS CON HILOS //////////////
    Private Sub backgroundWorkerCalcular_DoWork(
ByVal sender As Object,
ByVal e As DoWorkEventArgs) _
Handles backgroundWorkerCalcular.DoWork
        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        Dim dsMetodo As New DataSet, dsDetalle As New DataSet, Compras As New TablaCompras

        Compras = e.Argument(0)
        dsDetalle = e.Argument(1)
        dsMetodo = e.Argument(2)



        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        Else

            worker.WorkerReportsProgress = True
            worker.WorkerSupportsCancellation = True
            'e.Result = ActualizaMETODOcOMPRAWorker(Compras, dsDetalle, dsMetodo, worker, e)
        End If
    End Sub
    Private Sub backgroundWorkerCalcular_RunWorkerCompleted(
ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
Handles backgroundWorkerCalcular.RunWorkerCompleted



        If (e.Error IsNot Nothing) Then
            Bitacora(Now, NombreUsuario, "Compras", "Error " & e.Error.Message)
        ElseIf e.Cancelled Then
            Bitacora(Now, NombreUsuario, "Compras", "Hilo Cancelado")
        Else

            Dim Resultado As New CsResultadoCtasxCobrar, Filtro As String


            MDIMain.txtSPlano3.Text = ""

            Resultado = e.Result

            Me.TxtCargos.Text = Format(Resultado.ClaseTotalVentas.TotalCargos, "##,##0.00")
            Me.TxtAbonos.Text = Format(Resultado.ClaseTotalVentas.TotalAbonos, "##,##0.00")
            Me.TxtMora.Text = Format(Resultado.ClaseTotalVentas.TotalMora, "##,##0.00")
            Me.TxtNB.Text = Format(Resultado.ClaseTotalVentas.TotalMontoNotaDB - Resultado.ClaseTotalVentas.TotalMontoNotaCR, "##,##0.00")
            Me.TxtSaldoFinal.Text = Format(Resultado.ClaseTotalVentas.TotalFactura, "##,##0.00")


            If Me.ChkRegistrosCero.Checked = True Then
                Filtro = "Fecha_Factura <= '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "' AND Total > " & MontoMayor & " "
            Else
                Filtro = "Fecha_Factura <= '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "'  "
            End If


            dv = New DataView(DatasetReporte.Tables("TotalVentas"))

            Select Case Ordenar
                Case "Cliente" : dv.Sort = "Cod_Cliente"
            End Select

            dv.RowFilter = Filtro








            Me.Button1.Enabled = True
            Me.Button3.Enabled = True
            Me.Button5.Enabled = True
            Me.CmdAjustes.Enabled = True


            Me.TDGridImpuestos.DataSource = dv ' DatasetReporte.Tables("TotalVentas")
            Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
            Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
            Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
            Me.TDGridImpuestos.Columns(3).Caption = "DB/CR No"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 80
            Me.TDGridImpuestos.Columns(4).Caption = "Monto NB/CR"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 75
            Me.TDGridImpuestos.Columns(5).Caption = "Cargo"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
            Me.TDGridImpuestos.Columns(5).NumberFormat = "##,##0.00"
            Me.TDGridImpuestos.Columns(6).Caption = "Fecha Vence"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 73
            Me.TDGridImpuestos.Columns(7).Caption = "Abono"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
            Me.TDGridImpuestos.Columns(7).NumberFormat = "##,##0.00"
            Me.TDGridImpuestos.Columns(8).Caption = "Saldo"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 70
            Me.TDGridImpuestos.Columns(8).NumberFormat = "##,##0.00"
            Me.TDGridImpuestos.Columns(9).Caption = "Moratorio"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70
            Me.TDGridImpuestos.Columns(9).NumberFormat = "##,##0.00"
            Me.TDGridImpuestos.Columns(10).Caption = "Dias"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(10).Width = 40
            Me.TDGridImpuestos.Columns(11).Caption = "Total"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(11).Width = 70
            Me.TDGridImpuestos.Columns(11).NumberFormat = "##,##0.00"
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(12).Visible = False
            Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(13).Visible = False

        End If

    End Sub
    Private Sub backgroundWorkerCalcular_ProgressChanged(
ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
Handles backgroundWorkerCalcular.ProgressChanged


        MDIMain.txtSPlano3.Text = e.UserState.ToString


    End Sub




    Private Sub FrmCuentasXCobrar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ctas x Cobrar")
    End Sub

    Private Sub FrmCuentasXCobrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Cod_Cliente As Codigo, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres  FROM Clientes "
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion), SqlString As String = ""
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("Clientes")
        End If




        Me.DTPFechaIni.Value = Now


        Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
        Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
        Me.TDGridImpuestos.Columns(3).Caption = "Cargo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 70
        Me.TDGridImpuestos.Columns(4).Caption = "Fecha Vence"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 73
        Me.TDGridImpuestos.Columns(5).Caption = "Abono"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
        Me.TDGridImpuestos.Columns(6).Caption = "Saldo"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 70
        Me.TDGridImpuestos.Columns(7).Caption = "Moratorio"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
        Me.TDGridImpuestos.Columns(8).Caption = "Dias"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 40
        Me.TDGridImpuestos.Columns(9).Caption = "Total"
        Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        'Dim SQlString As String, NumeroFactura As String, NumeroRecibo As String = "", MontoRecibo As Double
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        'Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, TasaCambio As Double, Saldo As Double
        'Dim oDataRow As DataRow, MontoFactura As Double, FechaFactura As Date, Dias As Double, TasaInteres As Double, MontoMora As Double, Total As Double
        'Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double, TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        'Dim TotalMora As Double = 0, FechaVence As Date, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        'Dim MontoMetodoFactura As Double = 0, TipoNota As String = ""

        'Dim dv As New DataView

        If Me.CboCodigoCliente.Text = "" Then
            Exit Sub
        End If

        Dim worker As BackgroundWorker, Args As New CsFillCtasxCobrar

        Args.Codigo_Cliente = CboCodigoCliente.Text
        Args.Opt_Cordobas = OptCordobas.Checked
        Args.Fecha_Fin = Me.DTPFechaFin.Value
        Args.Proceso = "CtasxCobrar"
        Args.Excluir_Cero = ChkRegistrosCero.Checked
        Args.Ordenar = "Cliente"



        '///////////////////////EXISTENCIA EN SEGUNDO PLANO ///////////////
        AddHandler worker.DoWork, AddressOf backgroundWorkerCalcular_DoWork
        AddHandler worker.ProgressChanged, AddressOf backgroundWorkerCalcular_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf backgroundWorkerCalcular_RunWorkerCompleted
        worker.RunWorkerAsync(Args)


        dv = dvCtasxCobrar(CboCodigoCliente.Text, OptCordobas.Checked, Me.DTPFechaFin.Value, "CtasxCobrar", ChkRegistrosCero.Checked, "Cliente")
        'TotalFactura = TotalCargos - TotalAbonos + TotalMora + TotalMontoNotaDB - TotalMontoNotaCR

        'Me.TxtCargos.Text = Format(TotalCargos, "##,##0.00")
        'Me.TxtAbonos.Text = Format(TotalAbonos, "##,##0.00")
        'Me.TxtMora.Text = Format(TotalMora, "##,##0.00")
        'Me.TxtNB.Text = Format(TotalMontoNotaDB - TotalMontoNotaCR, "##,##0.00")
        'Me.TxtSaldoFinal.Text = Format(TotalFactura, "##,##0.00")

        'Me.Button1.Enabled = True
        'Me.Button3.Enabled = True
        'Me.Button5.Enabled = True
        'Me.CmdAjustes.Enabled = True


        'Me.TDGridImpuestos.DataSource = dv ' DatasetReporte.Tables("TotalVentas")
        'Me.TDGridImpuestos.Columns(0).Caption = "Fecha"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Width = 73
        'Me.TDGridImpuestos.Columns(1).Caption = "Factura No"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(1).Width = 61
        'Me.TDGridImpuestos.Columns(2).Caption = "Recibo No"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(2).Width = 71
        'Me.TDGridImpuestos.Columns(3).Caption = "DB/CR No"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(3).Width = 80
        'Me.TDGridImpuestos.Columns(4).Caption = "Monto NB/CR"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(4).Width = 75
        'Me.TDGridImpuestos.Columns(5).Caption = "Cargo"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(5).Width = 70
        'Me.TDGridImpuestos.Columns(5).NumberFormat = "##,##0.00"
        'Me.TDGridImpuestos.Columns(6).Caption = "Fecha Vence"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(6).Width = 73
        'Me.TDGridImpuestos.Columns(7).Caption = "Abono"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(7).Width = 70
        'Me.TDGridImpuestos.Columns(7).NumberFormat = "##,##0.00"
        'Me.TDGridImpuestos.Columns(8).Caption = "Saldo"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(8).Width = 70
        'Me.TDGridImpuestos.Columns(8).NumberFormat = "##,##0.00"
        'Me.TDGridImpuestos.Columns(9).Caption = "Moratorio"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(9).Width = 70
        'Me.TDGridImpuestos.Columns(9).NumberFormat = "##,##0.00"
        'Me.TDGridImpuestos.Columns(10).Caption = "Dias"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(10).Width = 40
        'Me.TDGridImpuestos.Columns(11).Caption = "Total"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(11).Width = 70
        'Me.TDGridImpuestos.Columns(11).NumberFormat = "##,##0.00"
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(12).Visible = False
        'Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(13).Visible = False

    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged

        Dim SQL As String = "SELECT * FROM Clientes WHERE  (Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")) Then
                Me.LblNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                Me.Button1.Enabled = False
                Me.Button3.Enabled = False
                Me.Button5.Enabled = False
                Me.CmdAjustes.Enabled = False
            End If

        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub OptDolares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptDolares.CheckedChanged
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub OptCordobas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCordobas.CheckedChanged
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ArepEstadoCuentas As New ArepEstadoCuentas
        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                Ruc = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If

        If Dir(RutaLogo) <> "" Then
            ArepEstadoCuentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If

        ArepEstadoCuentas.LblTitulo.Text = NombreEmpresa
        ArepEstadoCuentas.LblDireccion.Text = DireccionEmpresa
        ArepEstadoCuentas.LblRuc.Text = Ruc
        ArepEstadoCuentas.LblCodCliente.Text = Me.CboCodigoCliente.Text
        ArepEstadoCuentas.LblNombreCliente.Text = Me.LblNombres.Text

        If Me.OptCordobas.Checked = True Then
            ArepEstadoCuentas.LblMoneda.Text = "Cordobas"
        Else
            ArepEstadoCuentas.LblMoneda.Text = "Dolares"
        End If

        ArepEstadoCuentas.LblFecha.Text = Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
        ArepEstadoCuentas.LblCargo.Text = Me.TxtCargos.Text
        ArepEstadoCuentas.LblAbono.Text = Me.TxtAbonos.Text
        ArepEstadoCuentas.LblMora.Text = Me.TxtMora.Text
        ArepEstadoCuentas.LblSaldoFinal.Text = Me.TxtSaldoFinal.Text


        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepEstadoCuentas.Document
        My.Application.DoEvents()
        ArepEstadoCuentas.DataSource = dv 'DatasetReporte.Tables("TotalVentas")
        ArepEstadoCuentas.Run(False)
        ViewerForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If Len(Me.LblNombres.Text) > 29 Then
            My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
        Else
            My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
        End If

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
        Else
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
        End If
        My.Forms.FrmRegistroDebito.TipoNota = "Debito Clientes"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        If Me.TDGridImpuestos.Columns(0).Text <> "" Then
            My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        Else
            My.Forms.FrmRegistroDebito.DTPFecha.Value = Format(Now, "dd/MM/yyyy")
        End If
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE DEBITO"

        My.Forms.FrmRegistroDebito.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Len(Me.LblNombres.Text) > 29 Then
            My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
        Else
            My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
        End If

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
        Else
            My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
        End If
        My.Forms.FrmRegistroDebito.TipoNota = "Credito Clientes"
        My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
        My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.NumeroFactura = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE CREDITO"
        My.Forms.FrmRegistroDebito.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmRecibos.TxtCodigoClientes.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRecibos.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        My.Forms.FrmRecibos.ShowDialog()
        CmdGrabar_Click(sender, e)
    End Sub

    Private Sub TDGridImpuestos_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles TDGridImpuestos.AfterFilter

    End Sub

    Private Sub TDGridImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.Click

    End Sub

    Private Sub TDGridImpuestos_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.ClientSizeChanged

    End Sub

    Private Sub TDGridImpuestos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TDGridImpuestos.MouseDown


        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Select Case Me.TDGridImpuestos.Col
                Case 2
                    If Me.TDGridImpuestos.Columns(2).Text = "" Then
                        Me.ContextMenuStripGrid.Items(0).Visible = False
                        Me.ContextMenuStripGrid.Items(1).Visible = True

                    Else
                        Me.ContextMenuStripGrid.Items(0).Visible = True
                        Me.ContextMenuStripGrid.Items(1).Visible = True

                    End If

                    Me.ContextMenuStripGrid.Items(2).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = False
                    Me.ContextMenuStripGrid.Items(4).Visible = False

                Case 3
                    Me.ContextMenuStripGrid.Items(0).Visible = False
                    Me.ContextMenuStripGrid.Items(1).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = True
                    Me.ContextMenuStripGrid.Items(4).Visible = True
                    Me.ContextMenuStripGrid.Items(2).Visible = True

                Case Else
                    Me.ContextMenuStripGrid.Items(0).Visible = False
                    Me.ContextMenuStripGrid.Items(1).Visible = False
                    Me.ContextMenuStripGrid.Items(2).Visible = False
                    Me.ContextMenuStripGrid.Items(3).Visible = False
                    Me.ContextMenuStripGrid.Items(4).Visible = False

            End Select



        End If
    End Sub

    Private Sub AnularNotasDeDebitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularNotasDeDebitoToolStripMenuItem.Click
        My.Forms.FrmAgregarRecibo.LblNombreCliente.Text = Me.LblNombres.Text
        My.Forms.FrmAgregarRecibo.LblNumeroFactura.Text = Me.TDGridImpuestos.Columns(1).Text
        My.Forms.FrmAgregarRecibo.TxtMontoRecibo.Text = Me.TDGridImpuestos.Columns(11).Text
        My.Forms.FrmAgregarRecibo.LblMontoFactura.Text = Me.TDGridImpuestos.Columns(11).Text
        My.Forms.FrmAgregarRecibo.DTPFecha.Value = Now

        If Me.OptCordobas.Checked = True Then
            My.Forms.FrmAgregarRecibo.MonedaRecibo = "Cordobas"
        Else
            My.Forms.FrmAgregarRecibo.MonedaRecibo = "Dolares"
        End If

        My.Forms.FrmAgregarRecibo.ShowDialog()


        'My.Forms.FrmRecibos.TxtCodigoClientes.Text = Me.CboCodigoCliente.Text
        'My.Forms.FrmRecibos.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
        'My.Forms.FrmRecibos.ShowDialog()
        'CmdGrabar_Click(sender, e)




    End Sub

    Private Sub AsignarFacturaAlReciboToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaAlReciboToolStripMenuItem.Click

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.OptCordobas.Checked = True Then
            FrmAjustarTodos.OptCordobas.Checked = True
        Else
            FrmAjustarTodos.OptDolares.Checked = True
        End If

        FrmAjustarTodos.DTPFechaFin.Value = Format(Now, "dd/MM/yyyy")
        FrmAjustarTodos.ShowDialog()
    End Sub

    Private Sub AjustarDiferencialCambiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarDiferencialCambiarioToolStripMenuItem.Click
        Dim Consecutivo As Double = 0, SQlstring As String, TipoNota As String = "Credito Clientes", Monto As Double, Moneda As String, CodigoNota As String = "", Descripcion As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroNota As String = "", Consecutivoconserie As Boolean = True

        '/////////////////////////////////////////////////DIFERENCIAL CAMBIARIO AUTOMATICO ////////////////////////////

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        If Me.TDGridImpuestos.Columns(11).Text <> "" Then
            Monto = Me.TDGridImpuestos.Columns(11).Text
        Else
            Monto = 0
        End If

        Select Case Monto
            Case Is > 0 : TipoNota = "Credito Clientes"
            Case Is < 0 : TipoNota = "Debito Clientes"
            Case 0 : Exit Sub
        End Select

        If Me.OptCordobas.Checked = True Then
            Moneda = "Cordobas"
        Else
            Moneda = "Dolares"
        End If


        Select Case TipoNota
            Case "Credito Clientes"

                Quien = "CtasXcob"

                If Moneda = "Cordobas" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif C$')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                ElseIf Moneda = "Dolares" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Credito Clientes Dif $')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                End If





                If Len(Me.LblNombres.Text) > 29 Then
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
                Else
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
                End If

                If Me.OptCordobas.Checked = True Then
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
                Else
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
                End If

                My.Forms.FrmRegistroDebito.TipoNota = "Credito Clientes"
                My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
                My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.NumeroFactura = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
                My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
                My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE CREDITO"
                My.Forms.FrmRegistroDebito.Codigo = CodigoNota
                My.Forms.FrmRegistroDebito.Monto = Monto
                My.Forms.FrmRegistroDebito.TxtObservaciones.Text = "Proceso AJUSTES AUTOMATICOS ZEUS"
                My.Forms.FrmRegistroDebito.ShowDialog()


            Case "Debito Clientes"


                Quien = "CtasXcob"

                If Moneda = "Cordobas" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif C$')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial C$", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                ElseIf Moneda = "Dolares" Then
                    '///////////////////////////////////////////////////////////////////////////////////////////////
                    SQlstring = "SELECT * FROM NotaDebito WHERE (Tipo = 'Debito Clientes Dif $')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        CodigoNota = DataSet.Tables("Consulta").Rows(0)("CodigoNB")
                        Descripcion = DataSet.Tables("Consulta").Rows(0)("Descripcion")
                    Else
                        MsgBox("No Existe Nota de Diferencial $", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If

                End If

                If Len(Me.LblNombres.Text) > 29 Then
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Mid(Me.LblNombres.Text, 1, 29)
                Else
                    My.Forms.FrmRegistroDebito.LblNombre.Text = Me.LblNombres.Text
                End If

                If Me.OptCordobas.Checked = True Then
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Cordobas"
                Else
                    My.Forms.FrmRegistroDebito.LblMoneda.Text = "Dolares"
                End If
                My.Forms.FrmRegistroDebito.TipoNota = "Debito Clientes"
                My.Forms.FrmRegistroDebito.TxtNumeroEnsamble.Text = "-----0-----" 'Format(Consecutivo, "0000#")
                My.Forms.FrmRegistroDebito.LblFactura.Text = Me.TDGridImpuestos.Columns(1).Text
                My.Forms.FrmRegistroDebito.DTPFecha.Value = Me.TDGridImpuestos.Columns(0).Text
                My.Forms.FrmRegistroDebito.TxtCodCliente.Text = Me.CboCodigoCliente.Text
                My.Forms.FrmRegistroDebito.Label1.Text = "NOTAS DE DEBITO"
                My.Forms.FrmRegistroDebito.Codigo = CodigoNota
                My.Forms.FrmRegistroDebito.Monto = Abs(Monto)
                My.Forms.FrmRegistroDebito.TxtObservaciones.Text = "Proceso AJUSTES AUTOMATICOS ZEUS"
                My.Forms.FrmRegistroDebito.ShowDialog()



        End Select





    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAjustes.Click
        Dim Fecha As Date

        If Me.OptCordobas.Checked = True Then
            FrmAjustes.OptCordobas.Checked = True
        Else
            FrmAjustes.OptDolares.Checked = True
        End If

        Fecha = Me.TDGridImpuestos.Columns("Fecha_Factura").Text
        FrmAjustes.CboCodigoCliente.Text = Me.CboCodigoCliente.Text
        FrmAjustes.TxtNombre.Text = Me.LblNombres.Text
        FrmAjustes.DTPFechaIni.Value = Format(Fecha, "dd/MM/yyyy")
        FrmAjustes.DTPFechaFin.Value = Format(Fecha, "dd/MM/yyyy")
        FrmAjustes.ShowDialog()
    End Sub

    Private Sub AsignarFacturaALaNotaDeCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Click
        Dim Saldo As Double

        Saldo = Me.TDGridImpuestos.Columns("Saldo").Text

        If Saldo > 0 Then

            FrmAgregarNotaCredito.ds.Reset()
            FrmAgregarNotaCredito.ds = DatasetReporte.Copy

            FrmAgregarNotaCredito.Numero_Factura = Me.TDGridImpuestos.Columns(1).Text
            FrmAgregarNotaCredito.Fecha_Factura = Me.TDGridImpuestos.Columns(0).Text
            FrmAgregarNotaCredito.MontoFactura = Me.TDGridImpuestos.Columns("Saldo").Text
            FrmAgregarNotaCredito.TxtMontoRecibo.Text = Me.TDGridImpuestos.Columns("Saldo").Text

            If Me.OptCordobas.Checked = True Then
                FrmAgregarNotaCredito.MonedaEstado = "Cordobas"
            ElseIf Me.OptDolares.Checked = True Then
                FrmAgregarNotaCredito.MonedaEstado = "Dolares"
            End If


            FrmAgregarNotaCredito.ShowDialog()

            CmdGrabar_Click(sender, e)

        Else
            MsgBox("La Factura no tiene Saldo Pendiente", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If

    End Sub
End Class