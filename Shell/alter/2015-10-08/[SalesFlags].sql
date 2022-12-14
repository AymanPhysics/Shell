 
CREATE TABLE [dbo].[SalesFlags](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Cashier] [nvarchar](100) NULL,
	[ItemInOut] [float] NULL,
	[ItemIn] [float] NULL,
	[ItemOut] [float] NULL,
	[FlagValue] [float] NULL,
 CONSTRAINT [PK SalesFlags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (1, N'أرصدة افتتاحية', N'', N'المستلم', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (2, N'إضافة', N'', N'المستلم', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (3, N'تسوية إضافة', N'', N'المستلم', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (4, N'صرف', N'', N'المستلم', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (5, N'تسوية صرف', N'', N'المستلم', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (6, N'هدايا', N'', N'المستلم', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (7, N'هالك', N'', N'المستلم', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (8, N'تحويل إلى مخزن', N'المخزن المحول إليه', N'المستلم', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (9, N'مشتريات', N'المورد', N'الطالب', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (10, N'مردودات مشتريات', N'المورد', N'الطالب', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (11, N'مبيعات الصالة', N'العميل', N'البائع', -1, 0, 1, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (12, N'مردودات مبيعات الصالة', N'العميل', N'البائع', 1, 1, 0, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (13, N'المبيعات', N'العميل', N'البائع', -1, 0, 1, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (14, N'مردودات المبيعات', N'العميل', N'البائع', 1, 1, 0, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (15, N'مبيعات التوصيل', N'العميل', N'البائع', -1, 0, 1, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (16, N'مردودات مبيعات التوصيل', N'العميل', N'البائع', 1, 1, 0, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (17, N'مشتريات من عملاء', N'العميل', N'البائع', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (18, N'مبيعات لموردين', N'المورد', N'البائع', -1, 0, 1, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (19, N'سلفة', N'المورد', N'الطالب', 1, 1, 0, 1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (20, N'رد سلفة', N'المورد', N'الطالب', -1, 0, 1, -1)
INSERT [dbo].[SalesFlags] ([Id], [Name], [Title], [Cashier], [ItemInOut], [ItemIn], [ItemOut], [FlagValue]) VALUES (27, N'مبيعات الوردية', N'العميل', N'البائع', 0, 0, 0, 0)
