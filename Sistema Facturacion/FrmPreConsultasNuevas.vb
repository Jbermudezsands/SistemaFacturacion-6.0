Public Class FrmPreConsultasNuevas
    Public Numero_Expediente As String, Numero_Admision As Double, Hora_Admision As Date, Id_Consultorio As Double = 0



    Public Sub Cargar_Expediente(ByVal Numero_Expediente As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroExpediente As String, Num(2) As String, RutaOrigen As String
        Dim CodDepartamento As String, IdMunicipio As Double, IdComarca As Double
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
                'Num = Numero_Expediente.Split("-")
                'NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")

                Me.TxtCodigo.Text = Numero_Expediente

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombres")) Then
                    Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Apellidos")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
                End If


                'If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdComarca")) Then
                '    IdComarca = DataSet.Tables("Expediente").Rows(0)("IdComarca")

                '    SQLstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdComarca & "') AND (Tipo = 'Comarca')"
                '    ds = BuscaConsulta(SQLstring, "Comarca").Copy
                '    If ds.Tables("Comarca").Rows.Count <> 0 Then
                '        Me.TxtComarca.Text = ds.Tables("Comarca").Rows(0)("Nombre_Municipio")
                '    End If

                'End If
                'If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdMunicipio")) Then
                '    IdMunicipio = DataSet.Tables("Expediente").Rows(0)("IdMunicipio")

                '    SQLstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdMunicipio & "') AND (Tipo = 'Municipio')"
                '    ds = BuscaConsulta(SQLstring, "Municipio").Copy
                '    If ds.Tables("Municipio").Rows.Count <> 0 Then
                '        Me.TxtMunicipio.Text = ds.Tables("Municipio").Rows(0)("Nombre_Municipio")
                '    End If

                'End If

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

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub FrmPreConsultasNuevas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim Hora As Date, idAdmision As Double

        If Me.TxtCodigo.Text = "" Then
            MsgBox("Es Necesario Digitar el Numero Expediente", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtSistolica.Text = "" Then
            MsgBox("Es Necesario Digitar la Sistolica", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtDiastolica.Text = "" Then
            MsgBox("Es Necesario Digitar la Diastolica", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtTemperatura.Text = "" Then
            MsgBox("Es Necesario Digitar la Temperatura", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtAzucarSangre.Text = "" Then
            MsgBox("Es Necesario Digitar el Azucar en Sangre", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.Id_Consultorio = 0 Then
            MsgBox("Seleccione el Consultorio", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtTalla.Text) Then
            Me.TxtTalla.Text = 0
        End If

        If Not IsNumeric(Me.TxtPeso.Text) Then
            Me.TxtPeso.Text = 0
        End If


        Hora = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy") & " " & Me.LblHora.Text


        Grabar_PreConsultas(Me.TxtCodigo.Text, Hora, True, False, False, Numero_Admision, Me.TxtSistolica.Text, Me.TxtDiastolica.Text, Me.TxtTemperatura.Text, Me.TxtAzucarSangre.Text, Me.Id_Consultorio, Me.TxtTalla.Text, Me.TxtPeso.Text)
        My.Forms.FrmPreConsultas.Cargar_PreConsultas()
        Limpiar_Expediente()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Consultorio"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtNombre.Text = My.Forms.FrmConsultas.Descripcion2
        Me.TxtConsultorio.Text = My.Forms.FrmConsultas.Descripcion
        Me.Id_Consultorio = My.Forms.FrmConsultas.IdConsulta
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class