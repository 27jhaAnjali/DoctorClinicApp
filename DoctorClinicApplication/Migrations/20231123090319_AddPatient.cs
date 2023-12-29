using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorClinicApplication.Migrations
{
    public partial class AddPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "Id", "Age", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 26, "xys.kum@xyz.com", "Shivam", "9199292870" },
                    { 2, 28, "abc.hjk@xyz.com", "Nishant", "9078101884" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
