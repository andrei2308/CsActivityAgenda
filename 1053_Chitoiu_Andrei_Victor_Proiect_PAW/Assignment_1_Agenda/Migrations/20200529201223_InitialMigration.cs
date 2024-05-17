using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_1_Agenda.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domenii",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DenumireDomeniu = table.Column<string>(nullable: true),
                    NecesitateResurse = table.Column<bool>(nullable: false),
                    Resursa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domenii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proiecte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    denumire = table.Column<string>(nullable: true),
                    coord = table.Column<string>(nullable: true),
                    deadLine = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proiecte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Activitatis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    denumire = table.Column<string>(nullable: true),
                    tipAct = table.Column<int>(nullable: false),
                    timpStart = table.Column<DateTime>(nullable: false),
                    timpFinish = table.Column<DateTime>(nullable: false),
                    necesitaProiect = table.Column<bool>(nullable: false),
                    domeniuID = table.Column<int>(nullable: true),
                    proiectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitatis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activitatis_Domenii_domeniuID",
                        column: x => x.domeniuID,
                        principalTable: "Domenii",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activitatis_Proiecte_proiectID",
                        column: x => x.proiectID,
                        principalTable: "Proiecte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activitatis_domeniuID",
                table: "Activitatis",
                column: "domeniuID");

            migrationBuilder.CreateIndex(
                name: "IX_Activitatis_proiectID",
                table: "Activitatis",
                column: "proiectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activitatis");

            migrationBuilder.DropTable(
                name: "Domenii");

            migrationBuilder.DropTable(
                name: "Proiecte");
        }
    }
}
