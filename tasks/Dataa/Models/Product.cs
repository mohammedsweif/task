﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskDate.Models
{
  public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProName { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal Unitprice { get; set; }
        public List<Invoice> invoices { get; set; }
    }
}
