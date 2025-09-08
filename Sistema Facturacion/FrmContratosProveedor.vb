Imports System.Data.SqlTypes
Imports System.Diagnostics.Contracts

Public Class FrmContratosProveedor
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public Numero_Contrato As String

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
    Public Sub Cargar_Contrato(Numero_Contrato As String)
        Dim Contrato As TablaContrato_Proveedor = New TablaContrato_Proveedor

        Contrato = Cargar_Contrato_Proveedor(Numero_Contrato)
        If Contrato IsNot Nothing Then

            Me.TxtNumeroContrato.Text = Contrato.Numero_Contrato
            Me.CboCodigoProveedor.Text = Contrato.Codigo_Proveedor
            Me.TxtContacto.Text = Contrato.Contacto_Proveedor
            Me.TxtTelefono.Text = Contrato.Telefono_Contacto
            Me.TxtDescripcion.Text = Contrato.Descripcion
            Me.DtpInicioContrato.Value = Contrato.Fecha_Inicio
            Me.DtpInicioContrato.Value = Contrato.Fecha_Fin
            CmbTipoServicio.Text = Contrato.Tipo_Servicio
            CmbTipoContrato.Text = Contrato.Tipo_Contrato
            txtModelo.Text = Contrato.ModeloContrato
            TxtDiasRespuesta.Text = Contrato.Num_Respuesta
            TxtDiasResolucion.Text = Contrato.Num_Resolucion
            CmbDiasRespuesta.Text = Contrato.Tiempo_Respuesta
            CmbDiasResolucion.Text = Contrato.Tiempo_Resolucion
            CmbEstado.Text = Contrato.Estado
            TxtComentarios.Text = Contrato.Comentarios
            ChkLunes.Checked = Contrato.Cobertura_Lunes
            ChkMartes.Checked = Contrato.Cobertura_Martes
            ChkMiercoles.Checked = Contrato.Cobertura_Miercoles
            ChkJueves.Checked = Contrato.Cobertura_Jueves
            ChkViernes.Checked = Contrato.Cobertura_Viernes
            ChkSabado.Checked = Contrato.Cobertura_Sabado
            ChkDomingo.Checked = Contrato.Cobertura_Domingo
            TxtLunesInicio.Text = Contrato.Lunes_Fin
            TxtMartesInicio.Text = Contrato.Martes_Inicio
            TxtMartesFin.Text = Contrato.Martes_Fin
            TxtMiercolesInicio.Text = Contrato.Miercoles_Inicio
            TxtMiercolesFin.Text = Contrato.Miercoles_Fin
            TxtJuevesInicio.Text = Contrato.Jueves_Inicio
            TxtJuevesFin.Text = Contrato.Jueves_Fin
            TxtViernesInicio.Text = Contrato.Viernes_Inicio
            TxtViernesFin.Text = Contrato.Viernes_Fin
            TxtSabadoInicio.Text = Contrato.Sabado_Inicio
            TxtSabadoFin.Text = Contrato.Sabado_Fin
            TxtDomingoInicio.Text = Contrato.Domingo_Inicio
            TxtDomingoFin.Text = Contrato.Domingo_Fin


        Else
            MsgBox("Contrato no Existe", vbCritical, "Zeus Facturacion")
        End If

    End Sub


    Private Sub Limpiar_Contrato()
        Me.TxtNumeroContrato.Text = "-----0-----"
        Me.CboCodigoProveedor.Text = ""
        Me.TxtContacto.Text = ""
        Me.TxtTelefono.Text = ""
        Me.TxtDescripcion.Text = ""
        Me.DtpInicioContrato.Value = Format(Now, "dd/MM/yyyy")
        Me.DtpInicioContrato.Value = Format(Now, "dd/MM/yyyy")
        CmbTipoServicio.Text = "Regular"
        CmbTipoContrato.Text = "Servicios"
        txtModelo.Text = ""
        TxtDiasRespuesta.Text = "1"
        TxtDiasResolucion.Text = "1"
        CmbDiasResolucion.Text = "Dias"
        CmbDiasRespuesta.Text = "Dias"
        CmbEstado.Text = "Autorizado"
        TxtComentarios.Text = ""
        ChkLunes.Checked = False
        ChkMartes.Checked = False
        ChkMiercoles.Checked = False
        ChkJueves.Checked = False
        ChkViernes.Checked = False
        ChkSabado.Checked = False
        ChkDomingo.Checked = False
        TxtLunesInicio.Text = ""
        TxtLunesFin.Text = ""
        TxtMartesInicio.Text = ""
        TxtMartesFin.Text = ""
        TxtMiercolesInicio.Text = ""
        TxtMiercolesFin.Text = ""
        TxtJuevesInicio.Text = ""
        TxtJuevesFin.Text = ""
        TxtViernesInicio.Text = ""
        TxtViernesFin.Text = ""
        TxtSabadoInicio.Text = ""
        TxtSabadoFin.Text = ""
        TxtDomingoInicio.Text = ""
        TxtDomingoFin.Text = ""
    End Sub


    Private Sub CboCodigoProveedor_TextChanged(sender As Object, e As EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        'SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        SqlProveedor = "SELECT  Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor, Contrato_Proveedor.Telefono_Contacto, Proveedor.Direccion_Proveedor, Contrato_Proveedor.Contacto_Proveedor FROM  Contrato_Proveedor RIGHT OUTER JOIN Proveedor ON Contrato_Proveedor.Codigo_Proveedor = Proveedor.Cod_Proveedor WHERE (Proveedor.Cod_Proveedor <> N'' AND Proveedor.Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            'If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
            '    Me.TxtDescripcion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
            'End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono_Contacto")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono_Contacto")
            End If

            'If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Contacto_Proveedor")) Then
            '    Me.TxtContacto.Text = DataSet.Tables("Proveedor").Rows(0)("Contacto_Proveedor")
            'End If

        End If
    End Sub

    Private Sub FrmContratosProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar_Contrato()

        Cargar_Contrato(Numero_Contrato)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Contrato As TablaContrato_Proveedor = New TablaContrato_Proveedor
        Dim Numero_Contrato As String

        If Me.CboCodigoProveedor.Text = "" Then
            MsgBox("Se necesito codigo Proveedo", vbCritical, "Zeus Facturacion")
            Exit Sub
        End If

        If Me.TxtNumeroContrato.Text = "-----0-----" Then
            Numero_Contrato = Format(BuscaConsecutivo("Numero_Contrato_Proveedor"), "0000#")
            Me.TxtNumeroContrato.Text = Numero_Contrato
        Else
            Numero_Contrato = Me.TxtNumeroContrato.Text
        End If

        Contrato.Numero_Contrato = Numero_Contrato
        Contrato.Codigo_Proveedor = Me.CboCodigoProveedor.Text
        Contrato.Contacto_Proveedor = Me.TxtContacto.Text
        Contrato.Telefono_Contacto = Me.TxtTelefono.Text
        Contrato.Descripcion = Me.TxtDescripcion.Text
        Contrato.Fecha_Inicio = Me.DtpInicioContrato.Value
        Contrato.Fecha_Fin = Me.DtpInicioContrato.Value
        Contrato.Tipo_Servicio = CmbTipoServicio.Text
        Contrato.Tipo_Contrato = CmbTipoContrato.Text
        Contrato.ModeloContrato = txtModelo.Text
        Contrato.Num_Respuesta = TxtDiasRespuesta.Text
        Contrato.Num_Resolucion = TxtDiasResolucion.Text
        Contrato.Tiempo_Respuesta = CmbDiasRespuesta.Text
        Contrato.Tiempo_Resolucion = CmbDiasResolucion.Text
        Contrato.Estado = CmbEstado.Text
        Contrato.Comentarios = TxtComentarios.Text
        Contrato.Cobertura_Lunes = ChkLunes.Checked
        Contrato.Cobertura_Martes = ChkMartes.Checked
        Contrato.Cobertura_Miercoles = ChkMiercoles.Checked
        Contrato.Cobertura_Jueves = ChkJueves.Checked
        Contrato.Cobertura_Viernes = ChkViernes.Checked
        Contrato.Cobertura_Sabado = ChkSabado.Checked
        Contrato.Cobertura_Domingo = ChkDomingo.Checked
        Contrato.Lunes_Inicio = TxtLunesInicio.Text
        Contrato.Lunes_Fin = TxtLunesFin.Text
        Contrato.Martes_Inicio = TxtMartesInicio.Text
        Contrato.Martes_Fin = TxtMartesFin.Text
        Contrato.Miercoles_Inicio = TxtMiercolesInicio.Text
        Contrato.Miercoles_Fin = TxtMiercolesFin.Text
        Contrato.Jueves_Inicio = TxtJuevesInicio.Text
        Contrato.Jueves_Fin = TxtJuevesFin.Text
        Contrato.Viernes_Inicio = TxtViernesInicio.Text
        Contrato.Viernes_Fin = TxtViernesFin.Text
        Contrato.Sabado_Inicio = TxtSabadoInicio.Text
        Contrato.Sabado_Fin = TxtSabadoFin.Text
        Contrato.Domingo_Inicio = TxtDomingoInicio.Text
        Contrato.Domingo_Fin = TxtDomingoFin.Text

        Gravar_Contrato_Proveedor(Contrato)
        Limpiar_Contrato()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, Dataset As New DataSet
        Dim SQlString As String, StrSqlUpdate As String, NumeroContrato As String
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Contrato?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If

        NumeroContrato = Me.TxtNumeroContrato.Text

        SQlString = "SELECT  * FROM  Contrato_Proveedor WHERE (Numero_Contrato = '" & NumeroContrato & "') "
        Dataset = FillConsultaSQL(SqlString, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count <> 0 Then
            StrSqlUpdate = "DELETE FROM Contrato_Proveedor  WHERE (Numero_Contrato = '" & NumeroContrato & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            Bitacora(Now, NombreUsuario, "Contrato Proveedores", "Borro el Contrato: " & NumeroContrato)
        Else
            Bitacora(Now, NombreUsuario, "Contrato Proveedores", "Intento Borrar Contrato: " & NumeroContrato)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class