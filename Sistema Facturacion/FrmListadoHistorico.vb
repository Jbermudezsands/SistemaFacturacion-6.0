Public Class FrmListadoHistorico
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
    Public Sub Cargar_Grid()
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT IndiceNota.Numero_Nota, IndiceNota.Fecha_Nota, NotaDebito.CodigoNB, NotaDebito.Descripcion, NotaDebito.Tipo, IndiceNota.Cod_Cliente, IndiceNota.Nombre_Cliente, IndiceNota.Activo, IndiceNota.Contabilizado FROM IndiceNota INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Listado")
        Me.TDGridListadoNomina.DataSource = DataSet.Tables("Listado")


    End Sub



    Private Sub FrmListadoHistorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Grid()
    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles BtnVisualizar.Click
        Dim Numero_Nota As String, Fecha_Nota As Date, Tipo_Nota As String

        Numero_Nota = Me.TDGridListadoNomina.Columns("Numero_Nota").Text
        Fecha_Nota = Me.TDGridListadoNomina.Columns("Fecha_Nota").Text
        Tipo_Nota = Me.TDGridListadoNomina.Columns("Tipo").Text

        Quien = "Historico"
        FrmRegistroDebito.Show()
        FrmRegistroDebito.DTPFecha.Value = Fecha_Nota
        FrmRegistroDebito.TxtNumeroEnsamble.Text = Numero_Nota
        FrmRegistroDebito.Cargar_Nota_Debito(Fecha_Nota, Numero_Nota, Tipo_Nota)



    End Sub
    Public Sub Imprimir_Nota(NumeroNota As String, Codigo_Tipo_Nota As String, FechaNota As String, TipoImpresion As String)
        Dim ArepNotaDebito As New ArepNotaDebito
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim NombreEmpresa As String = "", DireccionEmpresa As String = "", Ruc As String = "", RutaLogo As String = "", Observaciones As String = ""
        Dim SqlString As String, TipoNota As String = ""

        '//////////////////////////////////DATOS DE EMPRESA ///////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                Ruc = "R.U.C NO " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If

        SqlDatos = "SELECT  *  FROM  IndiceNota INNER JOIN Detalle_Nota ON IndiceNota.Numero_Nota = Detalle_Nota.Numero_Nota AND IndiceNota.Fecha_Nota = Detalle_Nota.Fecha_Nota AND IndiceNota.Tipo_Nota = Detalle_Nota.Tipo_Nota WHERE  (IndiceNota.Numero_Nota = '" & NumeroNota & "') AND (IndiceNota.Fecha_Nota = CONVERT(DATETIME, '" & Format(CDate(FechaNota), "yyyy-MM-dd") & "', 102)) AND (IndiceNota.Tipo_Nota = '" & Codigo_Tipo_Nota & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        If Not DataSet.Tables("Notas").Rows.Count = 0 Then
            Observaciones = DataSet.Tables("Notas").Rows(0)("Observaciones")
            TipoNota = DataSet.Tables("Notas").Rows(0)("Tipo_Nota")
        End If

        If Dir(RutaLogo) <> "" Then
            ArepNotaDebito.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If
        ArepNotaDebito.LblTitulo.Text = NombreEmpresa
        ArepNotaDebito.LblDireccion.Text = DireccionEmpresa
        ArepNotaDebito.LblRuc.Text = Ruc
        ArepNotaDebito.TxtObservaciones.Text = Observaciones


        If TipoNota = "Credito Clientes" Then
            TipoImpresion = "Notas Credito"
        ElseIf TipoNota = "Debito Clientes" Then
            TipoImpresion = "Notas Debito"
        End If

        SqlDatos = "SELECT     Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente, IndiceNota.Nombre_Cliente, IndiceNota.Observaciones, Clientes.RUC,NotaDebito.Tipo FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN Clientes ON IndiceNota.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB  " &
                               "WHERE  (Detalle_Nota.Numero_Nota = '" & NumeroNota & "') AND (Detalle_Nota.Fecha_Nota = CONVERT(DATETIME, '" & Format(CDate(FechaNota), "yyyy-MM-dd") & "', 102)) AND (Detalle_Nota.Tipo_Nota = '" & TipoNota & "')"

        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDatos
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepNotaDebito.Document
        My.Application.DoEvents()
        ArepNotaDebito.DataSource = SQL
        ArepNotaDebito.Run(False)
        ViewerForm.Show()


        'SqlString = "SELECT  *  FROM Impresion WHERE (Impresion = '" & TipoImpresion & " ')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Coordenadas")
        'If Not DataSet.Tables("Coordenadas").Rows.Count = 0 Then
        '    Select Case DataSet.Tables("Coordenadas").Rows(0)("Configuracion")
        '        Case "Papel en Blanco"



        '            SqlDatos = "SELECT     Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, IndiceNota.MonedaNota, IndiceNota.Cod_Cliente, IndiceNota.Nombre_Cliente, IndiceNota.Observaciones, Clientes.RUC,NotaDebito.Tipo FROM  Detalle_Nota INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN Clientes ON IndiceNota.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB  " &
        '                       "WHERE  (Detalle_Nota.Numero_Nota = '" & NumeroNota & "') AND (Detalle_Nota.Fecha_Nota = CONVERT(DATETIME, '" & FechaNota & "', 102)) AND (Detalle_Nota.Tipo_Nota = '" & TipoNota & "')"

        '            SQL.ConnectionString = Conexion
        '            SQL.SQL = SqlDatos
        '            Dim ViewerForm As New FrmViewer()
        '            ViewerForm.arvMain.Document = ArepNotaDebito.Document
        '            My.Application.DoEvents()
        '            ArepNotaDebito.DataSource = SQL
        '            ArepNotaDebito.Run(False)
        '            ViewerForm.Show()

        '        Case "Personalizado"




        '        Case "Papel en Blanco Standard"
        '            Dim ViewerForm As New FrmViewer()
        '            ViewerForm.arvMain.Document = ArepNotaDebito.Document
        '            My.Application.DoEvents()
        '            ArepNotaDebito.DataSource = SQL
        '            ArepNotaDebito.Run(False)
        '            ViewerForm.Show()



        '    End Select
        'End If
    End Sub


    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim Numero_Nota As String, Fecha_Nota As Date, Tipo_Nota As String

        Numero_Nota = Me.TDGridListadoNomina.Columns("Numero_Nota").Text
        Fecha_Nota = Me.TDGridListadoNomina.Columns("Fecha_Nota").Text
        Tipo_Nota = Me.TDGridListadoNomina.Columns("CodigoNB").Text

        Imprimir_Nota(Numero_Nota, Tipo_Nota, Fecha_Nota, "Papel en Blanco")
    End Sub
End Class