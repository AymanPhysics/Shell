alter TABLE TanksInventoryDetailsSub drop column Line 
alter TABLE TanksInventoryDetails drop column Line 
alter TABLE SalesDetails drop column Line 
alter TABLE DeletedSalesDetails drop column Line 
alter TABLE PumpsInventoryDetails drop column Line 
alter TABLE MoneyTypes drop column Line 
alter TABLE LiquidationDetails drop column Line 
alter TABLE InventoryDetails drop column Line 
go
alter TABLE TanksInventoryDetailsSub add Line int null
alter TABLE TanksInventoryDetails add Line int null
alter TABLE SalesDetails add Line int null
alter TABLE DeletedSalesDetails add Line int null
alter TABLE PumpsInventoryDetails add Line int null
alter TABLE MoneyTypes add Line int null
alter TABLE LiquidationDetails add Line int null
alter TABLE InventoryDetails add Line int null
