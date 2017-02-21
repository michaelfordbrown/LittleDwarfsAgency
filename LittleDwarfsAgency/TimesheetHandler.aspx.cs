using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LittleDwarfsAgency
{
    public partial class TimesheetHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                //Append New Record

                Timesheet appendTimesheet = new Timesheet
                {
                    Agency = "Little Giant",
                    CareWorker = "Mike",
                    Timesheet1 = 87654322
                };
                context.Timesheets.Add(appendTimesheet);
                context.SaveChanges();

                for (int i = 1; i < 10; i++)
                {
                    appendTimesheet.Agency = "Little Giant";
                    appendTimesheet.CareWorker = "Mike";
                    appendTimesheet.Timesheet1 = 87654322 + i;
                    context.Timesheets.Add(appendTimesheet);
                    context.SaveChanges();
                }



                //Select A Record
                Timesheet selectTimesheet = context.Timesheets.FirstOrDefault(t => t.CareWorker == "Mike");

                //Remove A Record
                //Timesheet removeTimesheet = context.Timesheets.FirstOrDefault(t => t.CareWorker == "Mike");
                //context.Timesheets.Remove(removeTimesheet);
                //context.SaveChanges();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int rowCnt = 0;
            int rowCtr = 0;
            int cellCtr = 0;
            int cellCnt = 0;

            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                int timesheet = Int32.Parse(txtTimesheet.Text);

                Timesheet selectTimesheet = context.Timesheets.FirstOrDefault(t => t.Timesheet1 == timesheet);

                if (selectTimesheet == null)
                {
                    footerTabTimesheet.Text = "Timesheet Not Found";
                }
                else
                {
                    footerTabTimesheet.Text = "Timesheet Found";
                    rowCnt = 1;

                    for (rowCtr = 0; rowCtr < rowCnt; rowCtr++)
                    {
                        TableRow tRow = new TableRow();
                        tabTimesheet.Rows.Add(tRow);

                        TableCell tCell1 = new TableCell();
                        tCell1.Text = selectTimesheet.Timesheet1.ToString();
                        tRow.Cells.Add(tCell1);

                        TableCell tCell2 = new TableCell();
                        tCell2.Text = selectTimesheet.Agency;
                        tRow.Cells.Add(tCell2);

                        TableCell tCell3 = new TableCell();
                        tCell3.Text = selectTimesheet.CareWorker;
                        tRow.Cells.Add(tCell3);

                    }
                }

                List<WorkPeriod> selectWorkPeriodList = new List<WorkPeriod>();

                var selectWorkPeriods = context.WorkPeriods.Where(w => w.Timesheet == timesheet);

                if (selectWorkPeriods.Count() > 0)
                {
                    foreach (var r in selectWorkPeriods)
                    {
                        TableRow tRow = new TableRow();
                        tabWorkPeriod.Rows.Add(tRow);

                        TableCell tCell1 = new TableCell();
                        tCell1.Text = r.PeriodDate.ToString().Substring(0, 10);
                        tRow.Cells.Add(tCell1);

                        TableCell tCell2 = new TableCell();
                        tCell2.Text = r.AllocHours.ToString();
                        tRow.Cells.Add(tCell2);

                        TableCell tCell3 = new TableCell();
                        tCell3.Text = r.TimeIn.ToString();
                        tRow.Cells.Add(tCell3);

                        TableCell tCell4 = new TableCell();
                        tCell4.Text = r.TimeExit.ToString();
                        tRow.Cells.Add(tCell4);

                        TableCell tCell5 = new TableCell();
                        tCell5.Text = r.ActualService;
                        tRow.Cells.Add(tCell5);
                    }

                }

            }

        }

        protected void btnSubTimesheet_Click(object sender, EventArgs e)
        {
            
            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                //Append New Record

                Timesheet appendTimesheet = new Timesheet
                {
                    Timesheet1 = Int32.Parse(TextBox1.Text),
                    Agency = TextBox2.Text,
                    CareWorker = TextBox3.Text
                };
                context.Timesheets.Add(appendTimesheet);
                context.SaveChanges();
            }
            
        }

        protected void btnSubWorkPeriod_Click(object sender, EventArgs e)
        {
            
            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                //Append New Record

                WorkPeriod appendWorkPeriod = new WorkPeriod
                {
                    Timesheet = Int32.Parse(txtTimesheetSub.Text),
                    PeriodDate = DateTime.Parse(txtPeriodDateSub.Text),
                    AllocHours = float.Parse(txtAllocHoursSub.Text),
                    TimeIn = TimeSpan.Parse(txtTimeIn.Text),
                    TimeExit = TimeSpan.Parse(txtTimeExit.Text),
                    ActualService = txtActualService.Text
                };
                context.WorkPeriods.Add(appendWorkPeriod);
                context.SaveChanges();
            }
            
        }

        protected void btnSubTimesheetDelete_Click(object sender, EventArgs e)
        {
            
            using (LittleDwarfAgencyEntities context = new LittleDwarfAgencyEntities())
            {
                //Remove A Record

                Timesheet removeTimesheet = new Timesheet();
                {
                    removeTimesheet = context.Timesheets.FirstOrDefault(t => t.Timesheet1 == Int32.Parse(txtTimesheetDelSub.Text));
                    context.Timesheets.Remove(removeTimesheet);
                    context.SaveChanges();
                }
            }
            
        }

        protected void txtAllocHoursSub_TextChanged(object sender, EventArgs e)
        {

        }
    }
}