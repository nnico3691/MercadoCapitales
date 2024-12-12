using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.CreateTable(
                name: "InstrumentId",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Proprietary = table.Column<string>(nullable: true),
                    ClientOrderId = table.Column<string>(nullable: true),
                    CancelPrevious = table.Column<bool>(nullable: false),
                    Iceberg = table.Column<bool>(nullable: false),
                    DisplayQuantity = table.Column<long>(nullable: false),
                    InstrumentIdId = table.Column<Guid>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Side = table.Column<int>(nullable: false),
                    Expiration = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_InstrumentId_InstrumentIdId",
                        column: x => x.InstrumentIdId,
                        principalTable: "InstrumentId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_InstrumentIdId",
                table: "Order",
                column: "InstrumentIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "InstrumentId");

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<float>(type: "real", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Comitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComitenteId = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    OrdenCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plazo = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCompraVenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidezOferta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                });
        }
    }
}
