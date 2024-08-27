using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7277), 10.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7285), 12.50m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7288), 8.25m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7291), 14.75m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7293), 18.50m });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 8, 13, 49, 7, 578, DateTimeKind.Utc).AddTicks(4862), "vyIrydG2ltwrvc9b5mmVbA==.0xjA2dSbqSxetq+HkchDJk0Ox5H193VYGK1XXIFCA7w=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MenuItems",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5787), 10.99 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5793), 12.5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5796), 8.25 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5799), 14.75 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateAt", "Price" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5801), 18.5 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5688));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5693));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 10, 8, 32, 169, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 8, 10, 8, 32, 156, DateTimeKind.Utc).AddTicks(356), "TGdUWBYiIcJ+T4dJMmqOhg==.fKaCnkbim/l0CIRKh5sPSZM7T5mhamT32PTDvXI/J2A=" });
        }
    }
}
