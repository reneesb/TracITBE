using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trac_IT.Migrations
{
    public partial class issuetostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 4, 21, 10, 18, 615, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.CreateIndex(
                name: "IX_IssueStatuses_issueId",
                table: "IssueStatuses",
                column: "issueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStatuses_statusId",
                table: "IssueStatuses",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueStatuses_Issues_issueId",
                table: "IssueStatuses",
                column: "issueId",
                principalTable: "Issues",
                principalColumn: "issueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueStatuses_Status_statusId",
                table: "IssueStatuses",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "statusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueStatuses_Issues_issueId",
                table: "IssueStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueStatuses_Status_statusId",
                table: "IssueStatuses");

            migrationBuilder.DropIndex(
                name: "IX_IssueStatuses_issueId",
                table: "IssueStatuses");

            migrationBuilder.DropIndex(
                name: "IX_IssueStatuses_statusId",
                table: "IssueStatuses");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 3, 11, 19, 9, 723, DateTimeKind.Local).AddTicks(5918));
        }
    }
}
