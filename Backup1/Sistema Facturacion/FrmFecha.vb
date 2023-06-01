Public Class FrmFecha
    Public FechaCompra As Date

    Private Sub FrmFecha_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FechaCompra = Me.DTPFechaRequerido.Value
    End Sub
    Private Sub FrmFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPFechaRequerido.Value = Now
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Aceptar"
        FechaCompra = Me.DTPFechaRequerido.Value
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FechaCompra = Me.DTPFechaRequerido.Value
        Quien = "Cancelar"
        Me.Close()
    End Sub
End Class