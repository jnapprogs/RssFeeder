using Microsoft.EntityFrameworkCore.Migrations;

namespace RssFeeder.Data.Migrations
{
    public partial class AddedLinkNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RssLinks",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RssLinks");
        }
    }
}
