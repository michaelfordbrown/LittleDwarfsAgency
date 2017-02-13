using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{

    public class InvoiceVO
    {
        private int _Id;
        private int _Invoice;
        private string _AccountRef;
        private DateTime _InvoiceDate;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }
        public int Invoice
        {
            get
            {
                return _Invoice;
            }

            set
            {
                _Invoice = value;
            }
        }
        public string AccountRef
        {
            get
            {
                return _AccountRef;
            }

            set
            {
                _AccountRef = value;
            }
        }
        public DateTime InvoiceDate
        {
            get
            {
                return _InvoiceDate;
            }

            set
            {
                _InvoiceDate = value;
            }
        }

    }

}