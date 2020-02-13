using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class SeedAccountsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance" },
                values: new object[,]
                {
                    { 56, "45345453dfvxv", 6000.56m },
                    { 47, "456790-=dfskdf", 7000.67m },
                    { 87, "9304823742350", 125000.78m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 87);
        }
    }
}
