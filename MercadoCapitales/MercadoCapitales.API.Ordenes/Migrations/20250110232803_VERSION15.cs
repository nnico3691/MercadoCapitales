using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentId");

            migrationBuilder.AddColumn<string>(
                name: "Market",
                table: "Orden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Orden",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Market",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Orden");

            migrationBuilder.CreateTable(
                name: "InstrumentId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentId_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentId_OrdenId",
                table: "InstrumentId",
                column: "OrdenId",
                unique: true);
        }
    }
}
