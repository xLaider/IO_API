using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IO_API.Migrations
{
    public partial class AddNewColumnToField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BigFieldID",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigFieldID",
                table: "Fields");
        }
    }
}
