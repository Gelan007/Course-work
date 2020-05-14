using Microsoft.EntityFrameworkCore.Migrations;

namespace NumizmatDictionary.Data.Migrations
{
    public partial class AddCoinsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinsName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    FaceValue = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    MetalOrAlloy = table.Column<string>(nullable: true),
                    NumberOfCoins = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    AvailabilityInCollection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Collectors");
        }
    }
}
