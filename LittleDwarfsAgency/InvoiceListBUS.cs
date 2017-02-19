using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class InvoiceListBUS
    {
        private InvoiceListDAO _invoiceListDAO;
        public InvoiceListBUS()
        {
            _invoiceListDAO = new InvoiceListDAO();
        }
        
        public int getNextInvoiceListsId()
        {
            DataTable dataTable = new DataTable();
            List<InvoiceListVO> invoiceListsVOList = new List<InvoiceListVO>();

            dataTable = _invoiceListDAO.highestInvoiceId();

            foreach (DataRow dr in dataTable.Rows)
            {
                invoiceListsVOList.Add(new InvoiceListVO()
                {
                    Id = Int32.Parse(dr[0].ToString()),
                });
            }

            return Int32.Parse(invoiceListsVOList[0].Id.ToString());
        }

        public List<InvoiceListVO> getInvoiceListByInvoiceNumber(int invoice)
        {
            List<InvoiceListVO> invoiceListVOList = new List<InvoiceListVO>();
            DataTable dataTable = new DataTable();

            dataTable = _invoiceListDAO.searchInvoiceListByInvoiceNumber(invoice);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    invoiceListVOList.Add(new InvoiceListVO()
                    {
                        Id = Int32.Parse(dr[0].ToString()),
                        Invoice = Int32.Parse(dr[1].ToString()),
                        Weekending = Convert.ToDateTime(dr[2]),
                        Timesheet  = Int32.Parse(dr[3].ToString()),
                        HoursWorked = float.Parse(dr[4].ToString()),
                        Rate = float.Parse(dr[5].ToString()),
                        Cost = float.Parse(dr[6].ToString())
                    });
                }
                return invoiceListVOList;
            }
            else
            {
                return null;
            }
        }

        public void setTimesheetSummaryInInvoices(int id, int invoice, DateTime weekending, int timesheet, float hoursworked, float rate, float cost)
        {
            _invoiceListDAO.insertTimesheetSummaryIntoInvoiceLists(id, invoice, weekending, timesheet, hoursworked, rate, cost);
        }
    }
}