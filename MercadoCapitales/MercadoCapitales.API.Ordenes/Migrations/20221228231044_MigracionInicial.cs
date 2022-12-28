using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    PrecioId = table.Column<Guid>(nullable: false),
                    OrdenCodigo = table.Column<string>(nullable: true),
                    TipoCompraVenta = table.Column<string>(nullable: true),
                    Comitente = table.Column<string>(nullable: true),
                    Cliente = table.Column<string>(nullable: true),
                    ComitenteId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    Cantidad = table.Column<float>(nullable: false),
                    TipoDeOrden = table.Column<string>(nullable: true),
                    Precio = table.Column<float>(nullable: false),
                    Importe = table.Column<float>(nullable: false),
                    ValidezOferta = table.Column<int>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(nullable: true),
                    Plazo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.PrecioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orden");
        }
    }
}
