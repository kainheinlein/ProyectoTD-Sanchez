/*
 01_Bitacora_Detalle.sql
 Agrega a la bitacora la "informacion asociada con la actividad" (columna Detalle).
 Script idempotente: se puede ejecutar mas de una vez sin errores ni duplicados.
 - Bitacora.Detalle nvarchar(500) NULL (las filas existentes quedan en NULL).
 - SP_RegistrarEvento: parametro opcional @detalle (default NULL).
 - SP_ExtBitacora: lista explicita de columnas, Detalle al final (la capa DAL lee por indice).
 - SP_BuscarBitacora: solo se agrega B.Detalle al SELECT; el filtro no cambia.
 - Traduccion: clave BIT_COL_DETALLE para ES (1) y EN (2).
 El detalle guarda datos neutros de idioma (clave=valor;clave=valor), nunca frases
 traducibles ni contrasenas/hashes.
*/
USE [FerreDB]
GO

IF COL_LENGTH('dbo.Bitacora', 'Detalle') IS NULL
BEGIN
    ALTER TABLE [dbo].[Bitacora] ADD [Detalle] [nvarchar](500) NULL;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_RegistrarEvento]
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

CREATE OR ALTER PROCEDURE [dbo].[SP_ExtBitacora]
AS
BEGIN
    SELECT Registro, Usuario, Accion, Fecha, Detalle
    FROM Bitacora
    ORDER BY Fecha DESC
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_BuscarBitacora]
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

INSERT INTO [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto])
SELECT 1, N'BIT_COL_DETALLE', N'Detalle'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE IdIdioma = 1 AND Clave = N'BIT_COL_DETALLE');
INSERT INTO [dbo].[Traduccion] ([IdIdioma], [Clave], [Texto])
SELECT 2, N'BIT_COL_DETALLE', N'Details'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Traduccion] WHERE IdIdioma = 2 AND Clave = N'BIT_COL_DETALLE');
GO
