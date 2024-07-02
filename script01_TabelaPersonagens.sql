IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_MEMBERS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Email] varchar(200) NOT NULL,
    [Nivelconta] int NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_MEMBERS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Email', N'Nivelconta', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_MEMBERS]'))
    SET IDENTITY_INSERT [TB_MEMBERS] ON;
INSERT INTO [TB_MEMBERS] ([Id], [Classe], [Email], [Nivelconta], [Nome])
VALUES (1, 3, 'brad@gmail.com', 10, 'Brad'),
(2, 2, 'bruno@gmail.com', 8, 'Bruno'),
(3, 3, 'eduardo@gmail.com', 6, 'Eduardo'),
(4, 1, 'vitor@gmail.com', 4, 'Vitor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Email', N'Nivelconta', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_MEMBERS]'))
    SET IDENTITY_INSERT [TB_MEMBERS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240702020042_InitialCreate', N'8.0.6');
GO

COMMIT;
GO

