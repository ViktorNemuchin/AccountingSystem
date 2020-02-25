using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    SourceAccountBalance = table.Column<decimal>(nullable: false),
                    DestinationAccountBalance = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    DueDate = table.Column<DateTimeOffset>(nullable: false),
                    Description = table.Column<string>(nullable: true)
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
                    AccountNumber = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountTypeName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeModelId);
                });

            migrationBuilder.CreateTable(
                name: "Buffer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SourceAccountId = table.Column<Guid>(nullable: false),
                    DestinationAccountId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    DueDate = table.Column<DateTimeOffset>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHistory");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Buffer");
        }
    }
}
