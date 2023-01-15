using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiocoDizionarioBot.Migrations
{
    public partial class Commit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Groups");
        }
    }
}
