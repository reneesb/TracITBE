using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trac_IT.Migrations
{
    public partial class issueusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    issueId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueUser_Issues_issueId",
                        column: x => x.issueId,
                        principalTable: "Issues",
                        principalColumn: "issueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueUser_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 6, 12, 23, 32, 401, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.CreateIndex(
                name: "IX_IssueUser_issueId",
                table: "IssueUser",
                column: "issueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueUser_userId",
                table: "IssueUser",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueUser");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "issueId",
                keyValue: 1,
                column: "dateTimeCreated",
                value: new DateTime(2023, 12, 4, 21, 10, 18, 615, DateTimeKind.Local).AddTicks(5729));
        }
    }
}
