using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingBase.Data.EF.Migrations
{
    public partial class AddTemperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Products");
        }
    }
}
