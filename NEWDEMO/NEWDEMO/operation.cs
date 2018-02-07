using NEWDEMO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NEWDEMO
{

    public class operation : IModificationHistory
    {
        public operation()
        {
            List<operation> oper = new List<operation>();
        }
        public int Id { get; set; }

        public string vendorName { get; set; }
        public int invoiceNB { get; set; }
        public int siteNB { get; set; }
        public System.DateTime scanDate { get; set; }
        public decimal paymentDueDate { get; set; }
        public int voucherNB { get; set; }
        public int bankNB { get; set; }

       public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }

}