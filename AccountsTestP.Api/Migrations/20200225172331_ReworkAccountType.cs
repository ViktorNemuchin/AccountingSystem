using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AccountsTestP.Api.Migrations
{
    public partial class ReworkAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "AccountTypeModelId",
                table: "AccountTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AccountTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeNumber",
                table: "AccountTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "AccountTypeNumber",
                table: "AccountTypes");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeModelId",
                table: "AccountTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "AccountTypeModelId");
        }
    }
}
