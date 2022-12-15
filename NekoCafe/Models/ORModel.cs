using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class ORModel
    {
        public int OrderID { get; set; }
        public int? AccountID { get; set; }
        public DateTime Date_Time { get; set; }
        public int NPR { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }

    }
}