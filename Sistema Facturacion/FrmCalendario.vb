

Public Class FrmCalendario
    Public NombreBD As String, Id As Double, RutaBD = My.Application.Info.DirectoryPath & "\BDAuto.mdb", Servidor As String
    Public ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "
    Public MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess)





    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrecios.Click
        Dim mydlg As New MSDASC.DataLinks
        Dim ADOcon As New ADODB.Connection


        Try


            ADOcon = mydlg.PromptNew
            If Not IsDBNull(ADOcon.ConnectionString) Then
                Me.TxtConexion.Text = ADOcon.ConnectionString
            Else
                Me.TxtConexion.Text = ""
            End If

            'Dim RutaReportes As String
            'RutaReportes = My.Application.Info.DirectoryPath & "\CreateConnectString.exe"
            'Shell(RutaReportes)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub



    Private Sub CmbFrecuencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFrecuencia.SelectedIndexChanged
        If Me.CmbFrecuencia.Text = "Semanal" Then
            Me.ChkLunes.Visible = True
            Me.ChkMartes.Visible = True
            Me.ChkMiercoles.Visible = True
            Me.ChkJueves.Visible = True
            Me.ChkViernes.Visible = True
            Me.ChkSabado.Visible = True
            Me.ChkDomingo.Visible = True
        Else


            Me.ChkLunes.Visible = False
            Me.ChkMartes.Visible = False
            Me.ChkMiercoles.Visible = False
            Me.ChkJueves.Visible = False
            Me.ChkViernes.Visible = False
            Me.ChkSabado.Visible = False
            Me.ChkDomingo.Visible = False

        End If
    End Sub

    Private Sub Chk2Veces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk2Veces.CheckedChanged
        If Me.Chk2Veces.Checked = True Then
            Me.DTPHora1.Visible = True
            Me.DTPHora2.Visible = True
            Me.LblHora1.Visible = True
            Me.LblHora2.Visible = True
        Else
            Me.DTPHora1.Visible = True
            Me.DTPHora2.Visible = False
            Me.LblHora1.Visible = True
            Me.LblHora2.Visible = False
        End If
    End Sub

    Private Sub FrmCalendario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim StrSQLAccess As String, StrSQLUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Cadena() As String
        Dim SubCadena As String, Cadena2() As String, Password As String, Usuario As String
        Dim i As Integer, j As Integer


        Dim ComandoUpdateAccess As New OleDb.OleDbCommand
        Dim DataAdapterAccess As New OleDb.OleDbDataAdapter()
        Dim DatasetDatos As New DataSet, Conexion As String

        If Me.TxtConexion.Text = "" Then
            MsgBox("Se necesita Seleccionar una Base de Datos", MsgBoxStyle.Exclamation, "Zeus Respaldos")
            Exit Sub
        End If

        If Me.Chk2Veces.Checked = True Then
            If Me.DTPHora1.Value = Me.DTPHora2.Value Then
                MsgBox("La Hora1 tiene que ser distinta a la hora2", MsgBoxStyle.Critical, "Zeus Respaldos")
                Exit Sub
            End If
        End If

        If Me.TxtRuta.Text = "" Then
            MsgBox("Se necesita la Ruta de Respaldo", MsgBoxStyle.Critical, "Zeus Respaldos")
            Exit Sub
        End If


        Conexion = Me.TxtConexion.Text
        Cadena = Split(Conexion, ";")
        For i = 0 To UBound(Cadena)
            SubCadena = Cadena(i)
            '///////////////////////////////////BUSCO EL SERVIDO Y DATOS DE SQL ///////////////////////////
            Cadena2 = Split(SubCadena, "=")
            If Cadena2.Length = 2 Then
                Select Case Cadena2(0)
                    Case "Password" : Password = Cadena2(1)
                    Case "User ID" : Usuario = Cadena2(1)
                    Case "Initial Catalog" : NombreBD = Cadena2(1)
                    Case "Data Source" : Servidor = Cadena2(1)
                End Select
            End If


        Next i

        '/////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////BUSCO EN NOMBRE DEL SERVIDOR ///////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////
        StrSQLAccess = "SELECT Programacion.* FROM Programacion WHERE (((Programacion.Id)=" & Me.Id & "))"
        DataAdapterAccess = New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
        DataAdapterAccess.Fill(DatasetDatos, "Consulta")

        If DatasetDatos.Tables("Consulta").Rows.Count = 0 Then
            MiConexionAccess.Open()
            StrSQLUpdate = "INSERT INTO [Programacion] ([NombreBD],[Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado],[Domingo],[Frecuencia],[Respaldar2Veces],[Hora1],[Hora2],[Cadena],[RutaRespaldo],[UltimoRespaldo]) " & _
                       "VALUES ('" & NombreBD & "'," & Me.ChkLunes.Checked & "," & Me.ChkMartes.Checked & "," & Me.ChkMiercoles.Checked & " ," & Me.ChkJueves.Checked & "," & Me.ChkViernes.Checked & "," & Me.ChkSabado.Checked & " ," & Me.ChkDomingo.Checked & ",'" & Me.CmbFrecuencia.Text & "'," & Me.Chk2Veces.Checked & ",'" & Me.DTPHora1.Value & "','" & Me.DTPHora2.Value & "','" & Me.TxtConexion.Text & "','" & Me.TxtRuta.Text & "', '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "')"
            ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
            iResultado = ComandoUpdateAccess.ExecuteNonQuery
            MiConexionAccess.Close()
        Else
            MiConexionAccess.Open()
            StrSQLUpdate = "UPDATE Programacion SET [NombreBD] = '" & NombreBD & "',[Lunes] = " & Me.ChkLunes.Checked & ",[Martes] = " & Me.ChkMartes.Checked & ",[Miercoles] = " & Me.ChkMiercoles.Checked & ",[Jueves] = " & Me.ChkJueves.Checked & ",[Sabado] = " & Me.ChkSabado.Checked & ",[Domingo] = " & Me.ChkDomingo.Checked & ",[Frecuencia] = '" & Me.CmbFrecuencia.Text & "',[Respaldar2Veces] = " & Me.Chk2Veces.Checked & ",[Hora1] = '" & Me.DTPHora1.Value & "' ,[Hora2] = '" & Me.DTPHora2.Value & "',[Cadena] = '" & Me.TxtConexion.Text & "',[RutaRespaldo] = '" & Me.TxtRuta.Text & "',[UltimoRespaldo] = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE (((Programacion.Id)=" & Me.Id & "))"
            ComandoUpdateAccess = New OleDb.OleDbCommand(StrSQLUpdate, MiConexionAccess)
            iResultado = ComandoUpdateAccess.ExecuteNonQuery
            MiConexionAccess.Close()
        End If



        MsgBox("Programacion Grabada con Exito!!!", MsgBoxStyle.Information, "Zeus Facturacion")
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.TxtConexion.Text = ""
        Me.TxtRuta.Text = ""
        Me.CmbFrecuencia.Text = "Diaria"
        Me.Chk2Veces.Checked = True

        Me.DTPHora1.Value = Now
        Me.DTPHora2.Value = Now

        Me.ChkLunes.Checked = False
        Me.ChkMartes.Checked = False
        Me.ChkMiercoles.Checked = False
        Me.ChkJueves.Checked = False
        Me.ChkViernes.Checked = False
        Me.ChkSabado.Checked = False
        Me.ChkDomingo.Checked = False

        Me.ChkLunes.Visible = False
        Me.ChkMartes.Visible = False
        Me.ChkMiercoles.Visible = False
        Me.ChkJueves.Visible = False
        Me.ChkViernes.Visible = False
        Me.ChkSabado.Visible = False
        Me.ChkDomingo.Visible = False

        Me.Id = 0

    End Sub

    Private Sub BtnRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRuta.Click
        Dim Ruta As String
        Me.FolderBrowserDialog.ShowDialog()
        Ruta = Me.FolderBrowserDialog.SelectedPath
        Me.TxtRuta.Text = Ruta

    End Sub
End Class
