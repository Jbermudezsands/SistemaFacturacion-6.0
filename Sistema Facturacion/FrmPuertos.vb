Imports System.IO.Ports
Imports System.Text

''' <summary>
''' Configuración y prueba del puerto serial de una báscula.
''' Se usa con cualquier formulario que tenga un <see cref="BasculaConexion"/>:
'''
'''     Using f As New FrmPuertos()
'''         f.Bascula = Me.Bascula
'''         f.ShowDialog(Me)
'''     End Using
'''
''' (Compatibilidad: si solo se asigna <see cref="Pregunta"/> = "Recepcion" o "Bascula", se usa la
''' conexión de FrmRecepcion / FrmBascula.)
''' </summary>
Public Class FrmPuertos
    Public Pregunta As String

    Private _bascula As BasculaConexion
    Private _suprimidoAntes As Boolean
    Private _suscrito As Boolean
    Private ReadOnly _lineas As New System.Collections.Generic.Queue(Of String)
    Private Const MaxLineasConsola As Integer = 200

    ''' <summary>Conexión de la báscula que se va a configurar.</summary>
    Public Property Bascula As BasculaConexion
        Get
            Return _bascula
        End Get
        Set(ByVal value As BasculaConexion)
            _bascula = value
        End Set
    End Property

    Private Function ResolverBascula() As BasculaConexion
        If _bascula IsNot Nothing Then Return _bascula
        Select Case Pregunta
            Case "Recepcion" : Return My.Forms.FrmRecepcion.Bascula
            Case "Bascula" : Return My.Forms.FrmBascula.Bascula
        End Select
        Return Nothing
    End Function

    Private Sub FrmPuertos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _bascula = ResolverBascula()
        If _bascula Is Nothing Then
            MessageBox.Show("No hay una báscula asociada a esta ventana.", "Puertos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        Me.LblTitulo.Text = "Conexión de la báscula - " & _bascula.Clave

        CargarOpciones()
        CargarPuertos(_bascula.Config.Puerto)
        AplicarConfig(_bascula.Config)
        MostrarEstado(_bascula.Estado)

        ' Mientras esta ventana está abierta se muestran las lecturas pero no se registran pesadas.
        _suprimidoAntes = _bascula.SuprimirPeso
        _bascula.SuprimirPeso = True
        AddHandler _bascula.LineaRecibida, AddressOf OnLinea
        AddHandler _bascula.EstadoCambiado, AddressOf OnEstado
        _suscrito = True
    End Sub

    Private Sub FrmPuertos_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        If _suscrito AndAlso _bascula IsNot Nothing Then
            RemoveHandler _bascula.LineaRecibida, AddressOf OnLinea
            RemoveHandler _bascula.EstadoCambiado, AddressOf OnEstado
            _bascula.SuprimirPeso = _suprimidoAntes
            _suscrito = False
        End If
    End Sub

    '---------------------------------------------------------------------------------------------
    ' Carga de opciones
    '---------------------------------------------------------------------------------------------
    Private Sub CargarOpciones()
        Me.CboVelocidad.Items.Clear()
        For Each v As Integer In BasculaConfig.Velocidades
            Me.CboVelocidad.Items.Add(v)
        Next

        Me.CboBits.Items.Clear()
        For Each b As Integer In New Integer() {5, 6, 7, 8}
            Me.CboBits.Items.Add(b)
        Next

        Me.CboParidad.Items.Clear()
        Me.CboParidad.Items.Add(New Opcion(Parity.None, "Ninguna"))
        Me.CboParidad.Items.Add(New Opcion(Parity.Even, "Par"))
        Me.CboParidad.Items.Add(New Opcion(Parity.Odd, "Impar"))
        Me.CboParidad.Items.Add(New Opcion(Parity.Mark, "Marca"))
        Me.CboParidad.Items.Add(New Opcion(Parity.Space, "Espacio"))

        Me.CboParada.Items.Clear()
        Me.CboParada.Items.Add(New Opcion(StopBits.One, "1"))
        Me.CboParada.Items.Add(New Opcion(StopBits.OnePointFive, "1.5"))
        Me.CboParada.Items.Add(New Opcion(StopBits.Two, "2"))

        Me.CboFlujo.Items.Clear()
        Me.CboFlujo.Items.Add(New Opcion(Handshake.None, "Ninguno"))
        Me.CboFlujo.Items.Add(New Opcion(Handshake.XOnXOff, "Software (XON/XOFF)"))
        Me.CboFlujo.Items.Add(New Opcion(Handshake.RequestToSend, "Hardware (RTS/CTS)"))
        Me.CboFlujo.Items.Add(New Opcion(Handshake.RequestToSendXOnXOff, "Hardware + Software"))
    End Sub

    Private Sub CargarPuertos(ByVal seleccionar As String)
        Me.CboPuerto.Items.Clear()
        For Each p As String In BasculaConexion.ListarPuertos()
            Me.CboPuerto.Items.Add(p)
        Next

        If Me.CboPuerto.Items.Count = 0 Then
            Agregar("No se encontraron puertos seriales. Revise el cable o el adaptador USB.")
            Return
        End If

        Dim i As Integer = -1
        If Not String.IsNullOrEmpty(seleccionar) Then i = Me.CboPuerto.Items.IndexOf(seleccionar)
        Me.CboPuerto.SelectedIndex = If(i >= 0, i, 0)
    End Sub

    Private Sub AplicarConfig(ByVal cfg As BasculaConfig)
        SeleccionarEntero(Me.CboVelocidad, cfg.Velocidad, 3)
        SeleccionarEntero(Me.CboBits, cfg.BitsDatos, 3)
        SeleccionarOpcion(Me.CboParidad, cfg.Paridad)
        SeleccionarOpcion(Me.CboParada, cfg.BitsParada)
        SeleccionarOpcion(Me.CboFlujo, cfg.ControlFlujo)
        Me.ChkDtrRts.Checked = cfg.SenalesDtrRts
        Me.ChkReconectar.Checked = cfg.Reconectar
    End Sub

    Private Shared Sub SeleccionarEntero(ByVal cbo As ComboBox, ByVal valor As Integer, ByVal defecto As Integer)
        Dim i As Integer = cbo.Items.IndexOf(valor)
        cbo.SelectedIndex = If(i >= 0, i, defecto)
    End Sub

    Private Shared Sub SeleccionarOpcion(ByVal cbo As ComboBox, ByVal valor As Object)
        For i As Integer = 0 To cbo.Items.Count - 1
            Dim o As Opcion = CType(cbo.Items(i), Opcion)
            If o.Valor.Equals(valor) Then cbo.SelectedIndex = i : Return
        Next
        cbo.SelectedIndex = 0
    End Sub

    Private Function LeerConfig() As BasculaConfig
        Dim cfg As New BasculaConfig
        cfg.Puerto = If(Me.CboPuerto.SelectedItem Is Nothing, "", Me.CboPuerto.SelectedItem.ToString())
        cfg.Velocidad = If(Me.CboVelocidad.SelectedItem Is Nothing, 9600, CInt(Me.CboVelocidad.SelectedItem))
        cfg.BitsDatos = If(Me.CboBits.SelectedItem Is Nothing, 8, CInt(Me.CboBits.SelectedItem))
        cfg.Paridad = CType(CType(Me.CboParidad.SelectedItem, Opcion).Valor, Parity)
        cfg.BitsParada = CType(CType(Me.CboParada.SelectedItem, Opcion).Valor, StopBits)
        cfg.ControlFlujo = CType(CType(Me.CboFlujo.SelectedItem, Opcion).Valor, Handshake)
        cfg.SenalesDtrRts = Me.ChkDtrRts.Checked
        cfg.Reconectar = Me.ChkReconectar.Checked
        Return cfg
    End Function

    '---------------------------------------------------------------------------------------------
    ' Acciones
    '---------------------------------------------------------------------------------------------
    Private Sub BtnActualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnActualizar.Click
        Dim actual As String = If(Me.CboPuerto.SelectedItem Is Nothing, "", Me.CboPuerto.SelectedItem.ToString())
        CargarPuertos(actual)
        Agregar("Puertos encontrados: " & Me.CboPuerto.Items.Count)
    End Sub

    Private Sub BtnConectar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnConectar.Click
        If _bascula Is Nothing Then Return
        Dim cfg As BasculaConfig = LeerConfig()
        If cfg.Puerto = "" Then
            MessageBox.Show("Seleccione un puerto.", "Puertos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Agregar("Abriendo " & cfg.Puerto & " a " & cfg.Velocidad & " bps...")
        Me.Cursor = Cursors.WaitCursor
        Dim motivo As String = ""
        Dim ok As Boolean = _bascula.Conectar(cfg, motivo)
        Me.Cursor = Cursors.Default

        If ok Then
            Agregar("Puerto " & cfg.Puerto & " abierto. Ponga peso en la báscula para probar la lectura.")
        Else
            Agregar("ERROR: " & motivo)
            MessageBox.Show(motivo, "No se pudo conectar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnDesconectar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDesconectar.Click
        If _bascula Is Nothing Then Return
        _bascula.Desconectar()
        Agregar("Puerto cerrado.")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    '---------------------------------------------------------------------------------------------
    ' Eventos de la báscula (ya llegan en el hilo de pantalla)
    '---------------------------------------------------------------------------------------------
    Private Sub OnLinea(ByVal linea As String)
        Agregar("< " & linea)
        Dim peso As Double? = BasculaParser.Interpretar(linea)
        If peso.HasValue Then
            Me.LblPesoPrueba.Text = peso.Value.ToString("N2")
        End If
    End Sub

    Private Sub OnEstado(ByVal estado As EstadoBascula, ByVal mensaje As String)
        MostrarEstado(estado)
        If Not String.IsNullOrEmpty(mensaje) Then Agregar("* " & mensaje)
    End Sub

    Private Sub MostrarEstado(ByVal estado As EstadoBascula)
        BasculaDisenio.MostrarEstado(Me.LblEstadoPuerto, estado)
        Me.LblEstadoPuerto.TextAlign = ContentAlignment.MiddleCenter
        Me.BtnDesconectar.Enabled = (estado <> EstadoBascula.Desconectado)
    End Sub

    Private Sub Agregar(ByVal texto As String)
        _lineas.Enqueue(DateTime.Now.ToString("HH:mm:ss") & "  " & texto)
        Do While _lineas.Count > MaxLineasConsola
            _lineas.Dequeue()
        Loop
        Dim sb As New StringBuilder
        For Each l As String In _lineas
            sb.AppendLine(l)
        Next
        Me.consola.Text = sb.ToString()
        Me.consola.SelectionStart = Me.consola.TextLength
        Me.consola.ScrollToCaret()
    End Sub

    ''' <summary>Elemento de lista con texto en español y valor del enum.</summary>
    Private Class Opcion
        Public ReadOnly Valor As Object
        Public ReadOnly Texto As String

        Public Sub New(ByVal valor As Object, ByVal texto As String)
            Me.Valor = valor
            Me.Texto = texto
        End Sub

        Public Overrides Function ToString() As String
            Return Texto
        End Function
    End Class
End Class
