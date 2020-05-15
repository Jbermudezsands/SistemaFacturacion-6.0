Public Class FrmAccesos


    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Sub ActualizarLista()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String
        Dim Iposicion As Double = 0

        Me.ListBox.Items.Clear()

        SqlString = "SELECT *  FROM Perfil"
        DataSet.Reset()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")
        Iposicion = 0
        Do While DataSet.Tables("Perfil").Rows.Count > Iposicion
            Me.ListBox.Items.Add(DataSet.Tables("Perfil").Rows(Iposicion)("NombrePerfil"))

            Iposicion = Iposicion + 1
        Loop
        MiConexion.Close()
    End Sub
    Public Sub GrabaAccesos(ByVal IdPerfil As Double, ByVal Modulo As String, ByVal Acceso As String)
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        SQLClientes = "SELECT *  FROM Accesos WHERE (IdPerfil = " & IdPerfil & ") AND (Modulo = '" & Modulo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")
        If DataSet.Tables("Perfil").Rows.Count = 0 Then
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Accesos] ([IdPerfil],[Modulo],[Acceso]) VALUES (" & IdPerfil & ", '" & Modulo & "' , '" & Acceso & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "UPDATE [Accesos] SET [Acceso] = '" & Acceso & "'  WHERE (IdPerfil = " & IdPerfil & ") AND (Modulo = '" & Modulo & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If
    End Sub



    Private Sub FrmControlPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String
        Dim Iposicion As Double = 0

        SqlString = "SELECT *  FROM Perfil"
        DataSet.Reset()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")
        Iposicion = 0
        Do While DataSet.Tables("Perfil").Rows.Count > Iposicion
            Me.ListBox.Items.Add(DataSet.Tables("Perfil").Rows(Iposicion)("NombrePerfil"))

            Iposicion = Iposicion + 1
        Loop
        MiConexion.Close()


        ''-----------------------------AGREGO LOS USUARIOS A LA LISTA --------------------------------
        ''--------------------------------------------------------------------------------------------
        'SqlString = "SELECT  Usuarios.* FROM Usuarios "
        'DataSet.Reset()
        'MiConexion.Open()
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Usuarios")
        'Iposicion = 0
        'Do While DataSet.Tables("Usuarios").Rows.Count >= Iposicion
        '    Me.ListBoxOpciones.Items.Add(DataSet.Tables("Usuarios").Rows(Iposicion)("Usuario"))

        '    Iposicion = Iposicion + 1
        'Loop
        'MiConexion.Close()




        Me.ListBoxOpciones.Items.Add("Facturacion")
        Me.ListBoxOpciones.Items.Add("Cotizacion")
        Me.ListBoxOpciones.Items.Add("Devolucion de Venta")
        Me.ListBoxOpciones.Items.Add("Salida Bodega")
        Me.ListBoxOpciones.Items.Add("Orden de Trabajo")
        Me.ListBoxOpciones.Items.Add("Compras")
        Me.ListBoxOpciones.Items.Add("Pagos")
        Me.ListBoxOpciones.Items.Add("Recibo de Caja")
        Me.ListBoxOpciones.Items.Add("Ensamble")
        Me.ListBoxOpciones.Items.Add("Arqueo de Caja")
        Me.ListBoxOpciones.Items.Add("Ctas x Cobrar")
        Me.ListBoxOpciones.Items.Add("Ctas x Pagar")
        Me.ListBoxOpciones.Items.Add("Clientes")
        Me.ListBoxOpciones.Items.Add("Proveedores")
        Me.ListBoxOpciones.Items.Add("Productos")
        Me.ListBoxOpciones.Items.Add("Vendedores")
        Me.ListBoxOpciones.Items.Add("Bodegas")
        Me.ListBoxOpciones.Items.Add("Linea Produtos")
        Me.ListBoxOpciones.Items.Add("Impuestos")
        Me.ListBoxOpciones.Items.Add("Tasa de Cambio")
        Me.ListBoxOpciones.Items.Add("Servicios")
        Me.ListBoxOpciones.Items.Add("Cajeros")
        Me.ListBoxOpciones.Items.Add("Liquidacion")
        Me.ListBoxOpciones.Items.Add("Transferencia de Bodegas")
        Me.ListBoxOpciones.Items.Add("Rubros")
        Me.ListBoxOpciones.Items.Add("Tipos de Precios")
        Me.ListBoxOpciones.Items.Add("Notas de Debito y Credito")
        Me.ListBoxOpciones.Items.Add("Proyectos")
        Me.ListBoxOpciones.Items.Add("Tareas")
        Me.ListBoxOpciones.Items.Add("Historico Facturacion")
        Me.ListBoxOpciones.Items.Add("Historico Compras")
        Me.ListBoxOpciones.Items.Add("Plantilla Ventas/Compras")
        Me.ListBoxOpciones.Items.Add("Reportes Generales")
        Me.ListBoxOpciones.Items.Add("Reportes Ventas/Compras")
        Me.ListBoxOpciones.Items.Add("Reportes Inventario")
        Me.ListBoxOpciones.Items.Add("Reportes Cuentas x Cobrar")
        Me.ListBoxOpciones.Items.Add("Exportar a Excel")
        Me.ListBoxOpciones.Items.Add("Importacion")
        Me.ListBoxOpciones.Items.Add("Usuarios")
        Me.ListBoxOpciones.Items.Add("Configurar")
        Me.ListBoxOpciones.Items.Add("Ajustes")
        Me.ListBoxOpciones.Items.Add("Personalizar")
        Me.ListBoxOpciones.Items.Add("Inventario Fisico")
        Me.ListBoxOpciones.Items.Add("Actualizacion")
        Me.ListBoxOpciones.Items.Add("Perfiles y Accesos")




    End Sub

    Private Sub ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox.SelectedIndexChanged

        ConfiguracionAcceso(Me.ListBox.Text, Me.ListBoxOpciones.Text)
    End Sub

    Private Sub ListBoxOpciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxOpciones.SelectedIndexChanged
        Me.ChkAnular.Visible = False
        Me.ChkProcesar.Visible = False
        Me.ChkImprimir.Visible = False

        Me.ChkGrabar.Visible = True
        Me.ChkGrabar.Location = New Point(7, 43)
        Me.ChkGrabar.Text = "Grabar"
        Me.ChkProcesar.Visible = True
        Me.ChkProcesar.Location = New Point(7, 89)
        Me.ChkEliminar.Visible = True
        Me.ChkEliminar.Location = New Point(7, 66)
        Me.ChkEliminar.Text = "Eliminar"
        Me.ChkEditar.Visible = False
        Me.ChkCambiarBodega.Visible = False

        ListBox_SelectedIndexChanged(sender, e)
        Select Case Me.ListBoxOpciones.Text
            Case "Orden de Trabajo"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Salida Bodega"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Cotizacion"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Devolucion de Venta"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Facturacion"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Compras"
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 133)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True
            Case "Ensamble"
                Me.ChkProcesar.Visible = True

                Me.ChkImprimir.Visible = True
            Case "Arqueo de Caja"
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 66)

            Case "Ctas x Cobrar"
                Me.ChkGrabar.Text = "Consultar"
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)

            Case "Liquidacion"
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 89)
            Case "Transferencia de Bodegas"
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 89)
                Me.ChkCambiarBodega.Visible = True
                Me.ChkCambiarBodega.Location = New Point(7, 110)
                Me.ChkEditar.Visible = True

            Case "Historico Facturacion"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 43)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 66)

            Case "Historico Compras"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkAnular.Visible = True
                Me.ChkAnular.Location = New Point(7, 43)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 66)

            Case "Plantilla Ventas/Compras"
                Me.ChkGrabar.Visible = True
                Me.ChkGrabar.Location = New Point(7, 43)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkEliminar.Visible = True
                Me.ChkEliminar.Location = New Point(7, 66)
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkAnular.Visible = False

            Case "Reportes Generales"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Reportes Ventas/Compras"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Reportes Inventario"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Reportes Cuentas x Cobrar"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Exportar a Excel"
                Me.ChkGrabar.Visible = True
                Me.ChkGrabar.Location = New Point(7, 43)
                Me.ChkGrabar.Text = "Exportar"
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Importacion"
                Me.ChkGrabar.Visible = True
                Me.ChkGrabar.Location = New Point(7, 43)
                Me.ChkGrabar.Text = "Leer Archivo"
                Me.ChkProcesar.Visible = True
                Me.ChkEliminar.Location = New Point(7, 66)
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Configurar"
                Me.ChkGrabar.Visible = True
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Inventario Fisico"
                Me.ChkGrabar.Visible = True
                Me.ChkGrabar.Location = New Point(7, 43)
                Me.ChkProcesar.Visible = True
                Me.ChkProcesar.Location = New Point(7, 89)
                Me.ChkEliminar.Visible = True
                Me.ChkEliminar.Location = New Point(7, 66)
                Me.ChkEliminar.Text = "Iniciar"
                Me.ChkImprimir.Visible = True
                Me.ChkImprimir.Location = New Point(7, 110)
                Me.ChkAnular.Visible = False

            Case "Ajustes"
                Me.ChkGrabar.Visible = True
                Me.ChkGrabar.Text = "Iniciar"
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

            Case "Actualizacion"
                Me.ChkGrabar.Visible = False
                Me.ChkProcesar.Visible = False
                Me.ChkEliminar.Visible = False
                Me.ChkImprimir.Visible = False
                Me.ChkAnular.Visible = False

        End Select
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGrabar.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Forms.FrmAccesosAddPerfil.ShowDialog()
        ActualizarLista()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Cadena As String

        Cadena = "¿Esta segura de Elimnar el Perfil?" & vbLf
        Cadena = Cadena & " si existen usarios se eliminaran tambien con el Perfil"

        If MsgBox(Cadena, MsgBoxStyle.YesNo, "Zeus Facturacion") = MsgBoxResult.Yes Then

            SQLClientes = "SELECT  NombrePerfil FROM Perfil WHERE (NombrePerfil = '" & Me.ListBox.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Perfil")
            If Not DataSet.Tables("Perfil").Rows.Count = 0 Then
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [Perfil] WHERE (NombrePerfil = '" & Me.ListBox.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            SQLClientes = "SELECT  Nivel FROM Usuarios WHERE (Nivel = '" & Me.ListBox.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Usuarios")
            If Not DataSet.Tables("Usuarios").Rows.Count = 0 Then
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [Usuarios] WHERE (Nivel = '" & Me.ListBox.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            ActualizarLista()

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Cadena As String, IdPerfil As Double, Modulo As String

        '''''''''''''''''''''''---------------------------------------------------------------------------
        '--------------------BUSCO EL ID DE LOS PERFILES DE USUARIOS -------------------------------------
        '-------------------------------------------------------------------------------------------------

        Cadena = ""


        If Me.ChkAbrir.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Abrir"
            Else
                Cadena = "Abrir"
            End If
        Else
            Cadena = "NoAbrir"
        End If

        If Me.ChkGrabar.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Grabar"
            Else
                Cadena = "Grabar"
            End If
        Else
            Cadena = Cadena & "," & "NoGrabar"
        End If

        If Me.ChkEliminar.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Eliminar"
            Else
                Cadena = "Eliminar"
            End If
        Else
            Cadena = Cadena & "," & "NoEliminar"
        End If

        If Me.ChkAnular.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Anular"
            Else
                Cadena = "Anular"
            End If
        Else
            Cadena = Cadena & "," & "NoAnular"
        End If

        If Me.ChkProcesar.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Procesar"
            Else
                Cadena = "Procesar"
            End If
        Else
            Cadena = Cadena & "," & "NoProcesar"
        End If

        If Me.ChkImprimir.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Imprimir"
            Else
                Cadena = "Imprimir"
            End If
        Else
            Cadena = Cadena & "," & "NoImprimir"
        End If

        If Me.ChkEditar.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Editar"
            Else
                Cadena = "Editar"
            End If
        Else
            Cadena = Cadena & "," & "NoEditar"
        End If


        If Me.ChkCambiarBodega.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "CambiarBodega"
            Else
                Cadena = "CambiarBodega"
            End If
        Else
            Cadena = Cadena & "," & "NoCambiarBodega"
        End If


        If Me.ChkPrevio.Checked = True Then
            If Cadena <> "" Then
                Cadena = Cadena & "," & "Previo"
            Else
                Cadena = "Previo"
            End If
        Else
            Cadena = Cadena & "," & "NoPrevio"
        End If


        SQLClientes = "SELECT  * FROM Perfil WHERE (NombrePerfil = '" & Me.ListBox.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")





        If Not DataSet.Tables("Perfil").Rows.Count = 0 Then

            IdPerfil = DataSet.Tables("Perfil").Rows(0)("IdPerfil")
            Modulo = Me.ListBoxOpciones.Text

            '------------------------------------------------------------------------------------------
            '------------------------BUSCO SI ESTA GRABADO EN LA TABLA DE ACCESOS --------------------
            '---------------------------------------------------------------------------------------------
            SQLClientes = "SELECT  * FROM Accesos WHERE (IdPerfil = " & IdPerfil & ") AND (Modulo = '" & Modulo & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
            DataAdapter.Fill(DataSet, "Acceso")

            If Not DataSet.Tables("Acceso").Rows.Count = 0 Then

                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Accesos]  SET [Acceso] = '" & Cadena & "'  WHERE (IdPerfil = " & IdPerfil & ") AND (Modulo = '" & Modulo & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


                MsgBox("Registro Correcto !!", MsgBoxStyle.Critical, "Zeus Facturacion")
            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [Accesos] ([IdPerfil] ,[Modulo] ,[Acceso])" & _
                               "VALUES (" & IdPerfil & " , '" & Modulo & "',  '" & Cadena & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                MsgBox("Registro Correcto !!", MsgBoxStyle.Critical, "Zeus Facturacion")
            End If

        End If







    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class