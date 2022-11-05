

CREATE FUNCTION [dbo].[Fn_EmpStores]
(
@EmpId bigint
)
RETURNS @tbl table(Id int, Name nvarchar(1000),Permission bit,Flag int)
--with encryption
AS
BEGIN
	
	insert @tbl 
	select distinct S.Id,S.Name,cast((case when E.EmpId is null then 0 else 1 end) as bit) Permission,Flag
	from EmpStores E right join Stores S on(E.StoreId=S.Id)
	where (EmpId=@EmpId or 
			exists(select Id from Employees where Id=@EmpId and Manager=1) or 
			exists(select DefaultStore from Employees where Id=@EmpId and DefaultStore=S.Id)
			)
	
	RETURN 
END

GO


