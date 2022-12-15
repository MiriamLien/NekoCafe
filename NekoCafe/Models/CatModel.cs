using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class CatModel
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public string Sex { get; set; }
        public DateTime Birth { get; set; }
        public string strBirth { get; set; }
        public string Contents { get; set; }
        public int CatBreedID { get; set; }
    }
}