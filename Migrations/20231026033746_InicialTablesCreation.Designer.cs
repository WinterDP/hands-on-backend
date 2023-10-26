﻿// <auto-generated />
using System;
using EventsLogger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventsLogger.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231026033746_InicialTablesCreation")]
    partial class InicialTablesCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventsLogger.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string[]>("Files")
                        .HasColumnType("text[]");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Worker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("EventsLogger.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string[]>("Entries")
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedDate")
                        .HasColumnType("date");

                    b.Property<string[]>("Users")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EventsLogger.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Project")
                        .HasColumnType("text[]");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7f43b3c0-bfb5-49d0-a9e5-3aa9eeb33e94"),
                            CreatedDate = new DateOnly(1, 1, 1),
                            Email = "admin@admin.com",
                            Name = "admin",
                            Password = "admin",
                            PhotoPath = "",
                            Role = "admin",
                            UpdatedDate = new DateOnly(1, 1, 1)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
