using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class CatStateModel
    {
        public int CatStateID { get; set; }
        public int CatID { get; set; }
        public DateTime Date { get; set; }
        public bool Work { get; set; }
    }
}