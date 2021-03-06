USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[DataSetMetaData]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSetMetaData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataSetID] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_DataSetMetaData_IsDeleted]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DataSetMetaData] ON 

INSERT [dbo].[DataSetMetaData] ([ID], [DataSetID], [Name], [IsDeleted]) VALUES (1, 1, N'TransactionId', 0)
INSERT [dbo].[DataSetMetaData] ([ID], [DataSetID], [Name], [IsDeleted]) VALUES (2, 1, N'Amount', 0)
INSERT [dbo].[DataSetMetaData] ([ID], [DataSetID], [Name], [IsDeleted]) VALUES (3, 1, N'TransactionDate', 0)
INSERT [dbo].[DataSetMetaData] ([ID], [DataSetID], [Name], [IsDeleted]) VALUES (4, 1, N'Status', 0)
INSERT [dbo].[DataSetMetaData] ([ID], [DataSetID], [Name], [IsDeleted]) VALUES (5, 1, N'TransactionCode', 0)
SET IDENTITY_INSERT [dbo].[DataSetMetaData] OFF
