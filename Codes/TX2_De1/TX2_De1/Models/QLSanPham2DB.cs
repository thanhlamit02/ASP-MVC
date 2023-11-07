using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TX2_De1.Models
{
    public partial class QLSanPham2DB : DbContext
    {
        public QLSanPham2DB()
            : base("name=QLSanPham2DB")
        {
        }

        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Trangsuc> Trangsucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Danhmuc>()
                .Property(e => e.Mota)
                .IsUnicode(false);

            modelBuilder.Entity<Danhmuc>()
                .HasMany(e => e.Trangsucs)
                .WithRequired(e => e.Danhmuc)
                .WillCascadeOnDelete(false);
        }
    }
}
