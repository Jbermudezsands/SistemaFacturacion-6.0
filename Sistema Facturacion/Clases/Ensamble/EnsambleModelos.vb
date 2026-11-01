Option Strict On
Option Explicit On
Option Infer On

Imports System.Data

'=====================================================================================================
'  ENSAMBLE - MODELOS
'  Tipos de ensamble, encabezado del documento y adaptador de componentes para el grid.
'=====================================================================================================

''' <summary>Error de regla de negocio: el mensaje es apto para mostrarse tal cual al usuario.</summary>
Public Class EnsambleNegocioException
    Inherits Exception

    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub
End Class

''' <summary>Tipos de documento de ensamble y sus consecutivos.</summary>
Public NotInheritable Class TiposEnsamble

    Public Const Orden As String = "Orden de Ensamble"
    Public Const Recibido As String = "Ensamble Recibido"
    Public Const Deshacer As String = "Deshacer Ensamble"

    ''' <summary>Texto que muestra el formulario mientras el documento no tiene número.</summary>
    Public Const SinNumero As String = "-----0-----"

    Private Sub New()
    End Sub

    Public Shared Function EsValido(ByVal tipo As String) As Boolean
        Return tipo = Orden OrElse tipo = Recibido OrElse tipo = Deshacer
    End Function

    ''' <summary>Nombre del consecutivo que usa BuscaConsecutivo para cada tipo.</summary>
    Public Shared Function CampoConsecutivo(ByVal tipo As String) As String
        Select Case tipo
            Case Recibido
                Return "Ensamble_Recibido"
            Case Orden
                Return "Orden_Ensamble"
            Case Deshacer
                Return "Deshacer_Ensamble"
        End Select
        Throw New EnsambleNegocioException("Es necesario seleccionar el tipo de ensamble.")
    End Function
End Class

''' <summary>Datos del documento de ensamble tal como están en pantalla.</summary>
Public Class EnsambleEncabezado

    ''' <summary>Número del documento; 0 cuando todavía no se ha guardado.</summary>
    Public Property Numero() As Double
    Public Property Fecha() As Date
    Public Property Tipo() As String
    Public Property CodProducto() As String
    Public Property Cantidad() As Double
    Public Property CodComponente() As Double
    Public Property Referencias() As String
    Public Property BodegaOrigen() As String
    Public Property BodegaDestino() As String
    Public Property Rendimiento() As Double

    Public Sub New()
        Tipo = ""
        CodProducto = ""
        Referencias = ""
        BodegaOrigen = ""
        BodegaDestino = ""
        Fecha = Date.Today
    End Sub
End Class

''' <summary>
''' Unifica las dos formas de tabla que alimentan el grid (Componentes y Detalle_Ensamble)
''' en una sola con columnas Cod_Producto, Descripcion_Producto, Requerido y Desecho.
''' </summary>
Public NotInheritable Class ComponentesGrid

    Public Const Codigo As String = "Cod_Producto"
    Public Const Descripcion As String = "Descripcion_Producto"
    Public Const Requerido As String = "Requerido"
    Public Const Desecho As String = "Desecho"

    Private Sub New()
    End Sub

    Public Shared Function Vacia() As DataTable
        Dim tabla As New DataTable("Componentes")
        tabla.Columns.Add(Codigo, GetType(String))
        tabla.Columns.Add(Descripcion, GetType(String))
        tabla.Columns.Add(Requerido, GetType(Double))
        tabla.Columns.Add(Desecho, GetType(Double))
        Return tabla
    End Function

    Public Shared Function Normalizar(ByVal origen As DataTable) As DataTable
        Dim destino As DataTable = Vacia()
        If origen Is Nothing Then Return destino

        Dim colCodigo As String = If(origen.Columns.Contains("Cod_Producto"), "Cod_Producto", "CodProducto")
        Dim colRequerido As String = If(origen.Columns.Contains("Requerido"), "Requerido", "Cantidad_Ensamble")
        If Not origen.Columns.Contains(colCodigo) OrElse Not origen.Columns.Contains(colRequerido) Then Return destino

        For Each fila As DataRow In origen.Rows
            Dim nueva As DataRow = destino.NewRow()
            nueva(Codigo) = Convert.ToString(fila(colCodigo))
            If origen.Columns.Contains(Descripcion) Then nueva(Descripcion) = Convert.ToString(fila(Descripcion))
            nueva(Requerido) = Numero(fila(colRequerido))
            If origen.Columns.Contains(Desecho) Then nueva(Desecho) = Numero(fila(Desecho))
            destino.Rows.Add(nueva)
        Next
        Return destino
    End Function

    Private Shared Function Numero(ByVal valor As Object) As Double
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0
        Return Convert.ToDouble(valor)
    End Function
End Class
