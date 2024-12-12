using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoCapitales.API.Ordenes.Migrations
{
    public partial class VERSION7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientOrderId",
                table: "OrderStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientOrderId",
                table: "OrderStatus",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
