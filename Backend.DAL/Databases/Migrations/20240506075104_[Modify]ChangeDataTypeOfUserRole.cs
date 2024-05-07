using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChangeDataTypeOfUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("0b9ef125-63ec-4f04-a5b5-811dd470ceb3"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("12fca1ab-4ee0-430d-b654-c6b28d072ca0"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("ce02875f-0111-48cf-8e44-233391925d0b"));

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "refresh_token", "refresh_token_expiry_time", "role" },
                values: new object[,]
                {
                    { new Guid("25d11280-d035-4508-b36e-8f16406cd338"), "trung@example.com", "Trung", "Nguyen", "password123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USER" },
                    { new Guid("603fe1de-d103-41a1-af97-ced565cbac5c"), "adminexample@gmail.com", null, null, "reallystrongpass!123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN" },
                    { new Guid("c078be03-6a7e-44cd-8ac2-3160e8225f16"), "linh@example.com", "Linh", "Pham", "password456", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("25d11280-d035-4508-b36e-8f16406cd338"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("603fe1de-d103-41a1-af97-ced565cbac5c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("c078be03-6a7e-44cd-8ac2-3160e8225f16"));

            migrationBuilder.AlterColumn<int>(
                name: "role",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "refresh_token", "refresh_token_expiry_time", "role" },
                values: new object[,]
                {
                    { new Guid("0b9ef125-63ec-4f04-a5b5-811dd470ceb3"), "linh@example.com", "Linh", "Pham", "password456", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("12fca1ab-4ee0-430d-b654-c6b28d072ca0"), "adminexample@gmail.com", null, null, "reallystrongpass!123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ce02875f-0111-48cf-8e44-233391925d0b"), "trung@example.com", "Trung", "Nguyen", "password123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }
    }
}
