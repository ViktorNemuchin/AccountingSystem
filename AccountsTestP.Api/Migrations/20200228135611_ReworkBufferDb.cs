using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class ReworkBufferDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "SourceAccountId",
                table: "Buffer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActualDate",
                table: "Buffer",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "DestinationAccountNumber",
                table: "Buffer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountType",
                table: "Buffer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SourceAccountNumber",
                table: "Buffer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceAccountType",
                table: "Buffer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDate",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "DestinationAccountNumber",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "DestinationAccountType",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "SourceAccountNumber",
                table: "Buffer");

            migrationBuilder.DropColumn(
                name: "SourceAccountType",
                table: "Buffer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Buffer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationAccountId",
                table: "Buffer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DueDate",
                table: "Buffer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceAccountId",
                table: "Buffer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
