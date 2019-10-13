using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedColumnToPlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Players");
        }
    }
}
