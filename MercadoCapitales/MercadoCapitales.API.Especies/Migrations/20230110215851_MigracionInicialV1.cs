using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class MigracionInicialV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NestedMarket",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "NestedSymbol",
                table: "Instrumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NestedMarket",
                table: "Instrumento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NestedSymbol",
                table: "Instrumento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
