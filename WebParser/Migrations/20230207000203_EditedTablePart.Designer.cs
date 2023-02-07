﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebParser.Data;

#nullable disable

namespace WebParser.Migrations
{
    [DbContext(typeof(ilcatsParserDbContext))]
    [Migration("20230207000203_EditedTablePart")]
    partial class EditedTablePart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebParser.Models.Complectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Complectations");
                });

            modelBuilder.Entity("WebParser.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Assembly")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Models");
                });

            modelBuilder.Entity("WebParser.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartsSubGroupId")
                        .HasColumnType("int");

                    b.Property<long?>("ReplacementCode")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("PartsSubGroupId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("WebParser.Models.PartsGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("ComplectationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComplectationId");

                    b.ToTable("PartsGroups");
                });

            modelBuilder.Entity("WebParser.Models.PartsSubGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartsGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartsGroupId");

                    b.ToTable("PartsSubGroups");
                });

            modelBuilder.Entity("WebParser.Models.Complectation", b =>
                {
                    b.HasOne("WebParser.Models.Model", "Model")
                        .WithMany("Complectations")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("WebParser.Models.Part", b =>
                {
                    b.HasOne("WebParser.Models.PartsSubGroup", "PartsSubGroup")
                        .WithMany("Parts")
                        .HasForeignKey("PartsSubGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartsSubGroup");
                });

            modelBuilder.Entity("WebParser.Models.PartsGroup", b =>
                {
                    b.HasOne("WebParser.Models.Complectation", "Complectation")
                        .WithMany("GroupPart")
                        .HasForeignKey("ComplectationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Complectation");
                });

            modelBuilder.Entity("WebParser.Models.PartsSubGroup", b =>
                {
                    b.HasOne("WebParser.Models.PartsGroup", "PartsGroup")
                        .WithMany("PartsSubGroups")
                        .HasForeignKey("PartsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartsGroup");
                });

            modelBuilder.Entity("WebParser.Models.Complectation", b =>
                {
                    b.Navigation("GroupPart");
                });

            modelBuilder.Entity("WebParser.Models.Model", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("WebParser.Models.PartsGroup", b =>
                {
                    b.Navigation("PartsSubGroups");
                });

            modelBuilder.Entity("WebParser.Models.PartsSubGroup", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
