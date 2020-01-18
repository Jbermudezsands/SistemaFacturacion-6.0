Attribute VB_Name = "mod_Sahred"
DefLng A-Z
Option Explicit

Public Const Void As String = ""
Public Const Dot  As String = "."

'//String utility
Public Sub ReplaceStringFrom(s As String, OldWrd As String, NewWrd As String, ptr)
    s = Left$(s, ptr - 1) + NewWrd + Mid$(s, Len(OldWrd) + ptr)
End Sub

'//String utility
Public Sub ReplaceAll(s As String, OldWrd As String, NewWrd As String)
    Dim ptr
    Do
       ptr = InStr(s, OldWrd)
       If ptr Then
          s = Left$(s, ptr - 1) + NewWrd + Mid$(s, Len(OldWrd) + ptr)
       End If
    Loop Until ptr = 0
End Sub

'//String utility
Public Function Singular(s As String) As String
    If Len(s) >= 2 Then
       If Right$(s, 1) = "s" Then
          If Right$(s, 2) = "es" Then
             Singular = Left$(s, Len(s) - 2)
          Else
             Singular = Left$(s, Len(s) - 1)
          End If
       Else
          Singular = s
       End If
    End If
End Function
