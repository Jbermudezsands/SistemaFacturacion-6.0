Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Text

''' <summary>Una fecha/producto donde el motor y CostoPromedioKardex no coinciden.</summary>
Public Class DiferenciaCosto
    Public Property CodigoProducto As String
    Public Property Fecha As Date
    Public Property OriginalCordoba As Double
    Public Property MotorCordoba As Double
    Public Property OriginalDolar As Double
    Public Property MotorDolar As Double
    Public Property OrigenMotor As OrigenCostoCalculado
    Public Property Nota As String
End Class

Public Class ResumenComparacion
    Public Property Productos As Integer
    Public Property FechasComparadas As Integer
    Public Property Diferencias As New List(Of DiferenciaCosto)
    Public Property Errores As New List(Of String)
    Public Property Advertencias As New List(Of String)
    Public Property MsOriginal As Long
    Public Property MsMotor As Long
    Public Property Cancelado As Boolean
End Class

''' <summary>
''' Herramienta de validacion (Fase 5): ejecuta la funcion ORIGINAL CostoPromedioKardex y el
''' CalculadorCostoPromedio del motor sobre los mismos productos/fechas y reporta diferencias.
''' No modifica datos. La funcion original NO se toca.
''' </summary>
Public Class ComparadorCostos

    Public Event Progreso(ByVal actual As Integer, ByVal total As Integer, ByVal mensaje As String)

    ''' <summary>Poner en True para detener la comparacion de forma segura.</summary>
    Public Property Cancelar As Boolean

    Private ReadOnly _repositorio As RepositorioMovimientos
    Private ReadOnly _calculador As New CalculadorCostoPromedio

    Public Sub New(ByVal cadenaConexion As String)
        _repositorio = New RepositorioMovimientos(cadenaConexion)
    End Sub

    ''' <param name="codigos">Productos a comparar.</param>
    ''' <param name="maxFechasPorProducto">0 = todas las fechas con movimiento; N = muestra de N fechas repartidas (siempre incluye primera, ultima y hoy).</param>
    ''' <param name="tolerancia">Diferencia absoluta aceptada (C$ y US$).</param>
    Public Function Comparar(ByVal codigos As List(Of String), ByVal maxFechasPorProducto As Integer,
                             ByVal tolerancia As Double) As ResumenComparacion
        Dim resumen As New ResumenComparacion
        resumen.Productos = codigos.Count
        Cancelar = False

        Dim cronoOriginal As New Stopwatch
        Dim cronoMotor As New Stopwatch

        For i As Integer = 0 To codigos.Count - 1
            If Cancelar Then
                resumen.Cancelado = True
                Exit For
            End If

            Dim codigo As String = codigos(i)
            RaiseEvent Progreso(i + 1, codigos.Count, codigo)

            Try
                ' ---------- Motor: una carga y un recorrido ----------
                cronoMotor.Start()
                Dim movs As List(Of MovimientoCosto) = _repositorio.CargarMovimientos(codigo, Nothing)
                Dim cands As List(Of UltimoCostoCandidato) = _repositorio.CargarCandidatosUltimoCosto(codigo, Nothing)
                Dim fechas As List(Of Date) = SeleccionarFechas(movs, cands, maxFechasPorProducto)
                Dim motor As Dictionary(Of Date, ResultadoCosteo) = _calculador.CostosPorFechas(codigo, fechas, movs, cands)
                cronoMotor.Stop()

                ' ---------- Original: una llamada por fecha ----------
                For Each f As Date In fechas
                    If Cancelar Then
                        resumen.Cancelado = True
                        Exit For
                    End If

                    Dim original As RstCostoPromedio
                    cronoOriginal.Start()
                    Try
                        original = CostoPromedioKardexOriginal(codigo, f)
                    Finally
                        cronoOriginal.Stop()
                    End Try

                    Dim m As ResultadoCosteo = motor(f.Date)
                    resumen.FechasComparadas += 1

                    Dim dC As Double = Math.Abs(original.Costo_Cordoba - m.CostoCordoba)
                    Dim dD As Double = Math.Abs(original.Costo_Dolar - m.CostoDolar)
                    If dC > tolerancia OrElse dD > tolerancia Then
                        Dim d As New DiferenciaCosto
                        d.CodigoProducto = codigo
                        d.Fecha = f
                        d.OriginalCordoba = original.Costo_Cordoba
                        d.MotorCordoba = m.CostoCordoba
                        d.OriginalDolar = original.Costo_Dolar
                        d.MotorDolar = m.CostoDolar
                        d.OrigenMotor = m.Origen
                        d.Nota = String.Join(" | ", m.Advertencias.ToArray())
                        resumen.Diferencias.Add(d)
                    ElseIf m.Advertencias.Count > 0 Then
                        resumen.Advertencias.Add(codigo & " " & f.ToString("yyyy-MM-dd") & ": " & String.Join(" | ", m.Advertencias.ToArray()))
                    End If
                Next
            Catch ex As Exception
                If cronoMotor.IsRunning Then cronoMotor.Stop()
                resumen.Errores.Add(codigo & ": " & ex.Message)
            End Try
        Next

        resumen.MsOriginal = cronoOriginal.ElapsedMilliseconds
        resumen.MsMotor = cronoMotor.ElapsedMilliseconds
        Return resumen
    End Function

    ''' <summary>Guarda las diferencias, errores y advertencias en un CSV (separador coma, punto decimal).</summary>
    Public Shared Sub ExportarCsv(ByVal resumen As ResumenComparacion, ByVal ruta As String)
        Dim inv As CultureInfo = CultureInfo.InvariantCulture
        Dim sb As New StringBuilder
        sb.AppendLine("Tipo,Producto,Fecha,Original_C$,Motor_C$,Original_US$,Motor_US$,OrigenMotor,Nota")
        For Each d As DiferenciaCosto In resumen.Diferencias
            sb.AppendLine("DIFERENCIA," & Csv(d.CodigoProducto) & "," & d.Fecha.ToString("yyyy-MM-dd", inv) & "," &
                          d.OriginalCordoba.ToString("0.000000000", inv) & "," & d.MotorCordoba.ToString("0.000000000", inv) & "," &
                          d.OriginalDolar.ToString("0.000000000", inv) & "," & d.MotorDolar.ToString("0.000000000", inv) & "," &
                          d.OrigenMotor.ToString() & "," & Csv(d.Nota))
        Next
        For Each e As String In resumen.Errores
            sb.AppendLine("ERROR,,,,,,,," & Csv(e))
        Next
        For Each a As String In resumen.Advertencias
            sb.AppendLine("ADVERTENCIA,,,,,,,," & Csv(a))
        Next
        File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8)
    End Sub

    Private Shared Function Csv(ByVal texto As String) As String
        If texto Is Nothing Then Return ""
        Return """" & texto.Replace("""", """""") & """"
    End Function

    ''' <summary>Fechas con movimiento del producto (mas hoy), reducidas a una muestra repartida si se pide.</summary>
    Private Shared Function SeleccionarFechas(ByVal movs As List(Of MovimientoCosto), ByVal cands As List(Of UltimoCostoCandidato),
                                              ByVal maximo As Integer) As List(Of Date)
        Dim set1 As New HashSet(Of Date)
        For Each m As MovimientoCosto In movs
            set1.Add(m.Fecha.Date)
        Next
        For Each c As UltimoCostoCandidato In cands
            set1.Add(c.Fecha.Date)
        Next
        set1.Add(Date.Today)

        Dim todas As New List(Of Date)(set1)
        todas.Sort()
        If maximo <= 0 OrElse todas.Count <= maximo Then Return todas

        Dim muestra As New List(Of Date)
        Dim usados As New HashSet(Of Integer)
        If maximo = 1 Then
            muestra.Add(todas(todas.Count - 1))
            Return muestra
        End If
        For k As Integer = 0 To maximo - 1
            Dim idx As Integer = CInt(Math.Round(k * (todas.Count - 1) / (maximo - 1)))
            If usados.Add(idx) Then muestra.Add(todas(idx))
        Next
        Return muestra
    End Function

End Class
