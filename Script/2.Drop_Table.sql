USE [FilesMangerDB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileMetadata]') AND type in (N'U'))
DROP TABLE[dbo].[FileMetadata]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 4/3/2024 10:19:20 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Files]') AND type in (N'U'))
DROP TABLE [dbo].[Files]
GO
