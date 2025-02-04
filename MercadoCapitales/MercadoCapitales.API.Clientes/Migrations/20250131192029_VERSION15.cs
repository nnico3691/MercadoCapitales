using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountExecutive",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    Organization = table.Column<int>(nullable: false),
                    Recommender = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExecutive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RiskLevel = table.Column<int>(nullable: false),
                    AccountExecutiveId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommendation_AccountExecutive_AccountExecutiveId",
                        column: x => x.AccountExecutiveId,
                        principalTable: "AccountExecutive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentRecommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstrumentId = table.Column<Guid>(nullable: false),
                    CommissionPercentage = table.Column<decimal>(nullable: false),
                    RecommendationId = table.Column<Guid>(nullable: false),
                    RecommendationId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentRecommendation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentRecommendation_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentRecommendation_Recommendation_RecommendationId1",
                        column: x => x.RecommendationId1,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecommendation_RecommendationId",
                table: "InvestmentRecommendation",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecommendation_RecommendationId1",
                table: "InvestmentRecommendation",
                column: "RecommendationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_AccountExecutiveId",
                table: "Recommendation",
                column: "AccountExecutiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentRecommendation");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "AccountExecutive");
        }
    }
}
