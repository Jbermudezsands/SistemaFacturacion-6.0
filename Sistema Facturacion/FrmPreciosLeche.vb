Public Class FrmPreciosLeche

    Private dtPreciosLeche As DataTable
    Private bsPreciosLeche As BindingSource
    Private Sub FrmPreciosLeche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPreciosLeche()
    End Sub

    Private Sub CargarPreciosLeche()

        Try

            dtPreciosLeche = ObtenerPreciosLeche()

            bsPreciosLeche = New BindingSource()
            bsPreciosLeche.DataSource = dtPreciosLeche

            TDGrigPreciosLeche.DataSource = bsPreciosLeche

            ConfigurarGridPreciosLeche()

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los precios de leche." &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ConfigurarGridPreciosLeche()

        With TDGrigPreciosLeche

            .AllowUpdate = True

            '========================================
            ' COLUMNAS OCULTAS
            '========================================

            .Splits(0).DisplayColumns("Cod_Productos").Visible = False
            .Splits(0).DisplayColumns("Tipo_Producto").Visible = False
            .Splits(0).DisplayColumns("Cod_TipoPrecio").Visible = False


            '========================================
            ' COLUMNAS VISIBLES
            '========================================

            .Splits(0).DisplayColumns("Descripcion_Producto").Visible = True
            .Splits(0).DisplayColumns("Tipo_Precio").Visible = True
            .Splits(0).DisplayColumns("Monto_Precio").Visible = True
            .Splits(0).DisplayColumns("Monto_PrecioDolar").Visible = True

            'Campo técnico: no se muestra
            .Splits(0).DisplayColumns("Cod_TipoPrecio").Visible = False

            'Campos que no debe modificar el usuario
            .Splits(0).DisplayColumns("Cod_Productos").Locked = True
            .Splits(0).DisplayColumns("Tipo_Producto").Locked = True
            .Splits(0).DisplayColumns("Descripcion_Producto").Locked = True
            .Splits(0).DisplayColumns("Tipo_Precio").Locked = True

            'Campos que sí puede modificar
            .Splits(0).DisplayColumns("Monto_Precio").Locked = False
            .Splits(0).DisplayColumns("Monto_PrecioDolar").Locked = False



        End With

        '========================================
        ' ENCABEZADOS DEL GRID
        '========================================

        With TDGrigPreciosLeche

            .Columns("Cod_Productos").Caption = "Código"
            .Columns("Tipo_Producto").Caption = "Tipo"
            .Columns("Descripcion_Producto").Caption = "Descripción"
            .Columns("Tipo_Precio").Caption = "Tipo Precio"
            .Columns("Monto_Precio").Caption = "Precio Córdobas"
            .Columns("Monto_PrecioDolar").Caption = "Precio Dólares"

        End With


        '========================================
        ' FORMATO DE PRECIOS
        '========================================

        TDGrigPreciosLeche.Columns("Monto_Precio").NumberFormat = "N2"
        TDGrigPreciosLeche.Columns("Monto_PrecioDolar").NumberFormat = "N2"

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try

            'Finalizar la edición del Grid
            TDGrigPreciosLeche.UpdateData()

            'Finalizar la edición del BindingSource
            If bsPreciosLeche IsNot Nothing Then
                bsPreciosLeche.EndEdit()
            End If

            If dtPreciosLeche Is Nothing Then
                MessageBox.Show("El DataTable no está cargado.")
                Exit Sub
            End If

            'Cantidad de filas modificadas
            Dim dtCambios As DataTable =
                dtPreciosLeche.GetChanges(DataRowState.Modified)

            If dtCambios Is Nothing Then

                MessageBox.Show(
                    "El DataTable no detecta ninguna fila modificada.",
                    "Guardar precios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Exit Sub

            End If

            MessageBox.Show(
                "Filas modificadas detectadas: " & dtCambios.Rows.Count.ToString(),
                "Prueba",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            'Guardar cambios
            If GuardarPreciosLeche(dtPreciosLeche) Then

                MessageBox.Show(
                    "Los precios fueron guardados correctamente.",
                    "Precios de leche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            MessageBox.Show(
                "No fue posible guardar los precios." &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BtnAjustar_Click(sender As Object, e As EventArgs) Handles BtnAjustar.Click

        Try

            Dim respuesta As DialogResult

            respuesta = MessageBox.Show(
                "¿Desea ajustar los precios de leche para todos los productores activos?",
                "Ajustar precios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then
                Exit Sub
            End If


            '=========================================================
            ' FINALIZAR EDICIÓN DEL GRID
            '=========================================================

            TDGrigPreciosLeche.UpdateData()

            If bsPreciosLeche IsNot Nothing Then
                bsPreciosLeche.EndEdit()
            End If


            '=========================================================
            ' VARIABLES PARA EL RESUMEN
            '=========================================================

            Dim productosProcesados As Integer = 0
            Dim productoresActivos As Integer = 0
            Dim registrosActualizados As Integer = 0
            Dim registrosNuevos As Integer = 0


            '=========================================================
            ' AJUSTAR PRECIOS
            '=========================================================

            If AjustarPreciosProductores(
                dtPreciosLeche,
                productosProcesados,
                productoresActivos,
                registrosActualizados,
                registrosNuevos) Then


                '=====================================================
                ' MOSTRAR RESUMEN
                '=====================================================

                Dim mensaje As String =
                    "AJUSTE DE PRECIOS COMPLETADO" &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Productos procesados : " &
                    productosProcesados.ToString() &
                    Environment.NewLine &
                    "Productores activos  : " &
                    productoresActivos.ToString() &
                    Environment.NewLine &
                    "Registros actualizados : " &
                    registrosActualizados.ToString() &
                    Environment.NewLine &
                    "Registros nuevos       : " &
                    registrosNuevos.ToString()


                MessageBox.Show(
                    mensaje,
                    "Ajustar precios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

            End If


        Catch ex As Exception

            MessageBox.Show(
                "No fue posible ajustar los precios." &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

End Class