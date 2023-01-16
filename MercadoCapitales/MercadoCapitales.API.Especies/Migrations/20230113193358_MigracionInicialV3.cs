using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class MigracionInicialV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timesInForce",
                table: "Instrumento");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaAlta",
                table: "Instrumento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaAlta",
                table: "Instrumento");

            migrationBuilder.AddColumn<string>(
                name: "timesInForce",
                table: "Instrumento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
