using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.DAL.Databases.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDatabasev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    area_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    area_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.area_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "combo",
                columns: table => new
                {
                    combo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    combo_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    combo_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combo", x => x.combo_id);
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
                    table.PrimaryKey("PK_users", x => x.user_id);
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
                    doctor_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificate", x => x.certificate_id);
                    table.ForeignKey(
                        name: "FK_certificate_users_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "users",
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
                        name: "FK_clinic_Area_area_id",
                        column: x => x.area_id,
                        principalTable: "Area",
                        principalColumn: "area_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctor_schedule",
                columns: table => new
                {
                    schedule_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    working_date = table.Column<DateOnly>(type: "date", nullable: true),
                    doctor_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_doctor_schedule_users_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "users",
                        principalColumn: "user_id",
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
                    customer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
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
                        name: "FK_appointment_treatment_detail_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "treatment_detail",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clinic_doctors",
                columns: table => new
                {
                    cd_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_doctors", x => x.cd_no);
                    table.ForeignKey(
                        name: "FK_clinic_doctors_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_doctors_users_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "users",
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
                        name: "FK_clinic_feedback_users_customer_id",
                        column: x => x.customer_id,
                        principalTable: "users",
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
                name: "doctor_working_hours",
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
                    table.PrimaryKey("PK_doctor_working_hours", x => x.working_hour_id);
                    table.ForeignKey(
                        name: "FK_doctor_working_hours_doctor_schedule_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "doctor_schedule",
                        principalColumn: "schedule_id",
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

            migrationBuilder.CreateTable(
                name: "combo_service",
                columns: table => new
                {
                    combo_service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    combo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combo_service", x => x.combo_service_id);
                    table.ForeignKey(
                        name: "FK_combo_service_combo_combo_id",
                        column: x => x.combo_id,
                        principalTable: "combo",
                        principalColumn: "combo_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_combo_service_service_service_id",
                        column: x => x.service_id,
                        principalTable: "service",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "area_id", "area_name" },
                values: new object[,]
                {
                    { 1, "Hà Nội" },
                    { 2, "Tp.Hồ Chí Minh" },
                    { 3, "Bình Dương" },
                    { 4, "Đồng Nai" }
                });

            migrationBuilder.InsertData(
                table: "combo",
                columns: new[] { "combo_id", "combo_name", "combo_description" },
                values: new object[,]
                {
                    { 1, "Khám tư vấn", "Mục gồm các vấn đề liên quan đến Khám tư vấn" },
                    { 2, "Nha khoa tổng quát", "Mục gồm các vấn đề liên quan đến Nha khoa tổng quát" },
                    { 3, "Nha khoa trẻ em", "Mục gồm các vấn đề liên quan đến Nha khoa trẻ em" },
                    { 4, "Chỉnh nha", "Mục gồm các vấn đề liên quan đến Chỉnh nha" },
                    { 5, "Cấy ghép Implant", "Mục gồm các vấn đề liên quan đến Cấy ghép Implant" },
                    { 6, "Nhổ răng", "Mục gồm các vấn đề liên quan đến Nhổ răng" },
                    { 7, "Nha khoa thẩm mỹ", "Mục gồm các vấn đề liên quan đến Nha khoa thẩm mỹ" },
                    { 8, "Khác", "Mục gồm các vấn đề khác ngoài các mục đã có" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "citizen_id", "date_of_birth", "email", "first_name", "last_name", "password", "phone_number", "refresh_token", "refresh_token_expiry_time", "role", "sex" },
                values: new object[,]
                {
                    { new Guid("0172a2dd-a259-4429-9737-5b485d4fab06"), "phường Phước Long A, Q.9, Tp.Hồ Chí Minh", null, new DateTime(1987, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "janetran639@gmail.com", "Hà", "Phùng Trần Mai", "999doahoahong@", "0902694265", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), "Tp.Hồ Chí Minh", null, new DateTime(2003, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "baongoc1234@gmail.com", "Ngọc", "Bảo", "12345!", "0912345678", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("324c5b1d-e99e-4f5e-ba4f-8ce83f615954"), null, null, null, "adminexample@gmail.com", "Admin", null, "reallystrongpass!123", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", (short)0 },
                    { new Guid("38be5156-f30e-478c-bfc0-a1b05c6a88b5"), "789 Trần Hưng Đạo, Hà Nội, Vietnam", null, new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tran.thib@example.com", "B", "Trần Thị", "Password123!", "0976543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), "Tân Bình, Tp.Hồ Chí Minh", null, new DateTime(2003, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatvmse172011@fpt.edu.vn", "Nhật", "Vũ Minh", "Password123!", "0366412667", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"), "phường Chánh Nghĩa, Tp.Thủ Dầu Một, tỉnh Bình Dương", null, new DateTime(2003, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "vulongbinhduong@gmail.com", "Long", "Vũ", "xxx123!", "0866742614", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CO", (short)1 },
                    { new Guid("5ba3815b-d294-40fd-b4c4-1dd975a527c4"), "456 Lê Lợi, Hồ Chí Minh City, Vietnam", null, new DateTime(1990, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyen.vana@gmail.com", "A", "Nguyễn Văn", "Password123!", "0987654321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 },
                    { new Guid("7e1a0d29-0ee8-4692-bb88-416e44369cb0"), "789 Pine St, Anytown, USA", null, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "Password123!", "3456789012", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"), "Tp.Sóc Trăng", null, new DateTime(2003, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "huyquac@gmail.com", "Huy", "Quách Hoàng", "xxx123!", "0332877905", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CO", (short)1 },
                    { new Guid("8a74a99d-17b4-4e91-8457-333b42837f0a"), "456 Oak St, Anytown, USA", null, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "Password123!", "2345678901", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)2 },
                    { new Guid("b9b61b52-9eb0-414c-886d-1ee2589a5438"), "Thủ Đức, Tp.Hồ Chí Minh", null, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bangtlhss170429@fpt.edu.vn", "Bằng", "Trần Lê Hữu", "Password123!", "0384691554", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUS", (short)1 },
                    { new Guid("fd86db0c-0058-405e-a406-dbe82f6e98f3"), "123 Main St, Anytown, USA", null, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "Password123!", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", (short)1 }
                });

            migrationBuilder.InsertData(
                table: "certificate",
                columns: new[] { "certificate_id", "certificate_image", "certificate_name", "certificate_number", "doctor_id", "expired_date", "issued_date" },
                values: new object[,]
                {
                    { 1, "https://example.com/certificateImage.jpg", "Medical Practice License", "CERT-001", new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"), null, new DateTime(2024, 6, 14, 16, 15, 51, 899, DateTimeKind.Local).AddTicks(6670) },
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
                    { 1, 1, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 6, 14, 16, 15, 51, 899, DateTimeKind.Local).AddTicks(6545), "The clinic was clean and the staff were courteous, but the waiting time was longer than expected.", (short)3 },
                    { 2, 2, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent service! The doctor was very thorough and answered all my questions.", (short)2 },
                    { 3, 3, new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"), new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The clinic environment was good, but the appointment was delayed by 30 minutes.", (short)4 }
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
                    { 5, 1, "Máng chống ê buốt cho răng", 120.0, "Máng chống ê buốt" },
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
                table: "combo_service",
                columns: new[] { "combo_service_id", "combo_id", "service_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
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

            migrationBuilder.CreateIndex(
                name: "IX_appointment_clinic_id",
                table: "appointment",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_customer_id",
                table: "appointment",
                column: "customer_id");

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
                name: "IX_certificate_doctor_id",
                table: "certificate",
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
                name: "IX_clinic_doctors_clinic_id",
                table: "clinic_doctors",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_doctors_doctor_id",
                table: "clinic_doctors",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_feedback_clinic_id",
                table: "clinic_feedback",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_feedback_customer_id",
                table: "clinic_feedback",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_combo_service_combo_id",
                table: "combo_service",
                column: "combo_id");

            migrationBuilder.CreateIndex(
                name: "IX_combo_service_service_id",
                table: "combo_service",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_schedule_doctor_id",
                table: "doctor_schedule",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_working_hours_schedule_id",
                table: "doctor_working_hours",
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
                name: "clinic_doctors");

            migrationBuilder.DropTable(
                name: "clinic_feedback");

            migrationBuilder.DropTable(
                name: "combo_service");

            migrationBuilder.DropTable(
                name: "doctor_working_hours");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "combo");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "doctor_schedule");

            migrationBuilder.DropTable(
                name: "treatment_detail");

            migrationBuilder.DropTable(
                name: "clinic");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
