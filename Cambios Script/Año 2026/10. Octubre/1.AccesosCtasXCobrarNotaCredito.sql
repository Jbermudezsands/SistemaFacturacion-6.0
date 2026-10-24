-- Cuentas por Cobrar: el boton "Nota de credito" (Button1) lleva Tag 26 = Anular.
-- Antes FrmAccesos no mostraba "Anular" para el modulo "Ctas x Cobrar", asi que al guardar el perfil
-- quedaba "NoAnular" y el boton se apagaba aunque el usuario tuviera el resto de accesos.
-- Este script devuelve el permiso a los perfiles que ya tienen acceso a Consultar/Recibos en el modulo.
-- Ajuste @Perfil si solo quiere corregir uno (NULL = todos los que tengan Grabar y Procesar concedidos).
DECLARE @Perfil NVARCHAR(100) = NULL;

UPDATE a
SET a.Acceso = REPLACE(a.Acceso, 'NoAnular', 'Anular')
FROM Accesos a
INNER JOIN Perfil p ON p.IdPerfil = a.IdPerfil
WHERE a.Modulo = 'Ctas x Cobrar'
  AND a.Acceso LIKE '%NoAnular%'
  AND (   (@Perfil IS NOT NULL AND p.NombrePerfil = @Perfil)
       OR (@Perfil IS NULL AND a.Acceso LIKE '%Grabar%' AND a.Acceso NOT LIKE '%NoGrabar%'
                           AND a.Acceso LIKE '%Procesar%' AND a.Acceso NOT LIKE '%NoProcesar%'));
