using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class Updatedatabaseandchangesql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AppUser_UserId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_UserId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CreatebBy",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Attachment");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatebBy",
                table: "Attachment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 15, 10, 39, 46, 322, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 15, 10, 39, 46, 324, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 15, 10, 39, 46, 331, DateTimeKind.Local), "cdsoYPl+MWBqH+1XdAHFdWcTSPlzYBcAK6FW6gPmy3nG2NHQuULab3QbBj5n2kZUg9mV/ZLxFHIpcKNjGKaA2JgqJnLnvw==", "Qi6944nX33DydxF1rxhJR+rgXVImhRcQNw/1BX1uMmTIPk+V1rajxipjtZmxBDyLVlZNAXJoOOE6GQeW+KKm4cPl81LByQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_UserId",
                table: "Attachment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AppUser_UserId",
                table: "Attachment",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
