using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDataComboService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 1,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Khám tư vấn", "Mục gồm các vấn đề liên quan đến Khám tư vấn" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 2,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Nha khoa tổng quát", "Mục gồm các vấn đề liên quan đến Nha khoa tổng quát" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 3,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Nha khoa trẻ em", "Mục gồm các vấn đề liên quan đến Nha khoa trẻ em" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 4,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Chỉnh nha", "Mục gồm các vấn đề liên quan đến Chỉnh nha" });

            migrationBuilder.InsertData(
                table: "combo",
                columns: new[] { "combo_id", "combo_name", "combo_description" },
                values: new object[,]
                {
                    { 5, "Cấy ghép Implant", "Mục gồm các vấn đề liên quan đến Cấy ghép Implant" },
                    { 6, "Nhổ răng", "Mục gồm các vấn đề liên quan đến Nhổ răng" },
                    { 7, "Nha khoa thẩm mỹ", "Mục gồm các vấn đề liên quan đến Nha khoa thẩm mỹ" },
                    { 8, "Khác", "Mục gồm các vấn đề khác ngoài các mục đã có" }
                });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 3,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 4,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 6,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "combo_service",
                columns: new[] { "combo_service_id", "combo_id", "service_id" },
                values: new object[,]
                {
                    { 7, 2, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 2, 10 },
                    { 11, 2, 11 },
                    { 12, 2, 12 },
                    { 13, 3, 13 },
                    { 14, 3, 14 },
                    { 15, 3, 15 },
                    { 16, 3, 16 },
                    { 17, 3, 17 },
                    { 18, 3, 18 },
                    { 19, 3, 19 },
                    { 20, 4, 20 },
                    { 21, 4, 21 },
                    { 22, 4, 22 },
                    { 23, 4, 23 },
                    { 24, 4, 24 },
                    { 25, 4, 25 },
                    { 26, 5, 26 },
                    { 27, 5, 27 },
                    { 28, 5, 28 },
                    { 29, 5, 29 },
                    { 30, 5, 30 },
                    { 31, 5, 31 },
                    { 32, 6, 32 },
                    { 33, 6, 33 },
                    { 34, 6, 34 },
                    { 35, 6, 35 },
                    { 36, 6, 36 },
                    { 37, 6, 37 },
                    { 38, 7, 38 },
                    { 39, 7, 39 },
                    { 40, 7, 40 },
                    { 41, 7, 41 },
                    { 42, 7, 42 },
                    { 43, 7, 43 },
                    { 44, 7, 44 },
                    { 45, 7, 45 },
                    { 46, 8, 46 },
                    { 47, 8, 47 },
                    { 48, 1, 48 },
                    { 49, 1, 49 },
                    { 50, 2, 50 },
                    { 51, 2, 51 },
                    { 52, 1, 52 },
                    { 53, 1, 53 },
                    { 54, 2, 54 },
                    { 55, 2, 55 },
                    { 56, 1, 56 },
                    { 57, 1, 57 },
                    { 58, 2, 58 },
                    { 59, 2, 59 }
                });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 1,
                columns: new[] { "description", "service_name" },
                values: new object[] { "Bệnh nhân sẽ được Chụp Xquang CBCT", "Chụp Xquang CBCT" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 2,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 1, "Bệnh nhân sẽ được Chụp Xquang Cephalometric", "Chụp Xquang Cephalometric" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 3,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 1, "Bệnh nhân sẽ được khám tư vấn", "Khám tư vấn" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 4,
                columns: new[] { "description", "service_name" },
                values: new object[] { "Bệnh nhân sẽ được Chụp Xquang Panorama", "Chụp Xquang Panorama" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 5,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 1, "Máng chống ê buốt cho răng", "Máng chống ê buốt" });

            migrationBuilder.InsertData(
                table: "service",
                columns: new[] { "service_id", "clinic_id", "description", "service_price", "service_name" },
                values: new object[,]
                {
                    { 6, 1, "Máng dành cho bệnh nhân nha chu", 50.0, "Máng nha chu" },
                    { 7, 1, "Lấy cao răng", 80.0, "Lấy cao răng 2 hàm" },
                    { 8, 1, "Trám răng để răng đẹp và tốt hơn", 70.0, "Điều trị tủy" },
                    { 9, 1, "Hàn thẩm mỹ cho bệnh nhân", 100.0, "Hàn thẩm mỹ" },
                    { 10, 1, "Hàn cổ răng cho bệnh nhân", 120.0, "Hàn cổ răng" },
                    { 11, 1, "Hàn răng sâu cho bệnh nhân", 120.0, "Hàn răng sâu" },
                    { 12, 1, "Tiểu phẫu dành cho bệnh nhân nha chu", 120.0, "Tiểu phẫu nha chu" },
                    { 13, 1, "Ngừa sâu răng cho trẻ em", 120.0, "Sealant ngừa sâu răng" },
                    { 14, 1, "Ngừa sâu răng cho trẻ em", 120.0, "Bôi fluoride dự phòng sâu răng" },
                    { 15, 1, "Điều trị tủy răng cho trẻ em", 120.0, "Điều trị tủy răng sữa nhiều chân" },
                    { 16, 1, "Điều trị tủy răng cho trẻ em", 120.0, "Điều trị tủy răng sữa 1 chân" },
                    { 17, 1, "Hàn răng sữa cho trẻ em", 120.0, "Hàn răng sữa" },
                    { 18, 1, "Nhổ răng tiêm thuốc tê cho trẻ em", 120.0, "Nhổ răng sữa tê tiêm" },
                    { 19, 1, "Nhổ răng bôi thuốc tê cho trẻ em", 120.0, "Nhổ răng sữa tê bôi" },
                    { 20, 1, "Hàm Twinblock", 120.0, "Hàm Twinblock" },
                    { 21, 1, "Hàm nong", 120.0, "Hàm nong" },
                    { 22, 1, "Chỉnh nha bằng khay trong suốt Invisalign cho bệnh nhân", 120.0, "Chỉnh nha bằng khay trong suốt Invisalign" },
                    { 23, 1, "Chỉnh nha bằng mắc cài sứ 2 hàm cho bệnh nhân", 120.0, "Chỉnh nha bằng mắc cài sứ 2 hàm" },
                    { 24, 1, "Chỉnh nha bằng mắc cài kim loại 2 hàm cho bệnh nhân", 120.0, "Chỉnh nha bằng mắc cài kim loại 2 hàm" },
                    { 25, 1, "Hàm duy trì sau chỉnh nha cho bệnh nhân", 120.0, "Hàm duy trì sau chỉnh nha" },
                    { 26, 1, "Implant", 120.0, "Cấy Implant All-on-6" },
                    { 27, 1, "Implant", 120.0, "Cấy Implant All-on-4" },
                    { 28, 1, "Implant răng hàm", 120.0, "Cấy Implant Hàn Quốc răng hàm" },
                    { 29, 1, "Implant răng cửa", 120.0, "Cấy Implant Hàn Quốc răng cửa" },
                    { 30, 1, "Ghép xương", 120.0, "Ghép xương" },
                    { 31, 1, "Nâng xoang", 120.0, "Nâng xoang" },
                    { 32, 1, "Nhổ răng khôn", 120.0, "Nhổ răng khôn (răng số 8) mọc ngầm" },
                    { 33, 1, "Nhổ răng khôn", 120.0, "Nhổ răng khôn (răng số 8) mọc lệch" },
                    { 34, 1, "Nhổ răng khôn", 120.0, "Nhổ răng khôn (răng số 8) mọc thẳng" },
                    { 35, 1, "Nhổ chân răng", 120.0, "Nhổ chân răng" },
                    { 36, 1, "Nhổ răng hàm", 120.0, "Nhổ răng hàm" },
                    { 37, 1, "Nhổ răng cửa", 120.0, "Nhổ răng cửa" },
                    { 38, 1, "Onlay/inlay sứ kim loại", 120.0, "Onlay/inlay sứ kim loại" },
                    { 39, 1, "Hàm nhựa dẻo tháo lắp", 120.0, "Hàm nhựa dẻo tháo lắp" },
                    { 40, 1, "Chụp sứ/veneer sứ Emax HT", 120.0, "Chụp sứ/veneer sứ Emax HT" },
                    { 41, 1, "Chụp sứ/Veneer sứ Emax", 120.0, "Chụp sứ/Veneer sứ Emax" },
                    { 42, 1, "Chụp sứ Zirconia", 120.0, "Chụp sứ Zirconia" },
                    { 43, 1, "Chụp sứ Titan", 120.0, "Chụp sứ Titan" },
                    { 44, 1, "Chụp sứ kim loại thường", 120.0, "Chụp sứ kim loại thường" },
                    { 45, 1, "Chụp composite", 120.0, "Chụp composite" },
                    { 46, 1, "Phẫu thuật tạo hình lợi", 120.0, "Phẫu thuật tạo hình lợi" },
                    { 47, 1, "Hàm điều chỉnh khớp thái dương hàm", 120.0, "Hàm điều chỉnh khớp thái dương hàm" },
                    { 48, 2, "Khám và tư vấn", 120.0, "Khám tư vấn" },
                    { 49, 2, "Chụp Xquang", 120.0, "Chụp Xquang" },
                    { 50, 2, "Lấy cao răng", 120.0, "Lấy cao răng" },
                    { 51, 2, "Máng chống ê buốt", 120.0, "Máng chống ê buốt" },
                    { 52, 3, "Khám và tư vấn", 120.0, "Khám tư vấn" },
                    { 53, 3, "Chụp Xquang", 120.0, "Chụp Xquang" },
                    { 54, 3, "Lấy cao răng", 120.0, "Lấy cao răng" },
                    { 55, 3, "Máng chống ê buốt", 120.0, "Máng chống ê buốt" },
                    { 56, 4, "Khám và tư vấn", 120.0, "Khám tư vấn" },
                    { 57, 4, "Chụp Xquang", 120.0, "Chụp Xquang" },
                    { 58, 4, "Lấy cao răng", 120.0, "Lấy cao răng" },
                    { 59, 4, "Máng chống ê buốt", 120.0, "Máng chống ê buốt" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 59);

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

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 1,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Gói ưu đãi Răng sạch miệng thơm", "Gồm Khám răng tổng quát và Vệ sinh răng" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 2,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Gói ưu đãi nhổ răng", "Gồm Khám răng tổng quát và nhổ răng" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 3,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Gói giành cho người lớn tuổi", "Gồm Khám răng tổng quát và Trám răng" });

            migrationBuilder.UpdateData(
                table: "combo",
                keyColumn: "combo_id",
                keyValue: 4,
                columns: new[] { "combo_name", "combo_description" },
                values: new object[] { "Gói Răng bạn thưa hãy lựa gói này", "Gồm Khám răng tổng quát và Niềng răng" });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 3,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 4,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "combo_service",
                keyColumn: "combo_service_id",
                keyValue: 6,
                columns: new[] { "combo_id", "service_id" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 1,
                columns: new[] { "description", "service_name" },
                values: new object[] { "Bệnh nhân sẽ được khám tổng quát để biết được tình trạng sức khỏe răng miệng", "Khám răng tổng quát" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 2,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 2, "Đánh bóng, lấy cao răng", "Vệ sinh răng" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 3,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 3, "Trám răng để răng đẹp và tốt hơn", "Trám răng" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 4,
                columns: new[] { "description", "service_name" },
                values: new object[] { "Nếu răng thưa bị thưa hay mọc lệch, hãy niềng răng để có một hàm răng đẹp hơn", "Niềng răng" });

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "service_id",
                keyValue: 5,
                columns: new[] { "clinic_id", "description", "service_name" },
                values: new object[] { 2, "Nhổ răng sữa, răng khôn", "Nhổ răng" });

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
    }
}
