Imports System.Data.SqlClient

Public Class FrmConsultasMedicas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdPreConsultas As Double, HoraInicio As Date, IdConsultorio As Double, IdDoctor As Double
    Public dsMedicamento As New DataSet, daMedicamento As New SqlClient.SqlDataAdapter, CmdBuilderMedicamento As New SqlCommandBuilder
    Public dsExamen As New DataSet, daExamen As New SqlClient.SqlDataAdapter, CmdBuilderExamen As New SqlCommandBuilder

    Public Sub Cargar_Grid()


        Dim SqlCompras As String, DataSet As New DataSet

        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT  Cod_Productos, Descripcion, Cantidad, IdConsulta FROM Medicamentos_Consulta  WHERE(IdConsulta = -1000)"
        dsMedicamento = New DataSet
        daMedicamento = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderMedicamento = New SqlCommandBuilder(daMedicamento)
        daMedicamento.Fill(dsMedicamento, "DetalleCompra")
        Me.BindingDetalle.DataSource = dsMedicamento.Tables("DetalleCompra")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT Descripcion, IdConsulta, IdTipoExamen, Facturado, Activo, Pagado  FROM TipoExamen_Consulta WHERE (IdConsulta = -100)"
        dsExamen = New DataSet
        daExamen = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderExamen = New SqlCommandBuilder(daMedicamento)
        daExamen.Fill(dsExamen, "Examen")
        Me.BindingExamenes.DataSource = dsExamen.Tables("Examen")
        Me.TdGridExamenes.DataSource = Me.BindingExamenes
        Me.TdGridExamenes.Columns("Descripcion").Caption = "Descripcion"
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("Descripcion").Width = 259
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("IdConsulta").Visible = False
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("IdTipoExamen").Visible = False
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("Pagado").Visible = False


    End Sub
    Public Sub InsertarRowGridExamen()
        Dim oTabla As DataTable, iPosicion As Double, idConsulta As String

        iPosicion = Me.TdGridExamenes.Row
        idConsulta = Me.TdGridExamenes.Columns("IdConsulta").Text

        CmdBuilderExamen.RefreshSchema()
        oTabla = dsExamen.Tables("Examen").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daExamen.Update(oTabla)
            dsExamen.Tables("Examen").AcceptChanges()
            daExamen.Update(dsExamen.Tables("Examen"))

            Me.TdGridExamenes.Row = iPosicion

        Else
            oTabla = dsExamen.Tables("Examen").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daExamen.Update(oTabla)
                dsExamen.Tables("Examen").AcceptChanges()
                daExamen.Update(dsExamen.Tables("Examen"))
            End If
        End If

        'ActualizarGridInsertRow(idConsulta)

    End Sub
    Public Sub ActualizarGridInsertRowExamen(ByVal idConsulta As Double)
        Dim SqlCompras As String, TipoCompra As String

        dsExamen.Tables("Examen").Reset()

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT Descripcion, IdConsulta, IdTipoExamen, Facturado, Activo, Pagado  FROM TipoExamen_Consulta WHERE(IdConsulta = " & idConsulta & ")"
        dsExamen = New DataSet
        daExamen = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderExamen = New SqlCommandBuilder(daMedicamento)
        daExamen.Fill(dsExamen, "Examen")
        Me.BindingExamenes.DataSource = dsExamen.Tables("Examen")
        Me.TdGridExamenes.DataSource = Me.BindingExamenes
        Me.TdGridExamenes.Columns(0).Caption = "Codigo"
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TdGridExamenes.Columns(1).Caption = "Descripcion"
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns(1).Width = 259
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TdGridExamenes.Columns(2).Caption = "Cantidad"
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("IdConsulta").Visible = False
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("IdTipoExamen").Visible = False
        Me.TdGridExamenes.Splits.Item(0).DisplayColumns("Pagado").Visible = False


    End Sub
    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, idConsulta As String

        iPosicion = Me.TrueDBGridComponentes.Row
        idConsulta = Me.TrueDBGridComponentes.Columns("idConsulta").Text

        CmdBuilderMedicamento.RefreshSchema()
        oTabla = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            daMedicamento.Update(oTabla)
            dsMedicamento.Tables("DetalleCompra").AcceptChanges()
            daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))



            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                daMedicamento.Update(oTabla)
                dsMedicamento.Tables("DetalleCompra").AcceptChanges()
                daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))
            End If
        End If

        'ActualizarGridInsertRow(idConsulta)



    End Sub


    Public Sub ActualizarGridInsertRow(ByVal idConsulta As Double)
        Dim SqlCompras As String, TipoCompra As String

        dsMedicamento.Tables("DetalleCompra").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "SELECT  Cod_Productos, Descripcion, Cantidad, IdConsulta, idMedicamentos FROM Medicamentos_Consulta  WHERE(IdConsulta = " & idConsulta & ")"
        dsMedicamento = New DataSet
        daMedicamento = New SqlDataAdapter(SqlCompras, MiConexion)
        CmdBuilderMedicamento = New SqlCommandBuilder(daMedicamento)
        daMedicamento.Fill(dsMedicamento, "DetalleCompra")
        Me.BindingDetalle.DataSource = dsMedicamento.Tables("DetalleCompra")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False


    End Sub


    Public Sub Cargar_Expediente(ByVal Numero_Expediente As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroExpediente As String, Num(2) As String, RutaOrigen As String
        Dim CodDepartamento As String, IdMunicipio As Double, IdComarca As Double
        Dim ds As New DataSet, Hora As Date

        Try

            If Numero_Expediente = "" Then
                MsgBox("Se necesita el Numeero del Expediente", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub
            End If

            IdPreConsultas = 0

            SQLstring = "SELECT Expediente.*, PreConsultas.*, Doctores.Nombre_Doctor + ' ' + Doctores.Apellido_Doctor AS Nombre_Doctor, Consultorio.Nombre_Consultorio FROM  Expediente INNER JOIN PreConsultas ON Expediente.Numero_Expediente = PreConsultas.Numero_Expediente INNER JOIN Consultorio ON PreConsultas.IdConsultorio = Consultorio.IdConsultorio INNER JOIN Doctores ON Consultorio.Codigo_Minsa = Doctores.Codigo_Minsa WHERE (Expediente.Numero_Expediente = '" & Numero_Expediente & "') AND (PreConsultas.Activo = 'True')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
            DataAdapter.Fill(DataSet, "Expediente")
            If Not DataSet.Tables("Expediente").Rows.Count = 0 Then


                Numero_Expediente = DataSet.Tables("Expediente").Rows(0)("Numero_Expediente")
                Me.IdPreConsultas = DataSet.Tables("Expediente").Rows(0)("idPreConsulta")
                'Num = Numero_Expediente.Split("-")
                'NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")



                Me.TxtCodigo.Text = Numero_Expediente

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombres")) Then
                    Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Apellidos")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Sistolica")) Then
                    Me.TxtSistolica.Text = DataSet.Tables("Expediente").Rows(0)("Sistolica")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Diastolica")) Then
                    Me.TxtDiastolica.Text = DataSet.Tables("Expediente").Rows(0)("Diastolica")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Temperatura")) Then
                    Me.TxtTemperatura.Text = DataSet.Tables("Expediente").Rows(0)("Temperatura")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Azucar_Sangre")) Then
                    Me.TxtAzucarSangre.Text = DataSet.Tables("Expediente").Rows(0)("Azucar_Sangre")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Consultorio")) Then
                    Me.TxtConsultorio.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Consultorio")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Fecha_Hora")) Then
                    Me.TxtHoraPreConsulta.Text = DataSet.Tables("Expediente").Rows(0)("Fecha_Hora")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Doctor")) Then
                    Me.TxtNombre_Doctor.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Doctor")
                End If

                HoraInicio = (Now)
                Me.TxtHora_Inicio_Consulta.Text = Format(CDate(HoraInicio), "dd/MM/yyyy hh:mm:ss tt")





                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdLocalidad")) Then
                    CodDepartamento = DataSet.Tables("Expediente").Rows(0)("IdLocalidad")

                    SQLstring = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos WHERE (Cod_Departamento = '" & CodDepartamento & "')"
                    ds = BuscaConsulta(SQLstring, "Departamento").Copy
                    If ds.Tables("Departamento").Rows.Count <> 0 Then
                        Me.TxtSistolica.Text = ds.Tables("Departamento").Rows(0)("Nombre_Departamento")
                    End If

                End If

                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Expediente & ".bmp"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                Else
                    Me.ImgFoto.Image = My.Resources.NoDisponible
                End If

            Else
                Limpiar_Expediente()
            End If


        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub


    Public Sub Limpiar_Expediente()
        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""
        Me.TxtSistolica.Text = ""
        Me.ImgFoto.Image = My.Resources.NoDisponible
    End Sub



    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim idConsultas As Double, SQLstring As String, ds As New DataSet, Hora As Date



        Grabar_ConsultasMedicas(Me.TxtCodigo.Text, Me.HoraInicio, Now, Me.TxtSintomas.Text, Me.TxtDiagnostico.Text, IdPreConsultas, IdDoctor, IdConsultorio)

        Me.Close()

    End Sub

    Private Sub FrmConsultasMedicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Grid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()

        Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
        Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
        Me.TrueDBGridComponentes.Columns(2).Text = 1
        Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1


    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim IdTipoExamen As Double, Descripcion_Examen As String

        Quien = "TipoExamen"
        My.Forms.FrmConsultas.ShowDialog()

        IdTipoExamen = My.Forms.FrmConsultas.IdConsulta
        Descripcion_Examen = My.Forms.FrmConsultas.Descripcion

        Me.TdGridExamenes.Columns("IdTipoExamen").Text = IdTipoExamen
        Me.TdGridExamenes.Columns("Descripcion").Text = Descripcion_Examen
        Me.TdGridExamenes.Columns("Facturado").Text = 1
        Me.TdGridExamenes.Columns("Activo").Text = 1
        Me.TdGridExamenes.Row = Me.TdGridExamenes.Row + 1

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim Resultado As Double, iPosicion As Double

        Resultado = MsgBox("�Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        iPosicion = Me.BindingDetalle.Position

        If Me.BindingDetalle.Count <> 0 Then

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            oDataRow = dsMedicamento.Tables("DetalleCompra").Rows(iPosicion)
            oDataRow.Delete()

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
            'oTablaBorrados = dsMedicamento.Tables("DetalleCompra").GetChanges(DataRowState.Deleted)
            'If Not IsNothing(oTablaBorrados) Then
            '    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            '    daMedicamento.Update(oTablaBorrados)
            'End If
            'dsMedicamento.Tables("DetalleCompra").AcceptChanges()
            'daMedicamento.Update(dsMedicamento.Tables("DetalleCompra"))

        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.TdGridExamenes.Delete()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Sqlstring As String, ExpedienteNo As String, ds As New DataSet
        Dim IdAdmision As Double
        Dim Hora As Date



        Sqlstring = "SELECT  Consulta.* FROM Consulta WHERE  (Numero_Expediente = '" & ExpedienteNo & "') AND (Activo = 1) ORDER BY idConsulta DESC"
        ds = BuscaConsulta(Sqlstring, "Admision").Copy
        If ds.Tables("Admision").Rows.Count <> 0 Then
            IdAdmision = ds.Tables("Admision").Rows(0)("idAdminsion")
        End If

        'Imprimir_Receta()

    End Sub

    Private Sub TdGridExamenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TdGridExamenes.Click

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub
End Class