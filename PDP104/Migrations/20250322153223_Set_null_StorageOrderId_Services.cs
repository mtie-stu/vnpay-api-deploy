using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class Set_null_StorageOrderId_Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "StorageOrdersId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services",
                column: "StorageOrdersId",
                principalTable: "StorageOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "StorageOrdersId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services",
                column: "StorageOrdersId",
                principalTable: "StorageOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
