using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddLocationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Games");
        }
    }
}
