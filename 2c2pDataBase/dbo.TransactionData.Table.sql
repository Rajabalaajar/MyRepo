USE [2c3pTestDatabase]
GO
/****** Object:  Table [dbo].[TransactionData]    Script Date: 22-11-2020 09:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionData] ON 

INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (1, N'Inv00001', CAST(200 AS Decimal(18, 0)), N'USD', CAST(N'2019-01-23 13:45:10.000' AS DateTime), N'Done', CAST(N'2020-11-20 10:20:13.250' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (2, N'Inv00002 ', CAST(10000 AS Decimal(18, 0)), N'EUR', CAST(N'2019-01-24 16:09:15.000' AS DateTime), N'Rejected', CAST(N'2020-11-20 10:20:13.250' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (3, N'Invoice0000001g', CAST(1000 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-20 12:33:16.000' AS DateTime), N'Approved', CAST(N'2020-11-20 21:41:56.143' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (4, N'Invoice0000002', CAST(300 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-21 02:04:59.000' AS DateTime), N'Failed', CAST(N'2020-11-20 21:41:56.143' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (5, N'Inv00001', CAST(200 AS Decimal(18, 0)), N'USD', CAST(N'2019-01-23 13:45:10.000' AS DateTime), N'Done', CAST(N'2020-11-21 00:09:43.237' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (6, N'Inv00002 ', CAST(10000 AS Decimal(18, 0)), N'EUR', CAST(N'2019-01-24 16:09:15.000' AS DateTime), N'Rejected', CAST(N'2020-11-21 00:09:43.237' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (7, N'Invoice0000001g', CAST(1000 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-20 12:33:16.000' AS DateTime), N'Approved', CAST(N'2020-11-21 00:28:38.133' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (8, N'Invoice0000002', CAST(300 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-21 02:04:59.000' AS DateTime), N'Failed', CAST(N'2020-11-21 00:28:38.133' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (9, N'Invoice0000001g', CAST(1000 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-20 12:33:16.000' AS DateTime), N'Approved', CAST(N'2020-11-22 09:25:23.030' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (10, N'Invoice0000002', CAST(300 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-21 02:04:59.000' AS DateTime), N'Failed', CAST(N'2020-11-22 09:25:23.030' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (11, N'Inv00001', CAST(200 AS Decimal(18, 0)), N'USD', CAST(N'2019-01-23 13:45:10.000' AS DateTime), N'Done', CAST(N'2020-11-22 09:31:39.877' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (12, N'Inv00002 ', CAST(10000 AS Decimal(18, 0)), N'EUR', CAST(N'2019-01-24 16:09:15.000' AS DateTime), N'Rejected', CAST(N'2020-11-22 09:31:39.877' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (13, N'Inv00001', CAST(200 AS Decimal(18, 0)), N'USD', CAST(N'2019-01-23 13:45:10.000' AS DateTime), N'Done', CAST(N'2020-11-22 09:32:33.557' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (14, N'Inv00002 ', CAST(10000 AS Decimal(18, 0)), N'EUR', CAST(N'2019-01-24 16:09:15.000' AS DateTime), N'Rejected', CAST(N'2020-11-22 09:32:33.557' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (15, N'Inv00001', CAST(200 AS Decimal(18, 0)), N'USD', CAST(N'2019-01-23 13:45:10.000' AS DateTime), N'Done', CAST(N'2020-11-22 09:32:41.180' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (16, N'Inv00002 ', CAST(10000 AS Decimal(18, 0)), N'EUR', CAST(N'2019-01-24 16:09:15.000' AS DateTime), N'Rejected', CAST(N'2020-11-22 09:32:41.180' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (17, N'Invoice0000001g', CAST(1000 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-20 12:33:16.000' AS DateTime), N'Approved', CAST(N'2020-11-22 09:38:45.350' AS DateTime), 0)
INSERT [dbo].[TransactionData] ([ID], [Transaction Id], [Amount], [Currency Code], [Transaction Date], [Status], [UpdatedOn], [IsDeleted]) VALUES (18, N'Invoice0000002', CAST(300 AS Decimal(18, 0)), N'USD', CAST(N'2019-02-21 02:04:59.000' AS DateTime), N'Failed', CAST(N'2020-11-22 09:38:45.350' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TransactionData] OFF
