using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class DumpDataForCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("50f88073-9c33-4037-a824-95925ba55f98"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("564ba85a-8e22-4aa2-a464-b1a682b6598b"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("6f0d4b83-c3d6-462f-8368-b469326746cc"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("99ad086c-be82-402d-8383-686edd9fc04a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("9e51f5de-8b09-4957-88b9-5eadb1f19e5c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("d82f2cd7-300f-4903-b681-56380d71cc25"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("dc6f432b-7672-49f2-a5be-8d3f833b7f10"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("f827328a-8efd-4da7-bb39-2cf32dcaf8dd"));

            migrationBuilder.UpdateData(
                table: "clinic_feedback",
                keyColumn: "clinic_fb_id",
                keyValue: 1,
                column: "fb_date",
                value: new DateTime(2024, 6, 11, 22, 6, 24, 368, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("033f3d07-b144-4332-b449-470f93a2c56e"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), "Tp.Hồ Chí Minh", null, new DateTime(2003, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "baongoc1234@gmail.com", "Ngọc", "Bảo", "12345!", "0912345678", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("35115282-c79c-4c88-89b1-cb9a940e0115"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("57b45576-2a11-4751-acec-4d6a4847d0ee"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("a294d2cf-413d-486d-aa8c-b623555d2ac0"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("b2891139-fa92-41ee-bc2f-5fb4f2fea682"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("cd1a49cd-0e2e-4a3e-8518-77be78230259"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("ec0fd3bf-8d13-444a-bdac-923cfa091310"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("fe3589a9-c44c-4af8-949c-e613be711d96"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 }
                });

            migrationBuilder.InsertData(
                table: "certificate",
                columns: new[] { "certificate_id", "certificate_image", "certificate_name", "doctor_id", "expired_date", "issued_date" },
                values: new object[,]
                {
                    { 1, "https://example.com/certificateImage.jpg", "Medical Practice License", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2024, 6, 11, 22, 6, 24, 368, DateTimeKind.Local).AddTicks(9923) },
                    { 2, "https://example.com/certificateImage2.jpg", "Dental Surgery Certification", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "https://example.com/certificateImage3.jpg", "Emergency Medicine Training", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "certificate",
                keyColumn: "certificate_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "certificate",
                keyColumn: "certificate_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "certificate",
                keyColumn: "certificate_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("033f3d07-b144-4332-b449-470f93a2c56e"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("35115282-c79c-4c88-89b1-cb9a940e0115"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("57b45576-2a11-4751-acec-4d6a4847d0ee"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a294d2cf-413d-486d-aa8c-b623555d2ac0"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("b2891139-fa92-41ee-bc2f-5fb4f2fea682"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("cd1a49cd-0e2e-4a3e-8518-77be78230259"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("ec0fd3bf-8d13-444a-bdac-923cfa091310"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("fe3589a9-c44c-4af8-949c-e613be711d96"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"));

            migrationBuilder.UpdateData(
                table: "clinic_feedback",
                keyColumn: "clinic_fb_id",
                keyValue: 1,
                column: "fb_date",
                value: new DateTime(2024, 6, 11, 15, 28, 14, 808, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("50f88073-9c33-4037-a824-95925ba55f98"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("564ba85a-8e22-4aa2-a464-b1a682b6598b"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("6f0d4b83-c3d6-462f-8368-b469326746cc"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("99ad086c-be82-402d-8383-686edd9fc04a"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("9e51f5de-8b09-4957-88b9-5eadb1f19e5c"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("d82f2cd7-300f-4903-b681-56380d71cc25"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("dc6f432b-7672-49f2-a5be-8d3f833b7f10"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("f827328a-8efd-4da7-bb39-2cf32dcaf8dd"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 }
                });
        }
    }
}
