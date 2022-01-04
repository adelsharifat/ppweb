using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class added_attachmentDate_column_table_attachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AttachmentDate",
                table: "Attachment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 7, 26, 5, 931, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentDate",
                table: "Attachment");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 1, 16, 28, 40, 238, DateTimeKind.Local));
        }
    }
}
