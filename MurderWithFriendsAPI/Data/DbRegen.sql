
/****** Object:  Database [ItsOnlyHeroes]    Script Date: 9/4/2018 10:11:43 PM ******/
CREATE DATABASE [ItsOnlyHeroes]
GO

USE [ItsOnlyHeroes]
GO
ALTER DATABASE SCOPED CONFIGURATION SET DISABLE_BATCH_MODE_ADAPTIVE_JOINS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET DISABLE_BATCH_MODE_MEMORY_GRANT_FEEDBACK = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET DISABLE_INTERLEAVED_EXECUTION_TVF = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_ONLINE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_RESUMABLE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ISOLATE_SECURITY_POLICY_CARDINALITY = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET OPTIMIZE_FOR_AD_HOC_WORKLOADS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = OFF;
GO
USE [ItsOnlyHeroes]
GO
/****** Object:  User [murder]    Script Date: 9/4/2018 10:11:44 PM ******/
CREATE USER [murder] FOR LOGIN [murder] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [murder]
GO
ALTER ROLE [db_datareader] ADD MEMBER [murder]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [murder]
GO
/****** Object:  Schema [Account]    Script Date: 9/4/2018 10:11:44 PM ******/
CREATE SCHEMA [Account]
GO
/****** Object:  Schema [Character]    Script Date: 9/4/2018 10:11:44 PM ******/
CREATE SCHEMA [Character]
GO
/****** Object:  Schema [Currency]    Script Date: 9/4/2018 10:11:44 PM ******/
CREATE SCHEMA [Currency]
GO
/****** Object:  Schema [Item]    Script Date: 9/4/2018 10:11:44 PM ******/
CREATE SCHEMA [Item]
GO
/****** Object:  Schema [Stats]    Script Date: 9/4/2018 10:11:45 PM ******/
CREATE SCHEMA [Stats]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Account].[Inventory](
	[UserId] [bigint] NULL,
	[ItemId] [int] NULL,
	[CharacterId] [bigint] NULL,
	[InventoryId] [bigint] IDENTITY(1,1) PRIMARY KEY
)
GO
/****** Object:  Table [Account].[LoginHistory]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Account].[LoginHistory](
	[LoginHistoryId] [bigint] NOT NULL,
	[UserId] [bigint] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[LoginResultId] [int] IDENTITY (1,1) PRIMARY KEY
)
GO
/****** Object:  Table [Account].[LoginResult]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Account].[LoginResult](
	[LoginResultId] [int] IDENTITY(1,1) PRIMARY KEY,
	[Result] [nvarchar](50) NULL,
	[Details] [nvarchar](500) NULL
)
GO
/****** Object:  Table [Account].[Security]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Account].[Security](
	[SecurityId] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[UserId] [bigint] NOT NULL,
	[SaltedHash] [nvarchar](256) NULL
)

GO
/****** Object:  Table [Account].[User]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Account].[User](
	[UserId] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[UserName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[LastLogin] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL
	)
GO
/****** Object:  Table [Character].[Character]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Character].[Character](
	[CharacterId] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[BaseStatsId] [bigint] NOT NULL,
	[SkillSetId] [bigint] NOT NULL,
	[ExperienceId] [bigint] NULL
)
GO
/****** Object:  Table [Character].[Equipment]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Character].[Equipment](
	[CharacterId] [bigint] NULL,
	[ItemId] [int] NULL,
	[UserId] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[ExperienceId] [bigint] NOT NULL,
	[EquipmentId] [bigint] IDENTITY(1,1) PRIMARY KEY 
)
GO
/****** Object:  Table [Currency].[CurrencyType]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Currency].[CurrencyType](
	[CurrencyTypeId] [int] IDENTITY(1,1) PRIMARY KEY,
	[CurrencyTypeName] [nchar](20) NULL,
	[Active] [bit] NULL,
	[ValueInUSD] [money] NULL
)
GO
/****** Object:  Table [Currency].[UserCurrency]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Currency].[UserCurrency](
	[UserId] [bigint] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[UserCurrencyId] [bigint] IDENTITY(1,1) PRIMARY KEY
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Item].[Item](
	[ItemId] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](256) NULL,
	[Description] [nvarchar](256) NULL,
	[SellValue] [int] NULL,
	[BuyValue] [int] NULL,
	[BuyCurrencyId] [int] NULL,
	[ItemTypeId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[StatsId] [bigint] NULL
	)
GO
/****** Object:  Table [Item].[ItemType]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Item].[ItemType](
	[ItemTypeId] [int] IDENTITY(1,1) PRIMARY KEY,
	[ItemTypeName] [nchar](20) NULL,
	[ItemTypeDescription] [nchar](256) NULL,
)
GO
/****** Object:  Table [Stats].[Experience]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Stats].[Experience](
	[ExperienceId] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Amount] [bigint] NOT NULL,
	[CurrentLevel] [int] NOT NULL,
)
GO
/****** Object:  Table [Stats].[Stats]    Script Date: 9/4/2018 10:11:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Stats].[Stats](
	[StatsId] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Strength] [int] NULL,
	[Dexterity] [int] NULL,
	[Agility] [int] NULL,
	[Wisdom] [int] NULL,
	[Intelligence] [int] NULL,
	[Charisma] [int] NULL,
	[Constitution] [int] NULL,
	[ElectricResist] [int] NULL,
	[WaterResist] [int] NULL,
	[FireResist] [int] NULL,
	[EarthResist] [int] NULL,
	[HolyResist] [int] NULL,
	[DarkResist] [int] NULL,
	[ElectricBonus] [int] NULL,
	[WaterBonus] [int] NULL,
	[FireBonus] [int] NULL,
	[EarthBonus] [int] NULL,
	[HolyBonus] [int] NULL,
	[DarkBonus] [int] NULL,
	[Armor] [int] NULL,
	[MagicResist] [int] NULL,
	[ArmorPenetration] [int] NULL,
	[MagicPenetration] [int] NULL,
 )
GO
ALTER TABLE [Account].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Item] FOREIGN KEY([ItemId])
REFERENCES [Item].[Item] ([ItemId])
GO
ALTER TABLE [Account].[Inventory] CHECK CONSTRAINT [FK_Inventory_Item]
GO
ALTER TABLE [Account].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_User] FOREIGN KEY([UserId])
REFERENCES [Account].[User] ([UserId])
GO
ALTER TABLE [Account].[Inventory] CHECK CONSTRAINT [FK_Inventory_User]
GO
ALTER TABLE [Account].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_LoginResult] FOREIGN KEY([LoginResultId])
REFERENCES [Account].[LoginResult] ([LoginResultId])
GO
ALTER TABLE [Account].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_LoginResult]
GO
ALTER TABLE [Account].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_User] FOREIGN KEY([UserId])
REFERENCES [Account].[User] ([UserId])
GO
ALTER TABLE [Account].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_User]
GO
ALTER TABLE [Account].[Security]  WITH CHECK ADD  CONSTRAINT [FK_Security_User] FOREIGN KEY([UserId])
REFERENCES [Account].[User] ([UserId])
GO
ALTER TABLE [Account].[Security] CHECK CONSTRAINT [FK_Security_User]
GO
ALTER TABLE [Character].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Experience] FOREIGN KEY([ExperienceId])
REFERENCES [Stats].[Experience] ([ExperienceId])
GO
ALTER TABLE [Character].[Character] CHECK CONSTRAINT [FK_Character_Experience]
GO
ALTER TABLE [Character].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Stats] FOREIGN KEY([BaseStatsId])
REFERENCES [Stats].[Stats] ([StatsId])
GO
ALTER TABLE [Character].[Character] CHECK CONSTRAINT [FK_Character_Stats]
GO
ALTER TABLE [Character].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Character] FOREIGN KEY([CharacterId])
REFERENCES [Character].[Character] ([CharacterId])
GO
ALTER TABLE [Character].[Equipment] CHECK CONSTRAINT [FK_Equipment_Character]
GO
ALTER TABLE [Character].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Experience] FOREIGN KEY([ExperienceId])
REFERENCES [Stats].[Experience] ([ExperienceId])
GO
ALTER TABLE [Character].[Equipment] CHECK CONSTRAINT [FK_Equipment_Experience]
GO
ALTER TABLE [Character].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Item] FOREIGN KEY([ItemId])
REFERENCES [Item].[Item] ([ItemId])
GO
ALTER TABLE [Character].[Equipment] CHECK CONSTRAINT [FK_Equipment_Item]
GO
ALTER TABLE [Character].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_User] FOREIGN KEY([UserId])
REFERENCES [Account].[User] ([UserId])
GO
ALTER TABLE [Character].[Equipment] CHECK CONSTRAINT [FK_Equipment_User]
GO
ALTER TABLE [Currency].[UserCurrency]  WITH CHECK ADD  CONSTRAINT [FK_UserCurrency_CurrencyType] FOREIGN KEY([CurrencyId])
REFERENCES [Currency].[CurrencyType] ([CurrencyTypeId])
GO
ALTER TABLE [Currency].[UserCurrency] CHECK CONSTRAINT [FK_UserCurrency_CurrencyType]
GO
ALTER TABLE [Currency].[UserCurrency]  WITH CHECK ADD  CONSTRAINT [FK_UserCurrency_User] FOREIGN KEY([UserId])
REFERENCES [Account].[User] ([UserId])
GO
ALTER TABLE [Currency].[UserCurrency] CHECK CONSTRAINT [FK_UserCurrency_User]
GO
ALTER TABLE [Item].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_CurrencyType] FOREIGN KEY([BuyCurrencyId])
REFERENCES [Currency].[CurrencyType] ([CurrencyTypeId])
GO
ALTER TABLE [Item].[Item] CHECK CONSTRAINT [FK_Item_CurrencyType]
GO
ALTER TABLE [Item].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [Item].[ItemType] ([ItemTypeId])
GO
ALTER TABLE [Item].[Item] CHECK CONSTRAINT [FK_Item_ItemType]
GO
ALTER TABLE [Item].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Stats] FOREIGN KEY([StatsId])
REFERENCES [Stats].[Stats] ([StatsId])
GO
ALTER TABLE [Item].[Item] CHECK CONSTRAINT [FK_Item_Stats]
GO
