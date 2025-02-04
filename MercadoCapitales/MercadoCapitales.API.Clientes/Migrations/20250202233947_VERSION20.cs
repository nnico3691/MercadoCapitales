using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvestmentRecommendation_RecommendationId",
                table: "InvestmentRecommendation");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecommendation_RecommendationId",
                table: "InvestmentRecommendation",
                column: "RecommendationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvestmentRecommendation_RecommendationId",
                table: "InvestmentRecommendation");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentRecommendation_RecommendationId",
                table: "InvestmentRecommendation",
                column: "RecommendationId");
        }
    }
}
