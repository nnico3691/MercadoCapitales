using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_Orden_Id",
                table: "OrderStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdenId",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_OrdenId",
                table: "OrderStatus",
                column: "OrdenId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_Orden_OrdenId",
                table: "OrderStatus",
                column: "OrdenId",
                principalTable: "Orden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_Orden_OrdenId",
                table: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatus_OrdenId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "OrdenId",
                table: "OrderStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_Orden_Id",
                table: "OrderStatus",
                column: "Id",
                principalTable: "Orden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
