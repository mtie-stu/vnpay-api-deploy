using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class repair_keyword_in_StorageSpaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Satus",
                table: "StorageSpaces",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "LoacationStorage",
                table: "StorageSpaces",
                newName: "LocationStorage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "StorageSpaces",
                newName: "Satus");

            migrationBuilder.RenameColumn(
                name: "LocationStorage",
                table: "StorageSpaces",
                newName: "LoacationStorage");
        }
    }
}
