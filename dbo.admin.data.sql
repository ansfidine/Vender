
CREATE TABLE [dbo].[admin]
(
	[id] INT NOT NULL, 
    [username] NCHAR(20) NOT NULL, 
    [password] NCHAR(20) NOT NULL 
)

INSERT INTO [dbo].[admin] ([id],[username], [password]) VALUES (1,'ansfidine', 'root')
