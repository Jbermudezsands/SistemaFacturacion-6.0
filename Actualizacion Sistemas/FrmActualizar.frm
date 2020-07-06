VERSION 5.00
Object = "{74848F95-A02A-4286-AF0C-A3C755E4A5B3}#1.0#0"; "actskn43.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Object = "{A8E5842E-102B-4289-9D57-3B3F5B5E15D3}#12.0#0"; "Codejock.Controls.v12.0.0.Demo.ocx"
Begin VB.Form Form1 
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   3870
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7845
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3870
   ScaleWidth      =   7845
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   4800
      Top             =   1200
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton CmdSalir 
      Caption         =   "Salir"
      Height          =   375
      Left            =   6120
      TabIndex        =   1
      Top             =   3240
      Width           =   1215
   End
   Begin VB.CommandButton CmdActualizar 
      Caption         =   "Actualizar"
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Top             =   3240
      Width           =   1215
   End
   Begin ACTIVESKINLibCtl.Skin Skin1 
      Left            =   7200
      OleObjectBlob   =   "FrmActualizar.frx":0000
      Top             =   3720
   End
   Begin XtremeSuiteControls.ProgressBar osProgress1 
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   2040
      Visible         =   0   'False
      Width           =   3735
      _Version        =   786432
      _ExtentX        =   6588
      _ExtentY        =   661
      _StockProps     =   93
      BackColor       =   14737632
      Scrolling       =   2
      Appearance      =   6
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00800000&
      BorderWidth     =   2
      X1              =   3600
      X2              =   10560
      Y1              =   840
      Y2              =   840
   End
   Begin VB.Label lbltitulo 
      BackStyle       =   0  'Transparent
      Caption         =   "Actualizacion "
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   15.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   375
      Left            =   4680
      TabIndex        =   3
      Top             =   240
      Width           =   1800
   End
   Begin VB.Image Image1 
      Height          =   3840
      Left            =   0
      Picture         =   "FrmActualizar.frx":25B82D
      Stretch         =   -1  'True
      Top             =   0
      Width           =   3600
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()

End Sub

Private Sub CmdActualizar_Click()
Dim miFile As File
Dim fso As New FileSystemObject
Dim FechaLocal As Date, FechaActualizacion As Date
Dim RutaUpdate As String, RutaOrigen As String, I As Double, J As Double

Me.osProgress1.Visible = True
Me.CmdActualizar.Enabled = False
Me.CmdSalir.Enabled = False
DoEvents


Open App.Path + "\RutaUpdate.dll" For Input As #1
 Do Until EOF(1)
  Line Input #1, NextLine
        RutaUpdate = Trim(NextLine)
  Loop
Close #1

RutaOrigen = App.Path + "\Sistema Facturacion 6.0.exe"
RutaUpdate = RutaUpdate + "\Sistema Facturacion 6.0.exe"

If Dir(RutaOrigen) = "" Then
  MsgBox "La Ruta Origen no Existe", vbCritical, "Zeus Facturacion"
  Exit Sub
End If

If Dir(RutaUpdate) = "" Then
  MsgBox "La Ruta Actualizacion no Existe", vbCritical, "Zeus Facturacion"
  Exit Sub
End If

'Me.CommonDialog1.ShowOpen
'Set miFile = fso.GetFile(CommonDialog1.FileTitle)
'rutaserver = App.Path + "\ZeusContabilidad.exe"
'If Dir(rutaserver) <> "" Then
'
'End If

Set miFile = fso.GetFile(RutaOrigen)
FechaLocal = miFile.DateLastModified

Set miFile = fso.GetFile(RutaUpdate)
FechaActualizacion = miFile.DateLastModified

If FechaActualizacion > FechaLocal Then
  Respuesta = MsgBox("Existe una Nueva Version,Desea Actualizar?", vbYesNo, "Actualizando..")
  If Respuesta = 6 Then
    KillProcess ("Sistema Facturacion 6.0.exe")
    DoEvents
    '------------RETARDO EL PROCEDIMIENTO ------------------------------------------------
    For I = 1 To 1000
     J = 1
    Next
    
    Kill (RutaOrigen)
    '------------RETARDO EL PROCEDIMIENTO ------------------------------------------------
    For I = 1 To 1000
     J = 1
    Next
    DoEvents
    FileCopy RutaUpdate, RutaOrigen
    DoEvents
    Shell (RutaOrigen)
    Unload Me
  Else
    Shell (RutaOrigen)
    Unload Me
  End If
  
Else
   MsgBox "NO EXISTE ACTUALIZACION RECIENTE!!!", vbInformation, "Actualiazacion"
   Shell (RutaOrigen)
   Unload Me
End If


Me.CmdActualizar.Enabled = True
Me.CmdSalir.Enabled = True

End Sub

Private Sub Command2_Click()

End Sub

Private Sub CmdSalir_Click()
Unload Me
End Sub

Private Sub Form_Load()
Me.Skin1.ApplySkin hWnd
Me.BackColor = RGB(239, 243, 255)
End Sub

Private Sub Image3_Click()

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    KillProcess ("Actualizar.exe")
End Sub
