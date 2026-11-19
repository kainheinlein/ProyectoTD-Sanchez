USE [FerreDB]
GO

-- M3: modificar proveedor, baja logica y reactivacion (extiende el CUN-008).
-- Proveedores.Activo ya existe. Un proveedor inactivo no admite importaciones de lista ni ordenes de compra nuevas
-- y conserva su historial (ordenes y ListaPrecio). No se puede dar de baja el proveedor de referencia de un producto.
-- Contenido: a) SP nuevos, b) controles de proveedor inactivo en dos SP existentes, c) traducciones ES/EN.
-- El script se entrega, no se ejecuta.

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- a1) ContarProductosReferencia_SP: cuantos productos tienen a este proveedor como referencia
CREATE PROCEDURE [dbo].[ContarProductosReferencia_SP]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS Cantidad FROM dbo.Productos WHERE Proveedor = @IdProveedor;
END
GO

-- a2) ModificarProveedor_SP: modifica un proveedor activo. Si cambia el margen, recalcula en la misma
-- transaccion Productos.Precio de los productos vinculados cuyo proveedor de referencia es este.
-- La formula es la misma que usa ImportarListaPrecios_SP y ProveedorBE_883SC.CalcularPrecioVenta_883SC
-- (ROUND(PrecioLista * (1 + Margen/100), 2)): si cambia una, hay que cambiar las otras dos.
-- Solo cuentan (y se actualizan) los productos cuyo precio de venta cambia de valor; no toca Fecha_Actualizacion.
-- Errores: 50001 inactivo, 50002 no existe, 50003 nombre repetido. Devuelve una fila: PreciosActualizados.
CREATE PROCEDURE [dbo].[ModificarProveedor_SP]
    @IdProveedor   INT,
    @Nombre        NVARCHAR(50),
    @Especialidad  NVARCHAR(100) = NULL,
    @Telefono      NVARCHAR(30),
    @Direccion     NVARCHAR(50)  = NULL,
    @Margen        DECIMAL(5,2),
    @Observaciones NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @MargenActual DECIMAL(5,2), @Activo BIT;
    SELECT @MargenActual = Margen, @Activo = Activo
    FROM dbo.Proveedores WITH (UPDLOCK, HOLDLOCK)
    WHERE IDProveedor = @IdProveedor;

    IF @Activo IS NULL
        THROW 50002, 'El proveedor no existe', 1;
    IF @Activo = 0
        THROW 50001, 'El proveedor esta dado de baja', 1;
    IF EXISTS (SELECT 1 FROM dbo.Proveedores WHERE Nombre = @Nombre AND IDProveedor <> @IdProveedor)
        THROW 50003, 'Ya existe otro proveedor con ese nombre', 1;

    UPDATE dbo.Proveedores
    SET Nombre = @Nombre, Especialidad = @Especialidad, Telefono = @Telefono,
        Direccion = @Direccion, Margen = @Margen, Observaciones = @Observaciones
    WHERE IDProveedor = @IdProveedor;

    DECLARE @PreciosActualizados INT = 0;
    IF @MargenActual <> @Margen
    BEGIN
        UPDATE p
           SET p.Precio = CAST(ROUND(lp.PrecioLista * (1 + @Margen / 100.0), 2) AS DECIMAL(18,2))
        FROM dbo.Productos p
        INNER JOIN dbo.ListaPrecio lp
            ON lp.IdProveedor = p.Proveedor AND lp.Codigo = p.Codigo
        WHERE p.Proveedor = @IdProveedor
          AND p.Precio <> CAST(ROUND(lp.PrecioLista * (1 + @Margen / 100.0), 2) AS DECIMAL(18,2));

        SET @PreciosActualizados = @@ROWCOUNT;
    END

    COMMIT TRANSACTION;

    SELECT @PreciosActualizados AS PreciosActualizados;
END
GO

-- a3) BajaProveedor_SP: baja logica. 50002 no existe, 50001 ya esta dado de baja,
-- 50004 es el proveedor de referencia de algun producto (la BLL lo controla antes; esto cubre la concurrencia).
CREATE PROCEDURE [dbo].[BajaProveedor_SP]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Activo BIT;
    SELECT @Activo = Activo FROM dbo.Proveedores WITH (UPDLOCK, HOLDLOCK) WHERE IDProveedor = @IdProveedor;

    IF @Activo IS NULL
        THROW 50002, 'El proveedor no existe', 1;
    IF @Activo = 0
        THROW 50001, 'El proveedor ya esta dado de baja', 1;
    IF EXISTS (SELECT 1 FROM dbo.Productos WITH (UPDLOCK, HOLDLOCK) WHERE Proveedor = @IdProveedor)
        THROW 50004, 'El proveedor es el de referencia de algun producto', 1;

    UPDATE dbo.Proveedores SET Activo = 0 WHERE IDProveedor = @IdProveedor;

    COMMIT TRANSACTION;
END
GO

-- a4) ReactivarProveedor_SP: 50002 no existe, 50001 ya esta activo
CREATE PROCEDURE [dbo].[ReactivarProveedor_SP]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Activo BIT;
    SELECT @Activo = Activo FROM dbo.Proveedores WITH (UPDLOCK, HOLDLOCK) WHERE IDProveedor = @IdProveedor;

    IF @Activo IS NULL
        THROW 50002, 'El proveedor no existe', 1;
    IF @Activo = 1
        THROW 50001, 'El proveedor ya esta activo', 1;

    UPDATE dbo.Proveedores SET Activo = 1 WHERE IDProveedor = @IdProveedor;

    COMMIT TRANSACTION;
END
GO

-- b1) ImportarListaPrecios_SP: igual que antes, pero rechaza (50008) un proveedor dado de baja
ALTER PROCEDURE [dbo].[ImportarListaPrecios_SP]
    @IdProveedor INT,
    @Items       dbo.TipoItemListaPrecio READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DECLARE @Margen DECIMAL(5,2), @Activo BIT;
    SELECT @Margen = Margen, @Activo = Activo FROM dbo.Proveedores WHERE IDProveedor = @IdProveedor;
    IF @Margen IS NULL
        THROW 50007, 'El proveedor no existe', 1;
    IF @Activo = 0
        THROW 50008, 'El proveedor esta dado de baja', 1;

    DECLARE @Ahora DATETIME2 = SYSDATETIME();
    DECLARE @Acciones TABLE (Accion NVARCHAR(10));

    MERGE dbo.ListaPrecio WITH (HOLDLOCK) AS destino
    USING (SELECT CodigoProveedor, Descripcion, PrecioLista FROM @Items) AS origen
        ON destino.IdProveedor = @IdProveedor
       AND destino.CodigoProveedor = origen.CodigoProveedor
    WHEN MATCHED THEN
        UPDATE SET Descripcion = origen.Descripcion,
                   PrecioLista = origen.PrecioLista,
                   FechaActualizacion = @Ahora
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdProveedor, CodigoProveedor, Descripcion, Codigo, PrecioLista, FechaActualizacion)
        VALUES (@IdProveedor, origen.CodigoProveedor, origen.Descripcion, NULL, origen.PrecioLista, @Ahora)
    OUTPUT $action INTO @Acciones;

    --Solo cuentan los productos cuyo precio de venta cambia de valor
    DECLARE @Cambios TABLE (Codigo NVARCHAR(50));
    UPDATE p
       SET p.Precio = CAST(ROUND(lp.PrecioLista * (1 + @Margen / 100.0), 2) AS DECIMAL(18,2))
    OUTPUT inserted.Codigo INTO @Cambios (Codigo)
    FROM dbo.Productos p
    INNER JOIN dbo.ListaPrecio lp
        ON lp.IdProveedor = p.Proveedor AND lp.Codigo = p.Codigo
    WHERE p.Proveedor = @IdProveedor
      AND p.Precio <> CAST(ROUND(lp.PrecioLista * (1 + @Margen / 100.0), 2) AS DECIMAL(18,2));

    COMMIT TRANSACTION;

    SELECT
        (SELECT COUNT(*) FROM @Acciones WHERE Accion = 'INSERT')  AS Insertados,
        (SELECT COUNT(*) FROM @Acciones WHERE Accion = 'UPDATE')  AS Actualizados,
        (SELECT COUNT(*) FROM @Cambios)                           AS PreciosVentaActualizados,
        (SELECT COUNT(*) FROM dbo.ListaPrecio
          WHERE IdProveedor = @IdProveedor AND Codigo IS NULL)    AS Pendientes;
END
GO

-- b2) AltaOrdenesCompra_SP: igual que antes, pero rechaza (50003) una linea de un proveedor dado de baja
ALTER PROCEDURE [dbo].[AltaOrdenesCompra_SP]
    @IdUsuario INT,
    @Detalle dbo.TipoDetalleOrdenCompra READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM @Detalle)
        THROW 50001, 'La lista de compra esta vacia', 1;

    -- Cada linea debe corresponder a un producto vinculado a ese proveedor
    IF EXISTS (SELECT 1 FROM @Detalle d
               WHERE NOT EXISTS (SELECT 1 FROM ListaPrecio lp
                                 WHERE lp.IdProveedor = d.IdProveedor AND lp.Codigo = d.Codigo))
        THROW 50002, 'El producto no esta vinculado al proveedor', 1;

    -- No se generan ordenes nuevas para un proveedor dado de baja
    IF EXISTS (SELECT 1 FROM @Detalle d
               INNER JOIN Proveedores pv ON pv.IDProveedor = d.IdProveedor
               WHERE pv.Activo = 0)
        THROW 50003, 'El proveedor esta dado de baja', 1;

    DECLARE @Base INT;
    SELECT @Base = ISNULL(MAX(IdOrdenCompra), 0) FROM OrdenCompra WITH (UPDLOCK, HOLDLOCK);

    DECLARE @Ordenes TABLE (IdProveedor INT PRIMARY KEY, IdOrdenCompra INT NOT NULL);
    INSERT INTO @Ordenes (IdProveedor, IdOrdenCompra)
    SELECT IdProveedor, @Base + ROW_NUMBER() OVER (ORDER BY IdProveedor)
    FROM (SELECT DISTINCT IdProveedor FROM @Detalle) x;

    INSERT INTO OrdenCompra (IdOrdenCompra, IdProveedor, Estado, FechaCreacion, IdUsuarioCreacion)
    SELECT IdOrdenCompra, IdProveedor, 'Pendiente', SYSDATETIME(), @IdUsuario FROM @Ordenes;

    INSERT INTO DetalleOrdenCompra (IdOrdenCompra, Codigo, Cantidad, PrecioUnitario)
    SELECT o.IdOrdenCompra, d.Codigo, d.Cantidad, d.PrecioUnitario
    FROM @Detalle d INNER JOIN @Ordenes o ON o.IdProveedor = d.IdProveedor;

    COMMIT TRANSACTION;

    SELECT IdOrdenCompra, IdProveedor FROM @Ordenes ORDER BY IdOrdenCompra;
END
GO

-- c) Traducciones (solo ES/EN; PT no se implementa)
INSERT INTO [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES
(1, N'PROV_ABM_TITULO', N'GESTION DE PROVEEDORES'),
(1, N'PROV_ABM_GB_DATOS', N'Datos del proveedor'),
(1, N'PROV_ABM_GB_MENSAJES', N'Mensajes'),
(1, N'PROV_ABM_LBL_OPCIONES', N'Opciones'),
(1, N'PROV_ABM_CHK_INACTIVOS', N'Mostrar inactivos'),
(1, N'PROV_ABM_BTN_CREAR', N'Crear Proveedor'),
(1, N'PROV_ABM_BTN_MODIFICAR', N'Modificar Proveedor'),
(1, N'PROV_ABM_BTN_ELIMINAR', N'Eliminar Proveedor'),
(1, N'PROV_ABM_BTN_REACTIVAR', N'Reactivar Proveedor'),
(1, N'PROV_ABM_MSG_ACTUALIZADO', N'Proveedor {0} actualizado correctamente. Precios de venta recalculados: {1}.'),
(1, N'PROV_ABM_MSG_BAJA_OK', N'Proveedor {0} dado de baja.'),
(1, N'PROV_ABM_MSG_REACTIVADO', N'Proveedor {0} reactivado.'),
(1, N'PROV_ABM_MSG_CONFIRMA_ELIMINAR', N'Desea dar de baja al proveedor {0}?'),
(1, N'PROV_ABM_MSG_CONFIRMA_REACTIVAR', N'Desea reactivar al proveedor {0}?'),
(1, N'PROV_ABM_ERR_NO_EXISTE', N'El proveedor no existe.'),
(1, N'PROV_ABM_ERR_INACTIVO', N'El proveedor esta dado de baja. Reactivelo antes de modificarlo.'),
(1, N'PROV_ABM_ERR_YA_ACTIVO', N'El proveedor ya esta activo.'),
(1, N'PROV_ABM_ERR_REFERENCIA', N'No se puede dar de baja: es el proveedor de referencia de {0} producto(s).'),
(1, N'PROD_ERR_PROV_INACTIVO', N'El proveedor esta dado de baja y no puede ser el proveedor de referencia del producto.'),
(1, N'LIST_ERR_PROV_INACTIVO', N'El proveedor esta dado de baja: no se pueden importar listas de precios.'),
(2, N'PROV_ABM_TITULO', N'SUPPLIER MANAGEMENT'),
(2, N'PROV_ABM_GB_DATOS', N'Supplier data'),
(2, N'PROV_ABM_GB_MENSAJES', N'Messages'),
(2, N'PROV_ABM_LBL_OPCIONES', N'Options'),
(2, N'PROV_ABM_CHK_INACTIVOS', N'Show inactive'),
(2, N'PROV_ABM_BTN_CREAR', N'Create Supplier'),
(2, N'PROV_ABM_BTN_MODIFICAR', N'Edit Supplier'),
(2, N'PROV_ABM_BTN_ELIMINAR', N'Delete Supplier'),
(2, N'PROV_ABM_BTN_REACTIVAR', N'Reactivate Supplier'),
(2, N'PROV_ABM_MSG_ACTUALIZADO', N'Supplier {0} updated successfully. Sale prices recalculated: {1}.'),
(2, N'PROV_ABM_MSG_BAJA_OK', N'Supplier {0} deactivated.'),
(2, N'PROV_ABM_MSG_REACTIVADO', N'Supplier {0} reactivated.'),
(2, N'PROV_ABM_MSG_CONFIRMA_ELIMINAR', N'Do you want to deactivate supplier {0}?'),
(2, N'PROV_ABM_MSG_CONFIRMA_REACTIVAR', N'Do you want to reactivate supplier {0}?'),
(2, N'PROV_ABM_ERR_NO_EXISTE', N'The supplier does not exist.'),
(2, N'PROV_ABM_ERR_INACTIVO', N'The supplier is deactivated. Reactivate it before editing.'),
(2, N'PROV_ABM_ERR_YA_ACTIVO', N'The supplier is already active.'),
(2, N'PROV_ABM_ERR_REFERENCIA', N'It cannot be deactivated: it is the reference supplier of {0} product(s).'),
(2, N'PROD_ERR_PROV_INACTIVO', N'The supplier is deactivated and cannot be the reference supplier of the product.'),
(2, N'LIST_ERR_PROV_INACTIVO', N'The supplier is deactivated: price lists cannot be imported.')
GO
