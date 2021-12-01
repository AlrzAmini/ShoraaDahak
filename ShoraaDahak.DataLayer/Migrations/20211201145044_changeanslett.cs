using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class changeanslett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "LetterAnswers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LetterAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LetterAnswers_UserId",
                table: "LetterAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterAnswers_Users_UserId",
                table: "LetterAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterAnswers_Users_UserId",
                table: "LetterAnswers");

            migrationBuilder.DropIndex(
                name: "IX_LetterAnswers_UserId",
                table: "LetterAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LetterAnswers");

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "LetterAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
