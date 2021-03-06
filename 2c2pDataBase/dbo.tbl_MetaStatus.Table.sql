USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[tbl_MetaStatus]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MetaStatus](
	[ID] [int] NOT NULL,
	[Name] [nchar](10) NULL,
	[StatusID] [int] NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatus_IsDeleted]  DEFAULT ((0)),
	[Short] [nchar](10) NULL,
	[IsGlobal] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatus_IsGlobal]  DEFAULT ((0))
) ON [PRIMARY]

GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (1, N'Approved  ', 1, 0, N'A         ', 1)
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (2, N'Finished  ', 2, 0, N'F         ', 0)
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (3, N'Done      ', 3, 0, N'D         ', 1)
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (4, N'Failed    ', 4, 0, N'R         ', 1)
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (5, N'Rejected  ', 5, 0, N'R         ', 0)
