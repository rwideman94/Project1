using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations.TestDb
{
    public partial class overdraftFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Overdraft",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Overdraft",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
