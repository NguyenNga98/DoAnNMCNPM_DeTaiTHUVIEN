using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OA.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiDocGia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoaiDocGia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDocGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyDinhDocGia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThoiHanThe = table.Column<int>(nullable: false),
                    TuoiToiDa = table.Column<int>(nullable: false),
                    TuoiToiThieu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDinhDocGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyDinhMuonSach",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SoNgayMuonToiDa = table.Column<int>(nullable: false),
                    SoSachMuonToiDa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDinhMuonSach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenTheLoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocGia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    LoaiDocGiaId = table.Column<int>(nullable: false),
                    NgayHetHan = table.Column<DateTime>(nullable: false),
                    NgayLapThe = table.Column<DateTime>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocGia_LoaiDocGia_LoaiDocGiaId",
                        column: x => x.LoaiDocGiaId,
                        principalTable: "LoaiDocGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamXuatBan = table.Column<int>(nullable: false),
                    NgayNhapSach = table.Column<DateTime>(nullable: false),
                    NhaXuatBan = table.Column<string>(nullable: true),
                    TacGia = table.Column<string>(nullable: true),
                    Tensach = table.Column<string>(nullable: true),
                    TheLoaiId = table.Column<int>(nullable: false),
                    TinhTrang = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sach_TheLoai_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "TheLoai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuonTraSach",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocGiaId = table.Column<int>(nullable: false),
                    NgayTra = table.Column<DateTime>(nullable: false),
                    SachId = table.Column<int>(nullable: false),
                    TienPhat = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuonTraSach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuonTraSach_DocGia_DocGiaId",
                        column: x => x.DocGiaId,
                        principalTable: "DocGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuonTraSach_Sach_SachId",
                        column: x => x.SachId,
                        principalTable: "Sach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocGia_LoaiDocGiaId",
                table: "DocGia",
                column: "LoaiDocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTraSach_DocGiaId",
                table: "MuonTraSach",
                column: "DocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_MuonTraSach_SachId",
                table: "MuonTraSach",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheLoaiId",
                table: "Sach",
                column: "TheLoaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuonTraSach");

            migrationBuilder.DropTable(
                name: "QuyDinhDocGia");

            migrationBuilder.DropTable(
                name: "QuyDinhMuonSach");

            migrationBuilder.DropTable(
                name: "DocGia");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "LoaiDocGia");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
