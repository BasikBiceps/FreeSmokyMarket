using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeSmokyMarket.EF.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CategoryPicture",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BrandPicture",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPicture",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BrandPicture",
                table: "Brands");
        }
    }
}
