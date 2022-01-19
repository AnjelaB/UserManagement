CREATE TABLE [dbo].[Users] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [FullName]       NVARCHAR (500) NOT NULL,
    [MobileNumber]   NVARCHAR (100) NOT NULL,
    [CountryId]      INT            NOT NULL,
    [State]          TINYINT        NOT NULL,
    [CreationTime]   DATETIME2 (7)  NOT NULL,
    [LastUpdateTime] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);

