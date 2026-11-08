-- Normaliza IndiceNota.MonedaNota: el valor valido es 'Cordobas' (sin tilde).
-- Caso detectado: nota M03244 (cliente J2338) guardada como 'Córdobas'; la ventana
-- de Notas la trataba como moneda distinta y multiplicaba el monto por la tasa de cambio.
UPDATE IndiceNota
SET MonedaNota = 'Cordobas'
WHERE MonedaNota COLLATE Latin1_General_CS_AS <> 'Cordobas'
  AND MonedaNota COLLATE Latin1_General_CI_AI = 'Cordobas';
GO
