using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class ChangeTokenTableNameandRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_AppUser_CreatedBy",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "RefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_Token_CreatedBy",
                table: "RefreshToken",
                newName: "IX_RefreshToken_CreatedBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AppUser",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "AppUser",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AppRole",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "AppRole",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RefreshToken",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "RefreshToken",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(2021, 10, 25, 13, 52, 33, 229, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(2021, 10, 25, 13, 52, 33, 231, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "Password", "Salt" },
                values: new object[] { null, new DateTime(2021, 10, 25, 13, 52, 33, 238, DateTimeKind.Local), "yFr8S8rHALVVetTuWXWBVKGXQZxnWsd6AaMOaF+/EUll6MDMsTvxFLxGryZsFMueY593xPd1vNoXNV+umiBGslghvfE2Lw==", "/zo0ZfGtBATvfi3uTd8nbV0hbqD/LiXq4LTJw8umur54eo4FRRujZsRp2RgCeVzMgR6f7B+TGY+524P+YI/5tTwvzo4ySA==" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AppUser_CreatedBy",
                table: "RefreshToken",
                column: "CreatedBy",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AppUser_CreatedBy",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "Token");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_CreatedBy",
                table: "Token",
                newName: "IX_Token_CreatedBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AppUser",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "AppUser",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AppRole",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "AppRole",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Token",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Token",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { 0, new DateTime(2021, 10, 25, 13, 49, 24, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { 0, new DateTime(2021, 10, 25, 13, 49, 24, 253, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "Password", "Salt" },
                values: new object[] { 0, new DateTime(2021, 10, 25, 13, 49, 24, 261, DateTimeKind.Local), "6oKNDQgVmE9dnNLTQlKsWNAHPJPeyq2RkqfJIpWiM3HQvMv1mm50wigOewHZ0098PWh4yDF8NHcO+sgeoir5eIKkuLA94g==", "sUSRpGdnw62mgaR4xgW0+T+cm9iaQS3nMxo22dUo+WDSxwezDMijQCrM2HIQYQ7hDFub40gdy31aGjQ/bWN9GRuLNDd38A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Token_AppUser_CreatedBy",
                table: "Token",
                column: "CreatedBy",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
