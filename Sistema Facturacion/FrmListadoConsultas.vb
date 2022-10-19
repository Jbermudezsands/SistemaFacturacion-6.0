Public Class FrmListadoConsultas
    Public Id_Consultorio As Double
    Dim MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Sub Cargar_PreConsultas()
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////CARGO LAS ADMISIONES PARA ESTE PACIENTE ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLstring = "SELECT PreConsultas.Numero_Expediente, Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombres, PreConsultas.Fecha_Hora, PreConsultas.Activo,  PreConsultas.idAdmision, PreConsultas.IdConsultorio  FROM  PreConsultas INNER JOIN Expediente ON PreConsultas.Numero_Expediente = Expediente.Numero_Expediente  WHERE (Activo = 1) AND (IdConsultorio = " & Me.Id_Consultorio & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
        DataAdapter.Fill(DataSet, "PreConsultas")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("PreConsultas")
        Me.TrueDBGridConsultas.Columns("Numero_Expediente").Caption = "Expediente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Expediente").Width = 70
        Me.TrueDBGridConsultas.Columns("Nombres").Caption = "Nombre Paciente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Nombres").Width = 200
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Fecha_Hora").Width = 110
        Me.TrueDBGridConsultas.Columns("Fecha_Hora").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Admision").Width = 70
        'Me.TrueDBGridConsultas.Columns("Numero_Admision").Caption = "No Admision"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Activo").Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("idAdmision").Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("IdConsultorio").Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Consultorio"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtNombre.Text = My.Forms.FrmConsultas.Descripcion2
        Me.TxtConsultorio.Text = My.Forms.FrmConsultas.Descripcion
        Me.Id_Consultorio = My.Forms.FrmConsultas.IdConsulta
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cargar_PreConsultas()
    End Sub

    Private Sub FrmListadoConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim NumeroExpediente As String, NumeroAdmision As Double

        NumeroExpediente = Me.TrueDBGridConsultas.Columns("Numero_Expediente").Text
        My.Forms.FrmConsultasMedicas.TxtCodigo.Text = NumeroExpediente
        My.Forms.FrmConsultasMedicas.TxtHoraAdmision.Text = Me.TrueDBGridConsultas.Columns("Fecha_Hora").Text
        My.Forms.FrmConsultasMedicas.Cargar_Expediente(NumeroExpediente)
        My.Forms.FrmConsultasMedicas.ShowDialog()
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
End Class