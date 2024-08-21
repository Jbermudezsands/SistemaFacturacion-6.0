<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoRecibo))
        Me.BtnAnular = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.BtnVisualizar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox()
        Me.TDGridListadoNomina = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridListadoNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAnular
        '
        Me.BtnAnular.Image = CType(resources.GetObject("BtnAnular.Image"), System.Drawing.Image)
        Me.BtnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAnular.Location = New System.Drawing.Point(818, 249)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(87, 34)
        Me.BtnAnular.TabIndex = 363
        Me.BtnAnular.Text = "Anular"
        Me.BtnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAnular.UseVisualStyleBackColor = True
        Me.BtnAnular.Visible = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(818, 119)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(87, 36)
        Me.BtnImprimir.TabIndex = 362
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(818, 350)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(87, 34)
        Me.CmdCerrar.TabIndex = 361
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'BtnVisualizar
        '
        Me.BtnVisualizar.Image = CType(resources.GetObject("BtnVisualizar.Image"), System.Drawing.Image)
        Me.BtnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVisualizar.Location = New System.Drawing.Point(818, 79)
        Me.BtnVisualizar.Name = "BtnVisualizar"
        Me.BtnVisualizar.Size = New System.Drawing.Size(87, 34)
        Me.BtnVisualizar.TabIndex = 360
        Me.BtnVisualizar.Text = "Visualizar"
        Me.BtnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVisualizar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(317, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(223, 16)
        Me.Label9.TabIndex = 359
        Me.Label9.Text = "LISTADO HISTORICO DE RECIBOS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 358
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.Location = New System.Drawing.Point(-1, -1)
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.Size = New System.Drawing.Size(969, 60)
        Me.CmdBorraLinea.TabIndex = 357
        Me.CmdBorraLinea.TabStop = False
        '
        'TDGridListadoNomina
        '
        Me.TDGridListadoNomina.AlternatingRows = True
        Me.TDGridListadoNomina.Caption = "Listado Historico de Recibos"
        Me.TDGridListadoNomina.FilterBar = True
        Me.TDGridListadoNomina.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridListadoNomina.Images.Add(CType(resources.GetObject("TDGridListadoNomina.Images"), System.Drawing.Image))
        Me.TDGridListadoNomina.Location = New System.Drawing.Point(14, 79)
        Me.TDGridListadoNomina.Name = "TDGridListadoNomina"
        Me.TDGridListadoNomina.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridListadoNomina.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridListadoNomina.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridListadoNomina.PrintInfo.PageSettings = CType(resources.GetObject("TDGridListadoNomina.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridListadoNomina.Size = New System.Drawing.Size(787, 305)
        Me.TDGridListadoNomina.TabIndex = 356
        Me.TDGridListadoNomina.Text = "C1TrueDBGrid1"
        Me.TDGridListadoNomina.PropBag = resources.GetString("TDGridListadoNomina.PropBag")
        '
        'FrmListadoRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 402)
        Me.Controls.Add(Me.BtnAnular)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.BtnVisualizar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.Controls.Add(Me.TDGridListadoNomina)
        Me.Name = "FrmListadoRecibo"
        Me.Text = "Registros de Recibos Historicos"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridListadoNomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAnular As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents CmdCerrar As Button
    Friend WithEvents BtnVisualizar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents CmdBorraLinea As PictureBox
    Friend WithEvents TDGridListadoNomina As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
