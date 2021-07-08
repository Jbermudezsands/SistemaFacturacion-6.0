USE [SistemaFacturacionEmtrides]
GO

UPDATE [dbo].[Detalle_Compras]
   SET [Precio_Unitario] =  dbo.Productos.Descuento
      ,[Precio_Neto] = dbo.Productos.Descuento
      ,[Importe] = dbo.Detalle_Compras.Cantidad * dbo.Productos.Descuento
   FROM  dbo.Detalle_Compras INNER JOIN  dbo.Compras ON (Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra) INNER JOIN dbo.Productos ON (Detalle_Compras.Cod_Producto = Productos.Cod_Productos)
   WHERE (dbo.Compras.Cod_Bodega = '06');
GO


