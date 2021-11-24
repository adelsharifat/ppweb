using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectProgress.Data.Migrations
{
    public partial class AddedItemtypecolumntoitemtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemsType",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 24, 13, 32, 27, 656, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 24, 13, 32, 27, 658, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 11, 24, 13, 32, 27, 671, DateTimeKind.Local), "bTmmJrsDe9n4xbiON0o2e/3D2JtRR3QI3Ip4SxVqb0L5OkX5bySUP+/enFyMPLPfaFG9wFB7/gxOl0mJZjNnyWurszKpnQ==", "eOryIJVXKDAoTiEHwi00SinTvo4Vtxz/Xh3U+FmaBVQcX5t5fgq8Ldk4Zsg4T8mhj43257j4zftykjNv675Zn5YfwsPRuA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsType",
                table: "Item");

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
        }
    }
}
