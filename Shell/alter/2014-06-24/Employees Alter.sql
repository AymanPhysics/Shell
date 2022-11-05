Alter Table Employees Add DefaultBank int

Go

Update Employees Set
DefaultBank = 0
Where DefaultBank is null

Go

Alter Table SalesMaster Add BankId int

Go

Update SalesMaster Set
BankId = 1
Where BankId is null

Go

Alter Table DeletedSalesMaster Add BankId int

Go

Update DeletedSalesMaster  Set
BankId = 1
Where BankId is null


Alter Table SalesDetails Add Qty2 int

Go

Update SalesDetails Set
Qty2 = 1
Where Qty2 is null


