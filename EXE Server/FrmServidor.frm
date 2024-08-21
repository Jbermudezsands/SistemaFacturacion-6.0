VERSION 5.00
Object = "{080026CA-5CAE-11D6-82C2-000021B74250}#16.0#0"; "vbskfree.ocx"
Object = "{E1C6DB9D-BD4A-4A61-A759-0CED75D034BF}#43.0#0"; "SmartButton.ocx"
Begin VB.Form FrmServidor 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Registro del Servidor Contabilidad"
   ClientHeight    =   3015
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4680
   Icon            =   "FrmServidor.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3015
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox TxtNombreBD 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   1800
      TabIndex        =   9
      Top             =   240
      Width           =   2535
   End
   Begin VB.TextBox TxtClave 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   1800
      PasswordChar    =   "*"
      TabIndex        =   7
      Top             =   1680
      Width           =   2535
   End
   Begin VB.TextBox TxtUsuario 
      Height          =   375
      Left            =   1800
      TabIndex        =   5
      Top             =   1200
      Width           =   2535
   End
   Begin VB.Data DtaServidor 
      Caption         =   "DtaServidor"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   375
      Left            =   480
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   3720
      Width           =   2295
   End
   Begin SmartButtonProject.SmartButton SmartButton2 
      Height          =   735
      Left            =   3480
      TabIndex        =   3
      Top             =   2160
      Width           =   1095
      _ExtentX        =   1931
      _ExtentY        =   1296
      Caption         =   "Cancelar"
      Picture         =   "FrmServidor.frx":030A
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      PictureLayout   =   7
   End
   Begin SmartButtonProject.SmartButton SmartButton1 
      Height          =   735
      Left            =   120
      TabIndex        =   2
      Top             =   2160
      Width           =   1095
      _ExtentX        =   1931
      _ExtentY        =   1296
      Caption         =   "Grabar"
      Picture         =   "FrmServidor.frx":0624
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      PictureLayout   =   7
   End
   Begin vbskfree.Skinner Skinner1 
      Left            =   360
      Top             =   3600
      _ExtentX        =   1270
      _ExtentY        =   1270
      CloseButtonToolTipText=   "Cerrar"
      MinButtonToolTipText=   "Minimizar"
      MaxButtonToolTipText=   "Maximizar"
      RestoreButtonToolTipText=   "Restaurar"
   End
   Begin VB.TextBox TxtNombre 
      Height          =   375
      Left            =   1800
      TabIndex        =   1
      Top             =   720
      Width           =   2535
   End
   Begin VB.Label Label4 
      Caption         =   "Nombre BD"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   255
      Left            =   720
      TabIndex        =   8
      Top             =   360
      Width           =   975
   End
   Begin VB.Label Label3 
      Caption         =   "Clave:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   255
      Left            =   1080
      TabIndex        =   6
      Top             =   1680
      Width           =   615
   End
   Begin VB.Label Label2 
      Caption         =   "Usuario:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   255
      Left            =   840
      TabIndex        =   4
      Top             =   1200
      Width           =   855
   End
   Begin VB.Label Label1 
      Caption         =   "Nombre Servidor"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   720
      Width           =   1575
   End
End
Attribute VB_Name = "FrmServidor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public RutaServer As String
Public Server As String, NombreBD As String
Private Sub Form_Load()

RutaServer = App.Path + "\CntConta.dll"
If Dir(RutaServer) <> "" Then

  
  With Me.DtaServidor
     .DatabaseName = RutaServer
     .RecordSource = "Servidor"
     .Refresh
  End With
  
  If Not IsNull(Me.DtaServidor.Recordset.Servidor) Then
   Server = Me.DtaServidor.Recordset.Servidor
   Me.TxtNombre.Text = Server
  Else
   MsgBox "No se ha definido el Servidor", vbCritical, "Sistmea de Nominas"
   Exit Sub
  End If
  
   If Not IsNull(Me.DtaServidor.Recordset.Usuario) Then
    Me.TxtUsuario.Text = Me.DtaServidor.Recordset.Usuario
   Else
     MsgBox "No se ha definido el Usuario", vbCritical, "Sistmea de Nominas"
     Exit Sub
   End If
  
   If Not IsNull(Me.DtaServidor.Recordset.Clave) Then
    Me.TxtClave.Text = Me.DtaServidor.Recordset.Clave
   Else
     MsgBox "No se ha definido la Clave", vbCritical, "Sistmea de Nominas"
     Exit Sub
   End If
   
  If Not IsNull(Me.DtaServidor.Recordset.NombreBD) Then
   NombreBD = Me.DtaServidor.Recordset.NombreBD
   Me.TxtNombreBD.Text = NombreBD
  Else
   MsgBox "No se ha definido el Servidor", vbCritical, "Sistmea de Nominas"
   Exit Sub
  End If
  
 Else
   MsgBox "No se ha definido el Servidor", vbCritical, "Sistmea de Nominas"
   Exit Sub
 End If
End Sub

Private Sub SmartButton1_Click()
If Me.TxtNombre.Text = "" Then
   MsgBox "No ha Definido Ningun Servidor", vbCritical, "Sistema Nominas"
   Exit Sub
Else
  Me.DtaServidor.Refresh
  Me.DtaServidor.Recordset.Edit
    Me.DtaServidor.Recordset.Servidor = Me.TxtNombre.Text
    Me.DtaServidor.Recordset.Usuario = Me.TxtUsuario.Text
    Me.DtaServidor.Recordset.Clave = Me.TxtClave.Text
    Me.DtaServidor.Recordset.NombreBD = Me.TxtNombreBD.Text
  Me.DtaServidor.Recordset.Update
End If
End Sub

Private Sub SmartButton2_Click()
Unload Me
End Sub
