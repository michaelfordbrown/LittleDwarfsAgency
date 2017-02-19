using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class InvoiceListDAO
    {
        private dbConnection conn;

        public InvoiceListDAO()
        {
            conn = new dbConnection();
        }

        public DataTable highestInvoiceId()
        {
            string _table = "InvoiceLists";
            string _field = "Id";
            DataTable dt = new DataTable();

            string query = string.Format("select max({0}) from {1}", _field, _table);

            SqlParameter[] sqlParameter = new SqlParameter[1];

            sqlParameter[0] = new SqlParameter("@t01_id", SqlDbType.Int);
            sqlParameter[0].Value = 0;

            return conn.executeSelectQuery(query, sqlParameter);

        }

        public DataTable searchInvoiceListByInvoiceNumber(int invoice)
        {
            string _table = "InvoiceLists";
            string _field = "Invoice";

            string _query = string.Format("select * from {0} where {1} like @t01_invoice", _table, _field);

            SqlParameter[] _sqlParameter = new SqlParameter[1];
            _sqlParameter[0] = new SqlParameter("@t01_invoice", SqlDbType.Int);
            _sqlParameter[0].Value = invoice;

            return conn.executeSelectQuery(_query, _sqlParameter);
        }

        public void insertTimesheetSummaryIntoInvoiceLists(int id, int invoice, DateTime weekending, int timesheet, float hoursworked, float rate, float cost)
        {
            string _table = "InvoiceLists";

            string _query = string.Format("insert into {0} (Id, Invoice, Weekending, Timesheet, HoursWorked, Rate, Cost) values(@t01_id, @t01_invoice, @t01_weekending, @t01_timesheet, @t01_hoursworked, @t01_rate, @t01_cost)", _table);

            SqlParameter[] _sqlParameter = new SqlParameter[7];

            _sqlParameter[0] = new SqlParameter("@t01_id", SqlDbType.Int);
            _sqlParameter[0].Value = id;

            _sqlParameter[1] = new SqlParameter("@t01_invoice", SqlDbType.Int);
            _sqlParameter[1].Value = invoice;

            _sqlParameter[2] = new SqlParameter("@t01_weekending", SqlDbType.Date);
            _sqlParameter[2].Value = weekending;

            _sqlParameter[3] = new SqlParameter("@t01_timesheet", SqlDbType.Int);
            _sqlParameter[3].Value = timesheet;

            _sqlParameter[4] = new SqlParameter("@t01_hoursworked", SqlDbType.Float);
            _sqlParameter[4].Value = hoursworked;

            _sqlParameter[5] = new SqlParameter("@t01_rate", SqlDbType.Float);
            _sqlParameter[5].Value = rate;

            _sqlParameter[6] = new SqlParameter("@t01_cost", SqlDbType.Float);
            _sqlParameter[6].Value = cost;

            conn.executeInsertQuery(_query, _sqlParameter);
        }
    }
}