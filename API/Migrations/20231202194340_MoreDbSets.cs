using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class MoreDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetail_Recipe_RecipeId",
                table: "RecipeDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDetail",
                table: "RecipeDetail");

            migrationBuilder.RenameTable(
                name: "RecipeDetail",
                newName: "RecipeDetails");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDetail_RecipeId",
                table: "RecipeDetails",
                newName: "IX_RecipeDetails_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDetails",
                table: "RecipeDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_Recipe_RecipeId",
                table: "RecipeDetails",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_Recipe_RecipeId",
                table: "RecipeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDetails",
                table: "RecipeDetails");

            migrationBuilder.RenameTable(
                name: "RecipeDetails",
                newName: "RecipeDetail");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDetails_RecipeId",
                table: "RecipeDetail",
                newName: "IX_RecipeDetail_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDetail",
                table: "RecipeDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetail_Recipe_RecipeId",
                table: "RecipeDetail",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
