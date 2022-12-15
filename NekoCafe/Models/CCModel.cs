using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class CCModel
    {
        public int CatStateID { get; set; }
        public int CatID { get; set; }
        public string CatName { get; set; }
        public string Sex { get; set; }
        public string Breed { get; set; }
        public DateTime Birth { get; set; }
        public string strBirth { get; set; }
        public string Contents { get; set; }
        public DateTime Date { get; set; }
        public bool Work { get; set; }

    }
}