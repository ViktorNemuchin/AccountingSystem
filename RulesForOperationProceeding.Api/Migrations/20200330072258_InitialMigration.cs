using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RulesForOperationProceeding.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OperationParameterName = table.Column<string>(nullable: true),
                    OperationParameterValue = table.Column<string>(nullable: true),
                    OperationTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OperationTypeName = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SourceAccount = table.Column<string>(nullable: true),
                    DestinationAccount = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OperationTypeId = table.Column<Guid>(nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationParameters");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "Rules");
        }
    }
}
