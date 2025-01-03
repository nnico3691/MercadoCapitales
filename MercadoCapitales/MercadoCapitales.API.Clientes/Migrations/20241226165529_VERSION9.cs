using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimaryUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryUser_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryUser_ClienteId",
                table: "PrimaryUser",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimaryUser");
        }
    }
}
