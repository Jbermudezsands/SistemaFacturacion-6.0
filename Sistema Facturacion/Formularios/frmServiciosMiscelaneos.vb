' =====================================================================
' frmServiciosMiscelaneos.vb
' Formulario "Mantenimiento de Servicios y Misceláneos" - Diseño moderno
' .NET Framework 4.0 - Controles estándar de Windows Forms
' =====================================================================

Public Class frmServiciosMiscelaneos

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmServiciosMiscelaneos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO: Cargar cboCodigoServicio, cboRubro y demás combos desde la base de datos
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ' TODO: Limpiar controles para capturar un nuevo servicio
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' TODO: Validar campos y guardar el servicio/misceláneo
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' TODO: Eliminar el servicio seleccionado (con confirmación)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarServicio_Click(sender As Object, e As EventArgs) Handles btnBuscarServicio.Click
        ' TODO: Abrir formulario de búsqueda de servicios
    End Sub

    Private Sub btnBuscarCuentaCosto_Click(sender As Object, e As EventArgs) Handles btnBuscarCuentaCosto.Click
        ' TODO: Abrir formulario de búsqueda de cuentas contables (costo)
    End Sub

    Private Sub btnBuscarCuentaVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarCuentaVenta.Click
        ' TODO: Abrir formulario de búsqueda de cuentas contables (venta)
    End Sub

End Class
