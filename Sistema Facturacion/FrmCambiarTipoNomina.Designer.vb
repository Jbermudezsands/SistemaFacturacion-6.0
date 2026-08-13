<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambiarTipoNomina
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambiarTipoNomina))
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblRol = New System.Windows.Forms.Label()
        Me.LblTipoNominaActual = New System.Windows.Forms.Label()
        Me.CboTipoNominaProductor = New C1.Win.C1List.C1Combo()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CboTipoNominaProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(12, 9)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.LblCodigo.TabIndex = 0
        Me.LblCodigo.Text = "Codigo"
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(12, 32)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(47, 13)
        Me.LblNombre.TabIndex = 1
        Me.LblNombre.Text = "Nombre:"
        '
        'LblRol
        '
        Me.LblRol.AutoSize = True
        Me.LblRol.Location = New System.Drawing.Point(12, 56)
        Me.LblRol.Name = "LblRol"
        Me.LblRol.Size = New System.Drawing.Size(26, 13)
        Me.LblRol.TabIndex = 2
        Me.LblRol.Text = "Rol:"
        '
        'LblTipoNominaActual
        '
        Me.LblTipoNominaActual.AutoSize = True
        Me.LblTipoNominaActual.Location = New System.Drawing.Point(12, 79)
        Me.LblTipoNominaActual.Name = "LblTipoNominaActual"
        Me.LblTipoNominaActual.Size = New System.Drawing.Size(109, 13)
        Me.LblTipoNominaActual.TabIndex = 3
        Me.LblTipoNominaActual.Text = "Tipo Nomina Anterior:"
        '
        'CboTipoNominaProductor
        '
        Me.CboTipoNominaProductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoNominaProductor.Caption = ""
        Me.CboTipoNominaProductor.CaptionHeight = 17
        Me.CboTipoNominaProductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoNominaProductor.ColumnCaptionHeight = 17
        Me.CboTipoNominaProductor.ColumnFooterHeight = 17
        Me.CboTipoNominaProductor.ContentHeight = 15
        Me.CboTipoNominaProductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoNominaProductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTipoNominaProductor.DropDownWidth = 300
        Me.CboTipoNominaProductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoNominaProductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoNominaProductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoNominaProductor.EditorHeight = 15
        Me.CboTipoNominaProductor.Images.Add(CType(resources.GetObject("CboTipoNominaProductor.Images"), System.Drawing.Image))
        Me.CboTipoNominaProductor.ItemHeight = 15
        Me.CboTipoNominaProductor.Location = New System.Drawing.Point(94, 101)
        Me.CboTipoNominaProductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoNominaProductor.MaxDropDownItems = CType(5, Short)
        Me.CboTipoNominaProductor.MaxLength = 32767
        Me.CboTipoNominaProductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoNominaProductor.Name = "CboTipoNominaProductor"
        Me.CboTipoNominaProductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoNominaProductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoNominaProductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoNominaProductor.Size = New System.Drawing.Size(127, 21)
        Me.CboTipoNominaProductor.TabIndex = 181
        Me.CboTipoNominaProductor.PropBag = resources.GetString("CboTipoNominaProductor.PropBag")
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(12, 103)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(64, 13)
        Me.Label56.TabIndex = 180
        Me.Label56.Text = "TipoNomina"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(15, 197)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 182
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(249, 197)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 183
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 45)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "El cambio retirará este rol de las nóminas activas" & Global.Microsoft.VisualBasic.ChrW(10) & "del tipo anterior. Podrá incor" &
    "porarse nuevamente" & Global.Microsoft.VisualBasic.ChrW(10) & "al recalcular las planillas del nuevo tipo."
        '
        'FrmCambiarTipoNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.CboTipoNominaProductor)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.LblTipoNominaActual)
        Me.Controls.Add(Me.LblRol)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.LblCodigo)
        Me.Name = "FrmCambiarTipoNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Tipo Nomina"
        CType(Me.CboTipoNominaProductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblCodigo As Label
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblRol As Label
    Friend WithEvents LblTipoNominaActual As Label
    Friend WithEvents CboTipoNominaProductor As C1.Win.C1List.C1Combo
    Friend WithEvents Label56 As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents Label1 As Label
End Class
