using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class add_svc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageOrderServices_Services_ServicesId",
                table: "StorageOrderServices");

            migrationBuilder.DropIndex(
                name: "IX_StorageOrderServices_ServicesId",
                table: "StorageOrderServices");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "StorageOrderServices");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "NameServices", "StatusService", "TypeService", "UnitPrice" },
                values: new object[] { 16, "Balet", "Null ", 0, 3, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_ServiceId",
                table: "StorageOrderServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOrderServices_Services_ServiceId",
                table: "StorageOrderServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageOrderServices_Services_ServiceId",
                table: "StorageOrderServices");

            migrationBuilder.DropIndex(
                name: "IX_StorageOrderServices_ServiceId",
                table: "StorageOrderServices");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "StorageOrderServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_ServicesId",
                table: "StorageOrderServices",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOrderServices_Services_ServicesId",
                table: "StorageOrderServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
