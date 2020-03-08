using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addWarehouseCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Norms",
                newName: "WarehouseCount");

            migrationBuilder.AddColumn<int>(
                name: "NormsCount",
                table: "Norms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormsCount",
                table: "Norms");

            migrationBuilder.RenameColumn(
                name: "WarehouseCount",
                table: "Norms",
                newName: "Count");
        }
    }
}
