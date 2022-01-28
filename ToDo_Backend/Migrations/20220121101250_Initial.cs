using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo_Backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Beschreibung = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deadline = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Erledigt = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "ID", "Beschreibung", "Deadline", "Erledigt", "Titel" },
                values: new object[] { 1, "Alle CRUD-Operatioen umsetzen", new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Webservice fertig implementieren" });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "ID", "Beschreibung", "Deadline", "Erledigt", "Titel" },
                values: new object[] { 2, "Sollte man eh immer machen :)", new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mathe lernen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todos");
        }
    }
}
