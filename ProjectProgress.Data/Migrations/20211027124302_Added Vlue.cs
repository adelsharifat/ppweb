using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddedVlue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2021, 10, 27, 16, 13, 1, 928, DateTimeKind.Local), null, null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, new DateTime(2021, 10, 27, 16, 13, 1, 929, DateTimeKind.Local), null, null, "user", null, null });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Avatar", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FirstName", "LastName", "Password", "Salt", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[] { 1, null, null, new DateTime(2021, 10, 27, 16, 13, 1, 937, DateTimeKind.Local), null, null, null, null, "figwXMBSv4L7ZViuIxZJHZzxAxhBk0bXsnTkoSSs2SAFue1WuQONnn3K0Z6PEiTIp1iGutFtAYu44Aphp94i3KY5ZEf0oA==", "HtvxPsPydkDbq5sM8xvo4Z6hCgpw3SjNzP8PGR6Wfkwwvs45rtMf1wTennSHHQc1xBvaKKhM8eN1M5CWzR4fC03cn4UiOA==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
