using Microsoft.EntityFrameworkCore.Migrations;

namespace NumizmatDictionary.Data.Migrations
{
    public partial class AddMyCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Coins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coins");
        }
    }
}
