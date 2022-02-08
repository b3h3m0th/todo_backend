using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo_Backend.Migrations
{
    public partial class AddVerfasserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerfasserID",
                table: "todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Vorname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nachname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "ID", "Geburtsdatum", "Nachname", "Vorname" },
                values: new object[] { 1, new DateTime(1978, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prinz", "Herta" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "ID", "Geburtsdatum", "Nachname", "Vorname" },
                values: new object[] { 2, new DateTime(1980, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adalbert", "Hubert" });

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "ID",
                keyValue: 1,
                column: "VerfasserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "todos",
                keyColumn: "ID",
                keyValue: 2,
                column: "VerfasserID",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_todos_VerfasserID",
                table: "todos",
                column: "VerfasserID");

            migrationBuilder.AddForeignKey(
                name: "FK_todos_persons_VerfasserID",
                table: "todos",
                column: "VerfasserID",
                principalTable: "persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todos_persons_VerfasserID",
                table: "todos");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropIndex(
                name: "IX_todos_VerfasserID",
                table: "todos");

            migrationBuilder.DropColumn(
                name: "VerfasserID",
                table: "todos");
        }
    }
}
