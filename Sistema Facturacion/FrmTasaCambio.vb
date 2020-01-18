Public Class FrmTasaCambio
    Public DataSet As New DataSet
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Codigo As String, Descripcion As String, TipoProducto As String
    Public MiconexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)

    Private Sub FrmTasaCambio_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Tasa de Cambio")
    End Sub

    Private Sub FrmTasaCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLTasa As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter

        SQLTasa = "SELECT * FROM  TasaCambio"
        Me.TrueDBGridConsultas.Columns(0).Caption = "Fecha Tasa"
        Me.TrueDBGridConsultas.Columns(1).Caption = "Monto Tasa"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQLTasa, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")
        Me.BindingTasa.DataSource = DataSet.Tables("Consultas")
        Me.TrueDBGridConsultas.DataSource = Me.BindingTasa
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQL As String, FechaTasa As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Tasa de Cambio?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        FechaTasa = Format(CDate(Me.TrueDBGridConsultas.Columns(0).Text), "yyyy-MM-dd")


        SQL = "SELECT *  FROM TasaCambio WHERE (FechaTasa = CONVERT(DATETIME, '" & FechaTasa & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TasaCambio")
        If Not DataSet.Tables("TasaCambio").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////

            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [TasaCambio] WHERE (FechaTasa = CONVERT(DATETIME, '" & FechaTasa & "', 102))"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If


        SQL = "SELECT * FROM  TasaCambio"
        Me.TrueDBGridConsultas.Columns(0).Caption = "Fecha Tasa"
        Me.TrueDBGridConsultas.Columns(1).Caption = "Monto Tasa"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")
        Me.BindingTasa.DataSource = DataSet.Tables("Consultas")
        Me.TrueDBGridConsultas.DataSource = Me.BindingTasa

    End Sub

    Private Sub TrueDBGridConsultas_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridConsultas.BeforeUpdate
        Dim FechaTasa As String, Monto As Double, Fecha As String

        FechaTasa = Me.TrueDBGridConsultas.Columns(0).Text
        If Me.TrueDBGridConsultas.Columns(1).Text = "" Then
            Exit Sub
        End If
        Monto = Me.TrueDBGridConsultas.Columns(1).Text
        Fecha = Format(CDate(FechaTasa), "yyyy-MM-dd")

        Dim SQL As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        SQL = "SELECT  * FROM TasaCambio WHERE (FechaTasa = CONVERT(DATETIME, '" & Fecha & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = "UPDATE [TasaCambio] SET [MontoTasa] = " & Monto & "  WHERE FechaTasa= '" & Fecha & "'"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            MiConexion.Close()
            StrSqlUpdate = "INSERT INTO [TasaCambio] ([FechaTasa],[MontoTasa]) " & _
                           "VALUES ('" & FechaTasa & "','" & Monto & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

    End Sub



    Private Sub TrueDBGridConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.Click

    End Sub

    Private Sub cmdAddDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddDocente.Click
        Dim FechaTasa As String

        FechaTasa = Format(Now, "dd/MM/yyyy")
        Me.BindingTasa.AddNew()
        Me.TrueDBGridConsultas.Columns(0).Text = FechaTasa




    End Sub
End Class