
CREATE TABLE [dbo].[TanksInventoryMaster2](
InvoiceNo bigint,
	[DayDate] [datetime] NOT NULL,
	[Shift] [int] NOT NULL,
	[UserName] [int] NULL,
	[MyGetDate] [datetime] NULL,
	[Notes] [varchar](4000) NULL,
	[Total] [float] NULL,
	[ToId] [bigint] NULL,
 CONSTRAINT [PK_TanksInventoryMaster2] PRIMARY KEY CLUSTERED 
(
	InvoiceNo 
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


alter table [TanksInventoryMaster2] add Car float,Diff float