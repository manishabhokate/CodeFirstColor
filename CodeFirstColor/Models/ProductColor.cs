using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstColor.Models
{
    [Table("ProductColorTbl")]
    public class ProductColor
    {
        [Key]
        public Int64 ProductColorId { get; set; }
        [ForeignKey("Product")]
        public Int64 ProductId { get; set; }
        [ForeignKey("Color")]
        public Int64 ColorId { get; set; }
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
    }
}