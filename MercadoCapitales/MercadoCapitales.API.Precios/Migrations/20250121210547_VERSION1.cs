using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Precios.Migrations
{
    public partial class VERSION1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LA",
                table: "MarketData");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Offer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MarketData",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "MarketData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Bid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LastPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Date = table.Column<long>(nullable: false),
                    MarketDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastPrice_MarketData_MarketDataId",
                        column: x => x.MarketDataId,
                        principalTable: "MarketData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastPrice_MarketDataId",
                table: "LastPrice",
                column: "MarketDataId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastPrice");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Bid");

            migrationBuilder.AddColumn<decimal>(
                name: "LA",
                table: "MarketData",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
