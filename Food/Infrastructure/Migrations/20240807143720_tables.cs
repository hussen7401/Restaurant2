using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tables");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 7, 14, 37, 19, 371, DateTimeKind.Utc).AddTicks(4427), "YAGtOMLg/HlYu6YDDnIlxA==.QAAR+7m6h2t/8wJv2jRNh56bAgcpoD1RyYSZijLCYKI=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleterId",
                table: "Tables",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4190), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4200), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4203), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4204), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4206), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4208), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4209), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4211), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4213), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4214), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4215), null, null, false });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreateAt", "DeletedAt", "DeleterId", "IsDeleted" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 594, DateTimeKind.Utc).AddTicks(4217), null, null, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 7, 13, 29, 46, 580, DateTimeKind.Utc).AddTicks(7442), "HyI2RRettL+QxPfr2jOk3g==.4YG9DTxuvntm8FY91AdwUH+JB9MTXIIevdnlWcP4cc0=" });
        }
    }
}
