namespace NekoCafe.CatCafe.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CatState
    {
        public int CatStateID { get; set; }

        public int CatID { get; set; }

        public DateTime Date { get; set; }

        public bool Work { get; set; }

        public virtual Cat Cat { get; set; }
    }
}
