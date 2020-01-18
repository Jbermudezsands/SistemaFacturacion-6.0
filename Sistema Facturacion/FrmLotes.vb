Public Class FrmLotes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public CodigoProducto As String, NombreProducto As String, Cantidad As Double, NumeroDocumento As String, TipoDocumento As String, Fecha As Date, NumeroLote As String, NombreLote As String, FechaVence As Date

    Private Sub FrmLotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim oDataRow As DataRow, i As Double

        'SQlString = "SELECT id_Detalle_Lote, Cantidad, Numero_Lote, FechaVence, Tipo_Documento, Numero_Documento, Fecha, Codigo_Producto  FROM Detalle_Lote WHERE (Numero_Documento = '" & NumeroDocumento & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        SQlString = "SELECT *  FROM Lote  WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")

        Me.BindingDetalle.DataSource = DataSet.Tables("Lotes")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Col = 1
        Me.TrueDBGridComponentes.Row = 0
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TrueDBGridComponentes.Columns(0).Caption = "Numero"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 150
        Me.TrueDBGridComponentes.Columns(1).Caption = "Nombre Lote"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 330
        Me.TrueDBGridComponentes.Columns(2).Caption = "Fecha Vence"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 100
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Visible = False
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = False
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, id As Double, Posicion As Double, Fecha2 As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        Fecha2 = Format(Fecha, "yyyy-MM-dd")

        Posicion = Me.BindingDetalle.Position
        id = Me.BindingDetalle.Item(Posicion)("id_Detalle_Lote")
        SQLProveedor = "SELECT Detalle_Lote.* FROM  Detalle_Lote WHERE (id_Detalle_Lote = " & id & ") AND (Numero_Documento = '" & NumeroDocumento & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha2 & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "lOTES")
        If Not DataSet.Tables("lOTES").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Detalle_Lote] WHERE (id_Detalle_Lote = " & id & ") AND (Numero_Documento = '" & NumeroDocumento & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha2 & "', 102)) AND (Tipo_Documento = '" & TipoDocumento & "') AND (Codigo_Producto = '" & CodigoProducto & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Bitacora(Now, NombreUsuario, "Compra Lotes", "Borro lOTE Producto: " & Me.LblProducto.Text)
        Me.BindingDetalle.RemoveCurrent()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Registros As String, iPosicion As Double, NombreLote As String, id As Double, CodigoProducto As String, FechaVence As Date, CantidadLote As Double

        Me.BindingDetalle.MoveFirst()
        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        id = 1
        Do While iPosicion < Registros
            '/////////////////////////////////////////BUSCO EL NUEMERO DE SERIES //////////////////////////////
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")) Then
                id = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Lote")
            Else
                id = -1000000
            End If

            CodigoProducto = Me.CodigoProducto
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                NombreLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
                FechaVence = Me.BindingDetalle.Item(iPosicion)("FechaVence")
                CantidadLote = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                If NombreLote <> "" Then
                    GrabaDetalleLotes(Me.NumeroDocumento, Me.Fecha, Me.TipoDocumento, id, CodigoProducto, CantidadLote, NombreLote, FechaVence)
                    'id = id + 1
                End If

            End If

            iPosicion = iPosicion + 1
        Loop

        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        My.Forms.FrmListaLotes.CodigoProducto = Me.CodigoProducto
        My.Forms.FrmListaLotes.ShowDialog()
        Me.TrueDBGridComponentes.Columns(1).Text = 1
        Me.TrueDBGridComponentes.Columns(2).Text = My.Forms.FrmListaLotes.NombreLote
        Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmListaLotes.FechaVence
        Me.TrueDBGridComponentes.Columns(4).Text = TipoDocumento
        Me.TrueDBGridComponentes.Columns(5).Text = NumeroDocumento
        Me.TrueDBGridComponentes.Columns(6).Text = Fecha
        Me.TrueDBGridComponentes.Columns(7).Text = CodigoProducto


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Posicion As Double

        Posicion = Me.BindingDetalle.Position
        NumeroLote = Me.BindingDetalle.Item(Posicion)("Numero_Lote")
        FechaVence = Me.BindingDetalle.Item(Posicion)("FechaVence")
        Me.Close()


    End Sub
End Class