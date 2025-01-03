using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Login");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Login",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_ClienteId",
                table: "Login",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Cliente_ClienteId",
                table: "Login",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Cliente_ClienteId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_ClienteId",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Login");

            migrationBuilder.AddColumn<Guid>(
                name: "Cliente",
                table: "Login",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
