CREATE TABLE [dbo].[Countries] (
    [Id]        INT            NOT NULL,
    [Name]      NVARCHAR (150) NOT NULL,
    [PhoneCode] NVARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

