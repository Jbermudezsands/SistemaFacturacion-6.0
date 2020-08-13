Public Class FrmActivar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)


    Private Sub FrmActivar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM TipoNomina WHERE (Activa=0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        Me.BindingNominas.DataSource = DataSet.Tables("TipoNomina")
        Me.TrueDBGridComponentes.DataSource = Me.BindingNominas
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True




    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridComponentes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.DoubleClick
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodTipoNomina As String, Posicion As Integer, Nomina As String

        Posicion = Me.BindingNominas.Position
        CodTipoNomina = Me.BindingNominas.Item(Posicion)("CodTipoNomina")
        Nomina = Me.BindingNominas.Item(Posicion)("TipoNomina")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO LOS PERIODOS ACTIVOS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT * FROM Periodos WHERE (Calculada = 0) AND (TipoNomina = '" & CodTipoNomina & "') ORDER BY Periodo"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Periodos")
        If DataSet.Tables("Periodos").Rows.Count <> 0 Then
            Me.CboPeriodo.DataSource = DataSet.Tables("Periodos")
            Me.CboPeriodo.Text = DataSet.Tables("Periodos").Rows(0)("Periodo")
            Me.CmdNuevo.Enabled = True
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboPeriodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPeriodo.TextChanged
        Me.DTPFechaIni.Value = Me.CboPeriodo.Columns(4).Text
        Me.DTPFechaFin.Value = Me.CboPeriodo.Columns(5).Text
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodTipoNomina As String, Posicion As Integer, ConsecutivoCompra As Double, NumeroPlanilla As String
        Dim FechaInicio As String, SqlString As String, Nomina As String, Año As Double, Mes As Double, Periodo As Double
        Dim ConsecutivoConductores As Double, NumeroPlanillaConductores As String, ConsecutivoLiquida As Double, NumeroPlanillaLiquida As String

        Try



            Posicion = Me.BindingNominas.Position
            CodTipoNomina = Me.BindingNominas.Item(Posicion)("CodTipoNomina")
            Nomina = Me.BindingNominas.Item(Posicion)("TipoNomina")

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "Update [TipoNomina] SET [Activa] = 1  WHERE (CodTipoNomina='" & CodTipoNomina & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()



            ConsecutivoCompra = BuscaConsecutivo("Planilla")
            NumeroPlanilla = Format(ConsecutivoCompra, "0000#")
            FechaInicio = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")


            StrSqlUpdate = "UPDATE [Periodos] SET [Actual] = 1 ,[NumNomina] = '" & NumeroPlanilla & "' WHERE (TipoNomina = '" & CodTipoNomina & "') AND (Inicio = CONVERT(DATETIME, '" & FechaInicio & "', 102))"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////BUSCO EL PERIODO GRABADO////////////////////////////////////////////////
            SqlString = "SELECT  * FROM Periodos WHERE (NumNomina = '" & NumeroPlanilla & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Periodo")
            If DataSet.Tables("Periodo").Rows.Count <> 0 Then
                Año = DataSet.Tables("Periodo").Rows(0)("año")
                Mes = DataSet.Tables("Periodo").Rows(0)("mes")
                Periodo = DataSet.Tables("Periodo").Rows(0)("Periodo")
            End If


            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////AGREGO LA NOMINA///////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT * FROM Nomina WHERE (NumPlanilla = '" & NumeroPlanilla & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Nomina")
            If DataSet.Tables("Nomina").Rows.Count = 0 Then
                StrSqlUpdate = "INSERT INTO [Nomina] ([NumPlanilla],[CodTipoNomina],[FechaInicial],[FechaFinal],[Año],[mes],[Periodo]) " & _
                               "VALUES( '" & NumeroPlanilla & "', '" & CodTipoNomina & "','" & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "','" & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy") & "'," & Año & " ," & Mes & "," & Periodo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO LA NOMINA CONTRATISTAS //////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT NominaTransportista.* FROM NominaTransportista WHERE(Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "NominaConductor")
            If DataSet.Tables("NominaConductor").Rows.Count = 0 Then

                ConsecutivoConductores = BuscaConsecutivo("PlanillaConductor")
                NumeroPlanillaConductores = Format(ConsecutivoConductores, "0000#")

                StrSqlUpdate = "INSERT INTO [NominaTransportista] ([NumPlanilla],[CodTipoNomina],[FechaInicial],[FechaFinal],[Año],[mes],[Periodo]) " & _
                               "VALUES( '" & NumeroPlanillaConductores & "', '" & CodTipoNomina & "','" & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "','" & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy") & "'," & Año & " ," & Mes & "," & Periodo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If



            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO LA NOMINA LIQUIDACION //////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT NominaLiquidacion.* FROM NominaLiquidacion WHERE(Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "NominaLiquidacion")
            If DataSet.Tables("NominaLiquidacion").Rows.Count = 0 Then
                ConsecutivoLiquida = BuscaConsecutivo("Liquidacion")
                NumeroPlanillaLiquida = Format(ConsecutivoConductores, "0000#")
                StrSqlUpdate = "INSERT INTO [NominaLiquidacion] ([NumPlanilla],[FechaInicial],[FechaFinal],[Año],[mes],[Periodo]) " & _
                               "VALUES( '" & NumeroPlanillaLiquida & "', '" & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "','" & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy") & "'," & Año & " ," & Mes & "," & Periodo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////ACTIVO LA NOMINA/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM TipoNomina WHERE (Activa=0)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "TipoNomina")
            Me.BindingNominas.DataSource = DataSet.Tables("TipoNomina")
            Me.TrueDBGridComponentes.DataSource = Me.BindingNominas
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True

            MsgBox("La nomina se Activo correctamente", MsgBoxStyle.Exclamation, "Zeus Acopio")

            Me.CmdNuevo.Enabled = False

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
End Class