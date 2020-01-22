Imports C1.Win.C1Ribbon
Imports System.Collections.Specialized
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports System

Public Class MDIMain

    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub ExitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitButton.Click, RibbonApplicationMenu1.DoubleClick
        Close()
    End Sub


    Private Sub StyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Office2007BlackStyleButton.Click, Office2007SilverStyleButton.Click, Office2007BlueStyleButton.Click
        Dim B As C1.Win.C1Ribbon.RibbonToggleButton = CType(sender, C1.Win.C1Ribbon.RibbonToggleButton)
        If B.ID = "Office2007BlueStyleButton" Then
            VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Blue
        ElseIf B.ID = "Office2007SilverStyleButton" Then
            VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Silver
        ElseIf B.ID = "Office2007BlackStyleButton" Then
            VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black
        End If
    End Sub

    Private Sub c1Ribbon1_VisualStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1Ribbon1.VisualStyleChanged
        UpdateRibbonStyleMenuCheckMark()
    End Sub

    Private Sub UpdateRibbonStyleMenuCheckMark()
        Select Case VisualStyle
            Case C1.Win.C1Ribbon.VisualStyle.Office2007Blue
                Office2007BlueStyleButton.Pressed = True
            Case C1.Win.C1Ribbon.VisualStyle.Office2007Silver
                Office2007SilverStyleButton.Pressed = True
            Case C1.Win.C1Ribbon.VisualStyle.Office2007Black
                Office2007BlackStyleButton.Pressed = True
        End Select
    End Sub

    ' InitializeQatPosition

    Private Sub InitializeQatPosition()
        Dim settings As My.MySettings = My.MySettings.Default

        ' Initialize QAT position from application settings.
        RibbonQat1.BelowRibbon = settings.QatBelowRibbon
    End Sub

    Private Sub RibbonQat1_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RibbonQat1.PositionChanged
        Dim settings As My.MySettings = My.MySettings.Default
        settings.QatBelowRibbon = RibbonQat1.BelowRibbon
    End Sub

    ' Recent Document List

    Private recentDocuments As RecentDocumentList


    Private Class RecentDocumentList

        Public Delegate Sub LoadDocumentDelegate(ByVal filename As String)

        Private ReadOnly rightPaneItems As RibbonItemCollection
        Private ReadOnly files As StringCollection
        Private ReadOnly loadDocument As LoadDocumentDelegate
        Private ReadOnly listTopIndex As Integer

        Public Sub New(ByVal rightPaneItems As RibbonItemCollection, ByVal files As StringCollection, ByVal loadDocument As LoadDocumentDelegate)
            Me.rightPaneItems = rightPaneItems
            Me.files = files
            Me.loadDocument = loadDocument

            ' first create a header and make sure it's not selectable
            Dim listItem As RibbonListItem = New RibbonListItem(New RibbonLabel("Recordatorio de Tareas"))
            listItem.AllowSelection = False
            rightPaneItems.Add(listItem)
            rightPaneItems.Add(New RibbonListItem(New RibbonSeparator()))

            Me.listTopIndex = rightPaneItems.Count

            ' create the recently used document list
            For Each document As String In Me.files
                Dim item As RecentDocumentItem = New RecentDocumentItem(document, False, loadDocument)
                rightPaneItems.Add(item)
            Next
        End Sub

        Public Class RecentDocumentItem
            Inherits RibbonListItem

            Private ReadOnly label As RibbonLabel
            Private WithEvents pin As RibbonToggleButton
            Private ReadOnly fullFileName_Renamed As String
            Private ReadOnly loadDocument As LoadDocumentDelegate

            Public Sub New(ByVal fullFileName_Renamed As String, ByVal pinned As Boolean, ByVal loadDocument As LoadDocumentDelegate)
                Me.fullFileName_Renamed = fullFileName_Renamed
                Me.loadDocument = loadDocument

                Dim documentName As String = New System.IO.FileInfo(fullFileName_Renamed).Name

                ' each item consists of the name of the document and a push pin
                Me.label = New RibbonLabel(documentName)
                Me.pin = New RibbonToggleButton()

                ' allow the button to be selectable so we can toggle it
                Me.pin.AllowSelection = True

                Me.pin.Pressed = pinned
                Me.SetPinImage()

                Me.Items.Add(Me.label)
                Me.Items.Add(Me.pin)

                Me.ToolTip = fullFileName_Renamed
            End Sub

            Private Sub Pin_PressedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pin.PressedChanged
                Me.SetPinImage()
            End Sub

            Private Sub Me_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Click
                Me.loadDocument(Me.FullFileName)
            End Sub

            Private Sub SetPinImage()
                If Me.pin.Pressed Then
                    Me.pin.SmallImage = My.Resources.Pinned
                Else
                    Me.pin.SmallImage = My.Resources.Unpinned
                End If
            End Sub

            Public ReadOnly Property FullFileName() As String
                Get
                    Return Me.fullFileName_Renamed
                End Get
            End Property

            Public ReadOnly Property Pinned() As Boolean
                Get
                    Return Me.pin.Pressed
                End Get
            End Property
        End Class

        ' Adds or moves the file to the top of the list.
        Public Sub Update(ByVal filename As String)
            Dim fullFileName As String = New System.IO.FileInfo(filename).FullName

            Dim i As Integer = Me.IndexOf(fullFileName)
            If i >= 0 Then
                If Me(i).Pinned Then ' do not move pinned items
                    Return
                End If

                Me.RemoveAt(i)
            End If

            Me.Insert(0, New RecentDocumentItem(fullFileName, False, Me.loadDocument))
        End Sub

        Private ReadOnly Property Count() As Integer
            Get
                Return Me.rightPaneItems.Count - Me.listTopIndex
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal i As Integer) As RecentDocumentItem
            Get
                Return CType(Me.rightPaneItems(Me.listTopIndex + i), RecentDocumentItem)
            End Get
        End Property

        Private Function IndexOf(ByVal fullFileName As String) As Integer
            For i As Integer = 0 To Me.Count - 1
                If Me(i).FullFileName = fullFileName Then
                    Return i
                End If
            Next
            Return -1
        End Function

        Private Sub RemoveAt(ByVal i As Integer)
            Me.rightPaneItems.RemoveAt(Me.listTopIndex + i)
            Me.files.RemoveAt(i)
        End Sub

        Private Sub Insert(ByVal i As Integer, ByVal item As RecentDocumentItem)
            Me.rightPaneItems.Insert(Me.listTopIndex + i, item)
            Me.files.Insert(i, item.FullFileName)
        End Sub
    End Class

    Private Sub ParagraphGroup_DialogLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParagraphGroup.DialogLauncherClick

    End Sub

    Private Sub RibbonGroup7_DialogLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonGroup7.DialogLauncherClick

    End Sub

    Private Sub RibbonButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonSalir.Click
        Me.Close()
    End Sub

    Private Sub RibbonFacturacion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonFacturacion1.Click
        My.Forms.FrmFacturas.MdiParent = Me
        My.Forms.FrmFacturas.Show()
    End Sub

    Private Sub RibbonCompras1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCompras1.Click
        My.Forms.FrmCompras.MdiParent = Me
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub RibbonLiquidacion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonLiquidacion1.Click
        My.Forms.FrmLiquidacion.MdiParent = Me
        My.Forms.FrmLiquidacion.Show()
    End Sub

    Private Sub RibbonProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonProductos.Click
        My.Forms.FrmProductos.MdiParent = Me
        My.Forms.FrmProductos.Show()
    End Sub

    Private Sub RibbonProductos1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonProductos1.Click
        My.Forms.FrmProductos.MdiParent = Me
        My.Forms.FrmProductos.Show()
    End Sub

    Private Sub RibbonClietes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonClietes.Click
        My.Forms.FrmClientes.MdiParent = Me
        My.Forms.FrmClientes.Show()
    End Sub

    Private Sub RibbonProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonProveedores.Click
        My.Forms.FrmProveedores.MdiParent = Me
        My.Forms.FrmProveedores.Show()
    End Sub

    Private Sub RibbonVendedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonVendedores.Click
        My.Forms.FrmVendedor.MdiParent = Me
        My.Forms.FrmVendedor.Show()
    End Sub

    Private Sub RibbonTasaCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTasaCambio.Click
        My.Forms.FrmTasaCambio.MdiParent = Me
        My.Forms.FrmTasaCambio.Show()
    End Sub

    Private Sub RibbonImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonImpuestos.Click
        My.Forms.FrmImpuestos.MdiParent = Me
        My.Forms.FrmImpuestos.Show()
    End Sub

    Private Sub RibbonLineaProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonLineaProductos.Click
        My.Forms.FrmLineaProductos.MdiParent = Me
        My.Forms.FrmLineaProductos.Show()
    End Sub

    Private Sub RibbonCajeros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCajeros.Click
        My.Forms.FrmCajeros.MdiParent = Me
        My.Forms.FrmCajeros.Show()
    End Sub

    Private Sub RibbonServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonServicios.Click
        My.Forms.FrmServicios.MdiParent = Me
        My.Forms.FrmServicios.Show()
    End Sub

    Private Sub RibbonRubros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonRubros.Click
        My.Forms.FrmRubros.MdiParent = Me
        My.Forms.FrmRubros.Show()
    End Sub

    Private Sub RibbonClietes1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonClietes1.Click
        My.Forms.FrmClientes.MdiParent = Me
        My.Forms.FrmClientes.Show()
    End Sub

    Private Sub RibbonServicios1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonServicios1.Click
        My.Forms.FrmServicios.MdiParent = Me
        My.Forms.FrmServicios.Show()
    End Sub

    Private Sub RibbonTasaCambio1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTasaCambio1.Click
        My.Forms.FrmTasaCambio.MdiParent = Me
        My.Forms.FrmTasaCambio.Show()
    End Sub

    Private Sub RibbonTransferencia1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTransferencia1.Click
        My.Forms.FrmTransferenciaListado.MdiParent = Me
        My.Forms.FrmTransferenciaListado.Show()
    End Sub

    Private Sub RibbonFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonFacturacion.Click
        My.Forms.FrmFacturas.MdiParent = Me
        My.Forms.FrmFacturas.Show()
    End Sub

    Private Sub RibbonCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCompras.Click
        My.Forms.FrmCompras.MdiParent = Me
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub RibbonEnsamble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonEnsamble.Click
        My.Forms.FrmEnsamble.MdiParent = Me
        My.Forms.FrmEnsamble.Show()
    End Sub

    Private Sub RibbonLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonLiquidacion.Click
        My.Forms.FrmLiquidacion.MdiParent = Me
        My.Forms.FrmLiquidacion.Show()
    End Sub

    Private Sub RibbonTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTransferencia.Click
        My.Forms.FrmTransferenciaListado.MdiParent = Me
        My.Forms.FrmTransferenciaListado.Show()
    End Sub

    Private Sub RibbonButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonInventarioFisico.Click
        My.Forms.FrmInventarioFisico.MdiParent = Me
        My.Forms.FrmInventarioFisico.Show()
    End Sub

    Private Sub RibbonPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPagos.Click
        My.Forms.FrmPagos.MdiParent = Me
        My.Forms.FrmPagos.Show()
    End Sub

    Private Sub RibbonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonRecibos.Click
        My.Forms.FrmRecibos.MdiParent = Me
        My.Forms.FrmRecibos.Show()
    End Sub

    Private Sub RibbonArqueo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonArqueo.Click
        My.Forms.FrmArqueo.MdiParent = Me
        My.Forms.FrmArqueo.Show()
    End Sub

    Private Sub RibbonButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCtasxCobrar.Click
        My.Forms.FrmCuentasXCobrar.MdiParent = Me
        My.Forms.FrmCuentasXCobrar.Show()
    End Sub

    Private Sub RibbonCtasXPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCtasXPagar.Click
        My.Forms.FrmCuentasXPagar.MdiParent = Me
        My.Forms.FrmCuentasXPagar.Show()
    End Sub

    Private Sub RibbonButton41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonCtasXCobrar1.Click
        My.Forms.FrmCuentasXCobrar.MdiParent = Me
        My.Forms.FrmCuentasXCobrar.Show()
    End Sub

    Private Sub RibbonHistoricoFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonHistoricoFactura.Click
        My.Forms.FrmFacturasHistoricos.MdiParent = Me
        My.Forms.FrmFacturasHistoricos.Show()
    End Sub

    Private Sub RibbonHistoricoCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonHistoricoCompras.Click
        My.Forms.FrmComprasHistorico.MdiParent = Me
        My.Forms.FrmComprasHistorico.Show()
    End Sub

    Private Sub RibbonPlantillaVtasCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPlantillaVtasCompras.Click
        My.Forms.FrmPlantillas.MdiParent = Me
        My.Forms.FrmPlantillas.Show()
    End Sub

    Private Sub RibbonButton61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonHistoricoFactura1.Click
        My.Forms.FrmFacturasHistoricos.MdiParent = Me
        My.Forms.FrmFacturasHistoricos.Show()
    End Sub

    Private Sub RibbonHistoricoCompras1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonHistoricoCompras1.Click
        My.Forms.FrmComprasHistorico.MdiParent = Me
        My.Forms.FrmComprasHistorico.Show()
    End Sub

    Private Sub RibbonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonExportar.Click
        My.Forms.FrmExportar.MdiParent = Me
        My.Forms.FrmExportar.Show()
    End Sub

    Private Sub RibbonImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonImportar.Click
        My.Forms.FrmImportacion.MdiParent = Me
        My.Forms.FrmImportacion.Show()
    End Sub

    Private Sub RibbonUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonUsuarios.Click
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub RibbonConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonConfigurar.Click
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub RibbonPersonalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPersonalizar.Click
        My.Forms.FrmPersonalizar.MdiParent = Me
        My.Forms.FrmPersonalizar.Show()
    End Sub

    Private Sub RibbonAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonAjustes.Click
        My.Forms.FrmActualiza.MdiParent = Me
        My.Forms.FrmActualiza.Show()
    End Sub

    Private Sub RibbonUsuarios1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonUsuarios1.Click
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub RibbonConfigurar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonConfigurar1.Click
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub RibbonReporteGenerales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteGenerales.Click
        Quien = "Reporte General"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonReporteVentasCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteVentasCompras.Click
        Quien = "Reporte Ventas"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonReporteInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteInventario.Click
        Quien = "Reporte Inventario"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonReporteCtasXCob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteCtasXCob.Click
        Quien = "Reporte Cuentas x Cobrar"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonActualizacion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonActualizacion1.Click
        Dim Directorio As String, RutaUpdate As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim objStreamReader As StreamReader
        Dim objStreamWriter As StreamWriter
        Dim strLine As String

        Try

            Sql = "SELECT *  FROM DatosEmpresa "
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    If Dir(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) <> "" Then

                        '---------------------------------------------------------------------------------------------
                        '------------------------BORRO EL ARCHIVO ----------------------------------------------------
                        '---------------------------------------------------------------------------------------------

                        RutaUpdate = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                        objStreamReader = New StreamReader(My.Application.Info.DirectoryPath + "\RutaUpdate.dll")
                        strLine = objStreamReader.ReadLine
                        Do While Not strLine Is Nothing

                            'Write the line to the Console window.
                            objStreamWriter.WriteLine("")


                            'Read the next line.
                            strLine = objStreamReader.ReadLine 'LEO LA LINEA

                        Loop

                        '---------------------------------------------------------------------------------------------
                        '------------------------GRABO LA NUEVA RUTA ----------------------------------------------------
                        '---------------------------------------------------------------------------------------------
                        objStreamWriter.WriteLine(RutaUpdate)

                        Directorio = My.Application.Info.DirectoryPath & "\Actualizar.exe"
                        Directorio = Shell(Directorio, vbNormalFocus)
                        objStreamReader.Close()
                        Me.Close()
                    Else
                        MsgBox("NO existe el Archivo en la Ruta Indicada", vbCritical, "Zeus Contable")
                    End If
                Else
                    MsgBox("Seleccione una Ruta de Actualizacion", vbCritical, "Zeus Contable")
                End If
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Demo(Now)
    End Sub

    Private Sub FrmMDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TasaCambio As Double, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Fecha As String
        Dim FechaTasa As String, Monto As Double, FechaInicio As Date, FechaFin As Date, FechaBusca As Date, i As Double
        Dim SqlDatos As String, Cadena2 As String = "", Registros As Double = 0





        TasaCambio = BuscaTasaCambio(Now)

        Me.Text = "Nombre Compañia: " & NombreCompañia

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////// /CIERRO TODAS LAS OPCIONES QUE EL PERFIL NO TIENE ACCESO /////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        i = 0
        SQl = "SELECT  Accesos.IdPerfil, Accesos.Modulo, Accesos.Acceso FROM  Accesos INNER JOIN Perfil ON Accesos.IdPerfil = Perfil.IdPerfil  " & _
               "WHERE (Accesos.Acceso LIKE '%NoAbrir%') AND (Perfil.NombrePerfil = '" & Acceso & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "Acceso")
        Registros = DataSet.Tables("Acceso").Rows.Count

        My.Application.DoEvents()
        Do While Registros > i
            Select Case DataSet.Tables("Acceso").Rows(i)("Modulo")

                Case "Personalizar" : Me.RibbonPersonalizar.Enabled = False
                Case "Perfiles y Accesos" : Me.RibbonPerfiles.Enabled = False : Me.RibbonPerfiles1.Enabled = False
                Case "Ajustes" : Me.RibbonAjustes.Enabled = False
                Case "Actualizacion" : Me.RibbonActualizacion.Enabled = False : Me.RibbonActualizacion1.Enabled = False
                Case "Inventario Fisico" : Me.RibbonInventarioFisico.Enabled = False
                Case "Configurar" : Me.RibbonConfigurar.Enabled = False : Me.RibbonConfigurar1.Enabled = False
                Case "Exportar a Excel" : Me.RibbonExportar.Enabled = False
                Case "Importacion" : Me.RibbonImportar.Enabled = False
                Case "Usuarios" : Me.RibbonUsuarios.Enabled = False : Me.RibbonUsuarios1.Enabled = False : Me.MenuUsuarios.Enabled = False
                Case "Reportes Inventario" : Me.RibbonInventarioFisico.Enabled = False
                Case "Reportes Ventas/Compras" : Me.RibbonReporteVentasCompras.Enabled = False
                Case "Reportes Generales" : Me.RibbonReporteGenerales.Enabled = False
                Case "Reportes Cuentas x Cobrar" : Me.RibbonReporteCtasXCob.Enabled = False
                Case "Plantilla Ventas/Compras" : Me.RibbonPlantillaVtasCompras.Enabled = False
                Case "Historico Facturacion" : Me.RibbonHistoricoFactura.Enabled = False : Me.RibbonHistoricoFactura1.Enabled = False
                Case "Historico Compras" : Me.RibbonHistoricoCompras.Enabled = False : Me.RibbonHistoricoCompras1.Enabled = False
                Case "Tareas" : Me.RibbonTareas.Enabled = False
                Case "Cajeros" : Me.RibbonCajeros.Enabled = False
                Case "Transferencia de Bodegas" : Me.RibbonTransferencia.Enabled = False : Me.RibbonTransferencia1.Enabled = False
                Case "Tipos de Precios" : Me.RibbonTiposPrecios.Enabled = False
                Case "Tasa de Cambio" : Me.RibbonTasaCambio.Enabled = False : Me.RibbonTasaCambio1.Enabled = False
                Case "Servicios" : Me.RibbonServicios.Enabled = False : Me.RibbonServicios1.Enabled = False
                Case "Rubros" : Me.RibbonRubros.Enabled = False
                Case "Proyectos" : Me.RibbonProyectos.Enabled = False
                Case "Notas de Debito y Credito" : Me.RibbonNotaDebitoCredito.Enabled = False
                Case "Impuestos" : Me.RibbonImpuestos.Enabled = False
                Case "Liquidacion" : Me.RibbonLiquidacion.Enabled = False : Me.RibbonLiquidacion1.Enabled = False
                Case "Arqueo de Caja" : Me.RibbonArqueo.Enabled = False
                Case "Vendedores" : Me.RibbonVendedores.Enabled = False
                Case "Proveedores" : Me.RibbonProveedores.Enabled = False
                Case "Productos" : Me.RibbonProductos.Enabled = False : Me.RibbonProductos1.Enabled = False
                Case "Linea Produtos" : Me.RibbonLineaProductos.Enabled = False
                Case "Ensamble" : Me.RibbonEnsamble.Enabled = False
                Case "Ctas x Pagar" : Me.RibbonCtasXPagar.Enabled = False
                Case "Ctas x Cobrar" : Me.RibbonCtasxCobrar.Enabled = False : Me.RibbonCtasXCobrar1.Enabled = False
                Case "Bodegas" : Me.RibbonBodegas.Enabled = False
                Case "Arqueo de Caja" : Me.RibbonArqueo.Enabled = False
                Case "Compras" : Me.RibbonCompras.Enabled = False : Me.RibbonCompras1.Enabled = False
                Case "Facturacion" : Me.RibbonFacturacion.Enabled = False : Me.RibbonFacturacion1.Enabled = False
                Case "Pagos" : Me.RibbonPagos.Enabled = False
                Case "Recibo de Caja" : RibbonRecibos.Enabled = False : RibbonRecibos1.Enabled = False
                Case "Clientes" : Me.RibbonClietes.Enabled = False : Me.RibbonClietes1.Enabled = False

            End Select

            i = i + 1
        Loop

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////SI LA TASA DE CAMBIO NO EXISTE, LA SINCRONIZO CON EL SISTEMA CONTABLE//////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        'If TasaCambio = 0 Then
        SQl = "SELECT *  FROM DatosEmpresa "
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            My.Application.DoEvents()

            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Version")) Then
            '    If DataSet.Tables("DatosEmpresa").Rows(0)("Version") = "Inventario" Then
            '        Me.RibbonPersonalizar.Enabled = True
            '        Me.RibbonPerfiles.Enabled = False : Me.RibbonPerfiles1.Enabled = False
            '        Me.RibbonAjustes.Enabled = True
            '        Me.RibbonActualizacion.Enabled = False : Me.RibbonActualizacion1.Enabled = False
            '        Me.RibbonInventarioFisico.Enabled = True
            '        Me.RibbonConfigurar.Enabled = True : Me.RibbonConfigurar1.Enabled = True
            '        Me.RibbonExportar.Enabled = False
            '        Me.RibbonImportar.Enabled = False
            '        Me.RibbonUsuarios.Enabled = True : Me.RibbonUsuarios1.Enabled = True : Me.MenuUsuarios.Enabled = True
            '        Me.RibbonInventarioFisico.Enabled = True
            '        Me.RibbonCompras.Enabled = True : Me.RibbonCompras1.Enabled = True
            '        Me.RibbonReporteGenerales.Enabled = False
            '        Me.RibbonReporteCtasXCob.Enabled = False
            '        Me.RibbonPlantillaVtasCompras.Enabled = False
            '        Me.RibbonHistoricoFactura.Enabled = True : Me.RibbonHistoricoFactura1.Enabled = True
            '        Me.RibbonHistoricoCompras.Enabled = True : Me.RibbonHistoricoCompras1.Enabled = True
            '        Me.RibbonTareas.Enabled = False
            '        Me.RibbonCajeros.Enabled = False
            '        Me.RibbonTransferencia.Enabled = False : Me.RibbonTransferencia1.Enabled = False
            '        Me.RibbonTiposPrecios.Enabled = False
            '        Me.RibbonTasaCambio.Enabled = True : Me.RibbonTasaCambio1.Enabled = True
            '        Me.RibbonServicios.Enabled = False : Me.RibbonServicios1.Enabled = False
            '        Me.RibbonRubros.Enabled = True
            '        Me.RibbonProyectos.Enabled = False
            '        Me.RibbonNotaDebitoCredito.Enabled = False
            '        Me.RibbonImpuestos.Enabled = True
            '        Me.RibbonLiquidacion.Enabled = True : Me.RibbonLiquidacion1.Enabled = True
            '        Me.RibbonArqueo.Enabled = False
            '        Me.RibbonVendedores.Enabled = False
            '        Me.RibbonProveedores.Enabled = True
            '        Me.RibbonProductos.Enabled = True : Me.RibbonProductos1.Enabled = True
            '        Me.RibbonLineaProductos.Enabled = True
            '        Me.RibbonEnsamble.Enabled = True
            '        Me.RibbonCtasXPagar.Enabled = False
            '        Me.RibbonCtasxCobrar.Enabled = False : Me.RibbonCtasXCobrar1.Enabled = False
            '        Me.RibbonBodegas.Enabled = False
            '        Me.RibbonArqueo.Enabled = False
            '        Me.RibbonReporteVentasCompras.Enabled = False
            '        Me.RibbonFacturacion.Enabled = True : Me.RibbonFacturacion1.Enabled = True
            '        Me.RibbonPagos.Enabled = False
            '        Me.RibbonArqueo.Enabled = False
            '        Me.RibbonClietes.Enabled = True : Me.RibbonClietes1.Enabled = True
            '        Me.RibbonRecibos.Enabled = False
            '    End If
            'End If


            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("CodigoClienteNumerico")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("CodigoClienteNumerico") = True Then
                    CodigoClienteNumero = True
                Else
                    CodigoClienteNumero = False
                End If
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("SincronizarTasa")) Then
                If DataSet.Tables("DatosEmpresa").Rows(0)("SincronizarTasa") = True Then
                    ExisteConexion = ValidarConexionContable(Now)
                    If TasaCambio = 0 Then
                        If ExisteConexion = True Then
                            TasaCambio = BuscaTasaCambioContabilidad(Now)
                        End If

                        If TasaCambio = 0 Then
                            MsgBox("No Existe Tasa de Cambio en el Sistema Contable", MsgBoxStyle.Critical, "Zeus Facturacion")
                            My.Forms.FrmTasaCambio.ShowDialog()
                        Else

                            '/////////////////SI EN EL SISTEMA CONTABLE EXISTE LA TABLA LA GRABO/////////////////////////////////////////



                            FechaInicio = DateSerial(Year(Now), Month(Now), 1)
                            FechaFin = DateSerial(Year(Now), Month(Now) + 1, 0)
                            FechaBusca = DateSerial(Year(Now), Month(Now), 1)
                            Fecha = Format(FechaInicio, "yyyy-MM-dd")
                            FechaTasa = Format(FechaInicio, "dd/MM/yyyy")
                            i = 1
                            Monto = TasaCambio

                            Do While FechaFin >= FechaBusca
                                TasaCambio = BuscaTasaCambioContabilidad(FechaBusca)

                                My.Application.DoEvents()

                                If Val(TasaCambio) <> 0 Then
                                    Monto = TasaCambio
                                    '////////////////////////////////////RECORRO TODO EL MES PARA GRABAR TODAS LAS TASAS ////////////////////////

                                    SQl = "SELECT *  FROM TasaCambio WHERE (FechaTasa = CONVERT(DATETIME, '" & Fecha & "', 102))"
                                    DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
                                    DataAdapter.Fill(DataSet, "Consulta")
                                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                                        If Monto <> 0 Then
                                            MiConexion.Close()
                                            StrSqlUpdate = "UPDATE [TasaCambio] SET [MontoTasa] = '" & Monto & "' WHERE (FechaTasa = CONVERT(DATETIME, '" & Fecha & "', 102))"
                                            MiConexion.Open()
                                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                                            iResultado = ComandoUpdate.ExecuteNonQuery
                                            MiConexion.Close()
                                        End If

                                    Else
                                        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                                        If Monto <> 0 Then
                                            MiConexion.Close()
                                            StrSqlUpdate = "INSERT INTO [TasaCambio] ([FechaTasa],[MontoTasa]) " & _
                                                           "VALUES ('" & FechaTasa & "','" & Monto & "')"
                                            MiConexion.Open()
                                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                                            iResultado = ComandoUpdate.ExecuteNonQuery
                                            MiConexion.Close()
                                        End If

                                    End If
                                    DataSet.Tables("Consulta").Reset()

                                End If


                                i = i + 1
                                FechaBusca = DateSerial(Year(FechaBusca), Month(FechaBusca), i)
                                Fecha = Format(FechaBusca, "yyyy-MM-dd")
                                FechaTasa = Format(FechaBusca, "dd/MM/yyyy")
                            Loop

                        End If
                    End If
                Else
                    '/////////////////// SI NO SE SINCRONIZA, VERIFICO SI TIENE LA TASA ////////////////////////
                    If TasaCambio = 0 Then
                        ExisteConexion = False
                        MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Zeus Facturacion")
                        My.Forms.FrmTasaCambio.ShowDialog()
                    End If
                End If
            End If
        End If
        'End If


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Valor")) Then
                If Not DataSet.Tables("DatosEmpresa").Rows(0)("Valor") = "" Then
                    Cadena2 = DataSet.Tables("DatosEmpresa").Rows(0)("Valor")
                    Cadena2 = Decrypt(Cadena2)
                End If
            End If

            Dim Cadena As String = "", CadenaDiv() As String, Max As Double, InstanciaDiv() As String, Instancia As String = ""

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////BUSCO LA INSTANCIA DE LA BASE DE DATOS QUE SE CONECTO ///////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CadenaDiv = Conexion.Split(";")
            Max = UBound(CadenaDiv)
            i = 0
            For i = 0 To Max
                Cadena = CadenaDiv(i).IndexOf("Source")
                If Cadena <> -1 Then  '/////////////////SI NO LO ENCUNTRA ES IGUAL A MENOS UNO ////////////////
                    InstanciaDiv = CadenaDiv(i).Split("=")
                    Instancia = Trim(InstanciaDiv(1))
                Else
                    '////////////////////////7BUSCO LA PALABRA SI ESTA MINUSCULA /////////////////////////////////////
                    Cadena = CadenaDiv(i).IndexOf("source")
                    If Cadena <> -1 Then  '/////////////////SI NO LO ENCUNA ES IGUAL A MENOS UNO ////////////////
                        InstanciaDiv = CadenaDiv(i).Split("=")
                        Instancia = Trim(InstanciaDiv(1))
                    End If
                End If

            Next

            '////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////BUSCO SI LA INSTANCIA ESTA REGISTRADA //////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////
            'Cadena2 = "JUANBERMUDEZ\SQL2005;F1C784F5-F935-4BC6-9BBE-4C29F9407560;Siempre;30"
            'If Cadena2.IndexOf(Instancia) <> -1 Then


            'Else
            '    MsgBox("No Tiene Registro de Licencia", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            '    Me.Close()

            'End If

            'JUANBERMUDEZ\SQL2005;F1C784F5-F935-4BC6-9BBE-4C29F9407560;Siempre;30
            'JUANBERMUDEZ\SQL2005;F1C784F5-F935-4BC6-9BBE-4C29F9407560;Demo;30
            'JUANBERMUDEZ\SQL2005;F1C784F5-F935-4BC6-9BBE-4C29F9407560;Renta;30



            'Cadena = Encrypt("Siempre")

            '¯°±ž  ABC0
            'Á×ÓÛÞàÓ  Siempre

            'If Cadena2 <> "Siempre" Then
            '    If Cadena2 = "" Then
            '        MsgBox("Licencia Demo ha Caducado!!!!", vbCritical, " Demos")
            '        Me.Close()
            '    Else
            '        If CDbl(Mid(Cadena2, 4, 9)) > 9600 Then
            '            MsgBox("Licencia Demo ha Caducado!!!!", vbCritical, " Demos")
            '            Me.Close()
            '        End If
            '    End If



            'End If

            FechaIngreso = Now

        End If
    End Sub

    Private Sub RibbonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonProyectos.Click
        My.Forms.FrmProyectos.MdiParent = Me
        My.Forms.FrmProyectos.Show()
    End Sub

    Private Sub RibbonPerfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPerfiles.Click
        My.Forms.FrmAccesos.MdiParent = Me
        My.Forms.FrmAccesos.Show()
    End Sub

    Private Sub RibbonActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonActualizacion.Click
        Dim Directorio As String, RutaUpdate As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim objStreamReader As StreamReader
        Dim objStreamWriter As StreamWriter
        Dim strLine As String

        Try

            Sql = "SELECT *  FROM DatosEmpresa "
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    If Dir(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) <> "" Then

                        '---------------------------------------------------------------------------------------------
                        '------------------------BORRO EL ARCHIVO ----------------------------------------------------
                        '---------------------------------------------------------------------------------------------

                        RutaUpdate = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                        objStreamReader = New StreamReader(My.Application.Info.DirectoryPath + "\RutaUpdate.dll")
                        strLine = objStreamReader.ReadLine
                        Do While Not strLine Is Nothing

                            'Write the line to the Console window.
                            objStreamWriter.WriteLine("")


                            'Read the next line.
                            strLine = objStreamReader.ReadLine 'LEO LA LINEA

                        Loop

                        '---------------------------------------------------------------------------------------------
                        '------------------------GRABO LA NUEVA RUTA ----------------------------------------------------
                        '---------------------------------------------------------------------------------------------
                        objStreamWriter.WriteLine(RutaUpdate)

                        Directorio = My.Application.Info.DirectoryPath & "\Actualizar.exe"
                        Directorio = Shell(Directorio, vbNormalFocus)
                        objStreamReader.Close()
                        Me.Close()
                    Else
                        MsgBox("NO existe el Archivo en la Ruta Indicada", vbCritical, "Zeus Contable")
                    End If
                Else
                    MsgBox("Seleccione una Ruta de Actualizacion", vbCritical, "Zeus Contable")
                End If
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub RibbonBodegas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonBodegas.Click
        My.Forms.FrmBodegas.MdiParent = Me
        My.Forms.FrmBodegas.Show()
    End Sub

    Private Sub RibbonTiposPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTiposPrecios.Click
        My.Forms.FrmTipoPrecios.MdiParent = Me
        My.Forms.FrmTipoPrecios.Show()
    End Sub

    Private Sub RibbonTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonTareas.Click
        My.Forms.FrmTareas.MdiParent = Me
        My.Forms.FrmTipoPrecios.Show()
    End Sub

    Private Sub RibbonNotaDebitoCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonNotaDebitoCredito.Click
        My.Forms.FrmNotaDebito.MdiParent = Me
        My.Forms.FrmNotaDebito.Show()
    End Sub

    Private Sub RibbonReporteGraficos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteGraficos.Click
        Quien = "Reporte Grafico"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonRecibos1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RibbonRecibos1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonRecibos1.Click
        My.Forms.FrmRecibos.MdiParent = Me
        My.Forms.FrmRecibos.Show()
    End Sub

    Private Sub RibbonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUsuarios.Click
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub RibbonPerfiles1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonPerfiles1.Click
        My.Forms.FrmAccesos.MdiParent = Me
        My.Forms.FrmAccesos.Show()
    End Sub

    Private Sub RibbonUsuarioActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonUsuarioActual.Click
        My.Forms.FrmInformacion.MdiParent = Me
        My.Forms.FrmInformacion.Show()
    End Sub


    Private Sub RibbonButtonRespaldar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButtonRespaldar.Click
        My.Forms.frmDBBackup.MdiParent = Me
        My.Forms.frmDBBackup.Show()
    End Sub

    Private Sub RibbonButtonRespaldar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButtonRespaldar1.Click
        My.Forms.frmDBBackup.MdiParent = Me
        My.Forms.frmDBBackup.Show()
    End Sub

    Private Sub RibbonReporteGraficos1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonReporteGraficos1.Click
        Quien = "Reporte Excel"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RibbonButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton1.Click
        My.Forms.FrmLotesInfo.ShowDialog()
    End Sub

    Private Sub RibbonButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RibbonRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonRecepcion.Click
        Quien = "Recepcion"
        My.Forms.FrmRecepcion.Show()
    End Sub

    Private Sub RibbonSalidaBascula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonSalidaBascula.Click
        Quien = "SalidaBascula"
        My.Forms.FrmRecepcion.Show()

    End Sub

    Private Sub RibbonGroup12_DialogLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonGroup12.DialogLauncherClick

    End Sub

    Private Sub RibbonButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonVehiculo.Click
        My.Forms.FrmVehiculo.MdiParent = Me
        My.Forms.FrmVehiculo.Show()
    End Sub

    Private Sub RibbonConductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonConductor.Click
        My.Forms.FrmConductor.MdiParent = Me
        My.Forms.FrmConductor.Show()
    End Sub

    Private Sub RibbonButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton4.Click
        Quien = "Repesaje"
        My.Forms.FrmInventarioFisico.MdiParent = Me
        My.Forms.FrmInventarioFisico.Show()

        '
    End Sub
End Class
