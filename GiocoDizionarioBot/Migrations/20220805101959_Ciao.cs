using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiocoDizionarioBot.Migrations
{
    public partial class Ciao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "GamesHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WinnerId",
                table: "GamesHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "RankElement",
                columns: table => new
                {
                    PlayerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GameHistoryGameId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankElement", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_RankElement_GamesHistory_GameHistoryGameId",
                        column: x => x.GameHistoryGameId,
                        principalTable: "GamesHistory",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankElement_GameHistoryGameId",
                table: "RankElement",
                column: "GameHistoryGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankElement");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "GamesHistory");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "GamesHistory");
        }
    }
}
