using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class AgregueTipoInstruccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoInstrumento",
                table: "Instrumento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInstrumento",
                table: "Instrumento");
        }
    }
}
