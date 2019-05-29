CREATE DATABASE ONLINESHOP
GO
USE ONLINESHOP
GO
CREATE TABLE Account
(
	UserName VARCHAR(20) PRIMARY KEY NOT NULL,
	PassWord VARCHAR(16) NOT NULL
)
CREATE TABLE Category
(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(250) ,
	MetaTitle VARCHAR(250),
	ParentID INT ,
	DisplayOrder INT DEFAULT 0,
	CreateDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(50),
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(50),
	MetaKeywords NVARCHAR(250),
	MetaDescriptions NCHAR(250),
	Status BIT DEFAULT 1,
	ShowOnHome Bit DEFAULT 0
)
CREATE TABLE Product
(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(250),
	MetaTitle VARCHAR(250),
	Description NVARCHAR(250),
	Images NVARCHAR(250),
	MoreImages XML,
	Price DECIMAL(18,0) DEFAULT 0,
	PromotionPrice DECIMAL(18,0),
	IncludeVAT BIT,
	Quantity INT NOT NULL DEFAULT 0,
	CategoryID BIGINT ,
	Detail NTEXT,
	Warranty INT,
	CreateDate DATETIME DEFAULT GETDATE(),
	CreatedBy VARCHAR(50),
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(50),
	MetaKeywords NVARCHAR(250),
	MetaDescriptions NCHAR(250),
	Status BIT DEFAULT 1,
	TopHot DATETIME,

)
CREATE PROCEDURE USP_Login @user varchar(20), @pass varchar(16)
AS
BEGIN
	DECLARE @count INT
	DECLARE @res BIT
    SELECT @count=COUNT(*) FROM dbo.Account WHERE UserName=@user AND PassWord=@pass
	IF (@count>0)
		SET @res=1
	ELSE
		SET @res=0
	SELECT @res
END
GO
CREATE PROC USP_Category_ListAll
AS
BEGIN
	SELECT * FROM dbo.Category WHERE Status=1
	ORDER BY [Order] asc
END
GO
CREATE PROC USP_Category_Insert
	@Name NVARCHAR(50),
	@Alias VARCHAR(50),
	@ParentID INT,
	@Order INT,
	@Status bit
AS
BEGIN
	INSERT INTO dbo.Category
	        ( Name ,
	          Alias ,
	          ParentID ,
	          CreateDate ,
	          [Order] ,
	          Status
	        )
	VALUES  ( @Name, -- Name - nvarchar(50)
	          @Alias , -- Alias - varchar(50)
	          @ParentID , -- ParentID - int
	          GETDATE() , -- CreateDate - datetime
	          @Order , -- Order - int
	          @Status  -- Status - bit
	        )
END
EXEC dbo.USP_Category_Insert @Name = N'', -- nvarchar(50)
    @Alias = '', -- varchar(50)
    @ParentID = 0, -- int
    @Order = 0, -- int
    @Status = NULL -- bit
