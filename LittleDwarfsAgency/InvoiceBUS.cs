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

        public List<InvoiceVO> getInvoiceByInvoiceNumber (int invoice)
        {
            List<InvoiceVO> invoiceVOList  = new List<InvoiceVO>();
            DataTable dataTable = new DataTable();

            dataTable = _invoiceDAO.searchInvoicesByInvoiceNumber(invoice);

            if (dataTable.Rows.Count > 0){
                foreach (DataRow dr in dataTable.Rows)
                {
                    invoiceVOList.Add(new InvoiceVO()
                    {
                        Id = Int32.Parse(dr[0].ToString()),
                        Invoice = Int32.Parse(dr[1].ToString()),
                        AccountRef = dr[2].ToString(),
                        InvoiceDate = Convert.ToDateTime(dr[3])
                    });
                }
                return invoiceVOList;
            }
            else
            {
                return null;
            }
        }

        
    }
}