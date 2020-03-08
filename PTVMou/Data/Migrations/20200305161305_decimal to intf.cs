using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class decimaltointf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "Norms",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "Norms",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
