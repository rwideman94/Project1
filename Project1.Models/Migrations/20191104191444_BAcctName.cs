using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations
{
    public partial class BAcctName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "BusinessAccounts",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "BusinessAccounts");
        }
    }
}
