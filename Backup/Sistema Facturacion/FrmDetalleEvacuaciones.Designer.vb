<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleEvacuaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalleEvacuaciones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblTipoServicio = New System.Windows.Forms.Label
        Me.LblCliente = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.TDGridSolicitud = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BtnVer = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblTipoServicio)
        Me.GroupBox1.Controls.Add(Me.LblCliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFechaInicio)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 86)
        Me.GroupBox1.TabIndex = 258
        Me.GroupBox1.TabStop = False
        '
        'LblTipoServicio
        '
        Me.LblTipoServicio.AutoSize = True
        Me.LblTipoServicio.Location = New System.Drawing.Point(83, 56)
        Me.LblTipoServicio.Name = "LblTipoServicio"
        Me.LblTipoServicio.Size = New System.Drawing.Size(0, 13)
        Me.LblTipoServicio.TabIndex = 263
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(234, 55)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(0, 13)
        Me.LblCliente.TabIndex = 262
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Tipo Servicio"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.CustomFormat = ""
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(269, 21)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaFin.TabIndex = 256
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Fecha Fin"
        '
        'DTPFechaInicio
        '
        Me.DTPFechaInicio.CustomFormat = ""
        Me.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicio.Location = New System.Drawing.Point(83, 20)
        Me.DTPFechaInicio.Name = "DTPFechaInicio"
        Me.DTPFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaInicio.TabIndex = 254
        '
        'TDGridSolicitud
        '
        Me.TDGridSolicitud.AllowUpdate = False
        Me.TDGridSolicitud.AlternatingRows = True
        Me.TDGridSolicitud.Caption = "Listado de Clientes x Dias"
        Me.TDGridSolicitud.FilterBar = True
        Me.TDGridSolicitud.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridSolicitud.Images.Add(CType(resources.GetObject("TDGridSolicitud.Images"), System.Drawing.Image))
        Me.TDGridSolicitud.Location = New System.Drawing.Point(12, 94)
        Me.TDGridSolicitud.Name = "TDGridSolicitud"
        Me.TDGridSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridSolicitud.PreviewInfo.ZoomFactor = 75
        Me.TDGridSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("TDGridSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridSolicitud.Size = New System.Drawing.Size(637, 346)
        Me.TDGridSolicitud.TabIndex = 259
        Me.TDGridSolicitud.Text = "C1TrueDBGrid1"
        Me.TDGridSolicitud.PropBag = resources.GetString("TDGridSolicitud.PropBag")
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVer.Location = New System.Drawing.Point(655, 94)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(126, 56)
        Me.BtnVer.TabIndex = 263
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(655, 156)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(126, 56)
        Me.Button3.TabIndex = 269
        Me.Button3.Text = "Anular"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(655, 384)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(125, 56)
        Me.BtnSalir.TabIndex = 268
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'FrmDetalleEvacuaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 453)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnVer)
        Me.Controls.Add(Me.TDGridSolicitud)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmDetalleEvacuaciones"
        Me.Text = "FrmDetalleEvacuaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents TDGridSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents LblTipoServicio As System.Windows.Forms.Label
End Class
