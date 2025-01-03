using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    BuySize = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    SellSize = table.Column<int>(nullable: false),
                    SellPrice = table.Column<decimal>(nullable: false),
                    TotalDailyDiff = table.Column<decimal>(nullable: false),
                    TotalDiff = table.Column<decimal>(nullable: false),
                    TradingSymbol = table.Column<string>(nullable: true),
                    PrimaryUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_PrimaryUser_PrimaryUserId",
                        column: x => x.PrimaryUserId,
                        principalTable: "PrimaryUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SymbolReference = table.Column<string>(nullable: true),
                    SettType = table.Column<int>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrument_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_PositionId",
                table: "Instrument",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_PrimaryUserId",
                table: "Position",
                column: "PrimaryUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
