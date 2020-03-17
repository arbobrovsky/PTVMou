using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EditFails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Norms_PTVs_Norms_NormsId",
                table: "Norms_PTVs");

            migrationBuilder.AlterColumn<int>(
                name: "NormsId",
                table: "Norms_PTVs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Norms_PTVs_Norms_NormsId",
                table: "Norms_PTVs",
                column: "NormsId",
                principalTable: "Norms",
                principalColumn: "NormsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Norms_PTVs_Norms_NormsId",
                table: "Norms_PTVs");

            migrationBuilder.AlterColumn<int>(
                name: "NormsId",
                table: "Norms_PTVs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Norms_PTVs_Norms_NormsId",
                table: "Norms_PTVs",
                column: "NormsId",
                principalTable: "Norms",
                principalColumn: "NormsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
