namespace NekoCafe.CatCafe.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bulletin")]
    public partial class Bulletin
    {
        public int BulletinID { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int? PicID { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
