using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class CrearTableProductGroupV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mercado",
                table: "ProductGroup",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mercado",
                table: "ProductGroup");
        }
    }
}
