create table CustomersItemsFavorites(
CustomerId bigint,
ItemId bigint,
  primary key (CustomerId , ItemId )
)
go
create table CustomersItemsCart(
CustomerId bigint,
ItemId bigint,
Qty float,
  primary key (CustomerId , ItemId )
)
go

create table CustomersItemsOrders(
InvoiceNo bigint,
CustomerId bigint,
ItemId bigint,
Qty float,
  primary key (InvoiceNo,CustomerId , ItemId )
)
go
