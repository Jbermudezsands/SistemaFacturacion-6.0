Public Class FrmExamen
    Public TipoExamen As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Numero_Expediente As String, id_Expediente As Double

    Public Sub Cargar_Combo()
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String

        DataSet.Reset()
        SqlProductos = "SELECT IdTipoExamen, TipoExamen FROM TipoExamen"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "TipoExamen")
        Me.CboTipoExamen.DataSource = DataSet.Tables("TipoExamen")
        'If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
        '    Me.CboTipoExamen.DataSource = DataSet.Tables("TipoExamen")
        'End If
        'Me.CboTipoExamen.Splits.Item(0).DisplayColumns(1).Width = 350
    End Sub

    Public Sub Cargar_Examen(ByVal Numero_Expediente As String, ByVal Id_Numero_Examen As Double, ByVal Fecha As Date)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim TotalCosto As Double, TotalFob As Double, TasaCambio As Double, Id_Tipo_Examen As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        Me.txtNumero_Expediente.Text = Numero_Expediente

        '///////////////////////////////DATOS DEL EXPEDIENTE
        SqlCompras = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If Not DataSet.Tables("Expediente").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
            Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
        End If

        '///////////////////////////////TIPO EXAMEN ////////////////////////////////////
        SqlCompras = "SELECT  IdTipoExamen, TipoExamen FROM TipoExamen WHERE (TipoExamen LIKE '% " & TipoExamen & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "TipoExamen")
        If Not DataSet.Tables("TipoExamen").Rows.Count = 0 Then
            Id_Tipo_Examen = DataSet.Tables("TipoExamen").Rows(0)("IdTipoExamen")
        End If


        'SqlCompras = "SELECT Examenes.* FROM(Examenes) WHERE (id_Numero_Examen = " & Id_Numero_Examen & ") AND (IdTipoExamen = " & Id_Tipo_Examen & ") AND (Numero_Expediente = '" & Numero_Expediente & "')"
        SqlCompras = "SELECT    * FROM Examenes INNER JOIN Expediente ON Examenes.Numero_Expediente = Expediente.Numero_Expediente INNER JOIN TipoExamen ON Examenes.IdTipoExamen = TipoExamen.IdTipoExamen  " &
                     "WHERE (Examenes.IdTipoExamen = " & Id_Numero_Examen & ") AND (Examenes.Numero_Expediente = '" & Numero_Expediente & "') AND (Examenes.Fecha_Examen = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Examen")
        If Not DataSet.Tables("Examen").Rows.Count = 0 Then

            Select Case TipoExamen
                Case "Examen Perfil Lipidico"
                    Me.txtTrigliceridos.Text = DataSet.Tables("Examen").Rows(0)("Trigliceridos")
                    Me.txtColesterol_Total.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_Total")
                    Me.txtColesterol_HDL.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_HDL")
                    Me.txtColesterol_LDL.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_LDL")
                    Me.txtRiesgo_Coronario.Text = DataSet.Tables("Examen").Rows(0)("Riesgo_Coronario")


                Case "Extamen Heces"
                    Me.TxtConsitencia.Text = DataSet.Tables("Examen").Rows(0)("Consistencia")
                    Me.txtColor.Text = DataSet.Tables("Examen").Rows(0)("Color")
                    Me.txtMucos.Text = DataSet.Tables("Examen").Rows(0)("Mucos")
                    Me.txtOlor.Text = DataSet.Tables("Examen").Rows(0)("Olor")
                    Me.txtObservaciones.Text = DataSet.Tables("Examen").Rows(0)("Observaciones")
                    Me.txtAncylostomaHuevos.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaHuevos")
                    Me.txtAncylostomaAdultos.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaAdultos")
                    Me.txtAncylostomaLarvas.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaLarvas")
                    Me.txtAscarisHuevos.Text = DataSet.Tables("Examen").Rows(0)("AscarisHuevos")
                    Me.AscarisAdultos.Text = DataSet.Tables("Examen").Rows(0)("AscarisAdultos")
                    Me.txtAscarisLarvas.Text = DataSet.Tables("Examen").Rows(0)("AscarisLarvas")
                    Me.txtTrichurisHuevos.Text = DataSet.Tables("Examen").Rows(0)("TrichurisHuevos")
                    Me.txtTrichurisAdultos.Text = DataSet.Tables("Examen").Rows(0)("TrichurisAdultos")
                    Me.txtTrichurisLarva.Text = DataSet.Tables("Examen").Rows(0)("TrichurisLarva")
                    Me.txtStrongyloidesHuevos.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesHuevos")
                    Me.txtStrongyloidesAdultos.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesAdultos")
                    Me.txtStrongyloidesLarva.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesLarva")
                    Me.txtEnterobiosHuevos.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosHuevos")
                    Me.txtEnterobiosAdultos.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosAdultos")
                    Me.txtEnterobiosLarva.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosLarva")
                    Me.txtStrongyloidesHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaHuevos")
                    Me.txtStrongyloidesAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaAdultos")
                    Me.txtStrongyloidesLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaLarva")
                    Me.txtHymenolepsisnanaHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaHuevos")
                    Me.txtHymenolepsisnanaAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaAdultos")
                    Me.HymenolepsisnanaLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaLarva")
                    Me.txtHymenolepsisdiminutaHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaHuevos")
                    Me.txtHymenolepsisdiminutaAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaAdultos")
                    Me.txtHymenolepsisdiminutaLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaLarva")
                    Me.txtTaeniaHuevos.Text = DataSet.Tables("Examen").Rows(0)("TaeniaHuevos")
                    Me.txtTaeniaAdultos.Text = DataSet.Tables("Examen").Rows(0)("TaeniaAdultos")
                    Me.txtTaeniaLarva.Text = DataSet.Tables("Examen").Rows(0)("TaeniaLarva")
                    Me.txtUncinariasHuevos.Text = DataSet.Tables("Examen").Rows(0)("UncinariasHuevos")
                    Me.txtUncinariasAdultos.Text = DataSet.Tables("Examen").Rows(0)("UncinariasAdultos")
                    Me.txtUncinariasLarva.Text = DataSet.Tables("Examen").Rows(0)("UncinariasLarva")
                    Me.txtEntamoebaTrofo.Text = DataSet.Tables("Examen").Rows(0)("EntamoebaTrofo")
                    Me.txtEntamoebaQuistes.Text = DataSet.Tables("Examen").Rows(0)("EntamoebaQuistes")
                    Me.txtEndolimaxTrofo.Text = DataSet.Tables("Examen").Rows(0)("EndolimaxTrofo")
                    Me.txtEndolimaxQuistes.Text = DataSet.Tables("Examen").Rows(0)("EndolimaxQuistes")
                    Me.txtLodamoebaTrofo.Text = DataSet.Tables("Examen").Rows(0)("LodamoebaTrofo")
                    Me.txtLodamoebaQuistes.Text = DataSet.Tables("Examen").Rows(0)("LodamoebaQuistes")
                    Me.txtGiardiaTrofo.Text = DataSet.Tables("Examen").Rows(0)("GiardiaTrofo")
                    Me.txtGiardiaQuistes.Text = DataSet.Tables("Examen").Rows(0)("GiardiaQuistes")
                    Me.txtTrinchomonasTrofo.Text = DataSet.Tables("Examen").Rows(0)("TrinchomonasTrofo")
                    Me.txtTrinchomonasQuistes.Text = DataSet.Tables("Examen").Rows(0)("TrinchomonasQuistes")
                    Me.txtChilomastixTrofo.Text = DataSet.Tables("Examen").Rows(0)("ChilomastixTrofo")
                    Me.txtChilomastixQuistes.Text = DataSet.Tables("Examen").Rows(0)("ChilomastixQuistes")
                    Me.txtBalantidiumTrofo.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumTrofo")
                    Me.txtBalantidiumQuistes.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumQuistes")
                    Me.txtBalantidiumTrofo.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumTrofo")
                    Me.txtBalantidiumQuistes.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumQuistes")

                Case "Examen Biometria Hematica"
                    Me.txtHbA1c.Text = DataSet.Tables("Examen").Rows(0)("Eritrocitos")
                    Me.txtLeucocitos.Text = DataSet.Tables("Examen").Rows(0)("Leucocitos")
                    Me.txtPlaquetas.Text = DataSet.Tables("Examen").Rows(0)("Plaquetas")
                    Me.txtReticulocitos.Text = DataSet.Tables("Examen").Rows(0)("Reticulocitos")

                    Me.txtSedimentacion.Text = DataSet.Tables("Examen").Rows(0)("Sedimentacion")
                    Me.txtCoagulacion.Text = DataSet.Tables("Examen").Rows(0)("Coagulacion")
                    Me.txtSangria.Text = DataSet.Tables("Examen").Rows(0)("Sangria")
                    Me.txtProtombina.Text = DataSet.Tables("Examen").Rows(0)("Protombina")

                    Me.txtTromboplast.Text = DataSet.Tables("Examen").Rows(0)("Tromboplast")
                    Me.txtRetracCoagulo.Text = DataSet.Tables("Examen").Rows(0)("RetracCoagulo")
                    Me.txtHemoglobina.Text = DataSet.Tables("Examen").Rows(0)("Hemoglobina")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hematocrito")

                    Me.txtVol_Corp_Med.Text = DataSet.Tables("Examen").Rows(0)("Vol_Corp_Med")
                    Me.txtHp_Corp_Med.Text = DataSet.Tables("Examen").Rows(0)("Hp_Corp_Med")
                    Me.txtInv_Hematozoaria.Text = DataSet.Tables("Examen").Rows(0)("Inv_Hematozoaria")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hematocrito")
                    Me.txtCaracteres_Celulares.Text = DataSet.Tables("Examen").Rows(0)("Caracteres_Celulares")

                Case "Examen Hemoglobina"
                    Me.txtHbA1c.Text = DataSet.Tables("Examen").Rows(0)("HbA1c")

                Case "Examen Quimica Sanguinea"
                    Me.txtGlucosa.Text = DataSet.Tables("Examen").Rows(0)("Glucosa")
                    Me.txtColesterol_Total.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_Total")
                    Me.txtTrigliceridos.Text = DataSet.Tables("Examen").Rows(0)("Trigliceridos")
                    Me.txtCreatinina.Text = DataSet.Tables("Examen").Rows(0)("Creatinina")

                    Me.txtTGO.Text = DataSet.Tables("Examen").Rows(0)("TGO")
                    Me.txtTGP.Text = DataSet.Tables("Examen").Rows(0)("TGP")
                    Me.txtBilirrubina.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaTotal")
                    Me.txtBilirrubinaDirecto.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaDirecto")
                    Me.txtBilirrubinaIndirecto.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaIndirecto")

                    Me.txtAmilasa.Text = DataSet.Tables("Examen").Rows(0)("Amilasa")
                    Me.txtAlbuminas.Text = DataSet.Tables("Examen").Rows(0)("Albuminas")
                    Me.txtProteinas_Totales.Text = DataSet.Tables("Examen").Rows(0)("Proteinas_Totales")
                    Me.txtAslo.Text = DataSet.Tables("Examen").Rows(0)("ASLO")
                    Me.txtFR.Text = DataSet.Tables("Examen").Rows(0)("FR")

                    Me.txtPCR.Text = DataSet.Tables("Examen").Rows(0)("PCR")
                    Me.txtVRDL.Text = DataSet.Tables("Examen").Rows(0)("VRDL")
                    Me.txtAcidoUrico.Text = DataSet.Tables("Examen").Rows(0)("AcidoUrico")
                    Me.txtFost_Alkalina.Text = DataSet.Tables("Examen").Rows(0)("Fost_Alkalina")

                Case "Examen Orina"
                    Me.txtColor2.Text = DataSet.Tables("Examen").Rows(0)("Color")
                    Me.txtSedimento.Text = DataSet.Tables("Examen").Rows(0)("Sedimento")
                    Me.txtDensidad.Text = DataSet.Tables("Examen").Rows(0)("Desidad")
                    Me.txtProteinas.Text = DataSet.Tables("Examen").Rows(0)("Proteinas")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hemoglobina")

                    Me.txtCetonicos.Text = DataSet.Tables("Examen").Rows(0)("Cetonicos")
                    Me.txtPH.Text = DataSet.Tables("Examen").Rows(0)("PH")
                    Me.txtUrobilinogeno.Text = DataSet.Tables("Examen").Rows(0)("Urobilinogeno")
                    Me.txtGlucosa2.Text = DataSet.Tables("Examen").Rows(0)("Bilirrubina")
                    Me.txtNitritos.Text = DataSet.Tables("Examen").Rows(0)("Nitritos")

                    Me.txtEpiteliales.Text = DataSet.Tables("Examen").Rows(0)("Epiteliales")
                    Me.txtLeucocitos.Text = DataSet.Tables("Examen").Rows(0)("Leucocitos")
                    Me.txtEritrocitos3.Text = DataSet.Tables("Examen").Rows(0)("Eritrocitos")
                    Me.txtCilindros.Text = DataSet.Tables("Examen").Rows(0)("Cilindros")
                    Me.txtCristales.Text = DataSet.Tables("Examen").Rows(0)("Cristales")
                    Me.txtHilos_Mucosos.Text = DataSet.Tables("Examen").Rows(0)("Hilos_Mucosos")
                    Me.txtCualitativo.Text = DataSet.Tables("Examen").Rows(0)("Cualitativo")
                    Me.txtCuantitativo.Text = DataSet.Tables("Examen").Rows(0)("Cuantitativo")

                Case "Examen Electrolitos Sericos"
                    Me.txtSodio.Text = DataSet.Tables("Examen").Rows(0)("Sodio")
                    Me.txtPotasio.Text = DataSet.Tables("Examen").Rows(0)("Potasio")
                    Me.txtCloro.Text = DataSet.Tables("Examen").Rows(0)("Cloro")
                    Me.txtCalcio.Text = DataSet.Tables("Examen").Rows(0)("Calcio")
                    Me.txtMagnesio.Text = DataSet.Tables("Examen").Rows(0)("Mangesio")
                    Me.txtFosforo.Text = DataSet.Tables("Examen").Rows(0)("Fosforo")

                Case "Examen Perfil Renal"
                    Me.txtCreatinina2.Text = DataSet.Tables("Examen").Rows(0)("Creatinina")
                    Me.txtAcidoUrico2.Text = DataSet.Tables("Examen").Rows(0)("AcidoUrico")
                    Me.txtUrea.Text = DataSet.Tables("Examen").Rows(0)("Urea")
                    Me.txtBUN.Text = DataSet.Tables("Examen").Rows(0)("BUN")
                    Me.txtProteinas_Totales.Text = DataSet.Tables("Examen").Rows(0)("Proteinas_Totales")
                    Me.txtGlobulina.Text = DataSet.Tables("Examen").Rows(0)("Glubolina")


            End Select

        End If




    End Sub
    Public Sub InsertarActualizarExamen(ByVal Id_Tipo_Examen As Double, ByVal Numero_Expediente As String, ByVal Id_Numero_Examen As Double, ByVal Fecha As Date)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        SqlCompras = "SELECT Examenes.* FROM(Examenes) WHERE (id_Numero_Examen = " & Id_Numero_Examen & ") AND (IdTipoExamen = " & Id_Tipo_Examen & ") AND (Numero_Expediente = '" & Numero_Expediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Examen")
        If DataSet.Tables("Examen").Rows.Count = 0 Then
            SqlString = "INSERT INTO [Examenes] ([IdTipoExamen],[Numero_Expediente],[Fecha_Examen],[Consistencia],[Color],[Mucos],[Observaciones],[AncylostomaHuevos],[AncylostomaAdultos],[AncylostomaLarvas],[AscarisHuevos],[AscarisAdultos],[AscarisLarvas],[TrichurisHuevos],[TrichurisAdultos],[TrichurisLarva],[StrongyloidesHuevos],[StrongyloidesAdultos],[StrongyloidesLarva],[EnterobiosHuevos],[EnterobiosAdultos],[EnterobiosLarva],[HymenolepsisnanaHuevos],[HymenolepsisnanaAdultos],[HymenolepsisnanaLarva],[HymenolepsisdiminutaHuevos],[HymenolepsisdiminutaAdultos],[HymenolepsisdiminutaLarva],[TaeniaHuevos],[TaeniaAdultos],[TaeniaLarva],[UncinariasHuevos],[UncinariasAdultos],[UncinariasLarva],[EntamoebaTrofo],[EntamoebaQuistes],[EntamoebaColiTrofo],[EntamoebaColiQuistes],[EndolimaxTrofo],[EndolimaxQuistes],[LodamoebaTrofo],[LodamoebaQuistes],[GiardiaTrofo] ,[GiardiaQuistes],[TrinchomonasTrofo],[TrinchomonasQuistes],[ChilomastixTrofo],[ChilomastixQuistes],[BalantidiumTrofo],[BalantidiumQuistes],[Trigliceridos],[Colesterol_Total],[Colesterol_HDL],[Colesterol_LDL],[Riesgo_Coronario],[Eritrocitos],[Leucocitos],[Plaquetas],[Reticulocitos],[Sedimentacion],[Coagulacion],[Sangria],[Protombina],[Tromboplast],[RetracCoagulo],[Hemoglobina],[Hematocrito],[Caracteres_Celulares],[Vol_Corp_Med],[Hp_Corp_Med],[Inv_Hematozoaria],[HbA1c],[Creatinina],[Aspecto],[TGO],[TGP],[BilirrubinaTotal],[BilirrubinaDirecto],[BilirrubinaIndirecto],[Amilasa],[Albuminas],[ASLO],[FR],[PCR],[VRDL],[AcidoUrico],[Fost_Alkalina],[Sedimento],[Desidad],[Cualitativo],[Cuantitativo],[Proteinas],[Cetonicos],[PH],[Urobilinogeno],[Glucosa],[Bilirrubina],[Nitritos],[Epiteliales],[Cilindros],[Cristales],[Bacterias],[Hilos_Mucosos],[Embarzo_Cualitativo],[Embarazo_Cuantitativo],[Sodio],[Potasio],[Cloro],[Calcio],[Mangesio],[Fosforo],[Urea],[BUN] ,[Proteinas_Totales],[Glubolina]) " & _
                  "VALUES (" & Id_Tipo_Examen & ",'" & Numero_Expediente & "','" & Fecha & "','" & Me.TxtConsitencia.Text & "','" & Me.txtColor.Text & "' ,'" & Me.txtMucos.Text & "','" & Me.txtObservaciones.Text & "'," & Me.txtAncylostomaHuevos.Text & "," & Me.txtAncylostomaAdultos.Text & "," & Me.txtAncylostomaLarvas.Text & "," & Me.txtAscarisHuevos.Text & "," & Me.txtAscarisLarvas.Text & "," & Me.AscarisAdultos.Text & "," & Me.txtTrichurisHuevos.Text & "," & Me.txtTrichurisAdultos.Text & " ," & Me.txtTrichurisLarva.Text & " ," & Me.txtStrongyloidesHuevos.Text & "," & Me.txtStrongyloidesAdultos.Text & "," & Me.txtStrongyloidesLarva.Text & "," & Me.txtEnterobiosHuevos.Text & ", " & Me.txtEnterobiosAdultos.Text & ", " & Me.txtEnterobiosLarva.Text & " , " & Me.txtHymenolepsisnanaHuevos.Text & " , " & Me.txtHymenolepsisnanaAdultos.Text & " ," & Me.HymenolepsisnanaLarva.Text & "," & Me.txtHymenolepsisdiminutaHuevos.Text & "," & Me.txtHymenolepsisdiminutaAdultos.Text & " ," & Me.txtHymenolepsisdiminutaLarva.Text & " ," & Me.txtTaeniaHuevos.Text & " ," & Me.txtTaeniaAdultos.Text & " ," & Me.txtTaeniaLarva.Text & " , " & Me.txtUncinariasHuevos.Text & " ," & Me.txtUncinariasAdultos.Text & " , " & Me.txtUncinariasLarva.Text & " ," & Me.txtEntamoebaTrofo.Text & ", " & Me.txtEntamoebaQuistes.Text & " ," & Me.txtEntamoebaColiTrofo.Text & " ," & Me.txtEntamoebaColiQuistes.Text & " ," & Me.txtEndolimaxTrofo.Text & " , " & Me.txtEndolimaxQuistes.Text & " , " & Me.txtLodamoebaTrofo.Text & ",  " & Me.txtLodamoebaQuistes.Text & " , " & Me.txtGiardiaTrofo.Text & " , " & Me.txtGiardiaQuistes.Text & ", " & Me.txtTrinchomonasTrofo.Text & " ,  " & Me.txtTrinchomonasQuistes.Text & " , " & Me.txtChilomastixTrofo.Text & " ," & Me.txtChilomastixQuistes.Text & " ," & Me.txtBalantidiumTrofo.Text & " ," & Me.txtBalantidiumQuistes.Text & " ," & Me.txtTrigliceridos.Text & " ," & Me.txtColesterol_Total.Text & " , " & Me.txtColesterol_HDL.Text & " ," & Me.txtColesterol_LDL.Text & " , " & Me.txtEritrocitos2.Text & " , " & Me.txtLeucocitos.Text & " , " & Me.txtPlaquetas.Text & "  , " & Me.txtReticulocitos.Text & " ," & Me.txtSedimentacion.Text & " ," & Me.txtCoagulacion.Text & " , " & Me.txtSangria.Text & " ," & Me.txtProtombina.Text & " ," & Me.txtTromboplast.Text & " , " & Me.txtRetracCoagulo.Text & " ," & Me.txtHemoglobina.Text & " ," & Me.txtHematocrito.Text & " ," & Me.txtCaracteres_Celulares.Text & " ," & Me.txtVol_Corp_Med.Text & " , " & Me.txtHp_Corp_Med.Text & " , " & Me.txtInv_Hematozoaria.Text & " , " & Me.txtHbA1c.Text & " ," & Me.txtCreatinina.Text & ", " & Me.txtAspecto.Text & " , " & Me.txtTGO.Text & " , " & Me.txtTGP.Text & " , " & Me.txtBilirrubina.Text & " ," & Me.txtBilirrubinaDirecto.Text & " ," & Me.txtBilirrubinaIndirecto.Text & " , " & Me.txtAmilasa.Text & " , " & Me.txtAlbuminas.Text & " , " & Me.txtAslo.Text & " , " & Me.txtFR.Text & " ," & Me.txtPCR.Text & ", " & Me.txtVRDL.Text & " , " & Me.txtAcidoUrico.Text & " ," & Me.txtFost_Alkalina.Text & " ," & Me.txtSedimento.Text & " , " & Me.txtDensidad.Text & " ," & Me.txtCualitativo.Text & " , " & Me.txtCuantitativo.Text & " ," & Me.txtProteinas2.Text & " ," & Me.txtCetonicos.Text & " ," & Me.txtPH.Text & " ," & Me.txtUrobilinogeno.Text & " ," & Me.txtGlucosa2.Text & " ," & Me.txtBilirrubina2.Text & " ," & Me.txtNitritos.Text & " ," & Me.txtEpiteliales.Text & "," & Me.txtCilindros.Text & " ," & Me.txtCristales.Text & " ," & Me.txtCristales.Text & " ," & Me.txtHilos_Mucosos.Text & " ," & Me.txtCualitativo.Text & "," & Me.txtCuantitativo.Text & " ," & Me.txtSodio.Text & " ," & Me.txtPotasio.Text & "," & Me.txtCloro.Text & " ," & Me.txtCalcio.Text & " , " & Me.txtMagnesio.Text & " ," & Me.txtFosforo.Text & " , " & Me.txtUrea.Text & " ," & Me.txtBUN.Text & " ," & Me.txtProteinas_Totales.Text & " ," & Me.txtGlobulina.Text & ")"

        Else

            SqlString = "UPDATE [Examenes]  SET [IdTipoExamen] = " & Id_Tipo_Examen & " ,[Numero_Expediente] = '" & Numero_Expediente & "' ,[Fecha_Examen] = '" & Fecha & "' ,[Consistencia] = '" & Me.TxtConsitencia.Text & "' ,[Color] = '" & Me.txtColor.Text & "' ,[Mucos] = '" & Me.txtMucos.Text & "' ,[Observaciones] = '" & Me.txtObservaciones.Text & "' ,[AncylostomaHuevos] = " & Me.txtAncylostomaHuevos.Text & " ,[AncylostomaAdultos] = " & Me.txtAncylostomaAdultos.Text & " ,[AncylostomaLarvas] = " & Me.txtAncylostomaLarvas.Text & "  ,[AscarisHuevos] = " & Me.txtAscarisHuevos.Text & " ,[AscarisAdultos] = " & Me.AscarisAdultos.Text & " ,[AscarisLarvas] = " & Me.txtAscarisLarvas.Text & " ,[TrichurisHuevos] = " & Me.txtTrichurisHuevos.Text & " ,[TrichurisAdultos] = " & Me.txtTrichurisAdultos.Text & "  ,[TrichurisLarva] = " & Me.txtTrichurisLarva.Text & " ,[StrongyloidesHuevos] = " & Me.txtStrongyloidesHuevos.Text & " ,[StrongyloidesAdultos] = " & Me.txtStrongyloidesAdultos.Text & " ,[StrongyloidesLarva] = " & Me.txtStrongyloidesLarva.Text & " ,[EnterobiosHuevos] = " & Me.txtEnterobiosHuevos.Text & "  ,[EnterobiosAdultos] =  " & Me.txtEnterobiosAdultos.Text & " ,[EnterobiosLarva] = " & Me.txtEnterobiosLarva.Text & " ,[HymenolepsisnanaHuevos] = " & Me.txtHymenolepsisnanaHuevos.Text & " ,[HymenolepsisnanaAdultos] = " & Me.txtHymenolepsisnanaAdultos.Text & " ,[HymenolepsisnanaLarva] = " & Me.HymenolepsisnanaLarva.Text & " ,[HymenolepsisdiminutaHuevos] = " & Me.txtHymenolepsisdiminutaHuevos.Text & " ,[HymenolepsisdiminutaAdultos] = " & Me.txtHymenolepsisdiminutaAdultos.Text & " ,[HymenolepsisdiminutaLarva] = " & Me.txtHymenolepsisdiminutaLarva.Text & " ,[TaeniaHuevos] = " & Me.txtTaeniaHuevos.Text & " ,[TaeniaAdultos] = " & Me.txtTaeniaAdultos.Text & " ,[TaeniaLarva] = " & Me.txtTaeniaLarva.Text & " ,[UncinariasHuevos] = " & Me.txtUncinariasHuevos.Text & " ,[UncinariasAdultos] = " & Me.txtUncinariasAdultos.Text & " ,[UncinariasLarva] = " & Me.txtUncinariasLarva.Text & " ,[EntamoebaTrofo] = " & Me.txtEntamoebaTrofo.Text & " ,[EntamoebaQuistes] = " & Me.txtEntamoebaQuistes.Text & "  ,[EntamoebaColiTrofo] = " & Me.txtEntamoebaColiTrofo.Text & " ,[EntamoebaColiQuistes] = " & Me.txtEntamoebaColiQuistes.Text & ",[EndolimaxTrofo] = " & Me.txtEndolimaxTrofo.Text & ",[EndolimaxQuistes] = " & Me.txtEndolimaxQuistes.Text & ",[LodamoebaTrofo] = " & Me.txtLodamoebaTrofo.Text & " ,[LodamoebaQuistes] = " & Me.txtLodamoebaQuistes.Text & ",[GiardiaTrofo] = " & Me.txtGiardiaTrofo.Text & " ,[GiardiaQuistes] = " & Me.txtGiardiaQuistes.Text & " ,[TrinchomonasTrofo] = " & Me.txtTrinchomonasTrofo.Text & " ,[TrinchomonasQuistes] = " & Me.txtTrinchomonasQuistes.Text & " ,[ChilomastixTrofo] = " & Me.txtChilomastixTrofo.Text & " ,[ChilomastixQuistes] = " & Me.txtChilomastixQuistes.Text & " ,[BalantidiumTrofo] = " & Me.txtBalantidiumTrofo.Text & " ,[BalantidiumQuistes] = " & Me.txtBalantidiumQuistes.Text & " ,[Trigliceridos] = " & Me.txtTrigliceridos.Text & " ,[Colesterol_Total] = " & Me.txtColesterol_Total.Text & " ,[Colesterol_HDL] = " & Me.txtColesterol_HDL.Text & " ,[Colesterol_LDL] = " & Me.txtColesterol_LDL.Text & " ,[Riesgo_Coronario] = " & Me.txtRiesgo_Coronario.Text & " ,[Eritrocitos] = " & Me.txtEritrocitos2.Text & " ,[Leucocitos] = " & Me.txtLeucocitos.Text & ",[Plaquetas] = " & Me.txtPlaquetas.Text & " ,[Reticulocitos] = " & Me.txtReticulocitos.Text & ",[Sedimentacion] = " & Me.txtSedimentacion.Text & " ,[Coagulacion] = " & Me.txtCoagulacion.Text & ",[Sangria] = " & Me.txtSangria.Text & " ,[Protombina] = " & Me.txtProtombina.Text & " ,[Tromboplast] = " & Me.txtTromboplast.Text & " ,[RetracCoagulo] = " & Me.txtRetracCoagulo.Text & " ,[Hemoglobina] = " & Me.txtHemoglobina.Text & " ,[Hematocrito] = " & Me.txtHematocrito.Text & " ,[Caracteres_Celulares] = " & Me.txtCaracteres_Celulares.Text & " ,[Vol_Corp_Med] = " & Me.txtVol_Corp_Med.Text & " ,[Hp_Corp_Med] = " & Me.txtHp_Corp_Med.Text & " ,[Inv_Hematozoaria] = " & Me.txtInv_Hematozoaria.Text & " ,[HbA1c] = " & Me.txtHbA1c.Text & " ,[Creatinina] = " & Me.txtCreatinina.Text & " ,[Aspecto] = " & Me.txtAspecto.Text & " ,[TGO] = " & Me.txtTGO.Text & " ,[TGP] = " & Me.txtTGP.Text & " ,[BilirrubinaTotal] = " & Me.txtBilirrubina.Text & " ,[BilirrubinaDirecto] = " & Me.txtBilirrubinaDirecto.Text & " ,[BilirrubinaIndirecto] = " & Me.txtBilirrubinaIndirecto.Text & " ,[Amilasa] = " & Me.txtAmilasa.Text & " ,[Albuminas] = " & Me.txtAlbuminas.Text & ",[ASLO] = " & Me.txtAslo.Text & ",[FR] = " & Me.txtFR.Text & ",[PCR] = " & Me.txtPCR.Text & " ,[VRDL] = " & Me.txtVRDL.Text & " ,[AcidoUrico] = " & Me.txtAcidoUrico.Text & " ,[Fost_Alkalina] = " & Me.txtFost_Alkalina.Text & " ,[Sedimento] = " & Me.txtSedimento.Text & ",[Desidad] = " & Me.txtDensidad.Text & " ,[Cualitativo] = " & Me.txtCualitativo.Text & " ,[Cuantitativo] = " & Me.txtCuantitativo.Text & " ,[Proteinas] = " & Me.txtProteinas.Text & " ,[Cetonicos] = " & Me.txtCetonicos.Text & " ,[PH] = " & Me.txtPH.Text & " ,[Urobilinogeno] = " & Me.txtUrobilinogeno.Text & " ,[Glucosa] = " & Me.txtGlucosa.Text & " ,[Bilirrubina] = " & Me.txtBilirrubina.Text & " ,[Nitritos] = " & Me.txtNitritos.Text & " ,[Epiteliales] = " & Me.txtEpiteliales.Text & " ,[Cilindros] = " & Me.txtCilindros.Text & ",[Cristales] = " & Me.txtCristales.Text & " ,[Bacterias] = " & Me.txtBacterias.Text & " ,[Hilos_Mucosos] = " & Me.txtHilos_Mucosos.Text & "  ,[Embarzo_Cualitativo] = " & Me.txtCualitativo.Text & " ,[Embarazo_Cuantitativo] = " & Me.txtCuantitativo.Text & " ,[Sodio] = " & Me.txtSodio.Text & " ,[Potasio] = " & Me.txtPotasio.Text & " ,[Cloro] = " & Me.txtCloro.Text & ",[Calcio] = " & Me.txtCalcio.Text & ",[Mangesio] = " & Me.txtMagnesio.Text & " ,[Fosforo] = " & Me.txtFosforo.Text & " ,[Urea] = " & Me.txtUrea.Text & " ,[BUN] = " & Me.txtBUN.Text & " ,[Proteinas_Totales] = " & Me.txtProteinas_Totales.Text & " ,[Glubolina] = " & Me.txtGlobulina.Text & "  " & _
                        "WHERE (id_Numero_Examen = " & Id_Numero_Examen & ") AND (IdTipoExamen = " & Id_Tipo_Examen & ") AND (Numero_Expediente = '" & Numero_Expediente & "')"

        End If

 

    End Sub
    Public Sub LimpiarCampos()


        Me.txtTrigliceridos.Text = ""
        Me.txtColesterol_Total.Text = ""
        Me.txtColesterol_HDL.Text = ""
        Me.txtColesterol_LDL.Text = ""
        Me.txtRiesgo_Coronario.Text = ""
        Me.TxtConsitencia.Text = ""
        Me.txtColor.Text = ""
        Me.txtMucos.Text = ""
        Me.txtOlor.Text = ""
        Me.txtObservaciones.Text = ""
        Me.txtAncylostomaHuevos.Text = ""
        Me.txtAncylostomaAdultos.Text = ""
        Me.txtAncylostomaLarvas.Text = ""
        Me.txtAscarisHuevos.Text = ""
        Me.AscarisAdultos.Text = ""
        Me.txtAscarisLarvas.Text = ""
        Me.txtTrichurisHuevos.Text = ""
        Me.txtTrichurisAdultos.Text = ""
        Me.txtTrichurisLarva.Text = ""
        Me.txtStrongyloidesHuevos.Text = ""
        Me.txtStrongyloidesAdultos.Text = ""
        Me.txtStrongyloidesLarva.Text = ""
        Me.txtEnterobiosHuevos.Text = ""
        Me.txtEnterobiosAdultos.Text = ""
        Me.txtEnterobiosLarva.Text = ""
        Me.txtStrongyloidesHuevos.Text = ""
        Me.txtStrongyloidesAdultos.Text = ""
        Me.txtStrongyloidesLarva.Text = ""
        Me.txtHymenolepsisnanaHuevos.Text = ""
        Me.txtHymenolepsisnanaAdultos.Text = ""
        Me.HymenolepsisnanaLarva.Text = ""
        Me.txtHymenolepsisdiminutaHuevos.Text = ""
        Me.txtHymenolepsisdiminutaAdultos.Text = ""
        Me.txtHymenolepsisdiminutaLarva.Text = ""
        Me.txtTaeniaHuevos.Text = ""
        Me.txtTaeniaAdultos.Text = ""
        Me.txtTaeniaLarva.Text = ""
        Me.txtUncinariasHuevos.Text = ""
        Me.txtUncinariasAdultos.Text = ""
        Me.txtUncinariasLarva.Text = ""
        Me.txtEntamoebaTrofo.Text = ""
        Me.txtEntamoebaQuistes.Text = ""
        Me.txtEndolimaxTrofo.Text = ""
        Me.txtEndolimaxQuistes.Text = ""
        Me.txtLodamoebaTrofo.Text = ""
        Me.txtLodamoebaQuistes.Text = ""
        Me.txtGiardiaTrofo.Text = ""
        Me.txtGiardiaQuistes.Text = ""
        Me.txtTrinchomonasTrofo.Text = ""
        Me.txtTrinchomonasQuistes.Text = ""
        Me.txtChilomastixTrofo.Text = ""
        Me.txtChilomastixQuistes.Text = ""
        Me.txtBalantidiumTrofo.Text = ""
        Me.txtBalantidiumQuistes.Text = ""
        Me.txtBalantidiumTrofo.Text = ""
        Me.txtBalantidiumQuistes.Text = ""
        Me.txtHbA1c.Text = ""
        Me.txtLeucocitos.Text = ""
        Me.txtPlaquetas.Text = ""
        Me.txtReticulocitos.Text = ""

        Me.txtSedimentacion.Text = ""
        Me.txtCoagulacion.Text = ""
        Me.txtSangria.Text = ""
        Me.txtProtombina.Text = ""

        Me.txtTromboplast.Text = ""
        Me.txtRetracCoagulo.Text = ""
        Me.txtHemoglobina.Text = ""
        Me.txtHematocrito.Text = ""

        Me.txtVol_Corp_Med.Text = ""
        Me.txtHp_Corp_Med.Text = ""
        Me.txtInv_Hematozoaria.Text = ""
        Me.txtHematocrito.Text = ""
        Me.txtCaracteres_Celulares.Text = ""

        Me.txtHbA1c.Text = ""


        Me.txtGlucosa.Text = ""
        Me.txtColesterol_Total.Text = ""
        Me.txtTrigliceridos.Text = ""
        Me.txtCreatinina.Text = ""

        Me.txtTGO.Text = ""
        Me.txtTGP.Text = ""
        Me.txtBilirrubina.Text = ""
        Me.txtBilirrubinaDirecto.Text = ""
        Me.txtBilirrubinaIndirecto.Text = ""

        Me.txtAmilasa.Text = ""
        Me.txtAlbuminas.Text = ""
        Me.txtProteinas_Totales.Text = ""
        Me.txtAslo.Text = ""
        Me.txtFR.Text = ""

        Me.txtPCR.Text = ""
        Me.txtVRDL.Text = ""
        Me.txtAcidoUrico.Text = ""
        Me.txtFost_Alkalina.Text = ""

        Me.txtColor2.Text = ""
        Me.txtSedimento.Text = ""
        Me.txtDensidad.Text = ""
        Me.txtProteinas.Text = ""
        Me.txtHematocrito.Text = ""

        Me.txtCetonicos.Text = ""
        Me.txtPH.Text = ""
        Me.txtUrobilinogeno.Text = ""
        Me.txtGlucosa2.Text = ""
        Me.txtNitritos.Text = ""

        Me.txtEpiteliales.Text = ""
        Me.txtLeucocitos.Text = ""
        Me.txtCilindros.Text = ""
        Me.txtCristales.Text = ""
        Me.txtHilos_Mucosos.Text = ""
        Me.txtCualitativo.Text = ""
        Me.txtCuantitativo.Text = ""


        Me.txtSodio.Text = ""
        Me.txtPotasio.Text = ""
        Me.txtCloro.Text = ""
        Me.txtCalcio.Text = ""
        Me.txtMagnesio.Text = ""
        Me.txtFosforo.Text = ""

        Me.txtCreatinina2.Text = ""
        Me.txtAcidoUrico2.Text = ""
        Me.txtUrea.Text = ""
        Me.txtBUN.Text = ""
        Me.txtProteinas_Totales.Text = ""
        Me.txtGlobulina.Text = ""

    End Sub



    Public Sub BloquearCampos(ByVal TipoExamen As String)
        Dim ActivoPerfil As Boolean, ActivoHeces As Boolean, ActivarBiometriaHematica As Boolean, ActivarHemoglobina As Boolean
        Dim ActivarQuimica As Boolean, ActivarOrina As Boolean, ActivarElectrolitos As Boolean, ActivarPerfilRenal As Boolean

        Select Case TipoExamen
            Case "Examen Perfil Lipidico"
                ActivoPerfil = True
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage2

            Case "Extamen Heces"
                ActivoPerfil = False
                ActivoHeces = True
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage1

            Case "Examen Biometria Hematica"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = True
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage2

            Case "Examen Hemoglobina"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = True
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage2

            Case "Examen Quimica Sanguinea"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = True
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage2

            Case "Examen Orina"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = True
                ActivarElectrolitos = False
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage3

            Case "Examen Electrolitos Sericos"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = True
                ActivarPerfilRenal = False
                Me.TabControlHeces.SelectedTab = TabPage4

            Case "Examen Perfil Renal"
                ActivoPerfil = False
                ActivoHeces = False
                ActivarBiometriaHematica = False
                ActivarHemoglobina = False
                ActivarQuimica = False
                ActivarOrina = False
                ActivarElectrolitos = False
                ActivarPerfilRenal = True
                Me.TabControlHeces.SelectedTab = TabPage4

        End Select

        Me.txtTrigliceridos.Enabled = ActivoPerfil
        Me.txtColesterol_Total.Enabled = ActivoPerfil
        Me.txtColesterol_HDL.Enabled = ActivoPerfil
        Me.txtColesterol_LDL.Enabled = ActivoPerfil
        Me.txtRiesgo_Coronario.Enabled = ActivoPerfil


        Me.TxtConsitencia.Enabled = ActivoHeces
        Me.txtColor.Enabled = ActivoHeces
        Me.txtMucos.Enabled = ActivoHeces
        Me.txtOlor.Enabled = ActivoHeces
        Me.txtObservaciones.Enabled = ActivoHeces
        Me.txtAncylostomaHuevos.Enabled = ActivoHeces
        Me.txtAncylostomaAdultos.Enabled = ActivoHeces
        Me.txtAncylostomaLarvas.Enabled = ActivoHeces
        Me.txtAscarisHuevos.Enabled = ActivoHeces
        Me.AscarisAdultos.Enabled = ActivoHeces
        Me.txtAscarisLarvas.Enabled = ActivoHeces
        Me.txtTrichurisHuevos.Enabled = ActivoHeces
        Me.txtTrichurisAdultos.Enabled = ActivoHeces
        Me.txtTrichurisLarva.Enabled = ActivoHeces
        Me.txtStrongyloidesHuevos.Enabled = ActivoHeces
        Me.txtStrongyloidesAdultos.Enabled = ActivoHeces
        Me.txtStrongyloidesLarva.Enabled = ActivoHeces
        Me.txtEnterobiosHuevos.Enabled = ActivoHeces
        Me.txtEnterobiosAdultos.Enabled = ActivoHeces
        Me.txtEnterobiosLarva.Enabled = ActivoHeces
        Me.txtStrongyloidesHuevos.Enabled = ActivoHeces
        Me.txtStrongyloidesAdultos.Enabled = ActivoHeces
        Me.txtStrongyloidesLarva.Enabled = ActivoHeces
        Me.txtHymenolepsisnanaHuevos.Enabled = ActivoHeces
        Me.txtHymenolepsisnanaAdultos.Enabled = ActivoHeces
        Me.HymenolepsisnanaLarva.Enabled = ActivoHeces
        Me.txtHymenolepsisdiminutaHuevos.Enabled = ActivoHeces
        Me.txtHymenolepsisdiminutaAdultos.Enabled = ActivoHeces
        Me.txtHymenolepsisdiminutaLarva.Enabled = ActivoHeces
        Me.txtTaeniaHuevos.Enabled = ActivoHeces
        Me.txtTaeniaAdultos.Enabled = ActivoHeces
        Me.txtTaeniaLarva.Enabled = ActivoHeces
        Me.txtUncinariasHuevos.Enabled = ActivoHeces
        Me.txtUncinariasAdultos.Enabled = ActivoHeces
        Me.txtUncinariasLarva.Enabled = ActivoHeces
        Me.txtEntamoebaTrofo.Enabled = ActivoHeces
        Me.txtEntamoebaQuistes.Enabled = ActivoHeces
        Me.txtEntamoebaColiTrofo.Enabled = ActivoHeces
        Me.txtEntamoebaColiQuistes.Enabled = ActivoHeces
        Me.txtEndolimaxTrofo.Enabled = ActivoHeces
        Me.txtEndolimaxQuistes.Enabled = ActivoHeces
        Me.txtLodamoebaTrofo.Enabled = ActivoHeces
        Me.txtLodamoebaQuistes.Enabled = ActivoHeces
        Me.txtGiardiaTrofo.Enabled = ActivoHeces
        Me.txtGiardiaQuistes.Enabled = ActivoHeces
        Me.txtTrinchomonasTrofo.Enabled = ActivoHeces
        Me.txtTrinchomonasQuistes.Enabled = ActivoHeces
        Me.txtChilomastixTrofo.Enabled = ActivoHeces
        Me.txtChilomastixQuistes.Enabled = ActivoHeces
        Me.txtBalantidiumTrofo.Enabled = ActivoHeces
        Me.txtBalantidiumQuistes.Enabled = ActivoHeces
        Me.txtBalantidiumTrofo.Enabled = ActivoHeces
        Me.txtBalantidiumQuistes.Enabled = ActivoHeces

        Me.txtEritrocitos2.Enabled = ActivarBiometriaHematica
        Me.txtLeucocitos.Enabled = ActivarBiometriaHematica
        Me.txtPlaquetas.Enabled = ActivarBiometriaHematica
        Me.txtReticulocitos.Enabled = ActivarBiometriaHematica
        Me.txtSedimentacion.Enabled = ActivarBiometriaHematica
        Me.txtCoagulacion.Enabled = ActivarBiometriaHematica
        Me.txtSangria.Enabled = ActivarBiometriaHematica
        Me.txtProtombina.Enabled = ActivarBiometriaHematica
        Me.txtTromboplast.Enabled = ActivarBiometriaHematica
        Me.txtRetracCoagulo.Enabled = ActivarBiometriaHematica
        Me.txtHemoglobina.Enabled = ActivarBiometriaHematica
        Me.txtHematocrito.Enabled = ActivarBiometriaHematica
        Me.txtVol_Corp_Med.Enabled = ActivarBiometriaHematica
        Me.txtHp_Corp_Med.Enabled = ActivarBiometriaHematica
        Me.txtInv_Hematozoaria.Enabled = ActivarBiometriaHematica
        Me.txtHematocrito.Enabled = ActivarBiometriaHematica
        Me.txtCaracteres_Celulares.Enabled = ActivarBiometriaHematica

        Me.txtHbA1c.Enabled = ActivarHemoglobina

        Me.txtGlucosa.Enabled = ActivarQuimica
        Me.txtColesterol_Total2.Enabled = ActivarQuimica
        Me.txtTrigliceridos2.Enabled = ActivarQuimica
        Me.txtCreatinina.Enabled = ActivarQuimica
        Me.txtTGO.Enabled = ActivarQuimica
        Me.txtTGP.Enabled = ActivarQuimica
        Me.txtBilirrubina.Enabled = ActivarQuimica
        Me.txtBilirrubinaDirecto.Enabled = ActivarQuimica
        Me.txtBilirrubinaIndirecto.Enabled = ActivarQuimica
        Me.txtAmilasa.Enabled = ActivarQuimica
        Me.txtAlbuminas.Enabled = ActivarQuimica
        Me.txtProteinas.Enabled = ActivarQuimica
        Me.txtAslo.Enabled = ActivarQuimica
        Me.txtFR.Enabled = ActivarQuimica
        Me.txtPCR.Enabled = ActivarQuimica
        Me.txtVRDL.Enabled = ActivarQuimica
        Me.txtAcidoUrico.Enabled = ActivarQuimica
        Me.txtFost_Alkalina.Enabled = ActivarQuimica


        Me.txtAspecto.Enabled = ActivarOrina
        Me.txtColor2.Enabled = ActivarOrina
        Me.txtSedimento.Enabled = ActivarOrina
        Me.txtDensidad.Enabled = ActivarOrina
        Me.txtProteinas2.Enabled = ActivarOrina
        Me.txtHemoglobina2.Enabled = ActivarOrina
        Me.txtCetonicos.Enabled = ActivarOrina
        Me.txtPH.Enabled = ActivarOrina
        Me.txtUrobilinogeno.Enabled = ActivarOrina
        Me.txtGlucosa2.Enabled = ActivarOrina
        Me.txtNitritos.Enabled = ActivarOrina
        Me.txtEpiteliales.Enabled = ActivarOrina
        Me.txtLeucocitos2.Enabled = ActivarOrina
        Me.txtEritrocitos3.Enabled = ActivarOrina
        Me.txtCilindros.Enabled = ActivarOrina
        Me.txtCristales.Enabled = ActivarOrina
        Me.txtHilos_Mucosos.Enabled = ActivarOrina
        Me.txtCualitativo.Enabled = ActivarOrina
        Me.txtCuantitativo.Enabled = ActivarOrina
        Me.txtBilirrubina2.Enabled = ActivarOrina
        Me.txtBacterias.Enabled = ActivarOrina


        Me.txtSodio.Enabled = ActivarElectrolitos
        Me.txtPotasio.Enabled = ActivarElectrolitos
        Me.txtCloro.Enabled = ActivarElectrolitos
        Me.txtCalcio.Enabled = ActivarElectrolitos
        Me.txtMagnesio.Enabled = ActivarElectrolitos
        Me.txtFosforo.Enabled = ActivarElectrolitos


        Me.txtCreatinina2.Enabled = ActivarPerfilRenal
        Me.txtAcidoUrico2.Enabled = ActivarPerfilRenal
        Me.txtUrea.Enabled = ActivarPerfilRenal
        Me.txtBUN.Enabled = ActivarPerfilRenal
        Me.txtProteinas_Totales.Enabled = ActivarPerfilRenal
        Me.txtGlobulina.Enabled = ActivarPerfilRenal
        Me.txtAlbuminas2.Enabled = ActivarPerfilRenal


    End Sub



    Public Sub Grabar_Examen(ByVal TipoExamen As String, ByVal Numero_Expediente As String, ByVal Id_Numero_Examen As Double, ByVal Fecha As Date)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim TotalCosto As Double, TotalFob As Double, TasaCambio As Double, Id_Tipo_Examen As Double, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        Me.txtNumero_Expediente.Text = Numero_Expediente

        '///////////////////////////////DATOS DEL EXPEDIENTE
        SqlCompras = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If Not DataSet.Tables("Expediente").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
            Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
        End If

        '///////////////////////////////TIPO EXAMEN ////////////////////////////////////
        SqlCompras = "SELECT  IdTipoExamen, TipoExamen FROM TipoExamen WHERE (TipoExamen LIKE '% " & TipoExamen & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "TipoExamen")
        If Not DataSet.Tables("TipoExamen").Rows.Count = 0 Then
            Id_Tipo_Examen = DataSet.Tables("TipoExamen").Rows(0)("IdTipoExamen")
        End If

        SqlCompras = "SELECT Examenes.* FROM(Examenes) WHERE (id_Numero_Examen = " & Id_Numero_Examen & ") AND (IdTipoExamen = " & Id_Tipo_Examen & ") AND (Numero_Expediente = '" & Numero_Expediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Examen")
        If Not DataSet.Tables("Examen").Rows.Count = 0 Then

            Select Case TipoExamen
                Case "Examen Perfil Lipidico"
                    Me.txtTrigliceridos.Text = DataSet.Tables("Examen").Rows(0)("Trigliceridos")
                    Me.txtColesterol_Total.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_Total")
                    Me.txtColesterol_HDL.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_HDL")
                    Me.txtColesterol_LDL.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_LDL")
                    Me.txtRiesgo_Coronario.Text = DataSet.Tables("Examen").Rows(0)("Riesgo_Coronario")



                Case "Extamen Heces"
                    Me.TxtConsitencia.Text = DataSet.Tables("Examen").Rows(0)("Consistencia")
                    Me.txtColor.Text = DataSet.Tables("Examen").Rows(0)("Color")
                    Me.txtMucos.Text = DataSet.Tables("Examen").Rows(0)("Mucos")
                    Me.txtOlor.Text = DataSet.Tables("Examen").Rows(0)("Olor")
                    Me.txtObservaciones.Text = DataSet.Tables("Examen").Rows(0)("Observaciones")
                    Me.txtAncylostomaHuevos.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaHuevos")
                    Me.txtAncylostomaAdultos.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaAdultos")
                    Me.txtAncylostomaLarvas.Text = DataSet.Tables("Examen").Rows(0)("AncylostomaLarvas")
                    Me.txtAscarisHuevos.Text = DataSet.Tables("Examen").Rows(0)("AscarisHuevos")
                    Me.AscarisAdultos.Text = DataSet.Tables("Examen").Rows(0)("AscarisAdultos")
                    Me.txtAscarisLarvas.Text = DataSet.Tables("Examen").Rows(0)("AscarisLarvas")
                    Me.txtTrichurisHuevos.Text = DataSet.Tables("Examen").Rows(0)("TrichurisHuevos")
                    Me.txtTrichurisAdultos.Text = DataSet.Tables("Examen").Rows(0)("TrichurisAdultos")
                    Me.txtTrichurisLarva.Text = DataSet.Tables("Examen").Rows(0)("TrichurisLarva")
                    Me.txtStrongyloidesHuevos.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesHuevos")
                    Me.txtStrongyloidesAdultos.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesAdultos")
                    Me.txtStrongyloidesLarva.Text = DataSet.Tables("Examen").Rows(0)("StrongyloidesLarva")
                    Me.txtEnterobiosHuevos.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosHuevos")
                    Me.txtEnterobiosAdultos.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosAdultos")
                    Me.txtEnterobiosLarva.Text = DataSet.Tables("Examen").Rows(0)("EnterobiosLarva")
                    Me.txtStrongyloidesHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaHuevos")
                    Me.txtStrongyloidesAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaAdultos")
                    Me.txtStrongyloidesLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaLarva")
                    Me.txtHymenolepsisnanaHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaHuevos")
                    Me.txtHymenolepsisnanaAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaAdultos")
                    Me.HymenolepsisnanaLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisnanaLarva")
                    Me.txtHymenolepsisdiminutaHuevos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaHuevos")
                    Me.txtHymenolepsisdiminutaAdultos.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaAdultos")
                    Me.txtHymenolepsisdiminutaLarva.Text = DataSet.Tables("Examen").Rows(0)("HymenolepsisdiminutaLarva")
                    Me.txtTaeniaHuevos.Text = DataSet.Tables("Examen").Rows(0)("TaeniaHuevos")
                    Me.txtTaeniaAdultos.Text = DataSet.Tables("Examen").Rows(0)("TaeniaAdultos")
                    Me.txtTaeniaLarva.Text = DataSet.Tables("Examen").Rows(0)("TaeniaLarva")
                    Me.txtUncinariasHuevos.Text = DataSet.Tables("Examen").Rows(0)("UncinariasHuevos")
                    Me.txtUncinariasAdultos.Text = DataSet.Tables("Examen").Rows(0)("UncinariasAdultos")
                    Me.txtUncinariasLarva.Text = DataSet.Tables("Examen").Rows(0)("UncinariasLarva")
                    Me.txtEntamoebaTrofo.Text = DataSet.Tables("Examen").Rows(0)("EntamoebaTrofo")
                    Me.txtEntamoebaQuistes.Text = DataSet.Tables("Examen").Rows(0)("EntamoebaQuistes")
                    Me.txtEndolimaxTrofo.Text = DataSet.Tables("Examen").Rows(0)("EndolimaxTrofo")
                    Me.txtEndolimaxQuistes.Text = DataSet.Tables("Examen").Rows(0)("EndolimaxQuistes")
                    Me.txtLodamoebaTrofo.Text = DataSet.Tables("Examen").Rows(0)("LodamoebaTrofo")
                    Me.txtLodamoebaQuistes.Text = DataSet.Tables("Examen").Rows(0)("LodamoebaQuistes")
                    Me.txtGiardiaTrofo.Text = DataSet.Tables("Examen").Rows(0)("GiardiaTrofo")
                    Me.txtGiardiaQuistes.Text = DataSet.Tables("Examen").Rows(0)("GiardiaQuistes")
                    Me.txtTrinchomonasTrofo.Text = DataSet.Tables("Examen").Rows(0)("TrinchomonasTrofo")
                    Me.txtTrinchomonasQuistes.Text = DataSet.Tables("Examen").Rows(0)("TrinchomonasQuistes")
                    Me.txtChilomastixTrofo.Text = DataSet.Tables("Examen").Rows(0)("ChilomastixTrofo")
                    Me.txtChilomastixQuistes.Text = DataSet.Tables("Examen").Rows(0)("ChilomastixQuistes")
                    Me.txtBalantidiumTrofo.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumTrofo")
                    Me.txtBalantidiumQuistes.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumQuistes")
                    Me.txtBalantidiumTrofo.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumTrofo")
                    Me.txtBalantidiumQuistes.Text = DataSet.Tables("Examen").Rows(0)("BalantidiumQuistes")

                Case "Examen Biometria Hematica"
                    Me.txtEritrocitos2.Text = DataSet.Tables("Examen").Rows(0)("Eritrocitos")
                    Me.txtLeucocitos.Text = DataSet.Tables("Examen").Rows(0)("Leucocitos")
                    Me.txtPlaquetas.Text = DataSet.Tables("Examen").Rows(0)("Plaquetas")
                    Me.txtReticulocitos.Text = DataSet.Tables("Examen").Rows(0)("Reticulocitos")

                    Me.txtSedimentacion.Text = DataSet.Tables("Examen").Rows(0)("Sedimentacion")
                    Me.txtCoagulacion.Text = DataSet.Tables("Examen").Rows(0)("Coagulacion")
                    Me.txtSangria.Text = DataSet.Tables("Examen").Rows(0)("Sangria")
                    Me.txtProtombina.Text = DataSet.Tables("Examen").Rows(0)("Protombina")

                    Me.txtTromboplast.Text = DataSet.Tables("Examen").Rows(0)("Tromboplast")
                    Me.txtRetracCoagulo.Text = DataSet.Tables("Examen").Rows(0)("RetracCoagulo")
                    Me.txtHemoglobina.Text = DataSet.Tables("Examen").Rows(0)("Hemoglobina")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hematocrito")

                    Me.txtVol_Corp_Med.Text = DataSet.Tables("Examen").Rows(0)("Vol_Corp_Med")
                    Me.txtHp_Corp_Med.Text = DataSet.Tables("Examen").Rows(0)("Hp_Corp_Med")
                    Me.txtInv_Hematozoaria.Text = DataSet.Tables("Examen").Rows(0)("Inv_Hematozoaria")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hematocrito")
                    Me.txtCaracteres_Celulares.Text = DataSet.Tables("Examen").Rows(0)("Caracteres_Celulares")

                Case "Examen Hemoglobina"
                    Me.txtHbA1c.Text = DataSet.Tables("Examen").Rows(0)("HbA1c")

                Case "Examen Quimica Sanguinea"
                    Me.txtGlucosa.Text = DataSet.Tables("Examen").Rows(0)("Glucosa")
                    Me.txtColesterol_Total.Text = DataSet.Tables("Examen").Rows(0)("Colesterol_Total")
                    Me.txtTrigliceridos.Text = DataSet.Tables("Examen").Rows(0)("Trigliceridos")
                    Me.txtCreatinina.Text = DataSet.Tables("Examen").Rows(0)("Creatinina")

                    Me.txtTGO.Text = DataSet.Tables("Examen").Rows(0)("TGO")
                    Me.txtTGP.Text = DataSet.Tables("Examen").Rows(0)("TGP")
                    Me.txtBilirrubina.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaTotal")
                    Me.txtBilirrubinaDirecto.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaDirecto")
                    Me.txtBilirrubinaIndirecto.Text = DataSet.Tables("Examen").Rows(0)("BilirrubinaIndirecto")

                    Me.txtAmilasa.Text = DataSet.Tables("Examen").Rows(0)("Amilasa")
                    Me.txtAlbuminas.Text = DataSet.Tables("Examen").Rows(0)("Albuminas")
                    Me.txtProteinas_Totales.Text = DataSet.Tables("Examen").Rows(0)("Proteinas_Totales")
                    Me.txtAslo.Text = DataSet.Tables("Examen").Rows(0)("ASLO")
                    Me.txtFR.Text = DataSet.Tables("Examen").Rows(0)("FR")

                    Me.txtPCR.Text = DataSet.Tables("Examen").Rows(0)("PCR")
                    Me.txtVRDL.Text = DataSet.Tables("Examen").Rows(0)("VRDL")
                    Me.txtAcidoUrico.Text = DataSet.Tables("Examen").Rows(0)("AcidoUrico")
                    Me.txtFost_Alkalina.Text = DataSet.Tables("Examen").Rows(0)("Fost_Alkalina")

                Case "Examen Orina"
                    Me.txtColor2.Text = DataSet.Tables("Examen").Rows(0)("Color")
                    Me.txtSedimento.Text = DataSet.Tables("Examen").Rows(0)("Sedimento")
                    Me.txtDensidad.Text = DataSet.Tables("Examen").Rows(0)("Desidad")
                    Me.txtProteinas.Text = DataSet.Tables("Examen").Rows(0)("Proteinas")
                    Me.txtHematocrito.Text = DataSet.Tables("Examen").Rows(0)("Hemoglobina")

                    Me.txtCetonicos.Text = DataSet.Tables("Examen").Rows(0)("Cetonicos")
                    Me.txtPH.Text = DataSet.Tables("Examen").Rows(0)("PH")
                    Me.txtUrobilinogeno.Text = DataSet.Tables("Examen").Rows(0)("Urobilinogeno")
                    Me.txtGlucosa2.Text = DataSet.Tables("Examen").Rows(0)("Bilirrubina")
                    Me.txtNitritos.Text = DataSet.Tables("Examen").Rows(0)("Nitritos")

                    Me.txtEpiteliales.Text = DataSet.Tables("Examen").Rows(0)("Epiteliales")
                    Me.txtLeucocitos.Text = DataSet.Tables("Examen").Rows(0)("Leucocitos")
                    Me.txtEritrocitos3.Text = DataSet.Tables("Examen").Rows(0)("Eritrocitos")
                    Me.txtCilindros.Text = DataSet.Tables("Examen").Rows(0)("Cilindros")
                    Me.txtCristales.Text = DataSet.Tables("Examen").Rows(0)("Cristales")
                    Me.txtHilos_Mucosos.Text = DataSet.Tables("Examen").Rows(0)("Hilos_Mucosos")
                    Me.txtCualitativo.Text = DataSet.Tables("Examen").Rows(0)("Cualitativo")
                    Me.txtCuantitativo.Text = DataSet.Tables("Examen").Rows(0)("Cuantitativo")

                Case "Examen Electrolitos Sericos"
                    Me.txtSodio.Text = DataSet.Tables("Examen").Rows(0)("Sodio")
                    Me.txtPotasio.Text = DataSet.Tables("Examen").Rows(0)("Potasio")
                    Me.txtCloro.Text = DataSet.Tables("Examen").Rows(0)("Cloro")
                    Me.txtCalcio.Text = DataSet.Tables("Examen").Rows(0)("Calcio")
                    Me.txtMagnesio.Text = DataSet.Tables("Examen").Rows(0)("Mangesio")
                    Me.txtFosforo.Text = DataSet.Tables("Examen").Rows(0)("Fosforo")

                Case "Examen Perfil Renal"
                    Me.txtCreatinina2.Text = DataSet.Tables("Examen").Rows(0)("Creatinina")
                    Me.txtAcidoUrico2.Text = DataSet.Tables("Examen").Rows(0)("AcidoUrico")
                    Me.txtUrea.Text = DataSet.Tables("Examen").Rows(0)("Urea")
                    Me.txtBUN.Text = DataSet.Tables("Examen").Rows(0)("BUN")
                    Me.txtProteinas_Totales.Text = DataSet.Tables("Examen").Rows(0)("Proteinas_Totales")
                    Me.txtGlobulina.Text = DataSet.Tables("Examen").Rows(0)("Glubolina")


            End Select

        End If




    End Sub



    Private Sub FrmExamen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Combo()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        InsertarActualizarExamen(Me.CboTipoExamen.Text, txtNumero_Expediente.Text, CboTipoExamen.Text, DtpFecheExamen.Value)
    End Sub
End Class