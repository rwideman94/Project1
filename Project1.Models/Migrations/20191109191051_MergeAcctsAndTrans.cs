using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Models.Migrations
{
    public partial class MergeAcctsAndTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckingAccounts_AspNetUsers_AppUserId",
                table: "CheckingAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingTransactions_CheckingAccounts_CheckingAccountID",
                table: "CheckingTransactions");

            migrationBuilder.DropTable(
                name: "BusinessTransactions");

            migrationBuilder.DropTable(
                name: "BusinessAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingTransactions",
                table: "CheckingTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingAccounts",
                table: "CheckingAccounts");

            migrationBuilder.RenameTable(
                name: "CheckingTransactions",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "CheckingAccounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "CheckingAccountID",
                table: "Transactions",
                newName: "CheckingAccountId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CheckingTransactions_CheckingAccountID",
            //    table: "Transactions",
            //    newName: "IX_Transactions_CheckingAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckingAccounts_AppUserId",
                table: "Accounts",
                newName: "IX_Accounts_AppUserId1");

            migrationBuilder.AlterColumn<int>(
                name: "CheckingAccountId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BusinessAccountId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Accounts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OverdraftFees",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BusinessAccountId",
                table: "Transactions",
                column: "BusinessAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AppUserId",
                table: "Accounts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId1",
                table: "Accounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId1",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_CheckingAccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AppUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BusinessAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OverdraftFees",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "CheckingTransactions");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "CheckingAccounts");

            migrationBuilder.RenameColumn(
                name: "CheckingAccountId",
                table: "CheckingTransactions",
                newName: "CheckingAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CheckingAccountId",
                table: "CheckingTransactions",
                newName: "IX_CheckingTransactions_CheckingAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_AppUserId1",
                table: "CheckingAccounts",
                newName: "IX_CheckingAccounts_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "CheckingAccountID",
                table: "CheckingTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CheckingAccounts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingTransactions",
                table: "CheckingTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingAccounts",
                table: "CheckingAccounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BusinessAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OverdraftFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessAccounts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BusinessAccountID = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTransactions_BusinessAccounts_BusinessAccountID",
                        column: x => x.BusinessAccountID,
                        principalTable: "BusinessAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAccounts_AppUserId",
                table: "BusinessAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTransactions_BusinessAccountID",
                table: "BusinessTransactions",
                column: "BusinessAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingAccounts_AspNetUsers_AppUserId",
                table: "CheckingAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
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
    }
}
