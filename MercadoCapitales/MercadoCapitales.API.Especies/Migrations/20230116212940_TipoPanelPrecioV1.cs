using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class TipoPanelPrecioV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mercado",
                table: "TipoPanelPrecio",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mercado",
                table: "TipoPanelPrecio");
        }
    }
}
