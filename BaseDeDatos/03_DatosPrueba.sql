-- FerreSV - Datos de prueba: proveedores, listas de precios y productos (con stock variado).
-- Lo ejecuta la aplicacion (Admin -> Cargar datos de prueba, DatosPruebaBLL) DENTRO de una transaccion que abre el Mapper,
-- despues de hacer el backup PreDatosPrueba_*.bak. NO lleva USE: corre en la base de la conexion. Es un solo lote (sin GO).
-- Los clientes (la direccion se cifra en la BLL) y los usuarios (digito verificador) NO se cargan aca: los crea la BLL.
-- Todo entra por los procedimientos de la aplicacion (AltaProveedor_SP, ImportarListaPrecios_SP, AltaProductoVinculado_SP);
-- el stock inicial se asigna despues del alta (el alta deja stock 0). No pisa nada: si hay datos, lanza el error 50001.
--
-- Datos armados a partir de los de FerreDB (arandela, cupla de bronce, pinza de corte, codo PVC, tornillo inox) y ampliados.
-- Para que NO choquen con ListaFenix.csv (importacion de prueba del proveedor "Fenix"):
--   * los proveedores se llaman distinto de "Fenix";
--   * los codigos de producto son FSV-001..FSV-014 y los codigos de proveedor P1-.., P2-.., P3-.., P4-..;
--     el .csv usa codigos numericos tipo 1000/01, 4699/27, CI-123, CD-123, 123EC... (se verifico que no hay ninguno igual).
-- Precio de venta = ROUND(PrecioLista * (1 + Margen/100), 2), igual que ProveedorBE.CalcularPrecioVenta_883SC.

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF EXISTS (SELECT 1 FROM dbo.Proveedores) OR EXISTS (SELECT 1 FROM dbo.Productos) OR EXISTS (SELECT 1 FROM dbo.ListaPrecio)
   OR EXISTS (SELECT 1 FROM dbo.Clientes) OR EXISTS (SELECT 1 FROM dbo.Facturas) OR EXISTS (SELECT 1 FROM dbo.OrdenCompra)
    THROW 50001, 'La base ya tiene datos: los datos de prueba solo se cargan en una base vacia', 1;

DECLARE @DefProv TABLE (Nro INT PRIMARY KEY, Nombre NVARCHAR(50), Especialidad NVARCHAR(100), Telefono NVARCHAR(30),
                        Direccion NVARCHAR(50), Margen DECIMAL(5,2), Observaciones NVARCHAR(200));
INSERT INTO @DefProv (Nro, Nombre, Especialidad, Telefono, Direccion, Margen, Observaciones) VALUES
 (1, N'Ferrosur Distribuciones',  N'Ferreteria general',                 N'1147001001', N'Av. Rivadavia 4500',   35.00, N'Proveedor de prueba'),
 (2, N'Mayorista Pampa',          N'Tornilleria y bulonería',            N'1147002002', N'Calle 9 de Julio 120', 40.00, N'Proveedor de prueba'),
 (3, N'Sanitarios del Litoral',   N'Sanitarios y plomería',              N'3414003003', N'Ruta 9 km 45',         45.00, N'Proveedor de prueba'),
 (4, N'Herramientas Andina',      N'Herramientas manuales y eléctricas', N'2614004004', N'Av. San Martin 800',    30.00, N'Proveedor de prueba');

-- Items de la lista de cada proveedor. Codigo no nulo = se vincula a un producto (se da de alta); nulo = item pendiente de vincular.
DECLARE @DefItem TABLE (Prov INT, CodigoProveedor NVARCHAR(50), Descripcion NVARCHAR(200), PrecioLista DECIMAL(18,2),
                        Codigo NVARCHAR(50) NULL, Nombre NVARCHAR(50) NULL, StockMinimo INT NULL, Stock INT NULL,
                        PRIMARY KEY (Prov, CodigoProveedor));
INSERT INTO @DefItem (Prov, CodigoProveedor, Descripcion, PrecioLista, Codigo, Nombre, StockMinimo, Stock) VALUES
 -- Ferrosur Distribuciones (35%)
 (1, N'P1-0001', N'Arandela PVC 1/2',                 15.00,   N'FSV-001', N'Arandela PVC',            50, 120),
 (1, N'P1-0002', N'Cinta teflon 12mm',               450.00,   N'FSV-002', N'Cinta Teflon 12mm',       20,   8),
 (1, N'P1-0003', N'Candado bronce 40mm',            4200.00,   N'FSV-003', N'Candado Bronce 40mm',     10,  35),
 (1, N'P1-0004', N'Pinza de corte 30mm',            2600.00,   N'FSV-004', N'Pinza de Corte 30mm',     10,   9),
 (1, N'P1-0901', N'Sellador de roscas 100g',         980.00,   NULL, NULL, NULL, NULL),
 (1, N'P1-0902', N'Cinta aisladora negra 20m',       620.00,   NULL, NULL, NULL, NULL),
 -- Mayorista Pampa (40%)
 (2, N'P2-0001', N'Tornillo inox 22x70',              36.00,   N'FSV-005', N'Tornillo Inox 22x70',     30,  95),
 (2, N'P2-0002', N'Tarugo nylon 8mm x100',          1100.00,   N'FSV-006', N'Tarugo Nylon 8mm x100',   15,   0),
 (2, N'P2-0003', N'Bulon hexagonal 3/8 x 2 pulg',     85.50,   N'FSV-007', N'Bulon Hexagonal 3/8',    100, 300),
 (2, N'P2-0901', N'Tuerca hexagonal 3/8',             22.40,   NULL, NULL, NULL, NULL),
 (2, N'P2-0902', N'Arandela plana 3/8',               12.75,   NULL, NULL, NULL, NULL),
 -- Sanitarios del Litoral (45%)
 (3, N'P3-0001', N'Codo PVC 1/2',                   1062.40,   N'FSV-008', N'Codo PVC 1/2',            10,  12),
 (3, N'P3-0002', N'Cupla bronce 1/2',               1300.00,   N'FSV-009', N'Cupla Bronce 1/2',        10,   0),
 (3, N'P3-0003', N'Canilla de paso 1/2',            5200.00,   N'FSV-010', N'Canilla de Paso 1/2',      8,  22),
 (3, N'P3-0004', N'Cano PVC 110mm x 4m',           18500.00,   N'FSV-011', N'Cano PVC 110mm x 4m',      6,   5),
 (3, N'P3-0901', N'Sifon plastico doble',           3400.00,   NULL, NULL, NULL, NULL),
 (3, N'P3-0902', N'Flexible malla 40cm',            2100.00,   NULL, NULL, NULL, NULL),
 -- Herramientas Andina (30%)
 (4, N'P4-0001', N'Taladro percutor 650W',         74000.00,   N'FSV-012', N'Taladro Percutor 650W',    2,   4),
 (4, N'P4-0002', N'Martillo carpintero 500g',       9800.00,   N'FSV-013', N'Martillo Carpintero 500g', 5,  18),
 (4, N'P4-0003', N'Destornillador Phillips PH2',    3100.00,   N'FSV-014', N'Destornillador Phillips', 12,   3),
 (4, N'P4-0901', N'Llave francesa 10 pulg',        12500.00,   NULL, NULL, NULL, NULL),
 (4, N'P4-0902', N'Metro de acero 5m',              2800.00,   NULL, NULL, NULL, NULL);

DECLARE @Nro INT = 1, @IdProv INT, @Margen DECIMAL(5,2);
DECLARE @Items dbo.TipoItemListaPrecio;

WHILE @Nro <= (SELECT MAX(Nro) FROM @DefProv)
BEGIN
    DECLARE @Nombre NVARCHAR(50), @Esp NVARCHAR(100), @Tel NVARCHAR(30), @Dir NVARCHAR(50), @Obs NVARCHAR(200);
    SELECT @Nombre = Nombre, @Esp = Especialidad, @Tel = Telefono, @Dir = Direccion, @Margen = Margen, @Obs = Observaciones
    FROM @DefProv WHERE Nro = @Nro;

    -- Alta del proveedor (devuelve el IDProveedor; se lo vuelve a leer por nombre, que es unico)
    EXEC dbo.AltaProveedor_SP @Nombre = @Nombre, @Especialidad = @Esp, @Telefono = @Tel, @Direccion = @Dir,
                              @Margen = @Margen, @Observaciones = @Obs;
    SELECT @IdProv = IDProveedor FROM dbo.Proveedores WHERE Nombre = @Nombre;

    -- Lista de precios completa del proveedor (items vinculables y pendientes)
    DELETE FROM @Items;
    INSERT INTO @Items (CodigoProveedor, Descripcion, PrecioLista)
    SELECT CodigoProveedor, Descripcion, PrecioLista FROM @DefItem WHERE Prov = @Nro;
    EXEC dbo.ImportarListaPrecios_SP @IdProveedor = @IdProv, @Items = @Items;

    -- Productos: alta + vinculo con su item (stock 0; el precio de venta aplica el margen del proveedor)
    DECLARE @Cod NVARCHAR(50), @CodProv NVARCHAR(50), @Nom NVARCHAR(50), @Desc NVARCHAR(200), @Min INT, @Precio DECIMAL(18,2);
    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT Codigo, CodigoProveedor, Nombre, Descripcion, StockMinimo,
               CAST(ROUND(PrecioLista * (1 + @Margen / 100.0), 2) AS DECIMAL(18,2))
        FROM @DefItem WHERE Prov = @Nro AND Codigo IS NOT NULL ORDER BY Codigo;
    OPEN cur;
    FETCH NEXT FROM cur INTO @Cod, @CodProv, @Nom, @Desc, @Min, @Precio;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC dbo.AltaProductoVinculado_SP @Codigo = @Cod, @Nombre = @Nom, @Descripcion = @Desc, @StockMinimo = @Min,
                                          @Precio = @Precio, @IdProveedor = @IdProv, @CodigoProveedor = @CodProv;
        FETCH NEXT FROM cur INTO @Cod, @CodProv, @Nom, @Desc, @Min, @Precio;
    END
    CLOSE cur;
    DEALLOCATE cur;

    SET @Nro += 1;
END

-- Stock inicial variado (varios productos quedan por debajo del minimo)
UPDATE p SET p.Stock = d.Stock
FROM dbo.Productos p
INNER JOIN @DefItem d ON d.Codigo = p.Codigo
WHERE d.Codigo IS NOT NULL;
