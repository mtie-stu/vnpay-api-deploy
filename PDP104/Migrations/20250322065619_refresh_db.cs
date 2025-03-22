using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class refresh_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_StorageOrders_StorageOrdersId",
                table: "StorageSpaces");

            migrationBuilder.RenameColumn(
                name: "Satus",
                table: "WareHouses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Loacation",
                table: "WareHouses",
                newName: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "StorageOrdersId",
                table: "StorageSpaces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_StorageOrders_StorageOrdersId",
                table: "StorageSpaces",
                column: "StorageOrdersId",
                principalTable: "StorageOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_StorageOrders_StorageOrdersId",
                table: "StorageSpaces");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "WareHouses",
                newName: "Satus");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "WareHouses",
                newName: "Loacation");

            migrationBuilder.AlterColumn<int>(
                name: "StorageOrdersId",
                table: "StorageSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_StorageOrders_StorageOrdersId",
                table: "StorageSpaces",
                column: "StorageOrdersId",
                principalTable: "StorageOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
