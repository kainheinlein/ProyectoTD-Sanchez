USE [FerreDB]
GO

-- M5: reordenamiento del menu. Gestion -> Productos pasa a ser submenu (Administrar / Importar Lista de Precios, antes en Compras)
-- y Maestros -> Productos y Usuarios abren los ABM (Administrar Productos y frmUsuario). Unica clave nueva: MENU_ADMINISTRAR_PRODUCTOS (ES/EN).
-- El resto de los items reutiliza claves existentes (MENU_IMPORTAR_LISTA, MENU_MAESTRO_*).
-- El script se entrega, no se ejecuta.

IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'MENU_ADMINISTRAR_PRODUCTOS')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'MENU_ADMINISTRAR_PRODUCTOS', N'Administrar')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'MENU_ADMINISTRAR_PRODUCTOS')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'MENU_ADMINISTRAR_PRODUCTOS', N'Manage')
GO
