using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransactionChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transactions",
                newName: "TargetAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                newName: "IX_Transactions_TargetAccountId");

            migrationBuilder.AddColumn<long>(
                name: "SourceAccountId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_TargetAccountId",
                table: "Transactions",
                column: "TargetAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_TargetAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceAccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TargetAccountId",
                table: "Transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TargetAccountId",
                table: "Transactions",
                newName: "IX_Transactions_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
