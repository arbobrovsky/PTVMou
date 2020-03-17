using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditFailspart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WarehouseCount",
                table: "Norms_PTVs",
                newName: "WarehouseNormsCount");

            migrationBuilder.AddColumn<bool>(
                name: "OnCar",
                table: "Norms_PTVs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnCar",
                table: "Norms_PTVs");

            migrationBuilder.RenameColumn(
                name: "WarehouseNormsCount",
                table: "Norms_PTVs",
                newName: "WarehouseCount");
        }
    }
}
