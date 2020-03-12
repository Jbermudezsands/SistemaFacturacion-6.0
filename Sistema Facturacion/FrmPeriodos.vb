Public Class FrmPeriodos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGenerar.Click
        Dim iPeriodo As Integer
        Dim saMes() As Object = {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"}, Lineas As Integer
        Dim saMes2() As Object = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
        Dim iCont As Integer
        Dim Numfecha2 As String
        Dim iMes As Integer
        Dim iSem As Integer
        Dim FechaIni As Date
        Dim FechaFin As Date
        'Dim iA�o As Integer
        'Dim sIntervalo As String
        'Dim bBisiesto As Boolean
        Dim Fechas As Date

        iPeriodo = 1
        iSem = 1
        iCont = 0

        Select Case Me.CmbTipoPlanilla.Text
            Case "Semanal Domingo"

                'If DepurarFecha(Me.DTPFechaInicio.Value) Then
                '    MsgBox("La Fecha Inicial no es v�lida, corrija", vbInformation)
                '    Me.DTPFechaInicio.Focus()
                '    Exit Sub
                'ElseIf DepurarFecha(Me.DTPFechaFin.Value) Then
                '    MsgBox("La Fecha Final no es v�lida, corrija", vbInformation)
                '    Me.DTPFechaFin.Focus()
                '    Exit Sub
                'End If



                lstPlanilla.Items.Clear()
                FechaIni = Format(Me.DTPFechaInicio.Value, "dd/MM/yyyy")
                FechaFin = DateAdd(DateInterval.Day, 6, FechaIni)


                If Not IsNumeric(Me.TxtA�o.Text) Then

                    MsgBox("El a�o actual de planilla no es v�lido", vbInformation, "Error!!!")
                    Exit Sub
                End If

                Semanas(Year(FechaFin))
                'Hay que setear el a�o actual de planilla OJO
                'Para que no de problemas
                Lineas = 1
                If FechaFin < Me.DTPFechaFin.Value Then
                    Do While FechaFin <= Me.DTPFechaFin.Value  'Hay que setear el a�o actual de planilla OJO
                        'Me.dtaSem.Recordset.FindFirst "[Mes] like '" & saMes(iCont) & "' AND [A�o] like " & Me.DtaA�o.Recordset("A�o") & ""
                        'iMes = 'Me.dtaSem.Recordset.Fields(2)
                        Fechas = "01/" & saMes(iCont) & "/" & Me.TxtA�o.Text
                        NumFecha2 = Fechas
                        iMes = SabadosMes(NumFecha2)
                        lstPlanilla.Items.Add("        " & saMes2(iCont))


                        Do While iMes >= iSem 'And iPeriodo <= 52
                            'GuardarPeriodo
                            lstPlanilla.Items.Add(" " & CStr(iPeriodo) & "   " & CStr(FechaIni) & "  al  " & CStr(FechaFin))
                            FechaIni = DateAdd(DateInterval.Day, 1, FechaFin)
                            FechaFin = DateAdd(DateInterval.Day, 6, FechaIni)


                            iSem = iSem + 1
                            iPeriodo = iPeriodo + 1
                            Lineas = Lineas + 1
                        Loop

                        iSem = 1
                        iCont = iCont + 1
                        lstPlanilla.Items.Add("      ")
                        If Lineas = 14 Then
                            lstPlanilla.Items.Add("      ")
                        End If
                    Loop

                Else
                    MsgBox("El intervalo de la fecha inicial y final no es v�lido", vbInformation, "corrija")
                End If


        End Select


        iPeriodo = 1
        iSem = 1
        iCont = 0
    End Sub

    Private Sub FrmPeriodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQL As String, A�o As Double, Registros As Double, Fecha1 As Date, Fecha2 As Date, TipoPlanilla As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        SQL = "SELECT  *  FROM FechaPlanilla WHERE(Activa = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Periodos")
        If Not DataSet.Tables("Periodos").Rows.Count = 0 Then
            'Periodo1 = DataSet.Tables("Periodos").Rows(0)("Periodo")
            Fecha1 = DataSet.Tables("Periodos").Rows(0)("FechaIni")
            'Registros = DataSet.Tables("Periodos").Rows.Count - 1
            'Periodo2 = DataSet.Tables("Periodos").Rows(Registros)("Periodo")
            Fecha2 = DataSet.Tables("Periodos").Rows(Registros)("FechaFin")
            TipoPlanilla = DataSet.Tables("Periodos").Rows(Registros)("TipoNomina")
            A�o = DataSet.Tables("Periodos").Rows(Registros)("a�o")

            GenerarPeriodo(Fecha1, Fecha2, A�o, TipoPlanilla)
            Me.DTPFechaInicio.Value = Format(Fecha1, "yyyy/MM/dd")
            Me.DTPFechaFin.Value = Format(Fecha2, "yyyy/MM/dd")
            Me.TxtA�o.Text = A�o
            Me.CmbTipoPlanilla.Text = TipoPlanilla
        Else
            Me.DTPFechaInicio.Value = Format(Now, "yyyy/MM/dd")
            Me.DTPFechaFin.Value = Format(Now, "yyyy/MM/dd")
            Me.TxtA�o.Text = Year(Me.DTPFechaFin.Value)

        End If




    End Sub

    Private Sub DTPFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFechaFin.ValueChanged
        Me.TxtA�o.Text = Year(Me.DTPFechaFin.Value)
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim iPeriodo As Integer
        Dim saMes() As Object = {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"}, Lineas As Integer
        Dim saMes2() As Object = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
        Dim iCont As Integer, SQL As String, Periodo As Double, Mes As Double, A�o As Double
        Dim Numfecha2 As String, CodTipoNomina As String = "01"
        Dim iMes As Integer, FechaInicial As String, FechaFinal As String, Fecha2 As Date
        Dim iSem As Integer
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        'Dim iA�o As Integer
        'Dim sIntervalo As String
        'Dim bBisiesto As Boolean
        Dim Fechas As Date

        iPeriodo = 1
        iSem = 1
        iCont = 0

        Select Case Me.CmbTipoPlanilla.Text
            Case "Semanal Domingo"

                'If DepurarFecha(Me.DTPFechaInicio.Value) Then
                '    MsgBox("La Fecha Inicial no es v�lida, corrija", vbInformation)
                '    Me.DTPFechaInicio.Focus()
                '    Exit Sub
                'ElseIf DepurarFecha(Me.DTPFechaFin.Value) Then
                '    MsgBox("La Fecha Final no es v�lida, corrija", vbInformation)
                '    Me.DTPFechaFin.Focus()

                FechaIni = Format(Me.DTPFechaInicio.Value, "dd/MM/yyyy")
                FechaFin = DateAdd(DateInterval.Day, 6, FechaIni)


                If Not IsNumeric(Me.TxtA�o.Text) Then

                    MsgBox("El a�o actual de planilla no es v�lido", vbInformation, "Error!!!")
                    Exit Sub
                End If

                lstPlanilla.Items.Clear()
                Semanas(Year(FechaFin))
                'Hay que setear el a�o actual de planilla OJO
                'Para que no de problemas
                Lineas = 1

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////BUSCO EL TIPO DE LA NOMINA//////////////////////////////////////////
                SQL = "SELECT * FROM TipoNomina WHERE (TipoNomina = '" & Me.CmbTipoPlanilla.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                DataAdapter.Fill(DataSet, "TipoPlanilla")
                If DataSet.Tables("TipoPlanilla").Rows.Count <> 0 Then
                    CodTipoNomina = DataSet.Tables("TipoPlanilla").Rows(0)("CodTipoNomina")
                End If

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////BUSCO SI EXISTE LA NOMINA//////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7

                FechaInicial = Format(Me.DTPFechaInicio.Value, "yyyy-MM-dd")
                FechaFinal = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                Fecha2 = Me.DTPFechaFin.Value
                A�o = Fecha2.Year
                SQL = "SELECT * FROM FechaPlanilla WHERE (CodTipoNomina = '" & CodTipoNomina & "') AND (FechaIni = CONVERT(DATETIME, '" & FechaInicial & "', 102)) AND (FechaFin = CONVERT(DATETIME,'" & FechaFinal & "', 102))"
                DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                DataAdapter.Fill(DataSet, "FechaPlanilla")
                If DataSet.Tables("FechaPlanilla").Rows.Count = 0 Then
                    StrSqlUpdate = "INSERT INTO [FechaPlanilla] ([CodTipoNomina],[FechaIni],[FechaFin],[A�o],[TipoNomina]) " & _
                                   "VALUES('" & CodTipoNomina & "','" & Me.DTPFechaInicio.Value & "','" & Me.DTPFechaFin.Value & "'," & A�o & ",'" & Me.CmbTipoPlanilla.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                End If


                If FechaFin < Me.DTPFechaFin.Value Then
                    Do While FechaFin <= Me.DTPFechaFin.Value  'Hay que setear el a�o actual de planilla OJO
                        'Me.dtaSem.Recordset.FindFirst "[Mes] like '" & saMes(iCont) & "' AND [A�o] like " & Me.DtaA�o.Recordset("A�o") & ""
                        'iMes = 'Me.dtaSem.Recordset.Fields(2)
                        Fechas = "01/" & saMes(iCont) & "/" & Me.TxtA�o.Text
                        Numfecha2 = Fechas
                        iMes = SabadosMes(Numfecha2)
                        lstPlanilla.Items.Add("        " & saMes2(iCont))



                        Do While iMes >= iSem 'And iPeriodo <= 52

                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '///////////////////////////////////////GUARDAR PERIODO////////////////////////////////////////////////////////////
                            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            A�o = FechaFin.Year
                            Mes = FechaFin.Month
                            Periodo = iPeriodo
                            SQL = "SELECT  * FROM Periodos WHERE (Periodo = " & Periodo & ") AND (a�o = " & A�o & ") AND (mes = " & Mes & ") AND (TipoNomina = '" & Me.CmbTipoPlanilla.Text & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                            DataAdapter.Fill(DataSet, "Periodos")
                            If DataSet.Tables("Periodos").Rows.Count = 0 Then
                                If Periodo = 1 Then
                                    StrSqlUpdate = "INSERT INTO [Periodos] ([Periodo],[a�o],[mes],[TipoNomina],[Inicio],[Final],[Actual]) " & _
                                                   "VALUES(" & Periodo & " ," & A�o & "," & Mes & " ,'" & Me.CmbTipoPlanilla.Text & "','" & FechaIni & "','" & FechaFin & "',0)"
                                Else
                                    StrSqlUpdate = "INSERT INTO [Periodos] ([Periodo],[a�o],[mes],[TipoNomina],[Inicio],[Final]) " & _
                                                   "VALUES(" & Periodo & " ," & A�o & "," & Mes & " ,'" & Me.CmbTipoPlanilla.Text & "','" & FechaIni & "','" & FechaFin & "')"
                                End If
                                MiConexion.Open()
                                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                                iResultado = ComandoUpdate.ExecuteNonQuery
                                MiConexion.Close()
                            End If

                            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////////LO IMPRIMO EN LA LISTA//////////////////////////////
                            '////////////////////////////////////////////////////////////////////////////////////////////////////

                            lstPlanilla.Items.Add(" " & CStr(iPeriodo) & "   " & CStr(FechaIni) & "  al  " & CStr(FechaFin))

                            FechaIni = DateAdd(DateInterval.Day, 1, FechaFin)
                            FechaFin = DateAdd(DateInterval.Day, 6, FechaIni)

                            iSem = iSem + 1
                            iPeriodo = iPeriodo + 1
                            Lineas = Lineas + 1
                        Loop

                        iSem = 1
                        iCont = iCont + 1
                        lstPlanilla.Items.Add("      ")
                        If Lineas = 14 Then
                            lstPlanilla.Items.Add("      ")
                        End If
                    Loop

                Else
                    MsgBox("El intervalo de la fecha inicial y final no es v�lido", vbInformation, "corrija")
                End If


        End Select


        iPeriodo = 1
        iSem = 1
        iCont = 0
    End Sub
End Class