Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Windows.Forms

'=====================================================================================================
'  COMUNICACIÓN CON BÁSCULAS (puerto serial) - clases reutilizables
'
'  Uso en cualquier formulario:
'
'     Private WithEvents Bascula As BasculaConexion
'     ...
'     Bascula = New BasculaConexion("Recepcion", Me)      ' "Me" = formulario que recibe los eventos
'     Bascula.ConectarGuardado()                           ' abre el último puerto configurado
'     ...
'     Private Sub Bascula_PesoRecibido(ByVal peso As Double, ByVal linea As String) Handles Bascula.PesoRecibido
'     Private Sub Bascula_EstadoCambiado(ByVal estado As EstadoBascula, ByVal mensaje As String) Handles Bascula.EstadoCambiado
'
'  La configuración (puerto, velocidad, paridad...) se guarda por clave en
'  %AppData%\ZeusFacturacion\Bascula_<clave>.cfg, y se edita en FrmPuertos.
'
'  Qué corrige respecto a la versión anterior (FrmRecepcion/FrmBascula usaban SerialPort directo):
'   - Se lee con un búfer propio y se separa por CR o LF: la báscula que termina en CR (sin LF) ya no
'     deja colgado ReadLine, y las tramas partidas se reconstruyen.
'   - Ningún error del hilo de lectura llega sin controlar al usuario (antes cerraba el programa).
'   - Los eventos se entregan en el hilo de pantalla y se ignoran si el formulario ya se cerró.
'   - Velocidad, bits, paridad y control de flujo son configurables; el puerto se guarda y se
'     reconecta solo si el cable se desconecta un momento.
'=====================================================================================================

Public Enum EstadoBascula
    Desconectado = 0
    Conectado = 1
    Reconectando = 2
    [Error] = 3
End Enum

'-----------------------------------------------------------------------------------------------------
' Configuración del puerto
'-----------------------------------------------------------------------------------------------------
Public Class BasculaConfig
    Public Property Puerto As String = ""
    Public Property Velocidad As Integer = 9600
    Public Property BitsDatos As Integer = 8
    Public Property Paridad As Parity = Parity.None
    Public Property BitsParada As StopBits = StopBits.One
    Public Property ControlFlujo As Handshake = Handshake.None
    ''' <summary>Activa DTR y RTS (necesario en varios adaptadores USB-serial y básculas).</summary>
    Public Property SenalesDtrRts As Boolean = True
    Public Property Reconectar As Boolean = True

    Public Shared ReadOnly Property Velocidades As Integer()
        Get
            Return New Integer() {1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200}
        End Get
    End Property

    Private Shared Function RutaArchivo(ByVal clave As String) As String
        Dim carpeta As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZeusFacturacion")
        Dim limpia As String = clave
        For Each c As Char In Path.GetInvalidFileNameChars()
            limpia = limpia.Replace(c, "_"c)
        Next
        Return Path.Combine(carpeta, "Bascula_" & limpia & ".cfg")
    End Function

    Public Shared Function Cargar(ByVal clave As String) As BasculaConfig
        Dim cfg As New BasculaConfig
        Try
            Dim ruta As String = RutaArchivo(clave)
            If Not File.Exists(ruta) Then Return cfg
            For Each linea As String In File.ReadAllLines(ruta)
                Dim i As Integer = linea.IndexOf("="c)
                If i <= 0 Then Continue For
                Dim k As String = linea.Substring(0, i).Trim()
                Dim v As String = linea.Substring(i + 1).Trim()
                Select Case k
                    Case "Puerto" : cfg.Puerto = v
                    Case "Velocidad" : cfg.Velocidad = Entero(v, 9600)
                    Case "BitsDatos" : cfg.BitsDatos = Entero(v, 8)
                    Case "Paridad" : cfg.Paridad = CType(Entero(v, 0), Parity)
                    Case "BitsParada" : cfg.BitsParada = CType(Entero(v, 1), StopBits)
                    Case "ControlFlujo" : cfg.ControlFlujo = CType(Entero(v, 0), Handshake)
                    Case "DtrRts" : cfg.SenalesDtrRts = (v = "1")
                    Case "Reconectar" : cfg.Reconectar = (v <> "0")
                End Select
            Next
        Catch
            ' archivo dañado o sin permiso: se usan los valores por defecto
        End Try
        Return cfg
    End Function

    Public Sub Guardar(ByVal clave As String)
        Try
            Dim ruta As String = RutaArchivo(clave)
            Directory.CreateDirectory(Path.GetDirectoryName(ruta))
            Dim l As New List(Of String)
            l.Add("Puerto=" & Puerto)
            l.Add("Velocidad=" & Velocidad.ToString(CultureInfo.InvariantCulture))
            l.Add("BitsDatos=" & BitsDatos.ToString(CultureInfo.InvariantCulture))
            l.Add("Paridad=" & CInt(Paridad).ToString(CultureInfo.InvariantCulture))
            l.Add("BitsParada=" & CInt(BitsParada).ToString(CultureInfo.InvariantCulture))
            l.Add("ControlFlujo=" & CInt(ControlFlujo).ToString(CultureInfo.InvariantCulture))
            l.Add("DtrRts=" & If(SenalesDtrRts, "1", "0"))
            l.Add("Reconectar=" & If(Reconectar, "1", "0"))
            File.WriteAllLines(ruta, l.ToArray())
        Catch
            ' no poder guardar la preferencia no debe impedir pesar
        End Try
    End Sub

    Private Shared Function Entero(ByVal texto As String, ByVal defecto As Integer) As Integer
        Dim n As Integer
        If Integer.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, n) Then Return n
        Return defecto
    End Function

    Public Function Copia() As BasculaConfig
        Return CType(Me.MemberwiseClone(), BasculaConfig)
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Interpretación de las tramas de la báscula
'-----------------------------------------------------------------------------------------------------
Public NotInheritable Class BasculaParser
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Devuelve el peso de una línea recibida, o Nothing si la línea no es una lectura
    ''' (TARA, NETO, teléfonos, líneas vacías o muy cortas).
    ''' Mismas reglas que usaban FrmRecepcion y FrmBascula.
    ''' </summary>
    Public Shared Function Interpretar(ByVal linea As String) As Double?
        If linea Is Nothing Then Return Nothing
        Dim s As String = linea.Trim()
        If s.Length <= 5 Then Return Nothing

        ' Tramas de 19 caracteres que no son "GROSS" no son lecturas de peso bruto.
        If s.Length = 19 AndAlso Not s.StartsWith("GROSS", StringComparison.OrdinalIgnoreCase) Then Return Nothing

        Dim cab As String = s.Substring(0, 4).ToUpperInvariant()
        If cab = "TARA" OrElse cab = "NETO" OrElse s.StartsWith("TEL", StringComparison.OrdinalIgnoreCase) Then Return Nothing

        ' Solo dígitos, signo y punto (igual que SoloNumeros).
        Dim sb As New StringBuilder
        For Each c As Char In s
            If (c >= "0"c AndAlso c <= "9"c) OrElse c = "-"c OrElse c = "."c Then sb.Append(c)
        Next

        Dim valor As Double
        If Not Double.TryParse(sb.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, valor) Then Return Nothing
        If valor <= 0 Then Return Nothing ' báscula en cero / vacía: no es una pesada
        Return valor
    End Function
End Class

'-----------------------------------------------------------------------------------------------------
' Conexión
'-----------------------------------------------------------------------------------------------------
Public Class BasculaConexion
    Implements IDisposable

    Private Const MaxLongitudLinea As Integer = 128

    Private ReadOnly _clave As String
    Private ReadOnly _duenio As Control
    Private _sp As SerialPort
    Private _config As BasculaConfig
    Private ReadOnly _buffer As New StringBuilder
    Private ReadOnly _candado As New Object
    Private WithEvents _timerReconexion As Timer
    Private _deseaConectado As Boolean
    Private _estado As EstadoBascula = EstadoBascula.Desconectado
    Private _liberado As Boolean

    ''' <summary>Se interpretó una lectura de peso (en el hilo de pantalla).</summary>
    Public Event PesoRecibido(ByVal peso As Double, ByVal linea As String)
    ''' <summary>Cualquier línea cruda recibida (para la consola de pruebas de FrmPuertos).</summary>
    Public Event LineaRecibida(ByVal linea As String)
    Public Event EstadoCambiado(ByVal estado As EstadoBascula, ByVal mensaje As String)

    ''' <param name="clave">Identifica la báscula: "Recepcion", "Bascula", "Tara"...</param>
    ''' <param name="duenio">Formulario/control cuyo hilo recibe los eventos.</param>
    Public Sub New(ByVal clave As String, ByVal duenio As Control)
        If duenio Is Nothing Then Throw New ArgumentNullException("duenio")
        _clave = clave
        _duenio = duenio
        _config = BasculaConfig.Cargar(clave)
        _timerReconexion = New Timer()
        _timerReconexion.Interval = 3000
    End Sub

    ''' <summary>True mientras se prueba la báscula (FrmPuertos): se muestran las líneas pero NO se registran pesadas.</summary>
    Public Property SuprimirPeso As Boolean

    Public ReadOnly Property Clave As String
        Get
            Return _clave
        End Get
    End Property

    Public ReadOnly Property Estado As EstadoBascula
        Get
            Return _estado
        End Get
    End Property

    Public ReadOnly Property EstaConectado As Boolean
        Get
            Return _sp IsNot Nothing AndAlso _sp.IsOpen
        End Get
    End Property

    Public ReadOnly Property Config As BasculaConfig
        Get
            Return _config
        End Get
    End Property

    Public Shared Function ListarPuertos() As String()
        Try
            Dim p As String() = SerialPort.GetPortNames()
            Array.Sort(p, New Comparison(Of String)(AddressOf CompararPuertos))
            Return p
        Catch
            Return New String() {}
        End Try
    End Function

    ' COM2 antes que COM10
    Private Shared Function CompararPuertos(ByVal a As String, ByVal b As String) As Integer
        Dim na As Integer = NumeroPuerto(a), nb As Integer = NumeroPuerto(b)
        If na <> nb Then Return na.CompareTo(nb)
        Return String.Compare(a, b, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function NumeroPuerto(ByVal nombre As String) As Integer
        Dim n As Integer
        If nombre IsNot Nothing AndAlso nombre.Length > 3 AndAlso Integer.TryParse(nombre.Substring(3), n) Then Return n
        Return Integer.MaxValue
    End Function

    ''' <summary>Abre el puerto con la configuración dada (y la guarda). Devuelve False con el motivo en <paramref name="motivo"/>.</summary>
    Public Function Conectar(ByVal cfg As BasculaConfig, ByRef motivo As String) As Boolean
        motivo = ""
        If cfg Is Nothing OrElse String.IsNullOrEmpty(cfg.Puerto) Then
            motivo = "Seleccione un puerto."
            Return False
        End If

        CerrarPuerto()
        _config = cfg.Copia()
        _deseaConectado = True

        If Not AbrirPuerto(motivo) Then
            If _config.Reconectar Then
                _timerReconexion.Start()
                CambiarEstado(EstadoBascula.Reconectando, motivo)
            Else
                _deseaConectado = False
                CambiarEstado(EstadoBascula.Error, motivo)
            End If
            Return False
        End If

        _config.Guardar(_clave)
        _timerReconexion.Start()
        CambiarEstado(EstadoBascula.Conectado, "Conectado a " & _config.Puerto)
        Return True
    End Function

    ''' <summary>Abre el último puerto guardado, sin mensajes si no se puede (arranque automático).</summary>
    Public Function ConectarGuardado() As Boolean
        If String.IsNullOrEmpty(_config.Puerto) Then Return False
        Dim motivo As String = ""
        Return Conectar(_config, motivo)
    End Function

    Public Sub Desconectar()
        _deseaConectado = False
        _timerReconexion.Stop()
        CerrarPuerto()
        CambiarEstado(EstadoBascula.Desconectado, "Desconectado")
    End Sub

    Private Function AbrirPuerto(ByRef motivo As String) As Boolean
        Try
            Dim sp As New SerialPort(_config.Puerto, _config.Velocidad, _config.Paridad, _config.BitsDatos, _config.BitsParada)
            sp.Handshake = _config.ControlFlujo
            sp.DtrEnable = _config.SenalesDtrRts
            sp.RtsEnable = _config.SenalesDtrRts
            sp.ReadTimeout = 500
            sp.WriteTimeout = 500
            sp.Encoding = Encoding.ASCII
            sp.ReceivedBytesThreshold = 1
            AddHandler sp.DataReceived, AddressOf OnDataReceived
            AddHandler sp.ErrorReceived, AddressOf OnErrorReceived
            sp.Open()
            sp.DiscardInBuffer()
            SyncLock _candado
                _buffer.Length = 0
            End SyncLock
            _sp = sp
            Return True
        Catch ex As UnauthorizedAccessException
            motivo = "El puerto " & _config.Puerto & " está en uso por otro programa u otra ventana."
        Catch ex As IOException
            motivo = "El puerto " & _config.Puerto & " no está disponible (¿cable desconectado?)."
        Catch ex As ArgumentException
            motivo = "Configuración de puerto no válida: " & ex.Message
        Catch ex As InvalidOperationException
            motivo = "No se pudo abrir " & _config.Puerto & ": " & ex.Message
        Catch ex As Exception
            motivo = "Error al abrir " & _config.Puerto & ": " & ex.Message
        End Try
        _sp = Nothing
        Return False
    End Function

    Private Sub CerrarPuerto()
        Dim sp As SerialPort = _sp
        _sp = Nothing
        If sp Is Nothing Then Return
        Try
            RemoveHandler sp.DataReceived, AddressOf OnDataReceived
            RemoveHandler sp.ErrorReceived, AddressOf OnErrorReceived
            If sp.IsOpen Then
                sp.DiscardInBuffer()
                sp.Close()
            End If
        Catch
            ' el cable ya estaba desconectado
        End Try
        Try
            sp.Dispose()
        Catch
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------------
    ' Lectura (hilo del puerto)
    '-------------------------------------------------------------------------------------------------
    Private Sub OnDataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Dim sp As SerialPort = TryCast(sender, SerialPort)
        If sp Is Nothing Then Return

        Dim lineas As New List(Of String)
        Try
            If Not sp.IsOpen Then Return
            Dim datos As String = sp.ReadExisting()
            If datos.Length = 0 Then Return

            SyncLock _candado
                _buffer.Append(datos)
                Dim texto As String = _buffer.ToString()
                Dim inicio As Integer = 0
                For i As Integer = 0 To texto.Length - 1
                    If texto(i) = ControlChars.Cr OrElse texto(i) = ControlChars.Lf Then
                        If i > inicio Then lineas.Add(texto.Substring(inicio, i - inicio))
                        inicio = i + 1
                    End If
                Next
                _buffer.Length = 0
                If inicio < texto.Length Then
                    Dim resto As String = texto.Substring(inicio)
                    ' báscula sin terminador o basura sin fin de línea: se procesa para no acumular
                    If resto.Length >= MaxLongitudLinea Then
                        lineas.Add(resto)
                    Else
                        _buffer.Append(resto)
                    End If
                End If
            End SyncLock
        Catch ex As Exception
            Publicar(Sub() RaiseEvent EstadoCambiado(EstadoBascula.Error, "Error de lectura: " & ex.Message))
            Return
        End Try

        For Each linea As String In lineas
            Dim l As String = linea
            Dim peso As Double? = BasculaParser.Interpretar(l)
            Publicar(Sub()
                         RaiseEvent LineaRecibida(l)
                         If peso.HasValue AndAlso Not SuprimirPeso Then RaiseEvent PesoRecibido(peso.Value, l)
                     End Sub)
        Next
    End Sub

    Private Sub OnErrorReceived(ByVal sender As Object, ByVal e As SerialErrorReceivedEventArgs)
        Dim tipo As SerialError = e.EventType
        Publicar(Sub() RaiseEvent EstadoCambiado(EstadoBascula.Error, "Error de comunicación en el puerto (" & tipo.ToString() & ")"))
    End Sub

    ''' <summary>Entrega la acción en el hilo de pantalla, ignorando formularios ya cerrados.</summary>
    Private Sub Publicar(ByVal accion As MethodInvoker)
        If _liberado Then Return
        Try
            If _duenio.IsDisposed OrElse Not _duenio.IsHandleCreated Then Return
            _duenio.BeginInvoke(New MethodInvoker(Sub()
                                                      If _liberado OrElse _duenio.IsDisposed Then Return
                                                      Try
                                                          accion()
                                                      Catch ex As Exception
                                                          ' un error en el formulario no debe tumbar la lectura
                                                          Diagnostics.Debug.WriteLine("Bascula: " & ex.ToString())
                                                      End Try
                                                  End Sub))
        Catch ex As InvalidOperationException
            ' el formulario se cerró mientras llegaba un dato
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------------
    ' Reconexión automática (hilo de pantalla)
    '-------------------------------------------------------------------------------------------------
    Private Sub _timerReconexion_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles _timerReconexion.Tick
        If Not _deseaConectado OrElse _liberado Then
            _timerReconexion.Stop()
            Return
        End If

        Dim abierto As Boolean = False
        Try
            abierto = (_sp IsNot Nothing AndAlso _sp.IsOpen)
        Catch
        End Try

        ' El adaptador USB desconectado deja IsOpen en True un rato: se verifica que el puerto exista.
        If abierto Then
            Dim existe As Boolean = False
            For Each p As String In ListarPuertos()
                If String.Equals(p, _config.Puerto, StringComparison.OrdinalIgnoreCase) Then existe = True : Exit For
            Next
            If existe Then
                If _estado <> EstadoBascula.Conectado Then CambiarEstado(EstadoBascula.Conectado, "Conectado a " & _config.Puerto)
                Return
            End If
            CerrarPuerto()
        End If

        If Not _config.Reconectar Then
            _deseaConectado = False
            _timerReconexion.Stop()
            CambiarEstado(EstadoBascula.Error, "Se perdió la conexión con " & _config.Puerto)
            Return
        End If

        CambiarEstado(EstadoBascula.Reconectando, "Reconectando con " & _config.Puerto & "...")
        Dim motivo As String = ""
        If AbrirPuerto(motivo) Then CambiarEstado(EstadoBascula.Conectado, "Reconectado a " & _config.Puerto)
    End Sub

    Private Sub CambiarEstado(ByVal nuevo As EstadoBascula, ByVal mensaje As String)
        Dim cambio As Boolean = (nuevo <> _estado)
        _estado = nuevo
        If cambio OrElse nuevo = EstadoBascula.Error Then RaiseEvent EstadoCambiado(nuevo, mensaje)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _liberado = True
        _deseaConectado = False
        Try
            _timerReconexion.Stop()
            _timerReconexion.Dispose()
        Catch
        End Try
        CerrarPuerto()
    End Sub
End Class
