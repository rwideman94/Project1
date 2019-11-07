using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations
{
    public partial class TransChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountId",
                table: "BusinessTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountId",
                table: "CheckingTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CheckingTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "BusinessTransactions");

            migrationBuilder.RenameColumn(
                name: "CheckingAccountId",
                table: "CheckingTransactions",
                newName: "CheckingAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckingTransactions_CheckingAccountId",
                table: "CheckingTransactions",
                newName: "IX_CheckingTransactions_CheckingAccountID");

            migrationBuilder.RenameColumn(
                name: "BusinessAccountId",
                table: "BusinessTransactions",
                newName: "BusinessAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTransactions_BusinessAccountId",
                table: "BusinessTransactions",
                newName: "IX_BusinessTransactions_BusinessAccountID");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CheckingTransactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "CheckingTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransTime",
                table: "CheckingTransactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "BusinessTransactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "BusinessTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransTime",
                table: "BusinessTransactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountID",
                table: "BusinessTransactions",
                column: "BusinessAccountID",
                principalTable: "BusinessAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountID",
                table: "CheckingTransactions",
                column: "CheckingAccountID",
                principalTable: "CheckingAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountID",
                table: "BusinessTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountID",
                table: "CheckingTransactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CheckingTransactions");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "CheckingTransactions");

            migrationBuilder.DropColumn(
                name: "TransTime",
                table: "CheckingTransactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BusinessTransactions");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "BusinessTransactions");

            migrationBuilder.DropColumn(
                name: "TransTime",
                table: "BusinessTransactions");

            migrationBuilder.RenameColumn(
                name: "CheckingAccountID",
                table: "CheckingTransactions",
                newName: "CheckingAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckingTransactions_CheckingAccountID",
                table: "CheckingTransactions",
                newName: "IX_CheckingTransactions_CheckingAccountId");

            migrationBuilder.RenameColumn(
                name: "BusinessAccountID",
                table: "BusinessTransactions",
                newName: "BusinessAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessTransactions_BusinessAccountID",
                table: "BusinessTransactions",
                newName: "IX_BusinessTransactions_BusinessAccountId");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "CheckingTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "BusinessTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountId",
                table: "BusinessTransactions",
                column: "BusinessAccountId",
                principalTable: "BusinessAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountId",
                table: "CheckingTransactions",
                column: "CheckingAccountId",
                principalTable: "CheckingAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
