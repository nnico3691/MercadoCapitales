using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrderType_Instrumento_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentTimeInForce_Instrumento_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento");

            migrationBuilder.RenameTable(
                name: "Instrumento",
                newName: "Instrument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrderType_Instrument_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentTimeInForce_Instrument_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument");

            migrationBuilder.RenameTable(
                name: "Instrument",
                newName: "Instrumento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrderType_Instrumento_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId",
                principalTable: "Instrumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentTimeInForce_Instrumento_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId",
                principalTable: "Instrumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
