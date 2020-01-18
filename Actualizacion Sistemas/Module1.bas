Attribute VB_Name = "Module1"
Public Sub KillProcess(ByVal processName As String)
    On Error GoTo errHandler
    Dim oWMI
    Dim ret
    Dim sService
    Dim oWMIServices
    Dim oWMIService
    Dim oServices
    Dim oService
    Dim servicename
    Set oWMI = GetObject("winmgmts:")
    Set oServices = oWMI.InstancesOf("win32_process")
    For Each oService In oServices
    
    servicename = LCase(Trim(CStr(oService.Name) & ""))
    
    If InStr(1, servicename, LCase(processName), vbTextCompare) > 0 Then
    ret = oService.Terminate
    End If
    
    Next
    
    Set oServices = Nothing
    Set oWMI = Nothing
    
errHandler:
    Err.Clear
End Sub
