using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int ItemClassID { get; set; }
        public int Price { get; set; }
    }
}