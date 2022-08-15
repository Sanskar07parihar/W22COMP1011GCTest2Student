CREATE DATABASE [InventoryManagement]
GO

USE [InventoryManagement]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_InventoryOut_ItemOutDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InventoryOut] DROP CONSTRAINT [DF_InventoryOut_ItemOutDate]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_InventoryIn_ItemInDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InventoryIn] DROP CONSTRAINT [DF_InventoryIn_ItemInDate]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/12/2021 7:48:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UnitOfMeasurement]    Script Date: 12/12/2021 7:48:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UnitOfMeasurement]') AND type in (N'U'))
DROP TABLE [dbo].[UnitOfMeasurement]
GO
/****** Object:  Table [dbo].[InventoryOut]    Script Date: 12/12/2021 7:48:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryOut]') AND type in (N'U'))
DROP TABLE [dbo].[InventoryOut]
GO
/****** Object:  Table [dbo].[InventoryIn]    Script Date: 12/12/2021 7:48:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryIn]') AND type in (N'U'))
DROP TABLE [dbo].[InventoryIn]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2021 7:48:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2021 7:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryIn]    Script Date: 12/12/2021 7:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemInDate] [datetime] NULL,
	[Qty] [int] NULL,
	[UnitId] [int] NULL,
	[CategoryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryOut]    Script Date: 12/12/2021 7:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemOutDate] [datetime] NULL,
	[Qty] [int] NULL,
	[UnitId] [int] NULL,
	[CategoryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitOfMeasurement]    Script Date: 12/12/2021 7:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitOfMeasurement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnitOfMeasurement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/12/2021 7:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InventoryIn] ADD  CONSTRAINT [DF_InventoryIn_ItemInDate]  DEFAULT (getdate()) FOR [ItemInDate]
GO
ALTER TABLE [dbo].[InventoryOut] ADD  CONSTRAINT [DF_InventoryOut_ItemOutDate]  DEFAULT (getdate()) FOR [ItemOutDate]
GO
