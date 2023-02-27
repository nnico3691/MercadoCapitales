using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class MigracionInicialV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketSegmentId",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaturityDate",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PriceConversionFactor",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "cficode",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "contractMultiplier",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "highLimitPrice",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "instrumentPricePrecision",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instrumentSizePrecision",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "lowLimitPrice",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "marketId",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "maxTradeVol",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "minPriceIncrement",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "minTradeVol",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "roundLot",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "securityId",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "securityIdSource",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "securityType",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "settlType",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tickSize",
                table: "Instrumento",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "timesInForce",
                table: "Instrumento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstrumentOrderType",
                columns: table => new
                {
                    InstrumentOrderTypeId = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    InstrumentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentOrderType", x => x.InstrumentOrderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentTimeInForce",
                columns: table => new
                {
                    InstrumentTimesInForceId = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    InstrumentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTimeInForce", x => x.InstrumentTimesInForceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentOrderType");

            migrationBuilder.DropTable(
                name: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "MarketSegmentId",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "MaturityDate",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "PriceConversionFactor",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "cficode",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "contractMultiplier",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "highLimitPrice",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "instrumentPricePrecision",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "instrumentSizePrecision",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "lowLimitPrice",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "marketId",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "maxTradeVol",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "minPriceIncrement",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "minTradeVol",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "roundLot",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "securityId",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "securityIdSource",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "securityType",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "settlType",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "tickSize",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "timesInForce",
                table: "Instrumento");
        }
    }
}
