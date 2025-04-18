using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class updb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    NameND = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Hinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InventoryStatus = table.Column<int>(type: "integer", nullable: false),
                    StorageOrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameServices = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TypeService = table.Column<int>(type: "integer", nullable: false),
                    StatusService = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryId = table.Column<int>(type: "integer", nullable: true),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfEntry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfShipment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusOrder = table.Column<int>(type: "integer", nullable: false),
                    StatusInventory = table.Column<int>(type: "integer", nullable: false),
                    TypeOfGoods = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Hinh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NguoiDungId = table.Column<string>(type: "text", nullable: true),
                    InventoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageOrders_AspNetUsers_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageOrders_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageOrderImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StorageOrdersId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "StorageOrderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StorageOrderId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageOrderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageOrderServices_Services_ServiceId",
                        column: x => x.ServiceId,
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

            migrationBuilder.CreateTable(
                name: "StorageSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    LocationStorage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StorageOrdersId = table.Column<int>(type: "integer", nullable: true),
                    WareHouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_StorageOrders_StorageOrdersId",
                        column: x => x.StorageOrdersId,
                        principalTable: "StorageOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageSpaces_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "NameServices", "StatusService", "TypeService", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Dịch vụ lưu trữ hàng balet theo ngày", "Lưu trữ hàng Balet - Ngày", 0, 3, 100000m },
                    { 2, "Dịch vụ lưu trữ hàng balet theo tháng", "Lưu trữ hàng Balet - Tháng", 0, 3, 1500000m },
                    { 3, "Dịch vụ lưu trữ hàng balet theo năm", "Lưu trữ hàng Balet - Năm", 0, 3, 5000000m },
                    { 4, "Dịch vụ lưu trữ Container 18ft theo ngày", "Lưu trữ Container 18ft - Ngày", 0, 4, 200000m },
                    { 5, "Dịch vụ lưu trữ Container 18ft theo tháng", "Lưu trữ Container 18ft - Tháng", 0, 4, 1500000m },
                    { 6, "Dịch vụ lưu trữ Container 18ft theo năm", "Lưu trữ Container 18ft - Năm", 0, 4, 15000000m },
                    { 7, "Dịch vụ lưu trữ Container 20ft theo ngày", "Lưu trữ Container 20ft - Ngày", 0, 5, 250000m },
                    { 8, "Dịch vụ lưu trữ Container 20ft theo tháng", "Lưu trữ Container 20ft - Tháng", 0, 5, 2000000m },
                    { 9, "Dịch vụ lưu trữ Container 20ft theo năm", "Lưu trữ Container 20ft - Năm", 0, 5, 20000000m },
                    { 10, "Dịch vụ lưu trữ Container 22ft theo ngày", "Lưu trữ Container 22ft - Ngày", 0, 6, 300000m },
                    { 11, "Dịch vụ lưu trữ Container 22ft theo tháng", "Lưu trữ Container 22ft - Tháng", 0, 6, 2500000m },
                    { 12, "Dịch vụ lưu trữ Container 22ft theo năm", "Lưu trữ Container 22ft - Năm", 0, 6, 25000000m },
                    { 13, "Dịch vụ Kiểm kê Container 18ft", "Kiểm kê Container 18ft ", 0, 0, 350000m },
                    { 14, "Dịch vụ Kiểm kê Container 20ft", "Kiểm kê Container 20ft ", 0, 1, 450000m },
                    { 15, "Dịch vụ Kiểm kê Container 22ft", "Kiểm kê Container 22ft ", 0, 2, 550000m },
                    { 16, "Balet", "Null ", 0, 3, 0m }
                });

            migrationBuilder.InsertData(
                table: "WareHouses",
                columns: new[] { "Id", "Location", "Status" },
                values: new object[,]
                {
                    { 1, "VNOS ", 0 },
                    { 2, "VNIS ", 0 }
                });

            migrationBuilder.InsertData(
                table: "StorageSpaces",
                columns: new[] { "Id", "Floor", "LocationStorage", "Status", "StorageOrdersId", "WareHouseId" },
                values: new object[,]
                {
                    { 1, 0, "VNOS-001-0", 0, null, 1 },
                    { 2, 0, "VNOS-002-0", 0, null, 1 },
                    { 3, 0, "VNOS-003-0", 0, null, 1 },
                    { 4, 0, "VNOS-004-0", 0, null, 1 },
                    { 5, 0, "VNOS-005-0", 0, null, 1 },
                    { 6, 0, "VNOS-006-0", 0, null, 1 },
                    { 7, 0, "VNOS-007-0", 0, null, 1 },
                    { 8, 0, "VNOS-008-0", 0, null, 1 },
                    { 9, 0, "VNOS-009-0", 0, null, 1 },
                    { 10, 0, "VNOS-010-0", 0, null, 1 },
                    { 11, 0, "VNOS-011-0", 0, null, 1 },
                    { 12, 0, "VNOS-012-0", 0, null, 1 },
                    { 13, 0, "VNOS-013-0", 0, null, 1 },
                    { 14, 0, "VNOS-014-0", 0, null, 1 },
                    { 15, 0, "VNOS-015-0", 0, null, 1 },
                    { 16, 0, "VNOS-016-0", 0, null, 1 },
                    { 17, 0, "VNOS-017-0", 0, null, 1 },
                    { 18, 0, "VNOS-018-0", 0, null, 1 },
                    { 19, 0, "VNOS-019-0", 0, null, 1 },
                    { 20, 0, "VNOS-020-0", 0, null, 1 },
                    { 21, 0, "VNOS-021-0", 0, null, 1 },
                    { 22, 0, "VNOS-022-0", 0, null, 1 },
                    { 23, 0, "VNOS-023-0", 0, null, 1 },
                    { 24, 0, "VNOS-024-0", 0, null, 1 },
                    { 25, 0, "VNOS-025-0", 0, null, 1 },
                    { 26, 0, "VNOS-026-0", 0, null, 1 },
                    { 27, 0, "VNOS-027-0", 0, null, 1 },
                    { 28, 0, "VNOS-028-0", 0, null, 1 },
                    { 29, 0, "VNOS-029-0", 0, null, 1 },
                    { 30, 0, "VNOS-030-0", 0, null, 1 },
                    { 31, 0, "VNOS-031-0", 0, null, 1 },
                    { 32, 0, "VNOS-032-0", 0, null, 1 },
                    { 33, 0, "VNOS-033-0", 0, null, 1 },
                    { 34, 0, "VNOS-034-0", 0, null, 1 },
                    { 35, 0, "VNOS-035-0", 0, null, 1 },
                    { 36, 0, "VNOS-036-0", 0, null, 1 },
                    { 37, 0, "VNOS-037-0", 0, null, 1 },
                    { 38, 0, "VNOS-038-0", 0, null, 1 },
                    { 39, 0, "VNOS-039-0", 0, null, 1 },
                    { 40, 0, "VNOS-040-0", 0, null, 1 },
                    { 41, 0, "VNOS-041-0", 0, null, 1 },
                    { 42, 0, "VNOS-042-0", 0, null, 1 },
                    { 43, 0, "VNOS-043-0", 0, null, 1 },
                    { 44, 0, "VNOS-044-0", 0, null, 1 },
                    { 45, 0, "VNOS-045-0", 0, null, 1 },
                    { 46, 0, "VNOS-046-0", 0, null, 1 },
                    { 47, 0, "VNOS-047-0", 0, null, 1 },
                    { 48, 0, "VNOS-048-0", 0, null, 1 },
                    { 49, 0, "VNOS-049-0", 0, null, 1 },
                    { 50, 0, "VNOS-050-0", 0, null, 1 },
                    { 51, 0, "VNOS-051-0", 0, null, 1 },
                    { 52, 0, "VNOS-052-0", 0, null, 1 },
                    { 53, 0, "VNOS-053-0", 0, null, 1 },
                    { 54, 0, "VNOS-054-0", 0, null, 1 },
                    { 55, 0, "VNOS-055-0", 0, null, 1 },
                    { 56, 0, "VNOS-056-0", 0, null, 1 },
                    { 57, 0, "VNOS-057-0", 0, null, 1 },
                    { 58, 0, "VNOS-058-0", 0, null, 1 },
                    { 59, 0, "VNOS-059-0", 0, null, 1 },
                    { 60, 0, "VNOS-060-0", 0, null, 1 },
                    { 61, 0, "VNOS-061-0", 0, null, 1 },
                    { 62, 0, "VNOS-062-0", 0, null, 1 },
                    { 63, 0, "VNOS-063-0", 0, null, 1 },
                    { 64, 0, "VNOS-064-0", 0, null, 1 },
                    { 65, 0, "VNOS-065-0", 0, null, 1 },
                    { 66, 0, "VNOS-066-0", 0, null, 1 },
                    { 67, 0, "VNOS-067-0", 0, null, 1 },
                    { 68, 0, "VNOS-068-0", 0, null, 1 },
                    { 69, 0, "VNOS-069-0", 0, null, 1 },
                    { 70, 0, "VNOS-070-0", 0, null, 1 },
                    { 71, 0, "VNOS-071-0", 0, null, 1 },
                    { 72, 0, "VNOS-072-0", 0, null, 1 },
                    { 73, 0, "VNOS-073-0", 0, null, 1 },
                    { 74, 0, "VNOS-074-0", 0, null, 1 },
                    { 75, 0, "VNOS-075-0", 0, null, 1 },
                    { 76, 0, "VNOS-076-0", 0, null, 1 },
                    { 77, 0, "VNOS-077-0", 0, null, 1 },
                    { 78, 0, "VNOS-078-0", 0, null, 1 },
                    { 79, 0, "VNOS-079-0", 0, null, 1 },
                    { 80, 0, "VNOS-080-0", 0, null, 1 },
                    { 81, 0, "VNOS-081-0", 0, null, 1 },
                    { 82, 0, "VNOS-082-0", 0, null, 1 },
                    { 83, 0, "VNOS-083-0", 0, null, 1 },
                    { 84, 0, "VNOS-084-0", 0, null, 1 },
                    { 85, 0, "VNOS-085-0", 0, null, 1 },
                    { 86, 0, "VNOS-086-0", 0, null, 1 },
                    { 87, 0, "VNOS-087-0", 0, null, 1 },
                    { 88, 0, "VNOS-088-0", 0, null, 1 },
                    { 89, 0, "VNOS-089-0", 0, null, 1 },
                    { 90, 0, "VNOS-090-0", 0, null, 1 },
                    { 91, 0, "VNOS-091-0", 0, null, 1 },
                    { 92, 0, "VNOS-092-0", 0, null, 1 },
                    { 93, 0, "VNOS-093-0", 0, null, 1 },
                    { 94, 0, "VNOS-094-0", 0, null, 1 },
                    { 95, 0, "VNOS-095-0", 0, null, 1 },
                    { 96, 0, "VNOS-096-0", 0, null, 1 },
                    { 97, 0, "VNOS-097-0", 0, null, 1 },
                    { 98, 0, "VNOS-098-0", 0, null, 1 },
                    { 99, 0, "VNOS-099-0", 0, null, 1 },
                    { 100, 0, "VNOS-100-0", 0, null, 1 },
                    { 1010, 0, "VNIS-001-0", 0, null, 2 },
                    { 1011, 1, "VNIS-001-1", 0, null, 2 },
                    { 1012, 2, "VNIS-001-2", 0, null, 2 },
                    { 1013, 3, "VNIS-001-3", 0, null, 2 },
                    { 1014, 4, "VNIS-001-4", 0, null, 2 },
                    { 1015, 5, "VNIS-001-5", 0, null, 2 },
                    { 1016, 6, "VNIS-001-6", 0, null, 2 },
                    { 1017, 7, "VNIS-001-7", 0, null, 2 },
                    { 1020, 0, "VNIS-002-0", 0, null, 2 },
                    { 1021, 1, "VNIS-002-1", 0, null, 2 },
                    { 1022, 2, "VNIS-002-2", 0, null, 2 },
                    { 1023, 3, "VNIS-002-3", 0, null, 2 },
                    { 1024, 4, "VNIS-002-4", 0, null, 2 },
                    { 1025, 5, "VNIS-002-5", 0, null, 2 },
                    { 1026, 6, "VNIS-002-6", 0, null, 2 },
                    { 1027, 7, "VNIS-002-7", 0, null, 2 },
                    { 1030, 0, "VNIS-003-0", 0, null, 2 },
                    { 1031, 1, "VNIS-003-1", 0, null, 2 },
                    { 1032, 2, "VNIS-003-2", 0, null, 2 },
                    { 1033, 3, "VNIS-003-3", 0, null, 2 },
                    { 1034, 4, "VNIS-003-4", 0, null, 2 },
                    { 1035, 5, "VNIS-003-5", 0, null, 2 },
                    { 1036, 6, "VNIS-003-6", 0, null, 2 },
                    { 1037, 7, "VNIS-003-7", 0, null, 2 },
                    { 1040, 0, "VNIS-004-0", 0, null, 2 },
                    { 1041, 1, "VNIS-004-1", 0, null, 2 },
                    { 1042, 2, "VNIS-004-2", 0, null, 2 },
                    { 1043, 3, "VNIS-004-3", 0, null, 2 },
                    { 1044, 4, "VNIS-004-4", 0, null, 2 },
                    { 1045, 5, "VNIS-004-5", 0, null, 2 },
                    { 1046, 6, "VNIS-004-6", 0, null, 2 },
                    { 1047, 7, "VNIS-004-7", 0, null, 2 },
                    { 1050, 0, "VNIS-005-0", 0, null, 2 },
                    { 1051, 1, "VNIS-005-1", 0, null, 2 },
                    { 1052, 2, "VNIS-005-2", 0, null, 2 },
                    { 1053, 3, "VNIS-005-3", 0, null, 2 },
                    { 1054, 4, "VNIS-005-4", 0, null, 2 },
                    { 1055, 5, "VNIS-005-5", 0, null, 2 },
                    { 1056, 6, "VNIS-005-6", 0, null, 2 },
                    { 1057, 7, "VNIS-005-7", 0, null, 2 },
                    { 1060, 0, "VNIS-006-0", 0, null, 2 },
                    { 1061, 1, "VNIS-006-1", 0, null, 2 },
                    { 1062, 2, "VNIS-006-2", 0, null, 2 },
                    { 1063, 3, "VNIS-006-3", 0, null, 2 },
                    { 1064, 4, "VNIS-006-4", 0, null, 2 },
                    { 1065, 5, "VNIS-006-5", 0, null, 2 },
                    { 1066, 6, "VNIS-006-6", 0, null, 2 },
                    { 1067, 7, "VNIS-006-7", 0, null, 2 },
                    { 1070, 0, "VNIS-007-0", 0, null, 2 },
                    { 1071, 1, "VNIS-007-1", 0, null, 2 },
                    { 1072, 2, "VNIS-007-2", 0, null, 2 },
                    { 1073, 3, "VNIS-007-3", 0, null, 2 },
                    { 1074, 4, "VNIS-007-4", 0, null, 2 },
                    { 1075, 5, "VNIS-007-5", 0, null, 2 },
                    { 1076, 6, "VNIS-007-6", 0, null, 2 },
                    { 1077, 7, "VNIS-007-7", 0, null, 2 },
                    { 1080, 0, "VNIS-008-0", 0, null, 2 },
                    { 1081, 1, "VNIS-008-1", 0, null, 2 },
                    { 1082, 2, "VNIS-008-2", 0, null, 2 },
                    { 1083, 3, "VNIS-008-3", 0, null, 2 },
                    { 1084, 4, "VNIS-008-4", 0, null, 2 },
                    { 1085, 5, "VNIS-008-5", 0, null, 2 },
                    { 1086, 6, "VNIS-008-6", 0, null, 2 },
                    { 1087, 7, "VNIS-008-7", 0, null, 2 },
                    { 1090, 0, "VNIS-009-0", 0, null, 2 },
                    { 1091, 1, "VNIS-009-1", 0, null, 2 },
                    { 1092, 2, "VNIS-009-2", 0, null, 2 },
                    { 1093, 3, "VNIS-009-3", 0, null, 2 },
                    { 1094, 4, "VNIS-009-4", 0, null, 2 },
                    { 1095, 5, "VNIS-009-5", 0, null, 2 },
                    { 1096, 6, "VNIS-009-6", 0, null, 2 },
                    { 1097, 7, "VNIS-009-7", 0, null, 2 },
                    { 1100, 0, "VNIS-010-0", 0, null, 2 },
                    { 1101, 1, "VNIS-010-1", 0, null, 2 },
                    { 1102, 2, "VNIS-010-2", 0, null, 2 },
                    { 1103, 3, "VNIS-010-3", 0, null, 2 },
                    { 1104, 4, "VNIS-010-4", 0, null, 2 },
                    { 1105, 5, "VNIS-010-5", 0, null, 2 },
                    { 1106, 6, "VNIS-010-6", 0, null, 2 },
                    { 1107, 7, "VNIS-010-7", 0, null, 2 },
                    { 1110, 0, "VNIS-011-0", 0, null, 2 },
                    { 1111, 1, "VNIS-011-1", 0, null, 2 },
                    { 1112, 2, "VNIS-011-2", 0, null, 2 },
                    { 1113, 3, "VNIS-011-3", 0, null, 2 },
                    { 1114, 4, "VNIS-011-4", 0, null, 2 },
                    { 1115, 5, "VNIS-011-5", 0, null, 2 },
                    { 1116, 6, "VNIS-011-6", 0, null, 2 },
                    { 1117, 7, "VNIS-011-7", 0, null, 2 },
                    { 1120, 0, "VNIS-012-0", 0, null, 2 },
                    { 1121, 1, "VNIS-012-1", 0, null, 2 },
                    { 1122, 2, "VNIS-012-2", 0, null, 2 },
                    { 1123, 3, "VNIS-012-3", 0, null, 2 },
                    { 1124, 4, "VNIS-012-4", 0, null, 2 },
                    { 1125, 5, "VNIS-012-5", 0, null, 2 },
                    { 1126, 6, "VNIS-012-6", 0, null, 2 },
                    { 1127, 7, "VNIS-012-7", 0, null, 2 },
                    { 1130, 0, "VNIS-013-0", 0, null, 2 },
                    { 1131, 1, "VNIS-013-1", 0, null, 2 },
                    { 1132, 2, "VNIS-013-2", 0, null, 2 },
                    { 1133, 3, "VNIS-013-3", 0, null, 2 },
                    { 1134, 4, "VNIS-013-4", 0, null, 2 },
                    { 1135, 5, "VNIS-013-5", 0, null, 2 },
                    { 1136, 6, "VNIS-013-6", 0, null, 2 },
                    { 1137, 7, "VNIS-013-7", 0, null, 2 },
                    { 1140, 0, "VNIS-014-0", 0, null, 2 },
                    { 1141, 1, "VNIS-014-1", 0, null, 2 },
                    { 1142, 2, "VNIS-014-2", 0, null, 2 },
                    { 1143, 3, "VNIS-014-3", 0, null, 2 },
                    { 1144, 4, "VNIS-014-4", 0, null, 2 },
                    { 1145, 5, "VNIS-014-5", 0, null, 2 },
                    { 1146, 6, "VNIS-014-6", 0, null, 2 },
                    { 1147, 7, "VNIS-014-7", 0, null, 2 },
                    { 1150, 0, "VNIS-015-0", 0, null, 2 },
                    { 1151, 1, "VNIS-015-1", 0, null, 2 },
                    { 1152, 2, "VNIS-015-2", 0, null, 2 },
                    { 1153, 3, "VNIS-015-3", 0, null, 2 },
                    { 1154, 4, "VNIS-015-4", 0, null, 2 },
                    { 1155, 5, "VNIS-015-5", 0, null, 2 },
                    { 1156, 6, "VNIS-015-6", 0, null, 2 },
                    { 1157, 7, "VNIS-015-7", 0, null, 2 },
                    { 1160, 0, "VNIS-016-0", 0, null, 2 },
                    { 1161, 1, "VNIS-016-1", 0, null, 2 },
                    { 1162, 2, "VNIS-016-2", 0, null, 2 },
                    { 1163, 3, "VNIS-016-3", 0, null, 2 },
                    { 1164, 4, "VNIS-016-4", 0, null, 2 },
                    { 1165, 5, "VNIS-016-5", 0, null, 2 },
                    { 1166, 6, "VNIS-016-6", 0, null, 2 },
                    { 1167, 7, "VNIS-016-7", 0, null, 2 },
                    { 1170, 0, "VNIS-017-0", 0, null, 2 },
                    { 1171, 1, "VNIS-017-1", 0, null, 2 },
                    { 1172, 2, "VNIS-017-2", 0, null, 2 },
                    { 1173, 3, "VNIS-017-3", 0, null, 2 },
                    { 1174, 4, "VNIS-017-4", 0, null, 2 },
                    { 1175, 5, "VNIS-017-5", 0, null, 2 },
                    { 1176, 6, "VNIS-017-6", 0, null, 2 },
                    { 1177, 7, "VNIS-017-7", 0, null, 2 },
                    { 1180, 0, "VNIS-018-0", 0, null, 2 },
                    { 1181, 1, "VNIS-018-1", 0, null, 2 },
                    { 1182, 2, "VNIS-018-2", 0, null, 2 },
                    { 1183, 3, "VNIS-018-3", 0, null, 2 },
                    { 1184, 4, "VNIS-018-4", 0, null, 2 },
                    { 1185, 5, "VNIS-018-5", 0, null, 2 },
                    { 1186, 6, "VNIS-018-6", 0, null, 2 },
                    { 1187, 7, "VNIS-018-7", 0, null, 2 },
                    { 1190, 0, "VNIS-019-0", 0, null, 2 },
                    { 1191, 1, "VNIS-019-1", 0, null, 2 },
                    { 1192, 2, "VNIS-019-2", 0, null, 2 },
                    { 1193, 3, "VNIS-019-3", 0, null, 2 },
                    { 1194, 4, "VNIS-019-4", 0, null, 2 },
                    { 1195, 5, "VNIS-019-5", 0, null, 2 },
                    { 1196, 6, "VNIS-019-6", 0, null, 2 },
                    { 1197, 7, "VNIS-019-7", 0, null, 2 },
                    { 1200, 0, "VNIS-020-0", 0, null, 2 },
                    { 1201, 1, "VNIS-020-1", 0, null, 2 },
                    { 1202, 2, "VNIS-020-2", 0, null, 2 },
                    { 1203, 3, "VNIS-020-3", 0, null, 2 },
                    { 1204, 4, "VNIS-020-4", 0, null, 2 },
                    { 1205, 5, "VNIS-020-5", 0, null, 2 },
                    { 1206, 6, "VNIS-020-6", 0, null, 2 },
                    { 1207, 7, "VNIS-020-7", 0, null, 2 },
                    { 1210, 0, "VNIS-021-0", 0, null, 2 },
                    { 1211, 1, "VNIS-021-1", 0, null, 2 },
                    { 1212, 2, "VNIS-021-2", 0, null, 2 },
                    { 1213, 3, "VNIS-021-3", 0, null, 2 },
                    { 1214, 4, "VNIS-021-4", 0, null, 2 },
                    { 1215, 5, "VNIS-021-5", 0, null, 2 },
                    { 1216, 6, "VNIS-021-6", 0, null, 2 },
                    { 1217, 7, "VNIS-021-7", 0, null, 2 },
                    { 1220, 0, "VNIS-022-0", 0, null, 2 },
                    { 1221, 1, "VNIS-022-1", 0, null, 2 },
                    { 1222, 2, "VNIS-022-2", 0, null, 2 },
                    { 1223, 3, "VNIS-022-3", 0, null, 2 },
                    { 1224, 4, "VNIS-022-4", 0, null, 2 },
                    { 1225, 5, "VNIS-022-5", 0, null, 2 },
                    { 1226, 6, "VNIS-022-6", 0, null, 2 },
                    { 1227, 7, "VNIS-022-7", 0, null, 2 },
                    { 1230, 0, "VNIS-023-0", 0, null, 2 },
                    { 1231, 1, "VNIS-023-1", 0, null, 2 },
                    { 1232, 2, "VNIS-023-2", 0, null, 2 },
                    { 1233, 3, "VNIS-023-3", 0, null, 2 },
                    { 1234, 4, "VNIS-023-4", 0, null, 2 },
                    { 1235, 5, "VNIS-023-5", 0, null, 2 },
                    { 1236, 6, "VNIS-023-6", 0, null, 2 },
                    { 1237, 7, "VNIS-023-7", 0, null, 2 },
                    { 1240, 0, "VNIS-024-0", 0, null, 2 },
                    { 1241, 1, "VNIS-024-1", 0, null, 2 },
                    { 1242, 2, "VNIS-024-2", 0, null, 2 },
                    { 1243, 3, "VNIS-024-3", 0, null, 2 },
                    { 1244, 4, "VNIS-024-4", 0, null, 2 },
                    { 1245, 5, "VNIS-024-5", 0, null, 2 },
                    { 1246, 6, "VNIS-024-6", 0, null, 2 },
                    { 1247, 7, "VNIS-024-7", 0, null, 2 },
                    { 1250, 0, "VNIS-025-0", 0, null, 2 },
                    { 1251, 1, "VNIS-025-1", 0, null, 2 },
                    { 1252, 2, "VNIS-025-2", 0, null, 2 },
                    { 1253, 3, "VNIS-025-3", 0, null, 2 },
                    { 1254, 4, "VNIS-025-4", 0, null, 2 },
                    { 1255, 5, "VNIS-025-5", 0, null, 2 },
                    { 1256, 6, "VNIS-025-6", 0, null, 2 },
                    { 1257, 7, "VNIS-025-7", 0, null, 2 },
                    { 1260, 0, "VNIS-026-0", 0, null, 2 },
                    { 1261, 1, "VNIS-026-1", 0, null, 2 },
                    { 1262, 2, "VNIS-026-2", 0, null, 2 },
                    { 1263, 3, "VNIS-026-3", 0, null, 2 },
                    { 1264, 4, "VNIS-026-4", 0, null, 2 },
                    { 1265, 5, "VNIS-026-5", 0, null, 2 },
                    { 1266, 6, "VNIS-026-6", 0, null, 2 },
                    { 1267, 7, "VNIS-026-7", 0, null, 2 },
                    { 1270, 0, "VNIS-027-0", 0, null, 2 },
                    { 1271, 1, "VNIS-027-1", 0, null, 2 },
                    { 1272, 2, "VNIS-027-2", 0, null, 2 },
                    { 1273, 3, "VNIS-027-3", 0, null, 2 },
                    { 1274, 4, "VNIS-027-4", 0, null, 2 },
                    { 1275, 5, "VNIS-027-5", 0, null, 2 },
                    { 1276, 6, "VNIS-027-6", 0, null, 2 },
                    { 1277, 7, "VNIS-027-7", 0, null, 2 },
                    { 1280, 0, "VNIS-028-0", 0, null, 2 },
                    { 1281, 1, "VNIS-028-1", 0, null, 2 },
                    { 1282, 2, "VNIS-028-2", 0, null, 2 },
                    { 1283, 3, "VNIS-028-3", 0, null, 2 },
                    { 1284, 4, "VNIS-028-4", 0, null, 2 },
                    { 1285, 5, "VNIS-028-5", 0, null, 2 },
                    { 1286, 6, "VNIS-028-6", 0, null, 2 },
                    { 1287, 7, "VNIS-028-7", 0, null, 2 },
                    { 1290, 0, "VNIS-029-0", 0, null, 2 },
                    { 1291, 1, "VNIS-029-1", 0, null, 2 },
                    { 1292, 2, "VNIS-029-2", 0, null, 2 },
                    { 1293, 3, "VNIS-029-3", 0, null, 2 },
                    { 1294, 4, "VNIS-029-4", 0, null, 2 },
                    { 1295, 5, "VNIS-029-5", 0, null, 2 },
                    { 1296, 6, "VNIS-029-6", 0, null, 2 },
                    { 1297, 7, "VNIS-029-7", 0, null, 2 },
                    { 1300, 0, "VNIS-030-0", 0, null, 2 },
                    { 1301, 1, "VNIS-030-1", 0, null, 2 },
                    { 1302, 2, "VNIS-030-2", 0, null, 2 },
                    { 1303, 3, "VNIS-030-3", 0, null, 2 },
                    { 1304, 4, "VNIS-030-4", 0, null, 2 },
                    { 1305, 5, "VNIS-030-5", 0, null, 2 },
                    { 1306, 6, "VNIS-030-6", 0, null, 2 },
                    { 1307, 7, "VNIS-030-7", 0, null, 2 },
                    { 1310, 0, "VNIS-031-0", 0, null, 2 },
                    { 1311, 1, "VNIS-031-1", 0, null, 2 },
                    { 1312, 2, "VNIS-031-2", 0, null, 2 },
                    { 1313, 3, "VNIS-031-3", 0, null, 2 },
                    { 1314, 4, "VNIS-031-4", 0, null, 2 },
                    { 1315, 5, "VNIS-031-5", 0, null, 2 },
                    { 1316, 6, "VNIS-031-6", 0, null, 2 },
                    { 1317, 7, "VNIS-031-7", 0, null, 2 },
                    { 1320, 0, "VNIS-032-0", 0, null, 2 },
                    { 1321, 1, "VNIS-032-1", 0, null, 2 },
                    { 1322, 2, "VNIS-032-2", 0, null, 2 },
                    { 1323, 3, "VNIS-032-3", 0, null, 2 },
                    { 1324, 4, "VNIS-032-4", 0, null, 2 },
                    { 1325, 5, "VNIS-032-5", 0, null, 2 },
                    { 1326, 6, "VNIS-032-6", 0, null, 2 },
                    { 1327, 7, "VNIS-032-7", 0, null, 2 },
                    { 1330, 0, "VNIS-033-0", 0, null, 2 },
                    { 1331, 1, "VNIS-033-1", 0, null, 2 },
                    { 1332, 2, "VNIS-033-2", 0, null, 2 },
                    { 1333, 3, "VNIS-033-3", 0, null, 2 },
                    { 1334, 4, "VNIS-033-4", 0, null, 2 },
                    { 1335, 5, "VNIS-033-5", 0, null, 2 },
                    { 1336, 6, "VNIS-033-6", 0, null, 2 },
                    { 1337, 7, "VNIS-033-7", 0, null, 2 },
                    { 1340, 0, "VNIS-034-0", 0, null, 2 },
                    { 1341, 1, "VNIS-034-1", 0, null, 2 },
                    { 1342, 2, "VNIS-034-2", 0, null, 2 },
                    { 1343, 3, "VNIS-034-3", 0, null, 2 },
                    { 1344, 4, "VNIS-034-4", 0, null, 2 },
                    { 1345, 5, "VNIS-034-5", 0, null, 2 },
                    { 1346, 6, "VNIS-034-6", 0, null, 2 },
                    { 1347, 7, "VNIS-034-7", 0, null, 2 },
                    { 1350, 0, "VNIS-035-0", 0, null, 2 },
                    { 1351, 1, "VNIS-035-1", 0, null, 2 },
                    { 1352, 2, "VNIS-035-2", 0, null, 2 },
                    { 1353, 3, "VNIS-035-3", 0, null, 2 },
                    { 1354, 4, "VNIS-035-4", 0, null, 2 },
                    { 1355, 5, "VNIS-035-5", 0, null, 2 },
                    { 1356, 6, "VNIS-035-6", 0, null, 2 },
                    { 1357, 7, "VNIS-035-7", 0, null, 2 },
                    { 1360, 0, "VNIS-036-0", 0, null, 2 },
                    { 1361, 1, "VNIS-036-1", 0, null, 2 },
                    { 1362, 2, "VNIS-036-2", 0, null, 2 },
                    { 1363, 3, "VNIS-036-3", 0, null, 2 },
                    { 1364, 4, "VNIS-036-4", 0, null, 2 },
                    { 1365, 5, "VNIS-036-5", 0, null, 2 },
                    { 1366, 6, "VNIS-036-6", 0, null, 2 },
                    { 1367, 7, "VNIS-036-7", 0, null, 2 },
                    { 1370, 0, "VNIS-037-0", 0, null, 2 },
                    { 1371, 1, "VNIS-037-1", 0, null, 2 },
                    { 1372, 2, "VNIS-037-2", 0, null, 2 },
                    { 1373, 3, "VNIS-037-3", 0, null, 2 },
                    { 1374, 4, "VNIS-037-4", 0, null, 2 },
                    { 1375, 5, "VNIS-037-5", 0, null, 2 },
                    { 1376, 6, "VNIS-037-6", 0, null, 2 },
                    { 1377, 7, "VNIS-037-7", 0, null, 2 },
                    { 1380, 0, "VNIS-038-0", 0, null, 2 },
                    { 1381, 1, "VNIS-038-1", 0, null, 2 },
                    { 1382, 2, "VNIS-038-2", 0, null, 2 },
                    { 1383, 3, "VNIS-038-3", 0, null, 2 },
                    { 1384, 4, "VNIS-038-4", 0, null, 2 },
                    { 1385, 5, "VNIS-038-5", 0, null, 2 },
                    { 1386, 6, "VNIS-038-6", 0, null, 2 },
                    { 1387, 7, "VNIS-038-7", 0, null, 2 },
                    { 1390, 0, "VNIS-039-0", 0, null, 2 },
                    { 1391, 1, "VNIS-039-1", 0, null, 2 },
                    { 1392, 2, "VNIS-039-2", 0, null, 2 },
                    { 1393, 3, "VNIS-039-3", 0, null, 2 },
                    { 1394, 4, "VNIS-039-4", 0, null, 2 },
                    { 1395, 5, "VNIS-039-5", 0, null, 2 },
                    { 1396, 6, "VNIS-039-6", 0, null, 2 },
                    { 1397, 7, "VNIS-039-7", 0, null, 2 },
                    { 1400, 0, "VNIS-040-0", 0, null, 2 },
                    { 1401, 1, "VNIS-040-1", 0, null, 2 },
                    { 1402, 2, "VNIS-040-2", 0, null, 2 },
                    { 1403, 3, "VNIS-040-3", 0, null, 2 },
                    { 1404, 4, "VNIS-040-4", 0, null, 2 },
                    { 1405, 5, "VNIS-040-5", 0, null, 2 },
                    { 1406, 6, "VNIS-040-6", 0, null, 2 },
                    { 1407, 7, "VNIS-040-7", 0, null, 2 },
                    { 1410, 0, "VNIS-041-0", 0, null, 2 },
                    { 1411, 1, "VNIS-041-1", 0, null, 2 },
                    { 1412, 2, "VNIS-041-2", 0, null, 2 },
                    { 1413, 3, "VNIS-041-3", 0, null, 2 },
                    { 1414, 4, "VNIS-041-4", 0, null, 2 },
                    { 1415, 5, "VNIS-041-5", 0, null, 2 },
                    { 1416, 6, "VNIS-041-6", 0, null, 2 },
                    { 1417, 7, "VNIS-041-7", 0, null, 2 },
                    { 1420, 0, "VNIS-042-0", 0, null, 2 },
                    { 1421, 1, "VNIS-042-1", 0, null, 2 },
                    { 1422, 2, "VNIS-042-2", 0, null, 2 },
                    { 1423, 3, "VNIS-042-3", 0, null, 2 },
                    { 1424, 4, "VNIS-042-4", 0, null, 2 },
                    { 1425, 5, "VNIS-042-5", 0, null, 2 },
                    { 1426, 6, "VNIS-042-6", 0, null, 2 },
                    { 1427, 7, "VNIS-042-7", 0, null, 2 },
                    { 1430, 0, "VNIS-043-0", 0, null, 2 },
                    { 1431, 1, "VNIS-043-1", 0, null, 2 },
                    { 1432, 2, "VNIS-043-2", 0, null, 2 },
                    { 1433, 3, "VNIS-043-3", 0, null, 2 },
                    { 1434, 4, "VNIS-043-4", 0, null, 2 },
                    { 1435, 5, "VNIS-043-5", 0, null, 2 },
                    { 1436, 6, "VNIS-043-6", 0, null, 2 },
                    { 1437, 7, "VNIS-043-7", 0, null, 2 },
                    { 1440, 0, "VNIS-044-0", 0, null, 2 },
                    { 1441, 1, "VNIS-044-1", 0, null, 2 },
                    { 1442, 2, "VNIS-044-2", 0, null, 2 },
                    { 1443, 3, "VNIS-044-3", 0, null, 2 },
                    { 1444, 4, "VNIS-044-4", 0, null, 2 },
                    { 1445, 5, "VNIS-044-5", 0, null, 2 },
                    { 1446, 6, "VNIS-044-6", 0, null, 2 },
                    { 1447, 7, "VNIS-044-7", 0, null, 2 },
                    { 1450, 0, "VNIS-045-0", 0, null, 2 },
                    { 1451, 1, "VNIS-045-1", 0, null, 2 },
                    { 1452, 2, "VNIS-045-2", 0, null, 2 },
                    { 1453, 3, "VNIS-045-3", 0, null, 2 },
                    { 1454, 4, "VNIS-045-4", 0, null, 2 },
                    { 1455, 5, "VNIS-045-5", 0, null, 2 },
                    { 1456, 6, "VNIS-045-6", 0, null, 2 },
                    { 1457, 7, "VNIS-045-7", 0, null, 2 },
                    { 1460, 0, "VNIS-046-0", 0, null, 2 },
                    { 1461, 1, "VNIS-046-1", 0, null, 2 },
                    { 1462, 2, "VNIS-046-2", 0, null, 2 },
                    { 1463, 3, "VNIS-046-3", 0, null, 2 },
                    { 1464, 4, "VNIS-046-4", 0, null, 2 },
                    { 1465, 5, "VNIS-046-5", 0, null, 2 },
                    { 1466, 6, "VNIS-046-6", 0, null, 2 },
                    { 1467, 7, "VNIS-046-7", 0, null, 2 },
                    { 1470, 0, "VNIS-047-0", 0, null, 2 },
                    { 1471, 1, "VNIS-047-1", 0, null, 2 },
                    { 1472, 2, "VNIS-047-2", 0, null, 2 },
                    { 1473, 3, "VNIS-047-3", 0, null, 2 },
                    { 1474, 4, "VNIS-047-4", 0, null, 2 },
                    { 1475, 5, "VNIS-047-5", 0, null, 2 },
                    { 1476, 6, "VNIS-047-6", 0, null, 2 },
                    { 1477, 7, "VNIS-047-7", 0, null, 2 },
                    { 1480, 0, "VNIS-048-0", 0, null, 2 },
                    { 1481, 1, "VNIS-048-1", 0, null, 2 },
                    { 1482, 2, "VNIS-048-2", 0, null, 2 },
                    { 1483, 3, "VNIS-048-3", 0, null, 2 },
                    { 1484, 4, "VNIS-048-4", 0, null, 2 },
                    { 1485, 5, "VNIS-048-5", 0, null, 2 },
                    { 1486, 6, "VNIS-048-6", 0, null, 2 },
                    { 1487, 7, "VNIS-048-7", 0, null, 2 },
                    { 1490, 0, "VNIS-049-0", 0, null, 2 },
                    { 1491, 1, "VNIS-049-1", 0, null, 2 },
                    { 1492, 2, "VNIS-049-2", 0, null, 2 },
                    { 1493, 3, "VNIS-049-3", 0, null, 2 },
                    { 1494, 4, "VNIS-049-4", 0, null, 2 },
                    { 1495, 5, "VNIS-049-5", 0, null, 2 },
                    { 1496, 6, "VNIS-049-6", 0, null, 2 },
                    { 1497, 7, "VNIS-049-7", 0, null, 2 },
                    { 1500, 0, "VNIS-050-0", 0, null, 2 },
                    { 1501, 1, "VNIS-050-1", 0, null, 2 },
                    { 1502, 2, "VNIS-050-2", 0, null, 2 },
                    { 1503, 3, "VNIS-050-3", 0, null, 2 },
                    { 1504, 4, "VNIS-050-4", 0, null, 2 },
                    { 1505, 5, "VNIS-050-5", 0, null, 2 },
                    { 1506, 6, "VNIS-050-6", 0, null, 2 },
                    { 1507, 7, "VNIS-050-7", 0, null, 2 },
                    { 1510, 0, "VNIS-051-0", 0, null, 2 },
                    { 1511, 1, "VNIS-051-1", 0, null, 2 },
                    { 1512, 2, "VNIS-051-2", 0, null, 2 },
                    { 1513, 3, "VNIS-051-3", 0, null, 2 },
                    { 1514, 4, "VNIS-051-4", 0, null, 2 },
                    { 1515, 5, "VNIS-051-5", 0, null, 2 },
                    { 1516, 6, "VNIS-051-6", 0, null, 2 },
                    { 1517, 7, "VNIS-051-7", 0, null, 2 },
                    { 1520, 0, "VNIS-052-0", 0, null, 2 },
                    { 1521, 1, "VNIS-052-1", 0, null, 2 },
                    { 1522, 2, "VNIS-052-2", 0, null, 2 },
                    { 1523, 3, "VNIS-052-3", 0, null, 2 },
                    { 1524, 4, "VNIS-052-4", 0, null, 2 },
                    { 1525, 5, "VNIS-052-5", 0, null, 2 },
                    { 1526, 6, "VNIS-052-6", 0, null, 2 },
                    { 1527, 7, "VNIS-052-7", 0, null, 2 },
                    { 1530, 0, "VNIS-053-0", 0, null, 2 },
                    { 1531, 1, "VNIS-053-1", 0, null, 2 },
                    { 1532, 2, "VNIS-053-2", 0, null, 2 },
                    { 1533, 3, "VNIS-053-3", 0, null, 2 },
                    { 1534, 4, "VNIS-053-4", 0, null, 2 },
                    { 1535, 5, "VNIS-053-5", 0, null, 2 },
                    { 1536, 6, "VNIS-053-6", 0, null, 2 },
                    { 1537, 7, "VNIS-053-7", 0, null, 2 },
                    { 1540, 0, "VNIS-054-0", 0, null, 2 },
                    { 1541, 1, "VNIS-054-1", 0, null, 2 },
                    { 1542, 2, "VNIS-054-2", 0, null, 2 },
                    { 1543, 3, "VNIS-054-3", 0, null, 2 },
                    { 1544, 4, "VNIS-054-4", 0, null, 2 },
                    { 1545, 5, "VNIS-054-5", 0, null, 2 },
                    { 1546, 6, "VNIS-054-6", 0, null, 2 },
                    { 1547, 7, "VNIS-054-7", 0, null, 2 },
                    { 1550, 0, "VNIS-055-0", 0, null, 2 },
                    { 1551, 1, "VNIS-055-1", 0, null, 2 },
                    { 1552, 2, "VNIS-055-2", 0, null, 2 },
                    { 1553, 3, "VNIS-055-3", 0, null, 2 },
                    { 1554, 4, "VNIS-055-4", 0, null, 2 },
                    { 1555, 5, "VNIS-055-5", 0, null, 2 },
                    { 1556, 6, "VNIS-055-6", 0, null, 2 },
                    { 1557, 7, "VNIS-055-7", 0, null, 2 },
                    { 1560, 0, "VNIS-056-0", 0, null, 2 },
                    { 1561, 1, "VNIS-056-1", 0, null, 2 },
                    { 1562, 2, "VNIS-056-2", 0, null, 2 },
                    { 1563, 3, "VNIS-056-3", 0, null, 2 },
                    { 1564, 4, "VNIS-056-4", 0, null, 2 },
                    { 1565, 5, "VNIS-056-5", 0, null, 2 },
                    { 1566, 6, "VNIS-056-6", 0, null, 2 },
                    { 1567, 7, "VNIS-056-7", 0, null, 2 },
                    { 1570, 0, "VNIS-057-0", 0, null, 2 },
                    { 1571, 1, "VNIS-057-1", 0, null, 2 },
                    { 1572, 2, "VNIS-057-2", 0, null, 2 },
                    { 1573, 3, "VNIS-057-3", 0, null, 2 },
                    { 1574, 4, "VNIS-057-4", 0, null, 2 },
                    { 1575, 5, "VNIS-057-5", 0, null, 2 },
                    { 1576, 6, "VNIS-057-6", 0, null, 2 },
                    { 1577, 7, "VNIS-057-7", 0, null, 2 },
                    { 1580, 0, "VNIS-058-0", 0, null, 2 },
                    { 1581, 1, "VNIS-058-1", 0, null, 2 },
                    { 1582, 2, "VNIS-058-2", 0, null, 2 },
                    { 1583, 3, "VNIS-058-3", 0, null, 2 },
                    { 1584, 4, "VNIS-058-4", 0, null, 2 },
                    { 1585, 5, "VNIS-058-5", 0, null, 2 },
                    { 1586, 6, "VNIS-058-6", 0, null, 2 },
                    { 1587, 7, "VNIS-058-7", 0, null, 2 },
                    { 1590, 0, "VNIS-059-0", 0, null, 2 },
                    { 1591, 1, "VNIS-059-1", 0, null, 2 },
                    { 1592, 2, "VNIS-059-2", 0, null, 2 },
                    { 1593, 3, "VNIS-059-3", 0, null, 2 },
                    { 1594, 4, "VNIS-059-4", 0, null, 2 },
                    { 1595, 5, "VNIS-059-5", 0, null, 2 },
                    { 1596, 6, "VNIS-059-6", 0, null, 2 },
                    { 1597, 7, "VNIS-059-7", 0, null, 2 },
                    { 1600, 0, "VNIS-060-0", 0, null, 2 },
                    { 1601, 1, "VNIS-060-1", 0, null, 2 },
                    { 1602, 2, "VNIS-060-2", 0, null, 2 },
                    { 1603, 3, "VNIS-060-3", 0, null, 2 },
                    { 1604, 4, "VNIS-060-4", 0, null, 2 },
                    { 1605, 5, "VNIS-060-5", 0, null, 2 },
                    { 1606, 6, "VNIS-060-6", 0, null, 2 },
                    { 1607, 7, "VNIS-060-7", 0, null, 2 },
                    { 1610, 0, "VNIS-061-0", 0, null, 2 },
                    { 1611, 1, "VNIS-061-1", 0, null, 2 },
                    { 1612, 2, "VNIS-061-2", 0, null, 2 },
                    { 1613, 3, "VNIS-061-3", 0, null, 2 },
                    { 1614, 4, "VNIS-061-4", 0, null, 2 },
                    { 1615, 5, "VNIS-061-5", 0, null, 2 },
                    { 1616, 6, "VNIS-061-6", 0, null, 2 },
                    { 1617, 7, "VNIS-061-7", 0, null, 2 },
                    { 1620, 0, "VNIS-062-0", 0, null, 2 },
                    { 1621, 1, "VNIS-062-1", 0, null, 2 },
                    { 1622, 2, "VNIS-062-2", 0, null, 2 },
                    { 1623, 3, "VNIS-062-3", 0, null, 2 },
                    { 1624, 4, "VNIS-062-4", 0, null, 2 },
                    { 1625, 5, "VNIS-062-5", 0, null, 2 },
                    { 1626, 6, "VNIS-062-6", 0, null, 2 },
                    { 1627, 7, "VNIS-062-7", 0, null, 2 },
                    { 1630, 0, "VNIS-063-0", 0, null, 2 },
                    { 1631, 1, "VNIS-063-1", 0, null, 2 },
                    { 1632, 2, "VNIS-063-2", 0, null, 2 },
                    { 1633, 3, "VNIS-063-3", 0, null, 2 },
                    { 1634, 4, "VNIS-063-4", 0, null, 2 },
                    { 1635, 5, "VNIS-063-5", 0, null, 2 },
                    { 1636, 6, "VNIS-063-6", 0, null, 2 },
                    { 1637, 7, "VNIS-063-7", 0, null, 2 },
                    { 1640, 0, "VNIS-064-0", 0, null, 2 },
                    { 1641, 1, "VNIS-064-1", 0, null, 2 },
                    { 1642, 2, "VNIS-064-2", 0, null, 2 },
                    { 1643, 3, "VNIS-064-3", 0, null, 2 },
                    { 1644, 4, "VNIS-064-4", 0, null, 2 },
                    { 1645, 5, "VNIS-064-5", 0, null, 2 },
                    { 1646, 6, "VNIS-064-6", 0, null, 2 },
                    { 1647, 7, "VNIS-064-7", 0, null, 2 },
                    { 1650, 0, "VNIS-065-0", 0, null, 2 },
                    { 1651, 1, "VNIS-065-1", 0, null, 2 },
                    { 1652, 2, "VNIS-065-2", 0, null, 2 },
                    { 1653, 3, "VNIS-065-3", 0, null, 2 },
                    { 1654, 4, "VNIS-065-4", 0, null, 2 },
                    { 1655, 5, "VNIS-065-5", 0, null, 2 },
                    { 1656, 6, "VNIS-065-6", 0, null, 2 },
                    { 1657, 7, "VNIS-065-7", 0, null, 2 },
                    { 1660, 0, "VNIS-066-0", 0, null, 2 },
                    { 1661, 1, "VNIS-066-1", 0, null, 2 },
                    { 1662, 2, "VNIS-066-2", 0, null, 2 },
                    { 1663, 3, "VNIS-066-3", 0, null, 2 },
                    { 1664, 4, "VNIS-066-4", 0, null, 2 },
                    { 1665, 5, "VNIS-066-5", 0, null, 2 },
                    { 1666, 6, "VNIS-066-6", 0, null, 2 },
                    { 1667, 7, "VNIS-066-7", 0, null, 2 },
                    { 1670, 0, "VNIS-067-0", 0, null, 2 },
                    { 1671, 1, "VNIS-067-1", 0, null, 2 },
                    { 1672, 2, "VNIS-067-2", 0, null, 2 },
                    { 1673, 3, "VNIS-067-3", 0, null, 2 },
                    { 1674, 4, "VNIS-067-4", 0, null, 2 },
                    { 1675, 5, "VNIS-067-5", 0, null, 2 },
                    { 1676, 6, "VNIS-067-6", 0, null, 2 },
                    { 1677, 7, "VNIS-067-7", 0, null, 2 },
                    { 1680, 0, "VNIS-068-0", 0, null, 2 },
                    { 1681, 1, "VNIS-068-1", 0, null, 2 },
                    { 1682, 2, "VNIS-068-2", 0, null, 2 },
                    { 1683, 3, "VNIS-068-3", 0, null, 2 },
                    { 1684, 4, "VNIS-068-4", 0, null, 2 },
                    { 1685, 5, "VNIS-068-5", 0, null, 2 },
                    { 1686, 6, "VNIS-068-6", 0, null, 2 },
                    { 1687, 7, "VNIS-068-7", 0, null, 2 },
                    { 1690, 0, "VNIS-069-0", 0, null, 2 },
                    { 1691, 1, "VNIS-069-1", 0, null, 2 },
                    { 1692, 2, "VNIS-069-2", 0, null, 2 },
                    { 1693, 3, "VNIS-069-3", 0, null, 2 },
                    { 1694, 4, "VNIS-069-4", 0, null, 2 },
                    { 1695, 5, "VNIS-069-5", 0, null, 2 },
                    { 1696, 6, "VNIS-069-6", 0, null, 2 },
                    { 1697, 7, "VNIS-069-7", 0, null, 2 },
                    { 1700, 0, "VNIS-070-0", 0, null, 2 },
                    { 1701, 1, "VNIS-070-1", 0, null, 2 },
                    { 1702, 2, "VNIS-070-2", 0, null, 2 },
                    { 1703, 3, "VNIS-070-3", 0, null, 2 },
                    { 1704, 4, "VNIS-070-4", 0, null, 2 },
                    { 1705, 5, "VNIS-070-5", 0, null, 2 },
                    { 1706, 6, "VNIS-070-6", 0, null, 2 },
                    { 1707, 7, "VNIS-070-7", 0, null, 2 },
                    { 1710, 0, "VNIS-071-0", 0, null, 2 },
                    { 1711, 1, "VNIS-071-1", 0, null, 2 },
                    { 1712, 2, "VNIS-071-2", 0, null, 2 },
                    { 1713, 3, "VNIS-071-3", 0, null, 2 },
                    { 1714, 4, "VNIS-071-4", 0, null, 2 },
                    { 1715, 5, "VNIS-071-5", 0, null, 2 },
                    { 1716, 6, "VNIS-071-6", 0, null, 2 },
                    { 1717, 7, "VNIS-071-7", 0, null, 2 },
                    { 1720, 0, "VNIS-072-0", 0, null, 2 },
                    { 1721, 1, "VNIS-072-1", 0, null, 2 },
                    { 1722, 2, "VNIS-072-2", 0, null, 2 },
                    { 1723, 3, "VNIS-072-3", 0, null, 2 },
                    { 1724, 4, "VNIS-072-4", 0, null, 2 },
                    { 1725, 5, "VNIS-072-5", 0, null, 2 },
                    { 1726, 6, "VNIS-072-6", 0, null, 2 },
                    { 1727, 7, "VNIS-072-7", 0, null, 2 },
                    { 1730, 0, "VNIS-073-0", 0, null, 2 },
                    { 1731, 1, "VNIS-073-1", 0, null, 2 },
                    { 1732, 2, "VNIS-073-2", 0, null, 2 },
                    { 1733, 3, "VNIS-073-3", 0, null, 2 },
                    { 1734, 4, "VNIS-073-4", 0, null, 2 },
                    { 1735, 5, "VNIS-073-5", 0, null, 2 },
                    { 1736, 6, "VNIS-073-6", 0, null, 2 },
                    { 1737, 7, "VNIS-073-7", 0, null, 2 },
                    { 1740, 0, "VNIS-074-0", 0, null, 2 },
                    { 1741, 1, "VNIS-074-1", 0, null, 2 },
                    { 1742, 2, "VNIS-074-2", 0, null, 2 },
                    { 1743, 3, "VNIS-074-3", 0, null, 2 },
                    { 1744, 4, "VNIS-074-4", 0, null, 2 },
                    { 1745, 5, "VNIS-074-5", 0, null, 2 },
                    { 1746, 6, "VNIS-074-6", 0, null, 2 },
                    { 1747, 7, "VNIS-074-7", 0, null, 2 },
                    { 1750, 0, "VNIS-075-0", 0, null, 2 },
                    { 1751, 1, "VNIS-075-1", 0, null, 2 },
                    { 1752, 2, "VNIS-075-2", 0, null, 2 },
                    { 1753, 3, "VNIS-075-3", 0, null, 2 },
                    { 1754, 4, "VNIS-075-4", 0, null, 2 },
                    { 1755, 5, "VNIS-075-5", 0, null, 2 },
                    { 1756, 6, "VNIS-075-6", 0, null, 2 },
                    { 1757, 7, "VNIS-075-7", 0, null, 2 },
                    { 1760, 0, "VNIS-076-0", 0, null, 2 },
                    { 1761, 1, "VNIS-076-1", 0, null, 2 },
                    { 1762, 2, "VNIS-076-2", 0, null, 2 },
                    { 1763, 3, "VNIS-076-3", 0, null, 2 },
                    { 1764, 4, "VNIS-076-4", 0, null, 2 },
                    { 1765, 5, "VNIS-076-5", 0, null, 2 },
                    { 1766, 6, "VNIS-076-6", 0, null, 2 },
                    { 1767, 7, "VNIS-076-7", 0, null, 2 },
                    { 1770, 0, "VNIS-077-0", 0, null, 2 },
                    { 1771, 1, "VNIS-077-1", 0, null, 2 },
                    { 1772, 2, "VNIS-077-2", 0, null, 2 },
                    { 1773, 3, "VNIS-077-3", 0, null, 2 },
                    { 1774, 4, "VNIS-077-4", 0, null, 2 },
                    { 1775, 5, "VNIS-077-5", 0, null, 2 },
                    { 1776, 6, "VNIS-077-6", 0, null, 2 },
                    { 1777, 7, "VNIS-077-7", 0, null, 2 },
                    { 1780, 0, "VNIS-078-0", 0, null, 2 },
                    { 1781, 1, "VNIS-078-1", 0, null, 2 },
                    { 1782, 2, "VNIS-078-2", 0, null, 2 },
                    { 1783, 3, "VNIS-078-3", 0, null, 2 },
                    { 1784, 4, "VNIS-078-4", 0, null, 2 },
                    { 1785, 5, "VNIS-078-5", 0, null, 2 },
                    { 1786, 6, "VNIS-078-6", 0, null, 2 },
                    { 1787, 7, "VNIS-078-7", 0, null, 2 },
                    { 1790, 0, "VNIS-079-0", 0, null, 2 },
                    { 1791, 1, "VNIS-079-1", 0, null, 2 },
                    { 1792, 2, "VNIS-079-2", 0, null, 2 },
                    { 1793, 3, "VNIS-079-3", 0, null, 2 },
                    { 1794, 4, "VNIS-079-4", 0, null, 2 },
                    { 1795, 5, "VNIS-079-5", 0, null, 2 },
                    { 1796, 6, "VNIS-079-6", 0, null, 2 },
                    { 1797, 7, "VNIS-079-7", 0, null, 2 },
                    { 1800, 0, "VNIS-080-0", 0, null, 2 },
                    { 1801, 1, "VNIS-080-1", 0, null, 2 },
                    { 1802, 2, "VNIS-080-2", 0, null, 2 },
                    { 1803, 3, "VNIS-080-3", 0, null, 2 },
                    { 1804, 4, "VNIS-080-4", 0, null, 2 },
                    { 1805, 5, "VNIS-080-5", 0, null, 2 },
                    { 1806, 6, "VNIS-080-6", 0, null, 2 },
                    { 1807, 7, "VNIS-080-7", 0, null, 2 },
                    { 1810, 0, "VNIS-081-0", 0, null, 2 },
                    { 1811, 1, "VNIS-081-1", 0, null, 2 },
                    { 1812, 2, "VNIS-081-2", 0, null, 2 },
                    { 1813, 3, "VNIS-081-3", 0, null, 2 },
                    { 1814, 4, "VNIS-081-4", 0, null, 2 },
                    { 1815, 5, "VNIS-081-5", 0, null, 2 },
                    { 1816, 6, "VNIS-081-6", 0, null, 2 },
                    { 1817, 7, "VNIS-081-7", 0, null, 2 },
                    { 1820, 0, "VNIS-082-0", 0, null, 2 },
                    { 1821, 1, "VNIS-082-1", 0, null, 2 },
                    { 1822, 2, "VNIS-082-2", 0, null, 2 },
                    { 1823, 3, "VNIS-082-3", 0, null, 2 },
                    { 1824, 4, "VNIS-082-4", 0, null, 2 },
                    { 1825, 5, "VNIS-082-5", 0, null, 2 },
                    { 1826, 6, "VNIS-082-6", 0, null, 2 },
                    { 1827, 7, "VNIS-082-7", 0, null, 2 },
                    { 1830, 0, "VNIS-083-0", 0, null, 2 },
                    { 1831, 1, "VNIS-083-1", 0, null, 2 },
                    { 1832, 2, "VNIS-083-2", 0, null, 2 },
                    { 1833, 3, "VNIS-083-3", 0, null, 2 },
                    { 1834, 4, "VNIS-083-4", 0, null, 2 },
                    { 1835, 5, "VNIS-083-5", 0, null, 2 },
                    { 1836, 6, "VNIS-083-6", 0, null, 2 },
                    { 1837, 7, "VNIS-083-7", 0, null, 2 },
                    { 1840, 0, "VNIS-084-0", 0, null, 2 },
                    { 1841, 1, "VNIS-084-1", 0, null, 2 },
                    { 1842, 2, "VNIS-084-2", 0, null, 2 },
                    { 1843, 3, "VNIS-084-3", 0, null, 2 },
                    { 1844, 4, "VNIS-084-4", 0, null, 2 },
                    { 1845, 5, "VNIS-084-5", 0, null, 2 },
                    { 1846, 6, "VNIS-084-6", 0, null, 2 },
                    { 1847, 7, "VNIS-084-7", 0, null, 2 },
                    { 1850, 0, "VNIS-085-0", 0, null, 2 },
                    { 1851, 1, "VNIS-085-1", 0, null, 2 },
                    { 1852, 2, "VNIS-085-2", 0, null, 2 },
                    { 1853, 3, "VNIS-085-3", 0, null, 2 },
                    { 1854, 4, "VNIS-085-4", 0, null, 2 },
                    { 1855, 5, "VNIS-085-5", 0, null, 2 },
                    { 1856, 6, "VNIS-085-6", 0, null, 2 },
                    { 1857, 7, "VNIS-085-7", 0, null, 2 },
                    { 1860, 0, "VNIS-086-0", 0, null, 2 },
                    { 1861, 1, "VNIS-086-1", 0, null, 2 },
                    { 1862, 2, "VNIS-086-2", 0, null, 2 },
                    { 1863, 3, "VNIS-086-3", 0, null, 2 },
                    { 1864, 4, "VNIS-086-4", 0, null, 2 },
                    { 1865, 5, "VNIS-086-5", 0, null, 2 },
                    { 1866, 6, "VNIS-086-6", 0, null, 2 },
                    { 1867, 7, "VNIS-086-7", 0, null, 2 },
                    { 1870, 0, "VNIS-087-0", 0, null, 2 },
                    { 1871, 1, "VNIS-087-1", 0, null, 2 },
                    { 1872, 2, "VNIS-087-2", 0, null, 2 },
                    { 1873, 3, "VNIS-087-3", 0, null, 2 },
                    { 1874, 4, "VNIS-087-4", 0, null, 2 },
                    { 1875, 5, "VNIS-087-5", 0, null, 2 },
                    { 1876, 6, "VNIS-087-6", 0, null, 2 },
                    { 1877, 7, "VNIS-087-7", 0, null, 2 },
                    { 1880, 0, "VNIS-088-0", 0, null, 2 },
                    { 1881, 1, "VNIS-088-1", 0, null, 2 },
                    { 1882, 2, "VNIS-088-2", 0, null, 2 },
                    { 1883, 3, "VNIS-088-3", 0, null, 2 },
                    { 1884, 4, "VNIS-088-4", 0, null, 2 },
                    { 1885, 5, "VNIS-088-5", 0, null, 2 },
                    { 1886, 6, "VNIS-088-6", 0, null, 2 },
                    { 1887, 7, "VNIS-088-7", 0, null, 2 },
                    { 1890, 0, "VNIS-089-0", 0, null, 2 },
                    { 1891, 1, "VNIS-089-1", 0, null, 2 },
                    { 1892, 2, "VNIS-089-2", 0, null, 2 },
                    { 1893, 3, "VNIS-089-3", 0, null, 2 },
                    { 1894, 4, "VNIS-089-4", 0, null, 2 },
                    { 1895, 5, "VNIS-089-5", 0, null, 2 },
                    { 1896, 6, "VNIS-089-6", 0, null, 2 },
                    { 1897, 7, "VNIS-089-7", 0, null, 2 },
                    { 1900, 0, "VNIS-090-0", 0, null, 2 },
                    { 1901, 1, "VNIS-090-1", 0, null, 2 },
                    { 1902, 2, "VNIS-090-2", 0, null, 2 },
                    { 1903, 3, "VNIS-090-3", 0, null, 2 },
                    { 1904, 4, "VNIS-090-4", 0, null, 2 },
                    { 1905, 5, "VNIS-090-5", 0, null, 2 },
                    { 1906, 6, "VNIS-090-6", 0, null, 2 },
                    { 1907, 7, "VNIS-090-7", 0, null, 2 },
                    { 1910, 0, "VNIS-091-0", 0, null, 2 },
                    { 1911, 1, "VNIS-091-1", 0, null, 2 },
                    { 1912, 2, "VNIS-091-2", 0, null, 2 },
                    { 1913, 3, "VNIS-091-3", 0, null, 2 },
                    { 1914, 4, "VNIS-091-4", 0, null, 2 },
                    { 1915, 5, "VNIS-091-5", 0, null, 2 },
                    { 1916, 6, "VNIS-091-6", 0, null, 2 },
                    { 1917, 7, "VNIS-091-7", 0, null, 2 },
                    { 1920, 0, "VNIS-092-0", 0, null, 2 },
                    { 1921, 1, "VNIS-092-1", 0, null, 2 },
                    { 1922, 2, "VNIS-092-2", 0, null, 2 },
                    { 1923, 3, "VNIS-092-3", 0, null, 2 },
                    { 1924, 4, "VNIS-092-4", 0, null, 2 },
                    { 1925, 5, "VNIS-092-5", 0, null, 2 },
                    { 1926, 6, "VNIS-092-6", 0, null, 2 },
                    { 1927, 7, "VNIS-092-7", 0, null, 2 },
                    { 1930, 0, "VNIS-093-0", 0, null, 2 },
                    { 1931, 1, "VNIS-093-1", 0, null, 2 },
                    { 1932, 2, "VNIS-093-2", 0, null, 2 },
                    { 1933, 3, "VNIS-093-3", 0, null, 2 },
                    { 1934, 4, "VNIS-093-4", 0, null, 2 },
                    { 1935, 5, "VNIS-093-5", 0, null, 2 },
                    { 1936, 6, "VNIS-093-6", 0, null, 2 },
                    { 1937, 7, "VNIS-093-7", 0, null, 2 },
                    { 1940, 0, "VNIS-094-0", 0, null, 2 },
                    { 1941, 1, "VNIS-094-1", 0, null, 2 },
                    { 1942, 2, "VNIS-094-2", 0, null, 2 },
                    { 1943, 3, "VNIS-094-3", 0, null, 2 },
                    { 1944, 4, "VNIS-094-4", 0, null, 2 },
                    { 1945, 5, "VNIS-094-5", 0, null, 2 },
                    { 1946, 6, "VNIS-094-6", 0, null, 2 },
                    { 1947, 7, "VNIS-094-7", 0, null, 2 },
                    { 1950, 0, "VNIS-095-0", 0, null, 2 },
                    { 1951, 1, "VNIS-095-1", 0, null, 2 },
                    { 1952, 2, "VNIS-095-2", 0, null, 2 },
                    { 1953, 3, "VNIS-095-3", 0, null, 2 },
                    { 1954, 4, "VNIS-095-4", 0, null, 2 },
                    { 1955, 5, "VNIS-095-5", 0, null, 2 },
                    { 1956, 6, "VNIS-095-6", 0, null, 2 },
                    { 1957, 7, "VNIS-095-7", 0, null, 2 },
                    { 1960, 0, "VNIS-096-0", 0, null, 2 },
                    { 1961, 1, "VNIS-096-1", 0, null, 2 },
                    { 1962, 2, "VNIS-096-2", 0, null, 2 },
                    { 1963, 3, "VNIS-096-3", 0, null, 2 },
                    { 1964, 4, "VNIS-096-4", 0, null, 2 },
                    { 1965, 5, "VNIS-096-5", 0, null, 2 },
                    { 1966, 6, "VNIS-096-6", 0, null, 2 },
                    { 1967, 7, "VNIS-096-7", 0, null, 2 },
                    { 1970, 0, "VNIS-097-0", 0, null, 2 },
                    { 1971, 1, "VNIS-097-1", 0, null, 2 },
                    { 1972, 2, "VNIS-097-2", 0, null, 2 },
                    { 1973, 3, "VNIS-097-3", 0, null, 2 },
                    { 1974, 4, "VNIS-097-4", 0, null, 2 },
                    { 1975, 5, "VNIS-097-5", 0, null, 2 },
                    { 1976, 6, "VNIS-097-6", 0, null, 2 },
                    { 1977, 7, "VNIS-097-7", 0, null, 2 },
                    { 1980, 0, "VNIS-098-0", 0, null, 2 },
                    { 1981, 1, "VNIS-098-1", 0, null, 2 },
                    { 1982, 2, "VNIS-098-2", 0, null, 2 },
                    { 1983, 3, "VNIS-098-3", 0, null, 2 },
                    { 1984, 4, "VNIS-098-4", 0, null, 2 },
                    { 1985, 5, "VNIS-098-5", 0, null, 2 },
                    { 1986, 6, "VNIS-098-6", 0, null, 2 },
                    { 1987, 7, "VNIS-098-7", 0, null, 2 },
                    { 1990, 0, "VNIS-099-0", 0, null, 2 },
                    { 1991, 1, "VNIS-099-1", 0, null, 2 },
                    { 1992, 2, "VNIS-099-2", 0, null, 2 },
                    { 1993, 3, "VNIS-099-3", 0, null, 2 },
                    { 1994, 4, "VNIS-099-4", 0, null, 2 },
                    { 1995, 5, "VNIS-099-5", 0, null, 2 },
                    { 1996, 6, "VNIS-099-6", 0, null, 2 },
                    { 1997, 7, "VNIS-099-7", 0, null, 2 },
                    { 2000, 0, "VNIS-100-0", 0, null, 2 },
                    { 2001, 1, "VNIS-100-1", 0, null, 2 },
                    { 2002, 2, "VNIS-100-2", 0, null, 2 },
                    { 2003, 3, "VNIS-100-3", 0, null, 2 },
                    { 2004, 4, "VNIS-100-4", 0, null, 2 },
                    { 2005, 5, "VNIS-100-5", 0, null, 2 },
                    { 2006, 6, "VNIS-100-6", 0, null, 2 },
                    { 2007, 7, "VNIS-100-7", 0, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryId",
                table: "InventoryItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderImages_StorageOrdersId",
                table: "StorageOrderImages",
                column: "StorageOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrders_InventoryId",
                table: "StorageOrders",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrders_NguoiDungId",
                table: "StorageOrders",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_ServiceId",
                table: "StorageOrderServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrderServices_StorageOrderId",
                table: "StorageOrderServices",
                column: "StorageOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_StorageOrdersId",
                table: "StorageSpaces",
                column: "StorageOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_WareHouseId",
                table: "StorageSpaces",
                column: "WareHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "StorageOrderImages");

            migrationBuilder.DropTable(
                name: "StorageOrderServices");

            migrationBuilder.DropTable(
                name: "StorageSpaces");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "StorageOrders");

            migrationBuilder.DropTable(
                name: "WareHouses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
