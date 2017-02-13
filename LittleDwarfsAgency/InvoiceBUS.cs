using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class InvoiceBUS
    {
        private InvoiceDAO _invoiceDAO;

        public InvoiceBUS()
        {
            _invoiceDAO = new InvoiceDAO();
        }

        public InvoiceVO getInvoiceByInvoiceNumber (int invoice)
        {
            InvoiceVO invoiceVO  = new InvoiceVO();
            DataTable dataTable = new DataTable();

            dataTable = _invoiceDAO.searchByInvoiceNumber(invoice);

            if (dataTable.Rows.Count > 0){
                foreach (DataRow dr in dataTable.Rows)
                {
                    Console.Write("SQL Search Found!");
                    invoiceVO.Id = Int32.Parse(dr[0].ToString());
                    invoiceVO.Invoice = Int32.Parse(dr[1].ToString());
                    invoiceVO.AccountRef = dr[2].ToString();
                    invoiceVO.InvoiceDate = Convert.ToDateTime(dr[3]);
                }
                return invoiceVO;
            }
            else
            {
                Console.Write("SQL Search NULL!");
                return null;
            }
            

        }
    }
}