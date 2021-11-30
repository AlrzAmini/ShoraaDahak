using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class changesendname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Users_UserId",
                table: "Letters");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Letters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Letters",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Users_UserId",
                table: "Letters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Users_UserId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Letters");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Letters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Users_UserId",
                table: "Letters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
