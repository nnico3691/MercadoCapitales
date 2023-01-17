using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class UpdateTipoInstumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "TipoInstrumento");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TipoInstrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TipoInstrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Market",
                table: "TipoInstrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "TipoInstrumento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TipoInstrumento");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TipoInstrumento");

            migrationBuilder.DropColumn(
                name: "Market",
                table: "TipoInstrumento");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "TipoInstrumento");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "TipoInstrumento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
