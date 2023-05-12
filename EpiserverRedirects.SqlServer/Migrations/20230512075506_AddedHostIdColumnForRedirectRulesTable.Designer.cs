﻿// <auto-generated />
using System;
using Forte.EpiserverRedirects.SqlServer.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forte.EpiserverRedirects.SqlServer.Migrations
{
    [DbContext(typeof(SqlRedirectRulesDbContext))]
    [Migration("20230512075506_AddedHostIdColumnForRedirectRulesTable")]
    partial class AddedHostIdColumnForRedirectRulesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forte.EpiserverRedirects.EntityFramework.Model.RedirectRuleEntity", b =>
                {
                    b.Property<Guid>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NewPattern")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldPattern")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("RedirectOrigin")
                        .HasColumnType("int");

                    b.Property<int>("RedirectRuleType")
                        .HasColumnType("int");

                    b.Property<int>("RedirectType")
                        .HasColumnType("int");

                    b.HasKey("RuleId");

                    b.HasIndex("RuleId")
                        .IsUnique();

                    b.ToTable("RedirectRules");
                });
#pragma warning restore 612, 618
        }
    }
}
