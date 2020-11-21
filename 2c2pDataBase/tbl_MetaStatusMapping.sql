
CREATE TABLE [dbo].[tbl_MetaStatusMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SourceID] [int] NULL,
	[TargetID] [int] NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_tbl_MetaStatusMapping_IsDeleted]  DEFAULT ((0))
) ON [PRIMARY]
