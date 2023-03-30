using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstColor.Models
{
    [Table("ProductTbl")]
    public class Product
    {
        [Key]
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public string MfgName { get; set; }
        public double Price { get; set; }
        public virtual List<ProductColor> ProductColors { get; set; }
    }
}