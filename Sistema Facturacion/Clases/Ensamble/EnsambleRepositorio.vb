Option Strict On
Option Explicit On
Option Infer On

Imports System.Data
Imports System.Data.SqlClient

'=====================================================================================================
'  ENSAMBLE - REPOSITORIO
'  Todo el acceso a SQL Server del formulario de ensambles (consultas parametrizadas).
'=====================================================================================================
Public Class EnsambleRepositorio

    Private Const SQL_DETALLE As String = _
        "SELECT D.Cod_ReciboEnsamble, D.Fecha_Ensamble, D.Tipo_Ensamble, D.CodProducto, P.Descripcion_Producto, " & _
        "       D.Cantidad_Ensamble, D.Valor_Ensamble, D.Desecho, D.Valor_Desecho " & _
        "FROM Detalle_Ensamble D INNER JOIN Productos P ON D.CodProducto = P.Cod_Productos " & _
        "WHERE D.Cod_ReciboEnsamble = @numero AND D.Fecha_Ensamble = @fecha AND D.Tipo_Ensamble = @tipo"

    Private ReadOnly _conexion As String

    Public Sub New(ByVal conexion As String)
        _conexion = conexion
    End Sub

#Region "Consultas"

    Public Function ObtenerBodegas() As DataTable
        Return LeerTabla("SELECT * FROM Bodegas")
    End Function

    ''' <summary>Producto por código; Nothing si no existe.</summary>
    Public Function ObtenerProducto(ByVal codigo As String) As DataRow
        Dim tabla As DataTable = LeerTabla("SELECT * FROM Productos WHERE Cod_Productos = @codigo", _
                                           Texto("@codigo", codigo))
        If tabla.Rows.Count = 0 Then Return Nothing
        Return tabla.Rows(0)
    End Function

    ''' <summary>Componentes de la receta, por unidad de producto.</summary>
    Public Function ObtenerComponentes(ByVal codComponente As Double) As DataTable
        Return LeerTabla("SELECT * FROM Componentes WHERE Cod_Componente = @componente", _
                         Decimal_("@componente", codComponente))
    End Function

    ''' <summary>Componentes de la receta con Requerido y Desecho multiplicados por la cantidad a ensamblar.</summary>
    Public Function ObtenerComponentes(ByVal codComponente As Double, ByVal cantidad As Double) As DataTable
        Return LeerTabla("SELECT Cod_Componente, Cod_Producto, Descripcion_Producto, Requerido * @cantidad AS Requerido, " & _
                         "       Recuperable, Desecho * @cantidad AS Desecho " & _
                         "FROM Componentes WHERE Cod_Componente = @componente", _
                         Decimal_("@componente", codComponente), Decimal_("@cantidad", cantidad))
    End Function

    Public Function ObtenerDetalle(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String) As DataTable
        Return LeerTabla(SQL_DETALLE, Decimal_("@numero", numero), Fecha_("@fecha", fecha), Texto("@tipo", tipo))
    End Function

    Public Function ObtenerDatosEmpresa() As DataTable
        Return LeerTabla("SELECT * FROM DatosEmpresa")
    End Function

    ''' <summary>Primera fila de Clientes marcada como cuenta de inventario físico (Nothing si no hay).</summary>
    Public Function ObtenerClienteInventario() As DataRow
        Dim tabla As DataTable = LeerTabla("SELECT * FROM Clientes WHERE InventarioFisico = 1")
        If tabla.Rows.Count = 0 Then Return Nothing
        Return tabla.Rows(0)
    End Function

    ''' <summary>Primera fila de Proveedor marcada como cuenta de inventario físico (Nothing si no hay).</summary>
    Public Function ObtenerProveedorInventario() As DataRow
        Dim tabla As DataTable = LeerTabla("SELECT * FROM Proveedor WHERE InventarioFisico = 1")
        If tabla.Rows.Count = 0 Then Return Nothing
        Return tabla.Rows(0)
    End Function

    ''' <summary>Costo unitario de la última salida facturada hasta la fecha (para productos sin costo promedio).</summary>
    Public Function UltimoCostoFactura(ByVal codProducto As String, ByVal fecha As Date) As Double?
        Dim tabla As DataTable = LeerTabla( _
            "SELECT TOP 1 DF.Costo_Unitario " & _
            "FROM Detalle_Facturas DF INNER JOIN TasaCambio T ON DF.Fecha_Factura = T.FechaTasa " & _
            "WHERE DF.Cod_Producto = @producto AND DF.Costo_Unitario <> 0 AND DF.Fecha_Factura <= @fecha " & _
            "ORDER BY DF.Fecha_Factura DESC", _
            Texto("@producto", codProducto), Fecha_("@fecha", fecha))
        If tabla.Rows.Count = 0 OrElse IsDBNull(tabla.Rows(0)(0)) Then Return Nothing
        Return Convert.ToDouble(tabla.Rows(0)(0))
    End Function

    ''' <summary>Importe (cantidad x costo) de la salida de bodega generada por el ensamble.</summary>
    Public Function TotalSalidaBodega(ByVal numeroFactura As String, ByVal fecha As Date) As Double
        Return Escalar("SELECT SUM(Cantidad * Costo_Unitario) FROM Detalle_Facturas " & _
                       "WHERE Tipo_Factura = 'Salida Bodega' AND Numero_Factura = @numero AND Fecha_Factura = @fecha", _
                       Texto("@numero", numeroFactura), Fecha_("@fecha", fecha))
    End Function

    ''' <summary>Importe (cantidad x precio) de la compra generada por el desensamble.</summary>
    Public Function TotalCompra(ByVal numeroCompra As String, ByVal fecha As Date) As Double
        Return Escalar("SELECT SUM(Cantidad * Precio_Unitario) FROM Detalle_Compras " & _
                       "WHERE Numero_Compra = @numero AND Fecha_Compra = @fecha AND Tipo_Compra = 'Mercancia Recibida'", _
                       Texto("@numero", numeroCompra), Fecha_("@fecha", fecha))
    End Function

#End Region

#Region "Escritura"

    ''' <summary>
    ''' Inserta o actualiza el encabezado y deja el detalle del ensamble igual a la receta
    ''' escalada por la cantidad, todo en una sola transacción.
    ''' </summary>
    Public Sub Guardar(ByVal enc As EnsambleEncabezado)
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction()
                GuardarEncabezado(cn, tx, enc)
                GuardarDetalle(cn, tx, enc)
                tx.Commit()
            End Using
        End Using
    End Sub

    Private Sub GuardarEncabezado(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal enc As EnsambleEncabezado)
        Dim actualizadas As Integer
        Using cmd As New SqlCommand( _
            "UPDATE Ensamble SET SubTotalEnsamble = 0, Cantidad_Principal = @cantidad, Cod_Componente = @componente, " & _
            "       CodBodega = @origen, CodBodegaDestino = @destino, Rendimiento = @rendimiento " & _
            "WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo", cn, tx)
            AgregarEncabezado(cmd, enc)
            actualizadas = cmd.ExecuteNonQuery()
        End Using

        If actualizadas > 0 Then Return

        Using cmd As New SqlCommand( _
            "INSERT INTO Ensamble (Cod_ReciboEnsamble, Fecha_Ensamble, SubTotalEnsamble, Cod_ProductoEnsamble, Cantidad_Principal, " & _
            "                      Tipo_Ensamble, Cod_Contratista, Cod_Componente, Referencias, CodBodega, Rendimiento, CodBodegaDestino) " & _
            "VALUES (@numero, @fecha, 0, @producto, @cantidad, @tipo, '0', @componente, @referencias, @origen, @rendimiento, @destino)", cn, tx)
            AgregarEncabezado(cmd, enc)
            cmd.Parameters.Add(Texto("@producto", enc.CodProducto))
            cmd.Parameters.Add(Texto("@referencias", enc.Referencias))
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub AgregarEncabezado(ByVal cmd As SqlCommand, ByVal enc As EnsambleEncabezado)
        cmd.Parameters.Add(Decimal_("@numero", enc.Numero))
        cmd.Parameters.Add(Fecha_("@fecha", enc.Fecha))
        cmd.Parameters.Add(Texto("@tipo", enc.Tipo))
        cmd.Parameters.Add(Decimal_("@cantidad", enc.Cantidad))
        cmd.Parameters.Add(Decimal_("@componente", enc.CodComponente))
        cmd.Parameters.Add(Texto("@origen", enc.BodegaOrigen))
        cmd.Parameters.Add(Texto("@destino", enc.BodegaDestino))
        cmd.Parameters.Add(Decimal_("@rendimiento", enc.Rendimiento))
    End Sub

    Private Sub GuardarDetalle(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal enc As EnsambleEncabezado)
        Dim componentes As New DataTable
        Using cmd As New SqlCommand( _
            "SELECT Cod_Producto, Requerido * @cantidad AS Requerido, Desecho * @cantidad AS Desecho " & _
            "FROM Componentes WHERE Cod_Componente = @componente", cn, tx)
            cmd.Parameters.Add(Decimal_("@cantidad", enc.Cantidad))
            cmd.Parameters.Add(Decimal_("@componente", enc.CodComponente))
            Using da As New SqlDataAdapter(cmd)
                da.Fill(componentes)
            End Using
        End Using

        For Each fila As DataRow In componentes.Rows
            Dim requerido As Double = If(IsDBNull(fila("Requerido")), 0.0, Convert.ToDouble(fila("Requerido")))
            Dim desecho As Double = If(IsDBNull(fila("Desecho")), 0.0, Convert.ToDouble(fila("Desecho")))
            Dim codProducto As String = Convert.ToString(fila("Cod_Producto"))

            Dim actualizadas As Integer
            Using cmd As New SqlCommand( _
                "UPDATE Detalle_Ensamble SET Cantidad_Ensamble = @requerido, Valor_Ensamble = 0, Desecho = @desecho, Valor_Desecho = 0 " & _
                "WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo AND CodProducto = @producto", cn, tx)
                AgregarClaveDetalle(cmd, enc, codProducto, requerido, desecho)
                actualizadas = cmd.ExecuteNonQuery()
            End Using

            If actualizadas = 0 Then
                Using cmd As New SqlCommand( _
                    "INSERT INTO Detalle_Ensamble (Cod_ReciboEnsamble, Fecha_Ensamble, Tipo_Ensamble, CodProducto, Cantidad_Ensamble, Valor_Ensamble, Desecho, Valor_Desecho) " & _
                    "VALUES (@numero, @fecha, @tipo, @producto, @requerido, 0, @desecho, 0)", cn, tx)
                    AgregarClaveDetalle(cmd, enc, codProducto, requerido, desecho)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Next
    End Sub

    Private Shared Sub AgregarClaveDetalle(ByVal cmd As SqlCommand, ByVal enc As EnsambleEncabezado, _
                                           ByVal codProducto As String, ByVal requerido As Double, ByVal desecho As Double)
        cmd.Parameters.Add(Decimal_("@numero", enc.Numero))
        cmd.Parameters.Add(Fecha_("@fecha", enc.Fecha))
        cmd.Parameters.Add(Texto("@tipo", enc.Tipo))
        cmd.Parameters.Add(Texto("@producto", codProducto))
        cmd.Parameters.Add(Decimal_("@requerido", requerido))
        cmd.Parameters.Add(Decimal_("@desecho", desecho))
    End Sub

    ''' <summary>Borra detalle y encabezado. Devuelve False si el ensamble no existía.</summary>
    Public Function Eliminar(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String) As Boolean
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction()
                Dim existe As Boolean
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM Ensamble WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo", cn, tx)
                    AgregarClaveEncabezado(cmd, numero, fecha, tipo)
                    existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using

                If existe Then
                    Using cmd As New SqlCommand("DELETE FROM Detalle_Ensamble WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo", cn, tx)
                        AgregarClaveEncabezado(cmd, numero, fecha, tipo)
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As New SqlCommand("DELETE FROM Ensamble WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo", cn, tx)
                        AgregarClaveEncabezado(cmd, numero, fecha, tipo)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                tx.Commit()
                Return existe
            End Using
        End Using
    End Function

    ''' <summary>Marca el ensamble como inactivo (ya procesado).</summary>
    Public Sub Inactivar(ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String)
        Ejecutar("UPDATE Ensamble SET Activo = 0 WHERE Cod_ReciboEnsamble = @numero AND Fecha_Ensamble = @fecha AND Tipo_Ensamble = @tipo", _
                 Decimal_("@numero", numero), Fecha_("@fecha", fecha), Texto("@tipo", tipo))
    End Sub

    ''' <summary>Deja inactiva la salida de bodega recién creada hasta que se complete el proceso.</summary>
    Public Sub DesactivarSalidaBodega(ByVal numeroFactura As String, ByVal fecha As Date)
        Ejecutar("UPDATE Facturas SET Activo = 'False' " & _
                 "WHERE Numero_Factura = @numero AND Fecha_Factura = @fecha AND Tipo_Factura = 'Salida Bodega'", _
                 Texto("@numero", numeroFactura), Fecha_("@fecha", fecha))
    End Sub

    ''' <summary>Deja inactiva la compra recién creada hasta que se complete el proceso.</summary>
    Public Sub DesactivarCompra(ByVal numeroCompra As String, ByVal fecha As Date)
        Ejecutar("UPDATE Compras SET Activo = 'False' " & _
                 "WHERE Numero_Compra = @numero AND Fecha_Compra = @fecha AND Tipo_Compra = 'Mercancia Recibida'", _
                 Texto("@numero", numeroCompra), Fecha_("@fecha", fecha))
    End Sub

    Private Shared Sub AgregarClaveEncabezado(ByVal cmd As SqlCommand, ByVal numero As Double, ByVal fecha As Date, ByVal tipo As String)
        cmd.Parameters.Add(Decimal_("@numero", numero))
        cmd.Parameters.Add(Fecha_("@fecha", fecha))
        cmd.Parameters.Add(Texto("@tipo", tipo))
    End Sub

#End Region

#Region "Utilidades"

    Private Function LeerTabla(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddRange(parametros)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    Private Function Escalar(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter) As Double
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddRange(parametros)
                cn.Open()
                Dim valor As Object = cmd.ExecuteScalar()
                If valor Is Nothing OrElse IsDBNull(valor) Then Return 0
                Return Convert.ToDouble(valor)
            End Using
        End Using
    End Function

    Private Sub Ejecutar(ByVal sql As String, ByVal ParamArray parametros() As SqlParameter)
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddRange(parametros)
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Function Texto(ByVal nombre As String, ByVal valor As String) As SqlParameter
        Dim p As New SqlParameter(nombre, SqlDbType.NVarChar)
        p.Value = If(valor, "")
        Return p
    End Function

    'Las columnas numéricas de ensamble son float en la base de datos
    Private Shared Function Decimal_(ByVal nombre As String, ByVal valor As Double) As SqlParameter
        Dim p As New SqlParameter(nombre, SqlDbType.Float)
        p.Value = valor
        Return p
    End Function

    'Fecha_Ensamble es smalldatetime: se guarda siempre sin hora
    Private Shared Function Fecha_(ByVal nombre As String, ByVal valor As Date) As SqlParameter
        Dim p As New SqlParameter(nombre, SqlDbType.DateTime)
        p.Value = valor.Date
        Return p
    End Function

#End Region

End Class
