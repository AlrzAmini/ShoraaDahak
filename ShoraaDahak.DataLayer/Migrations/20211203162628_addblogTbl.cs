using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class addblogTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogBody",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogImageName",
                table: "Blog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "Blog",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LittleDescription",
                table: "Blog",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubCatId",
                table: "Blog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CategoryId",
                table: "Blog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_SubCatId",
                table: "Blog",
                column: "SubCatId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_WriterId",
                table: "Blog",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_BlogCategories_CategoryId",
                table: "Blog",
                column: "CategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_BlogCategories_SubCatId",
                table: "Blog",
                column: "SubCatId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Users_WriterId",
                table: "Blog",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_BlogCategories_CategoryId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_BlogCategories_SubCatId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Users_WriterId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_CategoryId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_SubCatId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_WriterId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogBody",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogImageName",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "LittleDescription",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "SubCatId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Blog");
        }
    }
}
