Public Class FrmRegistroDebito
    Public MiConexion As New SqlClient.SqlConnection(Conexion), MiconexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad), TipoNota As String, ConsecutivoConSerie As Boolean, NumeroFactura As String, NumeroRuc As String, NombreCliente As String, Codigo As String, Monto As Double
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmRegistroDebito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "Historico" Then
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
            Me.Button4.Enabled = False
            Me.Button3.Enabled = False
            Me.CmbSerie.Enabled = False
            Me.DTPFecha.Enabled = False
            ChkFactura.Enabled = False
            ChkSseries.Enabled = False
            ChkTipoCuenta.Enabled = False
            TxtMonto.Enabled = False
            TxtDescripcion.Enabled = False
            CmbCodigo.Enabled = False
            TxtObservaciones.Enabled = False
        Else
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
            Me.Button4.Enabled = True
            Me.Button3.Enabled = True
            Me.CmbSerie.Enabled = True
            Me.DTPFecha.Enabled = True
            ChkFactura.Enabled = True
            ChkSseries.Enabled = True
            ChkTipoCuenta.Enabled = True
            TxtMonto.Enabled = True
            TxtDescripcion.Enabled = True
            CmbCodigo.Enabled = True
            TxtObservaciones.Enabled = True
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS DATOS DEL CLIENTE////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT * FROM Clientes WHERE (Cod_Cliente = '" & Me.TxtCodCliente.Text & "') "
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("RUC")) Then
                NumeroRuc = DataSet.Tables("Clientes").Rows(0)("RUC")
            End If
            NombreCliente = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
        End If
        MiConexion.Close()

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////CARGO LA SERIE PARA CADA USUARIO ////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Usuarios.* FROM Usuarios WHERE (Usuario = '" & NombreUsuario & "')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DefaulUsuario")
        If Not DataSet.Tables("DefaulUsuario").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("DefaulUsuario").Rows(0)("SerieFactura")
        End If
        MiConexion.Close()


        SqlString = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoReciboSerie") = True Then
                    Me.CmbSerie.Visible = True
                    Me.LblNumero.Location = New Point(335, 24)
                    ConsecutivoConSerie = True
                Else
                    Me.CmbSerie.Visible = False
                    Me.LblNumero.Location = New Point(382, 17)
                    ConsecutivoConSerie = False
                End If
            End If

        End If

        If LblMoneda.Text = "Cordobas" Then
            SqlString = "SELECT CodigoNB AS Cod, Descripcion, Tipo FROM NotaDebito WHERE Tipo = '" & TipoNota & "' OR Tipo='" & TipoNota & " Dif C$' "
        Else
            SqlString = "SELECT CodigoNB AS Cod, Descripcion, Tipo FROM NotaDebito WHERE Tipo = '" & TipoNota & "' OR Tipo='" & TipoNota & " Dif $'"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            Me.CmbCodigo.DataSource = DataSet.Tables("Notas")
        End If



        If TipoNota = "Debito Proveedor" Then
            Me.Label2.Text = "Proveedor"
        ElseIf TipoNota = "Credito Proveedor" Then
            Me.Label2.Text = "Proveedor"
        End If

        If Quien = "CtasXcob" Then
            Me.CmbCodigo.Text = Codigo
            Me.TxtMonto.Text = Monto

        Else
            Me.CmbCodigo.Text = ""
            Me.TxtMonto.Text = ""
            Me.TxtDescripcion.Text = ""
        End If

    End Sub

    Private Sub CmbCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCodigo.TextChanged
        Dim SQL As String = "SELECT  *  FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Notas").Rows(0)("Descripcion")) Then
                Me.TxtDescripcion.Text = DataSet.Tables("Notas").Rows(0)("Descripcion")
            End If
        Else
            Me.TxtDescripcion.Text = ""

        End If
    End Sub

    Private Sub TxtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.LostFocus
        Dim Monto As Double
        Monto = Me.TxtMonto.Text
        Me.TxtMonto.Text = Format(Monto, "##,##0.00")
    End Sub

    Private Sub TxtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonto.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Consecutivo As Double, SQlstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroNota As String, TipoCuenta As Boolean


        If Me.ChkTipoCuenta.Checked = True Then
            TipoCuenta = True
        Else
            TipoCuenta = False
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA NOTA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            If ConsecutivoConSerie = False Then
                Select Case TipoNota
                    Case "Debito Clientes" : Consecutivo = BuscaConsecutivo("NotaDebito")
                    Case "Credito Clientes" : Consecutivo = BuscaConsecutivo("NotaCredito")
                    Case "Debito Proveedores" : Consecutivo = BuscaConsecutivo("NotaDebitoProveedor")
                    Case "Credito Proveedores" : Consecutivo = BuscaConsecutivo("NotaCreditoProveedor")
                End Select
                NumeroNota = Format(Consecutivo, "0000#")
            Else
                If Me.ChkSseries.Checked = False Then
                    Select Case TipoNota
                        Case "Debito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaDebito", Me.CmbSerie.Text)
                        Case "Credito Clientes" : Consecutivo = BuscaConsecutivoSerie("NotaCredito", Me.CmbSerie.Text)
                        Case "Debito Proveedores" : Consecutivo = BuscaConsecutivoSerie("NotaDebitoProveedor", Me.CmbSerie.Text)
                        Case "Credito Proveedores" : Consecutivo = BuscaConsecutivoSerie("NotaCreditoProveedor", Me.CmbSerie.Text)
                    End Select
                    NumeroNota = Me.CmbSerie.Text & Format(Consecutivo, "0000#")
                Else
                    Select Case TipoNota
                        Case "Debito Clientes" : Consecutivo = BuscaConsecutivo("NotaDebito")
                        Case "Credito Clientes" : Consecutivo = BuscaConsecutivo("NotaCredito")
                        Case "Debito Proveedores" : Consecutivo = BuscaConsecutivo("NotaDebitoProveedor")
                        Case "Credito Proveedores" : Consecutivo = BuscaConsecutivo("NotaCreditoProveedor")
                    End Select
                    NumeroNota = Format(Consecutivo, "0000#")
                End If
            End If


            '///////////////////////////////BUSCO el tipo de la Nota de Credito o Debito ///////////////////////////////////
            SQlstring = "SELECT  *  FROM NotaDebito WHERE (CodigoNB = '" & Me.CmbCodigo.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                'TipoNota = DataSet.Tables("Clientes").Rows(0)("Tipo")
            End If

        Else
            NumeroNota = Me.TxtNumeroEnsamble.Text
        End If

        If Me.LblFactura.Text = "" Then
            Me.LblFactura.Text = "0000"
        End If

        If Me.TxtMonto.Text = "" Then
            Me.TxtMonto.Text = "0.00"
        End If

        If Me.ChkFactura.Checked = True Then
            Me.LblFactura.Text = "0000"
        End If


        Me.TxtNumeroEnsamble.Text = NumeroNota
        GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, Me.TxtMonto.Text, Me.LblMoneda.Text, Me.TxtCodCliente.Text, Me.LblNombre.Text, Me.TxtObservaciones.Text, True, False, TipoCuenta)
        'InsertarDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, Me.TxtDescripcion.Text, Me.LblFactura.Text, Me.TxtMonto.Text)
        GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, Me.TxtDescripcion.Text, Me.LblFactura.Text, Me.TxtMonto.Text)
        My.Forms.FrmCuentasXCobrar.CmdGrabar.PerformClick()
        MsgBox("Se ha Grabado con Exito!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
        Me.Close()

        Me.DTPFecha.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Moneda As String = ""

        Me.DTPFecha.Enabled = False

        If TipoNota = "Debito Proveedores" Or TipoNota = "Credito Proveedores" Then
            My.Forms.FrmConsultas.CodigoCliente = My.Forms.FrmCuentasXPagar.CboCodigoProveedor.Text
            Quien = "NBPROVEEDORES"
        Else
            My.Forms.FrmConsultas.CodigoCliente = My.Forms.FrmCuentasXCobrar.CboCodigoCliente.Text
            Quien = "NB"
        End If

        My.Forms.FrmConsultas.Tipo = TipoNota
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
            Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
            Cargar_Nota_Debito(DTPFecha.Value, TxtNumeroEnsamble.Text, TipoNota)
        End If
    End Sub

    Public Sub Cargar_Nota_Debito(FechaConsulta As Date, Numero_Nota As String, Tipo_Nota As String)
        Dim SqlString As String, Monto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Moneda As String = "", TasaCambio As Double
        Dim Fecha As String


        Fecha = Format(CDate(FechaConsulta), "yyyy-MM-dd")
        SqlString = "SELECT  IndiceNota.Numero_Nota, IndiceNota.Fecha_Nota, IndiceNota.Tipo_Nota, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente, IndiceNota.Nombre_Cliente, IndiceNota.Observaciones, IndiceNota.Activo, IndiceNota.Contabilizado, NotaDebito.Tipo FROM  IndiceNota INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB WHERE (IndiceNota.Numero_Nota = '" & Me.TxtNumeroEnsamble.Text & "') AND (IndiceNota.Fecha_Nota = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (NotaDebito.Tipo LIKE '%" & Tipo_Nota & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDebito")
        If Not DataSet.Tables("NotaDebito").Rows.Count = 0 Then
            Moneda = DataSet.Tables("NotaDebito").Rows(0)("MonedaNota")
            Me.LblMoneda.Text = DataSet.Tables("NotaDebito").Rows(0)("MonedaNota")
            Me.TxtObservaciones.Text = DataSet.Tables("NotaDebito").Rows(0)("Observaciones")
        End If

        TasaCambio = BuscaTasaCambio(Me.DTPFecha.Text)


        SqlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB WHERE (Detalle_Nota.Numero_Nota = '" & Numero_Nota & "') AND (Detalle_Nota.Fecha_Nota = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (NotaDebito.Tipo  LIKE '%" & Tipo_Nota & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleNotaDebito")
        If Not DataSet.Tables("DetalleNotaDebito").Rows.Count = 0 Then
            Me.CmbCodigo.Text = DataSet.Tables("DetalleNotaDebito").Rows(0)("Tipo_Nota")
            Me.TxtDescripcion.Text = DataSet.Tables("DetalleNotaDebito").Rows(0)("Descripcion")
            Me.LblFactura.Text = DataSet.Tables("DetalleNotaDebito").Rows(0)("Numero_Factura")
            NumeroFactura = DataSet.Tables("DetalleNotaDebito").Rows(0)("Numero_Factura")
            Monto = DataSet.Tables("DetalleNotaDebito").Rows(0)("Monto")
        End If

        If Me.LblFactura.Text = "0000" Then
            Me.ChkFactura.Checked = True
        Else
            Me.ChkFactura.Checked = False
        End If

        If My.Forms.FrmCuentasXCobrar.OptCordobas.Checked = True Then
            Me.LblMoneda.Text = My.Forms.FrmCuentasXCobrar.OptCordobas.Text
            If Moneda = "Cordobas" Then
                Me.TxtMonto.Text = Format(Monto, "##,##0.00")
            Else
                Me.TxtMonto.Text = Format(Monto * TasaCambio, "##,##0.00")
            End If
        Else
            Me.LblMoneda.Text = My.Forms.FrmCuentasXCobrar.OptDolares.Text
            If Moneda = "Dolares" Then
                Me.TxtMonto.Text = Format(Monto, "##,##0.00")
            Else
                Me.TxtMonto.Text = Format(Monto / TasaCambio, "##,##0.00")
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim NumeroNota As String, Monto As Double = 0, NombreCliente = "*******ANULADO*******"
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Anular la Nota?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        NumeroNota = Me.TxtNumeroEnsamble.Text
        GrabaNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, Monto, Me.LblMoneda.Text, Me.TxtCodCliente.Text, NombreCliente, Me.TxtObservaciones.Text, False, True, False)
        AnularDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, NombreCliente, Me.LblFactura.Text, 0)
        'InsertarDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, NombreCliente, Me.LblFactura.Text, Monto)
        'GrabaDetalleNotaDebito(NumeroNota, Me.DTPFecha.Text, Me.CmbCodigo.Text, NombreCliente, Me.LblFactura.Text, Monto)



        My.Forms.FrmCuentasXCobrar.CmdGrabar.PerformClick()
        MsgBox("Se ha Anulado con Exito!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ArepNotaDebito As New ArepNotaDebito
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim NombreEmpresa As String = "", DireccionEmpresa As String = "", Ruc As String = "", RutaLogo As String = ""
        Dim NumeroNota As String, FechaNota As String, SqlString As String, TipoImpresion As String

        If Me.CmbCodigo.Text = "" Then
            Exit Sub
        End If


        Button1_Click(sender, e)



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                Ruc = "R.U.C NO " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If

        If Dir(RutaLogo) <> "" Then
            ArepNotaDebito.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If
        ArepNotaDebito.LblTitulo.Text = NombreEmpresa
        ArepNotaDebito.LblDireccion.Text = DireccionEmpresa
        ArepNotaDebito.LblRuc.Text = Ruc
        ArepNotaDebito.TxtObservaciones.Text = Me.TxtObservaciones.Text


        NumeroNota = Me.TxtNumeroEnsamble.Text
        FechaNota = Format(Me.DTPFecha.Value, "yyyy-MM-dd")





        If TipoNota = "Credito Clientes" Then
            TipoImpresion = "Notas Credito"
        ElseIf TipoNota = "Debito Clientes" Then
            TipoImpresion = "Notas Debito"
        End If


        SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Coordenadas")
        If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
            Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
                Case "Papel en Blanco"

                    Button1_Click(sender, e)

                    SqlDatos = "SELECT     Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente, IndiceNota.Nombre_Cliente, IndiceNota.Observaciones, Clientes.RUC,NotaDebito.Tipo FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN Clientes ON IndiceNota.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB  " &
                               "WHERE  (Detalle_Nota.Numero_Nota = '" & NumeroNota & "') AND (Detalle_Nota.Fecha_Nota = CONVERT(DATETIME, '" & FechaNota & "', 102)) AND (Detalle_Nota.Tipo_Nota = '" & Me.CmbCodigo.Text & "')"

                    SQL.ConnectionString = Conexion
                    SQL.SQL = SqlDatos
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepNotaDebito.Document
                    My.Application.DoEvents()
                    ArepNotaDebito.DataSource = SQL
                    ArepNotaDebito.Run(False)
                    ViewerForm.Show()

                Case "Personalizado"
                    Button1_Click(sender, e)
                    Me.PrintNota.Print()


                Case "Papel en Blanco Standard"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepNotaDebito.Document
                    My.Application.DoEvents()
                    ArepNotaDebito.DataSource = SQL
                    ArepNotaDebito.Run(False)
                    ViewerForm.Show()



            End Select
        End If








    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged

    End Sub

    Private Sub ChkFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFactura.CheckedChanged
        If Me.ChkFactura.Checked = True Then
            Me.LblFactura.Text = "0000"
        Else
            Me.LblFactura.Text = NumeroFactura
        End If
    End Sub

    Private Sub ChkSseries_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSseries.CheckedChanged
        If Me.ChkSseries.Checked = True Then
            Me.CmbSerie.Visible = False
        Else
            Me.CmbSerie.Visible = True

        End If


    End Sub

    Private Sub PrintNota_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintNota.PrintPage
        Dim prFont As New Font("Arial", 15, FontStyle.Bold)
        Dim SQlString As String, TipoImpresion As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim TipoCoordenadas As String, X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer, X3 As Integer, Y3 As Integer, X4 As Integer, Y4 As Integer, X5 As Integer, Y5 As Integer, X6 As Integer, Y6 As Integer, X7 As Integer, Y7 As Integer, X28 As Integer, Y28 As Integer, X8 As Integer, Y8 As Integer, X9 As Integer, Y9 As Integer, X10 As Integer, Y10 As Integer, X11 As Integer, Y11 As Integer, CarateresLinea As Integer
        Dim Observaciones As String = "Esta es una impresion de prueba de las notas de debito del sistema Zeus Facturacion, con esto comprobamos el tamaño de las lineas configuradas en observaciones para imprimir dentro del formato sin problemas"
        Dim MontoLetras As String, MontoDolar As Double = 0, Monto As Double = 0, CaracteresObservacion As Integer = 0, CadenaDescripcion As String



        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        prFont = New Font("Arial", 8, FontStyle.Regular)

        TipoImpresion = ""
        If TipoNota = "Credito Clientes" Then
            TipoImpresion = "Notas Credito"
        ElseIf TipoNota = "Debito Clientes" Then
            TipoImpresion = "Notas Debito"
        End If


        If Me.ChkSseries.Checked = False Then
            TipoCoordenadas = TipoImpresion

        Else
            TipoCoordenadas = TipoImpresion & FrmPersonalizar.CmbSerieImprime.Text
        End If
        SQlString = "SELECT * FROM Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"


        Select Case TipoImpresion
            Case "Notas Credito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    CarateresLinea = DataSet.Tables("Coordenadas").Rows(0)("CaracteresLineas")
                    X1 = DataSet.Tables("Coordenadas").Rows(0)("X1")
                    Y1 = DataSet.Tables("Coordenadas").Rows(0)("Y1")
                    X2 = DataSet.Tables("Coordenadas").Rows(0)("X2")
                    Y2 = DataSet.Tables("Coordenadas").Rows(0)("Y2")
                    X3 = DataSet.Tables("Coordenadas").Rows(0)("X3")
                    Y3 = DataSet.Tables("Coordenadas").Rows(0)("Y3")
                    X4 = DataSet.Tables("Coordenadas").Rows(0)("X4")
                    Y4 = DataSet.Tables("Coordenadas").Rows(0)("Y4")
                    X5 = DataSet.Tables("Coordenadas").Rows(0)("X5")
                    Y5 = DataSet.Tables("Coordenadas").Rows(0)("Y5")
                    X6 = DataSet.Tables("Coordenadas").Rows(0)("X6")
                    Y6 = DataSet.Tables("Coordenadas").Rows(0)("Y6")
                    X7 = DataSet.Tables("Coordenadas").Rows(0)("X7")
                    Y7 = DataSet.Tables("Coordenadas").Rows(0)("Y7")
                    X8 = DataSet.Tables("Coordenadas").Rows(0)("X8")
                    Y8 = DataSet.Tables("Coordenadas").Rows(0)("Y8")
                    X9 = DataSet.Tables("Coordenadas").Rows(0)("X9")
                    Y9 = DataSet.Tables("Coordenadas").Rows(0)("Y9")
                    X10 = DataSet.Tables("Coordenadas").Rows(0)("X10")
                    Y10 = DataSet.Tables("Coordenadas").Rows(0)("Y10")
                    X11 = DataSet.Tables("Coordenadas").Rows(0)("X11")
                    Y11 = DataSet.Tables("Coordenadas").Rows(0)("Y11")
                    X28 = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Y28 = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                    If Not IsDBNull(DataSet.Tables("Coordenadas").Rows(0)("CaracteresObservacion")) Then
                        CaracteresObservacion = DataSet.Tables("Coordenadas").Rows(0)("CaracteresObservacion")
                    End If
                End If

            Case "Notas Debito"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Coordenadas")
                If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
                    CarateresLinea = DataSet.Tables("Coordenadas").Rows(0)("CaracteresLineas")
                    X1 = DataSet.Tables("Coordenadas").Rows(0)("X1")
                    Y1 = DataSet.Tables("Coordenadas").Rows(0)("Y1")
                    X2 = DataSet.Tables("Coordenadas").Rows(0)("X2")
                    Y2 = DataSet.Tables("Coordenadas").Rows(0)("Y2")
                    X3 = DataSet.Tables("Coordenadas").Rows(0)("X3")
                    Y3 = DataSet.Tables("Coordenadas").Rows(0)("Y3")
                    X4 = DataSet.Tables("Coordenadas").Rows(0)("X4")
                    Y4 = DataSet.Tables("Coordenadas").Rows(0)("Y4")
                    X5 = DataSet.Tables("Coordenadas").Rows(0)("X5")
                    Y5 = DataSet.Tables("Coordenadas").Rows(0)("Y5")
                    X6 = DataSet.Tables("Coordenadas").Rows(0)("X6")
                    Y6 = DataSet.Tables("Coordenadas").Rows(0)("Y6")
                    X7 = DataSet.Tables("Coordenadas").Rows(0)("X7")
                    Y7 = DataSet.Tables("Coordenadas").Rows(0)("Y7")
                    X8 = DataSet.Tables("Coordenadas").Rows(0)("X8")
                    Y8 = DataSet.Tables("Coordenadas").Rows(0)("Y8")
                    X9 = DataSet.Tables("Coordenadas").Rows(0)("X9")
                    Y9 = DataSet.Tables("Coordenadas").Rows(0)("Y9")
                    X10 = DataSet.Tables("Coordenadas").Rows(0)("X10")
                    Y10 = DataSet.Tables("Coordenadas").Rows(0)("Y10")
                    X11 = DataSet.Tables("Coordenadas").Rows(0)("X11")
                    Y11 = DataSet.Tables("Coordenadas").Rows(0)("Y11")
                    X28 = DataSet.Tables("Coordenadas").Rows(0)("X28")
                    Y28 = DataSet.Tables("Coordenadas").Rows(0)("Y28")
                    If Not IsDBNull(DataSet.Tables("Coordenadas").Rows(0)("CaracteresObservacion")) Then
                        CaracteresObservacion = DataSet.Tables("Coordenadas").Rows(0)("CaracteresObservacion")
                    End If
                End If

        End Select

        Monto = Me.TxtMonto.Text
        MontoLetras = Letras(Monto, Me.LblMoneda.Text)
        If Me.LblMoneda.Text = "Cordobas" Then
            Monto = Me.TxtMonto.Text
            MontoDolar = Format(Monto / BuscaTasaCambio(Me.DTPFecha.Value), "##,##0.00")
        Else
            Monto = Format(Monto * BuscaTasaCambio(Me.DTPFecha.Value), "##,##0.00")
            MontoDolar = Me.TxtMonto.Text
        End If

        If X1 <> 0 And Y1 <> 0 Then
            e.Graphics.DrawString(Format(Me.DTPFecha.Value, "dd/MM/yyyy"), prFont, Brushes.Black, X1, Y1)
        End If
        If X2 <> 0 And Y2 <> 0 Then
            e.Graphics.DrawString(Me.TxtNumeroEnsamble.Text, prFont, Brushes.Black, X2, Y2)
        End If
        If X3 <> 0 And Y3 <> 0 Then
            e.Graphics.DrawString(NombreCliente, prFont, Brushes.Black, X3, Y3)
        End If
        If X4 <> 0 And Y4 <> 0 Then
            e.Graphics.DrawString(Me.CmbCodigo.Text, prFont, Brushes.Black, X4, Y4)
        End If
        If X5 <> 0 And Y5 <> 0 Then
            e.Graphics.DrawString(Me.TxtDescripcion.Text, prFont, Brushes.Black, X5, Y5)
        End If
        If X6 <> 0 And Y6 <> 0 Then
            e.Graphics.DrawString(Format(Monto, "##,##0.00"), prFont, Brushes.Black, X6, Y6)
        End If
        If X7 <> 0 And Y7 <> 0 Then

            Dim Cadena As String, Caracter As Integer, ContadorLinea As Integer

            CadenaDescripcion = Me.TxtObservaciones.Text
            Cadena = Me.TxtObservaciones.Text
            Caracter = 1
            ContadorLinea = 0

            If Len(Cadena) > CaracteresObservacion Then

                Do While Len(Cadena) >= CaracteresObservacion
                    If Caracter = 1 Then
                        Cadena = Mid(Cadena, 1, CaracteresObservacion)
                        e.Graphics.DrawString(Cadena, prFont, Brushes.Black, X7, Y7)
                        Caracter = Caracter + CaracteresObservacion

                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA SIGUIENTE/////////////////
                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                        If Len(Cadena) < CaracteresObservacion Then
                            '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                            ContadorLinea = ContadorLinea + 1
                            e.Graphics.DrawString(Cadena, prFont, Brushes.Black, X7, Y7 + (5 * ContadorLinea))
                            Caracter = Caracter + CaracteresObservacion
                        End If
                    Else
                        ContadorLinea = ContadorLinea + 1
                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                        e.Graphics.DrawString(Cadena, prFont, Brushes.Black, X7, Y7 + (5 * ContadorLinea))
                        Caracter = Caracter + CaracteresObservacion

                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA/////////////////
                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                        If Len(Cadena) < CaracteresObservacion Then
                            '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                            ContadorLinea = ContadorLinea + 1
                            e.Graphics.DrawString(Cadena, prFont, Brushes.Black, X7, Y7 + (5 * ContadorLinea))
                            Caracter = Caracter + CaracteresObservacion
                        End If


                    End If


                Loop

            Else
                e.Graphics.DrawString(Cadena, prFont, Brushes.Black, X7, Y7)

            End If

        End If
        If X8 <> 0 And Y8 <> 0 Then
            e.Graphics.DrawString(NumeroRuc, prFont, Brushes.Black, X8, Y8)
        End If
        If X9 <> 0 And Y9 <> 0 Then
            e.Graphics.DrawString(Format(MontoDolar, "##,##0.00"), prFont, Brushes.Black, X9, Y9)
        End If
        If X10 <> 0 And Y10 <> 0 Then
            e.Graphics.DrawString(Format(Monto, "##,##0.00"), prFont, Brushes.Black, X10, Y10)
        End If
        If X11 <> 0 And Y11 <> 0 Then
            e.Graphics.DrawString(Format(MontoDolar, "##,##0.00"), prFont, Brushes.Black, X11, Y11)
        End If
        If X28 <> 0 And Y28 <> 0 Then
            e.Graphics.DrawString(MontoLetras, prFont, Brushes.Black, X28, Y28)
        End If
    End Sub

    Private Sub ChkTipoCuenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTipoCuenta.CheckedChanged
        Dim SqlString As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.ChkTipoCuenta.Checked = True Then
            'Quien = "Cuenta"
            'My.Forms.FrmConsultas.ShowDialog()
            SqlString = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas "

            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiconexionContabilidad)
            DataAdapter.Fill(DataSet, "Cuenta")
            If Not DataSet.Tables("Cuenta").Rows.Count = 0 Then
                Me.CmbCodigo.DataSource = DataSet.Tables("Cuenta")
            End If



        Else
            If LblMoneda.Text = "Cordobas" Then
                SqlString = "SELECT CodigoNB AS Cod, Descripcion, Tipo FROM NotaDebito WHERE Tipo = '" & TipoNota & "' OR Tipo='" & TipoNota & " Dif C$' "
            Else
                SqlString = "SELECT CodigoNB AS Cod, Descripcion, Tipo FROM NotaDebito WHERE Tipo = '" & TipoNota & "' OR Tipo='" & TipoNota & " Dif $'"
            End If
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Notas")
            If Not DataSet.Tables("Notas").Rows.Count = 0 Then
                Me.CmbCodigo.DataSource = DataSet.Tables("Notas")
            End If
        End If

    End Sub
End Class