Option Strict On
Option Explicit On

Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Lista los hallazgos de la auditoria marcados como Revisado / Autoauditado / Declarado al fisco y permite regresar
''' a la auditoria los que se marcaron por error. Controles creados por codigo, sin Designer.
''' </summary>
Public Class FrmHallazgosExcluidos
    Inherits Form

    Private TxtBuscar As TextBox
    Private ChkReactivados As CheckBox
    Private Grid As DataGridView
    Private BtnRegresar As Button
    Private BtnActualizar As Button
    Private BtnCerrar As Button
    Private LblResumen As Label

    Private _tabla As DataTable

    ''' <summary>True si se regreso algun hallazgo: la auditoria abierta debe ejecutarse de nuevo para mostrarlo.</summary>
    Public Property HuboReactivaciones As Boolean

    Public Sub New()
        ConstruirControles()
    End Sub

    Private Sub ConstruirControles()
        Me.Text = "Hallazgos excluidos de la auditoría"
        Me.ClientSize = New Size(980, 520)
        Me.MinimumSize = New Size(760, 420)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.BackColor = Color.FromArgb(240, 242, 245)

        Dim PnlHeader As New Panel
        PnlHeader.Dock = DockStyle.Top
        PnlHeader.Height = 58
        PnlHeader.BackColor = Color.FromArgb(31, 56, 100)
        Dim LblTitulo As New Label
        LblTitulo.Text = "Hallazgos excluidos de la auditoría"
        LblTitulo.ForeColor = Color.White
        LblTitulo.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        LblTitulo.AutoSize = True
        LblTitulo.Location = New Point(16, 8)
        Dim LblSub As New Label
        LblSub.Text = "No aparecen en la auditoría. Si se marcó uno por error, selecciónelo y use «Regresar a la auditoría»."
        LblSub.ForeColor = Color.FromArgb(200, 214, 235)
        LblSub.AutoSize = True
        LblSub.Location = New Point(18, 34)
        PnlHeader.Controls.Add(LblTitulo)
        PnlHeader.Controls.Add(LblSub)

        Dim PnlAcciones As New Panel
        PnlAcciones.Dock = DockStyle.Bottom
        PnlAcciones.Height = 56
        PnlAcciones.BackColor = Color.White
        BtnRegresar = New Button
        BtnRegresar.Text = "Regresar a la auditoría"
        BtnRegresar.Location = New Point(16, 10)
        BtnRegresar.Size = New Size(170, 36)
        BtnRegresar.Enabled = False
        BtnActualizar = New Button
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.Location = New Point(194, 10)
        BtnActualizar.Size = New Size(96, 36)
        BtnCerrar = New Button
        BtnCerrar.Text = "Cerrar"
        BtnCerrar.Location = New Point(298, 10)
        BtnCerrar.Size = New Size(96, 36)
        LblResumen = New Label
        LblResumen.AutoSize = False
        LblResumen.Location = New Point(410, 10)
        LblResumen.Size = New Size(550, 36)
        LblResumen.TextAlign = ContentAlignment.MiddleLeft
        LblResumen.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        PnlAcciones.Controls.AddRange(New Control() {BtnRegresar, BtnActualizar, BtnCerrar, LblResumen})

        Dim PnlFiltros As New Panel
        PnlFiltros.BackColor = Color.White
        PnlFiltros.Location = New Point(16, 66)
        PnlFiltros.Size = New Size(948, 44)
        PnlFiltros.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Dim LblB As New Label
        LblB.Text = "Buscar (documento, producto, motivo, usuario)"
        LblB.AutoSize = True
        LblB.Location = New Point(8, 14)
        TxtBuscar = New TextBox
        TxtBuscar.Location = New Point(270, 11)
        TxtBuscar.Size = New Size(260, 20)
        ChkReactivados = New CheckBox
        ChkReactivados.Text = "Mostrar también los ya regresados a la auditoría"
        ChkReactivados.AutoSize = True
        ChkReactivados.Location = New Point(550, 13)
        PnlFiltros.Controls.AddRange(New Control() {LblB, TxtBuscar, ChkReactivados})

        Grid = New DataGridView
        Grid.Location = New Point(16, 118)
        Grid.Size = New Size(948, 338)
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.ReadOnly = True
        Grid.AllowUserToAddRows = False
        Grid.AllowUserToDeleteRows = False
        Grid.AllowUserToResizeRows = False
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Grid.MultiSelect = False
        Grid.RowHeadersVisible = False
        Grid.BackgroundColor = Color.White
        Grid.BorderStyle = BorderStyle.None
        Grid.ColumnHeadersHeight = 32
        Grid.RowTemplate.Height = 26
        Grid.AutoGenerateColumns = False
        Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 252)

        Me.Controls.Add(Grid)
        Me.Controls.Add(PnlFiltros)
        Me.Controls.Add(PnlAcciones)
        Me.Controls.Add(PnlHeader)
        PnlHeader.SendToBack()
        PnlAcciones.SendToBack()
        Grid.BringToFront()

        AgregarColumna("FechaMarca", "Marcado el", 118, "dd/MM/yyyy HH:mm", False)
        AgregarColumna("Clasificacion", "Clasificación", 110, Nothing, False)
        AgregarColumna("Codigo", "Control", 70, Nothing, False)
        AgregarColumna("Tipo_Documento", "Tipo", 100, Nothing, False)
        AgregarColumna("Numero_Documento", "Documento", 80, Nothing, False)
        AgregarColumna("Fecha_Documento", "Fecha doc.", 75, "dd/MM/yyyy", False)
        AgregarColumna("Cod_Producto", "Producto", 90, Nothing, False)
        AgregarColumna("Cantidad", "Cantidad", 70, "N2", True)
        AgregarColumna("CostoUnitario", "Costo", 90, "N6", True)
        AgregarColumna("Motivo", "Motivo", 220, Nothing, False)
        AgregarColumna("Usuario", "Marcado por", 90, Nothing, False)
        AgregarColumna("Estado", "Estado", 110, Nothing, False)
        AgregarColumna("FechaReactivacion", "Regresado el", 118, "dd/MM/yyyy HH:mm", False)
        AgregarColumna("UsuarioReactivacion", "Regresado por", 90, Nothing, False)
        AgregarColumna("MotivoReactivacion", "Motivo al regresar", 200, Nothing, False)

        AddHandler Me.Load, AddressOf Formulario_Load
        AddHandler BtnRegresar.Click, AddressOf BtnRegresar_Click
        AddHandler BtnActualizar.Click, AddressOf BtnActualizar_Click
        AddHandler BtnCerrar.Click, AddressOf BtnCerrar_Click
        AddHandler TxtBuscar.TextChanged, AddressOf TxtBuscar_TextChanged
        AddHandler ChkReactivados.CheckedChanged, AddressOf ChkReactivados_CheckedChanged
        AddHandler Grid.SelectionChanged, AddressOf Grid_SelectionChanged
    End Sub

    Private Sub AgregarColumna(ByVal campo As String, ByVal titulo As String, ByVal ancho As Integer, ByVal formato As String, ByVal derecha As Boolean)
        Dim c As New DataGridViewTextBoxColumn
        c.DataPropertyName = campo
        c.Name = "col" & campo
        c.HeaderText = titulo
        c.Width = ancho
        c.SortMode = DataGridViewColumnSortMode.Automatic
        If formato IsNot Nothing Then c.DefaultCellStyle.Format = formato
        If derecha Then c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid.Columns.Add(c)
    End Sub

    ' ------------------------------------------------------------------
    ' Datos
    ' ------------------------------------------------------------------

    Private Sub Formulario_Load(ByVal sender As Object, ByVal e As EventArgs)
        Cargar()
    End Sub

    Private Sub Cargar()
        Me.Cursor = Cursors.WaitCursor
        Try
            _tabla = ExclusionesAuditoria.Listar(Conexion, ChkReactivados.Checked)
            _tabla.Columns.Add("Estado", GetType(String))
            For Each fila As DataRow In _tabla.Rows
                fila("Estado") = If(Convert.ToBoolean(fila("Activo")), "Excluido", "Regresado")
            Next
            Grid.DataSource = _tabla.DefaultView
            AplicarFiltro()
        Catch ex As Exception
            Grid.DataSource = Nothing
            _tabla = Nothing
            LblResumen.Text = ""
            MessageBox.Show(ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Me.Cursor = Cursors.Default
            ActualizarBoton()
        End Try
    End Sub

    Private Sub AplicarFiltro()
        If _tabla Is Nothing Then Return
        Dim texto As String = TxtBuscar.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
        If texto = "" Then
            _tabla.DefaultView.RowFilter = ""
        Else
            _tabla.DefaultView.RowFilter =
                "Numero_Documento LIKE '%" & texto & "%' OR Cod_Producto LIKE '%" & texto & "%' OR Motivo LIKE '%" & texto &
                "%' OR Usuario LIKE '%" & texto & "%' OR Clasificacion LIKE '%" & texto & "%'"
        End If
        LblResumen.Text = _tabla.DefaultView.Count.ToString() & " hallazgo(s) en la lista"
        ActualizarBoton()
    End Sub

    Private Function FilaSeleccionada() As DataRowView
        If Grid.CurrentRow Is Nothing Then Return Nothing
        Return TryCast(Grid.CurrentRow.DataBoundItem, DataRowView)
    End Function

    Private Sub ActualizarBoton()
        Dim fila As DataRowView = FilaSeleccionada()
        BtnRegresar.Enabled = (fila IsNot Nothing AndAlso Convert.ToBoolean(fila("Activo")))
    End Sub

    ' ------------------------------------------------------------------
    ' Eventos
    ' ------------------------------------------------------------------

    Private Sub TxtBuscar_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        AplicarFiltro()
    End Sub

    Private Sub ChkReactivados_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Cargar()
    End Sub

    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarBoton()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Cargar()
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnRegresar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fila As DataRowView = FilaSeleccionada()
        If fila Is Nothing OrElse Not Convert.ToBoolean(fila("Activo")) Then Return

        Dim resumen As String =
            Convert.ToString(fila("Codigo")) & " - " & Convert.ToString(fila("Tipo_Documento")).Trim() & " " &
            Convert.ToString(fila("Numero_Documento")).Trim() & "  Producto: " & Convert.ToString(fila("Cod_Producto")).Trim() &
            vbCrLf & "Marcado como «" & Convert.ToString(fila("Clasificacion")) & "» por " & Convert.ToString(fila("Usuario")) &
            vbCrLf & "Motivo: " & Convert.ToString(fila("Motivo"))

        Dim motivo As String = PedirMotivo(resumen)
        If motivo Is Nothing Then Return

        Try
            Dim id As Integer = Convert.ToInt32(fila("IdExclusion"))
            If Not ExclusionesAuditoria.Reactivar(Conexion, id, motivo) Then
                MessageBox.Show("El hallazgo ya había sido regresado a la auditoría.", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                HuboReactivaciones = True
                Try
                    Bitacora(Now, NombreUsuario, "Auditoria Facturacion",
                             "Regreso hallazgo a la auditoria " & Convert.ToString(fila("Codigo")) & ":" &
                             Convert.ToString(fila("Numero_Documento")).Trim() & " Prod:" & Convert.ToString(fila("Cod_Producto")).Trim() &
                             " Motivo:" & motivo)
                Catch
                End Try
                MessageBox.Show("El hallazgo volverá a aparecer la próxima vez que ejecute la auditoría.", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo regresar el hallazgo: " & ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Cargar()
    End Sub

    ''' <summary>Pide el motivo para regresar el hallazgo. Devuelve Nothing si el usuario cancela.</summary>
    Private Function PedirMotivo(ByVal resumen As String) As String
        Using dlg As New Form
            dlg.Text = "Regresar hallazgo a la auditoría"
            dlg.ClientSize = New Size(460, 250)
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.ShowInTaskbar = False

            Dim lblRes As New Label
            lblRes.Text = resumen
            lblRes.Location = New Point(16, 12)
            lblRes.Size = New Size(428, 88)
            lblRes.BorderStyle = BorderStyle.FixedSingle
            lblRes.BackColor = Color.FromArgb(246, 248, 252)
            Dim lblMot As New Label
            lblMot.Text = "¿Por qué se regresa? (obligatorio)"
            lblMot.AutoSize = True
            lblMot.Location = New Point(16, 110)
            Dim txt As New TextBox
            txt.Multiline = True
            txt.MaxLength = 500
            txt.ScrollBars = ScrollBars.Vertical
            txt.Location = New Point(16, 128)
            txt.Size = New Size(428, 64)
            Dim btnOk As New Button
            btnOk.Text = "Regresar"
            btnOk.Location = New Point(244, 206)
            btnOk.Size = New Size(96, 32)
            Dim btnNo As New Button
            btnNo.Text = "Cancelar"
            btnNo.DialogResult = DialogResult.Cancel
            btnNo.Location = New Point(348, 206)
            btnNo.Size = New Size(96, 32)
            dlg.Controls.AddRange(New Control() {lblRes, lblMot, txt, btnOk, btnNo})
            dlg.CancelButton = btnNo

            AddHandler btnOk.Click,
                Sub(s As Object, ev As EventArgs)
                    If txt.Text.Trim().Length < 5 Then
                        MessageBox.Show("Indique el motivo (mínimo 5 caracteres).", "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txt.Focus()
                    Else
                        dlg.DialogResult = DialogResult.OK
                    End If
                End Sub

            If dlg.ShowDialog(Me) = DialogResult.OK Then Return txt.Text.Trim()
            Return Nothing
        End Using
    End Function

End Class
