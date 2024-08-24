using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Holiday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitingListRecord_Doctor_DoctorId",
                table: "WaitingListRecord");

            migrationBuilder.DropIndex(
                name: "IX_WaitingListRecord_DoctorId",
                table: "WaitingListRecord");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "WaitingListRecord");

            migrationBuilder.DropColumn(
                name: "IsServed",
                table: "WaitingListRecord");

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_VisitId",
                table: "Holiday",
                column: "VisitId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "WaitingListRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsServed",
                table: "WaitingListRecord",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingListRecord_DoctorId",
                table: "WaitingListRecord",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingListRecord_Doctor_DoctorId",
                table: "WaitingListRecord",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");
        }
    }
}
