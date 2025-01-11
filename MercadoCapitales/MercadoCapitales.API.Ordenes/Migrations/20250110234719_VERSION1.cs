using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Proprietary = table.Column<string>(nullable: true),
                    ClientOrderId = table.Column<string>(nullable: true),
                    CancelPrevious = table.Column<bool>(nullable: false),
                    Iceberg = table.Column<bool>(nullable: false),
                    DisplayQuantity = table.Column<long>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    ExecutionId = table.Column<string>(nullable: true),
                    TransactionTime = table.Column<DateTime>(nullable: false),
                    AveragePrice = table.Column<decimal>(nullable: false),
                    LastPrice = table.Column<decimal>(nullable: false),
                    LastQuantity = table.Column<long>(nullable: false),
                    CumulativeQuantity = table.Column<long>(nullable: false),
                    LeavesQuantity = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusText = table.Column<string>(nullable: true),
                    OrdenId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatus_Order_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_OrdenId",
                table: "OrderStatus",
                column: "OrdenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
