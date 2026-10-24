Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Windows.Forms

'=====================================================================================================
'  SEGURIDAD
'  Perfiles, permisos por modulo y bloqueo de los controles de un formulario.
'
'  Uso en un formulario (reemplaza a la antigua funcion Bloqueo):
'      Seguridad.Bloqueo(Me, Acceso, "Ctas x Cobrar")
'
'  Bloqueo recorre todos los controles del formulario (incluye paneles, grupos y pestañas). Los botones
'  llevan en el Tag la accion que protegen (25 Grabar, 26 Anular, 27 Imprimir, 28 Procesar, 29 Eliminar,
'  30 Cambiar bodega, 31 Ver costo) y se habilitan o deshabilitan segun el permiso del perfil. Si el perfil
'  no tiene registro para el modulo (ej. Administrador) no se toca nada.
'=====================================================================================================
Public Class Seguridad

    Private ReadOnly _repositorio As SeguridadRepositorio

    Public Sub New(conexion As String)
        _repositorio = New SeguridadRepositorio(conexion)
    End Sub

    ''' <summary>Usa la cadena de conexión global del sistema.</summary>
    Public Sub New()
        Me.New(Conexion)
    End Sub

    '=================================================================================================
    ' BLOQUEO DE FORMULARIOS
    '=================================================================================================
    ''' <summary>
    ''' Aplica a los controles de "contenedor" los permisos que el perfil tiene sobre el modulo.
    ''' </summary>
    Public Shared Sub Bloqueo(ByVal contenedor As Control, ByVal nombrePerfil As String, ByVal modulo As String)
        If contenedor Is Nothing Then Exit Sub

        Dim permisos = New Seguridad().ObtenerPermisos(nombrePerfil, modulo)
        If Not permisos.Definido Then Exit Sub

        AplicarPermisoEditar(permisos, modulo)
        AplicarAControles(contenedor, permisos)
    End Sub

    ''' <summary>Los formularios de ventas consultan EditarFactura para permitir o no modificar un documento.</summary>
    Private Shared Sub AplicarPermisoEditar(ByVal permisos As PermisoModulo, ByVal modulo As String)
        Select Case modulo
            Case "Facturacion", "Cotizacion", "Devolucion de Venta", "Salida Bodega"
                Dim editar = permisos.Estado(AccionPermiso.Editar)
                If editar.HasValue Then EditarFactura = editar.Value
        End Select
    End Sub

    Private Shared Sub AplicarAControles(ByVal contenedor As Control, ByVal permisos As PermisoModulo)
        For Each control As Control In contenedor.Controls
            Dim accion As AccionPermiso
            If PermisoModulo.TryDesdeTag(control.Tag, accion) Then
                Dim estado = permisos.Estado(accion)
                If estado.HasValue Then
                    If TypeOf control Is Button Then
                        control.Enabled = estado.Value
                    ElseIf TypeOf control Is C1.Win.C1List.C1Combo Then
                        ' El combo de bodega solo se bloquea, nunca se habilita desde aquí
                        If accion = AccionPermiso.CambiarBodega AndAlso Not estado.Value Then control.Enabled = False
                    End If
                End If
            End If

            If control.HasChildren Then AplicarAControles(control, permisos)
        Next
    End Sub

    '=================================================================================================
    ' PERMISOS
    '=================================================================================================
    ''' <summary>Permisos del perfil (por nombre) sobre el modulo. Vacío si no hay registro.</summary>
    Public Function ObtenerPermisos(ByVal nombrePerfil As String, ByVal modulo As String) As PermisoModulo
        If String.IsNullOrEmpty(nombrePerfil) OrElse String.IsNullOrEmpty(modulo) Then Return New PermisoModulo()
        Return PermisoModulo.Desde(_repositorio.ObtenerAcceso(nombrePerfil, modulo))
    End Function

    Public Sub GuardarPermisos(ByVal perfil As PerfilSeguridad, ByVal modulo As String, ByVal permisos As PermisoModulo)
        If perfil Is Nothing Then Throw New ArgumentException("Seleccione un perfil.")
        If String.IsNullOrEmpty(modulo) Then Throw New ArgumentException("Seleccione un módulo.")
        If permisos Is Nothing OrElse Not permisos.Definido Then Throw New ArgumentException("No hay permisos que guardar.")

        _repositorio.GuardarAcceso(perfil.Id, modulo, permisos.ToString())
    End Sub

    '=================================================================================================
    ' PERFILES
    '=================================================================================================
    Public Function ListarPerfiles() As List(Of PerfilSeguridad)
        Return _repositorio.ListarPerfiles()
    End Function

    Public Sub CrearPerfil(ByVal nombre As String)
        nombre = If(nombre, "").Trim()
        If nombre.Length = 0 Then Throw New ArgumentException("Escriba el nombre del perfil.")
        If nombre.Length > 100 Then Throw New ArgumentException("El nombre del perfil no puede pasar de 100 caracteres.")
        If Not _repositorio.CrearPerfil(nombre) Then Throw New ArgumentException("Ya existe un perfil con el nombre '" & nombre & "'.")
    End Sub

    Public Function ContarUsuarios(ByVal perfil As PerfilSeguridad) As Integer
        Return _repositorio.ContarUsuarios(perfil.Nombre)
    End Function

    Public Sub EliminarPerfil(ByVal perfil As PerfilSeguridad)
        If perfil Is Nothing Then Throw New ArgumentException("Seleccione un perfil.")
        _repositorio.EliminarPerfil(perfil)
    End Sub
End Class

'=====================================================================================================
'  CATALOGO DE MODULOS
'  Qué acciones se pueden conceder en cada modulo y con qué texto se muestran en FrmAccesos.
'=====================================================================================================
Public Class ModuloAcceso

    Public ReadOnly Property Nombre As String
    Private ReadOnly _acciones As New List(Of KeyValuePair(Of AccionPermiso, String))

    Public Sub New(nombre As String)
        _Nombre = nombre
    End Sub

    ''' <summary>Acciones configurables del modulo, en el orden en que se muestran (Abrir va siempre).</summary>
    Public ReadOnly Property Acciones As IList(Of KeyValuePair(Of AccionPermiso, String))
        Get
            Return _acciones
        End Get
    End Property

    Public Function Agregar(accion As AccionPermiso, texto As String) As ModuloAcceso
        _acciones.Add(New KeyValuePair(Of AccionPermiso, String)(accion, texto))
        Return Me
    End Function

    Public Function Admite(accion As AccionPermiso) As Boolean
        If accion = AccionPermiso.Abrir Then Return True
        For Each par As KeyValuePair(Of AccionPermiso, String) In _acciones
            If par.Key = accion Then Return True
        Next
        Return False
    End Function

    Public Overrides Function ToString() As String
        Return Nombre
    End Function
End Class

Public NotInheritable Class CatalogoModulos

    Private Sub New()
    End Sub

    Public Shared Function Todos() As List(Of ModuloAcceso)
        Dim lista As New List(Of ModuloAcceso)()

        ' Documentos de venta y compra
        For Each nombre As String In New String() {"Facturacion", "Cotizacion", "Devolucion de Venta", "Salida Bodega", "Orden de Trabajo", "Compras"}
            lista.Add(Base(nombre).Agregar(AccionPermiso.Anular, "Anular").Agregar(AccionPermiso.Imprimir, "Imprimir").Agregar(AccionPermiso.Editar, "Editar"))
        Next

        lista.Add(Base("Pagos"))
        lista.Add(Base("Recibo de Caja"))
        lista.Add(Base("Ensamble").Agregar(AccionPermiso.Imprimir, "Imprimir"))
        lista.Add(Base("Arqueo de Caja").Agregar(AccionPermiso.Imprimir, "Imprimir"))

        ' Los botones del formulario de Cuentas por Cobrar usan estos Tag:
        '   25 Consultar y Nota de débito   26 Nota de crédito   27 Imprimir   28 Recibos y ajustes
        lista.Add(New ModuloAcceso("Ctas x Cobrar") _
                  .Agregar(AccionPermiso.Grabar, "Consultar / Nota de débito") _
                  .Agregar(AccionPermiso.Anular, "Nota de crédito") _
                  .Agregar(AccionPermiso.Procesar, "Recibos y ajustes") _
                  .Agregar(AccionPermiso.Eliminar, "Eliminar") _
                  .Agregar(AccionPermiso.Imprimir, "Imprimir estado de cuenta"))

        For Each nombre As String In New String() {"Ctas x Pagar", "Clientes", "Proveedores"}
            lista.Add(Base(nombre))
        Next
        lista.Add(Base("Productos").Agregar(AccionPermiso.VerCosto, "Ver costo"))
        For Each nombre As String In New String() {"Vendedores", "Bodegas", "Linea Produtos", "Impuestos", "Tasa de Cambio", "Servicios", "Cajeros"}
            lista.Add(Base(nombre))
        Next
        lista.Add(Base("Liquidacion").Agregar(AccionPermiso.Imprimir, "Imprimir"))
        lista.Add(Base("Transferencia de Bodegas").Agregar(AccionPermiso.Imprimir, "Imprimir").Agregar(AccionPermiso.CambiarBodega, "Cambiar bodega").Agregar(AccionPermiso.Editar, "Editar"))
        For Each nombre As String In New String() {"Rubros", "Tipos de Precios", "Notas de Debito y Credito", "Proyectos", "Tareas"}
            lista.Add(Base(nombre))
        Next

        lista.Add(New ModuloAcceso("Historico Facturacion").Agregar(AccionPermiso.Anular, "Anular").Agregar(AccionPermiso.Imprimir, "Imprimir"))
        lista.Add(New ModuloAcceso("Historico Compras").Agregar(AccionPermiso.Anular, "Anular").Agregar(AccionPermiso.Imprimir, "Imprimir"))
        lista.Add(Base("Plantilla Ventas/Compras").Agregar(AccionPermiso.Imprimir, "Imprimir"))

        For Each nombre As String In New String() {"Reportes Generales", "Reportes Ventas/Compras", "Reportes Inventario", "Reportes Cuentas x Cobrar"}
            lista.Add(New ModuloAcceso(nombre))
        Next

        lista.Add(New ModuloAcceso("Exportar a Excel").Agregar(AccionPermiso.Grabar, "Exportar"))
        lista.Add(New ModuloAcceso("Importacion").Agregar(AccionPermiso.Grabar, "Leer archivo").Agregar(AccionPermiso.Procesar, "Procesar"))
        lista.Add(Base("Usuarios"))
        lista.Add(New ModuloAcceso("Configurar").Agregar(AccionPermiso.Grabar, "Grabar"))
        lista.Add(New ModuloAcceso("Ajustes").Agregar(AccionPermiso.Grabar, "Iniciar"))
        lista.Add(Base("Personalizar"))
        lista.Add(New ModuloAcceso("Inventario Fisico") _
                  .Agregar(AccionPermiso.Grabar, "Grabar") _
                  .Agregar(AccionPermiso.Eliminar, "Iniciar") _
                  .Agregar(AccionPermiso.Procesar, "Procesar") _
                  .Agregar(AccionPermiso.Imprimir, "Imprimir"))
        lista.Add(New ModuloAcceso("Actualizacion"))
        lista.Add(Base("Perfiles y Accesos"))
        Return lista
    End Function

    ''' <summary>Modulo con las acciones habituales: Grabar, Eliminar y Procesar.</summary>
    Private Shared Function Base(nombre As String) As ModuloAcceso
        Return New ModuloAcceso(nombre) _
            .Agregar(AccionPermiso.Grabar, "Grabar") _
            .Agregar(AccionPermiso.Eliminar, "Eliminar") _
            .Agregar(AccionPermiso.Procesar, "Procesar")
    End Function
End Class
