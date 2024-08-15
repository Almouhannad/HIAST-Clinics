using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AcademicQualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAdditionalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineFormId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<decimal>(type: "numeric(9,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineForm_MedicineFormId",
                        column: x => x.MedicineFormId,
                        principalTable: "MedicineForm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_DoctorStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DoctorStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctor_PersonalInfo_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patient_PersonalInfo_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorPhone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorPhone_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfoId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CenterStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsMarried = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeAdditionalInfo_AdditionalInfoId",
                        column: x => x.AdditionalInfoId,
                        principalTable: "EmployeeAdditionalInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Patient_Id",
                        column: x => x.Id,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Patient_Id",
                        column: x => x.Id,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDisease_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientDisease_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visit_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WaitingListRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    IsServed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingListRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingListRecord_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WaitingListRecord_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmployee",
                columns: table => new
                {
                    RelatedEmployeesId = table.Column<int>(type: "int", nullable: false),
                    RelatedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployee", x => new { x.RelatedEmployeesId, x.RelatedToId });
                    table.ForeignKey(
                        name: "FK_EmployeeEmployee_Employee_RelatedEmployeesId",
                        column: x => x.RelatedEmployeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployee_Employee_RelatedToId",
                        column: x => x.RelatedToId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFamilyMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFamilyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFamilyMember_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFamilyMember_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeFamilyMember_FamilyRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FamilyRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitMedicalImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    MedicalImageId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitMedicalImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitMedicalImage_MedicalImage_MedicalImageId",
                        column: x => x.MedicalImageId,
                        principalTable: "MedicalImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitMedicalImage_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitMedicalTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    MedicalTestId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitMedicalTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitMedicalTest_MedicalTest_MedicalTestId",
                        column: x => x.MedicalTestId,
                        principalTable: "MedicalTest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitMedicalTest_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitMedicine_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PersonalInfoId",
                table: "Doctor",
                column: "PersonalInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_StatusId",
                table: "Doctor",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPhone_DoctorId",
                table: "DoctorPhone",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPhone_Phone",
                table: "DoctorPhone",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdditionalInfoId",
                table: "Employee",
                column: "AdditionalInfoId",
                unique: true,
                filter: "[AdditionalInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployee_RelatedToId",
                table: "EmployeeEmployee",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilyMember_EmployeeId",
                table: "EmployeeFamilyMember",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilyMember_FamilyMemberId",
                table: "EmployeeFamilyMember",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilyMember_RoleId",
                table: "EmployeeFamilyMember",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineFormId",
                table: "Medicine",
                column: "MedicineFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonalInfoId",
                table: "Patient",
                column: "PersonalInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDisease_DiseaseId",
                table: "PatientDisease",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDisease_PatientId_DiseaseId",
                table: "PatientDisease",
                columns: new[] { "PatientId", "DiseaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_MedicineId",
                table: "PatientMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_PatientId_MedicineId",
                table: "PatientMedicine",
                columns: new[] { "PatientId", "MedicineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_HospitalId",
                table: "Visit",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicalImage_MedicalImageId",
                table: "VisitMedicalImage",
                column: "MedicalImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicalImage_VisitId_MedicalImageId",
                table: "VisitMedicalImage",
                columns: new[] { "VisitId", "MedicalImageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicalTest_MedicalTestId",
                table: "VisitMedicalTest",
                column: "MedicalTestId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicalTest_VisitId_MedicalTestId",
                table: "VisitMedicalTest",
                columns: new[] { "VisitId", "MedicalTestId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicine_MedicineId",
                table: "VisitMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitMedicine_VisitId_MedicineId",
                table: "VisitMedicine",
                columns: new[] { "VisitId", "MedicineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingListRecord_DoctorId",
                table: "WaitingListRecord",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingListRecord_PatientId",
                table: "WaitingListRecord",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPhone");

            migrationBuilder.DropTable(
                name: "EmployeeEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeFamilyMember");

            migrationBuilder.DropTable(
                name: "PatientDisease");

            migrationBuilder.DropTable(
                name: "PatientMedicine");

            migrationBuilder.DropTable(
                name: "VisitMedicalImage");

            migrationBuilder.DropTable(
                name: "VisitMedicalTest");

            migrationBuilder.DropTable(
                name: "VisitMedicine");

            migrationBuilder.DropTable(
                name: "WaitingListRecord");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FamilyMember");

            migrationBuilder.DropTable(
                name: "FamilyRole");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "MedicalImage");

            migrationBuilder.DropTable(
                name: "MedicalTest");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "EmployeeAdditionalInfo");

            migrationBuilder.DropTable(
                name: "MedicineForm");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "DoctorStatus");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "PersonalInfo");
        }
    }
}
