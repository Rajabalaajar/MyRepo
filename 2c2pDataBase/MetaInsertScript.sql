USE [2c3pTestDatabase]
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaFileType] ON 

GO
INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (1, N'CSV')
GO
INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (2, N'XML')
GO
INSERT [dbo].[tbl_MetaFileType] ([ID], [Name]) VALUES (3, N'Global')
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaFileType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusFileMapping] ON 

GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (3, 3, N'Approved', N'Approved', N'A', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (4, 3, N'Done', N'Done', N'D', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (5, 3, N'Rejected', N'Rejected', N'R', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (6, 1, N'Approved', N'Approved', N'A', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (7, 1, N'Failed', N'Failed', N'F', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (8, 1, N'Finished', N'Finished', N'F', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (9, 2, N'Approved', N'Approved', N'A', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (10, 2, N'Rejected', N'Rejected', N'R', 0)
GO
INSERT [dbo].[tbl_MetaStatusFileMapping] ([ID], [FileType], [Name], [Description], [Short], [IsDeleted]) VALUES (11, 2, N'Done', N'Done', N'D', 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusFileMapping] OFF
GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (1, N'Approved', 1, 0, N'A', 1)
GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (2, N'Finished', 2, 0, N'F', 0)
GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (3, N'Done', 3, 0, N'D', 1)
GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (4, N'Failed', 4, 0, N'R', 1)
GO
INSERT [dbo].[tbl_MetaStatus] ([ID], [Name], [StatusID], [IsDeleted], [Short], [IsGlobal]) VALUES (5, N'Rejected', 5, 0, N'R', 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusMapping] ON 

GO
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (1, 1, 1, 0)
GO
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (2, 5, 4, 0)
GO
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (3, 3, 2, 0)
GO
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (4, 4, 5, 0)
GO
INSERT [dbo].[tbl_MetaStatusMapping] ([ID], [SourceID], [TargetID], [IsDeleted]) VALUES (5, 2, 3, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_MetaStatusMapping] OFF
GO
