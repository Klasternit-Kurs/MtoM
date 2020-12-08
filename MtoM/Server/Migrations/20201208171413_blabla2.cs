using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MtoM.Server.Migrations
{
    public partial class blabla2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radniks_Tims_Tim_FK",
                table: "Radniks");

            migrationBuilder.AlterColumn<int>(
                name: "Tim_FK",
                table: "Radniks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -3,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 12, 18, 14, 12, 269, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -2,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 1, 18, 14, 12, 269, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Racuni",
                keyColumn: "RbR",
                keyValue: -1,
                column: "DatumIzdavanja",
                value: new DateTime(2020, 12, 8, 18, 14, 12, 262, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.AddForeignKey(
                name: "FK_Radniks_Tims_Tim_FK",
                table: "Radniks",
                column: "Tim_FK",
                principalTable: "Tims",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radniks_Tims_Tim_FK",
                table: "Radniks");

            migrationBuilder.AlterColumn<int>(
                name: "Tim_FK",
                table: "Radniks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Radniks_Tims_Tim_FK",
                table: "Radniks",
                column: "Tim_FK",
                principalTable: "Tims",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
