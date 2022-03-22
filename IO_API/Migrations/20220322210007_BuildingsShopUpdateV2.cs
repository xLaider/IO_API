using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IO_API.Migrations
{
    public partial class BuildingsShopUpdateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BuildingsShop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BuildingsShop");
        }
    }
}
