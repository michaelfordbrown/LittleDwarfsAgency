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
        private InvoiceListBUS _invoiceListBUS;

        public GetInvoice()
        {
            InitializeComponent();
            _invoiceBUS = new InvoiceBUS();
            _invoiceListBUS = new InvoiceListBUS();
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

            List<InvoiceVO> _invoiceVOList = new List<InvoiceVO>();
            _invoiceVOList = _invoiceBUS.getInvoiceByInvoiceNumber(Convert.ToInt32(txtInvoice.Text));
            if (_invoiceVOList == null)
            {
                footerTabInvoice.Text = "Invoice Not Found";
            }
            else
            {
                footerTabInvoice.Text = "Invoice Found";
                //                rowCnt = _invoiceVOList.Count();
                rowCnt = 1;

                for (rowCtr=0; rowCtr < rowCnt; rowCtr++ )
                {
                    TableRow tRow = new TableRow();
                    tabInvoice.Rows.Add(tRow);

                    TableCell tCell1 = new TableCell();
                    tCell1.Text = _invoiceVOList[rowCtr].Invoice.ToString();
                    tRow.Cells.Add(tCell1);

                    TableCell tCell2 = new TableCell();
                    tCell2.Text = _invoiceVOList[rowCtr].AccountRef;
                    tRow.Cells.Add(tCell2);

                    TableCell tCell3 = new TableCell();
                    tCell3.Text = _invoiceVOList[rowCtr].InvoiceDate.ToString().Substring(0,10);
                    tRow.Cells.Add(tCell3);

                }
            }

            List<InvoiceListVO> _invoiceListVOList = new List<InvoiceListVO>();
            _invoiceListVOList = _invoiceListBUS.getInvoiceListByInvoiceNumber(Convert.ToInt32(txtInvoice.Text));
            if (_invoiceListVOList == null)
            {

            }
            else
            {

                rowCnt = _invoiceListVOList.Count();
                for (rowCtr = 0; rowCtr < rowCnt; rowCtr++)
                {
                    TableRow tRow = new TableRow();
                    tabInvoiceList.Rows.Add(tRow);

                    TableCell tCell1 = new TableCell();
                    tCell1.Text = _invoiceListVOList[rowCtr].Weekending.ToString().Substring(0,10);
                    tRow.Cells.Add(tCell1);

                    TableCell tCell2 = new TableCell();
                    tCell2.Text = _invoiceListVOList[rowCtr].Timesheet.ToString();
                    tRow.Cells.Add(tCell2);

                    TableCell tCell3 = new TableCell();
                    tCell3.Text = _invoiceListVOList[rowCtr].HoursWorked.ToString();
                    tRow.Cells.Add(tCell3);

                    TableCell tCell4 = new TableCell();
                    tCell4.Text = _invoiceListVOList[rowCtr].Rate.ToString();
                    tRow.Cells.Add(tCell4);

                    TableCell tCell5 = new TableCell();
                    tCell5.Text = _invoiceListVOList[rowCtr].Cost.ToString();
                    tRow.Cells.Add(tCell5);
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