using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token_expiry_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "refresh_token", "refresh_token_expiry_time", "role" },
                values: new object[,]
                {
                    { new Guid("95a0390a-64a2-4498-a972-ad7b52d7f6b8"), "linh@example.com", "Linh", "Pham", "password456", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USER" },
                    { new Guid("c08ff346-a0eb-4ff9-81b2-1c993a816984"), "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN" },
                    { new Guid("d89ec1ec-3fd4-4acd-b6f1-e763f0777d8f"), "trung@example.com", "Trung", "Nguyen", "password123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
