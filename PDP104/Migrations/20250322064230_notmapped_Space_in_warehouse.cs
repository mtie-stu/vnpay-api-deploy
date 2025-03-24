using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class notmapped_Space_in_warehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Space",
                table: "WareHouses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Space",
                table: "WareHouses",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }
    }
}
