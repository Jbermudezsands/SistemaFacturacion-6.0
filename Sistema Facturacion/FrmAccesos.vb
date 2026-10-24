Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

'=====================================================================================================
'  PERFILES Y ACCESOS
'  Elegir un perfil y un módulo, marcar lo que el perfil puede hacer y guardar.
'  La lógica (perfiles, permisos, bloqueo de formularios) vive en la clase Seguridad.
'=====================================================================================================
Public Class FrmAccesos

    Private _seguridad As Seguridad
    Private _modulos As List(Of ModuloAcceso)
    Private _permisosCargados As PermisoModulo
    Private _cargando As Boolean
    Private ReadOnly _casillas As New Dictionary(Of AccionPermiso, CheckBox)

    Private Shared ReadOnly ColorSeleccion As Color = Color.FromArgb(238, 242, 255)
    Private Shared ReadOnly ColorSeleccionTexto As Color = Color.FromArgb(30, 64, 175)
    Private Shared ReadOnly ColorTexto As Color = Color.FromArgb(31, 41, 55)
    Private Shared ReadOnly ColorMuted As Color = Color.FromArgb(100, 116, 139)
    Private Shared ReadOnly ColorOk As Color = Color.FromArgb(21, 128, 61)
    Private Shared ReadOnly ColorError As Color = Color.FromArgb(185, 28, 28)

    Private ReadOnly Property PerfilSeleccionado As PerfilSeguridad
        Get
            Return TryCast(Me.LstPerfiles.SelectedItem, PerfilSeguridad)
        End Get
    End Property

    Private ReadOnly Property ModuloSeleccionado As ModuloAcceso
        Get
            Return TryCast(Me.LstModulos.SelectedItem, ModuloAcceso)
        End Get
    End Property

    '=================================================================================================
    ' CARGA
    '=================================================================================================
    Private Sub FrmAccesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _seguridad = New Seguridad(Conexion)

        _casillas(AccionPermiso.Abrir) = Me.ChkAbrir
        _casillas(AccionPermiso.Grabar) = Me.ChkGrabar
        _casillas(AccionPermiso.Eliminar) = Me.ChkEliminar
        _casillas(AccionPermiso.Anular) = Me.ChkAnular
        _casillas(AccionPermiso.Procesar) = Me.ChkProcesar
        _casillas(AccionPermiso.Imprimir) = Me.ChkImprimir
        _casillas(AccionPermiso.Editar) = Me.ChkEditar
        _casillas(AccionPermiso.CambiarBodega) = Me.ChkCambiarBodega
        _casillas(AccionPermiso.VerCosto) = Me.ChkVerCosto

        _modulos = CatalogoModulos.Todos()
        FiltrarModulos()
        CargarPerfiles(Nothing)
        MostrarPermisos()
    End Sub

    Private Sub CargarPerfiles(ByVal seleccionar As String)
        Try
            Dim perfiles = _seguridad.ListarPerfiles()
            Me.LstPerfiles.BeginUpdate()
            Me.LstPerfiles.Items.Clear()
            For Each perfil As PerfilSeguridad In perfiles
                Me.LstPerfiles.Items.Add(perfil)
                If seleccionar IsNot Nothing AndAlso String.Equals(perfil.Nombre, seleccionar, StringComparison.OrdinalIgnoreCase) Then
                    Me.LstPerfiles.SelectedItem = perfil
                End If
            Next
            Me.LstPerfiles.EndUpdate()
        Catch ex As Exception
            MostrarEstado("No se pudieron cargar los perfiles: " & ex.Message, ColorError)
        End Try
        Me.BtnEliminarPerfil.Enabled = (PerfilSeleccionado IsNot Nothing)
    End Sub

    Private Sub FiltrarModulos()
        Dim texto = Me.TxtBuscarModulo.Text.Trim()
        Dim anterior = ModuloSeleccionado

        Me.LstModulos.BeginUpdate()
        Me.LstModulos.Items.Clear()
        For Each modulo As ModuloAcceso In _modulos
            If texto.Length = 0 OrElse modulo.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 Then
                Me.LstModulos.Items.Add(modulo)
                If anterior IsNot Nothing AndAlso modulo Is anterior Then Me.LstModulos.SelectedItem = modulo
            End If
        Next
        Me.LstModulos.EndUpdate()
    End Sub

    '=================================================================================================
    ' SELECCIÓN
    '=================================================================================================
    Private Sub LstPerfiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstPerfiles.SelectedIndexChanged
        Me.BtnEliminarPerfil.Enabled = (PerfilSeleccionado IsNot Nothing)
        MostrarPermisos()
    End Sub

    Private Sub LstModulos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstModulos.SelectedIndexChanged
        MostrarPermisos()
    End Sub

    Private Sub TxtBuscarModulo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtBuscarModulo.TextChanged
        FiltrarModulos()
        MostrarPermisos()
    End Sub

    ''' <summary>Muestra solo las acciones del módulo y las marca según lo guardado para el perfil.</summary>
    Private Sub MostrarPermisos()
        Dim perfil = PerfilSeleccionado
        Dim modulo = ModuloSeleccionado

        _cargando = True
        _permisosCargados = Nothing
        Me.BtnGuardar.Enabled = False
        For Each par As KeyValuePair(Of AccionPermiso, CheckBox) In _casillas
            par.Value.Visible = False
            par.Value.Checked = False
        Next

        If perfil Is Nothing OrElse modulo Is Nothing Then
            Me.LblContexto.Text = "Elija un perfil y un módulo para ver sus permisos."
            _cargando = False
            Exit Sub
        End If

        Try
            _permisosCargados = _seguridad.ObtenerPermisos(perfil.Nombre, modulo.Nombre)

            ' Lo que no está definido no se bloquea: se muestra marcado, como funciona en la realidad
            Me.ChkAbrir.Visible = True
            Me.ChkAbrir.Text = "Abrir"
            Me.ChkAbrir.Checked = _permisosCargados.Estado(AccionPermiso.Abrir).GetValueOrDefault(True)
            For Each par As KeyValuePair(Of AccionPermiso, String) In modulo.Acciones
                Dim casilla = _casillas(par.Key)
                casilla.Text = par.Value
                casilla.Checked = _permisosCargados.Estado(par.Key).GetValueOrDefault(True)
                casilla.Visible = True
            Next

            Dim ayuda = If(_permisosCargados.Definido,
                           "Marque lo que este perfil puede hacer.",
                           "Sin configuración guardada: el perfil tiene acceso completo.")
            Me.LblContexto.Text = perfil.Nombre & "  ·  " & modulo.Nombre & vbCrLf & ayuda
            Me.BtnGuardar.Enabled = True
        Catch ex As Exception
            Me.LblContexto.Text = "No se pudieron leer los permisos."
            MostrarEstado("No se pudieron leer los permisos: " & ex.Message, ColorError)
        Finally
            _cargando = False
        End Try
    End Sub

    '=================================================================================================
    ' GUARDAR
    '=================================================================================================
    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGuardar.Click
        Dim perfil = PerfilSeleccionado
        Dim modulo = ModuloSeleccionado
        If perfil Is Nothing OrElse modulo Is Nothing OrElse _permisosCargados Is Nothing Then Exit Sub

        ' Las acciones que el módulo no muestra se conservan tal como estaban guardadas
        Dim permisos = _permisosCargados.Clonar()
        permisos.Establecer(AccionPermiso.Abrir, Me.ChkAbrir.Checked)
        For Each par As KeyValuePair(Of AccionPermiso, String) In modulo.Acciones
            permisos.Establecer(par.Key, _casillas(par.Key).Checked)
        Next

        Try
            _seguridad.GuardarPermisos(perfil, modulo.Nombre, permisos)
            _permisosCargados = permisos
            MostrarEstado("Permisos guardados: " & perfil.Nombre & " · " & modulo.Nombre & ". Se aplican la próxima vez que el usuario abra el formulario.", ColorOk)
        Catch ex As Exception
            MostrarEstado("No se pudo guardar: " & ex.Message, ColorError)
            MsgBox("No se pudieron guardar los permisos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        End Try
    End Sub

    '=================================================================================================
    ' PERFILES
    '=================================================================================================
    Private Sub BtnNuevoPerfil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevoPerfil.Click
        My.Forms.FrmAccesosAddPerfil.TxtPerfil.Text = ""
        My.Forms.FrmAccesosAddPerfil.ShowDialog()
        CargarPerfiles(My.Forms.FrmAccesosAddPerfil.TxtPerfil.Text.Trim())
        MostrarPermisos()
    End Sub

    Private Sub BtnEliminarPerfil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEliminarPerfil.Click
        Dim perfil = PerfilSeleccionado
        If perfil Is Nothing Then Exit Sub

        Try
            Dim usuarios = _seguridad.ContarUsuarios(perfil)
            Dim mensaje = "¿Está seguro de eliminar el perfil '" & perfil.Nombre & "'?"
            If usuarios > 0 Then mensaje &= vbLf & "Se eliminarán también los " & usuarios & " usuario(s) que tienen este perfil."

            If MsgBox(mensaje, MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Zeus Facturacion") <> MsgBoxResult.Yes Then Exit Sub

            _seguridad.EliminarPerfil(perfil)
            CargarPerfiles(Nothing)
            MostrarPermisos()
            MostrarEstado("Perfil eliminado: " & perfil.Nombre, ColorOk)
        Catch ex As Exception
            MostrarEstado("No se pudo eliminar el perfil: " & ex.Message, ColorError)
        End Try
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    '=================================================================================================
    ' PRESENTACIÓN
    '=================================================================================================
    Private Sub MostrarEstado(ByVal texto As String, ByVal color As Color)
        Me.LblEstado.Text = texto
        Me.LblEstado.ForeColor = color
    End Sub

    Private Sub Casilla_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ChkAbrir.CheckedChanged, ChkGrabar.CheckedChanged, ChkEliminar.CheckedChanged, ChkAnular.CheckedChanged,
                ChkProcesar.CheckedChanged, ChkImprimir.CheckedChanged, ChkEditar.CheckedChanged,
                ChkCambiarBodega.CheckedChanged, ChkVerCosto.CheckedChanged
        If _cargando Then Exit Sub
        MostrarEstado("Hay cambios sin guardar.", ColorMuted)
    End Sub

    ''' <summary>Dibuja las filas de las dos listas con el estilo del sistema (selección azul claro).</summary>
    Private Sub Lista_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles LstPerfiles.DrawItem, LstModulos.DrawItem
        If e.Index < 0 Then Exit Sub
        Dim lista = DirectCast(sender, ListBox)
        Dim seleccionado = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        Using fondo As New SolidBrush(If(seleccionado, ColorSeleccion, lista.BackColor))
            e.Graphics.FillRectangle(fondo, e.Bounds)
        End Using
        If seleccionado Then
            Using barra As New SolidBrush(Color.FromArgb(37, 99, 235))
                e.Graphics.FillRectangle(barra, e.Bounds.X, e.Bounds.Y, 3, e.Bounds.Height)
            End Using
        End If

        Dim texto = lista.Items(e.Index).ToString()
        Dim area As New Rectangle(e.Bounds.X + 14, e.Bounds.Y, e.Bounds.Width - 14, e.Bounds.Height)
        TextRenderer.DrawText(e.Graphics, texto, lista.Font, area, If(seleccionado, ColorSeleccionTexto, ColorTexto),
                              TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)
    End Sub
End Class
