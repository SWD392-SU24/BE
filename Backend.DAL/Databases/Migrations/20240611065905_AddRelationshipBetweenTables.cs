using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipBetweenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<short>(
                name: "clinic_state",
                table: "clinic",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "appointment_id",
                table: "appointment_service",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_treatment_detail_appointment_id",
                table: "treatment_detail",
                column: "appointment_id");

            migrationBuilder.UpdateData(
                table: "clinic",
                keyColumn: "clinic_id",
                keyValue: 1,
                column: "clinic_state",
                value: (short)1);

            migrationBuilder.UpdateData(
                table: "clinic",
                keyColumn: "clinic_id",
                keyValue: 2,
                column: "clinic_state",
                value: (short)1);

            migrationBuilder.UpdateData(
                table: "clinic",
                keyColumn: "clinic_id",
                keyValue: 3,
                column: "clinic_state",
                value: (short)1);

            migrationBuilder.UpdateData(
                table: "clinic",
                keyColumn: "clinic_id",
                keyValue: 4,
                column: "clinic_state",
                value: (short)1);

            migrationBuilder.UpdateData(
                table: "clinic_feedback",
                keyColumn: "clinic_fb_id",
                keyValue: 1,
                column: "fb_date",
                value: new DateTime(2024, 6, 11, 13, 59, 3, 889, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("0e9e2696-7a28-4caf-b804-1007dfa15c40"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("228308bb-a92f-4b64-8eb0-34e5850333fc"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("2c44321b-9c64-4c9e-82c4-949d8957f31a"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("2d55d61b-7b60-4457-b786-09bcdd027b9c"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("3dfcc3d4-55b8-4951-85b9-9367e4b16ee3"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("502680e5-78a6-46db-b553-42c4daef997a"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("5f143b7a-f0b7-47c0-9a0a-98c5855b3539"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("bdd5b14c-cef8-4713-bcf0-a99eccf1c36f"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("f538bb98-0da1-458f-9404-62e0785cb339"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_service_clinic_id",
                table: "service",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_working_hours_schedule_id",
                table: "doctor_working_hours",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_schedule_doctor_id",
                table: "doctor_schedule",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_combo_service_combo_id",
                table: "combo_service",
                column: "combo_id");

            migrationBuilder.CreateIndex(
                name: "IX_combo_service_service_id",
                table: "combo_service",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_doctors_clinic_id",
                table: "clinic_doctors",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_doctors_doctor_id",
                table: "clinic_doctors",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_area_id",
                table: "clinic",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_owner_id",
                table: "clinic",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_certificate_doctor_id",
                table: "certificate",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_service_appointment_id",
                table: "appointment_service",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_service_service_id",
                table: "appointment_service",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_clinic_id",
                table: "appointment",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_customer_id",
                table: "appointment",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_clinic_clinic_id",
                table: "appointment",
                column: "clinic_id",
                principalTable: "clinic",
                principalColumn: "clinic_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_treatment_detail_appointment_id",
                table: "appointment",
                column: "appointment_id",
                principalTable: "treatment_detail",
                principalColumn: "appointment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_users_customer_id",
                table: "appointment",
                column: "customer_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_service_appointment_appointment_id",
                table: "appointment_service",
                column: "appointment_id",
                principalTable: "appointment",
                principalColumn: "appointment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_service_service_service_id",
                table: "appointment_service",
                column: "service_id",
                principalTable: "service",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_certificate_users_doctor_id",
                table: "certificate",
                column: "doctor_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinic_Area_area_id",
                table: "clinic",
                column: "area_id",
                principalTable: "Area",
                principalColumn: "area_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinic_users_owner_id",
                table: "clinic",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinic_doctors_clinic_clinic_id",
                table: "clinic_doctors",
                column: "clinic_id",
                principalTable: "clinic",
                principalColumn: "clinic_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clinic_doctors_users_doctor_id",
                table: "clinic_doctors",
                column: "doctor_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_combo_service_combo_combo_id",
                table: "combo_service",
                column: "combo_id",
                principalTable: "combo",
                principalColumn: "combo_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_combo_service_service_service_id",
                table: "combo_service",
                column: "service_id",
                principalTable: "service",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_schedule_users_doctor_id",
                table: "doctor_schedule",
                column: "doctor_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_working_hours_doctor_schedule_schedule_id",
                table: "doctor_working_hours",
                column: "schedule_id",
                principalTable: "doctor_schedule",
                principalColumn: "schedule_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_clinic_clinic_id",
                table: "service",
                column: "clinic_id",
                principalTable: "clinic",
                principalColumn: "clinic_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_clinic_clinic_id",
                table: "appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_treatment_detail_appointment_id",
                table: "appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_users_customer_id",
                table: "appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_service_appointment_appointment_id",
                table: "appointment_service");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_service_service_service_id",
                table: "appointment_service");

            migrationBuilder.DropForeignKey(
                name: "FK_certificate_users_doctor_id",
                table: "certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_clinic_Area_area_id",
                table: "clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_clinic_users_owner_id",
                table: "clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_clinic_doctors_clinic_clinic_id",
                table: "clinic_doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_clinic_doctors_users_doctor_id",
                table: "clinic_doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_combo_service_combo_combo_id",
                table: "combo_service");

            migrationBuilder.DropForeignKey(
                name: "FK_combo_service_service_service_id",
                table: "combo_service");

            migrationBuilder.DropForeignKey(
                name: "FK_doctor_schedule_users_doctor_id",
                table: "doctor_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_doctor_working_hours_doctor_schedule_schedule_id",
                table: "doctor_working_hours");

            migrationBuilder.DropForeignKey(
                name: "FK_service_clinic_clinic_id",
                table: "service");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_treatment_detail_appointment_id",
                table: "treatment_detail");

            migrationBuilder.DropIndex(
                name: "IX_service_clinic_id",
                table: "service");

            migrationBuilder.DropIndex(
                name: "IX_doctor_working_hours_schedule_id",
                table: "doctor_working_hours");

            migrationBuilder.DropIndex(
                name: "IX_doctor_schedule_doctor_id",
                table: "doctor_schedule");

            migrationBuilder.DropIndex(
                name: "IX_combo_service_combo_id",
                table: "combo_service");

            migrationBuilder.DropIndex(
                name: "IX_combo_service_service_id",
                table: "combo_service");

            migrationBuilder.DropIndex(
                name: "IX_clinic_doctors_clinic_id",
                table: "clinic_doctors");

            migrationBuilder.DropIndex(
                name: "IX_clinic_doctors_doctor_id",
                table: "clinic_doctors");

            migrationBuilder.DropIndex(
                name: "IX_clinic_area_id",
                table: "clinic");

            migrationBuilder.DropIndex(
                name: "IX_clinic_owner_id",
                table: "clinic");

            migrationBuilder.DropIndex(
                name: "IX_certificate_doctor_id",
                table: "certificate");

            migrationBuilder.DropIndex(
                name: "IX_appointment_service_appointment_id",
                table: "appointment_service");

            migrationBuilder.DropIndex(
                name: "IX_appointment_service_service_id",
                table: "appointment_service");

            migrationBuilder.DropIndex(
                name: "IX_appointment_clinic_id",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_customer_id",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("0e9e2696-7a28-4caf-b804-1007dfa15c40"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("228308bb-a92f-4b64-8eb0-34e5850333fc"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("2c44321b-9c64-4c9e-82c4-949d8957f31a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("2d55d61b-7b60-4457-b786-09bcdd027b9c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("3dfcc3d4-55b8-4951-85b9-9367e4b16ee3"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("502680e5-78a6-46db-b553-42c4daef997a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("5f143b7a-f0b7-47c0-9a0a-98c5855b3539"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("bdd5b14c-cef8-4713-bcf0-a99eccf1c36f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("f538bb98-0da1-458f-9404-62e0785cb339"));

            migrationBuilder.DropColumn(
                name: "clinic_state",
                table: "clinic");

            migrationBuilder.AlterColumn<string>(
                name: "appointment_id",
                table: "appointment_service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "clinic_feedback",
                keyColumn: "clinic_fb_id",
                keyValue: 1,
                column: "fb_date",
                value: new DateTime(2024, 6, 11, 10, 11, 36, 917, DateTimeKind.Local).AddTicks(7557));

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
    }
}
