
CREATE TABLE [dbo].[TransactionData](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Transaction Id] [varchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Currency Code] [varchar](10) NULL,
	[Transaction Date] [datetime] NULL,
	[Status] [varchar](10) NULL,
	[UpdatedOn] [datetime] NULL DEFAULT (getdate()),
	[IsDeleted] [bit] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
