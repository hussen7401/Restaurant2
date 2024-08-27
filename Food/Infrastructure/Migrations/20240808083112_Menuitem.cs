using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Menuitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifierId = table.Column<int>(type: "integer", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreateAt", "CreatorId", "Description", "IsAvailable", "ModifiedAt", "ModifierId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3890), 1, "A delicious beef burger with lettuce, tomato, and cheese.", true, null, null, "Classic Burger", 10.99 },
                    { 2, new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3895), 1, "A pizza topped with fresh vegetables and mozzarella cheese.", true, null, null, "Veggie Pizza", 12.5 },
                    { 3, new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3898), 1, "Crisp romaine lettuce with Caesar dressing and croutons.", true, null, null, "Caesar Salad", 8.25 },
                    { 4, new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3900), 1, "Spaghetti pasta served with a rich meat sauce.", true, null, null, "Spaghetti Bolognese", 14.75 },
                    { 5, new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3904), 1, "Grilled salmon fillet served with a side of vegetables.", true, null, null, "Grilled Salmon", 18.5 }
                });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 8, 8, 31, 12, 196, DateTimeKind.Utc).AddTicks(7154), "QctaoHIa4yr+VpQaactjvw==.USQWZw1/cGB6kJPL8U5n6ZiMnEzNvKKMsdsAC6OXxiQ=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 8, 7, 18, 54, 38, 10, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "PasswordHash" },
                values: new object[] { new DateTime(2024, 8, 7, 18, 54, 38, 2, DateTimeKind.Utc).AddTicks(159), "p2ZtNycFPGe3EkykxPpLpQ==.F1LCdTf5+o8MJcta2CqNFr2Oh8gMG2+K4RZ6ZFxNKDQ=" });
        }
    }
}
