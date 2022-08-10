Imports System.Data.SqlClient
Public Class frmDBBackup
    Public RutaBD = My.Application.Info.DirectoryPath & "\BDAuto.mdb", Servidor As String, HoraInicio As Date
    Public ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " ", Id As Double
    Public MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess)
    Public Function DiaSemana(ByVal Fecha As Date) As String
        Dim Dia As Double
        Dia = Weekday(Fecha, vbMonday)
        'he puesto vbmonday para que el primer dia de la semana lo coja el lunes 'y devuelva un 1 cuando sea lunes.
        If Dia = 7 Then
            DiaSemana = "Domingo"
        ElseIf Dia = 1 Then
            DiaSemana = "Lunes"
        ElseIf Dia = 2 Then
            DiaSemana = "Martes"
        ElseIf Dia = 3 Then
            DiaSemana = "Miercoles"
        ElseIf Dia = 4 Then
            DiaSemana = "Jueves"
        ElseIf Dia = 5 Then
            DiaSemana = "Viernes"
        ElseIf Dia = 6 Then
            DiaSemana = "Sabado"
        End If
    End Function

    Public Sub ActualizarGrid()
        Dim StrSQLAccess As String, StrSQLUpdate As String = ""
        Dim ComandoUpdate As New SqlClient.SqlCommand, ComandoUpdateAccess As New OleDb.OleDbCommand, DataAdapterAccess As New OleDb.OleDbDataAdapter()
        Dim DatasetDatos As New DataSet, Conexion As String = ""
        Dim Cadena() As String, SubCadena As String, Cadena2() As String, Ruta As String
        Dim i As Integer, j As Integer

        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////BUSCO EN NOMBRE DEL SERVIDOR ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////
        StrSQLAccess = "SELECT Programacion.NombreBD, Programacion.Frecuencia, Programacion.Hora1, Programacion.Hora2, Cadena, Id, RutaRespaldo, Respaldar2Veces, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, UltimoRespaldo FROM Programacion"
        DataAdapterAccess = New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
        DataAdapterAccess.Fill(DatasetDatos, "Consulta")
        Me.TDGridListado.DataSource = DatasetDatos.Tables("Consulta")
        Me.TDGridListado.Columns("NombreBD").Caption = "Nombre Base de Datos"
        Me.TDGridListado.Splits.Item(0).DisplayColumns("NombreBD").Width = 190
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Frecuencia").Width = 60
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Hora1").Width = 60
        Me.TDGridListado.Columns("Hora1").NumberFormat = "HH:mm:ss"
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Hora2").Width = 60
        Me.TDGridListado.Columns("Hora2").NumberFormat = "HH:mm:ss"
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Cadena").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Id").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("RutaRespaldo").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Respaldar2Veces").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Lunes").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Martes").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Miercoles").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Jueves").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Viernes").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Sabado").Visible = False
        Me.TDGridListado.Splits.Item(0).DisplayColumns("Domingo").Visible = False
        Me.TDGridListado.Columns("UltimoRespaldo").Caption = "UltimoResp."
        Me.TDGridListado.Columns("UltimoRespaldo").NumberFormat = "dd/MM/yyyy HH:mm:ss"


        If DatasetDatos.Tables("Consulta").Rows.Count <> 0 Then
            If Not IsDBNull(DatasetDatos.Tables("Consulta").Rows(0)("Cadena")) Then
                Conexion = DatasetDatos.Tables("Consulta").Rows(0)("Cadena")
            Else
                Conexion = ""
            End If

            If Not IsDBNull(DatasetDatos.Tables("Consulta").Rows(0)("RutaRespaldo")) Then
                Ruta = DatasetDatos.Tables("Consulta").Rows(0)("RutaRespaldo")
            Else
                Ruta = ""
            End If



            Cadena = Split(Conexion, ";")
            For i = 0 To UBound(Cadena)
                SubCadena = Cadena(i)
                '///////////////////////////////////BUSCO EL SERVIDO Y DATOS DE SQL ///////////////////////////
                Cadena2 = Split(SubCadena, "=")
                If Cadena2.Length = 2 Then
                    Select Case Cadena2(0)
                        Case "Password" : Me.txtPassword.Text = Cadena2(1)
                        Case "User ID" : Me.txtUsername.Text = Cadena2(1)
                        Case "Initial Catalog" : Me.txtDB.Text = Cadena2(1)
                        Case "Data Source" : Me.txtServer.Text = Cadena2(1)
                    End Select
                End If


            Next i

            Me.txtPath.Text = Ruta

            If Me.txtDB.Text <> "" Then
                Me.txtBackupName.Text = "Respaldo " & Trim(Me.txtDB.Text) & " " & Format(Now, "dd-MM-yyyy") & " " & Replace(Format(Now, "HH:mm:ss"), ":", "-")
            End If

        End If



    End Sub

    Public Sub BuscarConexion(ByVal Id As Double)
        Dim StrSQLAccess As String, StrSQLUpdate As String = ""
        Dim ComandoUpdate As New SqlClient.SqlCommand, ComandoUpdateAccess As New OleDb.OleDbCommand, DataAdapterAccess As New OleDb.OleDbDataAdapter()
        Dim DatasetDatos As New DataSet, Conexion As String = ""
        Dim Cadena() As String, SubCadena As String, Cadena2() As String, Ruta As String, Server As String
        Dim i As Integer, j As Integer

        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////BUSCO EN NOMBRE DEL SERVIDOR ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////
        StrSQLAccess = "SELECT Programacion.NombreBD, Programacion.Frecuencia, Programacion.Hora1, Programacion.Hora2, Cadena, RutaRespaldo FROM Programacion Where (Id = " & Id & ")"
        DataAdapterAccess = New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
        DataAdapterAccess.Fill(DatasetDatos, "Consulta")


        If DatasetDatos.Tables("Consulta").Rows.Count <> 0 Then
            If Not IsDBNull(DatasetDatos.Tables("Consulta").Rows(0)("Cadena")) Then
                Conexion = DatasetDatos.Tables("Consulta").Rows(0)("Cadena")
            Else
                Conexion = ""
            End If

            If Not IsDBNull(DatasetDatos.Tables("Consulta").Rows(0)("RutaRespaldo")) Then
                Ruta = DatasetDatos.Tables("Consulta").Rows(0)("RutaRespaldo")
            Else
                Ruta = ""
            End If

            Me.txtPath.Text = Ruta


            Cadena = Split(Conexion, ";")
            For i = 0 To UBound(Cadena)
                SubCadena = Cadena(i)
                '///////////////////////////////////BUSCO EL SERVIDO Y DATOS DE SQL ///////////////////////////
                Cadena2 = Split(SubCadena, "=")
                If Cadena2.Length = 2 Then
                    Select Case Cadena2(0)
                        Case "Password" : Me.txtPassword.Text = Cadena2(1)
                        Case "User ID" : Me.txtUsername.Text = Cadena2(1)
                        Case "Initial Catalog" : Me.txtDB.Text = Cadena2(1)
                        Case "Data Source" : Me.txtServer.Text = Cadena2(1)
                    End Select
                End If


            Next i

            If Me.txtDB.Text <> "" Then
                Server = Me.txtDB.Text
                Me.txtBackupName.Text = "Respaldo " & Trim(Server) & " " & Format(Now, "dd-MM-yyyy") & " " & Replace(Format(Now, "HH:mm:ss"), ":", "-")
            End If

        End If
    End Sub



    Private Enum Estado_Conexion
        NoComprobada
        Establecida
        NoEstablecida
    End Enum

    Dim EC As Estado_Conexion
    Dim CSBuilder As New SqlConnectionStringBuilder

    'Controlar los eventro de cambio de texto en las cajas de texto.
    Private Sub txts_TextChanged(sender As Object, e As EventArgs) Handles _
        txtServer.TextChanged, txtDB.TextChanged, txtUsername.TextChanged, txtPassword.TextChanged

        'Cada cambio del contenido provocará que el estado de la conexión sea "NoComprobada"
        EC = Estado_Conexion.NoComprobada
        pbConnStatus.BackgroundImage = My.Resources.light_yellow
        lblConnStatus.Text = "Conexión no comprobada."

        'Si los TextBox contienen información habilitamos btnTestConnection, de lo contrario lo deshabilitamos.
        If Not String.IsNullOrEmpty(txtServer.Text) And Not String.IsNullOrEmpty(txtDB.Text) And Not String.IsNullOrEmpty(txtUsername.Text) And Not String.IsNullOrEmpty(txtPassword.Text) Then
            btnTestConnection.Enabled = True
        Else
            btnTestConnection.Enabled = False
        End If

    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click

        'Deshabilitamos btnTestConnection durante la prueba e informamos
        btnTestConnection.Enabled = False
        lblConnStatus.Text = "Comprobando la conexión..."
        lblConnStatus.Refresh()

        'Construimos la cadena de conexión
        With CSBuilder
            .DataSource = txtServer.Text : .InitialCatalog = txtDB.Text : .IntegratedSecurity = False
            .UserID = txtUsername.Text : .Password = txtPassword.Text
        End With

        Dim Cnx As New SqlConnection(CSBuilder.ConnectionString)

        Try
            'Intentamos establecer conexión con el servidor de datos.
            'Si no hay errores, cambiamos la información del estado de la conexión.
            'Y habilitamos las opciones de respaldo
            Cnx.Open()
            'My.Application.DoEvents()
            EC = Estado_Conexion.Establecida
            pbConnStatus.BackgroundImage = My.Resources.light_green
            lblConnStatus.Text = "Conexión establecida exitosamente."


            If Me.txtDB.Text <> "" Then
                Me.txtBackupName.Text = "Respaldo " & Trim(Me.txtDB.Text) & " " & Format(Now, "dd-MM-yyyy") & " " & Replace(Format(Now, "HH:mm:ss"), ":", "-")
            End If

            'Ahora obtenemos la información de la base de datos ejecutando el procedimiento almacenado sp_spaceused
            Dim Cmd As New SqlCommand("sp_spaceused", Cnx)
            Cmd.CommandType = CommandType.StoredProcedure

            Dim Dt As New DataTable
            Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)

            Da.Fill(Dt)

            Dim Dr As DataRow = Dt.Rows.Item(0)

            lblDBName.Text = Dr.Item("database_name").ToString.Trim
            lblDBSize.Text = Dr.Item("database_size").ToString.Trim
            lblUnallocatedSize.Text = Dr.Item("unallocated space").ToString.Trim

            btnSelectDir.Enabled = True
            txtBackupName.Enabled = True

        Catch ex As Exception

            'Mostramos los errores que se hayan presentado y cambiamos el estado de la conexión
            MessageBox.Show(ex.Message, "Error en la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Opcional
            EC = Estado_Conexion.NoEstablecida
            pbConnStatus.BackgroundImage = My.Resources.light_red
            lblConnStatus.Text = "Error en la conexión"

            btnSelectDir.Enabled = False
            txtBackupName.Enabled = False

        Finally

            btnTestConnection.Enabled = True
            Cnx.Close()

        End Try

    End Sub

    Private Sub txtBackupName_TextChanged(sender As Object, e As EventArgs) Handles txtBackupName.TextChanged
        If Not String.IsNullOrEmpty(txtBackupName.Text) Then
            btnBackup.Enabled = True
        Else
            btnBackup.Enabled = False
        End If
    End Sub

    Private Sub btnSelectDir_Click(sender As Object, e As EventArgs) Handles btnSelectDir.Click
        'Mostramos un cuadro de diálogo para que el usuario seleccione la carpeta donde se guardará el respaldo
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog() = DialogResult.OK Then
            txtPath.Text = FBD.SelectedPath 'Asignamos la dirección de la carpeta a txtPath
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        'Verificamos que la conexión sea válida
        If EC = Estado_Conexion.Establecida Then

            'Deshabilitando el botón btnBackup durante el respaldo
            btnBackup.Text = "Respaldando..."
            btnBackup.Enabled = False
            btnBackup.Refresh()

            'Variable de texto que contiene la consulta de respaldo a ejecutarse en el servidor
            Dim Query As String = "BACKUP DATABASE " & txtDB.Text.Trim & " TO DISK = '" & txtPath.Text & "\" & txtBackupName.Text & ".bak' WITH FORMAT,  MEDIANAME  = '" & txtBackupName.Text & "', NAME = '" & txtBackupName.Text & "'"

            Try
                'Creamos la conexión y el comando que ejecutará la consulta 
                Dim Cnx As New SqlConnection(CSBuilder.ConnectionString)
                Dim Cmd As New SqlCommand(Query, Cnx)

                Cnx.Open()
                Cmd.ExecuteNonQuery()

                MessageBox.Show("Se ha respaldado la base de datos correctamente.", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                btnBackup.Text = "Respaldar"
                btnBackup.Enabled = True

            End Try
        Else
            MessageBox.Show("No se ha establecido ninguna conexión con el servidor de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub

 
    Private Sub frmDBBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Cadena() As String, SubCadena As String, Cadena2() As String
        Dim i As Integer, j As Integer

        '///////////////////////////////CARGO LA HORA DE INICIO /////////////////////////////////
        'HoraInicio = Format(Now, "HH:mm:ss")
        Date.Now.ToLongTimeString()

        ActualizarGrid()

        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")

        'Cadena = Split(Conexion, ";")
        'For i = 0 To UBound(Cadena)
        '    SubCadena = Cadena(i)
        '    '///////////////////////////////////BUSCO EL SERVIDO Y DATOS DE SQL ///////////////////////////
        '    Cadena2 = Split(SubCadena, "=")
        '    If Cadena2.Length = 2 Then
        '        Select Case Cadena2(0)
        '            Case "Password" : Me.txtPassword.Text = Cadena2(1)
        '            Case "User ID" : Me.txtUsername.Text = Cadena2(1)
        '            Case "Initial Catalog" : Me.txtDB.Text = Cadena2(1)
        '            Case "Data Source" : Me.txtServer.Text = Cadena2(1)
        '        End Select
        '    End If


        'Next i





    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim HoraActual As Date, Cont As Double, i As Double, Frecuencia As String, Hora1 As Date, Hora2 As Date, Programa2Veces As Boolean = True, HoraUltimo As Date
        Dim iResultado As Integer, StrSQLAccess As String, StrSQLUpdate As String, Respaldar As Boolean = False
        Dim ComandoUpdateAccess As New OleDb.OleDbCommand

        Me.LblHora.Text = Date.Now.ToLongTimeString

        HoraActual = Date.Now.ToLongTimeString
        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")



        If DateDiff(DateInterval.Second, HoraInicio, HoraActual) / 60 >= 1 Then
            '/////////////////////////////CADA MINUTO REORRO EL GRID PARA VER LA HORA DEL RESPALDO ////////////////////////
            Cont = Me.TDGridListado.RowCount
            i = 0

            Me.Button4.Enabled = False
            Me.Button2.Enabled = False
            Me.btnTestConnection.Enabled = False
            Me.LblProgramacion.Visible = True


            Do While Cont > i

                Me.LblProgramacion.Text = "Consultando Programacion " & Me.TDGridListado.Item(i)("NombreBD")
                Frecuencia = Me.TDGridListado.Item(i)("Frecuencia")
                Programa2Veces = Me.TDGridListado.Item(i)("Respaldar2Veces")
                HoraUltimo = TDGridListado.Item(i)("UltimoRespaldo")
                Me.Id = TDGridListado.Item(i)("Id")

                BuscarConexion(Id)



                If Frecuencia = "Diaria" Then
                    '//////////////////SI EL RESPALDO ES 2 VECES POR DIA ////////////////////
                    If Programa2Veces = True Then
                        Hora1 = Format(Me.TDGridListado.Item(i)("Hora1"), "HH:mm:ss")
                        Hora2 = Format(Me.TDGridListado.Item(i)("Hora2"), "HH:mm:ss")
                    Else
                        Hora1 = Format(Me.TDGridListado.Item(i)("Hora1"), "HH:mm:ss")
                    End If

                    '//////////////////////////////////////COMPARO SI LA HORA ES LA PROGRAMADA ///////////////////////////
                    If DateDiff(DateInterval.Second, HoraActual, Hora1) / 60 >= 0 And DateDiff(DateInterval.Second, HoraActual, Hora1) / 60 <= 1 Then
                        '//////////////VERIFICO QUE EL ULTIMO RESPALDO TENGA MAS DE UNA HORA
                        If DateDiff(DateInterval.Second, HoraUltimo, Now) / 60 > 1 Then
                            Me.LblProgramacion.Text = "Respaldando Base " & Me.TDGridListado.Item(i)("NombreBD")

                            btnTestConnection_Click(sender, e)
                            BtnRespaldoAuto_Click(sender, e)

                            '/////////////////////////////ACTUALIZO LA ULTIMA HORA DEL RESPALDO /////////////////////////
                            MiConexionAccess.Open()
                            StrSQLUpdate = "UPDATE Programacion SET [UltimoRespaldo] = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE (((Programacion.Id)=" & Me.Id & "))"
                            ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                            iResultado = ComandoUpdateAccess.ExecuteNonQuery
                            MiConexionAccess.Close()

                            ActualizarGrid()



                        End If
                    End If

                    If Programa2Veces = True Then


                        '//////////////////////////////////////COMPARO SI LA HORA ES LA PROGRAMADA ///////////////////////////
                        If DateDiff(DateInterval.Second, HoraActual, Hora2) / 60 >= 0 And DateDiff(DateInterval.Second, HoraActual, Hora2) / 60 <= 1 Then
                            '//////////////VERIFICO QUE EL ULTIMO RESPALDO TENGA MAS DE UNA HORA
                            If DateDiff(DateInterval.Second, HoraActual, HoraUltimo) / 60 > 1 Then
                                Me.LblProgramacion.Text = "Respaldando Base " & Me.TDGridListado.Item(i)("NombreBD")

                                btnTestConnection_Click(sender, e)
                                BtnRespaldoAuto_Click(sender, e)

                                '/////////////////////////////ACTUALIZO LA ULTIMA HORA DEL RESPALDO /////////////////////////
                                MiConexionAccess.Open()
                                StrSQLUpdate = "UPDATE Programacion SET [UltimoRespaldo] = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE (((Programacion.Id)=" & Me.Id & "))"
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                ActualizarGrid()



                            End If
                        End If

                    End If



                ElseIf Frecuencia = "Semanal" Then

                    Respaldar = False

                    If Me.TDGridListado.Item(i)("Lunes") = True Then
                        If DiaSemana(Now) = "Lunes" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Martes") = True Then
                        If DiaSemana(Now) = "Martes" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Miercoles") = True Then
                        If DiaSemana(Now) = "Miercoles" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Jueves") = True Then
                        If DiaSemana(Now) = "Jueves" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Viernes") = True Then
                        If DiaSemana(Now) = "Viernes" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Sabado") = True Then
                        If DiaSemana(Now) = "Sabado" Then
                            Respaldar = True
                        End If
                    End If

                    If Me.TDGridListado.Item(i)("Domingo") = True Then
                        If DiaSemana(Now) = "Domingo" Then
                            Respaldar = True
                        End If
                    End If




                    If Respaldar = True Then

                        '//////////////////SI EL RESPALDO ES 2 VECES POR DIA ////////////////////
                        If Programa2Veces = True Then
                            Hora1 = Format(Me.TDGridListado.Item(i)("Hora1"), "HH:mm:ss")
                            Hora2 = Format(Me.TDGridListado.Item(i)("Hora2"), "HH:mm:ss")
                        Else
                            Hora1 = Format(Me.TDGridListado.Item(i)("Hora1"), "HH:mm:ss")
                        End If

                        '//////////////////////////////////////COMPARO SI LA HORA ES LA PROGRAMADA ///////////////////////////
                        If DateDiff(DateInterval.Second, HoraActual, Hora1) / 60 >= 0 And DateDiff(DateInterval.Second, HoraActual, Hora1) / 60 <= 1 Then
                            '//////////////VERIFICO QUE EL ULTIMO RESPALDO TENGA MAS DE UNA HORA
                            If DateDiff(DateInterval.Second, HoraActual, HoraUltimo) / 60 > 1 Then
                                Me.LblProgramacion.Text = "Respaldando Base " & Me.TDGridListado.Item(i)("NombreBD")

                                btnTestConnection_Click(sender, e)
                                BtnRespaldoAuto_Click(sender, e)

                                '/////////////////////////////ACTUALIZO LA ULTIMA HORA DEL RESPALDO /////////////////////////
                                MiConexionAccess.Open()
                                StrSQLUpdate = "UPDATE Programacion SET [UltimoRespaldo] = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE (((Programacion.Id)=" & Me.Id & "))"
                                ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                MiConexionAccess.Close()

                                ActualizarGrid()



                            End If
                        End If

                        If Programa2Veces = True Then


                            '//////////////////////////////////////COMPARO SI LA HORA ES LA PROGRAMADA ///////////////////////////
                            If DateDiff(DateInterval.Second, HoraActual, Hora2) / 60 >= 0 And DateDiff(DateInterval.Second, HoraActual, Hora2) / 60 <= 1 Then
                                '//////////////VERIFICO QUE EL ULTIMO RESPALDO TENGA MAS DE UNA HORA
                                If DateDiff(DateInterval.Second, HoraActual, HoraUltimo) / 60 > 1 Then
                                    Me.LblProgramacion.Text = "Respaldando Base " & Me.TDGridListado.Item(i)("NombreBD")

                                    btnTestConnection_Click(sender, e)
                                    BtnRespaldoAuto_Click(sender, e)

                                    '/////////////////////////////ACTUALIZO LA ULTIMA HORA DEL RESPALDO /////////////////////////
                                    MiConexionAccess.Open()
                                    StrSQLUpdate = "UPDATE Programacion SET [UltimoRespaldo] = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE (((Programacion.Id)=" & Me.Id & "))"
                                    ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
                                    iResultado = ComandoUpdateAccess.ExecuteNonQuery
                                    MiConexionAccess.Close()

                                    ActualizarGrid()



                                End If
                            End If

                        End If


                    End If

                End If



                i = i + 1
            Loop



            Me.Button4.Enabled = True
            Me.Button2.Enabled = True
            Me.btnTestConnection.Enabled = True
            Me.LblProgramacion.Visible = False

            HoraInicio = Date.Now.ToLongTimeString

        Else
            If DateDiff(DateInterval.Second, HoraInicio, HoraActual) / 60 < 0 Then
                HoraInicio = Date.Now.ToLongTimeString
            End If
        End If

        'My.Application.DoEvents()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrSQLAccess As String, StrSQLUpdate As String = ""
        Dim ComandoUpdate As New SqlClient.SqlCommand, ComandoUpdateAccess As New OleDb.OleDbCommand, DataAdapterAccess As New OleDb.OleDbDataAdapter()
        Dim DatasetDatos As New DataSet, Conexion As String = ""
        Dim Cadena() As String, SubCadena As String, Cadena2() As String
        Dim i As Integer, j As Integer

        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////BUSCO EN NOMBRE DEL SERVIDOR ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////
        If Me.TDGridListado.RowCount <> 0 Then
            StrSQLAccess = "SELECT * FROM Programacion Where (Id = " & Me.TDGridListado.Columns("Id").Text & ")"
            DataAdapterAccess = New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
            DataAdapterAccess.Fill(DatasetDatos, "Consulta")


            If DatasetDatos.Tables("Consulta").Rows.Count <> 0 Then
                If Not IsDBNull(DatasetDatos.Tables("Consulta").Rows(0)("Cadena")) Then
                    Conexion = DatasetDatos.Tables("Consulta").Rows(0)("Cadena")
                Else
                    Conexion = ""
                End If

                My.Forms.FrmCalendario.TxtRuta.Text = DatasetDatos.Tables("Consulta").Rows(0)("RutaRespaldo")
                My.Forms.FrmCalendario.CmbFrecuencia.Text = DatasetDatos.Tables("Consulta").Rows(0)("Frecuencia")
                My.Forms.FrmCalendario.Chk2Veces.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Respaldar2Veces")
                My.Forms.FrmCalendario.DTPHora1.Value = DatasetDatos.Tables("Consulta").Rows(0)("Hora1")
                My.Forms.FrmCalendario.DTPHora2.Value = DatasetDatos.Tables("Consulta").Rows(0)("Hora2")

                My.Forms.FrmCalendario.ChkLunes.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Lunes")
                My.Forms.FrmCalendario.ChkMartes.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Martes")
                My.Forms.FrmCalendario.ChkMiercoles.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Miercoles")
                My.Forms.FrmCalendario.ChkJueves.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Jueves")
                My.Forms.FrmCalendario.ChkViernes.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Viernes")
                My.Forms.FrmCalendario.ChkSabado.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Sabado")
                My.Forms.FrmCalendario.ChkDomingo.Checked = DatasetDatos.Tables("Consulta").Rows(0)("Domingo")

                My.Forms.FrmCalendario.TxtConexion.Text = Conexion
                My.Forms.FrmCalendario.Id = Me.TDGridListado.Columns("Id").Text
                My.Forms.FrmCalendario.ShowDialog()
            Else

                My.Forms.FrmCalendario.Chk2Veces.Checked = True
                My.Forms.FrmCalendario.CmbFrecuencia.Text = "Diaria"
                My.Forms.FrmCalendario.DTPHora1.Value = Now
                My.Forms.FrmCalendario.DTPHora2.Value = Now
                My.Forms.FrmCalendario.Id = 0

            End If

        Else

            My.Forms.FrmCalendario.Chk2Veces.Checked = True
            My.Forms.FrmCalendario.CmbFrecuencia.Text = "Diaria"
            My.Forms.FrmCalendario.DTPHora1.Value = Now
            My.Forms.FrmCalendario.DTPHora2.Value = Now
            My.Forms.FrmCalendario.Id = 0
            My.Forms.FrmCalendario.ShowDialog()
        End If


        ActualizarGrid()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub TDGridListado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridListado.DoubleClick
        Dim NombreBase As String, Posicion As Double, Id As Double

        Posicion = Me.TDGridListado.Row

        NombreBase = Me.TDGridListado.Columns("NombreBD").Text
        Id = Me.TDGridListado.Columns("Id").Text
        BuscarConexion(Id)
    End Sub


    Private Sub TDGridListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridListado.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim StrSQLAccess As String, StrSQLUpdate As String = "", iResultado As Integer
        Dim ComandoUpdate As New SqlClient.SqlCommand, ComandoUpdateAccess As New OleDb.OleDbCommand, DataAdapterAccess As New OleDb.OleDbDataAdapter()
        Dim DatasetDatos As New DataSet, Conexion As String = "", Resultado As Integer



        Resultado = MsgBox("¿Esta Seguro de Eliminar la programacion?", MsgBoxStyle.YesNo, "Zeus Respaldos")

        If Resultado = "7" Then
            Exit Sub
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////BUSCO EN NOMBRE DEL SERVIDOR ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////
        StrSQLAccess = "SELECT * FROM Programacion Where (Id = " & Me.TDGridListado.Columns("Id").Text & ")"
        DataAdapterAccess = New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
        DataAdapterAccess.Fill(DatasetDatos, "Consulta")


        If DatasetDatos.Tables("Consulta").Rows.Count <> 0 Then
            MiConexionAccess.Open()
            StrSQLUpdate = "DELETE FROM Programacion WHERE ((Programacion.Id)= " & Me.TDGridListado.Columns("Id").Text & ")"
            ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
            iResultado = ComandoUpdateAccess.ExecuteNonQuery
            MiConexionAccess.Close()
        End If

        ActualizarGrid()


    End Sub

    Private Sub gbConnConfig_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbConnConfig.Enter

    End Sub

    Private Sub BtnRespaldoAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRespaldoAuto.Click

        'Verificamos que la conexión sea válida
        If EC = Estado_Conexion.Establecida Then

            'Deshabilitando el botón btnBackup durante el respaldo
            btnBackup.Text = "Respaldando..."
            btnBackup.Enabled = False
            btnBackup.Refresh()

            'Variable de texto que contiene la consulta de respaldo a ejecutarse en el servidor
            Dim Query As String = "BACKUP DATABASE " & txtDB.Text.Trim & " TO DISK = '" & txtPath.Text & "\" & txtBackupName.Text & ".bak' WITH FORMAT,  MEDIANAME  = '" & txtBackupName.Text & "', NAME = '" & txtBackupName.Text & "'"

            Try
                'Creamos la conexión y el comando que ejecutará la consulta 
                Dim Cnx As New SqlConnection(CSBuilder.ConnectionString)
                Dim Cmd As New SqlCommand(Query, Cnx)

                Cnx.Open()
                Cmd.ExecuteNonQuery()

                'MessageBox.Show("Se ha respaldado la base de datos correctamente.", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception

                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                btnBackup.Text = "Respaldar"
                btnBackup.Enabled = True

            End Try
        Else
            'MessageBox.Show("No se ha establecido ninguna conexión con el servidor de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ActualizarGrid()
    End Sub
End Class