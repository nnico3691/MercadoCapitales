using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType");

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
        }
    }
}
