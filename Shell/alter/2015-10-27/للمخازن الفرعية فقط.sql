-- راجعها كويس 
-- للمخازن الفرعية فقط

SELECT * FROM [Shell].[dbo].Stores
update [Shell].[dbo].Stores set Flag=1,CurrentDate='2015-11-13 00:00:00.000'


update [Shell].[dbo].Stores set Flag=1,CurrentShift=1,CurrentDate='2015-01-08 00:00:00.000' where CurrentDate is null

