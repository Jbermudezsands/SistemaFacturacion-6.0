Public Class FrmContratosNuevos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

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
                    Me.OptExsonerado.Checked = False
                Else
                    Me.OptExsonerado.Checked = True
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
End Class