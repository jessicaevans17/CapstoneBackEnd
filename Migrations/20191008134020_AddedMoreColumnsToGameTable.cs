using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedMoreColumnsToGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gameImageUrl",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxPlayTime",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minPlayTime",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "rulesUrl",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gameImageUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "maxPlayTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "minPlayTime",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "rulesUrl",
                table: "Games");
        }
    }
}
