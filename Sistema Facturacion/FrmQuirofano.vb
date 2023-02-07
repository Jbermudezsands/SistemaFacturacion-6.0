Public Class FrmQuirofano

    Public Sub Grabar_RegistroQuirofano(ByVal Numero_Expediente As String, ByVal Fecha_Inicio As Date, ByVal Fecha_Fin As Date, ByVal Activo As Boolean, ByVal IdDoctor As String, ByVal Diagnostico As String, ByVal Prontuario As String, ByVal Anestecista As String, ByVal Ayudante As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim ds As New DataSet, idConsultas As Double, i As Double, Cont As Double


        If Numero_Expediente = "" Then
            MsgBox("Se necesita el codigo del Expediente", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If


        SQLstring = "SELECT  Quirofano.*  FROM Quirofano WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1)"
        ds = BuscaConsulta(SQLstring, "PreConsulta").Copy
        If ds.Tables("PreConsulta").Rows.Count <> 0 Then
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "UPDATE [Quirofano] SET  [Fecha_Hora_Fin] = '" & Format(Fecha_Fin, "dd/MM/yyyy HH:mm:ss") & "' ,[Activo] = 0  WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.Timer2.Enabled = False
            Me.BtnSalida.Visible = False
            Me.BtnIngreso.Visible = False
        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Quirofano] ([Numero_Expediente],[Fecha_Hora_Inicio],[Fecha_Hora_Fin],[Activo],[IdDoctor_CodigoMinsa],[Diagnostico],[Prontuario],[Anestecista_CodigoMinsa],[Ayudante_CodigoMinsa],[Tecnico_Quirofano],[Tipo_Cirugia]) VALUES ('" & Numero_Expediente & "'  ,'" & Format(Fecha_Inicio, "dd/MM/yyyy HH:mm:ss") & "' ,'" & Format(Fecha_Inicio, "dd/MM/yyyy HH:mm:ss") & "',1, '" & IdDoctor & "', '" & Diagnostico & "', '" & Prontuario & "',  '" & Anestecista & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Me.Timer1.Enabled = False
            Me.BtnIngreso.Visible = False
            Me.BtnSalida.Visible = True
        End If


        MsgBox("Registro Completo", MsgBoxStyle.Exclamation, "Zeus Facturacion")

    End Sub
    Public Sub Limpiar_Expediente()

        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.TxtLetra.Text = ""
        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""

        Me.TxtNombreEmergencia.Text = ""
        Me.TxtTelefonoEmergencia.Text = ""
        Me.TxtDireccionEmergencia.Text = ""

        Me.ImgFoto.Image = My.Resources.NoDisponible

        Me.Timer1.Enabled = True
        Me.Timer2.Enabled = True
        Me.BtnIngreso.Visible = True
        Me.BtnSalida.Visible = True


    End Sub

    Public Sub Cargar_Expediente(ByVal Numero_Expediente As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroExpediente As String, Num(2) As String, RutaOrigen As String, Fecha As Date
        Dim ds As New DataSet

        Try

            If Numero_Expediente = "" Then
                MsgBox("Se necesita el Numeero del Expediente", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub

            End If

            SQLstring = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQLstring, MiConexion)
            DataAdapter.Fill(DataSet, "Expediente")
            If Not DataSet.Tables("Expediente").Rows.Count = 0 Then

                Numero_Expediente = DataSet.Tables("Expediente").Rows(0)("Numero_Expediente")
                Num = Numero_Expediente.Split("-")
                NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                Me.TxtLetra.Text = Num(0)
                Me.TxtCodigo.Text = Format(CDbl(Num(1)), "00000#")

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombres")) Then
                    Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Apellidos")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Emergencia")) Then
                    Me.TxtNombreEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Emergencia")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Telefono_Emergencia")) Then
                    Me.TxtTelefonoEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Telefono_Emergencia")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Direccion_Emergencia")) Then
                    Me.TxtDireccionEmergencia.Text = DataSet.Tables("Expediente").Rows(0)("Direccion_Emergencia")
                End If

                Dim CodDepartamento As String, IdMunicipio As Double, IdComarca As Double


                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Expediente & ".bmp"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                Else
                    Me.ImgFoto.Image = My.Resources.NoDisponible
                End If


                '////////////////////////////////////////////////////////////////////////////
                '//////////////////////VALIDO EL USO DEL QUIROFANO /////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////

                SQLstring = "SELECT  Quirofano.*  FROM Quirofano WHERE (Numero_Expediente = '" & Numero_Expediente & "') AND (Activo = 1)"
                ds = BuscaConsulta(SQLstring, "PreConsulta").Copy
                If ds.Tables("PreConsulta").Rows.Count <> 0 Then
                    Me.Timer1.Enabled = False
                    Me.Timer2.Enabled = True
                    Me.BtnIngreso.Visible = False
                    Me.BtnSalida.Visible = True

                    If Not IsDBNull(ds.Tables("PreConsulta").Rows(0)("Fecha_Hora_Inicio")) Then
                        Fecha = ds.Tables("PreConsulta").Rows(0)("Fecha_Hora_Inicio")

                        Me.DTPFecha.Text = Format(Fecha, "dd/MM/yyyy")
                        Me.LblHora.Text = Format(Fecha, "hh:mm:ss tt")
                    End If
                Else
                    Me.Timer1.Enabled = True
                    Me.Timer2.Enabled = True
                    Me.BtnIngreso.Visible = True
                    Me.BtnSalida.Visible = True
                End If



            Else
                Limpiar_Expediente()
            End If


        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.LblHora2.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Quien = "Expediente"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Cargar_Expediente(My.Forms.FrmConsultas.Codigo)
        End If
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngreso.Click
        Dim Numero_Expediente As String

        Numero_Expediente = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
        Grabar_RegistroQuirofano(Numero_Expediente, Now, Now, True, Me.txtIdCirujano.Text, Me.TxtSintomas.Text, Me.TxtDiagnostico.Text, Me.txtIdAnestecista.Text, Me.txtIdDoctorAyudante.Text)
    End Sub

    Private Sub BtnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalida.Click
        Dim Numero_Expediente As String

        Numero_Expediente = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
        Grabar_RegistroQuirofano(Numero_Expediente, Now, Now, True, Me.txtIdCirujano.Text, Me.TxtSintomas.Text, Me.TxtDiagnostico.Text, Me.txtIdAnestecista.Text, Me.txtIdDoctorAyudante.Text)
    End Sub

    Private Sub FrmQuirofano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class