 
CREATE TABLE [dbo].[InventoryMaster2](
	[StoreId] [int] NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[DocNo] [nvarchar](100) NULL,
	[DayDate] [datetime] NULL,
	[Shift] [int] NULL,
	[InInvoiceNo] [int] NULL,
	[OutInvoiceNo] [int] NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
 CONSTRAINT [PK_InventoryMaster2] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC,
	[InvoiceNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


