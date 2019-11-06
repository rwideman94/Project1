using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations
{
    public partial class CheckingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckingAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(maxLength: 20, nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingAccounts");
        }
    }
}
