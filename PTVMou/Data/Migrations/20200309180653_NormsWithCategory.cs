using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NormsWithCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeDeparmen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryesId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Norms",
                columns: table => new
                {
                    NormsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norms", x => x.NormsId);
                });

            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    SubdivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryesId = table.Column<int>(nullable: false),
                    CountCarInBattleCrew = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    BattleСrewId = table.Column<int>(nullable: false),
                    ReservId = table.Column<int>(nullable: false),
                    ReserveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.SubdivisionId);
                    table.ForeignKey(
                        name: "FK_Subdivision_BattleСrew_BattleСrewId",
                        column: x => x.BattleСrewId,
                        principalTable: "BattleСrew",
                        principalColumn: "BattleСrewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subdivision_Category_CategoryesId",
                        column: x => x.CategoryesId,
                        principalTable: "Category",
                        principalColumn: "CategoryesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subdivision_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subdivision_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Norms_PTVs",
                columns: table => new
                {
                    Norms_PTVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PTVId = table.Column<int>(nullable: false),
                    WarehouseCount = table.Column<decimal>(nullable: false),
                    NormsCount = table.Column<int>(nullable: false),
                    NormsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norms_PTVs", x => x.Norms_PTVId);
                    table.ForeignKey(
                        name: "FK_Norms_PTVs_Norms_NormsId",
                        column: x => x.NormsId,
                        principalTable: "Norms",
                        principalColumn: "NormsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Norms_PTVs_NormsId",
                table: "Norms_PTVs",
                column: "NormsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_BattleСrewId",
                table: "Subdivision",
                column: "BattleСrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_CategoryesId",
                table: "Subdivision",
                column: "CategoryesId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_DepartmentId",
                table: "Subdivision",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_ReserveId",
                table: "Subdivision",
                column: "ReserveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Norms_PTVs");

            migrationBuilder.DropTable(
                name: "Subdivision");

            migrationBuilder.DropTable(
                name: "Norms");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
