Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data

''' <summary>Reglas de negocio y validaciones del arqueo de caja. Los formularios solo hablan con esta clase.</summary>
Public Class ArqueoServicio

    Private ReadOnly _repositorio As ArqueoRepositorio

    Public Sub New(ByVal conexion As String)
        _repositorio = New ArqueoRepositorio(conexion)
    End Sub

    Public Function ObtenerCajeros() As DataTable
        Return _repositorio.ObtenerCajeros()
    End Function

    Public Function ObtenerEmpresa() As ArqueoEmpresa
        Return _repositorio.ObtenerEmpresa()
    End Function

    '=================================================================================================
    ' INICIO Y APERTURA
    '=================================================================================================

    ''' <summary>
    ''' Inicia un arqueo: toma los cheques/tarjetas pendientes del cajero, crea las denominaciones en cero
    ''' y marca los pagos incluidos como arqueados, todo en una transacción.
    ''' </summary>
    Public Function IniciarArqueo(ByVal codCajero As String, ByVal fecha As Date, ByVal fondoApertura As Decimal) As ArqueoCabecera
        If String.IsNullOrWhiteSpace(codCajero) Then
            Throw New ArgumentException("Debe seleccionar un cajero.")
        End If

        If fecha.Date > Date.Today Then
            Throw New ArgumentException("La fecha del arqueo no puede ser posterior a hoy.")
        End If

        If fondoApertura < 0D Then
            Throw New ArgumentException("El fondo de apertura no puede ser negativo.")
        End If

        Dim pagos As List(Of ArqueoPagoDiferido) = _repositorio.ObtenerPagosDiferidosPendientes(codCajero, fecha)
        Dim esperado As ArqueoEfectivoEsperado = ObtenerEfectivoEsperado(codCajero, fecha)

        Dim hayDolares As Boolean = esperado.EfectivoDolares <> 0D
        For Each pago As ArqueoPagoDiferido In pagos
            If pago.Moneda = ArqueoMoneda.Dolares Then hayDolares = True
        Next

        If hayDolares AndAlso esperado.TasaCambio <= 0D Then
            Throw New InvalidOperationException("No existe tasa de cambio para el " & fecha.ToString("dd/MM/yyyy") &
                                                ". Regístrela antes de iniciar el arqueo.")
        End If

        Dim cab As New ArqueoCabecera()
        cab.Codigo = Format(BuscaConsecutivo("Arqueo"), "0000#")
        cab.Fecha = fecha.Date
        cab.CodCajero = codCajero
        cab.FondoApertura = ArqueoCalculadora.Redondear(fondoApertura)

        ' Los montos del efectivo esperado se calculan y se marcan como arqueados dentro de la transacción de creación
        cab.EfectivoEsperado = New ArqueoEfectivoEsperado() With {.TasaCambio = esperado.TasaCambio}

        _repositorio.CrearArqueo(cab, CrearDenominacionesEnCero(), pagos)

        Return cab
    End Function

    Public Function AbrirArqueo(ByVal codigo As String) As ArqueoCabecera
        If String.IsNullOrWhiteSpace(codigo) Then
            Throw New ArgumentException("Debe indicar el número de arqueo.")
        End If

        Dim cab As ArqueoCabecera = _repositorio.ObtenerCabecera(codigo.Trim())
        If cab Is Nothing Then
            Throw New InvalidOperationException("No se encontró el arqueo " & codigo & ".")
        End If

        Return cab
    End Function

    Public Function ObtenerDetalleEfectivo(ByVal cab As ArqueoCabecera, ByVal moneda As String) As DataTable
        Return _repositorio.ObtenerDetalleEfectivo(cab, moneda)
    End Function

    Public Function ObtenerDetalleCheques(ByVal cab As ArqueoCabecera, ByVal moneda As String) As DataTable
        Return _repositorio.ObtenerDetalleCheques(cab, moneda)
    End Function

    ''' <summary>Efectivo esperado de un arqueo: el capturado al iniciarlo; si es anterior a esa captura, se calcula en vivo.</summary>
    Public Function ObtenerEfectivoEsperado(ByVal cab As ArqueoCabecera) As ArqueoEfectivoEsperado
        If cab.EfectivoEsperado IsNot Nothing Then Return cab.EfectivoEsperado
        Return ObtenerEfectivoEsperado(cab.CodCajero, cab.Fecha)
    End Function

    ''' <summary>Efectivo de facturas y recibos que el cajero debió recaudar, y la tasa de cambio de la fecha.</summary>
    Public Function ObtenerEfectivoEsperado(ByVal codCajero As String, ByVal fecha As Date) As ArqueoEfectivoEsperado
        Dim esperado As New ArqueoEfectivoEsperado()

        esperado.EfectivoCordobas = _repositorio.SumarEfectivoFacturas(codCajero, fecha, ArqueoMoneda.Cordobas) +
                                    _repositorio.SumarEfectivoRecibos(codCajero, fecha, ArqueoMoneda.Cordobas)

        esperado.EfectivoDolares = _repositorio.SumarEfectivoFacturas(codCajero, fecha, ArqueoMoneda.Dolares) +
                                   _repositorio.SumarEfectivoRecibos(codCajero, fecha, ArqueoMoneda.Dolares)

        esperado.TasaCambio = _repositorio.ObtenerTasaCambio(fecha)

        Return esperado
    End Function

    '=================================================================================================
    ' CÁLCULO Y GRABACIÓN
    '=================================================================================================

    Public Function Calcular(ByVal cab As ArqueoCabecera,
                             ByVal esperado As ArqueoEfectivoEsperado,
                             ByVal efectivoCordobas As DataTable,
                             ByVal efectivoDolares As DataTable,
                             ByVal chequesCordobas As DataTable,
                             ByVal chequesDolares As DataTable) As ArqueoResumen

        Dim entrada As New ArqueoEntradaCalculo()
        entrada.FondoApertura = cab.FondoApertura
        entrada.TasaCambio = esperado.TasaCambio
        entrada.EfectivoEsperadoCordobas = esperado.EfectivoCordobas
        entrada.EfectivoEsperadoDolares = esperado.EfectivoDolares
        entrada.ChequesCordobas = SumarColumna(chequesCordobas, "Monto")
        entrada.ChequesDolares = SumarColumna(chequesDolares, "Monto")
        entrada.DenominacionesCordobas.AddRange(LeerDenominaciones(efectivoCordobas, ArqueoMoneda.Cordobas))
        entrada.DenominacionesDolares.AddRange(LeerDenominaciones(efectivoDolares, ArqueoMoneda.Dolares))

        Return ArqueoCalculadora.Calcular(entrada)
    End Function

    ''' <summary>Graba el conteo y los totales. El monto de cada renglón se recalcula; no se toma del grid.</summary>
    Public Sub Guardar(ByVal cab As ArqueoCabecera,
                       ByVal esperado As ArqueoEfectivoEsperado,
                       ByVal efectivoCordobas As DataTable,
                       ByVal efectivoDolares As DataTable,
                       ByVal chequesCordobas As DataTable,
                       ByVal chequesDolares As DataTable,
                       ByVal observaciones As String,
                       ByVal practicadoPor As String)

        If Not cab.EsEditable Then
            Throw New InvalidOperationException("El arqueo " & cab.Codigo & " ya fue grabado y no se puede modificar.")
        End If

        If String.IsNullOrWhiteSpace(practicadoPor) Then
            Throw New ArgumentException("Indique quién practica el arqueo (campo 'Arqueado por').")
        End If

        Dim resumen As ArqueoResumen = Calcular(cab, esperado, efectivoCordobas, efectivoDolares, chequesCordobas, chequesDolares)
        If resumen.FaltaTasaCambio Then
            Throw New InvalidOperationException("No existe tasa de cambio para el " & cab.Fecha.ToString("dd/MM/yyyy") &
                                                ". Regístrela para poder grabar el arqueo.")
        End If

        Dim denominaciones As New List(Of ArqueoDenominacion)()
        denominaciones.AddRange(LeerDenominaciones(efectivoCordobas, ArqueoMoneda.Cordobas))
        denominaciones.AddRange(LeerDenominaciones(efectivoDolares, ArqueoMoneda.Dolares))

        cab.Observaciones = If(observaciones, "").Trim()
        cab.PracticadoPor = practicadoPor.Trim()
        cab.TotalCordobasDolares = resumen.TotalContado
        cab.ValorFacturas = resumen.TotalEsperado

        _repositorio.GuardarArqueo(cab, denominaciones)
    End Sub

    '=================================================================================================
    ' PRIVADOS
    '=================================================================================================

    Private Function CrearDenominacionesEnCero() As List(Of ArqueoDenominacion)
        Dim lista As New List(Of ArqueoDenominacion)()
        Dim tabla As DataTable = _repositorio.ObtenerDenominaciones()

        For Each moneda As String In New String() {ArqueoMoneda.Cordobas, ArqueoMoneda.Dolares}
            For Each fila As DataRow In tabla.Rows
                Dim den As New ArqueoDenominacion()
                den.Moneda = moneda
                den.IdDenominacion = Convert.ToInt32(fila("idDenominacion"))
                den.Valor = Convert.ToDecimal(fila("Valor"))
                den.Cantidad = 0D
                lista.Add(den)
            Next
        Next

        Return lista
    End Function

    Private Shared Function LeerDenominaciones(ByVal tabla As DataTable, ByVal moneda As String) As List(Of ArqueoDenominacion)
        Dim lista As New List(Of ArqueoDenominacion)()
        If tabla Is Nothing Then Return lista

        For Each fila As DataRow In tabla.Rows
            If fila.RowState = DataRowState.Deleted Then Continue For

            Dim den As New ArqueoDenominacion()
            den.Moneda = moneda
            den.IdDenominacion = Convert.ToInt32(fila("idDenominacion"))
            den.Valor = ComoDecimal(fila("Valor"))
            den.Cantidad = ComoDecimal(fila("Canitdad"))

            If den.Cantidad < 0D Then
                Throw New ArgumentException("La cantidad de la denominación " & den.Valor.ToString("N2") &
                                            " (" & moneda & ") no puede ser negativa.")
            End If

            lista.Add(den)
        Next

        Return lista
    End Function

    Private Shared Function SumarColumna(ByVal tabla As DataTable, ByVal columna As String) As Decimal
        Dim total As Decimal = 0D
        If tabla Is Nothing Then Return total

        For Each fila As DataRow In tabla.Rows
            If fila.RowState <> DataRowState.Deleted Then total += ComoDecimal(fila(columna))
        Next

        Return total
    End Function

    Private Shared Function ComoDecimal(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D

        Dim texto As String = TryCast(valor, String)
        If texto IsNot Nothing Then
            Dim resultado As Decimal
            If Decimal.TryParse(texto, Globalization.NumberStyles.Number, Globalization.CultureInfo.CurrentCulture, resultado) Then
                Return resultado
            End If
            Return 0D
        End If

        Return Convert.ToDecimal(valor)
    End Function

End Class
