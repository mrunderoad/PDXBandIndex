using Microsoft.EntityFrameworkCore.Migrations;

namespace PDXBandIndex.Migrations
{
    public partial class UserShows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Shows",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_UserId",
                table: "Shows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_AspNetUsers_UserId",
                table: "Shows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_AspNetUsers_UserId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_UserId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shows");
        }
    }
}
