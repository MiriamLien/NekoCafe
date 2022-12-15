using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int? AccountID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int NPR { get; set; }
    }
}