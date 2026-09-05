Public Class FrmCambiarTipoNomina

    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Codigo As String
    Public Nombre As String
    Public TipoProductor As String
    Public TipoNominaActual As String

    Public CambioRealizado As Boolean = False
    Public NuevoTipoNomina As String

    Private Sub CargarTipoNomina()

        Dim ds As New DataSet
        Dim da As New SqlClient.SqlDataAdapter

        Dim sql As String =
        "SELECT CodTipoNomina, TipoNomina
         FROM TipoNomina
         ORDER BY CodTipoNomina"

        da = New SqlClient.SqlDataAdapter(sql, MiConexion)
        da.Fill(ds, "TipoNomina")

        With CboTipoNominaProductor

            .DataSource = ds.Tables("TipoNomina")
            .DisplayMember = "CodTipoNomina"
            .ValueMember = "CodTipoNomina"

        End With

    End Sub
    Private Sub FrmCambiarTipoNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        LblCodigo.Text = "Código : " & Codigo
        LblNombre.Text = "Nombre : " & Nombre
        LblRol.Text = "Rol : " & TipoProductor
        LblTipoNominaActual.Text = "Tipo Actual : " & TipoNominaActual

        CargarTipoNomina()

        CboTipoNominaProductor.SelectedValue = TipoNominaActual

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If CboTipoNominaProductor.SelectedValue.ToString = TipoNominaActual Then

            MessageBox.Show("Debe seleccionar un Tipo de Nómina diferente.")

            Exit Sub

        End If

        Dim dal As New CsBeneficiario

        If dal.CambiarTipoNomina(Codigo,
                             TipoProductor,
                             CboTipoNominaProductor.SelectedValue.ToString) Then

            CambioRealizado = True

            Me.Close()

        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        NuevoTipoNomina = CboTipoNominaProductor.SelectedValue.ToString()

        CambioRealizado = True

        Me.Close()
    End Sub
End Class