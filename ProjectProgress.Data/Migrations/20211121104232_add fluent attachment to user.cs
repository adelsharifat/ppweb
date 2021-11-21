using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class addfluentattachmenttouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 21, 14, 12, 31, 865, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 21, 14, 12, 31, 866, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 21, 14, 12, 31, 874, DateTimeKind.Local), "YkF1TAncTWxd7jONvEg++uEh16klehZ5fnF4HfVXzHvTGnHuC7Pq4j5J2XsBzzyqTxKXV6pEit0P8zFaVJjqe533qvu5pw==", "F8iH+l5xfIJ50Wgk58rQI92UrxdmfgdPlc/HkeH80el4j8HiCh436Y9Y20GOgWYiWzOPXdp6V4PI6EexfzSITw5x29yh/A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CreatedBy",
                table: "Attachment",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AppUser_CreatedBy",
                table: "Attachment",
                column: "CreatedBy",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AppUser_CreatedBy",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_CreatedBy",
                table: "Attachment");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 21, 12, 59, 1, 595, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 21, 12, 59, 1, 597, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 21, 12, 59, 1, 604, DateTimeKind.Local), "/9wFZ8EuH+p14X6esQNzX+6PyTaoRAnFClaINmAirMtCy9lTq8LThEz5T3YBSO0qCXWVLK3ANHl6mH8uGZtzxzqaWj+/BA==", "jZCHkrgMqKyI3CN8h+5HM8N5R75Qdy/hQPpuqalvWSdQPCPGvdcyVDj5BAOii1qmfdJwMIRF157gxBUepW1ukKujoLXbXg==" });
        }
    }
}
