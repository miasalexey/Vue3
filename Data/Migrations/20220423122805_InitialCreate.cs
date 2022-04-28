using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CriminalDecisions",
                columns: table => new
                {
                    CriminalDecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalDecisions", x => x.CriminalDecisionId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountCriminalRecord = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "CriminalCases",
                columns: table => new
                {
                    CriminalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriminalDecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalCases", x => x.CriminalCaseId);
                    table.ForeignKey(
                        name: "FK_CriminalCases_CriminalDecisions_CriminalDecisionId",
                        column: x => x.CriminalDecisionId,
                        principalTable: "CriminalDecisions",
                        principalColumn: "CriminalDecisionId");
                });

            migrationBuilder.CreateTable(
                name: "PersonInCriminalCases",
                columns: table => new
                {
                    PersonInCriminalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CriminalCaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInCriminalCases", x => x.PersonInCriminalCaseId);
                    table.ForeignKey(
                        name: "FK_PersonInCriminalCases_CriminalCases_CriminalCaseId",
                        column: x => x.CriminalCaseId,
                        principalTable: "CriminalCases",
                        principalColumn: "CriminalCaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInCriminalCases_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriminalCases_CriminalDecisionId",
                table: "CriminalCases",
                column: "CriminalDecisionId",
                unique: true,
                filter: "[CriminalDecisionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInCriminalCases_CriminalCaseId",
                table: "PersonInCriminalCases",
                column: "CriminalCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInCriminalCases_PersonId",
                table: "PersonInCriminalCases",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInCriminalCases");

            migrationBuilder.DropTable(
                name: "CriminalCases");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "CriminalDecisions");
        }
    }
}
