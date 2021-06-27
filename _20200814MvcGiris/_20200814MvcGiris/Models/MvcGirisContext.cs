namespace _20200814MvcGiris.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MvcGirisContext : DbContext
    {
        public MvcGirisContext()
            : base("name=MvcGirisContext")
        {
        }

        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
