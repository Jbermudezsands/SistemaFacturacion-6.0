Public Class FrmPreConsultasNuevas
    Public Numero_Expediente As String, Numero_Admision As Double



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

    Public Sub Limpiar_Expediente()

        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""
        Me.TxtLocalidad.Text = ""
        Me.ImgFoto.Image = My.Resources.NoDisponible
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub FrmPreConsultasNuevas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class