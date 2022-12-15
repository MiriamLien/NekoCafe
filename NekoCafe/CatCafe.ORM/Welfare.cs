namespace NekoCafe.CatCafe.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Welfare")]
    public partial class Welfare
    {
        [Key]
        [Column("Welfare")]
        public int Welfare1 { get; set; }

        public int Level { get; set; }

        public int Discount { get; set; }
    }
}
