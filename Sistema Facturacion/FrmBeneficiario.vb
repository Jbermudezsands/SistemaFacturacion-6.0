Imports System.Configuration
Imports System.Data.SqlClient
Imports C1.Win.C1List



Public Class FrmBeneficiario

    Private ClienteOriginal As Boolean
    Private ProveedorOriginal As Boolean
    Private ProductorOriginal As Boolean
    Private SocioOriginal As Boolean
    Private PreSocioOriginal As Boolean
    Private EmpleadoOriginal As Boolean
    Private TransportistaOriginal As Boolean

    Private TipoNominaProductorOriginal As String
    Private TipoNominaSocioOriginal As String
    Private TipoNominaPreSocioOriginal As String

    Public CodigoInicial As String = ""

    Public Sub CargarDesdeCodigo(codigo As String)

        Me.CboCodigoProductor.Text = codigo

        Dim cs As New CsBeneficiario
        Dim b As Beneficiario = cs.CargarBeneficiario(codigo)

        If b IsNot Nothing Then

            Debug.Print(CboTipoNominaProductor.ListCount)
            Debug.Print(CboTipoNominaSocio.ListCount)
            Debug.Print(CboTipoNominaPreSocio.ListCount)

            LlenarFormulario(b)

            ClienteOriginal = ChkCliente.Checked
            ProveedorOriginal = ChkProveedor.Checked
            ProductorOriginal = ChkProductor.Checked
            SocioOriginal = ChkSocio.Checked
            PreSocioOriginal = ChkPreSocio.Checked
            EmpleadoOriginal = ChkEmpleado.Checked
            TransportistaOriginal = ChkTransportista.Checked

            TipoNominaProductorOriginal = b.CodTipoNominaProductor
            TipoNominaSocioOriginal = b.CodTipoNominaSocio
            TipoNominaPreSocioOriginal = b.CodTipoNominaPreSocio

        End If

    End Sub
    Private Function ProcesarCambioTipoNomina(dal As CsBeneficiario,
                                          Codigo As String,
                                          Tipo As String) As Boolean

        Dim r As ResultadoDesactivacion


        r = dal.PrepararCambioTipoNomina(Codigo, Tipo)

        If r.RequiereConfirmacion Then

            If MessageBox.Show(
            "El tipo de nómina de este " & Tipo &
            " ha cambiado." &
            vbCrLf & vbCrLf &
            r.Mensaje &
            vbCrLf &
            "Al continuar será eliminado de las nóminas activas para que pueda ser recalculado con el nuevo tipo de nómina." &
            vbCrLf & vbCrLf &
            "¿Desea continuar?",
            "Cambio de Tipo de Nómina",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) = DialogResult.No Then

                Return False

            End If

        End If

        Return dal.ProcesarCambioTipoNomina(Codigo, Tipo)

    End Function
    Private Function ProcesarDesactivacionRol(dal As CsBeneficiario,
                                          Codigo As String,
                                          Tipo As String) As Boolean

        Dim r As ResultadoDesactivacion

        r = dal.PrepararDesactivacion(Codigo, Tipo)

        If r.RequiereConfirmacion Then

            If MessageBox.Show(r.Mensaje,
                           "Confirmación",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then

                Return False

            End If

        End If

        Return dal.ProcesarDesactivacionTipo(Codigo, Tipo)

    End Function

    Private Sub LlenarFormulario(b As Beneficiario)

        TxtNombre.Text = b.Nombre
        TxtApellidos.Text = b.Apellido
        TxtDireccion.Text = b.Direccion
        TxtTelefono.Text = b.Telefonos
        TxtNumeroCedula.Text = b.Cedula
        TxtRuc.Text = b.RUC

        If b.Fecha_Admision <> Date.MinValue Then
            DTFechaAdmision.Value = b.Fecha_Admision
        End If

        If b.Fecha_Nacimiento <> Date.MinValue Then
            DTFechaNacimientos.Value = b.Fecha_Nacimiento
        End If

        ChkCliente.Checked = b.EsCliente
        ChkProveedor.Checked = b.EsProveedor
        ChkProductor.Checked = b.EsProductor
        ChkSocio.Checked = b.EsSocio
        ChkPreSocio.Checked = b.EsPreSocio
        ChkEmpleado.Checked = b.EsEmpleado
        ChkActivo.Checked = b.Activo
        ChkTransportista.Checked = b.EsTransportista

        '''''''''''''''DATOS DEL CLIENTE ////////////////////
        CboDepartamento.Text = b.Departamento
        CboMunicipio.Text = b.Municipio
        CboEndoso.Text = b.Endoso
        ChkEfectivo.Checked = b.Efectivo
        CboMonedaCliente.Text = b.MonedaCredito
        TxtLimiteCliente.Text = b.LimiteCredito
        TxtDiasCredito.Value = b.DiasCredito
        TxtRuc2.Text = b.RUC
        TxtCedula.Text = b.Cedula
        TxtCtaxCobrar.Text = b.CtasxCobrarClientes

        'Socio
        CboEscolaridadSocio.Text = b.EscolaridadSocio
        CboDepartamentosSocio.Text = b.DepartamentoSocio
        CboCooperativaSocio.Text = b.CooperatiaSocio
        CboRutaSocio.Text = b.RutaSocio
        TxtCtasCobrarSocio.Text = b.CtasxCobrarSocio
        TxtCtaxPagarSocio.Text = b.CtasxPagarSocio
        TxtCtaGastoSocio.Text = b.CtaPlanillaSocio
        TxtCtaBancoSocio.Text = b.CtaBancoSocio
        TxtCtaIr.Text = b.CtaIrSocio
        TxtCtaBolsaSocio.Text = b.CtaBolsaSocio
        TxtAnticipoSocio.Text = b.CtaAnticipoSocio
        TxtCtaTransporteSocio.Text = b.CtaTransporteSocio
        TxtCtaInseminacionSocio.Text = b.CtaInseminacionSocio
        TxtCtaTrazabilidadSocio.Text = b.CtaTrazabilidadSocio
        TxtCtaVeterinarioSocio.Text = b.CtaVeterinariosSocio
        TxtFondosAdmonSocio.Text = b.CtaFondosSocio
        TxtPrecioSocio.Text = b.PrecioSocio
        If b.EsSocio Then
            CboTipoNominaSocio.SelectedValue = b.CodTipoNominaSocio
        Else
            CboTipoNominaSocio.SelectedIndex = -1
        End If





        'Presocio
        CboEscolaridadPreSocio.Text = b.EscolaridadPreSocio
        CboDepartamentosPreSocio.Text = b.DepartamentoPreSocio
        CboCooperativaPreSocio.Text = b.CooperatiaPreSocio
        CboRutaPreSocio.Text = b.RutaPreSocio
        TxtCtasCobrarPreSocio.Text = b.CtasxCobrarPreSocio
        TxtCtaxPagarPreSocio.Text = b.CtasxPagarPreSocio
        TxtCtaGastoPreSocio.Text = b.CtaPlanillaPreSocio
        TxtCtaBancoPreSocio.Text = b.CtaBancoPreSocio
        TxtCtaIrPreSocio.Text = b.CtaIrPreSocio
        TxtCtaBolsaPreSocio.Text = b.CtaBolsaPreSocio
        TxtAnticipoPreSocio.Text = b.CtaAnticipoPreSocio
        TxtCtaTransportePreSocio.Text = b.CtaTransportePreSocio
        TxtCtaInseminacionPreSocio.Text = b.CtaInseminacionPreSocio
        TxtCtaTrazabilidadPreSocio.Text = b.CtaTrazabilidadPreSocio
        TxtCtaVeterinarioPreSocio.Text = b.CtaVeterinariosPreSocio
        TxtFondosAdmonPreSocio.Text = b.CtaFondosPreSocio
        TxtPrecioPreSocio.Text = b.PrecioPreSocio
        If b.EsPreSocio Then
            CboTipoNominaPreSocio.SelectedValue = b.CodTipoNominaPreSocio
        Else
            CboTipoNominaPreSocio.SelectedIndex = -1
        End If

        'Productor
        CboEscolaridadProductor.Text = b.EscolaridadProductor
        CboDepartamentosProductor.Text = b.DepartamentoProductor
        CboCooperativaProductor.Text = b.CooperatiaProductor
        CboRutaProductor.Text = b.RutaProductor
        TxtCtasCobrarProductor.Text = b.CtasxCobrarProductor
        TxtCtaxPagarProductor.Text = b.CtasxPagarProductor
        TxtCtaGastoProductor.Text = b.CtaPlanillaProductor
        TxtCtaBancoProductor.Text = b.CtaBancoProductor
        TxtCtaIrProductor.Text = b.CtaIrProductor
        TxtCtaBolsaProductor.Text = b.CtaBolsaProductor
        TxtAnticipoProductor.Text = b.CtaAnticipoProductor
        TxtCtaTransporteProductor.Text = b.CtaTransporteProductor
        TxtCtaInseminacionProductor.Text = b.CtaInseminacionProductor
        TxtCtaTrazabilidadProductor.Text = b.CtaTrazabilidadProductor
        TxtCtaVeterinarioProductor.Text = b.CtaVeterinariosProductor
        TxtFondosAdmonProductor.Text = b.CtaFondosProductor
        TxtPrecioProductor.Text = b.PrecioProductor
        If b.EsProductor Then
            CboTipoNominaProductor.SelectedValue = b.CodTipoNominaProductor
        Else
            CboTipoNominaProductor.SelectedIndex = -1
        End If







        'Transportista
        TxtCtaBanco.Text = b.CtaBancoTransp
        TxtCtaIr.Text = b.CtaIrTransp
        TxtCtaBolsa.Text = b.CtaBolsaTransp
        TxtAnticipo.Text = b.CtaAnticipoTransp
        TxtCtaGastoPlanilla.Text = b.CtaGtosPlanillaTransp
        TxtCtaTransporte.Text = b.CtaTransportista
        TxtCtaInseminacion.Text = b.CtaInseminacionTransp
        TxtCtaTrazabilidad.Text = b.CtaTrazabilidadTransp
        TxtCtaVeterinario.Text = b.CtaVeterinariaTransp
        TxtCtaOtras.Text = b.CtaOtrasDeduccionesTransp
        TxtCtaFondos.Text = b.CtaFondosTransp

    End Sub


    'Public Function CargarBeneficiario(codigo As String) As Beneficiario

    '    Dim b As New Beneficiario

    '    Using cn As New SqlConnection(Conexion)
    '        cn.Open()

    '        Using cmd As New SqlCommand("
    '        SELECT Codigo_Beneficiario, Nombre_Beneficiario, Apellido_Beneficiario, FechaAdmision, FechaNacimiento, Direccion, Sexo,
    '               Telefonos, EstadoCivil, Cedula, RUC, Activo,Foto
    '        FROM Beneficiario
    '        WHERE Codigo_Beneficiario = @Cod", cn)

    '            cmd.CommandType = CommandType.Text
    '            cmd.Parameters.Add("@Cod", SqlDbType.NVarChar, 4).Value = codigo

    '            Using dr As SqlDataReader = cmd.ExecuteReader()

    '                If dr.Read() Then

    '                    b.Codigo = dr("Codigo_Beneficiario").ToString()
    '                    b.Nombre = dr("Nombre_Beneficiario").ToString()
    '                    b.Apellido = dr("Apellido_Beneficiario").ToString()

    '                    If Not IsDBNull(dr("FechaAdmision")) Then
    '                        b.Fecha_Admision = Convert.ToDateTime(dr("FechaAdmision"))
    '                    End If

    '                    If Not IsDBNull(dr("FechaNacimiento")) Then
    '                        b.Fecha_Nacimiento = Convert.ToDateTime(dr("FechaNacimiento"))
    '                    End If

    '                    b.Direccion = dr("Direccion").ToString()
    '                    b.Sexo = dr("Sexo").ToString()
    '                    b.Telefonos = dr("Telefonos").ToString()
    '                    b.Estado_Civil = dr("EstadoCivil").ToString()
    '                    b.Cedula = dr("Cedula").ToString()
    '                    b.RUC = dr("Ruc").ToString()

    '                    If Not IsDBNull(dr("Foto")) Then
    '                        b.Foto = dr("Foto")
    '                    End If

    '                Else
    '                    Return Nothing
    '                End If

    '            End Using
    '        End Using
    '    End Using

    '    Return b

    'End Function



    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click

        Try

            Dim b As New Beneficiario()

            b.Codigo = CboCodigoProductor.Text
            b.Nombre = TxtNombre.Text
            b.Apellido = TxtApellidos.Text
            b.Fecha_Admision = DTFechaAdmision.Value
            b.Fecha_Nacimiento = DTFechaNacimientos.Value
            b.Direccion = TxtDireccion.Text
            b.Sexo = CboSexo.Text
            b.Cedula = TxtNumeroCedula.Text
            b.Estado_Civil = Me.CboEstadoCivil.Text
            b.Telefonos = Me.TxtTelefono.Text
            b.RUC = Me.TxtRuc.Text
            b.Foto = bytesToString(ImagenToBytes(Me.ImgFoto.Image))
            b.EsCliente = ChkCliente.Checked
            b.EsProveedor = ChkProveedor.Checked
            b.EsProductor = ChkProductor.Checked
            b.EsPreSocio = ChkPreSocio.Checked
            b.EsSocio = ChkSocio.Checked
            b.EsEmpleado = ChkEmpleado.Checked
            b.Activo = ChkActivo.Checked
            b.EsTransportista = ChkTransportista.Checked
            b.CuentaTransporte = "1120"
            b.Departamento = Me.CboDepartamento.Text
            b.Municipio = Me.CboMunicipio.Text
            b.Endoso = Me.CboEndoso.Text
            b.CodCuentaCliente = Me.TxtCtaxCobrar.Text
            b.MonedaCredito = Me.CboMonedaCliente.Text
            b.LimiteCredito = Me.TxtLimiteCliente.Text
            b.DiasCredito = TxtDiasCredito.Value
            b.BloquearPorLimiteCredito = ChkBloqueoLimite.Checked
            b.Efectivo = ChkEfectivo.Checked
            b.CtasxCobrarClientes = TxtCtaxCobrar.Text
            b.CausaIva = ChkCausaIVA.Checked
            b.CreditoDisponible = ChkCreditoDisponible.Checked

            If TxtCuentBanco.Text <> "" Then
                b.CodCuentaBanco = TxtCuentBanco.Text
                b.TipoPagoProductor = "Transferencia"
            Else
                b.TipoPagoProductor = "CHEQUE"
                b.CodCuentaBanco = "100100"
            End If

            'Socio
            b.EscolaridadSocio = CboEscolaridadSocio.ValueMember
            b.DepartamentoSocio = CboDepartamentosSocio.ValueMember
            b.CooperatiaSocio = CboCooperativaSocio.ValueMember
            b.RutaSocio = CboRutaSocio.ValueMember
            b.CtasxCobrarSocio = TxtCtasCobrarSocio.Text
            b.CtasxPagarSocio = TxtCtaxPagarSocio.Text
            b.CtaPlanillaSocio = TxtCtaGastoSocio.Text
            b.CtaBancoSocio = TxtCtaBancoSocio.Text
            b.CtaIrSocio = TxtCtaIrSocio.Text
            b.CtaBolsaSocio = TxtCtaBolsaSocio.Text
            b.CtaAnticipoSocio = TxtAnticipoSocio.Text
            b.CtaTransporteSocio = TxtCtaTransporteSocio.Text
            b.CtaInseminacionSocio = TxtCtaInseminacionSocio.Text
            b.CtaTrazabilidadSocio = TxtCtaTrazabilidadSocio.Text
            b.CtaVeterinariosSocio = TxtCtaVeterinarioSocio.Text
            b.CtaFondosSocio = TxtFondosAdmonSocio.Text
            b.CtaOtrasDeduccionesSocio = TxtCtaOtrasSocio.Text
            b.CodTipoNominaSocio = CboTipoNominaSocio.SelectedValue


            'PreSocio
            b.EscolaridadPreSocio = CboEscolaridadPreSocio.ValueMember
            b.DepartamentoPreSocio = CboDepartamentosPreSocio.ValueMember
            b.CooperatiaPreSocio = CboCooperativaPreSocio.ValueMember
            b.RutaPreSocio = CboRutaPreSocio.ValueMember
            b.CtasxCobrarPreSocio = TxtCtasCobrarPreSocio.Text
            b.CtasxPagarPreSocio = TxtCtaxPagarPreSocio.Text
            b.CtaPlanillaPreSocio = TxtCtaGastoPreSocio.Text
            b.CtaBancoPreSocio = TxtCtaBancoPreSocio.Text
            b.CtaIrPreSocio = TxtCtaIrPreSocio.Text
            b.CtaBolsaPreSocio = TxtCtaBolsaPreSocio.Text
            b.CtaAnticipoPreSocio = TxtAnticipoPreSocio.Text
            b.CtaTransportePreSocio = TxtCtaTransportePreSocio.Text
            b.CtaInseminacionPreSocio = TxtCtaInseminacionPreSocio.Text
            b.CtaTrazabilidadPreSocio = TxtCtaTrazabilidadPreSocio.Text
            b.CtaVeterinariosPreSocio = TxtCtaVeterinarioPreSocio.Text
            b.CtaFondosPreSocio = TxtFondosAdmonPreSocio.Text
            b.CtaOtrasDeduccionesPreSocio = TxtCtaOtrasPreSocio.Text
            b.CodTipoNominaPreSocio = CboTipoNominaPreSocio.SelectedValue

            'Productor
            b.EscolaridadProductor = CboEscolaridadProductor.ValueMember
            b.DepartamentoProductor = CboDepartamentosProductor.ValueMember
            b.CooperatiaProductor = CboCooperativaProductor.ValueMember
            b.RutaProductor = CboRutaProductor.ValueMember
            b.CtasxCobrarProductor = TxtCtasCobrarProductor.Text
            b.CtasxPagarProductor = TxtCtaxPagarProductor.Text
            b.CtaPlanillaProductor = TxtCtaGastoProductor.Text
            b.CtaBancoProductor = TxtCtaBancoProductor.Text
            b.CtaIrProductor = TxtCtaIrProductor.Text
            b.CtaBolsaProductor = TxtCtaBolsaProductor.Text
            b.CtaAnticipoProductor = TxtAnticipoProductor.Text
            b.CtaTransporteProductor = TxtCtaTransporteProductor.Text
            b.CtaInseminacionProductor = TxtCtaInseminacionProductor.Text
            b.CtaTrazabilidadProductor = TxtCtaTrazabilidadProductor.Text
            b.CtaVeterinariosProductor = TxtCtaVeterinarioProductor.Text
            b.CtaFondosProductor = TxtFondosAdmonProductor.Text
            b.CtaOtrasDeduccionesProductor = TxtCtaOtrasProductor.Text
            b.CodTipoNominaProductor = CboTipoNominaProductor.SelectedValue

            b.Precio = 0
            b.PrecioPreSocio = 0
            b.PrecioProductor = 0

            'Proveedor
            b.DepartamentoProveedor = Me.CboDepartamentoProveedor.Text
            b.MunicipioProveedor = Me.CboMunicipioProveedor.Text
            b.EndosoProveedor = Me.CboEndoso.Text
            b.CodCuentaProveedor = Me.TxtCtaxCobrar.Text
            b.LimiteCreditoProveedor = Me.TxtLimiteProveedor.Text
            b.MonedaCreditoProveedor = Me.CboMonedaCliente.Text
            b.DiasCreditoProveedor = TxtDiasCredito.Value
            b.BloquearPorLimiteCreditoProveedor = ChkBloqueoLimite.Checked
            b.EfectivoProveedor = ChkEfectivo.Checked
            b.CtasxPagarProveedor = TxtCtasxPagarProveedor.Text
            b.CausaIvaProveedor = ChkCausaIVA.Checked
            b.CreditoDisponibleProveedor = ChkCreditoDisponible.Checked

            'Transportista
            b.CtaTransportista = TxtCtaTransporte.Text
            b.CtaInseminacionTransp = TxtCtaInseminacion.Text
            b.CtaTrazabilidadTransp = TxtCtaTrazabilidad.Text
            b.CtaBolsaTransp = TxtCtaBolsa.Text
            b.CtaAnticipoTransp = TxtAnticipo.Text
            b.CtaOtrasDeduccionesTransp = TxtCtaOtras.Text
            b.CtaFondosTransp = TxtCtaFondos.Text
            b.CtaGtosPlanillaTransp = TxtCtaGastoPlanilla.Text
            b.CtaBancoTransp = TxtCtaBanco.Text
            b.CtaIrTransp = TxtCtaIr.Text
            b.CtaVeterinariaTransp = Me.TxtCtaVeterinario.Text


            Dim dal As New CsBeneficiario

            '-----------------------------------------
            ' PRODUCTOR
            '-----------------------------------------

            If ProductorOriginal Then
                If Not ChkProductor.Checked Then
                    If Not ProcesarDesactivacionRol(dal,
                                        b.Codigo,
                                        "Productor") Then Exit Sub
                Else
                    If TipoNominaProductorOriginal <> CboTipoNominaProductor.SelectedValue.ToString() Then
                        If Not ProcesarCambioTipoNomina(dal,
                                            b.Codigo,
                                            "Productor") Then Exit Sub
                    End If
                End If
            End If

            '-------------------------------------------------------
            ' SOCIO
            '-------------------------------------------------------
            If SocioOriginal Then
                If Not ChkSocio.Checked Then
                    If Not ProcesarDesactivacionRol(dal,
                                        b.Codigo,
                                        "Socio") Then Exit Sub
                Else
                    If TipoNominaSocioOriginal <> CboTipoNominaSocio.SelectedValue.ToString() Then
                        If Not ProcesarCambioTipoNomina(dal,
                                            b.Codigo,
                                            "Socio") Then Exit Sub
                    End If
                End If
            End If

            '-------------------------------------------------------
            ' PRESOCIO
            '-------------------------------------------------------
            If PreSocioOriginal Then
                If Not ChkPreSocio.Checked Then
                    If Not ProcesarDesactivacionRol(dal,
                                        b.Codigo,
                                        "PreSocio") Then Exit Sub
                Else
                    If TipoNominaPreSocioOriginal <> CboTipoNominaPreSocio.SelectedValue.ToString() Then
                        If Not ProcesarCambioTipoNomina(dal,
                                            b.Codigo,
                                            "PreSocio") Then Exit Sub
                    End If
                End If
            End If



            '-------------------------------------------------------
            ' GUARDAR
            '-------------------------------------------------------

            dal.Guardar(b)



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        MessageBox.Show("Registro guardado correctamente")
    End Sub

    Private Sub FrmBeneficiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cs As New CsBeneficiario
        Dim cat As New CsCatalogos()
        Dim dtDepto As DataTable = cat.ObtenerDepartamentos()
        Dim dtCoop As DataTable = cat.ObtenerCooperativa()
        Dim dtEscol As DataTable = cat.ObtenerEscolaridad()
        Dim dtRuta As DataTable = cat.ObtnerRuta()
        Dim dtTipoNomina As DataTable = cat.ObtenerTipoNomina()
        Dim sql As String


        'Departamentos
        CboDepartamento.DataSource = dtDepto.Copy()
        CboDepartamento.DisplayMember = "Nombre_Departamento"
        CboDepartamento.ValueMember = "Cod_Departamento"


        'Socio
        CboEscolaridadSocio.DataSource = dtEscol.Copy()
        CboEscolaridadSocio.DisplayMember = "Nombre_Escolaridad"
        CboEscolaridadSocio.ValueMember = "Cod_Escolaridad"

        CboDepartamentosSocio.DataSource = dtDepto.Copy()
        CboDepartamentosSocio.DisplayMember = "Nombre_Departamento"
        CboDepartamentosSocio.ValueMember = "Cod_Departamento"

        CboCooperativaSocio.DataSource = dtCoop.Copy()
        CboCooperativaSocio.DisplayMember = "Nombre_Cooperativa"
        CboCooperativaSocio.ValueMember = "Cod_Cooperativa"

        CboRutaSocio.DataSource = dtRuta.Copy()
        CboRutaSocio.DisplayMember = "Nombre_Ruta"
        CboRutaSocio.ValueMember = "CodRuta"

        'PreSocio
        CboDepartamentosPreSocio.DataSource = dtDepto.Copy()
        CboDepartamentosPreSocio.DisplayMember = "Nombre_Departamento"
        CboDepartamentosPreSocio.ValueMember = "Cod_Departamento"

        CboEscolaridadPreSocio.DataSource = dtEscol.Copy()
        CboEscolaridadPreSocio.DisplayMember = "Nombre_Escolaridad"
        CboEscolaridadPreSocio.ValueMember = "Cod_Escolaridad"

        CboCooperativaPreSocio.DataSource = dtCoop.Copy()
        CboCooperativaPreSocio.DisplayMember = "Nombre_Cooperativa"
        CboCooperativaPreSocio.ValueMember = "Cod_Cooperativa"

        CboRutaPreSocio.DataSource = dtRuta.Copy()
        CboRutaPreSocio.DisplayMember = "Nombre_Ruta"
        CboRutaPreSocio.ValueMember = "CodRuta"

        'Productor
        CboDepartamentosProductor.DataSource = dtDepto.Copy()
        CboDepartamentosProductor.DisplayMember = "Nombre_Departamento"
        CboDepartamentosProductor.ValueMember = "Cod_Departamento"

        CboEscolaridadProductor.DataSource = dtEscol.Copy()
        CboEscolaridadProductor.DisplayMember = "Nombre_Escolaridad"
        CboEscolaridadProductor.ValueMember = "Cod_Escolaridad"

        CboCooperativaProductor.DataSource = dtCoop.Copy()
        CboCooperativaProductor.DisplayMember = "Nombre_Cooperativa"
        CboCooperativaProductor.ValueMember = "Cod_Cooperativa"

        CboRutaProductor.DataSource = dtRuta.Copy()
        CboRutaProductor.DisplayMember = "Nombre_Ruta"
        CboRutaProductor.ValueMember = "CodRuta"

        ' Combo Socio
        CboTipoNominaSocio.DataSource = dtTipoNomina.Copy()
        CboTipoNominaSocio.DisplayMember = "TipoNomina"
        CboTipoNominaSocio.ValueMember = "CodTipoNomina"

        ' Combo PreSocio
        CboTipoNominaPreSocio.DataSource = dtTipoNomina.Copy()
        CboTipoNominaPreSocio.DisplayMember = "TipoNomina"
        CboTipoNominaPreSocio.ValueMember = "CodTipoNomina"

        ' Combo Productor
        CboTipoNominaProductor.DataSource = dtTipoNomina.Copy()
        CboTipoNominaProductor.DisplayMember = "TipoNomina"
        CboTipoNominaProductor.ValueMember = "CodTipoNomina"


        'Endoso
        CboEndoso.DataSource = cat.ObtenerEndoso()
        CboEndoso.DisplayMember = "Nombre"
        CboEndoso.ValueMember = "Nombre"

        cs.CargarBeneficiariosEnCombo(Me.CboCodigoProductor)


        Me.CboSexo.Text = "Masculino"
        Me.CboEstadoCivil.Text = "Soltero"
        Me.ImgFoto.Image = My.Resources.NoDisponible

        If CodigoInicial <> "" Then

            CargarDesdeCodigo(CodigoInicial)

            CodigoInicial = ""

        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoProductor_Close(sender As Object, e As EventArgs) Handles CboCodigoProductor.Close
        If CboCodigoProductor.SelectedIndex < 0 Then Exit Sub

        Dim codigo As String = CboCodigoProductor.Columns("Codigo_Beneficiario").Value.ToString()

        Dim cs As New CsBeneficiario
        Dim b As Beneficiario = cs.CargarBeneficiario(codigo)

        If b IsNot Nothing Then
            LlenarFormulario(b)
        End If

    End Sub

    Private Sub CboCodigoProductor_TextChanged(sender As Object, e As EventArgs) Handles CboCodigoProductor.TextChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Quien = "CodigoBenficiario"
        My.Forms.FrmConsultas.ShowDialog()



        Dim codigo As String = My.Forms.FrmConsultas.Codigo
        Me.CboCodigoProductor.Text = codigo

        Dim cs As New CsBeneficiario
        Dim b As Beneficiario = cs.CargarBeneficiario(codigo)

        If b IsNot Nothing Then
            LlenarFormulario(b)

            ClienteOriginal = ChkCliente.Checked
            ProveedorOriginal = ChkProveedor.Checked
            ProductorOriginal = ChkProductor.Checked
            SocioOriginal = ChkSocio.Checked
            PreSocioOriginal = ChkPreSocio.Checked
            EmpleadoOriginal = ChkEmpleado.Checked
            TransportistaOriginal = ChkTransportista.Checked

            TipoNominaProductorOriginal = b.CodTipoNominaProductor
            TipoNominaSocioOriginal = b.CodTipoNominaSocio
            TipoNominaPreSocioOriginal = b.CodTipoNominaPreSocio
        End If
    End Sub

    Private Sub CboDepartamento_TextChanged(sender As Object, e As EventArgs) Handles CboDepartamento.TextChanged
        If CboDepartamento.SelectedValue Is Nothing Then Exit Sub

        Dim cat As New CsCatalogos()

        CboMunicipio.DataSource =
            cat.ObtenerMunicipios(CboDepartamento.SelectedValue.ToString())

        CboMunicipio.DisplayMember = "Nombre_Municipio"
        CboMunicipio.ValueMember = "Nombre_Municipio"
    End Sub

    Private Sub CboDepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboDepartamento.SelectedValueChanged
        If CboDepartamento.SelectedValue Is Nothing Then Exit Sub

        'Evita error cuando aún está cargando
        If Not TypeOf CboDepartamento.SelectedValue Is String Then Exit Sub

        Dim cat As New CsCatalogos()

        CboMunicipio.DataSource =
            cat.ObtenerMunicipios(CboDepartamento.SelectedValue.ToString())

        CboMunicipio.DisplayMember = "Nombre_Municipio"
        CboMunicipio.ValueMember = "Nombre_Municipio"
    End Sub

    Private Sub TxtNumeroCedula_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNumeroCedula.MaskInputRejected

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click

    End Sub

    Private Sub Label92_Click(sender As Object, e As EventArgs) Handles Label92.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecioSocio.TextChanged

    End Sub
End Class