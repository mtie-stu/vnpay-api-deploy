using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class Create_seedsdata_services_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "NameServices", "StatusService", "TypeService", "UnitPrice" },
                values: new object[,]
                {
                    { 13, "Dịch vụ lưu trữ Container 18ft", "Kiểm kê Container 22ft - Năm", 0, 3, 350000m },
                    { 14, "Dịch vụ lưu trữ Container 20ft", "Kiểm kê Container 22ft - Năm", 0, 3, 450000m },
                    { 15, "Dịch vụ lưu trữ Container 22ft", "Kiểm kê Container 22ft - Năm", 0, 3, 550000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
