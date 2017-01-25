CREATE VIEW [dbo].[PeriodRates] 	AS 
select WorkPeriod.*, Invoice, InvoiceLists.Rate
from WorkPeriod
inner join InvoiceLists
on WorkPeriod.Timesheet = InvoiceLists.Timesheet;

CREATE VIEW [dbo].[DailyRates] 	AS 
select PeriodDate,
round(Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [DailyHours],
round(Max(Rate)*Sum((convert(float,left(cast(TimeExit as varchar),2)) + convert(float,substring(cast(TimeExit as varchar),4,2))/60)   - 
(convert(float,left(cast(TimeIn as varchar),2)) + convert(float,substring(cast(TimeIn as varchar),4,2))/60)),2)
as [AgencyCharge]
from PeriodRates
group by PeriodDate

CREATE VIEW [dbo].[DailyCharges]
	AS 
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

CREATE PROCEDURE [dbo].[ClearAllTablesProcedure]
AS
	truncate table WorkPeriod
	truncate table InvoiceLists
	truncate table Timesheet
	truncate table Invoices
RETURN 0

CREATE PROCEDURE [dbo].[MakeAllTablesProcedure]
AS

CREATE TABLE [dbo].[Invoices] (
    [Id]          INT           NOT NULL,
    [Invoice]     INT           NULL,
    [AccountRef]  NVARCHAR (50) NULL,
    [InvoiceDate] DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[InvoiceLists] (
    [Id]          INT        NOT NULL,
    [Invoice]     INT        NULL,
    [Weekending]  DATE       NULL,
    [Timesheet]   INT        NULL,
    [HoursWorked] FLOAT (53) NULL,
    [Rate]        FLOAT (53) NULL,
    [Cost]        FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

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

RETURN 0