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
    [DbContext(typeof(DenticareContext))]
    [Migration("20240519141645_InitialDb")]
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
                        .IsRequired()
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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c08ff346-a0eb-4ff9-81b2-1c993a816984"),
                            Email = "adminexample@gmail.com",
                            FirstName = "Admin",
                            Password = "reallystrongpass!123",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("d89ec1ec-3fd4-4acd-b6f1-e763f0777d8f"),
                            Email = "trung@example.com",
                            FirstName = "Trung",
                            LastName = "Nguyen",
                            Password = "password123",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "USER"
                        },
                        new
                        {
                            Id = new Guid("95a0390a-64a2-4498-a972-ad7b52d7f6b8"),
                            Email = "linh@example.com",
                            FirstName = "Linh",
                            LastName = "Pham",
                            Password = "password456",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "USER"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
