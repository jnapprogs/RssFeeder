using Microsoft.EntityFrameworkCore.Migrations;

namespace RssFeeder.Data.Migrations
{
    public partial class RssLink_ApplicationUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "RssLinks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RssLinks_OwnerId",
                table: "RssLinks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RssLinks_AspNetUsers_OwnerId",
                table: "RssLinks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RssLinks_AspNetUsers_OwnerId",
                table: "RssLinks");

            migrationBuilder.DropIndex(
                name: "IX_RssLinks_OwnerId",
                table: "RssLinks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "RssLinks");
        }
    }
}
