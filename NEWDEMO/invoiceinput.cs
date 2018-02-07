using NEWDEMO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWDEMO
{
    public class invoiceinput:IModificationHistory
    {
        public invoiceinput()
        {
         List<invoiceinput>   invoicein = new List<invoiceinput>();
        }
        public int Id { get; set; }
        public System.DateTime fromdate { get; set; }
        [Required]
        public operation op { get; set; }
        public System.DateTime todate { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

    }
}
