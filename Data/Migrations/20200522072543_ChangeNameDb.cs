using Microsoft.EntityFrameworkCore.Migrations;

namespace NumizmatDictionary.Data.Migrations
{
    public partial class ChangeNameDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Coins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Coins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
