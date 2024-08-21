Module Mod_Shared
    'DefLng A-Z
    'Option Explicit

    Public Const Void As String = ""
    Public Const Dot As String = "."

    '//String utility
    Public Sub ReplaceStringFrom(ByVal s As String, ByVal OldWrd As String, ByVal NewWrd As String, ByVal ptr As Double)
        s = Left$(s, ptr - 1) + NewWrd + Mid$(s, Len(OldWrd) + ptr)
    End Sub

    '//String utility
    Public Sub ReplaceAll(ByVal s As String, ByVal OldWrd As String, ByVal NewWrd As String)
        Dim ptr
        Do
            ptr = InStr(s, OldWrd)
            If ptr Then
                s = Left$(s, ptr - 1) + NewWrd + Mid$(s, Len(OldWrd) + ptr)
            End If
        Loop Until ptr = 0
    End Sub

    '//String utility
    Public Function Singular(ByVal s As String) As String
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
End Module
