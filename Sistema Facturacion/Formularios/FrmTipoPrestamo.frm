Public Class FrmTipoPrestamos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub TxtInteresAnual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInteresAnual.TextChanged
        Dim InteresAnual As Double, InteresMensual As Double, InteresDiario As Double, Factor = (365 / 12)
        InteresAnual = Val(Me.TxtInteresAnual.Text)
        InteresMensual = (InteresAnual / 12)
        InteresDiario = (InteresAnual / 365)

        Me.TxtInteresMensual.Text = Format(InteresMensual, "##,##0.0000000000")
        Me.TxtInteresDiario.Text = Format(InteresDiario, "##,##0.0000000000")

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub FrmTipoPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT dbo.Modalidades.* FROM  dbo.Modalidades"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Modalidades")
        If Not DataSet.Tables("Modalidades").Rows.Count = 0 Then
            Me.CboCodigoModalidad.DataSource = DataSet.Tables("Modalidades")
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////CARGO LOS TIPOS DE CREDITOS //////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT CodTipoPrestamo, TipoPrestamo FROM  TipoPrestamo"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrestamo")
        If Not DataSet.Tables("TipoPrestamo").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("TipoPrestamo")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CodigoModalidad"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoModalidad.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Dim SQLProveedor As String, CodModalidad As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        Try


            If Me.CboCodigoLinea.Text = "" Then
                MsgBox("Se necesita el Codigo del Tipo Credito", MsgBoxStyle.Critical, "Sistema de Credito")
                Exit Sub
            End If

            If Me.TxtNombre.Text = "" Then
                MsgBox("Se necesita el Nombre del Tipo Credito", MsgBoxStyle.Critical, "Sistema de Credito")
                Exit Sub
            End If

            If Me.CboCodigoModalidad.Text = "" Then
                MsgBox("Se necesita el tipo de Modalidad", MsgBoxStyle.Critical, "Sistema de Credito")
                Exit Sub
            End If

            CodModalidad = Me.CboCodigoModalidad.Columns(0).Text

            SQLProveedor = "SELECT TipoPrestamo.* FROM TipoPrestamo WHERE (CodTipoPrestamo = '" & Me.CboCodigoLinea.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "TipoPrestamo")
            If Not DataSet.Tables("TipoPrestamo").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [TipoPrestamo] SET [TipoPrestamo] = '" & Me.TxtNombre.Text & "',[InteresAnual] = " & Me.TxtInteresAnual.Text & ",[InteresMensual] = " & Me.TxtInteresMensual.Text & " ,[InteresDiario] = " & Me.TxtInteresDiario.Text & " ,[InteresMora] = " & Me.TxtInteresMora.Text & ",[InteresDeslizamiento] = " & Me.TxtInteresDeslizamiento.Text & ",[MaxCuotas] = " & Me.TxtMaximoCuotas.Value & ",[CantPrestamos] = " & Me.TxtCantidadPrestamos.Value & ",[CodModalidad] = '" & CodModalidad & "'  WHERE (CodTipoPrestamo = '" & Me.CboCodigoLinea.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [TipoPrestamo] ([CodTipoPrestamo],[TipoPrestamo],[InteresAnual],[InteresMensual],[InteresDiario],[InteresMora],[InteresDeslizamiento],[MaxCuotas],[CantPrestamos],[CodModalidad]) " & _
                               "VALUES ('" & Me.CboCodigoLinea.Text & "','" & Me.TxtNombre.Text & "'," & Me.TxtInteresAnual.Text & "," & Me.TxtInteresMensual.Text & "," & Me.TxtInteresDiario.Text & "," & Me.TxtInteresMora.Text & "," & Me.TxtInteresDeslizamiento.Text & "," & Me.TxtMaximoCuotas.Value & "," & Me.TxtCantidadPrestamos.Value & " ,'" & CodModalidad & "') "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
            Dim Sql As String = "SELECT  * FROM     TipoPrestamo"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataSet.Tables("TipoPrestamo").Clear()
            DataAdapter.Fill(DataSet, "TipoPrestamo")
            If Not DataSet.Tables("TipoPrestamo").Rows.Count = 0 Then

                Me.CboCodigoLinea.DataSource = DataSet.Tables("TipoPrestamo")

            End If

            Me.CboCodigoLinea.Text = ""

        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub

    Private Sub CboCodigoLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoLinea.TextChanged
        Dim CodTipoModalidad As String = ""
        Dim SQL As String = "SELECT * FROM TipoPrestamo WHERE (CodTipoPrestamo = '" & Me.CboCodigoLinea.Text & "') "
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPrestamos")
        If Not DataSet.Tables("TipoPrestamos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("TipoPrestamo")) Then
                Me.TxtNombre.Text = DataSet.Tables("TipoPrestamos").Rows(0)("TipoPrestamo")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("InteresAnual")) Then
                Me.TxtInteresAnual.Text = DataSet.Tables("TipoPrestamos").Rows(0)("InteresAnual")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("InteresMensual")) Then
                Me.TxtInteresMensual.Text = DataSet.Tables("TipoPrestamos").Rows(0)("InteresMensual")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("InteresDiario")) Then
                Me.TxtInteresDiario.Text = DataSet.Tables("TipoPrestamos").Rows(0)("InteresDiario")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("InteresMora")) Then
                Me.TxtInteresMora.Text = DataSet.Tables("TipoPrestamos").Rows(0)("InteresMora")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("InteresDeslizamiento")) Then
                Me.TxtInteresDeslizamiento.Text = DataSet.Tables("TipoPrestamos").Rows(0)("InteresDeslizamiento")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("MaxCuotas")) Then
                Me.TxtMaximoCuotas.Value = DataSet.Tables("TipoPrestamos").Rows(0)("MaxCuotas")
            End If
            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("CantPrestamos")) Then
                Me.TxtCantidadPrestamos.Value = DataSet.Tables("TipoPrestamos").Rows(0)("CantPrestamos")
            End If

            If Not IsDBNull(DataSet.Tables("TipoPrestamos").Rows(0)("CodModalidad")) Then
                CodTipoModalidad = DataSet.Tables("TipoPrestamos").Rows(0)("CodModalidad")
            End If

            '///////////////777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
            '///////////////////////////////////////////////BUSCO LA MODALIDAD//////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQL = "SELECT dbo.Modalidades.* FROM dbo.Modalidades WHERE (CodModalidad = '" & CodTipoModalidad & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Modalidad")
            If Not DataSet.Tables("Modalidad").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("Modalidad").Rows(0)("Modalidad")) Then
                    Me.CboCodigoModalidad.Text = DataSet.Tables("Modalidad").Rows(0)("Modalidad")
                End If
            Else
                Me.TxtNombre.Text = ""
            End If


        Else

            Me.TxtNombre.Text = ""
            Me.TxtInteresAnual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresMora.Text = ""
            Me.TxtInteresDeslizamiento.Text = ""
            Me.TxtMaximoCuotas.Value = "0"
            Me.TxtCantidadPrestamos.Value = "0"

        End If
    End Sub

    Private Sub ChkInteresUnico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInteresUnico.CheckedChanged
        If Me.ChkInteresUnico.Checked = True Then
            Me.TxtInteresAnual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresDiario.Text = ""
            Me.TxtInteresDeslizamiento.Text = ""
            Me.TxtInteresMora.Text = ""
            Me.TxtInteresAnual.Enabled = False
            Me.TxtInteresMensual.Enabled = False
            Me.TxtInteresDiario.Enabled = False
            Me.TxtMaximoCuotas.Enabled = False
            Me.TxtInteresMora.Enabled = False
            Me.TxtInteresDeslizamiento.Enabled = False
            Me.TxtMaximoCuotas.Value = 1
            Me.TxtInteresUnico.Enabled = True

        Else
            Me.TxtInteresAnual.Text = ""
            Me.TxtInteresMensual.Text = ""
            Me.TxtInteresDiario.Text = ""
            Me.TxtInteresDeslizamiento.Text = ""
            Me.TxtInteresMora.Text = ""
            Me.TxtInteresAnual.Enabled = True
            Me.TxtInteresMensual.Enabled = True
            Me.TxtInteresDiario.Enabled = True
            Me.TxtMaximoCuotas.Enabled = True
            Me.TxtInteresMora.Enabled = True
            Me.TxtInteresDeslizamiento.Enabled = True
            Me.TxtMaximoCuotas.Value = 1
            Me.TxtInteresUnico.Enabled = False
            Me.TxtInteresUnico.Text = ""

        End If
    End Sub
End Class