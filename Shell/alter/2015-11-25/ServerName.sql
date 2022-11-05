alter table statics add ServerName nvarchar(100),
ServerDatabaseName nvarchar(100)
go
update statics set ServerName= '41.38.222.242',
ServerDatabaseName ='Physics'
go

create table TablesToBeDownloaded(TableName nvarchar(100),Key1 nvarchar(100),Key2 nvarchar(100),Key3 nvarchar(100))
go
delete TablesToBeDownloaded
insert TablesToBeDownloaded select 'Employees','Id','',''
insert TablesToBeDownloaded select 'chart','Id','',''
insert TablesToBeDownloaded select 'Banks','Id','',''
insert TablesToBeDownloaded select 'Saves','Id','',''
insert TablesToBeDownloaded select 'Customers','Id','',''
insert TablesToBeDownloaded select 'Suppliers','Id','',''
insert TablesToBeDownloaded select 'Stores','Id','',''
insert TablesToBeDownloaded select 'Groups','Id','',''
insert TablesToBeDownloaded select 'Types','GroupId','Id',''
insert TablesToBeDownloaded select 'Items','Id','',''
insert TablesToBeDownloaded select 'ItemsBarcode','ItemId','Barcode',''
insert TablesToBeDownloaded select 'ItemsPrices','ItemId','StoreId',''
insert TablesToBeDownloaded select 'NLevels','Id','',''
insert TablesToBeDownloaded select 'PCs','Id','',''

go

create table TablesToBeUploaded(TableName nvarchar(100),Key1 nvarchar(100),Key2 nvarchar(100),Key3 nvarchar(100))
go
delete TablesToBeUploaded
insert TablesToBeUploaded select 'BankCash','InvoiceNo','Flag','BankId'
insert TablesToBeUploaded select 'BankCash2','InvoiceNo','Flag',''
insert TablesToBeUploaded select 'Entry','InvoiceNo','',''
insert TablesToBeUploaded select 'EntryDt','InvoiceNo','',''
insert TablesToBeUploaded select 'InventoryDetails','StoreId','InvoiceNo',''
insert TablesToBeUploaded select 'InventoryMaster','StoreId','InvoiceNo',''
insert TablesToBeUploaded select 'LiquidationDetails','DayDate','Shift',''
insert TablesToBeUploaded select 'LiquidationMaster','DayDate','Shift',''
insert TablesToBeUploaded select 'PumpsInventoryDetails','DayDate','Shift',''
insert TablesToBeUploaded select 'PumpsInventoryMaster','DayDate','Shift',''
insert TablesToBeUploaded select 'SalesDetails','InvoiceNo','Flag','StoreId'
insert TablesToBeUploaded select 'SalesMaster','InvoiceNo','Flag','StoreId'
insert TablesToBeUploaded select 'ShiftNotes','DayDate','Shift','EmpId'
insert TablesToBeUploaded select 'TanksInventoryDetails','DayDate','Shift','Id'
insert TablesToBeUploaded select 'TanksInventoryDetailsSub','DayDate','Shift','Id'
insert TablesToBeUploaded select 'TanksInventoryMaster','DayDate','Shift',''


