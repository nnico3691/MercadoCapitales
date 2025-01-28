using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION6 : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentTimeInForce",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentOrderType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrderType_Instrument_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentTimeInForce_Instrument_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentTimeInForce",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentOrderType",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId",
                unique: true,
                filter: "[InstrumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId",
                unique: true,
                filter: "[InstrumentId] IS NOT NULL");

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
