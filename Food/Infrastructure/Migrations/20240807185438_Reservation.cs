using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TableId = table.Column<int>(type: "integer", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "integer", nullable: false),
                    SpecialRequest = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifierId = table.Column<int>(type: "integer", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

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
    }
}
