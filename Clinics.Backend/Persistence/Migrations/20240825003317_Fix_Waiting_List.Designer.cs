﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ClinicsDbContext))]
    [Migration("20240825003317_Fix_Waiting_List")]
    partial class Fix_Waiting_List
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Identity.UserRoles.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.DoctorUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.ToTable("DoctorUser", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.ReceptionistUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId")
                        .IsUnique();

                    b.ToTable("ReceptionistUser", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Diseases.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Disease", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Hospitals.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Hospital", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.MedicalImages.MedicalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MedicalImage", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.MedicalTests.MedicalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MedicalTest", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Medicines.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("Dosage")
                        .HasColumnType("numeric(9, 3)");

                    b.Property<int>("MedicineFormId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicineFormId");

                    b.ToTable("Medicine", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForm", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MedicineForm", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues.DoctorStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DoctorStatus", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Shared.DoctorPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("DoctorPhone", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AdditionalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("CenterStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsMarried")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalInfoId")
                        .IsUnique()
                        .HasFilter("[AdditionalInfoId] IS NOT NULL");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.EmployeeFamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyMemberId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FamilyMemberId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeFamilyMember", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FamilyRole", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Shared.EmployeeAdditionalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicQualification")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("JobStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("WorkPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeAdditionalInfo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.FamilyMembers.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FamilyMember", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("PersonalInfoId")
                        .IsUnique();

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Relations.PatientDiseases.PatientDisease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("PatientId", "DiseaseId")
                        .IsUnique();

                    b.ToTable("PatientDisease", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Relations.PatientMedicines.PatientMedicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PatientId", "MedicineId")
                        .IsUnique();

                    b.ToTable("PatientMedicine", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Shared.GenderValues.Gender", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.People.Shared.PersonalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInfo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Visits.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateOnly>("From")
                        .HasColumnType("date");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitId")
                        .IsUnique();

                    b.ToTable("Holiday", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicalImages.VisitMedicalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MedicalImageId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalImageId");

                    b.HasIndex("VisitId", "MedicalImageId")
                        .IsUnique();

                    b.ToTable("VisitMedicalImage", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicalTests.VisitMedicalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MedicalTestId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalTestId");

                    b.HasIndex("VisitId", "MedicalTestId")
                        .IsUnique();

                    b.ToTable("VisitMedicalTest", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicines.VisitMedicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("VisitId", "MedicineId")
                        .IsUnique();

                    b.ToTable("VisitMedicine", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Visits.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visit", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.WaitingList.WaitingListRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("WaitingListRecord", (string)null);
                });

            modelBuilder.Entity("EmployeeEmployee", b =>
                {
                    b.Property<int>("RelatedEmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedToId")
                        .HasColumnType("int");

                    b.HasKey("RelatedEmployeesId", "RelatedToId");

                    b.HasIndex("RelatedToId");

                    b.ToTable("EmployeeEmployee");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.DoctorUser", b =>
                {
                    b.HasOne("Domain.Entities.People.Doctors.Doctor", "Doctor")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Identity.Users.DoctorUser", "DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Identity.Users.DoctorUser", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.ReceptionistUser", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Identity.Users.ReceptionistUser", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Shared.PersonalInfo", "PersonalInfo")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Identity.Users.ReceptionistUser", "PersonalInfoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PersonalInfo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Users.User", b =>
                {
                    b.HasOne("Domain.Entities.Identity.UserRoles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Medicines.Medicine", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForm", "MedicineForm")
                        .WithMany()
                        .HasForeignKey("MedicineFormId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MedicineForm");
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Doctor", b =>
                {
                    b.HasOne("Domain.Entities.People.Shared.PersonalInfo", "PersonalInfo")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.People.Doctors.Doctor", "PersonalInfoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues.DoctorStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PersonalInfo");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Shared.DoctorPhone", b =>
                {
                    b.HasOne("Domain.Entities.People.Doctors.Doctor", null)
                        .WithMany("Phones")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Employee", b =>
                {
                    b.HasOne("Domain.Entities.People.Employees.Shared.EmployeeAdditionalInfo", "AdditionalInfo")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.People.Employees.Employee", "AdditionalInfoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.People.Employees.Employee", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AdditionalInfo");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.EmployeeFamilyMember", b =>
                {
                    b.HasOne("Domain.Entities.People.Employees.Employee", "Employee")
                        .WithMany("FamilyMembers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.FamilyMembers.FamilyMember", "FamilyMember")
                        .WithMany()
                        .HasForeignKey("FamilyMemberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("FamilyMember");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.People.FamilyMembers.FamilyMember", b =>
                {
                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.People.FamilyMembers.FamilyMember", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Patient", b =>
                {
                    b.HasOne("Domain.Entities.People.Shared.GenderValues.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Shared.PersonalInfo", "PersonalInfo")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.People.Patients.Patient", "PersonalInfoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Relations.PatientDiseases.PatientDisease", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.Diseases.Disease", "Disease")
                        .WithMany("Patients")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithMany("Diseases")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Relations.PatientMedicines.PatientMedicine", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.Medicines.Medicine", "Medicine")
                        .WithMany("Patients")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithMany("Medicines")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.Visits.Holiday", b =>
                {
                    b.HasOne("Domain.Entities.Visits.Visit", null)
                        .WithOne("Holiday")
                        .HasForeignKey("Domain.Entities.Visits.Holiday", "VisitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicalImages.VisitMedicalImage", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.MedicalImages.MedicalImage", "MedicalImage")
                        .WithMany()
                        .HasForeignKey("MedicalImageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Visits.Visit", "Visit")
                        .WithMany("MedicalImages")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MedicalImage");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicalTests.VisitMedicalTest", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.MedicalTests.MedicalTest", "MedicalTest")
                        .WithMany()
                        .HasForeignKey("MedicalTestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Visits.Visit", "Visit")
                        .WithMany("MedicalTests")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MedicalTest");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Domain.Entities.Visits.Relations.VisitMedicines.VisitMedicine", b =>
                {
                    b.HasOne("Domain.Entities.Medicals.Medicines.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Visits.Visit", "Visit")
                        .WithMany("Medicines")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Domain.Entities.Visits.Visit", b =>
                {
                    b.HasOne("Domain.Entities.People.Doctors.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicals.Hospitals.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Hospital");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.WaitingList.WaitingListRecord", b =>
                {
                    b.HasOne("Domain.Entities.People.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("EmployeeEmployee", b =>
                {
                    b.HasOne("Domain.Entities.People.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("RelatedEmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.People.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("RelatedToId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Diseases.Disease", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Domain.Entities.Medicals.Medicines.Medicine", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Domain.Entities.People.Doctors.Doctor", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Domain.Entities.People.Employees.Employee", b =>
                {
                    b.Navigation("FamilyMembers");
                });

            modelBuilder.Entity("Domain.Entities.People.Patients.Patient", b =>
                {
                    b.Navigation("Diseases");

                    b.Navigation("Medicines");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Domain.Entities.Visits.Visit", b =>
                {
                    b.Navigation("Holiday");

                    b.Navigation("MedicalImages");

                    b.Navigation("MedicalTests");

                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}
