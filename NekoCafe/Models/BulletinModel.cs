using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Models
{
    public class BulletinModel
    {
        public int BulletinID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? PicID { get; set; }
    }
}