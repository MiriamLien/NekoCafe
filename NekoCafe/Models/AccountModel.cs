using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class AccountModel
    {
        public int AccountID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}