using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingBase.Data.EF.Migrations
{
    public partial class NextVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DungTich",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiongNho",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MauRuou",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NongDo",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGian",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeRuou",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowHome",
                table: "ProductCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DungTich",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiongNho",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MauRuou",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NongDo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThoiGian",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeRuou",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowHome",
                table: "ProductCategories");
        }
    }
}
