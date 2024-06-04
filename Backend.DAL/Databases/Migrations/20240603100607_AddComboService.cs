using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddComboService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("01430bf6-342e-49cf-b343-13458d486a20"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("102fff27-75c5-47d6-adb7-3e5ea5204006"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("133f3d90-33da-43e8-9e77-2b096da83878"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("1e0828e2-7e5b-4cf0-9fd0-24d638e666f3"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("455159e0-9d66-493c-a9cf-6b1083d35d92"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("4b2ac503-d43a-46e8-b97c-5ea0aa6908cc"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("6c5c43e8-daa9-42b1-96ba-56b567b29186"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("fcd3473f-711d-4180-8616-c6e1f62e2f8f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("fedd385a-8041-4933-988d-54e0a9d7e527"));

            migrationBuilder.InsertData(
                table: "combo",
                columns: new[] { "combo_id", "combo_name", "combo_description" },
                values: new object[,]
                {
                    { 1, "Gói ưu đãi Răng sạch miệng thơm", "Gồm Khám răng tổng quát và Vệ sinh răng" },
                    { 2, "Gói ưu đãi nhổ răng", "Gồm Khám răng tổng quát và nhổ răng" },
                    { 3, "Gói giành cho người lớn tuổi", "Gồm Khám răng tổng quát và Trám răng" },
                    { 4, "Gói Răng bạn thưa hãy lựa gói này", "Gồm Khám răng tổng quát và Niềng răng" }
                });

            migrationBuilder.InsertData(
                table: "combo_service",
                columns: new[] { "combo_service_id", "combo_id", "service_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 4, 4 },
                    { 4, 3, 3 },
                    { 5, 2, 5 },
                    { 6, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "service",
                columns: new[] { "service_id", "clinic_id", "description", "service_price", "service_name" },
                values: new object[,]
                {
                    { 1, 1, "Bệnh nhân sẽ được khám tổng quát để biết được tình trạng sức khỏe răng miệng", 50.0, "Khám răng tổng quát" },
                    { 2, 2, "Đánh bóng, lấy cao răng", 80.0, "Vệ sinh răng" },
                    { 3, 3, "Trám răng để răng đẹp và tốt hơn", 70.0, "Trám răng" },
                    { 4, 1, "Nếu răng thưa bị thưa hay mọc lệch, hãy niềng răng để có một hàm răng đẹp hơn", 100.0, "Niềng răng" },
                    { 5, 2, "Nhổ răng sữa, răng khôn", 120.0, "Nhổ răng" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("1d5e28bd-19fb-4eb5-8ad2-d4be68a6d5a2"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("37030f57-4de5-4835-951b-955d6ed227a6"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("61e0314c-8eff-48ee-ac71-cd10e36f1590"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("a4f3b037-dbcf-4539-8209-a2efd141d64d"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("a6df0c23-d12a-4718-9e55-d1d268d4a7ee"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("a8d24f09-03f2-42cd-b727-03b96ab7b600"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("b66076ca-15b4-44ae-b955-79638349828c"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("c4118b70-cc3b-43b5-91af-99d7c073e782"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("c85897d4-4e1d-4a88-b44e-fb0236ace39a"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("1d5e28bd-19fb-4eb5-8ad2-d4be68a6d5a2"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("37030f57-4de5-4835-951b-955d6ed227a6"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("61e0314c-8eff-48ee-ac71-cd10e36f1590"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a4f3b037-dbcf-4539-8209-a2efd141d64d"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a6df0c23-d12a-4718-9e55-d1d268d4a7ee"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("a8d24f09-03f2-42cd-b727-03b96ab7b600"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("b66076ca-15b4-44ae-b955-79638349828c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("c4118b70-cc3b-43b5-91af-99d7c073e782"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("c85897d4-4e1d-4a88-b44e-fb0236ace39a"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("01430bf6-342e-49cf-b343-13458d486a20"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("102fff27-75c5-47d6-adb7-3e5ea5204006"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("133f3d90-33da-43e8-9e77-2b096da83878"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("1e0828e2-7e5b-4cf0-9fd0-24d638e666f3"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("455159e0-9d66-493c-a9cf-6b1083d35d92"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("4b2ac503-d43a-46e8-b97c-5ea0aa6908cc"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("6c5c43e8-daa9-42b1-96ba-56b567b29186"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("fcd3473f-711d-4180-8616-c6e1f62e2f8f"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("fedd385a-8041-4933-988d-54e0a9d7e527"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 }
                });
        }
    }
}
