using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizWebApplication.Data.Migrations
{
    public partial class RankingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_Categories_CategoryId",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_CategoryId",
                table: "Rankings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Rankings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Rankings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_CategoryId",
                table: "Rankings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_Categories_CategoryId",
                table: "Rankings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
