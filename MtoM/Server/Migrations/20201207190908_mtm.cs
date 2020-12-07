using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MtoM.Server.Migrations
{
    public partial class mtm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikli",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikli", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Racuni",
                columns: table => new
                {
                    RbR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuni", x => x.RbR);
                });

            migrationBuilder.CreateTable(
                name: "RAs",
                columns: table => new
                {
                    R_FK = table.Column<int>(type: "int", nullable: false),
                    A_FK = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAs", x => new { x.A_FK, x.R_FK });
                    table.ForeignKey(
                        name: "FK_RAs_Artikli_A_FK",
                        column: x => x.A_FK,
                        principalTable: "Artikli",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAs_Racuni_R_FK",
                        column: x => x.R_FK,
                        principalTable: "Racuni",
                        principalColumn: "RbR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artikli",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { -1, "Bla" },
                    { -2, "A2" },
                    { -3, "A3" }
                });

            migrationBuilder.InsertData(
                table: "Racuni",
                columns: new[] { "RbR", "DatumIzdavanja" },
                values: new object[,]
                {
                    { -1, new DateTime(2020, 12, 7, 20, 9, 7, 835, DateTimeKind.Local).AddTicks(8199) },
                    { -2, new DateTime(2020, 11, 30, 20, 9, 7, 840, DateTimeKind.Local).AddTicks(1918) },
                    { -3, new DateTime(2020, 12, 11, 20, 9, 7, 840, DateTimeKind.Local).AddTicks(2090) }
                });

            migrationBuilder.InsertData(
                table: "RAs",
                columns: new[] { "A_FK", "R_FK", "Kolicina" },
                values: new object[,]
                {
                    { -2, -1, 5 },
                    { -1, -2, 2 },
                    { -3, -2, 7 },
                    { -1, -3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RAs_R_FK",
                table: "RAs",
                column: "R_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RAs");

            migrationBuilder.DropTable(
                name: "Artikli");

            migrationBuilder.DropTable(
                name: "Racuni");
        }
    }
}
