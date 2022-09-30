Public Class FrmAdmision
    Public PNumero_Expediente As String
    Public Sub Imprimir_Admision(ByVal IdAdmision As Double)
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepAdmision As New ArepAdmision, Sqldatos As String, RutaLogo As String

        SqlString = "SELECT   Admision.idAdminsion, Admision.Numero_Expediente, Admision.Fecha_Hora, Admision.Activo, Admision.Procesado, Admision.Cancelado, Admision.idPreconsultas, Expediente.Nombres + ' ' + Expediente.Apellidos AS Nombres FROM Admision INNER JOIN  Expediente ON Admision.Numero_Expediente = Expediente.Numero_Expediente "

        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString

        Bitacora(Now, NombreUsuario, "Admision", "Se Imprimio la Admision: " & IdAdmision)

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepAdmision.Document
        My.Application.DoEvents()
        ArepAdmision.DataSource = SQL
        ArepAdmision.Run(False)
        ViewerForm.Show()

    End Sub

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

            SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Expediente")
            If Not DataSet.Tables("Expediente").Rows.Count = 0 Then

                PNumero_Expediente = DataSet.Tables("Expediente").Rows(0)("Numero_Expediente")
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


                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdComarca")) Then
                    IdComarca = DataSet.Tables("Expediente").Rows(0)("IdComarca")

                    SqlString = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdComarca & "') AND (Tipo = 'Comarca')"
                    ds = BuscaConsulta(SqlString, "Comarca").Copy
                    If ds.Tables("Comarca").Rows.Count <> 0 Then
                        Me.TxtComarca.Text = ds.Tables("Comarca").Rows(0)("Nombre_Municipio")
                    End If

                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdMunicipio")) Then
                    IdMunicipio = DataSet.Tables("Expediente").Rows(0)("IdMunicipio")

                    SqlString = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdMunicipio & "') AND (Tipo = 'Municipio')"
                    ds = BuscaConsulta(SqlString, "Municipio").Copy
                    If ds.Tables("Municipio").Rows.Count <> 0 Then
                        Me.TxtMunicipio.Text = ds.Tables("Municipio").Rows(0)("Nombre_Municipio")
                    End If

                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdLocalidad")) Then
                    CodDepartamento = DataSet.Tables("Expediente").Rows(0)("IdLocalidad")

                    SqlString = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos WHERE (Cod_Departamento = '" & CodDepartamento & "')"
                    ds = BuscaConsulta(SqlString, "Departamento").Copy
                    If ds.Tables("Departamento").Rows.Count <> 0 Then
                        Me.TxtLocalidad.Text = ds.Tables("Departamento").Rows(0)("Nombre_Departamento")
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


    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Quien = "Expediente"
        PNumero_Expediente = ""
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Cargar_Expediente(My.Forms.FrmConsultas.Codigo)
        End If
    End Sub


    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Public Sub Limpiar_Expediente()

        Me.TxtLetra.Text = ""
        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""
        Me.TxtComarca.Text = ""
        Me.TxtMunicipio.Text = ""
        Me.TxtLocalidad.Text = ""
        Me.ImgFoto.Image = My.Resources.NoDisponible
    End Sub

    Private Sub FrmAdmision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.ImgFoto.Image = My.Resources.NoDisponible
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim Hora As Date

        If PNumero_Expediente = "" Then
            MsgBox("Es necesario un Numero Expediente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Hora = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy") & " " & Me.LblHora.Text

        Grabar_Admision(PNumero_Expediente, Hora, True, False, False, 0)
        Limpiar_Expediente()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click



    End Sub
End Class