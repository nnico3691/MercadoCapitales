using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Especies.Migrations
{
    public partial class VERSION1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "TipoPanelPrecio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentTimeInForce",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentOrderType",
                table: "InstrumentOrderType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "InstrumentTimesInForceId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentOrderTypeId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentoId",
                table: "Instrumento");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InstrumentTimeInForce",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentTimeInForce",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InstrumentOrderType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentId",
                table: "InstrumentOrderType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Instrumento",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentTimeInForce",
                table: "InstrumentTimeInForce",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentOrderType",
                table: "InstrumentOrderType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType",
                column: "InstrumentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrderType_Instrumento_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentTimeInForce_Instrumento_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentTimeInForce",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentTimeInForce_InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentOrderType",
                table: "InstrumentOrderType");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrderType_InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "InstrumentTimeInForce");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "InstrumentOrderType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Instrumento");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentTimesInForceId",
                table: "InstrumentTimeInForce",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentTimeInForce",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentOrderTypeId",
                table: "InstrumentOrderType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "InstrumentOrderType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentoId",
                table: "Instrumento",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentTimeInForce",
                table: "InstrumentTimeInForce",
                column: "InstrumentTimesInForceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentOrderType",
                table: "InstrumentOrderType",
                column: "InstrumentOrderTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrumento",
                table: "Instrumento",
                column: "InstrumentoId");

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    ProductGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mercado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ProductGroupId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPanelPrecio",
                columns: table => new
                {
                    TipoPanelPrecioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mercado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cficode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketSegmentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPanelPrecio", x => x.TipoPanelPrecioId);
                });
        }
    }
}
