using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class adtblanswerletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LetterAnswers",
                columns: table => new
                {
                    LetterAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    LetterAnswerBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterAnswers", x => x.LetterAnswerId);
                    table.ForeignKey(
                        name: "FK_LetterAnswers_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "LetterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LetterAnswers_LetterId",
                table: "LetterAnswers",
                column: "LetterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterAnswers");
        }
    }
}
