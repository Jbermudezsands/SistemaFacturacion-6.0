Imports System.Data.SqlClient

Public Class FrmRepararLotes

    Private Sub CargarAuditoria()

        Try

            Using cn As New SqlConnection(Conexion)

                Dim sql As String = "
            SELECT 
                A.Id,
                A.Cod_Producto,
                P.Descripcion_Producto,
                A.Cod_Bodega,
                B.Nombre_Bodega,
                A.LoteIncorrecto,
                A.LoteSugerido,
                A.Documento,
                A.TipoDocumento,
                A.FechaMovimiento,
                A.CantidadMovimiento,
                A.ExistenciaDespuesMovimiento, 
                CASE 
                    WHEN A.ExistenciaDespuesMovimiento < 0 
                        THEN 'Lote Negativo'
                    WHEN A.LoteSugerido IS NULL 
                        THEN 'Lote inexistente'
                    WHEN A.LoteIncorrecto <> A.LoteSugerido 
                        THEN 'Lote incorrecto'
                    ELSE 'Revisar'
                END AS TipoError
            FROM Auditoria_LotesNegativos A
            LEFT JOIN Productos P
                ON A.Cod_Producto = P.Cod_Productos
            LEFT JOIN Bodegas B
                ON A.Cod_Bodega = B.Cod_Bodega
            WHERE A.Reparado = 0
            ORDER BY A.FechaMovimiento"

                Dim da As New SqlDataAdapter(sql, cn)
                Dim dt As New DataTable

                da.Fill(dt)

                TrueDBGridLotes.DataSource = dt

                TrueDBGridLotes.Columns("Cod_Producto").Caption = "Producto"
                TrueDBGridLotes.Columns("Descripcion_Producto").Caption = "Descripción"
                TrueDBGridLotes.Columns("Cod_Bodega").Caption = "Bodega"
                TrueDBGridLotes.Columns("Nombre_Bodega").Caption = "Nombre Bodega"
                TrueDBGridLotes.Columns("LoteIncorrecto").Caption = "Lote Usado"
                TrueDBGridLotes.Columns("LoteSugerido").Caption = "Lote Correcto"
                TrueDBGridLotes.Columns("TipoError").Caption = "Tipo Error"

            End Using

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub TrueDBGridLotes_FetchRowStyle(sender As Object, e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles TrueDBGridLotes.FetchRowStyle

        Dim tipo As String = TrueDBGridLotes.Columns("TipoError").CellText(e.Row)

        If tipo = "Lote Negativo" Then
            e.CellStyle.BackColor = Color.LightCoral
        ElseIf tipo = "Lote incorrecto" Then
            e.CellStyle.BackColor = Color.LightYellow
        End If

    End Sub


    Private Sub FrmRepararLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAuditoria()
    End Sub

    Private Sub BtnRepararLinea_Click(sender As Object, e As EventArgs) Handles BtnRepararLinea.Click
        Try

            If TrueDBGridLotes.RowCount = 0 Then Exit Sub

            Dim factura As String = TrueDBGridLotes.Columns("Documento").Value
            Dim producto As String = TrueDBGridLotes.Columns("Cod_Producto").Value
            Dim loteIncorrecto As String = TrueDBGridLotes.Columns("LoteIncorrecto").Value
            Dim loteCorrecto As String = TrueDBGridLotes.Columns("LoteSugerido").Value

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Dim cmd As New SqlCommand("SP_RepararLoteFactura", cn)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Factura", factura)
                cmd.Parameters.AddWithValue("@Producto", producto)
                cmd.Parameters.AddWithValue("@LoteIncorrecto", loteIncorrecto)
                cmd.Parameters.AddWithValue("@LoteCorrecto", loteCorrecto)

                cmd.ExecuteNonQuery()

            End Using

            MsgBox("Lote reparado correctamente")

            CargarAuditoria()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub BtnRepararTodo_Click(sender As Object, e As EventArgs) Handles BtnRepararTodo.Click
        If MsgBox("¿Desea reparar todos los lotes detectados?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Try

            Using cn As New SqlConnection(Conexion)

                cn.Open()

                Dim cmd As New SqlCommand("SP_RepararLotesNegativos", cn)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.ExecuteNonQuery()

            End Using

            MsgBox("Reparación completa")

            CargarAuditoria()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TrueDBGridLotes_Click(sender As Object, e As EventArgs) Handles TrueDBGridLotes.Click

    End Sub
End Class