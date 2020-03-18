using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountsTestP.Api.Migrations
{
    public partial class ModifyMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("260bd8b0-dff8-4c50-919f-7a9afbf6a228"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc4c967f-d5a8-43c2-9654-f4fbf20dcbeb"));

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "AccountTypeName", "AccountTypeNumber", "IsActive" },
                values: new object[,]
                {
                    { new Guid("b90145c0-c5d3-46c0-8ae3-d4406ace78de"), "Плановый платеж", 1, true },
                    { new Guid("492d3e85-7a8a-4114-abbe-f93870787400"), "Резервы под обесценение по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", 23, false },
                    { new Guid("c6d2473a-4ebe-4d43-951a-ac7ed0798f54"), "Корректировки, уменьшающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам", 22, false },
                    { new Guid("6b180fdb-5793-443d-ab16-2e374ced6f5b"), "Корректировки, увеличивающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам", 21, true },
                    { new Guid("3d00cf8f-59d8-47cb-b438-1a52833817b5"), "Расчеты по расходам, связанным с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам", 20, true },
                    { new Guid("63fd82ee-f437-4b7c-9c4e-2da2e8525e0a"), "Начисленные расходы, связанные с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам", 19, false },
                    { new Guid("ae6eaae5-f9db-43fa-9890-7007add27176"), "Расчеты по прочим доходам по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", 18, false },
                    { new Guid("e574a3e0-470c-4b0f-804e-242516379089"), "Начисленные прочие доходы по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", 17, true },
                    { new Guid("6dfe61e4-fdc2-4474-92c4-95f7ef0c2ad3"), "Начисленные проценты по предоставленным (размещенным) денежным средствам", 16, true },
                    { new Guid("ad03157d-6bf3-4263-9c08-e6c733db77f3"), "Обязательства по уплате процентов", 15, false },
                    { new Guid("0fc171e2-b840-45e3-89ab-7489ed69271f"), "Резервы на возможные потери", 14, false },
                    { new Guid("454b726c-94a4-429b-ad8f-1b0a5779d1f4"), "Переоценка, увеличивающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам", 24, true },
                    { new Guid("2566cef4-e3cb-446f-8b4c-eba411711aa9"), "Требования по прочим операциям", 13, true },
                    { new Guid("3c429ddc-23cb-43a3-9df6-9e575913103d"), "Просроченный ОД Физическим лицам - нерезидентам", 11, true },
                    { new Guid("b67523a9-fdf1-46e4-9daa-178d207fe415"), "Доходы", 10, false },
                    { new Guid("cdd907dc-50eb-435b-84eb-7b2a749126d2"), "Пени", 9, true },
                    { new Guid("43733a09-39b2-4700-a6c8-e2d53faf4ac6"), "Уплата %", 8, false },
                    { new Guid("bf4b5543-3bf0-468d-b313-9bf7f524a1c5"), "Начисление %", 7, true },
                    { new Guid("154cb2f5-0f4d-474a-9776-9c02f92c6aa1"), "ОД", 6, true },
                    { new Guid("0f1a55a1-bbc6-4c37-9b99-c51a0ef69199"), "Переплата", 5, false },
                    { new Guid("f46853ed-7f37-4c83-9760-67e7f468ccae"), "Просроченные % Физическим лицам", 4, true },
                    { new Guid("ad4f2825-94fc-4fea-a9ed-2a0460316644"), "Просроченный ОД Физическим лицам", 3, true },
                    { new Guid("aeab18ba-58d8-4f25-a201-dc639d2ea821"), "Касса", 2, true },
                    { new Guid("d6d90ca7-8063-4065-943b-4ed0f6a64d0f"), "Просроченные % Физическим лицам - нерезидентам", 12, true },
                    { new Guid("ad5843de-16b5-474a-88a8-e58821de1108"), "Переоценка, уменьшающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам", 25, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f1a55a1-bbc6-4c37-9b99-c51a0ef69199"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("0fc171e2-b840-45e3-89ab-7489ed69271f"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("154cb2f5-0f4d-474a-9776-9c02f92c6aa1"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("2566cef4-e3cb-446f-8b4c-eba411711aa9"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("3c429ddc-23cb-43a3-9df6-9e575913103d"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d00cf8f-59d8-47cb-b438-1a52833817b5"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("43733a09-39b2-4700-a6c8-e2d53faf4ac6"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("454b726c-94a4-429b-ad8f-1b0a5779d1f4"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("492d3e85-7a8a-4114-abbe-f93870787400"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("63fd82ee-f437-4b7c-9c4e-2da2e8525e0a"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("6b180fdb-5793-443d-ab16-2e374ced6f5b"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("6dfe61e4-fdc2-4474-92c4-95f7ef0c2ad3"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("ad03157d-6bf3-4263-9c08-e6c733db77f3"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("ad4f2825-94fc-4fea-a9ed-2a0460316644"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("ad5843de-16b5-474a-88a8-e58821de1108"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("ae6eaae5-f9db-43fa-9890-7007add27176"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("aeab18ba-58d8-4f25-a201-dc639d2ea821"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("b67523a9-fdf1-46e4-9daa-178d207fe415"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("b90145c0-c5d3-46c0-8ae3-d4406ace78de"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("bf4b5543-3bf0-468d-b313-9bf7f524a1c5"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("c6d2473a-4ebe-4d43-951a-ac7ed0798f54"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdd907dc-50eb-435b-84eb-7b2a749126d2"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("d6d90ca7-8063-4065-943b-4ed0f6a64d0f"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("e574a3e0-470c-4b0f-804e-242516379089"));

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: new Guid("f46853ed-7f37-4c83-9760-67e7f468ccae"));

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "AccountTypeName", "AccountTypeNumber", "IsActive" },
                values: new object[,]
                {
                    { new Guid("260bd8b0-dff8-4c50-919f-7a9afbf6a228"), "Пассивный счет", 1, false },
                    { new Guid("cc4c967f-d5a8-43c2-9654-f4fbf20dcbeb"), "Активный счет ", 1, true }
                });
        }
    }
}
