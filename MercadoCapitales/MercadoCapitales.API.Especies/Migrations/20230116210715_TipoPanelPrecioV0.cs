using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class TipoPanelPrecioV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPanelPrecio",
                columns: table => new
                {
                    TipoPanelPrecioId = table.Column<Guid>(nullable: false),
                    cficode = table.Column<string>(nullable: true),
                    marketSegmentId = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPanelPrecio", x => x.TipoPanelPrecioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPanelPrecio");
        }
    }
}
