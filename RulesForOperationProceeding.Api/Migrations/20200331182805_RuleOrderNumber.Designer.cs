﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;

namespace RulesForOperationProceeding.Api.Migrations
{
    [DbContext(typeof(RulesForOperationProceedingDataDbContext))]
    [Migration("20200331182805_RuleOrderNumber")]
    partial class RuleOrderNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RulesForOperationProceeding.Domain.Models.OperationParameterModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OperationParameterName")
                        .HasColumnType("text");

                    b.Property<string>("OperationParameterValue")
                        .HasColumnType("text");

                    b.Property<Guid>("OperationTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("OperationParameters");
                });

            modelBuilder.Entity("RulesForOperationProceeding.Domain.Models.OperationTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OperationTypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("RulesForOperationProceeding.Domain.Models.RulesModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DestinationAccount")
                        .HasColumnType("text");

                    b.Property<string>("Formula")
                        .HasColumnType("text");

                    b.Property<Guid>("OperationTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("RuleOrderNumber")
                        .HasColumnType("integer");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });
#pragma warning restore 612, 618
        }
    }
}
