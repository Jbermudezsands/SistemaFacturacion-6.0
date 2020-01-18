VERSION 5.00
Object = "{74848F95-A02A-4286-AF0C-A3C755E4A5B3}#1.0#0"; "actskn43.ocx"
Object = "{FAEEE763-117E-101B-8933-08002B2F4F5A}#1.1#0"; "DBLIST32.OCX"
Begin VB.Form FrmCompañia 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Administracion de Compañias"
   ClientHeight    =   3930
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   6780
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3930
   ScaleWidth      =   6780
   StartUpPosition =   2  'CenterScreen
   Begin VB.Data DtaConsulta 
      Caption         =   "DtaConsulta"
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
      Top             =   4320
      Visible         =   0   'False
      Width           =   3375
   End
   Begin VB.CommandButton CmdConexion 
      Caption         =   "..."
      Height          =   375
      Left            =   6000
      TabIndex        =   13
      Top             =   1680
      Width           =   495
   End
   Begin VB.CommandButton CmdBorrar 
      Caption         =   "Borrar"
      Height          =   375
      Left            =   2520
      TabIndex        =   12
      Top             =   3360
      Width           =   1215
   End
   Begin VB.CommandButton CmdCancelar 
      Caption         =   "Cancelar"
      Height          =   375
      Left            =   5160
      TabIndex        =   11
      Top             =   3360
      Width           =   1215
   End
   Begin VB.CommandButton CmdAgregar 
      Caption         =   "Grabar"
      Height          =   375
      Left            =   360
      TabIndex        =   10
      Top             =   3360
      Width           =   1215
   End
   Begin ACTIVESKINLibCtl.SkinLabel SkinLabel1 
      Height          =   375
      Left            =   240
      OleObjectBlob   =   "FrmCompañia.frx":0000
      TabIndex        =   8
      Top             =   1320
      Width           =   1695
   End
   Begin MSDBCtls.DBCombo TxtNombreBD 
      Bindings        =   "FrmCompañia.frx":007C
      Height          =   315
      Left            =   2040
      TabIndex        =   7
      Top             =   1320
      Width           =   3855
      _ExtentX        =   6800
      _ExtentY        =   556
      _Version        =   393216
      ListField       =   "NombreBD"
      Text            =   ""
   End
   Begin VB.TextBox TxtConexionString 
      Height          =   1515
      Left            =   2040
      MaxLength       =   255
      MultiLine       =   -1  'True
      TabIndex        =   4
      Top             =   1680
      Width           =   3855
   End
   Begin VB.TextBox TxtUsuario 
      Height          =   375
      Left            =   3360
      TabIndex        =   3
      Top             =   5040
      Visible         =   0   'False
      Width           =   2535
   End
   Begin VB.TextBox TxtClave 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   3360
      PasswordChar    =   "*"
      TabIndex        =   2
      Top             =   5520
      Visible         =   0   'False
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
      Top             =   4680
      Visible         =   0   'False
      Width           =   3375
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      ForeColor       =   &H00FFFFFF&
      Height          =   1095
      Left            =   0
      ScaleHeight     =   1095
      ScaleWidth      =   9015
      TabIndex        =   0
      Top             =   0
      Width           =   9015
      Begin VB.Label lbltitulo 
         BackStyle       =   0  'Transparent
         Caption         =   "Administracion de Compañias"
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
         Left            =   1680
         TabIndex        =   1
         Top             =   240
         Width           =   4065
      End
      Begin VB.Image Image1 
         Height          =   645
         Left            =   480
         Top             =   120
         Width           =   645
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00800000&
         BorderWidth     =   2
         X1              =   0
         X2              =   9000
         Y1              =   1080
         Y2              =   1080
      End
      Begin VB.Image Image2 
         Height          =   960
         Left            =   240
         Picture         =   "FrmCompañia.frx":0096
         Stretch         =   -1  'True
         Top             =   0
         Width           =   960
      End
   End
   Begin ACTIVESKINLibCtl.SkinLabel SkinLabel2 
      Height          =   375
      Left            =   240
      OleObjectBlob   =   "FrmCompañia.frx":1BD8
      TabIndex        =   9
      Top             =   1680
      Width           =   1695
   End
   Begin ACTIVESKINLibCtl.Skin Skin1 
      Left            =   0
      OleObjectBlob   =   "FrmCompañia.frx":1C54
      Top             =   0
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
      Left            =   2400
      TabIndex        =   6
      Top             =   5040
      Visible         =   0   'False
      Width           =   855
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
      Left            =   2640
      TabIndex        =   5
      Top             =   5520
      Visible         =   0   'False
      Width           =   615
   End
End
Attribute VB_Name = "FrmCompañia"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub CmdAgregar_Click()
If Me.TxtNombreBD.Text = "" Then
 MsgBox "No ha dinido en nombre de la Compañia", vbCritical, "Sistema Contable"
 Exit Sub
End If


If Me.TxtConexionString.Text = "" Then
   MsgBox "No ha Definido Ningun Servidor", vbCritical, "Sistema Nominas"
   Exit Sub
Else
  Me.DtaConsulta.RecordSource = "SELECT * FROM Servidor WHERE (NombreBD = '" & Me.TxtNombreBD.Text & "')"
  Me.DtaConsulta.Refresh
  If Not Me.DtaConsulta.Recordset.EOF Then
    Me.DtaConsulta.Recordset.Edit
      Me.DtaConsulta.Recordset.Servidor = Me.TxtConexionString.Text
      Me.DtaConsulta.Recordset.NombreBD = Me.TxtNombreBD.Text
    Me.DtaConsulta.Recordset.Update
  Else
    Me.DtaConsulta.Recordset.AddNew
      Me.DtaConsulta.Recordset.Servidor = Me.TxtConexionString.Text
      Me.DtaConsulta.Recordset.NombreBD = Me.TxtNombreBD.Text
    Me.DtaConsulta.Recordset.Update
  End If
End If
End Sub

Private Sub CmdBorrar_Click()
Dim Respuesta As Double

Respuesta = MsgBox("Desea Eliminar la Compañia?", vbYesNo, "Sistema Contable")

If Respuesta <> 6 Then
 Exit Sub
End If

If Me.TxtNombreBD.Text = "" Then
 MsgBox "No ha dinido en nombre de la Compañia", vbCritical, "Sistema Contable"
 Exit Sub
End If


If Me.TxtConexionString.Text = "" Then
   MsgBox "No ha Definido Ningun Servidor", vbCritical, "Sistema Nominas"
   Exit Sub
Else
  Me.DtaConsulta.RecordSource = "SELECT * FROM Servidor WHERE (NombreBD = '" & Me.TxtNombreBD.Text & "')"
  Me.DtaConsulta.Refresh
  If Not Me.DtaConsulta.Recordset.EOF Then
    Me.DtaConsulta.Recordset.Delete
  End If

  MsgBox "Registro Eliminado con Exito!!!", vbExclamation, "Sistema Contable"
End If
End Sub

Private Sub CmdCancelar_Click()
Unload Me
End Sub

Private Sub CmdConexion_Click()
On Error GoTo TipoErrs
Dim mydlg As New MSDASC.DataLinks
Dim ADOcon As New ADODB.Connection

Me.TxtConexionString.Text = mydlg.PromptNew


Exit Sub
TipoErrs:
 MsgBox Err.Description
End Sub

Private Sub Form_Load()
Dim Server As String

Me.Picture1.BackColor = RGB(239, 243, 255)
Me.Skin1.ApplySkin hWnd



RutaServer = App.Path + "\CntFacturacion.dll"
If Dir(RutaServer) <> "" Then

  
  With Me.DtaServidor
     .DatabaseName = RutaServer
     .RecordSource = "Servidor"
     .Refresh
  End With
  
  With Me.DtaConsulta
     .DatabaseName = RutaServer
  End With
  
  If Not Me.DtaServidor.Recordset.EOF Then
              If Not IsNull(Me.DtaServidor.Recordset.Servidor) Then
               Server = Me.DtaServidor.Recordset.Servidor
               Me.TxtConexionString.Text = Server
              Else
               MsgBox "No se ha definido el Servidor", vbCritical, "Sistmea de Nominas"
               Exit Sub
              End If
              
               If Not IsNull(Me.DtaServidor.Recordset.Usuario) Then
                Me.TxtUsuario.Text = Me.DtaServidor.Recordset.Usuario
               Else
            '     MsgBox "No se ha definido el Usuario", vbCritical, "Sistmea de Nominas"
            '     Exit Sub
               End If
              
               If Not IsNull(Me.DtaServidor.Recordset.Clave) Then
                Me.TxtClave.Text = Me.DtaServidor.Recordset.Clave
               Else
            '     MsgBox "No se ha definido la Clave", vbCritical, "Sistmea de Nominas"
            '     Exit Sub
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
   End If

End Sub

Private Sub SmartButton1_Click()

End Sub

Private Sub TxtNombreBD_Change()
  Me.DtaConsulta.RecordSource = "SELECT * FROM Servidor WHERE (NombreBD = '" & Me.TxtNombreBD.Text & "')"
  Me.DtaConsulta.Refresh
  If Not Me.DtaConsulta.Recordset.EOF Then

      Me.TxtConexionString.Text = Me.DtaConsulta.Recordset.Servidor
      Me.TxtNombreBD.Text = Me.DtaConsulta.Recordset.NombreBD

  End If
End Sub

