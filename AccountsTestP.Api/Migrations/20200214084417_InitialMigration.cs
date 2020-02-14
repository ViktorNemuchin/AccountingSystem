using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SourceAccountId = table.Column<Guid>(nullable: false),
                    DestinationAccountId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: false),
                    ActualDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    AccountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHistory");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
