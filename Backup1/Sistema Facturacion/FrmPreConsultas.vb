Public Class FrmPreConsultas
    Dim MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmPreConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cargar_PreConsultas()

    End Sub
    Public Sub Cargar_PreConsultas()
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////CARGO LAS ADMISIONES PARA ESTE PACIENTE ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLstring = "SELECT  Admision.Numero_Expediente , Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombres, Expediente.Telefono, Admision.Fecha_Hora, Admision.idAdminsion AS Numero_Admision, Admision.idPreconsultas AS Preconsulta, Admision.Activo FROM  Admision INNER JOIN Expediente ON Admision.Numero_Expediente = Expediente.Numero_Expediente  " & _
                    "WHERE  (Admision.Activo = '1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
        DataAdapter.Fill(DataSet, "Admision")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Admision")

        Me.TrueDBGridConsultas.Columns("Numero_Expediente").Caption = "Expediente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Expediente").Width = 70
        Me.TrueDBGridConsultas.Columns("Nombres").Caption = "Nombre Paciente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Nombres").Width = 200
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Telefono").Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Fecha_Hora").Width = 110
        Me.TrueDBGridConsultas.Columns("Fecha_Hora").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Admision").Width = 70
        Me.TrueDBGridConsultas.Columns("Numero_Admision").Caption = "No Admision"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Activo").Width = 70
    End Sub


    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim NumeroExpediente As String, NumeroAdmision As Double

        NumeroExpediente = Me.TrueDBGridConsultas.Columns("Numero_Expediente").Text
        My.Forms.FrmPreConsultasNuevas.TxtCodigo.Text = NumeroExpediente
        My.Forms.FrmPreConsultasNuevas.TxtHoraAdmision.Text = Me.TrueDBGridConsultas.Columns("Fecha_Hora").Text
        My.Forms.FrmPreConsultasNuevas.Cargar_Expediente(NumeroExpediente)
        My.Forms.FrmPreConsultasNuevas.Numero_Admision = Me.TrueDBGridConsultas.Columns("Numero_Admision").Text
        My.Forms.FrmPreConsultasNuevas.ShowDialog()



    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Sqlstring As String, ExpedienteNo As String, ds As New DataSet
        Dim IdAdmision As Double
        Dim Hora As Date

        ExpedienteNo = Me.TrueDBGridConsultas.Columns("Numero_Expediente").Text
        Hora = Me.TrueDBGridConsultas.Columns("Fecha_Hora").Text

        Sqlstring = "SELECT  Admision.* FROM Admision WHERE  (Numero_Expediente = '" & ExpedienteNo & "') AND (Activo = 1) ORDER BY Admision.idAdminsion DESC"
        ds = BuscaConsulta(Sqlstring, "Admision").Copy
        If ds.Tables("Admision").Rows.Count <> 0 Then
            IdAdmision = ds.Tables("Admision").Rows(0)("idAdminsion")
        End If

        Imprimir_Admision(IdAdmision)

    End Sub
End Class