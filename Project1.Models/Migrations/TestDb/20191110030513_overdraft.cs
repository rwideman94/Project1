using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations.TestDb
{
    public partial class overdraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Overdraft",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overdraft",
                table: "AspNetUsers");
        }
    }
}
