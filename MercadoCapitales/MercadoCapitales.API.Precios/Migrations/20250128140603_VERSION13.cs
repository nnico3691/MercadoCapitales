using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Precios.Migrations
{
    public partial class VERSION13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "OpenInterests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Offer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MarketData",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "MarketData",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "LastPrice",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Bid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "MarketData");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "MarketData");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "OpenInterests",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Offer",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "LastPrice",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Bid",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
