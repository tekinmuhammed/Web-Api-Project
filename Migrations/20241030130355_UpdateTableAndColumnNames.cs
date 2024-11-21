using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAndColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_accounts_AccountId",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "transactions",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                newName: "IX_transactions_account_id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "cards",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_cards_AccountId",
                table: "cards",
                newName: "IX_cards_account_id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "accounts",
                newName: "account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_accounts_account_id",
                table: "cards",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_account_id",
                table: "transactions",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "account_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_accounts_account_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_account_id",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_account_id",
                table: "transactions",
                newName: "IX_transactions_AccountId");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "cards",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_cards_account_id",
                table: "cards",
                newName: "IX_cards_AccountId");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "accounts",
                newName: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_accounts_AccountId",
                table: "cards",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_AccountId",
                table: "transactions",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
