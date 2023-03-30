using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstColor.Models
{
    public class CheckBoxVm
    {
        public Int64 Value { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}