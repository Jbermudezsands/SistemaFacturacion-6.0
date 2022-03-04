Public Class FrmMostrarPesadas
    Public DescripcionProducto As String, Pesada As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)


    Private Sub FrmMostrarPesadas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.Forms.FrmRecepcion.VentaAbierta = True
    End Sub

    Private Sub FrmMostrarPesadas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Forms.FrmRecepcion.VentaAbierta = False
    End Sub

    Private Sub FrmMostrarPesadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String, RutaLogo As String
        Dim myImagenConsulta As Image


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.LblNombreEmpresa.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            Me.LblRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            Me.LblTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")

                If Dir(RutaLogo) <> "" Then
                    Me.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If


            End If




        End If
    End Sub

    Private Sub LblPeso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblPeso.Click

    End Sub
End Class