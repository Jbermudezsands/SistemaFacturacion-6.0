Option Strict On
Option Explicit On

Imports System.IO

''' <summary>Arma y muestra el reporte ArepArqueoCaja a partir de los datos del arqueo.</summary>
Public NotInheritable Class ArqueoImpresion

    Private Sub New()
    End Sub

    Public Shared Sub Mostrar(ByVal cab As ArqueoCabecera,
                              ByVal nombreCajero As String,
                              ByVal resumen As ArqueoResumen,
                              ByVal empresa As ArqueoEmpresa,
                              ByVal conexion As String)

        Dim reporte As New ArepArqueoCaja()

        reporte.LblTitulo.Text = empresa.Nombre
        reporte.LblDireccion.Text = empresa.Direccion
        reporte.LblRuc.Text = If(String.IsNullOrEmpty(empresa.Ruc), "", "Numero RUC " & empresa.Ruc)

        If Not String.IsNullOrEmpty(empresa.RutaLogo) AndAlso File.Exists(empresa.RutaLogo) Then
            reporte.ImgLogo.Image = New System.Drawing.Bitmap(empresa.RutaLogo)
        End If

        reporte.TxtFechaArqueo.Text = cab.Fecha.ToString("dd/MM/yyyy")
        reporte.TxtCodCajero.Text = cab.CodCajero
        reporte.TxtNumeroArqueo.Text = cab.Codigo
        reporte.TxtNombreCajero.Text = nombreCajero

        reporte.LblSubTotal1.Text = Formatear(resumen.EfectivoContadoCordobas)
        reporte.LblSubTotal2.Text = Formatear(resumen.EfectivoContadoDolares)
        reporte.LblSumaFact1.Text = Formatear(resumen.EfectivoEsperadoCordobas)
        reporte.LblSumaFact2.Text = Formatear(resumen.EfectivoEsperadoDolares)
        reporte.LblTotalChequeCordobas.Text = Formatear(resumen.ChequesCordobas)
        reporte.LblTotalChequeDolares.Text = Formatear(resumen.ChequesDolares)
        reporte.LbltotalCordobasDolares.Text = Formatear(resumen.TotalContado)
        reporte.LblMontoRecibidos.Text = Formatear(resumen.TotalEsperado)
        reporte.LblDiferencia.Text = Formatear(resumen.Diferencia)
        reporte.LblObservaciones.Text = cab.Observaciones
        reporte.LblArqueadoPor.Text = "Practicado por " & cab.PracticadoPor

        Dim origen As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource()
        origen.ConnectionString = conexion
        origen.SQL = "SELECT * FROM Arqueo WHERE CodArqueo = '" & cab.Codigo.Replace("'", "''") & "' " &
                     "AND FechaArqueo = CONVERT(DATETIME, '" & cab.Fecha.ToString("yyyy-MM-dd") & "', 102)"

        reporte.DataSource = origen
        reporte.Document.Name = "ARQUEO DE CAJA"
        reporte.Run(False)
        reporte.Show()
    End Sub

    Private Shared Function Formatear(ByVal monto As Decimal) As String
        Return monto.ToString("N2")
    End Function

End Class
