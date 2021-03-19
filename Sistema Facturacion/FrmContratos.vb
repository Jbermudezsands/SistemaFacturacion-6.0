Public Class FrmContratos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NumeroContrato As Double
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmContratosNuevos.LblNumeroContrato.Text = ""
        My.Forms.FrmContratosNuevos.Nuevo = True
        My.Forms.FrmContratosNuevos.ShowDialog()

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_listaContrattos(Me.OptActivo.Checked, Me.OptAnulado.Checked)
    End Sub


    Public Sub Cargar_listaContrattos(ByVal Activo As Boolean, ByVal Anulado As Boolean)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQlClientes As String = ""

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Activo = True Then
            SQlClientes = "SELECT Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.Cod_Cliente, Contratos.Frecuencia, Contratos.Inicio_Contrato, Contratos.Fin_Contrato, Contratos.Moneda, Contratos.Activo, Contratos.Anulado FROM  Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente WHERE (Contratos.Activo = 1)"

        ElseIf Activo = False Then
            SQlClientes = "SELECT Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.Cod_Cliente, Contratos.Frecuencia, Contratos.Inicio_Contrato, Contratos.Fin_Contrato, Contratos.Moneda, Contratos.Activo, Contratos.Anulado FROM  Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente WHERE (Contratos.Activo = 0)"
        ElseIf Anulado = True Then
            SQlClientes = "SELECT Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.Cod_Cliente, Contratos.Frecuencia, Contratos.Inicio_Contrato, Contratos.Fin_Contrato, Contratos.Moneda, Contratos.Activo, Contratos.Anulado FROM  Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente WHERE (Contratos.Anulado = 1)"
        ElseIf Anulado = False Then
            SQlClientes = "SELECT Contratos.Numero_Contrato, Contratos.Cod_Cliente, Clientes.Cod_Cliente, Contratos.Frecuencia, Contratos.Inicio_Contrato, Contratos.Fin_Contrato, Contratos.Moneda, Contratos.Activo, Contratos.Anulado FROM  Contratos INNER JOIN Clientes ON Contratos.Cod_Cliente = Clientes.Cod_Cliente WHERE (Contratos.Anulado = 0)"
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SQlClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato")
        Me.TDGridSolicitud.DataSource = DataSet.Tables("Contrato")
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Numero_Contrato").Width = 100
        Me.TDGridSolicitud.Columns("Numero_Contrato").Caption = "Numero Contrato"
        Me.TDGridSolicitud.Splits.Item(0).DisplayColumns("Cod_Cliente").Width = 80
        Me.TDGridSolicitud.Columns("Cod_Cliente").Caption = "Codigo Cliente"





    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Cargar_listaContrattos(Me.OptActivo.Checked, Me.OptAnulado.Checked)
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click

        My.Forms.FrmContratosNuevos.Nuevo = False
        My.Forms.FrmContratosNuevos.LblNumeroContrato.Text = "-----0-----"
        My.Forms.FrmContratosNuevos.LblNumeroContrato.Text = Format(CDbl(Me.TDGridSolicitud.Columns("Numero_Contrato").Text), "0000#")
        My.Forms.FrmContratosNuevos.NumeroContrato = Me.TDGridSolicitud.Columns("Numero_Contrato").Text
        My.Forms.FrmContratosNuevos.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double, Numero As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String, IposicionFila As Double

        Resultado = MsgBox("¿Esta Seguro de Anular el Contrato?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = "7" Then
            Exit Sub
        End If

        MiConexion.Close()
        Numero = Me.TDGridSolicitud.Columns("Numero").Text
        Fecha = Format(CDate(Me.TDGridSolicitud.Columns("Fecha").Text), "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "UPDATE [Contratos]  SET [Activo] = 0 ,[Activo2] = 0 ,[Anulado] = 1  WHERE (Numero_Contrato = '" & Numero & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        Cargar_listaContrattos(Me.OptActivo.Checked, Me.OptAnulado.Checked)

    End Sub

    Private Sub OptActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptActivo.CheckedChanged

    End Sub

    Private Sub OptAnulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAnulado.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQlString As String, Cont As Double, i As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Resultado As Double

        Resultado = MsgBox("Se Crearan Facturas segun Contrato", MsgBoxStyle.YesNo, "Zeus Facturacion")

        If Resultado = 7 Then
            Exit Sub
        End If

        SQlString = "SELECT Contratos.* FROM Contratos WHERE (Activo = 1) OR (Activo2 = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "ContratosActivos")
        Cont = DataSet.Tables("ContratosActivos").Rows.Count
        i = 0
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = Cont
        Me.ProgressBar.Value = 0
        Do While Cont > i


            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            i = i + 1
        Loop





    End Sub
End Class