using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessAccounts_AspNetUsers_AppUserId",
                table: "BusinessAccounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BusinessAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BusinessAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdraftFees",
                table: "BusinessAccounts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {   
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransTime = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessAccountId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountId",
                        column: x => x.BusinessAccountId,
                        principalTable: "BusinessAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckingAccountId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountId",
                        column: x => x.CheckingAccountId,
                        principalTable: "CheckingAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccounts_AppUserId",
                table: "CheckingAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTransactions_BusinessAccountId",
                table: "BusinessTransactions",
                column: "BusinessAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingTransactions_CheckingAccountId",
                table: "CheckingTransactions",
                column: "CheckingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessAccounts_AspNetUsers_AppUserId",
                table: "BusinessAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingAccounts_AspNetUsers_AppUserId",
                table: "CheckingAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessAccounts_AspNetUsers_AppUserId",
                table: "BusinessAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingAccounts_AspNetUsers_AppUserId",
                table: "CheckingAccounts");

            migrationBuilder.DropTable(
                name: "BusinessTransactions");

            migrationBuilder.DropTable(
                name: "CheckingTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_CheckingAccounts_AppUserId",
                table: "CheckingAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CheckingAccounts");

            migrationBuilder.DropColumn(
                name: "OverdraftFees",
                table: "BusinessAccounts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CheckingAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BusinessAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BusinessAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessAccounts_AspNetUsers_AppUserId",
                table: "BusinessAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
