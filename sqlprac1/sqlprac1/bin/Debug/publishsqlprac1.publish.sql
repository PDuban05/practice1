/*
Script de implementación para DBPrac1

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DBPrac1"
:setvar DefaultFilePrefix "DBPrac1"
:setvar DefaultDataPath "C:\Users\Usuario\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Usuario\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Se está quitando la columna [dbo].[CURSOS].[Cod]; puede que se pierdan datos.

Debe agregarse la columna [dbo].[CURSOS].[Id] de la tabla [dbo].[CURSOS], pero esta columna no tiene un valor predeterminado y no admite valores NULL. Si la tabla contiene datos, el script ALTER no funcionará. Para evitar esta incidencia, agregue un valor predeterminado a la columna, márquela de modo que permita valores NULL o habilite la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[CURSOS])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
/*
Se está quitando la columna [dbo].[INSCRITO].[Cod_Curso]; puede que se pierdan datos.

Debe agregarse la columna [dbo].[INSCRITO].[COD] de la tabla [dbo].[INSCRITO], pero esta columna no tiene un valor predeterminado y no admite valores NULL. Si la tabla contiene datos, el script ALTER no funcionará. Para evitar esta incidencia, agregue un valor predeterminado a la columna, márquela de modo que permita valores NULL o habilite la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[INSCRITO])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 49480299-e5a0-40ea-b9df-ac01ea26ee9f se ha omitido; no se cambiará el nombre del elemento [dbo].[alumno] (SqlTable) a [ALUMNO]';


GO
PRINT N'Quitando Clave externa [dbo].[FK_INSCRITO_CURSO]...';


GO
ALTER TABLE [dbo].[INSCRITO] DROP CONSTRAINT [FK_INSCRITO_CURSO];


GO
PRINT N'Quitando Clave externa [dbo].[FK_INSCRITO_ALUMNO]...';


GO
ALTER TABLE [dbo].[INSCRITO] DROP CONSTRAINT [FK_INSCRITO_ALUMNO];


GO
PRINT N'Quitando Clave externa [dbo].[FK_APODERADO_Alumno]...';


GO
ALTER TABLE [dbo].[APODERADO] DROP CONSTRAINT [FK_APODERADO_Alumno];


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[CURSOS]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CURSOS] (
    [Id]           INT           NOT NULL,
    [nombre]       NVARCHAR (50) NOT NULL,
    [fecha_inicio] NVARCHAR (50) NOT NULL,
    [duracion]     NVARCHAR (50) NOT NULL,
    [valor]        NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CURSOS])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_CURSOS] ([Nombre], [Fecha_Inicio], [Duracion], [Valor])
        SELECT [Nombre],
               [Fecha_Inicio],
               [Duracion],
               [Valor]
        FROM   [dbo].[CURSOS];
    END

DROP TABLE [dbo].[CURSOS];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CURSOS]', N'CURSOS';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[INSCRITO]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_INSCRITO] (
    [Id]        INT NOT NULL,
    [Id_Alumno] INT NOT NULL,
    [COD]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[INSCRITO])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_INSCRITO] ([Id], [Id_Alumno])
        SELECT   [Id],
                 [Id_Alumno]
        FROM     [dbo].[INSCRITO]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[INSCRITO];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_INSCRITO]', N'INSCRITO';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creando Tabla [dbo].[ALUMNO]...';


GO
CREATE TABLE [dbo].[ALUMNO] (
    [Id]     INT           NOT NULL,
    [nombre] NVARCHAR (50) NOT NULL,
    [ciudad] NVARCHAR (50) NOT NULL,
    [edad]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '49480299-e5a0-40ea-b9df-ac01ea26ee9f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('49480299-e5a0-40ea-b9df-ac01ea26ee9f')

GO

GO
PRINT N'Actualización completada.';


GO
