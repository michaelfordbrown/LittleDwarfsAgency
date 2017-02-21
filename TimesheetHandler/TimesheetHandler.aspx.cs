using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimesheetHandler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                Timesheet timesheet = new Timesheet
                {
                    Agency = "Little Dwarf",
                    CareWorker = "Mike",
                    Timesheet1 = 87654321
                };

                context.Timesheets.Add(timesheet);
                context.SaveChanges();
            }
        }
    }
}