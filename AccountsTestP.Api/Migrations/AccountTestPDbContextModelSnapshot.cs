﻿// <auto-generated />
using System;
using AccountsTestP.Data.AccountDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AccountsTestP.Api.Migrations
{
    [DbContext(typeof(AccountTestPDbContext))]
    partial class AccountTestPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AccountsTestP.Domain.Models.AccountHistoryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DestinationAccountBalance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("DestinationAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("SourceAccountBalance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SourceAccountId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("AccountHistory");
                });

            modelBuilder.Entity("AccountsTestP.Domain.Models.AccountModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<int>("AccountType")
                        .HasColumnType("integer");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AccountsTestP.Domain.Models.AccountTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountTypeName")
                        .HasColumnType("text");

                    b.Property<int>("AccountTypeNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b90145c0-c5d3-46c0-8ae3-d4406ace78de"),
                            AccountTypeName = "Плановый платеж",
                            AccountTypeNumber = 1,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("aeab18ba-58d8-4f25-a201-dc639d2ea821"),
                            AccountTypeName = "Касса",
                            AccountTypeNumber = 2,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("ad4f2825-94fc-4fea-a9ed-2a0460316644"),
                            AccountTypeName = "Просроченный ОД Физическим лицам",
                            AccountTypeNumber = 3,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("f46853ed-7f37-4c83-9760-67e7f468ccae"),
                            AccountTypeName = "Просроченные % Физическим лицам",
                            AccountTypeNumber = 4,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("0f1a55a1-bbc6-4c37-9b99-c51a0ef69199"),
                            AccountTypeName = "Переплата",
                            AccountTypeNumber = 5,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("154cb2f5-0f4d-474a-9776-9c02f92c6aa1"),
                            AccountTypeName = "ОД",
                            AccountTypeNumber = 6,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("bf4b5543-3bf0-468d-b313-9bf7f524a1c5"),
                            AccountTypeName = "Начисление %",
                            AccountTypeNumber = 7,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("43733a09-39b2-4700-a6c8-e2d53faf4ac6"),
                            AccountTypeName = "Уплата %",
                            AccountTypeNumber = 8,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("cdd907dc-50eb-435b-84eb-7b2a749126d2"),
                            AccountTypeName = "Пени",
                            AccountTypeNumber = 9,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("b67523a9-fdf1-46e4-9daa-178d207fe415"),
                            AccountTypeName = "Доходы",
                            AccountTypeNumber = 10,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("3c429ddc-23cb-43a3-9df6-9e575913103d"),
                            AccountTypeName = "Просроченный ОД Физическим лицам - нерезидентам",
                            AccountTypeNumber = 11,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("d6d90ca7-8063-4065-943b-4ed0f6a64d0f"),
                            AccountTypeName = "Просроченные % Физическим лицам - нерезидентам",
                            AccountTypeNumber = 12,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("2566cef4-e3cb-446f-8b4c-eba411711aa9"),
                            AccountTypeName = "Требования по прочим операциям",
                            AccountTypeNumber = 13,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("0fc171e2-b840-45e3-89ab-7489ed69271f"),
                            AccountTypeName = "Резервы на возможные потери",
                            AccountTypeNumber = 14,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("ad03157d-6bf3-4263-9c08-e6c733db77f3"),
                            AccountTypeName = "Обязательства по уплате процентов",
                            AccountTypeNumber = 15,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("6dfe61e4-fdc2-4474-92c4-95f7ef0c2ad3"),
                            AccountTypeName = "Начисленные проценты по предоставленным (размещенным) денежным средствам",
                            AccountTypeNumber = 16,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("e574a3e0-470c-4b0f-804e-242516379089"),
                            AccountTypeName = "Начисленные прочие доходы по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам",
                            AccountTypeNumber = 17,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("ae6eaae5-f9db-43fa-9890-7007add27176"),
                            AccountTypeName = "Расчеты по прочим доходам по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам",
                            AccountTypeNumber = 18,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("63fd82ee-f437-4b7c-9c4e-2da2e8525e0a"),
                            AccountTypeName = "Начисленные расходы, связанные с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам",
                            AccountTypeNumber = 19,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("3d00cf8f-59d8-47cb-b438-1a52833817b5"),
                            AccountTypeName = "Расчеты по расходам, связанным с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам",
                            AccountTypeNumber = 20,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("6b180fdb-5793-443d-ab16-2e374ced6f5b"),
                            AccountTypeName = "Корректировки, увеличивающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам",
                            AccountTypeNumber = 21,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("c6d2473a-4ebe-4d43-951a-ac7ed0798f54"),
                            AccountTypeName = "Корректировки, уменьшающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам",
                            AccountTypeNumber = 22,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("492d3e85-7a8a-4114-abbe-f93870787400"),
                            AccountTypeName = "Резервы под обесценение по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам",
                            AccountTypeNumber = 23,
                            IsActive = false
                        },
                        new
                        {
                            Id = new Guid("454b726c-94a4-429b-ad8f-1b0a5779d1f4"),
                            AccountTypeName = "Переоценка, увеличивающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам",
                            AccountTypeNumber = 24,
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("ad5843de-16b5-474a-88a8-e58821de1108"),
                            AccountTypeName = "Переоценка, уменьшающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам",
                            AccountTypeNumber = 25,
                            IsActive = false
                        });
                });

            modelBuilder.Entity("AccountsTestP.Domain.Models.BufferForFutureEntriesDatesModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DestinationAccountNumber")
                        .HasColumnType("text");

                    b.Property<int>("DestinationAccountType")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<string>("SourceAccountNumber")
                        .HasColumnType("text");

                    b.Property<int>("SourceAccountType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Buffer");
                });
#pragma warning restore 612, 618
        }
    }
}
