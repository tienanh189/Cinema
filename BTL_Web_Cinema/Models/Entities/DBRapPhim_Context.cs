using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_Web_Cinema.Models.Entities
{
    public partial class DBRapPhim_Context : DbContext
    {
        public DBRapPhim_Context()
            : base("name=DBRapPhim_Context2")
        {
        }

        public virtual DbSet<CaChieu> CaChieux { get; set; }
        public virtual DbSet<LichChieu> LichChieux { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<PhongChieu> PhongChieux { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaChieu>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.CaChieu1)
                .HasForeignKey(e => e.CaChieu);

            modelBuilder.Entity<LichChieu>()
                .Property(e => e.TienVe)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Phim>()
                .Property(e => e.GiaNhapPhim)
                .HasPrecision(19, 4);
        }
    }
}
