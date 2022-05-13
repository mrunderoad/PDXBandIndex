using Microsoft.EntityFrameworkCore.Migrations;

namespace PDXBandIndex.Migrations
{
    public partial class favorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Shows",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Shows");
        }
    }
}
