namespace NekoCafe.CatCafe.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cat()
        {
            CatStates = new HashSet<CatState>();
        }

        public int CatID { get; set; }

        [Required]
        [StringLength(50)]
        public string CatName { get; set; }

        [Required]
        [StringLength(10)]
        public string Sex { get; set; }

        public DateTime Birth { get; set; }

        [Required]
        [StringLength(100)]
        public string Contents { get; set; }

        public int CatBreedID { get; set; }

        public virtual CatBreed CatBreed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatState> CatStates { get; set; }
    }
}
