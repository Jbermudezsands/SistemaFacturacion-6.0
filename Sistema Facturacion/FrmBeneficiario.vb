Imports System.Configuration
Imports System.Data.SqlClient
Imports C1.Win.C1List

Public Class FrmBeneficiario

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
        ChkEmpleado.Checked = b.EsEmpleado
        ChkActivo.Checked = b.Activo

    End Sub


    Public Function CargarBeneficiario(codigo As String) As Beneficiario

        Dim b As New Beneficiario

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Using cmd As New SqlCommand("
            SELECT Codigo_Beneficiario, Nombre_Beneficiario, Apellido_Beneficiario, FechaAdmision, FechaNacimiento, Direccion, Sexo,
                   Telefonos, EstadoCivil, Cedula, RUC, Activo,Foto
            FROM Beneficiario
            WHERE Codigo_Beneficiario = @Cod", cn)

                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Cod", SqlDbType.NVarChar, 4).Value = codigo

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then

                        b.Codigo = dr("Codigo_Beneficiario").ToString()
                        b.Nombre = dr("Nombre_Beneficiario").ToString()
                        b.Apellido = dr("Apellido_Beneficiario").ToString()

                        If Not IsDBNull(dr("FechaAdmision")) Then
                            b.Fecha_Admision = Convert.ToDateTime(dr("FechaAdmision"))
                        End If

                        If Not IsDBNull(dr("FechaNacimiento")) Then
                            b.Fecha_Nacimiento = Convert.ToDateTime(dr("FechaNacimiento"))
                        End If

                        b.Direccion = dr("Direccion").ToString()
                        b.Sexo = dr("Sexo").ToString()
                        b.Telefonos = dr("Telefonos").ToString()
                        b.Estado_Civil = dr("EstadoCivil").ToString()
                        b.Cedula = dr("Cedula").ToString()
                        b.RUC = dr("Ruc").ToString()

                        If Not IsDBNull(dr("Foto")) Then
                            b.Foto = dr("Foto")
                        End If

                    Else
                        Return Nothing
                    End If

                End Using
            End Using
        End Using

        Return b

    End Function



    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click

        Dim b As New Beneficiario()

        b.Codigo = CboCodigoProductor.Columns("Codigo_Beneficiario").Value.ToString()
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
        b.EsEmpleado = ChkEmpleado.Checked
        b.Activo = ChkActivo.Checked

        Dim dal As New CsBeneficiario
        dal.Guardar(b)

        MessageBox.Show("Registro guardado correctamente")
    End Sub

    Private Sub FrmBeneficiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cs As New CsBeneficiario
        cs.CargarBeneficiariosEnCombo(Me.CboCodigoProductor)


        Me.CboSexo.Text = "Masculino"
        Me.CboEstadoCivil.Text = "Soltero"
        Me.ImgFoto.Image = My.Resources.NoDisponible
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
End Class