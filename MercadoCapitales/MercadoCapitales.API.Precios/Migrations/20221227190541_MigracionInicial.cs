using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Precios.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CotizacionAccion",
                columns: table => new
                {
                    PrecioId = table.Column<Guid>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    Precio = table.Column<float>(nullable: true),
                    VarPorcentual = table.Column<float>(nullable: true),
                    PrecioA = table.Column<float>(nullable: true),
                    CCompra = table.Column<float>(nullable: true),
                    PCompra = table.Column<float>(nullable: true),
                    PVenta = table.Column<float>(nullable: true),
                    CVenta = table.Column<float>(nullable: true),
                    Min = table.Column<float>(nullable: true),
                    Max = table.Column<float>(nullable: true),
                    Ajuste = table.Column<string>(nullable: true),
                    VolNom = table.Column<string>(nullable: true),
                    Monto = table.Column<float>(nullable: true),
                    Oper = table.Column<int>(nullable: true),
                    Hora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionAccion", x => x.PrecioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionAccion");
        }
    }
}
