USE [FerreDB]
GO

-- M4: Comprobante de Orden de Compra (se muestra al registrar el envio y se puede reimprimir).
-- No cambia el esquema: lee datos ya persistidos. El script se entrega, no se ejecuta.
-- Contenido: a) SP de solo lectura, b) traducciones ES/EN (prefijo OC_COMP_).

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- a) ObtenerComprobanteOrdenCompra_SP: una fila por linea de la orden, con la cabecera repetida.
-- CodigoProveedor y Descripcion salen de ListaPrecio (indice unico filtrado IdProveedor+Codigo: a lo sumo una fila).
-- Si el producto se desvinculo despues de generar la orden, se usa el Codigo y el Nombre de FerreSV.
-- Usuario creador / que decidio: Usuarios.Usuario (LEFT JOIN: la decision es NULL en una orden Pendiente).
-- Si la orden no existe devuelve cero filas.
CREATE PROCEDURE [dbo].[ObtenerComprobanteOrdenCompra_SP]
    @IdOrdenCompra INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT o.IdOrdenCompra, pv.Nombre AS Proveedor, o.Estado, o.FechaCreacion,
           uc.Usuario AS UsuarioCreacion, ud.Usuario AS UsuarioDecision, o.FechaDecision, o.FechaEnvio,
           ISNULL(lp.CodigoProveedor, d.Codigo) AS CodigoProveedor,
           ISNULL(lp.Descripcion, p.Nombre) AS Descripcion,
           d.Cantidad, d.PrecioUnitario
    FROM dbo.OrdenCompra o
    INNER JOIN dbo.Proveedores pv ON pv.IDProveedor = o.IdProveedor
    INNER JOIN dbo.DetalleOrdenCompra d ON d.IdOrdenCompra = o.IdOrdenCompra
    INNER JOIN dbo.Productos p ON p.Codigo = d.Codigo
    LEFT JOIN dbo.ListaPrecio lp ON lp.IdProveedor = o.IdProveedor AND lp.Codigo = d.Codigo
    LEFT JOIN dbo.Usuarios uc ON uc.Codigo = o.IdUsuarioCreacion
    LEFT JOIN dbo.Usuarios ud ON ud.Codigo = o.IdUsuarioDecision
    WHERE o.IdOrdenCompra = @IdOrdenCompra
    ORDER BY d.Codigo;
END
GO

-- b) Traducciones (IdIdioma 1 = ES, 2 = EN). Reutiliza FACT_COMP_BTN_IMPRIMIR, FACT_LBL_TOTAL, COMUN_FECHA y COMUN_SALIR.
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_TITULO', N'COMPROBANTE DE ORDEN DE COMPRA')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_NRO', N'Orden de compra Nro.:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_PROVEEDOR', N'Proveedor:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_GENERADA', N'Generada:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_GENERO', N'Genero:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_AUTORIZO', N'Autorizo:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_ENVIADA', N'Enviada:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_BTN_REIMPRIMIR', N'Reimprimir comprobante')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_ERR_ESTADO', N'El comprobante solo esta disponible para ordenes enviadas (en ejecucion o recibidas)')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_ERR_NO_EXISTE', N'La orden de compra no existe')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'OC_COMP_MSG_ERROR', N'No se pudo obtener el comprobante. Puede reimprimirlo desde esta pantalla')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_TITULO', N'PURCHASE ORDER RECEIPT')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_NRO', N'Purchase order No.:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_PROVEEDOR', N'Supplier:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_GENERADA', N'Created:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_GENERO', N'Created by:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_AUTORIZO', N'Authorized by:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_ENVIADA', N'Sent:')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_BTN_REIMPRIMIR', N'Reprint receipt')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_ERR_ESTADO', N'The receipt is only available for orders that were sent (in progress or received)')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_ERR_NO_EXISTE', N'The purchase order does not exist')
INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'OC_COMP_MSG_ERROR', N'The receipt could not be retrieved. You can reprint it from this screen')
GO
