using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class changeanswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterAnswers_Users_UserId",
                table: "LetterAnswers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LetterAnswers",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_LetterAnswers_UserId",
                table: "LetterAnswers",
                newName: "IX_LetterAnswers_SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterAnswers_Users_SenderId",
                table: "LetterAnswers",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterAnswers_Users_SenderId",
                table: "LetterAnswers");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "LetterAnswers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LetterAnswers_SenderId",
                table: "LetterAnswers",
                newName: "IX_LetterAnswers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterAnswers_Users_UserId",
                table: "LetterAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
