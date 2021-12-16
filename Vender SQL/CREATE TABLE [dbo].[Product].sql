CREATE TABLE [dbo].[Product]
(
	[ProdId] INT NOT NULL PRIMARY KEY, 
    [ProdName] NCHAR(20) NOT NULL, 
    [ProdPrice] INT NOT NULL, 
    [ProdQty] INT NOT NULL, 
    [ProdCat] NCHAR(30) NOT NULL
)