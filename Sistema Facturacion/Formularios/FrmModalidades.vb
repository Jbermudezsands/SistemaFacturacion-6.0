Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

Partial Public Class FrmModalidades
    Inherits Form

    Private _service As ModalidadService
    Private _registros As List(Of Modalidad)
    Private _indice As Integer = -1

    Private ReadOnly _colorCampo As Color = Color.FromArgb(249, 250, 251)
    Private ReadOnly _colorCampoActivo As Color = Color.FromArgb(239, 246, 255)

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddHandler Me.Load, AddressOf FrmModalidades_Load
    End Sub

    Private Sub FrmModalidades_Load(ByVal sender As Object, ByVal e As EventArgs)
        Try
            ' Conexion debe ser la variable global con la cadena SQL Server del proyecto.
            _service = New ModalidadService(Conexion)
            RecargarRegistros()
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar el catálogo de modalidades." & Environment.NewLine & ex.Message, "Modalidades", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RecargarRegistros()
        _registros = _service.Listar()
        If _registros.Count = 0 Then
            _indice = -1
            LimpiarCampos()
            lblEstado.Text = "No hay modalidades registradas."
        Else
            MostrarRegistro(Math.Max(0, Math.Min(_indice, _registros.Count - 1)))
        End If
        ActualizarNavegacion()
    End Sub

    Private Sub MostrarRegistro(ByVal nuevoIndice As Integer)
        If _registros Is Nothing OrElse _registros.Count = 0 Then Return
        If nuevoIndice < 0 OrElse nuevoIndice >= _registros.Count Then Return
        _indice = nuevoIndice
        txtCodigo.Text = _registros(_indice).CodModalidad
        txtNombre.Text = _registros(_indice).Nombre
        lblEstado.Text = "Registro " & (_indice + 1).ToString() & " de " & _registros.Count.ToString()
        ActualizarNavegacion()
    End Sub

    Private Sub NuevoRegistro(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        _indice = -1
        LimpiarCampos()
        txtCodigo.Focus()
        lblEstado.Text = "Nuevo registro"
        ActualizarNavegacion()
    End Sub

    Private Sub GuardarRegistro(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            Dim codigo As String = txtCodigo.Text.Trim()
            Dim existe As Boolean = _service.Listar().Exists(Function(m) String.Equals(m.CodModalidad, codigo, StringComparison.OrdinalIgnoreCase))
            _service.Guardar(codigo, txtNombre.Text)
            MessageBox.Show(If(existe, "Modalidad actualizada correctamente.", "Modalidad agregada correctamente."), "Modalidades", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RecargarRegistros()
            For i As Integer = 0 To _registros.Count - 1
                If String.Equals(_registros(i).CodModalidad, codigo, StringComparison.OrdinalIgnoreCase) Then
                    MostrarRegistro(i)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub EliminarRegistro(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click
        If String.IsNullOrWhiteSpace(txtCodigo.Text) Then
            MessageBox.Show("Seleccione una modalidad para eliminar.", "Modalidades", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("¿Desea eliminar la modalidad " & txtNombre.Text & "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            _service.Eliminar(txtCodigo.Text)
            RecargarRegistros()
            MessageBox.Show("Modalidad eliminada correctamente.", "Modalidades", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No se pudo eliminar la modalidad." & Environment.NewLine & ex.Message, "Modalidades", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtCodigo.Clear()
        txtNombre.Clear()
    End Sub

    Private Sub ActualizarNavegacion()
        Dim hayDatos As Boolean = _registros IsNot Nothing AndAlso _registros.Count > 0 AndAlso _indice >= 0
        btnPrimero.Enabled = hayDatos AndAlso _indice > 0
        btnAnterior.Enabled = hayDatos AndAlso _indice > 0
        btnSiguiente.Enabled = hayDatos AndAlso _indice < _registros.Count - 1
        btnUltimo.Enabled = hayDatos AndAlso _indice < _registros.Count - 1
        btnEliminar.Enabled = hayDatos
    End Sub

    Private Sub Codigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNombre.Focus()
        End If
    End Sub

    Private Sub Nombre_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnGuardar.PerformClick()
        End If
    End Sub

    ' ===== Navegación =====

    Private Sub btnPrimero_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrimero.Click
        MostrarRegistro(0)
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnterior.Click
        MostrarRegistro(_indice - 1)
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        MostrarRegistro(_indice + 1)
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUltimo.Click
        If _registros IsNot Nothing Then MostrarRegistro(_registros.Count - 1)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    ' ===== Detalles visuales =====

    ' Borde suave de la tarjeta blanca.
    Private Sub pnlCard_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlCard.Paint
        Using p As New Pen(Color.FromArgb(229, 231, 235))
            e.Graphics.DrawRectangle(p, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1)
        End Using
    End Sub

    ' Línea de acento bajo el encabezado.
    Private Sub pnlHeader_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlHeader.Paint
        Using b As New SolidBrush(Color.FromArgb(59, 130, 246))
            e.Graphics.FillRectangle(b, 0, pnlHeader.Height - 3, pnlHeader.Width, 3)
        End Using
    End Sub

    ' Resalta el campo que tiene el foco.
    Private Sub Campo_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtCodigo.Enter, txtNombre.Enter
        DirectCast(sender, TextBox).BackColor = _colorCampoActivo
    End Sub

    Private Sub Campo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCodigo.Leave, txtNombre.Leave
        DirectCast(sender, TextBox).BackColor = _colorCampo
    End Sub

End Class
