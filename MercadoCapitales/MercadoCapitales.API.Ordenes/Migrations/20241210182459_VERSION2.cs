using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "Orden",
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
                    table.PrimaryKey("PK_Orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_InstrumentId_InstrumentIdId",
                        column: x => x.InstrumentIdId,
                        principalTable: "InstrumentId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_InstrumentIdId",
                table: "Orden",
                column: "InstrumentIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancelPrevious = table.Column<bool>(type: "bit", nullable: false),
                    ClientOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayQuantity = table.Column<long>(type: "bigint", nullable: false),
                    Expiration = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iceberg = table.Column<bool>(type: "bit", nullable: false),
                    InstrumentIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Proprietary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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
    }
}
