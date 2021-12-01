using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddSeenDesktopModeColumntoAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SeenDesktopMode",
                table: "AppUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2021, 12, 1, 16, 28, 40, 238, DateTimeKind.Local), "ISMvKXpXpadDiUoOSoAfww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeenDesktopMode",
                table: "AppUser");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2021, 11, 28, 13, 9, 22, 851, DateTimeKind.Local), "$HASH|V1$10000$84VEIZZKQddLzOLmelRXPgUeKpdKC4LUavU6ersN0ZlZpz8d" });
        }
    }
}
