using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addWarehouseCounstProcent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WarehouseCount",
                table: "Norms",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WarehouseCount",
                table: "Norms",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
