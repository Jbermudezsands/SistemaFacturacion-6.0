Public Class FrmConsultasMedicas
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

            SQLstring = "SELECT Expediente.*, PreConsultas.*, Doctores.Nombre_Doctor + ' ' + Doctores.Apellido_Doctor AS Nombre_Doctor, Consultorio.Nombre_Consultorio FROM  Expediente INNER JOIN PreConsultas ON Expediente.Numero_Expediente = PreConsultas.Numero_Expediente INNER JOIN Consultorio ON PreConsultas.IdConsultorio = Consultorio.IdConsultorio INNER JOIN Doctores ON Consultorio.Codigo_Minsa = Doctores.Codigo_Minsa WHERE (Expediente.Numero_Expediente = '" & Numero_Expediente & "') "
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

                Hora = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy") & " " & Me.LblHora.Text

                Me.TxtHora_Inicio_Consulta.Text = Hora



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


    End Sub

    Private Sub FrmConsultasMedicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()

    End Sub
End Class