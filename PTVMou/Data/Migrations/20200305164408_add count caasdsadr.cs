using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addcountcaasdsadr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeedPTV",
                table: "Warehouse_PTV",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeedPTV",
                table: "ReservePTV",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeedPTV",
                table: "BattleСrew_PTV",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedPTV",
                table: "Warehouse_PTV");

            migrationBuilder.DropColumn(
                name: "NeedPTV",
                table: "ReservePTV");

            migrationBuilder.DropColumn(
                name: "NeedPTV",
                table: "BattleСrew_PTV");
        }
    }
}
