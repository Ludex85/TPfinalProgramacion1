CREATE TABLE [dbo].[Estudiantes] (
    [dni]             NVARCHAR (20)  NOT NULL,
    [nombre]          NVARCHAR (50)  NOT NULL,
    [apellido]        NVARCHAR (50)  NOT NULL,
    [fechanacimiento] DATE           NOT NULL,
    [carrera]         NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([dni] ASC)
);

