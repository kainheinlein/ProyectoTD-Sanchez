USE [FerreDB]
GO

-- S4: mensajes comprensibles para fallos de backup/restore por permisos, ruta o disco.
-- Claves nuevas (ES/EN): BKP_ERR_SQL_ACCESO, BKP_ERR_SQL_RUTA, BKP_ERR_SQL_DISCO, BKP_ERR_SQL_OTRO, BKP_ERR_SIN_LECTURA.
-- {0} se reemplaza por la carpeta de backups. El mismo contenido esta en Instalacion/02_DatosBase.sql (instalaciones nuevas).
-- El script se entrega, no se ejecuta. Es idempotente.

IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'BKP_ERR_SIN_LECTURA')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'BKP_ERR_SIN_LECTURA', N'No se pudo comprobar el archivo de backup: su usuario de Windows no tiene permiso para acceder a la carpeta {0}. Esto no significa que el archivo no exista. Pida al encargado que revise los permisos de la carpeta.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'BKP_ERR_SQL_ACCESO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'BKP_ERR_SQL_ACCESO', N'SQL Server no pudo acceder a la carpeta de backups {0}. El archivo lo escribe y lo lee el servicio de SQL Server, no su usuario de Windows. Pida al encargado que otorgue permisos sobre esa carpeta al servicio de SQL Server.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'BKP_ERR_SQL_DISCO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'BKP_ERR_SQL_DISCO', N'No hay espacio suficiente en el disco de la carpeta {0} para el backup. Libere espacio en el servidor y vuelva a intentarlo.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'BKP_ERR_SQL_OTRO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'BKP_ERR_SQL_OTRO', N'SQL Server no pudo completar la operacion con el archivo de backup. Si el problema persiste, informe este mensaje al encargado. Detalle de SQL Server:')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 1 AND [Clave] = N'BKP_ERR_SQL_RUTA')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (1, N'BKP_ERR_SQL_RUTA', N'La carpeta de backups {0} no existe en el servidor de SQL Server. Pida al encargado que la cree o que revise la configuracion de la instancia.')
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'BKP_ERR_SIN_LECTURA')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'BKP_ERR_SIN_LECTURA', N'The backup file could not be checked: your Windows user has no permission to access the folder {0}. This does not mean the file does not exist. Ask the administrator to review the folder permissions.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'BKP_ERR_SQL_ACCESO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'BKP_ERR_SQL_ACCESO', N'SQL Server could not access the backup folder {0}. The file is written and read by the SQL Server service, not by your Windows user. Ask the administrator to grant that folder permissions to the SQL Server service.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'BKP_ERR_SQL_DISCO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'BKP_ERR_SQL_DISCO', N'There is not enough disk space for the backup in {0}. Free up space on the server and try again.')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'BKP_ERR_SQL_OTRO')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'BKP_ERR_SQL_OTRO', N'SQL Server could not complete the operation on the backup file. If the problem persists, report this message to the administrator. SQL Server detail:')
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE [IdIdioma] = 2 AND [Clave] = N'BKP_ERR_SQL_RUTA')
    INSERT [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto]) VALUES (2, N'BKP_ERR_SQL_RUTA', N'The backup folder {0} does not exist on the SQL Server machine. Ask the administrator to create it or review the instance configuration.')
GO
