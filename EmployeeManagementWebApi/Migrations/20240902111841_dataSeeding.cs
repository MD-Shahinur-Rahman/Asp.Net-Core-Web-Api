using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Email", "EmployeeName", "ImageName", "ImageUrl", "IsActive", "JoinDate" },
                values: new object[,]
                {
                    { 1, "ashik@gmail.com", "Ashik Mahmud", "ashik.jpg", "/Upload/mohipic.jpg", true, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "mredul@.com", "Mredul", "Mredul.jpg", "/Upload/Mredul.jpg", true, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "ExperienceId", "Duration", "EmployeeId", "Title" },
                values: new object[,]
                {
                    { 1, 24, 1, "Software Developer" },
                    { 2, 12, 1, "Senior Developer" },
                    { 3, 36, 2, "Project Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Experience",
                keyColumn: "ExperienceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Experience",
                keyColumn: "ExperienceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Experience",
                keyColumn: "ExperienceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);
        }
    }
}
