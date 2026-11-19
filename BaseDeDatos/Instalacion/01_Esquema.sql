-- FerreSV - Instalacion: esquema (tablas, TVP, indices, restricciones y stored procedures).
-- Se ejecuta contra una base ya creada y seleccionada por la cadena de conexion. Idempotente. Separador: GO.
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Objeto: UserDefinedTableType [dbo].[TipoDetalleCarrito] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TipoDetalleCarrito' AND ss.name = N'dbo')
CREATE TYPE [dbo].[TipoDetalleCarrito] AS TABLE(
	[Codigo] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL
)
GO
/****** Objeto: UserDefinedTableType [dbo].[TipoDetalleFactura] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TipoDetalleFactura' AND ss.name = N'dbo')
CREATE TYPE [dbo].[TipoDetalleFactura] AS TABLE(
	[Codigo] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL
)
GO
/****** Objeto: UserDefinedTableType [dbo].[TipoDetalleOrdenCompra] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TipoDetalleOrdenCompra' AND ss.name = N'dbo')
CREATE TYPE [dbo].[TipoDetalleOrdenCompra] AS TABLE(
	[IdProveedor] [int] NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL
)
GO
/****** Objeto: UserDefinedTableType [dbo].[TipoItemListaPrecio] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TipoItemListaPrecio' AND ss.name = N'dbo')
CREATE TYPE [dbo].[TipoItemListaPrecio] AS TABLE(
	[CodigoProveedor] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[PrecioLista] [decimal](18, 2) NOT NULL
)
GO
/****** Objeto: UserDefinedTableType [dbo].[TipoRecepcionLinea] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TipoRecepcionLinea' AND ss.name = N'dbo')
CREATE TYPE [dbo].[TipoRecepcionLinea] AS TABLE(
	[Codigo] [nvarchar](100) NOT NULL,
	[CantidadRecibida] [int] NOT NULL
)
GO
/****** Objeto: Table [dbo].[Backups] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Backups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Backups](
	[IdBackup] [int] IDENTITY(1,1) NOT NULL,
	[NombreArchivo] [nvarchar](260) NOT NULL,
	[Ruta] [nvarchar](260) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[TamanioBytes] [bigint] NULL,
	[Verificado] [bit] NOT NULL,
 CONSTRAINT [PK_Backups] PRIMARY KEY CLUSTERED 
(
	[IdBackup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Bitacora] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bitacora]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bitacora](
	[Registro] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Accion] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Detalle] [nvarchar](500) NULL
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Carrito] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carrito]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Carrito](
	[IDCarrito] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fecha_creacion] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[IDCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Clientes] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clientes](
	[DNI] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[Direccion] [nvarchar](500) NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Detalle_Carrito] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Detalle_Carrito]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Detalle_Carrito](
	[IDCarrito] [int] NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Detalle_Carrito] PRIMARY KEY CLUSTERED 
(
	[IDCarrito] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Detalle_Factura] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Detalle_Factura]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Detalle_Factura](
	[IDFactura] [int] NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Detalle_Factura] PRIMARY KEY CLUSTERED 
(
	[IDFactura] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[DetalleOrdenCompra] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DetalleOrdenCompra](
	[IdOrdenCompra] [int] NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[CantidadRecibida] [int] NULL,
 CONSTRAINT [PK_DetalleOrdenCompra] PRIMARY KEY CLUSTERED 
(
	[IdOrdenCompra] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[DigitoVertical] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DigitoVertical]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DigitoVertical](
	[Tabla] [nvarchar](50) NOT NULL,
	[DVV] [nvarchar](65) NOT NULL
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Facturas] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facturas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Facturas](
	[IDFactura] [int] NOT NULL,
	[fecha_venta] [datetime2](3) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[IDCarrito] [int] NOT NULL,
	[IDMetodoPago] [int] NOT NULL,
	[CodigoAutorizacion] [varchar](50) NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[IDFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Facturas_Carrito] UNIQUE NONCLUSTERED 
(
	[IDCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[HistorialUsuario] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistorialUsuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistorialUsuario](
	[idHistorial] [int] IDENTITY(1,1) NOT NULL,
	[usuarioId] [int] NOT NULL,
	[dni] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[rol] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](150) NULL,
	[telefono] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[activo] [bit] NOT NULL,
	[bloqueado] [bit] NOT NULL,
	[accion] [int] NOT NULL,
	[usuarioResponsable] [nvarchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Idioma] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Idioma]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Idioma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](5) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Idioma_Codigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[ListaPrecio] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListaPrecio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ListaPrecio](
	[IdProveedor] [int] NOT NULL,
	[CodigoProveedor] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[Codigo] [nvarchar](50) NULL,
	[PrecioLista] [decimal](18, 2) NOT NULL,
	[FechaActualizacion] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_ListaPrecio] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC,
	[CodigoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[MetodoPago] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetodoPago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MetodoPago](
	[IdMetodoPago] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Validacion] [bit] NOT NULL,
	[RequiereDatosTarjeta] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMetodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[OrdenCompra] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenCompra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrdenCompra](
	[IdOrdenCompra] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[Estado] [nvarchar](20) NOT NULL,
	[FechaCreacion] [datetime2](3) NOT NULL,
	[IdUsuarioCreacion] [int] NOT NULL,
	[IdUsuarioDecision] [int] NULL,
	[FechaDecision] [datetime2](3) NULL,
	[ObservacionesDecision] [nvarchar](500) NULL,
	[FechaEnvio] [datetime2](3) NULL,
	[FechaRecepcion] [datetime2](3) NULL,
	[ObservacionesRecepcion] [nvarchar](500) NULL,
 CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	[IdOrdenCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Permiso] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permiso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permiso](
	[Nombre_Permiso] [nvarchar](100) NOT NULL,
	[Tipo] [nvarchar](20) NULL,
	[Rol] [bit] NULL,
	[Nombre_PermisoPadre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Nombre_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Productos] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Productos](
	[Codigo] [nvarchar](50) NOT NULL,
	[Proveedor] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Stock] [int] NOT NULL,
	[Fecha_Actualizacion] [datetime] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[StockMinimo] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Proveedores] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proveedores]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Proveedores](
	[IDProveedor] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[Activo] [bit] NOT NULL,
	[Margen] [decimal](5, 2) NOT NULL,
	[Especialidad] [nvarchar](100) NULL,
	[Telefono] [nvarchar](30) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[IDProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Traduccion] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Traduccion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Traduccion](
	[IdIdioma] [int] NOT NULL,
	[Clave] [nvarchar](100) NOT NULL,
	[Texto] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC,
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Table [dbo].[Usuarios] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Rol] [nvarchar](100) NULL,
	[Contraseña] [varchar](65) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Activo] [bit] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[DVH] [nvarchar](65) NULL,
	[PrimerInicio] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto: Index [IX_HistorialUsuario_UsuarioId] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[HistorialUsuario]') AND name = N'IX_HistorialUsuario_UsuarioId')
CREATE NONCLUSTERED INDEX [IX_HistorialUsuario_UsuarioId] ON [dbo].[HistorialUsuario]
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Objeto: Index [UX_ListaPrecio_Proveedor_Codigo] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ListaPrecio]') AND name = N'UX_ListaPrecio_Proveedor_Codigo')
CREATE UNIQUE NONCLUSTERED INDEX [UX_ListaPrecio_Proveedor_Codigo] ON [dbo].[ListaPrecio]
(
	[IdProveedor] ASC,
	[Codigo] ASC
)
WHERE ([Codigo] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Objeto: Index [UX_Proveedores_Nombre] Fecha de script: 07/11/2026 4:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Proveedores]') AND name = N'UX_Proveedores_Nombre')
CREATE UNIQUE NONCLUSTERED INDEX [UX_Proveedores_Nombre] ON [dbo].[Proveedores]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Backups_Verificado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Backups] ADD  CONSTRAINT [DF_Backups_Verificado]  DEFAULT ((0)) FOR [Verificado]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Clientes_FechaActualizacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_FechaActualizacion]  DEFAULT (getdate()) FOR [FechaActualizacion]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Clientes_Activo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Activo]  DEFAULT ((1)) FOR [Activo]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Historial__fecha__3C34F16F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[HistorialUsuario] ADD  DEFAULT (getdate()) FOR [fecha]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ListaPrecio_Fecha]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ListaPrecio] ADD  CONSTRAINT [DF_ListaPrecio_Fecha]  DEFAULT (sysdatetime()) FOR [FechaActualizacion]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_MetodoPago_RequiereDatosTarjeta]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MetodoPago] ADD  CONSTRAINT [DF_MetodoPago_RequiereDatosTarjeta]  DEFAULT ((0)) FOR [RequiereDatosTarjeta]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Productos_StockMinimo]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_StockMinimo]  DEFAULT ((0)) FOR [StockMinimo]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Proveedores_Margen]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Proveedores] ADD  CONSTRAINT [DF_Proveedores_Margen]  DEFAULT ((30)) FOR [Margen]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Usuarios_PrimerInicio]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_PrimerInicio]  DEFAULT ((0)) FOR [PrimerInicio]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleCarrito_Carrito]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Carrito]'))
ALTER TABLE [dbo].[Detalle_Carrito]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCarrito_Carrito] FOREIGN KEY([IDCarrito])
REFERENCES [dbo].[Carrito] ([IDCarrito])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleCarrito_Carrito]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Carrito]'))
ALTER TABLE [dbo].[Detalle_Carrito] CHECK CONSTRAINT [FK_DetalleCarrito_Carrito]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleCarrito_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Carrito]'))
ALTER TABLE [dbo].[Detalle_Carrito]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCarrito_Productos] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Productos] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleCarrito_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Carrito]'))
ALTER TABLE [dbo].[Detalle_Carrito] CHECK CONSTRAINT [FK_DetalleCarrito_Productos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleFactura_Facturas]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Factura]'))
ALTER TABLE [dbo].[Detalle_Factura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Facturas] FOREIGN KEY([IDFactura])
REFERENCES [dbo].[Facturas] ([IDFactura])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleFactura_Facturas]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Factura]'))
ALTER TABLE [dbo].[Detalle_Factura] CHECK CONSTRAINT [FK_DetalleFactura_Facturas]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleFactura_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Factura]'))
ALTER TABLE [dbo].[Detalle_Factura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Productos] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Productos] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleFactura_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[Detalle_Factura]'))
ALTER TABLE [dbo].[Detalle_Factura] CHECK CONSTRAINT [FK_DetalleFactura_Productos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleOrdenCompra_OrdenCompra]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrdenCompra_OrdenCompra] FOREIGN KEY([IdOrdenCompra])
REFERENCES [dbo].[OrdenCompra] ([IdOrdenCompra])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleOrdenCompra_OrdenCompra]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra] CHECK CONSTRAINT [FK_DetalleOrdenCompra_OrdenCompra]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleOrdenCompra_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrdenCompra_Productos] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Productos] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DetalleOrdenCompra_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra] CHECK CONSTRAINT [FK_DetalleOrdenCompra_Productos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Carrito]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Carrito] FOREIGN KEY([IDCarrito])
REFERENCES [dbo].[Carrito] ([IDCarrito])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Carrito]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Carrito]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Clientes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([DNI])
REFERENCES [dbo].[Clientes] ([DNI])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Clientes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_MetodoPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_MetodoPago] FOREIGN KEY([IDMetodoPago])
REFERENCES [dbo].[MetodoPago] ([IdMetodoPago])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_MetodoPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_MetodoPago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Usuarios] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Facturas_Usuarios]') AND parent_object_id = OBJECT_ID(N'[dbo].[Facturas]'))
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Usuarios]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistorialUsuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistorialUsuario]'))
ALTER TABLE [dbo].[HistorialUsuario]  WITH CHECK ADD  CONSTRAINT [FK_HistorialUsuario_Usuario] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[Usuarios] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HistorialUsuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[HistorialUsuario]'))
ALTER TABLE [dbo].[HistorialUsuario] CHECK CONSTRAINT [FK_HistorialUsuario_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ListaPrecio_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio]  WITH CHECK ADD  CONSTRAINT [FK_ListaPrecio_Productos] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Productos] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ListaPrecio_Productos]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio] CHECK CONSTRAINT [FK_ListaPrecio_Productos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ListaPrecio_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio]  WITH CHECK ADD  CONSTRAINT [FK_ListaPrecio_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ListaPrecio_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio] CHECK CONSTRAINT [FK_ListaPrecio_Proveedores]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_Proveedores]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_UsuarioCreacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_UsuarioCreacion] FOREIGN KEY([IdUsuarioCreacion])
REFERENCES [dbo].[Usuarios] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_UsuarioCreacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_UsuarioCreacion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_UsuarioDecision]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_UsuarioDecision] FOREIGN KEY([IdUsuarioDecision])
REFERENCES [dbo].[Usuarios] ([Codigo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenCompra_UsuarioDecision]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_UsuarioDecision]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permiso_PermisoPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permiso]'))
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_PermisoPadre] FOREIGN KEY([Nombre_PermisoPadre])
REFERENCES [dbo].[Permiso] ([Nombre_Permiso])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permiso_PermisoPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permiso]'))
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_PermisoPadre]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Productos_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[Productos]'))
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Proveedores] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Productos_Proveedores]') AND parent_object_id = OBJECT_ID(N'[dbo].[Productos]'))
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Proveedores]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Traduccion_Idioma]') AND parent_object_id = OBJECT_ID(N'[dbo].[Traduccion]'))
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD  CONSTRAINT [FK_Traduccion_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Traduccion_Idioma]') AND parent_object_id = OBJECT_ID(N'[dbo].[Traduccion]'))
ALTER TABLE [dbo].[Traduccion] CHECK CONSTRAINT [FK_Traduccion_Idioma]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuarios_Permiso]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Permiso] FOREIGN KEY([Rol])
REFERENCES [dbo].[Permiso] ([Nombre_Permiso])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuarios_Permiso]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Permiso]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_DetalleOrdenCompra_Cantidad]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra]  WITH CHECK ADD  CONSTRAINT [CK_DetalleOrdenCompra_Cantidad] CHECK  (([Cantidad]>(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_DetalleOrdenCompra_Cantidad]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra] CHECK CONSTRAINT [CK_DetalleOrdenCompra_Cantidad]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_DetalleOrdenCompra_Recibida]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra]  WITH CHECK ADD  CONSTRAINT [CK_DetalleOrdenCompra_Recibida] CHECK  (([CantidadRecibida] IS NULL OR [CantidadRecibida]>=(0) AND [CantidadRecibida]<=[Cantidad]))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_DetalleOrdenCompra_Recibida]') AND parent_object_id = OBJECT_ID(N'[dbo].[DetalleOrdenCompra]'))
ALTER TABLE [dbo].[DetalleOrdenCompra] CHECK CONSTRAINT [CK_DetalleOrdenCompra_Recibida]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ListaPrecio_Precio]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio]  WITH CHECK ADD  CONSTRAINT [CK_ListaPrecio_Precio] CHECK  (([PrecioLista]>(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ListaPrecio_Precio]') AND parent_object_id = OBJECT_ID(N'[dbo].[ListaPrecio]'))
ALTER TABLE [dbo].[ListaPrecio] CHECK CONSTRAINT [CK_ListaPrecio_Precio]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_OrdenCompra_Estado]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [CK_OrdenCompra_Estado] CHECK  (([Estado]=N'Recibida' OR [Estado]=N'EnEjecucion' OR [Estado]=N'Rechazada' OR [Estado]=N'Autorizada' OR [Estado]=N'Pendiente'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_OrdenCompra_Estado]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenCompra]'))
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [CK_OrdenCompra_Estado]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Productos_StockMinimo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Productos]'))
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [CK_Productos_StockMinimo] CHECK  (([StockMinimo]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Productos_StockMinimo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Productos]'))
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [CK_Productos_StockMinimo]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Proveedores_Margen]') AND parent_object_id = OBJECT_ID(N'[dbo].[Proveedores]'))
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [CK_Proveedores_Margen] CHECK  (([Margen]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Proveedores_Margen]') AND parent_object_id = OBJECT_ID(N'[dbo].[Proveedores]'))
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [CK_Proveedores_Margen]
GO
/****** Objeto: StoredProcedure [dbo].[ActualizarDVH_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActualizarDVH_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ActualizarDVH_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[ActualizarDVH_SP]
    @Codigo int,
    @DVH nvarchar(65)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuarios
    SET DVH = @DVH
    WHERE Codigo = @Codigo;
END

GO
/****** Objeto: StoredProcedure [dbo].[AltaOrdenesCompra_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AltaOrdenesCompra_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AltaOrdenesCompra_SP] AS' 
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
/****** Objeto: StoredProcedure [dbo].[AltaProductoVinculado_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AltaProductoVinculado_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AltaProductoVinculado_SP] AS' 
END
GO

-- Alta del producto (stock 0) + vinculo del item pendiente, en una sola transaccion.
-- El precio de venta lo calcula la BLL (ProveedorBE.CalcularPrecioVenta_883SC).
ALTER   PROCEDURE [dbo].[AltaProductoVinculado_SP]
    @Codigo NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(MAX),
    @StockMinimo INT,
    @Precio DECIMAL(18,2),
    @IdProveedor INT,
    @CodigoProveedor NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM ListaPrecio WITH (UPDLOCK, HOLDLOCK)
                   WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor AND Codigo IS NULL)
        THROW 50001, 'El item no existe o ya esta vinculado', 1;

    IF EXISTS (SELECT 1 FROM Productos WITH (UPDLOCK, HOLDLOCK) WHERE Codigo = @Codigo)
        THROW 50002, 'Ya existe un producto con ese codigo', 1;

    INSERT INTO Productos (Codigo, Proveedor, Nombre, Descripcion, Stock, Fecha_Actualizacion, Precio, StockMinimo)
    VALUES (@Codigo, @IdProveedor, @Nombre, @Descripcion, 0, GETDATE(), @Precio, @StockMinimo);

    UPDATE ListaPrecio SET Codigo = @Codigo
    WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[AltaProveedor_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AltaProveedor_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AltaProveedor_SP] AS' 
END
GO

-- b) AltaProveedor_SP: inserta el proveedor activo y devuelve el IDProveedor generado
ALTER PROCEDURE [dbo].[AltaProveedor_SP]
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

    BEGIN TRY
        -- UPDLOCK + HOLDLOCK: dos altas simultaneas no obtienen el mismo ID
        -- (mismo patron de MAX+1 que GuardarCarrito_SP).
        DECLARE @nuevoId INT;
        SELECT @nuevoId = ISNULL(MAX(IDProveedor), 0) + 1
        FROM dbo.Proveedores WITH (UPDLOCK, HOLDLOCK);

        INSERT INTO dbo.Proveedores
            (IDProveedor, Nombre, Direccion, Observaciones, Activo, Margen, Especialidad, Telefono)
        VALUES
            (@nuevoId, @Nombre, @Direccion, @Observaciones, 1, @Margen, @Especialidad, @Telefono);

        COMMIT TRANSACTION;

        SELECT @nuevoId AS IDProveedor;   -- lo lee EscribirRetornar_883SC (ExecuteScalar)
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

GO
/****** Objeto: StoredProcedure [dbo].[AutorizarOrdenCompra_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutorizarOrdenCompra_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AutorizarOrdenCompra_SP] AS' 
END
GO

-- Pendiente -> Autorizada. Vuelve a leer el estado dentro de la transaccion (UPDLOCK, HOLDLOCK): si otro usuario
-- ya resolvio la orden, no hace nada y lanza 50001. Orden inexistente: 50002.
ALTER   PROCEDURE [dbo].[AutorizarOrdenCompra_SP]
    @IdOrdenCompra INT,
    @IdUsuario INT,
    @Observaciones NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Estado NVARCHAR(20);
    SELECT @Estado = Estado FROM OrdenCompra WITH (UPDLOCK, HOLDLOCK) WHERE IdOrdenCompra = @IdOrdenCompra;

    IF @Estado IS NULL
        THROW 50002, 'La orden de compra no existe', 1;
    IF @Estado <> 'Pendiente'
        THROW 50001, 'La orden ya no esta pendiente', 1;

    UPDATE OrdenCompra
    SET Estado = 'Autorizada', IdUsuarioDecision = @IdUsuario, FechaDecision = SYSDATETIME(),
        ObservacionesDecision = @Observaciones
    WHERE IdOrdenCompra = @IdOrdenCompra;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[BajaCliente_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BajaCliente_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BajaCliente_SP] AS' 
END
GO
ALTER PROCEDURE [dbo].[BajaCliente_SP]
    @DNI int
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Activo = 0,
        FechaActualizacion = GETDATE()
    WHERE DNI = @DNI AND Activo = 1;

    IF @@ROWCOUNT = 0
        THROW 50001, 'El cliente no existe o ya esta dado de baja.', 1;
END

GO
/****** Objeto: StoredProcedure [dbo].[BajaProveedor_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BajaProveedor_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BajaProveedor_SP] AS' 
END
GO

-- a3) BajaProveedor_SP: baja logica. 50002 no existe, 50001 ya esta dado de baja,
-- 50004 es el proveedor de referencia de algun producto (la BLL lo controla antes; esto cubre la concurrencia).
ALTER PROCEDURE [dbo].[BajaProveedor_SP]
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
/****** Objeto: StoredProcedure [dbo].[BuscarCliente_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarCliente_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BuscarCliente_SP] AS' 
END
GO
ALTER PROCEDURE [dbo].[BuscarCliente_SP]
    @DNI int
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DNI, Nombre, Apellido, Direccion, Telefono, Activo
    FROM Clientes
    WHERE DNI = @DNI;
END

GO
/****** Objeto: StoredProcedure [dbo].[BuscarProductos_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscarProductos_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BuscarProductos_SP] AS' 
END
GO
  ALTER PROCEDURE [dbo].[BuscarProductos_SP]
    @criterio NVARCHAR(50),
    @dato NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @criterio = 'Codigo'
        SELECT Codigo, Nombre, Stock, Descripcion, Precio, Proveedor
        FROM Productos WHERE Codigo = @dato;
    ELSE IF @criterio = 'Nombre'
        SELECT Codigo, Nombre, Stock, Descripcion, Precio, Proveedor
        FROM Productos WHERE Nombre LIKE '%' + @dato + '%';
    ELSE IF @criterio = 'Tipo'
        SELECT Codigo, Nombre, Stock, Descripcion, Precio, Proveedor
        FROM Productos WHERE Descripcion LIKE '%' + @dato + '%';
    ELSE IF @criterio = 'Proveedor'
        SELECT Codigo, Nombre, Stock, Descripcion, Precio, Proveedor
        FROM Productos WHERE Proveedor = TRY_CAST(@dato AS INT);
    ELSE
        SELECT Codigo, Nombre, Stock, Descripcion, Precio, Proveedor
        FROM Productos WHERE 1 = 0;
END
GO
/****** Objeto: StoredProcedure [dbo].[ContarProductosReferencia_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContarProductosReferencia_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContarProductosReferencia_SP] AS' 
END
GO

-- a1) ContarProductosReferencia_SP: cuantos productos tienen a este proveedor como referencia
ALTER PROCEDURE [dbo].[ContarProductosReferencia_SP]
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS Cantidad FROM dbo.Productos WHERE Proveedor = @IdProveedor;
END

GO
/****** Objeto: StoredProcedure [dbo].[CrearCliente_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CrearCliente_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CrearCliente_SP] AS' 
END
GO

ALTER PROCEDURE [dbo].[CrearCliente_SP]
    @DNI       int,
    @Nombre    nvarchar(50),
    @Apellido  nvarchar(50),
    @Direccion nvarchar(500),
    @Telefono  nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes (DNI, Nombre, Apellido, Direccion, Telefono, FechaActualizacion)
    VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Telefono, GETDATE());
END

GO
/****** Objeto: StoredProcedure [dbo].[DesvincularItem_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DesvincularItem_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DesvincularItem_SP] AS' 
END
GO

-- Desvincula un item (vuelve a quedar pendiente). No se permite si es del proveedor de referencia del producto
-- y el producto tiene otros codigos vinculados (primero hay que cambiar la referencia).
ALTER   PROCEDURE [dbo].[DesvincularItem_SP]
    @IdProveedor INT,
    @CodigoProveedor NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Codigo NVARCHAR(50);
    SELECT @Codigo = Codigo FROM ListaPrecio WITH (UPDLOCK, HOLDLOCK)
    WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor;
    IF @Codigo IS NULL
        THROW 50001, 'El item no existe o no esta vinculado', 1;

    -- El de la referencia solo se puede desvincular si es el unico codigo vinculado del producto
    IF EXISTS (SELECT 1 FROM Productos WHERE Codigo = @Codigo AND Proveedor = @IdProveedor)
       AND EXISTS (SELECT 1 FROM ListaPrecio WHERE Codigo = @Codigo
                   AND NOT (IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor))
        THROW 50005, 'El codigo pertenece al proveedor de referencia del producto', 1;

    UPDATE ListaPrecio SET Codigo = NULL
    WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[EliminarBackup_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EliminarBackup_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EliminarBackup_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[EliminarBackup_SP]
    @IdBackup int
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Backups WHERE IdBackup = @IdBackup;
END

GO
/****** Objeto: StoredProcedure [dbo].[EnviarOrdenCompra_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EnviarOrdenCompra_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EnviarOrdenCompra_SP] AS' 
END
GO

-- Autorizada -> EnEjecucion. Relee el estado dentro de la transaccion (UPDLOCK, HOLDLOCK): si otro usuario ya
-- la envio, no hace nada y lanza 50001. Orden inexistente: 50002.
ALTER PROCEDURE [dbo].[EnviarOrdenCompra_SP]
    @IdOrdenCompra INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Estado NVARCHAR(20);
    SELECT @Estado = Estado FROM OrdenCompra WITH (UPDLOCK, HOLDLOCK) WHERE IdOrdenCompra = @IdOrdenCompra;

    IF @Estado IS NULL
        THROW 50002, 'La orden de compra no existe', 1;
    IF @Estado <> 'Autorizada'
        THROW 50001, 'La orden ya no esta autorizada', 1;

    UPDATE OrdenCompra
    SET Estado = 'EnEjecucion', FechaEnvio = SYSDATETIME()
    WHERE IdOrdenCompra = @IdOrdenCompra;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[ExisteProducto_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExisteProducto_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExisteProducto_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[ExisteProducto_SP]
    @Codigo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Codigo FROM Productos WHERE Codigo = @Codigo;
END

GO
/****** Objeto: StoredProcedure [dbo].[ExisteProveedor_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExisteProveedor_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExisteProveedor_SP] AS' 
END
GO

-- CUN-008 Registrar Proveedor: stored procedures y traducciones (solo ES/EN)

-- a) ExisteProveedor_SP: devuelve una fila si ya hay un proveedor con ese nombre
ALTER PROCEDURE [dbo].[ExisteProveedor_SP]
    @Nombre NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 1 AS Existe
    WHERE EXISTS (SELECT 1 FROM dbo.Proveedores WHERE Nombre = @Nombre);
END

GO
/****** Objeto: StoredProcedure [dbo].[GuardarCarrito_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GuardarCarrito_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GuardarCarrito_SP] AS' 
END
GO

/* --- c) GuardarCarrito_SP ----------------------------------------- */

ALTER PROCEDURE [dbo].[GuardarCarrito_SP]
    @Nombre         VARCHAR(50),
    @FechaCreacion  DATETIME2(3),
    @Detalle        dbo.TipoDetalleCarrito READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        -- UPDLOCK + HOLDLOCK: si dos cajeros guardan a la vez, el segundo
        -- espera y no obtiene el mismo IDCarrito (mismo patron de locking
        -- que se usa para generar IDs por MAX+1 en el resto del sistema).
        DECLARE @nuevoId INT;
        SELECT @nuevoId = ISNULL(MAX(IDCarrito), 0) + 1
        FROM dbo.Carrito WITH (UPDLOCK, HOLDLOCK);

        INSERT INTO dbo.Carrito (IDCarrito, nombre, fecha_creacion)
        VALUES (@nuevoId, @Nombre, @FechaCreacion);

        INSERT INTO dbo.Detalle_Carrito (IDCarrito, Codigo, cantidad, PrecioUnitario)
        SELECT @nuevoId, d.Codigo, d.Cantidad, d.PrecioUnitario
        FROM @Detalle AS d;

        COMMIT TRANSACTION;

        SELECT @nuevoId AS IDCarrito;   -- lo lee EscribirRetornar_883SC (ExecuteScalar)
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

GO
/****** Objeto: StoredProcedure [dbo].[GuardarFactura_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GuardarFactura_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GuardarFactura_SP] AS' 
END
GO

-- c) GuardarFactura_SP
ALTER   PROCEDURE [dbo].[GuardarFactura_SP]
    @IDUsuario          INT,
    @DNI                INT,
    @IDCarrito          INT,
    @IDMetodoPago       INT,
    @CodigoAutorizacion VARCHAR(50) = NULL,
    @FechaVenta         DATETIME2(3),
    @Detalle            dbo.TipoDetalleFactura READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @nuevoId INT;
        SELECT @nuevoId = ISNULL(MAX(IDFactura), 0) + 1
        FROM dbo.Facturas WITH (UPDLOCK, HOLDLOCK);

        INSERT INTO dbo.Facturas (IDFactura, fecha_venta, IDUsuario, DNI, IDCarrito, IDMetodoPago, CodigoAutorizacion)
        VALUES (@nuevoId, @FechaVenta, @IDUsuario, @DNI, @IDCarrito, @IDMetodoPago, @CodigoAutorizacion);

        INSERT INTO dbo.Detalle_Factura (IDFactura, Codigo, cantidad, PrecioUnitario)
        SELECT @nuevoId, d.Codigo, d.Cantidad, d.PrecioUnitario
        FROM @Detalle AS d;

        COMMIT TRANSACTION;
        SELECT @nuevoId AS IDFactura;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Objeto: StoredProcedure [dbo].[ImportarListaPrecios_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImportarListaPrecios_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ImportarListaPrecios_SP] AS' 
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
/****** Objeto: StoredProcedure [dbo].[ListarBackups_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarBackups_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarBackups_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[ListarBackups_SP]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdBackup, NombreArchivo, Ruta, Fecha, Usuario, TamanioBytes, Verificado
    FROM Backups
    ORDER BY Fecha DESC, IdBackup DESC;
END

GO
/****** Objeto: StoredProcedure [dbo].[ListarBajoStock_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarBajoStock_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarBajoStock_SP] AS' 
END
GO

-- Productos con stock inferior al minimo. CantProveedores = proveedores activos con el producto vinculado
-- (0 = no se puede comprar desde el sistema todavia).
ALTER   PROCEDURE [dbo].[ListarBajoStock_SP]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Codigo, p.Nombre, p.Stock, p.Descripcion, p.Precio, p.Proveedor, p.StockMinimo,
           (SELECT COUNT(*) FROM ListaPrecio lp
            INNER JOIN Proveedores pr ON pr.IDProveedor = lp.IdProveedor AND pr.Activo = 1
            WHERE lp.Codigo = p.Codigo) AS CantProveedores
    FROM Productos p
    WHERE p.Stock < p.StockMinimo
    ORDER BY (p.StockMinimo - p.Stock) DESC, p.Codigo;
END

GO
/****** Objeto: StoredProcedure [dbo].[ListarCarritosPendientes_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarCarritosPendientes_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarCarritosPendientes_SP] AS' 
END
GO

-- d) ListarCarritosPendientes_SP
ALTER   PROCEDURE [dbo].[ListarCarritosPendientes_SP]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.IDCarrito, c.nombre, c.fecha_creacion
    FROM dbo.Carrito AS c
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Facturas AS f WHERE f.IDCarrito = c.IDCarrito)
    ORDER BY c.IDCarrito;
END
GO
/****** Objeto: StoredProcedure [dbo].[ListarMetodosPago_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarMetodosPago_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarMetodosPago_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[ListarMetodosPago_SP] AS
    SELECT IdMetodoPago, Nombre, Validacion, RequiereDatosTarjeta
    FROM MetodoPago
    ORDER BY IdMetodoPago;
GO
/****** Objeto: StoredProcedure [dbo].[ListarOrdenesPorEstado_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarOrdenesPorEstado_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarOrdenesPorEstado_SP] AS' 
END
GO

-- CUN-010 Autorizar Orden de Compra.
-- Lista las ordenes de un estado, con su detalle (una fila por linea). Es de solo lectura y la reutiliza el CUN-011.
ALTER   PROCEDURE [dbo].[ListarOrdenesPorEstado_SP]
    @Estado NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT o.IdOrdenCompra, o.IdProveedor, pv.Nombre AS Proveedor, o.Estado, o.FechaCreacion,
           o.IdUsuarioCreacion, o.IdUsuarioDecision, o.FechaDecision, o.ObservacionesDecision,
           o.FechaEnvio, o.FechaRecepcion, o.ObservacionesRecepcion,
           d.Codigo, p.Nombre AS Producto, d.Cantidad, d.PrecioUnitario, d.CantidadRecibida
    FROM OrdenCompra o
    INNER JOIN Proveedores pv ON pv.IDProveedor = o.IdProveedor
    INNER JOIN DetalleOrdenCompra d ON d.IdOrdenCompra = o.IdOrdenCompra
    INNER JOIN Productos p ON p.Codigo = d.Codigo
    WHERE o.Estado = @Estado
    ORDER BY o.IdOrdenCompra, d.Codigo;
END

GO
/****** Objeto: StoredProcedure [dbo].[ListarPendientes_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarPendientes_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarPendientes_SP] AS' 
END
GO

-- Items pendientes de vinculacion (Codigo NULL); @IdProveedor NULL = todos los proveedores
ALTER   PROCEDURE [dbo].[ListarPendientes_SP]
    @IdProveedor INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdProveedor, CodigoProveedor, Descripcion, Codigo, PrecioLista, FechaActualizacion
    FROM ListaPrecio
    WHERE Codigo IS NULL AND (@IdProveedor IS NULL OR IdProveedor = @IdProveedor)
    ORDER BY IdProveedor, CodigoProveedor;
END

GO
/****** Objeto: StoredProcedure [dbo].[ListarPreciosProducto_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarPreciosProducto_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarPreciosProducto_SP] AS' 
END
GO

-- Precios de lista de un producto, uno por proveedor activo, de menor a mayor
ALTER   PROCEDURE [dbo].[ListarPreciosProducto_SP]
    @Codigo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pr.IDProveedor AS IdProveedor, pr.Nombre AS NombreProveedor, lp.CodigoProveedor,
           lp.PrecioLista, lp.FechaActualizacion
    FROM ListaPrecio lp
    INNER JOIN Proveedores pr ON pr.IDProveedor = lp.IdProveedor
    WHERE lp.Codigo = @Codigo AND pr.Activo = 1
    ORDER BY lp.PrecioLista, pr.Nombre;
END

GO
/****** Objeto: StoredProcedure [dbo].[ListarVinculados_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarVinculados_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ListarVinculados_SP] AS' 
END
GO

-- Codigos de proveedor vinculados a un producto
ALTER   PROCEDURE [dbo].[ListarVinculados_SP]
    @Codigo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdProveedor, CodigoProveedor, Descripcion, Codigo, PrecioLista, FechaActualizacion
    FROM ListaPrecio
    WHERE Codigo = @Codigo
    ORDER BY IdProveedor;
END

GO
/****** Objeto: StoredProcedure [dbo].[ModificarCliente_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModificarCliente_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ModificarCliente_SP] AS' 
END
GO
ALTER PROCEDURE [dbo].[ModificarCliente_SP]
    @DNI       int,
    @Nombre    nvarchar(50),
    @Apellido  nvarchar(50),
    @Direccion nvarchar(500),
    @Telefono  nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Direccion = @Direccion,
        Telefono = @Telefono,
        FechaActualizacion = GETDATE()
    WHERE DNI = @DNI AND Activo = 1;

    IF @@ROWCOUNT = 0
        THROW 50001, 'El cliente no existe o esta dado de baja.', 1;
END

GO
/****** Objeto: StoredProcedure [dbo].[ModificarProducto_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModificarProducto_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ModificarProducto_SP] AS' 
END
GO

-- Modifica nombre, descripcion, stock minimo, proveedor de referencia y precio (el codigo y el stock no cambian).
-- El nuevo proveedor de referencia debe tener un codigo vinculado al producto.
ALTER   PROCEDURE [dbo].[ModificarProducto_SP]
    @Codigo NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(MAX),
    @StockMinimo INT,
    @IdProveedor INT,
    @Precio DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @ProveedorActual INT;
    SELECT @ProveedorActual = Proveedor FROM Productos WITH (UPDLOCK, HOLDLOCK) WHERE Codigo = @Codigo;
    IF @ProveedorActual IS NULL
        THROW 50003, 'El producto no existe', 1;

    IF @ProveedorActual <> @IdProveedor
       AND NOT EXISTS (SELECT 1 FROM ListaPrecio WHERE IdProveedor = @IdProveedor AND Codigo = @Codigo)
        THROW 50006, 'El proveedor de referencia debe tener un codigo vinculado al producto', 1;

    UPDATE Productos
    SET Nombre = @Nombre, Descripcion = @Descripcion, StockMinimo = @StockMinimo,
        Proveedor = @IdProveedor, Precio = @Precio, Fecha_Actualizacion = GETDATE()
    WHERE Codigo = @Codigo;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[ModificarProveedor_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModificarProveedor_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ModificarProveedor_SP] AS' 
END
GO

-- a2) ModificarProveedor_SP: modifica un proveedor activo. Si cambia el margen, recalcula en la misma
-- transaccion Productos.Precio de los productos vinculados cuyo proveedor de referencia es este.
-- La formula es la misma que usa ImportarListaPrecios_SP y ProveedorBE_883SC.CalcularPrecioVenta_883SC
-- (ROUND(PrecioLista * (1 + Margen/100), 2)): si cambia una, hay que cambiar las otras dos.
-- Solo cuentan (y se actualizan) los productos cuyo precio de venta cambia de valor; no toca Fecha_Actualizacion.
-- Errores: 50001 inactivo, 50002 no existe, 50003 nombre repetido. Devuelve una fila: PreciosActualizados.
ALTER PROCEDURE [dbo].[ModificarProveedor_SP]
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
/****** Objeto: StoredProcedure [dbo].[ObtenerBackup_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObtenerBackup_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ObtenerBackup_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[ObtenerBackup_SP]
    @IdBackup int
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdBackup, NombreArchivo, Ruta, Fecha, Usuario, TamanioBytes, Verificado
    FROM Backups
    WHERE IdBackup = @IdBackup;
END

GO
/****** Objeto: StoredProcedure [dbo].[ObtenerCarritoDetalle_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObtenerCarritoDetalle_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ObtenerCarritoDetalle_SP] AS' 
END
GO
ALTER   PROCEDURE [dbo].[ObtenerCarritoDetalle_SP]
    @IDCarrito INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.IDCarrito, c.nombre, c.fecha_creacion,
           p.Codigo, p.Nombre AS NombreProducto, p.Stock, p.Descripcion, p.Precio, p.Proveedor,
           d.cantidad, d.PrecioUnitario
    FROM dbo.Carrito AS c
    JOIN dbo.Detalle_Carrito AS d ON d.IDCarrito = c.IDCarrito
    JOIN dbo.Productos       AS p ON p.Codigo = d.Codigo
    WHERE c.IDCarrito = @IDCarrito
    ORDER BY p.Codigo;
END
GO
/****** Objeto: StoredProcedure [dbo].[ObtenerComprobanteOrdenCompra_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObtenerComprobanteOrdenCompra_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ObtenerComprobanteOrdenCompra_SP] AS' 
END
GO

-- a) ObtenerComprobanteOrdenCompra_SP: una fila por linea de la orden, con la cabecera repetida.
-- CodigoProveedor y Descripcion salen de ListaPrecio (indice unico filtrado IdProveedor+Codigo: a lo sumo una fila).
-- Si el producto se desvinculo despues de generar la orden, se usa el Codigo y el Nombre de FerreSV.
-- Usuario creador / que decidio: Usuarios.Usuario (LEFT JOIN: la decision es NULL en una orden Pendiente).
-- Si la orden no existe devuelve cero filas.
ALTER PROCEDURE [dbo].[ObtenerComprobanteOrdenCompra_SP]
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
/****** Objeto: StoredProcedure [dbo].[ReactivarCliente_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReactivarCliente_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReactivarCliente_SP] AS' 
END
GO
ALTER PROCEDURE [dbo].[ReactivarCliente_SP]
    @DNI int
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Activo = 1,
        FechaActualizacion = GETDATE()
    WHERE DNI = @DNI AND Activo = 0;

    IF @@ROWCOUNT = 0
        THROW 50001, 'El cliente no existe o ya esta activo.', 1;
END

GO
/****** Objeto: StoredProcedure [dbo].[ReactivarProveedor_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReactivarProveedor_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReactivarProveedor_SP] AS' 
END
GO

-- a4) ReactivarProveedor_SP: 50002 no existe, 50001 ya esta activo
ALTER PROCEDURE [dbo].[ReactivarProveedor_SP]
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
/****** Objeto: StoredProcedure [dbo].[RechazarOrdenCompra_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RechazarOrdenCompra_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RechazarOrdenCompra_SP] AS' 
END
GO

-- Pendiente -> Rechazada. Mismo control de concurrencia que la autorizacion.
ALTER   PROCEDURE [dbo].[RechazarOrdenCompra_SP]
    @IdOrdenCompra INT,
    @IdUsuario INT,
    @Observaciones NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Estado NVARCHAR(20);
    SELECT @Estado = Estado FROM OrdenCompra WITH (UPDLOCK, HOLDLOCK) WHERE IdOrdenCompra = @IdOrdenCompra;

    IF @Estado IS NULL
        THROW 50002, 'La orden de compra no existe', 1;
    IF @Estado <> 'Pendiente'
        THROW 50001, 'La orden ya no esta pendiente', 1;

    UPDATE OrdenCompra
    SET Estado = 'Rechazada', IdUsuarioDecision = @IdUsuario, FechaDecision = SYSDATETIME(),
        ObservacionesDecision = @Observaciones
    WHERE IdOrdenCompra = @IdOrdenCompra;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[RegistrarBackup_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegistrarBackup_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RegistrarBackup_SP] AS' 
END
GO

ALTER   PROCEDURE [dbo].[RegistrarBackup_SP]
    @NombreArchivo nvarchar(260),
    @Ruta nvarchar(260),
    @Fecha datetime,
    @Usuario nvarchar(50),
    @TamanioBytes bigint = NULL,
    @Verificado bit
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Backups (NombreArchivo, Ruta, Fecha, Usuario, TamanioBytes, Verificado)
    VALUES (@NombreArchivo, @Ruta, @Fecha, @Usuario, @TamanioBytes, @Verificado);

    SELECT CAST(SCOPE_IDENTITY() AS int);
END

GO
/****** Objeto: StoredProcedure [dbo].[RegistrarRecepcion_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegistrarRecepcion_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RegistrarRecepcion_SP] AS' 
END
GO

-- EnEjecucion -> Recibida, en una sola transaccion: guarda CantidadRecibida de cada linea, suma esa cantidad al
-- stock del producto y cierra la orden. 50001: la orden ya no esta EnEjecucion. 50002: no existe.
-- 50003: las lineas recibidas no coinciden con las de la orden. 50004: cantidad recibida fuera de 0..Cantidad.
ALTER PROCEDURE [dbo].[RegistrarRecepcion_SP]
    @IdOrdenCompra INT,
    @Observaciones NVARCHAR(500) = NULL,
    @Lineas [dbo].[TipoRecepcionLinea] READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Estado NVARCHAR(20);
    SELECT @Estado = Estado FROM OrdenCompra WITH (UPDLOCK, HOLDLOCK) WHERE IdOrdenCompra = @IdOrdenCompra;

    IF @Estado IS NULL
        THROW 50002, 'La orden de compra no existe', 1;
    IF @Estado <> 'EnEjecucion'
        THROW 50001, 'La orden ya no esta en ejecucion', 1;

    -- Debe venir exactamente una fila por cada linea de la orden
    IF (SELECT COUNT(*) FROM @Lineas) <> (SELECT COUNT(*) FROM DetalleOrdenCompra WHERE IdOrdenCompra = @IdOrdenCompra)
       OR EXISTS (SELECT 1 FROM DetalleOrdenCompra d
                  WHERE d.IdOrdenCompra = @IdOrdenCompra
                    AND NOT EXISTS (SELECT 1 FROM @Lineas l WHERE l.Codigo = d.Codigo))
        THROW 50003, 'Las lineas recibidas no coinciden con las de la orden', 1;

    IF EXISTS (SELECT 1 FROM DetalleOrdenCompra d
               INNER JOIN @Lineas l ON l.Codigo = d.Codigo
               WHERE d.IdOrdenCompra = @IdOrdenCompra
                 AND (l.CantidadRecibida < 0 OR l.CantidadRecibida > d.Cantidad))
        THROW 50004, 'La cantidad recibida debe estar entre 0 y la cantidad pedida', 1;

    UPDATE d
    SET d.CantidadRecibida = l.CantidadRecibida
    FROM DetalleOrdenCompra d
    INNER JOIN @Lineas l ON l.Codigo = d.Codigo
    WHERE d.IdOrdenCompra = @IdOrdenCompra;

    -- Suma relativa (Stock + x): no pisa una venta que se confirme al mismo tiempo
    UPDATE p
    SET p.Stock = p.Stock + d.CantidadRecibida
    FROM Productos p
    INNER JOIN DetalleOrdenCompra d ON d.Codigo = p.Codigo
    WHERE d.IdOrdenCompra = @IdOrdenCompra;

    UPDATE OrdenCompra
    SET Estado = 'Recibida', FechaRecepcion = SYSDATETIME(), ObservacionesRecepcion = @Observaciones
    WHERE IdOrdenCompra = @IdOrdenCompra;

    COMMIT TRANSACTION;
END

GO
/****** Objeto: StoredProcedure [dbo].[SP_ActualizarBloqueado] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ActualizarBloqueado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ActualizarBloqueado] AS' 
END
GO

-- Bloqueo / desbloqueo: en el bloqueo la BLL manda el valor leido de la base (se conserva);
-- en el desbloqueo manda 1 (la clave por defecto obliga a cambiarla)
ALTER PROCEDURE [dbo].[SP_ActualizarBloqueado]
    @Usuario varchar(50),
	@pass varchar(65),
	@Bloqueado bit,
	@DVH NVARCHAR(65),
	@PrimerInicio bit
AS
begin
	UPDATE Usuarios
	SET Bloqueado = @Bloqueado, DVH = @DVH,
	Contraseña = @pass, PrimerInicio = @PrimerInicio
	WHERE Usuario = @Usuario;
end

GO
/****** Objeto: StoredProcedure [dbo].[SP_ActualizarDVV] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ActualizarDVV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ActualizarDVV] AS' 
END
GO
ALTER procedure [dbo].[SP_ActualizarDVV]
@tabla nvarchar(50),
@dvv nvarchar(65)
as
begin
IF EXISTS (SELECT 1
           FROM DigitoVertical
           WHERE Tabla = @Tabla)
begin
    update DigitoVertical
    set DVV = @dvv
    where Tabla = @tabla
end
else
begin
    insert into DigitoVertical(Tabla,DVV)
    values(@tabla,@dvv)
end
end
GO
/****** Objeto: StoredProcedure [dbo].[SP_ActualizarTraduccion] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ActualizarTraduccion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ActualizarTraduccion] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ActualizarTraduccion]
    @IdIdioma INT,
    @Clave NVARCHAR(100),
    @Texto NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Traduccion
    SET Texto = @Texto
    WHERE IdIdioma = @IdIdioma AND Clave = @Clave;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ActualizarUs] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ActualizarUs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ActualizarUs] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ActualizarUs]
(
    @Codigo INT,
    @DNI NVARCHAR(50),
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Usuario NVARCHAR(50),
    @Rol NVARCHAR(50),
    @Direccion NVARCHAR(200),
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100),
    @Activo BIT,
    @Bloqueado BIT,
    @DVH NVARCHAR(65)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN
		SELECT 1 FROM Usuarios WHERE Codigo = @Codigo
        BEGIN
            -- Actualizar los campos del usuario
            UPDATE Usuarios
            SET 
                DNI = @DNI,
                Nombre = @Nombre,
                Apellido = @Apellido,
                Usuario = @Usuario,
                Rol = @Rol,
                Direccion = @Direccion,
                Telefono = @Telefono,
                Email = @Email,
                Activo = @Activo,
                Bloqueado = @Bloqueado,
                DVH = @DVH
            WHERE Codigo = @Codigo;
        END
    END
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ActualizarUsuarioConHistorial] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ActualizarUsuarioConHistorial]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ActualizarUsuarioConHistorial] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ActualizarUsuarioConHistorial]
    @Codigo INT,
    @DNI INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Usuario NVARCHAR(50),
    @Rol NVARCHAR(50),
    @Direccion NVARCHAR(150) = NULL,
    @Telefono NVARCHAR(50) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Activo BIT,
    @Bloqueado BIT,
    @DVH NVARCHAR(200),
    @UsuarioResponsable NVARCHAR(50),
    @Accion INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        -- 1) Copia el estado ACTUAL (antes de pisarlo) al historial
        INSERT INTO HistorialUsuario
            (usuarioId, dni, nombre, apellido, usuario, rol, direccion, telefono, email, activo, bloqueado, accion, usuarioResponsable, fecha)
        SELECT Codigo, DNI, Nombre, Apellido, [Usuario], Rol, Direccion, Telefono, Email, Activo, Bloqueado, @Accion, @UsuarioResponsable, GETDATE()
        FROM Usuarios
        WHERE Codigo = @Codigo;

        -- 2) Recién ahí, pisa el usuario con los datos nuevos
        UPDATE Usuarios
        SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, [Usuario] = @Usuario, Rol = @Rol,
            Direccion = @Direccion, Telefono = @Telefono, Email = @Email,
            Activo = @Activo, Bloqueado = @Bloqueado, DVH = @DVH
        WHERE Codigo = @Codigo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_BuscarBitacora] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_BuscarBitacora]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_BuscarBitacora] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_BuscarBitacora]
    @Usuario VARCHAR(50) = NULL,
    @Accion INT = NULL,
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL
AS
BEGIN
    SELECT B.Registro, B.Usuario, B.Accion, B.Fecha, B.Detalle
    FROM Bitacora B
    WHERE (@Usuario IS NULL OR B.Usuario LIKE '%' + @Usuario + '%')
      AND (@Accion IS NULL OR B.Accion = @Accion)
      AND (@FechaDesde IS NULL OR B.Fecha >= @FechaDesde)
      AND (@FechaHasta IS NULL OR B.Fecha <= @FechaHasta)
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_CambiarPass] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_CambiarPass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_CambiarPass] AS' 
END
GO

-- Cambio de clave: la BLL manda PrimerInicio = 0
ALTER PROCEDURE [dbo].[SP_CambiarPass]
(
    @Usuario VARCHAR(50),
    @pass VARCHAR(65),
    @DVH NVARCHAR(65),
    @PrimerInicio BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN
		UPDATE Usuarios
        SET Contraseña = @pass, DVH = @DVH, PrimerInicio = @PrimerInicio
        WHERE Usuario = @Usuario;
    END
END

GO
/****** Objeto: StoredProcedure [dbo].[SP_CrearIdioma] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_CrearIdioma]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_CrearIdioma] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_CrearIdioma]
    @Codigo NVARCHAR(5),
    @Nombre NVARCHAR(50),
    @CodigoBase NVARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdBase INT = (SELECT Id FROM Idioma WHERE Codigo = @CodigoBase);
    DECLARE @IdNuevo INT;

    INSERT INTO Idioma (Codigo, Nombre) VALUES (@Codigo, @Nombre);
    SET @IdNuevo = SCOPE_IDENTITY();

    INSERT INTO Traduccion (IdIdioma, Clave, Texto)
    SELECT @IdNuevo, Clave, Texto
    FROM Traduccion
    WHERE IdIdioma = @IdBase;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_CrearUsuario] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_CrearUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_CrearUsuario] AS' 
END
GO

-- Alta: el usuario nuevo nace con la bandera que le manda la BLL (true)
ALTER PROCEDURE [dbo].[SP_CrearUsuario]
    @DNI INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Usuario NVARCHAR(50),
    @Rol NVARCHAR(50),
    @Contraseña NVARCHAR(200),
    @Direccion NVARCHAR(150) = NULL,
    @Telefono NVARCHAR(50) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Activo BIT,
    @Bloqueado BIT,
    @UsuarioResponsable NVARCHAR(50),
    @PrimerInicio BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO Usuarios(DNI, Nombre, Apellido, [Usuario], Rol, Contraseña, Direccion, Telefono, Email, Activo, Bloqueado, PrimerInicio)
        VALUES (@DNI, @Nombre, @Apellido, @Usuario, @Rol, @Contraseña, @Direccion, @Telefono, @Email, @Activo, @Bloqueado, @PrimerInicio);

        DECLARE @nuevoCod INT = SCOPE_IDENTITY();

        INSERT INTO HistorialUsuario
            (usuarioId, dni, nombre, apellido, usuario, rol, direccion, telefono, email, activo, bloqueado, accion, usuarioResponsable, fecha)
        VALUES
            (@nuevoCod, @DNI, @Nombre, @Apellido, @Usuario, @Rol, @Direccion, @Telefono, @Email, @Activo, @Bloqueado, 3 /* AltaUsuario */, @UsuarioResponsable, GETDATE());

        COMMIT TRANSACTION;
        SELECT @nuevoCod AS Codigo; -- para que EscribirRetornar lo lea, igual que el SP original
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

GO
/****** Objeto: StoredProcedure [dbo].[SP_ElimUsuario] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ElimUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ElimUsuario] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ElimUsuario]
    @Usuario NVARCHAR(50),
    @DVH NVARCHAR(200),
    @UsuarioResponsable NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO HistorialUsuario
            (usuarioId, dni, nombre, apellido, usuario, rol, direccion, telefono, email, activo, bloqueado, accion, usuarioResponsable, fecha)
        SELECT Codigo, DNI, Nombre, Apellido, [Usuario], Rol, Direccion, Telefono, Email, Activo, Bloqueado, 4 /* BajaUsuario */, @UsuarioResponsable, GETDATE()
        FROM Usuarios
        WHERE [Usuario] = @Usuario AND DVH = @DVH;

        UPDATE Usuarios
        set Activo = 0,
            dvh = @DVH
        WHERE [Usuario] = @Usuario;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtBitacora] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtBitacora]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtBitacora] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_ExtBitacora]
AS
BEGIN
    SELECT Registro, Usuario, Accion, Fecha, Detalle
    FROM Bitacora
    ORDER BY Fecha DESC
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtHistorialUsuario] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtHistorialUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtHistorialUsuario] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtHistorialUsuario]
    @idHistorial INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idHistorial, usuarioId, dni, nombre, apellido, usuario, rol,
           direccion, telefono, email, activo, bloqueado, accion, usuarioResponsable, fecha
    FROM HistorialUsuario
    WHERE idHistorial = @idHistorial;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtIdiomas] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtIdiomas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtIdiomas] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtIdiomas]
AS
BEGIN
    SELECT Id, Codigo, Nombre
    FROM Idioma
    ORDER BY Nombre
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtraerDVH] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtraerDVH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtraerDVH] AS' 
END
GO
ALTER procedure [dbo].[SP_ExtraerDVH]
@tabla nvarchar(50)
as
begin
    DECLARE @Query NVARCHAR(MAX);
    SET @Query = 'SELECT DVH FROM ' + @tabla + ' order by Codigo'

    EXEC sp_executesql @Query;
end
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtraerDVV] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtraerDVV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtraerDVV] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtraerDVV]
    @tabla NVARCHAR(50),
    @tablaVerif NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Query NVARCHAR(MAX);

    SET @Query = N'SELECT DVV 
                   FROM ' + QUOTENAME(@tabla) + 
                   N' WHERE tabla = @tablaVerif';

    EXEC sp_executesql @Query, N'@tablaVerif NVARCHAR(50)', @tablaVerif;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtTabla] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtTabla]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtTabla] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtTabla]
    @tabla NVARCHAR(50)
AS
BEGIN
    DECLARE @Query NVARCHAR(MAX);
    SET @Query = 'SELECT * FROM ' + @tabla

    EXEC sp_executesql @Query;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtTraducciones] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtTraducciones]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtTraducciones] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtTraducciones]
    @IdIdioma INT
AS
BEGIN
    SELECT Clave, Texto
    FROM Traduccion
    WHERE IdIdioma = @IdIdioma
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ExtUser] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ExtUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ExtUser] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ExtUser]
    @user NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Usuarios
    WHERE Usuario = @user;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_ListarHistorialUsuario] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarHistorialUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ListarHistorialUsuario] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ListarHistorialUsuario]
    @accion INT = NULL,
    @fechaDesde DATETIME,
    @fechaHasta DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idHistorial, usuarioId, dni, nombre, apellido, usuario, rol,
           direccion, telefono, email, activo, bloqueado, accion, usuarioResponsable, fecha
    FROM HistorialUsuario
    WHERE (@accion IS NULL OR accion = @accion)
      AND fecha BETWEEN @fechaDesde AND @fechaHasta
    ORDER BY fecha DESC;
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_Login] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Login] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_Login]
(
	@user NVARCHAR(50),
	@pass NVARCHAR(65),
	@Result INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Block INT;
	DECLARE @Active INT;
	--Verifico si existe el usuario en la tabla
	IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @user)
	BEGIN
		--Verifico si el usuario se encuentra activo
		SELECT @Active = Activo FROM Usuarios WHERE  Usuario = @user;
		IF @Active = 0
		BEGIN 
			SET @Result = 4 --Indica usuario inactivo
		END
		ELSE
		BEGIN
			--Verifico si el usuario se encuentra bloqueado
			SELECT @Block = Bloqueado FROM Usuarios WHERE  Usuario = @user;
			IF @Block = 1
			BEGIN 
				SET @Result = 2 --Indica usuario bloqueado
			END
			ELSE
			BEGIN
				IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @user AND Contraseña = @pass)
				BEGIN
					SET @Result = 1; --Indica Login correcto
				END
				ELSE
				BEGIN
					SET @Result = 3; --Indica contraseña incorrecta
				END
			END
		END
	END
	ELSE
	BEGIN
		SET @Result = 0 --Indica usuario no encontrado
	END
END
GO
/****** Objeto: StoredProcedure [dbo].[SP_RegistrarEvento] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_RegistrarEvento]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_RegistrarEvento] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_RegistrarEvento]
@usuario nvarchar(50),
@accion int,
@fecha datetime,
@detalle nvarchar(500) = NULL
AS
BEGIN
    INSERT INTO Bitacora
    (Usuario, Accion, Fecha, Detalle)
    VALUES
    (@usuario, @accion, @fecha, @detalle);
END
GO
/****** Objeto: StoredProcedure [dbo].[VincularItem_SP] Fecha de script: 07/11/2026 4:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VincularItem_SP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[VincularItem_SP] AS' 
END
GO

-- Vincula un item pendiente con un producto existente (no cambia proveedor de referencia ni precio)
ALTER   PROCEDURE [dbo].[VincularItem_SP]
    @IdProveedor INT,
    @CodigoProveedor NVARCHAR(50),
    @Codigo NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM ListaPrecio WITH (UPDLOCK, HOLDLOCK)
                   WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor AND Codigo IS NULL)
        THROW 50001, 'El item no existe o ya esta vinculado', 1;

    IF NOT EXISTS (SELECT 1 FROM Productos WHERE Codigo = @Codigo)
        THROW 50003, 'El producto no existe', 1;

    IF EXISTS (SELECT 1 FROM ListaPrecio WHERE IdProveedor = @IdProveedor AND Codigo = @Codigo)
        THROW 50004, 'El producto ya tiene un codigo vinculado para este proveedor', 1;

    UPDATE ListaPrecio SET Codigo = @Codigo
    WHERE IdProveedor = @IdProveedor AND CodigoProveedor = @CodigoProveedor;

    COMMIT TRANSACTION;
END

GO
