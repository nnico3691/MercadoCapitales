using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class MigracionInicialV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrumento",
                columns: table => new
                {
                    InstrumentoId = table.Column<Guid>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    NestedMarket = table.Column<string>(nullable: true),
                    NestedSymbol = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumento", x => x.InstrumentoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrumento");
        }
    }
}
