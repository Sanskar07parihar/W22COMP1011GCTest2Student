USE [InventoryManagement]
GO

DELETE FROM [dbo].[Users]
GO

INSERT [dbo].[Users] ([UserName], [Password], [FirstName], [LastName]) VALUES (N'admin', N'admin', N'admin', N'user')
GO
