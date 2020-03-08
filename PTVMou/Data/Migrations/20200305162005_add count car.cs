using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addcountcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountCarInBattleCrew",
                table: "Subdivision",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountCarInBattleCrew",
                table: "Subdivision");
        }
    }
}
