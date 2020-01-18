Imports System.Windows.Forms
Imports System.IO

Public Class MDIParent1
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Agregar código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregar código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del primario.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub MDIParent1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Demo(Now)
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim TasaCambio As Double, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Fecha As String
        Dim FechaTasa As String, Monto As Double, FechaInicio As Date, FechaFin As Date, FechaBusca As Date, i As Double
        Dim SqlDatos As String, Cadena2 As String = "", Registros As Double = 0




        TasaCambio = BuscaTasaCambio(Now)

        Me.ToolStripMenuItem5.Text = NombreCliente
        Me.NavBarClientes.Caption = NombreCliente
        Me.Text = "Nombre Compañia: " & NombreCompañia

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////CIERRO TODAS LAS OPCIONES QUE EL PERFIL NO TIENE ACCESO /////////////////////////////////////////////
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

                Case "Personalizar" : Me.NavBarPersonalizar.Enabled = False
                Case "Perfiles y Accesos" : Me.NavBarPerfiles.Enabled = False
                Case "Ajustes" : Me.NavBarActualiza.Enabled = False
                Case "Actualizacion" : Me.NavBarActualizacion.Enabled = False
                Case "Inventario Fisico" : Me.NavBarInventarioFisico.Enabled = False
                Case "Configurar" : Me.NavBarConfigurar.Enabled = False : Me.MenuGenerar.Enabled = False
                Case "Exportar a Excel" : Me.NavBarExportar.Enabled = False
                Case "Importacion" : Me.NavBarImportacion.Enabled = False
                Case "Usuarios" : Me.NavBarItem2.Enabled = False : Me.ToolStripMenuItem7.Enabled = False
                Case "Reportes Inventario" : Me.NavBarInventario.Enabled = False
                Case "Reportes Ventas/Compras" : Me.NavBarVentas.Enabled = False
                Case "Reportes Generales" : Me.NavBarGeneral.Enabled = False
                Case "Reportes Cuentas x Cobrar" : NavBarCtasPagar.Enabled = False
                Case "Plantilla Ventas/Compras" : Me.NavBarPlantillas.Enabled = False
                Case "Historico Facturacion" : Me.NavBarHistoricoFactura.Enabled = False
                Case "Historico Compras" : Me.NavBarHistoricoCompra.Enabled = False
                Case "Tareas" : Me.NavBarTareas.Enabled = False
                Case "Cajeros" : Me.NavBarCajero.Enabled = False
                Case "Transferencia de Bodegas" : Me.NavBarTransferencias.Enabled = False
                Case "Tipos de Precios" : Me.NavBarTipoPrecio.Enabled = False
                Case "Tasa de Cambio" : Me.NavBarTasaCambio.Enabled = False
                Case "Servicios" : Me.NavBarServicio.Enabled = False : Me.ToolStripMenuServicio.Enabled = False
                Case "Rubros" : Me.NavBarRubros.Enabled = False
                Case "Proyectos" : Me.Proyectos.Enabled = False
                Case "Notas de Debito y Credito" : Me.NavBarNotaDebito.Enabled = False
                Case "Impuestos" : Me.NavBarItem4.Enabled = False
                Case "Liquidacion" : Me.NavBarLiquidacion.Enabled = False : Me.ToolStripMenuItem1.Enabled = False
                Case "Arqueo de Caja" : Me.NavBarArqueo.Enabled = False
                Case "Vendedores" : Me.Vendedores.Enabled = False
                Case "Proveedores" : Me.NavBarProveedores.Enabled = False
                Case "Productos" : Me.NavBarProductos.Enabled = False : Me.ToolStripMenuItem6.Enabled = False
                Case "Linea Produtos" : Me.NavBarLinea.Enabled = False
                Case "Ensamble" : Me.NavBarEnsamble.Enabled = False
                Case "Ctas x Pagar" : Me.NavBarCuentasXPagar.Enabled = False
                Case "Ctas x Cobrar" : Me.NavBarCuentasXCobrar.Enabled = False
                Case "Bodegas" : Me.NavBarMultiBodega.Enabled = False
                Case "Arqueo de Caja" : Me.NavBarArqueo.Enabled = False
                Case "Compras" : Me.NavBarCompras.Enabled = False
                Case "Facturacion" : Me.NavBarFacturacion.Enabled = False
                Case "Pagos" : Me.NavBarPagos.Enabled = False
                Case "Recibo de Caja" : Me.NavBarRecibo.Enabled = False
                Case "Clientes" : Me.NavBarClientes.Enabled = False : Me.ToolStripMenuItem5.Enabled = False

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



        'Select Case Acceso
        '    Case "Contador"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarCompras.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarClientes.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        Me.NavBarProductos.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.Vendedores.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False

        '    Case "Bodeguero"
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        'Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarClientes.Enabled = False
        '        Me.Vendedores.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarCuentasXCobrar.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False

        '    Case "Bodeguero2"
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        'Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarClientes.Enabled = False
        '        Me.Vendedores.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarCuentasXCobrar.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False
        '        Me.NavBarGeneral.Enabled = False
        '        Me.NavBarVentas.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False


        '    Case "Vendedores"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuServicio.Enabled = False
        '        'Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        Me.NavBarCompras.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        'Me.NavBarProductos.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False
        '        Me.NavBarGeneral.Enabled = False
        '        Me.NavBarInventario.Enabled = False
        '        Me.NavBarVentas.Enabled = False
        '        Me.NavBarTransferencias.Enabled = False
        '        Me.NavBarRubros.Enabled = False
        '        Me.NavBarTipoPrecio.Enabled = False
        '        Me.NavBarActualiza.Enabled = False
        '        Me.NavBarCuentasXCobrar.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False
        '        Me.NavBarHistoricoCompra.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarTareas.Enabled = False
        '        Me.NavBarNotaDebito.Enabled = False
        '        Me.NavBarImportacion.Enabled = False

        '    Case "Jefe de Tienda"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuServicio.Enabled = False
        '        'Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        'Me.NavBarCompras.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        'Me.NavBarProductos.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False
        '        Me.NavBarGeneral.Enabled = False
        '        Me.NavBarInventario.Enabled = False
        '        Me.NavBarVentas.Enabled = False
        '        Me.NavBarTransferencias.Enabled = False
        '        Me.NavBarRubros.Enabled = False
        '        Me.NavBarTipoPrecio.Enabled = False
        '        Me.NavBarActualiza.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False
        '        Me.NavBarHistoricoCompra.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarTareas.Enabled = False
        '        Me.NavBarNotaDebito.Enabled = False
        '        Me.NavBarImportacion.Enabled = False

        '    Case "Vendedores 2"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuServicio.Enabled = False
        '        'Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        Me.NavBarCompras.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        'Me.NavBarProductos.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False
        '        Me.NavBarGeneral.Enabled = False
        '        Me.NavBarInventario.Enabled = False
        '        Me.NavBarVentas.Enabled = False
        '        Me.NavBarTransferencias.Enabled = False
        '        Me.NavBarRubros.Enabled = False
        '        Me.NavBarTipoPrecio.Enabled = False
        '        Me.NavBarActualiza.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False
        '        Me.NavBarHistoricoCompra.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarTareas.Enabled = False
        '        Me.NavBarNotaDebito.Enabled = False
        '        Me.NavBarImportacion.Enabled = False

        '    Case "Cuentas x Cobrar"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        'Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuServicio.Enabled = False
        '        Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        Me.NavBarCompras.Enabled = False
        '        Me.NavBarPagos.Enabled = False
        '        Me.NavBarRecibo.Enabled = False
        '        Me.NavBarArqueo.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        Me.NavBarProductos.Enabled = False
        '        Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarCajero.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False
        '        Me.NavBarGeneral.Enabled = False
        '        Me.NavBarInventario.Enabled = False
        '        Me.NavBarVentas.Enabled = True
        '        Me.NavBarTransferencias.Enabled = False
        '        Me.NavBarRubros.Enabled = False
        '        Me.NavBarTipoPrecio.Enabled = False
        '        Me.NavBarActualiza.Enabled = False
        '        Me.NavBarCuentasXPagar.Enabled = False
        '        Me.NavBarHistoricoCompra.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarTareas.Enabled = False
        '        Me.NavBarNotaDebito.Enabled = False
        '        Me.NavBarImportacion.Enabled = False
        '        Me.Vendedores.Enabled = False



        '    Case "Cajeros"
        '        Me.ToolStripMenuItem1.Enabled = False
        '        Me.ToolStripMenuItem5.Enabled = False
        '        Me.ToolStripMenuItem6.Enabled = False
        '        Me.MenuGenerar.Enabled = False
        '        Me.NavBarFacturacion.Enabled = False
        '        Me.NavBarCompras.Enabled = False
        '        Me.NavBarEnsamble.Enabled = False
        '        Me.NavBarClientes.Enabled = False
        '        Me.NavBarProveedores.Enabled = False
        '        Me.NavBarMultiBodega.Enabled = False
        '        Me.NavBarProductos.Enabled = False
        '        Me.NavBarLinea.Enabled = False
        '        Me.Vendedores.Enabled = False
        '        Me.NavBarItem4.Enabled = False
        '        Me.NavBarTasaCambio.Enabled = False
        '        Me.NavBarServicio.Enabled = False
        '        Me.NavBarConfigurar.Enabled = False
        '        Me.NavBarPersonalizar.Enabled = False
        '        Me.NavBarInventarioFisico.Enabled = False
        '        Me.NavBarLiquidacion.Enabled = False
        'End Select

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



            'Cadena = Encrypt("Siempre")

            '¯°±ž  ABC0
            'Á×ÓÛÞàÓ  Siempre

            If Cadena2 <> "Siempre" Then
                If Cadena2 = "" Then
                    MsgBox("Licencia Demo ha Caducado!!!!", vbCritical, " Demos")
                    Me.Close()
                Else
                    If CDbl(Mid(Cadena2, 4, 9)) > 9600 Then
                        MsgBox("Licencia Demo ha Caducado!!!!", vbCritical, " Demos")
                        Me.Close()
                    End If
                End If



            End If

            FechaIngreso = Now

        End If


    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NavBarControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarControl.Click

    End Sub

    Private Sub NavBarFacturacion_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarFacturacion.LinkClicked
        My.Forms.FrmFacturas.MdiParent = Me
        My.Forms.FrmFacturas.Show()
    End Sub

    Private Sub NavBarProductos_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarProductos.LinkClicked
        My.Forms.FrmProductos.MdiParent = Me
        My.Forms.FrmProductos.Show()
    End Sub

    Private Sub MenuGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuGenerar.Click
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub NavBarConfigurar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarConfigurar.LinkClicked
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub NavBarItem2_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem2.LinkClicked
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub NavBarProveedores_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarProveedores.LinkClicked
        My.Forms.FrmProveedores.MdiParent = Me
        My.Forms.FrmProveedores.Show()
    End Sub

    Private Sub NavBarLinea_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarLinea.LinkClicked
        My.Forms.FrmLineaProductos.MdiParent = Me
        My.Forms.FrmLineaProductos.Show()
    End Sub

    Private Sub NavBarItem4_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem4.LinkClicked
        My.Forms.FrmImpuestos.MdiParent = Me
        My.Forms.FrmImpuestos.Show()
    End Sub

    Private Sub NavBarClientes_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarClientes.LinkClicked
        My.Forms.FrmClientes.MdiParent = Me
        My.Forms.FrmClientes.Show()
    End Sub

    Private Sub Vendedores_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles Vendedores.LinkClicked
        My.Forms.FrmVendedor.MdiParent = Me
        My.Forms.FrmVendedor.Show()
    End Sub


    Private Sub NavBarTasaCambio_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarTasaCambio.LinkClicked
        My.Forms.FrmTasaCambio.MdiParent = Me
        My.Forms.FrmTasaCambio.Show()
    End Sub

    Private Sub NavBarProcesos_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarProcesos.ItemChanged
        If Me.NavBarProcesos.Expanded = True Then
            Me.Catalogos.Expanded = False
            Me.NavBarReportes.Expanded = False
            Me.NavBarOpciones.Expanded = False
            Me.NavBarHistoricos.Expanded = False

        End If
    End Sub

    Private Sub Catalogos_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Catalogos.ItemChanged
        If Me.Catalogos.Expanded = True Then
            Me.NavBarProcesos.Expanded = False
            Me.NavBarReportes.Expanded = False
            Me.NavBarOpciones.Expanded = False
            Me.NavBarHistoricos.Expanded = False
        End If
    End Sub

    Private Sub NavBarReportes_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarReportes.ItemChanged
        If Me.NavBarReportes.Expanded = True Then
            Me.NavBarProcesos.Expanded = False
            Me.Catalogos.Expanded = False
            Me.NavBarOpciones.Expanded = False
            Me.NavBarHistoricos.Expanded = False
        End If
    End Sub

    Private Sub NavBarOpciones_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarOpciones.ItemChanged
        If Me.NavBarOpciones.Expanded = True Then
            Me.NavBarProcesos.Expanded = False
            Me.Catalogos.Expanded = False
            Me.NavBarReportes.Expanded = False
            Me.NavBarHistoricos.Expanded = False
        End If
    End Sub


 
    Private Sub NavBarPersonalizar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarPersonalizar.LinkClicked
        My.Forms.FrmPersonalizar.MdiParent = Me
        My.Forms.FrmPersonalizar.Show()
    End Sub

    Private Sub NavBarInventarioFisico_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarInventarioFisico.LinkClicked
        My.Forms.FrmInventarioFisico.MdiParent = Me
        My.Forms.FrmInventarioFisico.Show()
    End Sub

    Private Sub NavBarMultiBodega_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarMultiBodega.LinkClicked
        My.Forms.FrmBodegas.MdiParent = Me
        My.Forms.FrmBodegas.Show()
    End Sub

    Private Sub NavBarEnsamble_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarEnsamble.LinkClicked
        My.Forms.FrmEnsamble.MdiParent = Me
        My.Forms.FrmEnsamble.Show()
    End Sub

    Private Sub NavBarCompras_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarCompras.LinkClicked
        My.Forms.FrmCompras.MdiParent = Me
        My.Forms.FrmCompras.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        My.Forms.FrmClientes.MdiParent = Me
        My.Forms.FrmClientes.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        My.Forms.FrmProductos.MdiParent = Me
        My.Forms.FrmProductos.Show()
    End Sub

    Private Sub NavBarPagos_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarPagos.LinkClicked
        My.Forms.FrmPagos.MdiParent = Me
        My.Forms.FrmPagos.Show()
    End Sub

    Private Sub NavBarRecibo_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarRecibo.LinkClicked
        My.Forms.FrmRecibos.MdiParent = Me
        My.Forms.FrmRecibos.Show()
    End Sub

    Private Sub NavBarArqueo_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarArqueo.LinkClicked
        My.Forms.FrmArqueo.MdiParent = Me
        My.Forms.FrmArqueo.Show()
    End Sub

    Private Sub NavBarCajero_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarCajero.LinkClicked
        My.Forms.FrmCajeros.MdiParent = Me
        My.Forms.FrmCajeros.Show()
    End Sub

    Private Sub NavBarGeneral_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarGeneral.LinkClicked
        Quien = "Reporte General"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub NavBarInventario_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarInventario.LinkClicked
        Quien = "Reporte Inventario"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub OpcionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcionesToolStripMenuItem.Click
        Dim RutaReportes As String
        RutaReportes = My.Application.Info.DirectoryPath & "\Calculadora.exe"

        If Dir(RutaReportes) = "Calculadora.exe" Then
            Shell(RutaReportes)
        Else
            MsgBox("No existe la Calculadora", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub NavBarActualiza_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarActualiza.LinkClicked
        My.Forms.FrmActualiza.MdiParent = Me
        My.Forms.FrmActualiza.Show()
    End Sub

    Private Sub NavBarLiquidacion_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarLiquidacion.LinkClicked
        My.Forms.FrmLiquidacion.MdiParent = Me
        My.Forms.FrmLiquidacion.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        My.Forms.FrmLiquidacion.MdiParent = Me
        My.Forms.FrmLiquidacion.Show()
    End Sub

    Private Sub NavBarServicio_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarServicio.LinkClicked
        My.Forms.FrmServicios.MdiParent = Me
        My.Forms.FrmServicios.Show()
    End Sub

    Private Sub ToolStripMenuServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuServicio.Click
        My.Forms.FrmServicios.MdiParent = Me
        My.Forms.FrmServicios.Show()
    End Sub


    Private Sub NavBarHistoricos_ItemChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarHistoricos.ItemChanged
        If Me.NavBarHistoricos.Expanded = True Then
            Me.NavBarProcesos.Expanded = False
            Me.Catalogos.Expanded = False
            Me.NavBarReportes.Expanded = False
            Me.NavBarOpciones.Expanded = False

        End If
    End Sub

    Private Sub NavBarHistoricoFactura_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarHistoricoFactura.LinkClicked
        My.Forms.FrmFacturasHistoricos.MdiParent = Me
        My.Forms.FrmFacturasHistoricos.Show()
    End Sub

    Private Sub NavBarHistoricoCompra_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarHistoricoCompra.LinkClicked
        My.Forms.FrmComprasHistorico.MdiParent = Me
        My.Forms.FrmComprasHistorico.Show()
    End Sub

    Private Sub NavBarPlantillas_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarPlantillas.LinkClicked
        My.Forms.FrmPlantillas.MdiParent = Me
        My.Forms.FrmPlantillas.Show()
    End Sub

    Private Sub NavBarVentas_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarVentas.LinkClicked
        Quien = "Reporte Ventas"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub NavBarRubros_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarRubros.LinkClicked
        My.Forms.FrmRubros.MdiParent = Me
        My.Forms.FrmRubros.Show()
    End Sub


    Private Sub NavBarTareas_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarTareas.LinkClicked
        My.Forms.FrmTareas.MdiParent = Me
        My.Forms.FrmTareas.Show()
    End Sub

    Private Sub NavBarTransferencias_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarTransferencias.LinkClicked
        My.Forms.FrmTransferenciaListado.MdiParent = Me
        My.Forms.FrmTransferenciaListado.Show()

    End Sub

    Private Sub NavBarTipoPrecio_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarTipoPrecio.LinkClicked
        My.Forms.FrmTipoPrecios.MdiParent = Me
        My.Forms.FrmTipoPrecios.Show()
    End Sub

    Private Sub NavBarImportacion_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarImportacion.LinkClicked
        My.Forms.FrmImportacion.MdiParent = Me
        My.Forms.FrmImportacion.Show()
    End Sub

    Private Sub NavBarCuentasXCobrar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarCuentasXCobrar.LinkClicked
        My.Forms.FrmCuentasXCobrar.MdiParent = Me
        My.Forms.FrmCuentasXCobrar.Show()
    End Sub

    Private Sub NavBarNotaDebito_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarNotaDebito.LinkClicked
        My.Forms.FrmNotaDebito.MdiParent = Me
        My.Forms.FrmNotaDebito.Show()
    End Sub

    Private Sub NavBarCuentasXPagar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarCuentasXPagar.LinkClicked
        My.Forms.FrmCuentasXPagar.MdiParent = Me
        My.Forms.FrmCuentasXPagar.Show()
    End Sub


    Private Sub NavBarActualizacion_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarActualizacion.LinkClicked
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

    Private Sub NavBarCtasPagar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarCtasPagar.LinkClicked
        Quien = "Reporte Cuentas x Cobrar"
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub Proyectos_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles Proyectos.LinkClicked
        My.Forms.FrmProyectos.MdiParent = Me
        My.Forms.FrmProyectos.Show()
    End Sub

    Private Sub NavBarExportar_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarExportar.LinkClicked
        My.Forms.FrmExportar.MdiParent = Me
        My.Forms.FrmExportar.Show()
    End Sub

    Private Sub NavBarPerfiles_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarPerfiles.LinkClicked
        My.Forms.FrmAccesos.MdiParent = Me
        My.Forms.Frmaccesos.Show()
    End Sub

    Private Sub NavBarPerfiles_LinkPressed(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarPerfiles.LinkPressed

    End Sub

    Private Sub NavBarPerfiles_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarPerfiles.ItemChanged

    End Sub
End Class
