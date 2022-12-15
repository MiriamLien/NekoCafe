using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NekoCafe.CatCafe.ORM
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ContextModel1")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<CatBreed> CatBreeds { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<CatState> CatStates { get; set; }
        public virtual DbSet<ItemClass> ItemClasses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MemberInfo> MemberInfos { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Welfare> Welfares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Account1)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.MemberInfo)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<CatBreed>()
                .HasMany(e => e.Cats)
                .WithRequired(e => e.CatBreed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cat>()
                .HasMany(e => e.CatStates)
                .WithRequired(e => e.Cat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemClass>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.ItemClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasOptional(e => e.Reservation)
                .WithRequired(e => e.Order);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.Note)
                .IsUnicode(false);
        }
    }
}
