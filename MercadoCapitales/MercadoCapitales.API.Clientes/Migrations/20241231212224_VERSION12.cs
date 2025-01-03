using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Clientes.Migrations
{
    public partial class VERSION12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_PrimaryUser_PrimaryUserId",
                table: "Position");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryUserId",
                table: "Position",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentId",
                table: "Position",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Position_PrimaryUser_PrimaryUserId",
                table: "Position",
                column: "PrimaryUserId",
                principalTable: "PrimaryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_PrimaryUser_PrimaryUserId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "Position");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryUserId",
                table: "Position",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SettType = table.Column<int>(type: "int", nullable: false),
                    SymbolReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrument_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_PositionId",
                table: "Instrument",
                column: "PositionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_PrimaryUser_PrimaryUserId",
                table: "Position",
                column: "PrimaryUserId",
                principalTable: "PrimaryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
