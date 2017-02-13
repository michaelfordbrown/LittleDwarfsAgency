using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LittleDwarfsAgency
{

    public partial class GetInvoice : System.Web.UI.Page
    {

        private InvoiceBUS _invoiceBUS;

        public GetInvoice()
        {
            InitializeComponent();
            _invoiceBUS = new InvoiceBUS();
        }
        private void InitializeComponent()
        {
            /*this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);//your got a button
            this.Load += new System.EventHandler(this.Page_Load);*/
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int rowCnt = 0;
            int rowCtr = 0;
            int cellCtr = 0;
            int cellCnt = 0;

            InvoiceVO _invoiceVO = new InvoiceVO();
            _invoiceVO = _invoiceBUS.getInvoiceByInvoiceNumber(Convert.ToInt32(txtInvoice.Text));
            if (_invoiceVO == null)
            {
                Console.Write("Invoice Not Found");
            }
            else
            {
                Console.Write("Invoice Found");

                rowCnt = 1;
                for(rowCtr=0; rowCtr < rowCnt; rowCtr++ )
                {
                    TableRow tRow = new TableRow();
                    tabInvoice.Rows.Add(tRow);

                    TableCell tCell1 = new TableCell();
                    tCell1.Text = _invoiceVO.Id.ToString();
                    tRow.Cells.Add(tCell1);

                    TableCell tCell2 = new TableCell();
                    tCell2.Text = _invoiceVO.Invoice.ToString();
                    tRow.Cells.Add(tCell2);

                    TableCell tCell3 = new TableCell();
                    tCell3.Text = _invoiceVO.AccountRef;
                    tRow.Cells.Add(tCell3);

                    TableCell tCell4 = new TableCell();
                    tCell4.Text = _invoiceVO.InvoiceDate.ToString();
                    tRow.Cells.Add(tCell4);

                }

            }
        }

        protected void btnCancel_click(object sender, EventArgs e)
        {
            //Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}