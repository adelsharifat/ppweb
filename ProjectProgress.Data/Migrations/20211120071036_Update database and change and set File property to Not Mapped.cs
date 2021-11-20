using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class UpdatedatabaseandchangeandsetFilepropertytoNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Attachment");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 20, 10, 40, 35, 826, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 20, 10, 40, 35, 828, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 20, 10, 40, 35, 835, DateTimeKind.Local), "7hP4gAqqPea2LO4A3+h58i5StcxngEzmyFLG114+sIOhcvFx3Nwz05non/zNlFqxdF9AjRGyvWPY9H9evN3m+se+DM2K5A==", "vd9DKB6oDIQv4JV+7iY5Kv3fx4eEWycpV2jYFVKSu0/MswNaH4fLWF2hf9N7uGC7BXl3JzbgCzxQtG6H8rknwX7Zb+qIPA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Attachment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 20, 10, 38, 12, 729, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 20, 10, 38, 12, 731, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 20, 10, 38, 12, 738, DateTimeKind.Local), "VXJxe6tL/6h38wrtnaPOT9noYzmeMjjfmAmo9pbRj59ItP+qnOp9hHyDkAwa2Fd4AJLX9/vcJTplYwo+DjeFIfTTmXtP/Q==", "zjRX5IwwHNrkVuPzC4NvLWwQ+aesBFkcdHXUMkz6iIp+IuqGZh3nf+j9JKDgwbxWNEWkcxKyyZl2xHb02avQb0bSuRhuzw==" });
        }
    }
}
