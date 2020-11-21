
CREATE TABLE [dbo].[tbl_MetaStatusFileMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileType] [int] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[Short] [varchar](5) NULL,
	[IsDeleted] [bit] NULL DEFAULT ((0))
) ON [PRIMARY]
