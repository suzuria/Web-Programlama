namespace _MvcResimEkleme.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MvcContext : DbContext
    {
        public MvcContext()
            : base("name=MvcContext")
        {
        }

        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birim>()
                .HasMany(e => e.Birim1)
                .WithOptional(e => e.Birim2)
                .HasForeignKey(e => e.ustID);
        }
    }
}
