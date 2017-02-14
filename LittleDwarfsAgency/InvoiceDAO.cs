﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class InvoiceDAO
    {
        private dbConnection conn;

        // <constructor>
        // Constructor UserDAO
        // <.constructor>
        public InvoiceDAO()
        {
            conn = new dbConnection();
        }

        // <method>
        // Get Invoice By Invoice Number and return DataTable
        // </method>
        public DataTable searchInvoicesByInvoiceNumber(int _invoice)
        {
            string _table = "Invoices";
            string _field = "Invoice";
            
            string query = string.Format("select * from {0} where {1} like @t01_invoice", _table, _field);
            //string query = string.Format("select * from [t01_user]  where t01_invoice like @t01_invoice");

            //SqlParameter - Represents a parameter to a SqlCommand and optionally its mapping to DataSet columns.
            //SqlParameter(String, SqlDbType) - Initializes a new instance of the SqlParameter class that uses the parameter name and the data type.
            //SqlParameter Name - "@t01_invoice"
            //SqlDbType  - Int (Specifies SQL Server-specific data type of a field, property, for use in a SqlParameter.)
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@t01_invoice", SqlDbType.Int);
            // sqlParameter.Value - Gets or sets the value of the parameter.
            sqlParameter[0].Value = _invoice;
            return conn.executeSelectQuery(query, sqlParameter);

        }

        public void insertInvoiceIntoInvoices(int _Id, int _Invoice, string _AccountRef, DateTime _InvoiceDate)
        {
            string _table = "Invoices";

            string query = string.Format("insert into {0} (Id, Invoice, AccountRef,InvoiceDate) values(@t01_id, @t01_invoice, @t01_accountref, @t01_invoicedate)", _table);

            SqlParameter[] sqlParameter = new SqlParameter[4];

            sqlParameter[0] = new SqlParameter("@t01_id", SqlDbType.Int);
            sqlParameter[0].Value = _Id;

            sqlParameter[1] = new SqlParameter("@t01_invoice", SqlDbType.Int);
            sqlParameter[1].Value = _Invoice;

            sqlParameter[2] = new SqlParameter("@t01_accountref", SqlDbType.Text);
            sqlParameter[2].Value = _AccountRef;

            sqlParameter[3] = new SqlParameter("@t01_invoicedate", SqlDbType.Date);
            sqlParameter[3].Value = _InvoiceDate;

            conn.executeInsertQuery(query, sqlParameter);
        }
    }
}