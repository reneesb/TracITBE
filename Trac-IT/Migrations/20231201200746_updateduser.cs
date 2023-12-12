using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trac_IT.Migrations
{
    public partial class updateduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "userRole");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 1, 15, 7, 46, 16, DateTimeKind.Local).AddTicks(2894));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userRole",
                table: "Users",
                newName: "userName");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 11, 28, 20, 52, 8, 489, DateTimeKind.Local).AddTicks(299));
        }
    }
}
