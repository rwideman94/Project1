using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations.TestDb
{
    public partial class RmOvrdrftFs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_CheckingAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CheckingAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CheckingAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OverdraftFees",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "BusinessAccountId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckingAccountId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdraftFees",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BusinessAccountId",
                table: "Transactions",
                column: "BusinessAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CheckingAccountId",
                table: "Transactions",
                column: "CheckingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_BusinessAccountId",
                table: "Transactions",
                column: "BusinessAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_CheckingAccountId",
                table: "Transactions",
                column: "CheckingAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
