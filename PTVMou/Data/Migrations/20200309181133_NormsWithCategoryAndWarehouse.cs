using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NormsWithCategoryAndWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Subdivision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_WarehouseId",
                table: "Subdivision",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subdivision_Warehouse_WarehouseId",
                table: "Subdivision",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subdivision_Warehouse_WarehouseId",
                table: "Subdivision");

            migrationBuilder.DropIndex(
                name: "IX_Subdivision_WarehouseId",
                table: "Subdivision");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Subdivision");
        }
    }
}
