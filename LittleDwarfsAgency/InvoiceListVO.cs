using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class InvoiceListVO
    {
        private int _Id;
        private int _Invoice;
        private DateTime _Weekending;
        private int _Timesheet;
        private float _HoursWorked;
        private float _Rate;
        private float _Cost;

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
        public DateTime Weekending
        {
            get
            {
                return _Weekending;
            }
            set
            {
                _Weekending = value;
            }
        }
        public int Timesheet
        {
            get
            {
                return _Timesheet;
            }
            set
            {
                _Timesheet = value;
            }
        }
        public float HoursWorked
        {
            get
            {
                return _HoursWorked;
            }
            set
            {
                _HoursWorked = value;
            }
        }
        public float Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }

        public float Cost
        {
            get
            {
                return _Cost;
            }
            set
            {
                _Cost = value;
            }
        }
    }
}