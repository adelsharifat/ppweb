using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddedFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE DocumentStore AS FILETABLE WITH (FileTable_Directory = 'DocumentStore', FileTable_Collate_Filename = database_default);");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2021, 10, 27, 15, 43, 37, 449, DateTimeKind.Local), null, null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, new DateTime(2021, 10, 27, 15, 43, 37, 451, DateTimeKind.Local), null, null, "user", null, null });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Avatar", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FirstName", "LastName", "Password", "Salt", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[] { 1, null, null, new DateTime(2021, 10, 27, 15, 43, 37, 461, DateTimeKind.Local), null, null, null, null, "YGiiWc7FTrrY8Kr8nLJ6DCVXbsGnAzpP6F0+84T+Jn0h7c6T2S5aIedS1MYSHoU8Sgyr5eVtxzDPLe1k6/Pw6FCteXv1dQ==", "RwcG0+iyE3HSNNT8LSbdREt8TQamv404f2h0A0hIzp3x0YdqcVHetWk5IgleJAgtPHh++hFtQIC9++9bnNMWiXDOZIYRHw==", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });
        }
    }
}
