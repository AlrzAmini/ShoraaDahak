using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class migtblletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Users_UserId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Letters");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Letters",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Letters_UserId",
                table: "Letters",
                newName: "IX_Letters_SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Users_SenderId",
                table: "Letters",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Users_SenderId",
                table: "Letters");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Letters",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Letters_SenderId",
                table: "Letters",
                newName: "IX_Letters_UserId");

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
    }
}
