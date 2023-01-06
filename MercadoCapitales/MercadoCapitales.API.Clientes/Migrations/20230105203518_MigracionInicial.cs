using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    TipoDNI = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEncuestas",
                columns: table => new
                {
                    ClienteEncuestasId = table.Column<Guid>(nullable: false),
                    EncuestaRespuesta = table.Column<Guid>(nullable: true),
                    ClieKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEncuestas", x => x.ClienteEncuestasId);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaPregunta",
                columns: table => new
                {
                    EncuestaPreguntaId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Pregunta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaPregunta", x => x.EncuestaPreguntaId);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaRespuesta",
                columns: table => new
                {
                    EncuestaRespuestaId = table.Column<Guid>(nullable: false),
                    Respuesta = table.Column<string>(nullable: true),
                    Puntos = table.Column<int>(nullable: false),
                    NameInput = table.Column<string>(nullable: true),
                    TipoInput = table.Column<string>(nullable: true),
                    EncuestaPregunta = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRespuesta", x => x.EncuestaRespuestaId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<Guid>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Cliente = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ClienteEncuestas");

            migrationBuilder.DropTable(
                name: "EncuestaPregunta");

            migrationBuilder.DropTable(
                name: "EncuestaRespuesta");

            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
