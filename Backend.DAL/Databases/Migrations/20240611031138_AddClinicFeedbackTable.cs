using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicFeedbackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("3c9b5821-bc0a-4202-a2e0-2633cea9157b"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("67b99dd7-0da3-4695-9154-8c19e372285a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("92f00a49-091c-4c7d-9f6e-2bc757df3a0c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("9c29e297-55ee-4d15-8fef-999b110f0251"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a2e8a185-0f2d-42b9-b6f0-bb603b2c8431"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a37f86b4-52e1-4a10-9e83-7f2204406e65"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("b86d9827-9214-4d65-9b96-9234c4f293e1"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("d2b05a1d-5636-4319-af49-194cf76ccf34"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("ee48b4bf-a2fc-46ef-87ef-588fd846ff0c"));

            migrationBuilder.CreateTable(
                name: "clinic_feedback",
                columns: table => new
                {
                    clinic_fb_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    rating = table.Column<short>(type: "smallint", nullable: false),
                    fb_description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fb_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_feedback", x => x.clinic_fb_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "clinic_feedback",
                columns: new[] { "clinic_fb_id", "clinic_id", "customer_id", "fb_date", "fb_description", "rating" },
                values: new object[,]
                {
                    { 1, 1, new Guid("4b2ac503-d43a-46e8-b97c-5ea0aa6908cc"), new DateTime(2024, 6, 11, 10, 11, 36, 917, DateTimeKind.Local).AddTicks(7557), "The clinic was clean and the staff were courteous, but the waiting time was longer than expected.", (short)3 },
                    { 2, 2, new Guid("4b2ac503-d43a-46e8-b97c-5ea0aa6908cc"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent service! The doctor was very thorough and answered all my questions.", (short)2 },
                    { 3, 3, new Guid("4b2ac503-d43a-46e8-b97c-5ea0aa6908cc"), new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The clinic environment was good, but the appointment was delayed by 30 minutes.", (short)4 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("1020d42b-c2b6-4615-96f1-3e4f36420b8f"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("18728392-fce6-491c-86e6-6d662212a3d9"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("205034b8-3fe2-4047-9dac-90c06b73757f"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("233ab089-425f-4cfe-9f7f-fec750083c47"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("3dda6601-fff6-48ec-9133-03ba07133400"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("54030f14-f364-4113-b2b0-85db28fa46a5"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("5ddc8bd2-de75-4062-96c4-808cd90ee264"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("ba970efc-ae6b-411f-9928-1fc9b3c92c90"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("ece94aff-e8f1-4c58-8869-270d2bbb22f7"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinic_feedback");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("1020d42b-c2b6-4615-96f1-3e4f36420b8f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("18728392-fce6-491c-86e6-6d662212a3d9"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("205034b8-3fe2-4047-9dac-90c06b73757f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("233ab089-425f-4cfe-9f7f-fec750083c47"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("3dda6601-fff6-48ec-9133-03ba07133400"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("54030f14-f364-4113-b2b0-85db28fa46a5"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("5ddc8bd2-de75-4062-96c4-808cd90ee264"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("ba970efc-ae6b-411f-9928-1fc9b3c92c90"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("ece94aff-e8f1-4c58-8869-270d2bbb22f7"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("3c9b5821-bc0a-4202-a2e0-2633cea9157b"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("67b99dd7-0da3-4695-9154-8c19e372285a"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("92f00a49-091c-4c7d-9f6e-2bc757df3a0c"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("9c29e297-55ee-4d15-8fef-999b110f0251"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("a2e8a185-0f2d-42b9-b6f0-bb603b2c8431"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("a37f86b4-52e1-4a10-9e83-7f2204406e65"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("b86d9827-9214-4d65-9b96-9234c4f293e1"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("d2b05a1d-5636-4319-af49-194cf76ccf34"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("ee48b4bf-a2fc-46ef-87ef-588fd846ff0c"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 }
                });
        }
    }
}
