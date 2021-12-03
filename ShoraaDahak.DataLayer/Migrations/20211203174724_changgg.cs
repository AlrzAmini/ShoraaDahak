using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoraaDahak.DataLayer.Migrations
{
    public partial class changgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_BlogCategories_CategoryId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_BlogCategories_SubCatId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Genders_GenderId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Users_WriterId",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_WriterId",
                table: "Blogs",
                newName: "IX_Blogs_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_SubCatId",
                table: "Blogs",
                newName: "IX_Blogs_SubCatId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_GenderId",
                table: "Blogs",
                newName: "IX_Blogs_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_SubCatId",
                table: "Blogs",
                column: "SubCatId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Genders_GenderId",
                table: "Blogs",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_SubCatId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Genders_GenderId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_WriterId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterId",
                table: "Blog",
                newName: "IX_Blog_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_SubCatId",
                table: "Blog",
                newName: "IX_Blog_SubCatId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_GenderId",
                table: "Blog",
                newName: "IX_Blog_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blog",
                newName: "IX_Blog_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogId");

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
                name: "FK_Blog_Genders_GenderId",
                table: "Blog",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Users_WriterId",
                table: "Blog",
                column: "WriterId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
