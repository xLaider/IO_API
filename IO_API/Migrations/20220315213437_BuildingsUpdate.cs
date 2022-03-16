using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IO_API.Migrations
{
    public partial class BuildingsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountedCoins",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountingValue",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAccountings",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountedCoins",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "AccountingValue",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "NumberOfAccountings",
                table: "Buildings");
        }
    }
}
