Imports System
Imports System.Drawing.Printing


Public Class FrmImpresoras
    Public RutaBD As String = My.Application.Info.DirectoryPath & "\Impresoras.dll", ConexionImpresora As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "

    Private Sub FrmImpresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Impresoras As String

        Me.CmbImpresorasRemision.Items.Clear()
        Me.CmbImpresorasRecibo.Items.Clear()
        Me.CmbImpresorasComanda.Items.Clear()
        Me.CmbImpresorasComandaBar.Items.Clear()

        ' recorre las impresoras instaladas
        For Each Impresoras In PrinterSettings.InstalledPrinters
            Me.CmbImpresorasRemision.Items.Add(Impresoras.ToString)
            Me.CmbImpresorasRecibo.Items.Add(Impresoras.ToString)
            Me.CmbImpresorasComanda.Items.Add(Impresoras.ToString)
            Me.CmbImpresorasComandaBar.Items.Add(Impresoras.ToString)
        Next

        Me.CmbImpresorasRemision.Text = BuscaImpresora("Factura")
        Me.CmbImpresorasRecibo.Text = BuscaImpresora("Recibo")
        Me.CmbImpresorasComanda.Text = BuscaImpresora("Comanda")
        Me.CmbImpresorasComandaBar.Text = BuscaImpresora("ComandaBar")

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            GuardaImpresora("Factura", Me.CmbImpresorasRemision.Text)
            GuardaImpresora("Recibo", Me.CmbImpresorasRecibo.Text)
            GuardaImpresora("Comanda", Me.CmbImpresorasComanda.Text)
            ' Si el tipo ComandaBar no existe en Impresoras.dll, GuardaImpresora lo agrega
            GuardaImpresora("ComandaBar", Me.CmbImpresorasComandaBar.Text)

            MsgBox("Se ha Guardado con Exito!!!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("No se pudo guardar la configuracion de impresoras." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Impresoras")
        End Try
    End Sub
End Class
