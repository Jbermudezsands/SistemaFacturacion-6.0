# CLAUDE.md

Guía para trabajar en este repositorio. Idioma del proyecto: **español** (nombres de formularios, tablas, mensajes de usuario y comentarios).

## Qué es

**Sistema de Facturación 6.0 ("Zeus Facturación")**: aplicación de escritorio Windows Forms en **VB.NET** (solución de Visual Studio 2019, `.sln` en la raíz). Cubre facturación, compras, inventario/kardex con lotes, cuentas por cobrar y recibos, caja, planillas/créditos (plan de pago, financiamiento, deducciones) y más de 350 reportes. Hay varias instalaciones de clientes con variantes (colegios, instituto, etc.).

## Estructura del repositorio

La raíz mezcla código fuente vivo, copias de respaldo, binarios y utilitarios. **El código activo está solo en `Sistema Facturacion/`.**

| Carpeta | Contenido |
|---|---|
| `Sistema Facturacion/` | Proyecto principal `Sistema Facturacion 6.0.vbproj` (WinExe, namespace raíz `Sistema_Facturacion`, ensamblado `Sistema Facturacion 6.0`) |
| `Instalador/` | Instalador (`InstalarCompleto.vdproj`, referenciado en la `.sln`), `CntFacturacion.dll`, `CntConta.dll` |
| `Imprime/`, `Imprime Instituto/`, `EXE Server/`, `Actualizacion Sistemas/` | Utilitarios legados en **VB6** (`.vbp`, `.frm`, `.bas`): impresión de cheques, servidor, actualizador. No se compilan con la solución |
| `Cambios Script/` | Scripts SQL de cambios de esquema organizados por año (2010–2026), `SistemaFacturacionBlanco.sql` (BD en blanco), `.bak` |
| `QuerySQL/` | Consultas SQL de referencia (existencias por lote/bodega/producto, etc.) |
| `Formatos Excel/` | Plantillas de importación (inventario, clientes, proveedores, precios, contratos) |
| `Auditoria/` | Documento de hallazgos de auditoría del sistema |
| `Backup/`, `Backup1/` | Copias antiguas del proyecto. **No editar**; ignorarlas al buscar código |
| `FrmComprasGenerales.*`, `FrmReportes.Designer.vb` (raíz) | Archivos sueltos fuera del proyecto; confirmar antes de tocarlos |

## Estructura de `Sistema Facturacion/`

- `Formularios/` – formularios nuevos/refactorizados (`FrmRecibos_v2`, `FrmPlanPago`, `FrmCreditosNuevos`, `FrmDesembolsos`, `FrmDeduccionPlanilla`, …).
- Raíz del proyecto – la mayoría de los formularios históricos (`FrmXxx.vb`, `FormMDI.vb` como contenedor MDI principal).
- `Clases/` – lógica de negocio y acceso a datos: servicios (`ServicioRecibos`, `PlanPagoReciboService`, `FacturasCreditoService`, `TipoPrestamoService`), el módulo CxC (`CxC_Motor`, `CxC_Servicio`, `CxC_Repositorio`, `CxC_Recibos`, `CxC_Modelos`), kardex/costos (`MovimientoKardex`, `RstCostoPromedio`), modelos (`Beneficiario`, `Lote`, `Modalidad`…) y `CsLogError`/`Auditoria`.
- `Modulos/` – utilidades globales (`Mod_Shared`, `MotorCostos`, `aletras` / `Cls_NumSpanishWord` para montos en letras, `Conversion`).
- `Formularios DevExpress/` – patrón más moderno de referencia: `Modalidad` (modelo) + `ModalidadRepository` (SQL) + `ModalidadService` (validación) + formulario.
- `Reportes/` – ~370 reportes **ActiveReports 3** (`ArepXxx.vb` + `.Designer.vb` + `.resx`).
- `Resources/`, `My Project/`, `app.config`.
- `Respaldo/`, `bin/`, `obj/`, `.vs/` – no relevantes.

## Stack y dependencias

- VB.NET WinForms sobre **.NET Framework 4.0** (proyecto de formato antiguo). No usar características posteriores a 4.0 (p. ej. `Async/Await`, `HttpClient`, interpolación de cadenas `$""`).
- Base de datos: **SQL Server** vía `System.Data.SqlClient`; hay uso heredado de **ADODB/DAO** (referencias COM).
- La cadena de conexión a SQL Server está en la variable global **`Conexion`**. Usarla al abrir conexiones (`New SqlConnection(Conexion)`) y pasarla a los repositorios/servicios nuevos (p. ej. `New ModalidadService(Conexion)`); no escribir cadenas de conexión a mano.
- Controles/reportes de terceros con licencia: **ActiveReports 5.2**, **ComponentOne (C1) 2.0** (FlexGrid, TrueDBGrid, Ribbon, Input, Chart, Excel…). Referencias COM a Office Interop (Excel).
- Compilar requiere tener instalados y licenciados esos componentes en la máquina; sin ellos el build falla.

## Compilar y ejecutar

Solo con **Visual Studio 2019+** en Windows (no hay CI ni tests automatizados):

- Abrir `Sistema de Facturacion 6.0.sln`, configuración `Debug|Any CPU`, ejecutar con F5.
- Por línea de comandos (desde "Developer PowerShell for VS"): `msbuild "Sistema de Facturacion 6.0.sln" /p:Configuration=Debug`. Si `msbuild` no está en el PATH, no insistir: pedir al usuario que compile desde VS.
- No hay suite de pruebas. Verificar cambios compilando y probando el formulario/reporte afectado manualmente.
- `git` puede no estar en el PATH de PowerShell en esta máquina.

## Convenciones del código

- Los **formularios clásicos** acceden a datos directamente; el código **nuevo** sigue el patrón *Modelo → Repositorio (SQL con `Using cn As New SqlConnection(...)`) → Servicio (validaciones, `ArgumentException` con mensaje en español) → Formulario*. Preferir este patrón y consultas **parametrizadas** (`SqlParameter`); no concatenar valores en SQL.
- Código compatible con .NET Framework 4.0 y VB de esa época.
- Código nuevo: `Option Strict On` / `Option Explicit On`. Mantener nombres en español, prefijos `Frm` (formularios), `Arep` (reportes ActiveReports), `Cs` (clases), `Mod_` (módulos).
- Los `.Designer.vb` y `.resx` los genera Visual Studio: no editarlos a mano salvo que sea imprescindible; al añadir un archivo nuevo, **registrarlo en el `.vbproj`** (`<Compile Include=...>` / `<EmbeddedResource>`).
- Codificación de archivos: algunos `.vb` están en ANSI/Windows-1252 con tildes y ñ; al editar, **preservar la codificación original** (si se ve "Ã³" en lugar de "ó", se ha corrompido).
- Cambios de esquema: agregar un script SQL en `Cambios Script/Año <AAAA>/` en lugar de modificar `SistemaFacturacionBlanco.sql` sin necesidad, y mantener scripts idempotentes (`IF NOT EXISTS`/`IF COL_LENGTH`).

## Precauciones

- Es software contable/fiscal: cuidado con redondeos, costos promedio, kardex y saldos de CxC. Cualquier cambio en `MotorCostos`, `CxC_*`, recibos o notas de crédito debe revisarse con especial atención y no alterar datos históricos.
- No tocar `Backup/`, `Backup1/`, `Respaldo/`, binarios (`.exe`, `.dll`, `.ocx`, `.rar`, `.zip`) ni archivos de usuario de VS (`.suo`, `.vs/`).
- Hay un `.sln` adicional (`Sistema de Facturacion Colegios - copia.sln`): es una copia; el oficial es `Sistema de Facturacion 6.0.sln`.
- Rama de trabajo actual al crear este archivo: `ReparacionRecibo`; rama principal: `master`.
