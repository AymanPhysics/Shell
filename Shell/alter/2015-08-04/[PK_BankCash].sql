alter TABLE [dbo].[BankCash]alter column [BankId] [int] not NULL
go
alter TABLE [dbo].[BankCash]
add CONSTRAINT [PK_BankCash] PRIMARY KEY CLUSTERED 
(
	[Flag] ASC,
	[BankId] ASC,
	[InvoiceNo] ASC
)

