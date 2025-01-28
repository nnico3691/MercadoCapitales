using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Instrument");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Instrument",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Instrument",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Instrument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Instrument",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Instrument",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Instrument",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Instrument");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Instrument",
                type: "datetime2",
                nullable: true);
        }
    }
}
