﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OA.Data;
using System;

namespace OA.Data.Migrations
{
    [DbContext(typeof(ThuVienContext))]
    partial class ThuVienContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OA.Data.Model.DocGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiaChi");

                    b.Property<string>("Email");

                    b.Property<string>("HoTen");

                    b.Property<int>("LoaiDocGiaId");

                    b.Property<DateTime>("NgayHetHan");

                    b.Property<DateTime>("NgayLapThe");

                    b.Property<DateTime>("NgaySinh");

                    b.Property<int>("SoSachDangMuon");

                    b.HasKey("Id");

                    b.HasIndex("LoaiDocGiaId");

                    b.ToTable("DocGia");
                });

            modelBuilder.Entity("OA.Data.Model.LoaiDocGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenLoaiDocGia");

                    b.HasKey("Id");

                    b.ToTable("LoaiDocGia");
                });

            modelBuilder.Entity("OA.Data.Model.MuonTraSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DocGiaId");

                    b.Property<DateTime>("NgayMuon");

                    b.Property<DateTime?>("NgayTra");

                    b.Property<int>("SachId");

                    b.Property<decimal?>("TienPhat");

                    b.HasKey("Id");

                    b.HasIndex("DocGiaId");

                    b.HasIndex("SachId");

                    b.ToTable("MuonTraSach");
                });

            modelBuilder.Entity("OA.Data.Model.QuyDinhDocGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ThoiHanThe");

                    b.Property<int>("TuoiToiDa");

                    b.Property<int>("TuoiToiThieu");

                    b.HasKey("Id");

                    b.ToTable("QuyDinhDocGia");
                });

            modelBuilder.Entity("OA.Data.Model.QuyDinhMuonSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SoNgayMuonToiDa");

                    b.Property<int>("SoSachMuonToiDa");

                    b.HasKey("Id");

                    b.ToTable("QuyDinhMuonSach");
                });

            modelBuilder.Entity("OA.Data.Model.Sach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NamXuatBan");

                    b.Property<DateTime>("NgayNhapSach");

                    b.Property<string>("NhaXuatBan");

                    b.Property<string>("TacGia");

                    b.Property<string>("Tensach");

                    b.Property<int>("TheLoaiId");

                    b.Property<bool?>("TinhTrang");

                    b.HasKey("Id");

                    b.HasIndex("TheLoaiId");

                    b.ToTable("Sach");
                });

            modelBuilder.Entity("OA.Data.Model.TheLoai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenTheLoai");

                    b.HasKey("Id");

                    b.ToTable("TheLoai");
                });

            modelBuilder.Entity("OA.Data.Model.DocGia", b =>
                {
                    b.HasOne("OA.Data.Model.LoaiDocGia", "LoaiDocGia")
                        .WithMany("DocGias")
                        .HasForeignKey("LoaiDocGiaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OA.Data.Model.MuonTraSach", b =>
                {
                    b.HasOne("OA.Data.Model.DocGia", "DocGia")
                        .WithMany("MuonTraSachs")
                        .HasForeignKey("DocGiaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OA.Data.Model.Sach", "Sach")
                        .WithMany("MuonTraSachs")
                        .HasForeignKey("SachId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OA.Data.Model.Sach", b =>
                {
                    b.HasOne("OA.Data.Model.TheLoai", "TheLoai")
                        .WithMany()
                        .HasForeignKey("TheLoaiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
