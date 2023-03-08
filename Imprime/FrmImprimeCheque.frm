VERSION 5.00
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "MSADODC.OCX"
Object = "{74848F95-A02A-4286-AF0C-A3C755E4A5B3}#1.0#0"; "actskn43.ocx"
Begin VB.Form FrmImprime 
   BackColor       =   &H00FFC0C0&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Imprimiendo..."
   ClientHeight    =   2160
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   2745
   Icon            =   "FrmImprimeCheque.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2160
   ScaleWidth      =   2745
   StartUpPosition =   1  'CenterOwner
   Begin ACTIVESKINLibCtl.SkinLabel SkinLabel2 
      Height          =   255
      Left            =   240
      OleObjectBlob   =   "FrmImprimeCheque.frx":6C22
      TabIndex        =   6
      Top             =   1080
      Width           =   975
   End
   Begin ACTIVESKINLibCtl.SkinLabel SkinLabel1 
      Height          =   375
      Left            =   240
      OleObjectBlob   =   "FrmImprimeCheque.frx":6C92
      TabIndex        =   5
      Top             =   600
      Width           =   975
   End
   Begin VB.CommandButton SmartButton2 
      Caption         =   "Salir"
      Height          =   495
      Left            =   1440
      TabIndex        =   4
      Top             =   1560
      Width           =   1215
   End
   Begin VB.CommandButton SmartButton1 
      BackColor       =   &H00FF8080&
      Caption         =   "Imprimir"
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   1560
      Width           =   1215
   End
   Begin MSAdodcLib.Adodc AdoTasa 
      Height          =   495
      Left            =   120
      Top             =   4080
      Width           =   3135
      _ExtentX        =   5530
      _ExtentY        =   873
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoTasa"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc AdoEmpresa 
      Height          =   375
      Left            =   360
      Top             =   5760
      Width           =   2295
      _ExtentX        =   4048
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoEmpresa"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc AdoEncabezado 
      Height          =   375
      Left            =   240
      Top             =   5280
      Width           =   2415
      _ExtentX        =   4260
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoEncabezado"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc DtaConsulta 
      Height          =   375
      Left            =   120
      Top             =   4680
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "DtaConsulta"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc AdoCordenadas 
      Height          =   375
      Left            =   120
      Top             =   4200
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoCordenadas"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFC0C0&
      Caption         =   "Consecutivo Factura"
      Height          =   1335
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2535
      Begin VB.TextBox TxtCopias 
         Height          =   285
         Left            =   1080
         TabIndex        =   2
         Text            =   "3"
         Top             =   960
         Width           =   375
      End
      Begin VB.TextBox LblConsecutivo 
         Height          =   285
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   1
         Top             =   480
         Width           =   1335
      End
   End
   Begin ACTIVESKINLibCtl.Skin Skin1 
      Left            =   0
      OleObjectBlob   =   "FrmImprimeCheque.frx":6D04
      Top             =   0
   End
   Begin MSAdodcLib.Adodc AdoConfiguracionAccess 
      Height          =   375
      Left            =   120
      Top             =   3840
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoConfiguracionAccess"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc AdoMetodo 
      Height          =   375
      Left            =   120
      Top             =   5160
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoMetodo"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin MSAdodcLib.Adodc AdoFacturas 
      Height          =   375
      Left            =   120
      Top             =   5640
      Width           =   2535
      _ExtentX        =   4471
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   8
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   ""
      Caption         =   "AdoFacturas"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
End
Attribute VB_Name = "FrmImprime"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private ew As cls_NumEnglishWord
Private sw As cls_NumSpanishWord

Private Sub Form_Load()
Dim Ruta As String

FacturaSerie = False
'Me.Skin1.ApplySkin hWnd

Me.SmartButton1.BackColor = RGB(216, 228, 248)
Me.SmartButton2.BackColor = RGB(216, 228, 248)

 Dim ConexionSTR1 As String
'abro el archivo para solo lectura de la cadena de conexion
 Dim NextLine As String
 
 
 '////////////////////////////////////////////////////////////////////////////////////////
 '////////////////CONEXION CON LA BASE DE DATOS DEL SISTEMA///////////////////////////////
 '///////////////////////////////////////////////////////////////////////////////////////
 
 Open App.Path + "\SysInfo.txt" For Input As #1
  Do Until EOF(1)
   Line Input #1, NextLine
        ConexionSTR1 = Trim(NextLine)
   Loop
 Close #1

Conexion = ConexionSTR1

Conexion = Replace(Conexion, "ï»¿", "")

'/////////////////////////////////////////////////////////////////////////////////////////////
'//////////////////CONEXION CON LA BASE DE DATOS ENLACE/////////////////////////////////
'////////////////////////////////////////////////////////////////////////////////////////////
Ruta = App.Path & "\TrueDbGridFr.dll"
ConexionAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & Ruta & "';Persist Security Info=False"




With Me.AdoConfiguracionAccess
   .ConnectionString = ConexionAccess
   .RecordSource = "SELECT Usuarios.* From Usuarios "
   .Refresh
End With

If Not Me.AdoConfiguracionAccess.Recordset.EOF Then
  TipoImpresion = Me.AdoConfiguracionAccess.Recordset("TipoImpresion")
  NumeroImpresion = Me.AdoConfiguracionAccess.Recordset("NumeroImpresion")
  FechaImpresion = Me.AdoConfiguracionAccess.Recordset("Usuario")
End If

Me.SkinLabel1.Caption = TipoImpresion & "No"
Me.LblConsecutivo.Text = NumeroImpresion
Me.Frame2.Caption = "Consecutivo " & TipoImpresion

With Me.AdoCordenadas
   .ConnectionString = Conexion
End With

With Me.AdoTasa
   .ConnectionString = Conexion
End With

With Me.AdoEmpresa
   .ConnectionString = Conexion
   .RecordSource = "SELECT  * From DatosEmpresa "
   .Refresh
End With

With Me.DtaConsulta
   .ConnectionString = Conexion
End With

With Me.AdoMetodo
   .ConnectionString = Conexion
End With

With Me.AdoEncabezado
   .ConnectionString = Conexion
End With

With Me.AdoFacturas
   .ConnectionString = Conexion
End With

If Not Me.AdoEmpresa.Recordset.EOF Then
  FacturaSerie = Me.AdoEmpresa.Recordset("ConsecutivoFacSerie")
  Me.TxtCopias.Text = Me.AdoEmpresa.Recordset("NumeroCopias")
End If

End Sub

Private Sub SmartButton1_Click()
Dim Fechas1 As String, Fechas2 As String
Dim CodigoCuenta As String, Concepto As String
Dim x, y, H, V, Page As Integer, Dia As String, Mes As String, Año As String
Dim i, j As Integer, Fechass As Date, Fecha As String
Dim TotalDebito, TotalCredito, Totalpag As Double
Dim SubTotal, Total, IGV As Double, Cadena As String
Dim X1 As Double, Y1 As Double, X2 As Double, Y2 As Double, X3 As Double, Y3 As Double, X4 As Double, Y4 As Double, X5 As Double, Y5 As Double, X6 As Double, Y6 As Double, X7 As Double, Y7 As Double, X8 As Double, Y8 As Double, X9 As Double, Y9 As Double, X10 As Double, Y10 As Double, X11 As Double, Y11 As Double, X12 As Double, Y12 As Double, X13 As Double, Y13 As Double, X14 As Double, Y14 As Double, X15 As Double, Y15 As Double, X16 As Double, Y16 As Double, X17 As Double, Y17 As Double, X18 As Double, Y18 As Double, X19 As Double, Y19 As Double, X20 As Double, Y20 As Double, X21 As Double, Y21 As Double, X22 As Double, Y22 As Double, X23 As Double, Y23 As Double, X24 As Double, Y24 As Double, X25 As Double, Y25 As Double, X26 As Double, Y26 As Double, X27 As Double, Y27 As Double, X28 As Double, Y28 As Double, X29 As Double, Y29 As Double
Dim UltimaLinea As Double, DiferenciaY As Double, NLineas As Double, TasaCambio As Double, CaracteresLineas As Double
Dim MontoDolar As Double, FechaFactura As Date, MonedaFactura As String, MonedaImprime As String
Dim Copias As Double, l As Integer, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Descuento As Double
Dim IVA As Double, Pagado As Double, NetoPagar As Double, Descuento2 As Double, CadenaDescripcion As String
Dim Caracter As Double, ContadorLinea As Double, MonedaRecibo As String, MontoCordobas As Double, MontoDolares As Double, MontoLetras As String
Dim MonedaMetodo As String, NumeroFactura As String, Simbolo As String, Simbolo2 As String
Dim TipoCoordenadas As String, Retencion1 As Double, Retencion2 As Double, ImporteExcento As Double, ImporteGrabado As Double
Dim X33 As Double, Y33 As Double, X34 As Double, Y34 As Double, CaracteresObservacion As Double, X35 As Double, Y35 As Double, X36 As Double, Y36 As Double
Dim FacturaLotes As Boolean, NumeroLote As String

'On Error GoTo TipoErrs

  If FacturaSerie = True Then
      TipoCoordenadas = TipoImpresion & Mid(NumeroImpresion, 1, 1)
  Else
      TipoCoordenadas = TipoImpresion
  End If

Copias = Int(Val(Me.TxtCopias.Text))

Descuento = 0

 For l = 1 To Copias

            Page = 1
            
            Printer.FontSize = 6
            Printer.ScaleMode = 6
            Printer.FontSize = 6
            TotalDebito = 0
            TotalCredito = 0
            
            
            '///////imprimo el reporte/////
             
             Me.AdoCordenadas.RecordSource = "SELECT * From Coordenadas WHERE (Tipo = '" & TipoCoordenadas & "')"
             Me.AdoCordenadas.Refresh
             If Me.AdoCordenadas.Recordset.EOF Then
              MsgBox "No Existen Coordenadas, para la Cuenta", vbCritical, "Zeus Facturacion"
              Exit Sub
             End If
             
             
                    X1 = Me.AdoCordenadas.Recordset("X1")
                    Y1 = Me.AdoCordenadas.Recordset("Y1")
                    X2 = Me.AdoCordenadas.Recordset("X2")
                    Y2 = Me.AdoCordenadas.Recordset("Y2")
                    X3 = Me.AdoCordenadas.Recordset("X3")
                    Y3 = Me.AdoCordenadas.Recordset("Y3")
                    X4 = Me.AdoCordenadas.Recordset("X4")
                    Y4 = Me.AdoCordenadas.Recordset("Y4")
                    X5 = Me.AdoCordenadas.Recordset("X5")
                    Y5 = Me.AdoCordenadas.Recordset("Y5")
                    X6 = Me.AdoCordenadas.Recordset("X6")
                    Y6 = Me.AdoCordenadas.Recordset("Y6")
                    X7 = Me.AdoCordenadas.Recordset("X7")
                    Y7 = Me.AdoCordenadas.Recordset("Y7")
                    X8 = Me.AdoCordenadas.Recordset("X8")
                    Y8 = Me.AdoCordenadas.Recordset("Y8")
                    X9 = Me.AdoCordenadas.Recordset("X9")
                    Y9 = Me.AdoCordenadas.Recordset("Y9")
                    X10 = Me.AdoCordenadas.Recordset("X10")
                    Y10 = Me.AdoCordenadas.Recordset("Y10")
                    X11 = Me.AdoCordenadas.Recordset("X11")
                    Y11 = Me.AdoCordenadas.Recordset("Y11")
                    X12 = Me.AdoCordenadas.Recordset("X12")
                    Y12 = Me.AdoCordenadas.Recordset("Y12")
                    X13 = Me.AdoCordenadas.Recordset("X13")
                    Y13 = Me.AdoCordenadas.Recordset("Y13")
                    X14 = Me.AdoCordenadas.Recordset("X14")
                    Y14 = Me.AdoCordenadas.Recordset("Y14")
                    X15 = Me.AdoCordenadas.Recordset("X15")
                    Y15 = Me.AdoCordenadas.Recordset("Y15")
                    X16 = Me.AdoCordenadas.Recordset("X16")
                    Y16 = Me.AdoCordenadas.Recordset("Y16")
                    X17 = Me.AdoCordenadas.Recordset("X17")
                    Y17 = Me.AdoCordenadas.Recordset("Y17")
                    Y18 = Me.AdoCordenadas.Recordset("Y18")
                    X18 = Me.AdoCordenadas.Recordset("X18")
                    X19 = Me.AdoCordenadas.Recordset("X19")
                    Y19 = Me.AdoCordenadas.Recordset("Y19")
                    X20 = Me.AdoCordenadas.Recordset("X20")
                    Y20 = Me.AdoCordenadas.Recordset("Y20")
                    X21 = Me.AdoCordenadas.Recordset("X21")
                    Y21 = Me.AdoCordenadas.Recordset("Y21")
                    X22 = Me.AdoCordenadas.Recordset("X22")
                    Y22 = Me.AdoCordenadas.Recordset("Y22")
                    X23 = Me.AdoCordenadas.Recordset("X23")
                    Y23 = Me.AdoCordenadas.Recordset("Y23")
                    X24 = Me.AdoCordenadas.Recordset("X24")
                    Y24 = Me.AdoCordenadas.Recordset("Y24")
                    X25 = Me.AdoCordenadas.Recordset("X25")
                    Y25 = Me.AdoCordenadas.Recordset("Y25")
                    X26 = Me.AdoCordenadas.Recordset("X26")
                    Y26 = Me.AdoCordenadas.Recordset("Y26")
                    X27 = Me.AdoCordenadas.Recordset("X27")
                    Y27 = Me.AdoCordenadas.Recordset("Y27")
                    X28 = Me.AdoCordenadas.Recordset("X28")
                    Y28 = Me.AdoCordenadas.Recordset("Y28")
                    X29 = Me.AdoCordenadas.Recordset("X29")
                    Y29 = Me.AdoCordenadas.Recordset("Y29")
                    X30 = Me.AdoCordenadas.Recordset("X30")
                    Y30 = Me.AdoCordenadas.Recordset("Y30")
                    X31 = Me.AdoCordenadas.Recordset("X31")
                    Y31 = Me.AdoCordenadas.Recordset("Y31")
                    X32 = Me.AdoCordenadas.Recordset("X32")
                    Y32 = Me.AdoCordenadas.Recordset("Y32")
                    X33 = Me.AdoCordenadas.Recordset("X33")
                    Y33 = Me.AdoCordenadas.Recordset("Y33")
                    X34 = Me.AdoCordenadas.Recordset("X34")
                    Y34 = Me.AdoCordenadas.Recordset("Y34")
                    X35 = Me.AdoCordenadas.Recordset("X35")
                    Y35 = Me.AdoCordenadas.Recordset("Y35")
                    X36 = Me.AdoCordenadas.Recordset("X36")
                    Y36 = Me.AdoCordenadas.Recordset("Y36")
                    
                    
                    
                    NLineas = Val(Me.AdoCordenadas.Recordset("NLineas"))
                    CaracteresLineas = Val(Me.AdoCordenadas.Recordset("CaracteresLineas"))
                    CaracteresObservacion = Val(Me.AdoCordenadas.Recordset("CaracteresObservacion"))
            
            TasaCambio = BuscaTasa(FechaFactura)
            
             Me.AdoEmpresa.Refresh
            If Not Me.AdoEmpresa.Recordset.EOF Then
                FacturaLotes = Me.AdoEmpresa.Recordset("FacturaLotes")
             Else
                FacturaLotes = False
            End If
             
            'Cargo la Consulta del a imprmier
             Select Case TipoImpresion
             Case "Factura"
'                Dim rs As New ADODB.Recordset, SubT As Double, IvaT As Double
                
'                If FacturaExonerada(NumeroImpresion) = False Then
'                        rs.Open "UPDATE Detalle_Facturas  Set Importe = Round((Cantidad * Precio_Unitario) * (1 - Descuento / 100), 2) WHERE (Numero_Factura = '" & NumeroImpresion & "') AND (Tipo_Factura = '" & TipoImpresion & "') ", Conexion
'
'                        Me.DtaConsulta.RecordSource = "SELECT ROUND(SUM(Detalle_Facturas.Importe), 4) AS SubTotal, SUM(Detalle_Facturas.Importe * Impuestos.Impuesto) AS Iva, SUM(Detalle_Facturas.Importe * (1 + Impuestos.Impuesto)) As Total FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva  " & _
'                                                      "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroImpresion & "') AND (Detalle_Facturas.Tipo_Factura = '" & TipoImpresion & "')"
'                        Me.DtaConsulta.Refresh
'                        If Not Me.DtaConsulta.Recordset.EOF Then
'                           SubT = Me.DtaConsulta.Recordset("SubTotal")
'                           IvaT = Me.DtaConsulta.Recordset("Iva")
'                           rs.Open "UPDATE Facturas SET [SubTotal] =" & SubT & " ,[IVA] = " & IvaT & " WHERE (Numero_Factura = '" & NumeroImpresion & "') AND (Tipo_Factura = '" & TipoImpresion & "') ", Conexion
'
'                        End If
'                 End If
             

'                Me.DtaConsulta.RecordSource = "SELECT * From Detalle_Facturas  " & _
'                                              "WHERE (Numero_Factura = '" & NumeroImpresion & "') AND (Tipo_Factura = '" & TipoImpresion & "')"
                Me.DtaConsulta.RecordSource = "SELECT Detalle_Facturas.id_Detalle_Factura, Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Detalle_Facturas.Importe, Detalle_Facturas.TasaCambio, Detalle_Facturas.CodTarea, Detalle_Facturas.Costo_Unitario, Impuestos.Impuesto , Impuestos.TipoImpuesto, Impuestos.Descripcion_Iva FROM Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN  Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva " & _
                                              "WHERE (Detalle_Facturas.Numero_Factura = '" & NumeroImpresion & "') AND (Detalle_Facturas.Tipo_Factura = '" & TipoImpresion & "')"
                Me.DtaConsulta.Refresh
                 
                Me.AdoEncabezado.RecordSource = "SELECT *, Vendedores.Nombre_Vendedor, Clientes.RUC FROM Facturas INNER JOIN  Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Numero_Factura = '" & NumeroImpresion & "') AND (Tipo_Factura = '" & TipoImpresion & "')"
                Me.AdoEncabezado.Refresh
                If Me.AdoEncabezado.Recordset.EOF Then
                  MsgBox "No se encontro el encabezado de la factura"
                  Exit Sub
                End If
              
                      
                      Printer.FontSize = 9
                     'Inicio el Ciclo de Impresion
                     i = 1
                     ImporteExcento = 0
                     ImporteGrabado = 0
                     
                     Do While Not Me.DtaConsulta.Recordset.EOF
                       
                       '////////////////////////////////////////////////////////////////////////////////////////////
                       '//////////////////////SI EL NUMERO DE LINEAS ES MAYOR CREO UNA NUEVA PAGINA////////////////
                       '///////////////////////////////////////////////////////////////////////////////////////////
                     ImporteExcento = 0
                     ImporteGrabado = 0
                        
                        If i > NLineas Then
                          Printer.NewPage
                          i = 1
                        End If
                              
                              If i = 1 Then
                              
                                       '//////////////////////////////////////////////////////////////////////////////////////
                                       '//////////////////////////IMPRIMO LOS ENCABEZADOS ////////////////////////////////////
                                       '//////////////////////////////////////////////////////////////////////////////////
                                        
                                       
                    '                    Dia = Day(Me.DtaConsulta.Recordset("FechaTransaccion"))
                    '                    Mes = Month(Me.DtaConsulta.Recordset("FechaTransaccion"))
                    '                    Año = Year(Me.DtaConsulta.Recordset("FechaTransaccion"))
                                        
                                        NumeroFactura = Me.AdoEncabezado.Recordset("Numero_Factura")
                                        Fecha = Format(Me.AdoEncabezado.Recordset("Fecha_Factura"), "dd/mm/yyyy")
                                        FechaFactura = Me.AdoEncabezado.Recordset("Fecha_Factura")
                                        MonedaFactura = Me.AdoEmpresa.Recordset("MonedaFactura")
                                        MonedaImprime = Me.AdoEmpresa.Recordset("ModedaImprimeFactura")
                                        
                                        Me.AdoFacturas.RecordSource = "SELECT Facturas.* From Facturas WHERE  (Numero_Factura = '" & NumeroImpresion & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Format(FechaFactura, "yyyy-mm-dd") & "', 102)) AND (Tipo_Factura = '" & TipoImpresion & "')"
                                        Me.AdoFacturas.Refresh
                                        If Not Me.AdoFacturas.Recordset.EOF Then
                                         MonedaFactura = Me.AdoFacturas.Recordset("MonedaFactura")
                                         MonedaImprime = Me.AdoFacturas.Recordset("MonedaImprime")
                                        Else
                                         MonedaFactura = Me.AdoEmpresa.Recordset("MonedaFactura")
                                         MonedaImprime = Me.AdoEmpresa.Recordset("ModedaImprimeFactura")
                                        End If
                                        
                                        
                                       If X1 <> 0 Or Y1 <> 0 Then
                                        Printer.CurrentX = Val(X1) '5
                                        Printer.CurrentY = Val(Y1) + (5 * i) '120
                                        Printer.Print Fecha
                                       End If
                        
                                    '    me.DtaConsulta.Recordset.MoveLast
                                       If X2 <> 0 Or Y2 <> 0 Then
                                        Printer.CurrentX = X2
                                        Printer.CurrentY = Y2
                                        Printer.Print Me.AdoEncabezado.Recordset("Numero_Factura")
                                       End If
                                        
                                       If X3 <> 0 Or Y3 <> 0 Then
                                        Printer.CurrentX = Val(X3)
                                        Printer.CurrentY = Val(Y3) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("MonedaFactura")
                                       End If
                                       
                                       If X29 <> 0 Or Y29 <> 0 Then
                                        Printer.CurrentX = Val(X29)
                                        Printer.CurrentY = Val(Y29) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("Cod_Cliente")
                                       End If
                                       
                                       If X4 <> 0 Or Y4 <> 0 Then
                                        Printer.CurrentX = Val(X4)
                                        Printer.CurrentY = Val(Y4) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("Nombre_Cliente")
                                       End If
                                       
                                       If X5 <> 0 Or Y5 <> 0 Then
                                        Printer.CurrentX = Val(X5)
                                        Printer.CurrentY = Val(Y5) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("Apellido_Cliente")
                                       End If
                                    
                                       If X6 <> 0 Or Y6 <> 0 Then
                                        Printer.CurrentX = Val(X6) '20
                                        Printer.CurrentY = Val(Y6) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("Direccion_Cliente")
                                      End If
                                      
                                      If X7 <> 0 Or Y7 <> 0 Then
                                        Printer.CurrentX = Val(X7) '20
                                        Printer.CurrentY = Val(Y7) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("Telefono_Cliente")
                                      End If
                                      
                                    If X36 <> 0 Or Y36 <> 0 Then
                                        Printer.CurrentX = Val(X36) '20
                                        Printer.CurrentY = Val(Y36) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("RUC")
                                      End If
                                    
                                       If X8 <> 0 Or Y8 <> 0 Then
                                        Printer.CurrentX = Val(X8) '20
                                        Printer.CurrentY = Val(Y8) '288
                                        Printer.Print Format(Me.AdoEncabezado.Recordset("Fecha_Vencimiento"), "dd/mm/yyyy")
                                      End If
                                      
                                      If X9 <> 0 Or Y9 <> 0 Then
                                        Printer.CurrentX = Val(X9) '20
                                        Printer.CurrentY = Val(Y9) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("Cod_Bodega")
                                      End If
                                      
                                      If X10 <> 0 Or Y10 <> 0 Then
                                        Printer.CurrentX = Val(X10) '20
                                        Printer.CurrentY = Val(Y10) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("Nombre_Vendedor")
                                      End If
                                      
                                     If X11 <> 0 Or Y11 <> 0 Then
                                        Printer.CurrentX = Val(X11) '20
                                        Printer.CurrentY = Val(Y11) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("Cod_Cajero")
                                      End If
                                      
                                     If X12 <> 0 Or Y12 <> 0 Then
                                        Printer.CurrentX = Val(X12) '20
                                        Printer.CurrentY = Val(Y12) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("MetodoPago")
                                        
                                      End If
                    
                                 End If
                               
                               
                               
                               If X13 <> 0 Or Y13 <> 0 Then
                                Printer.CurrentX = Val(X13) '5
                                Printer.CurrentY = Val(Y13) + (5 * i)
                                
                                If FacturaLotes = True Then
                                 If Not IsNull(Me.DtaConsulta.Recordset("CodTarea")) Then
                                  Cadena = Me.DtaConsulta.Recordset("CodTarea")
                                  End If
                                Else
                                  Cadena = Me.DtaConsulta.Recordset("Cod_Producto")
                                End If
                                
                                If Len(Cadena) > 10 Then
                                 Cadena = Trim(Cadena)
                                End If
                                Printer.Print Cadena
                               End If
                            
                            
                              If X14 <> 0 Or Y14 <> 0 Then
        
                                CadenaDescripcion = Me.DtaConsulta.Recordset("Descripcion_Producto")
                                Cadena = Me.DtaConsulta.Recordset("Descripcion_Producto")
                                Caracter = 1
                                ContadorLinea = i
                                
                                    If Len(Cadena) > CaracteresLineas Then
                                    
                                     Do While Len(Cadena) >= CaracteresLineas
                                       If Caracter = 1 Then
                                        Cadena = Mid(Cadena, 1, CaracteresLineas)
                                        Printer.CurrentX = Val(X14) '25
                                        Printer.CurrentY = Val(Y14) + (5 * i)
                                        Printer.Print Cadena
        '                                ContadorLinea = ContadorLinea + 1
                                        Caracter = Caracter + CaracteresLineas
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA SIGUIENTE/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        If Len(Cadena) < CaracteresLineas Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X14) '25
                                            Printer.CurrentY = Val(Y14) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresLineas
                                        End If
                                       Else
                                        ContadorLinea = ContadorLinea + 1
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        Printer.CurrentX = Val(X14) '25
                                        Printer.CurrentY = Val(Y14) + (5 * ContadorLinea)
                                        Printer.Print Cadena
                                        
                                        Caracter = Caracter + CaracteresLineas
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        If Len(Cadena) < CaracteresLineas Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X14) '25
                                            Printer.CurrentY = Val(Y14) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresLineas
                                        End If
                                        
                                        
                                       End If
        
                                     
                                     Loop
                                     
                                    Else
                                      Printer.CurrentX = Val(X14) '25
                                      Printer.CurrentY = Val(Y14) + (5 * i)
                                      Printer.Print Cadena
                                    
                                    End If
                                
                                
                               End If
                            
                            Printer.FontSize = 10
                               If X15 <> 0 Or Y15 <> 0 Then
                                Printer.CurrentX = Val(X15) '25
                                Printer.CurrentY = Val(Y15) + (5 * i)
                                Cadena = Me.DtaConsulta.Recordset("Cantidad")
                                If Len(Cadena) > 8 Then
                                 Cadena = Mid(Cadena, 1, 8)
                                End If
                                Printer.Print Cadena
                              End If
                               
                            Printer.FontSize = 10
                               
                                TasaCambio = BuscaTasa(FechaFactura)
                      
                                If MonedaFactura = MonedaImprime Then
                                    PrecioUnitario = Format(Val(Me.DtaConsulta.Recordset("Precio_Unitario")), "##,##0.00")
                                    If Not IsNull(Me.DtaConsulta.Recordset("Descuento")) Then
                                      Descuento = Format(Val(Me.DtaConsulta.Recordset("Descuento")), "##,##0.00")
                                    End If
                                    PrecioNeto = Format(Val(Me.DtaConsulta.Recordset("Precio_Neto")), "##,##0.00")
                                    Importe = Format(Val(Me.DtaConsulta.Recordset("Importe")), "##,##0.00")
                                  
                                    
                                ElseIf MonedaFactura = "Cordobas" Then
                                  If MonedaImprime = "Dolares" Then
                                    PrecioUnitario = Format(Val(Me.DtaConsulta.Recordset("Precio_Unitario")) / TasaCambio, "##,##0.00")
                                    If Not IsNull(Me.DtaConsulta.Recordset("Descuento")) Then
                                     Descuento = Format(Val(Me.DtaConsulta.Recordset("Descuento")) / TasaCambio, "##,##0.00")
                                    End If
                                    PrecioNeto = Format(Val(Me.DtaConsulta.Recordset("Precio_Neto")) / TasaCambio, "##,##0.00")
                                    Importe = Format(Val(Me.DtaConsulta.Recordset("Importe")) / TasaCambio, "##,##0.00")
                                  End If
                                ElseIf MonedaFactura = "Dolares" Then
                                  If MonedaImprime = "Cordobas" Then
                                    PrecioUnitario = Format(Val(Me.DtaConsulta.Recordset("Precio_Unitario")) * TasaCambio, "##,##0.00")
                                    If Not IsNull(Me.DtaConsulta.Recordset("Descuento")) Then
                                      Descuento = Format(Val(Me.DtaConsulta.Recordset("Descuento")) * TasaCambio, "##,##0.00")
                                    End If
                                    PrecioNeto = Format(Val(Me.DtaConsulta.Recordset("Precio_Neto")) * TasaCambio, "##,##0.00")
                                    Importe = Format(Val(Me.DtaConsulta.Recordset("Importe")) * TasaCambio, "##,##0.00")
                                  End If
                                End If
                                
                                If Me.DtaConsulta.Recordset("Impuesto") = 0 Then
                                   ImporteExcento = Importe
                                Else
                                   ImporteGrabado = Importe
                                End If
                             
                              
                               If X16 <> 0 Or Y16 <> 0 Then
                                Printer.CurrentX = Val(X16) '135
                                Printer.CurrentY = Val(Y16) + (5 * i)
                                Printer.RightToLeft = True
                                Printer.Print Format(PrecioUnitario, "##,##0.00")
                                
                               End If
                            
                            
                               If X17 <> 0 Or Y17 <> 0 Then
                                Printer.CurrentX = Val(X17) '165
                                Printer.CurrentY = Val(Y17) + (5 * i)
                                Printer.RightToLeft = True
                                Printer.Print Format(Descuento, "##,##0.00")
                               End If
                               
                               
                                If X18 <> 0 Or Y18 <> 0 Then
                                 Printer.CurrentX = Val(X18) '165
                                 Printer.CurrentY = Val(Y18) + (5 * i) '165
                                 Printer.RightToLeft = True
                                Printer.Print Format(PrecioNeto, "##,##0.00")
                               End If
                               
                              If X19 <> 0 Or Y19 <> 0 Then
                                Printer.CurrentX = Val(X19) '165
                                Printer.CurrentY = Val(Y19) + (5 * i) '165
                                Printer.RightToLeft = True
                                Printer.Print Format(Importe, "##,##0.00")
                              End If
                              
                              If X33 <> 0 Or Y33 <> 0 Then
                                Printer.CurrentX = Val(X33) '165
                                Printer.CurrentY = Val(Y33) + (5 * i) '165
                                Printer.RightToLeft = True
                                Printer.Print Format(ImporteExcento, "##,##0.00")
                              End If
                               
                              
                               If X34 <> 0 Or Y34 <> 0 Then
                                Printer.CurrentX = Val(X34) '165
                                Printer.CurrentY = Val(Y34) + (5 * i) '165
                                Printer.RightToLeft = True
                                Printer.Print Format(ImporteGrabado, "##,##0.00")
                              End If
                           
                               
                               
                                If i > 1 Then
                                  UltimaLinea = UltimaLinea + (5 * i) + DiferenciaY - 4
                                End If
                                
                                i = ContadorLinea
                                i = i + 1
                                ContadorLinea = i
                    
                    
                     Me.DtaConsulta.Recordset.MoveNext
                     Loop
                     
                     '-----------------IMPRIMO LA HORA EN LA ULTIMA LINEA ------------------------
                     i = i + 1
                     If i <= NLineas Then
                       If X35 <> 0 Or Y35 <> 0 Then
                        Printer.CurrentX = Val(X35) '165
                        Printer.CurrentY = Val(Y35) + (5 * i) '165
                        Printer.RightToLeft = True
                        Printer.Print "********* " & Format(Now, "HH:MM:SS") & " *********"
                       End If
                     End If
                     
                     
                     
                      TasaCambio = BuscaTasa(FechaFactura)
                      
                      Descuento2 = 0
                      
                      If MonedaFactura = MonedaImprime Then
        '                MontoDolar = Format(Val(Me.AdoEncabezado.Recordset("NetoPagar")), "##,##0.00")
                        SubTotal = Format(Val(Me.AdoEncabezado.Recordset("SubTotal")), "##,##0.00")
                        IVA = Format(Val(Me.AdoEncabezado.Recordset("IVA")), "##,##0.00")
                        Pagado = Format(Val(Me.AdoEncabezado.Recordset("Pagado")), "##,##0.00")
'                        NetoPagar = Format(Val(Me.AdoEncabezado.Recordset("NetoPagar")), "##,##0.00")
                         NetoPagar = SubTotal + IVA
                        If Not IsNull(Me.AdoEncabezado.Recordset("Descuento")) Then
                          Descuento2 = Format(Val(Me.AdoEncabezado.Recordset("Descuento")), "##,##0.00")
                        End If
                      ElseIf MonedaFactura = "Cordobas" Then
                        If MonedaImprime = "Dolares" Then
        '                    MontoDolar = Me.AdoEncabezado.Recordset("NetoPagar") / TasaCambio
                            SubTotal = Format(Val(Me.AdoEncabezado.Recordset("SubTotal")) / TasaCambio, "##,##0.00")
                            IVA = Format(Val(Me.AdoEncabezado.Recordset("IVA")) / TasaCambio, "##,##0.00")
                            Pagado = Format(Val(Me.AdoEncabezado.Recordset("Pagado")) / TasaCambio, "##,##0.00")
'                            NetoPagar = Format(Val(Me.AdoEncabezado.Recordset("NetoPagar")) / TasaCambio, "##,##0.00")
                            NetoPagar = SubTotal + IVA
                            If Not IsNull(Me.AdoEncabezado.Recordset("Descuento")) Then
                             If Val(Me.AdoEncabezado.Recordset("Descuento")) <> 0 Then
                              Descuento2 = Format(Val(Me.AdoEncabezado.Recordset("Descuento")) / TasaCambio, "##,##0.00")
                             End If
                            End If
                        End If
                      ElseIf MonedaFactura = "Dolares" Then
                        If MonedaImprime = "Cordobas" Then
        '                    MontoDolar = Me.AdoEncabezado.Recordset("NetoPagar") * TasaCambio
                            SubTotal = Format(Val(Me.AdoEncabezado.Recordset("SubTotal")) * TasaCambio, "##,##0.00")
                            IVA = Format(Val(Me.AdoEncabezado.Recordset("IVA")) * TasaCambio, "##,##0.00")
                            Pagado = Format(Val(Me.AdoEncabezado.Recordset("Pagado")) * TasaCambio, "##,##0.00")
'                            NetoPagar = Format(Val(Me.AdoEncabezado.Recordset("NetoPagar")) * TasaCambio, "##,##0.00")
                             NetoPagar = SubTotal + IVA
                            If Not IsNull(Me.AdoEncabezado.Recordset("Descuento")) Then
                             If Val(Me.AdoEncabezado.Recordset("Descuento")) <> 0 Then
                              Descuento2 = Format(Val(Me.AdoEncabezado.Recordset("Descuento")) * TasaCambio, "##,##0.00")
                             End If
                            End If
                        End If
                      End If
                      
                      If MonedaImprime = "Dolares" Then
                        Simbolo = "$"
                      Else
                        Simbolo = "C$"
                      End If
                      
                      
                      If MonedaImprime = "Cordobas" Then
                         MontoDolar = NetoPagar / TasaCambio
                         Simbolo2 = "$"
                      ElseIf MonedaImprime = "Dolares" Then
                         MontoDolar = NetoPagar * TasaCambio
                         Simbolo2 = "C$"
                      End If
                      
                      Retencion1 = 0
                      If Me.AdoEncabezado.Recordset("Retener1Porciento") = True Then
                       If X30 <> 0 Or Y30 <> 0 Then
                        Printer.CurrentX = Val(X30) '135
                        Printer.CurrentY = Val(Y30) '288
                        Printer.Print "IM " & Simbolo & " " & Format(SubTotal * 0.01, "##,##0.00")
                        Printer.RightToLeft = True
                        Retencion1 = Format(SubTotal * 0.01, "##,##0.00")
                       End If
                      End If
                      
                      Retencion2 = 0
                      If Me.AdoEncabezado.Recordset("Retener2Porciento") = True Then
                       If X31 <> 0 Or Y31 <> 0 Then
                        Printer.CurrentX = Val(X31) '165
                        Printer.CurrentY = Val(Y31) '288
                        Printer.Print "IR " & Simbolo & " " & Format(SubTotal * 0.02, "##,##0.00")
                        Retencion2 = Format(SubTotal * 0.02, "##,##0.00")
                        Printer.RightToLeft = True
                       End If
                      End If
                    
                    
                      If X20 <> 0 Or Y20 <> 0 Then
                        Printer.CurrentX = Val(X20) '135
                        Printer.CurrentY = Val(Y20) '288
                        Printer.Print Simbolo & " " & Format(SubTotal, "##,##0.00")
                        Printer.RightToLeft = True
                        
'                        Printer.CurrentX = Val(X16) '135
'                        Printer.CurrentY = Val(Y20) '288
'                        Printer.Print "SubTotal"
'                        Printer.RightToLeft = True
                      End If
                      
                      If X21 <> 0 Or Y21 <> 0 Then
                        Printer.CurrentX = Val(X21) '165
                        Printer.CurrentY = Val(Y21) '288
                        Printer.Print Simbolo & " " & Format(IVA, "##,##0.00")
                        Printer.RightToLeft = True
                        
'                        Printer.CurrentX = Val(X16) '135
'                        Printer.CurrentY = Val(Y21) '288
'                        Printer.Print "IVA"
'                        Printer.RightToLeft = True
                      End If
                    
                      If X22 <> 0 Or Y22 <> 0 Then
                        Printer.CurrentX = Val(X22) '165
                        Printer.CurrentY = Val(Y22) '288
                        Printer.Print Simbolo & " " & Format(Pagado, "##,##0.00")
                        Printer.RightToLeft = True
                        
                        Printer.CurrentX = Val(X16) '135
                        Printer.CurrentY = Val(Y22) '288
                        Printer.Print "Pagado"
                        Printer.RightToLeft = True
                      End If
                    
                       If X23 <> 0 Or Y23 <> 0 Then
                        Printer.CurrentX = Val(X23) '165
                        Printer.CurrentY = Val(Y23) '288
                        Printer.Print Simbolo & " " & Format(NetoPagar - (Retencion1 + Retencion2), "##,##0.00")
                        Printer.RightToLeft = True
                      End If
                    
                       If X24 <> 0 Or Y24 <> 0 Then
                       
                       
                                CadenaDescripcion = Me.AdoEncabezado.Recordset("Observaciones")
                                Cadena = Me.AdoEncabezado.Recordset("Observaciones")
                                Caracter = 1
                                ContadorLinea = 0
                                
                                    If Len(Cadena) > CaracteresObservacion Then
                                    
                                     Do While Len(Cadena) >= CaracteresObservacion
                                       If Caracter = 1 Then
                                        Cadena = Mid(Cadena, 1, CaracteresObservacion)
                                        Printer.CurrentX = Val(X24) '25
                                        Printer.CurrentY = Val(Y24)
                                        Printer.Print Cadena
        '                                ContadorLinea = ContadorLinea + 1
                                        Caracter = Caracter + CaracteresObservacion
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA SIGUIENTE/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                                        If Len(Cadena) < CaracteresObservacion Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X24) '25
                                            Printer.CurrentY = Val(Y24) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresObservacion
                                        End If
                                       Else
                                        ContadorLinea = ContadorLinea + 1
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                                        Printer.CurrentX = Val(X24) '25
                                        Printer.CurrentY = Val(Y24) + (5 * ContadorLinea)
                                        Printer.Print Cadena
                                        
                                        Caracter = Caracter + CaracteresObservacion
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresObservacion)
                                        If Len(Cadena) < CaracteresObservacion Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X24) '25
                                            Printer.CurrentY = Val(Y24) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresObservacion
                                        End If
                                        
                                        
                                       End If
        
                                     
                                     Loop
                                     
                                    Else
                                      Printer.CurrentX = Val(X24) '25
                                      Printer.CurrentY = Val(Y24)
                                      Printer.Print Cadena
                                    
                                    End If
                       
                      
                       
                       
'                        Printer.CurrentX = Val(X24) '165
'                        Printer.CurrentY = Val(Y24) '288
'                        Printer.Print Me.AdoEncabezado.Recordset("Observaciones")
                      End If
                      
        
                      
                      
                      If X25 <> 0 Or Y25 <> 0 Then
                        Printer.CurrentX = Val(X25) '165
                        Printer.CurrentY = Val(Y25) '288
                        Printer.Print Simbolo2 & " " & Format(MontoDolar, "##,##0.00")
                      End If
                      
                      If X26 <> 0 Or Y26 <> 0 Then
                        Printer.CurrentX = Val(X26) '165
                        Printer.CurrentY = Val(Y26) '288
                        Printer.Print "Tasa Cambio: " & Format(TasaCambio, "##,##0.0000")
                      End If
                      
                       If X27 <> 0 Or Y27 <> 0 Then
                        Printer.CurrentX = Val(X27) '165
                        Printer.CurrentY = Val(Y27) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(Descuento2, "##,##0.00")
                      End If
                      
                      If MonedaImprime = "Dolares" Then
                            MontoLetras = sw.ConvertCurrencyToSpanish(NetoPagar - (Retencion1 + Retencion2), "Dólares")
                      ElseIf MonedaImprime = "Cordobas" Then
                            MontoLetras = sw.ConvertCurrencyToSpanish(NetoPagar - (Retencion1 + Retencion2), "Córdobas")
                      End If
                      
                       If X28 <> 0 Or Y28 <> 0 Then
                        Printer.CurrentX = Val(X28) '165
                        Printer.CurrentY = Val(Y28) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(MontoLetras, "##,##0.00")
                      End If
                      
                     If X32 <> 0 Or Y32 <> 0 Then
                        Printer.CurrentX = Val(X32) '165
                        Printer.CurrentY = Val(Y32) '288
                        Printer.RightToLeft = True
                        Printer.Print "AFC-DGI-ARC-JTA-0002-05-2012"
                      End If
                      
                    'termino de imprimir las facturas
                    Printer.EndDoc
        
        '            DoEvents
        
          Case "Recibos de Caja"
                Me.DtaConsulta.RecordSource = "SELECT * From DetalleRecibo WHERE  (CodReciboPago = '" & NumeroImpresion & "') AND (Fecha_Recibo = CONVERT(DATETIME, '" & Format(FechaImpresion, "yyyy-mm-dd") & "', 102))"
                Me.DtaConsulta.Refresh
                 
                Me.AdoEncabezado.RecordSource = "SELECT  * From Recibo WHERE (CodReciboPago = '" & NumeroImpresion & "') AND (Fecha_Recibo = CONVERT(DATETIME,  '" & Format(FechaImpresion, "yyyy-mm-dd") & "', 102))"
                Me.AdoEncabezado.Refresh
                If Me.AdoEncabezado.Recordset.EOF Then
                  MsgBox "No se encontro el encabezado del recibo"
                  Exit Sub
                End If
           
                      
                      Printer.FontSize = 9
                     'Inicio el Ciclo de Impresion
                     i = 1
                     Do While Not Me.DtaConsulta.Recordset.EOF
                       
                       '////////////////////////////////////////////////////////////////////////////////////////////
                       '//////////////////////SI EL NUMERO DE LINEAS ES MAYOR CREO UNA NUEVA PAGINA////////////////
                       '///////////////////////////////////////////////////////////////////////////////////////////
                        
                        If i > NLineas Then
                          Printer.NewPage
                          i = 1
                        End If
                              
                              If i = 1 Then
                              
                                       '//////////////////////////////////////////////////////////////////////////////////////
                                       '//////////////////////////IMPRIMO LOS ENCABEZADOS ////////////////////////////////////
                                       '//////////////////////////////////////////////////////////////////////////////////
                                        
                                       
                    '                    Dia = Day(Me.DtaConsulta.Recordset("FechaTransaccion"))
                    '                    Mes = Month(Me.DtaConsulta.Recordset("FechaTransaccion"))
                    '                    Año = Year(Me.DtaConsulta.Recordset("FechaTransaccion"))
                                        Fecha = Format(Me.AdoEncabezado.Recordset("Fecha_Recibo"), "dd/mm/yyyy")
                                        FechaFactura = Me.AdoEncabezado.Recordset("Fecha_Recibo")
                                        MonedaRecibo = Me.AdoEncabezado.Recordset("MonedaRecibo")
                                        TasaCambio = BuscaTasa(FechaFactura)
                                        
                                       If X1 <> 0 Or Y1 <> 0 Then
                                        Printer.CurrentX = Val(X1) '5
                                        Printer.CurrentY = Val(Y1) + (5 * i) '120
                                        Printer.Print Fecha
                                       End If
                        
                                    '    me.DtaConsulta.Recordset.MoveLast
                                       If X2 <> 0 Or Y2 <> 0 Then
                                        Printer.CurrentX = X2
                                        Printer.CurrentY = Y2
                                        Printer.Print Me.AdoEncabezado.Recordset("CodReciboPago")
                                       End If
                                        
                                       If X3 <> 0 Or Y3 <> 0 Then
                                        Printer.CurrentX = Val(X3)
                                        Printer.CurrentY = Val(Y3) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("Cod_Cliente")
                                       End If
                                       
                                       If X4 <> 0 Or Y4 <> 0 Then
                                        Printer.CurrentX = Val(X4)
                                        Printer.CurrentY = Val(Y4) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("NombreCliente")
                                       End If
                                       
                                       If X5 <> 0 Or Y5 <> 0 Then
                                        Printer.CurrentX = Val(X5)
                                        Printer.CurrentY = Val(Y5) + (5 * i)
                                        Printer.Print Me.AdoEncabezado.Recordset("ApellidosCliente")
                                       End If
                                    
                                       If X6 <> 0 Or Y6 <> 0 Then
                                        Printer.CurrentX = Val(X6) '20
                                        Printer.CurrentY = Val(Y6) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("DireccionCliente")
                                      End If
                                      
                                      If X7 <> 0 Or Y7 <> 0 Then
                                        Printer.CurrentX = Val(X7) '20
                                        Printer.CurrentY = Val(Y7) '288
                                        Printer.Print Me.AdoEncabezado.Recordset("TelefonoCliente")
                                      End If
                                      
                                      '//////////////////////////////////////////////////////////////////////////////////////////////////////////
                                      '///////////////////////ESTAS SON LAS COORDENADAS DEL IMPORTE RECIBIDO Y APLICADO Y POR APLICAR /////////////////
                                      '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                      
'                                       If X8 <> 0 Or Y8 <> 0 Then
'                                        Printer.CurrentX = Val(X8) '20
'                                        Printer.CurrentY = Val(Y8) '288
'                                        Printer.Print Format(Me.AdoEncabezado.Recordset("Fecha_Vencimiento"), "dd/mm/yyyy")
'                                      End If
'
'                                      If X9 <> 0 Or Y9 <> 0 Then
'                                        Printer.CurrentX = Val(X9) '20
'                                        Printer.CurrentY = Val(Y9) '288
'                                        Printer.Print Me.AdoEncabezado.Recordset("Cod_Bodega")
'                                      End If
'
'                                      If X10 <> 0 Or Y10 <> 0 Then
'                                        Printer.CurrentX = Val(X10) '20
'                                        Printer.CurrentY = Val(Y10) '288
'                                        Printer.Print Me.AdoEncabezado.Recordset("Nombre_Vendedor")
'                                      End If
                                      
                    
                                 End If
                                 
     '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     '/////////////////////////////////IMPRIMO EL DETALLE DEL RECIBO//////////////////////////////////////////////////
     '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                 
                              If X11 <> 0 Or Y11 <> 0 Then
                                  Printer.CurrentX = Val(X11) '20
                                  Printer.CurrentY = Val(Y11) '288
                                  Printer.Print Me.DtaConsulta.Recordset("NombrePago")
                                  If Len(Cadena) > 10 Then
                                    Cadena = Mid(Cadena, 1, 10)
                                  End If
                                  Printer.Print Cadena
                              End If
                                      
                           
                            
                              If X12 <> 0 Or Y12 <> 0 Then
        
                                CadenaDescripcion = Me.DtaConsulta.Recordset("Descripcion") & " Recibo No " & Me.DtaConsulta.Recordset("Numero_Factura")
                                Cadena = Me.DtaConsulta.Recordset("Descripcion") & " Factura No " & Me.DtaConsulta.Recordset("Numero_Factura")
                                Caracter = 1
                                ContadorLinea = i
                                
                                    If Len(Cadena) > CaracteresLineas Then
                                    
                                     Do While Len(Cadena) >= CaracteresLineas
                                       If Caracter = 1 Then
                                        Cadena = Mid(Cadena, 1, CaracteresLineas)
                                        Printer.CurrentX = Val(X12) '25
                                        Printer.CurrentY = Val(Y12) + (5 * i)
                                        Printer.Print Cadena
        '                                ContadorLinea = ContadorLinea + 1
                                        Caracter = Caracter + CaracteresLineas
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA SIGUIENTE/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        If Len(Cadena) < CaracteresLineas Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X12) '25
                                            Printer.CurrentY = Val(Y12) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresLineas
                                        End If
                                       Else
                                        ContadorLinea = ContadorLinea + 1
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        Printer.CurrentX = Val(X12) '25
                                        Printer.CurrentY = Val(Y12) + (5 * ContadorLinea)
                                        Printer.Print Cadena
                                        
                                        Caracter = Caracter + CaracteresLineas
                                        
                                        '//////////////////VERIFICO SI LO QUE SOBRE ES MAYOR DE LA LINEA/////////////////
                                        Cadena = Mid(CadenaDescripcion, Caracter, CaracteresLineas)
                                        If Len(Cadena) < CaracteresLineas Then
                                         '///////////////////////SI ES MENOR IMPRIMO/////////////////////////
                                            ContadorLinea = ContadorLinea + 1
                                            Printer.CurrentX = Val(X12) '25
                                            Printer.CurrentY = Val(Y12) + (5 * ContadorLinea)
                                            Printer.Print Cadena
                                            
                                            Caracter = Caracter + CaracteresLineas
                                        End If
                                        
                                        
                                       End If
        
                                     
                                     Loop
                                     
                                    Else
                                      Printer.CurrentX = Val(X12) '25
                                      Printer.CurrentY = Val(Y12) + (5 * i)
                                      Printer.Print Cadena
                                    
                                    End If
                                
                                
                               End If
                               
'                              If X13 <> 0 Or Y13 <> 0 Then
'                                Printer.CurrentX = Val(X13) '5
'                                Printer.CurrentY = Val(Y13) + (5 * i)
'                                Cadena = Me.DtaConsulta.Recordset("Cod_Producto")
'                                If Len(Cadena) > 10 Then
'                                 Cadena = Mid(Cadena, 1, 10)
'                                End If
'                                Printer.Print Cadena
'                               End If
                            
                            
                               If X14 <> 0 Or Y14 <> 0 Then
                                Printer.CurrentX = Val(X14) '25
                                Printer.CurrentY = Val(Y14) + (5 * i)
                                Cadena = Me.DtaConsulta.Recordset("MontoPagado")
'                                If Len(Cadena) > 10 Then
'                                 Cadena = Mid(Cadena, 1, 5)
'                                End If
                                Printer.Print Format(Me.DtaConsulta.Recordset("MontoPagado"), "##,##0.00")
                              End If
                               
                                  Me.AdoMetodo.RecordSource = "SELECT  * From MetodoPago WHERE (NombrePago = '" & Me.DtaConsulta.Recordset("NombrePago") & "')"
                                  Me.AdoMetodo.Refresh
                                  If Not Me.AdoMetodo.Recordset.EOF Then
                                   MonedaMetodo = Me.AdoMetodo.Recordset("Moneda")
                                  End If
                               
                                TasaCambio = BuscaTasa(FechaFactura)
                                
                                
                                If MonedaMetodo = "Cordobas" Then
                                     MontoCordobas = Me.DtaConsulta.Recordset("MontoPagado") + MontoCordobas
                                     If TasaCambio <> 0 Then
                                        MontoDolares = MontoCordobas / TasaCambio
                                     Else
                                        MsgBox "Tasa de Cambio no Existe", vbCritical, "Zeus Facturacion"
                                        Exit Sub
                                     End If
                                Else
                                     MontoDolares = Me.DtaConsulta.Recordset("MontoPagado") + MontoDolares
                                     If TasaCambio <> 0 Then
                                        MontoCordobas = MontoDolares * TasaCambio
                                     Else
                                        MsgBox "Tasa de Cambio no Existe", vbCritical, "Zeus Facturacion"
                                        Exit Sub
                                     End If
                                End If
                            
                            
                                If i > 1 Then
                                  UltimaLinea = UltimaLinea + (5 * i) + DiferenciaY - 4
                                End If
                                
                                i = ContadorLinea
                                i = i + 1
                                ContadorLinea = i
                    
                    
                     Me.DtaConsulta.Recordset.MoveNext
                     Loop
                     
                        SubTotal = Format(Val(Me.AdoEncabezado.Recordset("Sub_Total")), "##,##0.00")
                        IVA = Format(Val(Me.AdoEncabezado.Recordset("Descuento")), "##,##0.00")
                        Pagado = Format(Val(Me.AdoEncabezado.Recordset("Total")), "##,##0.00")
                        
                      If X15 <> 0 Or Y15 <> 0 Then
                        Printer.CurrentX = Val(X15) '135
                        Printer.CurrentY = Val(Y15) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(SubTotal, "##,##0.00")
                      End If
                      
                      If X16 <> 0 Or Y16 <> 0 Then
                        Printer.CurrentX = Val(X16) '165
                        Printer.CurrentY = Val(Y16) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(IVA, "##,##0.00")
                      End If
                    
                      If X17 <> 0 Or Y17 <> 0 Then
                        Printer.CurrentX = Val(X17) '165
                        Printer.CurrentY = Val(Y17) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(Pagado, "##,##0.00")
                      End If
                      
                      If X18 <> 0 Or Y18 <> 0 Then
                        Printer.CurrentX = Val(X18) '165
                        Printer.CurrentY = Val(Y18) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(MontoCordobas, "##,##0.00")
                      End If
                      
                      If X19 <> 0 Or Y19 <> 0 Then
                        Printer.CurrentX = Val(X19) '165
                        Printer.CurrentY = Val(Y19) '288
                        Printer.RightToLeft = True
                        Printer.Print Format(MontoDolares, "##,##0.00")
                      End If
                      
                      If MonedaRecibo = "Dolares" Then
                            MontoLetras = sw.ConvertCurrencyToSpanish(Pagado, "Dólares")
                      ElseIf MonedaRecibo = "Cordobas" Then
                            MontoLetras = sw.ConvertCurrencyToSpanish(Pagado, "Córdobas")
                      End If
                      
                       If X20 <> 0 Or Y20 <> 0 Then
                        Printer.CurrentX = Val(X20) '165
                        Printer.CurrentY = Val(Y20) '288
                        Printer.RightToLeft = True
                        Printer.Print MontoLetras
                      End If
                      
                      Printer.EndDoc
        
        End Select

 Next


MsgBox "Impresion Correcta", vbExclamation, "Zeus Facturacion"
Exit Sub
TipoErrs:
 MsgBox Err.Description




End Sub

Private Sub SmartButton2_Click()
Unload Me
End Sub

Private Sub Form_Initialize()
    On Error GoTo TipoErrs
    Dim SqlCheque As String
        Set ew = New cls_NumEnglishWord
        Set sw = New cls_NumSpanishWord
        'DBGdetalleCk.Columns(3).Button = True
    Exit Sub
TipoErrs:
    MsgBox Err.Description
End Sub

Private Sub Form_Terminate()
On Error GoTo TipoErrs
    Set ew = Nothing
    Set sw = Nothing
    Exit Sub
TipoErrs:
MsgBox Err.Description
End Sub
