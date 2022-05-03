Public Class FrmExpediente
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Existe As Boolean = False
    Public Function BuscaConsulta(ByVal Sqlstring As String, ByVal Nombre As String) As DataSet
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, Nombre)
        If Not DataSet.Tables(Nombre).Rows.Count = 0 Then
            BuscaConsulta = DataSet.Copy
        End If

        BuscaConsulta = DataSet.Copy

    End Function


    Public Sub Limpiar_Expediente()

        Me.TxtLetra.Text = ""
        Me.TxtCodigo.Text = ""
        Me.TxtNombres.Text = ""
        Me.TxtApellidos.Text = ""
        Me.TxtEdad.Text = ""
        Me.CboSexo.Text = ""
        Me.DtpFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.CboEstadoCivil.Text = ""
        Me.CboEscolaridad.Text = ""
        Me.CboOcupacion.Text = ""
        Me.TxtTelefono.Text = ""
        Me.TxtDireccion.Text = ""
        Me.DtpFecha.Value = Format(Now, "dd/MM/yyyy")
        Me.CboUnidadSalud.Text = ""
        Me.TxtNombrePadre.Text = ""
        Me.TxtNombreMadre.Text = ""
        Me.CboLocalidad.Text = ""
        Me.CboComarca.Text = ""
        Me.CboMunicipio.Text = ""
        Me.CboLocalidad.Text = ""

        Me.TxtNombreEmergencia.Text = ""
        Me.TxtTelefonoEmergencia.Text = ""
        Me.TxtDireccionEmergencia.Text = ""
    End Sub

    Public Sub Cargar_Expediente(ByVal Numero_Expediente As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroExpediente As String, Num(2) As String, RutaOrigen As String
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
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Edad")) Then
                    Me.TxtEdad.Text = DataSet.Tables("Expediente").Rows(0)("Edad")
                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Sexo")) Then
                    Me.CboSexo.Text = DataSet.Tables("Expediente").Rows(0)("Sexo")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Fecha_Nacimiennto")) Then
                    Me.DtpFecha.Value = DataSet.Tables("Expediente").Rows(0)("Fecha_Nacimiennto")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Estado_Civil")) Then
                    Me.CboEstadoCivil.Text = DataSet.Tables("Expediente").Rows(0)("Estado_Civil")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Escolaridad")) Then
                    Me.CboEscolaridad.Text = DataSet.Tables("Expediente").Rows(0)("Escolaridad")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Ocupacion")) Then
                    Me.CboOcupacion.Text = DataSet.Tables("Expediente").Rows(0)("Ocupacion")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Expediente").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Direccion")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Expediente").Rows(0)("Direccion")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Direccion")) Then
                    Me.DtpFecha.Value = DataSet.Tables("Expediente").Rows(0)("Fecha_Ingreso")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Unidad_Salud")) Then
                    Me.CboUnidadSalud.Text = DataSet.Tables("Expediente").Rows(0)("Unidad_Salud")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Padre")) Then
                    Me.TxtNombrePadre.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Padre")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Padre")) Then
                    Me.TxtNombreMadre.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Madre")
                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("Nombre_Madre")) Then
                    Me.CboLocalidad.Text = DataSet.Tables("Expediente").Rows(0)("Nombre_Madre")
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

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdComarca")) Then
                    IdComarca = DataSet.Tables("Expediente").Rows(0)("IdComarca")

                    SQLstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdComarca & "') AND (Tipo = 'Comarca')"
                    ds = Me.BuscaConsulta(SQLstring, "Comarca").Copy
                    If ds.Tables("Comarca").Rows.Count <> 0 Then
                        Me.CboComarca.Text = ds.Tables("Comarca").Rows(0)("Nombre_Municipio")
                    End If

                End If
                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdMunicipio")) Then
                    IdMunicipio = DataSet.Tables("Expediente").Rows(0)("IdMunicipio")

                    SQLstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (IdMunicipio = '" & IdMunicipio & "') AND (Tipo = 'Municipio')"
                    ds = Me.BuscaConsulta(SQLstring, "Municipio").Copy
                    If ds.Tables("Municipio").Rows.Count <> 0 Then
                        Me.CboMunicipio.Text = ds.Tables("Municipio").Rows(0)("Nombre_Municipio")
                    End If

                End If

                If Not IsDBNull(DataSet.Tables("Expediente").Rows(0)("IdLocalidad")) Then
                    CodDepartamento = DataSet.Tables("Expediente").Rows(0)("IdLocalidad")

                    SQLstring = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos WHERE (Cod_Departamento = '" & CodDepartamento & "')"
                    ds = Me.BuscaConsulta(SQLstring, "Departamento").Copy
                    If ds.Tables("Departamento").Rows.Count <> 0 Then
                        Me.CboLocalidad.Text = ds.Tables("Departamento").Rows(0)("Nombre_Departamento")
                    End If

                End If

                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Expediente & ".bmp"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                End If

            Else
                Limpiar_Expediente()
            End If


        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub


    Public Sub GenerarExpediente()
        Dim Serie As String, Numero As Double, NumeroExpediente As String, NumeroExpedienteG As String
        Dim SqlString As String, Num() As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, i As Double



        If Me.TxtLetra.Text <> "" Then
            If Not IsNumeric(Me.TxtLetra.Text) Then
                Serie = Me.TxtLetra.Text
            Else
                Serie = "B"
            End If
        Else
            Serie = "B"
        End If

        If Me.TxtCodigo.Text <> "" Then
            If IsNumeric(Me.TxtCodigo.Text) Then
                Numero = Me.TxtCodigo.Text
            Else
                Numero = 1
            End If
        Else
            Numero = 1
        End If

        '/////////////////////////////////////BUSCO SI EXISTE EL NOMBRE /////////////////////////////////////
        SqlString = "SELECT Expediente.* FROM Expediente WHERE (Nombres LIKE '%" & Me.TxtNombres.Text & "%') AND (Apellidos LIKE '%" & Me.TxtApellidos.Text & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If DataSet.Tables("Expediente").Rows.Count = 0 Then
            NumeroExpediente = Serie & "-" & Format(Numero, "00000#")
            Existe = False
        Else
            NumeroExpediente = DataSet.Tables("Expediente").Rows(0)("Numero_Expediente")
            Existe = True
        End If


        Num = NumeroExpediente.Split("-")
        Me.TxtLetra.Text = Num(0)
        Me.TxtCodigo.Text = Num(1)

        SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & NumeroExpediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If DataSet.Tables("Expediente").Rows.Count = 0 Then

            '/////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////SI NO EXISTE BUSCO SI ES EL SIGUIENTE //////////////////
            '////////////////////////////7////////////////////////////////////////////////////////
            SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente like  '%" & Serie & "%') ORDER BY Numero_Expediente"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Siguiente")
            i = 0

            '/////////////////RECORRO PARA BUCAR EL SIGUIENTE DISPONIBLE
            Do While DataSet.Tables("Siguiente").Rows.Count > i
                If i = 0 Then
                    NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(0)("Numero_Expediente")
                Else
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")

                    If NumeroExpediente <> DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente") Then
                        Num = NumeroExpediente.Split("-")
                        Me.TxtLetra.Text = Num(0)
                        Me.TxtCodigo.Text = Num(1)
                        Exit Do
                    Else
                        NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente")
                    End If
                End If


                i = i + 1

                If DataSet.Tables("Siguiente").Rows.Count = i Then
                    Num = NumeroExpedienteG.Split("-")
                    NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                    Me.TxtLetra.Text = Num(0)
                    Me.TxtCodigo.Text = Format(CDbl(Num(1)) + 1, "00000#")
                    Exit Do

                End If
            Loop


            'If NumeroExpediente <> NumeroExpedienteG Then
            '    If NumeroExpedienteG <> Nothing Then
            '        NumeroExpediente = NumeroExpedienteG
            '    End If
            'End If

            'Num = NumeroExpediente.Split("-")
            'Me.TxtLetra.Text = Num(0)
            'Me.TxtCodigo.Text = Num(1)

        Else

            If Existe = False Then


                '/////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO EL SIGUIENTE //////////////////
                '////////////////////////////7////////////////////////////////////////////////////////
                SqlString = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente like  '%" & Serie & "%') ORDER BY Numero_Expediente"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Siguiente")
                i = 0

                '/////////////////RECORRO PARA BUCAR EL SIGUIENTE DISPONIBLE
                Do While DataSet.Tables("Siguiente").Rows.Count > i
                    If i = 0 Then
                        NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(0)("Numero_Expediente")
                    Else
                        Num = NumeroExpedienteG.Split("-")
                        NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")

                        If NumeroExpediente <> DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente") Then
                            Num = NumeroExpediente.Split("-")
                            Me.TxtLetra.Text = Num(0)
                            Me.TxtCodigo.Text = Num(1)
                            Exit Do
                        Else
                            NumeroExpedienteG = DataSet.Tables("Siguiente").Rows(i)("Numero_Expediente")
                        End If
                    End If


                    i = i + 1

                    If DataSet.Tables("Siguiente").Rows.Count = i Then
                        Num = NumeroExpedienteG.Split("-")
                        NumeroExpediente = Num(0) & "-" & Format(CDbl(Num(1)) + 1, "00000#")
                        Me.TxtLetra.Text = Num(0)
                        Me.TxtCodigo.Text = Format(CDbl(Num(1)) + 1, "00000#")
                        Exit Do

                    End If
                Loop

            Else


            End If


        End If






    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Numero_Exp As String



        If Me.TxtApellidos.Text <> "" Then

            Me.TxtLetra.Text = Mid(Me.TxtApellidos.Text, 1, 1)
            GenerarExpediente()
            Numero_Exp = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
            If Me.Existe = True Then
                Me.Cargar_Expediente(Numero_Exp)
            End If

        End If
    End Sub

    Private Sub TxtApellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellidos.TextChanged
        Dim SqlString As String
        Dim ds As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        'If Me.TxtApellidos.Text <> "" Then

        '    Me.TxtLetra.Text = Mid(Me.TxtApellidos.Text, 1, 1)
        '    GenerarExpediente()
        '    If Me.Existe = True Then

        '    End If
        'End If

    End Sub

    Private Sub FrmExpediente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdLocalidad As Double, IdMunicipio As Double
        Dim SQlString As String

        '//////////////////////////BUSCO EL ID DE LA LOCALIDAD ////////////////////////////////////////////////
        SQlString = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos "
        ds = Me.BuscaConsulta(SQlString, "Departamento").Copy
        Me.CboLocalidad.DataSource = ds.Tables("Departamento")

        '//////////////////////////BUSCO LA OCUPACION ////////////////////////////////////////////////
        SQlString = "SELECT DISTINCT Ocupacion FROM  Expediente"
        ds = Me.BuscaConsulta(SQlString, "Ocupacion").Copy
        If ds.Tables("Ocupacion").Rows.Count <> 0 Then
            Me.CboOcupacion.DataSource = ds.Tables("Ocupacion")
            Me.CboOcupacion.Text = ds.Tables("Ocupacion").Rows(0)("Ocupacion")
        End If

        '//////////////////////////UNIDAD DE SALUD ////////////////////////////////////////////////
        SQlString = "SELECT DISTINCT  Unidad_Salud FROM  Expediente"
        ds = Me.BuscaConsulta(SQlString, "Unidad_Salud").Copy
        If ds.Tables("Unidad_Salud").Rows.Count <> 0 Then
            Me.CboUnidadSalud.DataSource = ds.Tables("Unidad_Salud")
            Me.CboUnidadSalud.Text = ds.Tables("Unidad_Salud").Rows(0)("Unidad_Salud")
        End If

    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Quien = "Expediente"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Cargar_Expediente(My.Forms.FrmConsultas.Codigo)
        End If
    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim Numero_Expediente As String
        Dim ds As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQlString As String, CodDepartamento As String, idMunicipio As Double, IdComarca As Double

        Numero_Expediente = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
        '//////////////////////////BUSCO EL ID DE LA LOCALIDAD ////////////////////////////////////////////////
        SQlString = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos WHERE (Nombre_Departamento = '" & Me.CboLocalidad.Text & "')"
        ds = Me.BuscaConsulta(SQlString, "Departamento").Copy
        If ds.Tables("Departamento").Rows.Count <> 0 Then
            CodDepartamento = ds.Tables("Departamento").Rows(0)("Cod_Departamento")
        End If

        SQlString = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (Nombre_Municipio = '" & Me.CboMunicipio.Text & "') AND (Tipo = 'Municipio')"
        ds = Me.BuscaConsulta(SQlString, "Municipio").Copy
        If ds.Tables("Municipio").Rows.Count <> 0 Then
            idMunicipio = ds.Tables("Municipio").Rows(0)("IdMunicipio")
        End If

        SQlString = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (Nombre_Municipio = '" & Me.CboComarca.Text & "') AND (Tipo = 'Comarca')"
        ds = Me.BuscaConsulta(SQlString, "Comarca").Copy
        If ds.Tables("Comarca").Rows.Count <> 0 Then
            IdComarca = ds.Tables("Comarca").Rows(0)("IdMunicipio")
        End If


        Grabar_Expediente(Numero_Expediente, Me.TxtNombres.Text, Me.TxtApellidos.Text, Me.TxtEdad.Text, Me.CboSexo.Text, Me.CboEstadoCivil.Text, Me.CboEscolaridad.Text, Me.CboOcupacion.Text, Me.TxtTelefono.Text, Me.TxtDireccion.Text, Me.DtpFecha.Value, Me.CboUnidadSalud.Text, Me.TxtNombrePadre.Text, Me.TxtNombreMadre.Text, CodDepartamento, idMunicipio, IdComarca, Me.TxtNombreEmergencia.Text, Me.TxtTelefonoEmergencia.Text, Me.TxtDireccionEmergencia.Text, Me.DtpFechaNacimiento.Value)

        Limpiar_Expediente()
    End Sub

    Private Sub DtpFechaNacimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaNacimiento.ValueChanged
        Me.TxtEdad.Text = DateDiff(DateInterval.Year, Me.DtpFechaNacimiento.Value, Now)
    End Sub

    Private Sub CboLocalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocalidad.SelectedIndexChanged
        FiltroMunicipio()
    End Sub

    Public Sub FiltroMunicipio()

        Dim Sqlstring As String, CodDepartamento As String
        Dim ds As New DataSet

        '//////////////////////////BUSCO EL ID DE LA LOCALIDAD ////////////////////////////////////////////////
        Sqlstring = "SELECT Cod_Departamento, Nombre_Departamento FROM Departamentos WHERE (Nombre_Departamento = '" & Me.CboLocalidad.Text & "')"
        ds = Me.BuscaConsulta(Sqlstring, "Departamento").Copy
        If ds.Tables("Departamento").Rows.Count <> 0 Then
            CodDepartamento = ds.Tables("Departamento").Rows(0)("Cod_Departamento")
        End If


        Sqlstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE  (Tipo = 'Municipio') AND (Cod_Departamento = '" & CodDepartamento & "')"
        ds = Me.BuscaConsulta(Sqlstring, "Municipio").Copy
        Me.CboMunicipio.DataSource = ds.Tables("Municipio")


    End Sub

    Public Sub FiltroComarca()
        Dim Sqlstring As String, CodDepartamento As String, IdMunicipio As Double
        Dim ds As New DataSet

        Sqlstring = "SELECT  IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE (Nombre_Municipio = '" & Me.CboMunicipio.Text & "') AND (Tipo = 'Municipio')"
        ds = Me.BuscaConsulta(Sqlstring, "Consulta").Copy
        If ds.Tables("Consulta").Rows.Count <> 0 Then
            IdMunicipio = ds.Tables("Consulta").Rows(0)("IdMunicipio")
        End If


        Sqlstring = "SELECT IdMunicipio, Cod_Departamento, Nombre_Municipio FROM Municipio WHERE  (Tipo = 'Comarca') AND (Cod_Departamento = '" & IdMunicipio & "')"
        ds = Me.BuscaConsulta(Sqlstring, "Municipio").Copy
        Me.CboComarca.DataSource = ds.Tables("Municipio")



    End Sub

    Private Sub CboMunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMunicipio.SelectedIndexChanged
        Me.CboComarca.Text = ""
        FiltroComarca()
    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmdAgregarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregarFoto.Click
        Dim RutaOrigen As String = "", RutaDestino As String, Numero_Exp As String

        Numero_Exp = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text
        Me.OpenFileDialog1.ShowDialog()
        RutaOrigen = Me.OpenFileDialog1.FileName.ToString()
        If RutaOrigen = "OpenFileDialog1" Then
            Exit Sub
        End If
        Me.ImgFoto.ImageLocation = RutaOrigen
        RutaDestino = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Exp & ".bmp"
        If System.IO.File.Exists(RutaDestino) = True Then
            System.IO.File.Delete(RutaDestino)
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        Else
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        End If
    End Sub

    Private Sub CmdQuitarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdQuitarFoto.Click
        Dim RutaOrigen As String, Resultado As Double, Numero_Exp As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Foto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        Numero_Exp = Me.TxtLetra.Text & "-" & Me.TxtCodigo.Text

        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\E" & Numero_Exp & ".bmp"
        If System.IO.File.Exists(RutaOrigen) = True Then
            System.IO.File.Delete(RutaOrigen)
            ImgFoto.ImageLocation = ""
            ImgFoto.Refresh()
        Else
            MsgBox("El archivo no Existe", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If
    End Sub
End Class