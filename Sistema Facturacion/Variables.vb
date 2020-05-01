Module Variables
    Public Conexion As String, Quien As String, ConexionContabilidad As String, ImporteCompra As Double = 0, ImporteVenta As Double = 0, MontoInicial As Double = 0
    Public Acceso As String = "Administrador", GIdDetalle As Double, MontoEntrada As Double, MontoSalida As Double, ImporteDevFactura As Double = 0
    Public UsuarioBodega As String = "Ninguna", UsuarioTipoSerie As String = "Ninguna", UsuarioTipoFactura As String = "Ninguna", UsuarioVendedor As String = "Ninguna", UsuarioCliente As String = "Ninguna"
    Public ExistenciaBodega As Double = 0, MontoInicialD As Double = 0, MontoEntradaD As Double = 0, MontoSalidaD As Double = 0
    Public NombreUsuario As String = "Desconocido"
    Public NombreCliente As String = "Clientes"
    Public NombreCompañia As String, Columna As Double, IncrementoTarjeta As Double = 0, DiasMaxMora As Double = 0
    Public CostoPromedioDolar As Double, TotalUnidades As Double, StringMoneda As String
    Public ExisteConexion As Boolean, CantidadCompra As Double = 0, CantidadSalida As Double = 0
    Public TotalMontoFacturas As Double = 0, TotalCosto As Double, TotalMontoCompras As Double = 0, CambiarFechaFactura As Boolean = False, CambiaFechaRecibo As Boolean = False, CambiarFechaCompra As Boolean = False
    Public CodigoClienteNumero As Boolean = False, FechaIngreso As Date, CostoUnitarioB As Double = 0, FSubTotal As Double = 0, FIva As Double = 0
    Public CadenaRecibo As String, PrimerRegistroFactura As Boolean, PrimerRegistroCompra As Boolean
    Public EditarFactura As Boolean = True, CodigoProducto() As String, Mensaje As String
    Public CambioFechaRespuesta As Boolean = False, FechaFacturacion As Date, RefNotaDebito As String
    Public iAño As Integer, FechaGuardar As Date, UsuarioBodegaCompra As String, UsuarioTipoCompra As String, UsuarioProveedor As String
    Public DatasetDetalle As New DataSet
End Module
