using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class UpdateTipoInstumentoV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInstrumento",
                table: "Instrumento");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoInstrumentoId",
                table: "Instrumento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInstrumentoId",
                table: "Instrumento");

            migrationBuilder.AddColumn<string>(
                name: "TipoInstrumento",
                table: "Instrumento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
