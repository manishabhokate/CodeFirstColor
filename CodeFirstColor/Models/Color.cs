using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstColor.Models
{
    [Table("ColorTbl")]
    public class Color
    {
        [Key]
        public Int64 ColorId { get; set; }
        public string ColorName { get; set; }
        public virtual List<ProductColor> ProductColors  { get; set; }
    }
}