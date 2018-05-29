using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OA.Data.Model;

namespace OA.Data
{
    public class ThuVienContext : DbContext
    {
        public ThuVienContext(DbContextOptions<ThuVienContext> options) : base(options)
        {
        }
        public DbSet<DocGia> DocGia { get; set; }
        public DbSet<LoaiDocGia> LoaiDocGia { get; set; }
        public DbSet<MuonTraSach> MuonTraSach { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<QuyDinhMuonSach> QuyDinhMuonSach { get; set; }
        public DbSet<QuyDinhDocGia> QuyDinhDocGia { get; set; }
        public DbSet<TheLoai> TheLoai { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DocGia>().ToTable(nameof(DocGia));
            builder.Entity<LoaiDocGia>().ToTable(nameof(LoaiDocGia));
            builder.Entity<MuonTraSach>().ToTable(nameof(MuonTraSach));
            builder.Entity<Sach>().ToTable(nameof(Sach));
            builder.Entity<QuyDinhMuonSach>().ToTable(nameof(QuyDinhMuonSach));
            builder.Entity<QuyDinhDocGia>().ToTable(nameof(QuyDinhDocGia));
            builder.Entity<TheLoai>().ToTable(nameof(TheLoai));
        }
    }
}
