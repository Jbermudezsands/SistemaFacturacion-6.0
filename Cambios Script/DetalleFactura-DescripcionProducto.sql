USE [ZeusFacturacionLP1]
GO

UPDATE [dbo].[Detalle_Facturas]
   SET [Descripcion_Producto] = dbo.Productos.Descripcion_Producto 
   FROM dbo.Detalle_Facturas INNER JOIN dbo.Productos ON (dbo.Detalle_Facturas.Cod_Producto = dbo.Productos.Cod_Productos);
GO


