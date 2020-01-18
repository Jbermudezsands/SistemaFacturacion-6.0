
Private Function ConvertHundreds(ByVal MyNumber As Variant) As String
   On Error GoTo TipoErrs
    Dim rtn As String
    
    '//Exit if there is nothing to convert.
    If Val(MyNumber) = 0 Then Exit Function
    
    '//Append leading zeros to number.
    MyNumber = Right$("000" & MyNumber, 3)
    
    '//Do we have a hundreds place digit to convert?
    If Not Left$(MyNumber, 1) = "0" Then
       rtn = ConvertDigit(Left$(MyNumber, 1)) & " Hundred "
    End If
    
    '//Do we have a tens place digit to convert?
    If Not Mid$(MyNumber, 2, 1) = "0" Then
       rtn = rtn & ConvertTens(Mid$(MyNumber, 2))
    Else
       '//If not, then convert the ones place digit.
       rtn = rtn & ConvertDigit(Mid$(MyNumber, 3))
    End If
    
    ConvertHundreds = Trim$(rtn)
  Exit Function
TipoErrs:

End Function

Private Function ConvertTens(ByVal MyTens As Variant) As String
    Dim rtn As String
    On Error GoTo TipoErrs:
    '//Is value between 10 and 19?
    If Val(Left$(MyTens, 1)) = 1 Then
       Select Case Val(MyTens)
           Case 10: rtn = "Ten"
           Case 11: rtn = "Eleven"
           Case 12: rtn = "Twelve"
           Case 13: rtn = "Thirteen"
           Case 14: rtn = "Fourteen"
           Case 15: rtn = "Fifteen"
           Case 16: rtn = "Sixteen"
           Case 17: rtn = "Seventeen"
           Case 18: rtn = "Eighteen"
           Case 19: rtn = "Nineteen"
           Case Else
       End Select
    Else
       '//.. otherwise it's between 20 and 99.
       Select Case Val(Left$(MyTens, 1))
           Case 2: rtn = "Twenty "
           Case 3: rtn = "Thirty "
           Case 4: rtn = "Forty "
           Case 5: rtn = "Fifty "
           Case 6: rtn = "Sixty "
           Case 7: rtn = "Seventy "
           Case 8: rtn = "Eighty "
           Case 9: rtn = "Ninety "
           Case Else
       End Select
    
       '//Convert ones place digit.
       rtn = rtn & ConvertDigit(Right$(MyTens, 1))
    End If
    
    ConvertTens = rtn
    Exit Function
TipoErrs:

End Function

Private Function ConvertDigit(ByVal MyDigit As Variant) As String
  On Error GoTo TipoErrs
    Select Case Val(MyDigit)
        Case 1: ConvertDigit = "One"
        Case 2: ConvertDigit = "Two"
        Case 3: ConvertDigit = "Three"
        Case 4: ConvertDigit = "Four"
        Case 5: ConvertDigit = "Five"
        Case 6: ConvertDigit = "Six"
        Case 7: ConvertDigit = "Seven"
        Case 8: ConvertDigit = "Eight"
        Case 9: ConvertDigit = "Nine"
        Case Else: ConvertDigit = Void
    End Select
Exit Function
TipoErrs:

End Function


