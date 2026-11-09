Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Pide la clasificacion y el motivo con que un hallazgo de la auditoria deja de mostrarse (p. ej. costo ya declarado
''' al fisco). Controles creados por codigo, sin Designer.
''' </summary>
Public Class FrmMarcarHallazgo
    Inherits Form

    Private CboClasificacion As ComboBox
    Private TxtMotivo As TextBox

    Public ReadOnly Property Clasificacion As String
        Get
            Return Convert.ToString(CboClasificacion.SelectedItem)
        End Get
    End Property

    Public ReadOnly Property Motivo As String
        Get
            Return TxtMotivo.Text.Trim()
        End Get
    End Property

    Public Sub New(ByVal resumenHallazgo As String)
        Me.Text = "Marcar hallazgo como revisado"
        Me.ClientSize = New Size(480, 330)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False

        Dim LblResumen As New Label
        LblResumen.Text = resumenHallazgo
        LblResumen.Location = New Point(16, 12)
        LblResumen.Size = New Size(448, 96)
        LblResumen.BorderStyle = BorderStyle.FixedSingle
        LblResumen.BackColor = Color.FromArgb(246, 248, 252)
        LblResumen.Padding = New Padding(6)

        Dim LblAviso As New Label
        LblAviso.Text = "El hallazgo dejará de aparecer en las próximas auditorías. No se modifica ningún dato del documento; " &
                        "queda registrado quién lo marcó, cuándo y por qué."
        LblAviso.Location = New Point(16, 114)
        LblAviso.Size = New Size(448, 34)
        LblAviso.ForeColor = Color.FromArgb(120, 70, 0)

        Dim LblClas As New Label
        LblClas.Text = "Clasificación"
        LblClas.AutoSize = True
        LblClas.Location = New Point(16, 156)
        CboClasificacion = New ComboBox
        CboClasificacion.DropDownStyle = ComboBoxStyle.DropDownList
        CboClasificacion.Items.Add(ExclusionesAuditoria.ClasificacionDeclarado)
        CboClasificacion.Items.Add(ExclusionesAuditoria.ClasificacionAutoauditado)
        CboClasificacion.Items.Add(ExclusionesAuditoria.ClasificacionRevisado)
        CboClasificacion.SelectedIndex = 0
        CboClasificacion.Location = New Point(16, 172)
        CboClasificacion.Size = New Size(448, 21)

        Dim LblMot As New Label
        LblMot.Text = "Motivo (obligatorio)"
        LblMot.AutoSize = True
        LblMot.Location = New Point(16, 202)
        TxtMotivo = New TextBox
        TxtMotivo.Multiline = True
        TxtMotivo.MaxLength = 500
        TxtMotivo.ScrollBars = ScrollBars.Vertical
        TxtMotivo.Location = New Point(16, 218)
        TxtMotivo.Size = New Size(448, 56)

        Dim BtnAceptar As New Button
        BtnAceptar.Text = "Marcar"
        BtnAceptar.Location = New Point(264, 286)
        BtnAceptar.Size = New Size(96, 32)
        Dim BtnCancelar As New Button
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.DialogResult = DialogResult.Cancel
        BtnCancelar.Location = New Point(368, 286)
        BtnCancelar.Size = New Size(96, 32)

        Me.Controls.AddRange(New Control() {LblResumen, LblAviso, LblClas, CboClasificacion, LblMot, TxtMotivo, BtnAceptar, BtnCancelar})
        Me.CancelButton = BtnCancelar
        AddHandler BtnAceptar.Click, AddressOf BtnAceptar_Click
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TxtMotivo.Text.Trim().Length < 5 Then
            MessageBox.Show("Indique el motivo (mínimo 5 caracteres).", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtMotivo.Focus()
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
