using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class Create_Storage_Orders_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StorageOrderImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageOrdersId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageOrderImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageOrderImages_StorageOrders_StorageOrdersId",
                        column: x => x.StorageOrdersId,
                        principalTable: "StorageOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderImages_StorageOrdersId",
                table: "StorageOrderImages",
                column: "StorageOrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageOrderImages");
        }
    }
}
