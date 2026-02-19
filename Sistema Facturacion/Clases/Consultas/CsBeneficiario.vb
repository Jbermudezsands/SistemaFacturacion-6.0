Imports System.Data.SqlClient
Imports C1.Win.C1List

Public Class CsBeneficiario

    Public Sub Guardar(b As Beneficiario)

        Using cn As New SqlConnection(Conexion)
            cn.Open()

            Using trans As SqlTransaction = cn.BeginTransaction()

                Try

                    GuardarBeneficiario(b, cn, trans)

                    GestionarCliente(b, cn, trans)
                    GestionarProveedor(b, cn, trans)
                    GestionarProductor(b, cn, trans)
                    'GestionarEmpleado(b, cn, trans)

                    trans.Commit()

                Catch ex As Exception
                    trans.Rollback()
                    Throw
                End Try

            End Using
        End Using

    End Sub

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
            (Cod_Cliente,Nombre_Cliente,Apellido_Cliente,
             Direccion_Cliente,Telefono,Cedula,Activo)
            VALUES
            (@Cod,@Nom,@Ape,@Dir,@Tel,@Ced,1)"

                    Dim cmd As New SqlCommand(sqlInsert, cn, trans)
                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                    cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                    cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                    cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                    cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                    cmd.Parameters.AddWithValue("@Ced", b.Cedula)
                    cmd.ExecuteNonQuery()

                Else

                    Dim sqlUpdate As String = "
            UPDATE Clientes SET
                Nombre_Cliente=@Nom,
                Apellido_Cliente=@Ape,
                Direccion_Cliente=@Dir,
                Telefono=@Tel,
                Cedula=@Ced,
                Activo=1
            WHERE Cod_Cliente=@Cod"

                    Dim cmd As New SqlCommand(sqlUpdate, cn, trans)
                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                    cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                    cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                    cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                    cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                    cmd.Parameters.AddWithValue("@Ced", b.Cedula)
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

        Dim sqlExiste As String = "
        SELECT COUNT(*) 
        FROM Productor 
        WHERE CodProductor=@Cod 
        AND TipoProductor=@Tipo"

        Using cmdExiste As New SqlCommand(sqlExiste, cn, trans)

            cmdExiste.Parameters.AddWithValue("@Cod", b.Codigo)
            cmdExiste.Parameters.AddWithValue("@Tipo", tipo)

            Dim existe As Integer = Convert.ToInt32(cmdExiste.ExecuteScalar())

            If existe = 0 Then

                If activoCheck Then

                    Dim sqlInsert As String = "
                INSERT INTO Productor
                (CodProductor,TipoProductor,
                 NombreProductor,ApellidoProductor,
                 FechaAdmision,FechaNacimiento,
                 DireccionProductor,Sexo,
                 Telefonos,EstadoCivil,
                 Cedula,RUC,Activo)
                VALUES
                (@Cod,@Tipo,
                 @Nom,@Ape,
                 @FAdm,@FNac,
                 @Dir,@Sexo,
                 @Tel,@EstCivil,
                 @Ced,@Ruc,1)"

                    Dim cmd As New SqlCommand(sqlInsert, cn, trans)

                    cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                    cmd.Parameters.AddWithValue("@Tipo", tipo)
                    cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                    cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                    cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
                    cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
                    cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                    cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
                    cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                    cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
                    cmd.Parameters.AddWithValue("@Ced", b.Cedula)
                    cmd.Parameters.AddWithValue("@Ruc", b.RUC)

                    cmd.ExecuteNonQuery()

                End If

            Else

                Dim sqlUpdate As String = "
            UPDATE Productor SET
                NombreProductor=@Nom,
                ApellidoProductor=@Ape,
                FechaAdmision=@FAdm,
                FechaNacimiento=@FNac,
                DireccionProductor=@Dir,
                Sexo=@Sexo,
                Telefonos=@Tel,
                EstadoCivil=@EstCivil,
                Cedula=@Ced,
                RUC=@Ruc,
                Activo=@Activo
            WHERE CodProductor=@Cod 
            AND TipoProductor=@Tipo"

                Dim cmd As New SqlCommand(sqlUpdate, cn, trans)

                cmd.Parameters.AddWithValue("@Cod", b.Codigo)
                cmd.Parameters.AddWithValue("@Tipo", tipo)
                cmd.Parameters.AddWithValue("@Nom", b.Nombre)
                cmd.Parameters.AddWithValue("@Ape", b.Apellido)
                cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
                cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
                cmd.Parameters.AddWithValue("@Dir", b.Direccion)
                cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
                cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
                cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
                cmd.Parameters.AddWithValue("@Ced", b.Cedula)
                cmd.Parameters.AddWithValue("@Ruc", b.RUC)
                cmd.Parameters.AddWithValue("@Activo", activoCheck)

                cmd.ExecuteNonQuery()

            End If

        End Using

    End Sub


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
        cmd.Parameters.AddWithValue("@FAdm", b.Fecha_Admision)
        cmd.Parameters.AddWithValue("@FNac", b.Fecha_Nacimiento)
        cmd.Parameters.AddWithValue("@Dir", b.Direccion)
        cmd.Parameters.AddWithValue("@Sexo", b.Sexo)
        cmd.Parameters.AddWithValue("@Tel", b.Telefonos)
        cmd.Parameters.AddWithValue("@EstCivil", b.Estado_Civil)
        cmd.Parameters.AddWithValue("@Ced", b.Cedula)
        cmd.Parameters.AddWithValue("@Ruc", b.RUC)
        cmd.Parameters.AddWithValue("@Foto", b.Foto)
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

                '========================================
                ' 3. VERIFICAR SI ES PROVEEDOR
                '========================================
                b.EsProveedor = ExisteRegistro(cn, "Proveedor",
                                           "Cod_Proveedor",
                                           codigo)

            '========================================
            ' 4. VERIFICAR SI ES PRODUCTOR
            '========================================
            CargarRolesProductor(cn, b)

            '========================================
            ' 5. VERIFICAR SI ES EMPLEADO ACTIVO
            '========================================
            'b.EsEmpleado = ExisteEmpleadoActivo(cn, codigo)

        End Using

            Return b

        End Function

    Private Sub CargarRolesProductor(cn As SqlConnection,
                                 b As Beneficiario)

        Dim sql As String = "
        SELECT TipoProductor, Activo
        FROM Productor
        WHERE CodProductor=@Cod"

        Using cmd As New SqlCommand(sql, cn)

            cmd.Parameters.AddWithValue("@Cod", b.Codigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()

                ' Inicializamos en falso
                b.EsProductor = False
                b.EsSocio = False
                b.EsPreSocio = False

                While dr.Read()

                    Dim tipo As String = dr("TipoProductor").ToString()
                    Dim activo As Boolean = Convert.ToBoolean(dr("Activo"))

                    If tipo = "Productor" Then b.EsProductor = activo
                    If tipo = "Socio" Then b.EsSocio = activo
                    If tipo = "PreSocio" Then b.EsPreSocio = activo

                End While

            End Using
        End Using

    End Sub


    Private Function ExisteRegistro(cn As SqlConnection,
                                    tabla As String,
                                    campo As String,
                                    codigo As String) As Boolean

            Dim sql As String = "SELECT COUNT(*) FROM " & tabla &
                            " WHERE " & campo & "=@Cod AND Activo=1"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)

                Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return existe > 0
            End Using

        End Function
        Private Function ExisteProductor(cn As SqlConnection,
                                     codigo As String) As Boolean

            Dim sql As String = "
        SELECT COUNT(*) 
        FROM Productor 
        WHERE CodProductor=@Cod 
        AND TipoProductor='GENERAL'
        AND Activo=1"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)

                Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return existe > 0
            End Using

        End Function
        Private Function ExisteEmpleadoActivo(cn As SqlConnection,
                                          codigo As String) As Boolean

            Dim sql As String = "
        SELECT COUNT(*) 
        FROM Empleado
        WHERE CodEmpleado1=@Cod 
        AND Activo=1"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Cod", codigo)

                Dim existe As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return existe > 0
            End Using

        End Function


End Class
