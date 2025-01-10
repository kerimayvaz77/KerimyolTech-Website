using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulama.Migrations
{
    /// <inheritdoc />
    public partial class UrunOzelliklerEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResimUrl",
                table: "Urunler",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fiyat",
                table: "Urunler",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Urunler",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GarantiSuresi",
                table: "Urunler",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Urunler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marka",
                table: "Urunler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Urunler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeknikOzellikler",
                table: "Urunler",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "GarantiSuresi",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Marka",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "TeknikOzellikler",
                table: "Urunler");

            migrationBuilder.AlterColumn<string>(
                name: "ResimUrl",
                table: "Urunler",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fiyat",
                table: "Urunler",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
