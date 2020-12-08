using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MtoM.Server.Migrations
{
    public partial class blabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nestos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VremenaZaBazu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nestos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tims",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tims", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radniks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tim_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radniks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Radniks_Tims_Tim_FK",
                        column: x => x.Tim_FK,
                        principalTable: "Tims",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -3,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 12, 17, 55, 42, 302, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -2,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 1, 17, 55, 42, 302, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -1,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 8, 17, 55, 42, 290, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.InsertData(
                table: "Tims",
                columns: new[] { "ID", "Naziv" },
                values: new object[] { -1, "A" });

            migrationBuilder.InsertData(
                table: "Radniks",
                columns: new[] { "ID", "Naziv", "Tim_FK" },
                values: new object[] { -1, "Pera", -1 });

            migrationBuilder.InsertData(
                table: "Radniks",
                columns: new[] { "ID", "Naziv", "Tim_FK" },
                values: new object[] { -2, "Neko", -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_Tim_FK",
                table: "Radniks",
                column: "Tim_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nestos");

            migrationBuilder.DropTable(
                name: "Radniks");

            migrationBuilder.DropTable(
                name: "Tims");

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -3,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 11, 20, 9, 7, 840, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -2,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 11, 30, 20, 9, 7, 840, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -1,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 7, 20, 9, 7, 835, DateTimeKind.Local).AddTicks(8199));
        }
    }
}
