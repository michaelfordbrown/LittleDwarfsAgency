using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace LittleDwarfsAgency
{
    public partial class XMLHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sendaer, EventArgs s)
        {

        }

        protected void DeleteAllData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlCommand cmd = new SqlCommand("ClearAllTablesProcedure", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DeleteStatus.Text = "All Tables Cleared";
            }
            catch (SqlException ex)
            {
                DeleteStatus.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void DeleteAllInvoiceData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ClearInvoicesTableProcedure", con);
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();

                con.Open();
                cmd = new SqlCommand("ClearInvoiceListsTableProcedure", con);
                dr = cmd.ExecuteReader();

                DeleteStatus.Text = "All Invoice Tables Cleared";
            }
            catch (SqlException ex)
            {
                DeleteStatus.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void DeleteAllTimesheetData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ClearTimesheetTableProcedure", con);
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();

                con.Open();
                cmd = new SqlCommand("ClearWorkPeriodTableProcedure", con);
                dr = cmd.ExecuteReader();

                DeleteStatus.Text = "All Timesheet Tables Cleared";
            }
            catch (SqlException ex)
            {
                DeleteStatus.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void CheckSizeofInvoiceData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select count(*) from Invoices", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Label2.Text = "Size of Invoices Table is: " + dr[0].ToString();
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Label2.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void CheckSizeofTimesheetData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("select count(*) from Timesheet", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Label2.Text = "Size of Timesheet Table is: " + dr[0].ToString();
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Label2.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        protected void CheckSizeofAllTables_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmdCheckTimesheet = new SqlCommand("select count(*) from Timesheet", con);
            SqlCommand cmdCheckInvoices = new SqlCommand("select count(*) from Invoices", con);

            string sizeOfTimesheet = "0";

            try
            {
                con.Open();

                SqlDataReader drCheckTimesheet = cmdCheckTimesheet.ExecuteReader();
                while (drCheckTimesheet.Read())
                {
                    sizeOfTimesheet = drCheckTimesheet[0].ToString();
                }
                drCheckTimesheet.Close();

                SqlDataReader drCheckInvoices = cmdCheckInvoices.ExecuteReader();
                while (drCheckInvoices.Read())
                {
                    Label2.Text = "Size of Invoices : " + drCheckInvoices[0].ToString() +
                        " Timesheet: " + sizeOfTimesheet;
                }
                drCheckInvoices.Close();

            }
            catch (SqlException ex)
            {
                Label2.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void SetWorkPeriodData(ref DataSet ds, ref SqlConnection con)
        {
            ds.ReadXml(Server.MapPath("~/App_Data/PeriodsWorked.xml"));
            DataTable dt = ds.Tables["WorkPeriod"];
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                bc.DestinationTableName = "WorkPeriod";
                bc.ColumnMappings.Add("Timesheet", "Timesheet");
                bc.ColumnMappings.Add("Date", "PeriodDate".Substring(0,10));
                bc.ColumnMappings.Add("AllocHours", "AllocHours");
                bc.ColumnMappings.Add("TimeIn", "TimeIn");
                bc.ColumnMappings.Add("TimeOut", "TimeExit");
                bc.ColumnMappings.Add("ActualService", "ActualService");
                bc.WriteToServer(dt);
            }
        }

        protected void SetTimesheetData(ref DataSet ds, ref SqlConnection con)
        {
            ds.ReadXml(Server.MapPath("~/App_Data/Timesheets.xml"));
            DataTable dt = ds.Tables["TimeSheet"];
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                bc.DestinationTableName = "Timesheet";
                bc.ColumnMappings.Add("TimesheetNumber", "Timesheet");
                bc.ColumnMappings.Add("Agency", "Agency");
                bc.ColumnMappings.Add("CareWorker", "CareWorker");
                bc.WriteToServer(dt);
            }
        }

        protected void SetInvoiceData(ref DataSet ds, ref SqlConnection con)
        {
            ds.ReadXml(Server.MapPath("~/App_Data/Invoices.xml"));
            DataTable dt = ds.Tables["Invoice"];
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                bc.DestinationTableName = "Invoices";
                bc.ColumnMappings.Add("InvoiceNo", "Invoice");
                bc.ColumnMappings.Add("AccountRef", "AccountRef");
                bc.ColumnMappings.Add("Date", "InvoiceDate");
                bc.WriteToServer(dt);
            }
        }


        protected void SetInvListData(ref DataSet ds, ref SqlConnection con)
        {
            ds.ReadXml(Server.MapPath("~/App_Data/InvoiceLists.xml"));
            DataTable dt = ds.Tables["InvList"];
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                bc.DestinationTableName = "[InvoiceLists]";
                bc.ColumnMappings.Add("Invoice", "Invoice");
                bc.ColumnMappings.Add("Weekending", "Weekending");
                bc.ColumnMappings.Add("Timesheet", "Timesheet");
                bc.ColumnMappings.Add("Hours", "HoursWorked");
                bc.ColumnMappings.Add("Rate", "Rate");
                bc.ColumnMappings.Add("Cost", "Cost");
                bc.WriteToServer(dt);
            }
        }

        protected void LoadAllDefaultData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            DataSet dsTimesheet = new DataSet();
            DataSet dsWorkPeriod = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsInvList = new DataSet();

            int TimesheetSize = 0;
            int InvoicesSize = 0;
            int InvoiceListsSize = 0;
            int WorkPeriodSize = 0;

            SqlCommand cmdCheckTimesheet = new SqlCommand("select count(*) from Timesheet", con);
            SqlCommand cmdCheckInvoices = new SqlCommand("select count(*) from Invoices", con);
            SqlCommand cmdCheckInvoiceLists = new SqlCommand("select count(*) from InvoiceLists", con);
            SqlCommand cmdCheckWorkPeriod = new SqlCommand("select count(*) from WorkPeriod", con);

            string sizeOfTimesheet = "0";
            string sizeOfInvoices = "0";
            string sizeOfInvoiceLists = "0";
            string sizeOfWorkPeriod = "0";

            try
            {
                con.Open();

                SqlDataReader drCheckTimesheet = cmdCheckTimesheet.ExecuteReader();
                while (drCheckTimesheet.Read())
                {
                    sizeOfTimesheet = drCheckTimesheet[0].ToString();
                    TimesheetSize = Convert.ToInt32(drCheckTimesheet[0].ToString());
                }
                drCheckTimesheet.Close();

                SqlDataReader drCheckInvoiceLists = cmdCheckInvoiceLists.ExecuteReader();
                while (drCheckInvoiceLists.Read())
                {
                    sizeOfInvoiceLists = drCheckInvoiceLists[0].ToString();
                    InvoiceListsSize = Convert.ToInt32(drCheckInvoiceLists[0].ToString());
                }
                drCheckInvoiceLists.Close();

                SqlDataReader drCheckWorkPeriod = cmdCheckWorkPeriod.ExecuteReader();
                while (drCheckWorkPeriod.Read())
                {
                    sizeOfWorkPeriod = drCheckWorkPeriod[0].ToString();
                    WorkPeriodSize = Convert.ToInt32(drCheckWorkPeriod[0].ToString());
                }
                drCheckWorkPeriod.Close();

                SqlDataReader drCheckInvoices = cmdCheckInvoices.ExecuteReader();
                while (drCheckInvoices.Read())
                {
                    InvoicesSize = Convert.ToInt32(drCheckInvoices[0].ToString());
                    Label2.Text = "Size of Invoices : " + drCheckInvoices[0].ToString() +
                                           " InvoiceLists : " + sizeOfInvoiceLists +
                                           " Timesheet: " + sizeOfTimesheet +
                                           " WorkPeriod: " + sizeOfWorkPeriod;
                }
                drCheckInvoices.Close();

                if ((TimesheetSize == 0) && (InvoicesSize == 0))
                {

                    SetWorkPeriodData(ref dsWorkPeriod, ref con);
                    SetTimesheetData(ref dsTimesheet, ref con);
                    SetInvoiceData(ref dsInvoice, ref con);
                    SetInvListData(ref dsInvList, ref con);

                    Label1.Text = "All Tables Loaded With Default Data";
                }
                else
                {
                    Label1.Text = "Database NOT Empty! Invoices has " + InvoicesSize + " records and Timesheet has records " + TimesheetSize;
                }

                drCheckInvoices.Close();
                drCheckTimesheet.Close();
            }
            catch (SqlException ex)
            {
                Label1.Text = "Exception Error! " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void LoadTimesheetTables_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand sqlcmd4 = new SqlCommand("select * from Timesheet", con);

            SqlDataAdapter sda4 = new SqlDataAdapter();
            sda4.SelectCommand = sqlcmd4;

            DataTable dt4 = new DataTable();
            dt4.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda4.Fill(dt4);
            GridView4.DataSource = dt4;
            GridView4.DataBind();

            SqlCommand sqlcmd7 = new SqlCommand("select * from WorkPeriod", con);

            SqlDataAdapter sda7 = new SqlDataAdapter();
            sda7.SelectCommand = sqlcmd7;

            DataTable dt7 = new DataTable();
            dt7.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda7.Fill(dt7);
            GridView7.DataSource = dt7;
            GridView7.DataBind();
        }


        protected void LoadInvoiceTables_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand sqlcmd1 = new SqlCommand("select * from Invoices", con);

            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = sqlcmd1;

            DataTable dt1 = new DataTable();
            dt1.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            SqlCommand sqlcmd3 = new SqlCommand("select * from InvoiceLists", con);

            SqlDataAdapter sda3 = new SqlDataAdapter();
            sda3.SelectCommand = sqlcmd3;

            DataTable dt3 = new DataTable();
            dt3.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda3.Fill(dt3);
            GridView3.DataSource = dt3;
            GridView3.DataBind();
        }

        protected void LoadAllViews_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["AZ"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand sqlcmd2 = new SqlCommand("select * from DailyCharges", con);

            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = sqlcmd2;

            DataTable dt2 = new DataTable();
            dt2.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda2.Fill(dt2);
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            SqlCommand sqlcmd5 = new SqlCommand("select * from DailyRates", con);

            SqlDataAdapter sda5 = new SqlDataAdapter();
            sda5.SelectCommand = sqlcmd5;

            DataTable dt5 = new DataTable();
            dt5.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda5.Fill(dt5);
            GridView5.DataSource = dt5;
            GridView5.DataBind();

            SqlCommand sqlcmd6 = new SqlCommand("select * from PeriodRates", con);

            SqlDataAdapter sda6 = new SqlDataAdapter();
            sda6.SelectCommand = sqlcmd6;

            DataTable dt6 = new DataTable();
            dt6.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda6.Fill(dt6);
            GridView6.DataSource = dt6;
            GridView6.DataBind();
        }
    }
}



