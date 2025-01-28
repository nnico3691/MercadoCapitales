using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrderType_InstrumentOrderType_InstrumentoId",
                table: "InstrumentOrderType");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentTimeInForce_InstrumentTimeInForce_InstrumentoId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentTimeInForce_InstrumentoId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrderType_InstrumentoId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentOrderType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentOrderType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentoId",
                table: "InstrumentTimeInForce",
                column: "InstrumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentoId",
                table: "InstrumentOrderType",
                column: "InstrumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrderType_InstrumentOrderType_InstrumentoId",
                table: "InstrumentOrderType",
                column: "InstrumentoId",
                principalTable: "InstrumentOrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentTimeInForce_InstrumentTimeInForce_InstrumentoId",
                table: "InstrumentTimeInForce",
                column: "InstrumentoId",
                principalTable: "InstrumentTimeInForce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
