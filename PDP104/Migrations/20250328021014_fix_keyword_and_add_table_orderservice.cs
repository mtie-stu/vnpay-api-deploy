using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class fix_keyword_and_add_table_orderservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_StorageOrdersId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "StorageOrdersId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "SatusOrder",
                table: "StorageOrders",
                newName: "StatusOrder");

            migrationBuilder.RenameColumn(
                name: "Quanity",
                table: "StorageOrders",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StorageOrderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageOrderId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageOrderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageOrderServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageOrderServices_StorageOrders_StorageOrderId",
                        column: x => x.StorageOrderId,
                        principalTable: "StorageOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_ServicesId",
                table: "StorageOrderServices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_StorageOrderId",
                table: "StorageOrderServices",
                column: "StorageOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageOrderServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "StatusOrder",
                table: "StorageOrders",
                newName: "SatusOrder");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StorageOrders",
                newName: "Quanity");

            migrationBuilder.AddColumn<int>(
                name: "StorageOrdersId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_StorageOrdersId",
                table: "Services",
                column: "StorageOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_StorageOrders_StorageOrdersId",
                table: "Services",
                column: "StorageOrdersId",
                principalTable: "StorageOrders",
                principalColumn: "Id");
        }
    }
}
