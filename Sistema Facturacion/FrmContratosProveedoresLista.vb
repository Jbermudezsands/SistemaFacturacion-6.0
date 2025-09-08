Public Class FrmContratosProveedoresLista
    Public Sub Cargar_Grid()
        Dim SQlString As String, DataSet As New DataSet

        SQlString = "SELECT Contrato_Proveedor.Numero_Contrato, Proveedor.Nombre_Proveedor, Contrato_Proveedor.Modelo, Contrato_Proveedor.Fecha_Inicio, Contrato_Proveedor.Fecha_Fin, Contrato_Proveedor.Telefono_Contacto, Proveedor.RUC, Contrato_Proveedor.Estado FROM Contrato_Proveedor INNER JOIN Proveedor ON Contrato_Proveedor.Codigo_Proveedor = Proveedor.Cod_Proveedor WHERE  (Contrato_Proveedor.Estado = '" & Me.CmbEstado.Text & "')"
        DataSet = FillConsultaSQL(SQlString, "Contrato")
        Me.TDGridListadoNomina.DataSource = DataSet.Tables("Contrato")
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Numero_Contrato").Width = 70
        Me.TDGridListadoNomina.Columns("Numero_Contrato").Caption = "No.Contrato"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Nombre_Proveedor").Width = 217
        Me.TDGridListadoNomina.Columns("Nombre_Proveedor").Caption = "Nombre Proveedor"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Modelo").Width = 70
        Me.TDGridListadoNomina.Columns("Modelo").Caption = "Modelo"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Fecha_Inicio").Width = 80
        Me.TDGridListadoNomina.Columns("Fecha_Inicio").Caption = "Fecha Inicio"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Fecha_Fin").Width = 80
        Me.TDGridListadoNomina.Columns("Fecha_Fin").Caption = "Fecha Fin"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("Telefono_Contacto").Width = 80
        Me.TDGridListadoNomina.Columns("Telefono_Contacto").Caption = "Telefono"
        Me.TDGridListadoNomina.Splits.Item(0).DisplayColumns("RUC").Width = 80
        Me.TDGridListadoNomina.Columns("RUC").Caption = "RUC"

    End Sub




    Private Sub BtnContratoNuevo_Click(sender As Object, e As EventArgs) Handles BtnContratoNuevo.Click
        FrmContratosProveedor.ShowDialog()
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmContratosProveedoresLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CmbEstado.Text = "Autorizado"
        Cargar_Grid()
    End Sub

    Private Sub BtnVisualizar_Click(sender As Object, e As EventArgs) Handles BtnVisualizar.Click
        Dim Numero_Contrato As String
        If Me.TDGridListadoNomina.Columns("Numero_Contrato").Text = "" Then
            Exit Sub
        End If

        Numero_Contrato = Me.TDGridListadoNomina.Columns("Numero_Contrato").Text
        My.Forms.FrmContratosProveedor.Numero_Contrato = Numero_Contrato
        My.Forms.FrmContratosProveedor.ShowDialog()


    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Cargar_Grid()
    End Sub
End Class