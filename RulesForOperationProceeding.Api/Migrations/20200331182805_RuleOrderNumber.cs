using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RulesForOperationProceeding.Api.Migrations
{
    public partial class RuleOrderNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "OperationTypes");

            migrationBuilder.AddColumn<int>(
                name: "RuleOrderNumber",
                table: "Rules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RuleOrderNumber",
                table: "Rules");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DueDate",
                table: "OperationTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
