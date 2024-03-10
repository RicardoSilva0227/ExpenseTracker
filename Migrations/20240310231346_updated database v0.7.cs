using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    public partial class updateddatabasev07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrencyOption",
                table: "Settings",
                newName: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CurrencyId",
                table: "Settings",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Currency_CurrencyId",
                table: "Settings",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Currency_CurrencyId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_CurrencyId",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Settings",
                newName: "CurrencyOption");
        }
    }
}
