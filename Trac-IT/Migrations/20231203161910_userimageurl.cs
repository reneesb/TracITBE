using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trac_IT.Migrations
{
    public partial class userimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 3, 11, 19, 9, 723, DateTimeKind.Local).AddTicks(5918));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 1, 15, 7, 46, 16, DateTimeKind.Local).AddTicks(2894));
        }
    }
}
