using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IO_API.Migrations
{
    public partial class ChangedVisibilityOfFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BigFieldID",
                table: "Fields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_BigFieldID",
                table: "Fields",
                column: "BigFieldID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_BigFields_BigFieldID",
                table: "Fields",
                column: "BigFieldID",
                principalTable: "BigFields",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_BigFields_BigFieldID",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_BigFieldID",
                table: "Fields");

            migrationBuilder.AlterColumn<int>(
                name: "BigFieldID",
                table: "Fields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
