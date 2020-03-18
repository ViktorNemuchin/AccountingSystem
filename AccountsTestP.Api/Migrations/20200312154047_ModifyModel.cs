using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class ModifyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "AccountTypeName", "AccountTypeNumber", "IsActive" },
                values: new object[,]
                {
                    { new Guid("260bd8b0-dff8-4c50-919f-7a9afbf6a228"), "Пассивный счет", 1, false },
                    { new Guid("cc4c967f-d5a8-43c2-9654-f4fbf20dcbeb"), "Активный счет ", 1, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("260bd8b0-dff8-4c50-919f-7a9afbf6a228"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc4c967f-d5a8-43c2-9654-f4fbf20dcbeb"));
        }
    }
}
