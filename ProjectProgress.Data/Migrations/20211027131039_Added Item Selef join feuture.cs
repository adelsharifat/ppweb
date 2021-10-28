using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddedItemSelefjoinfeuture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Item_ParentId",
                table: "Item",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Item_ParentId",
                table: "Item",
                column: "ParentId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Item_ParentId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ParentId",
                table: "Item");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 10, 27, 16, 13, 1, 928, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 10, 27, 16, 13, 1, 929, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 10, 27, 16, 13, 1, 937, DateTimeKind.Local), "figwXMBSv4L7ZViuIxZJHZzxAxhBk0bXsnTkoSSs2SAFue1WuQONnn3K0Z6PEiTIp1iGutFtAYu44Aphp94i3KY5ZEf0oA==", "HtvxPsPydkDbq5sM8xvo4Z6hCgpw3SjNzP8PGR6Wfkwwvs45rtMf1wTennSHHQc1xBvaKKhM8eN1M5CWzR4fC03cn4UiOA==" });
        }
    }
}
