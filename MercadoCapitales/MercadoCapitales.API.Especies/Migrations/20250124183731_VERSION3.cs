using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrderType_Instrument_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentTimeInForce_Instrument_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentOrderType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentOrderTypeId",
                table: "Instrument",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentTimeInForceId",
                table: "Instrument",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentoId",
                table: "InstrumentTimeInForce",
                column: "InstrumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentoId",
                table: "InstrumentOrderType",
                column: "InstrumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_InstrumentOrderTypeId",
                table: "Instrument",
                column: "InstrumentOrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_InstrumentTimeInForceId",
                table: "Instrument",
                column: "InstrumentTimeInForceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_InstrumentOrderType_InstrumentOrderTypeId",
                table: "Instrument",
                column: "InstrumentOrderTypeId",
                principalTable: "InstrumentOrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_InstrumentTimeInForce_InstrumentTimeInForceId",
                table: "Instrument",
                column: "InstrumentTimeInForceId",
                principalTable: "InstrumentTimeInForce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_InstrumentOrderType_InstrumentOrderTypeId",
                table: "Instrument");

            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_InstrumentTimeInForce_InstrumentTimeInForceId",
                table: "Instrument");

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

            migrationBuilder.DropIndex(
                name: "IX_Instrument_InstrumentOrderTypeId",
                table: "Instrument");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_InstrumentTimeInForceId",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentOrderTypeId",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "InstrumentTimeInForceId",
                table: "Instrument");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentTimeInForce",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentOrderType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrderType_Instrument_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentTimeInForce_Instrument_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
