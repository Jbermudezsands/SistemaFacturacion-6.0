Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Text

'=====================================================================================================
'  SEGURIDAD - MODELOS
'  Acciones que se pueden conceder a un perfil sobre un modulo y la cadena que se guarda en
'  Accesos.Acceso (ej. "Abrir,Grabar,NoEliminar,NoAnular").
'
'  Los valores de las acciones con boton coinciden con el Tag que llevan los botones de los formularios:
'  GRABAR=25  ANULAR=26  IMPRIMIR=27  PROCESAR=28  ELIMINAR=29  CAMBIARBODEGA=30  VERCOSTO=31
'=====================================================================================================
Public Enum AccionPermiso
    Abrir = 1
    Editar = 2
    Previo = 3
    Grabar = 25
    Anular = 26
    Imprimir = 27
    Procesar = 28
    Eliminar = 29
    CambiarBodega = 30
    VerCosto = 31
End Enum

''' <summary>Perfil de seguridad (tabla Perfil).</summary>
Public Class PerfilSeguridad
    Public ReadOnly Property Id As Long
    Public ReadOnly Property Nombre As String

    Public Sub New(id As Long, nombre As String)
        _Id = id
        _Nombre = nombre
    End Sub

    Public Overrides Function ToString() As String
        Return Nombre
    End Function
End Class

''' <summary>
''' Permisos de un perfil sobre un modulo. Cada accion puede estar concedida (True), negada (False)
''' o sin definir (Nothing): lo que no esta definido no se toca en el formulario.
''' </summary>
Public Class PermisoModulo

    ''' <summary>Orden en que se guardan las acciones en la cadena.</summary>
    Public Shared ReadOnly Orden As AccionPermiso() = {
        AccionPermiso.Abrir, AccionPermiso.Grabar, AccionPermiso.Eliminar, AccionPermiso.Anular,
        AccionPermiso.Procesar, AccionPermiso.Imprimir, AccionPermiso.Editar, AccionPermiso.CambiarBodega,
        AccionPermiso.Previo, AccionPermiso.VerCosto}

    Private ReadOnly _valores As New Dictionary(Of AccionPermiso, Boolean)

    ''' <summary>True si el perfil tiene al menos una accion definida para el modulo.</summary>
    Public ReadOnly Property Definido As Boolean
        Get
            Return _valores.Count > 0
        End Get
    End Property

    ''' <summary>Interpreta la cadena guardada en Accesos.Acceso. Ignora los nombres que no conoce.</summary>
    Public Shared Function Desde(cadena As String) As PermisoModulo
        Dim permiso As New PermisoModulo()
        If String.IsNullOrEmpty(cadena) Then Return permiso

        For Each parte As String In cadena.Split(","c)
            Dim texto = parte.Trim()
            If texto.Length = 0 Then Continue For

            Dim concedido = True
            If texto.StartsWith("No", StringComparison.Ordinal) Then
                concedido = False
                texto = texto.Substring(2)
            End If

            For Each accion As AccionPermiso In Orden
                If String.Equals(accion.ToString(), texto, StringComparison.OrdinalIgnoreCase) Then
                    permiso._valores(accion) = concedido
                    Exit For
                End If
            Next
        Next
        Return permiso
    End Function

    ''' <summary>Accion que corresponde al Tag de un boton (25 a 31). False si el Tag no es de seguridad.</summary>
    Public Shared Function TryDesdeTag(tag As Object, ByRef accion As AccionPermiso) As Boolean
        If tag Is Nothing Then Return False

        Dim numero As Integer
        If Not Integer.TryParse(Convert.ToString(tag), numero) Then Return False

        Select Case numero
            Case 25 To 31
                accion = CType(numero, AccionPermiso)
                Return True
        End Select
        Return False
    End Function

    ''' <summary>Estado de una accion: True concedida, False negada, Nothing sin definir.</summary>
    Public Function Estado(accion As AccionPermiso) As Boolean?
        Dim valor As Boolean
        If _valores.TryGetValue(accion, valor) Then Return valor
        Return Nothing
    End Function

    Public Sub Establecer(accion As AccionPermiso, concedido As Boolean)
        _valores(accion) = concedido
    End Sub

    Public Function Clonar() As PermisoModulo
        Dim copia As New PermisoModulo()
        For Each par As KeyValuePair(Of AccionPermiso, Boolean) In _valores
            copia._valores(par.Key) = par.Value
        Next
        Return copia
    End Function

    ''' <summary>Cadena para guardar en Accesos.Acceso (solo las acciones definidas).</summary>
    Public Overrides Function ToString() As String
        Dim texto As New StringBuilder()
        For Each accion As AccionPermiso In Orden
            Dim valor As Boolean
            If _valores.TryGetValue(accion, valor) Then
                If texto.Length > 0 Then texto.Append(","c)
                If Not valor Then texto.Append("No")
                texto.Append(accion.ToString())
            End If
        Next
        Return texto.ToString()
    End Function
End Class
