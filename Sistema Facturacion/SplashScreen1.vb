

Public NotInheritable Class SplashScreen1
    Public RutaBD As String = My.Application.Info.DirectoryPath & "\CntFacturacion.dll", ConexionAccess As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "


    Dim StrSQLAccess = "Select * From Servidor"
    Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess)
    Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
    Dim DatasetDatos As New DataSet, iPosicionFila As Double = 0
    Public MiConexion As New SqlClient.SqlConnection

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, SqlDatosEmpresa As String

        If Timer1.Interval < 40 Then
            Me.Timer1.Interval = Me.Timer1.Interval + 1
        ElseIf Me.Timer1.Interval <> 200 Then
            MiConexionAccess.Open()
            DataAdapterAccess.Fill(DatasetDatos, "Compañias")
            MiConexionAccess.Close()
            Me.Timer1.Interval = 200
            Me.Timer1.Enabled = False

            If DatasetDatos.Tables("Compañias").Rows.Count > 1 Then

                Do While iPosicionFila < (DatasetDatos.Tables("Compañias").Rows.Count)

                    Conexion = DatasetDatos.Tables("Compañias").Rows(iPosicionFila)("Servidor")
                    NombreCompañia = DatasetDatos.Tables("Compañias").Rows(iPosicionFila)("NombreBD")
                    My.Forms.FrmCompañias.ListBox1.Items.Add(NombreCompañia)

                    iPosicionFila = iPosicionFila + 1
                Loop

                Me.Hide()
                My.Forms.FrmCompañias.ShowDialog()
                Me.Close()
            ElseIf DatasetDatos.Tables("Compañias").Rows.Count <> 0 Then
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////SI SOLO EXISTE UNA COMPAÑIA ABRO DIRECTO /////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Conexion = DatasetDatos.Tables("Compañias").Rows(iPosicionFila)("Servidor")
                NombreCompañia = DatasetDatos.Tables("Compañias").Rows(iPosicionFila)("NombreBD")

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////VERIFICO SI EXISTEN USUARIOS //////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion = New SqlClient.SqlConnection(Conexion)

                '////////////////////Declaro las Consultas a Utilizar/////////////////////////////////////////////////
                Dim strSQL As String = "SELECT Usuario FROM Usuarios "

                MiConexion.Open()
                DataAdapter = New SqlClient.SqlDataAdapter(strSQL, MiConexion)
                DataAdapter.Fill(DataSet, "Usuarios")
                MiConexion.Close()

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////VERIFICO LOS DATOS DE LA COMPAÑIA///////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlDatosEmpresa = "SELECT * FROM DatosEmpresa"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatosEmpresa, MiConexion)
                DataAdapter.Fill(DataSet, "DatosEmpresa")
                If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")) Then
                        ConexionContabilidad = DataSet.Tables("DatosEmpresa").Rows(0)("Conexion_Contabilidad")
                    End If
                    If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("NombreCliente")) Then
                        NombreCliente = DataSet.Tables("DatosEmpresa").Rows(0)("NombreCliente")
                    End If

                End If

                If DataSet.Tables("Usuarios").Rows.Count = 0 Then
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////SI NO EXISTEN USUARIOS ////////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    Me.Hide()
                    If NombreCliente = "Alumnos" Then
                        'My.Forms.MDIParent1.NavBarEnsamble.Visible = False
                        'My.Forms.MDIParent1.NavBarPagos.Visible = False
                        'My.Forms.MDIParent1.Vendedores.Visible = False
                        'My.Forms.MDIParent1.NavBarLiquidacion.Visible = False
                        'My.Forms.MDIParent1.NavBarTransferencias.Visible = False
                        'My.Forms.MDIParent1.ShowDialog()

                        My.Forms.MDIMain.ShowDialog()
                    Else
                        'My.Forms.MDIParent1.ShowDialog()
                        My.Forms.MDIMain.ShowDialog()
                    End If
                    Me.Close()

                Else
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////SI EXISTEN USUARIOS ////////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Me.Hide()
                    My.Forms.FrmEntrada.ShowDialog()
                    Me.Close()

                End If


            Else
                MsgBox("No Existen Compañias", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub ApplicationTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub SplashScreen1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
