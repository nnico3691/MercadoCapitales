using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class MigracionInicialV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientePerfilInversor",
                columns: table => new
                {
                    ClientePerfilInversorId = table.Column<Guid>(nullable: false),
                    EncuestaRespuestaId = table.Column<Guid>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePerfilInversor", x => x.ClientePerfilInversorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePerfilInversor");
        }
    }
}
