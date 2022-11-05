declare @x int=221 ,@max int=500

while @x<=@max
begin
	declare @sql nvarchar(1000)='alter table NLevels drop column menuitem'+cast(@x as nvarchar(10))
	exec(@sql)
	set @x+=1
end

select * from NLevels