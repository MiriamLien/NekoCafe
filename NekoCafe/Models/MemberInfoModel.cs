using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class MemberInfoModel
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int? Level { get; set; }
    }
}