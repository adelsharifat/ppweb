using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddedAppUserToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Item",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StreamId",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId",
                table: "Item",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Item_AppUser_UserId",
                table: "Item",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AppUser_UserId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_AppUser_UserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_UserId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Attachment");

            migrationBuilder.AlterColumn<string>(
                name: "StreamId",
                table: "Attachment",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
