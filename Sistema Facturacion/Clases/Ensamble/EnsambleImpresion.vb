Option Strict On
Option Explicit On
Option Infer On

Imports System.Data
Imports System.Globalization
Imports System.IO

'=====================================================================================================
'  ENSAMBLE - IMPRESIÓN
'  Arma y muestra el reporte ArpEnsamble del documento actual.
'=====================================================================================================
Public Class EnsambleImpresion

    Private ReadOnly _conexion As String
    Private ReadOnly _repositorio As EnsambleRepositorio

    Public Sub New(ByVal conexion As String)
        _conexion = conexion
        _repositorio = New EnsambleRepositorio(conexion)
    End Sub

    Public Sub Mostrar(ByVal enc As EnsambleEncabezado, ByVal descripcionProducto As String)
        'El tipo viene de una lista cerrada; se valida porque el reporte recibe el SQL ya armado
        If Not TiposEnsamble.EsValido(enc.Tipo) Then
            Throw New EnsambleNegocioException("Es necesario seleccionar el tipo de ensamble.")
        End If

        Dim reporte As New ArpEnsamble
        CargarEncabezadoEmpresa(reporte)

        Dim origen As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        origen.ConnectionString = _conexion
        origen.SQL = _
            "SELECT D.Cod_ReciboEnsamble, D.Fecha_Ensamble, D.Tipo_Ensamble, D.CodProducto, P.Descripcion_Producto, " & _
            "       D.Cantidad_Ensamble, D.Valor_Ensamble, D.Desecho, D.Valor_Desecho " & _
            "FROM Detalle_Ensamble D INNER JOIN Productos P ON D.CodProducto = P.Cod_Productos " & _
            "WHERE D.Cod_ReciboEnsamble = " & enc.Numero.ToString(CultureInfo.InvariantCulture) & _
            " AND D.Fecha_Ensamble = CONVERT(DATETIME, '" & enc.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) & "', 102)" & _
            " AND D.Tipo_Ensamble = '" & enc.Tipo & "'"

        reporte.Document.Name = "Reporte de Ensamble"
        reporte.TxtTipoEnsamble.Text = enc.Tipo
        reporte.TxtFecha.Text = enc.Fecha.ToString()
        reporte.TxtNumero.Text = enc.Numero.ToString()
        reporte.TxtCodigo.Text = enc.CodProducto
        reporte.TxtDescripcion.Text = descripcionProducto
        reporte.TxtCantidad.Text = enc.Cantidad.ToString()
        reporte.TxtBodegaDestino.Text = enc.BodegaDestino
        reporte.TxtBodegaOrigen.Text = enc.BodegaOrigen
        reporte.DataSource = origen

        Dim visor As New FrmViewer()
        visor.arvMain.Document = reporte.Document
        visor.Show()
        reporte.Run(False)
    End Sub

    Private Sub CargarEncabezadoEmpresa(ByVal reporte As ArpEnsamble)
        Dim empresa As DataTable = _repositorio.ObtenerDatosEmpresa()
        If empresa.Rows.Count = 0 Then Return

        Dim fila As DataRow = empresa.Rows(0)
        reporte.LblEncabezado1.Text = Convert.ToString(fila("Nombre_Empresa"))
        reporte.LblDireccion1.Text = Convert.ToString(fila("Direccion_Empresa"))

        If Not IsDBNull(fila("Numero_Ruc")) Then
            reporte.LblDireccion2.Text = "Numero RUC " & Convert.ToString(fila("Numero_Ruc"))
        End If

        If Not IsDBNull(fila("Ruta_Logo")) Then
            Dim rutaLogo As String = Convert.ToString(fila("Ruta_Logo"))
            If rutaLogo.Length > 0 AndAlso File.Exists(rutaLogo) Then
                reporte.ImgLogo.Image = New System.Drawing.Bitmap(rutaLogo)
            End If
        End If
    End Sub

End Class
