<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBBackup
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
        Me.gbConnConfig = New System.Windows.Forms.GroupBox
        Me.lblConnStatus = New System.Windows.Forms.Label
        Me.pbConnStatus = New System.Windows.Forms.PictureBox
        Me.btnTestConnection = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtDB = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbDBInfo = New System.Windows.Forms.GroupBox
        Me.btnBackup = New System.Windows.Forms.Button
        Me.txtBackupName = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnSelectDir = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblUnallocatedSize = New System.Windows.Forms.Label
        Me.lblDBSize = New System.Windows.Forms.Label
        Me.lblDBName = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.gbConnConfig.SuspendLayout()
        CType(Me.pbConnStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDBInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConnConfig
        '
        Me.gbConnConfig.Controls.Add(Me.lblConnStatus)
        Me.gbConnConfig.Controls.Add(Me.pbConnStatus)
        Me.gbConnConfig.Controls.Add(Me.btnTestConnection)
        Me.gbConnConfig.Controls.Add(Me.txtPassword)
        Me.gbConnConfig.Controls.Add(Me.txtUsername)
        Me.gbConnConfig.Controls.Add(Me.txtDB)
        Me.gbConnConfig.Controls.Add(Me.txtServer)
        Me.gbConnConfig.Controls.Add(Me.Label4)
        Me.gbConnConfig.Controls.Add(Me.Label3)
        Me.gbConnConfig.Controls.Add(Me.Label2)
        Me.gbConnConfig.Controls.Add(Me.Label1)
        Me.gbConnConfig.Location = New System.Drawing.Point(13, 12)
        Me.gbConnConfig.Name = "gbConnConfig"
        Me.gbConnConfig.Size = New System.Drawing.Size(255, 245)
        Me.gbConnConfig.TabIndex = 0
        Me.gbConnConfig.TabStop = False
        Me.gbConnConfig.Text = "Configuración de la conexión"
        '
        'lblConnStatus
        '
        Me.lblConnStatus.Location = New System.Drawing.Point(6, 202)
        Me.lblConnStatus.Name = "lblConnStatus"
        Me.lblConnStatus.Size = New System.Drawing.Size(235, 37)
        Me.lblConnStatus.TabIndex = 10
        Me.lblConnStatus.Text = "Conexión no comprobada"
        Me.lblConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbConnStatus
        '
        Me.pbConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbConnStatus.Location = New System.Drawing.Point(193, 138)
        Me.pbConnStatus.Name = "pbConnStatus"
        Me.pbConnStatus.Size = New System.Drawing.Size(62, 61)
        Me.pbConnStatus.TabIndex = 9
        Me.pbConnStatus.TabStop = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Enabled = False
        Me.btnTestConnection.Location = New System.Drawing.Point(9, 138)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(178, 48)
        Me.btnTestConnection.TabIndex = 8
        Me.btnTestConnection.Text = "&Probar conexión"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(87, 112)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(154, 20)
        Me.txtPassword.TabIndex = 7
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(87, 86)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(154, 20)
        Me.txtUsername.TabIndex = 6
        Me.txtUsername.Text = "sa"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(87, 60)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(154, 20)
        Me.txtDB.TabIndex = 5
        Me.txtDB.Text = "master"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(87, 34)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(154, 20)
        Me.txtServer.TabIndex = 4
        Me.txtServer.Text = "(local)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Contraseña:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Base de datos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor:"
        '
        'gbDBInfo
        '
        Me.gbDBInfo.Controls.Add(Me.btnBackup)
        Me.gbDBInfo.Controls.Add(Me.txtBackupName)
        Me.gbDBInfo.Controls.Add(Me.Label17)
        Me.gbDBInfo.Controls.Add(Me.btnSelectDir)
        Me.gbDBInfo.Controls.Add(Me.txtPath)
        Me.gbDBInfo.Controls.Add(Me.Label16)
        Me.gbDBInfo.Controls.Add(Me.lblUnallocatedSize)
        Me.gbDBInfo.Controls.Add(Me.lblDBSize)
        Me.gbDBInfo.Controls.Add(Me.lblDBName)
        Me.gbDBInfo.Controls.Add(Me.Label7)
        Me.gbDBInfo.Controls.Add(Me.Label8)
        Me.gbDBInfo.Controls.Add(Me.Label9)
        Me.gbDBInfo.Location = New System.Drawing.Point(274, 12)
        Me.gbDBInfo.Name = "gbDBInfo"
        Me.gbDBInfo.Size = New System.Drawing.Size(308, 235)
        Me.gbDBInfo.TabIndex = 1
        Me.gbDBInfo.TabStop = False
        Me.gbDBInfo.Text = "Información de la base de datos y configuración del respaldo"
        '
        'btnBackup
        '
        Me.btnBackup.Enabled = False
        Me.btnBackup.Location = New System.Drawing.Point(6, 178)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(296, 51)
        Me.btnBackup.TabIndex = 17
        Me.btnBackup.Text = "&Respaldar"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'txtBackupName
        '
        Me.txtBackupName.Enabled = False
        Me.txtBackupName.Location = New System.Drawing.Point(125, 138)
        Me.txtBackupName.Name = "txtBackupName"
        Me.txtBackupName.Size = New System.Drawing.Size(177, 20)
        Me.txtBackupName.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Nombre del archivo:"
        '
        'btnSelectDir
        '
        Me.btnSelectDir.Enabled = False
        Me.btnSelectDir.Location = New System.Drawing.Point(273, 110)
        Me.btnSelectDir.Name = "btnSelectDir"
        Me.btnSelectDir.Size = New System.Drawing.Size(29, 20)
        Me.btnSelectDir.TabIndex = 14
        Me.btnSelectDir.Text = "..."
        Me.btnSelectDir.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(125, 110)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(177, 20)
        Me.txtPath.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Respaldar en:"
        '
        'lblUnallocatedSize
        '
        Me.lblUnallocatedSize.AutoSize = True
        Me.lblUnallocatedSize.ForeColor = System.Drawing.Color.Teal
        Me.lblUnallocatedSize.Location = New System.Drawing.Point(122, 75)
        Me.lblUnallocatedSize.Name = "lblUnallocatedSize"
        Me.lblUnallocatedSize.Size = New System.Drawing.Size(16, 13)
        Me.lblUnallocatedSize.TabIndex = 11
        Me.lblUnallocatedSize.Text = "..."
        '
        'lblDBSize
        '
        Me.lblDBSize.AutoSize = True
        Me.lblDBSize.ForeColor = System.Drawing.Color.Teal
        Me.lblDBSize.Location = New System.Drawing.Point(122, 56)
        Me.lblDBSize.Name = "lblDBSize"
        Me.lblDBSize.Size = New System.Drawing.Size(16, 13)
        Me.lblDBSize.TabIndex = 10
        Me.lblDBSize.Text = "..."
        '
        'lblDBName
        '
        Me.lblDBName.AutoSize = True
        Me.lblDBName.ForeColor = System.Drawing.Color.Teal
        Me.lblDBName.Location = New System.Drawing.Point(122, 37)
        Me.lblDBName.Name = "lblDBName"
        Me.lblDBName.Size = New System.Drawing.Size(16, 13)
        Me.lblDBName.TabIndex = 9
        Me.lblDBName.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Espacio no asignado:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Tamaño total:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Nombre:"
        '
        'frmDBBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 288)
        Me.Controls.Add(Me.gbDBInfo)
        Me.Controls.Add(Me.gbConnConfig)
        Me.Name = "frmDBBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respaldar base de datos"
        Me.gbConnConfig.ResumeLayout(False)
        Me.gbConnConfig.PerformLayout()
        CType(Me.pbConnStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDBInfo.ResumeLayout(False)
        Me.gbDBInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbConnConfig As GroupBox
    Friend WithEvents gbDBInfo As GroupBox
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtDB As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pbConnStatus As PictureBox
    Protected WithEvents lblConnStatus As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblUnallocatedSize As Label
    Friend WithEvents lblDBSize As Label
    Friend WithEvents lblDBName As Label
    Friend WithEvents txtPath As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnSelectDir As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents txtBackupName As TextBox
    Friend WithEvents Label17 As Label
End Class
