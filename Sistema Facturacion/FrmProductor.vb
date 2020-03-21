Public Class FrmProductor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLProductor As String, FuentesAgua As Integer, Vivienda As Integer, TenenciaTierra As String = "Propia", Activo As Integer = 0, CausaIva As Integer = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, TieneContrato As Integer = 0

        If Me.OptFuenteSi.Checked = True Then
            FuentesAgua = 1
        Else
            FuentesAgua = 0
        End If

        If Me.OptViviendaSi.Checked = True Then
            Vivienda = 1
        Else
            Vivienda = 0
        End If

        If Me.OptTPropia.Checked = True Then
            TenenciaTierra = "Propia"
        End If

        If Me.OptTHerencia.Checked = True Then
            TenenciaTierra = "Herencia"
        End If

        If Me.OptTComprada.Checked = True Then
            TenenciaTierra = "Comprada"
        End If

        If Me.OptTReforma.Checked = True Then
            TenenciaTierra = "Reforma"
        End If

        If Me.OptTAlquilada.Checked = True Then
            TenenciaTierra = "Alquilada"
        End If

        If Me.OptTPrestada.Checked = True Then
            TenenciaTierra = "Prestada"
        End If


        If Me.ChkActivo.Checked = True Then
            Activo = 1
        End If

        If Me.ChkCausaIVA.Checked = True Then
            CausaIva = 1
        End If

        If Me.OptContratoSi.Checked = True Then
            TieneContrato = 1
        Else
            TieneContrato = 0
        End If




        SQLProductor = "SELECT *  FROM Productor WHERE (TipoProductor = 'Productor') AND (CodProductor ='" & Me.CboCodigoProductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductor, MiConexion)
        DataAdapter.Fill(DataSet, "Productor")
        If Not DataSet.Tables("Productor").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Productor] SET [NombreProductor] = '" & Me.TxtNombre.Text & "',[ApellidoProductor] = '" & Me.TxtApellidos.Text & "',[FechaAdmision] = '" & Me.DTFechaAdmision.Text & "',[FechaNacimiento] = '" & Me.DTFechaNacimientos.Text & "',[DireccionProductor] = '" & Me.TxtDireccion.Text & "',[Sexo] = '" & Me.CboSexo.Text & "',[CodEscolaridad] = '" & Me.CboEscolaridad.Columns(0).Text & "',[CodDepartamentos] = '" & Me.CboDepartamentos.Columns(0).Text & "',[CodCooperativa] = '" & Me.CboCooperativa.Columns(0).Text & "',[CodRuta] = '" & Me.CboRuta.Columns(0).Text & "',[NombreConyugue] = '" & Me.TxtNombreConyugue.Text & "',[NumeroHijos] = '" & Me.TxtNumeroHijos.Text & "',[Telefonos] = '" & Me.TxtTelefono.Text & "',[Fax] = '" & Me.TxtFax.Text & "',[CorreoElectronico] = '" & Me.TxtCorreoElectronico.Text & "',[Comunidad] = '" & Me.TxtComunidad.Text & "',[Edad] = '" & Me.TxtEdad.Text & "',[EstadoCivil] = '" & Me.TxtEstadoCivil.Text & "',[FuentesAgua] = " & FuentesAgua & ",[ViviendaPropia] = " & Vivienda & ",[DescripcionVivienda] = '" & Me.TxtVivienda.Text & "',[TenenciaTierra] = '" & TenenciaTierra & "' ,[AreadePasto] = '" & Me.TxtAreaPasto.Text & "',[CantidadVacas] = " & Val(Me.TxtCantidadVacas.Text) & ",[CantidadVaquillas] = " & Val(Me.TxtCantidadVaquillas.Text) & ",[CantidadBueyes] = " & Val(Me.TxtCantidadBueyes.Text) & ",[CantidadTerrenos] = " & Val(Me.TxtCantidadTerreno.Text) & " ,[CualEmpresa] = '" & Me.TxtCualEmpresa.Text & "',[Cod_Cuenta_Cliente] = '" & Me.TxtCtaxCobrar.Text & "',[Cod_Cuenta_Proveedor] = '" & Me.TxtCtaxPagar.Text & "',[Activo] = " & Activo & ",[CausaIVA] = " & CausaIva & ",[TieneContrato] = " & TieneContrato & ",[Cedula] = '" & Me.TxtNumeroCedula.Text & "'  WHERE  (CodProductor = '" & Me.CboCodigoProductor.Text & "') AND (TipoProductor = 'Productor')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Productor] ([CodProductor],[TipoProductor],[NombreProductor] ,[ApellidoProductor],[FechaAdmision],[FechaNacimiento],[DireccionProductor],[Sexo],[CodEscolaridad],[CodDepartamentos],[CodCooperativa],[CodRuta],[NombreConyugue],[NumeroHijos],[Telefonos],[Fax],[CorreoElectronico],[Comunidad],[Edad],[EstadoCivil],[FuentesAgua],[ViviendaPropia],[DescripcionVivienda],[TenenciaTierra],[AreadePasto],[CantidadVacas],[CantidadVaquillas],[CantidadBueyes],[CantidadTerrenos],[CualEmpresa],[Cod_Cuenta_Cliente],[Cod_Cuenta_Proveedor],[Activo],[CausaIVA],[TieneContrato],[Cedula]) " & _
                           "VALUES ('" & Me.CboCodigoProductor.Text & "','Productor','" & Me.TxtNombre.Text & "','" & Me.TxtApellidos.Text & "'," & Format(Me.DTFechaAdmision.Value, "yyyy/MM/dd") & "," & Format(Me.DTFechaNacimientos.Value, "yyyy/MM/dd") & ",'" & Me.TxtDireccion.Text & "','" & Me.CboSexo.Text & "','" & Me.CboEscolaridad.Columns(0).Text & "','" & Me.CboDepartamentos.Columns(0).Text & "','" & Me.CboCooperativa.Columns(0).Text & "','" & Me.CboRuta.Columns(0).Text & "','" & Me.TxtNombreConyugue.Text & "','" & Me.TxtNumeroHijos.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtFax.Text & "','" & Me.TxtCorreoElectronico.Text & "','" & Me.TxtComunidad.Text & "','" & Me.TxtEdad.Text & "','" & Me.TxtEstadoCivil.Text & "','" & FuentesAgua & "','" & Vivienda & "','" & Me.TxtVivienda.Text & "','" & TenenciaTierra & "','" & Me.TxtAreaPasto.Text & "','" & Me.TxtCantidadVacas.Text & "','" & Me.TxtCantidadVaquillas.Text & "','" & Me.TxtCantidadBueyes.Text & "','" & Me.TxtCantidadTerreno.Text & "','" & Me.TxtCualEmpresa.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtCtaxPagar.Text & "'," & Activo & "," & CausaIva & "," & TieneContrato & ",'" & Me.TxtNumeroCedula.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        SQLProductor = "SELECT *  FROM Productor WHERE (TipoProductor = 'Proveedor')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProductor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProductor.Text = ""
    End Sub

    Private Sub FrmProductor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        '///////////////////////////////////////ESCOLARIDAD///////////////////////////////////////////////////////////////////
        Sql = "SELECT dbo.Escolaridad.* FROM  dbo.Escolaridad"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Escolaridad")
        If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
            Me.CboEscolaridad.DataSource = DataSet.Tables("Escolaridad")
        End If
        Me.CboEscolaridad.Splits.Item(0).DisplayColumns("Nombre_Escolaridad").Width = 180


        '///////////////////////////////DEPARTAMENTOS///////////////////////////////////////////////////////////////////////////
        Sql = "SELECT dbo.Departamentos.* FROM  dbo.Departamentos"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Departamentos")
        If Not DataSet.Tables("Departamentos").Rows.Count = 0 Then
            Me.CboDepartamentos.DataSource = DataSet.Tables("Departamentos")
        End If
        Me.CboDepartamentos.Splits.Item(0).DisplayColumns("Nombre_Departamento").Width = 180

        '//////////////////////////COOPERATIVA//////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT dbo.Cooperativa.* FROM  dbo.Cooperativa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Cooperativa")
        If Not DataSet.Tables("Cooperativa").Rows.Count = 0 Then
            Me.CboCooperativa.DataSource = DataSet.Tables("Cooperativa")
        End If
        Me.CboCooperativa.Splits.Item(0).DisplayColumns("Nombre_Cooperativa").Width = 180


        '////////////////////////////////RUTA/////////////////////////////////////////////////////////////////
        Sql = "SELECT   CodRuta, Nombre_Ruta  FROM Ruta_Distribucion"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Ruta")
        If Not DataSet.Tables("Ruta").Rows.Count = 0 Then
            Me.CboRuta.DataSource = DataSet.Tables("Ruta")
        End If
        Me.CboRuta.Splits.Item(0).DisplayColumns("Nombre_Ruta").Width = 180


        Sql = "SELECT *  FROM Productor WHERE (TipoProductor = 'Productor')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Productor")
        If Not DataSet.Tables("Productor").Rows.Count = 0 Then
            Me.CboCodigoProductor.DataSource = DataSet.Tables("Productor")
        End If


    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoProductor.Text = ""
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTelefono.TextChanged
1:
    End Sub

    Private Sub CboCodigoProductor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboCodigoProductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProductor.TextChanged
        Dim SQL As String = "SELECT * FROM Productor WHERE (TipoProductor = 'Productor') AND (CodProductor = '" & Me.CboCodigoProductor.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        Dim FuentesAgua As Boolean, ViviendaPropia As Boolean, TenenciaTierra As String, TieneContrato As Boolean, RutaOrigen As String

        DataAdapter.Fill(DataSet, "Productor")
        If Not DataSet.Tables("Productor").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("NombreProductor")) Then
                Me.TxtNombre.Text = DataSet.Tables("Productor").Rows(0)("NombreProductor")
            End If
            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("ApellidoProductor")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Productor").Rows(0)("ApellidoProductor")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Telefonos")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Productor").Rows(0)("Telefonos")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("DireccionProductor")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Productor").Rows(0)("DireccionProductor")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Cod_Cuenta_Cliente")) Then
                Me.TxtCtaxCobrar.Text = DataSet.Tables("Productor").Rows(0)("Cod_Cuenta_Cliente")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Cod_Cuenta_Proveedor")) Then
                Me.TxtCtaxPagar.Text = DataSet.Tables("Productor").Rows(0)("Cod_Cuenta_Proveedor")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("FechaAdmision")) Then
                Me.DTFechaAdmision.Value = DataSet.Tables("Productor").Rows(0)("FechaAdmision")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Sexo")) Then
                Me.CboSexo.Text = DataSet.Tables("Productor").Rows(0)("Sexo")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CodEscolaridad")) Then
                Me.CboEscolaridad.Text = DataSet.Tables("Productor").Rows(0)("CodEscolaridad")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CodDepartamentos")) Then
                Me.CboDepartamentos.Text = DataSet.Tables("Productor").Rows(0)("CodDepartamentos")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CodCooperativa")) Then
                Me.CboCooperativa.Text = DataSet.Tables("Productor").Rows(0)("CodCooperativa")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CodRuta")) Then
                Me.CboRuta.Text = DataSet.Tables("Productor").Rows(0)("CodRuta")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("NombreConyugue")) Then
                Me.TxtNombreConyugue.Text = DataSet.Tables("Productor").Rows(0)("NombreConyugue")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("NumeroHijos")) Then
                Me.TxtNumeroHijos.Text = DataSet.Tables("Productor").Rows(0)("NumeroHijos")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Telefonos")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Productor").Rows(0)("Telefonos")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Fax")) Then
                Me.TxtFax.Text = DataSet.Tables("Productor").Rows(0)("Fax")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CorreoElectronico")) Then
                Me.TxtCorreoElectronico.Text = DataSet.Tables("Productor").Rows(0)("CorreoElectronico")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Comunidad")) Then
                Me.TxtComunidad.Text = DataSet.Tables("Productor").Rows(0)("Comunidad")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Edad")) Then
                Me.TxtEdad.Text = DataSet.Tables("Productor").Rows(0)("Edad")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("EstadoCivil")) Then
                Me.TxtEstadoCivil.Text = DataSet.Tables("Productor").Rows(0)("EstadoCivil")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("Cedula")) Then
                Me.TxtNumeroCedula.Text = DataSet.Tables("Productor").Rows(0)("Cedula")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("FuentesAgua")) Then
                FuentesAgua = DataSet.Tables("Productor").Rows(0)("FuentesAgua")
                If FuentesAgua = True Then
                    Me.OptFuenteSi.Checked = True
                Else
                    Me.OptFuenteNo.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("ViviendaPropia")) Then
                ViviendaPropia = DataSet.Tables("Productor").Rows(0)("ViviendaPropia")
                If ViviendaPropia = True Then
                    Me.OptViviendaSi.Checked = True
                Else
                    Me.OptViviendaNo.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("TieneContrato")) Then
                TieneContrato = DataSet.Tables("Productor").Rows(0)("TieneContrato")
                If TieneContrato = True Then
                    Me.OptContratoSi.Checked = True
                Else
                    Me.OptFuenteNo.Checked = True
                End If
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("DescripcionVivienda")) Then
                Me.TxtVivienda.Text = DataSet.Tables("Productor").Rows(0)("DescripcionVivienda")
            End If

            If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("TenenciaTierra")) Then
                TenenciaTierra = DataSet.Tables("Productor").Rows(0)("TenenciaTierra")
                Select Case TenenciaTierra
                    Case "Propia"
                        Me.OptTPropia.Checked = True
                    Case "Herencia"
                        Me.OptTHerencia.Checked = True
                    Case "Comprada"
                        Me.OptTComprada.Checked = True
                    Case "Reforma"
                        Me.OptTReforma.Checked = True
                    Case "Alquilada"
                        Me.OptTAlquilada.Checked = True
                    Case "Prestada"
                        Me.OptTPrestada.Checked = True
                End Select

                If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("AreadePasto")) Then
                    Me.TxtAreaPasto.Text = DataSet.Tables("Productor").Rows(0)("AreadePasto")
                End If

                If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CantidadVacas")) Then
                    Me.TxtCantidadVacas.Text = DataSet.Tables("Productor").Rows(0)("CantidadVacas")
                End If

                If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CantidadVaquillas")) Then
                    Me.TxtCantidadVaquillas.Text = DataSet.Tables("Productor").Rows(0)("CantidadVaquillas")
                End If

                If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CantidadBueyes")) Then
                    Me.TxtCantidadBueyes.Text = DataSet.Tables("Productor").Rows(0)("CantidadBueyes")
                End If

                If Not IsDBNull(DataSet.Tables("Productor").Rows(0)("CantidadTerrenos")) Then
                    Me.TxtCantidadTerreno.Text = DataSet.Tables("Productor").Rows(0)("CantidadTerrenos")
                End If

            End If

            RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\P" & Me.CboCodigoProductor.Text & ".bmp"
            If System.IO.File.Exists(RutaOrigen) = True Then
                Me.ImgFoto.ImageLocation = RutaOrigen
            End If

        Else
            Me.TxtNombre.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtCtaxCobrar.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtNumeroCedula.Text = ""

        End If
    End Sub

    Private Sub CmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregar.Click
        Dim RutaOrigen As String = "", RutaDestino As String
        Me.OpenFileDialog1.ShowDialog()
        RutaOrigen = Me.OpenFileDialog1.FileName.ToString()
        If RutaOrigen = "OpenFileDialog1" Then
            Exit Sub
        End If
        Me.ImgFoto.ImageLocation = RutaOrigen
        RutaDestino = My.Application.Info.DirectoryPath & "\Fotos\P" & Me.CboCodigoProductor.Text & ".bmp"
        If System.IO.File.Exists(RutaDestino) = True Then
            System.IO.File.Delete(RutaDestino)
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        Else
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        End If
    End Sub

    Private Sub CmdBorrarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarFoto.Click
        Dim RutaOrigen As String, Resultado As Double
        Resultado = MsgBox("¿Esta Seguro de Eliminar la Foto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\P" & Me.CboCodigoProductor.Text & ".bmp"
        If System.IO.File.Exists(RutaOrigen) = True Then
            System.IO.File.Delete(RutaOrigen)
            ImgFoto.ImageLocation = ""
            ImgFoto.Refresh()
        Else
            MsgBox("El archivo no Existe", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoProductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProductor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class