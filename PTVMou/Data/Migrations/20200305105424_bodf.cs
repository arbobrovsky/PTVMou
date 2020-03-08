using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class bodf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleСrew_Subdivision_SubdivisionId",
                table: "BattleСrew");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Subdivision_SubdivisionId",
                table: "Reserve");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Subdivision_SubdivisionId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_SubdivisionId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_SubdivisionId",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_BattleСrew_SubdivisionId",
                table: "BattleСrew");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "BattleСrew");

            migrationBuilder.AddColumn<int>(
                name: "BattleСrewId",
                table: "Subdivision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservId",
                table: "Subdivision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReserveId",
                table: "Subdivision",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_BattleСrewId",
                table: "Subdivision",
                column: "BattleСrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_ReserveId",
                table: "Subdivision",
                column: "ReserveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subdivision_BattleСrew_BattleСrewId",
                table: "Subdivision",
                column: "BattleСrewId",
                principalTable: "BattleСrew",
                principalColumn: "BattleСrewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subdivision_Reserve_ReserveId",
                table: "Subdivision",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "ReserveId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subdivision_BattleСrew_BattleСrewId",
                table: "Subdivision");

            migrationBuilder.DropForeignKey(
                name: "FK_Subdivision_Reserve_ReserveId",
                table: "Subdivision");

            migrationBuilder.DropIndex(
                name: "IX_Subdivision_BattleСrewId",
                table: "Subdivision");

            migrationBuilder.DropIndex(
                name: "IX_Subdivision_ReserveId",
                table: "Subdivision");

            migrationBuilder.DropColumn(
                name: "BattleСrewId",
                table: "Subdivision");

            migrationBuilder.DropColumn(
                name: "ReservId",
                table: "Subdivision");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "Subdivision");

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "Warehouse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "Reserve",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Reserve",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "BattleСrew",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_SubdivisionId",
                table: "Warehouse",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_SubdivisionId",
                table: "Reserve",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleСrew_SubdivisionId",
                table: "BattleСrew",
                column: "SubdivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleСrew_Subdivision_SubdivisionId",
                table: "BattleСrew",
                column: "SubdivisionId",
                principalTable: "Subdivision",
                principalColumn: "SubdivisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Subdivision_SubdivisionId",
                table: "Reserve",
                column: "SubdivisionId",
                principalTable: "Subdivision",
                principalColumn: "SubdivisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Subdivision_SubdivisionId",
                table: "Warehouse",
                column: "SubdivisionId",
                principalTable: "Subdivision",
                principalColumn: "SubdivisionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
