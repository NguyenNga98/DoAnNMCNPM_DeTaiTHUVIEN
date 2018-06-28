using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OA.Data.Migrations
{
    public partial class updatemuontra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTra",
                table: "MuonTraSach",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayMuon",
                table: "MuonTraSach",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SoSachDangMuon",
                table: "DocGia",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayMuon",
                table: "MuonTraSach");

            migrationBuilder.DropColumn(
                name: "SoSachDangMuon",
                table: "DocGia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTra",
                table: "MuonTraSach",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
