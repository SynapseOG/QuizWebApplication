using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizWebApplication.Data.Migrations
{
    public partial class RankingNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Rankings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Rankings");
        }
    }
}
