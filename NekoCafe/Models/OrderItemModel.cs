using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class OrderItemModel
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}