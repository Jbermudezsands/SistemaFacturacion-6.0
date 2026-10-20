Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmModalidades
    Inherits Form

    Private _service As ModalidadService
    Private _registros As List(Of Modalidad)
    Private _indice As Integer = -1

    Private ReadOnly pnlHeader As New Panel()
    Private ReadOnly lblTitulo As New Label()
    Private ReadOnly lblSubtitulo As New Label()
    Private ReadOnly pnlCard As New Panel()
    Private ReadOnly lblCodigo As New Label()
    Private ReadOnly txtCodigo As New TextBox()
    Private ReadOnly lblNombre As New Label()
    Private ReadOnly txtNombre As New TextBox()
    Private ReadOnly lblEstado As New Label()
    Private ReadOnly btnPrimero As New Button()
    Private ReadOnly btnAnterior As New Button()
    Private ReadOnly btnSiguiente As New Button()
    Private ReadOnly btnUltimo As New Button()
    Private ReadOnly btnNuevo As New Button()
    Private ReadOnly btnGuardar As New Button()
    Private ReadOnly btnEliminar As New Button()
    Private ReadOnly btnSalir As New Button()

    Public Sub New()
        MyBase.New()
        ConstruirInterfaz()
        AddHandler Me.Load, AddressOf FrmModalidades_Load
    End Sub

    Private Sub ConstruirInterfaz()
        Me.Text = "Tipos de préstamo | Catálogos"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True
        Me.ClientSize = New Size(760, 440)
        Me.BackColor = Color.FromArgb(243, 246, 250)
        Me.Font = New Font("Segoe UI", 9.0F)

        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 94
        pnlHeader.BackColor = Color.FromArgb(24, 54, 92)
        lblTitulo.Text = "Tipos de préstamo"
        lblTitulo.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.White
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(28, 15)
        lblSubtitulo.Text = "Administración de modalidades de crédito"
        lblSubtitulo.Font = New Font("Segoe UI", 9.5F)
        lblSubtitulo.ForeColor = Color.FromArgb(211, 224, 241)
        lblSubtitulo.AutoSize = True
        lblSubtitulo.Location = New Point(31, 56)
        pnlHeader.Controls.Add(lblTitulo)
        pnlHeader.Controls.Add(lblSubtitulo)
        Me.Controls.Add(pnlHeader)

        pnlCard.Location = New Point(28, 118)
        pnlCard.Size = New Size(704, 194)
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(pnlCard)

        lblCodigo.Text = "Código de modalidad"
        lblCodigo.Location = New Point(25, 24)
        lblCodigo.AutoSize = True
        lblCodigo.ForeColor = Color.FromArgb(65, 78, 96)
        txtCodigo.Location = New Point(28, 49)
        txtCodigo.Size = New Size(200, 27)
        txtCodigo.MaxLength = 50

        lblNombre.Text = "Nombre de la modalidad"
        lblNombre.Location = New Point(25, 91)
        lblNombre.AutoSize = True
        lblNombre.ForeColor = Color.FromArgb(65, 78, 96)
        txtNombre.Location = New Point(28, 116)
        txtNombre.Size = New Size(640, 27)
        txtNombre.MaxLength = 150

        pnlCard.Controls.AddRange(New Control() {lblCodigo, txtCodigo, lblNombre, txtNombre})

        ConfigurarBoton(btnPrimero, "|◀ Primero", 28, 330, 105, Color.FromArgb(226, 233, 242), Color.FromArgb(35, 54, 78))
        ConfigurarBoton(btnAnterior, "◀ Anterior", 139, 330, 105, Color.FromArgb(226, 233, 242), Color.FromArgb(35, 54, 78))
        ConfigurarBoton(btnSiguiente, "Siguiente ▶", 250, 330, 105, Color.FromArgb(226, 233, 242), Color.FromArgb(35, 54, 78))
        ConfigurarBoton(btnUltimo, "Último ▶|", 361, 330, 95, Color.FromArgb(226, 233, 242), Color.FromArgb(35, 54, 78))
        ConfigurarBoton(btnNuevo, "Nuevo", 28, 375, 105, Color.FromArgb(16, 128, 96), Color.White)
        ConfigurarBoton(btnGuardar, "Guardar", 139, 375, 115, Color.FromArgb(30, 100, 181), Color.White)
        ConfigurarBoton(btnEliminar, "Eliminar", 260, 375, 105, Color.FromArgb(185, 55, 55), Color.White)
        ConfigurarBoton(btnSalir, "Cerrar", 622, 375, 110, Color.FromArgb(76, 88, 104), Color.White)
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(28, 310)
        lblEstado.ForeColor = Color.FromArgb(90, 105, 122)
        Me.Controls.AddRange(New Control() {btnPrimero, btnAnterior, btnSiguiente, btnUltimo, btnNuevo, btnGuardar, btnEliminar, btnSalir, lblEstado})

        AddHandler btnPrimero.Click, Sub(sender, e) MostrarRegistro(0)
        AddHandler btnAnterior.Click, Sub(sender, e) MostrarRegistro(_indice - 1)
        AddHandler btnSiguiente.Click, Sub(sender, e) MostrarRegistro(_indice + 1)
        AddHandler btnUltimo.Click, Sub(sender, e) MostrarRegistro(_registros.Count - 1)
        AddHandler btnNuevo.Click, AddressOf NuevoRegistro
        AddHandler btnGuardar.Click, AddressOf GuardarRegistro
        AddHandler btnEliminar.Click, AddressOf EliminarRegistro
        AddHandler btnSalir.Click, Sub(sender, e) Me.Close()
        AddHandler txtCodigo.KeyDown, AddressOf Codigo_KeyDown
        AddHandler txtNombre.KeyDown, AddressOf Nombre_KeyDown
    End Sub

    Private Shared Sub ConfigurarBoton(ByVal boton As Button, ByVal texto As String, ByVal x As Integer, ByVal y As Integer, ByVal ancho As Integer, ByVal fondo As Color, ByVal frente As Color)
        boton.Text = texto
        boton.Location = New Point(x, y)
        boton.Size = New Size(ancho, 34)
        boton.FlatStyle = FlatStyle.Flat
        boton.FlatAppearance.BorderSize = 0
        boton.BackColor = fondo
        boton.ForeColor = frente
        boton.Cursor = Cursors.Hand
        boton.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
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

    Private Sub NuevoRegistro(ByVal sender As Object, ByVal e As EventArgs)
        _indice = -1
        LimpiarCampos()
        txtCodigo.Focus()
        lblEstado.Text = "Nuevo registro"
        ActualizarNavegacion()
    End Sub

    Private Sub GuardarRegistro(ByVal sender As Object, ByVal e As EventArgs)
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

    Private Sub EliminarRegistro(ByVal sender As Object, ByVal e As EventArgs)
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

    Private Sub Codigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNombre.Focus()
        End If
    End Sub

    Private Sub Nombre_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnGuardar.PerformClick()
        End If
    End Sub
End Class
