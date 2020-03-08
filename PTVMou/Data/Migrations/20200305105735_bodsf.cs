using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class bodsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reserve",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BattleСrew",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BattleСrew");
        }
    }
}
