USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[tbl_MetaFileType]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_MetaFileType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaFileType] ON 

INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (1, N'CSV')
INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (2, N'XML')
INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (3, N'Global')
SET IDENTITY_INSERT [dbo].[tbl_MetaFileType] OFF
