using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class UpdateAttachmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Item_ObjectId",
                table: "Attachment");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectId",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatebBy",
                table: "Attachment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Item_ObjectId",
                table: "Attachment",
                column: "ObjectId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Item_ObjectId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CreatebBy",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Attachment");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectId",
                table: "Attachment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 10, 27, 16, 40, 38, 983, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 10, 27, 16, 40, 38, 985, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 10, 27, 16, 40, 38, 992, DateTimeKind.Local), "Va/jFczuGtDUE5L02MAqwO9rfZXpoEzhjOPfFZLb/6U7bywDfGofPU2ZpfvN0Y50EsUU/b3OxNvRNPvxUBPhv4TcLcrJxA==", "EywpaG7PB9N3KR20Ha/elnbW9bGOfFpPrRirs7HVLXDof+Wpc3RZVc4PKpu1EvL1RCTSm2QnN1NVoj1AL3E6Hzzaabsixg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Item_ObjectId",
                table: "Attachment",
                column: "ObjectId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
