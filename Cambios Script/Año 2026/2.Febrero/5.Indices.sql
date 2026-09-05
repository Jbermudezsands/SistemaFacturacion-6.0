CREATE INDEX IX_Clientes_Cod_Cliente ON Clientes (Cod_Cliente);
CREATE INDEX IX_Proveedor_Cod_Proveedor ON Proveedor (Cod_Proveedor);
CREATE INDEX IX_Productor_CodProductor_Tipo ON Productor (CodProductor, TipoProductor);
CREATE INDEX IX_Beneficiario_Codigo ON Beneficiario (Codigo_Beneficiario);