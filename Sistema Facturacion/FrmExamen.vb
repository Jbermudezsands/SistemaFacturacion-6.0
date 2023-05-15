Public Class FrmExamen
    Public TipoExamen As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Public Sub Cargar_Combo()
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String

        DataSet.Reset()
        SqlProductos = "SELECT IdTipoExamen, TipoExamen FROM TipoExamen"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "TipoExamen")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboTipoExamen.DataSource = DataSet.Tables("TipoExamen")
        End If
        Me.CboTipoExamen.Splits.Item(0).DisplayColumns(1).Width = 350
    End Sub

    Public Sub Cargar_Examen(ByVal TipoExamen As String, ByVal Numero_Expediente As String, ByVal Id_Numero_Examen As Double)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim TotalCosto As Double, TotalFob As Double, TasaCambio As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        Me.txtNumero_Expediente.Text = Numero_Expediente

        SqlCompras = "SELECT  Expediente.* FROM Expediente WHERE (Numero_Expediente = '" & Numero_Expediente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Expediente")
        If Not DataSet.Tables("Expediente").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Expediente").Rows(0)("Nombres")
            Me.TxtApellidos.Text = DataSet.Tables("Expediente").Rows(0)("Apellidos")
        End If


        SqlCompras = "SELECT Examenes.* FROM(Examenes) WHERE (id_Numero_Examen = " & Id_Numero_Examen & ") AND (IdTipoExamen = " & TipoExamen & ") AND (Numero_Expediente = '" & Numero_Expediente & "')"
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




    Private Sub FrmExamen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Combo()

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class