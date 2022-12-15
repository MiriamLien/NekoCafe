using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class MRModel
    {
        public int AccountID { get; set; }
        public int OrderID { get; set; }
        public DateTime Time { get; set; }
        public int NPR { get; set; }
        public int Spending { get; set; }
    }
}