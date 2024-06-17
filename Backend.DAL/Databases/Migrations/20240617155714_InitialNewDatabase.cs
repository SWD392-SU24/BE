using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class InitialNewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    area_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    area_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.area_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dentist",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    citizen_id = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_of_birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sex = table.Column<short>(type: "smallint", nullable: false),
                    refresh_token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token_expiry_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dentist", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "treatment_detail",
                columns: table => new
                {
                    treatment_detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    appointment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    details = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatment_detail", x => x.treatment_detail_id);
                    table.UniqueConstraint("AK_treatment_detail_appointment_id", x => x.appointment_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
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
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    citizen_id = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_of_birth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sex = table.Column<short>(type: "smallint", nullable: false),
                    role = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token_expiry_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificate",
                columns: table => new
                {
                    certificate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    certificate_name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    certificate_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    issued_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    expired_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    certificate_image = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dentist_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificate", x => x.certificate_id);
                    table.ForeignKey(
                        name: "FK_certificate_dentist_dentist_id",
                        column: x => x.dentist_id,
                        principalTable: "dentist",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dentist_schedule",
                columns: table => new
                {
                    schedule_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    working_date = table.Column<DateOnly>(type: "date", nullable: true),
                    doctor_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dentist_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_dentist_schedule_dentist_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "dentist",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clinic",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clinic_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    license_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    clinic_address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    clinic_phone_number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    no_of_employees = table.Column<int>(type: "int", nullable: false),
                    owner_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    area_id = table.Column<int>(type: "int", nullable: false),
                    clinic_state = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic", x => x.clinic_id);
                    table.ForeignKey(
                        name: "FK_clinic_area_area_id",
                        column: x => x.area_id,
                        principalTable: "area",
                        principalColumn: "area_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_user_owner_id",
                        column: x => x.owner_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dentist_working_hours",
                columns: table => new
                {
                    working_hour_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    schedule_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dentist_working_hours", x => x.working_hour_id);
                    table.ForeignKey(
                        name: "FK_dentist_working_hours_dentist_schedule_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "dentist_schedule",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    appointment_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    appointment_date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    appointment_type = table.Column<int>(type: "int", nullable: false),
                    appointment_status = table.Column<short>(type: "smallint", nullable: false),
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    dentist_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_appointment_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_dentist_dentist_id",
                        column: x => x.dentist_id,
                        principalTable: "dentist",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_treatment_detail_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "treatment_detail",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_user_customer_id",
                        column: x => x.customer_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clinic_dentist",
                columns: table => new
                {
                    cd_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    dentist_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_dentist", x => x.cd_no);
                    table.ForeignKey(
                        name: "FK_clinic_dentist_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_dentist_dentist_dentist_id",
                        column: x => x.dentist_id,
                        principalTable: "dentist",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    table.ForeignKey(
                        name: "FK_clinic_feedback_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id");
                    table.ForeignKey(
                        name: "FK_clinic_feedback_user_customer_id",
                        column: x => x.customer_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    service_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    service_price = table.Column<double>(type: "double(10, 2)", nullable: false),
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_service_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointment_service",
                columns: table => new
                {
                    appointment_service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    appointment_id = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    service_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_service", x => x.appointment_service_id);
                    table.ForeignKey(
                        name: "FK_appointment_service_appointment_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointment",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_service_service_service_id",
                        column: x => x.service_id,
                        principalTable: "service",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "area",
                columns: new[] { "area_id", "area_name" },
                values: new object[,]
                {
                    { 1, "Hà Nội" },
                    { 2, "Tp.Hồ Chí Minh" },
                    { 3, "Bình Dương" },
                    { 4, "Đồng Nai" }
                });

            migrationBuilder.InsertData(
                table: "dentist",
                columns: new[] { "user_id", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "sex" },
                values: new object[,]
                {
                    { new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2003, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "baongoc1234@gmail.com", "Ngọc", "Bảo", "12345!", "0912345678", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2 },
                    { new Guid("504a1a7c-36f5-46f9-95f4-b56877a648f6"), null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1 },
                    { new Guid("6b4deeed-b92a-4b77-9977-5b74d9176f5a"), null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)1 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("41c0a5a8-e51d-4045-86f9-5cc2fa87bd83"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"), "phường Chánh Nghĩa, Tp.Thủ Dầu Một, tỉnh Bình Dương", null, new DateTime(2003, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "vulongbinhduong@gmail.com", "Long", "Vũ", "xxx123!", "0866742614", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CO", (short)1 },
                    { new Guid("55ae0b1c-2a90-452f-9dff-7f0c5681525b"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"), "Tp.Sóc Trăng", null, new DateTime(2003, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "huyquac@gmail.com", "Huy", "Quách Hoàng", "xxx123!", "0332877905", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CO", (short)1 },
                    { new Guid("bc809408-1242-4ccc-8601-0949bad8d3ee"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("d2d88029-44c2-4bf3-81ef-5760a3940d26"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("d4f1b215-e31e-4c0b-a3b8-af757d7b3369"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 }
                });

            migrationBuilder.InsertData(
                table: "certificate",
                columns: new[] { "certificate_id", "certificate_image", "certificate_name", "certificate_number", "dentist_id", "expired_date", "issued_date" },
                values: new object[,]
                {
                    { 1, "https://example.com/certificateImage.jpg", "Medical Practice License", "CERT-001", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2024, 6, 17, 22, 57, 14, 74, DateTimeKind.Local).AddTicks(9738) },
                    { 2, "https://example.com/certificateImage2.jpg", "Dental Surgery Certification", "CERT-002", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "https://example.com/certificateImage3.jpg", "Emergency Medicine Training", "CERT-003", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "clinic",
                columns: new[] { "clinic_id", "clinic_address", "area_id", "clinic_name", "clinic_state", "license_number", "no_of_employees", "owner_id", "clinic_phone_number" },
                values: new object[,]
                {
                    { 1, "08 Alexandre de Rhodes St., Ben Nghe Ward, District 1, Ho Chi Minh City", 1, "Columbia Asia Saigon International Clinic", (short)1, "HCM0001", 150, new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"), "02838238888" },
                    { 2, "285B Dien Bien Phu, Vo Thi Sau Ward, District 3, Ho Chi Minh City", 1, "Raffles Medical Ho Chi Minh", (short)1, "HCM0002", 200, new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"), "02838240777" },
                    { 3, "30 Pham Ngoc Thach, Ward Vo Thi Sau, District 3, Ho Chi Minh City", 1, "Centre Médical International (CMI)", (short)1, "HCM0003", 100, new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"), "02838272366" },
                    { 4, "Block 8, Ground floor of SORA Gardens II, Lot C17, Hung Vuong Boulevard, Binh Duong New City, Hoa Phu Ward, Thu Dau Mot City, Binh Duong Province", 2, "Binh Duong Urban Clinic", (short)1, "BDU12345", 50, new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"), "02742222220" }
                });

            migrationBuilder.InsertData(
                table: "clinic_feedback",
                columns: new[] { "clinic_fb_id", "clinic_id", "customer_id", "fb_date", "fb_description", "rating" },
                values: new object[,]
                {
                    { 1, 1, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 6, 17, 22, 57, 14, 74, DateTimeKind.Local).AddTicks(9696), "", (short)1 },
                    { 2, 2, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", (short)3 },
                    { 3, 3, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", (short)4 }
                });

            migrationBuilder.InsertData(
                table: "service",
                columns: new[] { "service_id", "clinic_id", "description", "service_price", "service_name" },
                values: new object[,]
                {
                    { 1, 1, "Bệnh nhân sẽ được Chụp Xquang CBCT", 50.0, "Chụp Xquang CBCT" },
                    { 2, 1, "Bệnh nhân sẽ được Chụp Xquang Cephalometric", 80.0, "Chụp Xquang Cephalometric" },
                    { 3, 1, "Bệnh nhân sẽ được khám tư vấn", 70.0, "Khám tư vấn" },
                    { 4, 1, "Bệnh nhân sẽ được Chụp Xquang Panorama", 100.0, "Chụp Xquang Panorama" },
                    { 5, 2, "Máng chống ê buốt cho răng", 120.0, "Máng chống ê buốt" },
                    { 6, 2, "Máng dành cho bệnh nhân nha chu", 50.0, "Máng nha chu" },
                    { 7, 2, "Lấy cao răng", 80.0, "Lấy cao răng 2 hàm" },
                    { 8, 2, "Trám răng để răng đẹp và tốt hơn", 70.0, "Điều trị tủy" },
                    { 9, 3, "Hàn thẩm mỹ cho bệnh nhân", 100.0, "Hàn thẩm mỹ" },
                    { 10, 3, "Hàn cổ răng cho bệnh nhân", 120.0, "Hàn cổ răng" },
                    { 11, 3, "Hàn răng sâu cho bệnh nhân", 120.0, "Hàn răng sâu" },
                    { 12, 3, "Tiểu phẫu dành cho bệnh nhân nha chu", 120.0, "Tiểu phẫu nha chu" },
                    { 13, 4, "Ngừa sâu răng cho trẻ em", 120.0, "Sealant ngừa sâu răng" },
                    { 14, 4, "Ngừa sâu răng cho trẻ em", 120.0, "Bôi fluoride dự phòng sâu răng" },
                    { 15, 4, "Điều trị tủy răng cho trẻ em", 120.0, "Điều trị tủy răng sữa nhiều chân" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_clinic_id",
                table: "appointment",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_customer_id",
                table: "appointment",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_dentist_id",
                table: "appointment",
                column: "dentist_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_service_appointment_id",
                table: "appointment_service",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_service_service_id",
                table: "appointment_service",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_certificate_certificate_number",
                table: "certificate",
                column: "certificate_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_certificate_dentist_id",
                table: "certificate",
                column: "dentist_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_area_id",
                table: "clinic",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_owner_id",
                table: "clinic",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_dentist_clinic_id",
                table: "clinic_dentist",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_dentist_dentist_id",
                table: "clinic_dentist",
                column: "dentist_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_feedback_clinic_id",
                table: "clinic_feedback",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_feedback_customer_id",
                table: "clinic_feedback",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_dentist_schedule_doctor_id",
                table: "dentist_schedule",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_dentist_working_hours_schedule_id",
                table: "dentist_working_hours",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_clinic_id",
                table: "service",
                column: "clinic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment_service");

            migrationBuilder.DropTable(
                name: "certificate");

            migrationBuilder.DropTable(
                name: "clinic_dentist");

            migrationBuilder.DropTable(
                name: "clinic_feedback");

            migrationBuilder.DropTable(
                name: "dentist_working_hours");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "dentist_schedule");

            migrationBuilder.DropTable(
                name: "treatment_detail");

            migrationBuilder.DropTable(
                name: "clinic");

            migrationBuilder.DropTable(
                name: "dentist");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
