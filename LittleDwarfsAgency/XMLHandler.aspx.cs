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
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
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


        protected void CheckSizeofInvoiceData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
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
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
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
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
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
                bc.ColumnMappings.Add("Id", "Id");
                bc.ColumnMappings.Add("Timesheet", "Timesheet");
                bc.ColumnMappings.Add("Date", "PeriodDate");
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
                bc.ColumnMappings.Add("Id", "Id");
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
                bc.ColumnMappings.Add("Id", "Id");
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
                bc.ColumnMappings.Add("Id", "Id");
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
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            DataSet dsTimesheet = new DataSet();
            DataSet dsWorkPeriod = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsInvList = new DataSet();

            int TimesheetSize = 0;
            int InvoicesSize = 0;

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
                    TimesheetSize = Convert.ToInt32(drCheckTimesheet[0].ToString());
                }
                drCheckTimesheet.Close();

                SqlDataReader drCheckInvoices = cmdCheckInvoices.ExecuteReader();
                while (drCheckInvoices.Read())
                {
                    InvoicesSize = Convert.ToInt32(drCheckInvoices[0].ToString());
                    Label2.Text = "Size of Invoices : " + drCheckInvoices[0].ToString() +
                        " Timesheet: " + sizeOfTimesheet;
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

        protected void LoadInvoiceTable_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand sqlcmd = new SqlCommand("select * from Invoices", con);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void LoadDailyChargesView_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DA"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand sqlcmd = new SqlCommand("select * from DailyCharges", con);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InstalledUICulture;

            sda.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
}



