using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AccountExecutive",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AccountExecutive",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AccountExecutive",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AccountExecutive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "AccountExecutive",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AccountExecutive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AccountExecutive",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AccountExecutive");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AccountExecutive");
        }
    }
}
