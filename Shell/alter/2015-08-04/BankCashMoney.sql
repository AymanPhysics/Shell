alter table BankCashMoney add BankId bigint
go
update BankCashMoney set BankId=(select BankId from BankCash where BankCashMoney.Flag=BankCash.Flag and BankCashMoney.InvoiceNo=BankCash.InvoiceNo)
go
