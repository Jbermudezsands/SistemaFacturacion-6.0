Public Class FrmContenedores
    Public MiConexion As New SqlClient.SqlConnection(Conexion)



    Private Sub FrmContenedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT Codigo_Contenedor, Nombre_Contenedor FROM Contenedor "
        DataSet = FillConsultaSQL(SqlString, "Consulta").Copy

        Me.CboCodigoContenedor.DataSource = DataSet.Tables("Consulta")
        Me.CboCodigoContenedor.Columns(0).Caption = "Codigo"
        Me.CboCodigoContenedor.Columns(1).Caption = "Nombre"

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoContenedor_TextChanged(sender As Object, e As EventArgs) Handles CboCodigoContenedor.TextChanged
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT Codigo_Contenedor, Nombre_Contenedor, Activo FROM Contenedor WHERE (Codigo_Contenedor = '" & Me.CboCodigoContenedor.Text & "') "
        DataSet = FillConsultaSQL(SqlString, "Consulta").Copy

        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Nombre_Contenedor")) Then
                Me.TxtNombre.Text = DataSet.Tables("Consulta").Rows(0)("Nombre_Contenedor")
            End If

            If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Activo")) Then
                Me.ChkActivo.Checked = DataSet.Tables("Consulta").Rows(0)("Activo")
            End If

        Else
            LimpiarPlantillas()
        End If



    End Sub
    Public Sub Limpiar_Pantalla()
        Me.CboCodigoContenedor.Text = ""
        Me.TxtNombre.Text = ""
        Me.ChkActivo.Checked = 1
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Limpiar_Pantalla()
    End Sub

    Private Sub CmdGrabar_Click(sender As Object, e As EventArgs) Handles CmdGrabar.Click
        Dim Dataset As New DataSet, SQlstring As String

        SQlstring = "SELECT Codigo_Contenedor, Nombre_Contenedor, Activo FROM Contenedor WHERE (Codigo_Contenedor = '" & Me.CboCodigoContenedor.Text & "') "
        Dataset = FillConsultaSQL(SQlstring, "Consulta").Copy
        If Dataset.Tables("Consulta").Rows.Count = 0 Then
            SQlstring = "INSERT INTO Contenedor ([Codigo_Contenedor],[Nombre_Contenedor],[Activo])  VALUES ('" & CboCodigoContenedor.Text & "', '" & TxtNombre.Text & "' , '" & ChkActivo.Checked & "')"
            EjecutarConsulta(SQlstring)
        Else
            SQlstring = "UPDATE [Contenedor]  SET [Codigo_Contenedor] = '" & CboCodigoContenedor.Text & "' ,[Nombre_Contenedor] = '" & TxtNombre.Text & "' ,[Activo] = " & ChkActivo.Checked & "  WHERE (Codigo_Contenedor = '" & Me.CboCodigoContenedor.Text & "') "
            EjecutarConsulta(SQlstring)
        End If

        LimpiarPlantillas()
    End Sub

    Private Sub ButtonBorrar_Click(sender As Object, e As EventArgs) Handles ButtonBorrar.Click
        Dim Dataset As New DataSet, SQlstring As String, Resultado As Double

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Contenedor?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        SQlstring = "SELECT Codigo_Contenedor, Nombre_Contenedor, Activo FROM Contenedor WHERE (Codigo_Contenedor = '" & Me.CboCodigoContenedor.Text & "') "
        Dataset = FillConsultaSQL(SQlstring, "Consulta").Copy
        If Dataset.Tables("Consulta").Rows.Count <> 0 Then
            SQlstring = "DELETE FROM Contenedor WHERE (Codigo_Contenedor = '" & Me.CboCodigoContenedor.Text & "') "
            EjecutarConsulta(SQlstring)
        End If

        LimpiarPlantillas()
    End Sub

    Private Sub CmdPrecios_Click(sender As Object, e As EventArgs) Handles CmdPrecios.Click
        Quien = "Contenedores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoContenedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class