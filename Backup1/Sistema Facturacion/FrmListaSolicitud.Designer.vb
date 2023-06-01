<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaSolicitud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaSolicitud))
        Me.TDGridSolicitud = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnActualizar = New System.Windows.Forms.Button
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OptSinProcesar = New System.Windows.Forms.RadioButton
        Me.OptTodos = New System.Windows.Forms.RadioButton
        Me.BindingConsultas = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TDGridSolicitud
        '
        Me.TDGridSolicitud.AllowUpdate = False
        Me.TDGridSolicitud.AlternatingRows = True
        Me.TDGridSolicitud.Caption = "Listado de Impuestos para Liquidacion de Productos"
        Me.TDGridSolicitud.FilterBar = True
        Me.TDGridSolicitud.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridSolicitud.Images.Add(CType(resources.GetObject("TDGridSolicitud.Images"), System.Drawing.Image))
        Me.TDGridSolicitud.Location = New System.Drawing.Point(5, 64)
        Me.TDGridSolicitud.Name = "TDGridSolicitud"
        Me.TDGridSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridSolicitud.PreviewInfo.ZoomFactor = 75
        Me.TDGridSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("TDGridSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridSolicitud.Size = New System.Drawing.Size(965, 360)
        Me.TDGridSolicitud.TabIndex = 131
        Me.TDGridSolicitud.Text = "C1TrueDBGrid1"
        Me.TDGridSolicitud.PropBag = resources.GetString("TDGridSolicitud.PropBag")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1116, 60)
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(25, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(66, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 135
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(459, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(158, 13)
        Me.Label9.TabIndex = 186
        Me.Label9.Text = "SOLICITUD DE COMPRAS"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(986, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 56)
        Me.Button1.TabIndex = 245
        Me.Button1.Text = "Anular"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizar.Location = New System.Drawing.Point(986, 181)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(114, 56)
        Me.BtnActualizar.TabIndex = 244
        Me.BtnActualizar.Text = "Actualiza"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVer.Location = New System.Drawing.Point(986, 122)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(114, 56)
        Me.BtnVer.TabIndex = 243
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(986, 368)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(114, 56)
        Me.BtnSalir.TabIndex = 242
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdNuevo.Location = New System.Drawing.Point(986, 243)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(114, 54)
        Me.CmdNuevo.TabIndex = 246
        Me.CmdNuevo.Text = "Autorizar"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(986, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 56)
        Me.Button2.TabIndex = 247
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptSinProcesar)
        Me.GroupBox1.Controls.Add(Me.OptTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(800, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 49)
        Me.GroupBox1.TabIndex = 248
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Solicitudes"
        '
        'OptSinProcesar
        '
        Me.OptSinProcesar.AutoSize = True
        Me.OptSinProcesar.Checked = True
        Me.OptSinProcesar.Location = New System.Drawing.Point(78, 22)
        Me.OptSinProcesar.Name = "OptSinProcesar"
        Me.OptSinProcesar.Size = New System.Drawing.Size(85, 17)
        Me.OptSinProcesar.TabIndex = 1
        Me.OptSinProcesar.TabStop = True
        Me.OptSinProcesar.Text = "Sin Procesar"
        Me.OptSinProcesar.UseVisualStyleBackColor = True
        '
        'OptTodos
        '
        Me.OptTodos.AutoSize = True
        Me.OptTodos.Location = New System.Drawing.Point(12, 21)
        Me.OptTodos.Name = "OptTodos"
        Me.OptTodos.Size = New System.Drawing.Size(55, 17)
        Me.OptTodos.TabIndex = 0
        Me.OptTodos.Text = "Todos"
        Me.OptTodos.UseVisualStyleBackColor = True
        '
        'FrmListaSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 475)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.BtnVer)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TDGridSolicitud)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListaSolicitud"
        Me.Text = "FrmListaSolicitud"
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TDGridSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptSinProcesar As System.Windows.Forms.RadioButton
    Friend WithEvents OptTodos As System.Windows.Forms.RadioButton
    Friend WithEvents BindingConsultas As System.Windows.Forms.BindingSource
End Class
