<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjustarCostos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustarCostos))
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar
        Me.LblProceso = New System.Windows.Forms.Label
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.ListaImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(12, 180)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar4.TabIndex = 14
        '
        'ProgressBar5
        '
        Me.ProgressBar5.Location = New System.Drawing.Point(12, 135)
        Me.ProgressBar5.Name = "ProgressBar5"
        Me.ProgressBar5.Size = New System.Drawing.Size(318, 32)
        Me.ProgressBar5.TabIndex = 12
        '
        'LblProceso
        '
        Me.LblProceso.AutoSize = True
        Me.LblProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProceso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblProceso.Location = New System.Drawing.Point(12, 218)
        Me.LblProceso.Name = "LblProceso"
        Me.LblProceso.Size = New System.Drawing.Size(215, 25)
        Me.LblProceso.TabIndex = 15
        Me.LblProceso.Text = "Ajustando  M00404"
        '
        'Imagen
        '
        Me.Imagen.BackColor = System.Drawing.Color.Transparent
        Me.Imagen.Image = CType(resources.GetObject("Imagen.Image"), System.Drawing.Image)
        Me.Imagen.Location = New System.Drawing.Point(109, 12)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(133, 117)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 199
        Me.Imagen.TabStop = False
        '
        'ListaImagenes
        '
        Me.ListaImagenes.ImageStream = CType(resources.GetObject("ListaImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenes.Images.SetKeyName(0, "CirculosColor1.png")
        Me.ListaImagenes.Images.SetKeyName(1, "CirculosColor2.png")
        Me.ListaImagenes.Images.SetKeyName(2, "CirculosColor3.png")
        Me.ListaImagenes.Images.SetKeyName(3, "CirculosColor4.png")
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 200
        '
        'FrmAjustarCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.LblProceso)
        Me.Controls.Add(Me.ProgressBar4)
        Me.Controls.Add(Me.ProgressBar5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjustarCostos"
        Me.Text = "Ajustando Costos"
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar5 As System.Windows.Forms.ProgressBar
    Friend WithEvents LblProceso As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents ListaImagenes As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
