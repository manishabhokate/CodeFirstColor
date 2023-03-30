using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstColor.Models
{
    public class Context:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors  { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
    }
}