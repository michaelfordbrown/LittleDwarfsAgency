//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimesheetHandler
{
    using System;
    using System.Collections.Generic;
    
    public partial class PeriodRate
    {
        public int Id { get; set; }
        public Nullable<int> Timesheet { get; set; }
        public Nullable<System.DateTime> PeriodDate { get; set; }
        public Nullable<double> AllocHours { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeExit { get; set; }
        public string ActualService { get; set; }
        public Nullable<int> Invoice { get; set; }
        public Nullable<double> Rate { get; set; }
    }
}
