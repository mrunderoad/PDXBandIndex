using Microsoft.EntityFrameworkCore.Migrations;

namespace PDXBandIndex.Migrations
{
    public partial class showFlyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flyer",
                table: "Shows",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flyer",
                table: "Shows");
        }
    }
}
