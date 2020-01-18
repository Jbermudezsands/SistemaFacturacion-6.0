VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cls_NumSpanishWord"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'//PETROSOFT
'//Convertir números a palabras en Español
'//Ultima revisión Dic 20, 1998
'//Escrito por Harvey T.

DefLng A-Z
Option Explicit

'//PROPERTY: m_FeminineGenerous
Private m_FeminineGenerous As Boolean

Public Function ConvertCurrencyToSpanish( _
    ByVal Number As Variant, _
    ByVal CurrentMoney As Variant, _
    Optional FeminineGenerous As Variant = False _
    ) As String
    Dim s            As String
    Dim DecimalPlace As Long
    Dim IntPart      As String
    Dim Cents        As String
On Error GoTo TipoErrs
    m_FeminineGenerous = FeminineGenerous
    s = Format(Val(Number), "0.00")
    DecimalPlace = InStr(s, Dot)
   
    If DecimalPlace Then
       IntPart = Left$(s, DecimalPlace - 1)
       Cents = Left$(Mid$(s, DecimalPlace + 1, 2), 2)
    Else
       IntPart = s
       Cents = Void
    End If

    If IntPart = "0" Or IntPart = Void Then
       s = "Cero "
    ElseIf Len(IntPart) > 7 Then
       s = IntNumToSpanish(Val(Left$(IntPart, Len(IntPart) - 6))) + _
           "Millones " + IntNumToSpanish(Val(Right$(IntPart, 6)))
    Else
       s = IntNumToSpanish(Val(IntPart))
    End If

    If Right$(s, 9) = "Millones " Or Right$(s, 7) = "Millón " Then
       s = s + "de "
    End If
    Select Case s
        Case "Un ", "Una "
            s = s & Singular(CStr(CurrentMoney))
        Case Else
            s = s & CurrentMoney
    End Select

    If Val(Cents) Then
       Cents = " con " + IntNumToSpanish(Val(Cents)) + "Centavos"
    Else
       Cents = " con Cero Centavos"
    End If

    ConvertCurrencyToSpanish = s + Cents
Exit Function
TipoErrs:

End Function

Public Function IntNumToSpanish(numero As Long) As String
    Dim ptr
    Dim n
    Dim i
    Dim s   As String
    Dim rtn As String
    Dim tem As String
   On Error GoTo TipoErrs
    s = CStr(numero)
    n = Len(s)

    tem = Void
    i = n
    Do Until i = 0
       tem = EvalPart(Val(Mid$(s, n - i + 1, 1) + String$(i - 1, "0")))
       If Not tem = "Cero" Then
          rtn = rtn + tem + " "
       End If
       i = i - 1
    Loop
    
    '//Filters
    GoSub filterThousands
    GoSub filterHundreds
    GoSub filterMisc
    GoSub filterOne
    GoSub addAnd
  
    IntNumToSpanish$ = rtn
Exit Function

filterThousands:
  ReplaceAll rtn, " Mil Mil", " Un Mil"
  Do
     ptr = InStr(rtn, "Mil ")
     If ptr Then
        If InStr(ptr + 1, rtn, "Mil ") Then
           ReplaceStringFrom rtn, "Mil ", "", ptr
        Else: Exit Do
        End If
     Else: Exit Do
     End If
  Loop
Return

filterHundreds:
  ptr = 0
  Do
     ptr = InStr(ptr + 1, rtn, "Cien ")
     If ptr Then
        tem = Left$(Mid$(rtn, ptr + 5), 1)
        If tem = "M" Or tem = Void Then
        Else
           ReplaceStringFrom rtn, "Cien", "Ciento", ptr
        End If
     End If
  Loop Until ptr = 0
Return

filterMisc:
  ReplaceAll rtn, "Diez Un", "Once"
  ReplaceAll rtn, "Diez Dos", "Doce"
  ReplaceAll rtn, "Diez Tres", "Trece"
  ReplaceAll rtn, "Diez Cuatro", "Catorce"
  ReplaceAll rtn, "Diez Cinco", "Quince"
  ReplaceAll rtn, "Diez Seis", "Dieciseis"
  ReplaceAll rtn, "Diez Siete", "Diecisiete"
  ReplaceAll rtn, "Diez Ocho", "Dieciocho"
  ReplaceAll rtn, "Diez Nueve", "Diecinueve"
  ReplaceAll rtn, "Veinte Un", "Veintiun"
  ReplaceAll rtn, "Veinte Dos", "Veintidos"
  ReplaceAll rtn, "Veinte Tres", "Veintitres"
  ReplaceAll rtn, "Veinte Cuatro", "Veinticuatro"
  ReplaceAll rtn, "Veinte Cinco", "Veinticinco"
  ReplaceAll rtn, "Veinte Seis", "Veintiseís"
  ReplaceAll rtn, "Veinte Siete", "Veintisiete"
  ReplaceAll rtn, "Veinte Ocho", "Veintiocho"
  ReplaceAll rtn, "Veinte Nueve", "Veintinueve"
Return

filterOne:
  If Left$(rtn, 1) = "M" Then
     rtn = "Un " + rtn
  End If
  '//Un Mil...
  If Left$(rtn, 6) = "Un Mil" Then
     rtn = Mid$(rtn, 4)
  End If
Return

addAnd:
  For i = 65 To 88
      If Not i = 77 Then
         ReplaceAll rtn, "a " + Chr$(i), "* y " + Chr$(i)
      End If
  Next
  ReplaceAll rtn, "*", "a"
Return
Exit Function
TipoErrs:

End Function

Private Function EvalPart(x As Long) As String
   On Error GoTo TipoErrs
    Dim rtn As String, s As String, i
    Do
       GoSub SinglePart
       If s = Void Then
          i = i + 1
          x = x / 1000
          If x = 0 Then i = 0
       Else
         Exit Do
       End If
    Loop Until i = 0
   
    rtn = s
    GoSub EngPart
   
    EvalPart = rtn + s
Exit Function

SinglePart:
    Select Case x
           Case 0:  s = "Cero"
           Case 1:  s = "Un"
           Case 2:  s = "Dos"
           Case 3:  s = "Tres"
           Case 4:  s = "Cuatro"
           Case 5:  s = "Cinco"
           Case 6:  s = "Seis"
           Case 7:  s = "Siete"
           Case 8:  s = "Ocho"
           Case 9:  s = "Nueve"
           Case 10: s = "Diez"
           Case 20: s = "Veinte"
           Case 30: s = "Treinta"
           Case 40: s = "Cuarenta"
           Case 50: s = "Cincuenta"
           Case 60: s = "Sesenta"
           Case 70: s = "Setenta"
           Case 80: s = "Ochenta"
           Case 90: s = "Noventa"
           Case 100: s = "Cien"
           Case 200: s = "Doscientos"
           Case 300: s = "Trescientos"
           Case 400: s = "Cuatrocientos"
           Case 500: s = "Quinientos"
           Case 600: s = "Seiscientos"
           Case 700: s = "Setecientos"
           Case 800: s = "Ochocientos"
           Case 900: s = "Novecientos"
           Case 1000: s = "Mil"
           Case 1000000: s = "Millón"
    End Select
    If m_FeminineGenerous Then
       ReplaceAll s, "tos", "tas"
       If s = "Un" Then s = "Una"
    End If
Return

EngPart: '//E+00...
    Select Case i
           Case 0: s = Void
           Case 1: s = " Mil"
           Case 2: s = " Millones"
           Case 3: s = " Billones"
    End Select
Return
Exit Function
TipoErrs:

End Function
