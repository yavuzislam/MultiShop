using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Message.Migrations
{
    public partial class AddSubjectToUserMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "UserMessages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "UserMessages");
        }
    }
}
