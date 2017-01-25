CREATE TABLE [dbo].[InvoiceLists] (
    [Id]          INT        NOT NULL,
    [Invoice]     INT        NULL,
    [Weekending] DATE       NULL,
	[Timesheet] int NULL,
	[HoursWorked] float NULL,
	[Rate] float NULL,
	[Cost] float NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

select 
Id, 
year([InvoiceDate]) as Year,
month([InvoiceDate]) as Month,
day([InvoiceDate]) as Day,
day(eomonth([InvoiceDate])) as [End of Month],
11.48 as [Local Authority Rate],
14.5 as [Agency Rate],
3.02 as [Rate Diff]
from Invoices

select
*, (Cost-round((HoursWorked * Rate),2)) as [CostCalcCheck]
from InvoiceLists

select Invoice,
sum(Cost) as [Invoice Cost]
from InvoiceLists
group by Invoice
order by Invoice

select PeriodDate,
sum((convert(float,TimeExit)-(convert(float,TimeIn))*14.5)) as [Day Cost]
from WorkPeriod
group by PeriodDate
order by PeriodDate

select TimeExit, TimeIn,
round(
   (convert(float,left(cast(TimeExit as varchar), 2) 
   + 
    convert(float,substring(cast(TimeExit as varchar),4,2))/60))
	-
	(convert(float,left(cast(TimeIn as varchar), 2)
	 +
	 convert(float,substring(cast(TimeIn as varchar),4,2))/60))
	,2)
from WorkPeriod

select PeriodDate,
sum(round( (convert(float,left(cast(TimeExit as varchar), 2)  +  convert(float,substring(cast(TimeExit as varchar),4,2))/60)) -
		(convert(float,left(cast(TimeIn as varchar), 2) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)) as [Daily Cost]
from WorkPeriod
group by PeriodDate
order by PeriodDate

select PeriodDate,
round( sum(round( (convert(float,left(cast(TimeExit as varchar), 2)  +  convert(float,substring(cast(TimeExit as varchar),4,2))/60)) -
		(convert(float,left(cast(TimeIn as varchar), 2) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)),2) as [Daily Hours]
from WorkPeriod
group by PeriodDate
order by PeriodDate

select WorkPeriod.Timesheet, InvoiceLists.Rate
from WorkPeriod
inner join InvoiceLists
on WorkPeriod.Timesheet = InvoiceLists.Timesheet;

select WorkPeriod.PeriodDate, WorkPeriod.Timesheet
from WorkPeriod
where
WorkPeriod.Timesheet =
(select MAX(WorkPeriod.Timesheet)
from WorkPeriod)

select PeriodDate,
round( sum(round( (convert(float,left(cast(TimeExit as varchar), 2)  +  convert(float,substring(cast(TimeExit as varchar),4,2))/60)) -
		(convert(float,left(cast(TimeIn as varchar), 2) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)),2) as [DailyHours],
		round( sum(round( (convert(float,left(cast(TimeExit as varchar), 2)  +  convert(float,substring(cast(TimeExit as varchar),4,2))/60)) -
		(convert(float,left(cast(TimeIn as varchar), 2) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)),2) * Rate as [DailyCharge]
from DailyRates
group by PeriodDate
order by PeriodDate

select PeriodDate,
round(Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [DailyHours],
round(Max(Rate)*Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [DailyCharge]
from PeriodRates
group by PeriodDate
order by PeriodDate

select PeriodDate,
DailyHours,
AgencyCharge,
iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5) as Limit,
11.48*(iif(DailyHours > 2.5, iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5), DailyHours)) as LocalAuthCharge,
iif(DailyHours > (iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5)), 
   (14.5-11.48) * (DailyHours  - (iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5))),
   (14.5-11.48) * (DailyHours)) as ClientChargeNormalHours,
iif(DailyHours > (iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5)), 14.5 * (DailyHours - (iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5))),0 ) as ClientChargeExtraHours
from DailyRates;

14.5 * (DailyHours - (iif(datepart(dw,PeriodDate) = 4, 3.25, 2.5))) 
(14.5-11.48) * 
CREATE TABLE [dbo].[WorkPeriod] (
    [Id]            INT           NOT NULL,
    [Timesheet]     INT           NULL,
    [PeriodDate]    DATE          NULL,
    [AllocHours]    FLOAT (53)    NULL,
    [TimeIn]        TIME (7)      NULL,
    [TimeExit]      TIME (7)      NULL,
    [ActualService] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


select WorkPeriod.Timesheet, InvoiceLists.Rate
from WorkPeriod
inner join InvoiceLists
on WorkPeriod.Timesheet = InvoiceLists.Timesheet;

select WorkPeriod.*, Invoice, InvoiceLists.Rate
from WorkPeriod
inner join InvoiceLists
on WorkPeriod.Timesheet = InvoiceLists.Timesheet;

select Invoice,
round(Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [InvoiceHours],
round(Max(Rate)*Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [AgencyCharge]
from PeriodRates
group by Invoice

CREATE TABLE [dbo].[WorkPeriod] (
    [Id]            INT           NOT NULL,
    [Timesheet]     INT           NULL,
    [PeriodDate]    DATE          NULL,
    [AllocHours]    FLOAT (53)    NULL,
    [TimeIn]        TIME (7)      NULL,
    [TimeExit]      TIME (7)      NULL,
	[ActualService] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

select Timesheet.Timesheet, InvoiceLists.Invoice
from Timesheet 
inner join InvoiceLists on Timesheet.Timesheet = InvoiceLists.Timesheet
where InvoiceLists.invoice = 1407

select InvoiceLists.Invoice, WorkPeriod.Timesheet,
sum(round(
   (convert(float,left(cast(WorkPeriod.TimeExit as varchar), 2) 
   + 
    convert(float,substring(cast(WorkPeriod.TimeExit as varchar),4,2))/60))
	-
	(convert(float,left(cast(WorkPeriod.TimeIn as varchar), 2)
	 +
	 convert(float,substring(cast(WorkPeriod.TimeIn as varchar),4,2))/60))
	,2)) as TimeSpent
from WorkPeriod
	inner join InvoiceLists
	on WorkPeriod.Timesheet = InvoiceLists.Timesheet
	group by WorkPeriod.Timesheet, InvoiceLists.Invoice
	order by Invoice, Timesheet

select InvoiceLists.Invoice, 
sum(round(
   (convert(float,left(cast(WorkPeriod.TimeExit as varchar), 2) 
   + 
    convert(float,substring(cast(WorkPeriod.TimeExit as varchar),4,2))/60))
	-
	(convert(float,left(cast(WorkPeriod.TimeIn as varchar), 2)
	 +
	 convert(float,substring(cast(WorkPeriod.TimeIn as varchar),4,2))/60))
	,2)) as TimeSpent
from WorkPeriod
	inner join InvoiceLists
	on WorkPeriod.Timesheet = InvoiceLists.Timesheet
	group by  InvoiceLists.Invoice

	select Timesheet from Timesheet where Timesheet = 460414

	CREATE TABLE [dbo].[Timesheet] (
    [Id]         INT           NOT NULL,
    [Timesheet]  INT           NULL,
    [Agency]     NVARCHAR (50) NULL,
    [CareWorker] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[WorkPeriod] (
    [Id]            INT           NOT NULL,
    [Timesheet]     INT           NULL,
    [PeriodDate]    DATE          NULL,
    [AllocHours]    FLOAT (53)    NULL,
    [TimeIn]        TIME (7)      NULL,
    [TimeExit]      TIME (7)      NULL,
    [ActualService] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

create procedure LoadDefaultTables
as
begin
	select * from Timesheet
end