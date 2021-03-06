USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[tbl_MetaStatusFileMapping]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_MetaStatusFileMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileType] [int] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[Short] [varchar](5) NULL,
	[IsDeleted] [bit] NULL DEFAULT ((0))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusFileMapping] ON 

INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (3, 3, N'Approved', N'Approved', N'A', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (4, 3, N'Done', N'Done', N'D', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (5, 3, N'Rejected', N'Rejected', N'R', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (6, 1, N'Approved', N'Approved', N'A', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (7, 1, N'Failed', N'Failed', N'F', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (8, 1, N'Finished', N'Finished', N'F', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (9, 2, N'Approved', N'Approved', N'A', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (10, 2, N'Rejected', N'Rejected', N'R', 0)
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (11, 2, N'Done', N'Done', N'D', 0)
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusFileMapping] OFF
ALTER TABLE [dbo].[tbl_MetaStatusFileMapping]  WITH CHECK ADD FOREIGN KEY([FileType])
REFERENCES [dbo].[tbl_MetaFileType] ([ID])
GO
