using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class SpellingRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "AccountHistory");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "AccountHistory",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AccountHistory");

            migrationBuilder.AddColumn<decimal>(
                name: "Ammount",
                table: "AccountHistory",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
