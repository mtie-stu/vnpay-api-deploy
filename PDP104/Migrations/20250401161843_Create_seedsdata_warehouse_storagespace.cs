using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PDP104.Migrations
{
    /// <inheritdoc />
    public partial class Create_seedsdata_warehouse_storagespace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeService",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeService",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeService",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeService",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeService",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "TypeService",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "TypeService",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeService",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeService",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ Kiểm kê Container 18ft", "Kiểm kê Container 18ft ", 0 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ Kiểm kê Container 20ft", "Kiểm kê Container 20ft ", 1 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ Kiểm kê Container 22ft", "Kiểm kê Container 22ft ", 2 });

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
                    { 1, 0, "VNOS-001-0", 1, null, 1 },
                    { 2, 0, "VNOS-002-0", 0, null, 1 },
                    { 3, 0, "VNOS-003-0", 1, null, 1 },
                    { 4, 0, "VNOS-004-0", 0, null, 1 },
                    { 5, 0, "VNOS-005-0", 1, null, 1 },
                    { 6, 0, "VNOS-006-0", 0, null, 1 },
                    { 7, 0, "VNOS-007-0", 1, null, 1 },
                    { 8, 0, "VNOS-008-0", 0, null, 1 },
                    { 9, 0, "VNOS-009-0", 1, null, 1 },
                    { 10, 0, "VNOS-010-0", 0, null, 1 },
                    { 11, 0, "VNOS-011-0", 1, null, 1 },
                    { 12, 0, "VNOS-012-0", 0, null, 1 },
                    { 13, 0, "VNOS-013-0", 1, null, 1 },
                    { 14, 0, "VNOS-014-0", 0, null, 1 },
                    { 15, 0, "VNOS-015-0", 1, null, 1 },
                    { 16, 0, "VNOS-016-0", 0, null, 1 },
                    { 17, 0, "VNOS-017-0", 1, null, 1 },
                    { 18, 0, "VNOS-018-0", 0, null, 1 },
                    { 19, 0, "VNOS-019-0", 1, null, 1 },
                    { 20, 0, "VNOS-020-0", 0, null, 1 },
                    { 21, 0, "VNOS-021-0", 1, null, 1 },
                    { 22, 0, "VNOS-022-0", 0, null, 1 },
                    { 23, 0, "VNOS-023-0", 1, null, 1 },
                    { 24, 0, "VNOS-024-0", 0, null, 1 },
                    { 25, 0, "VNOS-025-0", 1, null, 1 },
                    { 26, 0, "VNOS-026-0", 0, null, 1 },
                    { 27, 0, "VNOS-027-0", 1, null, 1 },
                    { 28, 0, "VNOS-028-0", 0, null, 1 },
                    { 29, 0, "VNOS-029-0", 1, null, 1 },
                    { 30, 0, "VNOS-030-0", 0, null, 1 },
                    { 31, 0, "VNOS-031-0", 1, null, 1 },
                    { 32, 0, "VNOS-032-0", 0, null, 1 },
                    { 33, 0, "VNOS-033-0", 1, null, 1 },
                    { 34, 0, "VNOS-034-0", 0, null, 1 },
                    { 35, 0, "VNOS-035-0", 1, null, 1 },
                    { 36, 0, "VNOS-036-0", 0, null, 1 },
                    { 37, 0, "VNOS-037-0", 1, null, 1 },
                    { 38, 0, "VNOS-038-0", 0, null, 1 },
                    { 39, 0, "VNOS-039-0", 1, null, 1 },
                    { 40, 0, "VNOS-040-0", 0, null, 1 },
                    { 41, 0, "VNOS-041-0", 1, null, 1 },
                    { 42, 0, "VNOS-042-0", 0, null, 1 },
                    { 43, 0, "VNOS-043-0", 1, null, 1 },
                    { 44, 0, "VNOS-044-0", 0, null, 1 },
                    { 45, 0, "VNOS-045-0", 1, null, 1 },
                    { 46, 0, "VNOS-046-0", 0, null, 1 },
                    { 47, 0, "VNOS-047-0", 1, null, 1 },
                    { 48, 0, "VNOS-048-0", 0, null, 1 },
                    { 49, 0, "VNOS-049-0", 1, null, 1 },
                    { 50, 0, "VNOS-050-0", 0, null, 1 },
                    { 51, 0, "VNOS-051-0", 1, null, 1 },
                    { 52, 0, "VNOS-052-0", 0, null, 1 },
                    { 53, 0, "VNOS-053-0", 1, null, 1 },
                    { 54, 0, "VNOS-054-0", 0, null, 1 },
                    { 55, 0, "VNOS-055-0", 1, null, 1 },
                    { 56, 0, "VNOS-056-0", 0, null, 1 },
                    { 57, 0, "VNOS-057-0", 1, null, 1 },
                    { 58, 0, "VNOS-058-0", 0, null, 1 },
                    { 59, 0, "VNOS-059-0", 1, null, 1 },
                    { 60, 0, "VNOS-060-0", 0, null, 1 },
                    { 61, 0, "VNOS-061-0", 1, null, 1 },
                    { 62, 0, "VNOS-062-0", 0, null, 1 },
                    { 63, 0, "VNOS-063-0", 1, null, 1 },
                    { 64, 0, "VNOS-064-0", 0, null, 1 },
                    { 65, 0, "VNOS-065-0", 1, null, 1 },
                    { 66, 0, "VNOS-066-0", 0, null, 1 },
                    { 67, 0, "VNOS-067-0", 1, null, 1 },
                    { 68, 0, "VNOS-068-0", 0, null, 1 },
                    { 69, 0, "VNOS-069-0", 1, null, 1 },
                    { 70, 0, "VNOS-070-0", 0, null, 1 },
                    { 71, 0, "VNOS-071-0", 1, null, 1 },
                    { 72, 0, "VNOS-072-0", 0, null, 1 },
                    { 73, 0, "VNOS-073-0", 1, null, 1 },
                    { 74, 0, "VNOS-074-0", 0, null, 1 },
                    { 75, 0, "VNOS-075-0", 1, null, 1 },
                    { 76, 0, "VNOS-076-0", 0, null, 1 },
                    { 77, 0, "VNOS-077-0", 1, null, 1 },
                    { 78, 0, "VNOS-078-0", 0, null, 1 },
                    { 79, 0, "VNOS-079-0", 1, null, 1 },
                    { 80, 0, "VNOS-080-0", 0, null, 1 },
                    { 81, 0, "VNOS-081-0", 1, null, 1 },
                    { 82, 0, "VNOS-082-0", 0, null, 1 },
                    { 83, 0, "VNOS-083-0", 1, null, 1 },
                    { 84, 0, "VNOS-084-0", 0, null, 1 },
                    { 85, 0, "VNOS-085-0", 1, null, 1 },
                    { 86, 0, "VNOS-086-0", 0, null, 1 },
                    { 87, 0, "VNOS-087-0", 1, null, 1 },
                    { 88, 0, "VNOS-088-0", 0, null, 1 },
                    { 89, 0, "VNOS-089-0", 1, null, 1 },
                    { 90, 0, "VNOS-090-0", 0, null, 1 },
                    { 91, 0, "VNOS-091-0", 1, null, 1 },
                    { 92, 0, "VNOS-092-0", 0, null, 1 },
                    { 93, 0, "VNOS-093-0", 1, null, 1 },
                    { 94, 0, "VNOS-094-0", 0, null, 1 },
                    { 95, 0, "VNOS-095-0", 1, null, 1 },
                    { 96, 0, "VNOS-096-0", 0, null, 1 },
                    { 97, 0, "VNOS-097-0", 1, null, 1 },
                    { 98, 0, "VNOS-098-0", 0, null, 1 },
                    { 99, 0, "VNOS-099-0", 1, null, 1 },
                    { 100, 0, "VNOS-100-0", 0, null, 1 },
                    { 1010, 0, "VNIS-001-0", 1, null, 2 },
                    { 1011, 1, "VNIS-001-1", 0, null, 2 },
                    { 1012, 2, "VNIS-001-2", 1, null, 2 },
                    { 1013, 3, "VNIS-001-3", 0, null, 2 },
                    { 1014, 4, "VNIS-001-4", 1, null, 2 },
                    { 1015, 5, "VNIS-001-5", 0, null, 2 },
                    { 1016, 6, "VNIS-001-6", 1, null, 2 },
                    { 1017, 7, "VNIS-001-7", 0, null, 2 },
                    { 1020, 0, "VNIS-002-0", 0, null, 2 },
                    { 1021, 1, "VNIS-002-1", 1, null, 2 },
                    { 1022, 2, "VNIS-002-2", 0, null, 2 },
                    { 1023, 3, "VNIS-002-3", 1, null, 2 },
                    { 1024, 4, "VNIS-002-4", 0, null, 2 },
                    { 1025, 5, "VNIS-002-5", 1, null, 2 },
                    { 1026, 6, "VNIS-002-6", 0, null, 2 },
                    { 1027, 7, "VNIS-002-7", 1, null, 2 },
                    { 1030, 0, "VNIS-003-0", 1, null, 2 },
                    { 1031, 1, "VNIS-003-1", 0, null, 2 },
                    { 1032, 2, "VNIS-003-2", 1, null, 2 },
                    { 1033, 3, "VNIS-003-3", 0, null, 2 },
                    { 1034, 4, "VNIS-003-4", 1, null, 2 },
                    { 1035, 5, "VNIS-003-5", 0, null, 2 },
                    { 1036, 6, "VNIS-003-6", 1, null, 2 },
                    { 1037, 7, "VNIS-003-7", 0, null, 2 },
                    { 1040, 0, "VNIS-004-0", 0, null, 2 },
                    { 1041, 1, "VNIS-004-1", 1, null, 2 },
                    { 1042, 2, "VNIS-004-2", 0, null, 2 },
                    { 1043, 3, "VNIS-004-3", 1, null, 2 },
                    { 1044, 4, "VNIS-004-4", 0, null, 2 },
                    { 1045, 5, "VNIS-004-5", 1, null, 2 },
                    { 1046, 6, "VNIS-004-6", 0, null, 2 },
                    { 1047, 7, "VNIS-004-7", 1, null, 2 },
                    { 1050, 0, "VNIS-005-0", 1, null, 2 },
                    { 1051, 1, "VNIS-005-1", 0, null, 2 },
                    { 1052, 2, "VNIS-005-2", 1, null, 2 },
                    { 1053, 3, "VNIS-005-3", 0, null, 2 },
                    { 1054, 4, "VNIS-005-4", 1, null, 2 },
                    { 1055, 5, "VNIS-005-5", 0, null, 2 },
                    { 1056, 6, "VNIS-005-6", 1, null, 2 },
                    { 1057, 7, "VNIS-005-7", 0, null, 2 },
                    { 1060, 0, "VNIS-006-0", 0, null, 2 },
                    { 1061, 1, "VNIS-006-1", 1, null, 2 },
                    { 1062, 2, "VNIS-006-2", 0, null, 2 },
                    { 1063, 3, "VNIS-006-3", 1, null, 2 },
                    { 1064, 4, "VNIS-006-4", 0, null, 2 },
                    { 1065, 5, "VNIS-006-5", 1, null, 2 },
                    { 1066, 6, "VNIS-006-6", 0, null, 2 },
                    { 1067, 7, "VNIS-006-7", 1, null, 2 },
                    { 1070, 0, "VNIS-007-0", 1, null, 2 },
                    { 1071, 1, "VNIS-007-1", 0, null, 2 },
                    { 1072, 2, "VNIS-007-2", 1, null, 2 },
                    { 1073, 3, "VNIS-007-3", 0, null, 2 },
                    { 1074, 4, "VNIS-007-4", 1, null, 2 },
                    { 1075, 5, "VNIS-007-5", 0, null, 2 },
                    { 1076, 6, "VNIS-007-6", 1, null, 2 },
                    { 1077, 7, "VNIS-007-7", 0, null, 2 },
                    { 1080, 0, "VNIS-008-0", 0, null, 2 },
                    { 1081, 1, "VNIS-008-1", 1, null, 2 },
                    { 1082, 2, "VNIS-008-2", 0, null, 2 },
                    { 1083, 3, "VNIS-008-3", 1, null, 2 },
                    { 1084, 4, "VNIS-008-4", 0, null, 2 },
                    { 1085, 5, "VNIS-008-5", 1, null, 2 },
                    { 1086, 6, "VNIS-008-6", 0, null, 2 },
                    { 1087, 7, "VNIS-008-7", 1, null, 2 },
                    { 1090, 0, "VNIS-009-0", 1, null, 2 },
                    { 1091, 1, "VNIS-009-1", 0, null, 2 },
                    { 1092, 2, "VNIS-009-2", 1, null, 2 },
                    { 1093, 3, "VNIS-009-3", 0, null, 2 },
                    { 1094, 4, "VNIS-009-4", 1, null, 2 },
                    { 1095, 5, "VNIS-009-5", 0, null, 2 },
                    { 1096, 6, "VNIS-009-6", 1, null, 2 },
                    { 1097, 7, "VNIS-009-7", 0, null, 2 },
                    { 1100, 0, "VNIS-010-0", 0, null, 2 },
                    { 1101, 1, "VNIS-010-1", 1, null, 2 },
                    { 1102, 2, "VNIS-010-2", 0, null, 2 },
                    { 1103, 3, "VNIS-010-3", 1, null, 2 },
                    { 1104, 4, "VNIS-010-4", 0, null, 2 },
                    { 1105, 5, "VNIS-010-5", 1, null, 2 },
                    { 1106, 6, "VNIS-010-6", 0, null, 2 },
                    { 1107, 7, "VNIS-010-7", 1, null, 2 },
                    { 1110, 0, "VNIS-011-0", 1, null, 2 },
                    { 1111, 1, "VNIS-011-1", 0, null, 2 },
                    { 1112, 2, "VNIS-011-2", 1, null, 2 },
                    { 1113, 3, "VNIS-011-3", 0, null, 2 },
                    { 1114, 4, "VNIS-011-4", 1, null, 2 },
                    { 1115, 5, "VNIS-011-5", 0, null, 2 },
                    { 1116, 6, "VNIS-011-6", 1, null, 2 },
                    { 1117, 7, "VNIS-011-7", 0, null, 2 },
                    { 1120, 0, "VNIS-012-0", 0, null, 2 },
                    { 1121, 1, "VNIS-012-1", 1, null, 2 },
                    { 1122, 2, "VNIS-012-2", 0, null, 2 },
                    { 1123, 3, "VNIS-012-3", 1, null, 2 },
                    { 1124, 4, "VNIS-012-4", 0, null, 2 },
                    { 1125, 5, "VNIS-012-5", 1, null, 2 },
                    { 1126, 6, "VNIS-012-6", 0, null, 2 },
                    { 1127, 7, "VNIS-012-7", 1, null, 2 },
                    { 1130, 0, "VNIS-013-0", 1, null, 2 },
                    { 1131, 1, "VNIS-013-1", 0, null, 2 },
                    { 1132, 2, "VNIS-013-2", 1, null, 2 },
                    { 1133, 3, "VNIS-013-3", 0, null, 2 },
                    { 1134, 4, "VNIS-013-4", 1, null, 2 },
                    { 1135, 5, "VNIS-013-5", 0, null, 2 },
                    { 1136, 6, "VNIS-013-6", 1, null, 2 },
                    { 1137, 7, "VNIS-013-7", 0, null, 2 },
                    { 1140, 0, "VNIS-014-0", 0, null, 2 },
                    { 1141, 1, "VNIS-014-1", 1, null, 2 },
                    { 1142, 2, "VNIS-014-2", 0, null, 2 },
                    { 1143, 3, "VNIS-014-3", 1, null, 2 },
                    { 1144, 4, "VNIS-014-4", 0, null, 2 },
                    { 1145, 5, "VNIS-014-5", 1, null, 2 },
                    { 1146, 6, "VNIS-014-6", 0, null, 2 },
                    { 1147, 7, "VNIS-014-7", 1, null, 2 },
                    { 1150, 0, "VNIS-015-0", 1, null, 2 },
                    { 1151, 1, "VNIS-015-1", 0, null, 2 },
                    { 1152, 2, "VNIS-015-2", 1, null, 2 },
                    { 1153, 3, "VNIS-015-3", 0, null, 2 },
                    { 1154, 4, "VNIS-015-4", 1, null, 2 },
                    { 1155, 5, "VNIS-015-5", 0, null, 2 },
                    { 1156, 6, "VNIS-015-6", 1, null, 2 },
                    { 1157, 7, "VNIS-015-7", 0, null, 2 },
                    { 1160, 0, "VNIS-016-0", 0, null, 2 },
                    { 1161, 1, "VNIS-016-1", 1, null, 2 },
                    { 1162, 2, "VNIS-016-2", 0, null, 2 },
                    { 1163, 3, "VNIS-016-3", 1, null, 2 },
                    { 1164, 4, "VNIS-016-4", 0, null, 2 },
                    { 1165, 5, "VNIS-016-5", 1, null, 2 },
                    { 1166, 6, "VNIS-016-6", 0, null, 2 },
                    { 1167, 7, "VNIS-016-7", 1, null, 2 },
                    { 1170, 0, "VNIS-017-0", 1, null, 2 },
                    { 1171, 1, "VNIS-017-1", 0, null, 2 },
                    { 1172, 2, "VNIS-017-2", 1, null, 2 },
                    { 1173, 3, "VNIS-017-3", 0, null, 2 },
                    { 1174, 4, "VNIS-017-4", 1, null, 2 },
                    { 1175, 5, "VNIS-017-5", 0, null, 2 },
                    { 1176, 6, "VNIS-017-6", 1, null, 2 },
                    { 1177, 7, "VNIS-017-7", 0, null, 2 },
                    { 1180, 0, "VNIS-018-0", 0, null, 2 },
                    { 1181, 1, "VNIS-018-1", 1, null, 2 },
                    { 1182, 2, "VNIS-018-2", 0, null, 2 },
                    { 1183, 3, "VNIS-018-3", 1, null, 2 },
                    { 1184, 4, "VNIS-018-4", 0, null, 2 },
                    { 1185, 5, "VNIS-018-5", 1, null, 2 },
                    { 1186, 6, "VNIS-018-6", 0, null, 2 },
                    { 1187, 7, "VNIS-018-7", 1, null, 2 },
                    { 1190, 0, "VNIS-019-0", 1, null, 2 },
                    { 1191, 1, "VNIS-019-1", 0, null, 2 },
                    { 1192, 2, "VNIS-019-2", 1, null, 2 },
                    { 1193, 3, "VNIS-019-3", 0, null, 2 },
                    { 1194, 4, "VNIS-019-4", 1, null, 2 },
                    { 1195, 5, "VNIS-019-5", 0, null, 2 },
                    { 1196, 6, "VNIS-019-6", 1, null, 2 },
                    { 1197, 7, "VNIS-019-7", 0, null, 2 },
                    { 1200, 0, "VNIS-020-0", 0, null, 2 },
                    { 1201, 1, "VNIS-020-1", 1, null, 2 },
                    { 1202, 2, "VNIS-020-2", 0, null, 2 },
                    { 1203, 3, "VNIS-020-3", 1, null, 2 },
                    { 1204, 4, "VNIS-020-4", 0, null, 2 },
                    { 1205, 5, "VNIS-020-5", 1, null, 2 },
                    { 1206, 6, "VNIS-020-6", 0, null, 2 },
                    { 1207, 7, "VNIS-020-7", 1, null, 2 },
                    { 1210, 0, "VNIS-021-0", 1, null, 2 },
                    { 1211, 1, "VNIS-021-1", 0, null, 2 },
                    { 1212, 2, "VNIS-021-2", 1, null, 2 },
                    { 1213, 3, "VNIS-021-3", 0, null, 2 },
                    { 1214, 4, "VNIS-021-4", 1, null, 2 },
                    { 1215, 5, "VNIS-021-5", 0, null, 2 },
                    { 1216, 6, "VNIS-021-6", 1, null, 2 },
                    { 1217, 7, "VNIS-021-7", 0, null, 2 },
                    { 1220, 0, "VNIS-022-0", 0, null, 2 },
                    { 1221, 1, "VNIS-022-1", 1, null, 2 },
                    { 1222, 2, "VNIS-022-2", 0, null, 2 },
                    { 1223, 3, "VNIS-022-3", 1, null, 2 },
                    { 1224, 4, "VNIS-022-4", 0, null, 2 },
                    { 1225, 5, "VNIS-022-5", 1, null, 2 },
                    { 1226, 6, "VNIS-022-6", 0, null, 2 },
                    { 1227, 7, "VNIS-022-7", 1, null, 2 },
                    { 1230, 0, "VNIS-023-0", 1, null, 2 },
                    { 1231, 1, "VNIS-023-1", 0, null, 2 },
                    { 1232, 2, "VNIS-023-2", 1, null, 2 },
                    { 1233, 3, "VNIS-023-3", 0, null, 2 },
                    { 1234, 4, "VNIS-023-4", 1, null, 2 },
                    { 1235, 5, "VNIS-023-5", 0, null, 2 },
                    { 1236, 6, "VNIS-023-6", 1, null, 2 },
                    { 1237, 7, "VNIS-023-7", 0, null, 2 },
                    { 1240, 0, "VNIS-024-0", 0, null, 2 },
                    { 1241, 1, "VNIS-024-1", 1, null, 2 },
                    { 1242, 2, "VNIS-024-2", 0, null, 2 },
                    { 1243, 3, "VNIS-024-3", 1, null, 2 },
                    { 1244, 4, "VNIS-024-4", 0, null, 2 },
                    { 1245, 5, "VNIS-024-5", 1, null, 2 },
                    { 1246, 6, "VNIS-024-6", 0, null, 2 },
                    { 1247, 7, "VNIS-024-7", 1, null, 2 },
                    { 1250, 0, "VNIS-025-0", 1, null, 2 },
                    { 1251, 1, "VNIS-025-1", 0, null, 2 },
                    { 1252, 2, "VNIS-025-2", 1, null, 2 },
                    { 1253, 3, "VNIS-025-3", 0, null, 2 },
                    { 1254, 4, "VNIS-025-4", 1, null, 2 },
                    { 1255, 5, "VNIS-025-5", 0, null, 2 },
                    { 1256, 6, "VNIS-025-6", 1, null, 2 },
                    { 1257, 7, "VNIS-025-7", 0, null, 2 },
                    { 1260, 0, "VNIS-026-0", 0, null, 2 },
                    { 1261, 1, "VNIS-026-1", 1, null, 2 },
                    { 1262, 2, "VNIS-026-2", 0, null, 2 },
                    { 1263, 3, "VNIS-026-3", 1, null, 2 },
                    { 1264, 4, "VNIS-026-4", 0, null, 2 },
                    { 1265, 5, "VNIS-026-5", 1, null, 2 },
                    { 1266, 6, "VNIS-026-6", 0, null, 2 },
                    { 1267, 7, "VNIS-026-7", 1, null, 2 },
                    { 1270, 0, "VNIS-027-0", 1, null, 2 },
                    { 1271, 1, "VNIS-027-1", 0, null, 2 },
                    { 1272, 2, "VNIS-027-2", 1, null, 2 },
                    { 1273, 3, "VNIS-027-3", 0, null, 2 },
                    { 1274, 4, "VNIS-027-4", 1, null, 2 },
                    { 1275, 5, "VNIS-027-5", 0, null, 2 },
                    { 1276, 6, "VNIS-027-6", 1, null, 2 },
                    { 1277, 7, "VNIS-027-7", 0, null, 2 },
                    { 1280, 0, "VNIS-028-0", 0, null, 2 },
                    { 1281, 1, "VNIS-028-1", 1, null, 2 },
                    { 1282, 2, "VNIS-028-2", 0, null, 2 },
                    { 1283, 3, "VNIS-028-3", 1, null, 2 },
                    { 1284, 4, "VNIS-028-4", 0, null, 2 },
                    { 1285, 5, "VNIS-028-5", 1, null, 2 },
                    { 1286, 6, "VNIS-028-6", 0, null, 2 },
                    { 1287, 7, "VNIS-028-7", 1, null, 2 },
                    { 1290, 0, "VNIS-029-0", 1, null, 2 },
                    { 1291, 1, "VNIS-029-1", 0, null, 2 },
                    { 1292, 2, "VNIS-029-2", 1, null, 2 },
                    { 1293, 3, "VNIS-029-3", 0, null, 2 },
                    { 1294, 4, "VNIS-029-4", 1, null, 2 },
                    { 1295, 5, "VNIS-029-5", 0, null, 2 },
                    { 1296, 6, "VNIS-029-6", 1, null, 2 },
                    { 1297, 7, "VNIS-029-7", 0, null, 2 },
                    { 1300, 0, "VNIS-030-0", 0, null, 2 },
                    { 1301, 1, "VNIS-030-1", 1, null, 2 },
                    { 1302, 2, "VNIS-030-2", 0, null, 2 },
                    { 1303, 3, "VNIS-030-3", 1, null, 2 },
                    { 1304, 4, "VNIS-030-4", 0, null, 2 },
                    { 1305, 5, "VNIS-030-5", 1, null, 2 },
                    { 1306, 6, "VNIS-030-6", 0, null, 2 },
                    { 1307, 7, "VNIS-030-7", 1, null, 2 },
                    { 1310, 0, "VNIS-031-0", 1, null, 2 },
                    { 1311, 1, "VNIS-031-1", 0, null, 2 },
                    { 1312, 2, "VNIS-031-2", 1, null, 2 },
                    { 1313, 3, "VNIS-031-3", 0, null, 2 },
                    { 1314, 4, "VNIS-031-4", 1, null, 2 },
                    { 1315, 5, "VNIS-031-5", 0, null, 2 },
                    { 1316, 6, "VNIS-031-6", 1, null, 2 },
                    { 1317, 7, "VNIS-031-7", 0, null, 2 },
                    { 1320, 0, "VNIS-032-0", 0, null, 2 },
                    { 1321, 1, "VNIS-032-1", 1, null, 2 },
                    { 1322, 2, "VNIS-032-2", 0, null, 2 },
                    { 1323, 3, "VNIS-032-3", 1, null, 2 },
                    { 1324, 4, "VNIS-032-4", 0, null, 2 },
                    { 1325, 5, "VNIS-032-5", 1, null, 2 },
                    { 1326, 6, "VNIS-032-6", 0, null, 2 },
                    { 1327, 7, "VNIS-032-7", 1, null, 2 },
                    { 1330, 0, "VNIS-033-0", 1, null, 2 },
                    { 1331, 1, "VNIS-033-1", 0, null, 2 },
                    { 1332, 2, "VNIS-033-2", 1, null, 2 },
                    { 1333, 3, "VNIS-033-3", 0, null, 2 },
                    { 1334, 4, "VNIS-033-4", 1, null, 2 },
                    { 1335, 5, "VNIS-033-5", 0, null, 2 },
                    { 1336, 6, "VNIS-033-6", 1, null, 2 },
                    { 1337, 7, "VNIS-033-7", 0, null, 2 },
                    { 1340, 0, "VNIS-034-0", 0, null, 2 },
                    { 1341, 1, "VNIS-034-1", 1, null, 2 },
                    { 1342, 2, "VNIS-034-2", 0, null, 2 },
                    { 1343, 3, "VNIS-034-3", 1, null, 2 },
                    { 1344, 4, "VNIS-034-4", 0, null, 2 },
                    { 1345, 5, "VNIS-034-5", 1, null, 2 },
                    { 1346, 6, "VNIS-034-6", 0, null, 2 },
                    { 1347, 7, "VNIS-034-7", 1, null, 2 },
                    { 1350, 0, "VNIS-035-0", 1, null, 2 },
                    { 1351, 1, "VNIS-035-1", 0, null, 2 },
                    { 1352, 2, "VNIS-035-2", 1, null, 2 },
                    { 1353, 3, "VNIS-035-3", 0, null, 2 },
                    { 1354, 4, "VNIS-035-4", 1, null, 2 },
                    { 1355, 5, "VNIS-035-5", 0, null, 2 },
                    { 1356, 6, "VNIS-035-6", 1, null, 2 },
                    { 1357, 7, "VNIS-035-7", 0, null, 2 },
                    { 1360, 0, "VNIS-036-0", 0, null, 2 },
                    { 1361, 1, "VNIS-036-1", 1, null, 2 },
                    { 1362, 2, "VNIS-036-2", 0, null, 2 },
                    { 1363, 3, "VNIS-036-3", 1, null, 2 },
                    { 1364, 4, "VNIS-036-4", 0, null, 2 },
                    { 1365, 5, "VNIS-036-5", 1, null, 2 },
                    { 1366, 6, "VNIS-036-6", 0, null, 2 },
                    { 1367, 7, "VNIS-036-7", 1, null, 2 },
                    { 1370, 0, "VNIS-037-0", 1, null, 2 },
                    { 1371, 1, "VNIS-037-1", 0, null, 2 },
                    { 1372, 2, "VNIS-037-2", 1, null, 2 },
                    { 1373, 3, "VNIS-037-3", 0, null, 2 },
                    { 1374, 4, "VNIS-037-4", 1, null, 2 },
                    { 1375, 5, "VNIS-037-5", 0, null, 2 },
                    { 1376, 6, "VNIS-037-6", 1, null, 2 },
                    { 1377, 7, "VNIS-037-7", 0, null, 2 },
                    { 1380, 0, "VNIS-038-0", 0, null, 2 },
                    { 1381, 1, "VNIS-038-1", 1, null, 2 },
                    { 1382, 2, "VNIS-038-2", 0, null, 2 },
                    { 1383, 3, "VNIS-038-3", 1, null, 2 },
                    { 1384, 4, "VNIS-038-4", 0, null, 2 },
                    { 1385, 5, "VNIS-038-5", 1, null, 2 },
                    { 1386, 6, "VNIS-038-6", 0, null, 2 },
                    { 1387, 7, "VNIS-038-7", 1, null, 2 },
                    { 1390, 0, "VNIS-039-0", 1, null, 2 },
                    { 1391, 1, "VNIS-039-1", 0, null, 2 },
                    { 1392, 2, "VNIS-039-2", 1, null, 2 },
                    { 1393, 3, "VNIS-039-3", 0, null, 2 },
                    { 1394, 4, "VNIS-039-4", 1, null, 2 },
                    { 1395, 5, "VNIS-039-5", 0, null, 2 },
                    { 1396, 6, "VNIS-039-6", 1, null, 2 },
                    { 1397, 7, "VNIS-039-7", 0, null, 2 },
                    { 1400, 0, "VNIS-040-0", 0, null, 2 },
                    { 1401, 1, "VNIS-040-1", 1, null, 2 },
                    { 1402, 2, "VNIS-040-2", 0, null, 2 },
                    { 1403, 3, "VNIS-040-3", 1, null, 2 },
                    { 1404, 4, "VNIS-040-4", 0, null, 2 },
                    { 1405, 5, "VNIS-040-5", 1, null, 2 },
                    { 1406, 6, "VNIS-040-6", 0, null, 2 },
                    { 1407, 7, "VNIS-040-7", 1, null, 2 },
                    { 1410, 0, "VNIS-041-0", 1, null, 2 },
                    { 1411, 1, "VNIS-041-1", 0, null, 2 },
                    { 1412, 2, "VNIS-041-2", 1, null, 2 },
                    { 1413, 3, "VNIS-041-3", 0, null, 2 },
                    { 1414, 4, "VNIS-041-4", 1, null, 2 },
                    { 1415, 5, "VNIS-041-5", 0, null, 2 },
                    { 1416, 6, "VNIS-041-6", 1, null, 2 },
                    { 1417, 7, "VNIS-041-7", 0, null, 2 },
                    { 1420, 0, "VNIS-042-0", 0, null, 2 },
                    { 1421, 1, "VNIS-042-1", 1, null, 2 },
                    { 1422, 2, "VNIS-042-2", 0, null, 2 },
                    { 1423, 3, "VNIS-042-3", 1, null, 2 },
                    { 1424, 4, "VNIS-042-4", 0, null, 2 },
                    { 1425, 5, "VNIS-042-5", 1, null, 2 },
                    { 1426, 6, "VNIS-042-6", 0, null, 2 },
                    { 1427, 7, "VNIS-042-7", 1, null, 2 },
                    { 1430, 0, "VNIS-043-0", 1, null, 2 },
                    { 1431, 1, "VNIS-043-1", 0, null, 2 },
                    { 1432, 2, "VNIS-043-2", 1, null, 2 },
                    { 1433, 3, "VNIS-043-3", 0, null, 2 },
                    { 1434, 4, "VNIS-043-4", 1, null, 2 },
                    { 1435, 5, "VNIS-043-5", 0, null, 2 },
                    { 1436, 6, "VNIS-043-6", 1, null, 2 },
                    { 1437, 7, "VNIS-043-7", 0, null, 2 },
                    { 1440, 0, "VNIS-044-0", 0, null, 2 },
                    { 1441, 1, "VNIS-044-1", 1, null, 2 },
                    { 1442, 2, "VNIS-044-2", 0, null, 2 },
                    { 1443, 3, "VNIS-044-3", 1, null, 2 },
                    { 1444, 4, "VNIS-044-4", 0, null, 2 },
                    { 1445, 5, "VNIS-044-5", 1, null, 2 },
                    { 1446, 6, "VNIS-044-6", 0, null, 2 },
                    { 1447, 7, "VNIS-044-7", 1, null, 2 },
                    { 1450, 0, "VNIS-045-0", 1, null, 2 },
                    { 1451, 1, "VNIS-045-1", 0, null, 2 },
                    { 1452, 2, "VNIS-045-2", 1, null, 2 },
                    { 1453, 3, "VNIS-045-3", 0, null, 2 },
                    { 1454, 4, "VNIS-045-4", 1, null, 2 },
                    { 1455, 5, "VNIS-045-5", 0, null, 2 },
                    { 1456, 6, "VNIS-045-6", 1, null, 2 },
                    { 1457, 7, "VNIS-045-7", 0, null, 2 },
                    { 1460, 0, "VNIS-046-0", 0, null, 2 },
                    { 1461, 1, "VNIS-046-1", 1, null, 2 },
                    { 1462, 2, "VNIS-046-2", 0, null, 2 },
                    { 1463, 3, "VNIS-046-3", 1, null, 2 },
                    { 1464, 4, "VNIS-046-4", 0, null, 2 },
                    { 1465, 5, "VNIS-046-5", 1, null, 2 },
                    { 1466, 6, "VNIS-046-6", 0, null, 2 },
                    { 1467, 7, "VNIS-046-7", 1, null, 2 },
                    { 1470, 0, "VNIS-047-0", 1, null, 2 },
                    { 1471, 1, "VNIS-047-1", 0, null, 2 },
                    { 1472, 2, "VNIS-047-2", 1, null, 2 },
                    { 1473, 3, "VNIS-047-3", 0, null, 2 },
                    { 1474, 4, "VNIS-047-4", 1, null, 2 },
                    { 1475, 5, "VNIS-047-5", 0, null, 2 },
                    { 1476, 6, "VNIS-047-6", 1, null, 2 },
                    { 1477, 7, "VNIS-047-7", 0, null, 2 },
                    { 1480, 0, "VNIS-048-0", 0, null, 2 },
                    { 1481, 1, "VNIS-048-1", 1, null, 2 },
                    { 1482, 2, "VNIS-048-2", 0, null, 2 },
                    { 1483, 3, "VNIS-048-3", 1, null, 2 },
                    { 1484, 4, "VNIS-048-4", 0, null, 2 },
                    { 1485, 5, "VNIS-048-5", 1, null, 2 },
                    { 1486, 6, "VNIS-048-6", 0, null, 2 },
                    { 1487, 7, "VNIS-048-7", 1, null, 2 },
                    { 1490, 0, "VNIS-049-0", 1, null, 2 },
                    { 1491, 1, "VNIS-049-1", 0, null, 2 },
                    { 1492, 2, "VNIS-049-2", 1, null, 2 },
                    { 1493, 3, "VNIS-049-3", 0, null, 2 },
                    { 1494, 4, "VNIS-049-4", 1, null, 2 },
                    { 1495, 5, "VNIS-049-5", 0, null, 2 },
                    { 1496, 6, "VNIS-049-6", 1, null, 2 },
                    { 1497, 7, "VNIS-049-7", 0, null, 2 },
                    { 1500, 0, "VNIS-050-0", 0, null, 2 },
                    { 1501, 1, "VNIS-050-1", 1, null, 2 },
                    { 1502, 2, "VNIS-050-2", 0, null, 2 },
                    { 1503, 3, "VNIS-050-3", 1, null, 2 },
                    { 1504, 4, "VNIS-050-4", 0, null, 2 },
                    { 1505, 5, "VNIS-050-5", 1, null, 2 },
                    { 1506, 6, "VNIS-050-6", 0, null, 2 },
                    { 1507, 7, "VNIS-050-7", 1, null, 2 },
                    { 1510, 0, "VNIS-051-0", 1, null, 2 },
                    { 1511, 1, "VNIS-051-1", 0, null, 2 },
                    { 1512, 2, "VNIS-051-2", 1, null, 2 },
                    { 1513, 3, "VNIS-051-3", 0, null, 2 },
                    { 1514, 4, "VNIS-051-4", 1, null, 2 },
                    { 1515, 5, "VNIS-051-5", 0, null, 2 },
                    { 1516, 6, "VNIS-051-6", 1, null, 2 },
                    { 1517, 7, "VNIS-051-7", 0, null, 2 },
                    { 1520, 0, "VNIS-052-0", 0, null, 2 },
                    { 1521, 1, "VNIS-052-1", 1, null, 2 },
                    { 1522, 2, "VNIS-052-2", 0, null, 2 },
                    { 1523, 3, "VNIS-052-3", 1, null, 2 },
                    { 1524, 4, "VNIS-052-4", 0, null, 2 },
                    { 1525, 5, "VNIS-052-5", 1, null, 2 },
                    { 1526, 6, "VNIS-052-6", 0, null, 2 },
                    { 1527, 7, "VNIS-052-7", 1, null, 2 },
                    { 1530, 0, "VNIS-053-0", 1, null, 2 },
                    { 1531, 1, "VNIS-053-1", 0, null, 2 },
                    { 1532, 2, "VNIS-053-2", 1, null, 2 },
                    { 1533, 3, "VNIS-053-3", 0, null, 2 },
                    { 1534, 4, "VNIS-053-4", 1, null, 2 },
                    { 1535, 5, "VNIS-053-5", 0, null, 2 },
                    { 1536, 6, "VNIS-053-6", 1, null, 2 },
                    { 1537, 7, "VNIS-053-7", 0, null, 2 },
                    { 1540, 0, "VNIS-054-0", 0, null, 2 },
                    { 1541, 1, "VNIS-054-1", 1, null, 2 },
                    { 1542, 2, "VNIS-054-2", 0, null, 2 },
                    { 1543, 3, "VNIS-054-3", 1, null, 2 },
                    { 1544, 4, "VNIS-054-4", 0, null, 2 },
                    { 1545, 5, "VNIS-054-5", 1, null, 2 },
                    { 1546, 6, "VNIS-054-6", 0, null, 2 },
                    { 1547, 7, "VNIS-054-7", 1, null, 2 },
                    { 1550, 0, "VNIS-055-0", 1, null, 2 },
                    { 1551, 1, "VNIS-055-1", 0, null, 2 },
                    { 1552, 2, "VNIS-055-2", 1, null, 2 },
                    { 1553, 3, "VNIS-055-3", 0, null, 2 },
                    { 1554, 4, "VNIS-055-4", 1, null, 2 },
                    { 1555, 5, "VNIS-055-5", 0, null, 2 },
                    { 1556, 6, "VNIS-055-6", 1, null, 2 },
                    { 1557, 7, "VNIS-055-7", 0, null, 2 },
                    { 1560, 0, "VNIS-056-0", 0, null, 2 },
                    { 1561, 1, "VNIS-056-1", 1, null, 2 },
                    { 1562, 2, "VNIS-056-2", 0, null, 2 },
                    { 1563, 3, "VNIS-056-3", 1, null, 2 },
                    { 1564, 4, "VNIS-056-4", 0, null, 2 },
                    { 1565, 5, "VNIS-056-5", 1, null, 2 },
                    { 1566, 6, "VNIS-056-6", 0, null, 2 },
                    { 1567, 7, "VNIS-056-7", 1, null, 2 },
                    { 1570, 0, "VNIS-057-0", 1, null, 2 },
                    { 1571, 1, "VNIS-057-1", 0, null, 2 },
                    { 1572, 2, "VNIS-057-2", 1, null, 2 },
                    { 1573, 3, "VNIS-057-3", 0, null, 2 },
                    { 1574, 4, "VNIS-057-4", 1, null, 2 },
                    { 1575, 5, "VNIS-057-5", 0, null, 2 },
                    { 1576, 6, "VNIS-057-6", 1, null, 2 },
                    { 1577, 7, "VNIS-057-7", 0, null, 2 },
                    { 1580, 0, "VNIS-058-0", 0, null, 2 },
                    { 1581, 1, "VNIS-058-1", 1, null, 2 },
                    { 1582, 2, "VNIS-058-2", 0, null, 2 },
                    { 1583, 3, "VNIS-058-3", 1, null, 2 },
                    { 1584, 4, "VNIS-058-4", 0, null, 2 },
                    { 1585, 5, "VNIS-058-5", 1, null, 2 },
                    { 1586, 6, "VNIS-058-6", 0, null, 2 },
                    { 1587, 7, "VNIS-058-7", 1, null, 2 },
                    { 1590, 0, "VNIS-059-0", 1, null, 2 },
                    { 1591, 1, "VNIS-059-1", 0, null, 2 },
                    { 1592, 2, "VNIS-059-2", 1, null, 2 },
                    { 1593, 3, "VNIS-059-3", 0, null, 2 },
                    { 1594, 4, "VNIS-059-4", 1, null, 2 },
                    { 1595, 5, "VNIS-059-5", 0, null, 2 },
                    { 1596, 6, "VNIS-059-6", 1, null, 2 },
                    { 1597, 7, "VNIS-059-7", 0, null, 2 },
                    { 1600, 0, "VNIS-060-0", 0, null, 2 },
                    { 1601, 1, "VNIS-060-1", 1, null, 2 },
                    { 1602, 2, "VNIS-060-2", 0, null, 2 },
                    { 1603, 3, "VNIS-060-3", 1, null, 2 },
                    { 1604, 4, "VNIS-060-4", 0, null, 2 },
                    { 1605, 5, "VNIS-060-5", 1, null, 2 },
                    { 1606, 6, "VNIS-060-6", 0, null, 2 },
                    { 1607, 7, "VNIS-060-7", 1, null, 2 },
                    { 1610, 0, "VNIS-061-0", 1, null, 2 },
                    { 1611, 1, "VNIS-061-1", 0, null, 2 },
                    { 1612, 2, "VNIS-061-2", 1, null, 2 },
                    { 1613, 3, "VNIS-061-3", 0, null, 2 },
                    { 1614, 4, "VNIS-061-4", 1, null, 2 },
                    { 1615, 5, "VNIS-061-5", 0, null, 2 },
                    { 1616, 6, "VNIS-061-6", 1, null, 2 },
                    { 1617, 7, "VNIS-061-7", 0, null, 2 },
                    { 1620, 0, "VNIS-062-0", 0, null, 2 },
                    { 1621, 1, "VNIS-062-1", 1, null, 2 },
                    { 1622, 2, "VNIS-062-2", 0, null, 2 },
                    { 1623, 3, "VNIS-062-3", 1, null, 2 },
                    { 1624, 4, "VNIS-062-4", 0, null, 2 },
                    { 1625, 5, "VNIS-062-5", 1, null, 2 },
                    { 1626, 6, "VNIS-062-6", 0, null, 2 },
                    { 1627, 7, "VNIS-062-7", 1, null, 2 },
                    { 1630, 0, "VNIS-063-0", 1, null, 2 },
                    { 1631, 1, "VNIS-063-1", 0, null, 2 },
                    { 1632, 2, "VNIS-063-2", 1, null, 2 },
                    { 1633, 3, "VNIS-063-3", 0, null, 2 },
                    { 1634, 4, "VNIS-063-4", 1, null, 2 },
                    { 1635, 5, "VNIS-063-5", 0, null, 2 },
                    { 1636, 6, "VNIS-063-6", 1, null, 2 },
                    { 1637, 7, "VNIS-063-7", 0, null, 2 },
                    { 1640, 0, "VNIS-064-0", 0, null, 2 },
                    { 1641, 1, "VNIS-064-1", 1, null, 2 },
                    { 1642, 2, "VNIS-064-2", 0, null, 2 },
                    { 1643, 3, "VNIS-064-3", 1, null, 2 },
                    { 1644, 4, "VNIS-064-4", 0, null, 2 },
                    { 1645, 5, "VNIS-064-5", 1, null, 2 },
                    { 1646, 6, "VNIS-064-6", 0, null, 2 },
                    { 1647, 7, "VNIS-064-7", 1, null, 2 },
                    { 1650, 0, "VNIS-065-0", 1, null, 2 },
                    { 1651, 1, "VNIS-065-1", 0, null, 2 },
                    { 1652, 2, "VNIS-065-2", 1, null, 2 },
                    { 1653, 3, "VNIS-065-3", 0, null, 2 },
                    { 1654, 4, "VNIS-065-4", 1, null, 2 },
                    { 1655, 5, "VNIS-065-5", 0, null, 2 },
                    { 1656, 6, "VNIS-065-6", 1, null, 2 },
                    { 1657, 7, "VNIS-065-7", 0, null, 2 },
                    { 1660, 0, "VNIS-066-0", 0, null, 2 },
                    { 1661, 1, "VNIS-066-1", 1, null, 2 },
                    { 1662, 2, "VNIS-066-2", 0, null, 2 },
                    { 1663, 3, "VNIS-066-3", 1, null, 2 },
                    { 1664, 4, "VNIS-066-4", 0, null, 2 },
                    { 1665, 5, "VNIS-066-5", 1, null, 2 },
                    { 1666, 6, "VNIS-066-6", 0, null, 2 },
                    { 1667, 7, "VNIS-066-7", 1, null, 2 },
                    { 1670, 0, "VNIS-067-0", 1, null, 2 },
                    { 1671, 1, "VNIS-067-1", 0, null, 2 },
                    { 1672, 2, "VNIS-067-2", 1, null, 2 },
                    { 1673, 3, "VNIS-067-3", 0, null, 2 },
                    { 1674, 4, "VNIS-067-4", 1, null, 2 },
                    { 1675, 5, "VNIS-067-5", 0, null, 2 },
                    { 1676, 6, "VNIS-067-6", 1, null, 2 },
                    { 1677, 7, "VNIS-067-7", 0, null, 2 },
                    { 1680, 0, "VNIS-068-0", 0, null, 2 },
                    { 1681, 1, "VNIS-068-1", 1, null, 2 },
                    { 1682, 2, "VNIS-068-2", 0, null, 2 },
                    { 1683, 3, "VNIS-068-3", 1, null, 2 },
                    { 1684, 4, "VNIS-068-4", 0, null, 2 },
                    { 1685, 5, "VNIS-068-5", 1, null, 2 },
                    { 1686, 6, "VNIS-068-6", 0, null, 2 },
                    { 1687, 7, "VNIS-068-7", 1, null, 2 },
                    { 1690, 0, "VNIS-069-0", 1, null, 2 },
                    { 1691, 1, "VNIS-069-1", 0, null, 2 },
                    { 1692, 2, "VNIS-069-2", 1, null, 2 },
                    { 1693, 3, "VNIS-069-3", 0, null, 2 },
                    { 1694, 4, "VNIS-069-4", 1, null, 2 },
                    { 1695, 5, "VNIS-069-5", 0, null, 2 },
                    { 1696, 6, "VNIS-069-6", 1, null, 2 },
                    { 1697, 7, "VNIS-069-7", 0, null, 2 },
                    { 1700, 0, "VNIS-070-0", 0, null, 2 },
                    { 1701, 1, "VNIS-070-1", 1, null, 2 },
                    { 1702, 2, "VNIS-070-2", 0, null, 2 },
                    { 1703, 3, "VNIS-070-3", 1, null, 2 },
                    { 1704, 4, "VNIS-070-4", 0, null, 2 },
                    { 1705, 5, "VNIS-070-5", 1, null, 2 },
                    { 1706, 6, "VNIS-070-6", 0, null, 2 },
                    { 1707, 7, "VNIS-070-7", 1, null, 2 },
                    { 1710, 0, "VNIS-071-0", 1, null, 2 },
                    { 1711, 1, "VNIS-071-1", 0, null, 2 },
                    { 1712, 2, "VNIS-071-2", 1, null, 2 },
                    { 1713, 3, "VNIS-071-3", 0, null, 2 },
                    { 1714, 4, "VNIS-071-4", 1, null, 2 },
                    { 1715, 5, "VNIS-071-5", 0, null, 2 },
                    { 1716, 6, "VNIS-071-6", 1, null, 2 },
                    { 1717, 7, "VNIS-071-7", 0, null, 2 },
                    { 1720, 0, "VNIS-072-0", 0, null, 2 },
                    { 1721, 1, "VNIS-072-1", 1, null, 2 },
                    { 1722, 2, "VNIS-072-2", 0, null, 2 },
                    { 1723, 3, "VNIS-072-3", 1, null, 2 },
                    { 1724, 4, "VNIS-072-4", 0, null, 2 },
                    { 1725, 5, "VNIS-072-5", 1, null, 2 },
                    { 1726, 6, "VNIS-072-6", 0, null, 2 },
                    { 1727, 7, "VNIS-072-7", 1, null, 2 },
                    { 1730, 0, "VNIS-073-0", 1, null, 2 },
                    { 1731, 1, "VNIS-073-1", 0, null, 2 },
                    { 1732, 2, "VNIS-073-2", 1, null, 2 },
                    { 1733, 3, "VNIS-073-3", 0, null, 2 },
                    { 1734, 4, "VNIS-073-4", 1, null, 2 },
                    { 1735, 5, "VNIS-073-5", 0, null, 2 },
                    { 1736, 6, "VNIS-073-6", 1, null, 2 },
                    { 1737, 7, "VNIS-073-7", 0, null, 2 },
                    { 1740, 0, "VNIS-074-0", 0, null, 2 },
                    { 1741, 1, "VNIS-074-1", 1, null, 2 },
                    { 1742, 2, "VNIS-074-2", 0, null, 2 },
                    { 1743, 3, "VNIS-074-3", 1, null, 2 },
                    { 1744, 4, "VNIS-074-4", 0, null, 2 },
                    { 1745, 5, "VNIS-074-5", 1, null, 2 },
                    { 1746, 6, "VNIS-074-6", 0, null, 2 },
                    { 1747, 7, "VNIS-074-7", 1, null, 2 },
                    { 1750, 0, "VNIS-075-0", 1, null, 2 },
                    { 1751, 1, "VNIS-075-1", 0, null, 2 },
                    { 1752, 2, "VNIS-075-2", 1, null, 2 },
                    { 1753, 3, "VNIS-075-3", 0, null, 2 },
                    { 1754, 4, "VNIS-075-4", 1, null, 2 },
                    { 1755, 5, "VNIS-075-5", 0, null, 2 },
                    { 1756, 6, "VNIS-075-6", 1, null, 2 },
                    { 1757, 7, "VNIS-075-7", 0, null, 2 },
                    { 1760, 0, "VNIS-076-0", 0, null, 2 },
                    { 1761, 1, "VNIS-076-1", 1, null, 2 },
                    { 1762, 2, "VNIS-076-2", 0, null, 2 },
                    { 1763, 3, "VNIS-076-3", 1, null, 2 },
                    { 1764, 4, "VNIS-076-4", 0, null, 2 },
                    { 1765, 5, "VNIS-076-5", 1, null, 2 },
                    { 1766, 6, "VNIS-076-6", 0, null, 2 },
                    { 1767, 7, "VNIS-076-7", 1, null, 2 },
                    { 1770, 0, "VNIS-077-0", 1, null, 2 },
                    { 1771, 1, "VNIS-077-1", 0, null, 2 },
                    { 1772, 2, "VNIS-077-2", 1, null, 2 },
                    { 1773, 3, "VNIS-077-3", 0, null, 2 },
                    { 1774, 4, "VNIS-077-4", 1, null, 2 },
                    { 1775, 5, "VNIS-077-5", 0, null, 2 },
                    { 1776, 6, "VNIS-077-6", 1, null, 2 },
                    { 1777, 7, "VNIS-077-7", 0, null, 2 },
                    { 1780, 0, "VNIS-078-0", 0, null, 2 },
                    { 1781, 1, "VNIS-078-1", 1, null, 2 },
                    { 1782, 2, "VNIS-078-2", 0, null, 2 },
                    { 1783, 3, "VNIS-078-3", 1, null, 2 },
                    { 1784, 4, "VNIS-078-4", 0, null, 2 },
                    { 1785, 5, "VNIS-078-5", 1, null, 2 },
                    { 1786, 6, "VNIS-078-6", 0, null, 2 },
                    { 1787, 7, "VNIS-078-7", 1, null, 2 },
                    { 1790, 0, "VNIS-079-0", 1, null, 2 },
                    { 1791, 1, "VNIS-079-1", 0, null, 2 },
                    { 1792, 2, "VNIS-079-2", 1, null, 2 },
                    { 1793, 3, "VNIS-079-3", 0, null, 2 },
                    { 1794, 4, "VNIS-079-4", 1, null, 2 },
                    { 1795, 5, "VNIS-079-5", 0, null, 2 },
                    { 1796, 6, "VNIS-079-6", 1, null, 2 },
                    { 1797, 7, "VNIS-079-7", 0, null, 2 },
                    { 1800, 0, "VNIS-080-0", 0, null, 2 },
                    { 1801, 1, "VNIS-080-1", 1, null, 2 },
                    { 1802, 2, "VNIS-080-2", 0, null, 2 },
                    { 1803, 3, "VNIS-080-3", 1, null, 2 },
                    { 1804, 4, "VNIS-080-4", 0, null, 2 },
                    { 1805, 5, "VNIS-080-5", 1, null, 2 },
                    { 1806, 6, "VNIS-080-6", 0, null, 2 },
                    { 1807, 7, "VNIS-080-7", 1, null, 2 },
                    { 1810, 0, "VNIS-081-0", 1, null, 2 },
                    { 1811, 1, "VNIS-081-1", 0, null, 2 },
                    { 1812, 2, "VNIS-081-2", 1, null, 2 },
                    { 1813, 3, "VNIS-081-3", 0, null, 2 },
                    { 1814, 4, "VNIS-081-4", 1, null, 2 },
                    { 1815, 5, "VNIS-081-5", 0, null, 2 },
                    { 1816, 6, "VNIS-081-6", 1, null, 2 },
                    { 1817, 7, "VNIS-081-7", 0, null, 2 },
                    { 1820, 0, "VNIS-082-0", 0, null, 2 },
                    { 1821, 1, "VNIS-082-1", 1, null, 2 },
                    { 1822, 2, "VNIS-082-2", 0, null, 2 },
                    { 1823, 3, "VNIS-082-3", 1, null, 2 },
                    { 1824, 4, "VNIS-082-4", 0, null, 2 },
                    { 1825, 5, "VNIS-082-5", 1, null, 2 },
                    { 1826, 6, "VNIS-082-6", 0, null, 2 },
                    { 1827, 7, "VNIS-082-7", 1, null, 2 },
                    { 1830, 0, "VNIS-083-0", 1, null, 2 },
                    { 1831, 1, "VNIS-083-1", 0, null, 2 },
                    { 1832, 2, "VNIS-083-2", 1, null, 2 },
                    { 1833, 3, "VNIS-083-3", 0, null, 2 },
                    { 1834, 4, "VNIS-083-4", 1, null, 2 },
                    { 1835, 5, "VNIS-083-5", 0, null, 2 },
                    { 1836, 6, "VNIS-083-6", 1, null, 2 },
                    { 1837, 7, "VNIS-083-7", 0, null, 2 },
                    { 1840, 0, "VNIS-084-0", 0, null, 2 },
                    { 1841, 1, "VNIS-084-1", 1, null, 2 },
                    { 1842, 2, "VNIS-084-2", 0, null, 2 },
                    { 1843, 3, "VNIS-084-3", 1, null, 2 },
                    { 1844, 4, "VNIS-084-4", 0, null, 2 },
                    { 1845, 5, "VNIS-084-5", 1, null, 2 },
                    { 1846, 6, "VNIS-084-6", 0, null, 2 },
                    { 1847, 7, "VNIS-084-7", 1, null, 2 },
                    { 1850, 0, "VNIS-085-0", 1, null, 2 },
                    { 1851, 1, "VNIS-085-1", 0, null, 2 },
                    { 1852, 2, "VNIS-085-2", 1, null, 2 },
                    { 1853, 3, "VNIS-085-3", 0, null, 2 },
                    { 1854, 4, "VNIS-085-4", 1, null, 2 },
                    { 1855, 5, "VNIS-085-5", 0, null, 2 },
                    { 1856, 6, "VNIS-085-6", 1, null, 2 },
                    { 1857, 7, "VNIS-085-7", 0, null, 2 },
                    { 1860, 0, "VNIS-086-0", 0, null, 2 },
                    { 1861, 1, "VNIS-086-1", 1, null, 2 },
                    { 1862, 2, "VNIS-086-2", 0, null, 2 },
                    { 1863, 3, "VNIS-086-3", 1, null, 2 },
                    { 1864, 4, "VNIS-086-4", 0, null, 2 },
                    { 1865, 5, "VNIS-086-5", 1, null, 2 },
                    { 1866, 6, "VNIS-086-6", 0, null, 2 },
                    { 1867, 7, "VNIS-086-7", 1, null, 2 },
                    { 1870, 0, "VNIS-087-0", 1, null, 2 },
                    { 1871, 1, "VNIS-087-1", 0, null, 2 },
                    { 1872, 2, "VNIS-087-2", 1, null, 2 },
                    { 1873, 3, "VNIS-087-3", 0, null, 2 },
                    { 1874, 4, "VNIS-087-4", 1, null, 2 },
                    { 1875, 5, "VNIS-087-5", 0, null, 2 },
                    { 1876, 6, "VNIS-087-6", 1, null, 2 },
                    { 1877, 7, "VNIS-087-7", 0, null, 2 },
                    { 1880, 0, "VNIS-088-0", 0, null, 2 },
                    { 1881, 1, "VNIS-088-1", 1, null, 2 },
                    { 1882, 2, "VNIS-088-2", 0, null, 2 },
                    { 1883, 3, "VNIS-088-3", 1, null, 2 },
                    { 1884, 4, "VNIS-088-4", 0, null, 2 },
                    { 1885, 5, "VNIS-088-5", 1, null, 2 },
                    { 1886, 6, "VNIS-088-6", 0, null, 2 },
                    { 1887, 7, "VNIS-088-7", 1, null, 2 },
                    { 1890, 0, "VNIS-089-0", 1, null, 2 },
                    { 1891, 1, "VNIS-089-1", 0, null, 2 },
                    { 1892, 2, "VNIS-089-2", 1, null, 2 },
                    { 1893, 3, "VNIS-089-3", 0, null, 2 },
                    { 1894, 4, "VNIS-089-4", 1, null, 2 },
                    { 1895, 5, "VNIS-089-5", 0, null, 2 },
                    { 1896, 6, "VNIS-089-6", 1, null, 2 },
                    { 1897, 7, "VNIS-089-7", 0, null, 2 },
                    { 1900, 0, "VNIS-090-0", 0, null, 2 },
                    { 1901, 1, "VNIS-090-1", 1, null, 2 },
                    { 1902, 2, "VNIS-090-2", 0, null, 2 },
                    { 1903, 3, "VNIS-090-3", 1, null, 2 },
                    { 1904, 4, "VNIS-090-4", 0, null, 2 },
                    { 1905, 5, "VNIS-090-5", 1, null, 2 },
                    { 1906, 6, "VNIS-090-6", 0, null, 2 },
                    { 1907, 7, "VNIS-090-7", 1, null, 2 },
                    { 1910, 0, "VNIS-091-0", 1, null, 2 },
                    { 1911, 1, "VNIS-091-1", 0, null, 2 },
                    { 1912, 2, "VNIS-091-2", 1, null, 2 },
                    { 1913, 3, "VNIS-091-3", 0, null, 2 },
                    { 1914, 4, "VNIS-091-4", 1, null, 2 },
                    { 1915, 5, "VNIS-091-5", 0, null, 2 },
                    { 1916, 6, "VNIS-091-6", 1, null, 2 },
                    { 1917, 7, "VNIS-091-7", 0, null, 2 },
                    { 1920, 0, "VNIS-092-0", 0, null, 2 },
                    { 1921, 1, "VNIS-092-1", 1, null, 2 },
                    { 1922, 2, "VNIS-092-2", 0, null, 2 },
                    { 1923, 3, "VNIS-092-3", 1, null, 2 },
                    { 1924, 4, "VNIS-092-4", 0, null, 2 },
                    { 1925, 5, "VNIS-092-5", 1, null, 2 },
                    { 1926, 6, "VNIS-092-6", 0, null, 2 },
                    { 1927, 7, "VNIS-092-7", 1, null, 2 },
                    { 1930, 0, "VNIS-093-0", 1, null, 2 },
                    { 1931, 1, "VNIS-093-1", 0, null, 2 },
                    { 1932, 2, "VNIS-093-2", 1, null, 2 },
                    { 1933, 3, "VNIS-093-3", 0, null, 2 },
                    { 1934, 4, "VNIS-093-4", 1, null, 2 },
                    { 1935, 5, "VNIS-093-5", 0, null, 2 },
                    { 1936, 6, "VNIS-093-6", 1, null, 2 },
                    { 1937, 7, "VNIS-093-7", 0, null, 2 },
                    { 1940, 0, "VNIS-094-0", 0, null, 2 },
                    { 1941, 1, "VNIS-094-1", 1, null, 2 },
                    { 1942, 2, "VNIS-094-2", 0, null, 2 },
                    { 1943, 3, "VNIS-094-3", 1, null, 2 },
                    { 1944, 4, "VNIS-094-4", 0, null, 2 },
                    { 1945, 5, "VNIS-094-5", 1, null, 2 },
                    { 1946, 6, "VNIS-094-6", 0, null, 2 },
                    { 1947, 7, "VNIS-094-7", 1, null, 2 },
                    { 1950, 0, "VNIS-095-0", 1, null, 2 },
                    { 1951, 1, "VNIS-095-1", 0, null, 2 },
                    { 1952, 2, "VNIS-095-2", 1, null, 2 },
                    { 1953, 3, "VNIS-095-3", 0, null, 2 },
                    { 1954, 4, "VNIS-095-4", 1, null, 2 },
                    { 1955, 5, "VNIS-095-5", 0, null, 2 },
                    { 1956, 6, "VNIS-095-6", 1, null, 2 },
                    { 1957, 7, "VNIS-095-7", 0, null, 2 },
                    { 1960, 0, "VNIS-096-0", 0, null, 2 },
                    { 1961, 1, "VNIS-096-1", 1, null, 2 },
                    { 1962, 2, "VNIS-096-2", 0, null, 2 },
                    { 1963, 3, "VNIS-096-3", 1, null, 2 },
                    { 1964, 4, "VNIS-096-4", 0, null, 2 },
                    { 1965, 5, "VNIS-096-5", 1, null, 2 },
                    { 1966, 6, "VNIS-096-6", 0, null, 2 },
                    { 1967, 7, "VNIS-096-7", 1, null, 2 },
                    { 1970, 0, "VNIS-097-0", 1, null, 2 },
                    { 1971, 1, "VNIS-097-1", 0, null, 2 },
                    { 1972, 2, "VNIS-097-2", 1, null, 2 },
                    { 1973, 3, "VNIS-097-3", 0, null, 2 },
                    { 1974, 4, "VNIS-097-4", 1, null, 2 },
                    { 1975, 5, "VNIS-097-5", 0, null, 2 },
                    { 1976, 6, "VNIS-097-6", 1, null, 2 },
                    { 1977, 7, "VNIS-097-7", 0, null, 2 },
                    { 1980, 0, "VNIS-098-0", 0, null, 2 },
                    { 1981, 1, "VNIS-098-1", 1, null, 2 },
                    { 1982, 2, "VNIS-098-2", 0, null, 2 },
                    { 1983, 3, "VNIS-098-3", 1, null, 2 },
                    { 1984, 4, "VNIS-098-4", 0, null, 2 },
                    { 1985, 5, "VNIS-098-5", 1, null, 2 },
                    { 1986, 6, "VNIS-098-6", 0, null, 2 },
                    { 1987, 7, "VNIS-098-7", 1, null, 2 },
                    { 1990, 0, "VNIS-099-0", 1, null, 2 },
                    { 1991, 1, "VNIS-099-1", 0, null, 2 },
                    { 1992, 2, "VNIS-099-2", 1, null, 2 },
                    { 1993, 3, "VNIS-099-3", 0, null, 2 },
                    { 1994, 4, "VNIS-099-4", 1, null, 2 },
                    { 1995, 5, "VNIS-099-5", 0, null, 2 },
                    { 1996, 6, "VNIS-099-6", 1, null, 2 },
                    { 1997, 7, "VNIS-099-7", 0, null, 2 },
                    { 2000, 0, "VNIS-100-0", 0, null, 2 },
                    { 2001, 1, "VNIS-100-1", 1, null, 2 },
                    { 2002, 2, "VNIS-100-2", 0, null, 2 },
                    { 2003, 3, "VNIS-100-3", 1, null, 2 },
                    { 2004, 4, "VNIS-100-4", 0, null, 2 },
                    { 2005, 5, "VNIS-100-5", 1, null, 2 },
                    { 2006, 6, "VNIS-100-6", 0, null, 2 },
                    { 2007, 7, "VNIS-100-7", 1, null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1350);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1351);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1352);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1354);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1355);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1356);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1357);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1360);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1361);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1362);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1363);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1364);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1365);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1366);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1367);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1370);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1372);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1373);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1374);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1375);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1376);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1377);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1380);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1381);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1382);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1383);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1384);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1385);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1386);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1387);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1390);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1391);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1392);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1393);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1394);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1395);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1396);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1397);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1401);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1402);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1403);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1404);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1405);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1406);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1407);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1410);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1411);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1412);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1413);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1414);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1415);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1416);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1417);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1420);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1421);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1422);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1423);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1424);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1425);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1426);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1427);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1430);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1431);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1432);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1433);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1434);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1435);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1436);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1437);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1440);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1441);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1442);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1443);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1444);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1445);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1446);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1447);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1450);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1451);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1452);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1453);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1454);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1455);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1456);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1457);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1460);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1461);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1462);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1463);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1464);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1465);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1466);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1467);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1470);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1471);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1472);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1473);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1474);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1475);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1476);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1477);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1480);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1481);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1482);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1483);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1484);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1485);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1486);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1487);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1490);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1491);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1492);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1493);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1494);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1495);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1496);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1497);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1500);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1501);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1502);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1503);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1504);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1505);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1506);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1507);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1510);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1511);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1512);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1513);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1514);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1515);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1516);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1517);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1520);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1521);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1522);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1523);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1524);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1525);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1526);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1527);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1530);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1531);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1532);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1533);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1534);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1535);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1536);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1537);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1540);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1541);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1542);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1543);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1544);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1545);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1546);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1547);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1550);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1551);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1552);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1553);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1554);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1555);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1556);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1557);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1560);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1561);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1562);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1563);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1564);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1565);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1566);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1567);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1570);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1571);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1572);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1573);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1574);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1575);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1576);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1577);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1580);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1581);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1582);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1583);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1584);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1585);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1586);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1587);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1590);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1591);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1592);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1593);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1594);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1595);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1596);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1597);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1600);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1601);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1602);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1603);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1604);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1605);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1606);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1607);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1610);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1611);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1612);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1613);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1614);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1615);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1616);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1617);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1620);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1621);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1622);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1623);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1624);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1625);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1626);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1627);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1630);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1631);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1632);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1633);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1634);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1635);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1636);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1637);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1640);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1641);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1642);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1643);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1644);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1645);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1646);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1647);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1650);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1651);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1652);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1653);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1654);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1655);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1656);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1657);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1660);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1661);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1662);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1663);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1664);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1665);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1666);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1667);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1670);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1671);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1672);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1673);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1674);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1675);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1676);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1677);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1680);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1681);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1682);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1683);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1684);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1685);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1686);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1687);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1690);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1691);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1692);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1693);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1694);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1695);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1696);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1697);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1700);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1701);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1702);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1703);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1704);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1705);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1706);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1707);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1710);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1711);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1712);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1713);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1714);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1715);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1716);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1717);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1720);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1721);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1722);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1723);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1724);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1725);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1726);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1727);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1730);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1731);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1732);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1733);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1734);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1735);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1736);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1737);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1740);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1741);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1742);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1743);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1744);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1745);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1746);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1747);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1750);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1751);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1752);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1753);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1754);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1755);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1756);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1757);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1760);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1761);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1762);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1763);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1764);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1765);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1766);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1767);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1770);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1771);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1772);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1773);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1774);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1775);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1776);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1777);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1780);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1781);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1782);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1783);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1784);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1785);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1786);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1787);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1790);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1791);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1792);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1793);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1794);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1795);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1796);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1797);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1800);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1801);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1802);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1803);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1804);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1805);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1806);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1807);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1810);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1811);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1812);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1813);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1814);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1815);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1816);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1817);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1820);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1821);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1822);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1823);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1824);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1825);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1826);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1827);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1830);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1831);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1832);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1833);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1834);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1835);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1836);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1837);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1840);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1841);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1842);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1843);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1844);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1845);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1846);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1847);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1850);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1851);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1852);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1853);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1854);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1855);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1856);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1857);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1860);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1861);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1862);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1863);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1864);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1865);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1866);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1867);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1870);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1871);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1872);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1873);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1874);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1875);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1876);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1877);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1880);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1881);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1882);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1883);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1884);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1885);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1886);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1887);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1890);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1891);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1892);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1893);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1894);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1895);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1896);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1897);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1900);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1901);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1902);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1903);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1904);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1905);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1906);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1907);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1910);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1911);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1912);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1913);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1914);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1915);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1916);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1917);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1920);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1921);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1922);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1923);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1924);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1925);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1926);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1927);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1930);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1931);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1932);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1933);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1934);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1935);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1936);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1937);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1940);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1941);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1942);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1943);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1944);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1945);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1946);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1947);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1950);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1951);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1952);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1953);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1954);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1955);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1956);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1957);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1960);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1961);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1962);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1963);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1964);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1965);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1966);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1967);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1970);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1971);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1972);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1973);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1974);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1975);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1976);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1977);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1980);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1981);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1982);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1983);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1984);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1985);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1986);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1987);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1990);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1991);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1992);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1993);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1994);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1995);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1996);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 1997);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2005);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2006);

            migrationBuilder.DeleteData(
                table: "StorageSpaces",
                keyColumn: "Id",
                keyValue: 2007);

            migrationBuilder.DeleteData(
                table: "WareHouses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WareHouses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeService",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeService",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeService",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeService",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeService",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeService",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeService",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeService",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "TypeService",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeService",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ lưu trữ Container 18ft", "Kiểm kê Container 22ft - Năm", 3 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ lưu trữ Container 20ft", "Kiểm kê Container 22ft - Năm", 3 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "NameServices", "TypeService" },
                values: new object[] { "Dịch vụ lưu trữ Container 22ft", "Kiểm kê Container 22ft - Năm", 3 });
        }
    }
}
