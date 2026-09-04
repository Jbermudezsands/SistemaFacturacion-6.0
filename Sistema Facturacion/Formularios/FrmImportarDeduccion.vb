Imports System.IO
Imports System.Data.OleDb
Imports System.Text

Public Class FrmImportarDeduccion

    Private _TipoPlanilla As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _NumeroPlanilla As String

    '==========================================================
    ' PROPIEDADES
    '==========================================================

    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(ByVal value As Date)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(ByVal value As Date)
            _FechaHasta = value
        End Set
    End Property

    Public Property NumeroPlanilla As String
        Get
            Return _NumeroPlanilla
        End Get
        Set(ByVal value As String)
            _NumeroPlanilla = value
        End Set
    End Property

    Public Property TipoPlanilla As String
        Get
            Return _TipoPlanilla
        End Get
        Set(ByVal value As String)
            _TipoPlanilla = value
        End Set
    End Property


    '==========================================================
    ' LOAD
    '==========================================================

    Private Sub FrmImportarDeduccion_Load(sender As Object,
                                          e As EventArgs) Handles MyBase.Load

        Me.cboCentroAcopio.Items.Clear()

        If Me.TipoPlanilla <> "" Then

            Me.cboCentroAcopio.Items.Add(Me.TipoPlanilla)
            Me.cboCentroAcopio.SelectedIndex = 0

        End If

        Me.dtpPeriodoDesde.Value = Me.FechaDesde
        Me.dtpPeriodoHasta.Value = Me.FechaHasta
        Me.TxtNumeroPlanilla.Text = Me.NumeroPlanilla

        CargarTiposDeduccion()
        ConfigurarGrid()

        Me.btnCargar.Enabled = False

        LblTotal.Text = "TOTAL: 0.00"

    End Sub


    '==========================================================
    ' TIPOS DE DEDUCCION
    '==========================================================

    Private Sub CargarTiposDeduccion()

        Me.cboTipoDeduccion.Items.Clear()

        Me.cboTipoDeduccion.Items.Add("Anticipo")
        Me.cboTipoDeduccion.Items.Add("Transporte")
        Me.cboTipoDeduccion.Items.Add("Fondos")
        Me.cboTipoDeduccion.Items.Add("Inseminacion")
        Me.cboTipoDeduccion.Items.Add("Trazabilidad")
        Me.cboTipoDeduccion.Items.Add("OtrasDeducciones")
        Me.cboTipoDeduccion.Items.Add("ProductosVeterinarios")

        Me.cboTipoDeduccion.SelectedIndex = -1

    End Sub


    '==========================================================
    ' OBTENER CAMPO DE DEDUCCION
    '==========================================================

    Private Function ObtenerCampoDeduccion() As String

        Select Case Me.cboTipoDeduccion.Text

            Case "Anticipo"
                Return "Anticipo"

            Case "Transporte"
                Return "Transporte"

            Case "Fondos"
                Return "Pulperia"

            Case "Inseminacion"
                Return "Inseminacion"

            Case "Trazabilidad"
                Return "Trazabilidad"

            Case "OtrasDeducciones"
                Return "OtrasDeducciones"

            Case "ProductosVeterinarios"
                Return "ProductosVeterinarios"

            Case Else
                Return String.Empty

        End Select

    End Function


    '==========================================================
    ' CONFIGURAR GRID
    '==========================================================

    Private Sub ConfigurarGrid()

        With Me.dgvDetalle

            .AutoGenerateColumns = False
            .Columns.Clear()

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False

            '--------------------------------------------------
            ' CODIGO BENEFICIARIO
            '--------------------------------------------------

            Dim colCodigo As New DataGridViewTextBoxColumn

            colCodigo.Name = "colCodBeneficiario"
            colCodigo.HeaderText = "COD. BENEFICIARIO"
            colCodigo.Width = 140
            colCodigo.ReadOnly = True
            colCodigo.SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add(colCodigo)


            '--------------------------------------------------
            ' BENEFICIARIO
            '--------------------------------------------------

            Dim colBeneficiario As New DataGridViewTextBoxColumn

            colBeneficiario.Name = "colTercero"
            colBeneficiario.HeaderText = "BENEFICIARIO"
            colBeneficiario.Width = 360
            colBeneficiario.ReadOnly = True
            colBeneficiario.SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add(colBeneficiario)


            '--------------------------------------------------
            ' TIPO PRODUCTOR
            '--------------------------------------------------

            Dim colTipo As New DataGridViewTextBoxColumn

            colTipo.Name = "colTipoProductor"
            colTipo.HeaderText = "TIPO"
            colTipo.Width = 120
            colTipo.ReadOnly = True
            colTipo.SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add(colTipo)


            '--------------------------------------------------
            ' MONTO
            '--------------------------------------------------

            Dim colMonto As New DataGridViewTextBoxColumn

            colMonto.Name = "colMonto"
            colMonto.HeaderText = "MONTO"
            colMonto.Width = 150
            colMonto.ReadOnly = True

            colMonto.DefaultCellStyle.Format = "##,##0.00"
            colMonto.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight

            colMonto.SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add(colMonto)

        End With

    End Sub


    '==========================================================
    ' BOTON ABRIR
    '==========================================================

    Private Sub btnAbrir_Click(sender As Object,
                           e As EventArgs) Handles btnAbrir.Click

        Try

            '======================================================
            ' VALIDAR TIPO DE DEDUCCION
            '======================================================

            If Me.cboTipoDeduccion.SelectedIndex = -1 Then

                MessageBox.Show(
                "Seleccione el tipo de deducción.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            '======================================================
            ' SELECCIONAR ARCHIVO
            '======================================================

            Dim Dialogo As New OpenFileDialog

            Dialogo.Title = "Seleccione el archivo de deducciones"

            Dialogo.Filter =
            "Archivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls"

            Dialogo.Multiselect = False


            If Dialogo.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If


            Dim RutaArchivo As String =
            Dialogo.FileName


            '======================================================
            ' LEER EXCEL
            '======================================================

            Dim TablaExcel As DataTable =
            LeerArchivoExcel(RutaArchivo)


            If TablaExcel Is Nothing OrElse
           TablaExcel.Rows.Count = 0 Then

                MessageBox.Show(
                "El archivo no contiene registros.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            '======================================================
            ' BUSCAR COLUMNAS
            '======================================================

            Dim ColumnaCodigo As String =
            BuscarColumna(
                TablaExcel,
                "NIT",
                "CODIGO",
                "CODIGOBENEFICIARIO",
                "CODIGO BENEFICIARIO",
                "NIT - CODIGOBENEFICIARIO")


            Dim ColumnaNombre As String =
            BuscarColumna(
                TablaExcel,
                "TERCERO",
                "NOMBRE",
                "NOMBREBENEFICIARIO",
                "NOMBRE BENEFICIARIO")


            Dim ColumnaTipo As String =
            BuscarColumna(
                TablaExcel,
                "TIPO",
                "TIPOPRODUCTOR",
                "TIPO PRODUCTOR")


            Dim ColumnaMonto As String =
            BuscarColumna(
                TablaExcel,
                "HABER",
                "MONTO",
                "HABER - MONTO")


            '======================================================
            ' VALIDAR COLUMNAS
            '======================================================

            If ColumnaCodigo = "" Then

                MessageBox.Show(
                "No se encontró la columna del código de beneficiario.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Exit Sub

            End If


            If ColumnaNombre = "" Then

                MessageBox.Show(
                "No se encontró la columna del nombre del beneficiario.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Exit Sub

            End If


            If ColumnaTipo = "" Then

                MessageBox.Show(
                "No se encontró la columna TIPO del beneficiario.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Exit Sub

            End If


            If ColumnaMonto = "" Then

                MessageBox.Show(
                "No se encontró la columna del monto.",
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Exit Sub

            End If


            '======================================================
            ' VALIDAR REGISTROS
            '======================================================

            Dim Errores As New List(Of String)

            Dim Registros As New Dictionary(Of String,
                                         RegistroImportacion)


            ' La primera fila de Excel normalmente es encabezado.
            ' Por eso el primer registro de DataTable corresponde
            ' a la línea 2 del Excel.

            Dim NumeroLinea As Integer = 1


            For Each Fila As DataRow In TablaExcel.Rows

                NumeroLinea += 1


                '==================================================
                ' DATOS DEL EXCEL
                '==================================================

                Dim Codigo As String =
                Convert.ToString(
                    Fila(ColumnaCodigo)).Trim()


                Dim NombreExcel As String =
                Convert.ToString(
                    Fila(ColumnaNombre)).Trim()


                Dim TipoExcel As String =
                Convert.ToString(
                    Fila(ColumnaTipo)).Trim()


                Dim TextoMonto As String =
                Convert.ToString(
                    Fila(ColumnaMonto)).Trim()


                '==================================================
                ' VALIDAR CODIGO
                '==================================================

                If Codigo = "" Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El código de beneficiario está vacío.")

                    Continue For

                End If


                '==================================================
                ' VALIDAR TIPO
                '==================================================

                If TipoExcel = "" Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El tipo de productor está vacío.")

                    Continue For

                End If


                '==================================================
                ' VALIDAR MONTO
                '==================================================

                Dim Monto As Double


                If Not Double.TryParse(
                TextoMonto,
                Monto) Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El monto '" &
                    TextoMonto &
                    "' no es numérico.")

                    Continue For

                End If


                '==================================================
                ' VALIDAR MONTO NEGATIVO
                '==================================================

                If Monto < 0 Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El monto no puede ser negativo.")

                    Continue For

                End If


                '==================================================
                ' BUSCAR PRODUCTOR EN LA PLANILLA
                '==================================================

                Dim DatosProductor As DatosProductorImportacion =
                BuscarProductorPlanilla(Codigo)


                '==================================================
                ' VALIDAR EXISTENCIA DEL CODIGO
                '==================================================

                If DatosProductor Is Nothing Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El código de beneficiario '" &
                    Codigo &
                    "' no existe en la planilla " &
                    Me.NumeroPlanilla &
                    ".")

                    Continue For

                End If


                '==================================================
                ' VALIDAR TIPO
                '==================================================

                If NormalizarTexto(TipoExcel) <>
               NormalizarTexto(
                   DatosProductor.TipoProductor) Then

                    Errores.Add(
                    "Línea " &
                    NumeroLinea.ToString() &
                    ": El tipo de productor no coincide para " &
                    "el código '" &
                    Codigo &
                    "'." &
                    Environment.NewLine &
                    "    Tipo en Excel: '" &
                    TipoExcel &
                    "'" &
                    Environment.NewLine &
                    "    Tipo en planilla: '" &
                    DatosProductor.TipoProductor &
                    "'.")

                    Continue For

                End If


                '==================================================
                ' CONSOLIDAR CODIGOS REPETIDOS
                '==================================================

                Dim Clave As String =
                Codigo.Trim().ToUpperInvariant()


                If Registros.ContainsKey(Clave) Then

                    Registros(Clave).Monto += Monto

                Else

                    Dim Registro As New RegistroImportacion

                    Registro.CodigoBeneficiario =
                    Codigo

                    ' El nombre viene de la PLANILLA,
                    ' no del Excel.

                    Registro.NombreBeneficiario =
                    DatosProductor.NombreProductor

                    Registro.TipoProductor =
                    DatosProductor.TipoProductor

                    Registro.Monto =
                    Monto

                    Registros.Add(
                    Clave,
                    Registro)

                End If

            Next


            '======================================================
            ' SI EXISTEN ERRORES
            '======================================================

            If Errores.Count > 0 Then

                Dim RutaErrores As String =
                GenerarArchivoErrores(
                    RutaArchivo,
                    Errores)


                Me.dgvDetalle.Rows.Clear()
                LblTotal.Text = "TOTAL: 0.00"

                Me.btnCargar.Enabled = False


                MessageBox.Show(
                "Se encontraron " &
                Errores.Count.ToString() &
                " errores en el archivo." &
                Environment.NewLine &
                Environment.NewLine &
                "Se generó el archivo:" &
                Environment.NewLine &
                RutaErrores,
                "Zeus Acopio",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            '======================================================
            ' CARGAR GRID
            '======================================================

            Me.dgvDetalle.Rows.Clear()


            For Each Registro As RegistroImportacion In
            Registros.Values

                Me.dgvDetalle.Rows.Add(
                Registro.CodigoBeneficiario,
                Registro.NombreBeneficiario,
                Registro.TipoProductor,
                Registro.Monto)

            Next

            ActualizarTotal()

            '======================================================
            ' HABILITAR BOTON CARGAR
            '======================================================

            If Me.dgvDetalle.Rows.Count > 0 Then

                Me.btnCargar.Enabled = True

            Else

                Me.btnCargar.Enabled = False

            End If


            MessageBox.Show(
            "Archivo validado correctamente." &
            Environment.NewLine &
            Environment.NewLine &
            "Registros listos para cargar: " &
            Me.dgvDetalle.Rows.Count.ToString(),
            "Zeus Acopio",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


        Catch ex As Exception

            MessageBox.Show(
            "Ocurrió un error al abrir el archivo." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Zeus Acopio",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub

    '==========================================================
    ' LEER ARCHIVO EXCEL
    '==========================================================

    Private Function LeerArchivoExcel(ByVal RutaArchivo As String) As DataTable

        Dim Tabla As New DataTable()

        Dim Extension As String = Path.GetExtension(RutaArchivo).ToLowerInvariant()

        Dim CadenaConexion As String

        If Extension = ".xlsx" Then

            CadenaConexion =
            "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "Data Source=" & RutaArchivo & ";" &
            "Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"

        ElseIf Extension = ".xls" Then

            CadenaConexion =
            "Provider=Microsoft.Jet.OLEDB.4.0;" &
            "Data Source=" & RutaArchivo & ";" &
            "Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";"

        Else

            Throw New Exception("El archivo seleccionado no es un archivo Excel válido.")

        End If


        Using ConexionExcel As New OleDbConnection(CadenaConexion)

            ConexionExcel.Open()

            Dim Hojas As DataTable =
            ConexionExcel.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                Nothing)

            If Hojas Is Nothing OrElse Hojas.Rows.Count = 0 Then
                Throw New Exception("El archivo Excel no contiene ninguna hoja.")
            End If


            Dim NombreHoja As String = ""

            For Each FilaHoja As DataRow In Hojas.Rows

                Dim Nombre As String =
                FilaHoja("TABLE_NAME").ToString()

                If Nombre.EndsWith("$") OrElse
               Nombre.EndsWith("$'") Then

                    NombreHoja = Nombre
                    Exit For

                End If

            Next


            If NombreHoja = "" Then
                Throw New Exception("No se encontró una hoja válida en el archivo Excel.")
            End If


            Dim Consulta As String =
            "SELECT * FROM [" & NombreHoja & "]"

            Using Comando As New OleDbCommand(
            Consulta,
            ConexionExcel)

                Using Adaptador As New OleDbDataAdapter(Comando)

                    Adaptador.Fill(Tabla)

                End Using

            End Using

        End Using


        '==========================================================
        ' ELIMINAR COLUMNAS COMPLETAMENTE VACÍAS
        '==========================================================

        For I As Integer = Tabla.Columns.Count - 1 To 0 Step -1

            Dim TieneDatos As Boolean = False

            For Each Fila As DataRow In Tabla.Rows

                If Not Fila.IsNull(I) Then

                    Dim Valor As String =
                    Fila(I).ToString().Trim()

                    If Valor <> "" Then
                        TieneDatos = True
                        Exit For
                    End If

                End If

            Next

            If Not TieneDatos Then
                Tabla.Columns.RemoveAt(I)
            End If

        Next


        '==========================================================
        ' ELIMINAR FILAS COMPLETAMENTE VACÍAS
        '==========================================================

        For I As Integer = Tabla.Rows.Count - 1 To 0 Step -1

            Dim TieneDatos As Boolean = False

            For Each Columna As DataColumn In Tabla.Columns

                If Not Tabla.Rows(I).IsNull(Columna) Then

                    Dim Valor As String =
                    Tabla.Rows(I)(Columna).ToString().Trim()

                    If Valor <> "" Then
                        TieneDatos = True
                        Exit For
                    End If

                End If

            Next

            If Not TieneDatos Then
                Tabla.Rows.RemoveAt(I)
            End If

        Next


        Tabla.AcceptChanges()

        Return Tabla

    End Function

    '==========================================================
    ' BUSCAR COLUMNA
    '==========================================================

    Private Function BuscarColumna(
        ByVal Tabla As DataTable,
        ParamArray Nombres As String()) As String

        For Each Columna As DataColumn In Tabla.Columns

            Dim NombreColumna As String =
                NormalizarTexto(Columna.ColumnName)


            For Each NombreBuscado As String In Nombres

                If NombreColumna =
                   NormalizarTexto(NombreBuscado) Then

                    Return Columna.ColumnName

                End If

            Next

        Next


        Return String.Empty

    End Function


    '==========================================================
    ' NORMALIZAR TEXTO
    '==========================================================

    Private Function NormalizarTexto(
        ByVal Texto As String) As String

        If Texto Is Nothing Then
            Return String.Empty
        End If


        Dim Resultado As String =
            Texto.Trim().ToUpperInvariant()


        Resultado =
            Resultado.Replace("Á", "A").
                      Replace("É", "E").
                      Replace("Í", "I").
                      Replace("Ó", "O").
                      Replace("Ú", "U")


        Resultado =
            Resultado.Replace(" ", "").
                      Replace("_", "").
                      Replace("-", "")


        Return Resultado

    End Function


    '==========================================================
    ' BUSCAR PRODUCTOR EN PLANILLA
    '==========================================================

    Private Function BuscarProductorPlanilla(
        ByVal CodigoBeneficiario As String) _
        As DatosProductorImportacion

        Dim Resultado As DatosProductorImportacion = Nothing


        Dim Sql As String =
            "SELECT TOP 1 " &
            "CodProductor, " &
            "TipoProductor, " &
            "Nombres " &
            "FROM Detalle_Nomina " &
            "WHERE NumNomina = @NumNomina " &
            "AND CodProductor = @CodProductor"


        Using ConexionSQL As New SqlClient.SqlConnection(Conexion)

            Using Comando As New SqlClient.SqlCommand(
        Sql,
        ConexionSQL)

                Comando.Parameters.AddWithValue(
            "@NumNomina",
            Me.NumeroPlanilla)

                Comando.Parameters.AddWithValue(
            "@CodProductor",
            CodigoBeneficiario)

                ConexionSQL.Open()

                Using Lector As SqlClient.SqlDataReader =
            Comando.ExecuteReader()

                    If Lector.Read() Then

                        Resultado =
                    New DatosProductorImportacion

                        Resultado.CodigoBeneficiario =
                    Convert.ToString(
                        Lector("CodProductor"))

                        Resultado.TipoProductor =
                    Convert.ToString(
                        Lector("TipoProductor"))

                        Resultado.NombreProductor =
                    Convert.ToString(
                        Lector("Nombres"))

                    End If

                End Using

            End Using

        End Using

        Return Resultado

    End Function


    '==========================================================
    ' COMPARAR NOMBRES
    '==========================================================

    Private Function NombresCoinciden(
        ByVal NombreExcel As String,
        ByVal NombrePlanilla As String) As Boolean

        Return NormalizarTexto(NombreExcel) =
               NormalizarTexto(NombrePlanilla)

    End Function


    '==========================================================
    ' GENERAR ARCHIVO DE ERRORES
    '==========================================================

    Private Function GenerarArchivoErrores(
        ByVal RutaArchivoExcel As String,
        ByVal Errores As List(Of String)) As String

        Dim NombreArchivo As String =
            "ErroresImportacion_" &
            DateTime.Now.ToString("yyyyMMdd_HHmmss") &
            ".txt"


        Dim RutaErrores As String =
            Path.Combine(
                Application.StartupPath,
                NombreArchivo)


        Dim Texto As New StringBuilder


        Texto.AppendLine(
            "ERRORES DE IMPORTACIÓN")

        Texto.AppendLine(
            "========================================")

        Texto.AppendLine(
            "Archivo: " &
            Path.GetFileName(RutaArchivoExcel))

        Texto.AppendLine(
            "Planilla: " &
            Me.NumeroPlanilla)

        Texto.AppendLine(
            "Tipo de deducción: " &
            Me.cboTipoDeduccion.Text)

        Texto.AppendLine(
            "Fecha: " &
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))

        Texto.AppendLine()

        For Each ErrorImportacion As String In Errores

            Texto.AppendLine(ErrorImportacion)
            Texto.AppendLine()

        Next


        Texto.AppendLine(
            "========================================")

        Texto.AppendLine(
            "Total de errores: " &
            Errores.Count.ToString())


        File.WriteAllText(
            RutaErrores,
            Texto.ToString(),
            Encoding.UTF8)


        Return RutaErrores

    End Function


    '==========================================================
    ' CLASE REGISTRO IMPORTACION
    '==========================================================

    Private Class RegistroImportacion

        Public CodigoBeneficiario As String
        Public NombreBeneficiario As String
        Public TipoProductor As String
        Public Monto As Double

    End Class


    '==========================================================
    ' CLASE DATOS PRODUCTOR
    '==========================================================

    Private Class DatosProductorImportacion

        Public CodigoBeneficiario As String
        Public NombreProductor As String
        Public TipoProductor As String

    End Class


    '==========================================================
    ' BOTON CARGAR
    '==========================================================

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Try

            If dgvDetalle.Rows.Count = 0 Then

                MessageBox.Show(
                "No hay registros para cargar.",
                "Importar Deducciones",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            Dim CampoDeduccion As String =
            ObtenerCampoDeduccion()

            If String.IsNullOrWhiteSpace(CampoDeduccion) Then

                MessageBox.Show(
                "No se pudo determinar el tipo de deducción.",
                "Importar Deducciones",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            Dim CantidadRegistros As Integer = 0

            Using ConexionSQL As New SqlClient.SqlConnection(Conexion)

                ConexionSQL.Open()

                Using Transaccion As SqlClient.SqlTransaction =
                ConexionSQL.BeginTransaction()

                    Try

                        For Each Fila As DataGridViewRow In dgvDetalle.Rows

                            If Fila.IsNewRow Then
                                Continue For
                            End If


                            Dim CodProductor As String =
                            Convert.ToString(
                                Fila.Cells("colCodBeneficiario").Value).Trim()

                            Dim NombreProductor As String =
                            Convert.ToString(
                                Fila.Cells("colTercero").Value).Trim()

                            Dim TipoProductor As String =
                            Convert.ToString(
                                Fila.Cells("colTipoProductor").Value).Trim()


                            Dim Monto As Double

                            If Not Double.TryParse(
                            Convert.ToString(
                                Fila.Cells("colMonto").Value),
                            Monto) Then

                                Throw New Exception(
                                "El monto del beneficiario " &
                                CodProductor &
                                " no es válido.")

                            End If


                            '==================================================
                            ' BUSCAR EL ÚLTIMO REGISTRO DE DEDUCCIONES
                            '==================================================

                            Dim IdDeduccion As Integer = 0


                            Dim SQLBuscar As String =
                            "SELECT TOP 1 IdDeduccion " &
                            "FROM Deducciones_Planilla " &
                            "WHERE NumNomina = @NumNomina " &
                            "AND CodProductor = @CodProductor " &
                            "AND TipoProductor = @TipoProductor " &
                            "ORDER BY IdDeduccion DESC"


                            Using CmdBuscar As New SqlClient.SqlCommand(
                            SQLBuscar,
                            ConexionSQL,
                            Transaccion)

                                CmdBuscar.Parameters.AddWithValue(
                                "@NumNomina",
                                NumeroPlanilla)

                                CmdBuscar.Parameters.AddWithValue(
                                "@CodProductor",
                                CodProductor)

                                CmdBuscar.Parameters.AddWithValue(
                                "@TipoProductor",
                                TipoProductor)


                                Dim Resultado As Object =
                                CmdBuscar.ExecuteScalar()

                                If Resultado IsNot Nothing AndAlso
                               Resultado IsNot DBNull.Value Then

                                    IdDeduccion = Convert.ToInt32(Resultado)

                                End If

                            End Using


                            '==================================================
                            ' SI EXISTE: REEMPLAZAR EL VALOR
                            '==================================================

                            If IdDeduccion > 0 Then

                                Dim SQLActualizar As String =
                                "UPDATE Deducciones_Planilla " &
                                "SET " & CampoDeduccion & " = @Monto " &
                                "WHERE IdDeduccion = @IdDeduccion"


                                Using CmdActualizar As New SqlClient.SqlCommand(
                                SQLActualizar,
                                ConexionSQL,
                                Transaccion)

                                    CmdActualizar.Parameters.AddWithValue(
                                    "@Monto",
                                    Monto)

                                    CmdActualizar.Parameters.AddWithValue(
                                    "@IdDeduccion",
                                    IdDeduccion)

                                    CmdActualizar.ExecuteNonQuery()

                                End Using


                            Else

                                '==================================================
                                ' SI NO EXISTE: INSERTAR
                                '==================================================

                                Dim SQLInsertar As String =
                                "INSERT INTO Deducciones_Planilla " &
                                "(NumNomina, CodProductor, TipoProductor, NombreProductor, " &
                                CampoDeduccion & ") " &
                                "VALUES " &
                                "(@NumNomina, @CodProductor, @TipoProductor, " &
                                "@NombreProductor, @Monto)"


                                Using CmdInsertar As New SqlClient.SqlCommand(
                                SQLInsertar,
                                ConexionSQL,
                                Transaccion)

                                    CmdInsertar.Parameters.AddWithValue(
                                    "@NumNomina",
                                    NumeroPlanilla)

                                    CmdInsertar.Parameters.AddWithValue(
                                    "@CodProductor",
                                    CodProductor)

                                    CmdInsertar.Parameters.AddWithValue(
                                    "@TipoProductor",
                                    TipoProductor)

                                    CmdInsertar.Parameters.AddWithValue(
                                    "@NombreProductor",
                                    NombreProductor)

                                    CmdInsertar.Parameters.AddWithValue(
                                    "@Monto",
                                    Monto)

                                    CmdInsertar.ExecuteNonQuery()

                                End Using

                            End If


                            CantidadRegistros += 1

                        Next


                        '==================================================
                        ' CONFIRMAR TRANSACCIÓN
                        '==================================================

                        Transaccion.Commit()


                    Catch

                        '==================================================
                        ' DESHACER TODO SI OCURRE UN ERROR
                        '==================================================

                        Try
                            Transaccion.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


            '==============================================================
            ' IMPORTACIÓN COMPLETADA
            '==============================================================

            MessageBox.Show(
            "La importación se realizó correctamente." &
            Environment.NewLine &
            Environment.NewLine &
            "Registros procesados: " &
            CantidadRegistros.ToString(),
            "Importar Deducciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


            DialogResult = DialogResult.OK
            Me.Close()


        Catch ex As Exception

            MessageBox.Show(
            "No se pudo cargar la deducción." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Importar Deducciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub ActualizarTotal()

        Dim Total As Double = 0

        For Each Fila As DataGridViewRow In dgvDetalle.Rows

            If Not Fila.IsNewRow Then

                If Fila.Cells("colMonto").Value IsNot Nothing Then

                    Dim Monto As Double

                    If Double.TryParse(
                        Fila.Cells("colMonto").Value.ToString(),
                        Monto) Then

                        Total += Monto

                    End If

                End If

            End If

        Next

        LblTotal.Text = "TOTAL: " & Total.ToString("N2")

    End Sub

End Class