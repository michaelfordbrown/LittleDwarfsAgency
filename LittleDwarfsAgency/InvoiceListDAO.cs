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

        public DataTable searchInvoiceListByInvoiceNumber(int _invoice)
        {
            string _table = "InvoiceLists";
            string _field = "Invoice";

            string query = string.Format("select * from {0} where {1} like @t01_invoice", _table, _field);

            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@t01_invoice", SqlDbType.Int);
            sqlParameter[0].Value = _invoice;

            return conn.executeSelectQuery(query, sqlParameter);
        }
    }
}