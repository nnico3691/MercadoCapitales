using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Precios.Migrations
{
    public partial class VERSION0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    ACP = table.Column<decimal>(nullable: true),
                    CL = table.Column<decimal>(nullable: true),
                    EV = table.Column<int>(nullable: false),
                    HI = table.Column<decimal>(nullable: true),
                    IV = table.Column<decimal>(nullable: true),
                    LA = table.Column<decimal>(nullable: true),
                    LO = table.Column<decimal>(nullable: true),
                    NV = table.Column<int>(nullable: false),
                    OP = table.Column<decimal>(nullable: true),
                    TV = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    MarketDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_MarketData_MarketDataId",
                        column: x => x.MarketDataId,
                        principalTable: "MarketData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    MarketDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_MarketData_MarketDataId",
                        column: x => x.MarketDataId,
                        principalTable: "MarketData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    MarketDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenInterests_MarketData_MarketDataId",
                        column: x => x.MarketDataId,
                        principalTable: "MarketData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    MarketDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_MarketData_MarketDataId",
                        column: x => x.MarketDataId,
                        principalTable: "MarketData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_MarketDataId",
                table: "Bid",
                column: "MarketDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_MarketDataId",
                table: "Offer",
                column: "MarketDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenInterests_MarketDataId",
                table: "OpenInterests",
                column: "MarketDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_MarketDataId",
                table: "Settlements",
                column: "MarketDataId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "OpenInterests");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "MarketData");
        }
    }
}
