using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeSmokyMarket.EF.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Baskets",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
