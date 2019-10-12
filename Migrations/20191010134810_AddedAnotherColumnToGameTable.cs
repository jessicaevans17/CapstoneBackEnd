using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedAnotherColumnToGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "privateResidence",
                table: "Games",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "privateResidence",
                table: "Games");
        }
    }
}
