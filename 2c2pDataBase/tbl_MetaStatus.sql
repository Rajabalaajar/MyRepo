GO
CREATE TABLE [dbo].[tbl_MetaStatus](
	[ID] [int] NOT NULL,
	[Name] [nchar](10) NULL,
	[StatusID] [int] NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatus_IsDeleted]  DEFAULT ((0)),
	[Short] [nchar](10) NULL,
	[IsGlobal] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatus_IsGlobal]  DEFAULT ((0))
) ON [PRIMARY]
