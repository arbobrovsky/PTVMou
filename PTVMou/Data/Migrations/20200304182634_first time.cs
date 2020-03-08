using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class firsttime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeDeparmen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
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
                name: "PTV",
                columns: table => new
                {
                    PTVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Measure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTV", x => x.PTVId);
                });

            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    SubdivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.SubdivisionId);
                    table.ForeignKey(
                        name: "FK_Subdivision_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleСrew",
                columns: table => new
                {
                    BattleСrewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubdivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleСrew", x => x.BattleСrewId);
                    table.ForeignKey(
                        name: "FK_BattleСrew_Subdivision_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "SubdivisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    ReserveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WarehouseId = table.Column<int>(nullable: false),
                    SubdivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.ReserveId);
                    table.ForeignKey(
                        name: "FK_Reserve_Subdivision_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "SubdivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubdivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_Subdivision_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "SubdivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleСrew_PTV",
                columns: table => new
                {
                    BattleСrew_PTVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BattleСrewId = table.Column<int>(nullable: false),
                    PTVId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleСrew_PTV", x => x.BattleСrew_PTVId);
                    table.ForeignKey(
                        name: "FK_BattleСrew_PTV_BattleСrew_BattleСrewId",
                        column: x => x.BattleСrewId,
                        principalTable: "BattleСrew",
                        principalColumn: "BattleСrewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservePTV",
                columns: table => new
                {
                    ReservePTVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PTVId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ReserveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservePTV", x => x.ReservePTVId);
                    table.ForeignKey(
                        name: "FK_ReservePTV_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse_PTV",
                columns: table => new
                {
                    Warehouse_PTVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PTVId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    ReserveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse_PTV", x => x.Warehouse_PTVId);
                    table.ForeignKey(
                        name: "FK_Warehouse_PTV_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouse_PTV_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleСrew_SubdivisionId",
                table: "BattleСrew",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleСrew_PTV_BattleСrewId",
                table: "BattleСrew_PTV",
                column: "BattleСrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_SubdivisionId",
                table: "Reserve",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservePTV_ReserveId",
                table: "ReservePTV",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_DepartmentId",
                table: "Subdivision",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_SubdivisionId",
                table: "Warehouse",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_PTV_ReserveId",
                table: "Warehouse_PTV",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_PTV_WarehouseId",
                table: "Warehouse_PTV",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleСrew_PTV");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "PTV");

            migrationBuilder.DropTable(
                name: "ReservePTV");

            migrationBuilder.DropTable(
                name: "Warehouse_PTV");

            migrationBuilder.DropTable(
                name: "BattleСrew");

            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Subdivision");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
