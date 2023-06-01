Public Class FrmListadoNominas
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmListadoNominas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT  Nomina.NumPlanilla, Nomina.CodTipoNomina, TipoNomina.TipoNomina, Nomina.FechaInicial, Nomina.FechaFinal, Nomina.Año, Nomina.mes, Nomina.Periodo FROM Nomina INNER JOIN TipoNomina ON Nomina.CodTipoNomina = TipoNomina.CodTipoNomina WHERE(Nomina.Activo = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ListadoNomina")
        Me.TDGridListadoNomina.DataSource = DataSet.Tables("ListadoNomina")

        Me.TDGridListadoNomina.Splits(0).DisplayColumns("NumPlanilla").Width = 70
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("CodTipoNomina").Width = 103
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("TipoNomina").Width = 217
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("FechaInicial").Width = 84
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("FechaFinal").Width = 84
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("Año").Width = 45
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("mes").Width = 45
        Me.TDGridListadoNomina.Splits(0).DisplayColumns("Periodo").Width = 45



    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub CmdNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNomina.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepPlanilla As New ArepPlanilla, SqlDatos As String
        Dim RutaLogo As String, SqlDetalle As String, NumNomina As String, FechaIni As Date, FechaFin As Date
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource


        NumNomina = Me.TDGridListadoNomina.Columns("NumPlanilla").Text
        FechaIni = Me.TDGridListadoNomina.Columns("FechaInicial").Text
        FechaFin = Me.TDGridListadoNomina.Columns("FechaFinal").Text

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepPlanilla.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepPlanilla.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepPlanilla.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepPlanilla.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If


        ArepPlanilla.LblOrden.Text = NumNomina
        ArepPlanilla.LblFechaOrden.Text = FechaFin

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT Detalle_Nomina.NumNomina,Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado,Detalle_Nomina.Domingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos, Detalle_Nomina.IR, Detalle_Nomina.Trazabilidad, Detalle_Nomina.Bolsa, Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR + Detalle_Nomina.Bolsa + Detalle_Nomina.Trazabilidad + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos,Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor  " & _
                     "WHERE (Detalle_Nomina.NumNomina = '" & NumNomina & "') AND (Detalle_Nomina.TipoProductor = 'Productor')"
        'SqlDetalle = "SELECT Detalle_Nomina.NumNomina, Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes, Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado, Detalle_Nomina.Domingo, Detalle_Nomina.Lunes * Detalle_Nomina.PrecioVenta AS MontoLunes, Detalle_Nomina.Martes * Detalle_Nomina.PrecioVenta AS MontoMartes, Detalle_Nomina.Miercoles * Detalle_Nomina.PrecioVenta AS MontoMiercoles, Detalle_Nomina.Jueves * Detalle_Nomina.PrecioVenta AS MontoJueves, Detalle_Nomina.Viernes * Detalle_Nomina.PrecioVenta AS MontoViernes, Detalle_Nomina.Sabado * Detalle_Nomina.PrecioVenta AS MontoSabado, Detalle_Nomina.Domingo * Detalle_Nomina.PrecioVenta AS MontoDomingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos, Detalle_Nomina.IR, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia, Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios, Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos, Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar, Ruta_Distribucion.Nombre_Ruta, Ruta_Distribucion.CodRuta  FROM Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
        '             "WHERE (Detalle_Nomina.NumNomina = '" & Me.TxtNumNomina.Text & "') AND (Detalle_Nomina.TipoProductor = 'Productor') ORDER BY Ruta_Distribucion.CodRuta"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepPlanilla.DataSource = SQL
        ArepPlanilla.Document.Name = "Reporte de Planilla Reimpresion"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepPlanilla.Document
        ViewerForm.Show()
        ArepPlanilla.Run(False)

    End Sub

    Private Sub CmdColillas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdColillas.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Mes As String = ""
        Dim ArepColillas As New ArepListaRecepcion, SqlDatos As String, FechaInicio As Date, FechaFin As Date
        Dim RutaLogo As String, SqlDetalle As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim NumNomina As String

        NumNomina = Me.TDGridListadoNomina.Columns("NumPlanilla").Text
        FechaInicio = Me.TDGridListadoNomina.Columns("FechaInicial").Text
        FechaFin = Me.TDGridListadoNomina.Columns("FechaFinal").Text

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepColillas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepColillas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepColillas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepColillas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        Select Case FechaFin.Month
            Case 1 : Mes = "Enero"
            Case 2 : Mes = "Febrero"
            Case 3 : Mes = "Marzo"
            Case 4 : Mes = "Abril"
            Case 5 : Mes = "Mayo"
            Case 6 : Mes = "Junio"
            Case 7 : Mes = "Julio"
            Case 8 : Mes = "Agosto"
            Case 9 : Mes = "Septiembre"
            Case 10 : Mes = "Octubre"
            Case 11 : Mes = "Noviembre"
            Case 12 : Mes = "Diciembre"
        End Select



        ArepColillas.LblImpreso.Text = Format(Now, "dd/MM/yyyy")
        ArepColillas.LblRecepcion.Text = "Recepcion de Leche de la Semana del " & FechaInicio.Day & " al " & FechaFin.Day & " de " & Mes & " " & FechaFin.Year

        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        'SqlDetalle = "SELECT  Nomina.NumPlanilla, Nomina.FechaInicial, Nomina.FechaFinal, Productor.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Roc1, Detalle_Nomina.Lunes, Detalle_Nomina.Roc2, Detalle_Nomina.Martes, Detalle_Nomina.Roc3, Detalle_Nomina.Miercoles, Detalle_Nomina.Roc4, Detalle_Nomina.Jueves, Detalle_Nomina.Roc5, Detalle_Nomina.Viernes, Detalle_Nomina.Roc6, Detalle_Nomina.Sabado, Detalle_Nomina.Roc7, Detalle_Nomina.Domingo, Detalle_Nomina.Total, Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM  Detalle_Nomina INNER JOIN Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN  Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN  Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
        '             "WHERE  (Nomina.NumPlanilla = '" & Me.TxtNumNomina.Text & "') ORDER BY Ruta_Distribucion.CodRuta, Productor.CodProductor"

        SqlDetalle = "SELECT  Nomina.NumPlanilla, Nomina.FechaInicial, Nomina.FechaFinal, Productor.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Roc1, Detalle_Nomina.Lunes, Detalle_Nomina.Roc2, Detalle_Nomina.Martes, Detalle_Nomina.Roc3, Detalle_Nomina.Miercoles, Detalle_Nomina.Roc4, Detalle_Nomina.Jueves, Detalle_Nomina.Roc5, Detalle_Nomina.Viernes, Detalle_Nomina.Roc6, Detalle_Nomina.Sabado, Detalle_Nomina.Roc7, Detalle_Nomina.Domingo, Detalle_Nomina.Total, Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM Detalle_Nomina INNER JOIN  Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Ruta_Distribucion ON Productor.CodRuta = Ruta_Distribucion.CodRuta  " & _
                     "WHERE   (Nomina.NumPlanilla = '" & NumNomina & "') ORDER BY Ruta_Distribucion.CodRuta, Productor.CodProductor"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepColillas.DataSource = SQL
        ArepColillas.Document.Name = "Reporte de Planilla"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepColillas.Document
        ViewerForm.Show()
        ArepColillas.Run(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ArepColilla As New ArepColillas, SqlDatos As String
        Dim SqlDetalle As String, SqlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim i As Double = 0, CodRuta As String
        Dim NumNomina As String, FechaInicio As Date, FechaFin As Date


        NumNomina = Me.TDGridListadoNomina.Columns("NumPlanilla").Text
        FechaInicio = Me.TDGridListadoNomina.Columns("FechaInicial").Text
        FechaFin = Me.TDGridListadoNomina.Columns("FechaFinal").Text

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepColilla.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")


            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
            '    ArepColilla.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            'End If
            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
            '    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            '    If Dir(RutaLogo) <> "" Then
            '        ArepPlanilla.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
            '    End If

            'End If
        End If

        ArepColilla.LblPeriodo.Text = "Desde     " & Format(FechaInicio, "dd/MM/yyyy") & "    Hasta     " & Format(FechaFin, "dd/MM/yyyy")


        'SqlString = "SELECT DISTINCT Ruta_Distribucion.CodRuta, Ruta_Distribucion.Nombre_Ruta FROM  Ruta_Distribucion INNER JOIN Productor ON Ruta_Distribucion.CodRuta = Productor.CodRuta"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Ruta")
        'i = 0
        'Do While DataSet.Tables("Ruta").Rows.Count > i

        'CodRuta = DataSet.Tables("Ruta").Rows(i)("CodRuta")

        'MsgBox("SE IMPRIME LAS COLILLAS DE " & DataSet.Tables("Ruta").Rows(i)("Nombre_Ruta"))


        '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////
        SqlDetalle = "SELECT  Detalle_Nomina.CodProductor, Productor.NombreProductor + ' ' + Productor.ApellidoProductor AS Nombres, Detalle_Nomina.Lunes,Detalle_Nomina.Martes, Detalle_Nomina.Miercoles, Detalle_Nomina.Jueves, Detalle_Nomina.Viernes, Detalle_Nomina.Sabado,Detalle_Nomina.Domingo, Detalle_Nomina.Total, Detalle_Nomina.PrecioVenta, Detalle_Nomina.TotalIngresos,  Detalle_Nomina.Trazabilidad, Detalle_Nomina.IR,Detalle_Nomina.Bolsa,Detalle_Nomina.OtrasDeducciones, Detalle_Nomina.DeduccionPolicia, Detalle_Nomina.Anticipo, Detalle_Nomina.DeduccionTransporte, Detalle_Nomina.Pulperia,Detalle_Nomina.Inseminacion, Detalle_Nomina.ProductosVeterinarios,Detalle_Nomina.IR +  Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios AS TotalEgresos,Detalle_Nomina.TotalIngresos - (Detalle_Nomina.IR +  Detalle_Nomina.Trazabilidad + Detalle_Nomina.Bolsa + Detalle_Nomina.OtrasDeducciones + Detalle_Nomina.DeduccionPolicia + Detalle_Nomina.Anticipo + Detalle_Nomina.DeduccionTransporte + Detalle_Nomina.Pulperia + Detalle_Nomina.Inseminacion + Detalle_Nomina.ProductosVeterinarios) AS NetoPagar, Nomina.NumPlanilla,Nomina.FechaInicial, Nomina.FechaFinal ,  Detalle_Nomina.PrecioLunes, Detalle_Nomina.PrecioMartes, Detalle_Nomina.PrecioMiercoles, Detalle_Nomina.PrecioJueves, Detalle_Nomina.PrecioViernes, Detalle_Nomina.PrecioSabado, Detalle_Nomina.PrecioDomingo, TipoNomina.TipoNomina FROM  Detalle_Nomina INNER JOIN Productor ON Detalle_Nomina.CodProductor = Productor.CodProductor AND Detalle_Nomina.TipoProductor = Productor.TipoProductor INNER JOIN Nomina ON Detalle_Nomina.NumNomina = Nomina.NumPlanilla INNER JOIN TipoNomina ON Nomina.CodTipoNomina = TipoNomina.CodTipoNomina " & _
                     "WHERE (Detalle_Nomina.NumNomina = '" & NumNomina & "') AND (Detalle_Nomina.TipoProductor = 'Productor') "
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlDetalle
        ArepColilla.DataSource = SQL
        ArepColilla.Document.Name = "Reporte de Planilla"
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepColilla.Document
        ArepColilla.Run(True)
        ViewerForm.ShowDialog()

        'i = i + 1
        'Loop

    End Sub
End Class