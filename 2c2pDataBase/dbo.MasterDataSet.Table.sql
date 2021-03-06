USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[MasterDataSet]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterDataSet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_MasterDataSet_IsDeleted]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MasterDataSet] ON 

INSERT [dbo].[MasterDataSet] ([ID], [Name], [IsDeleted]) VALUES (1, N'FileModel', 0)
SET IDENTITY_INSERT [dbo].[MasterDataSet] OFF
