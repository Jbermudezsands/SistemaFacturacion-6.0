<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMostrarPesadas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblPeso = New System.Windows.Forms.Label
        Me.LblProductos = New System.Windows.Forms.Label
        Me.ImgLogo = New System.Windows.Forms.PictureBox
        Me.LblRuc = New System.Windows.Forms.Label
        Me.LblTelefono = New System.Windows.Forms.Label
        Me.LblNombreEmpresa = New System.Windows.Forms.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblPeso
        '
        Me.LblPeso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 80.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeso.ForeColor = System.Drawing.Color.Red
        Me.LblPeso.Location = New System.Drawing.Point(22, 420)
        Me.LblPeso.Name = "LblPeso"
        Me.LblPeso.Size = New System.Drawing.Size(1003, 120)
        Me.LblPeso.TabIndex = 0
        Me.LblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblProductos
        '
        Me.LblProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductos.Location = New System.Drawing.Point(12, 283)
        Me.LblProductos.Name = "LblProductos"
        Me.LblProductos.Size = New System.Drawing.Size(1034, 101)
        Me.LblProductos.TabIndex = 1
        Me.LblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImgLogo
        '
        Me.ImgLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgLogo.Location = New System.Drawing.Point(22, 34)
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.Size = New System.Drawing.Size(216, 193)
        Me.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgLogo.TabIndex = 2
        Me.ImgLogo.TabStop = False
        '
        'LblRuc
        '
        Me.LblRuc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRuc.Location = New System.Drawing.Point(22, 97)
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Size = New System.Drawing.Size(1024, 63)
        Me.LblRuc.TabIndex = 4
        Me.LblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTelefono
        '
        Me.LblTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTelefono.Location = New System.Drawing.Point(22, 164)
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Size = New System.Drawing.Size(1024, 63)
        Me.LblTelefono.TabIndex = 5
        Me.LblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNombreEmpresa
        '
        Me.LblNombreEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreEmpresa.Location = New System.Drawing.Point(32, 34)
        Me.LblNombreEmpresa.Name = "LblNombreEmpresa"
        Me.LblNombreEmpresa.Size = New System.Drawing.Size(1014, 63)
        Me.LblNombreEmpresa.TabIndex = 3
        Me.LblNombreEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMostrarPesadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 549)
        Me.Controls.Add(Me.ImgLogo)
        Me.Controls.Add(Me.LblTelefono)
        Me.Controls.Add(Me.LblRuc)
        Me.Controls.Add(Me.LblNombreEmpresa)
        Me.Controls.Add(Me.LblProductos)
        Me.Controls.Add(Me.LblPeso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmMostrarPesadas"
        Me.Text = "FrmMostrarPesadas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblPeso As System.Windows.Forms.Label
    Friend WithEvents LblProductos As System.Windows.Forms.Label
    Friend WithEvents ImgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents LblRuc As System.Windows.Forms.Label
    Friend WithEvents LblTelefono As System.Windows.Forms.Label
    Friend WithEvents LblNombreEmpresa As System.Windows.Forms.Label
End Class
