using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInitialRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctor_schedule_users_doctor_id",
                table: "doctor_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_doctor_working_hours_doctor_schedule_DoctorScheduleScheduleId",
                table: "doctor_working_hours");

            migrationBuilder.DropForeignKey(
                name: "FK_treatment_detail_appointment_appointment_id",
                table: "treatment_detail");

            migrationBuilder.DropIndex(
                name: "IX_treatment_detail_appointment_id",
                table: "treatment_detail");

            migrationBuilder.DropIndex(
                name: "IX_doctor_working_hours_DoctorScheduleScheduleId",
                table: "doctor_working_hours");

            migrationBuilder.DropIndex(
                name: "IX_doctor_schedule_doctor_id",
                table: "doctor_schedule");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("381f00a3-cf01-43a8-8800-54c4e246b79f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("49fd2fe3-9dc0-409f-b515-cd09cfd7b84b"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("c71d3dd1-71b1-45df-86f3-7864ec2974be"));

            migrationBuilder.DropColumn(
                name: "DoctorScheduleScheduleId",
                table: "doctor_working_hours");

            migrationBuilder.AlterColumn<string>(
                name: "appointment_id",
                table: "treatment_detail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("1d3f8ae7-2d9f-4ce2-9565-64df71890b15"), null, null, "linh@example.com", "Linh", "Pham", "password456", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)0 },
                    { new Guid("5486bdbc-7691-4991-ab42-d34d2b9977a7"), null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("b45a365a-d098-4321-a667-fcb331526ba1"), null, null, "trung@example.com", "Trung", "Nguyen", "password123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("1d3f8ae7-2d9f-4ce2-9565-64df71890b15"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("5486bdbc-7691-4991-ab42-d34d2b9977a7"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("b45a365a-d098-4321-a667-fcb331526ba1"));

            migrationBuilder.AlterColumn<string>(
                name: "appointment_id",
                table: "treatment_detail",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DoctorScheduleScheduleId",
                table: "doctor_working_hours",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("381f00a3-cf01-43a8-8800-54c4e246b79f"), null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("49fd2fe3-9dc0-409f-b515-cd09cfd7b84b"), null, null, "linh@example.com", "Linh", "Pham", "password456", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)0 },
                    { new Guid("c71d3dd1-71b1-45df-86f3-7864ec2974be"), null, null, "trung@example.com", "Trung", "Nguyen", "password123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_treatment_detail_appointment_id",
                table: "treatment_detail",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_working_hours_DoctorScheduleScheduleId",
                table: "doctor_working_hours",
                column: "DoctorScheduleScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_schedule_doctor_id",
                table: "doctor_schedule",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_schedule_users_doctor_id",
                table: "doctor_schedule",
                column: "doctor_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_working_hours_doctor_schedule_DoctorScheduleScheduleId",
                table: "doctor_working_hours",
                column: "DoctorScheduleScheduleId",
                principalTable: "doctor_schedule",
                principalColumn: "schedule_id");

            migrationBuilder.AddForeignKey(
                name: "FK_treatment_detail_appointment_appointment_id",
                table: "treatment_detail",
                column: "appointment_id",
                principalTable: "appointment",
                principalColumn: "appointment_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
