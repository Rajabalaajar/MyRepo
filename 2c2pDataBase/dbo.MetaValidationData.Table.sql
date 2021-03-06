USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[MetaValidationData]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetaValidationData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataSetMetaDataID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_MetaValidationData_IsDeleted]  DEFAULT ((0)),
	[ValidationType] [nvarchar](100) NULL,
	[FieldOrder] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MetaValidationData] ON 

INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (2, 1, N'The field ''Transaction Id'' is empty in the uploaded file ', 0, N'Field', 1)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (4, 1, N'The maximum length for ''Transaction Id'' is 50', 0, N'Business', 2)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (5, 2, N'The field ''Amount'' is empty in the uploaded file', 0, N'Field', 1)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (6, 2, N'The field ''Amount'' should be decimal or number', 0, N'Business', 2)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (7, 3, N'The field ''Transaction Date'' is empty', 0, N'Field', 1)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (9, 3, N'''Transaction Date'' is not in the correct format. Should be ''yyyy-MM-dd hh:mm:ss'' format', 0, N'Business', 2)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (10, 4, N'The field ''Status'' is empty in the uploaded file', 0, N'Field', 1)
INSERT [dbo].[MetaValidationData] ([ID], [DataSetMetaDataID], [Message], [IsDeleted], [ValidationType], [FieldOrder]) VALUES (11, 5, N'The filed ''Currency Code'' is empty in the uploaded file', 0, N'Field', 1)
SET IDENTITY_INSERT [dbo].[MetaValidationData] OFF
