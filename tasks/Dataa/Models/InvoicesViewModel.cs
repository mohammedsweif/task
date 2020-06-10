using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
   public class InvoicesViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
        public decimal unitprise { get; set; }
        public string description { get; set; }


    }
}
