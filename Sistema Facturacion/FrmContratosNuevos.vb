Public Class FrmContratosNuevos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NumeroContrato As Double

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged

        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DiasCredito As Double = 0, CausaIva As Boolean
        Dim SqlString As String = ""

        Try



            SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then


                Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")



                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("CausaIva")) Then
                    CausaIva = DataSet.Tables("Clientes").Rows(0)("CausaIva")
                End If

                If CausaIva = True Then
                    Me.ChkExonerado.Checked = False
                Else
                    Me.ChkExonerado.Checked = True
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                    Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                End If
                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
                End If

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("DiasCredito")) Then
                    DiasCredito = DataSet.Tables("Clientes").Rows(0)("DiasCredito")
                End If




            Else

                Me.TxtNombres.Text = ""
                Me.TxtApellidos.Text = ""
                Me.TxtDireccion.Text = ""
                Me.TxtTelefono.Text = ""

            End If



        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub FrmContratosNuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DiasCredito As Double = 0, CausaIva As Boolean, i As Double = 0, Cont As Double
        Dim SqlString As String = ""

        Try

            SqlProveedor = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "TipoContrato")
            Cont = DataSet.Tables("TipoContrato").Rows.Count
            i = 0
            Do While Cont > i
                Me.CmbContrato1.Items.Add(DataSet.Tables("TipoContrato").Rows(i)("TipoContrato"))
                Me.CmbContrato2.Items.Add(DataSet.Tables("TipoContrato").Rows(i)("TipoContrato"))
                i = i + 1
            Loop

            'If Cont > 0 Then
            '    Me.CmbContrato1.Text = DataSet.Tables("TipoContrato").Rows(0)("TipoContrato")
            '    Me.CmbContrato2.Text = DataSet.Tables("TipoContrato").Rows(0)("TipoContrato")
            'End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try




    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQLClientes As String, Exonerado As Boolean
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim IdContrato1 As Double, IdContrato2 As Double

        If Me.ChkExonerado.Checked = True Then
            Exonerado = True
        Else
            Exonerado = False
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////BUSCO EL ID DE LOS TIPOS DE CONTRATOS ////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato1.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato")
        If Not DataSet.Tables("Contrato").Rows.Count = 0 Then
            IdContrato1 = DataSet.Tables("Contrato").Rows(0)("idTipoContrato")
        End If

        SQLClientes = "SELECT idTipoContrato, TipoContrato, Activo FROM TipoContrato WHERE (TipoContrato = '" & Me.CmbContrato2.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Contrato2")
        If Not DataSet.Tables("Contrato2").Rows.Count = 0 Then
            IdContrato2 = DataSet.Tables("Contrato2").Rows(0)("idTipoContrato")
        End If




        SQLClientes = "SELECT Contratos.* FROM Contratos WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Contratos]    SET [Cod_Cliente] = '" & Me.TxtCodigoClientes.Text & "',[Tipo_Servicios1] = '" & Me.CmbContrato1.Text & "' ,[Tipo_Servicios2] = '" & Me.CmbContrato2.Text & "' ,[Frecuencia] = " & Me.CmbFrecuencia1.Text & " ,[Inicio_Contrato] = '" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato] = '" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' ,[Contacto_Administrativo] =  '" & Me.TxtContactoAdmon.Text & "' ,[Contacto_Operativo] =  '" & Me.TxtContactoOperativo.Text & "' ,[Precio_Unitario] = " & Me.TxtPrecioUnitario1.Text & " ,[Moneda] = '" & Me.CmbMoneda1.Text & "' ,[Activo] = '" & Me.ChkActivo.Checked & "'  ,[Exonerado] = " & Exonerado & " ,[Referencia] =  '" & Me.CboReferencia.Text & "'  ,[Observaciones] =  '" & Me.TxtObservaciones.Text & "' ,[Precio_Unitario2] =  '" & Me.TxtPrecioUnitario1.Text & "' ,[Inicio_Contrato2] = '" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,[Fin_Contrato2] = '" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,[Moneda2] = '" & Me.CmbMoneda1.Text & "' ,[Frecuencia2] = '" & Me.CmbFrecuencia2.Text & "' ,[IdContrato1] = " & IdContrato1 & " ,[IdContrato2] = " & IdContrato2 & "  WHERE (Numero_Contrato = " & NumeroContrato & ") AND (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Contratos] ([Cod_Cliente],[Tipo_Servicios1],[Tipo_Servicios2],[Frecuencia],[Inicio_Contrato],[Fin_Contrato] ,[Contacto_Administrativo] ,[Contacto_Operativo],[Precio_Unitario] ,[Moneda],[Activo],[Anulado],[Retencion1],[Retencion2],[Exonerado],[Referencia],[Observaciones],[Precio_Unitario2],[Inicio_Contrato2],[Fin_Contrato2] ,[Moneda2] ,[Frecuencia2] ,[IdContrato1],[IdContrato2]) " & _
                           "VALUES ('" & Me.TxtCodigoClientes.Text & "','" & Me.CmbContrato1.Text & "' ,'" & Me.CmbContrato2.Text & "' ," & Me.CmbFrecuencia1.Text & " ,'" & Format(Me.DtpInicioContrato1.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato1.Value, "dd/MM/yyyy") & "' , '" & Me.TxtContactoAdmon.Text & "' , '" & Me.TxtContactoOperativo.Text & "' , " & Me.TxtPrecioUnitario1.Text & " , '" & Me.CmbMoneda1.Text & "' ,1,0,0,0, " & Exonerado & ", '" & Me.CboReferencia.Text & "' ,'" & Me.TxtObservaciones.Text & "' , " & Me.TxtPrecioUnitario2.Text & " ,'" & Format(Me.DtpInicioContrato2.Value, "dd/MM/yyyy") & "' ,'" & Format(Me.DtpFinContrato2.Value, "dd/MM/yyyy") & "' ,'" & Me.CmbMoneda1.Text & "' ,'" & Me.CmbFrecuencia2.Text & "'  , " & IdContrato1 & " ," & IdContrato2 & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        Bitacora(Now, NombreUsuario, "Clientes", "Grabo el cliente: " & Me.TxtNombre.Text)
    End Sub
End Class