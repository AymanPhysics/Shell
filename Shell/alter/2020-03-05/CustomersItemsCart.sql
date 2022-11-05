select cast(0 as bigint)InvoiceNo,*,getdate()MyGetDate into CustomersItemsCartInvoices from CustomersItemsCart where 1=0
go
alter table CustomersItemsCartInvoices add Price float