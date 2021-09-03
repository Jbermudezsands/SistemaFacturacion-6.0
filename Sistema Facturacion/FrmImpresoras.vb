Imports System
Imports System.Drawing.Printing
Imports System.IO
Imports System.Collections


Public Class FrmImpresoras
    Public RutaBD As String = My.Application.Info.DirectoryPath & "\Impresoras.dll", ConexionImpresora As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean

    Private Sub FrmImpresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pd As New PrintDocument
        Dim Impresoras As String, Ruta As String
        Dim Settings As My.MySettings = My.MySettings.Default


        Me.CmbImpresorasRemision.Items.Clear()

        ' Default printer      
        Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            Me.CmbImpresorasRemision.Items.Add(Impresoras.ToString)
            Me.CmbImpresorasRecibo.Items.Add(Impresoras.ToString)
        Next
        ' selecciona la impresora predeterminada 
        Me.CmbImpresorasRemision.Text = s_Default_Printer

        Me.CmbImpresorasRemision.Text = BuscaImpresora("Remision")
        Me.CmbImpresorasRecibo.Text = BuscaImpresora("Tickets")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Establecer_Impresora(Me.CmbImpresorasRemision.Text)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim Ruta As String = My.Application.Info.DirectoryPath & "\Impresoras.txt"
        Dim sLine As String = "", RutaTemp As String, RutaOld As String
        Dim arrText As New ArrayList(), CadenaDiv() As String, Max As Double
        Dim ModuloArchivo As String, i As Double


        GuardaImpresora("Remision", Me.CmbImpresorasRemision.Text)

        GuardaImpresora("Tickets", Me.CmbImpresorasRecibo.Text)



        'If Dir(Ruta) <> "" Then
        '    File.Copy(Ruta, RutaOld, True)

        '    Dim objReader As New StreamReader(RutaOld)
        '    Dim sw As New System.IO.StreamWriter(RutaTemp)

        '    i = 0
        '    Do


        '        sLine = objReader.ReadLine()


        '        If Not sLine Is Nothing Then
        '            arrText.Add(sLine)

        '            CadenaDiv = sLine.Split(">")
        '            Max = UBound(CadenaDiv)

        '            If Max >= 1 Then

        '                ModuloArchivo = CadenaDiv(0)
        '                Select Case ModuloArchivo
        '                    Case "Remision" : CadenaDiv(1) = Me.CmbImpresorasRemision.Text
        '                    Case "Tickets" : CadenaDiv(1) = Me.CmbImpresorasRecibo.Text
        '                End Select


        '            End If



        '            sw.WriteLine(String.Join(">", CadenaDiv))

        '        End If
        '    Loop Until sLine Is Nothing

        '    objReader.Close()
        '    sw.Close()


        '    'File.Delete(Ruta)
        '    'File.Move(RutaTemp, Ruta)
        '    File.Copy(RutaTemp, Ruta, True)


        'Else
        '    MsgBox("No Existe el Archivo Impresoras", MsgBoxStyle.Critical, "Impresoras")
        'End If







        'GuardaImpresora(Me.ComboBox1.Text, Me.CmbImpresorasRemision.Text)

        MsgBox("Se ha Guardado con Exito!!!", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.CmbImpresorasRemision.Text = BuscaImpresora(Me.ComboBox1.Text)
    End Sub

    Private Sub CmbImpresorasRemision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbImpresorasRemision.SelectedIndexChanged

    End Sub

    Private Sub CmbImpresorasRecibo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbImpresorasRecibo.SelectedIndexChanged

    End Sub
End Class