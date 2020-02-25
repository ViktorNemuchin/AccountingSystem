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
                });

            modelBuilder.Entity("AccountsTestP.Domain.Models.BufferForFutureEntriesDatesModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("DestinationAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SourceAccountId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Buffer");
                });
#pragma warning restore 612, 618
        }
    }
}
