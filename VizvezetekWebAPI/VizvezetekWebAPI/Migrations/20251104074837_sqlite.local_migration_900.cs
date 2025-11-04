using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VizvezetekWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_900 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Helyek",
                columns: table => new
                {
                    Az = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telepules = table.Column<string>(type: "TEXT", nullable: false),
                    Utca = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helyek", x => x.Az);
                });

            migrationBuilder.CreateTable(
                name: "Szerelok",
                columns: table => new
                {
                    Az = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    KezdEv = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szerelok", x => x.Az);
                });

            migrationBuilder.CreateTable(
                name: "Munkalapok",
                columns: table => new
                {
                    Az = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeDatum = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    JavDatum = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HelyAz = table.Column<int>(type: "INTEGER", nullable: false),
                    SzereloAz = table.Column<int>(type: "INTEGER", nullable: false),
                    MunkaOra = table.Column<int>(type: "INTEGER", nullable: false),
                    AnyagAr = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Munkalapok", x => x.Az);
                    table.ForeignKey(
                        name: "FK_Munkalapok_Helyek_HelyAz",
                        column: x => x.HelyAz,
                        principalTable: "Helyek",
                        principalColumn: "Az",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Munkalapok_Szerelok_SzereloAz",
                        column: x => x.SzereloAz,
                        principalTable: "Szerelok",
                        principalColumn: "Az",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Munkalapok_HelyAz",
                table: "Munkalapok",
                column: "HelyAz");

            migrationBuilder.CreateIndex(
                name: "IX_Munkalapok_SzereloAz",
                table: "Munkalapok",
                column: "SzereloAz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Munkalapok");

            migrationBuilder.DropTable(
                name: "Helyek");

            migrationBuilder.DropTable(
                name: "Szerelok");
        }
    }
}
