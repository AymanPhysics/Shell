 alter table SalaryHistory add LoanValue float
 go
CREATE function [dbo].[GetEmpSumLoanValue]
(@EmpId bigint) returns float
--with encryption
as
begin
declare @val float

select @val=SUM(LoanValue)
from SalaryHistory
where EmpId=@EmpId

select @val=0 where @val is null

return @val

end

GO


