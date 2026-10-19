Imports System.Data
Imports System.Data.SqlClient

Public Class frmProveedoresTransportados

    Public Property NumNominaTransportista As String
    Public Property CodigoTransportista As String

    Private Sub frmProveedoresTransportados_Load(
        ByVal sender As Object,
        ByVal e As EventArgs
    ) Handles MyBase.Load

        CargarNombreTransportista()
        CargarProductoresTransportados()

    End Sub
    Private Sub CargarNombreTransportista()

        Try

            Dim Sql As String =
            "SELECT Nombre " &
            "FROM Conductor " &
            "WHERE Codigo = @CodigoTransportista"

            Using Cn As New SqlClient.SqlConnection(Conexion)

                Using Cmd As New SqlClient.SqlCommand(Sql, Cn)

                    Cmd.Parameters.Add(
                            "@CodigoTransportista",
                            System.Data.SqlDbType.NVarChar,
                            50
                        ).Value = CodigoTransportista

                    Cn.Open()

                    Dim Resultado As Object = Cmd.ExecuteScalar()

                    If Resultado IsNot Nothing AndAlso
                   Resultado IsNot DBNull.Value Then

                        LblNombreTransportista.Text =
                        Resultado.ToString().Trim()

                    Else

                        LblNombreTransportista.Text = "Transportista no encontrado"

                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
            "Error al cargar el nombre del transportista: " & ex.Message,
            "Nómina de transporte",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

        End Try

    End Sub


    Private Sub CargarProductoresTransportados()

        Dim Dt As New DataTable()

        Dim Sql As String =
            "SELECT " &
            "    H.CodProductor, " &
            "    H.TipoProductor, " &
            "    LTRIM(RTRIM(" &
            "        ISNULL(P.NombreProductor, '') + ' ' + " &
            "        ISNULL(P.ApellidoProductor, '')" &
            "    )) AS Beneficiario, " &
            "    ISNULL(TN.TipoNomina, '') AS CREL, " &
            "    SUM(H.Litros) AS Litros, " &
            "    H.PrecioAplicado AS Precio, " &
            "    SUM(H.Importe) AS PorPagar " &
            "FROM dbo.DetallePrecioTransportista AS H " &
            "LEFT JOIN dbo.Productor AS P " &
            "    ON P.CodProductor = H.CodProductor " &
            "   AND P.TipoProductor = H.TipoProductor " &
            "LEFT JOIN dbo.TipoNomina AS TN " &
            "    ON TN.CodTipoNomina = P.CodTipoNomina " &
            "WHERE H.NumNominaTransportista = @NumNomina " &
            "  AND H.CodigoTransportista = @CodigoTransportista " &
            "GROUP BY " &
            "    H.CodProductor, " &
            "    H.TipoProductor, " &
            "    P.NombreProductor, " &
            "    P.ApellidoProductor, " &
            "    TN.TipoNomina, " &
            "    H.PrecioAplicado " &
            "ORDER BY " &
            "    Beneficiario;"

        Try

            Using Cn As New SqlConnection(Conexion)

                Using Cmd As New SqlCommand(Sql, Cn)

                    Cmd.Parameters.Add(
                        "@NumNomina",
                        SqlDbType.NVarChar,
                        50
                    ).Value = NumNominaTransportista

                    Cmd.Parameters.Add(
                        "@CodigoTransportista",
                        SqlDbType.NVarChar,
                        50
                    ).Value = CodigoTransportista

                    Using Da As New SqlDataAdapter(Cmd)

                        Da.Fill(Dt)

                    End Using

                End Using

            End Using

            dgvProductores.DataSource = Dt

            ConfigurarGrid()

            CalcularTotales(Dt)

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los productores transportados: " &
                ex.Message,
                "Nómina de transporte",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub ConfigurarGrid()

        With dgvProductores

            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            If .Columns.Contains("CodProductor") Then
                .Columns("CodProductor").HeaderText = "Código"
                .Columns("CodProductor").Width = 70
            End If

            If .Columns.Contains("TipoProductor") Then
                .Columns("TipoProductor").HeaderText = "Tipo Beneficiario"
                .Columns("TipoProductor").Visible = True
                .Columns("TipoProductor").Width = 100
            End If

            If .Columns.Contains("Beneficiario") Then
                .Columns("Beneficiario").HeaderText = "Beneficiario"
                .Columns("Beneficiario").Width = 250
            End If

            If .Columns.Contains("CREL") Then
                .Columns("CREL").HeaderText = "CREL"
                .Columns("CREL").Width = 120
            End If

            If .Columns.Contains("Litros") Then
                .Columns("Litros").HeaderText = "Litros"
                .Columns("Litros").Width = 90
                .Columns("Litros").DefaultCellStyle.Format = "N2"
                .Columns("Litros").DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight
            End If

            If .Columns.Contains("Precio") Then
                .Columns("Precio").HeaderText = "Precio"
                .Columns("Precio").Width = 90
                .Columns("Precio").DefaultCellStyle.Format = "N2"
                .Columns("Precio").DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight
            End If

            If .Columns.Contains("PorPagar") Then
                .Columns("PorPagar").HeaderText = "Por pagar"
                .Columns("PorPagar").Width = 110
                .Columns("PorPagar").DefaultCellStyle.Format = "N2"
                .Columns("PorPagar").DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight
            End If

        End With

    End Sub

    Private Sub CalcularTotales(ByVal Dt As DataTable)

        Dim TotalLitros As Double = 0
        Dim TotalPorPagar As Double = 0

        For Each Fila As DataRow In Dt.Rows

            TotalLitros += Convert.ToDouble(Fila("Litros"))
            TotalPorPagar += Convert.ToDouble(Fila("PorPagar"))

        Next

        lblTotalLitros.Text = TotalLitros.ToString("N2")
        lblTotalPorPagar.Text = TotalPorPagar.ToString("N2")

    End Sub

    Private Sub lblCerrar_Click(
        ByVal sender As Object,
        ByVal e As EventArgs
    ) Handles lblCerrar.Click

        Me.Close()

    End Sub

    Private Sub dgvProductores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductores.CellContentClick

    End Sub
End Class
