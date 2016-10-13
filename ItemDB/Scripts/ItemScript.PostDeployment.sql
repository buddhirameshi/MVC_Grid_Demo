/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/****** Object:  StoredProcedure [dbo].[ItemDeleteData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ItemGetData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[ItemUpdateData]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Item]    Script Date: 10/6/2016 3:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

SET ANSI_PADDING OFF
GO

SET IDENTITY_INSERT [dbo].[Item] ON
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (2, 98.0000, 67.0000, N'This is expensive', NULL)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (3, 78.0000, 99.0000, N'Testing validators', 4)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (5, 104.0000, 456.0000, N'Testing length limitation  of the string', 6)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (12, 0.0000, 0.0000, N'Paging is working', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (14, 0.0000, 0.0000, N'Sorting is working', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (16, 45.0000, 0.0000, N'ass', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (28, 0.0000, 0.0000, N'', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (29, 0.0000, 0.0000, N'', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (30, 35.0000, 0.0000, N'gthhx', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (32, 33.0000, 0.0000, N'tintin', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (33, 0.0000, 0.0000, N'', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (34, 47.0000, 0.0000, N'tintinghjdldq', 0)
GO

INSERT [dbo].[Item] ([ItemId], [Price], [Cost], [Description], [PriceTag]) VALUES (35, 49.0000, 0.0000, N'tinghjyui', 0)
GO

SET IDENTITY_INSERT [dbo].[Item] OFF
GO
