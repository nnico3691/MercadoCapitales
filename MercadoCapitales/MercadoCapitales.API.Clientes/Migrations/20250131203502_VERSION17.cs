using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentRecommendation_Recommendation_RecommendationId1",
                table: "InvestmentRecommendation");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentRecommendation_RecommendationId1",
                table: "InvestmentRecommendation");

            migrationBuilder.DropColumn(
                name: "RecommendationId1",
                table: "InvestmentRecommendation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecommendationId1",
                table: "InvestmentRecommendation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecommendation_RecommendationId1",
                table: "InvestmentRecommendation",
                column: "RecommendationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentRecommendation_Recommendation_RecommendationId1",
                table: "InvestmentRecommendation",
                column: "RecommendationId1",
                principalTable: "Recommendation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
