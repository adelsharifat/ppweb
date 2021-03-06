USE [master]
GO
/****** Object:  Database [ProjectProgress]    Script Date: 12/18/2021 5:42:33 PM ******/
CREATE DATABASE [ProjectProgress]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectProgress', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ProjectProgress.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [DocumentFileStream] CONTAINS FILESTREAM  DEFAULT
( NAME = N'DocumentFiles', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DocumentFiles' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'ProjectProgress_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ProjectProgress_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectProgress] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectProgress].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectProgress] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectProgress] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectProgress] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectProgress] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectProgress] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectProgress] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectProgress] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectProgress] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectProgress] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectProgress] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectProgress] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectProgress] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectProgress] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectProgress] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectProgress] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectProgress] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectProgress] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectProgress] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectProgress] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectProgress] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectProgress] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectProgress] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectProgress] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectProgress] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectProgress] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectProgress] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectProgress] SET FILESTREAM( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'DocumentStore' ) 
GO
ALTER DATABASE [ProjectProgress] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectProgress] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectProgress', N'ON'
GO
ALTER DATABASE [ProjectProgress] SET QUERY_STORE = OFF
GO
USE [ProjectProgress]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ProjectProgress]
GO
/****** Object:  User [Sharifat]    Script Date: 12/18/2021 5:42:33 PM ******/
CREATE USER [Sharifat] FOR LOGIN [Sharifat] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Sharifat]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Sharifat]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Sharifat]
GO
/****** Object:  UserDefinedTableType [dbo].[tvpAttachments]    Script Date: 12/18/2021 5:42:33 PM ******/
CREATE TYPE [dbo].[tvpAttachments] AS TABLE(
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[FileName] [nvarchar](max) NULL,
	[ObjectId] [int] NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[FileType] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[CreatebBy] [int] NOT NULL,
	[File] [varbinary](max) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHierarchyName]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetHierarchyName] ( @childId int)
RETURNS VARCHAR(max) 

AS

BEGIN
 DECLARE @result varchar(MAX)

;WITH Hierarchy(ChildId, ChildName, ParentId, Parents)
AS
(
    SELECT Id, Name, ParentId, CAST([FirtGeneration].[Name] AS VARCHAR(MAX))
        FROM dbo.MaterialType AS FirtGeneration
        WHERE ParentId IS NULL AND FirtGeneration.isDelete = 0    
    UNION ALL
    SELECT NextGeneration.Id, NextGeneration.Name, Parent.ChildId,
    CAST(CASE WHEN Parent.Parents = ''
        THEN(CAST(NextGeneration.Name AS VARCHAR(MAX)))
        ELSE(Parent.Parents + ' > ' + CAST(NextGeneration.Name AS VARCHAR(MAX)))
    END AS VARCHAR(MAX))
        FROM dbo.MaterialType AS NextGeneration
        INNER JOIN Hierarchy AS Parent ON NextGeneration.ParentId = Parent.ChildId AND NextGeneration.isDelete = 0    
)
SELECT TOP 1 @result = Parents
    FROM Hierarchy WHERE Hierarchy.ChildId = @childId


	RETURN @result

end


GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHierarchyPath]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnGetHierarchyPath] ( @childId INT)
RETURNS VARCHAR(MAX) 

AS

BEGIN
 DECLARE @result VARCHAR(MAX)

;WITH Hierarchy(ChildId, ChildName, ParentId, Parents)
AS
(
    SELECT Id, Name, ParentId, CAST([FirtGeneration].[Name] AS VARCHAR(MAX))
        FROM dbo.Item AS FirtGeneration
        WHERE ParentId IS NULL AND FirtGeneration.isDelete = 0    
    UNION ALL
    SELECT NextGeneration.Id, NextGeneration.Name, Parent.ChildId,
    CAST(CASE WHEN Parent.Parents = ''
        THEN(CAST(NextGeneration.Name AS VARCHAR(MAX)))
        ELSE(Parent.Parents + ' > ' + CAST(NextGeneration.Name AS VARCHAR(MAX)))
    END AS VARCHAR(MAX))
        FROM dbo.Item AS NextGeneration
        INNER JOIN Hierarchy AS Parent ON NextGeneration.ParentId = Parent.ChildId AND NextGeneration.isDelete = 0    
)
SELECT TOP 1 @result = Parents
    FROM Hierarchy WHERE Hierarchy.ChildId = @childId


	RETURN @result

END



GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHierarchyPathId]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnGetHierarchyPathId] ( @childId INT)
RETURNS VARCHAR(MAX) 

AS

BEGIN
 DECLARE @result VARCHAR(MAX)

;WITH Hierarchy(ChildId,ChildName ,ParentId, Parents)
AS
(
    SELECT Id,NULL, ParentId, CAST([FirtGeneration].[Id] AS VARCHAR(MAX))
        FROM dbo.Item AS FirtGeneration
        WHERE ParentId IS NULL AND FirtGeneration.isDelete = 0    
    UNION ALL
    SELECT NextGeneration.Id, NextGeneration.Id, Parent.ChildId,
    CAST(CASE WHEN Parent.Parents = ''
        THEN(CAST(NextGeneration.Id AS VARCHAR(MAX)))
        ELSE(Parent.Parents + ' > ' + CAST(NextGeneration.Id AS VARCHAR(MAX)))
    END AS VARCHAR(MAX))
        FROM dbo.Item AS NextGeneration
        INNER JOIN Hierarchy AS Parent ON NextGeneration.ParentId = Parent.ChildId AND NextGeneration.isDelete = 0    
)
SELECT TOP 1 @result = Parents
    FROM Hierarchy WHERE Hierarchy.ChildId = @childId


	RETURN @result

END



GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[SeenDesktopMode] [bit] NOT NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attachment]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[FileName] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[ObjectId] [int] NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[FileType] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentStore]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[DocumentStore] AS FILETABLE ON [PRIMARY] FILESTREAM_ON [DocumentFileStream]
WITH
(
FILETABLE_DIRECTORY = N'DocumentStore', FILETABLE_COLLATE_FILENAME = Arabic_CI_AS
)

GO
/****** Object:  Table [dbo].[Item]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ParentId] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[ItemsType] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialType]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ParentCategory]  AS ([dbo].[fnGetHierarchyName]([Id])),
	[isDelete] [bit] NULL,
 CONSTRAINT [PK_MaterialType_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[Token] [nvarchar](max) NULL,
	[JwtId] [nvarchar](max) NULL,
	[IsUsed] [bit] NOT NULL,
	[Revoked] [datetime2](7) NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
	[CreatedByIp] [nvarchar](max) NULL,
	[RevokedByIp] [nvarchar](max) NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Attachment_CreatedBy]    Script Date: 12/18/2021 5:42:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Attachment_CreatedBy] ON [dbo].[Attachment]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attachment_ObjectId]    Script Date: 12/18/2021 5:42:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Attachment_ObjectId] ON [dbo].[Attachment]
(
	[ObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Item_ParentId]    Script Date: 12/18/2021 5:42:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Item_ParentId] ON [dbo].[Item]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RefreshToken_CreatedBy]    Script Date: 12/18/2021 5:42:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_RefreshToken_CreatedBy] ON [dbo].[RefreshToken]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppUser] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[AppUser] ADD  DEFAULT ((0)) FOR [SeenDesktopMode]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF__Item__ItemsType__46B27FE2]  DEFAULT ((0)) FOR [ItemsType]
GO
ALTER TABLE [dbo].[MaterialType] ADD  CONSTRAINT [DF_MaterialType_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[MaterialType] ADD  CONSTRAINT [DF_MaterialType_isDelete]  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_AppUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [FK_Attachment_AppUser_CreatedBy]
GO
ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_Item_ObjectId] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[Item] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [FK_Attachment_Item_ObjectId]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Item_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Item_ParentId]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_AppUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_AppUser_CreatedBy]
GO
/****** Object:  StoredProcedure [dbo].[DownloadAttachment]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DownloadAttachment]
@StreamId AS uniqueIdentifier
AS
BEGIN
	SELECT [file_stream] AS [FileStream],file_type AS Extention,[name] AS [FileName] FROM dbo.DocumentStore WHERE stream_id = @StreamId
END

GO
/****** Object:  StoredProcedure [dbo].[FetchItemsNode]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FetchItemsNode]
@ParentId INT = NULL
AS
BEGIN

	IF @ParentId IS NULL
	BEGIN
		WITH ItemsNode AS (
			SELECT * FROM dbo.Item
			WHERE ParentId IS NULL
			UNION ALL
			SELECT i.* FROM dbo.Item i
			JOIN ItemsNode iNodes ON iNodes.Id = i.ParentId
		) SELECT ItemsNode.Id, ItemsNode.CreatedBy, ItemsNode.CreatedDate, ItemsNode.UpdatedBy, ItemsNode.UpdatedDate, ItemsNode.DeletedBy, ItemsNode.DeletedDate, ItemsNode.Name, ItemsNode.ParentId, ItemsNode.IsDelete,dbo.fnGetHierarchyPathId(ItemsNode.Id) AS ParentCategoryPathId,dbo.fnGetHierarchyPath(ItemsNode.Id) AS ParentCategory FROM ItemsNode WHERE ItemsNode.ParentId IS NULL

	END
	ELSE
	BEGIN

		WITH ItemsNode AS (
			SELECT * FROM dbo.Item
			WHERE ParentId IS NULL
			UNION ALL
			SELECT i.* FROM dbo.Item i
			JOIN ItemsNode iNodes ON iNodes.Id = i.ParentId
		) SELECT ItemsNode.Id, ItemsNode.CreatedBy, ItemsNode.CreatedDate, ItemsNode.UpdatedBy, ItemsNode.UpdatedDate, ItemsNode.DeletedBy, ItemsNode.DeletedDate, ItemsNode.Name, ItemsNode.ParentId, ItemsNode.IsDelete,dbo.fnGetHierarchyPathId(ItemsNode.Id) AS ParentCategoryPathId,dbo.fnGetHierarchyPath(ItemsNode.Id) AS ParentCategory FROM ItemsNode WHERE ItemsNode.ParentId = @ParentId


	END

END

GO
/****** Object:  StoredProcedure [dbo].[SaveAttachment]    Script Date: 12/18/2021 5:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveAttachment]
@ObjectId INT,
@UserId INT,
@FileName VARCHAR(200),
@FileContent VARBINARY(MAX),
@Remark NVARCHAR(500) = null
AS
BEGIN

	DECLARE @InsertedAttachment TABLE(stream_id UNIQUEIDENTIFIER,fileName VARCHAR(200),fileType VARCHAR(10))

	INSERT INTO dbo.DocumentStore(file_stream, [name])
	OUTPUT Inserted.stream_id,Inserted.[name],Inserted.file_type INTO @InsertedAttachment
	VALUES(@FileContent,@FileName )

	DECLARE @StreamId UNIQUEIDENTIFIER;
	SELECT TOP 1 @StreamId = stream_id FROM @InsertedAttachment
	
	DECLARE @FileType VARCHAR(10);
	SELECT TOP 1 @FileType = fileType FROM @InsertedAttachment

	INSERT INTO dbo.Attachment(CreatedBy, CreatedDate, [FileName], ObjectId, StreamId,IsDelete, FileType, Remark)
	VALUES(@UserId,GETDATE(),@FileName,@ObjectId,@StreamId,0,@FileType,@Remark)
	
END

GO
USE [master]
GO
ALTER DATABASE [ProjectProgress] SET  READ_WRITE 
GO
