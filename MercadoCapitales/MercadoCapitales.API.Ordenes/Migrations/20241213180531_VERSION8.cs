using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_InstrumentId_InstrumentIdId",
                table: "Orden");

            migrationBuilder.DropIndex(
                name: "IX_Orden_InstrumentIdId",
                table: "Orden");

            migrationBuilder.DropColumn(
                name: "InstrumentIdId",
                table: "Orden");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdenId",
                table: "InstrumentId",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentId_OrdenId",
                table: "InstrumentId",
                column: "OrdenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentId_Orden_OrdenId",
                table: "InstrumentId",
                column: "OrdenId",
                principalTable: "Orden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentId_Orden_OrdenId",
                table: "InstrumentId");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentId_OrdenId",
                table: "InstrumentId");

            migrationBuilder.DropColumn(
                name: "OrdenId",
                table: "InstrumentId");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentIdId",
                table: "Orden",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orden_InstrumentIdId",
                table: "Orden",
                column: "InstrumentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_InstrumentId_InstrumentIdId",
                table: "Orden",
                column: "InstrumentIdId",
                principalTable: "InstrumentId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
