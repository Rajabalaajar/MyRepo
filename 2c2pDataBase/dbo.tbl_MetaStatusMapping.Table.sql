USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[tbl_MetaStatusMapping]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MetaStatusMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SourceID] [int] NULL,
	[TargetID] [int] NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatusMapping_IsDeleted]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusMapping] ON 

INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (1, 1, 1, 0)
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (2, 5, 4, 0)
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (3, 3, 2, 0)
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (4, 4, 5, 0)
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (5, 2, 3, 0)
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusMapping] OFF
