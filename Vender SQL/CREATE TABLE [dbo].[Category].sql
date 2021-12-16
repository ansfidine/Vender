CREATE TABLE [dbo].[Category] (
    [ID]   INT        NOT NULL,
    [Name] NCHAR (20) NOT NULL,
    [Description]  NCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);