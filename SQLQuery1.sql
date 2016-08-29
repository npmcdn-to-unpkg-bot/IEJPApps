

select 
	p.Id,
	p.ProjectNumber,
	p.Customer,
	p.Description,
	sum(t.Time) as TotalTime,
	sum(e.Amount) as Total
from
	Projects p left join 
	TimeTransactions t on p.Id = t.ProjectId left join
	ExpenditureTransactions e on p.Id = e.ProjectId
 group by 
	p.Id,p.ProjectNumber,
	p.Customer,
	p.Description