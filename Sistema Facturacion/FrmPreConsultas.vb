Public Class FrmPreConsultas
    Dim MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmPreConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        '//////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////CARGO LAS ADMISIONES PARA ESTE PACIENTE ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLstring = "SELECT  Admision.Numero_Expediente , Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombres, Expediente.Telefono, Admision.Fecha_Hora, Admision.idAdminsion AS Numero_Admision, Admision.idPreconsultas AS Numero_Preconsulta, Admision.Activo FROM  Admision INNER JOIN Expediente ON Admision.Numero_Expediente = Expediente.Numero_Expediente  " & _
                    "WHERE  (Admision.Activo = '1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
        DataAdapter.Fill(DataSet, "Admision")
        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Admision")

        Me.TrueDBGridConsultas.Columns("Numero_Expediente").Caption = "Expediente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Expediente").Width = 70
        Me.TrueDBGridConsultas.Columns("Nombres").Caption = "Nombre Paciente"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Nombres").Width = 200
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Telefono").Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Fecha_Hora").Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Numero_Admision").Width = 70
        Me.TrueDBGridConsultas.Columns("Numero_Admision").Caption = "Preconsulta"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Activo").Width = 70
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim NumeroExpediente As String, NumeroAdmision As Double

        NumeroExpediente = Me.TrueDBGridConsultas.Columns("Numero_Expediente").Text
        My.Forms.FrmPreConsultasNuevas.TxtCodigo.Text = NumeroExpediente
        My.Forms.FrmPreConsultasNuevas.Cargar_Expediente(NumeroExpediente)
        My.Forms.FrmPreConsultasNuevas.ShowDialog()



    End Sub
End Class