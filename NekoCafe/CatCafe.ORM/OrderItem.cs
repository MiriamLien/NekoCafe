namespace NekoCafe.CatCafe.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }

        public int ItemID { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }
    }
}
