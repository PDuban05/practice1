CREATE TABLE [dbo].[CURSOS]
(
	[COD] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [nombre] NVARCHAR(50) NOT NULL, 
    [fecha_inicio] NVARCHAR(50) NOT NULL, 
    [duracion] NVARCHAR(50) NOT NULL, 
    [valor] NVARCHAR(50) NOT NULL
)
