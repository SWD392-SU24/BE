﻿// <auto-generated />
using System;
using Backend.DAL.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.DAL.Databases.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240506035909_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Backend.BO.Commons.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("refresh_token_expiry_time");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("12fca1ab-4ee0-430d-b654-c6b28d072ca0"),
                            Email = "adminexample@gmail.com",
                            Password = "reallystrongpass!123",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("ce02875f-0111-48cf-8e44-233391925d0b"),
                            Email = "trung@example.com",
                            FirstName = "Trung",
                            LastName = "Nguyen",
                            Password = "password123",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = 2
                        },
                        new
                        {
                            Id = new Guid("0b9ef125-63ec-4f04-a5b5-811dd470ceb3"),
                            Email = "linh@example.com",
                            FirstName = "Linh",
                            LastName = "Pham",
                            Password = "password456",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
