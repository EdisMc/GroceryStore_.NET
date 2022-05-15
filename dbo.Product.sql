CREATE TABLE [dbo].[Product] (
    [ProdId]   INT          NOT NULL,
    [ProdName] VARCHAR (50) NOT NULL,
    [ProdQty]  INT          NOT NULL,
	[ProdPrice]  INT          NOT NULL,
	[prodExpDate] DATETIME NOT NULL,
    [ProdCat]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProdId] ASC)
);

