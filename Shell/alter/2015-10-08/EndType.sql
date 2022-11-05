select * from chart

update chart set EndType=(Case 
when EndType=0 then 3
when EndType=1 then 0
when EndType=2 then 1
when EndType=3 then 2
end)

select * from chart

