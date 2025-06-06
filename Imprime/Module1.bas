Attribute VB_Name = "Module1"
Public Conexion As String, ConexionAccess As String
Public TipoImpresion As String, NumeroImpresion As String, FechaImpresion As Date, FacturaSerie As Boolean

Function BuscaTasa(FechaTasa As Date) As Double
  Dim Fecha As String
  
  Fecha = Format(FechaTasa, "yyyy-mm-dd")

  FrmImprime.AdoTasa.ConnectionString = Conexion
  FrmImprime.AdoTasa.RecordSource = "SELECT FechaTasa, MontoTasa From TasaCambio WHERE  (FechaTasa = CONVERT(DATETIME, '" & Fecha & "', 102))"
  FrmImprime.AdoTasa.Refresh
  If Not FrmImprime.AdoTasa.Recordset.EOF Then
   If Not IsNull(FrmImprime.AdoTasa.Recordset("MontoTasa")) Then
    BuscaTasa = FrmImprime.AdoTasa.Recordset("MontoTasa")
   Else
    BuscaTasa = 0
   End If
  Else
    BuscaTasa = 0
  End If


End Function

Function FacturaExonerada(NumeroFactura As String) As Boolean

  FrmImprime.DtaConsulta.ConnectionString = Conexion
  FrmImprime.DtaConsulta.RecordSource = "SELECT   * From Facturas WHERE (Tipo_Factura = 'Factura') AND (Exonerado = 1) AND (Numero_Factura = '" & NumeroFactura & "')"
  FrmImprime.DtaConsulta.Refresh
  If Not FrmImprime.DtaConsulta.Recordset.EOF Then
     FacturaExonerada = True
  Else
    FacturaExonerada = False
  End If



End Function





