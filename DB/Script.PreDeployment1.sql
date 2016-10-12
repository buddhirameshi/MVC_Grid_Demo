/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [RamzDB]
GO
/****** Object:  StoredProcedure [dbo].[ItemDeleteData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[ItemDeleteData]
	@ItemId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


			DELETE  FROM [dbo].[Item] WHERE ItemId=@ItemId
		
END

GO
/****** Object:  StoredProcedure [dbo].[ItemGetData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- =============================================
CREATE PROCEDURE [dbo].[ItemGetData] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT ItemId,Price,Description FROM Item 
END

GO
/****** Object:  StoredProcedure [dbo].[ItemUpdateData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[ItemUpdateData]
	@ItemId INT=0,
	@Price MONEY,
	@Description VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PriceTag INT=0,
			@Cost MONEY =0.00

	IF EXISTS (SELECT ItemID FROM [dbo].[Item] T WHERE T.ItemId=@ItemId)
	BEGIN
			UPDATE [dbo].[Item]
				SET Description=@Description,
				Price=@Price
				WHERE ItemId=@ItemId

	END
	ELSE
			BEGIN
			
				INSERT INTO [dbo].[Item] (Price,Description,PriceTag,Cost)
													VALUES(@Price,@Description,@PriceTag,@Cost)
			END
  
END

GO
/****** Object:  Table [dbo].[Item]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NULL,
	[Cost] [money] NULL,
	[Description] [varchar](50) NULL,
	[PriceTag] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (2, 98.0000, 67.0000, N'This is expensive', NULL)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (3, 78.0000, 99.0000, N'Testing validators', 4)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (5, 104.0000, 456.0000, N'Testing length limitation  of the string', 6)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (12, 0.0000, 0.0000, N'Paging is working', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (14, 0.0000, 0.0000, N'Sorting is working', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (16, 45.0000, 0.0000, N'ass', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (28, 0.0000, 0.0000, N'', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (29, 0.0000, 0.0000, N'', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (30, 35.0000, 0.0000, N'gthhx', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (32, 33.0000, 0.0000, N'tintin', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (33, 0.0000, 0.0000, N'', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (34, 47.0000, 0.0000, N'tintinghjdldq', 0)
INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (35, 49.0000, 0.0000, N'tinghjyui', 0)
SET IDENTITY_INSERT [dbo].[Item] OFF
