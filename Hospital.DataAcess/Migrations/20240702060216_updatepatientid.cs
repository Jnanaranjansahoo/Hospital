using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class updatepatientid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "Age", "Depatment", "Email", "Gender", "Guardian", "Name", "Phone", "Resion" },
                values: new object[,]
                {
                    { 100, "Address", 25, "Depatments", "patient@gmail.com", "Male", "Guardian", "Patient", 1234567890, "Resion" },
                    { 101, "2Address", 25, "2Depatments", "2patient@gmail.com", "2Male", "2Guardian", "Patient2", 1234567890, "2Resion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "Age", "Depatment", "Email", "Gender", "Guardian", "Name", "Phone", "Resion" },
                values: new object[,]
                {
                    { 1, "Address", 25, "Depatments", "patient@gmail.com", "Male", "Guardian", "Patient", 1234567890, "Resion" },
                    { 2, "2Address", 25, "2Depatments", "2patient@gmail.com", "2Male", "2Guardian", "Patient2", 1234567890, "2Resion" }
                });
        }
    }
}
