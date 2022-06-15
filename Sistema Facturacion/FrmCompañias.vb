Public Class FrmCompañias
    Public RutaBD As String = My.Application.Info.DirectoryPath & "\CntFacturacion.dll", ConexionAccess As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "
    Public MiConexion As New SqlClient.SqlConnection

    Private Sub FrmCompañias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Version = My.Application.Info.Version.ToString
        Me.Text = "Listado de Compañias V." & Mid(Version, 1, Len(Version) - 2)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrSQLAccess As String = "Select * From Servidor Where (NombreBD= '" & Me.ListBox1.SelectedItem & "') "
        Dim MiConexionAccess As New OleDb.OleDbConnection(ConexionAccess)
        Dim DataAdapterAccess As New OleDb.OleDbDataAdapter(StrSQLAccess, MiConexionAccess)
        Dim DatasetDatos As New DataSet, iPosicionFila As Double = 0
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, SqlDatosEmpresa As String



        MiConexionAccess.Open()
        DataAdapterAccess.Fill(DatasetDatos, "Compañias")
        MiConexionAccess.Close()


        If DatasetDatos.Tables("Compañias").Rows.Count <> 0 Then

            '////////////////////////////////////GUARDO LA CONEXION DE LAS COMPAÑIAS ////////////////////////////////////////////////////
            Conexion = DatasetDatos.Tables("Compañias").Rows(0)("Servidor")
            NombreCompañia = DatasetDatos.Tables("Compañias").Rows(0)("NombreBD")


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
                    My.Forms.MDIMain.Text = "Nombre Compañia: " & NombreCompañia
                    My.Forms.MDIMain.ShowDialog()
                    'My.Forms.MDIParent1.Text = "Nombre Compañia: " & NombreCompañia
                    'My.Forms.MDIParent1.ShowDialog()

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

        End If
    End Sub
End Class