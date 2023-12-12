using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trac_IT.Migrations
{
    public partial class secondcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_statusId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "IssueUser");

            migrationBuilder.DropIndex(
                name: "IX_Issues_statusId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "userId");

            migrationBuilder.CreateTable(
                name: "IssueStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    issueId = table.Column<int>(type: "integer", nullable: false),
                    statusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 11, 28, 20, 52, 8, 489, DateTimeKind.Local).AddTicks(299));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueStatuses");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IssueUser",
                columns: table => new
                {
                    issuesissueId = table.Column<int>(type: "integer", nullable: false),
                    usersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueUser", x => new { x.issuesissueId, x.usersId });
                    table.ForeignKey(
                        name: "FK_IssueUser_Issues_issuesissueId",
                        column: x => x.issuesissueId,
                        principalTable: "Issues",
                        principalColumn: "issueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueUser_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                columns: new[] { "dateTimeCreated", "statusId" },
                values: new object[] { new DateTime(2023, 11, 28, 20, 38, 46, 384, DateTimeKind.Local).AddTicks(6492), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_statusId",
                table: "Issues",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueUser_usersId",
                table: "IssueUser",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Status_statusId",
                table: "Issues",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "statusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
