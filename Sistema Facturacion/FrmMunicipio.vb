Public Class FrmMunicipio
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Id_Municipio As Double
    Private Sub Limpiar_Municipio()
        Id_Municipio = -1
        Me.TxtNombre.Text = ""
        Me.CboCodigoLinea.Text = ""
        Me.LblIdMunicipio.Text = ""
    End Sub
    Public Sub Actualizar_Municipios()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SQLstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        Dim Sql As String = "SELECT dbo.Municipio.* FROM  dbo.Municipio WHERE (Tipo = 'Municipio')"
        DataAdapter.Fill(DataSet, "Municipio")
        If Not DataSet.Tables("Municipio").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("Municipio")
            Me.CboCodigoLinea.Splits.Item(0).DisplayColumns(0).Visible = False
            Me.CboCodigoLinea.Splits.Item(0).DisplayColumns(1).Visible = False
        End If

    End Sub

    Private Sub FrmMunicipio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT dbo.Departamentos.* FROM  dbo.Departamentos"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Departamento")
        If Not DataSet.Tables("Departamento").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("Departamento")
        End If

        Id_Municipio = -1

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Limpiar_Municipio()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "CodigoDepartamento"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoLinea.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Grabar_Municipios(Me.CboCodigoLinea.Text, Me.TxtNombre.Text, "Municipio", Id_Municipio, True)
        Limpiar_Municipio()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Municipio"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
            Exit Sub
        End If

        Id_Municipio = My.Forms.FrmConsultas.Codigo
        Me.TxtNombre.Text = My.Forms.FrmConsultas.Descripcion
        Me.CboCodigoLinea.Text = My.Forms.FrmConsultas.Descripcion2
        Me.LblIdMunicipio.Text = Id_Municipio
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim Resultado As Integer

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        Eliminar_Municipios(Id_Municipio, "Municipios")
        Me.Actualizar_Municipios()
        Limpiar_Municipio()
    End Sub
End Class