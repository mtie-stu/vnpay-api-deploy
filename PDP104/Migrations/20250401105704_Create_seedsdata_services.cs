using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class Create_seedsdata_services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "NameServices", "StatusService", "TypeService", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Dịch vụ lưu trữ hàng balet theo ngày", "Lưu trữ hàng Balet - Ngày", 0, 0, 100000m },
                    { 2, "Dịch vụ lưu trữ hàng balet theo tháng", "Lưu trữ hàng Balet - Tháng", 0, 0, 1500000m },
                    { 3, "Dịch vụ lưu trữ hàng balet theo năm", "Lưu trữ hàng Balet - Năm", 0, 0, 5000000m },
                    { 4, "Dịch vụ lưu trữ Container 18ft theo ngày", "Lưu trữ Container 18ft - Ngày", 0, 1, 200000m },
                    { 5, "Dịch vụ lưu trữ Container 18ft theo tháng", "Lưu trữ Container 18ft - Tháng", 0, 1, 1500000m },
                    { 6, "Dịch vụ lưu trữ Container 18ft theo năm", "Lưu trữ Container 18ft - Năm", 0, 1, 15000000m },
                    { 7, "Dịch vụ lưu trữ Container 20ft theo ngày", "Lưu trữ Container 20ft - Ngày", 0, 2, 250000m },
                    { 8, "Dịch vụ lưu trữ Container 20ft theo tháng", "Lưu trữ Container 20ft - Tháng", 0, 2, 2000000m },
                    { 9, "Dịch vụ lưu trữ Container 20ft theo năm", "Lưu trữ Container 20ft - Năm", 0, 2, 20000000m },
                    { 10, "Dịch vụ lưu trữ Container 22ft theo ngày", "Lưu trữ Container 22ft - Ngày", 0, 3, 300000m },
                    { 11, "Dịch vụ lưu trữ Container 22ft theo tháng", "Lưu trữ Container 22ft - Tháng", 0, 3, 2500000m },
                    { 12, "Dịch vụ lưu trữ Container 22ft theo năm", "Lưu trữ Container 22ft - Năm", 0, 3, 25000000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
