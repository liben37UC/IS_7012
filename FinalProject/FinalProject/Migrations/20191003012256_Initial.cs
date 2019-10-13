using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(maxLength: 80, nullable: false),
                    BusinessType = table.Column<string>(maxLength: 80, nullable: false),
                    BusinessCountry = table.Column<string>(maxLength: 80, nullable: false),
                    NumberEmployees = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(maxLength: 80, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PlannedEndDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    RunningTotalCost = table.Column<decimal>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 80, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PlannedEndDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    WorkStatus = table.Column<string>(nullable: true),
                    Rating = table.Column<decimal>(nullable: true),
                    BusinessID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contractor_Business_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Business",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractor_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_BusinessID",
                table: "Contractor",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_ProjectID",
                table: "Contractor",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
