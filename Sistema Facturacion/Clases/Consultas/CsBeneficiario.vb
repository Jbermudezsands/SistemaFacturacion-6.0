Imports System.Data.SqlClient
Imports C1.Win.C1List
Imports System.IO
Imports System.Text

Public Class CsBeneficiario
    Private Sub ActualizarTipoNomina(CodProductor As String,
                                 TipoProductor As String,
                                 NuevoTipoNomina As String,
                                 cn As SqlConnection,
                                 trans As SqlTransaction)

        Dim sql As String =
        "UPDATE Productor
         SET CodTipoNomina=@Tipo
         WHERE CodProductor=@Codigo
         AND TipoProductor=@Rol"

        Using cmd As New SqlCommand(sql, cn, trans)

            cmd.Parameters.AddWithValue("@Tipo", NuevoTipoNomina)
            cmd.Parameters.AddWithValue("@Codigo", CodProductor)
            cmd.Parameters.AddWithValue("@Rol", TipoProductor)

            cmd.ExecuteNonQuery()

        End Using

    End Sub

    Public Function CambiarTipoNomina(CodProductor As String,
                                  TipoProductor As String,
                                  NuevoTipoNomina As String) As Boolean

        Dim r As ResultadoDesactivacion

        r = PrepararCambioTipoNomina(CodProductor,
                                 TipoProductor)

        If r.RequiereConfirmacion Then

            If MessageBox.Show(r.Mensaje,
                           "Cambio de Tipo de Nómina",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then

                Return False

            End If

        End If

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Using trans = cn.BeginTransaction()

                Try

                    ProcesarCambioTipoNomina(CodProductor,
                                         TipoProductor,
                                         cn,
                                         trans)

                    ActualizarTipoNomina(CodProductor,
                                     TipoProductor,
                                     NuevoTipoNomina,
                                     cn,
                                     trans)

                    trans.Commit()

                    Return True

                Catch

                    trans.Rollback()

                    Throw

                End Try

            End Using

        End Using

    End Function

    Public Function ProcesarCambioTipoNomina(CodProductor As String,
                                         TipoProductor As String,
                                         Optional cn As SqlConnection = Nothing,
                                         Optional trans As SqlTransaction = Nothing) As Boolean

        Dim ConexionLocal As Boolean = False
        Dim TransaccionLocal As Boolean = False

        Try

            If cn Is Nothing Then
                cn = New SqlConnection(Conexion)
                cn.Open()
                ConexionLocal = True
            End If

            If trans Is Nothing Then
                trans = cn.BeginTransaction()
                TransaccionLocal = True
            End If

            '----------------------------------------
            ' Eliminar únicamente de las nóminas activas
            '----------------------------------------
            EliminarDeNominasActivas(CodProductor,
                                 TipoProductor,
                                 cn,
                                 trans)

            If TransaccionLocal Then
                trans.Commit()
            End If

            Return True

        Catch

            If TransaccionLocal Then
                trans.Rollback()
            End If

            Throw

        Finally

            If ConexionLocal Then
                cn.Close()
                cn.Dispose()
            End If

        End Try

    End Function

    Public Function PrepararCambioTipoNomina(CodProductor As String,
                                         TipoProductor As String) As ResultadoDesactivacion

        Dim r As New ResultadoDesactivacion

        Dim lista As List(Of NominaActiva)

        lista = ObtenerNominasActivas(CodProductor, TipoProductor)

        If lista.Count = 0 Then
            Return r
        End If

        r.RequiereConfirmacion = True

        Dim sb As New StringBuilder

        sb.AppendLine("El Tipo de Nómina del " & UCase(TipoProductor) & " será modificado.")
        sb.AppendLine()
        sb.AppendLine("Para mantener la consistencia de las planillas, este " &
                  UCase(TipoProductor) &
                  " será retirado de las siguientes nóminas activas:")
        sb.AppendLine()

        For Each n As NominaActiva In lista

            sb.AppendLine("Planilla : " & n.NumNomina)
            sb.AppendLine("Tipo Nómina : " & n.CodTipoNomina)
            sb.AppendLine("Período : " &
                      Format(n.FechaInicial, "dd/MM/yyyy") &
                      " al " &
                      Format(n.FechaFinal, "dd/MM/yyyy"))
            sb.AppendLine()

        Next

        sb.AppendLine("Una vez guardado el cambio, podrá incorporarse nuevamente")
        sb.AppendLine("al recalcular las planillas correspondientes al nuevo")
        sb.AppendLine("Tipo de Nómina.")
        sb.AppendLine()
        sb.AppendLine("Los demás roles del beneficiario no serán modificados.")
        sb.AppendLine()
        sb.AppendLine("¿Desea continuar?")

        r.Mensaje = sb.ToString()

        Return r

    End Function

    Public Function PrepararDesactivacion(CodProductor As String,
                                      TipoProductor As String) As ResultadoDesactivacion

        Dim r As New ResultadoDesactivacion

        Dim lista As List(Of NominaActiva)

        lista = ObtenerNominasActivas(CodProductor, TipoProductor)

        If lista.Count = 0 Then
            Return r
        End If

        r.RequiereConfirmacion = True

        Dim sb As New StringBuilder

        sb.AppendLine("El beneficiario " & CodProductor & " será desactivado únicamente como:")
        sb.AppendLine()
        sb.AppendLine("    " & UCase(TipoProductor))
        sb.AppendLine()
        sb.AppendLine("Será eliminado de las siguientes nóminas donde participa como " &
                  UCase(TipoProductor) & ":")
        sb.AppendLine()

        For Each n As NominaActiva In lista

            sb.AppendLine("Planilla : " & n.NumNomina)
            sb.AppendLine("Tipo Nómina : " & n.CodTipoNomina)
            sb.AppendLine("Período : " &
                      Format(n.FechaInicial, "dd/MM/yyyy") &
                      " al " &
                      Format(n.FechaFinal, "dd/MM/yyyy"))
            sb.AppendLine()

        Next

        sb.AppendLine("Los demás roles del beneficiario (Cliente, Proveedor,")
        sb.AppendLine("Transportista, Empleado, Productor, Socio o PreSocio)")
        sb.AppendLine("no serán modificados.")
        sb.AppendLine()
        sb.AppendLine("¿Desea continuar?")

        r.Mensaje = sb.ToString()

        Return r

    End Function


    Public Function ProcesarDesactivacionTipo(CodProductor As String,
                                          TipoProductor As String,
                                          Optional cn As SqlConnection = Nothing,
                                          Optional trans As SqlTransaction = Nothing) As Boolean

        Dim ConexionLocal As Boolean = False
        Dim TransaccionLocal As Boolean = False

        Try

            If cn Is Nothing Then
                cn = New SqlConnection(Conexion)
                cn.Open()
                ConexionLocal = True
            End If

            If trans Is Nothing Then
                trans = cn.BeginTransaction()
                TransaccionLocal = True
            End If

            '----------------------------------------
            '¿Ya estaba desactivado?
            '----------------------------------------

            Dim sql As String =
        "SELECT Activo
           FROM Productor
          WHERE CodProductor=@Cod
            AND TipoProductor=@Tipo"

            Dim Activo As Boolean = False

            Using cmd As New SqlCommand(sql, cn, trans)

                cmd.Parameters.AddWithValue("@Cod", CodProductor)
                cmd.Parameters.AddWithValue("@Tipo", TipoProductor)

                Dim r = cmd.ExecuteScalar()

                If r IsNot Nothing AndAlso r IsNot DBNull.Value Then
                    Activo = CBool(r)
                End If

            End Using

            If Not Activo Then

                If TransaccionLocal Then
                    trans.Commit()
                End If

                Return True

            End If

            '----------------------------------------
            'Eliminar de las nóminas
            '----------------------------------------

            EliminarDeNominasActivas(CodProductor,
                                 TipoProductor,
                                 cn,
                                 trans)

            '----------------------------------------
            'Desactivar tipo
            '----------------------------------------

            DesactivarTipoBeneficiario(CodProductor,
                                   TipoProductor,
                                   cn,
                                   trans)

            If TransaccionLocal Then
                trans.Commit()
            End If

            Return True

        Catch

            If TransaccionLocal Then
                trans.Rollback()
            End If

            Throw

        Finally

            If ConexionLocal Then
                cn.Close()
                cn.Dispose()
            End If

        End Try

    End Function

    Public Function DesactivarTipoBeneficiario(CodProductor As String,
                                           TipoProductor As String,
                                           Optional cn As SqlConnection = Nothing,
                                           Optional trans As SqlTransaction = Nothing) As Boolean

        Dim conexionLocal As Boolean = False

        Try

            If cn Is Nothing Then
                cn = New SqlConnection(Conexion)
                cn.Open()
                conexionLocal = True
            End If

            '---------------------------------------------------
            ' Desactivar el tipo (Productor, Socio o PreSocio)
            '---------------------------------------------------
            Dim sql As String =
        "UPDATE Productor
            SET Activo = 0
          WHERE CodProductor = @Cod
            AND TipoProductor = @Tipo"

            Using cmd As New SqlCommand(sql, cn)

                If trans IsNot Nothing Then
                    cmd.Transaction = trans
                End If

                cmd.Parameters.AddWithValue("@Cod", CodProductor)
                cmd.Parameters.AddWithValue("@Tipo", TipoProductor)

                cmd.ExecuteNonQuery()

            End Using

            '---------------------------------------------------
            ' Si todavía tiene algún rol activo, no hacer nada más
            '---------------------------------------------------
            If TieneAlgunRolActivo(cn, CodProductor, trans) Then
                Return True
            End If

            '---------------------------------------------------
            ' Ya no tiene ningún rol activo
            '---------------------------------------------------
            sql =
        "UPDATE Beneficiario
            SET Activo = 0
          WHERE Codigo_Beneficiario = @Cod"

            Using cmd As New SqlCommand(sql, cn)

                If trans IsNot Nothing Then
                    cmd.Transaction = trans
                End If

                cmd.Parameters.AddWithValue("@Cod", CodProductor)

                cmd.ExecuteNonQuery()

            End Using

            Return True

        Catch
            Throw

        Finally

            If conexionLocal Then
                cn.Close()
                cn.Dispose()
            End If

        End Try

    End Function
    Private Function TieneAlgunRolActivo(cn As SqlConnection,
                                     codigo As String,
                                     Optional trans As SqlTransaction = Nothing) As Boolean

        If ExisteRegistro(cn, "Clientes", "Cod_Cliente", codigo, trans) Then
            Return True
        End If

        If ExisteRegistro(cn, "Proveedor", "Cod_Proveedor", codigo, trans) Then
            Return True
        End If

        If ExisteRegistro(cn, "Conductor", "Codigo", codigo, trans) Then
            Return True
        End If

        If ExisteEmpleadoActivo(cn, codigo, trans) Then
            Return True
        End If

        If TieneRolesActivos(codigo, cn, trans) Then
            Return True
        End If

        Return False

    End Function

    Private Function TieneRolesActivos(CodProductor As String,
                                   Optional cn As SqlConnection = Nothing,
                                   Optional trans As SqlTransaction = Nothing) As Boolean

        Dim conexionLocal As Boolean = False

        Try

            If cn Is Nothing Then
                cn = New SqlConnection(Conexion)
                cn.Open()
                conexionLocal = True
            End If

            Dim sql As String =
        "SELECT COUNT(*)
           FROM Productor
          WHERE CodProductor=@Cod
            AND Activo=1"

            Using cmd As New SqlCommand(sql, cn)

                If trans IsNot Nothing Then
                    cmd.Transaction = trans
                End If

                cmd.Parameters.AddWithValue("@Cod", CodProductor)

                Return CInt(cmd.ExecuteScalar()) > 0

            End Using

        Finally

            If conexionLocal Then
                cn.Close()
                cn.Dispose()
            End If

        End Try

    End Function


    Public Function EliminarDeNominasActivas(CodProductor As String,
                                         TipoProductor As String,
                                         Optional cn As SqlConnection = Nothing,
                                         Optional trans As SqlTransaction = Nothing) As Integer

        Dim eliminados As Integer = 0

        Dim lista As List(Of NominaActiva)

        lista = ObtenerNominasActivas(CodProductor, TipoProductor)

        For Each n As NominaActiva In lista

            If EliminarDeNomina(n.NumNomina,
                            CodProductor,
                            TipoProductor,
                            cn,
                            trans) Then

                eliminados += 1

            End If

        Next

        Return eliminados

    End Function

    Public Function EliminarDeNomina(NumNomina As Integer,
                                 CodProductor As String,
                                 TipoProductor As String,
                                 Optional cn As SqlConnection = Nothing,
                                 Optional trans As SqlTransaction = Nothing) As Boolean

        Dim conexionLocal As Boolean = False

        Try

            If cn Is Nothing Then
                cn = New SqlConnection(Conexion)
                cn.Open()
                conexionLocal = True
            End If

            Dim sql As String =
        "DELETE FROM Detalle_Nomina
          WHERE NumNomina=@NumNomina
            AND CodProductor=@CodProductor
            AND TipoProductor=@TipoProductor"

            Using cmd As New SqlCommand(sql, cn)

                If trans IsNot Nothing Then
                    cmd.Transaction = trans
                End If

                cmd.Parameters.AddWithValue("@NumNomina", NumNomina)
                cmd.Parameters.AddWithValue("@CodProductor", CodProductor)
                cmd.Parameters.AddWithValue("@TipoProductor", TipoProductor)

                Return cmd.ExecuteNonQuery() > 0

            End Using

        Finally

            If conexionLocal Then
                cn.Close()
                cn.Dispose()
            End If

        End Try

    End Function

    Public Function TieneNominasActivas(CodProductor As String,
                                    TipoProductor As String) As Boolean

        Return ObtenerNominasActivas(CodProductor, TipoProductor).Count > 0

    End Function

    Public Function ObtenerDetalleNominasActivas(CodProductor As String,
                                             TipoProductor As String) As String

        Dim sb As New System.Text.StringBuilder

        Dim lista As List(Of NominaActiva) =
    ObtenerNominasActivas(CodProductor, TipoProductor)

        For Each n As NominaActiva In lista

            sb.AppendLine("Planilla : " & n.NumNomina)
            sb.AppendLine("Tipo     : " & n.CodTipoNomina)
            sb.AppendLine("Periodo  : " &
                      Format(n.FechaInicial, "dd/MM/yyyy") &
                      " al " &
                      Format(n.FechaFinal, "dd/MM/yyyy"))

            sb.AppendLine()

        Next

        Return sb.ToString()

    End Function

    Public Function ObtenerNominasActivas(CodProductor As String,
                                      TipoProductor As String) As List(Of NominaActiva)

        Dim lista As New List(Of NominaActiva)

        Using cn As New SqlConnection(Conexion)

            cn.Open()

            Dim sql As String =
        "SELECT DISTINCT
                N.NumPlanilla,
                N.CodTipoNomina,
                N.FechaInicial,
                N.FechaFinal
         FROM Nomina N
              INNER JOIN Detalle_Nomina D
                    ON N.NumPlanilla=D.NumNomina
         WHERE
                D.CodProductor=@Cod
            AND D.TipoProductor=@Tipo
            AND N.Activo=1
         ORDER BY
                N.FechaInicial"

            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@Cod", CodProductor)
                cmd.Parameters.AddWithValue("@Tipo", TipoProductor)

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()

                        Dim n As New NominaActiva

                        n.NumNomina = CInt(dr("NumPlanilla"))
                        n.CodTipoNomina = dr("CodTipoNomina").ToString

                        If Not IsDBNull(dr("FechaInicial")) Then
                            n.FechaInicial = CDate(dr("FechaInicial"))
                        End If

                        If Not IsDBNull(dr("FechaFinal")) Then
                            n.FechaFinal = CDate(dr("FechaFinal"))
                        End If

                        lista.Add(n)

                    End While

                End Using

            End Using

        End Using

        Return lista

    End Function


    Private Sub RegistrarError(ByVal b As Beneficiario, Proceso As String, ByVal ex As Exception)

        Dim Ruta As String = Path.Combine(Application.StartupPath, "ErroresImportacionBeneficiarios.txt")

        Using sw As New StreamWriter(Ruta, True, Encoding.UTF8)

            sw.WriteLine("===================================================")
            sw.WriteLine("Fecha : " & Now.ToString("dd/MM/yyyy HH:mm:ss"))
            sw.WriteLine("Codigo: " & b.Codigo)
            sw.WriteLine("Nombre: " & b.Nombre)
            sw.WriteLine("Proceso : " & Proceso)
            sw.WriteLine("")

            sw.WriteLine("Mensaje:")
            sw.WriteLine(ex.Message)

            sw.WriteLine("")
            'sw.WriteLine("Detalle:")
            'sw.WriteLine(ex.ToString)

            sw.WriteLine("===================================================")
            sw.WriteLine()

        End Using

    End Sub


    Public Sub Guardar(b As Beneficiario)
        Dim proceso As String = ""

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Using trans As SqlTransaction = cn.BeginTransaction()

                Try
                    proceso = "Guardar Beneficiario"
                    GuardarBeneficiario(b, cn, trans)
                    proceso = "Guardar Cliete"
                    GestionarCliente(b, cn, trans)
                    proceso = "Guardar Proveedor"
                    GestionarProveedor(b, cn, trans)
                    proceso = "Guardar Productor"
                    GestionarProductor(b, cn, trans)
                    proceso = "Guardar Transportista"
                    GestionarTransportista(b, cn, trans)
                    'GestionarEmpleado(b, cn, trans)

                    trans.Commit()

                Catch ex As Exception
                    RegistrarError(b, proceso, ex)
                    trans.Rollback()
                    Throw
                End Try

            End Using
        End Using

    End Sub
    Private Sub GestionarTransportista(b As Beneficiario,
                                   cn As SqlConnection,
                                   trans As SqlTransaction)

        Dim sqlExiste As String = "
        SELECT COUNT(*) 
        FROM Conductor 
        WHERE Codigo=@Cod"

        Using cmdExiste As New SqlCommand(sqlExiste, cn, trans)

            cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)
            Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

            If b.EsTransportista Then

                If existe = 0 Then

                    Dim sqlInsert As String = "
                INSERT INTO Conductor
                (Codigo,Nombre,Cedula,Licencia,
                 Activo,ListaNegra,RazonListaNegra,
                 Cuenta_Contable,Cuenta_Banco,
                 Precio,Evacuaciones)
                VALUES
                (@Cod,@Nom,@Ced,@Lic,
                 1,@ListaNegra,@Razon,
                 @Cuenta,@Banco,
                 @Precio,@Evacuaciones)"

                    Using cmd As New SqlCommand(sqlInsert, cn, trans)

                        cmd.Parameters.AddWithValue("@Cod", If(String.IsNullOrEmpty(b.Codigo), DBNull.Value, b.Codigo))
                        cmd.Parameters.AddWithValue("@Nom", If(String.IsNullOrEmpty(b.Nombre & " " & b.Apellido), DBNull.Value, b.Nombre & " " & b.Apellido))
                        cmd.Parameters.AddWithValue("@Ced", b.Cedula).Value = If(String.IsNullOrEmpty(b.Cedula), DBNull.Value, b.Cedula)
                        cmd.Parameters.Add("@Lic", SqlDbType.VarChar, 20).Value = If(String.IsNullOrEmpty(b.Licencia), DBNull.Value, b.Licencia)
                        cmd.Parameters.AddWithValue("@ListaNegra", b.ListaNegra).Value = If(String.IsNullOrEmpty(b.ListaNegra), DBNull.Value, b.ListaNegra)
                        cmd.Parameters.AddWithValue("@Razon", b.RazonListaNegra).Value = If(String.IsNullOrEmpty(b.RazonListaNegra), DBNull.Value, b.RazonListaNegra)
                        cmd.Parameters.AddWithValue("@Cuenta", b.CuentaContable).Value = If(String.IsNullOrEmpty(b.CuentaContable), DBNull.Value, b.CuentaContable)
                        cmd.Parameters.AddWithValue("@Banco", b.CuentaBanco).Value = If(String.IsNullOrEmpty(b.CuentaBanco), DBNull.Value, b.CuentaBanco)
                        cmd.Parameters.AddWithValue("@Precio", b.Precio).Value = If(String.IsNullOrEmpty(b.Precio), DBNull.Value, b.Precio)
                        cmd.Parameters.AddWithValue("@Evacuaciones", b.Evacuaciones).Value = If(String.IsNullOrEmpty(b.Evacuaciones), DBNull.Value, b.Evacuaciones)

                        cmd.ExecuteNonQuery()
                    End Using

                Else

                    Dim sqlUpdate As String = "
                UPDATE Conductor SET
                    Nombre=@Nom,
                    Cedula=@Ced,
                    Licencia=@Lic,
                    Activo=1,
                    ListaNegra=@ListaNegra,
                    RazonListaNegra=@Razon,
                    Cuenta_Contable=@Cuenta,
                    Cuenta_Banco=@Banco,
                    Precio=@Precio,
                    Evacuaciones=@Evacuaciones
                WHERE Codigo=@Cod"

                    Using cmd As New SqlCommand(sqlUpdate, cn, trans)

                        cmd.Parameters.AddWithValue("@Cod", If(String.IsNullOrEmpty(b.Codigo), DBNull.Value, b.Codigo))
                        cmd.Parameters.AddWithValue("@Nom", If(String.IsNullOrEmpty(b.Nombre & " " & b.Apellido), DBNull.Value, b.Nombre & " " & b.Apellido))
                        cmd.Parameters.AddWithValue("@Ced", If(String.IsNullOrEmpty(b.Cedula), DBNull.Value, b.Cedula))
                        cmd.Parameters.AddWithValue("@Lic", If(String.IsNullOrEmpty(b.Licencia), DBNull.Value, b.Licencia))
                        cmd.Parameters.AddWithValue("@ListaNegra", If(String.IsNullOrEmpty(b.ListaNegra), DBNull.Value, b.ListaNegra))
                        cmd.Parameters.AddWithValue("@Razon", If(String.IsNullOrEmpty(b.RazonListaNegra), DBNull.Value, b.RazonListaNegra))
                        cmd.Parameters.AddWithValue("@Cuenta", If(String.IsNullOrEmpty(b.CuentaContable), DBNull.Value, b.CuentaContable))
                        cmd.Parameters.AddWithValue("@Banco", If(String.IsNullOrEmpty(b.CuentaBanco), DBNull.Value, b.CuentaBanco))
                        cmd.Parameters.AddWithValue("@Precio", If(String.IsNullOrEmpty(b.Precio), DBNull.Value, b.Precio))
                        cmd.Parameters.AddWithValue("@Evacuaciones", If(String.IsNullOrEmpty(b.Evacuaciones), DBNull.Value, b.Evacuaciones))

                        cmd.ExecuteNonQuery()
                    End Using

                End If

            ElseIf existe > 0 Then

                Dim cmd As New SqlCommand("
                UPDATE Conductor 
                SET Activo=0 
                WHERE Codigo=@Cod",
                cn, trans)

                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                cmd.ExecuteNonQuery()

            End If

        End Using

    End Sub


    'Private Sub GestionarTransportista(b As Beneficiario,
    '                               cn As SqlConnection,
    '                               trans As SqlTransaction)

    '    Dim sqlExiste As String = "
    '    SELECT COUNT(*) 
    '    FROM Transportista 
    '    WHERE CodigoTransportista=@Cod"

    '    Using cmdExiste As New SqlCommand(sqlExiste, cn, trans)

    '        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)

    '        Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

    '        If b.EsTransportista Then

    '            If existe = 0 Then

    '                Dim sqlInsert As String = "
    '            INSERT INTO Transportista
    '            (CodigoTransportista,
    '             NombreTransportista,
    '             TelefonoTransportista,
    '             DireccionTransportista,
    '             CuentaContable,
    '             Activo)
    '            VALUES
    '            (@Cod,@Nom,@Tel,@Dir,@Cuenta,1)"

    '                Using cmd As New SqlCommand(sqlInsert, cn, trans)

    '                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
    '                    cmd.Parameters.AddWithValue("@Nom", b.Nombre)
    '                    cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
    '                    cmd.Parameters.AddWithValue("@Dir", b.Direccion)
    '                    cmd.Parameters.AddWithValue("@Cuenta", b.CuentaTransporte)

    '                    cmd.ExecuteNonQuery()

    '                End Using

    '            Else

    '                Dim sqlUpdate As String = "
    '            UPDATE Transportista SET
    '                NombreTransportista=@Nom,
    '                TelefonoTransportista=@Tel,
    '                DireccionTransportista=@Dir,
    '                CuentaContable=@Cuenta,
    '                Activo=1
    '            WHERE CodigoTransportista=@Cod"

    '                Using cmd As New SqlCommand(sqlUpdate, cn, trans)

    '                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
    '                    cmd.Parameters.AddWithValue("@Nom", b.Nombre)
    '                    cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
    '                    cmd.Parameters.AddWithValue("@Dir", b.Direccion)
    '                    cmd.Parameters.AddWithValue("@Cuenta", b.CuentaTransporte)

    '                    cmd.ExecuteNonQuery()

    '                End Using

    '            End If

    '        ElseIf existe > 0 Then

    '            Dim cmd As New SqlCommand("
    '            UPDATE Transportista 
    '            SET Activo=0 
    '            WHERE CodigoTransportista=@Cod",
    '            cn, trans)

    '            cmd.Parameters.AddWithValue("@Cod", b.Codigo)
    '            cmd.ExecuteNonQuery()

    '        End If

    '    End Using

    'End Sub


    Public Sub CargarBeneficiariosEnCombo(cbo As C1Combo)

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Dim sql As String = "
            SELECT Codigo_Beneficiario,
                   Nombre_Beneficiario + ' ' + Apellido_Beneficiario AS NombreCompleto
            FROM Beneficiario
            ORDER BY Nombre_Beneficiario, Apellido_Beneficiario"

            Using cmd As New SqlCommand(sql, cn)
                cmd.CommandType = CommandType.Text

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    Dim dt As New DataTable()
                    dt.Load(dr)

                    cbo.DataSource = dt
                    cbo.DisplayMember = "Codigo_Beneficiario"
                    cbo.ValueMember = "Codigo_Beneficiario"

                End Using
            End Using
        End Using

    End Sub

    Private Sub GuardarBeneficiario(b As Beneficiario, cn As SqlConnection, trans As SqlTransaction)

        Dim sqlExiste As String = "SELECT COUNT(*) FROM Beneficiario WHERE Codigo_Beneficiario=@Cod"

        Dim cmdExiste As New SqlCommand(sqlExiste, cn, trans)
        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)

        Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

        If existe = 0 Then

            Dim sqlInsert As String = "
        INSERT INTO Beneficiario
        (Codigo_Beneficiario,Nombre_Beneficiario,Apellido_Beneficiario,
         FechaAdmision,FechaNacimiento,Direccion,
         Sexo,Telefonos,EstadoCivil,Cedula,RUC,Foto,Activo)
        VALUES
        (@Cod,@Nom,@Ape,@FAdm,@FNac,@Dir,
         @Sexo,@Tel,@EstCivil,@Ced,@Ruc,@Foto,1)"

            Dim cmd As New SqlCommand(sqlInsert, cn, trans)
            AgregarParametrosBeneficiario(cmd, b)
            cmd.ExecuteNonQuery()

        Else

            Dim sqlUpdate As String = "
        UPDATE Beneficiario SET
            Nombre_Beneficiario=@Nom,
            Apellido_Beneficiario=@Ape,
            FechaAdmision=@FAdm,
            FechaNacimiento=@FNac,
            Direccion=@Dir,
            Sexo=@Sexo,
            Telefonos=@Tel,
            EstadoCivil=@EstCivil,
            Cedula=@Ced,
            RUC=@Ruc,
            Foto=@Foto,
            Activo=@Activo
        WHERE Codigo_Beneficiario=@Cod"

            Dim cmd As New SqlCommand(sqlUpdate, cn, trans)
            AgregarParametrosBeneficiario(cmd, b)
            cmd.ExecuteNonQuery()

        End If

    End Sub
    Private Sub GestionarCliente(b As Beneficiario, cn As SqlConnection, trans As SqlTransaction)

        Dim sqlExiste As String = "SELECT COUNT(*) FROM Clientes WHERE Cod_Cliente=@Cod"

        Dim cmdExiste As New SqlCommand(sqlExiste, cn, trans)
        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)

        Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

        If b.EsCliente Then

            If existe = 0 Then

                Dim sqlInsert As String = "
                                            INSERT INTO Clientes
                                            (Cod_Cliente,
                                             Nombre_Cliente,
                                             Apellido_Cliente,
                                             Direccion_Cliente,
                                             Telefono,
                                             Cedula,
                                             Departamento,
                                             Municipio,
                                             Endoso,
                                             Cod_Cuenta_Cliente,
                                             Limite_Credito,
                                             DiasCredito,
                                             MonedaCredito,
                                             BloquearPorLimiteCredito,
                                             Efectivo,
                                             Cod_Cuenta_Banco,
                                             CausaIva,Credito_Disponible,
                                             Activo)
                                            VALUES
                                            (@Cod,@Nom,@Ape,@Dir,@Tel,@Ced,
                                             @Dept,@Mun,@End,@Cta,
                                             @Limite,@Dias,@Moneda,@Bloquear,
                                             @Efectivo,@CtaBanco,@CausaIva,@CreditoDisponible, 1)"


                Dim cmd As New SqlCommand(sqlInsert, cn, trans)
                cmd.Parameters.AddWithValue("@Cod", If(String.IsNullOrEmpty(b.Codigo), DBNull.Value, b.Codigo))
                cmd.Parameters.AddWithValue("@Nom", If(String.IsNullOrEmpty(b.Nombre), DBNull.Value, b.Nombre))
                cmd.Parameters.AddWithValue("@Ape", If(String.IsNullOrEmpty(b.Apellido), DBNull.Value, b.Apellido))
                cmd.Parameters.AddWithValue("@Dir", If(String.IsNullOrEmpty(b.Direccion), DBNull.Value, b.Direccion))
                cmd.Parameters.AddWithValue("@Tel", If(String.IsNullOrEmpty(b.Telefonos), DBNull.Value, b.Telefonos))
                cmd.Parameters.AddWithValue("@Ced", If(String.IsNullOrEmpty(b.Cedula), DBNull.Value, b.Cedula))
                cmd.Parameters.AddWithValue("@Dept", If(String.IsNullOrEmpty(b.Departamento), DBNull.Value, b.Departamento))
                cmd.Parameters.AddWithValue("@Mun", If(String.IsNullOrEmpty(b.Municipio), DBNull.Value, b.Municipio))
                cmd.Parameters.AddWithValue("@End", If(String.IsNullOrEmpty(b.Endoso), DBNull.Value, b.Endoso))
                cmd.Parameters.AddWithValue("@Cta", If(String.IsNullOrEmpty(b.CodCuentaCliente), DBNull.Value, b.CodCuentaCliente))
                cmd.Parameters.AddWithValue("@Limite", If(String.IsNullOrEmpty(b.LimiteCredito), DBNull.Value, b.LimiteCredito))
                cmd.Parameters.AddWithValue("@Dias", If(String.IsNullOrEmpty(b.DiasCredito), DBNull.Value, b.DiasCredito))
                cmd.Parameters.AddWithValue("@Moneda", If(String.IsNullOrEmpty(b.MonedaCredito), DBNull.Value, b.MonedaCredito))
                cmd.Parameters.AddWithValue("@Bloquear", If(String.IsNullOrEmpty(b.BloquearPorLimiteCredito), DBNull.Value, b.BloquearPorLimiteCredito))
                cmd.Parameters.AddWithValue("@Efectivo", If(String.IsNullOrEmpty(b.Efectivo), DBNull.Value, b.Efectivo))
                cmd.Parameters.AddWithValue("@CtaBanco", If(String.IsNullOrEmpty(b.CuentaBanco), DBNull.Value, b.CuentaBanco))
                cmd.Parameters.AddWithValue("@CausaIva", If(String.IsNullOrEmpty(b.CausaIva), DBNull.Value, b.CausaIva))
                cmd.Parameters.AddWithValue("@CreditoDisponible", If(String.IsNullOrEmpty(b.CreditoDisponible), DBNull.Value, b.CreditoDisponible))
                cmd.ExecuteNonQuery()

            Else

                Dim sqlUpdate As String = "
                                            UPDATE Clientes SET
                                                Nombre_Cliente=@Nom,
                                                Apellido_Cliente=@Ape,
                                                Direccion_Cliente=@Dir,
                                                Telefono=@Tel,
                                                Cedula=@Ced,
                                                Departamento=@Dept,
                                                Municipio=@Mun,
                                                Endoso=@End,
                                                Cod_Cuenta_Cliente=@Cta,
                                                Limite_Credito=@Limite,
                                                DiasCredito=@Dias,
                                                MonedaCredito=@Moneda,
                                                BloquearPorLimiteCredito=@Bloquear,
                                                Efectivo=@Efectivo,
                                                Cod_Cuenta_Banco=@CtaBanco, CausaIva=@CausaIva, Credito_Disponible=@CreditoDisponible,
                                                Activo=1
                                            WHERE Cod_Cliente=@Cod"


                Dim cmd As New SqlCommand(sqlUpdate, cn, trans)
                cmd.Parameters.AddWithValue("@Cod", If(String.IsNullOrEmpty(b.Codigo), DBNull.Value, b.Codigo))
                cmd.Parameters.AddWithValue("@Nom", If(String.IsNullOrEmpty(b.Nombre), DBNull.Value, b.Nombre))
                cmd.Parameters.AddWithValue("@Ape", If(String.IsNullOrEmpty(b.Apellido), DBNull.Value, b.Apellido))
                cmd.Parameters.AddWithValue("@Dir", If(String.IsNullOrEmpty(b.Direccion), DBNull.Value, b.Direccion))
                cmd.Parameters.AddWithValue("@Tel", If(String.IsNullOrEmpty(b.Telefonos), DBNull.Value, b.Telefonos))
                cmd.Parameters.AddWithValue("@Ced", If(String.IsNullOrEmpty(b.Cedula), DBNull.Value, b.Cedula))
                cmd.Parameters.AddWithValue("@Dept", If(String.IsNullOrEmpty(b.Departamento), DBNull.Value, b.Departamento))
                cmd.Parameters.AddWithValue("@Mun", If(String.IsNullOrEmpty(b.Municipio), DBNull.Value, b.Municipio))
                cmd.Parameters.AddWithValue("@End", If(String.IsNullOrEmpty(b.Endoso), DBNull.Value, b.Endoso))
                cmd.Parameters.AddWithValue("@Cta", If(String.IsNullOrEmpty(b.CodCuentaCliente), DBNull.Value, b.CodCuentaCliente))
                cmd.Parameters.AddWithValue("@Limite", If(String.IsNullOrEmpty(b.LimiteCredito), DBNull.Value, b.LimiteCredito))
                cmd.Parameters.AddWithValue("@Dias", If(String.IsNullOrEmpty(b.DiasCredito), DBNull.Value, b.DiasCredito))
                cmd.Parameters.AddWithValue("@Moneda", If(String.IsNullOrEmpty(b.MonedaCredito), DBNull.Value, b.MonedaCredito))
                cmd.Parameters.AddWithValue("@Bloquear", If(String.IsNullOrEmpty(b.BloquearPorLimiteCredito), DBNull.Value, b.BloquearPorLimiteCredito))
                cmd.Parameters.AddWithValue("@Efectivo", If(String.IsNullOrEmpty(b.Efectivo), DBNull.Value, b.Efectivo))
                cmd.Parameters.AddWithValue("@CtaBanco", If(String.IsNullOrEmpty(b.CuentaBanco), DBNull.Value, b.CuentaBanco))
                cmd.Parameters.AddWithValue("@CausaIva", If(String.IsNullOrEmpty(b.CausaIva), DBNull.Value, b.CausaIva))
                cmd.Parameters.AddWithValue("@CreditoDisponible", If(String.IsNullOrEmpty(b.CreditoDisponible), DBNull.Value, b.CreditoDisponible))
                cmd.ExecuteNonQuery()
            End If

        ElseIf existe > 0 Then

            Dim cmd As New SqlCommand("UPDATE Clientes SET Activo=0 WHERE Cod_Cliente=@Cod", cn, trans)
            cmd.Parameters.AddWithValue("@Cod", b.Codigo)
            cmd.ExecuteNonQuery()

        End If

    End Sub
    Private Sub GestionarProveedor(b As Beneficiario, cn As SqlConnection, trans As SqlTransaction)

        Dim sqlExiste As String = "SELECT COUNT(*) FROM Proveedor WHERE Cod_Proveedor=@Cod"

        Dim cmdExiste As New SqlCommand(sqlExiste, cn, trans)
        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)

        Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

        If b.EsProveedor Then

            If existe = 0 Then

                Dim sqlInsert As String = "
            INSERT INTO Proveedor
            (Cod_Proveedor,Nombre_Proveedor,Apellido_Proveedor,
             Direccion_Proveedor,Telefono,RUC,Activo)
            VALUES
            (@Cod,@Nom,@Ape,@Dir,@Tel,@Ruc,1)"

                Dim cmd As New SqlCommand(sqlInsert, cn, trans)
                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                cmd.Parameters.AddWithValue("@Ruc", b.RUC)
                cmd.ExecuteNonQuery()

            Else

                Dim sqlUpdate As String = "
            UPDATE Proveedor SET
                Nombre_Proveedor=@Nom,
                Apellido_Proveedor=@Ape,
                Direccion_Proveedor=@Dir,
                Telefono=@Tel,
                RUC=@Ruc,
                Activo=1
            WHERE Cod_Proveedor=@Cod"

                Dim cmd As New SqlCommand(sqlUpdate, cn, trans)
                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                cmd.Parameters.AddWithValue("@Ruc", b.RUC)
                cmd.ExecuteNonQuery()

            End If

        ElseIf existe > 0 Then

            Dim cmd As New SqlCommand("
            UPDATE Proveedor SET Activo=0 
            WHERE Cod_Proveedor=@Cod", cn, trans)

            cmd.Parameters.AddWithValue("@Cod", b.Codigo)
            cmd.ExecuteNonQuery()

        End If

    End Sub
    Private Sub GestionarProductor(b As Beneficiario, cn As SqlConnection, trans As SqlTransaction)

        GestionarTipoProductor(b, "Productor", b.EsProductor, cn, trans)
        GestionarTipoProductor(b, "Socio", b.EsSocio, cn, trans)
        GestionarTipoProductor(b, "PreSocio", b.EsPreSocio, cn, trans)

    End Sub
    Private Sub GestionarTipoProductor(b As Beneficiario,
                                   tipo As String,
                                   activoCheck As Boolean,
                                   cn As SqlConnection,
                                   trans As SqlTransaction)

        '-------------------------------------------------------
        ' Obtener si el registro existe
        '-------------------------------------------------------
        Dim sqlExiste As String =
    "SELECT Activo
       FROM Productor
      WHERE CodProductor=@Cod
        AND TipoProductor=@Tipo"

        Dim existe As Boolean = False
        Dim activoBD As Boolean = False

        Using cmd As New SqlCommand(sqlExiste, cn, trans)

            cmd.Parameters.AddWithValue("@Cod", b.Codigo)
            cmd.Parameters.AddWithValue("@Tipo", tipo)

            Dim r = cmd.ExecuteScalar()

            If r IsNot Nothing AndAlso r IsNot DBNull.Value Then
                existe = True
                activoBD = CBool(r)
            End If

        End Using


        '-------------------------------------------------------
        ' Si el usuario quitó el check
        '-------------------------------------------------------
        If Not activoCheck Then

            If existe AndAlso activoBD Then

                Dim sql As String =
            "UPDATE Productor
                SET Activo=0
              WHERE CodProductor=@Cod
                AND TipoProductor=@Tipo"

                Using cmd As New SqlCommand(sql, cn, trans)

                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                    cmd.Parameters.AddWithValue("@Tipo", tipo)

                    cmd.ExecuteNonQuery()

                End Using

            End If

            Exit Sub

        End If


        '-------------------------------------------------------
        ' Obtener datos según el tipo
        '-------------------------------------------------------

        Dim codTipoNomina As Object = DBNull.Value
        Dim precio As Object = DBNull.Value
        Dim pagarCheque As Boolean = False
        Dim cuentaPagarBanco As Object = DBNull.Value


        Select Case tipo

            Case "Productor"

                If Not String.IsNullOrWhiteSpace(b.CodTipoNominaProductor) Then
                    codTipoNomina = b.CodTipoNominaProductor
                End If

                precio = If(b.PrecioProductor > 0, b.PrecioProductor, 0)

                If b.TipoPagoProductor = "CHEQUE" Then
                    pagarCheque = True
                    cuentaPagarBanco = DBNull.Value
                ElseIf Not String.IsNullOrWhiteSpace(b.TipoPagoProductor) Then
                    cuentaPagarBanco = b.TipoPagoProductor
                End If

            Case "Socio"

                If Not String.IsNullOrWhiteSpace(b.CodTipoNominaSocio) Then
                    codTipoNomina = b.CodTipoNominaSocio
                End If

                precio = If(b.PrecioSocio > 0, b.PrecioSocio, 0)

                If b.TipoPagoSocio = "CHEQUE" Then
                    pagarCheque = True
                    cuentaPagarBanco = DBNull.Value
                ElseIf Not String.IsNullOrWhiteSpace(b.TipoPagoSocio) Then
                    cuentaPagarBanco = b.TipoPagoSocio
                End If

            Case "PreSocio"

                If Not String.IsNullOrWhiteSpace(b.CodTipoNominaPreSocio) Then
                    codTipoNomina = b.CodTipoNominaPreSocio
                End If

                precio = If(b.PrecioPreSocio > 0, b.PrecioPreSocio, 0)

                If b.TipoPagoPreSocio = "CHEQUE" Then
                    pagarCheque = True
                    cuentaPagarBanco = DBNull.Value
                ElseIf Not String.IsNullOrWhiteSpace(b.TipoPagoPreSocio) Then
                    cuentaPagarBanco = b.TipoPagoPreSocio
                End If

        End Select


        '-------------------------------------------------------
        ' INSERT
        '-------------------------------------------------------
        If Not existe Then

            Dim sql As String =
        "INSERT INTO Productor
        (
            CodProductor,
            TipoProductor,
            NombreProductor,
            ApellidoProductor,
            FechaAdmision,
            FechaNacimiento,
            DireccionProductor,
            Sexo,
            Telefonos,
            EstadoCivil,
            Cedula,
            RUC,
            Activo,
            CodTipoNomina,
            Precio,
            PagarCheque,
            CuentaPagarBanco
        )
        VALUES
        (
            @Cod,@Tipo,@Nom,@Ape,
            @FAdm,@FNac,@Dir,@Sexo,
            @Tel,@EstadoCivil,@Ced,@Ruc,
            1,@CodTipoNomina,@Precio,
            @PagarCheque,@CuentaBanco
        )"

            Using cmd As New SqlCommand(sql, cn, trans)

                LlenarParametrosProductor(cmd, b, tipo, codTipoNomina,
                                      precio, pagarCheque, cuentaPagarBanco)

                cmd.ExecuteNonQuery()

            End Using

        Else

            '---------------------------------------------------
            ' UPDATE
            '---------------------------------------------------

            Dim sql As String =
        "UPDATE Productor
            SET NombreProductor=@Nom,
                ApellidoProductor=@Ape,
                FechaAdmision=@FAdm,
                FechaNacimiento=@FNac,
                DireccionProductor=@Dir,
                Sexo=@Sexo,
                Telefonos=@Tel,
                EstadoCivil=@EstadoCivil,
                Cedula=@Ced,
                RUC=@Ruc,
                Activo=1,
                CodTipoNomina=@CodTipoNomina,
                Precio=@Precio,
                PagarCheque=@PagarCheque,
                CuentaPagarBanco=@CuentaBanco
        WHERE CodProductor=@Cod
          AND TipoProductor=@Tipo"

            Using cmd As New SqlCommand(sql, cn, trans)

                LlenarParametrosProductor(cmd, b, tipo, codTipoNomina,
                                      precio, pagarCheque, cuentaPagarBanco)

                cmd.ExecuteNonQuery()

            End Using

        End If

    End Sub
    Private Sub LlenarParametrosProductor(cmd As SqlCommand,
                                      b As Beneficiario,
                                      tipo As String,
                                      codTipoNomina As Object,
                                      precio As Object,
                                      pagarCheque As Boolean,
                                      cuentaBanco As Object)

        cmd.Parameters.AddWithValue("@Cod", b.Codigo)
        cmd.Parameters.AddWithValue("@Tipo", tipo)
        cmd.Parameters.AddWithValue("@Nom", b.Nombre)
        cmd.Parameters.AddWithValue("@Ape", b.Apellido)

        cmd.Parameters.AddWithValue("@FAdm",
        If(b.Fecha_Admision <= New Date(1753, 1, 1),
           CType(DBNull.Value, Object),
           b.Fecha_Admision))

        cmd.Parameters.AddWithValue("@FNac",
        If(b.Fecha_Nacimiento <= New Date(1753, 1, 1),
           CType(DBNull.Value, Object),
           b.Fecha_Nacimiento))

        cmd.Parameters.AddWithValue("@Dir", b.Direccion)
        cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
        cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
        cmd.Parameters.AddWithValue("@EstadoCivil", b.Estado_Civil)
        cmd.Parameters.AddWithValue("@Ced", b.Cedula)
        cmd.Parameters.AddWithValue("@Ruc", b.RUC)

        cmd.Parameters.AddWithValue("@CodTipoNomina", codTipoNomina)
        cmd.Parameters.AddWithValue("@Precio", precio)
        cmd.Parameters.AddWithValue("@PagarCheque", pagarCheque)
        cmd.Parameters.AddWithValue("@CuentaBanco", cuentaBanco)

    End Sub


    '*********************CODIGO RETIRADO 31/07/2026************************************
    'Private Sub GestionarTipoProductor(b As Beneficiario,
    '                               tipo As String,
    '                               activoCheck As Boolean,
    '                               cn As SqlConnection,
    '                               trans As SqlTransaction)

    '    Dim sqlExiste As String = "
    '    SELECT COUNT(*) 
    '    FROM Productor 
    '    WHERE CodProductor=@Cod 
    '    AND TipoProductor=@Tipo"



    '    Using cmdExiste As New SqlCommand(sqlExiste, cn, trans)

    '        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)
    '        cmdExiste.Parameters.AddWithValue("@Tipo", tipo)

    '        Dim CodTipoNomina As String = ""
    '        Dim PagarxCheque As Integer = 0, CuentaBanco As String = ""
    '        Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

    '        If b.Codigo = "5284" Then
    '            b.Codigo = "5284"
    '        End If


    '        If b.TipoPagoProductor = "CHEQUE" Then
    '            PagarxCheque = 1
    '            CuentaBanco = "0"
    '        Else
    '            PagarxCheque = 0
    '            CuentaBanco = b.TipoPagoProductor
    '        End If

    '        Select Case tipo
    '            Case "Productor"
    '                CodTipoNomina = b.CodTipoNominaProductor
    '            Case "Socio"
    '                CodTipoNomina = b.CodTipoNominaSocio
    '            Case "PreSocio"
    '                CodTipoNomina = b.CodTipoNominaPreSocio
    '        End Select


    '        If existe = 0 Then

    '            If activoCheck Then

    '                Dim sqlInsert As String = "
    '            INSERT INTO Productor
    '            (CodProductor,TipoProductor,
    '             NombreProductor,ApellidoProductor,
    '             FechaAdmision,FechaNacimiento,
    '             DireccionProductor,Sexo,
    '             Telefonos,EstadoCivil,
    '             Cedula,RUC,Activo,CodTipoNomina, Precio, PagarCheque, CuentaPagarBanco)
    '            VALUES
    '            (@Cod,@Tipo,
    '             @Nom,@Ape,
    '             @FAdm,@FNac,
    '             @Dir,@Sexo,
    '             @Tel,@EstCivil,
    '             @Ced,@Ruc,1,@CodTipoNomina, @Precio,@PagaCheque,@CuentaPagaBanco)"

    '                Dim cmd As New SqlCommand(sqlInsert, cn, trans)

    '                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
    '                cmd.Parameters.AddWithValue("@Tipo", tipo)
    '                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
    '                cmd.Parameters.AddWithValue("@Ape", b.Apellido)

    '                If b.Fecha_Admision <= New Date(1753, 1, 1) Then
    '                    cmd.Parameters.AddWithValue("@FAdm", DBNull.Value)
    '                Else
    '                    cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
    '                End If

    '                If b.Fecha_Nacimiento <= New Date(1753, 1, 1) Then
    '                    cmd.Parameters.AddWithValue("@FNac", DBNull.Value)
    '                Else
    '                    cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
    '                End If

    '                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
    '                cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
    '                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
    '                cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
    '                cmd.Parameters.AddWithValue("@Ced", b.Cedula)
    '                cmd.Parameters.AddWithValue("@Ruc", b.RUC)
    '                cmd.Parameters.AddWithValue("@CodTipoNomina", CodTipoNomina)
    '                cmd.Parameters.AddWithValue("@Precio", b.PrecioProductor)
    '                cmd.Parameters.AddWithValue("@PagaCheque", PagarxCheque)
    '                cmd.Parameters.AddWithValue("@CuentaPagaBanco", CuentaBanco)

    '                cmd.ExecuteNonQuery()

    '            End If

    '        Else

    '            Dim sqlUpdate As String = "
    '        UPDATE Productor SET
    '            NombreProductor=@Nom,
    '            ApellidoProductor=@Ape,
    '            FechaAdmision=@FAdm,
    '            FechaNacimiento=@FNac,
    '            DireccionProductor=@Dir,
    '            Sexo=@Sexo,
    '            Telefonos=@Tel,
    '            EstadoCivil=@EstCivil,
    '            Cedula=@Ced,
    '            RUC=@Ruc,
    '            Activo=@Activo, CodTipoNomina=@CodTipoNomina, Precio=@Precio, 
    '            PagarCheque=@PagaCheque, CuentaPagarBanco=@CuentaPagaBanco
    '        WHERE CodProductor=@Cod 
    '        AND TipoProductor=@Tipo"

    '            Dim cmd As New SqlCommand(sqlUpdate, cn, trans)

    '            cmd.Parameters.AddWithValue("@Cod", b.Codigo)
    '            cmd.Parameters.AddWithValue("@Tipo", tipo)
    '            cmd.Parameters.AddWithValue("@Nom", b.Nombre)
    '            cmd.Parameters.AddWithValue("@Ape", b.Apellido)

    '            If b.Fecha_Admision <= New Date(1753, 1, 1) Then
    '                cmd.Parameters.AddWithValue("@FAdm", DBNull.Value)
    '            Else
    '                cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
    '            End If

    '            If b.Fecha_Nacimiento <= New Date(1753, 1, 1) Then
    '                cmd.Parameters.AddWithValue("@FNac", DBNull.Value)
    '            Else
    '                cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
    '            End If
    '            cmd.Parameters.AddWithValue("@Dir", b.Direccion)
    '            cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
    '            cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
    '            cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
    '            cmd.Parameters.AddWithValue("@Ced", b.Cedula)
    '            cmd.Parameters.AddWithValue("@Ruc", b.RUC)
    '            cmd.Parameters.AddWithValue("@Activo", activoCheck)
    '            cmd.Parameters.AddWithValue("@CodTipoNomina", CodTipoNomina)
    '            cmd.Parameters.AddWithValue("@Precio", b.PrecioProductor)
    '            cmd.Parameters.AddWithValue("@PagaCheque", PagarxCheque)
    '            cmd.Parameters.AddWithValue("@CuentaPagaBanco", CuentaBanco)

    '            cmd.ExecuteNonQuery()

    '        End If

    '    End Using

    'End Sub


    Private Sub GestionarEmpleado(b As Beneficiario, cn As SqlConnection, trans As SqlTransaction)

        Dim sqlExiste As String = "
    SELECT TOP 1 CodEmpleado
    FROM Empleado
    WHERE CodEmpleado1=@Cod AND Activo=1
    ORDER BY CodEmpleado DESC"

        Dim cmdExiste As New SqlCommand(sqlExiste, cn, trans)
        cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)

        Dim idActivo = cmdExiste.ExecuteScalar()

        If b.EsEmpleado Then

            If idActivo Is Nothing Then

                Dim sqlInsert As String = "
            INSERT INTO Empleado
            (CodEmpleado1,Nombre1,Apellido1,
             NumCedula,Direccion,Sexo,Telefono,Activo)
            VALUES
            (@Cod,@Nom,@Ape,@Ced,@Dir,@Sexo,@Tel,1)"

                Dim cmd As New SqlCommand(sqlInsert, cn, trans)
                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                cmd.Parameters.AddWithValue("@Ced", b.Cedula)
                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                cmd.ExecuteNonQuery()

            Else

                Dim sqlUpdate As String = "
            UPDATE Empleado SET
                Nombre1=@Nom,
                Apellido1=@Ape,
                NumCedula=@Ced,
                Direccion=@Dir,
                Sexo=@Sexo,
                Telefono=@Tel
            WHERE CodEmpleado=@Id"

                Dim cmd As New SqlCommand(sqlUpdate, cn, trans)
                cmd.Parameters.AddWithValue("@Id", idActivo)
                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                cmd.Parameters.AddWithValue("@Ced", b.Cedula)
                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                cmd.ExecuteNonQuery()

            End If

        ElseIf idActivo IsNot Nothing Then

            Dim cmd As New SqlCommand("UPDATE Empleado SET Activo=0 WHERE CodEmpleado=@Id", cn, trans)
            cmd.Parameters.AddWithValue("@Id", idActivo)
            cmd.ExecuteNonQuery()

        End If

    End Sub

    Private Sub AgregarParametrosBeneficiario(cmd As SqlCommand, b As Beneficiario)

        cmd.Parameters.AddWithValue("@Cod", b.Codigo)
        cmd.Parameters.AddWithValue("@Nom", b.Nombre)
        cmd.Parameters.AddWithValue("@Ape", b.Apellido)

        If b.Fecha_Admision <= New Date(1753, 1, 1) Then
            cmd.Parameters.AddWithValue("@FAdm", Date.MinValue)
        Else
            cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
        End If

        If b.Fecha_Nacimiento <= New Date(1753, 1, 1) Then
            cmd.Parameters.AddWithValue("@FNac", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
        End If

        cmd.Parameters.AddWithValue("@Dir", b.Direccion)
        cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
        cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
        cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
        cmd.Parameters.AddWithValue("@Ced", b.Cedula)
        cmd.Parameters.AddWithValue("@Ruc", b.RUC)

        If b.Foto Is Nothing Then
            cmd.Parameters.AddWithValue("@Foto", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@Foto", b.Foto)
        End If

        cmd.Parameters.AddWithValue("@Activo", b.Activo)

    End Sub

    Public Function CargarBeneficiario(codigo As String) As Beneficiario

        Dim b As New Beneficiario()

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            '========================================
            ' 1. CARGAR DATOS PRINCIPALES
            '========================================
            Dim sql As String = "SELECT * FROM Beneficiario WHERE Codigo_Beneficiario=@Cod"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then

                        b.Codigo = dr("Codigo_Beneficiario").ToString()
                        b.Nombre = dr("Nombre_Beneficiario").ToString()
                        b.Apellido = dr("Apellido_Beneficiario").ToString()
                        b.Direccion = dr("Direccion").ToString()
                        b.Sexo = dr("Sexo").ToString()
                        b.Telefonos = dr("Telefonos").ToString()
                        b.Estado_Civil = dr("EstadoCivil").ToString()
                        b.Cedula = dr("Cedula").ToString()
                        b.RUC = dr("RUC").ToString()
                        b.Foto = dr("Foto").ToString()

                        If Not IsDBNull(dr("Activo")) Then
                            b.Activo = Convert.ToBoolean(dr("Activo"))
                        Else
                            b.Activo = False
                        End If

                        If Not IsDBNull(dr("FechaAdmision")) Then
                            b.Fecha_Admision = dr("FechaAdmision")
                        End If

                        If Not IsDBNull(dr("FechaNacimiento")) Then
                            b.Fecha_Nacimiento = dr("FechaNacimiento")
                        End If


                    Else
                        Return Nothing
                    End If

                End Using
            End Using

            '========================================
            ' 2. VERIFICAR SI ES CLIENTE
            '========================================
            b.EsCliente = ExisteRegistro(cn, "Clientes",
                                         "Cod_Cliente",
                                         codigo)
            If b.EsCliente = True Then
                CargarDatosCliente(b, cn)
            End If

            '========================================
            ' 3. VERIFICAR SI ES PROVEEDOR
            '========================================
            b.EsProveedor = ExisteRegistro(cn, "Proveedor",
                                           "Cod_Proveedor",
                                           codigo)
            If b.EsProveedor = True Then
                CargarDatosProveedor(b, cn)
            End If

            '========================================
            ' 4. VERIFICAR SI ES PRODUCTOR
            '========================================
            'CargarRolesProductor(cn, b)
            CargarDatosProductores(b, cn)

            Debug.Print("Productor : " & b.EsProductor)
            Debug.Print("Socio     : " & b.EsSocio)
            Debug.Print("PreSocio  : " & b.EsPreSocio)

            '========================================
            ' 5. VERIFICAR SI ES EMPLEADO ACTIVO
            '========================================
            'b.EsEmpleado = ExisteEmpleadoActivo(cn, codigo)


            '========================================
            ' 6. VERIFICAR SI ES EMPLEADO ACTIVO
            '========================================
            b.EsTransportista = ExisteRegistro(cn, "Conductor", "Codigo", codigo)

            '========================================
            ' 7. VERIFICAR TRANSPORTISTA
            '========================================
            If b.EsTransportista = True Then
                CargarDatosTransportista(b, cn)
            End If

        End Using

        Return b

    End Function
    Private Sub CargarDatosProductores(b As Beneficiario,
                                   cn As SqlConnection)

        'Inicializamos
        b.EsProductor = False
        b.EsSocio = False
        b.EsPreSocio = False

        Dim sql As String =
    "SELECT *
       FROM Productor
      WHERE CodProductor=@Cod"

        Using cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@Cod", b.Codigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()

                While dr.Read()

                    Dim tipo As String = dr("TipoProductor").ToString.Trim()
                    Dim activo As Boolean = CBool(dr("Activo"))

                    Select Case tipo

                    '=====================================================
                    ' PRODUCTOR
                    '=====================================================
                        Case "Productor"

                            b.EsProductor = activo

                            If activo Then

                                b.CodTipoNominaProductor = dr("CodTipoNomina").ToString


                                b.EscolaridadProductor = dr("CodEscolaridad").ToString
                                b.DepartamentoProductor = dr("CodDepartamentos").ToString
                                b.CooperatiaProductor = dr("CodCooperativa").ToString
                                b.RutaProductor = dr("CodRuta").ToString

                                b.CtasxCobrarProductor = dr("Cod_Cuenta_Cliente").ToString
                                b.CtasxPagarProductor = dr("Cod_Cuenta_Proveedor").ToString

                                b.CtaBancoProductor = dr("Cuenta_Banco").ToString
                                b.CtaIrProductor = dr("Cuenta_IR").ToString
                                b.CtaBolsaProductor = dr("Cuenta_Bolsa").ToString
                                b.CtaAnticipoProductor = dr("Cuenta_Anticipo").ToString
                                b.CtaTransporteProductor = dr("Cuenta_Transporte").ToString
                                b.CtaInseminacionProductor = dr("Cuenta_Inseminacion").ToString
                                b.CtaTrazabilidadProductor = dr("Cuenta_Trazabilidad").ToString
                                b.CtaVeterinariosProductor = dr("Cuenta_Veterinario").ToString
                                b.CtaFondosProductor = dr("Cuenta_Otras").ToString
                                b.CtaPlanillaProductor = dr("Cuenta_GastoPlanilla").ToString

                                If Not IsDBNull(dr("Precio")) Then
                                    b.PrecioProductor = CDbl(dr("Precio"))
                                Else
                                    b.PrecioProductor = 0
                                End If


                            End If

                    '=====================================================
                    ' SOCIO
                    '=====================================================
                        Case "Socio"

                            b.EsSocio = activo

                            If activo Then

                                b.CodTipoNominaSocio = dr("CodTipoNomina").ToString


                                b.EscolaridadSocio = dr("CodEscolaridad").ToString
                                b.DepartamentoSocio = dr("CodDepartamentos").ToString
                                b.CooperatiaSocio = dr("CodCooperativa").ToString
                                b.RutaSocio = dr("CodRuta").ToString

                                b.CtasxCobrarSocio = dr("Cod_Cuenta_Cliente").ToString
                                b.CtasxPagarSocio = dr("Cod_Cuenta_Proveedor").ToString

                                b.CtaBancoSocio = dr("Cuenta_Banco").ToString
                                b.CtaIrSocio = dr("Cuenta_IR").ToString
                                b.CtaBolsaSocio = dr("Cuenta_Bolsa").ToString
                                b.CtaAnticipoSocio = dr("Cuenta_Anticipo").ToString
                                b.CtaTransporteSocio = dr("Cuenta_Transporte").ToString
                                b.CtaInseminacionSocio = dr("Cuenta_Inseminacion").ToString
                                b.CtaTrazabilidadSocio = dr("Cuenta_Trazabilidad").ToString
                                b.CtaVeterinariosSocio = dr("Cuenta_Veterinario").ToString
                                b.CtaFondosSocio = dr("Cuenta_Otras").ToString
                                b.CtaPlanillaSocio = dr("Cuenta_GastoPlanilla").ToString

                                If Not IsDBNull(dr("Precio")) Then
                                    b.PrecioSocio = CDbl(dr("Precio"))
                                Else
                                    b.PrecioSocio = 0
                                End If

                            End If

                    '=====================================================
                    ' PRESOCIO
                    '=====================================================
                        Case "PreSocio"

                            b.EsPreSocio = activo

                            If activo Then

                                b.CodTipoNominaPreSocio = dr("CodTipoNomina").ToString

                                b.EscolaridadPreSocio = dr("CodEscolaridad").ToString
                                b.DepartamentoPreSocio = dr("CodDepartamentos").ToString
                                b.CooperatiaPreSocio = dr("CodCooperativa").ToString
                                b.RutaPreSocio = dr("CodRuta").ToString

                                b.CtasxCobrarPreSocio = dr("Cod_Cuenta_Cliente").ToString
                                b.CtasxPagarPreSocio = dr("Cod_Cuenta_Proveedor").ToString

                                b.CtaBancoPreSocio = dr("Cuenta_Banco").ToString
                                b.CtaIrPreSocio = dr("Cuenta_IR").ToString
                                b.CtaBolsaPreSocio = dr("Cuenta_Bolsa").ToString
                                b.CtaAnticipoPreSocio = dr("Cuenta_Anticipo").ToString
                                b.CtaTransportePreSocio = dr("Cuenta_Transporte").ToString
                                b.CtaInseminacionPreSocio = dr("Cuenta_Inseminacion").ToString
                                b.CtaTrazabilidadPreSocio = dr("Cuenta_Trazabilidad").ToString
                                b.CtaVeterinariosPreSocio = dr("Cuenta_Veterinario").ToString
                                b.CtaFondosPreSocio = dr("Cuenta_Otras").ToString
                                b.CtaPlanillaPreSocio = dr("Cuenta_GastoPlanilla").ToString

                                If Not IsDBNull(dr("Precio")) Then
                                    b.PrecioPreSocio = CDbl(dr("Precio"))
                                Else
                                    b.PrecioPreSocio = 0
                                End If

                            End If

                    End Select

                End While

            End Using

        End Using

    End Sub

    '****************CODIGO RETIRADO REFACTORIZACION 31/07/2026 ******************
    'Private Sub CargarRolesProductor(cn As SqlConnection,
    '                             b As Beneficiario)

    '    Dim sql As String = "
    '    SELECT TipoProductor, Activo
    '    FROM Productor
    '    WHERE CodProductor=@Cod"

    '    Using cmd As New SqlCommand(sql, cn)

    '        cmd.Parameters.AddWithValue("@Cod", b.Codigo)

    '        Using dr As SqlDataReader = cmd.ExecuteReader()

    '            ' Inicializamos en falso
    '            b.EsProductor = False
    '            b.EsSocio = False
    '            b.EsPreSocio = False

    '            While dr.Read()

    '                Dim tipo As String = dr("TipoProductor").ToString()
    '                Dim activo As Boolean = Convert.ToBoolean(dr("Activo"))

    '                If tipo = "Productor" Then b.EsProductor = activo
    '                If tipo = "Socio" Then b.EsSocio = activo
    '                If tipo = "PreSocio" Then b.EsPreSocio = activo

    '            End While

    '        End Using
    '    End Using

    'End Sub
    Private Sub CargarDatosCliente(b As Beneficiario, cn As SqlConnection)

        Dim sql As String = "SELECT * FROM Clientes WHERE Cod_Cliente=@Cod"

        Using cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@Cod", b.Codigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then

                    b.Departamento = dr("Departamento").ToString()
                    b.Municipio = dr("Municipio").ToString()
                    b.Endoso = dr("Endoso").ToString()
                    b.CodCuentaCliente = dr("Cod_Cuenta_Cliente").ToString()
                    b.MonedaCredito = dr("MonedaCredito").ToString()
                    b.CodCuentaBanco = dr("Cod_Cuenta_Banco").ToString()

                    b.Efectivo = Convert.ToBoolean(dr("Efectivo"))
                    b.BloquearPorLimiteCredito =
                    Convert.ToBoolean(dr("BloquearPorLimiteCredito"))

                    If Not IsDBNull(dr("Limite_Credito")) Then
                        b.LimiteCredito = CDbl(dr("Limite_Credito"))
                    End If

                    If Not IsDBNull(dr("DiasCredito")) Then
                        b.DiasCredito = CDbl(dr("DiasCredito"))
                    End If


                    If Not IsDBNull(dr("Cod_Cuenta_Cliente")) Then
                        b.CtasxCobrarClientes = CDbl(dr("Cod_Cuenta_Cliente"))
                    End If

                End If

            End Using
        End Using

    End Sub
    Private Sub CargarDatosProveedor(b As Beneficiario, cn As SqlConnection)

        Dim sql As String = "
    SELECT *
    FROM Proveedor
    WHERE Cod_Proveedor = @Cod AND Activo = 1"

        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Cod", b.Codigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then

                    b.DepartamentoProveedor = dr("Departamento_Proveedor").ToString()
                    b.MunicipioProveedor = dr("Municipio_Proveedor").ToString()
                    b.CtasxPagarProveedor = dr("Cod_Cuenta_Pagar").ToString()

                End If

            End Using
        End Using

    End Sub
    Private Sub CargarDatosTransportista(b As Beneficiario, cn As SqlConnection)

        Dim sql As String = "
    SELECT *
    FROM Conductor
    WHERE Codigo = @Cod AND Activo = 1"

        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Cod", b.Codigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then
                    b.CtaTransportista = dr("Cuenta_Contable").ToString()
                    b.CtaBancoTransp = dr("Cuenta_Banco").ToString()
                    b.CtaIrTransp = dr("Cuenta_IR").ToString()
                    b.CtaBolsaTransp = dr("Cuenta_Bolsa").ToString()
                    b.CtaFondosTransp = dr("Cuenta_Transporte").ToString()
                    b.CtaAnticipoTransp = dr("Cuenta_Anticipo").ToString()
                    b.CtaVeterinariaTransp = dr("Cuenta_Pulperia").ToString()
                    b.CtaOtrasDeduccionesTransp = dr("Cuenta_Otras").ToString()
                    b.CtaInseminacionTransp = dr("Cuenta_Inseminacion").ToString()
                    b.CtaTrazabilidadTransp = dr("Cuenta_Trazabilidad").ToString()
                    b.CtaGtosPlanillaTransp = dr("Cuenta_GastoPlanilla").ToString()
                End If

            End Using
        End Using

    End Sub


    Private Function ExisteRegistro(cn As SqlConnection,
                                tabla As String,
                                campo As String,
                                codigo As String,
                                Optional trans As SqlTransaction = Nothing) As Boolean

        Dim sql As String = "SELECT COUNT(*) FROM " & tabla &
                        " WHERE " & campo & "=@Cod AND Activo=1"

        Using cmd As New SqlCommand(sql, cn)

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            cmd.Parameters.AddWithValue("@Cod", codigo)

            Return CInt(cmd.ExecuteScalar()) > 0

        End Using

    End Function

    Private Function ExisteProductor(cn As SqlConnection,
                                     codigo As String, Optional trans As SqlTransaction = Nothing) As Boolean

        Dim sql As String = "
        SELECT COUNT(*) 
        FROM Productor 
        WHERE CodProductor=@Cod 
        AND TipoProductor='GENERAL'
        AND Activo=1"

        Using cmd As New SqlCommand(sql, cn)

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            cmd.Parameters.AddWithValue("@Cod", codigo)

            Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return existe > 0
        End Using

    End Function
    Private Function ExisteEmpleadoActivo(cn As SqlConnection,
                                          codigo As String, Optional trans As SqlTransaction = Nothing) As Boolean

        Dim sql As String = "
        SELECT COUNT(*) 
        FROM Empleado
        WHERE CodEmpleado1=@Cod 
        AND Activo=1"

        Using cmd As New SqlCommand(sql, cn)

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            cmd.Parameters.AddWithValue("@Cod", codigo)

            Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return existe > 0
        End Using

    End Function


End Class
