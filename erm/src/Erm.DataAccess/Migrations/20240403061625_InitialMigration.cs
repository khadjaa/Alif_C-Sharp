using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_process",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    domain = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_process", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OccurrenceProbability = table.Column<int>(type: "int", nullable: false),
                    PotentialBusinessImpact = table.Column<int>(type: "int", nullable: false),
                    OccurrenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PotentialSolution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "risk_profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_process_id = table.Column<int>(type: "int", nullable: false),
                    risk_name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    description = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    occurrece_probability = table.Column<int>(type: "INTEGER", nullable: false),
                    potential_business_impact = table.Column<int>(type: "INTEGER", nullable: false),
                    potential_solution = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    RiskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_profile", x => x.id);
                    table.ForeignKey(
                        name: "FK_risk_profile_Risk_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_risk_profile_business_process_business_process_id",
                        column: x => x.business_process_id,
                        principalTable: "business_process",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_risk_profile_business_process_id",
                table: "risk_profile",
                column: "business_process_id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_profile_RiskId",
                table: "risk_profile",
                column: "RiskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "risk_profile");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "business_process");
        }
    }
}
